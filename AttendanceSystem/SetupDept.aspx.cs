using AttendanceSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace AttendanceSystem
{
    public partial class SetupDept : System.Web.UI.Page
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

                Response.Redirect("SetupDept.aspx");
            }

            try
            {

                if (txtdeptname.Value == "")
                {
                    lblmsg.Text = "Please Enter Department Name";
                    txtdeptname.Focus();
                    return;
                }



                if (ddlfaculty.SelectedItem.Text == "--Select Faculty--")
                {
                    lblmsg.Text = "Please Select Faculty Name";
                    ddlfaculty.Focus();
                    return;
                }


                int degid = 0;
                if (!string.IsNullOrEmpty(deptid.Value))
                {
                    degid = int.Parse(deptid.Value);

                }



                string deptname = txtdeptname.Value.Trim();



                
                int facid = int.Parse(ddlfaculty.SelectedItem.Value);

                var getInstid = (from s in Db.tblSetupInstitution

                                 select new
                                 {
                                     Instid = s.id,



                                 }).ToArray();


                int InstutID = getInstid[0].Instid;




                var CreateInst = Db.tblSetupDept.Where(x => x.deptid == degid).FirstOrDefault();





                if (CreateInst == null)
                {


                    var NewClassDeg = new tblSetupDept();

                    NewClassDeg.name = Utility.ToSentenceCase(deptname);




                    NewClassDeg.facid = facid;

                   



                    Db.tblSetupDept.Add(NewClassDeg);
                    Db.SaveChanges();



                    txtdeptname.Value = "";



                    deptid.Value = "0";


                    ddlfaculty.SelectedIndex = 0;


                    lblmsg.Text = "Department Created Successfully";



                }

                else
                {




                    


                    CreateInst.name = Utility.ToSentenceCase(deptname);




                    CreateInst.facid = facid;

                 




                    Db.Entry(CreateInst).State = EntityState.Modified;
                    Db.SaveChanges();






                    txtdeptname.Value = "";



                    deptid.Value = "0";


                    ddlfaculty.SelectedIndex = 0;

                    lblmsg.Text = "Department Updated Successfully";




                }






            }


            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }

        }
    }
}