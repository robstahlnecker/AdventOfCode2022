namespace AdventOfCode2022_Day1
{
    public class Elf
    {
        public IEnumerable<Food> FoodItems { get; private set; }

        public Elf(IEnumerable<Food> foodItems)
        {
            FoodItems = foodItems ?? Enumerable.Empty<Food>();
        }
    }
}
