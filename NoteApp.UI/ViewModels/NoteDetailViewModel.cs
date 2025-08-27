using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteApp.UI.Abstractions;
using NoteApp.UI.Models;

namespace NoteApp.UI.ViewModels;

public sealed partial class NoteDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    private string? _title;
    
    [ObservableProperty]
    private string? _description;
    
    public NoteDetailViewModel(INoteRepository  repository, INavigationService navigationService):base(repository, navigationService)
    {
        PageTitle = "Note Details";
    }

    [RelayCommand]
    private async Task Save()
    {
        var note = new Note
        {
            Title = Title,
            Description = Description,
            CreatedAt = DateTime.Now
        };
        
        var isSuceed = await NoteRepository.SaveAsync(note);
        if (isSuceed)
        {
            await NavigationService.GoBackAsync();
        }
    }
}