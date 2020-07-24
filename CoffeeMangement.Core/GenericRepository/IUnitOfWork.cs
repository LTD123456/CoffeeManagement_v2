using CoffeeMangement.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMangement.Core.GenericRepository
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
