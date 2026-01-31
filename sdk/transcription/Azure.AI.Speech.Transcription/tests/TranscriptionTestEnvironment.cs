// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.AI.Speech.Transcription.Tests
{
    /// <summary>
    /// Test environment for Transcription SDK tests.
    /// Manages test configuration and credentials.
    /// </summary>
    public class TranscriptionTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Gets the endpoint URL for the Transcription service.
        /// This value is recorded in session files to ensure playback uses the correct endpoint.
        /// </summary>
        public string Endpoint => GetRecordedVariable("TRANSCRIPTION_ENDPOINT");

        /// <summary>
        /// Gets the API key for the Transcription service.
        /// This value is sanitized in recordings for security.
        /// </summary>
        public string ApiKey => GetRecordedVariable("TRANSCRIPTION_API_KEY", options => options.IsSecret("api-key"));

        /// <summary>
        /// Gets the path to the sample audio file for testing.
        /// </summary>
        public string SampleAudioPath => GetAssetPath("sample-audio.wav");

        /// <summary>
        /// Gets the path to the English sample audio file for testing.
        /// </summary>
        public string SampleEnglishAudioPath => GetAssetPath("sample-whatstheweatherlike-en.mp3");

        /// <summary>
        /// Gets the path to the profanity sample audio file for testing.
        /// </summary>
        public string SampleProfanityAudioPath => GetAssetPath("sample-profanity.wav");

        /// <summary>
        /// Gets the path to the Chinese sample audio file for testing.
        /// </summary>
        public string SampleChineseAudioPath => GetAssetPath("sample-howstheweather-cn.wav");

        /// <summary>
        /// Gets the URL for the sample audio file (if configured).
        /// </summary>
        public string SampleAudioUrl => GetOptionalVariable("TRANSCRIPTION_SAMPLE_AUDIO_URL");

        /// <summary>
        /// Gets whether a sample audio URL is configured.
        /// </summary>
        public bool HasSampleAudioUrl => !string.IsNullOrEmpty(SampleAudioUrl);

        /// <summary>
        /// Gets the full path to an asset file in the samples/assets directory.
        /// </summary>
        private string GetAssetPath(string fileName)
        {
            string assemblyLocation = typeof(TranscriptionTestEnvironment).Assembly.Location;
            string assemblyDir = System.IO.Path.GetDirectoryName(assemblyLocation);
            string repoRoot = System.IO.Path.GetFullPath(System.IO.Path.Combine(assemblyDir, "..", "..", "..", "..", ".."));
            string assetsPath = System.IO.Path.Combine(repoRoot, "sdk", "transcription", "Azure.AI.Speech.Transcription", "samples", "assets", fileName);
            return System.IO.Path.GetFullPath(assetsPath);
        }

        /// <summary>
        /// Parses environment variables into the test environment.
        /// Called during test setup to populate recorded variables.
        /// </summary>
        public override Dictionary<string, string> ParseEnvironmentFile() => new()
        {
            { "TRANSCRIPTION_ENDPOINT", Environment.GetEnvironmentVariable("TRANSCRIPTION_ENDPOINT") },
            { "TRANSCRIPTION_API_KEY", Environment.GetEnvironmentVariable("TRANSCRIPTION_API_KEY") }
        };

        /// <summary>
        /// Waits for the test environment to be ready.
        /// Override this if you need to wait for resources to become available.
        /// </summary>
        public override Task WaitForEnvironmentAsync()
        {
            return Task.CompletedTask;
        }
    }
}
