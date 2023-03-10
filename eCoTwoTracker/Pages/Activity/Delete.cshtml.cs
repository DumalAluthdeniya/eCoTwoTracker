using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using eCoTwoTracker.Data;
using eCoTwoTracker.Models;
using eCoTwoTracker.Services;

namespace eCoTwoTracker.Pages.Activity
{
	public class DeleteModel : PageModel
	{
		private readonly IActivityService _activityService;

		public DeleteModel(IActivityService activityService)
		{
			_activityService = activityService;
		}

		[BindProperty]
		public Models.Activity Activity { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			Activity = await _activityService.GetActivityDetails(id);
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			await _activityService.DeleteActivity(id);

			return RedirectToPage("./Index");
		}
	}
}
