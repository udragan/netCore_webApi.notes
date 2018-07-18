using com.udragan.netCore.webApi.Notes.DAL.Repositories.Interfaces;
using com.udragan.netCore.webApi.Notes.DAL.UnitOfWork.Interfaces;
using com.udragan.netCore.webApi.Notes.Model.DbModels;

namespace com.udragan.netCore.webApi.Notes.DAL.Repositories
{
	public class NotesRepository : Repository<Note>, INotesRepository
	{
		#region Constructors

		public NotesRepository(INotesUnitOfWork unitOfWork)
			: base(unitOfWork)
		{ }

		#endregion
	}
}
