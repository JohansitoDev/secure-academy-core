using SistemaEscolar.BlazorApp.Components;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar servicios de Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // Habilita Blazor Server SSR interactivo

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery(); // Protección nativa contra CSRF (OWASP A01/A03)

// 2. Mapear los componentes y activar el modo interactivo global
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();