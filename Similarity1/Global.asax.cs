using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Similarity1.Entitiy;
namespace Similarity1
{
    public class Global : System.Web.HttpApplication
    {
        Entitiy.My_Entitiy model = new Entitiy.My_Entitiy();

        #region CalcSimilarty

        static int ComputeLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;
            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;
            if (sourceWordCount == 0)
                return targetWordCount;
            if (targetWordCount == 0)
                return sourceWordCount;

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;
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
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }

        #endregion


        protected void Application_Start(object sender, EventArgs e)
        {
            //Uygulamayı ilk başlatığın yer
            List<HOMEWORK> scanned = model.HOMEWORK.ToList();
            List<HOMEWORK> notscanned = model.HOMEWORK.Where(x => x.ISSCAN == false).ToList();
            decimal temp = 0, calculated = 0;

            foreach (HOMEWORK item in notscanned)
            {
                foreach (HOMEWORK list in scanned)
                {
                    if (item.ID != list.ID)
                    {
                        calculated = decimal.Parse(CalculateSimilarity(item.CONTEXT, list.CONTEXT).ToString());
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

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}