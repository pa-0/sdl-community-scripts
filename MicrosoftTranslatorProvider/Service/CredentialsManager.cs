﻿using System;
using MicrosoftTranslatorProvider.Interfaces;
using MicrosoftTranslatorProvider.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using TradosProxySettings.Model;

namespace MicrosoftTranslatorProvider.Service
{
    public static class CredentialsManager
    {
        private const string CredentialsKey = "microsoftCredentials";

        public static void GetCredentials(ITranslationOptions translationOptions)
        {
            if (translationOptions.AuthenticationType == AuthenticationType.None
                || translationOptions.AuthenticationType == AuthenticationType.Microsoft)
            {
                GetAndAssignCredentials<MicrosoftCredentials>(translationOptions,
                    Constants.MicrosoftProviderFullScheme);
            }

            if (translationOptions.AuthenticationType == AuthenticationType.None
                || translationOptions.AuthenticationType == AuthenticationType.PrivateEndpoint)
            {
                GetAndAssignCredentials<PrivateEndpoint>(translationOptions,
                    Constants.MicrosoftProviderPrivateEndpointFullScheme);
            }
        }

        private static void GetAndAssignCredentials<T>(ITranslationOptions translationOptions, string scheme)
        {
            var credentialStore = ApplicationInitializer.CredentialStore;
            if (credentialStore is null)
            {
                return;
            }

            var uri = new Uri(scheme);
            var translationProviderCredential = credentialStore.GetCredential(uri);
            if (translationProviderCredential is null
                || translationProviderCredential.Credential is not string persistedCredentials)
            {
                return;
            }

            try
            {
                var parsedObject = JObject.Parse(persistedCredentials);
                var credentials = parsedObject[CredentialsKey].ToString();
                AssignCredentials<T>(translationOptions, parsedObject[CredentialsKey].ToString());
            }
            catch
            {
            }
        }

        private static void AssignCredentials<T>(ITranslationOptions translationOptions, string credentials)
        {
            var tType = typeof(T);
            if (tType == typeof(MicrosoftCredentials))
            {
                translationOptions.MicrosoftCredentials = DeserializeAndCast<T>(credentials) as MicrosoftCredentials;
            }
            else if (tType == typeof(PrivateEndpoint))
            {
                translationOptions.PrivateEndpoint =
                    DeserializeAndCast<PrivateEndpoint>(credentials) as PrivateEndpoint;
            }
        }

        private static T DeserializeAndCast<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static void UpdateCredentials(ITranslationOptions translationOptions)
        {
            var credentialStore = ApplicationInitializer.CredentialStore;
            if (translationOptions.AuthenticationType == AuthenticationType.None)
            {
                return;
            }

            var credentials = translationOptions.AuthenticationType == AuthenticationType.Microsoft
                ? JsonConvert.SerializeObject(translationOptions.MicrosoftCredentials)
                : JsonConvert.SerializeObject(translationOptions.PrivateEndpoint);

            var jsonStructure = new JObject(new JProperty(CredentialsKey, JToken.Parse(credentials))).ToString();

            var translationProviderCredential = new TranslationProviderCredential(jsonStructure, true);
            credentialStore.RemoveCredential(translationOptions.Uri);
            credentialStore.AddCredential(translationOptions.Uri, translationProviderCredential);
        }


        public static void UpdateProxySettings(ProxySettings proxySettings)
        {
            var credentialStore = ApplicationInitializer.CredentialStore;

            var json = JsonConvert.SerializeObject(proxySettings);
            var translationProviderCredential = new TranslationProviderCredential(json, true);

            var uri = new Uri(Constants.MicrosoftProviderProxySettingsFullScheme);
            credentialStore.AddCredential(uri, translationProviderCredential);
        }

        public static void UpdateProxySettings(ITranslationOptions translationOptions)
        {
            UpdateProxySettings(translationOptions.ProxySettings);
        }

        public static ProxySettings GetProxySettings()
        {
            var credentialStore = ApplicationInitializer.CredentialStore;
            var uri = new Uri(Constants.MicrosoftProviderProxySettingsFullScheme);
            var credential = credentialStore.GetCredential(uri);

            if (credential?.Credential != null)
            {
                var proxySettings = JsonConvert.DeserializeObject<ProxySettings>(credential.Credential);
                if (proxySettings != null)
                {
                    return proxySettings;
                }
            }

            return new ProxySettings
            {
                IsEnabled = false
            };
        }

        public static void GetProxySettings(ITranslationOptions translationOptions)
        {
            translationOptions.ProxySettings = GetProxySettings();
        }
    }
}