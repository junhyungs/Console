﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class Map
    {
        public List<int[,]> m_MapList = new List<int[,]>();
        private char m_Wall = '■';
        private char m_Food = '⊙';
        private char m_Road = '　';

        public Map()
        {
            AddMap();
        }

        public char Road { get { return m_Road; } }
        public char Food { get { return m_Food; } }
        public char Wall { get { return m_Wall; } }

        private void AddMap()
        {
            m_MapList.Add(Stage0);
            m_MapList.Add(Stage1);
            m_MapList.Add(Stage2);
            m_MapList.Add(Stage3);
            m_MapList.Add(Stage4);
        }

        private int[,] Stage0 = new int[15, 15]
       {
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},
            {4,1,1,1,1,1,1,1,1,1,1,1,1,1,4},
            {4,1,1,1,1,1,1,1,1,1,1,1,1,1,4},
            {4,1,1,1,1,1,1,1,1,1,1,1,1,1,4},
            {4,1,1,1,1,1,1,1,1,1,1,1,1,1,4},
            {4,1,1,1,1,1,1,1,1,1,1,1,1,1,4},
            {4,1,1,1,1,1,1,1,1,1,1,1,1,1,4},
            {4,1,1,1,1,1,1,1,1,1,2,1,1,1,4},
            {4,1,1,1,1,1,1,1,1,1,1,1,1,1,4},
            {4,1,1,1,1,1,1,1,1,1,1,1,1,1,4},
            {4,1,1,1,1,1,1,1,1,1,1,1,1,1,4},
            {4,1,1,1,1,1,1,1,1,1,1,1,1,1,4},
            {4,1,1,1,1,1,1,1,1,1,1,1,1,1,4},
            {4,1,1,1,1,1,1,1,1,1,1,1,1,1,4},
            {4,4,4,4,4,4,4,4,4,4,4,4,4,4,4},

       };

        private int[,] Stage1 = new int[20, 20]
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,2,2,2,2,2,2,2,2,0,0,2,2,2,2,2,2,2,2,0 },
            {0,2,1,1,1,1,1,1,2,0,0,2,1,1,1,1,1,1,2,0 },
            {0,2,1,1,1,1,1,1,2,0,0,2,1,1,1,1,1,1,2,0 },
            {0,2,1,1,1,1,1,1,2,0,0,2,1,1,1,1,1,1,2,0 },
            {0,2,1,1,1,1,1,1,2,0,0,2,1,1,1,1,1,1,2,0 },
            {0,2,1,1,1,1,1,1,2,0,0,2,1,1,1,1,1,1,2,0 },
            {0,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,0 },
            {0,2,2,2,2,2,2,1,1,1,1,1,1,2,2,2,2,2,2,0 },
            {0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0 },
            {0,2,2,2,2,2,2,1,1,1,1,1,1,2,2,2,2,2,2,0 },
            {0,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,0 },
            {0,2,1,1,1,1,1,1,2,0,0,2,1,1,1,1,1,1,2,0 },
            {0,2,1,1,1,1,1,1,2,0,0,2,1,1,1,1,1,1,2,0 },
            {0,2,1,1,1,1,1,1,2,0,0,2,1,1,1,1,1,1,2,0 },
            {0,2,1,1,1,1,1,1,2,0,0,2,1,1,1,1,1,1,2,0 },
            {0,2,1,1,1,1,1,1,2,0,0,2,1,1,1,1,1,1,2,0 },
            {0,2,2,2,2,2,2,2,2,0,0,2,2,2,2,2,2,2,2,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        };

        private int[,] Stage2 = new int[25, 25]
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,2,2,2,2,2,2,2,2,2,2,2,0,2,2,2,2,2,2,2,2,2,2,2,0 },
            {0,2,1,1,1,1,0,0,0,1,2,1,0,1,2,1,0,0,0,1,1,0,0,2,0 },
            {0,2,0,0,1,1,0,0,0,1,2,1,0,1,2,1,0,0,0,1,1,0,0,2,0 },
            {0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0 },
            {0,2,0,0,1,1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,0,0,2,0 },
            {0,2,2,2,2,0,1,0,1,1,1,1,0,1,1,1,1,0,1,0,2,2,2,2,0 },
            {0,0,0,0,2,0,1,0,0,0,0,1,0,1,0,0,0,0,1,0,2,0,0,0,0 },
            {0,0,0,0,2,0,1,0,1,1,1,1,1,1,1,1,1,0,1,0,2,0,0,0,0 },
            {0,0,0,0,2,0,1,2,2,2,2,2,2,2,2,2,2,2,1,0,2,0,0,0,0 },
            {0,1,1,1,2,1,1,0,0,0,0,1,1,1,0,0,0,0,1,1,2,1,1,1,0 },
            {0,1,1,1,2,1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,2,1,1,1,0 },
            {0,0,0,0,2,0,1,0,1,1,1,1,1,1,1,1,1,0,1,0,2,0,0,0,0 },
            {0,0,0,0,2,0,1,0,1,1,1,1,1,1,1,1,1,0,1,0,2,0,0,0,0 },
            {0,0,0,0,2,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,2,0,0,0,0 },
            {0,2,2,2,2,1,1,2,2,2,2,2,2,2,2,2,2,2,1,1,2,2,2,2,0 },
            {0,2,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,2,0 },
            {0,2,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,2,0 },
            {0,2,1,0,1,1,1,0,0,0,0,0,1,0,0,0,0,0,1,1,1,0,1,2,0 },
            {0,2,2,2,2,1,2,2,2,2,2,2,2,2,2,2,2,2,2,1,2,2,2,2,0 },
            {0,0,0,0,2,1,0,0,1,1,0,0,0,0,0,1,1,0,0,1,2,0,0,0,0 },
            {0,2,2,2,2,1,0,0,1,1,1,1,0,1,1,1,1,0,0,1,2,2,2,2,0 },
            {0,2,1,1,1,1,0,0,1,1,0,0,0,0,0,1,1,0,0,1,1,1,1,2,0 },
            {0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        };

        private int[,] Stage3 = new int[25, 25]
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,2,2,2,2,2,0,0,0,2,2,2,2,2,0,0,0,0,0,0 },
            {0,0,1,2,2,2,2,1,1,1,2,0,0,0,2,1,1,1,2,2,2,2,2,0,0 },
            {0,0,2,1,1,0,0,0,0,1,2,0,0,0,2,1,0,0,0,0,1,1,2,0,0 },
            {0,0,2,1,1,0,0,0,0,1,2,2,2,2,2,1,0,0,0,0,1,1,2,0,0 },
            {0,0,2,1,1,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,1,1,2,0,0 },
            {0,2,2,1,1,1,1,1,1,1,0,0,0,0,0,1,1,1,1,1,1,1,2,2,0 },
            {0,2,2,2,1,1,1,1,1,1,0,2,2,2,0,1,1,1,1,1,1,2,2,2,0 },
            {0,0,0,2,1,0,0,0,0,1,0,2,2,2,0,1,0,0,0,0,1,2,0,0,0 },
            {0,0,0,2,1,0,0,0,0,1,0,2,2,2,0,1,0,0,0,0,1,2,0,0,0 },
            {0,0,0,2,1,0,0,0,0,1,0,2,2,2,0,1,0,0,0,0,1,2,0,0,0 },
            {0,2,2,2,2,2,2,2,2,1,0,1,1,1,0,1,2,2,2,2,2,2,2,2,0 },
            {0,0,0,0,0,0,0,0,2,1,0,1,1,1,0,1,2,0,0,0,0,0,0,0,0 },
            {0,2,2,2,2,2,2,2,2,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,0 },
            {0,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,0 },
            {0,0,0,0,2,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,2,0,0,0,0 },
            {0,0,0,0,2,1,1,1,0,1,0,1,0,1,0,1,0,1,1,1,2,0,0,0,0 },
            {0,2,2,2,2,1,1,1,0,1,0,1,0,1,0,1,0,1,1,1,2,2,2,2,0 },
            {0,2,1,1,1,0,0,0,0,1,0,1,0,1,0,1,0,0,0,0,1,1,1,2,0 },
            {0,2,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,2,0 },
            {0,2,1,1,1,2,1,1,1,1,2,2,2,2,2,1,1,1,1,2,1,1,1,2,0 },
            {0,2,0,0,0,0,1,1,0,1,2,0,0,0,2,1,0,1,1,0,0,0,0,2,0 },
            {0,2,0,0,0,0,1,1,0,1,2,0,0,0,2,1,0,1,1,0,0,0,0,2,0 },
            {0,2,2,2,2,2,2,2,2,2,2,0,0,0,2,2,2,2,2,2,2,2,2,2,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        };

        public int[,] Stage4 = new int[25, 25]
      {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,0,1,1,1,0,1,2,1,0,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
      };

        public void ImportMap(int[,] maplist, char[,] backbuffer) 
        {
            for (int i = 0; i < maplist.GetLength(0); i++)
            {
                for (int k = 0; k < maplist.GetLength(1); k++)
                {
                    if (maplist[i, k] == 0) 
                        backbuffer[i, k] = m_Wall;
                    else if (maplist[i, k] == 1)
                        backbuffer[i, k] = m_Road;
                    else if (maplist[i, k] == 2)
                        backbuffer[i, k] = m_Food;
                    else if (maplist[i, k] == 3)
                        backbuffer[i, k] = '★';
                    else if (maplist[i, k] == 4)
                        backbuffer[i, k] = '▩';
                }
            }
        }

        public int MapFoodCount(int[,] maplist) 
        {
            int foodcount = 0;

            for (int i = 0; i < maplist.GetLength(0); i++)
            {
                for (int k = 0; k  < maplist.GetLength(1); k++)
                {
                    if (maplist[i, k] == 2)
                        foodcount++;
                }
            }

            return foodcount;
        }

        public bool IsNext(char[,] backbuffer, char img, int X, int Y) 
        {
            if (backbuffer[Y, X] == img)
                return true;

            return false;
        }
    }
}
