using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteApp.Core.Abstractions;
using NoteApp.Core.Models;

namespace NoteApp.Core.ViewModels;

public partial class NoteDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    private string? _title;
    
    [ObservableProperty]
    private string? _description;
    
    public bool IsSaved { get; private set; }

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
        
        IsSaved = await NoteRepository.SaveAsync(note);
        if (IsSaved)
        {
            await NavigationService.GoBackAsync();
        }
    }
}