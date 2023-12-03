# TemplateGenerator

A tool for programmers, allowing place predefined codes (templates) in project, modifying certain keywords on the fly.

![Screen form application (screen.png)](screen.png)

NOTICE!: Sample templates are placed under catalog SampleTemplates.  

## How it works

The application runs on a specific directory structure that is placed next to the application runtime file.

```
📂 Templates
   📂 LanguageCatalog (e.g.: CSharp)
      📂 TemplateCatalog (e.g.: AspNetCoreService)
         📄 template.json
         📄 {ClassName}Service.cs
         📄 I{ClassName}Service.cs
         📄 {ClassName}ServiceConfig.cs
         📄 {ClassName}ServiceExtension.cs
      📂 NextTemplateCatalog
	  ...
   📂 NextLanguageCatalog
   ...
```

- LanguageCatalog - Responsible for templates for a specific programming language.  
- TemplateCatalog - Responsible for specified template.  
- template.json - Responsible for template configuration.

### template.json file:

```
{
  "files": [
    "{ClassName}Service.cs",
    "I{ClassName}Service.cs",
    "{ClassName}ServiceConfig.cs",
    "{ClassName}ServiceExtension.cs"
  ],
  "keywords": [
    "ClassName",
    "Namespace"
  ]
}
```

- files - This node is responsible for list of files that will be copied to the project for which the tool was launched.  
- keywords - This node is responsible for keywords that should be entered into the template files, which will then be replaced with phrases entered in the application.

### Example usage in template code:

``` CSharp
{AccessLevel} class {ClassName}Service
{
	/// <summary> {ClassName}Service class constructor. </summary>
    public {ClassName}Service()
	{
	    //
	}
}
```

In this example, the keywords should include: AccessLevel and ClassName, that will be replaced by phrases entered in application.  

### Starting application:

This application can be used in Visual Studio, as external tools. To set up this as external tool, You should:  
1. Click on: Tools > External tools...  
2. Select add  
3. In title, type: TemplatesGenerator
4. In Command, place path for the application. E.g: C:\Tools\TemplatesGenerator\TemplateGenerator.exe
5. In Arguments, place: "-path $(ItemDir)", when You click Generate, files will be generate in that $(ItemDir) directory.

### Additional buttons:

- Generate - after clicking Generate, template files will be preprocessed, and copied to directory shown below in application window.  
- Change Directory - allows to change the directory to which the template files are to be copied.  
- Refresh - reload tempaltes.  
