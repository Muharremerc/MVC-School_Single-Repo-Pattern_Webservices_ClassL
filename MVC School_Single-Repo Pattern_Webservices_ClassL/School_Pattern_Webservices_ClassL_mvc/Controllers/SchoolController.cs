using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Model;

namespace School_Pattern_Webservices_ClassL_mvc.Controllers
{
    public class SchoolController : Controller
    {
        // GET: School
        public ActionResult Index()
        {

            try
            {
                using (var SC = new DAL.Model.MVC_Sc())
                {
                    Models.SchoolModel SM = new Models.SchoolModel();
                    
                    Ws.WebService1 ws = new Ws.WebService1();

                    var DB = DAL.SchoolDB.getInstance();

                    var studentListWs = ws.getAllStudent();
                    List<Models.Student> S = new List<Models.Student>();

                    foreach (var item in studentListWs)
                    {
                        S.Add(new Models.Student
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Surname=item.Surname
                     });
                    }
                    SM.St = S;


                    var Lesson = DB.getAllLesson();
                    List<Models.Lesson> L = new List<Models.Lesson>();
                    foreach (var item in Lesson)
                    {
                        L.Add
                            (new Models.Lesson
                            {
                                Id=item.Id,
                                Name=item.LessonName

                        });

                    }
                    SM.Ls = L;

                    var Class = DB.getAllClass();
                    List<Models.Class> C = new List<Models.Class>();
                    foreach (var item in Class)
                    {
                        C.Add(new Models.Class
                        {
                        Id=item.Id,
                        Name=item.Name
                        }
                        );
                    }

                    SM.C = C;



                    var Teacher = DB.getAllTeacher();
                    List<Models.Teacher> t = new List<Models.Teacher>();
                    foreach (var item in Teacher)
                    {
                        t.Add(new Models.Teacher
                        {Id=item.Id,
                        Name=item.Name}
                        );
                    }
              
                    
                    SM.Tc = t;

                    return View(SM);
                }
                            
                
                
            }
            catch (Exception)
            {

                throw;
            }


           
        }

        public ActionResult StudentLessons(int id)
        {

            try
            {
                Ws.WebService1 ws = new Ws.WebService1();
                var studentLesson = ws.getStudentLessonsbyId(id);
                return PartialView("_StudentLessons", studentLesson);
            }
            catch (Exception ex)
            {

                throw;
            }


        }


        public ActionResult TeacherLessons(int id)
        {

            try
            {
                var DB = DAL.SchoolDB.getInstance();
                var TeacherLesson = DB.getTeacherLesson(id);
                return PartialView("_TeacherLesson", TeacherLesson);
            }
            catch (Exception ex)
            {

                throw;
            }


        }


        public ActionResult LessonsTeacher(int id)
        {

            try
            {
                var DB = DAL.SchoolDB.getInstance();
                var LessonTeacher = DB.getLessonTeacher(id);
                return PartialView("_LessonTeacher", LessonTeacher);
            }
            catch (Exception ex)
            {

                throw;
            }


        }


        public ActionResult ClassStudent(int id)
        {

            try
            {
                var DB = DAL.SchoolDB.getInstance();
                var ClassStudent = DB.ClassStudent(id);
                return PartialView("_ClassStudent", ClassStudent);
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public ActionResult TStudent(int id)
        {

            try
            {
                var DB = DAL.SchoolDB.getInstance();
                var ClassStudent = DB.ClassStudent(id);
                return PartialView("_Ttudent", ClassStudent);
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public JsonResult CreateStudent(string name,string surname,string clas)
        {

            try
            {
                var DB = DAL.SchoolDB.getInstance();
                var ClassStudent = DB.CreateStudent(name,surname,clas);
                return Json(ClassStudent);
            }
            catch (Exception ex)
            {

                throw;
            }

            
        }
        public JsonResult AddLesson(string lname)
        {

            try
            {
                var DB = DAL.SchoolDB.getInstance();
                var Lesson = DB.CreateLesson(lname);
                return Json(Lesson);
            }
            catch (Exception ex)
            {

                throw;
            }

            
        }

        public JsonResult AddClass(string cname)
        {

            try
            {
                var DB = DAL.SchoolDB.getInstance();
                var Class = DB.CreateClass(cname);
                return Json(Class);
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public JsonResult AddTeacher(string tname)
        {

            try
            {
                var DB = DAL.SchoolDB.getInstance();
                var Teacher = DB.CreateTeacher(tname);
                return Json(Teacher);
            }
            catch (Exception ex)
            {

                throw;
            }
          

        }
        public JsonResult addStudentLessons(int name, int lname)
        {
            var DB = DAL.SchoolDB.getInstance();
            bool StudentLessons = DB.addStudentLessons(name, lname);
            if(StudentLessons == true)
            {

                return Json("true");
            }

            return Json("false");
        }
        public JsonResult addTeacherLessons(int tname, int lname)
        {
            var DB = DAL.SchoolDB.getInstance();
            bool StudentLessons = DB.addTeacherLessons(tname, lname);
            if (StudentLessons == true)
            {

                return Json("true");
            }

            return Json("false");
        }
        
        public JsonResult addTeacherClass(int tname, int cname)
        {
            var DB = DAL.SchoolDB.getInstance();
            bool TeacherClass = DB.addTeacherClass(tname, cname);
            if (TeacherClass == true)
            {

                return Json("true");
            }

            return Json("false");
        }
    }
}