using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects.Enemies
{
    internal class Snake : Enemy
    {
        Dictionary<int, char> directions;
        LevelElement player;
        public Snake(int x, int y, List<LevelElement> element)
        {
            DisplayedCharacter = 's';
            positionX = x;
            positionY = y;
            Color = ConsoleColor.DarkGreen;
            directions = new Dictionary<int, char>();
            directions.Add(1, 'a');
            directions.Add(2, 'd');
            directions.Add(3, 'w');
            directions.Add(4, 's');
            this.element = element;
        }
        private bool CheckMovementValidity(char input)
        {
            switch (input)
            {
                case 'a':
                case 'A':
                    foreach (LevelElement element in element)
                    {
                        if (element.positionX == positionX - 1 && element.positionY == positionY)
                        {
                            return false;
                        }
                    }
                    return true;
                case 'd':
                case 'D':
                    foreach (LevelElement element in element)
                    {
                        if (element.positionX == positionX + 1 && element.positionY == positionY)
                        {
                            return false;
                        }
                    }
                    return true;
                case 'w':
                case 'W':
                    foreach (LevelElement element in element)
                    {
                        if (element.positionX == positionX && element.positionY == positionY - 1)
                        {
                            return false;
                        }
                    }
                    return true;
                case 's':
                case 'S':
                    foreach (LevelElement element in element)
                    {
                        if (element.positionX == positionX && element.positionY == positionY + 1)
                        {
                            return false;
                        }
                    }
                    return true;
                default:
                    return false;
            }
        }
        private void MoveRight(char input)
        {
            if (CheckMovementValidity(input))
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(' ');
                positionX++;
                Draw();
            }
        }
        private void MoveLeft(char input)
        {
            if (CheckMovementValidity(input))
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(' ');
                positionX--;
                Draw();
            }
        }
        private void MoveUp(char input)
        {
            if (CheckMovementValidity(input))
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(' ');
                positionY--;
                Draw();
            }
        }
        private void MoveDown(char input)
        {
            if (CheckMovementValidity(input))
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(' ');
                positionY++;
                Draw();
            }
        }
        public override void Update(char input, LevelElement player)
        {

            if (IsVisible)
            {
                var chosenDirection = new Random();
                double distanceToPlayer;
                distanceToPlayer = Math.Round(Math.Sqrt(Math.Abs(player.positionY - positionY) * Math.Abs(player.positionY - positionY) + Math.Abs(player.positionX - positionX) * Math.Abs(player.positionX - positionX)));
                if (distanceToPlayer < 3)
                {
                    switch (input)
                    {
                        case 'a':
                        case 'A':
                            MoveLeft(input);
                            break;
                        case 'd':
                        case 'D':
                            MoveRight(input);
                            break;
                        case 'w':
                        case 'W':
                            MoveUp(input);
                            break;
                        case 's':
                        case 'S':
                            MoveDown(input);
                            break;
                        default:
                            break;

                    }
                }
            }
        }
    }
}
