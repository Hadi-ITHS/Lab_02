using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_02.GameObjects;
using Lab_02.GameObjects.Environment;

namespace Lab_02.Services
{
    internal class GameService
    {
        LevelData levelData = new LevelData();
        ConsoleKeyInfo input;
        //Find a way to send the list that lives inside level data as argument to the update position method
        public void update(char input)
        {
            foreach (var item in levelData.Element)
            {
                if (item is not Wall)
                {
                    item.UpdatePosition(input, levelData.Element);
                }
            }
        }
        
        public void StartGame()
        {
            levelData.Load("Level1.txt");
            for (int i = 0; i < 1; i--)
            {
                input = Console.ReadKey(true);
                update(input.KeyChar);
            }
        }
    }
}
