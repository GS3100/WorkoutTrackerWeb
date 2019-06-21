using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WorkoutTrackerWeb
{
    public partial class WorkoutInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                // load combo box for # of sets
                selNumOfSets.Items.Add("0");
                int noOfSets = 10;
                for (var i = 1; i <= noOfSets; i++)
                {
                    selNumOfSets.Items.Add(i.ToString());
                }
                
                // load combo box for body area
                Workout.BodyArea bodyArea = new Workout.BodyArea();
                dynamic loadBodyArea = JsonConvert.DeserializeObject(bodyArea.LoadBodyArea());
                int c = 1;//start with the second element in the select
                selBodyArea.Items.Add("Select");
                selBodyArea.Items[0].Value = "0";
                selExercise.Items.Add("Select");
                foreach(var obj in loadBodyArea) {
                    selBodyArea.Items.Add(obj.Name.ToString());
                    selBodyArea.Items[c].Value = obj.IdBodyArea;
                    c++;
                }

            }
            else
            {

            }
            //display records for current workout
            Session["WID"] = 13;
            //if (!string.IsNullOrEmpty(Session["WID"] as string))
            //{
            DataTable dt = new DataTable();
                DataRow dr = null;

                Workout workout = new Workout();

            dynamic workoutLogDetail = JsonConvert.DeserializeObject(workout.LoadWorkoutDetail(13));
            dt.Columns.Add(new DataColumn("Exercise", typeof(string)));
                dt.Columns.Add(new DataColumn("Set #", typeof(string)));
                dt.Columns.Add(new DataColumn("Weight", typeof(string)));
                dt.Columns.Add(new DataColumn("Reps", typeof(string)));


                foreach (var item in workoutLogDetail)
                {
                dr = dt.NewRow();
                //dr["Exercise"]
                dr["Exercise"] = item.ExerciseName;
                    dr["Set #"] = "Set";
                    dr["Weight"] = "weight";
                    dr["Reps"] = "reps";
                dt.Rows.Add(dr);

                ViewState["CurrentTable"] = dt;
                grdWOLog.DataSource = dt;
                grdWOLog.DataBind();

            }

                Response.Write(workoutLogDetail);

                //}



            }

            protected void selNumOfSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int numOfSets = Int32.Parse(selNumOfSets.SelectedValue);
            string html = "";
            for(var i = 1; i <= numOfSets; i++)
            {
                
                html += "<div class='input-group'><span class='input-group-addon'>Set " + i + "</span>"+
                    "<input class='form-control' type='text' name='txtWt' id='txtWt_" + i + "' size='3' placeholder='Weight'/>" +
                    "<input class='form-control' type='text' name='txtReps' id='txtReps_" + i + "' size='3' placeholder='Reps'/>"+
                    "<textarea class='form-control' name='txtWONotes' placeholder='Notes'></textarea>" +
                    "</div><br/>";
            }
            html += "";
            DIVSetLog.InnerHtml = html;

        }

        protected void selBodyArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            selExercise.Items.Clear();
            int selValue = Int32.Parse(selBodyArea.SelectedValue);
            Workout.BodyArea bodyArea = new Workout.BodyArea();
            dynamic loadExercises = JsonConvert.DeserializeObject(bodyArea.LoadExercises(selValue +1));
            int c = 0;
            
            foreach (var items in loadExercises)
            {
                selExercise.Items.Add(items.Name.ToString());
                selExercise.Items[c].Value = items.IdExercise;
                c++;
            }
            
        }
        /**/
        protected void btnAddToWorkout_OnClick(object sender, EventArgs e)
        {
            //first time button is clicked write header record and return workoutid for log table
            string[] arrReps;
            string[] arrWt;
            string[] arrNotes;

            arrReps = Request.Form.GetValues("txtReps");
            arrWt = Request.Form.GetValues("txtWt");
            arrNotes = Request.Form.GetValues("txtWONotes");
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
                    Session["WID"] = workout.InsertWorkoutMaster("", UID, date);
                    //Session["WID"] = "1";

                    //insert first set of detail
                    for(var i = 0; i < sets; i++)
                    {
                        //Response.Write("reps " + arrReps[i] + "<br/>");
                        workoutLog = workout.InsertWorkoutDetail(Int32.Parse(Session["WID"].ToString()), i + 1, Int32.Parse(arrWt[i]), Int32.Parse(arrReps[i]), Int32.Parse(selExercise.SelectedValue), 0,arrNotes[i].ToString());
                        //Response.Write(workoutLog);
                    }
                }
                else
                {
                    //insert detail
                    //lock date field
                    txtDate.Attributes.Add("disabled","true");
                    for (var i = 0; i < sets; i++)
                    {
                        workoutLog = workout.InsertWorkoutDetail(Int32.Parse(Session["WID"].ToString()), i + 1, Int32.Parse(arrWt[i]), Int32.Parse(arrReps[i]), Int32.Parse(selExercise.SelectedValue), 0, arrNotes[i].ToString());
                        //Response.Write(workoutLog);
                    }
                } 
            }
            catch (Exception x)
            {
                lblErr.Text = x.ToString();
            }

        }
        protected void btnWOComplete_OnClick(object sender, EventArgs e)
        {
            Session["WID"] = "";
            txtDate.Attributes.Add("disabled", "false");
        }
    }
}