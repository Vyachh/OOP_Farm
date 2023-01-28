using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Farm.Models
{
    class Animals
    {
        virtual public string? AnimalName { get; }

        virtual public int Price { get; }

        public Age Age { get; set; }

         virtual public int maxGrowth { get; }
        virtual public int currentGrowth { get; set; }


        virtual public void PrintAnimalDescription(int i) { 
            Console.WriteLine($"{AnimalName}, " +
                $"Возраст особи: {Age}," +
                $"Рост: {FarmProfile.ListAnimals[i].currentGrowth}/ {FarmProfile.ListAnimals[i].maxGrowth}");
        }
    }
    class Cow : Animals
    {
        public override string AnimalName => "Корова";
        public override int Price => 5000;
        public override int maxGrowth => 250;
    }
    class Pig : Animals
    {
        public override string AnimalName => "Свинья";
        public override int Price => 3500;
        public override int maxGrowth => 200;

    }
    class Goat : Animals
    {
        public override string AnimalName => "Козел";
        public override int Price => 2000;
        public override int maxGrowth => 150;

    }
    class Chicken : Animals
    {
        public override string AnimalName => "Курица";
        public override int Price => 500;
        public override int maxGrowth => 50;

    }
    enum Age
    {
        Молодая,
        Взрослая 
    }

}
