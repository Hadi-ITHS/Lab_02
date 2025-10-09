using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects
{
    internal class Player : LevelElement
    {
        public Player (int x, int y, int spaceToNextElement)
        {
            positionX = x;
            positionY = y;
            this.spaceToPreviousElement = spaceToNextElement;
            Color = ConsoleColor.DarkBlue;
            DisplayedCharacter = '@';
        }

        public override void UpdatePosition(char input, List<LevelElement> elements)
        {
                Console.WriteLine("Input is recieved by player");
            switch (input)
            {
                case 'a':
                case 'A':
                    Console.WriteLine("Move left");
                    break;
                case 's':
                case 'S':
                    Console.WriteLine("Move down");
                    break;
                case 'd':
                case 'D':
                    Console.WriteLine("Move right");
                    break;
                case 'w':
                case 'W':
                    Console.WriteLine("Move up");
                    break;
                default:
                    break;
            }
        }
    }
}
