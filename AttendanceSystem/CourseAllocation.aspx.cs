using AttendanceSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace AttendanceSystem
{
    public partial class CourseAllocation : System.Web.UI.Page
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

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {


            int deptId = Convert.ToInt32(ddlDept.SelectedItem.Value);


            LoadCourse(deptId);

            LoadVenue(deptId);


            LoadInstructor(deptId);
        }

        private void LoadInstructor(int deptId)
        {
            var getdata = (from s in Db.tblUser.Where(s => s.Deptid == deptId && s.Statusid == 1)
                           select new { s.SchID, s.Name }).ToList();




            ddlstaffid.DataTextField = "Name";
            ddlstaffid.DataValueField = "SchID";
            ddlstaffid.DataSource = getdata;
            ddlstaffid.DataBind();
            ddlstaffid.Items.Insert(0, "--Select Instructor--");
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

        protected void btnsave_Click(object sender, EventArgs e)
        {


            if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
            {

                Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());

            }

            else
            {

                Response.Redirect("CourseAllocation.aspx");
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


                if (ddlstaffid.SelectedItem.Text == "--Select Instructor--")
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



                






                var CreateInst = Db.tblNewCourseAllocation.Where(x => x.Allocid == degid).FirstOrDefault();





                if (CreateInst == null)
                {


                    var NewClassDeg = new tblNewCourseAllocation();

                    NewClassDeg.Semid = int.Parse(ddlsemester.SelectedItem.Value);

                    NewClassDeg.code = ddlcode.SelectedItem.Text;

                    NewClassDeg.sessionid = int.Parse(ddlSession.SelectedItem.Value);

                    NewClassDeg.semester = ddlsemester.SelectedItem.Text;

                    NewClassDeg.Session = ddlSession.SelectedItem.Text;

                    NewClassDeg.Dept = ddlDept.SelectedItem.Text;

                    NewClassDeg.Deptid = int.Parse(ddlDept.SelectedItem.Value);


                    NewClassDeg.StaffName = ddlstaffid.SelectedItem.Text;

                    NewClassDeg.StaffId = ddlstaffid.SelectedItem.Value;



                    NewClassDeg.Venue = ddlvenue.SelectedItem.Text;

                    NewClassDeg.Venueid = int.Parse(ddlDept.SelectedItem.Value);


                    

                    Db.tblNewCourseAllocation.Add(NewClassDeg);
                    Db.SaveChanges();




                    ddlSession.SelectedIndex = 0;
                    ddlsemester.SelectedIndex = 0;

                    ddlDept.SelectedIndex = 0;
                    ddlvenue.SelectedIndex = 0;

                    ddlstaffid.SelectedIndex = 0;

                    ddlcode.SelectedIndex = 0;



                    lblmsg.Text = "Course Allocation Created Successfully";



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


                    CreateInst.StaffName = ddlstaffid.SelectedItem.Text;

                    CreateInst.StaffId = ddlstaffid.SelectedItem.Value;



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



                    lblmsg.Text = "Course Allocation Updated Successfully";






                }






            }


            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }



        }
    }
}