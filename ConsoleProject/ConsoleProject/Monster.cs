using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class Monster : Unit, I_MonsterMove
    {
        private Random m_RandomDirection = new Random();
        private E_Direction m_Direction = E_Direction.RIGHT;

        private int m_MonsterMoveCount = 0;
        protected bool FoodCheck = false;
        private bool MonsterActive = false;

        public bool IsActive
        {
            get { return MonsterActive; }
            set { MonsterActive = value; }
        }

        public Monster()
        {
            m_Img = '◈';
            m_PositionX = 12;
            m_PositionY = 12;

            Wall = m_Map.Wall;
            Food = m_Map.Food;
            Road = m_Map.Road;
        }

        public void Reset()
        {
            IsActive = true;
        }
        public E_Direction Direction()
        {
            int nDir = m_RandomDirection.Next(0, 4);

            switch (nDir)
            {
                case 0:
                    return E_Direction.RIGHT;
                case 1:
                    return E_Direction.LEFT;
                case 2:
                    return E_Direction.UP;
                case 3:
                    return E_Direction.DOWN;
                default:
                    return E_Direction.RIGHT;
            }
        }


        public void Movement(Buffer buffer, char[,] map)
        {
            bool IsWall = IsObject(buffer.BackBuffer, Wall, m_Direction);
            bool IsFood = IsObject(buffer.BackBuffer, Food, m_Direction);
            bool IsMonster = IsObject(buffer.BackBuffer, m_Img, m_Direction);

            if (!IsWall && !IsMonster)
            {
                if (IsFood && !FoodCheck)
                {
                    buffer.Draw(Road, m_PositionX, m_PositionY);
                    FoodCheck = true;
                }
                else if (IsFood && FoodCheck)
                {
                    buffer.Draw(Food, m_PositionX, m_PositionY);
                }
                else if (!IsFood && FoodCheck)
                {
                    buffer.Draw(Food, m_PositionX, m_PositionY);
                    FoodCheck = false;
                }
                else
                    buffer.Draw(Road, m_PositionX, m_PositionY);
                Move(m_Direction);
                if (m_MonsterMoveCount % 3 == 0)
                    m_Direction = Direction();
            }
            else
                m_Direction = Direction();
        }
        public void Move(E_Direction direction)
        {
            switch (direction)
            {
                case E_Direction.RIGHT:
                    m_PositionX++;
                    m_MonsterMoveCount++;
                    break;
                case E_Direction.LEFT:
                    m_PositionX--;
                    m_MonsterMoveCount++;
                    break;
                case E_Direction.UP:
                    m_PositionY--;
                    m_MonsterMoveCount++;
                    break;
                case E_Direction.DOWN:
                    m_PositionY++;
                    m_MonsterMoveCount++;
                    break;
            }
        }

    }
}
