using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Pattern_Webservices_ClassL_mvc.Models
{
    public class SchoolModel
    {

        
            public List<Student> St { get; set; }
            public List<Lesson> Ls { get; set; }
            public List<Teacher> Tc { get; set; }
            public List<Class> C { get; set; }

            
     }
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
        }
        public class Lesson
        {

            public int Id { get; set; }
            public string Name { get; set; }

        }
        public class   Teacher
        {

            public int Id { get; set; }
            public string Name { get; set; }

        }
        public class Class
        { 
        public int Id { get; set; }
        public string Name { get; set; }

        }


    }
