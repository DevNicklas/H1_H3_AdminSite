using AdminSite.DataAccess;
using AdminSite.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace AdminSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private string _username;
        private string _password;
        private string _error;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

		[BindProperty]
		public string Username
		{
			get { return _username; }
			set { _username = value; }
		}

		[BindProperty]
		public string Password
		{
			get { return _password; }
		    set { _password = value; }
		}

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

		public void OnGet()
        {

        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                DatabaseAction dbAction = new DatabaseAction(UtilityConstants.CONNECTION_STRING);
                try
                {
                    CurrentUser currentUser = new CurrentUser(dbAction, Username, Password);
                    Error = "";
                    Debug.WriteLine("Correct login, access granted");
                    return RedirectToPage("/Main");
                }
                catch
                {
                    Debug.WriteLine("Wrong login");
                    Error = "Please try again";
                    return Page();
                }
            }
            Error = "Please try again";
            return Page();
        }
    }
}