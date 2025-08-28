using Moq;
using Ninject.Modules;
using NoteApp.Core.Abstractions;
using NoteApp.Core.Models;
using NoteApp.Core.Services;
using NoteApp.Core.ViewModels;

namespace NoteApp.XUnitTest;

/// <summary>
/// this module will be detected by Niject
/// and load all the dependencies indicated
/// here. it needs to extends from NinjectModule class, though
/// </summary>
public sealed class MyNinjectBindings : NinjectModule
{
    public override void Load()
    {
        //using fake, meaning code by hand!
        //this.Bind<INoteRepository>().To<FakeNoteRepository>();
        
        //using MOQ, so we don't have to create
        //fake implementations per scenario
        //https://docs.microsoft.com/en-us/shows/visual-studio-toolbox/unit-testing-moq-framework
        //by default MockBehavior.Loose, strict force you to mock all methods
        //of your interface
        var noteRepository = new Mock<INoteRepository>();
        var navigationService = new Mock<INavigationService>();
        var notesViewModel = new  NotesViewModel(noteRepository.Object, navigationService.Object);
        var noteDetailViewModel = new  NoteDetailViewModel(noteRepository.Object, navigationService.Object);

        //Save
        noteRepository.Setup(n => n.SaveAsync("Test Title", 1)).ReturnsAsync(() => true);//valid for any object

        //valid
        noteRepository.Setup(n => n.SaveAsync(It.IsAny<Note>())).ReturnsAsync(() => true);//valid for any object
        //noteRepository.Setup(n => n.SaveAsync(It.Is<Note>((n) => n.Id == 1))).ReturnsAsync(() => true);
        
        //invalid
        noteRepository.Setup(n => n.SaveAsync(It.Is<Note>((n) => n.Id == 2))).ReturnsAsync(() => false);
        //null case
        noteRepository.Setup(n => n.SaveAsync(null!)).ReturnsAsync(() => false);
        
        //Delete
        //valid delete
        noteRepository.Setup(n => n.DeleteAsync(It.Is<Note>((n) => n.Id == 1))).ReturnsAsync(() => true);
        //invalid delete
        noteRepository.Setup(n => n.DeleteAsync(It.Is<Note>((n) => n.Id == 2))).ReturnsAsync(() => false);
        noteRepository.Setup(n => n.DeleteAsync(null!)).ReturnsAsync(() => false);
        
        //Get Notes
        noteRepository.Setup(n => n.GetNotesAsync())
                      .ReturnsAsync(() => new List<Note>
                      {
                          new Note { Id = 1, Title = "Note 1", Description = "Description 1" },
                          new Note { Id = 2, Title = "Note 2", Description = "Description 2" }
                      });
        
        //setup services
        Bind<INoteRepository>().ToConstant(noteRepository.Object);
        Bind<INavigationService>().ToConstant(navigationService.Object);
        Bind<NotesViewModel>().ToConstant(notesViewModel);
        Bind<NoteDetailViewModel>().ToConstant(noteDetailViewModel);
    }
}