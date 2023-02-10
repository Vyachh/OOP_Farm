using OOP_Farm.Models.Animals;
using OOP_Farm.Models.Enums;

namespace OOP_Farm.Models.Base_Methods
{
    static class DeleteExistingAnimals
    {
        public static void Open()
        {
            Console.Clear();
            Console.WriteLine("Удаление существующих животных" +
                "\n Ваш инвентарь: ");

            FarmProfile.Print();

            Console.WriteLine("Кого хотите продать?");

            int index = Convert.ToInt32(Console.ReadLine()) - 1;
            var animalFromList = FarmProfile.ListAnimals[index];

            if (animalFromList.Age == Age.Взрослая)
            {
                FarmProfile.Balance += animalFromList.SellPrice;
                FarmProfile.ListAnimals.Remove(animalFromList);
                FarmProfile.UpdateAppCfg();
                Console.WriteLine($"Вы успешно продали животное {animalFromList.AnimalName}! Ваш баланс составляет: {FarmProfile.Balance}");
            }
            else
            {
                Console.WriteLine("Нельзя продавать животное, пока оно не выросло.");
            }
            Task.Delay(1000).Wait();
            Console.Clear();
            Program.MainMenu();
        }
    }
}
