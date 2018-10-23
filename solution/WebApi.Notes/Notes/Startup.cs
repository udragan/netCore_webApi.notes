using com.udragan.netCore.webApi.Notes.Domain.Interfaces;
using com.udragan.netCore.webApi.Notes.Domain.Models;
using com.udragan.netCore.webApi.Notes.Infrastructure.Contexts;
using com.udragan.netCore.webApi.Notes.Infrastructure.Repositories;
using com.udragan.netCore.webApi.Notes.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace com.udragan.netCore.webApi.Notes
{
	/// <summary>
	/// Web host startup.
	/// </summary>
	public class Startup
	{
		#region Members

		private IConfiguration _configuration;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Startup"/> class.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Runtime called method for configuring/registering the services to the container.
		/// </summary>
		/// <param name="services">The services collection.</param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<NotesContext>(opt => opt.UseInMemoryDatabase(databaseName: "inMemoryDb"));
			services.AddScoped<INoteRepository, NoteRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<INotesAppUnitOfWork, NotesAppUnitOfWork>();

			services.AddMvc();
		}

		/// <summary>
		/// Runtime called method for configuring HTTP request pipeline and (optional) data seed.
		/// </summary>
		/// <param name="app">The application builder.</param>
		/// <param name="env">The hosting environment.</param>
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
				{
					NotesContext context = serviceScope.ServiceProvider.GetRequiredService<NotesContext>();

					SeedTestData(context);
				}

				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}

		#endregion

		#region Private methods

		private static void SeedTestData(NotesContext context)
		{
			User user1 = new User("TestUser1");
			user1.AddNote("First Note", "This is the first note.", false);

			User user2 = new User("TestUser2");
			user2.AddNote("Note Two", "This is second users first note", false);
			user2.AddNote("Note Two two", "This is the second note of the second user.", false);

			context.Users.Add(user1);
			context.Users.Add(user2);

			context.SaveChanges();
		}

		#endregion
	}
}
