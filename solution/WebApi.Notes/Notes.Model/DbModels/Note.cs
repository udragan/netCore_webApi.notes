using Newtonsoft.Json;

namespace com.udragan.netCore.webApi.Notes.Model.DbModels
{
	public class Note
	{
		public long Id { get; set; }

		[JsonIgnore]
		public long UserId { get; set; }
		[JsonIgnore]
		public User User { get; set; }
		public string Content { get; set; }
	}
}
