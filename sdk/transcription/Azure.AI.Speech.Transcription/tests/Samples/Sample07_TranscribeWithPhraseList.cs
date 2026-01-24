// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Speech.Transcription.Tests;
using NUnit.Framework;

namespace Azure.AI.Speech.Transcription.Samples
{
    /// <summary>
    /// Samples demonstrating custom phrase list for improved recognition accuracy.
    /// </summary>
    public partial class Sample07_TranscribeWithPhraseList : TranscriptionSampleBase
    {
#if !SNIPPET
        private TranscriptionClient _client;

        [OneTimeSetUp]
        public void Setup()
        {
            _client = TestConfiguration.CreateClient();
        }
#endif

        /// <summary>
        /// Transcribe audio with a custom phrase list to improve recognition accuracy.
        /// </summary>
        [Test]
        public async Task TranscribeWithPhraseList()
        {
#if !SNIPPET
            var client = _client;
#else
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
#endif

            #region Snippet:TranscribeWithPhraseListSample
#if SNIPPET
            string audioFilePath = "path/to/audio.wav";
#else
            string audioFilePath = TestConfiguration.SampleAudioFilePath;
#endif
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Add custom phrases to improve recognition of names and domain-specific terms
            TranscriptionOptions options = new TranscriptionOptions(audioStream)
            {
                PhraseList = new PhraseListProperties()
            };

            // Add names, locations, and terms that might be misrecognized
            // For example, "Jessie" might be recognized as "Jesse", or "Contoso" as "can't do so"
            options.PhraseList.Phrases.Add("Contoso");
            options.PhraseList.Phrases.Add("Jessie");
            options.PhraseList.Phrases.Add("Rehaan");

            ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            Console.WriteLine("Transcription with custom phrase list:");
            var channelPhrases = result.PhrasesByChannel.First();
            Console.WriteLine(channelPhrases.Text);
            #endregion Snippet:TranscribeWithPhraseListSample
        }
    }
}
