using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class Buffer
    {
        private int m_BufferPositionX;
        private int m_BufferPositionY;
        private char[,] m_BackBuffer;
        private char[,] m_FrontBuffer;

        public Buffer(int BufferX, int BufferY)
        {
            m_BufferPositionX = BufferX;
            m_BufferPositionY = BufferY;
            m_BackBuffer = new char[m_BufferPositionY, m_BufferPositionX];
            m_FrontBuffer = new char[m_BufferPositionY, m_BufferPositionX];

            Console.CursorVisible = false;
            Console.SetWindowSize(150, 50);
        }

        public char[,] BackBuffer { get { return m_BackBuffer; } }

        private bool IsOverFlow(int X, int Y)
        {
            bool OverFlow = ((X >= m_BufferPositionX || Y >= m_BufferPositionY) || (X < 0 || Y < 0));

            if (OverFlow)
                return true;

            return false;
        }

        public void Draw(char img, int X, int Y)
        {
            if (!IsOverFlow(X, Y))
                m_BackBuffer[Y, X] = img;
        }

        public void Clear()
        {
            Array.Clear(m_BackBuffer, 0, m_BufferPositionX * m_BufferPositionY);
        }

        private void BufferCopy()
        {
            Array.Copy(m_BackBuffer, m_FrontBuffer, m_BufferPositionX * m_BufferPositionY);
        }

        private void PrintBuffer()
        {
            for (int i = 0; i < m_BufferPositionY; i++)
            {
                for(int k = 0; k < m_BufferPositionX; k++)
                {
                    Console.Write(m_FrontBuffer[i, k]);
                }
                Console.WriteLine();
            }
        }

        public void Show()
        {
            BufferCopy();
            Console.SetCursorPosition(0, 0);
            PrintBuffer();
        }
    }
}
