using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Farm.Models.Animals
{
    class Goat : DefaultAnimal
    {
        public override string AnimalName => "Козел";
        public override int BuyPrice => 2000;
        public override int SellPrice => 2500;
        public override int MaxGrowth => 150;
    }
}
