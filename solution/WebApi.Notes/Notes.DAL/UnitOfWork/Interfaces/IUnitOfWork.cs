using System;
using Microsoft.EntityFrameworkCore;

namespace com.udragan.netCore.webApi.Notes.DAL.UnitOfWork.Interfaces
{
	/// <summary>
	/// Generic Unit Of Work interface.
	/// </summary>
	/// <seealso cref="System.IDisposable" />
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// Gets the context.
		/// </summary>
		DbContext Context { get; }

		/// <summary>
		/// Commits the changes to the context.
		/// </summary>
		void Commit();
	}
}
