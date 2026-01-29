// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Speech.Transcription.Samples
{
    /// <summary>
    /// Base class for transcription samples, providing helper methods for client creation.
    /// </summary>
    public class TranscriptionSampleBase : SamplesBase<TranscriptionClientTestEnvironment>
    {
        /// <summary>
        /// Creates an authenticated TranscriptionClient using API key authentication.
        /// </summary>
        protected TranscriptionClient CreateTranscriptionClient()
        {
            #region Snippet:CreateTranscriptionClientAuth
            string endpoint = Environment.GetEnvironmentVariable("TRANSCRIPTION_ENDPOINT");
            string key = Environment.GetEnvironmentVariable("TRANSCRIPTION_API_KEY");

#if !SNIPPET
            endpoint = TestEnvironment.Endpoint.ToString();
            key = TestEnvironment.Credential.Key;
#endif

            // Create a Transcription client
            TranscriptionClient client = new TranscriptionClient(
                new Uri(endpoint),
                new AzureKeyCredential(key));

            #endregion Snippet:CreateTranscriptionClientAuth

            return client;
        }

        /// <summary>
        /// Creates an authenticated TranscriptionClient with custom options.
        /// </summary>
        protected TranscriptionClient CreateTranscriptionClient(TranscriptionClientOptions options)
        {
            string endpoint = TestEnvironment.Endpoint.ToString();
            string key = TestEnvironment.Credential.Key;

            return new TranscriptionClient(new Uri(endpoint), new AzureKeyCredential(key), options);
        }
    }
}
