using MVCPopupUsers.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCPopupUsers.DAL
{
    public class FriendsDBContext:DbContext
    {
        public FriendsDBContext()
            : base("DefaultConnection") 
        {
            Database.SetInitializer<FriendsDBContext>(new DropCreateDatabaseIfModelChanges<FriendsDBContext>());
        }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
    }   
}