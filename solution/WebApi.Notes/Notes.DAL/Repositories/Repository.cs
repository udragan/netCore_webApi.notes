using System;
using System.Linq;
using System.Threading.Tasks;
using com.udragan.netCore.webApi.Notes.DAL.Repositories.Interfaces;
using com.udragan.netCore.webApi.Notes.DAL.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace com.udragan.netCore.webApi.Notes.DAL.Repositories
{
	/// <summary>
	/// Generic repository implementation.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <seealso cref="com.udragan.netCore.webApi.Notes.DAL.Repositories.Interfaces.IRepository{TEntity}" />
	public class Repository<TEntity> : IRepository<TEntity>
		where TEntity : class
	{
		#region Fields

		private readonly IUnitOfWork _unitOfWork;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
		/// </summary>
		/// <param name="unitOfWork">The unit of work.</param>
		public Repository(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		#endregion

		#region IRepository

		/// <summary>
		/// Gets all entities.
		/// </summary>
		/// <returns>
		/// An IQueryable of all available entities in the repository.
		/// </returns>
		public IQueryable<TEntity> GetAll()
		{
			return _unitOfWork.Context.Set<TEntity>().AsNoTracking();
		}

		/// <summary>
		/// Gets the entity by its identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>
		/// The entity with provided identifier.
		/// </returns>
		public Task<TEntity> GetById(long id)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Creates the specified entity in the repository.
		/// </summary>
		/// <param name="entity">The entity to create.</param>
		public async Task Create(TEntity entity)
		{
			await _unitOfWork.Context.Set<TEntity>().AddAsync(entity);
			await _unitOfWork.Context.SaveChangesAsync();
		}

		/// <summary>
		/// Removes the entity by specified id.
		/// </summary>
		/// <param name="id">The identifier.</param>
		public Task Remove(long id)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Updates the specified entity by its identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="entity">The entity to update.</param>
		public Task Update(long id, TEntity entity)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
