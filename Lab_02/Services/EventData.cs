using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.Services
{
    public delegate void AttackEvent(object sender, object reciever, int eventId, int damage);
    public delegate void ElementDestroyedEvent (object sender, object destroyer,int eventId);

    public enum EventIds
    {
        PlayerAttacks,
        EnemyAttacks,
        PlayerDead,
        EnemyDead,
    }
}
