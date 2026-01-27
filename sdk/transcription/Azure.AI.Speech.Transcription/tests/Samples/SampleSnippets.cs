// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using Azure.AI.Speech.Transcription.Tests;
using NUnit.Framework;

namespace Azure.AI.Speech.Transcription.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    [Category("Live")]
    public partial class SampleSnippets
    {
        [Test]
        public void CreateClientForSpecificApiVersion()
        {
#if !SNIPPET
            var endpoint = TestConfiguration.Endpoint;
            var credential = TestConfiguration.Credential;
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
