using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects
{
    internal abstract class LevelElement
    {
        public int spaceToPreviousElement { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
        public char DisplayedCharacter { get; set; }
        public ConsoleColor Color { get; set; }
        public virtual void Draw() 
        {
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
