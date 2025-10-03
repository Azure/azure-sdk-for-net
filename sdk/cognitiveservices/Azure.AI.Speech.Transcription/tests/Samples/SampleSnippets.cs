// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Speech.Transcription.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class SampleSnippets : SamplesBase<TranscriptionClientTestEnvironment>
    {
        [Test]
        public void CreateClientForSpecificApiVersion()
        {
#if !SNIPPET
            var endpoint = TestEnvironment.Endpoint;
            var credential = TestEnvironment.Credential;
#endif
            #region Snippet:CreateTranscriptionClientForSpecificApiVersion
#if SNIPPET
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new("your apikey");
#endif
            TranscriptionClientOptions options = new TranscriptionClientOptions(TranscriptionClientOptions.ServiceVersion.V2025_10_15);
            TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);
            #endregion Snippet:CreateTranscriptionClientForSpecificApiVersion
        }

        [Test]
        public void TranscribeLocalFileSync()
        {
#if !SNIPPET
            var client = CreateTestClient();
            string filePath = "path/to/audio.wav";
#endif
            #region Snippet:TranscribeLocalFileSync
            using (FileStream fileStream = File.Open(filePath, FileMode.Open))
            {
                var request = new TranscribeRequestContent { Audio = fileStream };
                var response = client.Transcribe(request);

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
            var client = CreateTestClient();
            string filePath = "path/to/audio.wav";
#endif
            #region Snippet:TranscribeLocalFileAsync
            using (FileStream fileStream = File.Open(filePath, FileMode.Open))
            {
                var request = new TranscribeRequestContent { Audio = fileStream };
                var response = await client.TranscribeAsync(request);

                Console.WriteLine($"File Duration: {response.Value.Duration}");
                foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
                {
                    Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
                }
            }
            #endregion Snippet:TranscribeLocalFileAsync
        }

        [Test]
        public void TranscribeRemoteFileSync()
        {
#if !SNIPPET
            var client = CreateTestClient();
#endif
            #region Snippet:TranscribeRemoteFileSync
            using HttpClient httpClient = new HttpClient();
            using HttpResponseMessage httpResponse = httpClient.GetAsync("https://your-domain.com/your-file.mp3").Result;
            using Stream stream = httpResponse.Content.ReadAsStreamAsync().Result;

            var request = new TranscribeRequestContent { Audio = stream };
            var response = client.Transcribe(request);

            Console.WriteLine($"File Duration: {response.Value.Duration}");
            foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
            {
                Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
            }
            #endregion Snippet:TranscribeRemoteFileSync
        }

        [Test]
        public async Task TranscribeRemoteFileAsync()
        {
#if !SNIPPET
            var client = CreateTestClient();
#endif
            #region Snippet:TranscribeRemoteFileAsync
            using HttpClient httpClient = new HttpClient();
            using HttpResponseMessage httpResponse = await httpClient.GetAsync("https://your-domain.com/your-file.mp3");
            using Stream stream = await httpResponse.Content.ReadAsStreamAsync();

            var request = new TranscribeRequestContent { Audio = stream };
            var response = await client.TranscribeAsync(request);

            Console.WriteLine($"File Duration: {response.Value.Duration}");
            foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
            {
                Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
            }
            #endregion Snippet:TranscribeRemoteFileAsync
        }

        [Test]
        public async Task TranscribeWithLocales()
        {
#if !SNIPPET
            var client = CreateTestClient();
            string filePath = "path/to/audio.wav";
#endif
            #region Snippet:TranscribeWithLocales
            using (FileStream fileStream = File.Open(filePath, FileMode.Open))
            {
                var options = new TranscriptionOptions();
                options.Locales.Add("en-US");

                var request = new TranscribeRequestContent
                {
                    Audio = fileStream,
                    Options = options
                };

                var response = await client.TranscribeAsync(request);

                Console.WriteLine($"File Duration: {response.Value.Duration}");
                foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
                {
                    Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
                }
            }
            #endregion Snippet:TranscribeWithLocales
        }

        [Test]
        public async Task TranscribeWithModels()
        {
#if !SNIPPET
            var client = CreateTestClient();
            string filePath = "path/to/audio.wav";
#endif
            #region Snippet:TranscribeWithModels
            using (FileStream fileStream = File.Open(filePath, FileMode.Open))
            {
                var options = new TranscriptionOptions();
                options.Models.Add("en-US", new Uri("https://myaccount.api.cognitive.microsoft.com/speechtotext/models/your-model-uuid"));

                var request = new TranscribeRequestContent
                {
                    Audio = fileStream,
                    Options = options
                };

                var response = await client.TranscribeAsync(request);

                Console.WriteLine($"File Duration: {response.Value.Duration}");
                foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
                {
                    Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
                }
            }
            #endregion Snippet:TranscribeWithModels
        }

        [Test]
        public async Task TranscribeWithProfanityFilter()
        {
#if !SNIPPET
            var client = CreateTestClient();
            string filePath = "path/to/audio.wav";
#endif
            #region Snippet:TranscribeWithProfinityFilter
            using (FileStream fileStream = File.Open(filePath, FileMode.Open))
            {
                var options = new TranscriptionOptions();
                options.ProfanityFilterMode = ProfanityFilterMode.Masked;

                var request = new TranscribeRequestContent
                {
                    Audio = fileStream,
                    Options = options
                };

                var response = await client.TranscribeAsync(request);

                Console.WriteLine($"File Duration: {response.Value.Duration}");
                foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
                {
                    Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
                }
            }
            #endregion Snippet:TranscribeWithProfinityFilter
        }

        [Test]
        public async Task TranscribeWithActiveChannels()
        {
#if !SNIPPET
            var client = CreateTestClient();
            string filePath = "path/to/audio.wav";
#endif
            #region Snippet:TranscribeWithActiveChannels
            using (FileStream fileStream = File.Open(filePath, FileMode.Open))
            {
                var options = new TranscriptionOptions();
                options.ActiveChannels.Add(0);

                var request = new TranscribeRequestContent
                {
                    Audio = fileStream,
                    Options = options
                };

                var response = await client.TranscribeAsync(request);

                Console.WriteLine($"File Duration: {response.Value.Duration}");
                foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
                {
                    Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
                }
            }
            #endregion Snippet:TranscribeWithActiveChannels
        }

        [Test]
        public async Task TranscribeWithDiarization()
        {
#if !SNIPPET
            var client = CreateTestClient();
            string filePath = "path/to/audio.wav";
#endif
            #region Snippet:TranscribeWithDiarization
            using (FileStream fileStream = File.Open(filePath, FileMode.Open))
            {
                var diarizationOptions = new TranscriptionDiarizationOptions();
                diarizationOptions.Enabled = true;
                diarizationOptions.MaxSpeakers = 2;

                var options = new TranscriptionOptions();
                options.DiarizationOptions = diarizationOptions;

                var request = new TranscribeRequestContent
                {
                    Audio = fileStream,
                    Options = options
                };

                var response = await client.TranscribeAsync(request);

                Console.WriteLine($"File Duration: {response.Value.Duration}");
                foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
                {
                    Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration} [{phrase.Speaker}]: {phrase.Text}");
                }
            }
            #endregion Snippet:TranscribeWithDiarization
        }

#if !SNIPPET
        private TranscriptionClient CreateTestClient()
        {
            return new TranscriptionClient(TestEnvironment.Endpoint, TestEnvironment.Credential);
        }
#endif
    }
}
