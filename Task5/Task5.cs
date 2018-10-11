using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task5
{
    class Task5
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string[] tmp = sr.ReadLine().Split(' ');
            int N = Int32.Parse(tmp[0]);
            int K = Int32.Parse(tmp[1]);

            int[] array = sr.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray(); // string to array <int>

            for (int i = 0; i < K; i++)
            {
                List<int> tmpList = new List<int>();
                for (int j = i; j < N; j += K)
                {
                    tmpList.Add(array[j]);
                }
                tmpList.Sort();

                for (int j = i, cur = 0; j < N; j += K)
                    array[j] = tmpList[cur++];
            }
            StreamWriter sw = new StreamWriter("output.txt");
            for (int i = 1; i < N; i++)
            {
                if (array[i] < array[i - 1])
                {
                    sw.Write("NO");
                    sw.Close();
                    return;
                }
            }
            sw.Write("YES");
            sw.Close();
     
        }
    }
}
