using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoffeeMangement.Data.Entities
{
    [Table("TableFood")]
    public class TableFood : BaseEntity
    {
        public TableFood()
        {
            this.ID = Guid.NewGuid();
            this.ModifiedDate = new DateTime();
            this.CreatedDate = new DateTime();
        }
        public string name { get; set; }
        public string status { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}
