﻿using System;
using LanguageMappingProvider;
using Newtonsoft.Json;
using Sdl.Community.MTCloud.Provider.Model;
using Sdl.Community.MTCloud.Provider.Service;
using Sdl.LanguagePlatform.TranslationMemoryApi;

namespace Sdl.Community.MTCloud.Provider.Studio.TranslationProvider
{
	[TranslationProviderFactory(Id = "SDLMachineTranslationCloudProviderFactory",
		Name = "SDLMachineTranslationCloudProviderFactory",
		Description = "SDL Machine Translation Cloud")]
	public class SdlMTCloudTranslationProviderFactory : ITranslationProviderFactory
	{
		public ITranslationProvider CreateTranslationProvider(Uri translationProviderUri, string translationProviderState,
			ITranslationProviderCredentialStore credentialStore)
		{
			var connectionService = MtCloudApplicationInitializer.ConnectionService;

			try
			{
				var options = JsonConvert.DeserializeObject<Options>(translationProviderState);
			}
			catch { }

			var connectionResult = connectionService.EnsureSignedIn(credentialStore);

			if (!connectionResult.Item1)
				throw new TranslationProviderAuthenticationException(PluginResources.Message_Invalid_credentials);

			connectionService.SaveCredential();
			MtCloudApplicationInitializer.SetTranslationService(connectionService, null);

			var languageProvider = new LanguageProvider();
			var provider = new SdlMTCloudTranslationProvider(translationProviderUri, translationProviderState,
				MtCloudApplicationInitializer.TranslationService, languageProvider);

			return provider;
		}

		public TranslationProviderInfo GetTranslationProviderInfo(Uri translationProviderUri, string translationProviderState)
		{
			MtCloudApplicationInitializer.RefreshQeStatus();
			var info = new TranslationProviderInfo
			{
				TranslationMethod = TranslationMethod.MachineTranslation,
				Name = PluginResources.SDLMTCloud_Provider_Name
			};

			return info;
		}

		public bool SupportsTranslationProviderUri(Uri translationProviderUri)
		{
			if (translationProviderUri == null)
			{
				throw new ArgumentNullException(nameof(translationProviderUri));
			}

			var supportsProvider = translationProviderUri.Scheme.StartsWith(Constants.MTCloudUriScheme);
			return supportsProvider;
		}
	}
}