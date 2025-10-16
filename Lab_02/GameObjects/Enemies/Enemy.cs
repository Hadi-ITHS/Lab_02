using Lab_02.Services;
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
        public event AttackEvent? EnemyAttacks;
        public event DefenceEvent? EnemyDefences;
        public event ElementDestroyedEvent? EnemyDead;
        public string Name { get; set; }
        public int hp { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }
        protected List<LevelElement> element;
        public void OnAttackRecieved (object sender,object reciever, int eventId, int damage)
        {
            var attacker = (Player)sender;
            var defender = (Enemy)reciever;
            int attackResult = damage - Defence();
            if (this.Equals(reciever))
            {
                if (attackResult > 0)
                {
                    hp -= attackResult;
                    Console.SetCursorPosition(0, 23);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Enemy:\n{defender.Name} is getting attacked by {attacker.Name}. Attack Damage: {damage}, Attack Taken: {attackResult}, HP: {hp}");
                    Console.WriteLine("----------------------------------------");
                }
                else
                {
                    Console.SetCursorPosition(0, 23);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Enemy:\n{attacker.Name} has attacked {defender.Name}. But the defence dice was greater than the attack dice. No damage is done!");
                    Console.WriteLine("----------------------------------------");
                }
                if (hp <= 0)
                    EnemyDead?.Invoke(this, sender, (int)EventIds.EnemyDead);
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
                            if (element is Player)
                                EnemyAttacks?.Invoke(this, element, (int)EventIds.PlayerAttacks, Attack());
                            return false;
                        }
                    }
                    return true;
                case Directions.right:
                    foreach (LevelElement element in element)
                    {
                        if (element.positionX == positionX + 1 && element.positionY == positionY)
                        {
                            if (element is Player)
                                EnemyAttacks?.Invoke(this, element, (int)EventIds.PlayerAttacks, Attack());
                            return false;
                        }
                    }
                    return true;
                case Directions.up:
                    foreach (LevelElement element in element)
                    {
                        if (element.positionX == positionX && element.positionY == positionY - 1)
                        {
                            if (element is Player)
                                EnemyAttacks?.Invoke(this, element, (int)EventIds.PlayerAttacks, Attack());
                            return false;
                        }
                    }
                    return true;
                case Directions.down:
                    foreach (LevelElement element in element)
                    {
                        if (element.positionX == positionX && element.positionY == positionY + 1)
                        {
                            if (element is Player)
                                EnemyAttacks?.Invoke(this, element, (int)EventIds.PlayerAttacks, Attack());
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
