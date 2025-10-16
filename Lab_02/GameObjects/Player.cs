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
        public event DefenceEvent? PlayerDefences;
        public event ElementDestroyedEvent? PlayerDead;

        Dice attackDice = new Dice(2, 6, 2);
        Dice defenceDice = new Dice(2, 6, 0);
        public string Name { get; set; }
        int hp = 100;

        protected List<LevelElement> element;
        public Player (int x, int y, List<LevelElement> element)
        {
            IsVisible = true;
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
        public void OnAttackRecieved (object sender, object reciever, int eventId, int damage)
        {
            var attacker = (Enemy)sender;
            int attackResult = damage - Defence();
            if (attackResult > 0)
            {
                hp -= attackResult;
                Console.SetCursorPosition(0, 21);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Player is getting attacked by {attacker.Name}. Attack Damage: {damage}, Attack Taken: {attackResult}, HP: {hp}");
                Console.WriteLine();
            }
            else
            {
                Console.SetCursorPosition(0, 21);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{attacker.Name} has attacked the player. But the defence dice was greater than the attack dice. No damage is done!");
                Console.WriteLine();
            }
                if (hp <= 0)
                    PlayerDead?.Invoke(this, sender, (int)EventIds.PlayerDead);
            //Create a similar event to PlayerAttacks for player. This event will be the counter attack that player does after a defence.
            //Add a event id that defines this kind of attack is a counter attack.
            //Then in OnAttackRecieved on enemy class check if it is a counter attack, then do not do another counter attack.
            //Because we already have done it once. If we do not check this, it will be an infinite loop of attack and counter attacks.
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