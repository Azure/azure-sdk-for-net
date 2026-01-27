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
    /// Samples demonstrating locale configuration for transcription.
    /// </summary>
    [Category("Live")]
    public partial class Sample08_TranscribeWithLocales : TranscriptionSampleBase
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
        /// Transcribe audio with a known locale specified.
        /// When you know the language of the audio, specifying a single locale
        /// improves transcription accuracy and minimizes latency.
        /// </summary>
        [Test]
        public async Task TranscribeWithKnownLocale()
        {
#if !SNIPPET
            var client = _client;
#else
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
#endif

            #region Snippet:TranscribeWithKnownLocale
#if SNIPPET
            string audioFilePath = "path/to/english-audio.mp3";
#else
            string audioFilePath = TestConfiguration.SampleEnglishAudioFilePath;
#endif
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // When you know the locale of the audio, specify a single locale
            // to improve transcription accuracy and minimize latency
            TranscriptionOptions options = new TranscriptionOptions(audioStream);
            options.Locales.Add("en-US");

            ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            Console.WriteLine("Transcription with known locale (en-US):");
            var channelPhrases = result.PhrasesByChannel.First();
            Console.WriteLine(channelPhrases.Text);
            #endregion Snippet:TranscribeWithKnownLocale
        }

        /// <summary>
        /// Transcribe audio with language identification enabled.
        /// When you're not sure about the locale, specify multiple candidate locales
        /// and the service will identify the language (one locale per audio file).
        /// </summary>
        [Test]
        public async Task TranscribeWithLanguageIdentification()
        {
#if !SNIPPET
            var client = _client;
#else
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
#endif

            #region Snippet:TranscribeWithLanguageIdentification
#if SNIPPET
            string audioFilePath = "path/to/english-audio.mp3";
#else
            string audioFilePath = TestConfiguration.SampleEnglishAudioFilePath;
#endif
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // When you're not sure about the locale, specify multiple candidate locales
            // The service will identify the language (one locale per audio file)
            TranscriptionOptions options = new TranscriptionOptions(audioStream);
            options.Locales.Add("en-US");
            options.Locales.Add("es-ES");

            ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            Console.WriteLine("Transcription with language identification:");
            var channelPhrases = result.PhrasesByChannel.First();

            // The detected locale is available in each phrase
            foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
            {
                Console.WriteLine($"[{phrase.Locale}] {phrase.Text}");
            }
            #endregion Snippet:TranscribeWithLanguageIdentification
        }
    }
}
