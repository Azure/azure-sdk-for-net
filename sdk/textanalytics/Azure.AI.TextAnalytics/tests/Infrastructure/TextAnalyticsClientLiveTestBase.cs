// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    [ClientTestFixture(
    TextAnalyticsClientOptions.ServiceVersion.V3_0,
    TextAnalyticsClientOptions.ServiceVersion.V3_1,
    TextAnalyticsClientOptions.ServiceVersion.V2022_05_01,
    TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview)]
    public class TextAnalyticsClientLiveTestBase : RecordedTestBase<TextAnalyticsTestEnvironment>
    {
        internal const int MaxRetriesCount = 12;

        /// <summary>
        /// The version of the REST API to test against.  This will be passed
        /// to the .ctor via ClientTestFixture's values.
        /// </summary>
        protected TextAnalyticsClientOptions.ServiceVersion ServiceVersion { get; }

        public TextAnalyticsClientLiveTestBase(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync)
        {
            ServiceVersion = serviceVersion;
            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");
        }

        protected TextAnalyticsClient GetClient(
            AzureKeyCredential credential = default,
            TextAnalyticsClientOptions options = default,
            bool useTokenCredential = default,
            bool useStaticResource = default)
            => GetClient(out _, credential, options, useTokenCredential, useStaticResource);

        public TextAnalyticsClient GetClient(
            out TextAnalyticsClient nonInstrumentedClient,
            AzureKeyCredential credential = default,
            TextAnalyticsClientOptions options = default,
            bool useTokenCredential = default,
            bool useStaticResource = default)
        {
            Uri authorityHost = new(TestEnvironment.AuthorityHostUrl);

            Uri endpoint = new(useStaticResource
                ? TestEnvironment.StaticEndpoint
                : TestEnvironment.Endpoint);

            options ??= new TextAnalyticsClientOptions(ServiceVersion)
            {
                Audience = GetAudience(authorityHost)
            };

            // While we use a persistent resource for live tests, we need to increase our retries.
            // We should remove when having dynamic resource again
            // Issue: https://github.com/Azure/azure-sdk-for-net/issues/25041
            if (useStaticResource)
            {
                options.Retry.MaxRetries = MaxRetriesCount;
            }

            if (useTokenCredential)
            {
                nonInstrumentedClient = new TextAnalyticsClient(endpoint, TestEnvironment.Credential, InstrumentClientOptions(options));
            }
            else
            {
                credential ??= new AzureKeyCredential(useStaticResource
                    ? TestEnvironment.StaticApiKey
                    : TestEnvironment.ApiKey);

                nonInstrumentedClient = new TextAnalyticsClient(endpoint, credential, InstrumentClientOptions(options));
            }
            return InstrumentClient(nonInstrumentedClient);
        }

        // This has been added to stop the custom tests to run forever while we
        // get more reliable information on which scenarios cause timeouts.
        // Issue https://github.com/Azure/azure-sdk-for-net/issues/25152
        internal static async Task PollUntilTimeout<T>(Operation<T> operation, int timeoutInMinutes = 20)
        {
            TimeSpan pollingInterval = TimeSpan.FromSeconds(10);
            var timeout = TimeSpan.FromMinutes(timeoutInMinutes);
            using CancellationTokenSource cts = new(timeout);
            try
            {
                await operation.WaitForCompletionAsync(pollingInterval, cts.Token);
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("Test cancelled. Test timed out.");
            }
        }

        internal static TextAnalyticsAudience GetAudience(Uri authorityHost)
        {
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

        internal static void IgnoreIfNotPublicCloud(Uri authorityHost)
        {
            TextAnalyticsAudience audience = GetAudience(authorityHost);

            if (audience != TextAnalyticsAudience.AzurePublicCloud)
            {
                Assert.Ignore("Currently, these tests can only be run in the public cloud.");
            }
        }
    }
}
