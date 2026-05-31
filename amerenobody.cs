using System;

interface IOutput
{
    void Show();
    void Show(string info);
}

class Array<T> : IOutput
{
    private T[] data;

    public Array(int size)
    {
        data = new T[size];
    }

    public void Set(int index, T value)
    {
        data[index] = value;
    }

    public T Get(int index)
    {
        return data[index];
    }

    public void Show()
    {
        foreach (T item in data)
        {
            Console.WriteLine(item);
        }
    }

    public void Show(string info)
    {
        Console.WriteLine(info);

        foreach (T item in data)
        {
            Console.WriteLine(item);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        #region testing_array
        Array<int> numbers = new Array<int>(3);
        numbers.Set(0, 10);
        numbers.Set(1, 20);
        numbers.Set(2, 30);

        numbers.Show("integer array //");
        Console.WriteLine("// /");

        Array<string> names = new Array<string>(2);
        names.Set(0, "Eevee");
        names.Set(1, "Umbreon");

        names.Show("pokemon array //");
        Console.WriteLine("// /");

        Array<double> values = new Array<double>(2);
        values.Set(0, 3.14);
        values.Set(1, 2.71);

        values.Show("val array //");
        Console.WriteLine("// /");
        #endregion
    }
}
