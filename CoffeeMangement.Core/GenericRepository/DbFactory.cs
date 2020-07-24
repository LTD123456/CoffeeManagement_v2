using CoffeeMangement.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMangement.Core.GenericRepository
{
    public class DbFactory : Disposable, IDbFactory
    {
        private CoffeeDBContext dbContext;
        public CoffeeDBContext init()
        {
            return dbContext ?? (dbContext = new CoffeeDBContext());
        }
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
