using System;
using System.Collections.Generic;
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
            positionX = x;
            positionY = y;
        }
    }
}
