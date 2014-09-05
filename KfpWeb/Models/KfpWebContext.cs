using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KfpWeb.Models
{
    public class KfpWebContext : DbContext
    {
        public KfpWebContext() : base("name=KfpWebContext")
        {
            kfpEntities DB = new kfpEntities();
            Teams = DB.Teams;
            Games = DB.Games;
            Users = DB.Users;
            Picks = DB.Picks;
        }

        public System.Data.Entity.DbSet<KfpWeb.Models.Team> Teams { get; set; }
        public System.Data.Entity.DbSet<KfpWeb.Models.Game> Games { get; set; }
        public System.Data.Entity.DbSet<KfpWeb.Models.User> Users { get; set; }
        public System.Data.Entity.DbSet<KfpWeb.Models.Pick> Picks { get; set; }
    
    }
}
