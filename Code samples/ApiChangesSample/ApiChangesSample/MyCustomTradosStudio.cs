using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.DefaultLocations;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.ProjectAutomation.FileBased;
using Sdl.TranslationStudioAutomation.IntegrationApi.Events;
using Sdl.TranslationStudioAutomation.IntegrationApi.Presentation.DefaultLocations;

namespace ApiChangesSample
{

	[RibbonGroup("CodeSampleRibbon", Name = "Api Samples", ContextByType = typeof(ProjectsController))]
	[RibbonGroupLayout(LocationByType = typeof(StudioDefaultRibbonTabs.AddinsRibbonTabLocation))]
	public class SamplesRibbon : AbstractRibbonGroup
	{
	}

	[Action("CodeSampleAction", Icon = "", Name = "",
		Description = "")]
	[ActionLayout(typeof(SamplesRibbon), 10, DisplayType.Large)]
	public class MyCustomTradosStudio : AbstractAction
	{
		protected override void Execute()
		{
			var eventAggregator = SdlTradosStudio.Application.GetService<IStudioEventAggregator>();
			var projectsController = SdlTradosStudio.Application.GetController<ProjectsController>();
			//OpenProjectForLanguage(eventAggregator);
			ChangeSourceContentSettings(eventAggregator, projectsController.CurrentProject);
		}

		private void OpenProjectForLanguage(IStudioEventAggregator eventAggregator)
		{
			var projectsController = SdlTradosStudio.Application.GetController<ProjectsController>();
			var activeProject = projectsController?.CurrentProject;
			if (activeProject is null) return;
			var targetLanguage = activeProject.GetProjectInfo().TargetLanguages[0]; // for this example we'll use the first language from list
			eventAggregator.Publish(new OpenProjectForSelectedLanguageEvent(activeProject, targetLanguage));
		}

		private void ChangeSourceContentSettings(IStudioEventAggregator eventAggregator, FileBasedProject activeProject)
		{
			eventAggregator.Publish(new ChangeSourceContentSettingsEvent(activeProject, true, true,true));
		}
	}

}
