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
            int result = CutRod(profit, profit.Length);

            Console.WriteLine("Optimal Solution is:{0}", result);
        }

        static int CutRod(int[] profit, int n)
        {
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
    }
}
