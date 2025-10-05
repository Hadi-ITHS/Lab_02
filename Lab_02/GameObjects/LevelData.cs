using Lab_02.GameObjects.Enemies;
using Lab_02.GameObjects.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects
{
    internal class LevelData
    {
        private List<LevelElement> element = new List<LevelElement>();
        public List<LevelElement> Element 
        {
            get { return element; }
        }

        public void Load (string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    int currentX = 1;
                    int currentY = 1;

                    while (!sr.EndOfStream)
                    {
                        switch ((char)sr.Read())
                        {
                            case '#':
                                Wall wall = new Wall(currentX, currentY);
                                this.element.Add(wall);
                                currentX++;
                                break;
                            case 'r':
                                Rat rat = new Rat(currentX, currentY);
                                this.element.Add(rat);
                                currentX++;
                                break;
                            case 's':
                                Snake snake = new Snake(currentX, currentY);
                                this.element.Add(snake);
                                currentX++;
                                break;
                            case '@':
                                Player player = new Player(currentX, currentY);
                                this.element.Add(player);
                                currentX++;
                                break;
                            case '\n':
                                currentY++;
                                currentX = 1;
                                break;
                            default:
                                currentX++;
                                break;
                        }
                    }
                }
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }            
        }
    }
}
