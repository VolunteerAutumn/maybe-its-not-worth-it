using System;

interface IOutput
{
    void Show();
    void Show(string info);
}

interface IMath
{
    int Max();
    int Min();
    float Avg();
    bool Search(int valueToSearch);
}

//class Array<T> : IOutput, IMath
//{
//    private T[] data;

//    public Array(int size)
//    {
//        data = new T[size];
//    }

//    public void Set(int index, T value)
//    {
//        data[index] = value;
//    }

//    public T Get(int index)
//    {
//        return data[index];
//    }

//    public void Show()
//    {
//        foreach (T item in data)
//        {
//            Console.WriteLine(item);
//        }
//    }

//    public void Show(string info)
//    {
//        Console.WriteLine(info);

//        foreach (T item in data)
//        {
//            Console.WriteLine(item);
//        }
//    }

//    public int Max()
//    {
//        // Implementation for finding max value (not implemented for generic type)
//        throw new NotImplementedException();
//    }
//    public int Min()
//    {
//        // Implementation for finding min value (not implemented for generic type)
//        throw new NotImplementedException();
//    }
//    public float Avg()
//    {
//        // Implementation for calculating average value (not implemented for generic type)
//        throw new NotImplementedException();
//    }
//    public bool Search(int valueToSearch)
//    {
//        // Implementation for searching a value (not implemented for generic type)
//        throw new NotImplementedException();
//    }
//}

class IntArray : IOutput, IMath
{
    private int[] data;

    public IntArray(int size)
    {
        data = new int[size];
    }

    public void Set(int index, int value)
    {
        data[index] = value;
    }

    public int Get(int index)
    {
        return data[index];
    }

    public void Show()
    {
        foreach (int item in data)
        {
            Console.WriteLine(item);
        }
    }

    public void Show(string info)
    {
        Console.WriteLine(info);

        foreach (int item in data)
        {
            Console.WriteLine(item);
        }
    }

    public int Max()
    {
        int max = data[0];
        foreach (int item in data)
        {
            if (item > max)
            {
                max = item;
            }
        }
        return max;
    }
    public int Min()
    {
        int min = data[0];
        foreach (int item in data)
        {
            if (item < min)
            {
                min = item;
            }
        }
        return min;
    }
    public float Avg()
    {
        int sum = 0;
        foreach (int item in data)
        {
            sum += item;
        }
        return (float)sum / data.Length;
    }
    public bool Search(int valueToSearch)
    {
        foreach (int item in data)
        {
            if (item == valueToSearch)
            {
                return true;
            }
        }
        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // #region testing_array
        //Array<int> numbers = new Array<int>(3);
        //numbers.Set(0, 10);
        //numbers.Set(1, 20);
        //numbers.Set(2, 30);

        //numbers.Show("integer array //");
        //Console.WriteLine("// /");

        //Array<string> names = new Array<string>(2);
        //names.Set(0, "Eevee");
        //names.Set(1, "Umbreon");

        //names.Show("pokemon array //");
        //Console.WriteLine("// /");

        //Array<double> values = new Array<double>(2);
        //values.Set(0, 3.14);
        //values.Set(1, 2.71);

        //values.Show("val array //");
        //Console.WriteLine("// /");
        //#endregion
        
        IntArray intArray = new IntArray(5);
        intArray.Set(0, 10);
        intArray.Set(1, 20);
        intArray.Set(2, 30);
        intArray.Set(3, 40);
        intArray.Set(4, 50);

        intArray.Show("Integer Array //");
        Console.WriteLine("Max: " + intArray.Max());
        Console.WriteLine("Min: " + intArray.Min());
        Console.WriteLine("Avg: " + intArray.Avg());
        Console.WriteLine("Search for 30: " + intArray.Search(30));
        Console.WriteLine("Search for 60: " + intArray.Search(60));
        Console.WriteLine("// /");
    }
}
