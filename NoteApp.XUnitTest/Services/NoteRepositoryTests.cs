using Ninject;
using NoteApp.Core.Abstractions;
using NoteApp.Core.Models;

namespace NoteApp.XUnitTest.Services;

public class NoteRepositoryTests : BaseTests
{
    [Fact]
    public async Task Add_Note_ShouldBe_True()
    {
        //1. Arrange
        var noteRepository = Kernel?.Get<INoteRepository>();
        var note = new Note
        {
            Id = 1,
        };
        
        //2. Act
        var result = await noteRepository!.SaveAsync(note);
        
        //3. Assert
        Assert.True(result);
    }
    
    [Fact]
    public async Task Add_Null_Note_ShouldBe_False()
    {
        //1. Arrange
        var noteRepository = Kernel?.Get<INoteRepository>();
        
        //2. Act
        var result = await noteRepository!.SaveAsync(null!);
        
        //3. Assert
        Assert.False(result);
    }
    
    [Fact]
    public async Task Add_InValid_Note_ShouldBe_False()
    {
        //1. Arrange
        var noteRepository = Kernel?.Get<INoteRepository>();
        const long id = 2;
        var note = new Note
        {
            Id = id,
            Title = $"Note {id}",
            Description = $"Description {id}"
        };
        
        //2. Act
        var result = await noteRepository?.SaveAsync(note);
        
        //3. Assert
        Assert.False(result);
    }
    
    [Theory]
    [InlineData("Test Title",  1)]
    //[InlineData("",  -1)]
    public async Task Add_Note_With_Valid_Title_And_NumberOfNotes_ShouldBeTrue(string title, int numberOfNotes)
    {
        //1. Arrange
        var noteRepository = Kernel?.Get<INoteRepository>();
        
        //2. Act
        var result = await noteRepository?.SaveAsync(title, numberOfNotes);
        
        //3. Assert
        Assert.True(result);
    }
}