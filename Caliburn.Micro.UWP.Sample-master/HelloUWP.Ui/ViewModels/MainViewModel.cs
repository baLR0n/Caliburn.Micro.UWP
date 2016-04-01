using Caliburn.Micro.HelloUWP.Ui.Messages;

using PropertyChanged;

namespace Caliburn.Micro.HelloUWP.Ui.ViewModels
{
    /// <summary>
    /// Class MainViewModel.
    /// </summary>
    [ImplementPropertyChanged]
    public class MainViewModel : Screen
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
        }

        /// <summary>
        /// Tests this instance.
        /// </summary>
        public void ShowTabView()
        {
            this.eventAggregator.PublishOnUIThread(new ChangeViewRequestMessage(Messages.Views.TabView));
        }
    }
}
