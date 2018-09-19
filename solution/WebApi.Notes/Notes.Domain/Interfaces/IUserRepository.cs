using com.udragan.netCore.webApi.Notes.Common.Shared;
using com.udragan.netCore.webApi.Notes.Domain.Models;

namespace com.udragan.netCore.webApi.Notes.Domain.Interfaces
{
	/// <summary>
	/// Repository interface for users.
	/// </summary>
	/// <seealso cref="com.udragan.netCore.webApi.Notes.Common.Shared.IRepository{com.udragan.netCore.webApi.Notes.Domain.Models.User}" />
	public interface IUserRepository : IRepository<User>
	{ }
}
