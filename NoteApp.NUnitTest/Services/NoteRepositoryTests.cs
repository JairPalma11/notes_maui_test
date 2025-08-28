using Ninject;
using NoteApp.Core.Abstractions;
using NoteApp.Core.Models;

namespace NoteApp.NUnitTest.Services;

[TestFixture(Description = "Note Repository Tests")]
public class NoteRepositoryTests : BaseTests
{
    public static Note ValidNote = new Note { Id = 1, CreatedAt = DateTime.Now };
    public static Note InvalidValidNote = new Note { Id = 2, CreatedAt = DateTime.Now };
    
    [Test, Description("Add a note using the repository")]
    public async Task Add_Note_ShouldBe_True()
    {
        //1. Arrange
        var noteRepository = Kernel?.Get<INoteRepository>();
        
        //2. Act
        var result = await noteRepository!.SaveAsync(ValidNote);
        
        //3. Assert
        Assert.That(result, Is.True);
    }
    
    [Test(ExpectedResult = false),Description("Add an invalid note using the repository")]
    public async Task<bool> Add_InValid_Note_ShouldBe_False()
    {
        //1. Arrange
        var noteRepository = Kernel?.Get<INoteRepository>();
        const long id = 1;
        var note = new Note
        {
            Id = id,
            Title = $"Note {id}",
            Description = $"Description {id}"
        };
        
        //2. Act
        var result = await noteRepository?.SaveAsync(InvalidValidNote);
        
        //3. Assert
        return result;
    }
}