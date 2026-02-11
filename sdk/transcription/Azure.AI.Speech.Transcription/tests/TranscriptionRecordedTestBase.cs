// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;
using System.ClientModel;

namespace Azure.AI.Speech.Transcription.Tests
{
    /// <summary>
    /// Base class for Transcription SDK recorded tests.
    /// Provides test recording/playback functionality and common test utilities.
    /// </summary>
    public abstract class TranscriptionRecordedTestBase : RecordedTestBase<TranscriptionTestEnvironment>
    {
        protected TranscriptionRecordedTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
            // Sanitize sensitive headers
            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");
            SanitizedHeaders.Add("api-key");
            SanitizedHeaders.Add("X-Request-ID");
            SanitizedHeaders.Add("Date");

            // Sanitize request IDs and other dynamic values
            JsonPathSanitizers.Add("$.id");
        }

        /// <summary>
        /// Creates a TranscriptionClient for testing.
        /// This client is automatically instrumented for recording/playback and sync/async proxying.
        /// </summary>
        /// <param name="options">Optional client options. If null, defaults are used.</param>
        /// <returns>An instrumented TranscriptionClient.</returns>
        protected TranscriptionClient CreateClient(TranscriptionClientOptions options = null)
        {
            options ??= new TranscriptionClientOptions();

            // Instrument the options to enable recording/playback
            InstrumentClientOptions(options);

            // TestEnvironment.Endpoint automatically uses:
            // - Live/Record mode: Real endpoint from environment variables (via ParseEnvironmentFile)
            // - Playback mode: Endpoint from session recordings
            return CreateProxyFromClient(new TranscriptionClient(
                new Uri(TestEnvironment.Endpoint),
                new ApiKeyCredential(TestEnvironment.ApiKey),
                options));
        }
    }
}
