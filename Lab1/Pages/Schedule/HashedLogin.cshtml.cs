using DocumentFormat.OpenXml.Math;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace Lab1.Pages.Schedule
{
    public class HashedLoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string PersonType { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string username, string password, string personType)
        {
            if (DBClass.HashedParameterLogin(username, password, personType))
            {
                HttpContext.Session.SetString("username", username);
                HttpContext.Session.SetString("personType", personType);

                SqlDataReader tempReader = null;

                if (personType == "Faculty")
                {
                    tempReader = DBClass.SelectFaculty(username);
                }
                else if (personType == "Student")
                {
                    tempReader = DBClass.SelectStudent(username);
                }

                while (tempReader.Read())
                {
                    // Get the user's ID from the database


                    // Check the user's ID and redirect accordingly
                    if (personType == "Faculty")
                    {
                        int facultyID = (int)tempReader["FacultyID"];
                        DBClass.Lab3DBConnection.Close();
                        return RedirectToPage("/Schedule/FacultyOfficeHour", new { facultyid = facultyID });
                    }
                    else if (personType == "Student")
                    {
                        DBClass.Lab3DBConnection.Close();
                        return RedirectToPage("/Schedule/ChooseFaculty");
                    }
                }

                tempReader.Close();
                DBClass.Lab3DBConnection.Close();
            }
            else
            {
                ViewData["LoginMessage"] = "Username, password, or selected type is incorrect.";
                DBClass.Lab3DBConnection.Close();
                return Page();
            }

            // Default redirect
            return RedirectToPage("/Index");

            
            
        }

        //Used to populate valid information in the login boxes
        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            Username = "pruta";
            ModelState.Clear();
            Password = "pruta";



            return Page();
        }
    }
}

      

            





       

