using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Farm.Models.Animals
{
    class Cow : DefaultAnimal
    {
        public override string AnimalName => "Корова";
        public override int BuyPrice => 5000;
        public override int SellPrice => 6000;
        public override int MaxGrowth => 250;
    }
}
