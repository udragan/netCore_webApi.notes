using com.udragan.netCore.webApi.Notes.Model.DbModels;
using Microsoft.EntityFrameworkCore;

namespace com.udragan.netCore.webApi.Notes.DAL.Contexts
{
	public class NotesContext : DbContext
	{
		public NotesContext(DbContextOptions<NotesContext> options)
			: base(options)
		{ }

		public DbSet<User> Users { get; set; }
		public DbSet<Note> Notes { get; set; }
	}
}
