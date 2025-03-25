using AttendanceSystem.Model;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Stimulsoft.Base.StiDataLoaderHelper;
using static System.Collections.Specialized.BitVector32;

namespace AttendanceSystem
{
    public partial class rptAttendanceView : System.Web.UI.Page
    {


        private string Connectionstring;
        private string ReportName;
        string StaffNumber;

        int statusid;


        string semester = "" ;
        string session = "";
        string course = "";
        DateTime date;

        AttendanceEntities Db = new AttendanceEntities();


        AttendanceClass Utility = new AttendanceClass();
        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session["StaffNumber"] == null)
            {

                Session["Page"] = HttpContext.Current.Request.Url.AbsolutePath;
                Response.Redirect("LoginPage.aspx");

            }


            else
            {

                StaffNumber = Session["StaffNumber"].ToString();




                string Statusid = Session["Status"].ToString();


                statusid = Convert.ToInt32(Statusid);



                  semester = Session["Semester"].ToString();
                 session = Session["session"].ToString();
                 course = Session["Course"].ToString();
                 date = Convert.ToDateTime(Session["Date"].ToString());

          

                if (!IsPostBack)
                {

                    divalert.Visible = false;


                    LoadReport();

                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                }

                else
                {

                    divalert.Visible = true;
                }


            }

        }

        private void LoadReport()
        {
            ReportName = "Attendance";
            StiReport Report = new StiReport();


            Connectionstring = ConfigurationManager.ConnectionStrings["ReportConnection"].ConnectionString;
            string AppDirectory = HttpContext.Current.Server.MapPath(string.Empty);
            string Path = AppDirectory + "\\Report\\" + ReportName + ".mrt";
            Report.Load(Path);

            Report.Dictionary.Databases.Clear();
            Report.Dictionary.Databases.Add(new StiSqlDatabase("Attendance", "Attendance", Connectionstring, false));






            Report["@Code"] = course;

            Report["@Semester"] = semester;

            Report["@Session"] = session;

            Report["@date"] = date;

           



            Report.Compile();
            Report.Render();

            StiWebViewer1.Report = Report;
        }
    }
}