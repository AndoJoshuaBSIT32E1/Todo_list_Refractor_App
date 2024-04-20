using Microsoft.EntityFrameworkCore;
using Todo_list_Refractor_App.Models;

namespace Todo_list_Refractor_App.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
            
        }

        public DbSet <TodolistApp> Todolist { get; set; }
	}
}
