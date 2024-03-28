using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class PlayerMove : Player, I_PlayerMove
    {
        private ConsoleKeyInfo m_KeyValue;

        public void PlayerInput(Buffer buffer)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo movekey = Console.ReadKey(true);

                m_KeyValue = movekey;
                PlayerKeyInput(buffer, movekey);
                EventInput(movekey);
            }
            else
            {
                Thread.Sleep(50);
                PlayerKeyInput(buffer, m_KeyValue);
            }
        }
        public void PlayerKeyInput(Buffer buffer, ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.RightArrow:
                    IsMove(buffer, key, E_Direction.RIGHT);
                    break;
                case ConsoleKey.LeftArrow:
                    IsMove(buffer, key, E_Direction.LEFT);
                    break;
                case ConsoleKey.UpArrow:
                    IsMove(buffer, key, E_Direction.UP);
                    break;
                case ConsoleKey.DownArrow:
                    IsMove(buffer, key, E_Direction.DOWN);
                    break;
            }
        }
        public void IsMove(Buffer buffer, ConsoleKeyInfo key, E_Direction e_Direction)
        {
            bool Wall = IsObject(buffer.BackBuffer, this.Wall, e_Direction);
            bool StartWall = IsObject(buffer.BackBuffer,'▩',e_Direction);
            bool Food = IsObject(buffer.BackBuffer,this.Food,e_Direction);
            bool Item = IsObject(buffer.BackBuffer, '★', e_Direction);

            if(!Wall && !StartWall)
            {
                if (Food)
                {
                    m_FoodCount++;
                    m_Score++;
                }
                if (Item)
                    NewItem();

                buffer.Draw(Road, m_PositionX, m_PositionY);
                MoveMent(key);
            }
        }
        public void MoveMent(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.RightArrow:
                    m_PositionX++;
                    break;
                case ConsoleKey.LeftArrow:
                    m_PositionX--;
                    break;
                case ConsoleKey.UpArrow:
                    m_PositionY--;
                    break;
                case ConsoleKey.DownArrow:
                    m_PositionY++;
                    break;
            }
        }
        private void EventInput(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                case ConsoleKey.Q:
                    if (FindItem())
                        m_Invincibilitytime.Start();
                    break;
            }
        }

    }
}
