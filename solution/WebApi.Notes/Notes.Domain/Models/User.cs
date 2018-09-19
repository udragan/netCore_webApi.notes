using System.Collections.Generic;
using com.udragan.netCore.webApi.Notes.Common.Shared;

namespace com.udragan.netCore.webApi.Notes.Domain.Models
{
	/// <summary>
	/// POCO class representing the user.
	/// </summary>
	/// <seealso cref="com.udragan.netCore.webApi.Notes.Common.Shared.Entity" />
	public class User : Entity
	{
		#region Members

		private List<Note> _notes;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="User"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		public User(string name)
		{
			Name = name;
			_notes = new List<Note>();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the user`s name.
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Gets the user`s notes.
		/// </summary>
		public IReadOnlyCollection<Note> Notes => _notes;

		#endregion

		#region Public methods

		/// <summary>
		/// Adds the note.
		/// </summary>
		/// <param name="caption">The note caption.</param>
		/// <param name="text">The note text.</param>
		/// <param name="isChecked">The note state.</param>
		public void AddNote(string caption, string text, bool isChecked)
		{
			Note note = new Note(Id, caption, text, isChecked);

			_notes.Add(note);
		}

		/// <summary>
		/// Remotes the note.
		/// </summary>
		/// <param name="noteId">The note identifier.</param>
		public void RemoteNote(long noteId)
		{
			_notes.RemoveAll(x => x.Id == noteId);
		}

		#endregion
	}
}
