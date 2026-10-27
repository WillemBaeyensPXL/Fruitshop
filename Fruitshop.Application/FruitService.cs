using Fruitshop.Domain;
using Fruitshop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fruitshop.Application
{
    public class FruitService
    {
        public IEnumerable<Fruit> GetAllFruits()
        {
            FruitRepository repo = new FruitRepository();
            return repo.LoadAllFruits();
        }
    }
}
