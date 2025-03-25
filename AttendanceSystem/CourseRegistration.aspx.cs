using AttendanceSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceSystem
{
    public partial class CourseRegistration : System.Web.UI.Page
    {
        AttendanceEntities Db = new AttendanceEntities();


        AttendanceClass Utility = new AttendanceClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                divalert.Visible = false;
                Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
            }

            else
            {

                divalert.Visible = true;
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
            {

                Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());

            }

            else
            {

                Response.Redirect("CourseRegistration.aspx");
            }

            try
            {




                if (ddlsemester.SelectedItem.Text == "--Select Semester--")
                {
                    lblmsg.Text = "Please Select Semester";
                    ddlsemester.Focus();
                    return;
                }


                if (ddlDept.SelectedItem.Text == "--Select Dept--")
                {
                    lblmsg.Text = "Please Select Department Name";
                    ddlDept.Focus();
                    return;
                }



                if (ddlvenue.SelectedItem.Text == "--Select Venue--")
                {
                    lblmsg.Text = "Please Select Venue for Course";
                    ddlvenue.Focus();
                    return;
                }

                if (ddlcode.SelectedItem.Text == "--Select CourseCode--")
                {
                    lblmsg.Text = "Please Select Course Code";
                    ddlcode.Focus();
                    return;
                }


                if (ddlstaffid.SelectedItem.Text == "--Select Student--")
                {
                    lblmsg.Text = "Please Select Instructor";
                    ddlstaffid.Focus();
                    return;
                }



                if (ddlSession.SelectedItem.Text == "--Select Session--")
                {
                    lblmsg.Text = "Please Select Session";
                    ddlSession.Focus();
                    return;
                }



                int degid = 0;
                if (!string.IsNullOrEmpty(Allocid.Value))
                {
                    degid = int.Parse(Allocid.Value);

                }










                var CreateInst = Db.tblCourseRegistration.Where(x => x.Allocid == degid).FirstOrDefault();





                if (CreateInst == null)
                {


                    var NewClassDeg = new tblCourseRegistration();

                    NewClassDeg.Semid = int.Parse(ddlsemester.SelectedItem.Value);

                    NewClassDeg.code = ddlcode.SelectedItem.Text;

                    NewClassDeg.sessionid = int.Parse(ddlSession.SelectedItem.Value);

                    NewClassDeg.semester = ddlsemester.SelectedItem.Text;

                    NewClassDeg.Session = ddlSession.SelectedItem.Text;

                    NewClassDeg.Dept = ddlDept.SelectedItem.Text;

                    NewClassDeg.Deptid = int.Parse(ddlDept.SelectedItem.Value);


                    NewClassDeg.StudentName = ddlstaffid.SelectedItem.Text;

                    NewClassDeg.StudentID = ddlstaffid.SelectedItem.Value;



                    NewClassDeg.Venue = ddlvenue.SelectedItem.Text;

                    NewClassDeg.Venueid = int.Parse(ddlDept.SelectedItem.Value);




                    Db.tblCourseRegistration.Add(NewClassDeg);
                    Db.SaveChanges();




                    ddlSession.SelectedIndex = 0;
                    ddlsemester.SelectedIndex = 0;

                    ddlDept.SelectedIndex = 0;
                    ddlvenue.SelectedIndex = 0;

                    ddlstaffid.SelectedIndex = 0;

                    ddlcode.SelectedIndex = 0;



                    lblmsg.Text = "Course Registration  Successfully";



                }

                else
                {





                    CreateInst.Semid = int.Parse(ddlsemester.SelectedItem.Value);

                    CreateInst.code = ddlcode.SelectedItem.Text;

                    CreateInst.sessionid = int.Parse(ddlSession.SelectedItem.Value);

                    CreateInst.semester = ddlsemester.SelectedItem.Text;

                    CreateInst.Session = ddlSession.SelectedItem.Text;

                    CreateInst.Dept = ddlDept.SelectedItem.Text;

                    CreateInst.Deptid = int.Parse(ddlDept.SelectedItem.Value);


                    CreateInst.StudentName = ddlstaffid.SelectedItem.Text;

                    CreateInst.StudentID = ddlstaffid.SelectedItem.Value;



                    CreateInst.Venue = ddlvenue.SelectedItem.Text;

                    CreateInst.Venueid = int.Parse(ddlDept.SelectedItem.Value);




                    Db.Entry(CreateInst).State = EntityState.Modified;
                    Db.SaveChanges();





                    ddlSession.SelectedIndex = 0;
                    ddlsemester.SelectedIndex = 0;

                    ddlDept.SelectedIndex = 0;
                    ddlvenue.SelectedIndex = 0;

                    ddlstaffid.SelectedIndex = 0;

                    ddlcode.SelectedIndex = 0;



                    lblmsg.Text = "Course Registration Updated Successfully";






                }






            }


            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }


        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deptId = Convert.ToInt32(ddlDept.SelectedItem.Value);


            LoadCourse(deptId);

            LoadVenue(deptId);


            LoadStudent();
        }




        private void LoadStudent()
        {
            var getdata = (from s in Db.tblUser.Where(s =>  s.Statusid == 2)
                           select new { s.SchID, s.Name }).ToList();




            ddlstaffid.DataTextField = "Name";
            ddlstaffid.DataValueField = "SchID";
            ddlstaffid.DataSource = getdata;
            ddlstaffid.DataBind();
            ddlstaffid.Items.Insert(0, "--Select Student--");
        }

        private void LoadVenue(int deptId)
        {

            var getdata = (from s in Db.tblSetupVenue.Where(s => s.deptid == deptId)
                           select new { s.venid, s.name }).ToList();




            ddlvenue.DataTextField = "name";
            ddlvenue.DataValueField = "venid";
            ddlvenue.DataSource = getdata;
            ddlvenue.DataBind();
            ddlvenue.Items.Insert(0, "--Select Venue--");
        }

        private void LoadCourse(int deptId)
        {


            var getdata = (from s in Db.tblsetupCourse.Where(s => s.deptid == deptId)
                           select new { s.courseid, s.code }).ToList();




            ddlcode.DataTextField = "code";
            ddlcode.DataValueField = "courseid";
            ddlcode.DataSource = getdata;
            ddlcode.DataBind();
            ddlcode.Items.Insert(0, "--Select CourseCode--");
        }

    }
}