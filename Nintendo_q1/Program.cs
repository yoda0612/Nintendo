using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintendo_q1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = new List<string>();
            List<int> killTimeList = new List<int>();

            int test = int.Parse(Console.ReadLine());
            for (int tn = 0; tn < test; tn++)
            {
                int killTimes = int.Parse(Console.ReadLine());
                string line = Console.ReadLine();

                killTimeList.Add(killTimes);
                lines.Add(line);


            }
            Console.WriteLine("============================");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.WriteLine(GetAnswer(lines[i], killTimeList[i]));
            }

            Console.ReadKey();
        }


        static string GetAnswer(string line, int killTimes)
        {
            string[] enemies = line.Split(' ');

            int totalEnemyNumber = 0;
            for (int i = 0; i < enemies.Length; i++)
            {
                totalEnemyNumber += int.Parse(enemies[i]);
            }

            int killed = 0;
            for (int i = 0; i < enemies.Length; i++)
            {
                if (int.Parse(enemies[i]) <= 5 || (killTimes--) > 0)
                    killed += int.Parse(enemies[i]);
                else
                    break;
            }

            return (killed == totalEnemyNumber) + " " + killed;
        }
    }
}
