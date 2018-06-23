namespace com.udragan.netCore.webApi.Notes.Model.DbModels
{
	public class Note
	{
		public long Id { get; set; }

		public long UserId { get; set; }
		public User User { get; set; }
		public string Content { get; set; }
	}
}
