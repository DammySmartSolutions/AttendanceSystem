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
    public partial class SetupSession : System.Web.UI.Page
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

                Response.Redirect("SetupSession.aspx");
            }

            try
            {

                if (txtsession.Value == "")
                {
                    lblmsg.Text = "Please Enter Session";
                    txtsession.Focus();
                    return;
                }




                int degid = 0;
                if (!string.IsNullOrEmpty(Sessid.Value))
                {
                    degid = int.Parse(Sessid.Value);

                }



                string comName = txtsession.Value.Trim();



               





                var CreateInst = Db.tblSetupSession.Where(x => x.sessid == degid).FirstOrDefault();





                if (CreateInst == null)
                {


                    var NewClassDeg = new tblSetupSession();

                    NewClassDeg.session = comName;




                    





                    Db.tblSetupSession.Add(NewClassDeg);
                    Db.SaveChanges();



                    txtsession.Value = "";



                    Sessid.Value = "0";


                    lblmsg.Text = "Session Created Successfully";



                }

                else
                {




                  


                    CreateInst.session = comName;



                    Db.Entry(CreateInst).State = EntityState.Modified;
                    Db.SaveChanges();







                    txtsession.Value = "";


                    Sessid.Value = "0";


                    lblmsg.Text = "Session Updated Successfully";




                }






            }


            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }

        }
    }
}