using AttendanceSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceSystem
{
    public partial class SetupFaculty : System.Web.UI.Page
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

                Response.Redirect("SetupFaculty.aspx");
            }

            try
            {

                if (txtname.Value == "")
                {
                    lblmsg.Text = "Please Enter Faculty Name";
                    txtname.Focus();
                    return;
                }

              


                int degid = 0;
                if (!string.IsNullOrEmpty(Facid.Value))
                {
                    degid = int.Parse(Facid.Value);

                }



                string comName = txtname.Value.Trim();



                var getInstid = (from s in Db.tblSetupInstitution

                                 select new
                                 {
                                     Instid = s.id,

                                    

                                 }).ToArray();


                int  InstutID = getInstid[0].Instid;

              



                var CreateInst = Db.tblSetupFaculty.Where(x => x.facid == degid).FirstOrDefault();





                if (CreateInst == null)
                {


                    var NewClassDeg = new tblSetupFaculty();

                    NewClassDeg.name = Utility.ToSentenceCase(comName);

                    


                    NewClassDeg.Instid = InstutID;

                    



                    Db.tblSetupFaculty.Add(NewClassDeg);
                    Db.SaveChanges();



                    txtname.Value = "";

                    

                    Facid.Value = "0";
                        

                    lblmsg.Text = "Faculty Created Successfully";



                }

                else
                {




                    CreateInst.name = Utility.ToSentenceCase(comName);

                   

                   


                    Db.Entry(CreateInst).State = EntityState.Modified;
                    Db.SaveChanges();







                    txtname.Value = "";

                 
                    Facid.Value = "0";


                    lblmsg.Text = "Faculty Updated Successfully";




                }






            }


            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }



        }
    }
}