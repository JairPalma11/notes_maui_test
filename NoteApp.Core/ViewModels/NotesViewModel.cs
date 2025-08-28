using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteApp.Core.Abstractions;

namespace NoteApp.Core.ViewModels;

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
        var model = note.GetModel();
        await NoteRepository.DeleteAsync(model);
        Notes.Remove(note);
    }
    
    protected override async Task Refresh()
    {
        var notes = await NoteRepository.GetNotesAsync();
        Notes = new ObservableCollection<NoteViewModel>(notes.Select(n => new NoteViewModel(n)).ToList());
        IsRefreshing = false;
    }
}