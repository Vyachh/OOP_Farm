using OOP_Farm.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Farm.Models.Base_Methods.Nutritions
{
    internal class Nutrition

    {

        public string Name { get; }
        public NutritionQuality _NutritionQuality { get; }
        public int GrowthPoints { get; }
        public int Price { get; }
        public Nutrition(string name, int nutritionQuality, int growthPoints, int price)
        {
            Name = name;
            _NutritionQuality = (NutritionQuality)nutritionQuality;
            GrowthPoints = growthPoints;
            Price = price;
        }

        static List<Nutrition> NutritionList = new()
        {
        new Nutrition("Похлебка", 1,5,50),
        new Nutrition("Кэтбучер", 2,15,100),
        new Nutrition("Хот-кэт", 3,25,200),
        new Nutrition("Макакароны", 4,40,300),
        new Nutrition("Шимпанское счастье", 5,50,500)
        };

        public static List<Nutrition> GetNutritionList() => NutritionList;
        public static void AddNewNutrition(Nutrition n)
        {
            NutritionList.Add(n);
        }

        public static void PrintNutritionList()
        {
            for (int i = 0; i < NutritionList.Count; i++)
            {
                Console.WriteLine(++i + $". {NutritionList[--i].Name}, Цена: {NutritionList[i].Price}, Качество: {NutritionList[i]._NutritionQuality}, Прибавляет {NutritionList[i].GrowthPoints} поинтов роста");
            }
        }
    }
}
