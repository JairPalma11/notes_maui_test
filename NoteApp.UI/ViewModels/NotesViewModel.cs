using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteApp.UI.Abstractions;

namespace NoteApp.UI.ViewModels;

public partial class NotesViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<NoteViewModel> _notes;

    public NotesViewModel(INoteRepository  repository, INavigationService navigationService) : base(repository, navigationService)
    {
        PageTitle = "Notes";
        Notes = [];
    }

    [RelayCommand]
    private async Task Add()
    {
        await NavigationService.NavigateAsync(nameof(NoteDetailViewModel));
    }
    
    [RelayCommand]
    private async Task Delete(NoteViewModel note)
    {
        await NoteRepository.DeleteAsync(note.GetModel());
    }
    
    protected override async Task Refresh()
    {
        var notes = await NoteRepository.GetNotesAsync();
        Notes = new ObservableCollection<NoteViewModel>(notes.Select(n => new NoteViewModel(n)).ToList());
        IsRefreshing = false;
    }
}