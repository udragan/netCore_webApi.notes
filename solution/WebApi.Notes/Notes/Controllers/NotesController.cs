using System.Collections.Generic;
using System.Threading.Tasks;
using com.udragan.netCore.webApi.Notes.DAL.Repositories.Interfaces;
using com.udragan.netCore.webApi.Notes.Model.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace com.udragan.netCore.webApi.Notes.Controllers
{
	[Route("api/[controller]")]
	public class NotesController : Controller
	{
		#region Members

		private readonly INotesRepository _notesRepository;

		#endregion

		#region Constructors

		public NotesController(INotesRepository notesRepository)
		{
			_notesRepository = notesRepository;
		}

		#endregion

		// GET api/notes
		[HttpGet]
		public async Task<List<Note>> Get()
		{
			var result = _notesRepository.GetAll();

			return await result.ToListAsync();
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody]Note value)
		{
			//_context.Notes.Add(value);
			//_context.SaveChanges();
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
