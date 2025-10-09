using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects.Enemies
{
    internal class Snake : Enemy
    {
        public Snake(int x, int y)
        {
            DisplayedCharacter = 's';
            positionX = x;
            positionY = y;
            Color = ConsoleColor.DarkGreen;
        }
        public override void Update(char input)
        {

        }
    }
}
