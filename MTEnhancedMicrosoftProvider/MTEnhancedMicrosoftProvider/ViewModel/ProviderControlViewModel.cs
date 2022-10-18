﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MTEnhancedMicrosoftProvider.Commands;
using MTEnhancedMicrosoftProvider.Interfaces;
using MTEnhancedMicrosoftProvider.Model;

namespace MTEnhancedMicrosoftProvider.ViewModel
{
	public class ProviderControlViewModel : BaseModel, IProviderControlViewModel
	{
		private readonly ITranslationOptions _options;
		private readonly RegionsProvider _regionsProvider;

		private ObservableCollection<RegionSubscription> _regions;
		private TranslationOption _selectedTranslationOption;
		private RegionSubscription _region;

		private bool _isMicrosoftSelected;
		private bool _useCatId;
		private bool _persistGoogleKey;
		private bool _persistMicrosoftKey;
		private bool _isTellMeAction;
		private bool _basicCsvGlossary;

		private string _catId;
		private string _clientId;
		private string _jsonFilePath;
		private string _projectName;
		private string _projectLocation;
		private string _glossaryId;
		private string _glossaryPath;

		private ICommand _clearCommand;

		public ProviderControlViewModel(ITranslationOptions options, RegionsProvider regionsProvider)
		{
			ViewModel = this;
			_options = options;
			_regionsProvider = regionsProvider;
			InitializeComponent();
		}

		public ICommand ClearCommand => _clearCommand ??= new RelayCommand(Clear);

		private void InitializeComponent()
		{
			TranslationOptions = new List<TranslationOption>
			{
				new TranslationOption
				{
					Name = PluginResources.Microsoft,
					ProviderType = MTETranslationOptions.ProviderType.MicrosoftTranslator
				}
			};

			Region = Regions.FirstOrDefault(a => a.Key == "");
			if (_options == null)
			{
				SetTranslationOption();
				return;
			}

			BasicCsvGlossary = _options.BasicCsv;
			CatId = _options.CatId;
			ClientId = _options.ClientId;
			GlossaryPath = _options.GlossaryPath;
			JsonFilePath = _options.JsonFilePath;
			PersistMicrosoftKey = _options.PersistMicrosoftCreds;
			ProjectLocation = _options.ProjectLocation;
			ProjectName = _options.ProjectName;
			UseCatId = _options.UseCatID;

			Region = Regions.FirstOrDefault(a => a.Key == (_options.Region ?? ""));
			SetTranslationOption();
		}


		private void Clear(object obj)
		{
			if (obj is not string objectName)
			{
				return;
			}

			switch (objectName)
			{
				case "CategoryId":
					CatId = string.Empty;
					break;
				case "JsonFilePath":
					JsonFilePath = string.Empty;
					break;
				case "ProjectName":
					ProjectName = string.Empty;
					break;
				case "ProjectLocation":
					ProjectLocation = string.Empty;
					break;
				case "GlossaryPath":
					GlossaryPath = string.Empty;
					break;
			}
		}

		public BaseModel ViewModel { get; set; }

		public ICommand ShowSettingsCommand { get; set; }

		public List<TranslationOption> TranslationOptions { get; set; }

		public string ProjectLocation
		{
			get => _projectLocation;
			set
			{
				if (_projectLocation == value) return;
				_projectLocation = value;
				OnPropertyChanged(nameof(ProjectLocation));
				ClearMessageRaised?.Invoke();
			}
		}

		public string GlossaryId
		{
			get => _glossaryId;
			set
			{
				if (_glossaryId == value) return;
				_glossaryId = value;
				OnPropertyChanged(nameof(GlossaryId));
				ClearMessageRaised?.Invoke();
			}
		}

		public string GlossaryPath
		{
			get => _glossaryPath;
			set
			{
				if (_glossaryPath == value) return;
				_glossaryPath = value;
				OnPropertyChanged(nameof(GlossaryPath));
				ClearMessageRaised?.Invoke();
			}
		}

		public event ClearMessageEventRaiser ClearMessageRaised;

		public TranslationOption SelectedTranslationOption
		{
			get => _selectedTranslationOption;
			set
			{
				_selectedTranslationOption = value;
				IsMicrosoftSelected = value.ProviderType == MTETranslationOptions.ProviderType.MicrosoftTranslator;
				OnPropertyChanged(nameof(SelectedTranslationOption));
				ClearMessageRaised?.Invoke();
			}
		}

		public bool IsMicrosoftSelected
		{
			get => _isMicrosoftSelected;
			set
			{
				if (_isMicrosoftSelected == value)
				{
					return;
				}

				OnPropertyChanged(nameof(IsMicrosoftSelected));
				ClearMessageRaised?.Invoke();
			}
		}
		public string ClientId
		{
			get => _clientId;
			set
			{
				if (_clientId == value) return;
				_clientId = value.Trim();
				OnPropertyChanged(nameof(ClientId));
				ClearMessageRaised?.Invoke();
			}
		}

		public RegionSubscription Region
		{
			get => _region;
			set
			{
				if (_region == value)
				{
					return;
				}

				_region = value;
				OnPropertyChanged(nameof(Region));
				ClearMessageRaised?.Invoke();
			}
		}

		public ObservableCollection<RegionSubscription> Regions
		{
			get
			{
				return _regions ?? (_regions = new ObservableCollection<RegionSubscription>( _regionsProvider.GetSubscriptionRegions()));
			}
			set
			{
				_regions = value;
				OnPropertyChanged(nameof(Region));
			}
		}

		public string JsonFilePath
		{
			get => _jsonFilePath;
			set
			{
				if (_jsonFilePath == value)
				{
					return;
				}

				_jsonFilePath = value;
				OnPropertyChanged(nameof(JsonFilePath));
				ClearMessageRaised?.Invoke();
			}
		}

		public string ProjectName
		{
			get => _projectName;
			set
			{
				if (_projectName == value) return;
				_projectName = value;
				OnPropertyChanged(nameof(ProjectName));
				ClearMessageRaised?.Invoke();
			}
		}

		public bool UseCatId
		{
			get => _useCatId;
			set
			{
				if (_useCatId == value) return;
				_useCatId = value;
				if (!value)
				{
					CatId = string.Empty;
				}
				OnPropertyChanged(nameof(UseCatId));
			}
		}

		public bool PersistGoogleKey
		{
			get => _persistGoogleKey;
			set
			{
				if (_persistGoogleKey == value) return;
				_persistGoogleKey = value;
				OnPropertyChanged(nameof(PersistGoogleKey));
			}
		}

		public bool PersistMicrosoftKey
		{
			get => _persistMicrosoftKey;
			set
			{
				if (_persistMicrosoftKey == value) return;
				_persistMicrosoftKey = value;
				OnPropertyChanged(nameof(PersistMicrosoftKey));
			}
		}

		public bool IsTellMeAction
		{
			get => _isTellMeAction;
			set
			{
				if (_isTellMeAction == value) return;
				_isTellMeAction = value;
				OnPropertyChanged(nameof(IsTellMeAction));
			}
		}

		public bool BasicCsvGlossary
		{
			get => _basicCsvGlossary;
			set
			{
				if (_basicCsvGlossary == value) return;
				_basicCsvGlossary = value;
				OnPropertyChanged(nameof(BasicCsvGlossary));
			}
		}

		public string CatId
		{
			get => _catId;
			set
			{
				if (_catId == value) return;
				_catId = value;
				OnPropertyChanged(nameof(CatId));
			}
		}

		private void SetTranslationOption()
		{
			IsMicrosoftSelected = true;
			SelectMicrosoftTranslation();
		}

		private void SelectMicrosoftTranslation()
		{
			SelectedTranslationOption = TranslationOptions[0];
			IsMicrosoftSelected = true;
		}
	}
}