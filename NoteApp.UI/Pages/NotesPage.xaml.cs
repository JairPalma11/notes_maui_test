using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteApp.UI.ViewModels;

namespace NoteApp.UI.Pages;

public partial class NotesPage : ContentPage
{
    private NotesViewModel _notesViewModel;
    public NotesPage(NotesViewModel notesViewModel)
    {
        InitializeComponent();
        BindingContext = _notesViewModel = notesViewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        _notesViewModel.RefreshCommand.Execute(null);
    }
}