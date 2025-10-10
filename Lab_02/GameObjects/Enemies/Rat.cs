using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects.Enemies
{
    internal class Rat : Enemy
    {
        Dictionary<int, char> directions;
        public Rat (int x , int y, List<LevelElement> element)
        {
            DisplayedCharacter = 'r';
            positionX = x;
            positionY = y;
            Color = ConsoleColor.DarkRed;
            this.element = element;
            directions = new Dictionary<int, char> ();
            directions.Add(1, 'a');
            directions.Add(2, 'd');
            directions.Add(3, 'w');
            directions.Add(4, 's');
        }
        public override void Update(char input, LevelElement player)
        {
            if (IsVisible)
            {
                var chosenDirection = new Random();
                switch (chosenDirection.Next(1, 5))
                {
                    case 1:
                        MoveLeft(directions[1]);
                        break;
                    case 2:
                        MoveRight(directions[2]);
                        break;
                    case 3:
                        MoveUp(directions[3]);
                        break;
                    case 4:
                        MoveDown(directions[4]);
                        break;
                    default:
                        break;

                }
            }

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
    }
}
