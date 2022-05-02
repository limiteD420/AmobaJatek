using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmobaJatek
{
    class Program
    {
        //Csinálj amőba játékot, egyszr X, egyszer O-t kér be.
        //A játéknak akkor van vége, ha egymás mellett, felett vagy kétirényba keresztbe 5 ugyanolyan szimbólum van.

        static string[,] gameTable= new string[10,10];
        static void Main(string[] args)
        {
            int x1, x2, y1, y2;

            for (int i = 0; i < gameTable.GetLength(0); i++) //feltölti szóközzel a mátrixot
            {
                for (int j = 0; j < gameTable.GetLength(1); j++)
                {
                    gameTable[i, j] = " ";
                }
            }
            
            while(!isOver())
            {
                
                Console.WriteLine("Hova tegyem az X-et, majd a O-t?");

                                
                Console.WriteLine("X Koordináta 1: ");
                x1 = int.Parse(Console.ReadLine());
                Console.WriteLine("X Koordináta 2: ");
                x2 = int.Parse(Console.ReadLine());

                gameTable[x1, x2] = "X";
                writeOut();

                Console.WriteLine("O Koordináta 1: ");
                y1 = int.Parse(Console.ReadLine());
                Console.WriteLine("O Koordináta 2: ");
                y2 = int.Parse(Console.ReadLine());

                if (gameTable[y1, y2] == "X")
                {
                   while(gameTable[y1, y2] == "X")
                   { 
                        Console.WriteLine("Add meg újra az O helyét:");
                        Console.WriteLine("O Koordináta 1: ");
                        y1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("O Koordináta 2: ");
                        y2 = int.Parse(Console.ReadLine());
                   }
                    
                }
                else
                {
                    gameTable[y1, y2] = "O";
                    writeOut();
                }
                
            }

        }

        private static bool isOver()
        {
           
            return false;
        }

        private static void writeOut()
        {
            for (int x = 0; x < gameTable.GetLength(0); x++)
            {
                for (int y = 0; y < gameTable.GetLength(1); y++)
                {
                    Console.Write("{0} ", gameTable[x, y]);
                }
                Console.WriteLine();
            }
        }


    }
}
