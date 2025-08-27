using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteApp.UI.Abstractions;

namespace NoteApp.UI.ViewModels;

public abstract partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private string? _pageTitle;
    
    [ObservableProperty]
    private bool _isRefreshing;
    
    protected readonly INoteRepository  NoteRepository;
    protected readonly INavigationService NavigationService;

    public BaseViewModel(INoteRepository noteRepository, INavigationService navigationService)
    {
        NoteRepository = noteRepository;
        NavigationService = navigationService;
    }

    [RelayCommand]
    protected virtual Task Refresh()
    {
        return Task.CompletedTask;
    }
}