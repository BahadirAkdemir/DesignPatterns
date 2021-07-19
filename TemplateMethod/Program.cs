using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm algorithm;
            Console.WriteLine("Men");
            algorithm = new MenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0,2,34)));
            Console.WriteLine("Women");
            algorithm = new WomenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 2, 34)));
            Console.WriteLine("Children");
            algorithm = new ChildrenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 2, 34)));

            Console.ReadLine();
        }
    }

    abstract class ScoringAlgorithm
    {
        public int GenerateScore(int hits,TimeSpan time)
        {
            int score = CalCulateBaseScore(hits);
            int reduction = CalculareReduction(time);
            return CalculateOverallScore(score,reduction);
        }

        public abstract int CalculateOverallScore(int score, int reduction);

        public abstract int CalCulateBaseScore(int hits);
        public abstract int CalculareReduction(TimeSpan time);  
    }

    class MenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculareReduction(TimeSpan time)
        {
            return (int)(time.TotalSeconds / 5);
        }

        public override int CalCulateBaseScore(int hits)
        {
            return hits*100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
    }

    class ChildrenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculareReduction(TimeSpan time)
        {
            return (int)(time.TotalSeconds / 50);
        }

        public override int CalCulateBaseScore(int hits)
        {
            return hits * 120;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
    }

    class WomenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculareReduction(TimeSpan time)
        {
            return (int)(time.TotalSeconds / 3);
        }

        public override int CalCulateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
    }
}
