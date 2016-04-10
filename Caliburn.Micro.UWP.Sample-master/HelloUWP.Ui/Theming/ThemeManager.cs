using System;
using System.Globalization;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Caliburn.Micro.HelloUWP.Ui.Theming
{
    public static class ThemeManager
    {
        #region Brush collections

        /// <summary>
        /// The background keys
        /// </summary>
        private static readonly string[] backgroundKeys = new[]
        {
            "ApplicationPageBackgroundThemeBrush"
        };

        /// <summary>
        /// The brush keys
        /// </summary>
        private static readonly string[] brushKeys = new[]
        {
            //wp

            "PhoneHighContrastSelectedForegroundThemeBrush",

            "JumpListDefaultEnabledBackground", "ListPickerFlyoutPresenterSelectedItemForegroundThemeBrush",

            "ProgressBarBackgroundThemeBrush",

            "PhoneAccentBrush",

            "PhoneRadioCheckBoxPressedBrush",

            "TextSelectionHighlightColorThemeBrush",

            "ButtonPressedBackgroundThemeBrush",

            "CheckBoxPressedBackgroundThemeBrush",

            "ComboBoxHighlightedBorderThemeBrush",

            "ComboBoxItemSelectedForegroundThemeBrush",

            "ComboBoxPressedBackgroundThemeBrush",

            "HyperlinkPressedForegroundThemeBrush",

            "ListBoxItemSelectedBackgroundThemeBrush",

            "ListBoxItemSelectedPointerOverBackgroundThemeBrush",

            "ListViewItemCheckHintThemeBrush",

            "ListViewItemCheckSelectingThemeBrush",

            "ListViewItemDragBackgroundThemeBrush",

            "ListViewItemSelectedBackgroundThemeBrush",

            "ListViewItemSelectedPointerOverBackgroundThemeBrush",

            "ListViewItemSelectedPointerOverBorderThemeBrush",

            "ProgressBarForegroundThemeBrush",

            "ProgressBarIndeterminateForegroundThemeBrush",

            "SliderTrackDecreaseBackgroundThemeBrush",

            "SliderTrackDecreasePointerOverBackgroundThemeBrush",

            "SliderTrackDecreasePressedBackgroundThemeBrush",

            "ToggleSwitchCurtainBackgroundThemeBrush",

            "ToggleSwitchCurtainPointerOverBackgroundThemeBrush",

            "ToggleSwitchCurtainPressedBackgroundThemeBrush",

            "LoopingSelectorSelectionBackgroundThemeBrush"
        };

        /// <summary>
        /// The accent keys
        /// </summary>
        private static readonly string[] accentKeys = new[]
        {
            // Selection highlight brushes
            "ComboBoxItemSelectedBackgroundThemeBrush",
            "TextBoxBorderThemeBrush",
            "ComboBoxSelectedBackgroundThemeBrush",
            "IMECandidateSelectedBackgroundThemeBrush",
            "ListBoxItemSelectedBackgroundThemeBrush",
            "ListViewItemSelectedBackgroundThemeBrush",
            "SearchBoxButtonBackgroundThemeBrush",
            "SearchBoxHitHighlightForegroundThemeBrush",
            "TextSelectionHighlightColorThemeBrush",
            "ComboBoxBorderThemeBrush",

            // System brushes
            "SystemControlBackgroundAccentBrush",
            "SystemControlDisabledAccentBrush",
            "SystemControlForegroundAccentBrush",
            "SystemControlHighlightAccentBrush",
            "SystemControlHighlightAltAccentBrush",
            "SystemControlHighlightAltListAccentHighBrush",
            "SystemControlHighlightAltListAccentLowBrush",
            "SystemControlHighlightAltListAccentMediumBrush",
            "SystemControlHighlightListAccentHighBrush",
            "SystemControlHighlightListAccentLowBrush",
            "SystemControlHighlightListAccentMediumBrush",
            "SystemControlHyperlinkTextBrush",
            "ContentDialogBorderThemeBrush",
            "JumpListDefaultEnabledBackground"
        };

        #endregion

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            // Primary Color
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey("PrimaryColor"))
            {
                ApplicationData.Current.LocalSettings.Values["PrimaryColor"] = ((SolidColorBrush)Application.Current.Resources["ApplicationPageBackgroundThemeBrush"]).Color.ToString();
            }
            SetPrimaryBackgroundColor(GetColorFromHexCode(ApplicationData.Current.LocalSettings.Values["PrimaryColor"].ToString()));

            // Secondary Color
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey("SecondaryColor"))
            {
                ApplicationData.Current.LocalSettings.Values["SecondaryColor"] = ((SolidColorBrush)Application.Current.Resources["ApplicationPageBackgroundThemeBrush"]).Color.ToString();
            }
            SetSecondaryColor(GetColorFromHexCode(ApplicationData.Current.LocalSettings.Values["SecondaryColor"].ToString()));

            // Accent Color
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey("AccentColor"))
            {
                ApplicationData.Current.LocalSettings.Values["AccentColor"] = ((SolidColorBrush) Application.Current.Resources["SystemControlHighlightAccentBrush"]).Color.ToString();
            }
            SetAccentColor(GetColorFromHexCode(ApplicationData.Current.LocalSettings.Values["AccentColor"].ToString()));

            // Backup Accent Color
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey("BackupAccentColor"))
            {
                ApplicationData.Current.LocalSettings.Values["BackupAccentColor"] = ((SolidColorBrush)Application.Current.Resources["SystemControlHighlightAccentBrush"]).Color.ToString();
            }
            SetBackupAccentColor(GetColorFromHexCode(ApplicationData.Current.LocalSettings.Values["BackupAccentColor"].ToString()));
        }

        /// <summary>
        /// Gets the color from hexadecimal code.
        /// </summary>
        /// <param name="colorCode">The color code.</param>
        /// <returns></returns>
        private static Color GetColorFromHexCode(string colorCode)
        {
            string argb = colorCode.Replace("#", "");

            Byte a = Byte.Parse(argb.Substring(0, 2), NumberStyles.HexNumber);
            Byte r = Byte.Parse(argb.Substring(2, 2), NumberStyles.HexNumber);
            Byte g = Byte.Parse(argb.Substring(4, 2), NumberStyles.HexNumber);
            Byte b = Byte.Parse(argb.Substring(6, 2), NumberStyles.HexNumber);

            return Color.FromArgb(a, r, g, b);
        }

        /// <summary>
        /// Gets or sets the color of the primary.
        /// </summary>
        /// <value>
        /// The color of the primary.
        /// </value>
        public static Color PrimaryColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the secondary.
        /// </summary>
        /// <value>
        /// The color of the secondary.
        /// </value>
        public static Color SecondaryColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the accent.
        /// </summary>
        /// <value>
        /// The color of the accent.
        /// </value>
        public static Color AccentColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the backup accent.
        /// </summary>
        /// <value>
        /// The color of the backup accent.
        /// </value>
        public static Color BackupAccentColor { get; set; }
        
        /// <summary>
        /// Sets the color of the theme.
        /// </summary>
        /// <param name="color">The color.</param>
        public static void SetPrimaryBackgroundColor(Color color)
        {
            PrimaryColor = color;
            ApplicationData.Current.LocalSettings.Values["PrimaryColor"] = color.ToString();

            foreach (var brushKey in backgroundKeys)
            {
                if (Application.Current.Resources.ContainsKey(brushKey))
                {
                    Application.Current.Resources[brushKey] = new SolidColorBrush(color);
                }
            }
        }

        /// <summary>
        /// Sets the color of the secondary.
        /// </summary>
        /// <param name="color">The color.</param>
        public static void SetSecondaryColor(Color color)
        {
            SecondaryColor = color;
            ApplicationData.Current.LocalSettings.Values["SecondaryColor"] = color.ToString();

            //foreach (var brushKey in backgroundKeys)
            //{
            //    if (Application.Current.Resources.ContainsKey(brushKey))
            //    {
            //        Application.Current.Resources[brushKey] = new SolidColorBrush(color);
            //    }
            //}
        }

        /// <summary>
        /// Sets the accent color for the application.
        /// </summary>
        /// <param name="color">The new accent color.</param>
        public static void SetAccentColor(Color color)
        {
            AccentColor = color;
            ApplicationData.Current.LocalSettings.Values["AccentColor"] = color.ToString();

            foreach (var brushKey in accentKeys)
            {
                // Get opacity for low, medium or high contrast brushes.
                double opacity = 1.0;
                if (brushKey.Contains("Low"))
                {
                    opacity = 0.6;
                }
                else if (brushKey.Contains("Medium"))
                {
                    opacity = 0.8;
                }
                else if (brushKey.Contains("High"))
                {
                    opacity = 0.9;
                }

                if (Application.Current.Resources.ContainsKey(brushKey))
                {
                    Application.Current.Resources[brushKey] = new SolidColorBrush(color) { Opacity = opacity };
                }
            }
        }

        /// <summary>
        /// Sets the color of the backup accent.
        /// </summary>
        /// <param name="color">The color.</param>
        public static void SetBackupAccentColor(Color color)
        {
            BackupAccentColor = color;
            ApplicationData.Current.LocalSettings.Values["BackupAccentColor"] = color.ToString();

            //foreach (var brushKey in backgroundKeys)
            //{
            //    if (Application.Current.Resources.ContainsKey(brushKey))
            //    {
            //        Application.Current.Resources[brushKey] = new SolidColorBrush(color);
            //    }
            //}
        }
    }
}
