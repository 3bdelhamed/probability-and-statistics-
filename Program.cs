
using System;
namespace program { 

  class Program
  {
        public static void Main(){


            Console.WriteLine("enter n number");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            Console.WriteLine("#*#*#*#*#*##*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#**##*#**##*#*#*#*#*#*");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            Array.Sort(arr);
            Console.WriteLine("#*#*#*#*#*##*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#*#**##*#**##*#*#*#*#*#*");
            Console.WriteLine("Ur data After sort ");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("\n1. The median : " + GetMedian(arr, n));

            Mode(arr);

            Console.Write("3. The range of the values : ");
            Range(arr, n);
            Console.WriteLine("The first Quartile : " + FirstQuartile(arr, n));
            Console.WriteLine("The third Quartile : " + ThirdQuartile(arr, n));
            Console.WriteLine("7. outlier lower  boundary :" + LowerBoundaries(arr, n));
            Console.WriteLine("   outlier upper  boundary :" + UpperBoundaries(arr, n));
            Console.WriteLine("p90 :" + P90(arr, n));
            Console.WriteLine("8. IQR :" + Iqr(arr, n));
            IsAnOutlier(arr, n);
        }



        
      
             static void Mode(int[] arr)
            {
                int[] distinct = arr.Distinct().ToArray();
                int[] count = new int[distinct.Length];

                for (int i = 0; i < distinct.Length; i++)
                {
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (distinct[i] == arr[j])
                        {
                            count[i]++;
                        }
                    }
                }


                for (int i = 0; i < count.Length; i++)
                {
                    if (count[i] == count.Max())
                    {
                        Console.WriteLine("Mode is : " + distinct[i]);
                    }
                    
                }
            }



        static float GetMedian(int[] arrSource,int n)
        {
            float median;
            if (n%2!=0)
            {
                median = arrSource[n / 2] ;
                return median;

            }
            
            else
            {
                median = (float)(arrSource[n / 2 -1] + arrSource[n / 2 ]) / 2 ;
            }
            return median;
        }

        static void Range(int[] arr, int n)
        {
            Console.WriteLine(arr[n - 1] - arr[0]);
        }

        static float FirstQuartile(int[] arr,int n)
        {
            if (n%2!=0)
            {
               return GetMedian(arr, (n / 2) );
            }
            else
            {
                return GetMedian(arr, (n / 2) - 1);

            }
        }

        static float ThirdQuartile(int[] arr, int n)
        {
            int sTemp = n - ((n / 2) + 1);
            int[] temp = new int[sTemp];

            if (n % 2 != 0)
            {
               
                for (int i = 0; i < sTemp; i++)
                {
                    temp[i] = arr[(n / 2) + 1 + i];
                }

                return (GetMedian(temp, sTemp));
            }
            else
            {
                for (int i = 0; i < sTemp; i++)
                {
                    temp[i] = arr[(n / 2) + 1 + i];
                }
                 return (GetMedian(temp, sTemp));
            }
        }

        
        static float Iqr(int[] arr, int n)
        {
            return ThirdQuartile(arr, n) - FirstQuartile(arr, n);
        }
         
        static float LowerBoundaries(int[] arr, int n)
        {
             return FirstQuartile(arr,n) - ((1.5f) * Iqr(arr,n));
             
        }
        static float UpperBoundaries(int[] arr, int n)
        {
            return ThirdQuartile(arr, n) + ((1.5f)* Iqr(arr, n));
        }
        static void IsAnOutlier(int[] arr, int n)
        {
            Console.WriteLine("enter number to test outlier or not");
            int input = Convert.ToInt32(Console.ReadLine());
            if (input > LowerBoundaries(arr,n) && input< UpperBoundaries(arr,n))
            {
                Console.WriteLine(" value is an outlier ");
            }
            else
            {
                Console.WriteLine(" value isn't an outlier ");

            }
        }
        public static float P90( int[] elements ,int n)

        {
             float p90 = (90 / 100.0f) * n - 1;
             int ceiledIndex = (int)Math.Ceiling(p90);

            return elements[ceiledIndex];
        }


    }
}