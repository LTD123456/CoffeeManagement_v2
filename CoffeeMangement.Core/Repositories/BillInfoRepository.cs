using CoffeeMangement.Core.GenericRepository;
using CoffeeMangement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMangement.Core.Repositories
{
    public interface IBillInfoRepository : IRepository<BillInfo>
    {
        //void Add(Bill entity);
        //void Update(Bill entity);
        //void AddRange(IEnumerable<Bill> lstEntity);
        //void Delete(Bill entity);
        //IEnumerable<Bill> GetAll();
        //Bill GetByKey(Guid? id);
    }
    public class BillInfoRepository : Repository<BillInfo>, IBillInfoRepository
    {
        public BillInfoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
