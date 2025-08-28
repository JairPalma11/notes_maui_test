using NoteApp.Core.Abstractions;
using NoteApp.Core.Models;

namespace NoteApp.Core.Services;

public sealed class FakeNoteRepository : INoteRepository
{
    private static readonly List<Note> Notes = [];

    public async Task<bool> SaveAsync(Note note)
    {
        Notes.Add(note);
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(Note note)
    {
        Notes.Remove(note);
        return await Task.FromResult(true);
    }

    public async Task<IReadOnlyList<Note>> GetNotesAsync()
    {
        return await Task.FromResult(Notes);
    }

    public static void Initialize()
    {
        for (var i = 0; i < 10; i++)
        {
            Notes.Add(new Note
            {
                Id = i,
                Title = "Note #" + i,
                Description = "This is a comment on note:" + i,
            });
        }
    }
}