using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
            foreach (var obj in loadExercises.Children())
            {
                selExercise.Items.Add(loadExercises[c]["Name"].ToString());
                selExercise.Items[c].Value = loadExercises[c]["IdExercise"].ToString(); //add id to value
                c++;
            }

        }
        /*
        protected void btnAddToWorkout_OnClick(object sender, EventArgs e)
        {
            var getWt = Request.Form["txtWt"]; //array
            //create table data list
            HtmlTableRow row;
            HtmlTableCell cell;

            row = new HtmlTableRow();
            cell = new HtmlTableCell();
            cell.InnerText = "test";
            row.Cells.Add(cell);
            
            Label1.Text = getWt[0].ToString();
        }*/
    }
}