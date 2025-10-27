// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.AI.Speech.Transcription.Samples
{
    /// <summary>
    /// Test environment for Transcription samples and tests.
    /// </summary>
    public class TranscriptionClientTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Gets the endpoint for the Speech Transcription service.
        /// </summary>
        public Uri Endpoint => new Uri(GetRecordedVariable("TRANSCRIPTION_ENDPOINT", options => options.HasSecretConnectionStringParameter("endpoint")));

        /// <summary>
        /// Gets the API key credential for authentication.
        /// </summary>
        public new AzureKeyCredential Credential => new AzureKeyCredential(
            GetRecordedVariable("TRANSCRIPTION_API_KEY", options => options.IsSecret()));
    }
}
