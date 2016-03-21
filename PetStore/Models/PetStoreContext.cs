using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    public class PetStoreContext : DbContext
    {
        public PetStoreContext()
            :base("DefaultConnection")
        {
        }
        public DbSet<Animal> Animals { get; set; }
    }
}