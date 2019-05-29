using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorkoutTrackerWeb
{
    public partial class WorkoutInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                int noOfSets = 10;
                for (var i = 1; i <= noOfSets; i++)
                {
                    selNumOfSets.Items.Add(i.ToString());
                }
            }
            

        }

        protected void selNumOfSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numOfSets = Int32.Parse(selNumOfSets.SelectedValue);
            string html = "";
            for(var i = 1; i <= numOfSets; i++)
            {
                
                html += "<h4>Set " + i + "</h4><input class='form-control' type='text' id='txtReps_'" + i + "/><br/>";
            }
            DIVSetLog.InnerHtml = html;

        }
    }
}