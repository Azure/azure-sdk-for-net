// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.AI.Language.Text;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.TextAnalytics.Tests
{
    /// <summary>
    /// Base class for live client tests using different service versions.
    /// </summary>
    /// <typeparam name="TClient">The type of client being tested.</typeparam>
    [ClientTestFixture(
        AnalyzeTextClientOptions.ServiceVersion.V2022_05_01,
        AnalyzeTextClientOptions.ServiceVersion.V2023_04_01,
        AnalyzeTextClientOptions.ServiceVersion.V2023_04_15_Preview,
        AnalyzeTextClientOptions.ServiceVersion.V2023_11_15_Preview
    )]
    [IgnoreServiceError(429, "429")]
    public abstract class AnalyzeTextTestBase : RecordedTestBase<TextAnalyticsClientTestEnvironment>
    {
        protected AnalyzeTextTestBase(bool isAsync, AnalyzeTextClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode)
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
        protected Text.Language Client { get; private set; }

        /// <summary>
        /// Gets the service version used for this instance of the test fixture.
        /// </summary>
        protected AnalyzeTextClientOptions.ServiceVersion ServiceVersion { get; }

        /// <summary>
        /// Creates the <see cref="Client"/> once tests begin.
        /// </summary>
        public override async Task StartTestRecordingAsync()
        {
            await base.StartTestRecordingAsync();

            AnalyzeTextClientOptions options = new AnalyzeTextClientOptions(ServiceVersion);
            Client = CreateClient<AnalyzeTextClient>(
                TestEnvironment.Endpoint,
                new AzureKeyCredential(TestEnvironment.ApiKey),
                InstrumentClientOptions(options)).GetLanguageClient(options.Version);
        }
    }
}
