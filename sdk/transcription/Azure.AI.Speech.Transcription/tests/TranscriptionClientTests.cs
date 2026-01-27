// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;
using System.ClientModel;
using System.IO;
using System.Threading.Tasks;

namespace Azure.AI.Speech.Transcription.Tests
{
    /// <summary>
    /// Unit and validation tests for the <see cref="TranscriptionClient"/> class (sync methods).
    /// Tests client construction, validation, and error handling.
    /// </summary>
    [TestFixture(false)]  // Run sync tests only
    [Category("Transcription")]
    public class TranscriptionClientTests : TranscriptionRecordedTestBase
    {
        private const string SampleAudioFile = "sample-whatstheweatherlike-en.mp3";
        private const string SampleProfanityFile = "sample-profanity.wav";

        public TranscriptionClientTests(bool isAsync) : base(isAsync)
        {
        }

        #region Client Construction Tests

        /// <summary>
        /// Tests that the client can be created successfully.
        /// </summary>
        [RecordedTest]
        public void CanCreateClient()
        {
            TranscriptionClient client = CreateClient();
            Assert.That(client, Is.Not.Null);
        }

        /// <summary>
        /// Tests that the client options can be configured.
        /// </summary>
        [Test]
        public void ClientOptionsCanBeConfigured()
        {
            var options = new TranscriptionClientOptions();
            Assert.That(options, Is.Not.Null);
        }

        /// <summary>
        /// Tests that the client constructor validates arguments.
        /// </summary>
        [Test]
        public void ClientConstructorValidatesArguments()
        {
            Uri validEndpoint = new Uri("https://test.cognitiveservices.azure.com");
            ApiKeyCredential validCredential = new ApiKeyCredential("test-key");

            // Test null endpoint
            Assert.Throws<ArgumentNullException>(() =>
                new TranscriptionClient(null, validCredential));

            // Test null credential
            Assert.Throws<ArgumentNullException>(() =>
                new TranscriptionClient(validEndpoint, (ApiKeyCredential)null));
        }

        #endregion

        #region Basic Transcription Tests

        [RecordedTest]
        public async Task TranscribeAudioStream()
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
        public async Task TranscribeAudioStreamWithMultipleLocales()
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
        public async Task TranscribeWithProfanityFilterMasked()
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
        public async Task TranscribeWithProfanityFilterRemoved()
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
        public async Task TranscribeWithDiarization()
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
        public async Task TranscribeWithDiarizationMaxSpeakers()
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
        public async Task TranscribeWithPhraseList()
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
        public async Task TranscribeWithMultipleOptions()
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
        public async Task TranscriptionResultHasDuration()
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
        public async Task TranscriptionResultHasCombinedPhrases()
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
        }

        [RecordedTest]
        public async Task TranscriptionResultHasPhrasesByChannel()
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
        }

        #endregion

        #region Validation Tests

        /// <summary>
        /// Tests that Transcribe (sync) validates null options parameter.
        /// </summary>
        [RecordedTest]
        public async Task TranscribeValidatesNullOptions()
        {
            TranscriptionClient client = CreateClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.TranscribeAsync((TranscriptionOptions)null));
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Gets the full path to an asset file in the samples/assets directory.
        /// </summary>
        private string GetAssetPath(string fileName)
        {
            string assemblyLocation = typeof(TranscriptionClientTests).Assembly.Location;
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
