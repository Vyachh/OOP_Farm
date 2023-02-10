using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Farm.Models.Animals
{
    class Pig : DefaultAnimal
    {
        public override string AnimalName => "Свинья";
        public override int BuyPrice => 3500;
        public override int SellPrice => 4000;
        public override int MaxGrowth => 200;
    }
}
