using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1;

internal static class DayOne
{
    private const string inputPath = @"DayOne\InputOne.txt";

    private static List<int> calories = new();
    private static List<int> elfCaloriesCarried = new();

    private static void GetFileInput()
    {
        calories.Clear();
        foreach (var line in File.ReadAllLines(inputPath))
        {
            if (line != string.Empty)
            {
                calories.Add(int.Parse(line));
            }
            else if (line == string.Empty)
            {
                TotalUpCalories();
                calories.Clear();
            }
        }
    }

    private static void TotalUpCalories()
    {
        int total = 0;
        foreach (var item in calories)
        {
            total += item;
        }
        elfCaloriesCarried.Add(total);
    }

    private static int GetMostCalories()
    {
        int largest = 0;
        foreach (var item in elfCaloriesCarried)
        {
            if (item > largest)
            {
                largest = item;
            }
        }
        return largest;
    }

    private static int TotalTopThreeCalories()
    {
        TopThree topThree = new();

        foreach (var item in elfCaloriesCarried)
        {
            if (item > topThree.First)
            {
                topThree.Second = topThree.First;
                topThree.First = item;
                continue;
            }
            else if (item > topThree.Second && item < topThree.First)
            {
                topThree.Third = topThree.Second;
                topThree.Second = item;
            }
            else if (item > topThree.Third && item < topThree.Second)
            {
                topThree.Third = item;
            }
        }
        return topThree.TotalTopThree;
    }

    public static int SolvePartOne()
    {
        GetFileInput();
        return GetMostCalories();
    }

    public static int SolvePartTwo()
    {
        return TotalTopThreeCalories();
    }
}

public record TopThree()
{
    public int First { get; set; } = 0;
    public int Second { get; set; } = 0;
    public int Third { get; set; } = 0;
    public int TotalTopThree
    {
        get => First + Second + Third;
    }
}