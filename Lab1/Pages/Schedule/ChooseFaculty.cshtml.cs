using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Lab1.Pages.Schedule
{
    public class ChooseFacultyModel : PageModel
    {

        [BindProperty]
        [Required]
        public string SelectMessage { get; set; }

        [BindProperty]
        [Required]
        public string SelectedTeacher { get; set; }

        public List<OfficeHours> OfficeHours { get; set; }

        public List<Faculty> FacultyList { get; set; }


        //Declaring OfficeHour and Faculty 
        public ChooseFacultyModel()
        {

            OfficeHours = new List<OfficeHours>();
            FacultyList = new List<Faculty>();
        }


        //OnGet to retrieve faculty first and last names for dropdown menu
        public void OnGet()
        {
            SqlDataReader facultyReader = DBClass.FacultyReader();

            while (facultyReader.Read())
            {
                FacultyList.Add(new Faculty
                {
                    FirstName = facultyReader["fName"].ToString(),
                    LastName = facultyReader["lName"].ToString(),
                    FacultyID = Int32.Parse(facultyReader["facultyID"].ToString())

                });

            }
            DBClass.Lab3DBConnection.Close();



        }

        public IActionResult OnPostSingleSelect(int facultyID)
        {
            return RedirectToPage("OfficeHourPage", new { facultyID = SelectedTeacher });
        }

    }





}



