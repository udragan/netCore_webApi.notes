using System.Linq;
using System.Threading.Tasks;

namespace com.udragan.netCore.webApi.Notes.DAL.Repositories.Interfaces
{
	/// <summary>
	/// Generic repository interface.
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	public interface IRepository<TEntity>
		where TEntity : class
	{
		/// <summary>
		/// Gets all entities.
		/// </summary>
		/// <returns>
		/// An IQueryable of all available entities in the repository.
		/// </returns>
		IQueryable<TEntity> GetAll();

		/// <summary>
		/// Gets the entity by its identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>The entity with provided identifier.</returns>
		Task<TEntity> GetById(long id);

		/// <summary>
		/// Creates the specified entity in the repository.
		/// </summary>
		/// <param name="entity">The entity to create.</param>
		Task Create(TEntity entity);

		/// <summary>
		/// Updates the specified entity by its identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="entity">The entity to update.</param>
		Task Update(long id, TEntity entity);

		/// <summary>
		/// Removes the entity by specified id.
		/// </summary>
		/// <param name="id">The identifier.</param>
		Task Remove(long id);
	}
}
