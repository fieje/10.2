using System;
using System.IO;
using System.Linq;

public class Program
{
    static void Main()
    {
        string filePath = "t.txt";

        int shortestWordLength = FindShortestWordLength(filePath);

        if (shortestWordLength == -1)
        {
            Console.WriteLine("No words found in the file.");
        }
        else
        {
            Console.WriteLine($"Length of shortest word in the file: {shortestWordLength}");
        }

        Console.ReadLine(); 
    }

    public static int FindShortestWordLength(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }

        try
        {
            string[] words = File.ReadAllText(filePath).Split(new char[] { ' ', '\r', '\n', '\t', '.', ',', ';', ':', '-', '!', '?', '(', ')', '[', ']', '{', '}' }, 
                StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
            {
                return -1; 
            }

            int shortestLength = words.Min(word => word.Length);
            return shortestLength;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return -1;
        }
    }
}
