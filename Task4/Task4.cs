using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Task4
    {
        public static int K1, K2;

        private static void QuickRecursive(ref int[] arr, int low, int high)
        {
            if (high - low < 1)
                return;
            int p = Partition(ref arr, low, high);
            if (K1 - 1 <= p && K2 - 1 >= low) 
                QuickRecursive(ref arr, low, p);
            if (K2 - 1 >= p + 1 && K1 - 1 <= high) 
                QuickRecursive(ref arr, p + 1, high);

        }
        private static int Partition(ref int[] arr, int low, int high)
        //разбиение массива
        {
            int x = arr[(low + high) / 2];
            int i = low - 1;
            int j = high + 1;
            while (true)
            {
                do
                {
                    i++;
                } while (arr[i] < x);
                do
                {
                    j--;
                } while (arr[j] > x);

                if (i >= j)
                    return j;

                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }


        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string[] tmp = sr.ReadLine().Split(' ');
            int N = Int32.Parse(tmp[0]);
            K1 = Int32.Parse(tmp[1]);
            K2 = Int32.Parse(tmp[2]);

            tmp = sr.ReadLine().Split(' ');
            int A = Int32.Parse(tmp[0]);
            int B = Int32.Parse(tmp[1]);
            int C = Int32.Parse(tmp[2]);

            int[] array = new int[N];
            array[0] = Int32.Parse(tmp[3]);
            array[1] = Int32.Parse(tmp[4]);

            for (int i = 2; i < N; i++)
            {
                array[i] = A * array[i - 2] + B * array[i - 1] + C;
            }
            sr.Close();
            QuickRecursive(ref array, 0, array.Length - 1);
            StreamWriter sw = new StreamWriter("output.txt");
            for (int i = K1 - 1; i < K2; i++) 
                sw.Write(array[i] + " ");
            sw.Close();

        }
    }
}
