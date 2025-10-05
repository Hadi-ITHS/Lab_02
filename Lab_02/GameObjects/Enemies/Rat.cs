using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.GameObjects.Enemies
{
    internal class Rat : Enemy
    {
        public Rat (int x , int y)
        {
            positionX = x;
            positionY = y;
        }
        public override void Update()
        {

        }
    }
}
