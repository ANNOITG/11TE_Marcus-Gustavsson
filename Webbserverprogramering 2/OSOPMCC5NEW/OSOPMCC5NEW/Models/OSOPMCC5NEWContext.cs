using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OSOPMCC5NEW.Models
{
    public class OSOPMCC5NEWContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public OSOPMCC5NEWContext() : base("name=OSOPMCC5NEWContext")
        {
            
        }

        public DbSet<Post> Posts { get; set; }

        //public System.Data.Entity.DbSet<OSOPMCC5NEW.Models.Post> Posts { get; set; }
    
    }
}
