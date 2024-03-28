using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class MonsterPool
    {
        private List<Monster>m_MonsterPool = new List<Monster>();

        public MonsterPool(int PoolSize)
        {
            for(int i = 0; i < PoolSize; i++)
            {
                m_MonsterPool.Add(new Monster());
            }
        }

        public Monster GetItem()
        {
            foreach (Monster monster in m_MonsterPool)
            {
                if (!monster.IsActive)
                {
                    monster.Reset();
                    return monster;
                }
            }
            Monster newMonster = new Monster();
            newMonster.Reset();
            m_MonsterPool.Add(newMonster);
            return newMonster;
        }


        public void ReturnItem(Monster item)
        {
            item.IsActive = false;
        }

    }
}
