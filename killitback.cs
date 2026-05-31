using System;
using System.Collections;
using System.Collections.Generic;

#region Director

class Director : ICloneable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Director() { }

    public Director(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public object Clone()
    {
        return new Director(FirstName, LastName);
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}

#endregion

#region Genre

enum Genre
{
    Action,
    Comedy,
    Drama,
    Horror,
    Adventure,
    ScienceFiction
}

#endregion

#region Movie

class Movie : ICloneable, IComparable<Movie>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Director Director { get; set; }
    public string Country { get; set; }
    public Genre Genre { get; set; }
    public int Year { get; set; }
    public short Rating { get; set; }

    public Movie() { }

    public Movie(
        string title,
        string description,
        Director director,
        string country,
        Genre genre,
        int year,
        short rating)
    {
        Title = title;
        Description = description;
        Director = director;
        Country = country;
        Genre = genre;
        Year = year;
        Rating = rating;
    }

    public object Clone()
    {
        return new Movie(
            Title,
            Description,
            (Director)Director.Clone(),
            Country,
            Genre,
            Year,
            Rating
        );
    }

    public int CompareTo(Movie other)
    {
        if (other == null)
            return 1;

        return Rating.CompareTo(other.Rating);
    }

    public override string ToString()
    {
        return
            $"Title: {Title}\n" +
            $"Director: {Director}\n" +
            $"Country: {Country}\n" +
            $"Genre: {Genre}\n" +
            $"Year: {Year}\n" +
            $"Rating: {Rating}/10\n" +
            $"Description: {Description}\n";
    }
}

#endregion

#region Comparers

class CompareByRating : IComparer<Movie>
{
    public int Compare(Movie x, Movie y)
    {
        return x.Rating.CompareTo(y.Rating);
    }
}

class CompareByYear : IComparer<Movie>
{
    public int Compare(Movie x, Movie y)
    {
        return x.Year.CompareTo(y.Year);
    }
}

#endregion

#region Cinema

class Cinema : IEnumerable<Movie>
{
    private List<Movie> movies = new List<Movie>();

    public string Address { get; set; }

    public Cinema(string address)
    {
        Address = address;
    }

    public void AddMovie(Movie movie)
    {
        movies.Add(movie);
    }

    public void Sort()
    {
        movies.Sort();
    }

    public void Sort(IComparer<Movie> comparer)
    {
        movies.Sort(comparer);
    }

    public IEnumerator<Movie> GetEnumerator()
    {
        return movies.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

#endregion

class Program
{
    static void Main()
    {
        Cinema cinema = new Cinema("221B Baker Street");

        cinema.AddMovie(
            new Movie(
                "Inception",
                "A thief enters dreams to steal information.",
                new Director("Christopher", "Nolan"),
                "USA",
                Genre.ScienceFiction,
                2010,
                9));

        cinema.AddMovie(
            new Movie(
                "The Shining",
                "A family stays in a haunted hotel.",
                new Director("Stanley", "Kubrick"),
                "USA",
                Genre.Horror,
                1980,
                8));

        cinema.AddMovie(
            new Movie(
                "Interstellar",
                "Humanity searches for a new home.",
                new Director("Christopher", "Nolan"),
                "USA",
                Genre.ScienceFiction,
                2014,
                10));

        Console.WriteLine("=== ORIGINAL ===\n");

        foreach (Movie movie in cinema)
        {
            Console.WriteLine(movie);
        }

        cinema.Sort();

        Console.WriteLine("=== SORTED BY RATING (IComparable) ===\n");

        foreach (Movie movie in cinema)
        {
            Console.WriteLine(movie);
        }

        cinema.Sort(new CompareByYear());

        Console.WriteLine("=== SORTED BY YEAR (IComparer) ===\n");

        foreach (Movie movie in cinema)
        {
            Console.WriteLine(movie);
        }
    }
}

// Wallahi chatgpt only formatted the code I did everything myself
