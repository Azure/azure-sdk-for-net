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
    /// Samples demonstrating profanity filtering options.
    /// </summary>
    [Category("Live")]
    public partial class Sample05_TranscribeWithProfanityFilter : TranscriptionSampleBase
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
        /// Transcribe audio with profanity filtering enabled, demonstrating all filter modes.
        /// </summary>
        [Test]
        public async Task TranscribeWithProfanityFilter()
        {
#if !SNIPPET
            var client = _client;
#else
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
#endif

            #region Snippet:TranscribeWithProfanityFilter
#if SNIPPET
            string audioFilePath = "path/to/audio-with-profanity.wav";
#else
            string audioFilePath = TestConfiguration.SampleProfanityAudioFilePath;
#endif

            // Demonstrate all four profanity filter modes (default is Masked)
            ProfanityFilterMode[] filterModes = new[]
            {
                ProfanityFilterMode.None,    // No filtering - profanity appears as spoken
                ProfanityFilterMode.Masked,  // Default - profanity is replaced with asterisks (e.g., "f***")
                ProfanityFilterMode.Removed, // Profanity is completely removed from the text
                ProfanityFilterMode.Tags     // Profanity is wrapped in XML tags (e.g., "<profanity>word</profanity>")
            };

            foreach (ProfanityFilterMode filterMode in filterModes)
            {
                using FileStream audioStream = File.OpenRead(audioFilePath);

                TranscriptionOptions options = new TranscriptionOptions(audioStream)
                {
                    ProfanityFilterMode = filterMode
                };

                ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
                TranscriptionResult result = response.Value;

                Console.WriteLine($"ProfanityFilterMode.{filterMode}:");
                var channelPhrases = result.PhrasesByChannel.First();
                Console.WriteLine($"  {channelPhrases.Text}");
                Console.WriteLine();
            }
            #endregion Snippet:TranscribeWithProfanityFilter
        }
    }
}
