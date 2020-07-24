using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoffeeMangement.Data.Entities
{
    [Table("User")]
    public class User : IdentityUser <Guid>
    {
        public User()
        {
            this.Id = Guid.NewGuid();
            this.CreatedDate = new DateTime();
            this.ModifiedDate = new DateTime();
        }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string DisplayName { get; set; }
        public string PassWord { get; set; }

    }
}
