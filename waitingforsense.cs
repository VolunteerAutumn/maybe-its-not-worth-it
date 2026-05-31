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

interface ISort
{
    void SortAsc();
    void SortDesc();
    void SortByParam(bool isAsc);
}

class IntArray : IOutput, IMath, ISort
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
    public void SortAsc()
    {
        Array.Sort(data);
    }

    public void SortDesc()
    {
        Array.Sort(data);
        Array.Reverse(data);
    }

    public void SortByParam(bool isAsc)
    {
        if (isAsc)
        {
            Array.Sort(data);
        }
        else
        {
            Array.Sort(data);
            Array.Reverse(data);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        IntArray intArray = new IntArray(5);
        intArray.Set(0, 10);
        intArray.Set(1, 20);
        intArray.Set(2, 30);
        intArray.Set(3, 70);
        intArray.Set(4, 20);

        intArray.Show("Integer Array //");
        Console.WriteLine("Max: " + intArray.Max());
        Console.WriteLine("Min: " + intArray.Min());
        Console.WriteLine("Avg: " + intArray.Avg());
        Console.WriteLine("Search for 30: " + intArray.Search(30));
        Console.WriteLine("Search for 60: " + intArray.Search(60));
        Console.WriteLine("// /");

        intArray.SortDesc();
        intArray.Show("Descending:");

        intArray.SortAsc();
        intArray.Show("Ascending:");

        intArray.SortByParam(false);
        intArray.Show("Descending by Param:");
    }
}
