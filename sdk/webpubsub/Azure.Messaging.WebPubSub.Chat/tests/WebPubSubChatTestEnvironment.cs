// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Messaging.WebPubSub.Chat.Tests
{
    public class WebPubSubChatTestEnvironment : TestEnvironment
    {
        public const string SanitizedEndpoint = "https://sanitized.webpubsub.azure.com";

        public string ConnectionString => GetRecordedVariable("WPS_CHAT_CONNECTION_STRING", options => options.HasSecretConnectionStringParameter("accessKey", SanitizedValue.Base64));

        public string Endpoint => GetRecordedVariable("WPS_CHAT_ENDPOINT", options => options.IsSecret(SanitizedEndpoint));

        public bool DisableLocalAuth => bool.TryParse(GetRecordedOptionalVariable("WPS_CHAT_DISABLE_LOCAL_AUTH"), out bool value) && value;

        protected override TokenCredential CreateDeveloperCredential() => new DefaultAzureCredential(
            new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeManagedIdentityCredential = true,
                ExcludeWorkloadIdentityCredential = true,
                ExcludeInteractiveBrowserCredential = true,
                ExcludeBrokerCredential = true,
                ExcludeVisualStudioCodeCredential = true,
            });
    }
}
