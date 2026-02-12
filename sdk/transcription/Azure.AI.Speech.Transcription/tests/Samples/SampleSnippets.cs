// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using Azure.AI.Speech.Transcription.Tests;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Speech.Transcription.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    [ClientTestFixture]
    [Category("Live")]
    public partial class SampleSnippets : TranscriptionSampleBase
    {
        public SampleSnippets(bool isAsync) : base(isAsync) { }

        [RecordedTest]
        public void CreateClientForSpecificApiVersion()
        {
#if !SNIPPET
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var credential = new ApiKeyCredential(TestEnvironment.ApiKey);
#endif
            #region Snippet:CreateTranscriptionClientForSpecificApiVersion
#if SNIPPET
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new("your apikey");
#endif
            TranscriptionClientOptions options = new TranscriptionClientOptions(TranscriptionClientOptions.ServiceVersion.V20251015);
            TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);
            #endregion Snippet:CreateTranscriptionClientForSpecificApiVersion
        }
    }
}
