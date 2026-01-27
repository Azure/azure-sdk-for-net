// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;
using System.ClientModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.AI.Speech.Transcription.Tests
{
    /// <summary>
    /// Async tests for the <see cref="TranscriptionClient"/> class.
    /// Tests audio transcription functionality against the live service.
    /// </summary>
    [TestFixture(true)]
    [Category("Transcription")]
    public class TranscriptionClientAsyncTests : TranscriptionRecordedTestBase
    {
        private const string SampleAudioFile = "sample-whatstheweatherlike-en.mp3";
        private const string SampleProfanityFile = "sample-profanity.wav";

        public TranscriptionClientAsyncTests(bool isAsync) : base(isAsync)
        {
        }

        #region Basic Transcription Tests

        [RecordedTest]
        public async Task TranscribeAudioStreamAsync()
        {
            TranscriptionClient client = CreateClient();
            string audioPath = GetAssetPath(SampleAudioFile);

            using FileStream audioStream = File.OpenRead(audioPath);
            TranscriptionOptions options = new TranscriptionOptions(audioStream);
            options.Locales.Add("en-US");

            ClientResult<TranscriptionResult> result = await client.TranscribeAsync(options);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.Not.Null);
            Assert.That(result.Value.Duration, Is.GreaterThan(TimeSpan.Zero));
            Assert.That(result.Value.PhrasesByChannel, Is.Not.Null);
        }

        [RecordedTest]
        public async Task TranscribeAudioStreamWithMultipleLocalesAsync()
        {
            TranscriptionClient client = CreateClient();
            string audioPath = GetAssetPath(SampleAudioFile);

            using FileStream audioStream = File.OpenRead(audioPath);
            TranscriptionOptions options = new TranscriptionOptions(audioStream);
            options.Locales.Add("en-US");
            options.Locales.Add("es-ES");

            ClientResult<TranscriptionResult> result = await client.TranscribeAsync(options);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.Not.Null);
            Assert.That(result.Value.Duration, Is.GreaterThan(TimeSpan.Zero));
        }

        #endregion

        #region Profanity Filter Tests

        [RecordedTest]
        public async Task TranscribeWithProfanityFilterMaskedAsync()
        {
            TranscriptionClient client = CreateClient();
            string audioPath = GetAssetPath(SampleProfanityFile);

            using FileStream audioStream = File.OpenRead(audioPath);
            TranscriptionOptions options = new TranscriptionOptions(audioStream);
            options.Locales.Add("en-US");
            options.ProfanityFilterMode = ProfanityFilterMode.Masked;

            ClientResult<TranscriptionResult> result = await client.TranscribeAsync(options);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.Not.Null);
        }

        [RecordedTest]
        public async Task TranscribeWithProfanityFilterRemovedAsync()
        {
            TranscriptionClient client = CreateClient();
            string audioPath = GetAssetPath(SampleProfanityFile);

            using FileStream audioStream = File.OpenRead(audioPath);
            TranscriptionOptions options = new TranscriptionOptions(audioStream);
            options.Locales.Add("en-US");
            options.ProfanityFilterMode = ProfanityFilterMode.Removed;

            ClientResult<TranscriptionResult> result = await client.TranscribeAsync(options);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.Not.Null);
        }

        #endregion

        #region Diarization Tests

        [RecordedTest]
        public async Task TranscribeWithDiarizationAsync()
        {
            TranscriptionClient client = CreateClient();
            string audioPath = GetAssetPath(SampleAudioFile);

            using FileStream audioStream = File.OpenRead(audioPath);
            TranscriptionOptions options = new TranscriptionOptions(audioStream);
            options.Locales.Add("en-US");
            options.DiarizationOptions = new TranscriptionDiarizationOptions
            {
                MaxSpeakers = 2
            };

            ClientResult<TranscriptionResult> result = await client.TranscribeAsync(options);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.Not.Null);
        }

        [RecordedTest]
        public async Task TranscribeWithDiarizationMaxSpeakersAsync()
        {
            TranscriptionClient client = CreateClient();
            string audioPath = GetAssetPath(SampleAudioFile);

            using FileStream audioStream = File.OpenRead(audioPath);
            TranscriptionOptions options = new TranscriptionOptions(audioStream);
            options.Locales.Add("en-US");
            options.DiarizationOptions = new TranscriptionDiarizationOptions
            {
                MaxSpeakers = 5
            };

            ClientResult<TranscriptionResult> result = await client.TranscribeAsync(options);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.Not.Null);
        }

        #endregion

        #region Phrase List Tests

        [RecordedTest]
        public async Task TranscribeWithPhraseListAsync()
        {
            TranscriptionClient client = CreateClient();
            string audioPath = GetAssetPath(SampleAudioFile);

            using FileStream audioStream = File.OpenRead(audioPath);
            TranscriptionOptions options = new TranscriptionOptions(audioStream);
            options.Locales.Add("en-US");
            options.PhraseList = new PhraseListProperties();
            options.PhraseList.Phrases.Add("weather");
            options.PhraseList.Phrases.Add("forecast");

            ClientResult<TranscriptionResult> result = await client.TranscribeAsync(options);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.Not.Null);
        }

        #endregion

        #region Combined Options Tests

        [RecordedTest]
        public async Task TranscribeWithMultipleOptionsAsync()
        {
            TranscriptionClient client = CreateClient();
            string audioPath = GetAssetPath(SampleAudioFile);

            using FileStream audioStream = File.OpenRead(audioPath);
            TranscriptionOptions options = new TranscriptionOptions(audioStream);
            options.Locales.Add("en-US");
            options.ProfanityFilterMode = ProfanityFilterMode.Masked;
            options.DiarizationOptions = new TranscriptionDiarizationOptions
            {
                MaxSpeakers = 3
            };
            options.PhraseList = new PhraseListProperties();
            options.PhraseList.Phrases.Add("weather");

            ClientResult<TranscriptionResult> result = await client.TranscribeAsync(options);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.Not.Null);
        }

        #endregion

        #region TranscriptionResult Tests

        [RecordedTest]
        public async Task TranscriptionResultHasDurationAsync()
        {
            TranscriptionClient client = CreateClient();
            string audioPath = GetAssetPath(SampleAudioFile);

            using FileStream audioStream = File.OpenRead(audioPath);
            TranscriptionOptions options = new TranscriptionOptions(audioStream);
            options.Locales.Add("en-US");

            ClientResult<TranscriptionResult> result = await client.TranscribeAsync(options);
            TranscriptionResult transcription = result.Value;

            Assert.That(transcription.Duration, Is.GreaterThan(TimeSpan.Zero));
        }

        [RecordedTest]
        public async Task TranscriptionResultHasCombinedPhrasesAsync()
        {
            TranscriptionClient client = CreateClient();
            string audioPath = GetAssetPath(SampleAudioFile);

            using FileStream audioStream = File.OpenRead(audioPath);
            TranscriptionOptions options = new TranscriptionOptions(audioStream);
            options.Locales.Add("en-US");

            ClientResult<TranscriptionResult> result = await client.TranscribeAsync(options);
            TranscriptionResult transcription = result.Value;

            Assert.That(transcription.CombinedPhrases, Is.Not.Null);
            Assert.That(transcription.CombinedPhrases.Count, Is.GreaterThan(0));
            Assert.That(transcription.CombinedPhrases.First().Text, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task TranscriptionResultHasPhrasesByChannelAsync()
        {
            TranscriptionClient client = CreateClient();
            string audioPath = GetAssetPath(SampleAudioFile);

            using FileStream audioStream = File.OpenRead(audioPath);
            TranscriptionOptions options = new TranscriptionOptions(audioStream);
            options.Locales.Add("en-US");

            ClientResult<TranscriptionResult> result = await client.TranscribeAsync(options);
            TranscriptionResult transcription = result.Value;

            var phrasesByChannel = transcription.PhrasesByChannel;
            Assert.That(phrasesByChannel, Is.Not.Null);
            Assert.That(phrasesByChannel.Count(), Is.GreaterThan(0));

            foreach (var channelPhrases in phrasesByChannel)
            {
                Assert.That(channelPhrases, Is.Not.Null);
                Assert.That(channelPhrases.Phrases, Is.Not.Null);
                Assert.That(channelPhrases.Text, Is.Not.Empty);
            }
        }

        #endregion

        #region Helper Methods

        private string GetAssetPath(string fileName)
        {
            string assemblyLocation = typeof(TranscriptionClientAsyncTests).Assembly.Location;
            string assemblyDir = Path.GetDirectoryName(assemblyLocation);
            string repoRoot = Path.GetFullPath(Path.Combine(assemblyDir, "..", "..", "..", "..", ".."));
            string assetsPath = Path.Combine(repoRoot, "sdk", "transcription", "Azure.AI.Speech.Transcription", "samples", "assets", fileName);
            assetsPath = Path.GetFullPath(assetsPath);

            if (!File.Exists(assetsPath))
            {
                Assert.Fail($"Asset file not found: {assetsPath}. Please ensure sample assets are available.");
            }

            return assetsPath;
        }

        #endregion
    }
}
