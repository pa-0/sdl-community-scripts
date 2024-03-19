using System.Collections.Generic;
using System.Collections.ObjectModel;
using MicrosoftTranslatorProvider.Model;
using Newtonsoft.Json;

namespace MicrosoftTranslatorProvider.Interfaces
{
	public delegate void ClearMessageEventRaiser();

	public interface IProviderViewModel
	{
		[JsonIgnore]
		string ApiKey { get; set; }

		bool PersistMicrosoftKey { get; set; }

		BaseModel ViewModel { get; }
		
		AccountRegion SelectedRegion { get; set; }

		List<AccountRegion> Regions { get; set; }

		List<PairMapping> LanguageMappings { get; set; }
	}
}