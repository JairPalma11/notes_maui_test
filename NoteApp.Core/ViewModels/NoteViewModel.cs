using CommunityToolkit.Mvvm.ComponentModel;
using NoteApp.Core.Models;

namespace NoteApp.Core.ViewModels;

public sealed partial class NoteViewModel : ObservableObject
{
    private Note _note;
    
    [ObservableProperty]
    private string? _title;
    
    [ObservableProperty]
    private string? _description;
    
    [ObservableProperty]
    private string? _date;
    
    public NoteViewModel(Note note)
    {
        _note = note;
        Title = note.Title;
        Description = note.Description;
        Date = note.CreatedAt.ToString("dd/MM/yyyy HH:mm");
    }

    public Note GetModel()
    {
        return _note;
    }
}