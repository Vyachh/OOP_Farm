using System.ComponentModel;
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
            MainMenu();
        }
        static void MainMenu()
        {

            Console.WriteLine("Меню:"
                              + "\n 1. Привоз новых животных"
                              + "\n 2. Кормление животных"
                              + "\n 3. Увоз на убой"
                              + "\n 4. Профиль"
                              + "\n 5. Выход");
            int sw = Convert.ToInt32(Console.ReadLine());
            switch (sw)
            {
                case 1: AddNewAnimals(); break;
                case 2: AnimalFeeding(); break;
                case 3: DeleteExistingAnimals(); break;
                case 4:
                    Console.Clear();
                    FarmProfile.UpdateAppCfg();
                    FarmProfile.Print();
                    Console.WriteLine("Для перехода в главное меню, нажмите на любую клавишу...");
                    Console.ReadKey();
                    Console.Clear();
                    MainMenu();
                    break;
                case 5: Environment.Exit(0); break;
                default:

                    MainMenu();
                    break;
            }
        }
        static void AddNewAnimals()
        {

            Console.Clear();
            Console.WriteLine("Добавление новых животных");
            Console.WriteLine("Кого вы хотите завести?" +
                "\n 1. Корова, цена: 5000 руб." +
                "\n 2. Свинья, цена: 3500 руб." +
                "\n 3. Коза, цена: 2000 руб." +
                "\n 4. Курица, цена: 500 руб."
                );
            int sw = Convert.ToInt32(Console.ReadLine());
            Animals[] animals = { new Cow(), new Pig(), new Goat(), new Chicken() };
            if (FarmProfile.balance >= animals[sw - 1].Price && FarmProfile.ListAnimals.Count <= 10)
            {
                switch (sw)
                {
                    case 1:
                            FarmProfile.balance -= 5000;
                            FarmProfile.ListAnimals.Add(new Cow());
                            Console.WriteLine("Покупка проведена успешно! Ваш баланс: {0}", FarmProfile.balance);
                        break;
                    case 2:
                            FarmProfile.balance -= 3500;
                            FarmProfile.ListAnimals.Add(new Goat());
                            Console.WriteLine("Покупка проведена успешно! Ваш баланс: {0}", FarmProfile.balance);
                        
                        break;
                    case 3:
                            FarmProfile.balance -= 2000;
                            FarmProfile.ListAnimals.Add(new Pig());
                            Console.WriteLine("Покупка проведена успешно! Ваш баланс: {0}", FarmProfile.balance);
                        
                        break;
                    case 4:
                            FarmProfile.balance -= 500;
                            FarmProfile.ListAnimals.Add(new Chicken());
                            Console.WriteLine("Покупка проведена успешно! Ваш баланс: {0}", FarmProfile.balance);
                        break;
                    default:
                        Console.WriteLine("Указан неверный номер!");
                        break;
                }
                FarmProfile.UpdateAppCfg();
            }
            else

            {
                Console.WriteLine("Недостаточно средств!");
            }

            Task.Delay(1000).Wait();
            Console.Clear();
            MainMenu();

        }
        static void AnimalFeeding() // Сделоть
        {
            Console.WriteLine("Кормление животных");

        }
        static void DeleteExistingAnimals() // Сделоть
        {
            Console.WriteLine("Удаление существующих животных");
        }
    }
}