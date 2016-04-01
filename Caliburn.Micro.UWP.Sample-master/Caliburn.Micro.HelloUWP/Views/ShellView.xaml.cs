using Windows.UI.Xaml;

namespace Caliburn.Micro.HelloUWP.Views
{
    public sealed partial class ShellView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShellView"/> class.
        /// </summary>
        public ShellView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Opens the navigation view.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OpenNavigationView(object sender, RoutedEventArgs e)
        {
            this.NavigationView.IsPaneOpen = true;
        }

        /// <summary>
        /// Closes the navigation pane after a menuitem is selected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnMenuButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationView.IsPaneOpen = false;
        }
    }
}
