using System.Collections.Generic;

namespace com.udragan.netCore.webApi.Notes.Model.DbModels
{
	/// <summary>
	/// POCO class representing the User.
	/// </summary>
	public class User
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the notes by this user.
		/// </summary>
		public IList<Note> Notes { get; set; }
	}
}
