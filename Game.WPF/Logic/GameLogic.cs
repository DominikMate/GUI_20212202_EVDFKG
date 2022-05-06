using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.WPF.Logic
{
    public class GameLogic
    {
        public double Angle { get; set; }
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
        public enum GameItem
        {
            player, enemy, space, laser, heart
        }

        private int maps;
        public GameItem[,] GameMatrix { get; set; }     //ebben tárolódik az enemy, player, jutalom szívek, pozíciói
        public int Maps { get => maps; set => maps = value; }

        public List<MapData> MapDatas; //a pályák generálásához szükséges adatokat tartalmazza

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
            MapData newmap=new MapData();
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

        private GameItem ConvertToEnum(char c)
        {
            switch (c)
            {
                case 'p': return GameItem.player;
                case 'e': return GameItem.enemy;
                case 'l': return GameItem.laser;
                case 'd': return GameItem.heart;
                default: return GameItem.space;
            }
        }
        public enum Controls
        {
            Left, Right, Shoot
        }

        public void Control(Controls control) { }

        private string[] mapgenerator() { return null; }
    }
}
