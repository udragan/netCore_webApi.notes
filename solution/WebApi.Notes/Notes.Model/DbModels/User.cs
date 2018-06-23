using System.Collections.Generic;

namespace com.udragan.netCore.webApi.Notes.Model.DbModels
{
	public class User
	{
		public long Id { get; set; }

		public string Name { get; set; }
		public IList<Note> Notes { get; set; }
	}
}
