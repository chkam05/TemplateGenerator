using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TemplateGenerator.Components
{
    public class SettingsOptionControl : Control, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
            nameof(Content),
            typeof(object),
            typeof(SettingsOptionControl),
            new PropertyMetadata(null));

        public static readonly DependencyProperty IconKindProperty = DependencyProperty.Register(
            nameof(IconKind),
            typeof(PackIconKind),
            typeof(SettingsOptionControl),
            new PropertyMetadata(PackIconKind.None));

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(SettingsOptionControl),
            new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
            nameof(Description),
            typeof(string),
            typeof(SettingsOptionControl),
            new PropertyMetadata(string.Empty));


        //  EVENTS

        public event PropertyChangedEventHandler? PropertyChanged;


        //  GETTERS & SETTERS

        public object Content
        {
            get => GetValue(ContentProperty);
            set
            {
                SetValue(ContentProperty, value);
                OnPropertyChanged(nameof(Content));
            }
        }

        public PackIconKind IconKind
        {
            get => (PackIconKind)GetValue(IconKindProperty);
            set
            {
                SetValue(IconKindProperty, value);
                OnPropertyChanged(nameof(CornerRadius));
            }
        }

        public string Title
        {
            get => (string)GetValue(DescriptionProperty);
            set
            {
                SetValue(DescriptionProperty, value);
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Description
        {
            get => (string)GetValue(TitleProperty);
            set
            {
                SetValue(TitleProperty, value);
                OnPropertyChanged(nameof(Description));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Static SettingsOptionControl class constructor. </summary>
        static SettingsOptionControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SettingsOptionControl),
                new FrameworkPropertyMetadata(typeof(SettingsOptionControl)));
        }

        #endregion CLASS METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler event. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

    }
}
