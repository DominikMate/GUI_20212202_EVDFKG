using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.WPF.Logic
{
    public class GameLogic : IGameModel
    {
        public event EventHandler Changed;
        public event EventHandler OneDamage;
        public event EventHandler TwoDamage;
        public event EventHandler ThreeDamage;
        Size area;
        Size PlayerSize;
        ITimerLogic timer;
        Random random;

        public List<Enemy> Enemys { get; set; }
        public List<Enemy> miniEnemys { get; set; }
        public List<Enemy> bossEnemys { get; set; }

        public int EnemyKillCounter { get; set; }
        public int miniEnemyKillCounter { get; set; }
        public int bossEnemyKillCounter { get; set; }
        public IPlayer Player;
        public class MapData
        {
            public int levelnum { get; set; }
            public int enemyskill { get; set; }
            public int heartspawnchance { get; set; }
            public bool miniboss { get; set; }
            public int minibossspawnchance { get; set; }
            public bool boss { get; set; }

        }
        public GameLogic()
        {
            random = new Random();
            MapDatas = new List<MapData>();
            CompletedLevels(Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Levels"), "complevels.lvlc").First());

            var path = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Levels"), "*.lvl");
            foreach (var item in path)
            {
                LoadMapData(item);
            }
            MapDatas.Sort((x, y) => x.levelnum.CompareTo(y.levelnum));
        }
        //public enum GameItem
        //{
        //    player, enemy, space, laser, heart
        //}

        private int maps;
        private int loadedlevel;
        //public GameItem[,] GameMatrix { get; set; }     //ebben tárolódik az enemy, player, jutalom szívek, pozíciói
        public int Maps { get => maps; set => maps = value; }
        public int Loadedlevel { get => loadedlevel; set => loadedlevel = value; }

        public List<MapData> MapDatas { get; set; } //a pályák generálásához szükséges adatokat tartalmazza

        private void CompletedLevels(string path) //ez a menüben lévő pályákat kéri be, hogy melyek azok amiket már megcsináltunk
        {
            int lvl = 0;
            if (int.TryParse(File.ReadAllText(path), out lvl) && lvl >= 1 && lvl <= 10)
            {
                maps = lvl-1;
            }
            else
            {
                maps = 0;
            }
        }
        public void SetupTimer(ITimerLogic timer)
        {
            this.timer = timer;
        }     
        private void LoadedLevel(string path) //ez a menüben lévő pályákat kéri be, hogy melyek azok amiket már megcsináltunk
        {
            int lvl = 0;
            if (int.TryParse(File.ReadAllText(path), out lvl) && lvl >= 1 && lvl <= 10)
            {
                loadedlevel = lvl-1;
            }
            else
            {
                loadedlevel = 0;
            }
        }
        private void LoadMapData(string path)
        {
            MapData newmap = new MapData();
            string[] lines = File.ReadAllLines(path);
            newmap.levelnum = int.Parse(path.Split(new string[] { "level" },
                StringSplitOptions.None)[1].Split(new string[] { ".lvl" },
                StringSplitOptions.None)[0]);
            for (int i = 0; i < lines.Length; i++)
            {
                string prop = lines[i].Split(':')[0];
                switch (prop)
                {
                    case "enemyskill":
                        newmap.enemyskill = int.Parse(lines[i].Split(':')[1]);
                        break;
                    case "heartspawnchance":
                        newmap.heartspawnchance = int.Parse(lines[i].Split(':')[1]);
                        break;
                    case "miniboss":
                        newmap.miniboss = bool.Parse(lines[i].Split(':')[1]);
                        break;
                    case "minibossspawnchance":
                        newmap.minibossspawnchance = int.Parse(lines[i].Split(':')[1]);
                        break;
                    case "boss":
                        newmap.boss = bool.Parse(lines[i].Split(':')[1]);
                        break;
                    default:
                        break;
                }
            }

            MapDatas.Add(newmap);
        }

        //private GameItem ConvertToEnum(char c)
        //{
        //    switch (c)
        //    {
        //        case 'p': return GameItem.player;
        //        case 'e': return GameItem.enemy;
        //        case 'l': return GameItem.laser;
        //        case 'd': return GameItem.heart;
        //        default: return GameItem.space;
        //    }
        //}


        public void SetupSizes(Size area)
        {
            this.area = area;
            this.PlayerSize.Width = area.Width / 6;
            this.PlayerSize.Height = area.Height / 6;
            Enemys = new List<Enemy>();
            miniEnemys = new List<Enemy>();
            bossEnemys = new List<Enemy>();

            for (int i = 0; i < MapDatas[loadedlevel].enemyskill; i++)
            {
                Enemys.Add(new Enemy(area, MapDatas[loadedlevel].enemyskill, false, false));
            }
        }
        public void SetupPlayer(IPlayer player)
        {
            this.Player = player;
        }
        public void TimeStep(Size area)
        {
            if (MapDatas[loadedlevel].miniboss && timer.TimerPos == 12000 && timer.TimerPos == 40000)
            {
                for (int i = 0; i < MapDatas[loadedlevel].enemyskill; i++)
                {
                    miniEnemys.Add(new Enemy(area, MapDatas[loadedlevel].enemyskill, MapDatas[loadedlevel].miniboss, false));
                }
            }
            if (MapDatas[loadedlevel].boss && timer.TimerPos == 80000)
            {
                for (int i = 0; i < MapDatas[loadedlevel].enemyskill; i++)
                {
                    bossEnemys.Add(new Enemy(area, MapDatas[loadedlevel].enemyskill, false, MapDatas[loadedlevel].boss));
                }
            }
            for (int i = 0; i < Enemys.Count; i++)
            {
                bool inside = Enemys[i].Move(area);
                if (!inside)
                {
                    OneDamage?.Invoke(this, null);
                    Enemys.RemoveAt(i);
                    Enemys.Add(new Enemy(area, MapDatas[loadedlevel].enemyskill));
                }
                else
                {
                    Rect enemyRect = new Rect(Enemys[i].PEnemy.X + (PlayerSize.Width / 4), Enemys[i].PEnemy.Y, (PlayerSize.Width / 2), PlayerSize.Height);
                    Rect shipRect = new Rect((area.Width / 2) - ((area.Width / 6) / 2) + Player.PlayerPos + (PlayerSize.Width / 4), (area.Height * 0.9) - ((area.Height / 6) / 2), PlayerSize.Width / 2, PlayerSize.Height);

                    if (enemyRect.IntersectsWith(shipRect))
                    {
                        Enemys.RemoveAt(i);
                        Enemys.Add(new Enemy(area, MapDatas[loadedlevel].enemyskill));
                        OneDamage?.Invoke(this, null);

                    }
                    foreach (var item in Player.Lasers.ToList())
                    {
                        Rect laserRect = new Rect(item.LaserPoint.X, item.LaserPoint.Y, (area.Width / 96) , (area.Height / 16));

                        if (laserRect.IntersectsWith(enemyRect))
                        {
                            Player.Lasers.Remove(item);
                            Enemys.RemoveAt(i);
                            Enemys.Add(new Enemy(area, MapDatas[loadedlevel].enemyskill));
                        }
                    }
                }
            }
            for (int i = 0; i < miniEnemys.Count; i++)
            {
                bool inside = miniEnemys[i].Move(area);
                if (!inside)
                {
                    TwoDamage?.Invoke(this, null);
                    miniEnemys.RemoveAt(i);
                    miniEnemys.Add(new Enemy(area, MapDatas[loadedlevel].enemyskill, true, false));
                }
                else
                {
                    Rect enemyRect = new Rect(miniEnemys[i].PEnemy.X + (PlayerSize.Width / 4), miniEnemys[i].PEnemy.Y, (PlayerSize.Width / 2), PlayerSize.Height);
                    Rect shipRect = new Rect((area.Width / 2) - ((area.Width / 6) / 2) + Player.PlayerPos + (PlayerSize.Width / 4), (area.Height * 0.9) - ((area.Height / 6) / 2), PlayerSize.Width / 2, PlayerSize.Height);

                    if (enemyRect.IntersectsWith(shipRect))
                    {
                        miniEnemys.RemoveAt(i);
                        miniEnemys.Add(new Enemy(area, MapDatas[loadedlevel].enemyskill));
                        TwoDamage?.Invoke(this, null);

                    }
                    foreach (var item in Player.Lasers.ToList())
                    {
                        Rect laserRect = new Rect(item.LaserPoint.X, item.LaserPoint.Y, (area.Width / 96), (area.Height / 16));

                        if (laserRect.IntersectsWith(enemyRect))
                        {
                            Player.Lasers.Remove(item);
                            miniEnemys.RemoveAt(i);
                            miniEnemys.Add(new Enemy(area, MapDatas[loadedlevel].enemyskill,true, false));
                        }
                    }
                }
            }
            for (int i = 0; i < bossEnemys.Count; i++)
            {
                bool inside = bossEnemys[i].Move(area);
                if (!inside)
                {
                    ThreeDamage?.Invoke(this, null);
                    bossEnemys.RemoveAt(i);
                    bossEnemys.Add(new Enemy(area, MapDatas[loadedlevel].enemyskill,false, true));
                }
                else
                {
                    Rect enemyRect = new Rect(bossEnemys[i].PEnemy.X + (PlayerSize.Width / 4), bossEnemys[i].PEnemy.Y, (PlayerSize.Width / 2), PlayerSize.Height);
                    Rect shipRect = new Rect((area.Width / 2) - ((area.Width / 6) / 2) + Player.PlayerPos + (PlayerSize.Width / 4), (area.Height * 0.9) - ((area.Height / 6) / 2), PlayerSize.Width / 2, PlayerSize.Height);

                    if (enemyRect.IntersectsWith(shipRect))
                    {
                        bossEnemys.RemoveAt(i);
                        bossEnemys.Add(new Enemy(area, MapDatas[loadedlevel].enemyskill, false, true));
                        ThreeDamage?.Invoke(this, null);

                    }
                    foreach (var item in Player.Lasers.ToList())
                    {
                        Rect laserRect = new Rect(item.LaserPoint.X, item.LaserPoint.Y, (area.Width / 96), (area.Height / 16));

                        if (laserRect.IntersectsWith(enemyRect))
                        {
                            Player.Lasers.Remove(item);
                            bossEnemys.RemoveAt(i);
                            bossEnemys.Add(new Enemy(area, MapDatas[loadedlevel].enemyskill));
                        }
                    }
                }
            }
            Changed?.Invoke(this, null);
        }
    }
}
