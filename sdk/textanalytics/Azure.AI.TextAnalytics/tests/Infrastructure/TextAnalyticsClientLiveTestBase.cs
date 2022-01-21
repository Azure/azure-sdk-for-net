﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    TextAnalyticsClientOptions.ServiceVersion.V3_2_Preview_2)]
    public class TextAnalyticsClientLiveTestBase : RecordedTestBase<TextAnalyticsTestEnvironment>
    {
        internal const int MaxRetriesCount = 12;

        /// <summary>
        /// The version of the REST API to test against.  This will be passed
        /// to the .ctor via ClientTestFixture's values.
        /// </summary>
        private readonly TextAnalyticsClientOptions.ServiceVersion _serviceVersion;

        public TextAnalyticsClientLiveTestBase(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync)
        {
            _serviceVersion = serviceVersion;
            Sanitizer = new TextAnalyticsRecordedTestSanitizer();
        }

        protected TextAnalyticsClient GetClient(AzureKeyCredential credential = default, TextAnalyticsClientOptions options = default, bool useTokenCredential = default)
            => GetClient(out _, credential, options, useTokenCredential);

        public TextAnalyticsClient GetClient(
            out TextAnalyticsClient nonInstrumentedClient,
            AzureKeyCredential credential = default,
            TextAnalyticsClientOptions options = default,
            bool useTokenCredential = default)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            options ??= new TextAnalyticsClientOptions(_serviceVersion);

            // While we use a persistent resource for live tests, we need to increase our retries.
            // We should remove when having dynamic resource again
            // Issue: https://github.com/Azure/azure-sdk-for-net/issues/25041
            options.Retry.MaxRetries = MaxRetriesCount;

            if (useTokenCredential)
            {
                nonInstrumentedClient = new TextAnalyticsClient(endpoint, TestEnvironment.Credential, InstrumentClientOptions(options));
            }
            else
            {
                credential ??= new AzureKeyCredential(TestEnvironment.ApiKey);
                nonInstrumentedClient = new TextAnalyticsClient(endpoint, credential, InstrumentClientOptions(options));
            }
            return InstrumentClient(nonInstrumentedClient);
        }

        // This has been added to stop the custom tests to run forever while we
        // get more reliable information on which scenarios cause timeouts.
        // Issue https://github.com/Azure/azure-sdk-for-net/issues/25152
        internal async Task PollUntilTimeout(AnalyzeActionsOperation operation, int timeoutInMinutes = 20)
        {
            TimeSpan pollingInterval = TimeSpan.FromSeconds(10);
            var timeout = TimeSpan.FromMinutes(timeoutInMinutes);
            using CancellationTokenSource cts = new CancellationTokenSource(timeout);
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
