using Microsoft.Extensions.Logging;
using NoteApp.UI.Abstractions;
using NoteApp.UI.Pages;
using NoteApp.UI.Services;
using NoteApp.UI.ViewModels;
using CommunityToolkit.Maui;

namespace NoteApp.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
        builder.Services.AddSingleton<INoteRepository, FakeNoteRepository>();
        builder.Services.AddSingleton<INavigationService, ShellNavigationService>();
        builder.Services.AddTransientWithShellRoute<NotesPage, NotesViewModel>(nameof(NotesViewModel));
        builder.Services.AddTransientWithShellRoute<NoteDetailPage, NoteDetailViewModel>(nameof(NoteDetailViewModel));

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}