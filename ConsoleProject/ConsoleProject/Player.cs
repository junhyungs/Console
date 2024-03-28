using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleProject
{
    internal class Player : Unit
    {
        protected int m_FoodCount = 0;
        protected int m_Score = 0;
        public int m_Invincibility = 5;
        public Queue<Item> m_ItemQueue = new Queue<Item>();
        public System.Timers.Timer m_Invincibilitytime = new System.Timers.Timer(1000);


        public Player()
        {
            m_PositionX = 0;
            m_PositionY = 0;
            m_Img = '▣';

            Wall = m_Map.Wall;
            Food = m_Map.Food;
            Road = m_Map.Road;
        }
        public int FoodCount
        {
            get { return m_FoodCount; }
            set { m_FoodCount = value; }
        }
        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }

        public void NewItem()
        {
            m_ItemQueue.Enqueue(new Item('★'));
        }
        public bool FindItem()
        {
            foreach (Item item in m_ItemQueue)
            {
                if (m_ItemQueue.Contains(item))
                    return true;
            }
            return false;
        }
        public void InvincibilityTimer()
        {
            m_Invincibilitytime.Elapsed += InvincibilityTime;
            m_Invincibilitytime.Interval = 1000;
            m_Invincibilitytime.Enabled = false;
            m_Invincibilitytime.AutoReset = true;
        }
        private void InvincibilityTime(object obj, ElapsedEventArgs e)
        {
            m_Invincibility--;

            if (m_Invincibility == 0)
            {
                m_Invincibility = 5;
                m_ItemQueue.Dequeue();
                m_Invincibilitytime.Stop();
            }
        }
    }
}
