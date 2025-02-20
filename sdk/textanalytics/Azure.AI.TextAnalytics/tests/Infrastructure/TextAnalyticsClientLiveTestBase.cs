// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.TextAnalytics.Tests
{
    [ClientTestFixture(
    TextAnalyticsClientOptions.ServiceVersion.V3_0,
    TextAnalyticsClientOptions.ServiceVersion.V3_1,
    TextAnalyticsClientOptions.ServiceVersion.V2022_05_01,
    TextAnalyticsClientOptions.ServiceVersion.V2023_04_01)]
    public class TextAnalyticsClientLiveTestBase : RecordedTestBase<TextAnalyticsTestEnvironment>
    {
        private const int MaxRetriesCount = 12;

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
            Uri endpoint = new(useStaticResource
                ? TestEnvironment.StaticEndpoint
                : TestEnvironment.Endpoint);

            TextAnalyticsAudience audience = TestEnvironment.GetAudience();

            options ??= new TextAnalyticsClientOptions(ServiceVersion)
            {
                Audience = audience
            };

            // We have seen transient timeouts while testing the custom text analysis features which are potentially
            // related to the use of the static resource.
            // TODO: https://github.com/Azure/azure-sdk-for-net/issues/25041.
            // Similarly, we have also seen transient timeouts when running tests in the China cloud regions which are
            // likely due to the physical distance between those regions and our CI infrastructure running in the US.
            if (useStaticResource || audience == TextAnalyticsAudience.AzureChina)
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
        // TODO: https://github.com/Azure/azure-sdk-for-net/issues/25152
        internal static async Task PollUntilTimeout<T>(Operation<T> operation, int timeoutInMinutes = 20)
        {
            TimeSpan pollingInterval = TimeSpan.FromSeconds(10);
            TimeSpan timeout = TimeSpan.FromMinutes(timeoutInMinutes);
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
    }
}
