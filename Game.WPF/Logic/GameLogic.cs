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
        Size area;

        public List<Enemy> Enemys { get; set; }
        public IPlayer Player;
        public class MapData
        {
            public int enemyskill { get; set; }
            public int heartspawnchance { get; set; }
            public bool miniboss { get; set; }
            public int minibossspawnchance { get; set; }
            public bool boss { get; set; }

        }
        public GameLogic()
        {
            MapDatas = new List<MapData>();
            CompletedLevels(Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Levels"), "complevels.lvl").First());
            var path = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Levels"), "*.lvl");
            foreach (var item in path)
            {
                LoadMapData(item);
            }
        }
        //public enum GameItem
        //{
        //    player, enemy, space, laser, heart
        //}

        private int maps;
        //public GameItem[,] GameMatrix { get; set; }     //ebben tárolódik az enemy, player, jutalom szívek, pozíciói
        public int Maps { get => maps; set => maps = value; }

        public List<MapData> MapDatas { get; set; } //a pályák generálásához szükséges adatokat tartalmazza

        private void CompletedLevels(string path) //ez a menüben lévő pályákat kéri be, hogy melyek azok amiket már megcsináltunk
        {
            int lvl = 1;
            if (int.TryParse(File.ReadAllText(path), out lvl) && lvl >= 1 && lvl <= 10)
            {
                maps = lvl;
            }
            else
            {
                maps = 1;
            }

        }
        private void LoadMapData(string path)
        {
            MapData newmap = new MapData();
            string[] lines = File.ReadAllLines(path);
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

            SoundPlayer splayer = new SoundPlayer();
            splayer.SoundLocation = "gameplaysong.wav";
            splayer.PlayLooping();

            this.area = area;
            Enemys = new List<Enemy>();
            for (int i = 0; i < 4* MapDatas[maps].enemyskill; i++)
            {
                Enemys.Add(new Enemy(area, MapDatas[maps].enemyskill));
            }
        }
        public void SetupPlayer(IPlayer player)
        {
            this.Player = player;
        }
        public void TimeStep(Size area)
        {
            for (int i = 0; i < Enemys.Count; i++)
            {
                bool inside = Enemys[i].Move(area);
                if (!inside)
                {
                    Enemys.RemoveAt(i);
                    Enemys.Add(new Enemy(area, MapDatas[maps].enemyskill));
                }
                else
                {
                    Rect enemyRect = new Rect(Enemys[i].PEnemy.X + 50, Enemys[i].PEnemy.Y, (area.Width / 10), (area.Height / 6));
                    Rect shipRect = new Rect((area.Width / 2) - ((area.Width / 6) / 2) + Player.PlayerPos, (area.Height * 0.9) - ((area.Height / 6) / 2), (area.Width / 6), (area.Height / 6));
                    if (enemyRect.IntersectsWith(shipRect))
                    {
                        Enemys.RemoveAt(i);
                        Enemys.Add(new Enemy(area, MapDatas[maps].enemyskill));
                        Player.HP--;
                        OneDamage?.Invoke(this, null);

                    }
                    foreach (var item in Player.Lasers.ToList())
                    {
                        Rect laserRect = new Rect(item.LaserPoint.X, item.LaserPoint.Y, (area.Width / 96) , (area.Height / 16));

                        if (laserRect.IntersectsWith(enemyRect))
                        {
                            Player.Lasers.Remove(item);
                            Enemys.RemoveAt(i);
                            Enemys.Add(new Enemy(area, MapDatas[maps].enemyskill));
                        }
                    }
                }
            }
            Changed?.Invoke(this, null);
        }
    }
}
