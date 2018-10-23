using System.Collections.Generic;
using System.Linq;
using com.udragan.netCore.webApi.Notes.Domain.Interfaces;
using com.udragan.netCore.webApi.Notes.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace com.udragan.netCore.webApi.Notes.Controllers
{
	[Route("api/[controller]")]
	public class NotesController : Controller
	{
		#region Members

		private readonly INotesAppUnitOfWork _notesUnitOfWork;

		#endregion

		#region Constructors

		public NotesController(INotesAppUnitOfWork notesUnitOfWork)
		{
			_notesUnitOfWork = notesUnitOfWork;
		}

		#endregion

		// GET api/notes
		[HttpGet]
		public List<Note> Get()
		{
			var result = _notesUnitOfWork.Notes.GetAll();

			return result.ToList();
		}

		// GET api/notes/5
		[HttpGet("{id}")]
		public Note Get(int id)
		{
			return _notesUnitOfWork.Notes.Get(id);
		}

		// POST api/notes
		[HttpPost]
		public void Post([FromBody]Note value)
		{
			_notesUnitOfWork.Notes.Add(value);
			_notesUnitOfWork.Commit();
		}

		// PUT api/notes/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody]Note value)
		{
			Note entity = Get(id);

			if (entity == null)
			{
				return NotFound();
			}

			entity.Update(value);

			_notesUnitOfWork.Commit();

			return NoContent();
		}

		// DELETE api/notes/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			Note entity = Get(id);
			_notesUnitOfWork.Notes.Remove(entity);

			return Ok();
		}
	}
}
