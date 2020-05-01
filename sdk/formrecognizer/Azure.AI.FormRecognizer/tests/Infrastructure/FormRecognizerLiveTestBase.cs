// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.FormRecognizer.Training;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.Tests
{
    public class FormRecognizerLiveTestBase : RecordedTestBase<FormRecognizerTestEnvironment>
    {
        public FormRecognizerLiveTestBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new FormRecognizerRecordedTestSanitizer();
            Matcher = new FormRecognizerRecordMatcher();
        }

        /// <summary>
        /// Creates a <see cref="FormTrainingClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="FormTrainingClient" />.</returns>
        protected FormTrainingClient CreateInstrumentedFormTrainingClient()
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var credential = new AzureKeyCredential(TestEnvironment.ApiKey);

            var options = Recording.InstrumentClientOptions(new FormRecognizerClientOptions());
            var client = new FormTrainingClient(endpoint, credential, options);

            return InstrumentClient(client);
        }
    }
}
