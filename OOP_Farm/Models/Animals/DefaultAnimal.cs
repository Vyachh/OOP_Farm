using OOP_Farm.Models.Enums;
namespace OOP_Farm.Models.Animals
{
    class DefaultAnimal
    {
        virtual public string? AnimalName { get; }
        virtual public int BuyPrice { get; }
        virtual public int SellPrice { get; }
        public Age Age { get; set; }
        virtual public int MaxGrowth { get; }
        virtual public int CurrentGrowth { get; set; }
        virtual public void PrintAnimalDescription(int i)
        {
            Console.WriteLine($"{AnimalName}, " +
                $"Возраст особи: {Age}," +
                $"Рост: {FarmProfile.ListAnimals[i].CurrentGrowth}/ {FarmProfile.ListAnimals[i].MaxGrowth}");
        }
    }
}
