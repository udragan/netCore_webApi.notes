using com.udragan.netCore.webApi.Notes.Common.Shared;

namespace com.udragan.netCore.webApi.Notes.Domain.Interfaces
{
	/// <summary>
	/// Notes application unit of work interface.
	/// </summary>
	/// <seealso cref="com.udragan.netCore.webApi.Notes.Common.Shared.IUnitOfWork" />
	public interface INotesAppUnitOfWork : IUnitOfWork
	{
		/// <summary>
		/// Gets the note repository.
		/// </summary>
		INoteRepository Notes { get; }

		/// <summary>
		/// Gets the user repository..
		/// </summary>
		IUserRepository Users { get; }
	}
}
