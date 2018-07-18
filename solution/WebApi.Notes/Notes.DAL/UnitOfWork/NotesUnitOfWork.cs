using com.udragan.netCore.webApi.Notes.DAL.Contexts;
using com.udragan.netCore.webApi.Notes.DAL.UnitOfWork.Interfaces;

namespace com.udragan.netCore.webApi.Notes.DAL.UnitOfWork
{
	public class NotesUnitOfWork : UnitOfWork, INotesUnitOfWork
	{
		public NotesUnitOfWork(NotesContext context)
			: base(context)
		{ }
	}
}
