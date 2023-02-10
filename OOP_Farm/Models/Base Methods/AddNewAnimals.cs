using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Farm;
using OOP_Farm.Models.Animals;

namespace OOP_Farm.Models.Base_Methods
{
    static class AddNewAnimals
    {
        public static void Open()
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
            DefaultAnimal[] animals = { new Cow(), new Pig(), new Goat(), new Chicken() };
            if (FarmProfile.Balance >= animals[sw - 1].BuyPrice)
            {
                switch (sw)
                {
                    case 1:
                        FarmProfile.Balance -= 5000;
                        FarmProfile.ListAnimals.Add(new Cow());
                        Console.WriteLine("Покупка проведена успешно! Ваш баланс: {0}", FarmProfile.Balance);
                        break;
                    case 2:
                        FarmProfile.Balance -= 3500;
                        FarmProfile.ListAnimals.Add(new Goat());
                        Console.WriteLine("Покупка проведена успешно! Ваш баланс: {0}", FarmProfile.Balance);

                        break;
                    case 3:
                        FarmProfile.Balance -= 2000;
                        FarmProfile.ListAnimals.Add(new Pig());
                        Console.WriteLine("Покупка проведена успешно! Ваш баланс: {0}", FarmProfile.Balance);

                        break;
                    case 4:
                        FarmProfile.Balance -= 500;
                        FarmProfile.ListAnimals.Add(new Chicken());
                        Console.WriteLine("Покупка проведена успешно! Ваш баланс: {0}", FarmProfile.Balance);
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
            Program.MainMenu();
        }
    }
}
