using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using com.udragan.netCore.webApi.Notes.Common.Shared;
using com.udragan.netCore.webApi.Notes.Domain.Interfaces;
using com.udragan.netCore.webApi.Notes.Domain.Models;
using com.udragan.netCore.webApi.Notes.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace com.udragan.netCore.webApi.Notes.Infrastructure.Repositories
{
	/// <summary>
	/// Implementation of INoteRepository.
	/// </summary>
	/// <seealso cref="com.udragan.netCore.webApi.Notes.Domain.Interfaces.INoteRepository" />
	public class NoteRepository : INoteRepository
	{
		#region Members

		private NotesContext _context;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="NoteRepository" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public NoteRepository(NotesContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		#endregion

		#region IRepository

		/// <summary>
		/// Gets the unit of work.
		/// </summary>
		public IUnitOfWork UnitOfWork => _context;

		/// <summary>
		/// Adds the specified Note entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public void Add(Note entity)
		{
			_context.Notes.Add(entity);
		}

		/// <summary>
		/// Finds all notes that satisfy specified predicate.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>A collection of notes that satisfy the predicate.</returns>
		public IEnumerable<Note> Find(Expression<Func<Note, bool>> predicate)
		{
			return _context.Notes
				.Where(predicate);
		}

		/// <summary>
		/// Gets the note by specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>The note that matches provided id if exists, otherwise null.</returns>
		public Note Get(long id)
		{
			return _context.Notes.Find(id);
		}

		/// <summary>
		/// Gets all existing notes in the context.
		/// </summary>
		/// <returns>A collection of all available notes.</returns>
		public IEnumerable<Note> GetAll()
		{
			return _context.Notes.AsNoTracking();
		}

		/// <summary>
		/// Removes the specified Note entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public void Remove(Note entity)
		{
			_context.Notes.Remove(entity);
		}

		#endregion
	}
}
