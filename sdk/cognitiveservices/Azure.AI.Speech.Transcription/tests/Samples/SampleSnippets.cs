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
            #region Snippet:TranscribeLocalFileSync
#if SNIPPET
            string filePath = "path/to/audio.wav";
            TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new AzureKeyCredential("your apikey"));
#else
            string filePath = "path/to/audio.wav";
            var client = CreateTestClient();
#endif
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
            #region Snippet:TranscribeLocalFileAsync
#if SNIPPET
            string filePath = "path/to/audio.wav";
            TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new AzureKeyCredential("your apikey"));
#else
            string filePath = "path/to/audio.wav";
            var client = CreateTestClient();
#endif
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
            #region Snippet:TranscribeRemoteFileSync
#if SNIPPET
            TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new AzureKeyCredential("your apikey"));
#else
            var client = CreateTestClient();
#endif
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
            #region Snippet:TranscribeRemoteFileAsync
#if SNIPPET
            TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new AzureKeyCredential("your apikey"));
#else
            var client = CreateTestClient();
#endif
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
            #region Snippet:TranscribeWithLocales
#if SNIPPET
            string filePath = "path/to/audio.wav";
            TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new AzureKeyCredential("your apikey"));
#else
            string filePath = "path/to/audio.wav";
            var client = CreateTestClient();
#endif
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
            #region Snippet:TranscribeWithModels
#if SNIPPET
            string filePath = "path/to/audio.wav";
            TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new AzureKeyCredential("your apikey"));
#else
            string filePath = "path/to/audio.wav";
            var client = CreateTestClient();
#endif
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
            #region Snippet:TranscribeWithProfinityFilter
#if SNIPPET
            string filePath = "path/to/audio.wav";
            TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new AzureKeyCredential("your apikey"));
#else
            string filePath = "path/to/audio.wav";
            var client = CreateTestClient();
#endif
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
            #region Snippet:TranscribeWithActiveChannels
#if SNIPPET
            string filePath = "path/to/audio.wav";
            TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new AzureKeyCredential("your apikey"));
#else
            string filePath = "path/to/audio.wav";
            var client = CreateTestClient();
#endif
            using (FileStream fileStream = File.Open(filePath, FileMode.Open))
            {
                var options = new TranscriptionOptions();
                options.Channels.Add(0);

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
            #region Snippet:TranscribeWithDiarization
#if SNIPPET
            string filePath = "path/to/audio.wav";
            TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new AzureKeyCredential("your apikey"));
#else
            string filePath = "path/to/audio.wav";
            var client = CreateTestClient();
#endif
            using (FileStream fileStream = File.Open(filePath, FileMode.Open))
            {
                var options = new TranscriptionOptions()
                {
                    Diarization = new()
                    {
                        Enabled = true,
                        MaxSpeakers = 2
                    }
                };

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
