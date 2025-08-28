using Ninject;
using NoteApp.Core.ViewModels;

namespace NoteApp.NUnitTest.ViewModels;

[TestFixture(Description = "Note Details ViewModel Tests")]
public sealed class NoteDetailViewModelTests : BaseTests
{
    [Test]
    public async Task Add_Valid_Note_ShouldBe_True()
    {
        //1. Arrange
        var noteDetailViewModel = Kernel?.Get<NoteDetailViewModel>();
        noteDetailViewModel.Title = "Note 1";
        noteDetailViewModel.Description = "Description 1";
        
        //2. Act
        await noteDetailViewModel.SaveCommand.ExecuteAsync(null);

        //3. Assert
        Assert.That(noteDetailViewModel.IsSaved,  Is.True);
    }
}