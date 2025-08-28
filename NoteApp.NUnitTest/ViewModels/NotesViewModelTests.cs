using Ninject;
using NoteApp.Core.ViewModels;

namespace NoteApp.NUnitTest.ViewModels;

[TestFixture(Description = "Notes ViewModel Tests")]
public class NotesViewModelTests : BaseTests
{
    [Test]
    public async Task GetNotes_Should_Returns_Items()
    {
        //1. Arrange
        var notesViewModel = Kernel?.Get<NotesViewModel>();
        
        //2. Act
        await notesViewModel?.RefreshCommand.ExecuteAsync(null);

        //3. Assert
        Assert.That(notesViewModel.Notes, Is.Not.Null);
        Assert.That(notesViewModel.Notes.Any(), Is.True);
    }
}