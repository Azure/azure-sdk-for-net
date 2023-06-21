// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.TextAnalytics.Perf
{
    /// <summary>
    /// Represents the ambient environment in which the test suite is being run, offering access to information such
    /// as environment variables.
    /// </summary>
    public sealed class PerfTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PerfTestEnvironment"/> class.
        /// </summary>
        private PerfTestEnvironment()
        {
        }

        /// <summary>
        /// The shared instance of the <see cref="PerfTestEnvironment"/> to be used during test runs.
        /// </summary>
        public static PerfTestEnvironment Instance { get; } = new PerfTestEnvironment();

        /// <summary>
        /// The endpoint of the Text Analytics account to test against.
        /// </summary>
        /// <value>The endpoint, read from the "TEXTANALYTICS_ENDPOINT" environment variable.</value>
        public string Endpoint => GetVariable("TEXTANALYTICS_ENDPOINT");

        /// <summary>
        /// The API key of the Text Analytics account to test against.
        /// </summary>
        /// <value>The API key, read from the "TEXTANALYTICS_API_KEY" environment variable.</value>
        public string ApiKey => GetVariable("TEXTANALYTICS_API_KEY");
    }
}
