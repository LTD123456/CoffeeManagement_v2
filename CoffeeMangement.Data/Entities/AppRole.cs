using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoffeeMangement.Data.Entities
{
    [Table("Role")]
    public class AppRole:IdentityRole<Guid>
    {
        public AppRole()
        {
            this.Id = Guid.NewGuid();
            this.CreatedDate = new DateTime();
            this.ModifiedDate = new DateTime();
        }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
