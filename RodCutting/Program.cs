using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodCutting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] profit = new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };
            //int result = CutRod(profit, profit.Length);
            //int result = MemoizedCutRod(profit, profit.Length);
            int result = BottomUpCutRod(profit, profit.Length);

            Console.WriteLine("Optimal Solution is:{0}", result);
        }

        static int CutRod(int[] profit, int n)
        {
           int time= gettime();
            if (n == 0) // first element is 0
                return 0;

            int q = int.MinValue;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Calculating for {0},{1}", i, n);
                q = Math.Max(q, profit[i - 1] + CutRod(profit, n - i));
            }

            //Console.WriteLine("N={0}, Q={1}", n, q);
            Console.WriteLine();

            return q;
        }

        static int MemoizedCutRod(int[] profit, int n)
        {
            int time = gettime();
            int[] r = new int[n];
            for (int i = 0; i < n; i++)
                r[i] = int.MinValue;

            return MemoizedCutRodAux(profit, r, n);
        }

        static int MemoizedCutRodAux(int[] profit, int[] r, int n)
        {
            int time= gettime();
            if (n > 0 && r[n - 1] >= 0)
                return r[n - 1];

            int q = int.MinValue;

            if (n == 0)
            {
                q = 0;
                return 0;
            }
            else
            {
                for (int i = 1; i <= n; i++)
                    q = Math.Max(q, profit[i - 1] + MemoizedCutRodAux(profit, r, n - i));
            }

            r[n - 1] = q;

            return q;
        }

        static int BottomUpCutRod(int[] profit, int n)
        {
            int time = gettime();
            int[] r = new int[n + 1]; 
            r[0] = 0;

            for (int j = 1; j <= n; j++)
            {
                int q = int.MinValue;
                for (int i = 1; i <= j; i++)
                {
                    q = Math.Max(q, profit[i-1] + r[j - i]);
                }
                r[j] = q;
            }

            return r[n];
        }
    }
}
