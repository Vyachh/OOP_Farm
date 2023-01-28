using System.Configuration;
using System.Text.Json;
namespace OOP_Farm.Models
{
    static class FarmProfile
    {
        static public int balance = Convert.ToInt32(ConfigurationManager.AppSettings["balance"]);
        static public int[] countOfAnimal = new int[4];
        static private string[] namesOfAnimals = { "Корова", "Свинья", "Козел", "Курица" };
        static public List<Animals> ListAnimals = new();
        static Timer timer = new Timer(new TimerCallback(StartAnimalGrowingTimer), null, 0, 5000);
        static private readonly Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        static void StartAnimalGrowingTimer(object? obj)
        {
            for (int i = 0; i < ListAnimals.Count; i++)
            {
                if (ListAnimals[i].currentGrowth >= ListAnimals[i].maxGrowth)
                {
                    ListAnimals[i].Age = Age.Взрослая;
                    ListAnimals[i].currentGrowth = 0;
                }
                else
                {
                    ListAnimals[i].currentGrowth++;
                }
            }
            UpdateGrowingProcessCfg();

        }
        public static void Print()
        {
            int counter = 0;
            Console.WriteLine("Ваш баланс составляет: {0} руб", balance);
            Console.WriteLine("Ваше хозяйство: ");
            foreach (var item in ListAnimals)
            {
                item.PrintAnimalDescription(counter);
                counter++;
            }
        }
        public static void Init()
        {
            string cfgGrowingValue = config.AppSettings.Settings["growingValue"].Value;
            string[] listGrowingValue = cfgGrowingValue.Split(',');
            Animals[] animals = { new Cow(), new Pig(), new Goat(), new Chicken() };

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
                ListAnimals[i].currentGrowth = int.Parse(listGrowingValue[i]);
            }
        }
        private static void UpdateGrowingProcessCfg()
        {
            string parseGrowingProcessToCfg = "";

            for (int i = 0; i < ListAnimals.Count; i++)
            {
                parseGrowingProcessToCfg += ListAnimals[i].currentGrowth.ToString() + ",";

            }
            config.AppSettings.Settings["GrowingValue"].Value = parseGrowingProcessToCfg;
            config.Save();
            }
        public static void UpdateAppCfg() // Запись изменний в app.config
        {
            config.AppSettings.Settings["balance"].Value = balance.ToString();
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