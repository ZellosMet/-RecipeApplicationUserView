using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeApplication.Data;
using RecipeApplication.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApplication.Pages
{
    public class UsersListModel : PageModel
    {

        private readonly UserManager<IdentityUser> userManager;

        public UsersListModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [BindProperty]
        public IList<UserRolesViewModel> model { get; set; } = new List<UserRolesViewModel>();

        public class UserRolesViewModel
        {
            public string UserName { get; set; }
            public string Email { get; set; }
        }

        public IActionResult OnGet()
        {
            List<IdentityUser> users = userManager.Users.ToList();

            foreach (IdentityUser user in users)
            {
                UserRolesViewModel urv = new UserRolesViewModel()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                };

                model.Add(urv);
            }
            return Page();
        }
        public IActionResult OnPostDeleteUser(string user_name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User? user = db.Users.FirstOrDefault(x => x.Id == user_name);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
            return Page();
        }

    }
}
