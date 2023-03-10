using eCoTwoTracker.Data;
using eCoTwoTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace eCoTwoTracker.Services
{
	public class ActivityService : IActivityService
	{
		private readonly eCoTwoTracker.Data.ApplicationDbContext _context;

		public ActivityService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task AddActivity(Activity activity)
		{
			_context.Activities.Add(activity);
			await _context.SaveChangesAsync();
		}

		public async Task EditActivity(Activity activity)
		{
			_context.Attach(activity).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ActivityExists(activity.Id))
				{
					
				}
				else
				{
					throw;
				}
			}
		}

		private bool ActivityExists(int id)
		{
			return _context.Activities.Any(e => e.Id == id);
		}

		public async Task<List<Activity>> GetActivitiesAsync()
		{
			if (_context.Activities != null)
			{
				return await _context.Activities.ToListAsync();
			}

			return new List<Activity>() { };
		}

		public async Task<Activity> GetActivityDetails(int? id)
		{
			if (id == null || _context.Activities == null)
			{
				return new Activity();
			}

			var activity = await _context.Activities.FirstOrDefaultAsync(m => m.Id == id);
			if (activity == null)
			{
				return new Activity();
			}
			else
			{
				return activity;
			}
		}

		public async Task DeleteActivity(int? id)
		{
			if (id == null || _context.Activities == null)
			{
				
			}
			var activity = await _context.Activities.FindAsync(id);

			if (activity != null)
			{
				
				_context.Activities.Remove(activity);
				await _context.SaveChangesAsync();
			}
		}

		public async Task UpdatePerformedStatus(int id)
		{
			var act =  await _context.Activities.Where(a => a.Id == id).FirstOrDefaultAsync();
			act.IsPerformed = true;
			_context.SaveChanges();
		}

		public async Task<string> GetActivitiesSummery()
		{
			var activities = await _context.Activities.Where(a => a.IsPerformed).ToListAsync();
			var water = activities.FindAll(s => s.Category == Category.Water).Sum(w => w.Units);
			var food = activities.FindAll(s => s.Category == Category.Food).Sum(w => w.Units);
			var elec = activities.FindAll(s => s.Category == Category.Electricity).Sum(w => w.Units);
			return water + "," + food + "," + elec;
		}
	}
}
