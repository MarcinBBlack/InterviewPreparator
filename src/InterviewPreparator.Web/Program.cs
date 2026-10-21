using InterviewPreparator.Web.Components;
using InterviewPreparator.Application.Interfaces;
using InterviewPreparator.Infrastructure.AgentFactory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAgentFactory, OpenAIAgentFactory>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
