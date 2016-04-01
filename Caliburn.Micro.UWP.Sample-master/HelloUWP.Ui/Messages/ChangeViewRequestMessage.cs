namespace Caliburn.Micro.HelloUWP.Ui.Messages
{
    public class ChangeViewRequestMessage
    {
        /// <summary>
        /// Gets or sets the requested view.
        /// </summary>
        /// <value>The requested view.</value>
        public Views RequestedView { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeViewRequestMessage"/> class.
        /// </summary>
        /// <param name="requestedView">The requested view.</param>
        public ChangeViewRequestMessage(Views requestedView)
        {
            this.RequestedView = requestedView;
        }
    }

    /// <summary>
    /// Enum Views
    /// </summary>
    public enum Views
    {
        MainView,
        TabView
    }
}
