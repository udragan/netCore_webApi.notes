using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using com.udragan.netCore.webApi.Notes.Domain.Interfaces;
using com.udragan.netCore.webApi.Notes.Domain.Models;
using com.udragan.netCore.webApi.Notes.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace com.udragan.netCore.webApi.Notes.Infrastructure.Repositories
{
	/// <summary>
	/// Implementation of IUserRepository.
	/// </summary>
	/// <seealso cref="com.udragan.netCore.webApi.Notes.Domain.Interfaces.IUserRepository" />
	public class UserRepository : IUserRepository
	{
		#region Members

		private NotesContext _context;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="UserRepository" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public UserRepository(NotesContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		#endregion

		#region IRepository

		/// <summary>
		/// Adds the specified User entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public void Add(User entity)
		{
			_context.Users.Add(entity);
		}

		/// <summary>
		/// Finds all users that satisfy the specified predicate.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>A collection of users that satisfy the predicate.</returns>
		public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
		{
			return _context.Users
				.Where(predicate);
		}

		/// <summary>
		/// Gets the user by specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>The user that matches provided id if exists, otherwise null.</returns>
		public User Get(long id)
		{
			User result = _context.Users
				.Where(x => x.Id == id)
				.FirstOrDefault();

			return result;
		}

		/// <summary>
		/// Gets all existing users in the context.
		/// </summary>
		/// <returns>A collection of all available users.</returns>
		public IEnumerable<User> GetAll()
		{
			return _context.Users.AsNoTracking();
		}

		/// <summary>
		/// Removes the specified user entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public void Remove(User entity)
		{
			_context.Users.Remove(entity);
		}

		#endregion
	}
}
