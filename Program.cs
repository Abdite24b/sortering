using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int[] sizes = { 10, 100, 1000, 10000, 100000 };
        Random random = new Random();

        Console.WriteLine("Antal tal | Bubble Sort (ms) | Insertion Sort (ms)");
        Console.WriteLine("-----------------------------------------------");

        foreach (int size in sizes)
        {
            int[] array1 = CreateRandomArray(size, random);
            int[] array2 = (int[])array1.Clone();

            long bubbleTime = MeasureTime(() => BubbleSort(array1));
            long insertionTime = MeasureTime(() => InsertionSort(array2));

            Console.WriteLine($"{size,9} | {bubbleTime,16} | {insertionTime,19}");
        }
    }

    static int[] CreateRandomArray(int size, Random random)
    {
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(1, 100000);
        }
        return array;
    }

    static long MeasureTime(Action sortMethod)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        sortMethod();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    // Bubble Sort
    static void BubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    // Insertion Sort
    static void InsertionSort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }
}
