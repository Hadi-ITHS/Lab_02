using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects
{
    internal class Player : LevelElement
    {
        public Player (int x, int y)
        {
            positionX = x;
            positionY = y;
            Color = ConsoleColor.DarkBlue;
            DisplayedCharacter = '@';
        }
        private void MoveRight ()
        {
            Console.SetCursorPosition (positionX, positionY);
            Console.Write(' ');
            positionX++;
            Draw();
        }
        private void MoveLeft ()
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(' ');
            positionX--;
            Draw();
        }
        private void MoveUp ()
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(' ');
            positionY--;
            Draw();
        }
        private void MoveDown ()
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(' ');
            positionY++;
            Draw();
        }
        public override void Update (char input)
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
