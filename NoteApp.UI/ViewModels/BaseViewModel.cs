using CommunityToolkit.Mvvm.ComponentModel;
using NoteApp.UI.Abstractions;

namespace NoteApp.UI.ViewModels;

public abstract partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private string? _pageTitle;
    
    protected readonly INoteRepository  NoteRepository;
    private readonly INavigationService NavigationService;

    public BaseViewModel(INoteRepository noteRepository, INavigationService navigationService)
    {
        NoteRepository = noteRepository;
        NavigationService = navigationService;
    }
}