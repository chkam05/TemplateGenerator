using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateGenerator.Data.Base;
using static System.Net.WebRequestMethods;

namespace TemplateGenerator.Data.Templates
{
    public class TemplateDataModel : BaseDataModel
    {

        //  VARIABLES

        private string _catalogPath;
        private TemplateConfig _templateConfig;

        private ObservableCollection<string> _files;
        private ObservableCollection<CustomKeyValuePair<string, string>> _keywords;


        //  GETTERS & SETTERS

        public string CatalogPath
        {
            get => _catalogPath;
            private set
            {
                _catalogPath = value;
                OnPropertyChanged(nameof(CatalogPath));
                OnPropertyChanged(nameof(TemplateName));
            }
        }

        public string TemplateName
        {
            get => Path.GetFileNameWithoutExtension(_catalogPath);
        }

        private TemplateConfig TemplateConfig
        {
            get => _templateConfig;
            set
            {
                _templateConfig = value;

                Files = new ObservableCollection<string>(_templateConfig.Files);
                Keywords = new ObservableCollection<CustomKeyValuePair<string, string>>(_templateConfig.Keywords.Select(
                    k => new CustomKeyValuePair<string, string>(k, string.Empty)));
            }
        }

        public ObservableCollection<string> Files
        {
            get => _files;
            set
            {
                _files = value;
                _files.CollectionChanged += (s,e) => { OnPropertyChanged(nameof(Files)); };
                OnPropertyChanged(nameof(Files));
            }
        }

        public ObservableCollection<CustomKeyValuePair<string, string>> Keywords
        {
            get => _keywords;
            set
            {
                _keywords = value;
                _keywords.CollectionChanged += (s, e) => { OnPropertyChanged(nameof(Keywords)); };
                OnPropertyChanged(nameof(Keywords));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> TemplateDataModel class constructor. </summary>
        /// <param name="catalogPath"> Template catalog path. </param>
        public TemplateDataModel(string catalogPath, TemplateConfig templateConfig)
        {
            CatalogPath = catalogPath;
            TemplateConfig = templateConfig;
        }

        #endregion CLASS METHODS

    }
}
