using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1.Pages.Schedule
{
    public class JoinStudentsModel : PageModel
    {

        [BindProperty]
        public OfficeHours OfficeHourView { get; set; }



        public JoinStudentsModel()
        {

            OfficeHourView = new OfficeHours();

        }



        public void OnGet(int officehourid)
        {
            SqlDataReader singleProduct = DBClass.SingleOfficeReader(officehourid);

            while (singleProduct.Read())
            {
                OfficeHourView.OfficeHourID = officehourid;
                OfficeHourView.StudentName = singleProduct["studentName"].ToString();
            }
            DBClass.Lab3DBConnection.Close();


        }

        public IActionResult OnPost()
        {
            DBClass.UpdateOfficeHours(OfficeHourView);

            DBClass.Lab3DBConnection.Close();

            return Redirect("/Schedule/ChooseFaculty");
        }

    }
}