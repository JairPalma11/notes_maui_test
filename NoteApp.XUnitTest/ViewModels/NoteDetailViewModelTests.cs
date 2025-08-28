using Ninject;
using NoteApp.Core.ViewModels;

namespace NoteApp.XUnitTest.ViewModels;

public sealed class NoteDetailViewModelTests : BaseTests
{
    [Fact]
    public async Task Add_Valid_Note_ShouldBe_True()
    {
        //1. Arrange
        var noteDetailViewModel = Kernel?.Get<NoteDetailViewModel>();
        noteDetailViewModel.Title = "Note 1";
        noteDetailViewModel.Description = "Description 1";
        
        //2. Act
        await noteDetailViewModel.SaveCommand.ExecuteAsync(null);

        //3. Assert
        Assert.True(noteDetailViewModel.IsSaved);
    }
}