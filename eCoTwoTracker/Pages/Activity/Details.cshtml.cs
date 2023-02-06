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
using System.Xml.Linq;

namespace eCoTwoTracker.Pages.Activity
{
	[IgnoreAntiforgeryToken]
	public class DetailsModel : PageModel
	{
		private readonly IActivityService _activityService;

		public DetailsModel(IActivityService activityService)
		{
			_activityService = activityService;
		}

		public Models.Activity? Activity { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			Activity = await _activityService.GetActivityDetails(id);
			return Page();
		}

		public async Task<IActionResult> OnPostUpdatePerformedStatusAsync([FromBody] Request request)
		{
			await _activityService.UpdatePerformedStatus(request.Id);

			return new JsonResult("Status" + true);
		}
	}
}
