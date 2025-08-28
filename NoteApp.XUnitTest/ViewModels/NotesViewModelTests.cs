using Ninject;
using NoteApp.Core.ViewModels;

namespace NoteApp.XUnitTest.ViewModels;

public class NotesViewModelTests : BaseTests
{
    [Fact]
    public async Task GetNotes_Should_Returns_Items()
    {
        //1. Arrange
        var notesViewModel = Kernel?.Get<NotesViewModel>();
        
        //2. Act
        await notesViewModel?.RefreshCommand.ExecuteAsync(null);

        //3. Assert
        Assert.NotNull(notesViewModel.Notes);
        Assert.True(notesViewModel.Notes.Any());
    }
}