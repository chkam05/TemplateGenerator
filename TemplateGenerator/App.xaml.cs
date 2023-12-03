using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TemplateGenerator.Data.Configuration;
using TemplateGenerator.Data.Templates;
using TemplateGenerator.Utilities;

namespace TemplateGenerator
{
    public partial class App : Application
    {

        //  METHODS

        #region APPLICATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Application startup method. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Startup Event Arguments. </param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var args = ApplicationHelper.ReadArguments(e.Args);
            string targetDirectory = ApplicationHelper.GetApplicationPath();

            if (args.TryGetValue("path", out string? tempTargetDir) && !string.IsNullOrEmpty(tempTargetDir))
                targetDirectory = tempTargetDir;
            else if (args.TryGetValue("p", out tempTargetDir) && !string.IsNullOrEmpty(tempTargetDir))
                targetDirectory = tempTargetDir;

            TemplatesManager.Initialize(targetDirectory);
        }

        #endregion APPLICATION METHODS

    }
}
