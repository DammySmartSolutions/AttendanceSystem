using AttendanceSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceSystem
{
    public partial class rptAttendance : System.Web.UI.Page
    {

        string StaffNumber;

        int statusid;

        AttendanceEntities Db = new AttendanceEntities();


        AttendanceClass Utility = new AttendanceClass();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["StaffNumber"] == null)
            {

                Session["Page"] = HttpContext.Current.Request.Url.AbsolutePath;
                Response.Redirect("LoginPage.aspx");

            }


            else
            {

                StaffNumber = Session["StaffNumber"].ToString();




                string Statusid = Session["Status"].ToString();


                statusid = Convert.ToInt32(Statusid);

                if (!IsPostBack)
                {

                    divalert.Visible = false;

                    txtdate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    /////LoadCourseCode();
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                }

                else
                {

                    divalert.Visible = true;
                }


            }
        }


        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];
        }


        protected void ddlsession_SelectedIndexChanged(object sender, EventArgs e)
        {
            int semid = int.Parse(ddlsemester.SelectedItem.Value);

            int sessid = int.Parse(ddlsession.SelectedItem.Value);


            LoadCourseCode(semid, sessid);


        }



        private void LoadCourseCode(int semid, int sessid)
        {
            if (statusid == 1)
            {
                var getdata = (from s in Db.tblNewCourseAllocation.Where(s => s.StaffId == StaffNumber && s.sessionid == sessid && s.Semid == semid)
                               select new { s.code, s.Allocid }).ToList();




                ddlcode.DataTextField = "code";
                ddlcode.DataValueField = "Allocid";
                ddlcode.DataSource = getdata;
                ddlcode.DataBind();
                ddlcode.Items.Insert(0, "--Select Course--");

            }

            else if (statusid == 3)
            {
                var getdata = (from s in Db.tblsetupCourse.Where(s => s.semid == semid)
                               select new { s.code, s.courseid }).ToList();



                ddlcode.DataTextField = "code";
                ddlcode.DataValueField = "courseid";
                ddlcode.DataSource = getdata;
                ddlcode.DataBind();
                ddlcode.Items.Insert(0, "--Select Course--");


            }


            else { }
        }



        protected void btnview_Click(object sender, EventArgs e)
        {


            if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
            {

                Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());

            }

            else
            {

                Response.Redirect("rptAttendance.aspx");
            }

            try
            {


                if (ddlsemester.SelectedItem.Text == "--Select Semester--")
                {
                    lblmsg.Text = "Please Select Semester";
                    ddlsemester.Focus();
                    return;
                }


                if (ddlsession.SelectedItem.Text == "--Select Session--")
                {
                    lblmsg.Text = "Please Select Session";
                    ddlsession.Focus();
                    return;
                }




                if (ddlcode.SelectedItem.Text == "--Select Course--")
                {
                    lblmsg.Text = "Please Select Course";
                    ddlcode.Focus();
                    return;
                }




                string semester = ddlsemester.SelectedItem.Text;
                string session = ddlsession.SelectedItem.Text;
                string course = ddlcode.SelectedItem.Text;

                DateTime date = DateTime.Parse(txtdate.Value);

                

                date.ToString("yyyy-MM-dd");

                Session["Semester"] = semester;
                Session["session"] = session;

                Session["Course"] = course;
                Session["Date"] = date;


                Response.Redirect("rptAttendanceView.aspx");



            }

            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }

        }
    }
}