// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Speech.Transcription.Tests;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Speech.Transcription.Samples
{
    /// <summary>
    /// Samples demonstrating multilingual transcription (preview).
    /// </summary>    [ClientTestFixture]    [Category("Live")]
    public partial class Sample09_MultilingualTranscription : TranscriptionSampleBase
    {
        public Sample09_MultilingualTranscription(bool isAsync) : base(isAsync) { }

        /// <summary>
        /// Transcribe audio with multilingual transcription enabled (preview).
        /// When your audio contains multilingual content that switches between languages,
        /// use the multilingual model by not specifying any locales.
        /// </summary>
        [RecordedTest]
        public async Task TranscribeWithMultilingualModel()
        {
#if !SNIPPET
            var client = CreateClient();
#else
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
#endif

            #region Snippet:TranscribeWithMultilingualModel
#if SNIPPET
            string audioFilePath = "path/to/multilingual-audio.wav";
#else
            string audioFilePath = TestEnvironment.SampleAudioPath;
#endif
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // For multilingual content, do not specify any locales
            TranscriptionOptions options = new TranscriptionOptions(audioStream);

            ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;
            #endregion Snippet:TranscribeWithMultilingualModel

            // Log results - show major locale and combined text
            var channelPhrases = result.PhrasesByChannel.First();
            var majorLocale = channelPhrases.Phrases.First().Locale;
            Console.WriteLine($"Multilingual transcription (Major locale: {majorLocale}):");
            Console.WriteLine(result.CombinedPhrases.First().Text);
        }
    }
}
