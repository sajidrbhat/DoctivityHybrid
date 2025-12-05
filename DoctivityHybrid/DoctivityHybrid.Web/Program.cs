using DoctivityHybrid.Shared.Services;
using DoctivityHybrid.Web;
using DoctivityHybrid.Web.Components;
using DoctivityHybrid.Web.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.Extensions.Options;
using MudBlazor.Services;

namespace DoctivityHybrid
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddMudServices();

            builder.Services.AddSingleton<LoaderService>();

            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddAuthentication(WebConstants.WebAuthScheme)
                .AddCookie(WebConstants.WebAuthScheme, options =>
                {
                    options.LoginPath = "/login";
                    options.LogoutPath = "/logout";
                    options.Cookie.Name = WebConstants.WebAuthScheme;
                    options.Cookie.HttpOnly = true;
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromDays(7);
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                });

            builder.Services.AddAuthorization();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddCascadingAuthenticationState();
            //builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider, WebAuthStateProvider>();

            // Add device-specific services used by the DoctivityHybrid.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();


            builder.Services.AddScoped<INoteService, NoteService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddAdditionalAssemblies(
                    typeof(DoctivityHybrid.Shared._Imports).Assembly);

            app.Run();
        }
    }
}
