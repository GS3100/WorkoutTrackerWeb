using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WorkoutTrackerWeb.Models;

namespace WorkoutTrackerWeb
{
    public class Workout
    {
        public class BodyArea
        {
            public string LoadBodyArea()
            {
                JObject json = new JObject();
                using(var context = new WorkoutTrackerEntities1())
                {

                    //var rs = context.WorkoutBodyAreas.SqlQuery("SELECT * FROM WorkoutBodyArea ORDER by Name;").ToList();
                    var query = from workoutBodyAreas in context.WorkoutBodyAreas  select workoutBodyAreas;

                    var muscleGroups = query.ToList<WorkoutBodyArea>();
                   
                    //rs = rs.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });
                   
                    return JsonConvert.SerializeObject(muscleGroups);
                }
                
            }

            public string LoadExercises(int area)
            {
                JObject json = new JObject();
                using (var context = new WorkoutTrackerEntities1())
                {
                    var query = from areaExercises in context.WorkoutExercises where areaExercises.IdBodyArea == area select areaExercises;
                    var exercises = query.ToList<WorkoutExercise>();
                    return JsonConvert.SerializeObject(exercises);
                }
            }
        }
        
    }
}