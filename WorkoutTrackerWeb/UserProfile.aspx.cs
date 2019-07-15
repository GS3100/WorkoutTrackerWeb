using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

// Newtonsoft is awesome!  

namespace WorkoutTrackerWeb
{
    public partial class UserProfile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                //load default user information after login
                User GetUser = new User();
                
                var GetPerson = JObject.Parse(GetUser.LoadProfile(1)); //---takes user ID / default to 1 for now
                string FirstName = GetPerson["FirstName"].ToString();
                string LastName = GetPerson["LastName"].ToString();
                string DOB = GetPerson["DOB"].ToString();
                int Height = Int32.Parse(GetPerson["Height"].ToString());
                int Weight = Int32.Parse(GetPerson["Weight"].ToString());
                int HeightFt = Height / 12;
                int HeightIn = Height % 12;

                lblName.Text = FirstName + " " + LastName;
                lblHeight.Text = HeightFt.ToString() + "ft " + HeightIn.ToString() + "in";
                lblDOB.Text = DOB;
                lblWeight.Text = Weight.ToString();
                hidID.Text = GetPerson["IdPerson"].ToString();
                txtHeightFt.Text = HeightFt.ToString();
                txtHeightIn.Text = HeightIn.ToString();
                txtWt.Text = Weight.ToString();
            }
        }
        public void BtnUpdateUser_Click(Object sender, EventArgs e)
        {
            /**/
            User User = new User();
            //UPDATE  the PersonDetails table with new information/update Person table with new values as well
            JObject UserDetails = new JObject();
            //if weight has changed then update 
            
            if (txtWt.Text != lblWeight.Text)
            {
                int ID = Int32.Parse(hidID.Text);
                int Weight = Int32.Parse(txtWt.Text);
                User.UpdateProfile(ID,Weight,0);

                //clear out postback cache to update view
                Response.Redirect(Request.RawUrl, false);
            }
            else
            {
                Label1.Text = "false";
            }

           
        }
        //after testing move this to a new class
        //builds the GridJS labels/data
        public (string,string) userStats()
        {
            Report.BuildChart report = new Report.BuildChart();
            string labels = report.Labels("Person").Item1;
            string data = report.Labels("Person").Item2;
  
            return (labels.ToString(), data.ToString());
        }
    }
}