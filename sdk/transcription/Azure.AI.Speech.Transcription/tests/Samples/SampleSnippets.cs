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
    /// Samples that are used in the associated README.md file.
    /// </summary>
    [Category("Live")]
    public partial class SampleSnippets
    {
#if !SNIPPET
        private TranscriptionClient _client;

        [OneTimeSetUp]
        public void Setup()
        {
            _client = TestConfiguration.CreateClient();
        }
#endif

        [Test]
        public void CreateClientForSpecificApiVersion()
        {
#if !SNIPPET
            var endpoint = TestConfiguration.Endpoint;
            var credential = TestConfiguration.Credential;
#endif
            #region Snippet:CreateTranscriptionClientForSpecificApiVersion
#if SNIPPET
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new("your apikey");
#endif
            TranscriptionClientOptions options = new TranscriptionClientOptions(TranscriptionClientOptions.ServiceVersion.V20251015);
            TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);
            #endregion Snippet:CreateTranscriptionClientForSpecificApiVersion
        }

        [Test]
        public void TranscribeLocalFileSync()
        {
#if !SNIPPET
            var client = _client;
#endif
            #region Snippet:TranscribeLocalFileSync
#if SNIPPET
            string filePath = "path/to/audio.wav";
            TranscriptionClient client = CreateTranscriptionClient();
#else
            string filePath = TestConfiguration.SampleAudioFilePath;
#endif
            using (FileStream fileStream = File.Open(filePath, FileMode.Open))
            {
                var options = new TranscriptionOptions(fileStream);
                var response = client.Transcribe(options);

                Console.WriteLine($"File Duration: {response.Value.Duration}");
                foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
                {
                    Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
                }
            }
            #endregion Snippet:TranscribeLocalFileSync
        }

        [Test]
        public async Task TranscribeLocalFileAsync()
        {
#if !SNIPPET
            var client = _client;
#endif
            #region Snippet:TranscribeLocalFileAsync
#if SNIPPET
            string filePath = "path/to/audio.wav";
            TranscriptionClient client = CreateTranscriptionClient();
#else
            string filePath = TestConfiguration.SampleAudioFilePath;
#endif
            using (FileStream fileStream = File.Open(filePath, FileMode.Open))
            {
                var options = new TranscriptionOptions(fileStream);
                var response = await client.TranscribeAsync(options);

                Console.WriteLine($"File Duration: {response.Value.Duration}");
                foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
                {
                    Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
                }
            }
            #endregion Snippet:TranscribeLocalFileAsync
        }

        [Test]
        public void TranscribeFromUrlSync()
        {
            if (!TestConfiguration.HasSampleAudioUrl)
                Assert.Ignore("TRANSCRIPTION_SAMPLE_AUDIO_URL not configured");

            #region Snippet:TranscribeFromUrlSync
#if SNIPPET
            TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new ApiKeyCredential("your apikey"));
            Uri audioUrl = new Uri("https://your-domain.com/your-file.wav");
#else
            var client = _client;
            Uri audioUrl = new Uri(TestConfiguration.SampleAudioUrl);
#endif
            // Transcribe directly from URL - the service fetches the audio
            var options = new TranscriptionOptions(audioUrl);
            var response = client.Transcribe(options);

            Console.WriteLine($"File Duration: {response.Value.Duration}");
            foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
            {
                Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
            }
            #endregion Snippet:TranscribeFromUrlSync
        }

        [Test]
        public async Task TranscribeFromUrlAsync()
        {
            if (!TestConfiguration.HasSampleAudioUrl)
                Assert.Ignore("TRANSCRIPTION_SAMPLE_AUDIO_URL not configured");

            #region Snippet:TranscribeFromUrlAsync
#if SNIPPET
            TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new ApiKeyCredential("your apikey"));
            Uri audioUrl = new Uri("https://your-domain.com/your-file.wav");
#else
            var client = _client;
            Uri audioUrl = new Uri(TestConfiguration.SampleAudioUrl);
#endif
            // Transcribe directly from URL - the service fetches the audio
            var options = new TranscriptionOptions(audioUrl);
            var response = await client.TranscribeAsync(options);

            Console.WriteLine($"File Duration: {response.Value.Duration}");
            foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
            {
                Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
            }
            #endregion Snippet:TranscribeFromUrlAsync
        }

        [Test]
        public async Task TranscribeWithDiarization()
        {
            #region Snippet:TranscribeWithDiarization
#if SNIPPET
            string filePath = "path/to/audio.wav";
            TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new ApiKeyCredential("your apikey"));
#else
            string filePath = TestConfiguration.SampleAudioFilePath;
            var client = _client;
#endif
            using (FileStream fileStream = File.Open(filePath, FileMode.Open))
            {
                var options = new TranscriptionOptions(fileStream)
                {
                    DiarizationOptions = new()
                    {
                        // Enabled is automatically set to true when MaxSpeakers is specified
                        MaxSpeakers = 2
                    }
                };

                var response = await client.TranscribeAsync(options);

                Console.WriteLine($"File Duration: {response.Value.Duration}");
                foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
                {
                    Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration} [{phrase.Speaker}]: {phrase.Text}");
                }
            }
            #endregion Snippet:TranscribeWithDiarization
        }
    }
}
