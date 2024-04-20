using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Todo_list_Refractor_App.Models
{
	public class TodolistApp
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public  String Name  { get; set; }
		[DisplayName("Table Ready")]
		public bool TableReady { get; set; } = false;

		public String? Description { get; set; }
	}
}
