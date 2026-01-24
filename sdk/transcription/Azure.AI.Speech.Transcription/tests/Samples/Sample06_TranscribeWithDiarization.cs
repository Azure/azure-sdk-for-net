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
    /// Samples demonstrating speaker diarization (identifying different speakers).
    /// </summary>
    public partial class Sample06_TranscribeWithDiarization : TranscriptionSampleBase
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
        /// Transcribe audio with speaker diarization (identifying different speakers).
        /// </summary>
        [Test]
        public async Task TranscribeWithDiarization()
        {
#if !SNIPPET
            var client = _client;
#else
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
#endif

            #region Snippet:TranscribeWithDiarizationSample
#if SNIPPET
            string audioFilePath = "path/to/conversation.wav";
#else
            string audioFilePath = TestConfiguration.SampleAudioFilePath;
#endif
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Enable speaker diarization
            TranscriptionOptions options = new TranscriptionOptions(audioStream)
            {
                DiarizationOptions = new TranscriptionDiarizationOptions
                {
                    // Enabled is automatically set to true when MaxSpeakers is specified
                    MaxSpeakers = 4 // Expect up to 4 speakers in the conversation
                }
            };

            ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            Console.WriteLine("Transcription with speaker diarization:");
            var channelPhrases = result.PhrasesByChannel.First();
            foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
            {
                // Speaker information is included in the phrase
                Console.WriteLine($"Speaker {phrase.Speaker}: {phrase.Text}");
            }
            #endregion Snippet:TranscribeWithDiarizationSample
        }
    }
}
