using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nintendo_q3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> dataSet = new List<List<string>>();
            int test = int.Parse(Console.ReadLine());
            for (int tn = 0; tn < test; tn++)
            {
                int successorNunmber = int.Parse(Console.ReadLine());
                List<string> data = new List<string>();
                for (int successorI = 0; successorI < successorNunmber; successorI++)
                {
                    string line = Console.ReadLine();
                    data.Add(line);
                }
                dataSet.Add(data);
            }
            Console.WriteLine("============================");
            foreach (var data in dataSet)
            {
                Console.WriteLine(GetAnswer(data));
            }
            Console.ReadKey();
        }
        static int GetAnswer(List<string> data)
        {
            List<List<string>> successors = new List<List<string>>();
            foreach (var line in data)
            {
                successors.Add(line.Split(' ').ToList());
            }

            for (int d = 1; d <= 30; d++)
            {

                List<List<string>> combineSuccessors = new List<List<string>>();
                for (int n = 0; n < successors.Count; n++)
                {
                    if (successors[n][0] == d.ToString())
                    {
                        combineSuccessors.Add(successors[n]);
                    }
                }

                if (combineSuccessors.Count <= 1) continue;

                foreach (var combineSuccessor in combineSuccessors)
                {
                    combineSuccessor.RemoveAt(0);
                    successors.Remove(combineSuccessor);
                }

                //re-generate combine schedule
                List<string> combinedSchedule = new List<string>();

                for (int d2 = d + 1; d2 <= 30; d2++)
                {
                    foreach (var combineSuccessor in combineSuccessors)
                    {
                        if (combineSuccessor.Contains(d2.ToString()))
                        {
                            combinedSchedule.Add(d2.ToString());
                            break;
                        }
                    }
                }

                successors.Add(combinedSchedule);

                if (successors.Count == 1)
                {
                    return d;
                }                
            }
            return -1;
        }       
    }
  
}
