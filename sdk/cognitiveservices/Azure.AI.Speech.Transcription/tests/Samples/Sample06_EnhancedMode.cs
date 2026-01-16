// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.Speech.Transcription.Samples
{
    /// <summary>
    /// Samples demonstrating LLM-powered Enhanced Mode for transcription and translation.
    /// </summary>
    public partial class Sample06_EnhancedMode : TranscriptionSampleBase
    {
        /// <summary>
        /// Transcribe audio using Enhanced Mode for improved quality.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeWithEnhancedMode()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeWithEnhancedMode
            string audioFilePath = "path/to/audio.wav";
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
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeWithTranslation()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeWithTranslation
            string audioFilePath = "path/to/spanish-audio.wav";
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Translate Spanish speech to English
            EnhancedModeProperties enhancedMode = new EnhancedModeProperties
            {
                Task = "translate",
                TargetLanguage = "en"  // Translate to English
            };

            TranscriptionOptions options = new TranscriptionOptions(audioStream)
            {
                EnhancedMode = enhancedMode
            };

            ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            Console.WriteLine("Translated to English:");
            var channelPhrases = result.PhrasesByChannel.First();
            Console.WriteLine(channelPhrases.Text);
            #endregion Snippet:TranscribeWithTranslation
        }

        /// <summary>
        /// Use prompts to guide output format and improve recognition.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeWithEnhancedPrompts()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeWithEnhancedPrompts
            string audioFilePath = "path/to/audio.wav";
            using FileStream audioStream = File.OpenRead(audioFilePath);

            EnhancedModeProperties enhancedMode = new EnhancedModeProperties
            {
                Task = "transcribe"
            };

            // Guide output formatting
            enhancedMode.Prompt.Add("Output must be in lexical format.");
            // Or improve recognition of specific terms
            enhancedMode.Prompt.Add("Pay attention to Azure, OpenAI, Kubernetes.");

            TranscriptionOptions options = new TranscriptionOptions(audioStream)
            {
                EnhancedMode = enhancedMode
            };

            ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            var channelPhrases = result.PhrasesByChannel.First();
            Console.WriteLine(channelPhrases.Text);
            #endregion Snippet:TranscribeWithEnhancedPrompts
        }

        /// <summary>
        /// Combine Enhanced Mode with diarization and profanity filtering.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeWithEnhancedAndDiarization()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeWithEnhancedAndDiarization
            string audioFilePath = "path/to/meeting.wav";
            using FileStream audioStream = File.OpenRead(audioFilePath);

            EnhancedModeProperties enhancedMode = new EnhancedModeProperties
            {
                Task = "transcribe"
            };
            enhancedMode.Prompt.Add("Output must be in lexical format.");

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
            #endregion Snippet:TranscribeWithEnhancedAndDiarization
        }
    }
}
