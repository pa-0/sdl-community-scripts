using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using Sdl.Core.Globalization;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.ProjectAutomation.Core;
using Sdl.ProjectAutomation.FileBased;

namespace AddProjectOrigin_IconPath
{
	// Sample code to set the ProjectOrigin and IconPath on ProjectInfo.cs
	// The ProjectOrigin changes the ProjectType which can be checked within Projects Controller, Project Type column (by default, the Project Type is Studio project)
	[ApplicationInitializer]
	public class MyCustomTradosStudio:IApplicationInitializer
    {
	    public void Execute()
	    {
		    var iconPath = GetIconPath();

			var projectInfo = new ProjectInfo
		    {
			    Name = "ProjectOriginIconSample",
			    SourceLanguage = new Language(CultureInfo.GetCultureInfo("en-US")), //import Sdl.core.globalization.dll 
			    TargetLanguages = new[]
			    {
				    new Language(CultureInfo.GetCultureInfo("de-DE")),
				    new Language(CultureInfo.GetCultureInfo("fr-FR"))
			    },
				// file path where you want to save the project
				LocalProjectFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Studio 2021\Projects\ProjectOriginIconSample"),
				
				// update with the needed ProjectOrigin which will be displayed at Project Type column, in Projects controller
				ProjectOrigin = "Star Transit",
				// update with the needed icon path, the phisical path is needed, so Studio will know from where to load the icon
				IconPath = iconPath
				//IconPath = @"C:\Repo_GitHubSdlCommunity\Code samples\AddProjectOrigin_IconPath\Resources\icon.ico" 
			};

		    //import Sdl.ProjectAutomation.FileBased
			var fileBasedProject = new FileBasedProject(projectInfo);

		    // HERE YOU NEED TO ADD THE PATH FOR FILES YOU WANT TO INCLUDE IN YOUT PROJECT
		    var filesPath = new[] { @"C:\TradosStudio_Plugins\TestDocuments\Test.docx" };

		    //add files to project
		    var projectFiles = fileBasedProject.AddFiles(filesPath);
		    //we need to run automatic task to create the project in studio
		    fileBasedProject.RunAutomaticTask(projectFiles.GetIds(), AutomaticTaskTemplateIds.Scan);
		    var taskSequence = fileBasedProject.RunDefaultTaskSequence(projectFiles.GetIds());
		    if (taskSequence.Status == TaskStatus.Completed)
		    {
			    //project was created succesfully
		    }
		    else
		    {
			    //here we'll see the erors
		    }
		    fileBasedProject.Save();
	    }

		// Write the icon to the Plugins\Unpacked folder and use the icon's path from that folder in order to set the project's IconPath
	    public string GetIconPath()
		{ 
		    var assemblyPath = Assembly.GetExecutingAssembly().Location;
		    var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
		    var targetPath = assemblyPath.Remove(assemblyPath.Length - assemblyName.Length - 4);
		    targetPath = targetPath + "icon.ico";

		    using (var fs = new FileStream(targetPath, FileMode.Create))
		    {
			    PluginResources.icon.Save(fs);
		    }
			return targetPath;
	    }
	}
}
