using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data.SqlClient;

namespace Lab1.Pages.Schedule
{
    public class StudentQueueModel : PageModel
    {

        public List<Student> Queue { get; set; }

        public StudentQueueModel()
        {
            Queue = new List<Student>();
        }

        //Used to read the student data from sql and put into table 
        public void OnGet()
        {
            SqlDataReader StudentReader = DBClass.StudentReader();

            while (StudentReader.Read())
            {
                Queue.Add(new Student
                {
                    StudentID = Int32.Parse(StudentReader["studentID"].ToString()),
                    FirstName = StudentReader["fName"].ToString(),
                    LastName = StudentReader["lName"].ToString(),
                    StuEmail = StudentReader["studentEmail"].ToString(),
                    
                }) ;
            }
            //close our remote connection
            DBClass.Lab3DBConnection.Close();
        }

    }
}
    


