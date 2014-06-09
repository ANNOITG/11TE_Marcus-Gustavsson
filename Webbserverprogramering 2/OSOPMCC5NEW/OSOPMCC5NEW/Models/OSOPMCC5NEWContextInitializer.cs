using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OSOPMCC5NEW.Models;

namespace OSOPMCC5NEW.Models
{
    public class OSOPMCC5NEWContextInitializer : DropCreateDatabaseIfModelChanges<OSOPMCC5NEWContext>
    {
        protected override void Seed(OSOPMCC5NEWContext context)
        {
            var posts = new List<Post>
            {
                new Post() {Title="TestTitle", Text="TestText", Alias="TestName"}
            };

            posts.ForEach(p => context.Posts.Add(p));
            context.SaveChanges();
        }
    }
}