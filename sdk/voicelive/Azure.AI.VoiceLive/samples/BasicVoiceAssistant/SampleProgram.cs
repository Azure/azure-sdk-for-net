// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.CommandLine;
using Azure.AI.VoiceLive.Samples;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NAudio.Wave;

namespace Azure.AI.VoiceLive.Samples
{
    /// <summary>
    /// FILE: Program.cs
    /// </summary>
    /// <remarks>
    /// DESCRIPTION:
    ///     This sample demonstrates the fundamental capabilities of the VoiceLive SDK by creating
    ///     a basic voice assistant that can engage in natural conversation with proper interruption
    ///     handling. This serves as the foundational example that showcases the core value
    ///     proposition of unified speech-to-speech interaction.
    ///
    /// USAGE:
    ///     dotnet run
    ///
    ///     Set the environment variables with your own values before running the sample:
    ///     1) AZURE_VOICELIVE_API_KEY - The Azure VoiceLive API key
    ///     2) AZURE_VOICELIVE_ENDPOINT - The Azure VoiceLive endpoint
    ///
    ///     Or update appsettings.json with your values.
    ///
    /// REQUIREMENTS:
    ///     - Azure.AI.VoiceLive
    ///     - Azure.Identity
    ///     - NAudio (for audio capture and playback)
    ///     - Microsoft.Extensions.Configuration
    ///     - System.CommandLine
    /// </remarks>
    public class SampleProgram
    {
        /// <summary>
        /// Main entry point for the Voice Assistant sample.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static async Task<int> Main(string[] args)
        {
            // Create command line interface
            var rootCommand = CreateRootCommand();
            return await rootCommand.InvokeAsync(args).ConfigureAwait(false);
        }

        private static RootCommand CreateRootCommand()
        {
            var rootCommand = new RootCommand("Basic Voice Assistant using Azure VoiceLive SDK");

            var apiKeyOption = new Option<string?>(
                "--api-key",
                "Azure VoiceLive API key. If not provided, will use AZURE_VOICELIVE_API_KEY environment variable.");

            var endpointOption = new Option<string>(
                "--endpoint",
                () => "wss://api.voicelive.com/v1",
                "Azure VoiceLive endpoint");

            var modelOption = new Option<string>(
                "--model",
                () => "gpt-4o",
                "VoiceLive model to use");

            var voiceOption = new Option<string>(
                "--voice",
                () => "en-US-AvaNeural",
                "Voice to use for the assistant");

            var instructionsOption = new Option<string>(
                "--instructions",
                () => "You are a helpful AI assistant. Respond naturally and conversationally. Keep your responses concise but engaging.",
                "System instructions for the AI assistant");

            var useTokenCredentialOption = new Option<bool>(
                "--use-token-credential",
                "Use Azure token credential instead of API key");

            var verboseOption = new Option<bool>(
                "--verbose",
                "Enable verbose logging");

            rootCommand.AddOption(apiKeyOption);
            rootCommand.AddOption(endpointOption);
            rootCommand.AddOption(modelOption);
            rootCommand.AddOption(voiceOption);
            rootCommand.AddOption(instructionsOption);
            rootCommand.AddOption(useTokenCredentialOption);
            rootCommand.AddOption(verboseOption);

            rootCommand.SetHandler(async (
                string? apiKey,
                string endpoint,
                string model,
                string voice,
                string instructions,
                bool useTokenCredential,
                bool verbose) =>
            {
                await RunVoiceAssistantAsync(apiKey, endpoint, model, voice, instructions, useTokenCredential, verbose).ConfigureAwait(false);
            },
            apiKeyOption,
            endpointOption,
            modelOption,
            voiceOption,
            instructionsOption,
            useTokenCredentialOption,
            verboseOption);

            return rootCommand;
        }

        private static async Task RunVoiceAssistantAsync(
            string? apiKey,
            string endpoint,
            string model,
            string voice,
            string instructions,
            bool useTokenCredential,
            bool verbose)
        {
            // Setup configuration
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            // Override with command line values if provided
            apiKey ??= configuration["VoiceLive:ApiKey"] ?? Environment.GetEnvironmentVariable("AZURE_VOICELIVE_API_KEY");
            endpoint = configuration["VoiceLive:Endpoint"] ?? endpoint;
            model = configuration["VoiceLive:Model"] ?? model;
            voice = configuration["VoiceLive:Voice"] ?? voice;
            instructions = configuration["VoiceLive:Instructions"] ?? instructions;

            // Setup logging
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                if (verbose)
                {
                    builder.SetMinimumLevel(LogLevel.Debug);
                }
                else
                {
                    builder.SetMinimumLevel(LogLevel.Information);
                }
            });

            var logger = loggerFactory.CreateLogger<SampleProgram>();

            // Validate credentials
            if (string.IsNullOrEmpty(apiKey) && !useTokenCredential)
            {
                Console.WriteLine("❌ Error: No authentication provided");
                Console.WriteLine("Please provide an API key using --api-key or set AZURE_VOICELIVE_API_KEY environment variable,");
                Console.WriteLine("or use --use-token-credential for Azure authentication.");
                return;
            }

            // Check audio system before starting
            if (!CheckAudioSystem(logger))
            {
                return;
            }

            try
            {
                // Create client with appropriate credential
                VoiceLiveClient client;
                if (useTokenCredential)
                {
                    var tokenCredential = new DefaultAzureCredential();
                    client = new VoiceLiveClient(new Uri(endpoint), tokenCredential, new VoiceLiveClientOptions());
                    logger.LogInformation("Using Azure token credential");
                }
                else
                {
                    var keyCredential = new Azure.AzureKeyCredential(apiKey!);
                    client = new VoiceLiveClient(new Uri(endpoint), keyCredential, new VoiceLiveClientOptions());
                    logger.LogInformation("Using API key credential");
                }

                // Create and start voice assistant
                using var assistant = new BasicVoiceAssistant(
                    client,
                    model,
                    voice,
                    instructions,
                    loggerFactory);

                // Setup cancellation token for graceful shutdown
                using var cancellationTokenSource = new CancellationTokenSource();
                Console.CancelKeyPress += (sender, e) =>
                {
                    e.Cancel = true;
                    logger.LogInformation("Received shutdown signal");
                    cancellationTokenSource.Cancel();
                };

                // Start the assistant
                await assistant.StartAsync(cancellationTokenSource.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\n👋 Voice assistant shut down. Goodbye!");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Fatal error");
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }

        private static bool CheckAudioSystem(ILogger logger)
        {
            try
            {
                // Try input (default device)
                using (var waveIn = new WaveInEvent
                {
                    WaveFormat = new WaveFormat(24000, 16, 1),
                    BufferMilliseconds = 50
                })
                {
                    // Start/Stop to force initialization and surface any device errors
                    waveIn.DataAvailable += (_, __) => { };
                    waveIn.StartRecording();
                    waveIn.StopRecording();
                }

                // Try output (default device)
                var buffer = new BufferedWaveProvider(new WaveFormat(24000, 16, 1))
                {
                    BufferDuration = TimeSpan.FromMilliseconds(200)
                };

                using (var waveOut = new WaveOutEvent { DesiredLatency = 100 })
                {
                    waveOut.Init(buffer);
                    // Playing isn’t strictly required to validate a device, but it’s safe
                    waveOut.Play();
                    waveOut.Stop();
                }

                logger.LogInformation("Audio system check passed (default input/output initialized).");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Audio system check failed: {ex.Message}");
                return false;
            }
        }
    }
}
