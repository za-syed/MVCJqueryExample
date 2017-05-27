using MVCPopupUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace MVCPopupUsers.DAL
{
    public class FriendsDBInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<FriendsDBContext>
    {
        protected override void Seed(FriendsDBContext context)
        {
            base.Seed(context);
            LoadFriends(context);
            LoadStates(context);
            LoadCities(context);

        }

        private static void LoadFriends(FriendsDBContext context)
        {
            try
            {
                var friends = new List<Friend> { 
                                                 new Friend(){ FirstName="Zainul", LastName="Syed", MaritalStatus="Single", MiddleName ="Abiddin", Gender ="Male", Address="3314 Wells Drive", City="Parlin", State="NJ", Zip = "08859"},
                                                 new Friend(){ FirstName="Fatima", LastName="Syed", MaritalStatus="Single", MiddleName ="Zoha",  Gender ="Female",  Address="3314 Wells Drive", City="Parlin", State="NJ", Zip = "08859"},
                                                 new Friend(){ FirstName="Farah", LastName="Sultana", MaritalStatus="Single", MiddleName ="Unknown", Gender ="Male",  Address="3314 Wells Drive", City="Parlin", State="NJ", Zip = "08859"},
                                                 new Friend(){ FirstName="Shareef", LastName="Syed", MaritalStatus="Single", MiddleName ="Faraz",Gender ="Male",  Address="3314 Wells Drive", City="Parlin", State="AL", Zip = "08859"},
                                                 new Friend(){ FirstName="Jalal", LastName="Syed", MaritalStatus="Married", MiddleName ="Akbar",Gender ="Male",  Address="3314 Wells Drive", City="Parlin", State="AL", Zip = "08859"},
                                                };
                friends.ForEach(f => context.Friends.Add(f));
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static void LoadStates(FriendsDBContext context)
        {
            try
            {
                var states = new List<State> { 
                                             new State(){ StateCode="AL", StateDescription="Alabama"},
                                             new State(){ StateCode="GA", StateDescription="Georgea"},
                                             new State(){ StateCode="IL", StateDescription="Illinos"},
                                             new State(){ StateCode="MI", StateDescription="Misshigan"},
                                             new State(){ StateCode="NJ", StateDescription="New Jersey"},
                                             new State(){ StateCode="NY", StateDescription="New York"}
                                            };
                states.ForEach(s => context.States.Add(s));
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static void LoadCities(FriendsDBContext context)
        {
            try
            {
                var cities
                    = new List<City> { 
                                             new City(){ CityCode ="AB" ,StateCode="NJ", CityDesc="Aberdeen"},
                                              new City(){ CityCode ="WB" ,StateCode="NJ", CityDesc="Woodbridge"},
                                              new City(){ CityCode ="OB" ,StateCode="NJ", CityDesc="Oldbridge"},
                                              new City(){ CityCode ="PA" ,StateCode="NJ", CityDesc="Parlin"},
                                              new City(){ CityCode ="CH" ,StateCode="IL", CityDesc="Chicago"},
                                              new City(){ CityCode ="AT" ,StateCode="GA", CityDesc="Atlanta"},
                                              new City(){ CityCode ="BR" ,StateCode="NY", CityDesc="Brooklyn"},
                                              new City(){ CityCode ="QU" ,StateCode="NY", CityDesc="Queens"},
                                              new City(){ CityCode ="BR" ,StateCode="NJ", CityDesc="Bronx"},
                                              new City(){ CityCode ="MA" ,StateCode="NJ", CityDesc="Manhattan"},
                                              new City(){ CityCode ="BO" ,StateCode="MA", CityDesc="Boston"},
                                              new City(){ CityCode ="TE" ,StateCode="AL", CityDesc="Telahasee"}
                                            };
                cities.ForEach(c => context.Cities.Add(c));
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}