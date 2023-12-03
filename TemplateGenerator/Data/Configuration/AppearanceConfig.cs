﻿using chkam05.Tools.ControlsEx.Colors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TemplateGenerator.Data.Base;

namespace TemplateGenerator.Data.Configuration
{
    public class AppearanceConfig : BaseDataModel
    {

        //  CONST

        private static readonly double LUMINANCE_R = 0.299;
        private static readonly double LUMINANCE_G = 0.587;
        private static readonly double LUMINANCE_B = 0.114;

        private static readonly int INACTIVE_FACTOR = 15;
        private static readonly int MOUSE_OVER_FACTOR = 15;
        private static readonly int PRESSED_FACTOR = 10;
        private static readonly int SELECTED_FACTOR = 5;

        public static readonly Color ACCENT_COLOR = Color.FromArgb(255, 0, 120, 215);
        public static readonly Color DARK_THEME_COLOR = Color.FromArgb(255, 36, 36, 36);
        public static readonly Color LIGHT_THEME_COLOR = Color.FromArgb(255, 219, 219, 219);


        //  VARIABLES

        private static AppearanceConfig? _instance;
        private static object _instanceLock = new object();

        private Brush _accentColorBrush;
        private Brush _accentForegroundBrush;
        private Brush _accentMouseOverBrush;
        private Brush _accentPressedBrush;
        private Brush _accentSelectedBrush;
        private Brush _themeBackgroundBrush;
        private Brush _themeForegroundBrush;
        private Brush _themeShadeBackgroundBrush;
        private Brush _themeMouseOverBrush;
        private Brush _themePressedBrush;
        private Brush _themeSelectedBrush;


        //  GETTERS & SETTERS

        public static AppearanceConfig Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                        _instance = new AppearanceConfig();

                    return _instance;
                }
            }
        }

        public Brush AccentColorBrush
        {
            get => _accentColorBrush;
            set
            {
                _accentColorBrush = value;
                OnPropertyChanged(nameof(AccentColorBrush));
            }
        }

        public Brush AccentForegroundBrush
        {
            get => _accentForegroundBrush;
            set
            {
                _accentForegroundBrush = value;
                OnPropertyChanged(nameof(AccentForegroundBrush));
            }
        }

        public Brush AccentMouseOverBrush
        {
            get => _accentMouseOverBrush;
            set
            {
                _accentMouseOverBrush = value;
                OnPropertyChanged(nameof(AccentMouseOverBrush));
            }
        }

        public Brush AccentPressedBrush
        {
            get => _accentPressedBrush;
            set
            {
                _accentPressedBrush = value;
                OnPropertyChanged(nameof(AccentPressedBrush));
            }
        }

        public Brush AccentSelectedBrush
        {
            get => _accentSelectedBrush;
            set
            {
                _accentSelectedBrush = value;
                OnPropertyChanged(nameof(AccentSelectedBrush));
            }
        }

        public Brush ThemeBackgroundBrush
        {
            get => _themeBackgroundBrush;
            set
            {
                _themeBackgroundBrush = value;
                OnPropertyChanged(nameof(ThemeBackgroundBrush));
            }
        }

        public Brush ThemeForegroundBrush
        {
            get => _themeForegroundBrush;
            set
            {
                _themeForegroundBrush = value;
                OnPropertyChanged(nameof(ThemeForegroundBrush));
            }
        }

        public Brush ThemeShadeBackgroundBrush
        {
            get => _themeShadeBackgroundBrush;
            set
            {
                _themeShadeBackgroundBrush = value;
                OnPropertyChanged(nameof(ThemeShadeBackgroundBrush));
            }
        }

        public Brush ThemeMouseOverBrush
        {
            get => _themeMouseOverBrush;
            set
            {
                _themeMouseOverBrush = value;
                OnPropertyChanged(nameof(ThemeMouseOverBrush));
            }
        }

        public Brush ThemePressedBrush
        {
            get => _themePressedBrush;
            set
            {
                _themePressedBrush = value;
                OnPropertyChanged(nameof(ThemePressedBrush));
            }
        }

        public Brush ThemeSelectedBrush
        {
            get => _themeSelectedBrush;
            set
            {
                _themeSelectedBrush = value;
                OnPropertyChanged(nameof(ThemeSelectedBrush));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Private AppearanceConfig class constructor. </summary>
        private AppearanceConfig()
        {
            Setup();
        }

        #endregion CLASS METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup. </summary>
        private void Setup()
        {
            var accentColor = ACCENT_COLOR;
            var accentAhslColor = AHSLColor.FromColor(accentColor);
            var accentForegroundColor = GetForegroundContrastedColor(accentColor);

            var accentMouseOverColor = UpdateAHSLColor(accentAhslColor,
                lightness: accentAhslColor.L + MOUSE_OVER_FACTOR).ToColor();

            var accentPressedColor = UpdateAHSLColor(accentAhslColor,
                lightness: accentAhslColor.L - PRESSED_FACTOR).ToColor();

            var accentSelectedColor = UpdateAHSLColor(accentAhslColor,
                lightness: accentAhslColor.L - SELECTED_FACTOR).ToColor();

            AccentColorBrush = new SolidColorBrush(accentColor);
            AccentForegroundBrush = new SolidColorBrush(accentForegroundColor);
            AccentMouseOverBrush = new SolidColorBrush(accentMouseOverColor);
            AccentPressedBrush = new SolidColorBrush(accentPressedColor);
            AccentSelectedBrush = new SolidColorBrush(accentSelectedColor);

            var backgroundColor = Colors.Black;
            var foregroundColor = Colors.White;
            var shadeBackgroundColor = AppearanceConfig.DARK_THEME_COLOR;

            var backgroundAhslColor = AHSLColor.FromColor(backgroundColor);

            var themeMouseOverColor = UpdateAHSLColor(backgroundAhslColor,
                lightness: backgroundAhslColor.S > 50 
                    ? backgroundAhslColor.S + MOUSE_OVER_FACTOR 
                    : backgroundAhslColor.L - MOUSE_OVER_FACTOR,
                saturation: 0).ToColor();

            var themePressedColor = UpdateAHSLColor(backgroundAhslColor,
                lightness: backgroundAhslColor.S > 50
                    ? backgroundAhslColor.S - PRESSED_FACTOR
                    : backgroundAhslColor.L + PRESSED_FACTOR,
                saturation: 0).ToColor();

            var themeSelectedColor = UpdateAHSLColor(backgroundAhslColor,
                lightness: backgroundAhslColor.S > 50
                    ? backgroundAhslColor.S - SELECTED_FACTOR
                    : backgroundAhslColor.L + SELECTED_FACTOR,
                saturation: 0).ToColor();

            ThemeBackgroundBrush = new SolidColorBrush(backgroundColor);
            ThemeForegroundBrush = new SolidColorBrush(foregroundColor);
            ThemeShadeBackgroundBrush = new SolidColorBrush(shadeBackgroundColor);
            ThemeMouseOverBrush = new SolidColorBrush(themeMouseOverColor);
            ThemePressedBrush = new SolidColorBrush(themePressedColor);
            ThemeSelectedBrush = new SolidColorBrush(themeSelectedColor);
        }

        #endregion SETUP METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get foreground contrasted color. </summary>
        /// <param name="accentColor"> Accent color. </param>
        /// <returns> Contrasted foreground color. </returns>
        public static Color GetForegroundContrastedColor(Color accentColor)
        {
            double luminance = (LUMINANCE_R * accentColor.R + LUMINANCE_G * accentColor.G
                + LUMINANCE_B * accentColor.B) / 255;

            if (luminance > 0.5)
                return Colors.Black;
            else
                return Colors.White;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update AHSL color. </summary>
        /// <param name="ahslColor"> AHSL color. </param>
        /// <param name="alpha"> Alpha factor. </param>
        /// <param name="hue"> Hue factor. </param>
        /// <param name="saturation"> Saturation factor. </param>
        /// <param name="lightness"> Lightness factor. </param>
        /// <returns> Updated AHSL color. </returns>
        private static AHSLColor UpdateAHSLColor(AHSLColor ahslColor, byte? alpha = null,
            int? hue = null, int? saturation = null, int? lightness = null)
        {
            return new AHSLColor(
                alpha.HasValue ? alpha.Value : ahslColor.A,
                hue.HasValue ? hue.Value : ahslColor.H,
                saturation.HasValue ? saturation.Value : ahslColor.S,
                lightness.HasValue ? lightness.Value : ahslColor.L);
        }

        #endregion UTILITY METHODS

    }
}
