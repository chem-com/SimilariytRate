using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Similarity1.Entitiy;
using System.Timers;
namespace SimilarityRateCalcute
{
    class Program
    {
        static My_Entitiy model = new My_Entitiy();
        static Thread th1 = new Thread(new ThreadStart(WriteX));
        static void Main(string[] args)
        {
            th1.Start();
            System.Timers.Timer timer = new System.Timers.Timer
            {
                Interval = 1000*60*5,
                Enabled = true
            };
            timer.Elapsed += new ElapsedEventHandler(TimerElapsedEvent);
        }

        private static void TimerElapsedEvent(object sender, ElapsedEventArgs e)
        {
            if (!th1.IsAlive)
            {
                th1.Start();
            }
        }

        private static void WriteX()
        {
            List<HOMEWORK> scanned = model.HOMEWORK.ToList();
            List<HOMEWORK> notscanned = model.HOMEWORK.Where(x => x.ISSCAN == false).ToList();
            decimal temp = 0, calculated = 0;

            foreach (HOMEWORK item in notscanned)
            {
                foreach (HOMEWORK list in scanned)
                {
                    if (item.ID != list.ID)
                    {
                        calculated = decimal.Parse(CalculateSimilarity(item.CONTEXT, list.CONTEXT).ToString("F", CultureInfo.InvariantCulture));
                        if (calculated > temp)
                        {
                            temp = calculated;
                        }
                    }
                }
                item.SIMILARTYRATE = temp;
                item.ISSCAN = true;
                model.SaveChanges();
            }
        }

        static int ComputeLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;

            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0)
                return targetWordCount;

            if (targetWordCount == 0)
                return sourceWordCount;

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
        }
        static double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;

            int stepsToSame = ComputeLevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)))*100;
        }
    }
}
