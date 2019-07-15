using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkoutTrackerWeb.Models;

namespace WorkoutTrackerWeb
{
    public class Report
    {
        public class BuildChart
        {
            
            // query DB and return a stringified version of an array for the ChartJS plugin
            public (string,string) Labels(string labelTitle)
            {
                //string[] arrLabels;
                //string[] arrData;
                int UID = 1; //while testing
                             //arrLabels = new string[] { "Element 1", "Element 2", "Element 3", "Element 4", "Element 5" };//testing
                             //arrData = new string[] { "10", "40", "20", "30", "50" };//testing
                             //string labelsToStr = "";
                             //string dataToStr = "";

                User user = new User();
                var list = user.LoadProfileDet(1);
                return ("", list);

                /*
                for (var i = 0; i < arrLabels.Length; ++i)
                {
                    if (i + 1 <= arrLabels.Length)
                    {
                        labelsToStr += "'" + arrLabels[i] + "',";
                        dataToStr += "'" + arrData[i] + "',";
                    }
                    else
                    {
                        labelsToStr += "'" + arrLabels[i] + "'";
                        dataToStr += "'" + arrData[i] + "',";
                    }

                }

                return (labelsToStr.ToString(), dataToStr.ToString());
                */
                
            }

           
        }
    }
}