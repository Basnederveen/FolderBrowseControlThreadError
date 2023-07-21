using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using ReactiveUI;
using System;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Interactivity;

namespace FolderBrowseControlThreadError.Controls
{
    [TemplatePart(nameof(PART_Button), typeof(Button))]
    public class BrowseFolderControl : TemplatedControl
    {
        // Keep a reference to the Button
        private Button? PART_Button; 
        
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

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            // unsubscribe if needed
            if(PART_Button is not null) 
                PART_Button.Click -= PART_ButtonOnClick;

            PART_Button = e.NameScope.Find<Button>(nameof(PART_Button));
            
            // Listen to Button.Click
            if(PART_Button is not null) 
                PART_Button.Click += PART_ButtonOnClick;
        }

        private void PART_ButtonOnClick(object? sender, RoutedEventArgs e)
        {
            SetFolder();
        }

        private void SetFolder()
        {
            Console.WriteLine("");
            Path = "Success";
        }
    }
}
