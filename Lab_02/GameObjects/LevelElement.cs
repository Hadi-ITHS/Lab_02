using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects
{
    internal abstract class LevelElement
    {
        public int positionX { get; set; }
        public int positionY { get; set; }
        public char DisplayedCharacter { get; set; }
        public ConsoleColor Color { get; set; }
        protected List<LevelElement> element;
        public abstract void Update(char input);
        public void Draw()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(DisplayedCharacter);
        }
    }
}
