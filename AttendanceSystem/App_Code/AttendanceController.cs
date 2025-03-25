using AttendanceSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using Antlr.Runtime.Misc;


namespace AttendanceSystem.App_Code
{
    public class AttendanceController : ApiController
    {


        AttendanceEntities Db = new AttendanceEntities();

        [HttpGet, HttpPost]
        [ActionName("LoadInstitution")]
        public IEnumerable<tblSetupInstitution> LoadInstitution()
        {


            try
            {
                var query = Db.tblSetupInstitution.ToArray();




                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Institution: {ex.Message}");
                return Enumerable.Empty<tblSetupInstitution>();
            }






        }




        [HttpGet, HttpPost]
        [ActionName("LoadFaculty")]
        public IEnumerable<tblSetupFaculty> LoadFaculty()
        {


            try
            {
                var query = Db.tblSetupFaculty.ToArray();




                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Faculty: {ex.Message}");
                return Enumerable.Empty<tblSetupFaculty>();
            }



        }


        [HttpPost, HttpGet]
        [ActionName("DeleteFaculty")]

        public int DeleteFaculty(int id)
        {


                     
                      

            var query = Db.Database.ExecuteSqlCommand("DELETE FROM tblSetupFaculty WHERE facid = @Id", new SqlParameter("@Id", id));
            Db.SaveChanges();




            return query;

        }






        [HttpGet, HttpPost]
        [ActionName("LoadDept")]
        public IEnumerable<tblSetupDept> LoadDept()
        {


            try
            {
                var query = Db.tblSetupDept.ToArray();




                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Department: {ex.Message}");
                return Enumerable.Empty<tblSetupDept>();
            }



        }


        [HttpPost, HttpGet]
        [ActionName("DeleteDept")]

        public int DeleteDept(int id)
        {





            var query = Db.Database.ExecuteSqlCommand("DELETE FROM tblSetupDept WHERE deptid = @Id", new SqlParameter("@Id", id));
            Db.SaveChanges();




            return query;

        }








        [HttpGet, HttpPost]
        [ActionName("LoadVenue")]
        public IEnumerable<tblSetupVenue> LoadVenue()
        {


            try
            {
                var query = Db.tblSetupVenue.ToArray();




                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Venue: {ex.Message}");
                return Enumerable.Empty<tblSetupVenue>();
            }



        }


        [HttpPost, HttpGet]
        [ActionName("DeleteVenue")]

        public int DeleteVenue(int id)
        {





            var query = Db.Database.ExecuteSqlCommand("DELETE FROM tblSetupVenue WHERE venid = @Id", new SqlParameter("@Id", id));
            Db.SaveChanges();




            return query;

        }




        [HttpGet, HttpPost]
        [ActionName("LoadSession")]
        public IEnumerable<tblSetupSession> LoadSession()
        {


            try
            {
                var query = Db.tblSetupSession.ToArray();




                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Session: {ex.Message}");
                return Enumerable.Empty<tblSetupSession>();
            }



        }


        [HttpPost, HttpGet]
        [ActionName("DeleteSession")]

        public int DeleteSession(int id)
        {





            var query = Db.Database.ExecuteSqlCommand("DELETE FROM tblSetupSession WHERE sessid = @Id", new SqlParameter("@Id", id));
            Db.SaveChanges();




            return query;

        }



        [HttpGet, HttpPost]
        [ActionName("LoadSemester")]
        public IEnumerable<tblSetupSemester> LoadSemester()
        {


            try
            {
                var query = Db.tblSetupSemester.ToArray();




                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Semester: {ex.Message}");
                return Enumerable.Empty<tblSetupSemester>();
            }



        }


        [HttpPost, HttpGet]
        [ActionName("DeleteSemester")]

        public int DeleteSemester(int id)
        {





            var query = Db.Database.ExecuteSqlCommand("DELETE FROM tblSetupSemester WHERE semid = @Id", new SqlParameter("@Id", id));
            Db.SaveChanges();




            return query;

        }






        [HttpGet, HttpPost]
        [ActionName("LoadCourse")]
        public IEnumerable<tblsetupCourse> LoadCourse()
        {


            try
            {
                var query = Db.tblsetupCourse.ToArray();




                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Courses: {ex.Message}");
                return Enumerable.Empty<tblsetupCourse>();
            }



        }


        [HttpPost, HttpGet]
        [ActionName("DeleteCourse")]

        public int DeleteCourse(int id)
        {





            var query = Db.Database.ExecuteSqlCommand("DELETE FROM tblsetupCourse WHERE courseid = @Id", new SqlParameter("@Id", id));
            Db.SaveChanges();




            return query;

        }





        [HttpGet, HttpPost]
        [ActionName("LoadUser")]
        public IEnumerable<tblUser> LoadUser()
        {


            try
            {
                var query = Db.tblUser.ToArray();




                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Users: {ex.Message}");
                return Enumerable.Empty<tblUser>();
            }



        }




        [HttpGet, HttpPost]
        [ActionName("LoadCourseAllocation")]
        public IEnumerable<tblNewCourseAllocation> LoadCourseAllocation()
        {


            try
            {
                var query = Db.tblNewCourseAllocation.ToArray();




                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Courses Allocation: {ex.Message}");
                return Enumerable.Empty<tblNewCourseAllocation>();
            }



        }


        [HttpPost, HttpGet]
        [ActionName("DeleteCourseAllocation")]

        public int DeleteCourseAllocation(int id)
        {





            var query = Db.Database.ExecuteSqlCommand("DELETE FROM tblNewCourseAllocation WHERE Allocid = @Id", new SqlParameter("@Id", id));
            Db.SaveChanges();




            return query;

        }







        [HttpGet, HttpPost]
        [ActionName("LoadCourseRegistration")]
        public IEnumerable<tblCourseRegistration> LoadCourseRegistration()
        {


            try
            {
                var query = Db.tblCourseRegistration.ToArray();




                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Courses Registration: {ex.Message}");
                return Enumerable.Empty<tblCourseRegistration>();
            }



        }


        [HttpPost, HttpGet]
        [ActionName("DeleteCourseRegister")]

        public int DeleteCourseRegister (int id)
        {





            var query = Db.Database.ExecuteSqlCommand("DELETE FROM tblCourseRegistration WHERE Allocid = @Id", new SqlParameter("@Id", id));
            Db.SaveChanges();




            return query;

        }








    }
}
