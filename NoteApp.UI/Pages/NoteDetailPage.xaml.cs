using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteApp.UI.ViewModels;

namespace NoteApp.UI.Pages;

public partial class NoteDetailPage : ContentPage
{
    public NoteDetailPage(NoteDetailViewModel noteDetailViewModel)
    {
        InitializeComponent();
        BindingContext = noteDetailViewModel;
    }
}