﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.Conversations.Tests
{
    /// <summary>
    /// Base class for live client tests using different service versions.
    /// </summary>
    /// <typeparam name="TClient">The type of client being tested.</typeparam>
    [ClientTestFixture(
        ConversationsClientOptions.ServiceVersion.V2023_04_01,
        ConversationsClientOptions.ServiceVersion.V2022_05_01)]
    [IgnoreServiceError(429, "429")]
    public abstract class ConversationAnalysisTestBase<TClient> : RecordedTestBase<ConversationAnalysisTestEnvironment> where TClient : class
    {
        protected ConversationAnalysisTestBase(bool isAsync, ConversationsClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode)
            : base(isAsync, mode)
        {
            // TODO: Compare bodies again when https://github.com/Azure/azure-sdk-for-net/issues/22219 is resolved.
            CompareBodies = false;

            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");
            ServiceVersion = serviceVersion;
        }

        /// <summary>
        /// Gets an instrumented client of type <typeparamref name="TClient"/>.
        /// </summary>
        protected TClient Client { get; private set; }

        /// <summary>
        /// Gets the service version used for this instance of the test fixture.
        /// </summary>
        protected ConversationsClientOptions.ServiceVersion ServiceVersion { get; }

        /// <summary>
        /// Creates the <see cref="Client"/> once tests begin.
        /// </summary>
        public override async Task StartTestRecordingAsync()
        {
            await base.StartTestRecordingAsync();

            ConversationsClientOptions options = new ConversationsClientOptions(ServiceVersion);
            Client = CreateClient<TClient>(
                TestEnvironment.Endpoint,
                new AzureKeyCredential(TestEnvironment.ApiKey),
                InstrumentClientOptions(options));
        }
    }
}
