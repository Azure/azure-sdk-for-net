// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using Azure.AI.Speech.Transcription.Tests;
using Microsoft.ClientModel.TestFramework;

namespace Azure.AI.Speech.Transcription.Samples
{
    /// <summary>
    /// Base class for transcription samples, providing helper methods for client creation.
    /// Inherits from TranscriptionRecordedTestBase to use the test framework's TestEnvironment.
    /// </summary>
    public class TranscriptionSampleBase : TranscriptionRecordedTestBase
    {
        public TranscriptionSampleBase(bool isAsync) : base(isAsync)
        {
        }

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
            // Use test framework's CreateClient which integrates with recordings
            return CreateClient();
#endif
        }

        /// <summary>
        /// Creates an authenticated TranscriptionClient with custom options.
        /// </summary>
        protected TranscriptionClient CreateTranscriptionClient(TranscriptionClientOptions options)
        {
            return CreateClient(options);
        }

        /// <summary>
        /// Gets the path to the sample audio file for testing.
        /// </summary>
        protected string GetSampleAudioFilePath()
        {
            return TestEnvironment.SampleAudioPath;
        }

        /// <summary>
        /// Gets the full path to an asset file in the samples\assets directory.
        /// </summary>
        protected string GetAssetPath(string fileName)
        {
            string assemblyLocation = typeof(TranscriptionSampleBase).Assembly.Location;
            string assemblyDir = System.IO.Path.GetDirectoryName(assemblyLocation);
            string repoRoot = System.IO.Path.GetFullPath(System.IO.Path.Combine(assemblyDir, "..", "..", "..", "..", ".."));
            string assetsPath = System.IO.Path.Combine(repoRoot, "sdk", "transcription", "Azure.AI.Speech.Transcription", "samples", "assets", fileName);
            assetsPath = System.IO.Path.GetFullPath(assetsPath);

            if (!System.IO.File.Exists(assetsPath))
            {
                throw new System.IO.FileNotFoundException($"Asset file not found: {assetsPath}. Please ensure sample assets are available.");
            }

            return assetsPath;
        }
    }
}
