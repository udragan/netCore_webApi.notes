using com.udragan.netCore.webApi.Notes.DAL.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace com.udragan.netCore.webApi.Notes.DAL.UnitOfWork
{
	/// <summary>
	/// UnitOfWork implementation.
	/// </summary>
	/// <seealso cref="com.udragan.netCore.webApi.Notes.DAL.UnitOfWork.Interfaces.IUnitOfWork" />
	class UnitOfWork : IUnitOfWork
	{
		#region Fields

		/// <summary>
		/// Gets the context.
		/// </summary>
		public DbContext Context { get; }

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="UnitOfWork"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public UnitOfWork(DbContext context)
		{
			Context = context;
		}

		#endregion

		#region IUnitOfWork

		/// <summary>
		/// Commits the changes to the context.
		/// </summary>
		public void Commit()
		{
			Context.SaveChangesAsync();
		}

		#endregion

		#region IDisposable

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Context.Dispose();
		}

		#endregion
	}
}
