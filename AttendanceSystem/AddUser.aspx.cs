using AttendanceSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace AttendanceSystem
{
    public partial class AddUser : System.Web.UI.Page
    {

        AttendanceEntities Db = new AttendanceEntities();


        AttendanceClass Utility = new AttendanceClass();

        int PageID = 0;

        string email = "";
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Request.QueryString["id"] != null)
            {
                string GetId = Request.QueryString["id"].ToString();

                PageID = Convert.ToInt32(GetId);


                
                    if (!IsPostBack)
                    {
                        divalert.Visible = false;
                        LoadPageData(PageID);

                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    }
                    else
                    {

                        divalert.Visible = true;
                    }


                


            }

            else
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




        }

        private void LoadPageData(int pageID)
        {
            var query = (from s in Db.tblUser.Where(s => s.userid == pageID)

                         select new
                         {
                             schno = s.SchID,
                             FullName = s.Name,
                             Emailaddr = s.Email,
                             Depart = s.Dept,
                             status = s.Status, 

                           

                         }).ToArray();






            txtid.Value = query[0].schno;
            txtname.Value = query[0].FullName;

            txtemail.Value = query[0].Emailaddr;

            ddlDept.SelectedItem.Text = query[0].Depart;

            ddlStatus.SelectedItem.Text = query[0].status;




            

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

                Response.Redirect("AddUser.aspx");
            }


            try
            {

                if (txtid.Value == "")
                {
                    lblmsg.Text = "Please Enter your Staff/StudentID";
                    txtid.Focus();
                    return;
                }



                if (txtname.Value == "")
                {
                    lblmsg.Text = "Please Enter your name";
                    txtname.Focus();
                    return;
                }



               


                if (ddlDept.SelectedItem.Text == "--Select Dept--")
                {
                    lblmsg.Text = "Please Select Department Name";
                    ddlDept.Focus();
                    return;
                }



                if (ddlStatus.SelectedItem.Text == "--Select Status--")
                {
                    lblmsg.Text = "Please Select Venue for Course";
                    ddlStatus.Focus();
                    return;
                }


                if (txtemail.Value == "")
                {
                    lblmsg.Text = "Please Enter your  Email Address!!!";
                    txtemail.Focus();
                    return;
                }
                else
                {

                    string Checkemail = txtemail.Value.Trim();
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


                if (txtpass.Value == "")
                {
                    lblmsg.Text = "Please Enter your New Password";
                    txtpass.Focus();
                    return;
                }

                if (txtconfirmpass.Value == "")
                {
                    lblmsg.Text = "Please Enter your Confirm Password";
                    txtconfirmpass.Focus();
                    return;
                }


                string pass = txtpass.Value.Trim();


                string confirmpass = txtconfirmpass.Value.Trim();

                if (pass != confirmpass)
                {
                    lblmsg.Text = "Password Mismatch";
                    txtconfirmpass.Focus();
                    return;
                }








                string SCHID= txtid.Value.Trim().ToUpper();


                string Fullname = txtname.Value.Trim().ToUpper();

                email = txtemail.Value.Trim();

                string Dept = ddlDept.SelectedItem.Text;


                string Status = ddlStatus.SelectedItem.Text;


                



                var CreateInst = Db.tblUser.Where(x => x.userid == PageID).FirstOrDefault();





                if (CreateInst == null)
                {



                    string EmailCheck = CheckEmailAddress(email);


                    if (EmailCheck == "Exist")
                    {
                        lblmsg.Text = "Email Address Already Exist, Kindly use a new Email Address";

                        return;
                    }



                    var NewClassDeg = new tblUser();

                    NewClassDeg.Name = Fullname;

                    NewClassDeg.SchID = SCHID;



                    NewClassDeg.Email = email;

                    NewClassDeg.Dept = Dept;

                    NewClassDeg.Deptid = int.Parse(ddlDept.SelectedItem.Value);


                    NewClassDeg.Status = Status;

                    NewClassDeg.Statusid = int.Parse(ddlStatus.SelectedItem.Value);

                    NewClassDeg.Password = Utility.Encrypt(pass);




                    Db.tblUser.Add(NewClassDeg);
                    Db.SaveChanges();



                    txtconfirmpass.Value = "";

                    txtemail.Value = "";

                    txtname.Value = "";

                    txtpass.Value = "";
                    txtid.Value = "";

                    ddlDept.SelectedIndex = 0;
                    ddlStatus.SelectedIndex = 0;



                    Session["Alert"] = "User Added Successfully";



                    Response.Redirect("UserList.aspx");

                    



                }

                else
                {




                    CreateInst.Name = Fullname;

                    CreateInst.SchID = SCHID;



                    CreateInst.Email = email;

                    CreateInst.Dept = Dept;

                    CreateInst.Deptid = int.Parse(ddlDept.SelectedItem.Value);


                    CreateInst.Status = Status;

                    CreateInst.Statusid = int.Parse(ddlStatus.SelectedItem.Value);

                    CreateInst.Password = Utility.Encrypt(pass);




                    Db.Entry(CreateInst).State = EntityState.Modified;
                    Db.SaveChanges();




                    txtconfirmpass.Value = "";

                    txtemail.Value = "";

                    txtname.Value = "";

                    txtpass.Value = "";
                    txtid.Value = "";

                    ddlDept.SelectedIndex = 0;
                    ddlStatus.SelectedIndex = 0;



                    Session["Alert"] = "User Detail Updated Successfully";



                    Response.Redirect("UserList.aspx");






                }






            }


            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }





        }

        private string CheckEmailAddress(string email)
        {
            var chkmail = Db.tblUser.Where(x => x.Email == email).FirstOrDefault();

            string result = "";

            if (chkmail == null)
            {
                result = "Not Exist";
            }
            else
            {
                result = "Exist";


            }

            return result;
        }
    }
}