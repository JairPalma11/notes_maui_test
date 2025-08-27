using NoteApp.UI.Models;

namespace NoteApp.UI.Abstractions;

public interface INoteRepository
{
    Task<bool> SaveAsync(Note note);
    Task<bool> DeleteAsync(Note note);
    Task<IReadOnlyList<Note>> GetNotesAsync();
}