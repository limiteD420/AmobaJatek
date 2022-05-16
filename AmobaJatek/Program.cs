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
        //A játéknak akkor van vége, ha egymás mellett, felett vagy kétirányba keresztbe 5 ugyanolyan szimbólum van.
        //Megoldani, hogy ne lehessen felülírni már meglévő karaktert.

        static string[,] gameTable = new string[10, 10];
        static int x, y;
        static string[] jatekos = new string[] {"X","O"};
        static void Main(string[] args)
        {
            
            for (int i = 0; i < gameTable.GetLength(0); i++) //feltölti csillaggal
            {
                for (int j = 0; j < gameTable.GetLength(1); j++)
                {
                    gameTable[i, j] = "*";
                }
            }

            int k = 0;

            do
            {
                writeOut();
                Console.WriteLine("Hova rajzolsz?");
                Console.WriteLine("A(z) " + jatekos[k % 2] + " 1. koordinátája: ");
                x = int.Parse(Console.ReadLine());
                Console.WriteLine("A(z) " + jatekos[k % 2] + " 2. koordinátája: ");
                y = int.Parse(Console.ReadLine());
                
                if (gameTable[x, y] == "*")
                {
                    gameTable[x, y] = jatekos[k % 2];
                    k++; 
                }
                
                Console.Clear();

            } while (!isOver(x, y));

            Console.WriteLine("Nyert a(z) " + jatekos[(k - 1) % 2]);
            Console.ReadLine();
        }

        private static bool isOver(int x, int y)
        {            
            return Darabszam(gameTable, x, y, 0, 1) >= 5 || Darabszam(gameTable, x, y, 1, 0) >=5 || Darabszam(gameTable, x, y, 1, 1) >= 5 || Darabszam(gameTable, x, y, 1, -1) >= 5;
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

        private static int Darabszam(string[,] matrix, int x, int y, int iranyX, int iranyY)
        {
            int x2 = x + iranyX;
            int y2 = y + iranyY;
            int db = 1;

            while (x2 >= 0 && x2 < matrix.GetLength(0)-1 && y2 >= 0 && y2 < matrix.GetLength(1)-1 && matrix[x,y] == matrix[x2,y2])
            {
                db++;
                x2 += iranyX;
                y2 += iranyY;
            }

            x2 = x - iranyX;
            y2 = y - iranyY;

            while (x2 >= 0 && x2 < matrix.GetLength(0)-1 && y2 >= 0 && y2 < matrix.GetLength(1)-1 && matrix[x, y] == matrix[x2, y2])
            {
                db++;
                x2 -= iranyX;
                y2 -= iranyY;
            }

            return db;
        }
        
    }
}
