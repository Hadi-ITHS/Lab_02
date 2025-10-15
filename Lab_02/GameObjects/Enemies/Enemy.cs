using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects.Enemies
{
    internal abstract class Enemy : LevelElement
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }
        protected List<LevelElement> element;
        public void OnAttackRecieved (object sender,object reciever, int eventId, int damage)
        {
            if (this.Equals(reciever))
            {
                Console.SetCursorPosition(0, 25);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{this} is getting attacked by {sender}. The damage is {damage}");
            }
        }
        public abstract void Update(LevelElement player);
        private bool CheckMovementValidity(Directions direction)
        {
            switch (direction)
            {
                case Directions.left:
                    foreach (LevelElement element in element)
                    {
                        if (element.positionX == positionX - 1 && element.positionY == positionY)
                        {
                            return false;
                        }
                    }
                    return true;
                case Directions.right:
                    foreach (LevelElement element in element)
                    {
                        if (element.positionX == positionX + 1 && element.positionY == positionY)
                        {
                            return false;
                        }
                    }
                    return true;
                case Directions.up:
                    foreach (LevelElement element in element)
                    {
                        if (element.positionX == positionX && element.positionY == positionY - 1)
                        {
                            return false;
                        }
                    }
                    return true;
                case Directions.down:
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
        protected void MoveRight()
        {
            if (CheckMovementValidity(Directions.right))
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(' ');
                positionX++;
                Draw();
            }
        }
        protected void MoveLeft()
        {
            if (CheckMovementValidity(Directions.left))
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(' ');
                positionX--;
                Draw();
            }
        }
        protected void MoveUp()
        {
            if (CheckMovementValidity(Directions.up))
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(' ');
                positionY--;
                Draw();
            }
        }
        protected void MoveDown()
        {
            if (CheckMovementValidity(Directions.down))
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(' ');
                positionY++;
                Draw();
            }
        }
        public int Attack()
        {
            return AttackDice.Throw();
        }
        public int Defence()
        {
            return DefenceDice.Throw();
        }
        public override void ElementOutOfVisionRange()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(DisplayedCharacter);
        }
    }
}
