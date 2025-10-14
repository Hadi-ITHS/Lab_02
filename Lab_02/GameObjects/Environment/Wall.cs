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
        public Wall(int x, int y) 
        {
            DisplayedCharacter = '#';
            Color = ConsoleColor.White;
            positionX = x;
            positionY = y;
        }
    }
}
