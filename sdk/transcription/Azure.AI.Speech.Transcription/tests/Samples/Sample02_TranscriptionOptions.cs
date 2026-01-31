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
    /// Samples demonstrating advanced transcription options.
    /// </summary>
    [ClientTestFixture]
    [Category("Live")]
    public partial class Sample02_TranscriptionOptions : TranscriptionSampleBase
    {
        public Sample02_TranscriptionOptions(bool isAsync) : base(isAsync) { }

        /// <summary>
        /// Combines multiple transcription options for complex scenarios.
        /// </summary>
        [RecordedTest]
        public async Task TranscribeWithMultipleOptions()
        {
#if !SNIPPET
            var client = CreateClient();
#else
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
#endif

            #region Snippet:TranscribeWithMultipleOptions
#if SNIPPET
            string audioFilePath = "path/to/meeting.wav";
#else
            string audioFilePath = TestEnvironment.SampleAudioPath;
#endif
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Create TranscriptionOptions with audio stream
            TranscriptionOptions options = new TranscriptionOptions(audioStream);

            // Enable speaker diarization to identify different speakers
            options.DiarizationOptions = new TranscriptionDiarizationOptions
            {
                MaxSpeakers = 5 // Enabled is automatically set to true
            };

            // Mask profanity in the transcription
            options.ProfanityFilterMode = ProfanityFilterMode.Masked;

            // Add custom phrases to improve recognition of domain-specific terms
            // These phrases help the service correctly recognize words that might be misheard
            options.PhraseList = new PhraseListProperties();
            options.PhraseList.Phrases.Add("action items");
            options.PhraseList.Phrases.Add("Q4");
            options.PhraseList.Phrases.Add("KPIs");

            ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            // Display results
            Console.WriteLine($"Duration: {result.Duration.TotalSeconds:F1}s | Speakers: {result.PhrasesByChannel.First().Phrases.Select(p => p.Speaker).Distinct().Count()}");
            Console.WriteLine();
            Console.WriteLine("Full Transcript:");
            Console.WriteLine(result.CombinedPhrases.First().Text);
            #endregion Snippet:TranscribeWithMultipleOptions
        }
    }
}
