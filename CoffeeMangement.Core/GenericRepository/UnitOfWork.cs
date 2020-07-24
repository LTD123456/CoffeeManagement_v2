using CoffeeMangement.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMangement.Core.GenericRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private CoffeeDBContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public CoffeeDBContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
