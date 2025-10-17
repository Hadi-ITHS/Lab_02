using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects.Enemies
{
    internal class Snake : Enemy
    {
        LevelElement player;
        public Snake(int x, int y, List<LevelElement> element)
        {
            Name = "Snake";
            hp = 25;
            DisplayedCharacter = 's';
            positionX = x;
            positionY = y;
            Color = ConsoleColor.DarkGreen;
            AttackDice = new Dice(3, 4, 2);
            DefenceDice = new Dice(1, 8, 5);
            this.element = element;
        }
        public override void Update(LevelElement player)
        {
            if (IsVisible)
            {
                double distanceToPlayer = Math.Round(Math.Sqrt(Math.Abs(player.positionY - positionY) * Math.Abs(player.positionY - positionY) + Math.Abs(player.positionX - positionX) * Math.Abs(player.positionX - positionX)));
                if (distanceToPlayer < 3)
                {
                    switch(DetectPlayerPosition(player))
                    {
                        case Directions.right:
                            MoveLeft();
                            break;
                        case Directions.left:
                            MoveRight();
                            break;
                        case Directions.up:
                            MoveDown();
                            break;
                        case Directions.down:
                            MoveUp();
                            break;
                    }
                }
            }
        }
        private Directions DetectPlayerPosition(LevelElement player)
        {
            int difX = player.positionX - positionX;
            int difY = player.positionY - positionY;
            if (difX > 0)
                return Directions.right;
            else if (difX < 0)
                return Directions.left;
            else if (difY > 0)
                return Directions.down;
            else
                return Directions.up;

        }
    }
}
