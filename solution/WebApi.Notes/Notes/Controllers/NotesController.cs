﻿using System.Collections.Generic;
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

		// GET api/notes/5
		[HttpGet("{id}")]
		public async Task<Note> Get(int id)
		{
			return await _notesRepository.GetById(id);
		}

		// POST api/notes
		[HttpPost]
		public void Post([FromBody]Note value)
		{
			_notesRepository.Create(value);
		}

		// PUT api/notes/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/notes/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}