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
        /// Parses environment variables into the test environment.
        /// Called during test setup to populate recorded variables.
        /// </summary>
        public override Dictionary<string, string> ParseEnvironmentFile() => new()
        {
            { "TRANSCRIPTION_ENDPOINT", Environment.GetEnvironmentVariable("TRANSCRIPTION_ENDPOINT") ?? "https://test-endpoint.cognitiveservices.azure.com/" },
            { "TRANSCRIPTION_API_KEY", Environment.GetEnvironmentVariable("TRANSCRIPTION_API_KEY") ?? "api-key" }
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
