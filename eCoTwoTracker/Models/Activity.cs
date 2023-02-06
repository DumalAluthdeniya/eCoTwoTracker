using System.ComponentModel.DataAnnotations;

namespace eCoTwoTracker.Models
{
	public class Activity
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public decimal Units { get; set; }
		public Category Category { get; set; }
		public bool IsPerformed { get; set; }
	}
}
