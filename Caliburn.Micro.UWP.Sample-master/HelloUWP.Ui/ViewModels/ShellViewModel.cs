using System;

using Windows.Globalization;
using Windows.UI.Xaml.Controls;

using Caliburn.Micro.HelloUWP.Ui.Messages;

using PropertyChanged;

namespace Caliburn.Micro.HelloUWP.Ui.ViewModels
{
    [ImplementPropertyChanged]
    public class ShellViewModel : Screen, IHandle<ResumeStateMessage>, IHandle<SuspendStateMessage>, IHandle<ChangeViewRequestMessage>, IHandle<SwitchLanguageMessage>
    {
        /// <summary>
        /// The container
        /// </summary>
        private readonly WinRTContainer container;

        /// <summary>
        /// The event aggregator
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// The navigation service
        /// </summary>
        private INavigationService navigationService;

        /// <summary>
        /// The resume
        /// </summary>
        private bool resume;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        public ShellViewModel(WinRTContainer container, IEventAggregator eventAggregator)
        {
            this.container = container;
            this.eventAggregator = eventAggregator;
        }

        /// <summary>
        /// Called when activating.
        /// </summary>
        protected override void OnActivate()
        {
            this.eventAggregator.Subscribe(this);
        }

        /// <summary>
        /// Called when deactivating.
        /// </summary>
        /// <param name="close">Inidicates whether this instance will be closed.</param>
        protected override void OnDeactivate(bool close)
        {
            this.eventAggregator.Unsubscribe(this);
        }

        /// <summary>
        /// Setups the navigation service.
        /// </summary>
        /// <param name="frame">The frame.</param>
        public void SetupNavigationService(Frame frame)
        {
            this.navigationService = this.container.RegisterNavigationService(frame);

            if (this.resume)
                this.navigationService.ResumeState();
        }

        /// <summary>
        /// Shows the devices.
        /// </summary>
        public void ShowMainView()
        {
            this.navigationService.For<MainViewModel>().Navigate();
        }

        /// <summary>
        /// Changes the language to german.
        /// </summary>
        public void LanguageGerman()
        {
            this.Handle(new SwitchLanguageMessage("de-DE"));
        }

        /// <summary>
        /// Changes the language to english.
        /// </summary>
        public void LanguageEnglish()
        {
            this.Handle(new SwitchLanguageMessage("en-US"));
        }

        /// <summary>
        /// Handles a suspend message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Handle(SuspendStateMessage message)
        {
            this.navigationService.SuspendState();
        }

        /// <summary>
        /// Handles a resume message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Handle(ResumeStateMessage message)
        {
            this.resume = true;
        }

        /// <summary>
        /// Handles a request to change the active view.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Handle(ChangeViewRequestMessage message)
        {
            switch (message.RequestedView)
            {
                case Messages.Views.MainView:
                    this.navigationService.For<MainViewModel>().Navigate();
                    break;
                case Messages.Views.TabView:
                    this.navigationService.For<TabViewModel>().Navigate();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Handles a language switch.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Handle(SwitchLanguageMessage message)
        {
            ApplicationLanguages.PrimaryLanguageOverride = message.NewLanguage;

            // This little trick reloads the current page.
            this.navigationService.SuspendState();
            this.navigationService.ResumeState();
        }
    }
}
