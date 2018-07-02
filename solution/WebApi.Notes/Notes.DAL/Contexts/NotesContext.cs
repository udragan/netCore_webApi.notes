using com.udragan.netCore.webApi.Notes.Model.DbModels;
using Microsoft.EntityFrameworkCore;

namespace com.udragan.netCore.webApi.Notes.DAL.Contexts
{
	/// <summary>
	/// Database context for Notes and Users.
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
	public class NotesContext : DbContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NotesContext"/> class.
		/// </summary>
		/// <param name="options">The options.</param>
		public NotesContext(DbContextOptions<NotesContext> options)
			: base(options)
		{ }

		/// <summary>
		/// Gets or sets the users in the context.
		/// </summary>
		public DbSet<User> Users { get; set; }

		/// <summary>
		/// Gets or sets the notes in the context.
		/// </summary>
		public DbSet<Note> Notes { get; set; }
	}
}
