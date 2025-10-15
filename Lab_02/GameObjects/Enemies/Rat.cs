using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects.Enemies
{
    internal class Rat : Enemy
    {
        public Rat (int x , int y, List<LevelElement> element)
        {
            Name = "Rat";
            hp = 10;
            DisplayedCharacter = 'r';
            positionX = x;
            positionY = y;
            Color = ConsoleColor.DarkRed;
            this.element = element;
            AttackDice = new Dice(1, 6, 3);
            DefenceDice = new Dice(1, 6, 1);
        }
        public override void Update(LevelElement player)
        {
            if (IsVisible)
            {
                var chosenDirection = new Random();
                switch (chosenDirection.Next(1, 5))
                {
                    case 1:
                        MoveLeft();
                        break;
                    case 2:
                        MoveRight();
                        break;
                    case 3:
                        MoveUp();
                        break;
                    case 4:
                        MoveDown();
                        break;
                    default:
                        break;

                }
            }

        }
        
    }
}
