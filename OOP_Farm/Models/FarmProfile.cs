using System;
using System.Collections.Generic;
using System.Configuration;
using Newtonsoft.Json;
using OOP_Farm.Models.Animals;
using OOP_Farm.Models.Enums;

namespace OOP_Farm.Models
{
    static class FarmProfile
    {
        static public int Balance = Convert.ToInt32(ConfigurationManager.AppSettings["balance"]);
        static public int[] countOfAnimal = new int[4];
        static readonly string[] namesOfAnimals = { "Корова", "Свинья", "Козел", "Курица" };
        static public List<DefaultAnimal> ListAnimals = new();
        static  readonly Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        /// <summary>
        /// Инициализация профиля.
        /// </summary>
        public static void Init()
        {
            string cfgGrowingValue = config.AppSettings.Settings["growingValue"].Value;
            string[] listGrowingValue = cfgGrowingValue.Split(',');

            List<DefaultAnimal> animals = new List<DefaultAnimal>() { new Cow(), new Pig(), new Goat(), new Chicken() };

            // Проблема в том, что в
            // ListAnimals добавляются лишь
            // ссылки на элемент из массива animals,
            // а не значения.

            for (int i = 0; i < namesOfAnimals.Length; i++)
            {
                int value = Convert.ToInt32(config.AppSettings.Settings[namesOfAnimals[i].ToString()].Value);
                if (value != 0 && ListAnimals.Count <= 10)
                {
                    for (int j = 0; j < value; j++)
                    {

                        ListAnimals.Add(animals[i]);
                    }
                }
            }

            for (int i = 0; i < ListAnimals.Count; i++)
            {
                ListAnimals[i].CurrentGrowth = int.Parse(listGrowingValue[i]);
            }
            Timer timer = new Timer(new TimerCallback(StartAnimalGrowingTimer), null, 10000, 5000);
        } 
        /// <summary>
        /// Вывод  на консоль состояния профиля.
        /// </summary>
        public static void Print()
        {
            Console.Clear();

            int i = 0;
            int counter = 0;
            Console.WriteLine("Ваш баланс составляет: {0} руб", Balance);
            Console.WriteLine("Ваше хозяйство: ");
            foreach (var item in ListAnimals)
            {
                Console.Write(++i + ": ");
                item.PrintAnimalDescription(counter);
                counter++;
            }

        }
        /// <summary>
        /// Метод, срабатывающий по тику таймера.
        /// </summary>
        /// <param name="obj"></param>
        static void StartAnimalGrowingTimer(object? obj)
        {
            for (int i = 0; i < ListAnimals.Count; i++)
            {
                if (ListAnimals[i].CurrentGrowth >= ListAnimals[i].MaxGrowth)
                {
                    ListAnimals[i].Age = Age.Взрослая;
                    ListAnimals[i].CurrentGrowth = 0;
                }
                else
                {
                    ListAnimals[i].CurrentGrowth++;
                }
            }
            UpdateGrowingProcessCfg();

        }
        /// <summary>
        /// Обновление значения роста животного в App.config.
        /// </summary>
        private static void UpdateGrowingProcessCfg()
        {
            string parseGrowingProcessToCfg = "";

            for (int i = 0; i < ListAnimals.Count; i++)
            {
                parseGrowingProcessToCfg += ListAnimals[i].CurrentGrowth.ToString() + ",";

            }
            config.AppSettings.Settings["GrowingValue"].Value = parseGrowingProcessToCfg;
            config.Save();
        }
        /// <summary>
        /// Запись изменний в App.config
        /// </summary>
        public static void UpdateAppCfg() 
        {
            config.AppSettings.Settings["balance"].Value = Balance.ToString();
            for (int i = 0; i < namesOfAnimals.Length; i++)
            {
                int countFromCfg = Convert.ToInt32(config.AppSettings.Settings[namesOfAnimals[i].ToString()].Value);
                int count = 0;
                int index = 0;
                for (int j = 0; j < ListAnimals.Count; j++)
                {
                    if (ListAnimals.Count > index)
                    {
                        if (ListAnimals[index].AnimalName == namesOfAnimals[i])
                        {
                            count++;
                            index++;
                        }
                    }
                    if (index != countFromCfg)
                    {
                        countFromCfg = count;
                        config.AppSettings.Settings[namesOfAnimals[i].ToString()].Value = countFromCfg.ToString();

                    }
                }
            }

            UpdateGrowingProcessCfg();

            config.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}