using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateGenerator.Data.Base;
using TemplateGenerator.Utilities;

namespace TemplateGenerator.Data.Templates
{
    public class TemplatesManager : BaseDataModel
    {

        //  CONST

        private const string TEMPLATE_CONFIG_NAME = "template.json";
        private const string TEMPLATES_PATH = "Templates";


        //  VARIABLES

        private static TemplatesManager? _instance;
        private static object _instnaceLock = new object();

        private string _appPath;
        private string _targetDirectory;

        private ObservableCollection<LanguageDataModel> _languageTemplates;
        private LanguageDataModel? _selectedLanguageTemplate;
        private TemplateDataModel? _selectedTemplate;


        //  GETTERS & SETTERS

        public static TemplatesManager Instance
        {
            get
            {
                lock (_instnaceLock)
                {
                    if (_instance == null)
                        _instance = new TemplatesManager();

                    return _instance;
                }
            }
        }

        public string AppPath
        {
            get => _appPath;
            set
            {
                _appPath = value;
                OnPropertyChanged(nameof(AppPath));
            }
        }

        public string TargetDirectory
        {
            get => _targetDirectory;
            set
            {
                _targetDirectory = value;
                OnPropertyChanged(nameof(TargetDirectory));
            }
        }

        public ObservableCollection<LanguageDataModel> LanguageTemplates
        {
            get => _languageTemplates;
            set
            {
                _languageTemplates = value;
                _languageTemplates.CollectionChanged += (s, e) => { OnPropertyChanged(nameof(LanguageTemplates)); };
                OnPropertyChanged(nameof(LanguageTemplates));
            }
        }

        public LanguageDataModel? SelectedLanguageTemplate
        {
            get => _selectedLanguageTemplate;
            set
            {
                _selectedLanguageTemplate = value;
                OnPropertyChanged(nameof(SelectedLanguageTemplate));
            }
        }

        public TemplateDataModel? SelectedTemplate
        {
            get => _selectedTemplate;
            set
            {
                _selectedTemplate = value;
                OnPropertyChanged(nameof(SelectedTemplate));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Private TemplatesManager class constructor. </summary>
        private TemplatesManager()
        {
            _appPath = ApplicationHelper.GetApplicationPath();
            _targetDirectory = string.Empty;
            _languageTemplates = new ObservableCollection<LanguageDataModel>();

            ScanTemplates();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Initialize TemplatesManager singleton instance. </summary>
        /// <param name="targetDirectory"> Target directory. </param>
        public static void Initialize(string targetDirectory)
        {
            lock (_instnaceLock)
            {
                if (_instance == null)
                {
                    _instance = new TemplatesManager()
                    {
                        TargetDirectory = targetDirectory
                    };
                }
                else
                {
                    _instance.TargetDirectory = targetDirectory;
                }
            }
        }

        #endregion CLASS METHODS

        #region GENERATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Generate template. </summary>
        /// <param name="errorMessage"> Output generator error message. </param>
        /// <returns> True - template generation complete successfully; False - otherwise. </returns>
        public bool Generate(out string? errorMessage)
        {
            if (!Directory.Exists(TargetDirectory))
            {
                errorMessage = "Invalid target directory.";
                return false;
            }

            if (SelectedTemplate?.Files == null || !SelectedTemplate.Files.Any())
            {
                errorMessage = "No files in template to generate.";
                return false;
            }

            foreach (var file in SelectedTemplate.Files)
            {
                var filePath = Path.Combine(SelectedTemplate.CatalogPath, file);
                var targetFilePath = Path.Combine(TargetDirectory, file);

                if (!File.Exists(filePath))
                {
                    errorMessage = $"File \"{filePath}\" not found.";
                    return false;
                }

                try
                {
                    var fileContent = File.ReadAllText(filePath);

                    foreach (var kvp in SelectedTemplate.Keywords)
                    {
                        if (!string.IsNullOrEmpty(kvp.Key))
                        {
                            var key = $"{{{kvp.Key}}}";
                            var value = kvp.Value ?? string.Empty;

                            fileContent = fileContent.Replace(key, value);
                            targetFilePath = targetFilePath.Replace(key, value);
                        }
                    }

                    File.WriteAllText(targetFilePath, fileContent);
                }
                catch (Exception exc)
                {
                    errorMessage = exc.Message;
                    return false;
                }
            }

            errorMessage = null;
            return true;
        }

        #endregion GENERATE METHODS

        #region MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Clear templates. </summary>
        public void ClearTemplates()
        {
            SelectedTemplate = null;
            SelectedLanguageTemplate = null;
            LanguageTemplates.Clear();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Scan templates. </summary>
        public void ScanTemplates()
        {
            var templatesPath = Path.Join(AppPath, TEMPLATES_PATH);

            if (!Directory.Exists(templatesPath))
                Directory.CreateDirectory(templatesPath);

            ClearTemplates();

            //  Scan each language code catalog.
            foreach (var languageCatalogName in Directory.GetDirectories(templatesPath))
            {
                var languagePath = Path.Combine(templatesPath, languageCatalogName);
                var languageDataModel = new LanguageDataModel(languagePath);

                //  Scan each template catalog.
                foreach (var templateCatalogName in Directory.GetDirectories(languagePath))
                {
                    var templatePath = Path.Combine(languagePath, templateCatalogName);
                    var templateConfigPath = Path.Combine(templatePath, TEMPLATE_CONFIG_NAME);
                    
                    if (File.Exists(templateConfigPath))
                    {
                        var templateConfigContent = File.ReadAllText(templateConfigPath);
                        var templateConfig = JsonConvert.DeserializeObject<TemplateConfig>(templateConfigContent);

                        if (templateConfig != null)
                            languageDataModel.Templates.Add(new TemplateDataModel(templatePath, templateConfig));
                    }
                }

                LanguageTemplates.Add(languageDataModel);
            }

            SelectedLanguageTemplate = LanguageTemplates.FirstOrDefault();
            SelectedTemplate = SelectedLanguageTemplate?.Templates?.FirstOrDefault();
        }

        #endregion MANAGEMENT METHODS

    }
}
