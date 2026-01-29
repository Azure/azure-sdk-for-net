// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.AI.Speech.Transcription.Tests;
using NUnit.Framework;

namespace Azure.AI.Speech.Transcription.Samples
{
    /// <summary>
    /// Samples demonstrating transcription from remote URLs.
    /// </summary>
    [Category("Live")]
    public partial class Sample03_TranscribeFromUrl : TranscriptionSampleBase
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
        /// Transcribes an audio file from a public URL.
        /// </summary>
        [Test]
        public async Task TranscribeFromUrl()
        {
            if (!TestConfiguration.HasSampleAudioUrl)
                Assert.Ignore("TRANSCRIPTION_SAMPLE_AUDIO_URL not configured");

#if !SNIPPET
            var client = _client;
#else
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
#endif

            #region Snippet:TranscribeFromUrl
            // Specify the URL of the audio file to transcribe
#if SNIPPET
            Uri audioUrl = new Uri("https://example.com/audio/sample.wav");
#else
            Uri audioUrl = new Uri(TestConfiguration.SampleAudioUrl);
#endif

            // Configure transcription to use the remote URL
            TranscriptionOptions options = new TranscriptionOptions(audioUrl);

            // No audio stream needed - the service fetches the file from the URL
            ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            Console.WriteLine($"Transcribed audio from URL: {audioUrl}");
            Console.WriteLine($"Duration: {result.Duration}");

            var channelPhrases = result.PhrasesByChannel.First();
            Console.WriteLine($"\nTranscription:\n{channelPhrases.Text}");
            #endregion Snippet:TranscribeFromUrl
        }
    }
}
