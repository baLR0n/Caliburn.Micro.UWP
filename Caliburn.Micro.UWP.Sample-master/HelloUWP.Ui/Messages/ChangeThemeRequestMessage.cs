using Windows.UI.Xaml.Media;

namespace Caliburn.Micro.HelloUWP.Ui.Messages
{
    /// <summary>
    /// Requests the change of the application theme.
    /// </summary>
    public class ChangeThemeRequestMessage
    {
        /// <summary>
        /// Gets or sets the palette.
        /// </summary>
        /// <value>
        /// The palette.
        /// </value>
        public ThemePalette Palette { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeThemeRequestMessage"/> class.
        /// </summary>
        /// <param name="palette">The palette.</param>
        public ChangeThemeRequestMessage(ThemePalette palette)
        {
            this.Palette = palette;
        }
    }

    /// <summary>
    /// A Collection of brushes building a color theme.
    /// </summary>
    public class ThemePalette
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
    }
}
