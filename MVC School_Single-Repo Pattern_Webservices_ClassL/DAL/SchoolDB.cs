using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL
{

    public class SchoolDB
    {

        private static SchoolDB instance = null;

        private SchoolDB()
        { }

        public static SchoolDB getInstance()
        {
            if (instance == null)
            {
                instance = new SchoolDB();
                return instance;
            }
            else
            {
                return instance;
            }


        }

        public List<Student> getAllStudent()
        {

            using (var SC = new DAL.Model.MVC_Sc())
            {

                var studentList = SC.Students.ToList();
                return studentList;

            }

        }

        public Student getStudentbyId(int id)
        {

            using (var SC = new DAL.Model.MVC_Sc())
            {
                var student = SC.Students.FirstOrDefault(x => x.Id == id);
                return student;
            }


        }


        public List<Student> getStudentLessonbyStudentId(int id)
        {
            using (var SC = new DAL.Model.MVC_Sc())
            {

                var stLesson = SC.Students.Include("StudentLessons").Include("StudentLessons.Lesson").Where(x => x.Id == id).ToList(); 
                return stLesson;

            }

        }

        public List<Lesson> getAllLesson()
        {
            using (var SC = new DAL.Model.MVC_Sc())
            {
                var lesson = SC.Lessons.ToList();
                return lesson;
                     
            }

        }
        public List<Class> getAllClass()
        {
            using (var SC = new DAL.Model.MVC_Sc())
            {
                var clas = SC.Classes.ToList();
                return clas;

            }

        }
        public List<Teacher> getAllTeacher()
        {
            using (var SC = new DAL.Model.MVC_Sc())
            {
                var teacher = SC.Teachers.ToList();
                return teacher;

            }

        }


        public List<Teacher> getTeacherLesson(int id)
        {

            using (var SC = new DAL.Model.MVC_Sc())
            {
                var Lessonteacher = SC.Teachers.Include("TeacherLessons").Include("TeacherLessons.Lesson").Where(z => z.Id == id).ToList();
                return Lessonteacher;

            }

        }

        public List<Lesson> getLessonTeacher(int id)
        {

            using (var SC = new DAL.Model.MVC_Sc())
            {
                var Lessonteacher = SC.Lessons.Include("TeacherLessons").Include("TeacherLessons.Teacher").Where(x=>x.Id==id).ToList();
                   
                return Lessonteacher;

            }

        }

        public List<Class> ClassStudent(int id)
        {

            using (var SC = new DAL.Model.MVC_Sc())
            {
                var ClassStudent = SC.Classes.Include("StudentClasses").Include("StudentClasses.Student").Where(x => x.Id == id).ToList();
                
                return ClassStudent;

            }

        }

        public Student addStudent(string name, string surname)
        {
            using (var SC = new DAL.Model.MVC_Sc())
            {
                Student S = new Student();
                S.Name = name;
                S.Surname = surname;
                S=SC.Students.Add(S);
                SC.SaveChanges();
                return S;
            }

        }

        public bool CreateStudent(string name, string surname, string clas)
        {

            using (var SC = new DAL.Model.MVC_Sc())
            {
                Student S = new Student();
                S = addStudent(name,surname);
                var C = SC.Classes.Where(z => z.Name == clas).FirstOrDefault();
                StudentClass SClas = new StudentClass();
                SClas.ClassId = C.Id;
                SClas.StudentId = S.Id;
                SC.StudentClasses.Add(SClas);
                SC.SaveChanges();
                return true;

            }
            
        }

        public bool CreateLesson(string lname)
        {

            using (var SC = new DAL.Model.MVC_Sc())
            {
                Lesson S = new Lesson();
                S.LessonName = lname;
                SC.Lessons.Add(S);
                SC.SaveChanges();
                return true;

            }
        }
        
       public bool CreateClass(string cname)
        {

            using (var SC = new DAL.Model.MVC_Sc())
            {
                Class C = new Class();
                C.Name = cname;
                SC.Classes.Add(C);
                SC.SaveChanges();
                return true;

            }
        }

        public bool CreateTeacher(string tname)
        {

            using (var SC = new DAL.Model.MVC_Sc())
            {

                Teacher T = new Teacher();
                T.Name = tname;
                SC.Teachers.Add(T);
                SC.SaveChanges();
                return true;

            }
        }

        public bool addStudentLessons(int name,int lname)
        {

            using (var SC = new DAL.Model.MVC_Sc())
            {

                var cek = SC.StudentLessons.Where(x => x.LessonId == lname).Where(x => x.StudentId == name).FirstOrDefault();
                if(cek == null)
                {
                    StudentLesson sl = new StudentLesson();
                    sl.LessonId = lname;
                    sl.StudentId = name;

                    
                        SC.StudentLessons.Add(sl);
                    SC.SaveChanges();
                    return true;
                }

                return false;
            }
        }
        

             public bool addTeacherLessons(int name, int lname)
        {

            using (var SC = new DAL.Model.MVC_Sc())
            {

                var cek = SC.TeacherLessons.Where(x => x.TeacherId == lname).Where(x => x.LessonId == lname).FirstOrDefault();
                if (cek == null)
                {
                    TeacherLesson sl = new TeacherLesson();
                    sl.LessonId = lname;
                    sl.TeacherId = name;


                    SC.TeacherLessons.Add(sl);
                    SC.SaveChanges();
                    return true;
                }

                return false;
            }
        }
        
                  public bool addTeacherClass(int name, int cname)
        {

            using (var SC = new DAL.Model.MVC_Sc())
            {

                var cek = SC.TeacherClasses.Where(x => x.TeacherId == name).Where(x => x.ClassId == cname).FirstOrDefault();
                if (cek == null)
                {
                    TeacherClass tc = new TeacherClass();
                    tc.ClassId = cname;
                    tc.TeacherId = name;


                    SC.TeacherClasses.Add(tc);
                    SC.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }




}
