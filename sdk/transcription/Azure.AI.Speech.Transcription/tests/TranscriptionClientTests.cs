// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.Speech.Transcription.Tests
{
    /// <summary>
    /// Tests for the <see cref="TranscriptionClient"/> class.
    /// </summary>
    [TestFixture]
    public class TranscriptionClientTests
    {
        /// <summary>
        /// Creates a TranscriptionClient for testing.
        /// </summary>
        protected TranscriptionClient CreateClient()
        {
            return TestConfiguration.CreateClient();
        }

        /// <summary>
        /// Tests that the client can be created successfully.
        /// </summary>
        [Test]
        [Category("Live")]
        public void CanCreateClient()
        {
            // Try to create client - this will load .env file if present
            try
            {
                TranscriptionClient client = CreateClient();
                Assert.IsNotNull(client);
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("TRANSCRIPTION_ENDPOINT"))
            {
                Assert.Ignore("TRANSCRIPTION_ENDPOINT not configured. Skipping live test.");
            }
        }

        /// <summary>
        /// Tests that the client options can be configured.
        /// </summary>
        [Test]
        public void ClientOptionsCanBeConfigured()
        {
            var options = new TranscriptionClientOptions();
            Assert.IsNotNull(options);
        }

        /// <summary>
        /// Tests that the client can transcribe an audio file.
        /// Requires valid credentials in .env file.
        /// </summary>
        [Test]
        [Category("Live")]
        public async Task CanTranscribeAudio()
        {
            TranscriptionClient client;
            try
            {
                client = CreateClient();
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("TRANSCRIPTION_ENDPOINT") || ex.Message.Contains("TRANSCRIPTION_API_KEY"))
            {
                Assert.Ignore("Credentials not configured. Skipping live test.");
                return;
            }

            string audioPath = TestConfiguration.SampleAudioFilePath;
            if (!File.Exists(audioPath))
            {
                Assert.Ignore($"Sample audio file not found at: {audioPath}");
            }

            using FileStream audioStream = File.OpenRead(audioPath);
            var options = new TranscriptionOptions(audioStream);

            var response = await client.TranscribeAsync(options);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            Assert.IsTrue(response.Value.Duration > TimeSpan.Zero);
            Assert.IsTrue(response.Value.PhrasesByChannel.Any());
        }
    }
}
