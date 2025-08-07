// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.Conversations.Authoring.Tests
{
    /// <summary>
    /// Base class for live client tests using different service versions for Conversation Authoring.
    /// </summary>
    /// <typeparam name="TClient">The type of client being tested.</typeparam>
    [ClientTestFixture(
        ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2023_04_01,
        ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2023_04_15_Preview,
        ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview,
        ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview
    )]
    [IgnoreServiceError(429, "429")]
    public abstract class ConversationAuthoringTestBase : RecordedTestBase<AuthoringClientTestEnvironment>
    {
        protected ConversationAuthoringTestBase(bool isAsync, ConversationAnalysisAuthoringClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode)
            : base(isAsync, mode)
        {
            CompareBodies = false;

            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");
            ServiceVersion = serviceVersion;
        }

        /// <summary>
        /// Gets an instrumented client of type <typeparamref name="TClient"/>.
        /// </summary>
        protected ConversationAnalysisAuthoringClient client { get; private set; }

        /// <summary>
        /// Gets the service version used for this instance of the test fixture.
        /// </summary>
        protected ConversationAnalysisAuthoringClientOptions.ServiceVersion ServiceVersion { get; }

        /// <summary>
        /// Creates the <see cref="Client"/> once tests begin.
        /// </summary>
        public override async Task StartTestRecordingAsync()
        {
            await base.StartTestRecordingAsync();

            ConversationAnalysisAuthoringClientOptions options = new(ServiceVersion);
            client = CreateClient<ConversationAnalysisAuthoringClient>(
                TestEnvironment.Endpoint,
                new AzureKeyCredential(TestEnvironment.ApiKey),
                InstrumentClientOptions(options));
        }
    }
}
