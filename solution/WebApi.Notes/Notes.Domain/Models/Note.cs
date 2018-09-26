using com.udragan.netCore.webApi.Notes.Common.Shared;

namespace com.udragan.netCore.webApi.Notes.Domain.Models
{
	/// <summary>
	/// POCO class representing the note.
	/// </summary>
	/// <seealso cref="com.udragan.netCore.webApi.Notes.Common.Shared.Entity" />
	public class Note : Entity
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Note"/> class.
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <param name="caption">The caption.</param>
		/// <param name="text">The text.</param>
		/// <param name="isChecked">if set to <c>true</c> [is checked].</param>
		public Note(
			long userId,
			string caption,
			string text,
			bool isChecked)
		{
			UserId = userId;
			Caption = caption;
			Text = text;
			IsChecked = isChecked;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the user identifier.
		/// </summary>
		public long UserId { get; private set; }

		/// <summary>
		/// Gets the note caption.
		/// </summary>
		public string Caption { get; private set; }

		/// <summary>
		/// Gets the note text.
		/// </summary>
		public string Text { get; private set; }

		/// <summary>
		/// Gets a value indicating whether the note is checked.
		/// </summary>
		public bool IsChecked { get; private set; }

		#endregion

		#region Public methods

		/// <summary>
		/// Updates this entity with specified other.
		/// </summary>
		/// <param name="other">The other note to update from.</param>
		public void Update(Note other)
		{
			Caption = other.Caption ?? Caption;
			Text = other.Text ?? Text;
			IsChecked = other.IsChecked;
		}

		#endregion
	}
}
