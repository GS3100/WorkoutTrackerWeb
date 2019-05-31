using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace WorkoutTrackerWeb
{
    public partial class WorkoutInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
    
                selNumOfSets.Items.Add("0");
                int noOfSets = 10;
                for (var i = 1; i <= noOfSets; i++)
                {
                    selNumOfSets.Items.Add(i.ToString());
                }
                
                // load combo box for body area
                Workout.BodyArea bodyArea = new Workout.BodyArea();
                var loadBodyArea = JArray.Parse(@bodyArea.LoadBodyArea());
                int c = 0;
                selBodyArea.Items.Add("Select");
                selExercise.Items.Add("Select");
                foreach (var obj in loadBodyArea.Children()) {
                    selBodyArea.Items.Add(loadBodyArea[c]["Name"].ToString());
                    selBodyArea.Items[c].Value = loadBodyArea[c]["IdBodyArea"].ToString(); //add id to value
                    c++;
                }
                
            }
            

        }

        protected void selNumOfSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int numOfSets = Int32.Parse(selNumOfSets.SelectedValue);
            string html = "";
            for(var i = 1; i <= numOfSets; i++)
            {
                
                html += "<div class='input-group'><span class='input-group-addon'>Set " + i + "</span>"+
                    "<input class='form-control' type='text' name='txtWt' id='txtWt_" + i + "' size='3' placeholder='Weight'/>" +
                    "<input class='form-control' type='text' name='txtReps' id='txtReps_" + i + "' size='3' placeholder='Reps'/></div><br/>";
            }
            html += "";
            DIVSetLog.InnerHtml = html;

        }
        protected void selBodyArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selValue = Int32.Parse(selBodyArea.SelectedValue);
            Workout.BodyArea bodyArea = new Workout.BodyArea();
            var loadExercises = JArray.Parse(bodyArea.LoadExercises(selValue));
 
            int c = 0;
            selExercise.Items.Clear();
            foreach (var items in loadExercises.Children())
            {
                //selExercise.Items.Add(loadExercises[items]["Name"].ToString());
                //selExercise.Items[obj].Value = loadExercises[obj]["IdExercise"].ToString(); //add id to value
                selExercise.Items.Add(items["Name"].ToString());
                //selExercise.Items[obj].Value = loadExercises[obj]["IdExercise"].ToString()
            }
            Response.Write(loadExercises.ToString());
        }
        /**/
        protected void btnAddToWorkout_OnClick(object sender, EventArgs e)
        {
            //first time button is clicked write header record and return workoutid for log table
            string[] arrReps;
            string[] arrWt;
            
            arrReps = Request.Form.GetValues("txtReps");
            arrWt = Request.Form.GetValues("txtWt");
            string date = txtDate.Value;
            int sets = selNumOfSets.SelectedIndex;
            int UID = 1;
            Workout workout = new Workout();
            //Session["WID"] = "";
            string workoutLog = "";
            try
            {
                string getExercise = selExercise.SelectedValue;

                //insert new workout header first and assign to session
                if (string.IsNullOrEmpty(Session["WID"] as string))
                {
                    //Session["WID"] = workout.InsertWorkoutMaster("", UID, date);
                    Session["WID"] = "1";

                    //insert first set of detail
                    for(var i = 0; i < sets; i++)
                    {
                        //Response.Write("reps " + arrReps[i] + "<br/>");
                        workoutLog = workout.InsertWorkoutDetail(Int32.Parse(Session["WID"].ToString()), i + 1, Int32.Parse(arrWt[i]), Int32.Parse(arrReps[i]), Int32.Parse(selExercise.SelectedValue), 0);
                        Response.Write(workoutLog);
                    }
                }
                else
                {

                    //insert detail
                    for (var i = 0; i < sets; i++)
                    {
                        workoutLog = workout.InsertWorkoutDetail(Int32.Parse(Session["WID"].ToString()), i + 1, Int32.Parse(arrWt[i]), Int32.Parse(arrReps[i]), Int32.Parse(selExercise.SelectedValue), 0);
                        Response.Write(workoutLog);
                    }
                }
                
            }
            catch (Exception x)
            {
                lblErr.Text = x.ToString();
            }
            
        }
    }
}