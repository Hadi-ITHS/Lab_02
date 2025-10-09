using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects.Enemies
{
    internal class Rat : Enemy
    {
        public Rat (int x , int y, int spaceToNextElement)
        {
            DisplayedCharacter = 'r';
            positionX = x;
            positionY = y;
            this.spaceToPreviousElement = spaceToNextElement;
            Color = ConsoleColor.DarkRed;
        }
        public override void Update()
        {

        }
        public override void UpdatePosition(char input, List<LevelElement> elements)
        {

        }
    }
}
