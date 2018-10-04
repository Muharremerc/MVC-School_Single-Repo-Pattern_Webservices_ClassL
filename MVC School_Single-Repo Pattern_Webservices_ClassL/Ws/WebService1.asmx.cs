using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Model;
using System.Web.Services;

namespace Ws
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        public List<Student> getAllStudent()
        {
            try
            {
                var db = DAL.SchoolDB.getInstance();
                var studentList = db.getAllStudent();
                return studentList;


            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<Student> getStudentLessonsbyId(int id)
        {
            try
            {
                var db = DAL.SchoolDB.getInstance();
                var StudentLesson = db.getStudentLessonbyStudentId(id);
                return StudentLesson;

            }
            catch (Exception)
            {

                throw;
            }


        }


        




    }
}
