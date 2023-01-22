using OOP_Farm.Enum;
using System.Configuration;

namespace OOP_Farm
{
    static class FarmProfile
    {
        static public int balance = Convert.ToInt32(ConfigurationManager.AppSettings["balance"]);
        static public int[] countOfAnimal = new int[4];
        static private string[] namesOfAnimals = { "Cow", "Pig", "Goat", "Chicken" };
        public static List<Animals> ListAnimals = new();

        public static void Print()
        {
            Console.WriteLine("Ваш баланс составляет: {0} руб", balance);
            Console.WriteLine("Ваше хозяйство: ");
            foreach (var item in ListAnimals)
            {
                item.PrintAnimalName();
            }
        }
        public static void Init()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Animals[] animals = { new Cow(), new Pig(), new Goat(), new Chicken() };
            for (int i = 0; i < namesOfAnimals.Length; i++)
            {
                int value = Convert.ToInt32(config.AppSettings.Settings[namesOfAnimals[i].ToString()].Value);
                if (value != 0)
                {
                    for (int j = 0; j < value; j++)
                    {
                        ListAnimals.Add(animals[i]);
                    }                
                }
            }
        }
        public static void UpdateAppCfg() // Запись изменний в app.config
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
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
                        if (ListAnimals[index].AnimalType == namesOfAnimals[i])
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
            config.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}