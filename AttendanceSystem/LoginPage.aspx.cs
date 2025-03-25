using AttendanceSystem.Model;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceSystem
{
    public partial class LoginPage : System.Web.UI.Page
    {

        AttendanceEntities Db = new AttendanceEntities();


        AttendanceClass Utility = new AttendanceClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
            }
        }


        protected void Page_PreRender(object sender, EventArgs e)
        {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];
        }


        private void ShowMessage(string Message)
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertmessage", "alert('" + Message + "')", true);

        }


        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {


            try
            {

                if (txtusername.Value == "")
                {
                    txtusername.Focus();
                    ShowMessage("Please Enter your Email Address");
                    return;
                }

                else
                {

                    string Checkemail = txtusername.Value.Trim();
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(Checkemail);
                    if (match.Success)
                    {

                    }

                    else
                    {
                        ShowMessage("Invalid Email Address");
                        txtusername.Focus();
                        return;
                    }

                }





                if (txtpassword.Value == "")
                {
                    ShowMessage("Please Enter password");
                    txtpassword.Focus();

                    return;
                }



                if (txtusername.Value != "" && txtpassword.Value != "")

                {

                    string username = "dammy4edu@gmail.com";
                    string adpasssword = "SuperAdmin@1234";



                    if (txtusername.Value == username && txtpassword.Value == adpasssword)
                    {
                        Session["StaffNumber"] = "SAF/ACA/P.1337";
                        Session["FullName"] = "System Administrator";
                        Session["Email"] = "dammy4edu@gmail.com";
                       
                        Session["Status"] = "3";

                        string previousurl = Request.QueryString["RedirectUr"];
                        // string item1 = base.Request.QueryString["Details.Page"];


                        string page;


                        if (Session["Page"] == null)
                        {

                            Response.Redirect("~/DashBoard.aspx");

                        }

                        else
                        {
                            page = Session["Page"].ToString();

                            string url = page + "." + "aspx";
                            Response.Redirect(url);
                        }






                    }


                    else
                    {


                        string staffno = txtusername.Value.Trim();

                        string password = txtpassword.Value;



                        string pass = Utility.Encrypt(password);


                        var User = Db.tblUser.Where(x => x.Email == staffno && x.Password == pass).FirstOrDefault();



                        if (User == null)
                        {



                            ShowMessage("Invalid Username or Password");
                            return;
                        }


                        else
                        {

                            var GetUserDetails = (from s in Db.tblUser.Where(s => s.Email == staffno)
                                                  select new
                                                  {

                                                      Status = s.Statusid,
                                                      Staffid = s.SchID,


                                                  }).ToArray();


                            
                            int Role = GetUserDetails[0].Status;

                            string getStaffid = GetUserDetails[0].Staffid;


                            string StatusID = Convert.ToString(Role);

                            Session["Status"] = StatusID;
                            Session["StaffNumber"] = getStaffid;



                            string previousurl = Request.QueryString["RedirectUr"];
                            // string item1 = base.Request.QueryString["Details.Page"];


                            string page;


                            if (Session["Page"] == null)
                            {

                                Response.Redirect("~/DashBoard.aspx");

                            }

                            else
                            {
                                page = Session["Page"].ToString();

                                string url = page + "." + "aspx";
                                Response.Redirect(url);
                            }








                        }





                    }


                }









            }

            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }


        }
    }
}