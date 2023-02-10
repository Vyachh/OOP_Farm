using OOP_Farm.Models.Base_Methods;
using System.Configuration;
using OOP_Farm.Models;
namespace OOP_Farm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigurationManager.RefreshSection("appSettings");
            FarmProfile.Init();
            Console.WriteLine("Добро пожаловать в ООП ферму! С чего начнем?");
            Task.Delay(1000).Wait();
            MainMenu();
        }
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Меню:"
                              + "\n 1. Привоз новых животных"
                              + "\n 2. Кормление животных"
                              + "\n 3. Увоз на убой"
                              + "\n 4. Профиль"
                              + "\n 5. Выход");
            string? sw = Console.ReadLine();
            switch (sw)
            {
                case "1": AddNewAnimals.Open(); break;
                case "2": AnimalFeeding.Open(); break;
                case "3": DeleteExistingAnimals.Open(); break;
                case "4":
                    FarmProfile.UpdateAppCfg();
                    FarmProfile.Print();
                    Console.WriteLine("Для перехода в главное меню, нажмите на любую клавишу...");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case "5": Environment.Exit(0); break;
                default:
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }
    }
}