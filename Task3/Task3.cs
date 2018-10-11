using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Task3
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            int N = Int32.Parse(sr.ReadLine());
            sr.Close();

            int[] outArr = new int[N];
            outArr[0] = 1;
            if (N != 1)
            {
                outArr[1] = 2;
                for (int i = 2; i < N; i++)
                {
                    outArr[i] = outArr[i / 2];
                    outArr[i / 2] = i + 1;
                }
            }
            StreamWriter sw = new StreamWriter("output.txt");

            foreach (int elem in outArr)
                sw.Write(elem + " ");

            sw.Close();
        }
    }
}
