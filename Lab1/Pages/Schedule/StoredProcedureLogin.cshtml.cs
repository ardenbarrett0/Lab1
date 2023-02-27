using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1.Pages.Schedule
{
    public class StoredProcedureLoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {

            if (DBClass.StoredProcedureLogin(Username, Password))
            {
                HttpContext.Session.SetString("username", Username);
                ViewData["LoginMessage"] = "Login Successful!";
                DBClass.Lab3DBConnection.Close();
                return Page();
            }
            else
            {
                ViewData["LoginMessage"] = "Username and/or Password Incorrect";
                DBClass.Lab3DBConnection.Close();
                return Page();
            }

        }
    }
}

