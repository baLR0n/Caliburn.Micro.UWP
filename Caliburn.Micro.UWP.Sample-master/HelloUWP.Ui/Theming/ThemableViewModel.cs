using Windows.UI.Xaml.Media;
using Caliburn.Micro.HelloUWP.Ui.Messages;

namespace Caliburn.Micro.HelloUWP.Ui.Theming
{
    public class ThemableViewModel : Screen, IHandle<ChangeThemeRequestMessage>
    {
        public ThemableViewModel()
        {
            this.PrimaryColor = new SolidColorBrush(ThemeManager.PrimaryColor);
            this.SecondaryColor = new SolidColorBrush(ThemeManager.SecondaryColor);
            this.AccentColor = new SolidColorBrush(ThemeManager.AccentColor);
            this.BackupAccentColor = new SolidColorBrush(ThemeManager.BackupAccentColor);
        }

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
            ThemeManager.SetPrimaryBackgroundColor(message.Palette.PrimaryColor.Color);
            ThemeManager.SetSecondaryColor(message.Palette.SecondaryColor.Color);
            ThemeManager.SetAccentColor(message.Palette.AccentColor.Color);
            ThemeManager.SetBackupAccentColor(message.Palette.BackupAccentColor.Color);

            this.PrimaryColor = message.Palette.PrimaryColor;
            this.SecondaryColor = message.Palette.SecondaryColor;
            this.AccentColor = message.Palette.AccentColor;
            this.BackupAccentColor = message.Palette.BackupAccentColor;
        }
    }
}
