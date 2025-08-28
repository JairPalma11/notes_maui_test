using NoteApp.Core.Models;
namespace NoteApp.Core.Abstractions;

public interface INoteRepository
{
    Task<bool> SaveAsync(Note note);
    Task<bool> DeleteAsync(Note note);
    Task<IReadOnlyList<Note>> GetNotesAsync();
}