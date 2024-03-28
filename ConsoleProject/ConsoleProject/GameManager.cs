using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleProject
{
    internal class GameManager
    {
        private int m_Stage;
        private int m_NextStage;
        private int m_BackupStage;
        private int m_BackupScore;
        private bool IsOverlap;
        private int MonsterCount;
        private int DeadMonsterCount;
       

        private System.Timers.Timer m_MonsterTime;
        
        private System.Timers.Timer m_ItemSpawnTime;
        private Random m_Random;
        private Buffer m_Buffer;
        private MonsterPool m_MonsterPool;
        private List<Monster> m_MonsterList;
        private PlayerMove m_Player;
        private Map m_Map;
        private UI m_UI;
        

        public GameManager()
        {
            m_MonsterTime = new System.Timers.Timer(100);
            
            m_ItemSpawnTime = new System.Timers.Timer(4000);    
            m_Random = new Random();
            m_Buffer = new Buffer(40, 40);
            m_MonsterPool = new MonsterPool(20);
            m_MonsterList = new List<Monster>();
            m_Player = new PlayerMove();
            m_Map = new Map();
            m_UI = new UI();

            m_Stage = 0;
            m_NextStage = 0;
            IsOverlap = false;
            m_BackupScore = 0;
            m_BackupStage = 0;
            MonsterCount = 0;
            DeadMonsterCount = 0;
            
        }

        private void SetGame(int PlayerPositionX, int PlayerPositionY)
        {
            m_Buffer.Clear();
            m_Map.ImportMap(m_Map.m_MapList[m_Stage], m_Buffer.BackBuffer);
            m_NextStage = m_Map.MapFoodCount(m_Map.m_MapList[m_Stage]);

            m_Player.SetPosition(PlayerPositionX, PlayerPositionY);
        }

        private void StartStage()
        {
            m_Buffer.Clear();
            m_Map.ImportMap(m_Map.m_MapList[m_Stage], m_Buffer.BackBuffer);
            m_Player.SetPosition(4, 7);

            int nData = m_Map.MapFoodCount(m_Map.m_MapList[m_Stage]);

            while(m_Player.FoodCount != nData)
            {
                m_Player.PlayerInput(m_Buffer);
                m_Player.Update(m_Buffer);
                m_Buffer.Show();
            }

            m_Player.Score = 0;
            m_Player.FoodCount = 0;
        }
        
        private void NextStage()
        {
            if(m_Player.FoodCount == m_NextStage)
            {
                Thread.Sleep(1500);
                Console.Clear();

                m_BackupStage = m_Stage;
                m_BackupScore = m_Player.Score;

                m_Stage++;
                if(m_Stage > 3)
                {
                    Environment.Exit(0);
                }

                m_Player.FoodCount = 0;


                SpawnMonster();

                IEnumerator<Monster> iter = m_MonsterList.GetEnumerator();
                while (iter.MoveNext())
                {
                    iter.Current.SetPosition(12, 12);
                }

                SetGame(2,2);
            }
        }

        private void DeadStage()
        {
            Console.Clear();
            TimerStop();

            m_Player.Score = 0;
            m_Player.m_ItemQueue.Clear();
            m_Player.FoodCount = 0;
            m_Stage = 0;

            m_Map.ImportMap(m_Map.m_MapList[4], m_Buffer.BackBuffer);
            m_Player.SetPosition(10, 4);
            m_NextStage = m_Map.MapFoodCount(m_Map.m_MapList[4]);

            while(m_Player.FoodCount != m_NextStage)
            {
                m_UI.DeadUI(m_Buffer);
                m_Player.PlayerInput(m_Buffer);
                m_Player.Update(m_Buffer);
                m_Buffer.Show();
            }

            TimerStart();
        }

        

        private void Timer()
        {
            ItemSpawnTimer();
            MonsterMoveTimer();
            m_Player.InvincibilityTimer();
        }
        private void TimerStart()
        {
            m_ItemSpawnTime.Start();
            m_MonsterTime.Start();
        }
        private void TimerStop()
        {
            m_ItemSpawnTime.Stop();
            m_MonsterTime.Stop();
        }



        private void SpawnMonster()
        {
            if(MonsterCount == 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    Monster newMonster = m_MonsterPool.GetItem();
                    newMonster.SetPosition(12, 12);
                    m_MonsterList.Add(newMonster);
                    MonsterCount++;
                }
            }
            else if(DeadMonsterCount > 0)
            {
                ReSpawnMonster();
            }
                
        }
        private void ReSpawnMonster()
        {
            for(int i = 0; i < DeadMonsterCount; i++)
            {
                Monster Respawn = m_MonsterPool.GetItem();
                Respawn.SetPosition(12, 12);
                m_MonsterList.Add(Respawn);
            }
            DeadMonsterCount = 0;
        }
        private void RemoveMonster(Monster monster)
        {
            m_MonsterList.Remove(monster);
            m_MonsterPool.ReturnItem(monster);
            DeadMonsterCount++;
        }
        private void MonsterMoveTimer()
        {
            m_MonsterTime.Elapsed += MonsterMove;
            m_MonsterTime.Enabled = true;
            m_MonsterTime.AutoReset = true;
        }
        private void MonsterMove(object sender, ElapsedEventArgs e)
        {
            foreach(Monster monster in m_MonsterList)
            {
                monster.Movement(m_Buffer, m_Buffer.BackBuffer);
            }
        }
        private void MonsterMoveUpdate()
        {
            foreach (Monster monster in m_MonsterList)
            {
                monster.Update(m_Buffer);
            }
        }



        
        


        private void ItemSpawnTimer()
        {
            m_ItemSpawnTime.Elapsed += ItemSpawn;
            m_ItemSpawnTime.Enabled = false;
            m_ItemSpawnTime.AutoReset = true;
        }
        private void ItemSpawn(object sender, ElapsedEventArgs e)
        {
            int MapSizeY = m_Map.m_MapList[m_Stage].GetLength(0);
            int MapSizeX = m_Map.m_MapList[m_Stage].GetLength(1);

            int RandomPositionX = m_Random.Next(1, MapSizeX);
            int RandomPositionY = m_Random.Next(1, MapSizeY);

            if (m_Buffer.BackBuffer[RandomPositionY, RandomPositionX] == m_Map.Road)
            {
                m_Buffer.BackBuffer[RandomPositionY, RandomPositionX] = '★';
            }
        }




        private void Dead()
        {
            int Index = 0;

            foreach(Monster monster in m_MonsterList)
            {
                if(monster.PositionX == m_Player.PositionX && monster.PositionY == m_Player.PositionY)
                {
                     Index = m_MonsterList.IndexOf(monster);
                    IsOverlap = true;
                }
            }
            if (IsOverlap)
            {
                if(m_Player.m_Invincibilitytime.Enabled == true)
                {
                    Monster returnMonster = m_MonsterList[Index];
                    RemoveMonster(returnMonster);
                    IsOverlap = false;
                    return;
                }
                else
                {
                    DeadStage();
                    IsOverlap = false;
                }
                
            }
        }
        private void ShowUI()
        {
            m_UI.DrawUI(m_Buffer.BackBuffer, $"   Stage : {m_Stage}\n", 10, 27);
            m_UI.DrawUI(m_Buffer.BackBuffer, $"   점수 : {m_Player.Score} 점\n", 10, 28);
            m_UI.DrawUI(m_Buffer.BackBuffer, $"   →, ←, ↑, ↓ 이동\n", 10, 29);
            m_UI.DrawUI(m_Buffer.BackBuffer, $"   ★ 무적 : {m_Player.m_ItemQueue.Count} 개\n", 10, 30);
            m_UI.DrawUI(m_Buffer.BackBuffer, $"   아이템 사용 : Q\n", 10, 31);
            if (m_Player.m_Invincibilitytime.Enabled == true)
                m_UI.DrawUI(m_Buffer.BackBuffer, $"   무적 시간 : {m_Player.m_Invincibility}초", 10, 32);
            else
                m_UI.DrawUI(m_Buffer.BackBuffer, $"                    ", 10, 32);
        }

        public void Run()
        {
            StartStage();
            Timer();
            TimerStart();

            while (true)
            {
                NextStage();
                ShowUI();

                m_Player.PlayerInput(m_Buffer);
                m_Player.Update(m_Buffer);
                MonsterMoveUpdate();
                Dead();
                m_Buffer.Show();
            }
          
        }

    }
}
