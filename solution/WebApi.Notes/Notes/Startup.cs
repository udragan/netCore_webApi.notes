using System.Collections.Generic;
using com.udragan.netCore.webApi.Notes.DAL.Contexts;
using com.udragan.netCore.webApi.Notes.Model.DbModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace com.udragan.netCore.webApi.Notes
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<NotesContext>(opt => opt.UseInMemoryDatabase(databaseName: "inMemoryDb"));
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
