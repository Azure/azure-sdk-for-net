// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;
using Azure.Core.TestFramework;
using System.Threading;

namespace Azure.AI.Translation.Text.Tests
{
    public class TextTranslationTestEnvironment : TestEnvironment
    {
        public TextTranslationTestEnvironment()
        {
        }

        /// <summary>The name of the environment variable from which the Text Translator resource's endpoint will be extracted for the live tests.</summary>
        private const string EndpointEnvironmentVariableName = "TEXT_TRANSLATION_ENDPOINT";

        /// <summary>
        /// The name of the environment variable from which the Text Translator resource's endpoint will be extracted for the live tests.
        /// Unlike regional endpoints, which were common for all customers in a specific Azure region, custom subdomain names are unique to the resource.
        /// Custom subdomain names are required to enable features like Azure Active Directory (Azure AD) for authentication.
        /// </summary>
        private const string CustomEndpointEnvironmentVariableName = "TEXT_TRANSLATION_CUSTOM_ENDPOINT";

        /// <summary>The name of the environment variable from which the Text Translator resource's API key will be extracted for the live tests.</summary>
        private const string ApiKeyEnvironmentVariableName = "TEXT_TRANSLATION_API_KEY";

        /// <summary>The name of the environment variable from which the Text Translator resource's region will be extracted for the live tests.</summary>
        private const string RegionEnvironmentVariableName = "TEXT_TRANSLATION_REGION";

        /// <summary>The name of the environment variable from which the Text Translator resource's region will be extracted for the live tests. This resource is used for AAD tests.</summary>
        private const string AADRegionEnvironmentVariableName = "TEXT_TRANSLATION_AAD_REGION";

        /// <summary>Client ID. This resource is used for AAD tests.</summary>
        private const string AADClientIdEnvironmentVariableName = "TEXT_TRANSLATION_AAD_CLIENT_ID";

        /// <summary>Tenant ID. This resource is used for AAD tests.</summary>
        private const string AADTentantIdEnvironmentVariableName = "TEXT_TRANSLATION_AAD_TENANT_ID";

        /// <summary>Secret Value. This resource is used for AAD tests.</summary>
        private const string AADSecretEnvironmentVariableName = "TEXT_TRANSLATION_AAD_SECRET";

        /// <summary>Resource ID. This resource is used for AAD tests.</summary>
        private const string AADResourceIDEnvironmentVariableName = "TEXT_TRANSLATION_AAD_RESOURCE_ID";

        public string ApiKey => GetRecordedVariable(ApiKeyEnvironmentVariableName, options => options.IsSecret());
        public string Endpoint => GetRecordedVariable(EndpointEnvironmentVariableName);
        public string CustomEndpoint => GetRecordedVariable(CustomEndpointEnvironmentVariableName);
        public string Region => GetRecordedVariable(RegionEnvironmentVariableName);
        public string AADRegion => GetRecordedVariable(AADRegionEnvironmentVariableName);
        public string AADClientId => GetRecordedVariable(AADClientIdEnvironmentVariableName, options => options.IsSecret());
        public string AADTenantId => GetRecordedVariable(AADTentantIdEnvironmentVariableName, options => options.IsSecret());
        public string AADSecret => GetRecordedVariable(AADSecretEnvironmentVariableName, options => options.IsSecret());
        public string AADResourceId => GetRecordedVariable(AADResourceIDEnvironmentVariableName, options => options.IsSecret());

        protected override async ValueTask<bool> IsEnvironmentReadyAsync()
        {
            string endpoint = GetOptionalVariable(EndpointEnvironmentVariableName);
            TextTranslationClient client = new TextTranslationClient(Credential, new Uri(endpoint));
            try
            {
                await client.GetLanguagesAsync(cancellationToken: CancellationToken.None).ConfigureAwait(false);
            }
            catch (RequestFailedException e) when (e.Status == 401)
            {
                return false;
            }
            return true;
        }
    }
}
