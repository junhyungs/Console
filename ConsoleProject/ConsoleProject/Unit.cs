using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    enum E_Direction 
    {
        RIGHT,
        LEFT,
        UP,
        DOWN
    }

    internal class Unit
    {
        protected Map m_Map = new Map();
        protected int m_PositionX;
        protected int m_PositionY;
        protected char m_Img;
        protected char Wall;
        protected char Food;
        protected char Road;

        public int PositionX { get { return m_PositionX; } }
        public int PositionY { get { return m_PositionY; } }

        public void SetPosition(int x, int y)
        {
            m_PositionX = x;
            m_PositionY = y;
        }

        public int NextPositionX(E_Direction direction)
        {
            switch (direction)
            {
                case E_Direction.RIGHT:
                    return 1;
                case E_Direction.LEFT:
                    return -1;
                default:
                    return 0;
            }
        }

        public int NextPositionY(E_Direction direction)
        {
            switch (direction)
            {
                case E_Direction.UP:
                    return -1;
                case E_Direction.DOWN:
                    return 1;
                default:
                    return 0;
            }
        }

        public bool IsObject(char[,]buffer,char img,E_Direction direction)
        {
            int NextPosition_X = NextPositionX(direction);
            int NextPosition_Y = NextPositionY(direction);

            if(IsNext(buffer,img,m_PositionX + NextPosition_X, m_PositionY + NextPosition_Y))
                return true;
            else
                return false;
        }

        private bool IsNext(char[,]buffer,char img, int x, int y)
        {
            if (buffer[y,x] == img)
                return true;

            return false;
        }

        public void Update(Buffer buffer)
        {
            buffer.Draw(m_Img, m_PositionX, m_PositionY);
        }

    }
}
