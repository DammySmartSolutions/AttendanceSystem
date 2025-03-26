using AttendanceSystem.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace AttendanceSystem
{
    public partial class CaptureAttendance : System.Web.UI.Page
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


                    /////LoadCourseCode();
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                }

                else
                {

                    divalert.Visible = true;
                }


            }
        }

        private void LoadCourseCode()
        {
            

           
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];
        }

        protected void btnview_Click(object sender, EventArgs e)
        {

            if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
            {

                Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());

            }

            else
            {

                Response.Redirect("CaptureAttendance.aspx");
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



                LoadGridView();

                btnProcess.Visible = true;
            }

            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
        }

        private void LoadGridView()
        {
            int semid = int.Parse(ddlsemester.SelectedItem.Value);

            int sessid = int.Parse(ddlsession.SelectedItem.Value);

            string code = ddlcode.SelectedItem.Text;


            var category = (from t in Db.tblCourseRegistration.Where(x => x.Semid == semid && x.sessionid == sessid && x.code == code)
                            select new
                            {
                                t.code,
                                t.StudentID,
                                t.StudentName,
                              
                            }).ToList();


            GridView1.DataSource = category;
            GridView1.DataBind();





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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadGridView();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            try
            {







                if (e.CommandName == "Present")
                {

                   

                    //Determine the RowIndex of the Row whose Button was clicked.
                    int rowIndex = Convert.ToInt32(e.CommandArgument);

                    //Reference the GridView Row.
                    GridViewRow row = GridView1.Rows[rowIndex];

                    

                    DateTime today = DateTime.Today;

                    
                    string Studentid = row.Cells[1].Text;
                    string studentname = row.Cells[2].Text;
                    string CourseCode = row.Cells[3].Text;

                    int semid = int.Parse(ddlsemester.SelectedItem.Value);

                    string semester = ddlsemester.SelectedItem.Text;

                    int sessid = int.Parse(ddlsession.SelectedItem.Value);

                    string session = ddlsession.SelectedItem.Text;

                    bool status = true;

                    // StaffNumber



                    var CreateInst = Db.tblCaptureAttendance.Where(x => x.StudentID == Studentid && x.CourseCode == CourseCode && x.Date == today).FirstOrDefault();





                    if (CreateInst == null)
                    {



                        
                        var NewClassDeg = new tblCaptureAttendance();

                        NewClassDeg.semid = semid;

                        NewClassDeg.semester = semester;




                        NewClassDeg.sessid = sessid;

                        NewClassDeg.session = session;

                        NewClassDeg.StudentID = Studentid;
                        NewClassDeg.StudentName = studentname;

                        NewClassDeg.Attend = status;

                        NewClassDeg.Date = today;

                        NewClassDeg.StaffID = StaffNumber;
                        NewClassDeg.CourseCode = CourseCode;


                        Db.tblCaptureAttendance.Add(NewClassDeg);
                        Db.SaveChanges();



                       

                        lblmsg.Text = studentname + " is present in class";

                       
           
                    }

                    

                }




                else
                {



                    //Determine the RowIndex of the Row whose Button was clicked.
                    int rowIndex = Convert.ToInt32(e.CommandArgument);

                    //Reference the GridView Row.
                    GridViewRow row = GridView1.Rows[rowIndex];



                    DateTime today = DateTime.Today;


                    string Studentid = row.Cells[1].Text;
                    string studentname = row.Cells[2].Text;
                    string CourseCode = row.Cells[3].Text;

                    int semid = int.Parse(ddlsemester.SelectedItem.Value);

                    string semester = ddlsemester.SelectedItem.Text;

                    int sessid = int.Parse(ddlsession.SelectedItem.Value);

                    string session = ddlsession.SelectedItem.Text;

                    bool status = false;

                    // StaffNumber



                    var CreateInst = Db.tblCaptureAttendance.Where(x => x.StudentID == Studentid && x.CourseCode == CourseCode && x.Date == today).FirstOrDefault();





                    if (CreateInst == null)
                    {




                        var NewClassDeg = new tblCaptureAttendance();

                        NewClassDeg.semid = semid;

                        NewClassDeg.semester = semester;




                        NewClassDeg.sessid = sessid;

                        NewClassDeg.session = session;

                        NewClassDeg.StudentID = Studentid;
                        NewClassDeg.StudentName = studentname;

                        NewClassDeg.Attend = status;

                        NewClassDeg.Date = today;

                        NewClassDeg.StaffID = StaffNumber;
                        NewClassDeg.CourseCode = CourseCode;


                        Db.tblCaptureAttendance.Add(NewClassDeg);
                        Db.SaveChanges();





                        lblmsg.Text = studentname + " is absent in class";



                    }

                }


            }



            catch (Exception ex)
            {

                lblmsg.Text = ex.Message;

            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {


            try
            {
                ////Determine the RowIndex of the Row whose Button was clicked.
                //int rowIndex = Convert.ToInt32(e.CommandArgument);

                ////Reference the GridView Row.
                //GridViewRow row = GridView1.Rows[rowIndex];



                DateTime today = DateTime.Today;


               

                int semid = int.Parse(ddlsemester.SelectedItem.Value);

                string semester = ddlsemester.SelectedItem.Text;

                int sessid = int.Parse(ddlsession.SelectedItem.Value);

                string session = ddlsession.SelectedItem.Text;

                

                // StaffNumber


                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                    if (chk != null && chk.Checked)
                    {
                        string Studentid = row.Cells[1].Text;
                        string studentname = row.Cells[2].Text;
                        string CourseCode = row.Cells[3].Text;

                        bool status = true;

                        // Check if already marked



                        var CreateInst = Db.tblCaptureAttendance.Where(x => x.StudentID == Studentid && x.CourseCode == CourseCode && x.Date == today).FirstOrDefault();





                        if (CreateInst == null)
                        {




                            var NewClassDeg = new tblCaptureAttendance
                            {


                                semid = semid,

                                semester = semester,




                                sessid = sessid,

                                session = session,

                                StudentID = Studentid,
                                StudentName = studentname,

                                Attend = status,

                                Date = today,

                                StaffID = StaffNumber,
                                CourseCode = CourseCode,

                            };


                            Db.tblCaptureAttendance.Add(NewClassDeg);

                        }





                    }



                    else if (chk != null && !chk.Checked)
                    {
                        string Studentid = row.Cells[1].Text;
                        string studentname = row.Cells[2].Text;
                        string CourseCode = row.Cells[3].Text;

                        // Check if already marked
                        bool status = false;


                        var CreateInst = Db.tblCaptureAttendance.Where(x => x.StudentID == Studentid && x.CourseCode == CourseCode && x.Date == today).FirstOrDefault();





                        if (CreateInst == null)
                        {




                            var NewClassDeg = new tblCaptureAttendance
                            {


                                semid = semid,

                                semester = semester,




                                sessid = sessid,

                                session = session,

                                StudentID = Studentid,
                                StudentName = studentname,

                                Attend = status,

                                Date = today,

                                StaffID = StaffNumber,
                                CourseCode = CourseCode,

                            };


                            Db.tblCaptureAttendance.Add(NewClassDeg);

                        }





                    }






                    else { }


                }



                    Db.SaveChanges();


                    lblmsg.Text = "Attendance processed successfully!";


                }


            catch (Exception ex)
            {

                lblmsg.Text = ex.Message;

            }

        }
    }
}