// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    /// <summary>
    /// Base class for live client tests using different service versions.
    /// </summary>
    /// <typeparam name="TClient">The type of client being tested.</typeparam>
    [ClientTestFixture(QuestionAnsweringClientOptions.ServiceVersion.V2021_05_01_preview)]
    public abstract class QuestionAnsweringTestBase<TClient> : RecordedTestBase<QuestionAnsweringTestEnvironment> where TClient : class
    {
        protected QuestionAnsweringTestBase(bool isAsync, QuestionAnsweringClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode)
            : base(isAsync, mode)
        {
            // TODO: Compare bodies again when https://github.com/Azure/azure-sdk-for-net/issues/22219 is resolved.
            Matcher = new RecordMatcher(compareBodies: false);

            Sanitizer = new QuestionAnsweringRecordedTestSanitizer();
            ServiceVersion = serviceVersion;
        }

        /// <summary>
        /// Gets an instrumented client of type <typeparamref name="TClient"/>.
        /// </summary>
        protected TClient Client { get; private set; }

        /// <summary>
        /// Gets the service version used for this instance of the test fixture.
        /// </summary>
        protected QuestionAnsweringClientOptions.ServiceVersion ServiceVersion { get; }

        /// <summary>
        /// Creates the <see cref="Client"/> once tests begin.
        /// </summary>
        public override void StartTestRecording()
        {
            base.StartTestRecording();

            Client = CreateClient<TClient>(
                TestEnvironment.Endpoint,
                new AzureKeyCredential(TestEnvironment.ApiKey),
                InstrumentClientOptions(
                    new QuestionAnsweringClientOptions(ServiceVersion)));
        }
    }
}
