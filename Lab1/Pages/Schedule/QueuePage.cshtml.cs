using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using System.Data.SqlClient;
using Queue = Lab1.Pages.DataClasses.Queue;

namespace Lab1.Pages.Schedule
{
    public class QueuePageModel : PageModel
    {
       

            public List<Queue> QueueList { get; set; }

            public List<Faculty> FacultyList { get; set; }

            public List<Student> StudentList { get; set; }

            public void OnGet(int studentID)
            {
                SqlDataReader SingleReader = DBClass.SingleReader();
                while (SingleReader.Read())
                {
                    int currentStudentID = studentID;
                    if (currentStudentID == studentID)
                    {
                        QueueList.Add(new Queue
                        {
                            QueueID = int.Parse(SingleReader["queueID"].ToString()),
                            QueueOrder = int.Parse(SingleReader["queueOrder"].ToString()),
                            StudentID = currentStudentID,
                            FacultyID = int.Parse(SingleReader["facultyID"].ToString()),

                        });
                    }
                }
                DBClass.Lab3DBConnection.Close();
            }

        }
    }


