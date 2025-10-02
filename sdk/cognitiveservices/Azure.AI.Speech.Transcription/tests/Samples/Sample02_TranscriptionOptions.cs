// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.Speech.Transcription.Samples
{
    /// <summary>
    /// Samples demonstrating advanced transcription options.
    /// </summary>
    public partial class Sample02_TranscriptionOptions : TranscriptionSampleBase
    {
        /// <summary>
        /// Transcribe audio with specific locale settings.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeWithLocales()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            string audioFilePath = "path/to/audio.wav";
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Configure transcription options with specific locales
            TranscriptionOptions options = new TranscriptionOptions();
            options.Locales.Add("en-US");
            options.Locales.Add("es-ES"); // Add Spanish as a secondary locale

            TranscribeRequestContent request = new TranscribeRequestContent
            {
                Audio = audioStream,
                Options = options
            };

            Response<TranscriptionResult> response = await client.TranscribeAsync(request);
            TranscriptionResult result = response.Value;

            Console.WriteLine($"Transcription with locales: {string.Join(", ", options.Locales)}");
            var channelPhrases = result.PhrasesByChannel.First();
            foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
            {
                Console.WriteLine($"[{phrase.Offset}] {phrase.Text}");
            }
        }

        /// <summary>
        /// Transcribe audio with profanity filtering enabled.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeWithProfanityFilter()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeWithProfanityFilter
            string audioFilePath = "path/to/audio.wav";
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Configure profanity filtering
            TranscriptionOptions options = new TranscriptionOptions
            {
                ProfanityFilterMode = ProfanityFilterMode.Masked // Masks profanity with asterisks
            };

            TranscribeRequestContent request = new TranscribeRequestContent
            {
                Audio = audioStream,
                Options = options
            };

            Response<TranscriptionResult> response = await client.TranscribeAsync(request);
            TranscriptionResult result = response.Value;

            Console.WriteLine("Transcription with profanity filtering:");
            var channelPhrases = result.PhrasesByChannel.First();
            Console.WriteLine(channelPhrases.Text);
            #endregion Snippet:TranscribeWithProfanityFilter
        }

        /// <summary>
        /// Transcribe audio with speaker diarization (identifying different speakers).
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeWithDiarization()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            string audioFilePath = "path/to/conversation.wav";
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Enable speaker diarization
            TranscriptionOptions options = new TranscriptionOptions
            {
                Diarization = new TranscriptionDiarizationOptions
                {
                    Enabled = true,
                    MaxSpeakers = 4 // Expect up to 4 speakers in the conversation
                }
            };

            TranscribeRequestContent request = new TranscribeRequestContent
            {
                Audio = audioStream,
                Options = options
            };

            Response<TranscriptionResult> response = await client.TranscribeAsync(request);
            TranscriptionResult result = response.Value;

            Console.WriteLine("Transcription with speaker diarization:");
            var channelPhrases = result.PhrasesByChannel.First();
            foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
            {
                // Speaker information is included in the phrase
                Console.WriteLine($"Speaker {phrase.Speaker}: {phrase.Text}");
            }
        }

        /// <summary>
        /// Transcribe audio with a custom phrase list to improve recognition accuracy.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeWithPhraseList()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeWithPhraseList
            string audioFilePath = "path/to/technical-talk.wav";
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Add custom phrases to improve recognition of domain-specific terms
            TranscriptionOptions options = new TranscriptionOptions
            {
                PhraseList = new PhraseListProperties
                {
                    BiasingWeight = 5.0f // Increase weight to favor these phrases (1.0 - 20.0)
                }
            };

            // Add technical terms that might be uncommon in general speech
            options.PhraseList.Phrases.Add("Azure Cognitive Services");
            options.PhraseList.Phrases.Add("TranscriptionClient");
            options.PhraseList.Phrases.Add("speech-to-text");
            options.PhraseList.Phrases.Add("API endpoint");

            TranscribeRequestContent request = new TranscribeRequestContent
            {
                Audio = audioStream,
                Options = options
            };

            Response<TranscriptionResult> response = await client.TranscribeAsync(request);
            TranscriptionResult result = response.Value;

            Console.WriteLine("Transcription with custom phrase list:");
            var channelPhrases = result.PhrasesByChannel.First();
            Console.WriteLine(channelPhrases.Text);
            #endregion Snippet:TranscribeWithPhraseList
        }

        /// <summary>
        /// Transcribe specific channels from a multi-channel audio file.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeWithChannelSelection()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeWithChannelSelection
            string audioFilePath = "path/to/stereo-audio.wav";
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Specify which channels to transcribe separately
            TranscriptionOptions options = new TranscriptionOptions();
            options.Channels.Add(0); // Left channel
            options.Channels.Add(1); // Right channel

            TranscribeRequestContent request = new TranscribeRequestContent
            {
                Audio = audioStream,
                Options = options
            };

            Response<TranscriptionResult> response = await client.TranscribeAsync(request);
            TranscriptionResult result = response.Value;

            // Each channel is transcribed separately
            Console.WriteLine("Multi-channel transcription:");
            foreach (var channelPhrases in result.PhrasesByChannel)
            {
                Console.WriteLine($"\nChannel {channelPhrases.Channel}:");
                Console.WriteLine(channelPhrases.Text);
            }
            #endregion Snippet:TranscribeWithChannelSelection
        }

        /// <summary>
        /// Transcribe audio using a custom model.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeWithCustomModel()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeWithCustomModel
            string audioFilePath = "path/to/audio.wav";
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Map locales to custom trained models
            TranscriptionOptions options = new TranscriptionOptions();
            options.Locales.Add("en-US");

            // Use a custom model for English transcription
            Uri customModelEndpoint = new Uri(
                "https://myaccount.api.cognitive.microsoft.com/speechtotext/models/your-custom-model-id");
            options.Models.Add("en-US", customModelEndpoint);

            TranscribeRequestContent request = new TranscribeRequestContent
            {
                Audio = audioStream,
                Options = options
            };

            Response<TranscriptionResult> response = await client.TranscribeAsync(request);
            TranscriptionResult result = response.Value;

            Console.WriteLine("Transcription with custom model:");
            var channelPhrases = result.PhrasesByChannel.First();
            Console.WriteLine(channelPhrases.Text);
            #endregion Snippet:TranscribeWithCustomModel
        }

        /// <summary>
        /// Combines multiple transcription options for complex scenarios.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeWithMultipleOptions()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeWithMultipleOptions
            string audioFilePath = "path/to/meeting.wav";
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Combine multiple options for a complete transcription solution
            TranscriptionOptions options = new TranscriptionOptions
            {
                ProfanityFilterMode = ProfanityFilterMode.Masked,
                Diarization = new TranscriptionDiarizationOptions
                {
                    Enabled = true,
                    MaxSpeakers = 5
                },
                PhraseList = new PhraseListProperties
                {
                    BiasingWeight = 3.0f
                }
            };

            // Add locale and custom phrases
            options.Locales.Add("en-US");
            options.PhraseList.Phrases.Add("quarterly report");
            options.PhraseList.Phrases.Add("action items");
            options.PhraseList.Phrases.Add("stakeholders");

            TranscribeRequestContent request = new TranscribeRequestContent
            {
                Audio = audioStream,
                Options = options
            };

            Response<TranscriptionResult> response = await client.TranscribeAsync(request);
            TranscriptionResult result = response.Value;

            Console.WriteLine($"Meeting transcription ({result.Duration}):");
            var channelPhrases = result.PhrasesByChannel.First();
            foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
            {
                Console.WriteLine($"[Speaker {phrase.Speaker}] {phrase.Text}");
            }
            #endregion Snippet:TranscribeWithMultipleOptions
        }
    }
}
