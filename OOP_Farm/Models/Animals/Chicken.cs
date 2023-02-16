using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Farm.Models.Animals
{
    class Chicken : DefaultAnimal
    {
        public override string AnimalName => "Курица";
        public override int BuyPrice => 500;
        public override int SellPrice => 700;
        public override int MaxGrowth => 50;

    }
}
