using Ninject;
using NoteApp.Core.Abstractions;
using NoteApp.Core.Models;

namespace NoteApp.NUnitTest.Services;

[TestFixture(Description = "Note Repository Tests")]
public class NoteRepositoryTests : BaseTests
{
    /// <summary>
    /// Examples of specific results.
    /// </summary>
    public static readonly Note ValidNote = new Note { Id = 1, CreatedAt = DateTime.Now };
    public static readonly Note InvalidValidNote = new Note { Id = 2, CreatedAt = DateTime.Now };
    
    [Test, Description("Add a valid note using the repository")]
    public async Task Add_Note_ShouldBe_True()
    {
        //1. Arrange
        var noteRepository = Kernel?.Get<INoteRepository>();
        
        //2. Act
        var result = await noteRepository!.SaveAsync(ValidNote);
        
        //3. Assert
        Assert.That(result, Is.True);
    }
    
    [Test, Description("Add a null note using the repository")]
    public async Task Add_Null_Note_ShouldBe_False()
    {
        //1. Arrange
        var noteRepository = Kernel?.Get<INoteRepository>();
        
        //2. Act
        var result = await noteRepository!.SaveAsync(null!);
        
        //3. Assert
        Assert.That(result, Is.False);
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