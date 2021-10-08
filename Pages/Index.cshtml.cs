using IdentityFarmActivities.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// This defines the activity futures that are displayed in Index.html 
/// </summary>

namespace IdentityFarmActivities.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private ApplicationDbContext Context;
        public IndexModel(ApplicationDbContext ctx)
        {
            Context = ctx;
        }
        [BindProperty(SupportsGet = true)]
        public bool ShowComplete { get; set; }
        public IEnumerable<Activity> Activities { get; set; }
        public void OnGet()
        {
            Activities = Context.Activities
                .Where(t => t.Owner == User.Identity.Name).OrderBy(t => t.Task);
            if (!ShowComplete)
            {
                Activities = Activities.Where(t => !t.Complete);
            }
            Activities = Activities.ToList();
        }
        public IActionResult OnPostShowComplete()
        {
            return RedirectToPage(new { ShowComplete });
        }
        public async Task<IActionResult> OnPostAddActivityAsync(string task)
        {
            if (!string.IsNullOrEmpty(task))
            {
                Activity activity = new()
                {
                    Task = task,
                    Owner = User.Identity.Name,
                    Complete = false
                };
                await Context.AddAsync(activity);
                await Context.SaveChangesAsync();
            }
            return RedirectToPage(new { ShowComplete });
        }
        public async Task<IActionResult> OnPostMarkActivityAsync(long id)
        {
            Activity activity = Context.Activities.Find(id);
            if (activity != null)
            {
                activity.Complete = !activity.Complete;
                await Context.SaveChangesAsync();
            }
            return RedirectToPage(new { ShowComplete });
        }
    }
}
