using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoffeeMangement.Data.Entities
{
    [Table("FoodCategory")]
    public class FoodCategory : BaseEntity
    {
        public FoodCategory()
        {
            this.ID = Guid.NewGuid();
            this.CreatedDate = new DateTime();
            this.ModifiedDate = new DateTime();
        }
        public string name { get; set; }
        public ICollection<Food> Foods { get; set; }
    }
}
