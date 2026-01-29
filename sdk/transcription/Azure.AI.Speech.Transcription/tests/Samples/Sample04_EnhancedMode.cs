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
    /// Samples demonstrating LLM-powered Enhanced Mode for transcription and translation.
    /// </summary>
    [Category("Live")]
    public partial class Sample04_EnhancedMode : TranscriptionSampleBase
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
        /// Transcribe audio using Enhanced Mode for improved quality.
        /// </summary>
        [Test]
        public async Task TranscribeWithEnhancedMode()
        {
#if !SNIPPET
            var client = _client;
#else
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
#endif

            #region Snippet:TranscribeWithEnhancedMode
#if SNIPPET
            string audioFilePath = "path/to/audio.wav";
#else
            string audioFilePath = TestConfiguration.SampleChineseAudioFilePath;
#endif
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Enhanced mode is automatically enabled
            EnhancedModeProperties enhancedMode = new EnhancedModeProperties
            {
                Task = "transcribe"
            };

            TranscriptionOptions options = new TranscriptionOptions(audioStream)
            {
                EnhancedMode = enhancedMode
            };

            ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            var channelPhrases = result.PhrasesByChannel.First();
            Console.WriteLine(channelPhrases.Text);
            #endregion Snippet:TranscribeWithEnhancedMode
        }

        /// <summary>
        /// Translate speech to another language using Enhanced Mode.
        /// </summary>
        [Test]
        public async Task TranslateWithEnhancedMode()
        {
#if !SNIPPET
            var client = _client;
#else
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
#endif

            #region Snippet:TranslateWithEnhancedMode
#if SNIPPET
            string audioFilePath = "path/to/chinese-audio.wav";
#else
            string audioFilePath = TestConfiguration.SampleChineseAudioFilePath;
#endif
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Translate Chinese speech to Korean
            EnhancedModeProperties enhancedMode = new EnhancedModeProperties
            {
                Task = "translate",
                TargetLanguage = "ko"  // Translate to Korean
            };

            TranscriptionOptions options = new TranscriptionOptions(audioStream)
            {
                EnhancedMode = enhancedMode
            };

            ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            Console.WriteLine("Translated to Korean:");
            var channelPhrases = result.PhrasesByChannel.First();
            Console.WriteLine(channelPhrases.Text);
            #endregion Snippet:TranslateWithEnhancedMode
        }

        /// <summary>
        /// Use prompts to guide output format and improve recognition.
        /// </summary>
        [Test]
        public async Task EnhancedModeWithPrompts()
        {
#if !SNIPPET
            var client = _client;
#else
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
#endif

            #region Snippet:EnhancedModeWithPrompts
#if SNIPPET
            string audioFilePath = "path/to/audio.wav";
#else
            string audioFilePath = TestConfiguration.SampleEnglishAudioFilePath;
#endif
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Guide output formatting using prompts
            EnhancedModeProperties enhancedMode = new EnhancedModeProperties
            {
                Task = "transcribe",
                Prompt = { "Output must be in lexical format." }
            };

            TranscriptionOptions options = new TranscriptionOptions(audioStream)
            {
                EnhancedMode = enhancedMode
            };

            ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            var channelPhrases = result.PhrasesByChannel.First();
            Console.WriteLine(channelPhrases.Text);
            #endregion Snippet:EnhancedModeWithPrompts
        }

        /// <summary>
        /// Combine Enhanced Mode with diarization and profanity filtering.
        /// </summary>
        [Test]
        public async Task EnhancedModeWithDiarization()
        {
#if !SNIPPET
            var client = _client;
#else
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
#endif

            #region Snippet:EnhancedModeWithDiarization
#if SNIPPET
            string audioFilePath = "path/to/meeting.wav";
#else
            string audioFilePath = TestConfiguration.SampleAudioFilePath;
#endif
            using FileStream audioStream = File.OpenRead(audioFilePath);

            EnhancedModeProperties enhancedMode = new EnhancedModeProperties
            {
                Task = "transcribe",
                Prompt = { "Output must be in lexical format." }
            };

            TranscriptionOptions options = new TranscriptionOptions(audioStream)
            {
                EnhancedMode = enhancedMode,
                ProfanityFilterMode = ProfanityFilterMode.Masked,
                DiarizationOptions = new TranscriptionDiarizationOptions
                {
                    MaxSpeakers = 2
                }
            };

            ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            var channelPhrases = result.PhrasesByChannel.First();
            foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
            {
                Console.WriteLine($"[Speaker {phrase.Speaker}] {phrase.Text}");
            }
            #endregion Snippet:EnhancedModeWithDiarization
        }
    }
}
