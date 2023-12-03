using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateGenerator.Data.Templates
{
    public class TemplateConfig
    {

        //  VARIABLES

        public List<string> Files { get; set; }
        public List<string> Keywords { get; set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> TemplateConfig class constructor. </summary>
        [JsonConstructor]
        public TemplateConfig(List<string>? files = null, List<string>? keywords = null)
        {
            Files = files ?? new List<string>();
            Keywords = keywords ?? new List<string>();
        }

        #endregion CLASS METHODS

    }
}
