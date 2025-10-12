using Lab_02.GameObjects;
using Lab_02.GameObjects.Enemies;
using Lab_02.GameObjects.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_02.Services
{
    internal class GameService
    {
        bool isGameRunning = true;
        LevelData levelData = new LevelData();
        List<LevelElement> updatableElements = new List<LevelElement>();
        LevelElement player;
        ConsoleKeyInfo input;

        public void Update(char input, LevelElement player)
        {
            foreach (var element in updatableElements)
                element.Update(input, player);
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
                        item.ElementOutOfVisionRange();
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
            //initializing the game
            Console.CursorVisible = false;
            levelData.Load("Level1.txt");
            foreach (var element in levelData.Element)
            {
                if (element is Player)
                {
                    this.player = element;
                    updatableElements.Add(element);
                }

                else if (element is not Wall)
                {
                    updatableElements.Add(element);
                }
            }
            //game loop
            while (isGameRunning)
            {
                HandleVisionRange();
                input = Console.ReadKey(true);
                Update(input.KeyChar, player);
            }
        }
    }
}
