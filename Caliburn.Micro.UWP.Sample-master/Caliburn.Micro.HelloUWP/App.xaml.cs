using System;
using System.Collections.Generic;
using System.Reflection;

using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Globalization;
using Windows.UI.Xaml.Controls;
using Caliburn.Micro.HelloUWP.Ui.Messages;
using Caliburn.Micro.HelloUWP.Ui.ViewModels;

namespace Caliburn.Micro.HelloUWP
{
    /// <summary>
    /// Class App. This class cannot be inherited.
    /// </summary>
    public sealed partial class App
    {
        /// <summary>
        /// The container
        /// </summary>
        private WinRTContainer container;

        /// <summary>
        /// The event aggregator
        /// </summary>
        private IEventAggregator eventAggregator;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Override to configure the framework and setup your IoC container.
        /// </summary>
        protected override void Configure()
        {
            this.container = new WinRTContainer();
            this.container.RegisterWinRTServices();

            // Register your view models here.
            this.container
                .Singleton<ShellViewModel>()
                .Singleton<MainViewModel>()
                .Singleton<TabViewModel>();

            this.eventAggregator = this.container.GetInstance<IEventAggregator>();
        }

        /// <summary>
        /// Handles the <see cref="E:Launched" /> event.
        /// </summary>
        /// <param name="args">The <see cref="LaunchActivatedEventArgs"/> instance containing the event data.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            // If we use this, we get the current system language.
            // ApplicationLanguages.PrimaryLanguageOverride = Windows.System.UserProfile.GlobalizationPreferences.Languages[0];

            // But we want english now.
            ApplicationLanguages.PrimaryLanguageOverride = "en-US";

            //Override the default subnamespaces
            var config = new TypeMappingConfiguration
            {
                DefaultSubNamespaceForViews = "Caliburn.Micro.HelloUWP.Views",
                DefaultSubNamespaceForViewModels = "Caliburn.Micro.HelloUWP.Ui.ViewModels"
            };

            ViewLocator.ConfigureTypeMappings(config);
            ViewModelLocator.ConfigureTypeMappings(config);

            // Note we're using DisplayRootViewFor (which is view model first)
            // this means we're not creating a root frame and just directly
            // inserting ShellView as the Window.Content
            this.DisplayRootViewFor<ShellViewModel>();

            // It's kind of weird having to use the event aggregator to pass 
            // a value to ShellViewModel, could be an argument for allowing
            // parameters or launch arguments
            if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                this.eventAggregator.PublishOnUIThread(new ResumeStateMessage());
            }
        }

        /// <summary>
        /// Override to tell the framework where to find assemblies to inspect for views, etc.
        /// </summary>
        /// <returns>
        /// A list of assemblies to inspect.
        /// </returns>
        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            var assemblies = new List<Assembly>()
            {
                // Load every assembly u want to use.
                Assembly.Load(new AssemblyName("Caliburn.Micro.HelloUWP")),
                Assembly.Load(new AssemblyName("Caliburn.Micro.HelloUWP.Ui"))
            };

            return assemblies;
        }

        public static Frame RootFrame;

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            RootFrame = rootFrame;
        }

        /// <summary>
        /// Override this to add custom behavior when the application transitions to Suspended state from some other state.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        protected override void OnSuspending(object sender, SuspendingEventArgs e)
        {
            this.eventAggregator.PublishOnUIThread(new SuspendStateMessage(e.SuspendingOperation));
        }

        /// <summary>
        /// Override this to provide an IoC specific implementation.
        /// </summary>
        /// <param name="service">The service to locate.</param>
        /// <param name="key">The key to locate.</param>
        /// <returns>The located service.</returns>
        protected override object GetInstance(Type service, string key)
        {
            return this.container.GetInstance(service, key);
        }

        /// <summary>
        /// Override this to provide an IoC specific implementation
        /// </summary>
        /// <param name="service">The service to locate.</param>
        /// <returns>The located services.</returns>
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return this.container.GetAllInstances(service);
        }

        /// <summary>
        /// Override this to provide an IoC specific implementation.
        /// </summary>
        /// <param name="instance">The instance to perform injection on.</param>
        protected override void BuildUp(object instance)
        {
            this.container.BuildUp(instance);
        }
    }
}
