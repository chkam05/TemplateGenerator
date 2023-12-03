using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateGenerator.Data.Base;

namespace TemplateGenerator.Data.Templates
{
    public class LanguageDataModel : BaseDataModel
    {

        //  VARIABLES

        private string _catalogPath;
        private ObservableCollection<TemplateDataModel> _templates;


        //  GETTERS & SETTERS

        public string CatalogPath
        {
            get => _catalogPath;
            private set
            {
                _catalogPath = value;
                OnPropertyChanged(nameof(CatalogPath));
                OnPropertyChanged(nameof(CatalongName));
            }
        }

        public string CatalongName
        {
            get => Path.GetFileNameWithoutExtension(CatalogPath);
        }

        public ObservableCollection<TemplateDataModel> Templates
        {
            get => _templates;
            set
            {
                _templates = value;
                _templates.CollectionChanged += (s, e) => { OnPropertyChanged(nameof(Templates)); };
                OnPropertyChanged(nameof(Templates));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> LanguageDataModel class constructor. </summary>
        /// <param name="catalogPath"> Language catalog path. </param>
        public LanguageDataModel(string catalogPath)
        {
            CatalogPath = catalogPath;
            Templates = new ObservableCollection<TemplateDataModel>();
        }

        #endregion CLASS METHODS

    }
}
