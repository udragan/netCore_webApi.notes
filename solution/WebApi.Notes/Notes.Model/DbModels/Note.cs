using Newtonsoft.Json;

namespace com.udragan.netCore.webApi.Notes.Model.DbModels
{
	/// <summary>
	/// POCO class representing the Note.
	/// </summary>
	public class Note
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Gets or sets the user identifier.
		/// </summary>
		[JsonIgnore]
		public long UserId { get; set; }

		/// <summary>
		/// Gets or sets the user.
		/// </summary>
		[JsonIgnore]
		public User User { get; set; }

		/// <summary>
		/// Gets or sets the note content.
		/// </summary>
		public string Content { get; set; }
	}
}
