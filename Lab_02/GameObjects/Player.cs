using Lab_02.GameObjects.Enemies;
using Lab_02.GameObjects.Environment;
using Lab_02.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects
{
    internal class Player : LevelElement
    {
        public event AttackEvent? PlayerAttacks;

        Dice attackDice = new Dice(2, 6, 2);
        Dice defenceDice = new Dice(2, 6, 0);
        public string Name { get; set; }
        int hp = 100;

        protected List<LevelElement> element;
        public Player (int x, int y, List<LevelElement> element)
        {
            Name = "Player";
            positionX = x;
            positionY = y;
            Color = ConsoleColor.DarkBlue;
            DisplayedCharacter = '@';
            this.element = element;
        }
        public int Attack()
        {
            return attackDice.Throw();
        }
        public int Defence()
        {
            return defenceDice.Throw();
        }

        private bool CheckMovementValidity (Directions direction)
        {
            switch (direction)
            {
                case Directions.left:
                    foreach (LevelElement element in element)
                    {
                        if (element.positionX == positionX - 1 && element.positionY == positionY)
                        {
                            if (element is Enemy)
                                PlayerAttacks?.Invoke(this, element,(int)EventIds.PlayerAttacks, Attack());
                            return false;
                        }
                    }
                    return true;
                case Directions.right:
                    foreach (LevelElement element in element)
                    {
                        if (element.positionX == positionX + 1 && element.positionY == positionY)
                        {
                            if (element is Enemy)
                                PlayerAttacks?.Invoke(this, element, (int)EventIds.PlayerAttacks, Attack());
                            return false;
                        }
                    }
                    return true;
                case Directions.up:
                    foreach (LevelElement element in element)
                    {
                        if (element.positionX == positionX && element.positionY == positionY - 1)
                        {
                            if (element is Enemy)
                                PlayerAttacks?.Invoke(this, element, (int)EventIds.PlayerAttacks, Attack());
                            return false;
                        }
                    }
                    return true;
                case Directions.down:
                    foreach (LevelElement element in element)
                    {
                        if (element.positionX == positionX && element.positionY == positionY + 1)
                        {
                            if (element is Enemy)
                                PlayerAttacks?.Invoke(this, element, (int)EventIds.PlayerAttacks, Attack());
                            return false;
                        }
                    }
                    return true;
                default:
                    return false;
            }
        }
        private void MoveRight ()
        {
            if (CheckMovementValidity(Directions.right))
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(' ');
                positionX++;
                Draw();
            }
        }
        private void MoveLeft ()
        {
            if (CheckMovementValidity(Directions.left))
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(' ');
                positionX--;
                Draw();
            }
        }
        private void MoveUp ()
        {
            if (CheckMovementValidity(Directions.up))
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(' ');
                positionY--;
                Draw();
            }
        }
        private void MoveDown ()
        {
            if (CheckMovementValidity(Directions.down))
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(' ');
                positionY++;
                Draw();
            }
        }
        public void Update (char input)
        {
            switch (input)
            {
                case 'a':
                case 'A':
                    MoveLeft();
                    break;
                case 'd':
                case 'D':
                    MoveRight();
                    break;
                case 'w':
                case 'W':
                    MoveUp();
                    break;
                case 's':
                case 'S':
                    MoveDown();
                    break;
                default:
                    break;
            }
        }
    }
}
