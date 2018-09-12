using com.udragan.netCore.webApi.Notes.Common.Shared;
using com.udragan.netCore.webApi.Notes.Domain.Models;

namespace com.udragan.netCore.webApi.Notes.Domain.Interfaces
{
	/// <summary>
	/// Repository interface for notes.
	/// </summary>
	/// <seealso cref="com.udragan.netCore.webApi.Notes.Common.Shared.IRepository{com.udragan.netCore.webApi.Notes.Domain.Models.Note}" />
	public interface INoteRepository : IRepository<Note>
	{ }
}
