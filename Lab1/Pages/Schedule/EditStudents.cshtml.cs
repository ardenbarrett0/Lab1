using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1.Pages.Schedule
{
    public class EditStudentsModel : PageModel
    {
        [BindProperty]
        public OfficeHours EditView { get; set; }



        public EditStudentsModel()
        {

            EditView = new OfficeHours();

        }



        public void OnGet(int officehourid)
        {
            SqlDataReader singleProduct = DBClass.SingleOfficeReader(officehourid);

            while (singleProduct.Read())
            {
                EditView.OfficeHourID = officehourid;
                EditView.StudentName = singleProduct["studentName"].ToString();
            }
            DBClass.Lab3DBConnection.Close();


        }

        public IActionResult OnPost()
        {
            DBClass.UpdateOfficeHours(EditView);
            DBClass.Lab3DBConnection.Close();

            SqlDataReader tempReader = DBClass.SingleReader();
            int facultyID = 0;

            if (tempReader.Read())
            {
                facultyID = tempReader.GetInt32(tempReader.GetOrdinal("FacultyID"));
            }

            tempReader.Close();
            DBClass.Lab3DBConnection.Close();

            return RedirectToPage("/Schedule/FacultyOfficeHour", new { facultyid = facultyID });
        }
    }
    
}
