using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.DefaultLocations;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.Desktop.IntegrationApi.Interfaces;
using Sdl.ProjectAutomation.Core;
using Sdl.ProjectAutomation.Settings;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.Events;

namespace ProjectController
{
	[ApplicationInitializer]
	public class ProjectControllerMethods : IApplicationInitializer
	{
		public void Execute()
		{
			//files controller
			//var filesController = SdlTradosStudio.Application.GetController<FilesController>();
			//var activeProjectFromFiles = filesController.CurrentProject;

		}
	}


	[RibbonGroup("Test", Name = "Test project icon")]
	[RibbonGroupLayout(LocationByType = typeof(StudioDefaultRibbonTabs.AddinsRibbonTabLocation))]
	public class ProjectTemplateRibbonGroup : AbstractRibbonGroup
	{
	}

	[Action("TestProjIconAction", Icon = "", Name = "Test icon",
		Description = "")]
	[ActionLayout(typeof(ProjectTemplateRibbonGroup), 10, DisplayType.Large)]
	public class ProjectAction : AbstractAction
	{
		protected override void Execute()
		{
			//projects controler open file view for selected language
			var eventAggregator = SdlTradosStudio.Application.GetService<IStudioEventAggregator>();
			eventAggregator.GetEvent<SegmentsMergedEvent>().Subscribe(SegmentsMerged);
			//eventAggregator.GetEvent<SegmentSplitEvent>().Subscribe(SegmentSplit);

			//var projectsController = SdlTradosStudio.Application.GetController<ProjectsController>();
			//var activeProject = projectsController?.CurrentProject;

			//var settings=activeProject?.GetSettings();
			//var tmSettings = settings.GetSettingsGroup<TranslationMemorySettings>();
			//tmSettings.AlignmentPenalty.Value = 10;

			//activeProject?.UpdateSettings(settings);
			//activeProject?.Save();
			//eventAggregator.Publish(new ChangeSourceContentSettingsEvent(activeProject, false, false, true));
			//var targetLanguages = activeProject?.GetProjectInfo().TargetLanguages;
			//if (targetLanguages?.Length >= 2)
			//{
			//	eventAggregator.Publish(new OpenProjectForSelectedLanguageEvent(activeProject, targetLanguages[1]));
			//	//to open just a project without target language
			//	//eventAggregator.Publish(new OpenProjectForSelectedLanguageEvent(activeProject));
			//}
		}


		//private void SegmentSplit(SegmentSplitEvent e)
		//{
		//	var document = e.Document;
		//	var originalSegId = e.OriginalSegmentId;
		//	var firstNewSegmentId = e.FirstNewSegmentId;
		//	var secondNewSegmentId = e.SecondNewSegmentId;
		//	var paragraphUnit = e.ParagraphUnitId;
		//}

		private void SegmentsMerged(SegmentsMergedEvent e)
		{
			var document = e.Document;
			var paragraphUnit = e.ParagraphUnitId;
			var newSegmentId = e.NewSegmentId;
			var oldSegmentIds = e.OldSegmentIds;
		}
	}
}