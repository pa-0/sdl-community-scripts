using System.Windows.Forms;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.Presentation.DefaultLocations;

namespace NewControllersCodeSample
{
	[RibbonGroup("Sample.WelcomeRibbonGroup", Name = "Sample_Action",
		ContextByType = typeof(WelcomeViewController))]
	[RibbonGroupLayout(LocationByType = typeof(TranslationStudioDefaultRibbonTabs.HomeRibbonTabLocation))]
	public class SampleWelcomeViewRibbonGroup : AbstractRibbonGroup
	{
	}

	[RibbonGroup("Sample.TranslationMemoriesRibbonGroup", Name = "Sample_Action",
		ContextByType = typeof(ReportsViewController))]
	[RibbonGroupLayout(LocationByType = typeof(TranslationStudioDefaultRibbonTabs.HomeRibbonTabLocation))]
	public class SampleTranslationMemoriesViewRibbonGroup : AbstractRibbonGroup
	{
	}

	[Action("Sdl.Community.SampleControllers", Name = "Sample action", Icon = "icon", Description = "Sample Action")]
	[ActionLayout(typeof(SampleWelcomeViewRibbonGroup), 20, DisplayType.Large)]
	[ActionLayout(typeof(SampleTranslationMemoriesViewRibbonGroup), 20, DisplayType.Large)]
	class BringBackTheButtonViewPartAction : AbstractAction
	{
		protected override void Execute()
		{
		}
	}
}
