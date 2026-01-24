// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using Azure.AI.Speech.Transcription.Tests;

namespace Azure.AI.Speech.Transcription.Samples
{
    /// <summary>
    /// Base class for transcription samples, providing helper methods for client creation.
    /// </summary>
    public class TranscriptionSampleBase
    {
        /// <summary>
        /// Creates an authenticated TranscriptionClient using API key authentication.
        /// </summary>
        protected TranscriptionClient CreateTranscriptionClient()
        {
#if SNIPPET
            #region Snippet:CreateTranscriptionClientAuth
            string endpoint = Environment.GetEnvironmentVariable("TRANSCRIPTION_ENDPOINT");
            string key = Environment.GetEnvironmentVariable("TRANSCRIPTION_API_KEY");

            // Create a Transcription client
            TranscriptionClient client = new TranscriptionClient(
                new Uri(endpoint),
                new ApiKeyCredential(key));
            #endregion Snippet:CreateTranscriptionClientAuth
            return client;
#else
            // Use TestConfiguration for actual test execution
            return TestConfiguration.CreateClient();
#endif
        }

        /// <summary>
        /// Creates an authenticated TranscriptionClient with custom options.
        /// </summary>
        protected TranscriptionClient CreateTranscriptionClient(TranscriptionClientOptions options)
        {
            return TestConfiguration.CreateClient(options);
        }

        /// <summary>
        /// Gets the path to the sample audio file for testing.
        /// </summary>
        protected string GetSampleAudioFilePath()
        {
            return TestConfiguration.SampleAudioFilePath;
        }
    }
}
