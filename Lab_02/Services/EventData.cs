using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.Services
{
    public delegate void AttackEvent(object sender, object reciever, int eventId, int damage);

    public enum EventIds
    {
        PlayerAttacks,
        RatAttacks,
        SnakeAttacks,
    }
}
