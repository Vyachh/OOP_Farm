using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Farm
{
    class Animals
    {
        virtual public string? AnimalType { get; }
        virtual public int Price { get; }

        public Age Age { get; set; }

        virtual public void PrintAnimalName() { }
    }
    class Cow : Animals
    {
        public override string AnimalType => "Cow";
        public override int Price => 5000;
        public override void PrintAnimalName()
        {
            Console.WriteLine("Корова");
        }
    }
    class Pig : Animals
    {
        public override string AnimalType => "Pig";
        public override int Price => 3500;
        public override void PrintAnimalName()
        {
            Console.WriteLine("Козел");
        }
    }
    class Goat : Animals
    {
        public override string AnimalType => "Goat";
        public override int Price => 2000;
        public override void PrintAnimalName()
        {
            Console.WriteLine("Свинья");
        }
    }
    class Chicken : Animals
    {
        public override string AnimalType => "Chicken";
        public override int Price => 500;
        public override void PrintAnimalName()
        {
            Console.WriteLine("Курица");
        }
    }
    enum Age
    {
        young,
        old
    }

}
