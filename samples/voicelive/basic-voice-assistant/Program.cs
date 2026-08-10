// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics;
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
    ///     - Azure.Core (DefaultAzureCredential in Azure.Identity namespace)
    ///     - NAudio (for audio capture and playback)
    ///     - Microsoft.Extensions.Configuration
    ///     - System.CommandLine
    /// </remarks>
    public class Program
    {
        //
        // Telemetry/Tracing:
        //
        // The Azure VoiceLive SDK for .NET emits OpenTelemetry spans for all major operations automatically
        // when an OpenTelemetry provider is present (such as Azure Monitor or Console exporter).
        // No explicit code is required in this sample to enable tracing.
        //
        // For more details, see the sample README and Azure SDK telemetry docs.
        //

        /// <summary>
        /// Main entry point for the Voice Assistant sample.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static async Task<int> Main(string[] args)
        {
            var rootCommand = new RootCommand("Basic Voice Assistant using Azure VoiceLive SDK");

            var apiKeyOption = new Option<string?>("--api-key")
            {
                Description = "Azure VoiceLive API key. If not provided, will use AZURE_VOICELIVE_API_KEY environment variable."
            };

            var endpointOption = new Option<string>("--endpoint")
            {
                Description = "Azure VoiceLive endpoint"
            };

            var modelOption = new Option<string>("--model")
            {
                Description = "VoiceLive model to use"
            };

            var voiceOption = new Option<string>("--voice")
            {
                Description = "Voice to use for the assistant"
            };

            var instructionsOption = new Option<string>("--instructions")
            {
                Description = "System instructions for the AI assistant"
            };

            var useTokenCredentialOption = new Option<bool>("--use-token-credential")
            {
                Description = "Use Azure token credential instead of API key"
            };

            var verboseOption = new Option<bool>("--verbose")
            {
                Description = "Enable verbose logging"
            };

            var showTracesOption = new Option<bool>("--show-traces")
            {
                Description = "Print VoiceLive telemetry spans to console"
            };

            rootCommand.Add(apiKeyOption);
            rootCommand.Add(endpointOption);
            rootCommand.Add(modelOption);
            rootCommand.Add(voiceOption);
            rootCommand.Add(instructionsOption);
            rootCommand.Add(useTokenCredentialOption);
            rootCommand.Add(verboseOption);
            rootCommand.Add(showTracesOption);

            var parseResult = rootCommand.Parse(args);
            if (parseResult.Errors.Count > 0)
            {
                foreach (var error in parseResult.Errors)
                {
                    Console.WriteLine(error.Message);
                }
                return 1;
            }

            var apiKey = parseResult.GetValue(apiKeyOption);
            var endpoint = parseResult.GetValue(endpointOption) ?? "wss://api.voicelive.com/v1";
            var model = parseResult.GetValue(modelOption) ?? "gpt-4o";
            var voice = parseResult.GetValue(voiceOption) ?? "en-US-AvaNeural";
            var instructions = parseResult.GetValue(instructionsOption) ?? "You are a helpful AI assistant. Respond naturally and conversationally. Keep your responses concise but engaging.";
            var useTokenCredential = parseResult.GetValue(useTokenCredentialOption);
            var verbose = parseResult.GetValue(verboseOption);
            var showTraces = parseResult.GetValue(showTracesOption)
                || string.Equals(Environment.GetEnvironmentVariable("VOICELIVE_ENABLE_CONSOLE_TRACING"), "true", StringComparison.OrdinalIgnoreCase);

            await RunVoiceAssistantAsync(apiKey, endpoint, model, voice, instructions, useTokenCredential, verbose, showTraces).ConfigureAwait(false);
            return 0;
        }

        private static async Task RunVoiceAssistantAsync(
                string? apiKey,
                string endpoint,
                string model,
                string voice,
                string instructions,
                bool useTokenCredential,
                bool verbose,
                bool showTraces)
        {
            using var traceListener = EnableVoiceLiveConsoleTracing(showTraces);

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

            var logger = loggerFactory.CreateLogger<Program>();

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

        private static IDisposable? EnableVoiceLiveConsoleTracing(bool enabled)
        {
            if (!enabled)
                return null;

            var listener = new ActivityListener
            {
                ShouldListenTo = source => source.Name == "Azure.AI.VoiceLive",
                Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
                SampleUsingParentId = (ref ActivityCreationOptions<string> _) => ActivitySamplingResult.AllDataAndRecorded,
                ActivityStopped = activity =>
                {
                    Console.WriteLine($"'{activity.DisplayName}' : {FormatTags(activity.TagObjects)}");
                    foreach (ActivityEvent evt in activity.Events)
                    {
                        Console.WriteLine($"  Event '{evt.Name}': {FormatTags(evt.Tags)}");
                    }
                }
            };

            ActivitySource.AddActivityListener(listener);
            Console.WriteLine("VoiceLive console tracing enabled.");
            return listener;
        }

        private static string FormatTags(IEnumerable<KeyValuePair<string, object?>> tags)
        {
            var parts = new List<string>();
            foreach (KeyValuePair<string, object?> kvp in tags)
            {
                parts.Add($"{kvp.Key}={kvp.Value}");
            }
            return "{" + string.Join(", ", parts) + "}";
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
