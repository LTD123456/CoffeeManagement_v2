using CoffeeMangement.Core.GenericRepository;
using CoffeeMangement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMangement.Core.Repositories
{
    public interface IFoodRepository : IRepository<Food>
    {
        //void Add(Bill entity);
        //void Update(Bill entity);
        //void AddRange(IEnumerable<Bill> lstEntity);
        //void Delete(Bill entity);
        //IEnumerable<Bill> GetAll();
        //Bill GetByKey(Guid? id);
    }
    public class FoodRepository : Repository<Food>, IFoodRepository
    {
        public FoodRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
