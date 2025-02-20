// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsTestEnvironment: TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("TEXTANALYTICS_ENDPOINT");
        public string ApiKey => GetRecordedVariable("TEXTANALYTICS_API_KEY", options => options.IsSecret());

        // The following variables refer to the static test resource, which is
        // used to test the custom text analysis features.
        public string StaticEndpoint => GetRecordedVariable("TEXTANALYTICS_STATIC_ENDPOINT");
        public string StaticApiKey => GetRecordedVariable("TEXTANALYTICS_STATIC_API_KEY", options => options.IsSecret());
        public string SingleClassificationProjectName => GetRecordedVariable("TEXTANALYTICS_SINGLE_CATEGORY_CLASSIFY_PROJECT_NAME");
        public string SingleClassificationDeploymentName => GetRecordedVariable("TEXTANALYTICS_SINGLE_CATEGORY_CLASSIFY_DEPLOYMENT_NAME");
        public string MultiClassificationProjectName => GetRecordedVariable("TEXTANALYTICS_MULTI_CATEGORY_CLASSIFY_PROJECT_NAME");
        public string MultiClassificationDeploymentName => GetRecordedVariable("TEXTANALYTICS_MULTI_CATEGORY_CLASSIFY_DEPLOYMENT_NAME");
        public string RecognizeCustomEntitiesProjectName => GetRecordedVariable("TEXTANALYTICS_CUSTOM_ENTITIES_PROJECT_NAME");
        public string RecognizeCustomEntitiesDeploymentName => GetRecordedVariable("TEXTANALYTICS_CUSTOM_ENTITIES_DEPLOYMENT_NAME");

        public TextAnalyticsAudience GetAudience()
        {
            Uri authorityHost = new(AuthorityHostUrl);

            if (authorityHost == AzureAuthorityHosts.AzurePublicCloud)
            {
                return TextAnalyticsAudience.AzurePublicCloud;
            }

            if (authorityHost == AzureAuthorityHosts.AzureChina)
            {
                return TextAnalyticsAudience.AzureChina;
            }

            if (authorityHost == AzureAuthorityHosts.AzureGovernment)
            {
                return TextAnalyticsAudience.AzureGovernment;
            }

            throw new NotSupportedException($"Cloud for authority host {authorityHost} is not supported.");
        }

        public void IgnoreIfNotPublicCloud()
        {
            if (GetAudience() != TextAnalyticsAudience.AzurePublicCloud)
            {
                Assert.Ignore("Currently, these tests can only be run in the public cloud.");
            }
        }

        protected override async ValueTask<bool> IsEnvironmentReadyAsync()
        {
            // Check that the dynamic resource is ready.
            Uri endpoint = new(Endpoint);
            AzureKeyCredential azureKeyCredential = new(ApiKey);
            TextAnalyticsClientOptions options = new() { Audience = GetAudience() };

            try
            {
                TextAnalyticsClient clientWithAzureKeyCredential = new(endpoint, azureKeyCredential, options);
                await clientWithAzureKeyCredential.DetectLanguageAsync("Ready!");

                TextAnalyticsClient clientWithTokenCredential = new(endpoint, Credential, options);
                await clientWithTokenCredential.DetectLanguageAsync("Ready!");
            }
            catch (RequestFailedException e) when (e.Status == 401)
            {
                return false;
            }

            return true;
        }
    }
}
