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
    }
}
