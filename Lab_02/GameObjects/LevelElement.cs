using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects
{
    internal abstract class LevelElement
    {
        public bool IsDiscovered { get; set; }
        public bool IsVisible { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
        public char DisplayedCharacter { get; set; }
        public ConsoleColor Color { get; set; }
        protected List<LevelElement> element;
        public abstract void Update(char input);
        public virtual void ElementOutOfRange ()
        {
            if (IsDiscovered)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(DisplayedCharacter);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(DisplayedCharacter);
            }
        }
        public void Draw()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(DisplayedCharacter);
        }
    }
}
