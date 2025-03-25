using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceSystem
{
    public partial class SiteMaster : MasterPage
    {


        int statusid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Status"] == null)
            {
                Response.Redirect("LoginPage.aspx");

            }


            else
            {
                string Statusid = Session["Status"].ToString();


                statusid = Convert.ToInt32(Statusid);

                if (!IsPostBack)
                {
                   
                    HideMenu(statusid);
                   
                }


            }

        }

        private void HideMenu(int statusid)
        {


            if (statusid == 1)
            {

                mnuSetup.Visible = false;

                mnuUsers.Visible = false;

                mnucoursesetup.Visible = false;


                mnucoursalloc.Visible = false;

            }

            //else if (statusid == 2)

            //{


            //}
            //else { }
        }
    }
}