using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.InternalMessages;
using chkam05.Tools.ControlsEx.WindowsEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TemplateGenerator.Data.Templates;
using TemplateGenerator.Utilities;

namespace TemplateGenerator.Windows
{
    public partial class MainWindow : WindowEx
    {

        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> MainWindow class constructor. </summary>
        public MainWindow() : base()
        {
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking on generate button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void GenerateButtonEx_Click(object sender, RoutedEventArgs e)
        {
            string? errorMessage = null;
            var templatesManager = TemplatesManager.Instance;

            if (!templatesManager.Generate(out errorMessage))
            {
                var im = InternalMessageEx.CreateErrorMessage(internalMessageExContainer,
                    "Generation failed", errorMessage);

                InternalMessagesHelper.SetInternalMessageAppearance(im);

                internalMessageExContainer.ShowMessage(im);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking on change target directory button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void ChangeTargetDirectoryButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var templatesManager = TemplatesManager.Instance;
            var startPath = Directory.Exists(templatesManager.TargetDirectory)
                ? templatesManager.TargetDirectory : Environment.GetEnvironmentVariable("USERPROFILE");

            var im = FilesSelectorInternalMessageEx.CreateSelectDirectoryInternalMessageEx(
                internalMessageExContainer, "Select target directory");

            im.InitialDirectory = startPath;

            im.OnClose += (s, e) =>
            {
                if (e.Result == InternalMessageResult.Ok)
                {
                    if (!Directory.Exists(e.FilePath))
                        Directory.CreateDirectory(e.FilePath);

                    templatesManager.TargetDirectory = e.FilePath;
                }
            };

            InternalMessagesHelper.SetFilesSelectorInternalMessageAppearance(im);

            internalMessageExContainer.ShowMessage(im);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking on refresh button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void RefreshButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var templatesManager = TemplatesManager.Instance;
            templatesManager.ScanTemplates();
        }

        #endregion INTERACTION METHODS

    }
}
