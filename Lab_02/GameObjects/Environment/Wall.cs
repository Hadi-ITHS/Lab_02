using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects.Environment
{
    internal class Wall : LevelElement
    {
        public bool isFirstObjectInLine { get; set; }
        public Wall(int x, int y, int spaceToNextElement, bool isFirstObjectInLine) 
        {
            DisplayedCharacter = '#';
            Color = ConsoleColor.White;
            this.spaceToPreviousElement = spaceToNextElement;
            this.isFirstObjectInLine = isFirstObjectInLine;
            positionX = x;
            positionY = y;
        }
        public override void Draw()
        {
            if (isFirstObjectInLine)
                Console.Write('\n');
            if (spaceToPreviousElement > 0)
            {
                for (int i = 1; i <= spaceToPreviousElement; i++)
                {
                    Console.Write(' ');
                }
            }
            Console.ForegroundColor = Color;
            Console.Write(DisplayedCharacter);
        }
    }
}
