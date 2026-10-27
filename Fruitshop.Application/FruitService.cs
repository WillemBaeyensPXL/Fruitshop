using Fruitshop.Domain;
using Fruitshop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fruitshop.Application
{
    public class FruitService
    {
        private readonly FruitRepository repo;

        public FruitService()
        {
            repo = new FruitRepository();
        }

        public IEnumerable<Fruit> GetAllFruits()
        {
            return repo.LoadAllFruits();
        }

        public bool Delete(Fruit fruit)
        {
            return repo.Delete(fruit.Id);
        }

        public void Update(Fruit fruit)
        {
            repo.Update(fruit);
        }

        public void AddFruit()
        {
            Fruit newFruit = new Fruit()
            {
                Name = "Test",
                Season = "Herfst",
                Color = "Zwart"
            };
            repo.Add(newFruit);
        }
    }
}
