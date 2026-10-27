using System;
using System.Collections.Generic;
using System.Text;

namespace Fruitshop.Domain
{
    public class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Season { get; set; }

        public override string ToString()
        {
            return $"{Name} {Color} {Season}";
        }
    }
}
