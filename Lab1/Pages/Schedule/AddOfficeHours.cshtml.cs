using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1.Pages.Schedule
{
    public class AddOfficeHoursModel : PageModel
    {
        [BindProperty]
        public OfficeHours NewOfficeHours { get; set; }




        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Call the InsertOffice method to update the data
            DBClass.InsertOffice(NewOfficeHours.OfficeNumber, NewOfficeHours.Date, NewOfficeHours.Time, NewOfficeHours.FacultyID);

            // Close the database connection
            DBClass.Lab3DBConnection.Close();

            // Redirect to the appropriate page based on the faculty ID in the URL
            return RedirectToPage("/Schedule/FacultyOfficeHour", new { facultyID = NewOfficeHours.FacultyID });
        }
    }
}


