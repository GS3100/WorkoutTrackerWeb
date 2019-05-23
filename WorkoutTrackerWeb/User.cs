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

                UserDetails.Add("FirstName", PersonDetail.FirstName);
                UserDetails.Add("LastName", PersonDetail.LastName);
                UserDetails.Add("DOB", PersonDetail.DOB);
                UserDetails.Add("Height", PersonDetail.HeightInches);
                UserDetails.Add("Weight", PersonDetail.WeightLbs);

                return JsonConvert.SerializeObject(UserDetails) ;
            }


        }

        public void UpdateDetails(int ID, int val)
        {
            using(var context = new WorkoutTrackerEntities1())
            {
                var GetPerson = JObject.Parse(LoadProfile(ID)); //copy values into PersonDetHistory table first

                //var query = from userProfile in context.PersonDetHistory;
            }
        }
    }
}