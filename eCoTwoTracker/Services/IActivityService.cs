using eCoTwoTracker.Models;

namespace eCoTwoTracker.Services
{
	public interface IActivityService
	{
		Task AddActivity(Activity activity);
		Task DeleteActivity(int? id);
		Task EditActivity(Activity activity);
		Task<List<Activity>> GetActivitiesAsync();
		Task<string> GetActivitiesSummery();
		Task<Activity> GetActivityDetails(int? id);
		Task UpdatePerformedStatus(int id);
	}
}