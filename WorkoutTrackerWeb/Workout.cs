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

                    var query = from workoutBodyAreas in context.WorkoutBodyAreas  select workoutBodyAreas;

                    var muscleGroups = query.ToList<WorkoutBodyArea>();

                    return JsonConvert.SerializeObject(muscleGroups);
                }
                
            }

            public string LoadExercises(int area)
            {
                JObject json = new JObject();
                using (var context = new WorkoutTrackerEntities1())
                {
                    var query = from areaExercises in context.WorkoutExercises where areaExercises.IdBodyArea == area -1 select areaExercises;
                    var exercises = query.ToList<WorkoutExercise>();
                    return JsonConvert.SerializeObject(exercises);
                }
            }
        }
        public string LoadWorkoutDetail(int WID)
        {
           
            using(var context = new WorkoutTrackerEntities1())
            {
                var query = from workoutLog in context.vw_WorkoutLogDetail where workoutLog.IdPersonWorkout == WID select workoutLog;
                var logDetail = query.ToList<vw_WorkoutLogDetail>();
                return JsonConvert.SerializeObject(logDetail);
            }   
        }
        public string InsertWorkoutMaster(string WID, int UID, string date)
        {
            
            using(var context = new WorkoutTrackerEntities1())
            {
                string workoutID = "";
              
                if (WID == "") //should be a new workout
                {
                    //test = "INSERT INTO PersonWorkoutMaster VALUES(" + UID + ", '" + date + "')";
                    context.Database.ExecuteSqlCommand("INSERT INTO PersonWorkoutMaster VALUES(" + UID + ", '" + date + "')");
                    context.SaveChanges();
                    //get new workoutID
                    workoutID = context.PersonWorkoutMasters.Max(p => p.IdWorkout).ToString();

                }
                else
                {
                    
                }
                //var query = from workoutMaster in context.PersonWorkoutMasters where workoutMaster.IdWorkout == WID select workoutMaster;

                return workoutID.ToString();
                
            }
            
        }
        public string InsertWorkoutDetail(int WID, int setNum, int wt, int reps, int exercise, int machine, string notes)
        {
            using (var context = new WorkoutTrackerEntities1())
            {
                //get max detail line

                //var detailLine = context.PersonWorkoutDetails.Select(p => p.IdDetailLine).DefaultIfEmpty(0).Max();
                int detailLine = context.Database.SqlQuery<int>("SELECT COALESCE(MAX(IdDetailLine),0) as IdDetailLine FROM PersonWorkoutDetail WHERE IdPersonWorkout = " + WID)
                   .FirstOrDefault();

                var query = from dl in context.PersonWorkoutDetails where dl.IdPersonWorkout == WID select dl;
                var detailList = query.ToList<PersonWorkoutDetail>();
                //int nextDetailLine = Int32.Parse(detailLine.ToString()) + 1;
 
                int nextDetailLine = detailLine + 1;
                //insert new detail 
                context.Database.ExecuteSqlCommand("INSERT INTO PersonWorkoutDetail VALUES("+ WID +","+ nextDetailLine + ","+ setNum +","+ wt +","+ reps +",NULL,"+ exercise +",'"+ notes +"')");
                JObject json = new JObject();
                
                return JsonConvert.SerializeObject(detailList);

            }


        }
        
    }
}