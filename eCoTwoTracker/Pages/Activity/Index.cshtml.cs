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
	public class IndexModel : PageModel
	{
		private readonly IActivityService _activityService;
		public IndexModel(IActivityService activityService)
		{
			_activityService = activityService;
		}

		public IList<Models.Activity> Activity { get; set; }

		public async Task OnGetAsync()
		{
			Activity = await _activityService.GetActivitiesAsync();
		}

		public async Task<IActionResult> OnGetGetActivitySummeryAsync()
		{			
			return new JsonResult("" + await _activityService.GetActivitiesSummery());
		}
	}
}
