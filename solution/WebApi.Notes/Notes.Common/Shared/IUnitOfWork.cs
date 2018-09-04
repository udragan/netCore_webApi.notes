using System;

namespace com.udragan.netCore.webApi.Notes.Common.Shared
{
	/// <summary>
	/// Generic Unit Of Work interface.
	/// </summary>
	/// <seealso cref="System.IDisposable" />
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// Commits the changes to the context.
		/// </summary>
		void Commit();
	}
}
