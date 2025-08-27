using CommunityToolkit.Mvvm.ComponentModel;
using NoteApp.UI.Models;

namespace NoteApp.UI.ViewModels;

public sealed partial class NoteViewModel : ObservableObject
{
    [ObservableProperty]
    private string? _title;
    
    [ObservableProperty]
    private string? _description;
    
    public NoteViewModel(Note note)
    {
        Title = note.Title;
        Description = note.Description;
    }
}