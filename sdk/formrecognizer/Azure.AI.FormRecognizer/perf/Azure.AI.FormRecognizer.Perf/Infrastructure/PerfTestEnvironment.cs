// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.Perf
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
        /// The endpoint of the Form Recognizer account to test against.
        /// </summary>
        /// <value>The endpoint, read from the "FORM_RECOGNIZER_ENDPOINT" environment variable.</value>
        public string Endpoint => GetVariable("FORM_RECOGNIZER_ENDPOINT");

        /// <summary>
        /// The API key of the Form Recognizer account to test against.
        /// </summary>
        /// <value>The API key, read from the "FORM_RECOGNIZER_API_KEY" environment variable.</value>
        public string ApiKey => GetVariable("FORM_RECOGNIZER_API_KEY");

        /// <summary>
        /// The SAS URL of the Blob Container used to train models to test against.
        /// </summary>
        /// <value>The SAS URL, read from the "FORM_RECOGNIZER_BLOB_CONTAINER_SAS_URL" environment variable.</value>
        public string BlobContainerSasUrl => GetVariable("FORM_RECOGNIZER_BLOB_CONTAINER_SAS_URL");
    }
}
