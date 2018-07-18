using System.Collections.Generic;
using com.udragan.netCore.webApi.Notes.DAL.Contexts;
using com.udragan.netCore.webApi.Notes.DAL.Repositories;
using com.udragan.netCore.webApi.Notes.DAL.Repositories.Interfaces;
using com.udragan.netCore.webApi.Notes.DAL.UnitOfWork;
using com.udragan.netCore.webApi.Notes.DAL.UnitOfWork.Interfaces;
using com.udragan.netCore.webApi.Notes.Model.DbModels;
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

		public IConfiguration Configuration { get; }

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="Startup"/> class.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
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
			services.AddTransient<INotesUnitOfWork, NotesUnitOfWork>();
			services.AddTransient<INotesRepository, NotesRepository>();
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
			context.AddRange(new User
			{
				Name = "TestUser1",
				Notes = new List<Note>
				{
					new Note
					{
						Content = "First content.",
					},
					new Note
					{
						Content = "Second note content of TestUser1.",
					},
				},
			},
			new User
			{
				Name = "TestUser2",
			},
			new User
			{
				Name = "TestUser3",
			});

			context.SaveChanges();
		}

		#endregion
	}
}
