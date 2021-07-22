using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintendo_q2
{
    class Program
    {
        static bool CheckBulls(string number, string question, int bulls)
        {
            if (bulls == 0) return true;
            int sameCount = 0;
            for(int i = 0; i < 4; i++)
            {
                if (number[i] == question[i])
                    sameCount++;
            }
            return sameCount == bulls;
        }

        static bool CheckCows(string number, string question, int cows)
        {
            if (cows == 0) return true;
            int sameCount = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    if (number[i] == question[j])
                        sameCount++;
            }
            return sameCount == cows;
        }
        static void Main(string[] args)
        {
            List<List<string>> dataSet = new List<List<string>>();
            int test = int.Parse(Console.ReadLine());
            for (int tn = 0; tn < test; tn++)
            {
                int lineNunmber = int.Parse(Console.ReadLine());
                List<string> data = new List<string>();
                for (int lineI = 0; lineI < lineNunmber; lineI++)
                {
                    string line = Console.ReadLine();
                    data.Add(line);
                }
                dataSet.Add(data);
            }
            Console.WriteLine("============================");


            foreach (var data in dataSet)
                Console.WriteLine(GetAnswer(data));



            Console.ReadKey();
        }

        static string GetAnswer(List<string> rules)
        {

            List<string> numbers = new List<string>();

            for (int n1 = 0; n1 <= 9; n1++)
            {
                for (int n2 = 0; n2 <= 9; n2++)
                {
                    if (n1 == n2) continue;
                    for (int n3 = 0; n3 <= 9; n3++)
                    {
                        if (n1 == n3 || n2 == n3) continue;
                        for (int n4 = 0; n4 <= 9; n4++)
                        {
                            if (n1 == n4 || n2 == n4 || n3 == n4) continue;
                            string number = n1 + "" + n2 + "" + n3 + "" + n4;
                            numbers.Add(number);
                        }
                    }
                }
            }

            List<string> fitNumbers = new List<string>();
            foreach (var number in numbers)
            {
                bool fit = true;
                for (int r = 0; r < rules.Count; r++)
                {
                    string questionNumber = rules[r].Split(' ')[0];
                    int bulls = int.Parse(rules[r].Split(' ')[1]);
                    int cows = int.Parse(rules[r].Split(' ')[2]);
                    if (!(CheckBulls(number, questionNumber, bulls) && CheckCows(number, questionNumber, cows)))
                    {
                        fit = false;
                        break;
                    }
                   
               
                }
                if (fit)
                {
                    fitNumbers.Add(number);
                }
            }
           
            if (fitNumbers.Count == 1)
                return fitNumbers[0];
            else
                return "None";
        }
    }
}
