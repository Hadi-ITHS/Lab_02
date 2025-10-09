using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects.Enemies
{
    internal class Snake : Enemy
    {
        public Snake(int x, int y, List<LevelElement> element)
        {
            DisplayedCharacter = 's';
            positionX = x;
            positionY = y;
            Color = ConsoleColor.DarkGreen;
            this.element = element;
        }
        public override void Update(char input)
        {

        }
    }
}
