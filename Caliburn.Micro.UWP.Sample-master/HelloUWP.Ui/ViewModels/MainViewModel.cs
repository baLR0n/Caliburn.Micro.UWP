using System;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Media;
using Caliburn.Micro.HelloUWP.Ui.Messages;
using Caliburn.Micro.HelloUWP.Ui.Theming;
using PropertyChanged;

namespace Caliburn.Micro.HelloUWP.Ui.ViewModels
{
    /// <summary>
    /// Class MainViewModel.
    /// </summary>
    [ImplementPropertyChanged]
    public class MainViewModel : ThemableViewModel
    {
        /// <summary>
        /// The event aggregator
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public MainViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.Subscribe(this);
        }

        /// <summary>
        /// Tests this instance.
        /// </summary>
        public void ShowTabView()
        {
            this.eventAggregator.PublishOnUIThread(new ChangeViewRequestMessage(Messages.Views.TabView));
        }

        /// <summary>
        /// Shows the ListView.
        /// </summary>
        public void ShowListView()
        {
            this.eventAggregator.PublishOnUIThread(new ChangeViewRequestMessage(Messages.Views.ListView));
        }

        /// <summary>
        /// Shows the form view.
        /// </summary>
        public void ShowFormView()
        {
            this.eventAggregator.PublishOnUIThread(new ChangeViewRequestMessage(Messages.Views.FormView));
        }

        /// <summary>
        /// Shows the carousel view.
        /// </summary>
        public void ShowCarouselView()
        {
            this.eventAggregator.PublishOnUIThread(new ChangeViewRequestMessage(Messages.Views.CarouselView));
        }

        /// <summary>
        /// Shows the blue theme.
        /// </summary>
        public void BlueTheme()
        {
            this.eventAggregator.PublishOnUIThread(new ChangeThemeRequestMessage(new ThemePalette()
            {
                PrimaryColor = new SolidColorBrush(Color.FromArgb(255, 38, 153, 202)),
                SecondaryColor = new SolidColorBrush(Colors.LightBlue),
                AccentColor = new SolidColorBrush(Colors.Pink),
                BackupAccentColor = new SolidColorBrush(Colors.Red),
            }));
        }

        /// <summary>
        /// Creates a random theme.
        /// </summary>
        public void RandomTheme()
        {
            Random random = new Random();
            Byte[] bytes = new Byte[3];

            random.NextBytes(bytes);
            Color primary = Color.FromArgb(255, bytes[0], bytes[1], bytes[2]);
            random.NextBytes(bytes);
            Color secondary = Color.FromArgb(255, bytes[0], bytes[1], bytes[2]);
            random.NextBytes(bytes);
            Color accent = Color.FromArgb(255, bytes[0], bytes[1], bytes[2]);
            random.NextBytes(bytes);
            Color backupAccent = Color.FromArgb(255, bytes[0], bytes[1], bytes[2]);

            this.eventAggregator.PublishOnUIThread(new ChangeThemeRequestMessage(new ThemePalette()
            {
                PrimaryColor = new SolidColorBrush(primary),
                SecondaryColor = new SolidColorBrush(secondary),
                AccentColor = new SolidColorBrush(accent),
                BackupAccentColor = new SolidColorBrush(backupAccent),
            }));
        }

        /// <summary>
        /// Resets the theme to default values.
        /// </summary>
        public void DefaultTheme()
        {
            var uiSettings = new UISettings();
            
            this.eventAggregator.PublishOnUIThread(new ChangeThemeRequestMessage(new ThemePalette()
            {
                PrimaryColor = new SolidColorBrush(uiSettings.GetColorValue(UIColorType.Background)),
                SecondaryColor = new SolidColorBrush(uiSettings.GetColorValue(UIColorType.AccentLight1)),
                AccentColor = new SolidColorBrush(uiSettings.GetColorValue(UIColorType.Accent)),
                BackupAccentColor = new SolidColorBrush(uiSettings.GetColorValue(UIColorType.AccentDark1)),
            }));
        }
    }
}
