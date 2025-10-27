// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.Speech.Transcription.Samples
{
    /// <summary>
    /// Samples demonstrating error handling in transcription operations.
    /// </summary>
    public partial class Sample03_ErrorHandling : TranscriptionSampleBase
    {
        /// <summary>
        /// Demonstrates basic error handling for transcription requests.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task HandleTranscriptionErrors()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:HandleTranscriptionErrors
            string audioFilePath = "path/to/audio.wav";

            try
            {
                using FileStream audioStream = File.OpenRead(audioFilePath);

                TranscribeRequestContent request = new TranscribeRequestContent
                {
                    Audio = audioStream
                };

                Response<TranscriptionResult> response = await client.TranscribeAsync(request);
                TranscriptionResult result = response.Value;

                Console.WriteLine($"Transcription successful. Duration: {result.Duration}");
                var channelPhrases = result.PhrasesByChannel.First();
                Console.WriteLine($"Text: {channelPhrases.Text}");
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.Unauthorized)
            {
                Console.WriteLine("Authentication failed. Please check your API key.");
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.BadRequest)
            {
                Console.WriteLine("Invalid request. Please check your audio file format and request parameters.");
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (RequestFailedException ex) when (ex.Status == 429) // TooManyRequests
            {
                Console.WriteLine("Rate limit exceeded. Please wait before making more requests.");
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Request failed with status code: {ex.Status}");
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Audio file not found: {audioFilePath}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading audio file: {ex.Message}");
            }
            #endregion Snippet:HandleTranscriptionErrors
        }

        /// <summary>
        /// Demonstrates handling errors with detailed diagnostics.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task HandleErrorsWithDiagnostics()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:HandleErrorsWithDiagnostics
            string audioFilePath = "path/to/audio.wav";

            try
            {
                using FileStream audioStream = File.OpenRead(audioFilePath);

                TranscribeRequestContent request = new TranscribeRequestContent
                {
                    Audio = audioStream
                };

                Response<TranscriptionResult> response = await client.TranscribeAsync(request);
                TranscriptionResult result = response.Value;

                Console.WriteLine("Transcription completed successfully.");
            }
            catch (RequestFailedException ex)
            {
                // Access detailed error information
                Console.WriteLine("Transcription request failed:");
                Console.WriteLine($"  Status Code: {ex.Status}");
                Console.WriteLine($"  Error Code: {ex.ErrorCode}");
                Console.WriteLine($"  Message: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"  Inner Exception: {ex.InnerException.Message}");
                }

                // Log the full exception for debugging
                Console.WriteLine($"\nFull Exception Details:\n{ex}");
            }
            #endregion Snippet:HandleErrorsWithDiagnostics
        }

        /// <summary>
        /// Demonstrates retry logic for transient errors.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task RetryOnTransientErrors()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:RetryOnTransientErrors
            string audioFilePath = "path/to/audio.wav";
            int maxRetries = 3;
            int retryDelayMilliseconds = 1000;

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    using FileStream audioStream = File.OpenRead(audioFilePath);

                    TranscribeRequestContent request = new TranscribeRequestContent
                    {
                        Audio = audioStream
                    };

                    Response<TranscriptionResult> response = await client.TranscribeAsync(request);
                    TranscriptionResult result = response.Value;

                    Console.WriteLine("Transcription successful!");
                    var channelPhrases = result.PhrasesByChannel.First();
                    Console.WriteLine($"Text: {channelPhrases.Text}");
                    break; // Success - exit retry loop
                }
                catch (RequestFailedException ex) when (
                    ex.Status == 429 || // TooManyRequests
                    ex.Status == (int)HttpStatusCode.ServiceUnavailable ||
                    ex.Status == (int)HttpStatusCode.GatewayTimeout)
                {
                    if (attempt < maxRetries)
                    {
                        Console.WriteLine($"Transient error occurred. Retrying in {retryDelayMilliseconds}ms...");
                        Console.WriteLine($"  Attempt {attempt} of {maxRetries}");
                        Console.WriteLine($"  Error: {ex.Message}");

                        await Task.Delay(retryDelayMilliseconds);
                        retryDelayMilliseconds *= 2; // Exponential backoff
                    }
                    else
                    {
                        Console.WriteLine($"Failed after {maxRetries} attempts.");
                        throw;
                    }
                }
            }
            #endregion Snippet:RetryOnTransientErrors
        }

        /// <summary>
        /// Demonstrates handling cancellation gracefully.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task HandleCancellation()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:HandleCancellation
            string audioFilePath = "path/to/audio.wav";

            // Create a cancellation token source with a timeout
            using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            try
            {
                using FileStream audioStream = File.OpenRead(audioFilePath);

                TranscribeRequestContent request = new TranscribeRequestContent
                {
                    Audio = audioStream
                };

                // Pass the cancellation token to the transcription request
                Response<TranscriptionResult> response = await client.TranscribeAsync(
                    request,
                    cancellationToken: cts.Token);

                TranscriptionResult result = response.Value;
                Console.WriteLine("Transcription completed successfully.");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Transcription operation was cancelled or timed out.");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Transcription failed: {ex.Message}");
            }
            #endregion Snippet:HandleCancellation
        }

        /// <summary>
        /// Validates audio file before transcription.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task ValidateAudioFile()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:ValidateAudioFile
            string audioFilePath = "path/to/audio.wav";

            // Validate the audio file before sending
            if (!File.Exists(audioFilePath))
            {
                Console.WriteLine($"Error: Audio file not found at '{audioFilePath}'");
                return;
            }

            FileInfo fileInfo = new FileInfo(audioFilePath);

            // Check file size (maximum 250 MB)
            const long maxFileSizeBytes = 250 * 1024 * 1024;
            if (fileInfo.Length > maxFileSizeBytes)
            {
                Console.WriteLine($"Error: Audio file is too large ({fileInfo.Length / 1024 / 1024} MB). Maximum size is 250 MB.");
                return;
            }

            if (fileInfo.Length == 0)
            {
                Console.WriteLine("Error: Audio file is empty.");
                return;
            }

            // Check file extension (common audio formats)
            string[] supportedExtensions = { ".wav", ".mp3", ".ogg", ".flac", ".opus" };
            string extension = fileInfo.Extension.ToLowerInvariant();
            if (!Array.Exists(supportedExtensions, ext => ext == extension))
            {
                Console.WriteLine($"Warning: File extension '{extension}' may not be supported.");
                Console.WriteLine($"Supported formats include: {string.Join(", ", supportedExtensions)}");
            }

            try
            {
                using FileStream audioStream = File.OpenRead(audioFilePath);

                TranscribeRequestContent request = new TranscribeRequestContent
                {
                    Audio = audioStream
                };

                Response<TranscriptionResult> response = await client.TranscribeAsync(request);
                TranscriptionResult result = response.Value;

                Console.WriteLine($"Transcription successful. Duration: {result.Duration}");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Transcription failed: {ex.Message}");
            }
            #endregion Snippet:ValidateAudioFile
        }

        /// <summary>
        /// Demonstrates handling errors when transcription options are invalid.
        /// </summary>
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task HandleInvalidOptionsErrors()
        {
            Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
            AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
            TranscriptionClient client = new TranscriptionClient(endpoint, credential);

            #region Snippet:HandleInvalidOptionsErrors
            string audioFilePath = "path/to/audio.wav";

            try
            {
                using FileStream audioStream = File.OpenRead(audioFilePath);

                TranscriptionOptions options = new TranscriptionOptions
                {
                    DiarizationOptions = new TranscriptionDiarizationOptions
                    {
                        Enabled = true,
                        MaxSpeakers = 50 // Invalid: must be between 2 and 35
                    }
                };

                TranscribeRequestContent request = new TranscribeRequestContent
                {
                    Audio = audioStream,
                    Options = options
                };

                Response<TranscriptionResult> response = await client.TranscribeAsync(request);
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.BadRequest)
            {
                Console.WriteLine("Invalid transcription options:");
                Console.WriteLine($"  {ex.Message}");
                Console.WriteLine("\nPlease check:");
                Console.WriteLine("  - MaxSpeakers should be between 2 and 35");
                Console.WriteLine("  - Locale codes are valid (e.g., 'en-US', 'es-ES')");
                Console.WriteLine("  - Custom model endpoints are accessible");
            }
            #endregion Snippet:HandleInvalidOptionsErrors
        }
    }
}
