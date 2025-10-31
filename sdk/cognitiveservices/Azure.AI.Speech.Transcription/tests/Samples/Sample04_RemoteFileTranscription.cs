// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.Speech.Transcription.Samples
{
    /// <summary>
    /// Samples demonstrating transcription of remote audio files.
    /// </summary>
    public partial class Sample04_RemoteFileTranscription : TranscriptionSampleBase
    {
        /// <summary>
        /// Transcribes an audio file from a public URL.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeFromUrl()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeFromUrl
            // Specify the URL of the audio file to transcribe
            Uri audioUrl = new Uri("https://example.com/audio/sample.wav");

            // Configure transcription to use the remote URL
            TranscriptionOptions options = new TranscriptionOptions(audioUrl);

            // No audio stream needed - the service fetches the file from the URL
            Response<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            Console.WriteLine($"Transcribed audio from URL: {audioUrl}");
            Console.WriteLine($"Duration: {result.Duration}");

            var channelPhrases = result.PhrasesByChannel.First();
            Console.WriteLine($"\nTranscription:\n{channelPhrases.Text}");
            #endregion Snippet:TranscribeFromUrl
        }

        /// <summary>
        /// Downloads and transcribes a remote audio file.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeFromHttpStream()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeFromHttpStream
            // Download the audio file from a remote location
            string audioUrl = "https://example.com/audio/sample.wav";

            using HttpClient httpClient = new HttpClient();
            using HttpResponseMessage httpResponse = await httpClient.GetAsync(audioUrl);
            httpResponse.EnsureSuccessStatusCode();

            // Get the audio stream from the HTTP response
            using Stream audioStream = await httpResponse.Content.ReadAsStreamAsync();

            // Create transcription request with the downloaded stream
            TranscriptionContent request = new TranscriptionContent
            {
                Audio = audioStream
            };

            Response<TranscriptionResult> response = await client.TranscribeAsync(request);
            TranscriptionResult result = response.Value;

            Console.WriteLine($"Downloaded and transcribed audio from: {audioUrl}");
            Console.WriteLine($"Duration: {result.Duration}");

            var channelPhrases = result.PhrasesByChannel.First();
            foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
            {
                Console.WriteLine($"[{phrase.Offset}] {phrase.Text}");
            }
            #endregion Snippet:TranscribeFromHttpStream
        }

        /// <summary>
        /// Transcribes audio from Azure Blob Storage using a SAS URL.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeFromBlobStorage()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeFromBlobStorage
            // Azure Blob Storage URL with SAS token for access
            Uri blobSasUrl = new Uri(
                "https://mystorageaccount.blob.core.windows.net/audio-files/recording.wav?sv=2021-06-08&st=...");

            TranscriptionOptions options = new TranscriptionOptions(blobSasUrl);

            Response<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            Console.WriteLine($"Transcribed audio from Azure Blob Storage");
            Console.WriteLine($"Duration: {result.Duration}");

            var channelPhrases = result.PhrasesByChannel.First();
            Console.WriteLine($"\nFull Transcription:\n{channelPhrases.Text}");
            #endregion Snippet:TranscribeFromBlobStorage
        }

        /// <summary>
        /// Transcribes remote audio with specific locale and options.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeRemoteFileWithOptions()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeRemoteFileWithOptions
            Uri audioUrl = new Uri("https://example.com/audio/spanish-interview.mp3");

            // Configure transcription options for remote audio
            TranscriptionOptions options = new TranscriptionOptions(audioUrl)
            {
                ProfanityFilterMode = ProfanityFilterMode.Masked,
                DiarizationOptions = new TranscriptionDiarizationOptions
                {
                    // Enabled is automatically set to true when MaxSpeakers is specified
                    MaxSpeakers = 2
                }
            };

            // Add Spanish locale
            options.Locales.Add("es-ES");

            Response<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            Console.WriteLine("Remote transcription with options:");
            Console.WriteLine($"Duration: {result.Duration}");

            var channelPhrases = result.PhrasesByChannel.First();
            foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
            {
                Console.WriteLine($"Speaker {phrase.Speaker}: {phrase.Text}");
            }
            #endregion Snippet:TranscribeRemoteFileWithOptions
        }

        /// <summary>
        /// Demonstrates fallback from URL to stream when URL is not accessible.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeWithUrlFallback()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeWithUrlFallback
            string audioUrlString = "https://example.com/audio/sample.wav";
            Uri audioUrl = new Uri(audioUrlString);

            try
            {
                // First, try to transcribe directly from URL
                TranscriptionOptions options = new TranscriptionOptions(audioUrl);

                Response<TranscriptionResult> response = await client.TranscribeAsync(options);
                TranscriptionResult result = response.Value;

                Console.WriteLine("Transcribed directly from URL");
                var channelPhrases = result.PhrasesByChannel.First();
                Console.WriteLine(channelPhrases.Text);
            }
            catch (RequestFailedException ex) when (ex.Status == 400)
            {
                // If URL method fails, fall back to downloading and streaming
                Console.WriteLine("URL access failed, downloading file...");

                using HttpClient httpClient = new HttpClient();
                using HttpResponseMessage httpResponse = await httpClient.GetAsync(audioUrlString);
                httpResponse.EnsureSuccessStatusCode();

                using Stream audioStream = await httpResponse.Content.ReadAsStreamAsync();

                TranscriptionContent streamRequest = new TranscriptionContent
                {
                    Audio = audioStream
                };

                Response<TranscriptionResult> response = await client.TranscribeAsync(streamRequest);
                TranscriptionResult result = response.Value;

                Console.WriteLine("Transcribed from downloaded stream");
                var channelPhrases = result.PhrasesByChannel.First();
                Console.WriteLine(channelPhrases.Text);
            }
            #endregion Snippet:TranscribeWithUrlFallback
        }

        /// <summary>
        /// Transcribes multiple remote files in parallel.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeMultipleRemoteFiles()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeMultipleRemoteFiles
            // List of audio files to transcribe
            Uri[] audioUrls = new[]
            {
                new Uri("https://example.com/audio/file1.wav"),
                new Uri("https://example.com/audio/file2.wav"),
                new Uri("https://example.com/audio/file3.wav")
            };

            // Create tasks for parallel transcription
            Task<Response<TranscriptionResult>>[] transcriptionTasks = audioUrls
                .Select(url =>
                {
                    TranscriptionOptions options = new TranscriptionOptions(url);

                    return client.TranscribeAsync(options);
                })
                .ToArray();

            // Wait for all transcriptions to complete
            Response<TranscriptionResult>[] responses = await Task.WhenAll(transcriptionTasks);

            // Process results
            for (int i = 0; i < responses.Length; i++)
            {
                TranscriptionResult result = responses[i].Value;
                Console.WriteLine($"\nFile {i + 1} ({audioUrls[i]}):");
                Console.WriteLine($"Duration: {result.Duration}");

                var channelPhrases = result.PhrasesByChannel.First();
                Console.WriteLine($"Text: {channelPhrases.Text}");
            }
            #endregion Snippet:TranscribeMultipleRemoteFiles
        }

        /// <summary>
        /// Demonstrates streaming transcription of a large remote file with progress tracking.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeRemoteFileWithProgress()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeRemoteFileWithProgress
            string audioUrlString = "https://example.com/audio/large-file.wav";

            Console.WriteLine("Downloading audio file...");

            using HttpClient httpClient = new HttpClient();
            using HttpResponseMessage httpResponse = await httpClient.GetAsync(
                audioUrlString,
                HttpCompletionOption.ResponseHeadersRead);

            httpResponse.EnsureSuccessStatusCode();

            long? totalBytes = httpResponse.Content.Headers.ContentLength;
            if (totalBytes.HasValue)
            {
                Console.WriteLine($"File size: {totalBytes.Value / 1024 / 1024} MB");
            }

            using Stream audioStream = await httpResponse.Content.ReadAsStreamAsync();

            Console.WriteLine("Starting transcription...");

            TranscriptionContent request = new TranscriptionContent
            {
                Audio = audioStream
            };

            Response<TranscriptionResult> response = await client.TranscribeAsync(request);
            TranscriptionResult result = response.Value;

            Console.WriteLine("Transcription complete!");
            Console.WriteLine($"Audio duration: {result.Duration}");

            var channelPhrases = Enumerable.First(result.PhrasesByChannel);
            Console.WriteLine($"Phrases transcribed: {Enumerable.Count(channelPhrases.Phrases)}");
            Console.WriteLine($"\nTranscription:\n{channelPhrases.Text}");
            #endregion Snippet:TranscribeRemoteFileWithProgress
        }
    }
}