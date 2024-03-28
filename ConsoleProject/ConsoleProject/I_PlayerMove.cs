using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal interface I_PlayerMove
    {
        void PlayerInput(Buffer buffer);
        void PlayerKeyInput(Buffer buffer, ConsoleKeyInfo key);
        void IsMove(Buffer buffer, ConsoleKeyInfo key, E_Direction e_Direction);
        void MoveMent(ConsoleKeyInfo key);
    }
}
