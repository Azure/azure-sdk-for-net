// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.Text.Authoring.Tests
{
    /// <summary>
    /// Base class for live client tests using different service versions for Text Authoring.
    /// </summary>
    /// <typeparam name="TClient">The type of client being tested.</typeparam>
    [ClientTestFixture(
        TextAnalysisAuthoringClientOptions.ServiceVersion.V2023_04_01,
        TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview,
        TextAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview
    )]
    [IgnoreServiceError(429, "429")]
    public abstract class TextAuthoringTestBase : RecordedTestBase<AuthoringClientTestEnvironment>
    {
        protected TextAuthoringTestBase(bool isAsync, TextAnalysisAuthoringClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode)
            : base(isAsync, mode)
        {
            CompareBodies = false;

            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");
            ServiceVersion = serviceVersion;
        }

        /// <summary>
        /// Gets an instrumented client of type <typeparamref name="TClient"/>.
        /// </summary>
        protected TextAnalysisAuthoringClient client { get; private set; }

        /// <summary>
        /// Gets the service version used for this instance of the test fixture.
        /// </summary>
        protected TextAnalysisAuthoringClientOptions.ServiceVersion ServiceVersion { get; }

        /// <summary>
        /// Creates the <see cref="Client"/> once tests begin.
        /// </summary>
        public override async Task StartTestRecordingAsync()
        {
            await base.StartTestRecordingAsync();

            TextAnalysisAuthoringClientOptions options = new(ServiceVersion);
            client = CreateClient<TextAnalysisAuthoringClient>(
                TestEnvironment.Endpoint,
                new AzureKeyCredential(TestEnvironment.ApiKey),
                InstrumentClientOptions(options));
        }
    }
}
