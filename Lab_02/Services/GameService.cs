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
        bool isPlayerAlive = true;
        LevelData levelData = new LevelData();
        List<Enemy> updatableElements = new List<Enemy>();
        Player player;
        ConsoleKeyInfo input;

        private void Update(char input, Player player)
        {
            player.Update(input);
            foreach (var element in updatableElements)
                element.Update(player);
        }

        private void HandleVisionRange ()
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

        /*private void HandleCombat (LevelElement player, LevelElement enemy)
        {
            double distanceToPlayer;
            distanceToPlayer = Math.Round(Math.Sqrt(Math.Abs(player.positionY - enemy.positionY) * Math.Abs(player.positionY - enemy.positionY) + Math.Abs(player.positionX - enemy.positionX) * Math.Abs(player.positionX - enemy.positionX)));
            if (distanceToPlayer < 1)
            {
                player.Attack()
            }
        }*/

        public void StartGame()
        {
            //initializing the game
            Console.CursorVisible = false;
            levelData.Load("Level1.txt");
            foreach (var element in levelData.Element)
            {
                if (element is Player)
                {
                    this.player = (Player)element;
                }

                else if (element is Enemy)
                {
                    updatableElements.Add((Enemy) element);
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
