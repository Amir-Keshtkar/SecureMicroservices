using IdentityServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.Clients())
    .AddInMemoryApiScopes(Config.ApiScopes())
    .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseIdentityServer();
//app.UseRouting();
//app.UseCors();
//app.UseAuthentication();
//app.UseAuthorization();
//app.UseEndpoints(endpoints =>
//    endpoints.MapControllers()
//);
//app.UseSession();
//app.UseCookiePolicy();

app.MapGet("/", () => "Hello World!");

app.Run();
