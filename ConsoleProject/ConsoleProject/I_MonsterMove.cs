using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal interface I_MonsterMove
    {
        void Movement(Buffer buffer, char[,] map);
        void Move(E_Direction direction);
        E_Direction Direction();
    }
}
