using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using NoteApp.UI.Abstractions;

namespace NoteApp.UI.ViewModels;

public sealed partial class NotesViewModel : BaseViewModel
{
    [ObservableProperty]
    private ObservableCollection<NoteViewModel> _notes;

    public NotesViewModel(INoteRepository  repository, INavigationService navigationService) : base(repository, navigationService)
    {
        Notes = [];
    }
    
    
}