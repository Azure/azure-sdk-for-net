// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Speech.Transcription.Tests;
using NUnit.Framework;

namespace Azure.AI.Speech.Transcription.Samples
{
    /// <summary>
    /// Samples demonstrating basic transcription operations using the <see cref="TranscriptionClient"/>.
    /// </summary>
    public partial class Sample01_BasicTranscription : TranscriptionSampleBase
    {
#if !SNIPPET
        private TranscriptionClient _client;

        [OneTimeSetUp]
        public void Setup()
        {
            _client = TestConfiguration.CreateClient();
        }
#endif

        /// <summary>
        /// Creates a new TranscriptionClient using an API key credential.
        /// </summary>
        [Test]
        public new void CreateTranscriptionClient()
        {
            #region Snippet:CreateTranscriptionClient
            // Get the endpoint and API key from your Speech resource in the Azure portal
#if SNIPPET
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
#else
            Uri endpoint = TestConfiguration.Endpoint;
            ApiKeyCredential credential = TestConfiguration.Credential;
#endif

            // Create the TranscriptionClient
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
            #endregion Snippet:CreateTranscriptionClient
        }

        /// <summary>
        /// Creates a TranscriptionClient with custom client options.
        /// </summary>
        [Test]
        public void CreateTranscriptionClientWithOptions()
        {
            #region Snippet:CreateTranscriptionClientWithOptions
#if SNIPPET
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
#else
            Uri endpoint = TestConfiguration.Endpoint;
            ApiKeyCredential credential = TestConfiguration.Credential;
#endif

            // Configure client options
            TranscriptionClientOptions options = new TranscriptionClientOptions(
                TranscriptionClientOptions.ServiceVersion.V20251015);

            TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);
            #endregion Snippet:CreateTranscriptionClientWithOptions
        }

        /// <summary>
        /// Transcribes a local audio file synchronously.
        /// </summary>
        [Test]
        public void TranscribeLocalFile()
        {
#if !SNIPPET
            var client = _client;
#else
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
#endif

            #region Snippet:TranscribeLocalFile
            // Path to your local audio file
#if SNIPPET
            string audioFilePath = "path/to/audio.wav";
#else
            string audioFilePath = TestConfiguration.SampleAudioFilePath;
#endif

            // Open the audio file as a stream
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Create the transcription request
            TranscriptionOptions options = new TranscriptionOptions(audioStream);

            // Perform synchronous transcription
            ClientResult<TranscriptionResult> response = client.Transcribe(options);
            TranscriptionResult result = response.Value;

            // Display the transcription results
            Console.WriteLine($"Total audio duration: {result.Duration}");
            Console.WriteLine("\nTranscription:");

            // Get the first channel's phrases (most audio files have a single channel)
            var channelPhrases = result.PhrasesByChannel.First();
            foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
            {
                Console.WriteLine($"[{phrase.Offset} - {phrase.Offset + phrase.Duration}] {phrase.Text}");
                Console.WriteLine($"  Confidence: {phrase.Confidence:F2}");
            }
            #endregion Snippet:TranscribeLocalFile
        }

        /// <summary>
        /// Transcribes a local audio file asynchronously.
        /// </summary>
        [Test]
        public async Task TranscribeLocalFileAsync()
        {
#if !SNIPPET
            var client = _client;
            string audioFilePath = TestConfiguration.SampleAudioFilePath;
#else
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            // Path to your local audio file
            string audioFilePath = "path/to/audio/file.wav";
#endif

            // Open the audio file as a stream
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Create the transcription request
            TranscriptionOptions options = new TranscriptionOptions(audioStream);

            // Perform asynchronous transcription
            ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            // Display the transcription results
            Console.WriteLine($"Total audio duration: {result.Duration}");
            Console.WriteLine("\nTranscription:");

            // Get the first channel's phrases
            var channelPhrases = result.PhrasesByChannel.First();
            foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
            {
                Console.WriteLine($"[{phrase.Offset} - {phrase.Offset + phrase.Duration}] {phrase.Text}");
                Console.WriteLine($"  Confidence: {phrase.Confidence:F2}");
            }
        }

        /// <summary>
        /// Demonstrates accessing individual words within transcribed phrases.
        /// </summary>
        [Test]
        public async Task AccessTranscribedWords()
        {
#if !SNIPPET
            var client = _client;
            string audioFilePath = TestConfiguration.SampleAudioFilePath;
#else
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
            string audioFilePath = "path/to/audio.wav";
#endif

            #region Snippet:AccessTranscribedWords
            using FileStream audioStream = File.OpenRead(audioFilePath);

            TranscriptionOptions options = new TranscriptionOptions(audioStream);

            ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            // Access individual words in each phrase
            var channelPhrases = result.PhrasesByChannel.First();
            foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
            {
                Console.WriteLine($"\nPhrase: {phrase.Text}");
                Console.WriteLine("Words:");

                foreach (TranscribedWord word in phrase.Words)
                {
                    Console.WriteLine($"  [{word.Offset} - {word.Offset + word.Duration}] {word.Text}");
                }
            }
            #endregion Snippet:AccessTranscribedWords
        }

        /// <summary>
        /// Demonstrates accessing the combined text for a channel.
        /// </summary>
        [Test]
        public async Task AccessCombinedText()
        {
#if !SNIPPET
            var client = _client;
            string audioFilePath = TestConfiguration.SampleAudioFilePath;
#else
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
            string audioFilePath = "path/to/audio.wav";
#endif

            #region Snippet:AccessCombinedText
            using FileStream audioStream = File.OpenRead(audioFilePath);

            TranscriptionOptions options = new TranscriptionOptions(audioStream);

            ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
            TranscriptionResult result = response.Value;

            // Access the combined text for each channel
            foreach (var channelPhrases in result.PhrasesByChannel)
            {
                Console.WriteLine($"Channel {channelPhrases.Channel ?? 0}:");
                Console.WriteLine($"Combined Text: {channelPhrases.Text}");
                Console.WriteLine();
            }
            #endregion Snippet:AccessCombinedText
        }

        /// <summary>
        /// Demonstrates configuring logging using a custom pipeline policy.
        /// System.ClientModel supports custom PipelinePolicy for logging HTTP requests/responses.
        /// </summary>
        [Test]
        public void ConfigureLogging()
        {
            #region Snippet:ConfigureLogging
#if SNIPPET
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
#else
            Uri endpoint = TestConfiguration.Endpoint;
            ApiKeyCredential credential = TestConfiguration.Credential;
#endif

            // Create client options and add a custom logging policy
            TranscriptionClientOptions options = new TranscriptionClientOptions();

            // Add a logging policy that runs per-call (before retries)
            options.AddPolicy(new LoggingPolicy(), System.ClientModel.Primitives.PipelinePosition.PerCall);

            TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);
            #endregion Snippet:ConfigureLogging
        }

        /// <summary>
        /// Demonstrates configuring custom retry policy for resilience.
        /// System.ClientModel uses ClientRetryPolicy for retry configuration.
        /// </summary>
        [Test]
        public void ConfigureRetryPolicy()
        {
            #region Snippet:ConfigureRetryPolicy
#if SNIPPET
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
#else
            Uri endpoint = TestConfiguration.Endpoint;
            ApiKeyCredential credential = TestConfiguration.Credential;
#endif

            // Configure retry policy with custom max retries
            TranscriptionClientOptions options = new TranscriptionClientOptions
            {
                RetryPolicy = new System.ClientModel.Primitives.ClientRetryPolicy(maxRetries: 5)
            };

            TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);
            #endregion Snippet:ConfigureRetryPolicy
        }

        /// <summary>
        /// Demonstrates configuring custom timeout for transcription operations.
        /// System.ClientModel uses NetworkTimeout property on ClientPipelineOptions.
        /// </summary>
        [Test]
        public void ConfigureTimeout()
        {
            #region Snippet:ConfigureTimeout
#if SNIPPET
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
#else
            Uri endpoint = TestConfiguration.Endpoint;
            ApiKeyCredential credential = TestConfiguration.Credential;
#endif

            // Configure a custom network timeout (default is 100 seconds)
            TranscriptionClientOptions options = new TranscriptionClientOptions
            {
                NetworkTimeout = TimeSpan.FromMinutes(5)
            };

            TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);
            #endregion Snippet:ConfigureTimeout
        }

        #region Snippet:LoggingPolicy
        /// <summary>
        /// Custom pipeline policy that logs HTTP requests and responses.
        /// </summary>
        private class LoggingPolicy : PipelinePolicy
        {
            public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
            {
                // Log request
                Console.WriteLine($"Request: {message.Request.Method} {message.Request.Uri}");

                // Continue the pipeline
                ProcessNext(message, pipeline, currentIndex);

                // Log response
                if (message.Response != null)
                {
                    Console.WriteLine($"Response: {message.Response.Status} {message.Response.ReasonPhrase}");
                }
            }

            public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
            {
                // Log request
                Console.WriteLine($"Request: {message.Request.Method} {message.Request.Uri}");

                // Continue the pipeline
                await ProcessNextAsync(message, pipeline, currentIndex);

                // Log response
                if (message.Response != null)
                {
                    Console.WriteLine($"Response: {message.Response.Status} {message.Response.ReasonPhrase}");
                }
            }
        }
        #endregion
    }
}
