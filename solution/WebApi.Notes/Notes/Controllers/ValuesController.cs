using System.Collections.Generic;
using com.udragan.netCore.webApi.Notes.DAL.Contexts;
using com.udragan.netCore.webApi.Notes.Model.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace com.udragan.netCore.webApi.Notes.Controllers
{
	[Route("api/[controller]")]
	public class ValuesController : Controller
	{
		#region Members

		private readonly NotesContext _context;

		#endregion

		#region Constructors

		public ValuesController(NotesContext context)
		{
			_context = context;
		}

		#endregion

		// GET api/values
		[HttpGet]
		public IEnumerable<User> Get()
		{
			var result = _context.Users.Include(x => x.Notes);

			return result;
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody]string value)
		{
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
