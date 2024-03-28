using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class UI
    {
        public void StartUI(Buffer buffer)
        {
            DrawUI(buffer.BackBuffer, $"Game Start ----->", 3, 10);
        }

        public void DeadUI(Buffer buffer)
        {
            DrawUI(buffer.BackBuffer, $"Game Over\n", 8, 8);
            DrawUI(buffer.BackBuffer, $"restart ->\n", 8, 9);
            DrawUI(buffer.BackBuffer, $"End : ESC", 8, 10);
        }

        public void EndUI()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                                                                                                            ");
            Console.WriteLine("                                                                                                            ");
            Console.WriteLine("    ■■■■■■■■■■■■■■■■■■  ■■■■                          ■■■    ■■■■■■■■■■■                                    ");
            Console.WriteLine("    ■■■■■■■■■■■■■■■■■■  ■■■■■                        ■■■    ■■■■■■■■■■■■■                                   ");
            Console.WriteLine("    ■■■■■■■■■■■■■■■■■■  ■■■■■■                      ■■■    ■■■■■■■■■■■■■■                                   ");
            Console.WriteLine("    ■■■■■■■■■■■■■■■■■■  ■■■ ■■■                     ■■■    ■■■■              ■■■■                           ");
            Console.WriteLine("    ■■■■■■■■■■■■■■■■■■  ■■■  ■■■                    ■■■    ■■■■                ■■■■                         ");
            Console.WriteLine("    ■■■■                              ■■■   ■■■                   ■■■    ■■■■                  ■■■■         ");
            Console.WriteLine("    ■■■■                              ■■■    ■■■                  ■■■    ■■■■                    ■■■■       ");
            Console.WriteLine("    ■■■■                              ■■■     ■■■                 ■■■    ■■■■                      ■■■■     ");
            Console.WriteLine("    ■■■■                              ■■■      ■■■                ■■■    ■■■■                       ■■■■    ");
            Console.WriteLine("    ■■■■                              ■■■       ■■■               ■■■    ■■■■                         ■■■■  ");
            Console.WriteLine("    ■■■■                              ■■■        ■■■              ■■■    ■■■■                          ■■■■ ");
            Console.WriteLine("    ■■■■■■■■■■■■■■■■■■  ■■■         ■■■             ■■■    ■■■■                           ■■■■              ");
            Console.WriteLine("    ■■■■■■■■■■■■■■■■■■  ■■■          ■■■            ■■■    ■■■■                           ■■■■              ");
            Console.WriteLine("    ■■■■■■■■■■■■■■■■■■  ■■■           ■■■           ■■■    ■■■■                           ■■■■              ");
            Console.WriteLine("    ■■■■■■■■■■■■■■■■■■  ■■■            ■■■          ■■■    ■■■■                           ■■■■              ");
            Console.WriteLine("    ■■■■■■■■■■■■■■■■■■  ■■■             ■■■         ■■■    ■■■■                           ■■■■              ");
            Console.WriteLine("    ■■■■                              ■■■              ■■■        ■■■    ■■■■                           ■■■■");
            Console.WriteLine("    ■■■■                              ■■■               ■■■       ■■■    ■■■■                          ■■■■ ");
            Console.WriteLine("    ■■■■                              ■■■                ■■■      ■■■    ■■■■                         ■■■■  ");
            Console.WriteLine("    ■■■■                              ■■■                 ■■■     ■■■    ■■■■                       ■■■■    ");
            Console.WriteLine("    ■■■■                              ■■■                  ■■■    ■■■    ■■■■                     ■■■■      ");
            Console.WriteLine("    ■■■■                              ■■■                   ■■■   ■■■    ■■■■                   ■■■■        ");
            Console.WriteLine("    ■■■■■■■■■■■■■■■■■■  ■■■                    ■■■  ■■■    ■■■■                  ■■■■                       ");
            Console.WriteLine("    ■■■■■■■■■■■■■■■■■■  ■■■                     ■■■ ■■■    ■■■■                ■■■■                         ");
            Console.WriteLine("    ■■■■■■■■■■■■■■■■■■  ■■■                      ■■■■■■    ■■■■■■■■■■■■■■■                                  ");
            Console.WriteLine("    ■■■■■■■■■■■■■■■■■■  ■■■                        ■■■■■    ■■■■■■■■■■■■■■                                  ");
            Console.WriteLine("    ■■■■■■■■■■■■■■■■■■  ■■■                          ■■■■    ■■■■■■■■■■■■                                   ");
        }

        public void DrawUI(char[,] buffer, string str, int X, int Y)
        {
            char[] Temp = str.ToCharArray();

            for (int i = 0; i < Temp.Length; i++)
            {
                buffer[Y, X + i] = Temp[i];
            }
        }

    }
}
