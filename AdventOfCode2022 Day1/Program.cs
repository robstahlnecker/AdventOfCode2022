using System;

namespace AdventOfCode2022_Day1
{
    internal static class Program
    {
        private const string FilePath = @"";

        static void Main(string[] args)
        {
            List<Elf> elves = new();
            List<int> foodCalories = new();

            //Add a blank new line at the end so we process the last elf. 
            foreach (string line in File.ReadAllLines(FilePath).Concat(new string[] { string.Empty }))
            {
                if (string.IsNullOrEmpty(line))
                {
                    elves.Add(new Elf(foodCalories.Select(x => new Food(x)).ToArray()));
                    foodCalories.Clear();
                }
                else
                {
                    foodCalories.Add(int.Parse(line));
                }
            }

            var evlesWthMostCaloriesDesc = elves.OrderByDescending(elf => elf.FoodItems.Sum(food => food.Calories)).ToList();
            Console.WriteLine($"Total calories for top 1: ({evlesWthMostCaloriesDesc.Take(1).SelectMany(x => x.FoodItems).Sum(x => x.Calories)})");
            Console.WriteLine($"Total calories for top 3: ({evlesWthMostCaloriesDesc.Take(3).SelectMany(x => x.FoodItems).Sum(x => x.Calories)})");
            Console.ReadKey();
        }
    }
}
