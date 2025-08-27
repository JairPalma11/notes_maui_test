using NoteApp.UI.Abstractions;

namespace NoteApp.UI.ViewModels;

public sealed class NoteDetailViewModel : BaseViewModel
{
    public NoteDetailViewModel(INoteRepository  repository, INavigationService navigationService):base(repository, navigationService)
    {
    }
}