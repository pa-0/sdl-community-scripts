using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi;

namespace ProjectInformationSample
{
	[ApplicationInitializer]
    class MyCustomTradosStudio : IApplicationInitializer
    {
	    public void Execute()
	    {
		    var projectsController = GetProjectController();
		    var allProjects = projectsController?.GetAllProjects();
		    if (allProjects != null)
		    {
			    foreach (var proj in allProjects)
			    {
				    // Retrieve the needed information from the project
				    var projectInfo = proj.GetProjectInfo();
				    var status = projectInfo?.Status; // the current status of the project
					var publicationStatus = projectInfo?.PublicationStatus; // the publication status of the project
					var projectType = projectInfo?.ProjectType; // the type of the project
			    }
		    }
	    }

		private ProjectsController GetProjectController()
		{
			return SdlTradosStudio.Application.GetController<ProjectsController>();
		}
	}
}