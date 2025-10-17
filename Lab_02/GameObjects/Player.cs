using Lab_02.GameObjects.Enemies;
using Lab_02.GameObjects.Environment;
using Lab_02.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
        public int HP { get; set; }

        protected List<LevelElement> element;
        public Player (int x, int y, List<LevelElement> element)
        {
            HP = 100;
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
            int defence = Defence();
            int attackResult = damage - defence;
            var attacker = (Enemy)sender;
            if (eventId == 1) //If enemy does an attack
            {
                DefenceCalculation(attackResult, attacker, damage, defence, eventId, 21);
                if (HP > 0)
                    PlayerAttacks?.Invoke(this, sender, (int)EventIds.PlayerCounterAttacks, Attack());
            }
            else if (eventId == 5) //If enemy does a counter attack
            {
                DefenceCalculation(attackResult, attacker, damage, defence, eventId, 22);
            }
            if (HP <= 0)
            {
                PlayerDead?.Invoke(this, sender, (int)EventIds.PlayerDead);
                return;
            }
        }
        private void DefenceCalculation(int attackResult, Enemy attacker, int damage, int defence, int eventId, int messegeLine)
        {
            if (eventId == 1) //If enemy does an attack
            {
                if (attackResult > 0)
                {
                    HP -= attackResult;
                    Console.SetCursorPosition(0, messegeLine);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Player is getting attacked by {attacker.Name}. Defence Dice: {defenceDice.ToString()} | Attack Damage: {damage} | Defence Damage: {defence} | HP: {HP}");
                }
                else
                {
                    Console.SetCursorPosition(0, messegeLine);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Player has been attacked by {attacker.Name}. But the defence dice was greater than the attack dice. No damage is done!");
                }
            }
            else if (eventId == 5) //If enemy does a counter attack
            {
                if (attackResult > 0)
                {
                    HP -= attackResult;
                    Console.SetCursorPosition(0, messegeLine);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{attacker.Name} has done a counter attack on Player. Defence Dice: {defenceDice.ToString()} | Attack Damage: {damage} | Defence Damage: {defence} | HP: {HP}");
                }
                else
                {
                    Console.SetCursorPosition(0, messegeLine);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{attacker.Name} has done a counter attack on Player. But the defence dice was greater than the attack dice. No damage is done!");
                }
            }
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