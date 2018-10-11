using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    class Task2
    {
        public static long Inversions;

        static int[] Merge_Sort(int[] massive)
        {
            if (massive.Length == 1)
                return massive;
            int mid_point = massive.Length / 2;
            return Merge(Merge_Sort(massive.Take(mid_point).ToArray()), Merge_Sort(massive.Skip(mid_point).ToArray()));
        }

        static int[] Merge(int[] firstArr, int[] secondArr)
        {
            int i = 0, j = 0;
            int n = firstArr.Length;
            int m = secondArr.Length;
            int[] result = new int[n + m];
            while (i < n && j < m)
            {
                if (firstArr[i] <= secondArr[j])
                {
                    result[i + j] = firstArr[i];
                    Inversions += j;
                    i++;
                }
                else
                {
                    result[i + j] = secondArr[j];
                    j++;
                }
            }
            while (i < n)
            {
                result[i + j] = firstArr[i];
                Inversions += j;
                ++i;
            }
            while (j < m)
            {
                result[i + j] = secondArr[j];
                j++;
            }
            return result;
        }

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            int N = Int32.Parse(sr.ReadLine());
            int[] array = sr.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray(); // string to array <int>
            sr.Close();
            Merge_Sort(array);
            StreamWriter sw = new StreamWriter("output.txt");
            sw.WriteLine(Inversions);
            sw.Close();
        }
    }
}
