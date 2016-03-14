using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PetStore.Models
{
    public class PetStoreContextInitializer : DropCreateDatabaseAlways<PetStoreContext>
    {
        protected override void Seed(PetStoreContext context)
        {
            base.Seed(context);
        }
    }
}