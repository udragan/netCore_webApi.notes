using com.udragan.netCore.webApi.Notes.Common.Shared;

namespace com.udragan.netCore.webApi.Notes.Domain.Models
{
	/// <summary>
	/// POCO class representing the note.
	/// </summary>
	/// <seealso cref="com.udragan.netCore.webApi.Notes.Common.Shared.Entity" />
	public class Note : Entity
	{
		#region Members

		private long _userId;
		private string _caption;
		private string _text;
		private bool _isChecked;

		#endregion

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
			_userId = userId;
			_caption = caption;
			_text = text;
			_isChecked = isChecked;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the note caption.
		/// </summary>
		public string Caption => _caption;

		/// <summary>
		/// Gets the note text.
		/// </summary>
		public string Text => _text;

		/// <summary>
		/// Gets a value indicating whether the note is checked.
		/// </summary>
		public bool IsChecked => _isChecked;

		#endregion
	}
}
