using Lab_02.GameObjects;
using Lab_02.GameObjects.Enemies;
using Lab_02.GameObjects.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.Services
{
    internal class GameService
    {
        LevelData levelData = new LevelData();
        LevelElement player;
        ConsoleKeyInfo input;

        public void Update(char input)
        {
            foreach (var item in levelData.Element)
            {
                if (item is not Wall)
                {
                    item.Update(input);
                }
            }
        }

        public void HandleVisionRange ()
        {
            foreach (var item in levelData.Element)
            {
                if (item is not Player)
                {
                    double distanceToPlayer;
                    distanceToPlayer = Math.Round(Math.Sqrt(Math.Abs(player.positionY - item.positionY) * Math.Abs(player.positionY - item.positionY) + Math.Abs(player.positionX - item.positionX) * Math.Abs(player.positionX - item.positionX)));
                    if (distanceToPlayer > 6)
                    {
                        item.IsVisible = false;
                        item.ElementOutOfRange();
                    }
                    else
                    {
                        item.IsVisible = true;
                        item.Draw();
                        item.IsDiscovered = true;
                    }
                }
            }
        }

        public void StartGame()
        {
            Console.CursorVisible = false;
            levelData.Load("Level1.txt");
            foreach (var player in levelData.Element)
                if (player is Player)
                    this.player = player;
            for (int i = 0; i > -1; i++)
            {
                HandleVisionRange();
                input = Console.ReadKey(true);
                Update(input.KeyChar);
            }
        }
    }
}
