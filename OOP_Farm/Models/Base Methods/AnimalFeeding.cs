using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OOP_Farm.Models.Base_Methods.Nutritions;

namespace OOP_Farm.Models.Base_Methods
{
    static class AnimalFeeding
    {
        static string? operation;
        static int index;
        /// <summary>
        /// Выводит меню AnimalFeeding и предоставляет выбор доступных дальнейших действий.
        /// </summary>
        public static void Open()
        {
            Console.Clear();
            Console.WriteLine("Кормление животных.");

            Console.WriteLine("1. Магазин с кормом" +
                "\n2. Перейти к кормлению" +
                "\n3. Выход");

            operation = Console.ReadLine();

            switch (operation)
            {
                case "1": OpenNutritionShop(); break; // Выбор нужного корма.
                case "2": AnimalFeedingProcessStart(); break;
                case "3": Program.MainMenu(); break;
                default:
                    Open();
                    break;
            }
        }

        private static void OpenNutritionShop()
        {
            Console.WriteLine("Ваш баланс: " + FarmProfile.Balance);
            Task.Delay(500).Wait();
            Console.WriteLine("Выберите корм:");

            Nutrition.PrintNutritionList();

            index = Convert.ToInt32(Console.ReadLine());
            if (/*инвентарь лист > FarmProfile.Balance*/ true )
            {

            }

        }

        private static void AnimalFeedingProcessStart()
        {
            FarmProfile.Print();
            Console.WriteLine("Выберите животное, которое хотите покормить.");
            int index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Животное успешно выбрано!");
            Task.Delay(1000).Wait();
            OpenNutritionChose(index);
        }
        private static void OpenNutritionChose(int index) // Отдельный метод, для того чтобы 
        {                                                 // не приходилось каждый раз выбирать 
            Console.Clear();                              // заново животное и сразу переходить к выбору корма
            Console.WriteLine("Выберите корм: ");

            // Корм из инвентаря, купленный

            index = Convert.ToInt32(Console.ReadLine());
            if (Nutrition.GetNutritionList()[--index].Price > FarmProfile.Balance)
            {
                Console.WriteLine("Животное успешно покормлено! Его рост теперь составляет: ");
                Console.WriteLine(FarmProfile.ListAnimals[++index].CurrentGrowth);
                Task.Delay(1000);
                Program.MainMenu();
            }
            else
            {
                Console.WriteLine("Денег не хватает.");
                Task.Delay(1000);
                OpenNutritionChose(index);
            }

        }
    }
}
