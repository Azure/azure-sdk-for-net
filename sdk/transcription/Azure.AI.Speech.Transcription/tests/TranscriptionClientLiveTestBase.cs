// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.AI.Speech.Transcription.Tests
{
    /// <summary>
    /// Base class for Transcription client live tests.
    /// Provides common functionality for tests that require a live service connection.
    /// </summary>
    public abstract class TranscriptionClientLiveTestBase
    {
        /// <summary>
        /// Creates a <see cref="TranscriptionClient"/> for testing.
        /// </summary>
        /// <returns>A <see cref="TranscriptionClient"/>.</returns>
        protected TranscriptionClient CreateClient()
        {
            return TestConfiguration.CreateClient();
        }

        /// <summary>
        /// Creates a <see cref="TranscriptionClient"/> with custom options for testing.
        /// </summary>
        /// <param name="options">The client options.</param>
        /// <returns>A <see cref="TranscriptionClient"/>.</returns>
        protected TranscriptionClient CreateClient(TranscriptionClientOptions options)
        {
            return TestConfiguration.CreateClient(options);
        }

        /// <summary>
        /// Gets the path to the sample audio file.
        /// </summary>
        protected string SampleAudioFilePath => TestConfiguration.SampleAudioFilePath;

        /// <summary>
        /// Skips the test if credentials are not configured.
        /// </summary>
        protected void SkipIfNotConfigured()
        {
            string endpoint = Environment.GetEnvironmentVariable("TRANSCRIPTION_ENDPOINT");
            if (string.IsNullOrEmpty(endpoint))
            {
                Assert.Ignore("TRANSCRIPTION_ENDPOINT not configured. Skipping live test.");
            }
        }
    }
}
