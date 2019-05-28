using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WorkoutTrackerWeb.Models;
namespace WorkoutTrackerWeb
{
    public class User
    {
        public string LoadProfile(int ID)
        {
            /**/
            JObject UserDetails = new JObject();

            using (var context = new WorkoutTrackerEntities1())
            {
                var query = from userProfile in context.People where userProfile.IdPerson == ID select userProfile;

                var PersonDetail = query.FirstOrDefault<Person>();

                UserDetails.Add("IdPerson", PersonDetail.IdPerson);
                UserDetails.Add("FirstName", PersonDetail.FirstName);
                UserDetails.Add("LastName", PersonDetail.LastName);
                UserDetails.Add("DOB", PersonDetail.DOB);
                UserDetails.Add("Height", PersonDetail.HeightInches);
                UserDetails.Add("Weight", PersonDetail.WeightLbs);

                return JsonConvert.SerializeObject(UserDetails) ;
            }


        }

        public void UpdateProfile(int ID, int weight, int heightInch)
        {
            //for now just focus on updating weight of the person
            using(var context = new WorkoutTrackerEntities1())
            {
                context.Database.ExecuteSqlCommand("INSERT INTO PersonDetHistory VALUES(" + ID + ", NULL, " + weight + ",GetDate())");
                context.SaveChanges();

                //now update the master table with new values
                context.Database.ExecuteSqlCommand("UPDATE Person SET WeightLbs = " + weight + " WHERE IdPerson = " + ID);
                context.SaveChanges();
            }
        }
    }
}