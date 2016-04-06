using Windows.UI;
using Windows.UI.Xaml.Media;
using Caliburn.Micro.HelloUWP.Ui.Messages;

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
        /// Blues the theme.
        /// </summary>
        public void BlueTheme()
        {
            this.eventAggregator.PublishOnUIThread(new ChangeThemeRequestMessage(new ThemePalette()
            {
                PrimaryColor = new SolidColorBrush(Colors.Blue),
                SecondaryColor = new SolidColorBrush(Colors.LightBlue),
                AccentColor = new SolidColorBrush(Colors.Pink),
                BackupAccentColor = new SolidColorBrush(Colors.Red),
            }));
        }
    }
}
