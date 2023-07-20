using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using ReactiveUI;
using System;
using System.Windows.Input;

namespace FolderBrowseControlThreadError.Controls
{
    public class BrowseFolderControl : TemplatedControl
    {
        public static readonly StyledProperty<string> HeaderProperty =
            AvaloniaProperty.Register<BrowseFolderControl, string>(
                nameof(Header), "Select a folder");

        public string Header
        {
            get { return GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly StyledProperty<string?> PathProperty =
            AvaloniaProperty.Register<BrowseFolderControl, string?>(
                nameof(Path), @"C:\");

        public string? Path
        {
            get { return GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }

        public BrowseFolderControl()
        {
            OpenFolderCommand = ReactiveCommand.Create(SetFolderUIThread);
        }

        public static DirectProperty<BrowseFolderControl, ICommand> OpenFolderCommandProperty =
            AvaloniaProperty.RegisterDirect<BrowseFolderControl, ICommand>(
                nameof(OpenFolderCommand),
                x => x.OpenFolderCommand);

        public ICommand OpenFolderCommand { get; }

        private void SetFolderUIThread()
        {
            Dispatcher.UIThread.InvokeAsync(SetFolder);
        }

        private void SetFolder()
        {
            Console.WriteLine("");
        }
    }
}
