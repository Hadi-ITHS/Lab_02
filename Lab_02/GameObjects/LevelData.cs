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
                    int spaceToPreviousElement = 0;
                    bool isFirstObjectInLine = false;
                    //reading the file and creating objects
                    while (!sr.EndOfStream)
                    {
                        switch ((char)sr.Read())
                        {
                            case '#':
                                Wall wall = new Wall(currentX, currentY, spaceToPreviousElement, isFirstObjectInLine);
                                this.element.Add(wall);
                                currentX++;
                                spaceToPreviousElement = 0;
                                if (isFirstObjectInLine)
                                    isFirstObjectInLine = false;
                                break;
                            case 'r':
                                Rat rat = new Rat(currentX, currentY, spaceToPreviousElement);
                                this.element.Add(rat);
                                currentX++;
                                spaceToPreviousElement = 0;
                                break;
                            case 's':
                                Snake snake = new Snake(currentX, currentY, spaceToPreviousElement);
                                this.element.Add(snake);
                                currentX++;
                                spaceToPreviousElement = 0;
                                break;
                            case '@':
                                Player player = new Player(currentX, currentY, spaceToPreviousElement);
                                this.element.Add(player);
                                currentX++;
                                spaceToPreviousElement = 0;
                                break;
                            case '\n':
                                currentY++;
                                currentX = 1;
                                spaceToPreviousElement = 0;
                                isFirstObjectInLine = true;
                                break;
                            default:
                                currentX++;
                                spaceToPreviousElement++;
                                break;
                        }
                    }
                }
                foreach (LevelElement item in this.element)
                {
                    item.Draw();
                }
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }            
        }
    }
}
