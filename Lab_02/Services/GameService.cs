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

        public void update(char input)
        {
            foreach (var item in levelData.Element)
            {
                if (item is not Wall)
                {
                    item.Update(input);
                }
            }
        }
        
        public void StartGame()
        {
            Console.CursorVisible = false;
            levelData.Load("Level1.txt");
            for (int i = 0; i < 1; i--)
            {
                input = Console.ReadKey(true);
                update(input.KeyChar);
            }
        }
    }
}
