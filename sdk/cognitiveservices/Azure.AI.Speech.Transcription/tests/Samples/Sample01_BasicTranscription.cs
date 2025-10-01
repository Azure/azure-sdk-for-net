// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.Speech.Transcription.Samples
{
    /// <summary>
    /// Samples demonstrating basic transcription operations using the <see cref="TranscriptionClient"/>.
    /// </summary>
    public partial class Sample01_BasicTranscription : TranscriptionSampleBase
    {
        /// <summary>
        /// Creates a new TranscriptionClient using an API key credential.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public new void CreateTranscriptionClient()
        {
            #region Snippet:CreateTranscriptionClient
            // Get the endpoint and API key from your Speech resource in the Azure portal
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");

            // Create the TranscriptionClient
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
            #endregion Snippet:CreateTranscriptionClient
        }

        /// <summary>
        /// Creates a TranscriptionClient with custom client options.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void CreateTranscriptionClientWithOptions()
        {
            #region Snippet:CreateTranscriptionClientWithOptions
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");

            // Configure client options
            TranscriptionClientOptions options = new TranscriptionClientOptions(
                TranscriptionClientOptions.ServiceVersion.V2025_10_15);

            TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);
            #endregion Snippet:CreateTranscriptionClientWithOptions
        }

        /// <summary>
        /// Transcribes a local audio file synchronously.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void TranscribeLocalFile()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeLocalFile
            // Path to your local audio file
            string audioFilePath = "path/to/audio.wav";

            // Open the audio file as a stream
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Create the transcription request
            TranscribeRequestContent request = new TranscribeRequestContent
            {
                Audio = audioStream
            };

            // Perform synchronous transcription
            Response<TranscriptionResult> response = client.Transcribe(request);
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
        [Ignore("Only validating compilation of examples")]
        public async Task TranscribeLocalFileAsync()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:TranscribeLocalFileAsync
            // Path to your local audio file
            string audioFilePath = "path/to/audio.wav";

            // Open the audio file as a stream
            using FileStream audioStream = File.OpenRead(audioFilePath);

            // Create the transcription request
            TranscribeRequestContent request = new TranscribeRequestContent
            {
                Audio = audioStream
            };

            // Perform asynchronous transcription
            Response<TranscriptionResult> response = await client.TranscribeAsync(request);
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
            #endregion Snippet:TranscribeLocalFileAsync
        }

        /// <summary>
        /// Demonstrates accessing individual words within transcribed phrases.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task AccessTranscribedWords()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
            string audioFilePath = "path/to/audio.wav";

            #region Snippet:AccessTranscribedWords
            using FileStream audioStream = File.OpenRead(audioFilePath);

            TranscribeRequestContent request = new TranscribeRequestContent
            {
                Audio = audioStream
            };

            Response<TranscriptionResult> response = await client.TranscribeAsync(request);
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
        [Ignore("Only validating compilation of examples")]
        public async Task AccessCombinedText()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);
            string audioFilePath = "path/to/audio.wav";

            #region Snippet:AccessCombinedText
            using FileStream audioStream = File.OpenRead(audioFilePath);

            TranscribeRequestContent request = new TranscribeRequestContent
            {
                Audio = audioStream
            };

            Response<TranscriptionResult> response = await client.TranscribeAsync(request);
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
        /// Demonstrates configuring logging and diagnostics for troubleshooting.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void ConfigureLogging()
        {
            #region Snippet:ConfigureLogging
            // Enable Azure Core diagnostics for console logging
            using Azure.Core.Diagnostics.AzureEventSourceListener listener =
                Azure.Core.Diagnostics.AzureEventSourceListener.CreateConsoleLogger();

            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");

            // Configure diagnostics options
            TranscriptionClientOptions options = new TranscriptionClientOptions
            {
                Diagnostics =
                {
                    IsLoggingEnabled = true,
                    IsLoggingContentEnabled = true, // Log request/response content
                    IsTelemetryEnabled = true,
                    ApplicationId = "MyApp/1.0.0" // Custom application identifier
                }
            };

            TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);

            // Logs will now be written to the console showing:
            // - HTTP requests and responses
            // - Request/response headers
            // - Request/response content (when IsLoggingContentEnabled = true)
            // - Client pipeline events
            #endregion Snippet:ConfigureLogging
        }

        /// <summary>
        /// Demonstrates configuring custom retry policy for resilience.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void ConfigureRetryPolicy()
        {
            #region Snippet:ConfigureRetryPolicy
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");

            // Configure retry policy
            TranscriptionClientOptions options = new TranscriptionClientOptions
            {
                Retry =
                {
                    MaxRetries = 5,                    // Maximum number of retry attempts
                    Delay = TimeSpan.FromSeconds(1),   // Initial delay between retries
                    MaxDelay = TimeSpan.FromSeconds(30), // Maximum delay between retries
                    Mode = RetryMode.Exponential       // Use exponential backoff
                }
            };

            TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);

            // The client will now automatically retry failed requests
            // using exponential backoff strategy
            #endregion Snippet:ConfigureRetryPolicy
        }

        /// <summary>
        /// Demonstrates configuring custom timeout for transcription operations.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void ConfigureTimeout()
        {
            #region Snippet:ConfigureTimeout
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");

            // Configure network timeout
            TranscriptionClientOptions options = new TranscriptionClientOptions
            {
                Retry =
                {
                    NetworkTimeout = TimeSpan.FromMinutes(5) // 5 minute timeout for network operations
                }
            };

            TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);

            // All transcription operations will use the configured timeout
            // This is useful for large audio files that take longer to process
            #endregion Snippet:ConfigureTimeout
        }
    }
}
