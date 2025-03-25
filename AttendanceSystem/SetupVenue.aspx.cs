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
    public partial class SetupVenue : System.Web.UI.Page
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

                Response.Redirect("SetupVenue.aspx");
            }

            try
            {

                if (txtname.Value == "")
                {
                    lblmsg.Text = "Please Enter Venue Name";
                    txtname.Focus();
                    return;
                }



                if (ddlfaculty.SelectedItem.Text == "--Select Faculty--")
                {
                    lblmsg.Text = "Please Select Faculty Name";
                    ddlfaculty.Focus();
                    return;
                }


                int degid = 0;
                if (!string.IsNullOrEmpty(venid.Value))
                {
                    degid = int.Parse(venid.Value);

                }



                string venname = txtname.Value.Trim();




                int facid = int.Parse(ddlfaculty.SelectedItem.Value);

               




                var CreateInst = Db.tblSetupVenue.Where(x => x.venid == degid).FirstOrDefault();





                if (CreateInst == null)
                {


                    var NewClassDeg = new tblSetupVenue();

                    NewClassDeg.name = venname.ToUpper();

                   


                    NewClassDeg.deptid = facid;





                    Db.tblSetupVenue.Add(NewClassDeg);
                    Db.SaveChanges();



                    txtname.Value = "";



                    venid.Value = "0";


                    ddlfaculty.SelectedIndex = 0;


                    lblmsg.Text = "Venue Created Successfully";



                }

                else
                {







                    CreateInst.name = venname.ToUpper(); 




                    CreateInst.deptid = facid;






                    Db.Entry(CreateInst).State = EntityState.Modified;
                    Db.SaveChanges();





                    txtname.Value = "";



                    venid.Value = "0";


                    ddlfaculty.SelectedIndex = 0;


                    lblmsg.Text = "Venue Updated Successfully";




                }






            }


            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }




        }
    }
}