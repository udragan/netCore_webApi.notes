using System;
using com.udragan.netCore.webApi.Notes.Domain.Interfaces;
using com.udragan.netCore.webApi.Notes.Infrastructure.Contexts;

namespace com.udragan.netCore.webApi.Notes.Infrastructure.UnitOfWork
{
	/// <summary>
	/// Implementation of Notes application unit of work.
	/// </summary>
	/// <seealso cref="com.udragan.netCore.webApi.Notes.Domain.Interfaces.INotesAppUnitOfWork" />
	public class NotesAppUnitOfWork : INotesAppUnitOfWork
	{
		#region Members

		private NotesContext _context;

		#endregion

		#region MyRegion

		/// <summary>
		/// Initializes a new instance of the <see cref="NotesAppUnitOfWork" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="noteRepository">The note repository.</param>
		/// <param name="userRepository">The user repository.</param>
		public NotesAppUnitOfWork(
					NotesContext context,
					INoteRepository noteRepository,
					IUserRepository userRepository)
		{
			_context = context;

			//TODO: should repositories be injected or instantiated ?!
			Notes = noteRepository ?? throw new ArgumentNullException(nameof(noteRepository));
			Users = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
		}

		#endregion

		#region INotesUnitOfWork

		/// <summary>
		/// Gets the note repository.
		/// </summary>
		public INoteRepository Notes { get; private set; }

		/// <summary>
		/// Gets the user repository.
		/// </summary>
		public IUserRepository Users { get; private set; }

		/// <summary>
		/// Commits all tracked changes to the context.
		/// </summary>
		public void Commit()
		{
			_context.SaveChanges();
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		public void Dispose()
		{
			_context.Dispose();
		}

		#endregion
	}
}
