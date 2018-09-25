using com.udragan.netCore.webApi.Notes.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace com.udragan.netCore.webApi.Notes.Infrastructure.Contexts
{
	/// <summary>
	/// Notes unit of work.
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
	public class NotesContext : DbContext
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="NotesContext"/> class.
		/// </summary>
		/// <param name="options">The options.</param>
		public NotesContext(DbContextOptions<NotesContext> options)
			: base(options)
		{ }

		#endregion

		/// <summary>
		/// Gets or sets the users DbSet.
		/// </summary>
		public DbSet<User> Users { get; set; }

		/// <summary>
		/// Gets or sets the notes DbSet.
		/// </summary>
		public DbSet<Note> Notes { get; set; }
	}
}
