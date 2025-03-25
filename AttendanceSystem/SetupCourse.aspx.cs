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
    public partial class SetupCourse : System.Web.UI.Page
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


        protected void ddlfaculty_SelectedIndexChanged(object sender, EventArgs e)
        {



            int facId = Convert.ToInt32(ddlfaculty.SelectedItem.Value);
            var getdata = (from s in Db.tblSetupDept.Where(s => s.facid == facId)
                           select new { s.deptid, s.name }).ToList();




            ddlDept.DataTextField = "name";
            ddlDept.DataValueField = "deptid";
            ddlDept.DataSource = getdata;
            ddlDept.DataBind();
            ddlDept.Items.Insert(0, "--Select Dept--");



        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {

            int facId = Convert.ToInt32(ddlDept.SelectedItem.Value);
            var getdata = (from s in Db.tblSetupVenue.Where(s => s.deptid == facId)
                           select new { s.venid, s.name }).ToList();




            ddlvenue.DataTextField = "name";
            ddlvenue.DataValueField = "venid";
            ddlvenue.DataSource = getdata;
            ddlvenue.DataBind();
            ddlvenue.Items.Insert(0, "--Select Venue--");






        }

        protected void btnsave_Click(object sender, EventArgs e)
        {


            if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
            {

                Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());

            }

            else
            {

                Response.Redirect("SetupCourse.aspx");
            }

            try
            {

                if (txtcode.Value == "")
                {
                    lblmsg.Text = "Please Enter Course Code";
                    txtcode.Focus();
                    return;
                }



                if (txttitle.Value == "")
                {
                    lblmsg.Text = "Please Enter Course Title";
                    txttitle.Focus();
                    return;
                }



                if (ddlfaculty.SelectedItem.Text == "--Select Faculty--")
                {
                    lblmsg.Text = "Please Select Faculty Name";
                    ddlfaculty.Focus();
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


                if (ddlsemester.SelectedItem.Text == "--Select Semester--")
                {
                    lblmsg.Text = "Please Select Semester for Course";
                    ddlsemester.Focus();
                    return;
                }



                int degid = 0;
                if (!string.IsNullOrEmpty(courseid.Value))
                {
                    degid = int.Parse(courseid.Value);

                }



                string comCode = txtcode.Value.Trim();


                string title = txttitle.Value.Trim();






                var CreateInst = Db.tblsetupCourse.Where(x => x.courseid == degid).FirstOrDefault();





                if (CreateInst == null)
                {


                    var NewClassDeg = new tblsetupCourse();

                    NewClassDeg.title = Utility.ToSentenceCase(title);

                    NewClassDeg.code = comCode.ToUpper();


                    NewClassDeg.Semester = ddlsemester.SelectedItem.Text;

                    NewClassDeg.semid = int.Parse(ddlsemester.SelectedItem.Value);

                    NewClassDeg.venid = int.Parse(ddlvenue.SelectedItem.Value);


                    NewClassDeg.deptid = int.Parse(ddlDept.SelectedItem.Value);


                    Db.tblsetupCourse.Add(NewClassDeg);
                    Db.SaveChanges();



                    txtcode.Value = "";

                    txttitle.Value = "";

                    courseid.Value = "0";

                    ddlfaculty.SelectedIndex = 0;
                    ddlsemester.SelectedIndex = 0;

                    ddlDept.SelectedIndex = 0;
                    ddlvenue.SelectedIndex = 0;



                    lblmsg.Text = "Course Created Successfully";



                }

                else
                {









                  



                    CreateInst.title = Utility.ToSentenceCase(title);

                    CreateInst.code = comCode.ToUpper();


                    CreateInst.Semester = ddlsemester.SelectedItem.Text;

                    CreateInst.semid = int.Parse(ddlsemester.SelectedItem.Value);

                    CreateInst.venid = int.Parse(ddlvenue.SelectedItem.Value);


                    CreateInst.deptid = int.Parse(ddlDept.SelectedItem.Value);



                    Db.Entry(CreateInst).State = EntityState.Modified;
                    Db.SaveChanges();




                    txtcode.Value = "";

                    txttitle.Value = "";

                    courseid.Value = "0";

                    ddlfaculty.SelectedIndex = 0;
                    ddlsemester.SelectedIndex = 0;

                    ddlDept.SelectedIndex = 0;
                    ddlvenue.SelectedIndex = 0;



                    lblmsg.Text = "Course Updated Successfully";






                }






            }


            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }


        }
    }
}