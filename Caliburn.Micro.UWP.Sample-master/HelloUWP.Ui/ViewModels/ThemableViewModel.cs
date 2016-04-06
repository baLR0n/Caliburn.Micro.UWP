using Windows.UI.Xaml.Media;
using Caliburn.Micro.HelloUWP.Ui.Messages;

namespace Caliburn.Micro.HelloUWP.Ui.ViewModels
{
    public class ThemableViewModel : Screen, IHandle<ChangeThemeRequestMessage>
    {
        /// <summary>
        /// Gets or sets the color of the primary.
        /// </summary>
        /// <value>
        /// The color of the primary.
        /// </value>
        public SolidColorBrush PrimaryColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the secondary.
        /// </summary>
        /// <value>
        /// The color of the secondary.
        /// </value>
        public SolidColorBrush SecondaryColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the accent.
        /// </summary>
        /// <value>
        /// The color of the accent.
        /// </value>
        public SolidColorBrush AccentColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the backup accent.
        /// </summary>
        /// <value>
        /// The color of the backup accent.
        /// </value>
        public SolidColorBrush BackupAccentColor { get; set; }

        /// <summary>
        /// Handles the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Handle(ChangeThemeRequestMessage message)
        {
            this.PrimaryColor = message.Palette.PrimaryColor;
            this.SecondaryColor = message.Palette.SecondaryColor;
            this.AccentColor = message.Palette.AccentColor;
            this.BackupAccentColor = message.Palette.BackupAccentColor;
        }
    }
}
