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
    public partial class SetupInstitution : System.Web.UI.Page
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

                Response.Redirect("SetupInstitution.aspx");
            }

            try
            {

                if (txtname.Value == "")
                {
                    lblmsg.Text = "Please Enter Institution Name";
                    txtname.Focus();
                    return;
                }

                if (txtaddress.Value == "")
                {
                    lblmsg.Text = "Please Enter Institution Address";
                    txtaddress.Focus();
                    return;
                }


                if (txtphone.Value == "")
                {
                    lblmsg.Text = "Please Enter Institution Phone Number ";
                    txtphone.Focus();
                    return;
                }

                if (txtpost.Value == "")
                {
                    lblmsg.Text = "Please Enter Institution Postal Code ";
                    txtpost.Focus();
                    return;
                }




                if (txtemail.Value == "")
                {
                    lblmsg.Text = "Please Enter Institution  Email Address!!!";
                    txtemail.Focus();
                    return;
                }

                else
                {

                    string Checkemail = txtemail.Value;
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(Checkemail);
                    if (match.Success)
                    {

                    }

                    else
                    {
                        lblmsg.Text = "Invalid Email Address";
                        txtemail.Focus();
                        return;
                    }

                }


                int degid = 0;
                if (!string.IsNullOrEmpty(ComID.Value))
                {
                    degid = int.Parse(ComID.Value);

                }



                string comName = txtname.Value.Trim();

                string comAddr = txtaddress.Value.Trim();

                string comPhone = txtphone.Value.Trim();

                string comEmail = txtemail.Value.Trim();

                string postcode = txtpost.Value.Trim();







                var CreateInst = Db.tblSetupInstitution.Where(x => x.id == degid).FirstOrDefault();



                if (CreateInst == null)
                {


                    var NewClassDeg = new tblSetupInstitution();

                    NewClassDeg.name = Utility.ToSentenceCase(comName);

                    NewClassDeg.address = Utility.ToSentenceCase(comAddr);


                    NewClassDeg.tel = comPhone;

                    NewClassDeg.email = comEmail;

                    NewClassDeg.postalcode = Utility.ToSentenceCase(postcode);



                    Db.tblSetupInstitution.Add(NewClassDeg);
                    Db.SaveChanges();



                    txtname.Value = "";

                    txtaddress.Value = "";

                    txtphone.Value = "";
                    txtemail.Value = "";


                    ComID.Value = "0";


                    lblmsg.Text = "Institution Created Successfully";



                }

                else
                {




                    CreateInst.name = Utility.ToSentenceCase(comName);

                    CreateInst.address = Utility.ToSentenceCase(comAddr);


                    CreateInst.tel = comPhone;

                    CreateInst.email = comEmail;

                    CreateInst.postalcode = Utility.ToSentenceCase(postcode);




                    Db.Entry(CreateInst).State = EntityState.Modified;
                    Db.SaveChanges();







                    txtname.Value = "";

                    txtaddress.Value = "";

                    txtphone.Value = "";
                    txtemail.Value = "";


                    txtpost.Value = "";


                    ComID.Value = "0";


                    lblmsg.Text = "Institution Updated Successfully";




                }






            }


            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }




        }
    }
}