using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TemplateGenerator.Utilities
{
    public static class ApplicationHelper
    {

        //  METHODS

        #region ARGUMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Read application arguments. </summary>
        /// <param name="args"> Array of arguments. </param>
        /// <returns> Dictionary arguments. </returns>
        public static Dictionary<string, string?> ReadArguments(string[]? args)
        {
            string? key = null;
            int keyIndex = 0;

            var result = new Dictionary<string, string?>();

            if (args?.Any() ?? false)
            {
                foreach (var arg in args)
                {
                    if (arg.StartsWith('-') || arg.StartsWith('/'))
                    {
                        if (!string.IsNullOrEmpty(key) && !result.ContainsKey(key))
                            result[key] = null;

                        key = arg.Substring(1).ToLower();
                        continue;
                    }

                    if (string.IsNullOrEmpty(key))
                    {
                        while (result.ContainsKey($"arg{keyIndex}"))
                            keyIndex++;

                        result.Add($"arg{keyIndex}", arg);
                        keyIndex++;
                    }
                    else
                    {
                        result.Add(key, arg);
                        key = null;
                    }
                }
            }

            return result;
        }

        #endregion ARGUMENT METHODS

        #region PATHS

        //  --------------------------------------------------------------------------------
        /// <summary> Get application location path. </summary>
        /// <returns> Application location path. </returns>
        public static string GetApplicationPath()
        {
            var assembly = Assembly.GetEntryAssembly();

            if (!string.IsNullOrEmpty(assembly?.Location))
                return Path.GetDirectoryName(assembly.Location);

            return AppDomain.CurrentDomain.BaseDirectory;
        }

        #endregion PATHS

    }
}
