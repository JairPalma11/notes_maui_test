namespace NoteApp.Core.Abstractions;

public interface INavigationService
{
    Task GoBackAsync();
    Task GoBackAsync(IDictionary<string, object> parameters);
    Task NavigateAsync(string path);
    Task NavigateAsync(string path, IDictionary<string, object> parameters);
}