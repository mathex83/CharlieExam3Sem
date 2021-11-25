using CharlieExam3Sem.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CharlieExam3Sem
{
	///Udviklet af: Martin N�rholm, Janus B. Reedtz og Frederik M. Nielsen
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
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));
			services.AddDatabaseDeveloperPageExceptionFilter();

			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
				.AddEntityFrameworkStores<ApplicationDbContext>();
			
			services.AddControllersWithViews();
			services.AddRazorPages();

			//her tilf�jer vi id og secret for vores forskellige apps
			services.AddAuthentication()
				.AddFacebook(options =>
				{
					options.AppId = Configuration["Authentication:Facebook:AppId"];
					options.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
					options.AccessDeniedPath = "/AccessDenied";
				})
				.AddGoogle(options =>
				{
					IConfigurationSection googleAuthNSection =
						Configuration.GetSection("Authentication:Google");

					options.ClientId = googleAuthNSection["ClientId"];
					options.ClientSecret = googleAuthNSection["ClientSecret"];
					options.AuthorizationEndpoint += "?prompt=consent";
					//Callback var navnet. Sku tilf�jes p� Google Developer ogs�
					options.AccessDeniedPath = "/AccessDenied";
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
			});
		}
	}
}
