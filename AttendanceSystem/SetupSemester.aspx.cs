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
    public partial class SetupSemester : System.Web.UI.Page
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

                Response.Redirect("SetupSemester.aspx");
            }

            try
            {

                if (txtsemester.Value == "")
                {
                    lblmsg.Text = "Please Enter Semester";
                    txtsemester.Focus();
                    return;
                }




                int degid = 0;
                if (!string.IsNullOrEmpty(Semid.Value))
                {
                    degid = int.Parse(Semid.Value);

                }



                string comName = txtsemester.Value.Trim();









                var CreateInst = Db.tblSetupSemester.Where(x => x.semid == degid).FirstOrDefault();





                if (CreateInst == null)
                {


                    var NewClassDeg = new tblSetupSemester();

                    NewClassDeg.semester = Utility.ToSentenceCase(comName);










                    Db.tblSetupSemester.Add(NewClassDeg);
                    Db.SaveChanges();



                    txtsemester.Value = "";



                    Semid.Value = "0";


                    lblmsg.Text = "Semester Created Successfully";



                }

                else
                {







                 

                    CreateInst.semester = Utility.ToSentenceCase(comName);



                    Db.Entry(CreateInst).State = EntityState.Modified;
                    Db.SaveChanges();





                    txtsemester.Value = "";



                    Semid.Value = "0";


                    lblmsg.Text = "Semester Updated Successfully";


                    



                }






            }


            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }

        }
    }
}