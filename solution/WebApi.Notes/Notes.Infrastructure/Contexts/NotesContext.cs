using com.udragan.netCore.webApi.Notes.Common.Shared;
using com.udragan.netCore.webApi.Notes.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace com.udragan.netCore.webApi.Notes.Infrastructure.Contexts
{
	/// <summary>
	/// Notes unit of work.
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
	/// <seealso cref="com.udragan.netCore.webApi.Notes.Common.Shared.IUnitOfWork" />
	public class NotesContext : DbContext, IUnitOfWork
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

		#region IUnitOfWork

		/// <summary>
		/// Commits all tracked changes to the context.
		/// </summary>
		public void Commit()
		{
			SaveChanges();
		}

		#endregion

		#region IDisposable
		// DbContext itself implements IDisposable
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
