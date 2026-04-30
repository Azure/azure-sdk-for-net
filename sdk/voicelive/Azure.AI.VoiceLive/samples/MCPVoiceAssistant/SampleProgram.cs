// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.CommandLine;
using System.CommandLine.Parsing;
using Azure.AI.VoiceLive.Samples;
using Azure.Identity;
using System.Net.WebSockets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NAudio.Wave;

namespace Azure.AI.VoiceLive.Samples
{
    /// <summary>
    /// FILE: SampleProgram.cs
    /// </summary>
    /// <remarks>
    /// DESCRIPTION:
    ///     Demonstrates how to use the VoiceLive SDK with MCP (Model Context Protocol) servers.
    ///     MCP servers extend the assistant with external tools and data sources — this sample
    ///     configures two MCP servers: deepwiki (wiki reading) and azure_doc (Azure documentation).
    ///
    /// USAGE:
    ///     dotnet run
    ///
    ///     Required environment variables:
    ///     1) AZURE_VOICELIVE_ENDPOINT  - The Azure VoiceLive endpoint
    ///     2) AZURE_VOICELIVE_MODEL     - The model to use (e.g., gpt-realtime)
    ///
    ///     Optional environment variables:
    ///     3) AZURE_VOICELIVE_API_KEY   - API key (if not using DefaultAzureCredential)
    ///     4) AZURE_VOICELIVE_VOICE     - Voice name (default: en-US-AvaNeural)
    ///
    ///     Note: MCP support requires API version 2026-01-01-preview.
    ///
    /// REQUIREMENTS:
    ///     - Azure.AI.VoiceLive
    ///     - Azure.Identity
    ///     - NAudio
    ///     - Microsoft.Extensions.Configuration
    ///     - System.CommandLine
    /// </remarks>
    public class SampleProgram
    {
        public static async Task<int> Main(string[] args)
        {
            var rootCommand = new RootCommand("MCP Voice Assistant using Azure VoiceLive SDK");

            var apiKeyOption = new Option<string?>("--api-key")
            {
                Description = "Azure VoiceLive API key (or set AZURE_VOICELIVE_API_KEY)"
            };
            var endpointOption = new Option<string?>("--endpoint")
            {
                Description = "Azure VoiceLive endpoint (or set AZURE_VOICELIVE_ENDPOINT)"
            };
            var modelOption = new Option<string?>("--model")
            {
                Description = "VoiceLive model to use (or set AZURE_VOICELIVE_MODEL)"
            };
            var voiceOption = new Option<string?>("--voice")
            {
                Description = "Voice for the assistant (or set AZURE_VOICELIVE_VOICE)"
            };
            var useTokenCredentialOption = new Option<bool>("--use-token-credential")
            {
                Description = "Use DefaultAzureCredential instead of API key"
            };
            var verboseOption = new Option<bool>("--verbose")
            {
                Description = "Enable verbose logging"
            };

            rootCommand.Add(apiKeyOption);
            rootCommand.Add(endpointOption);
            rootCommand.Add(modelOption);
            rootCommand.Add(voiceOption);
            rootCommand.Add(useTokenCredentialOption);
            rootCommand.Add(verboseOption);

            var parseResult = rootCommand.Parse(args);
            if (parseResult.Errors.Count > 0)
            {
                foreach (var error in parseResult.Errors)
                    Console.WriteLine(error.Message);
                return 1;
            }

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var apiKey = parseResult.GetValue(apiKeyOption)
                ?? configuration["VoiceLive:ApiKey"]
                ?? Environment.GetEnvironmentVariable("AZURE_VOICELIVE_API_KEY");

            var endpoint = parseResult.GetValue(endpointOption)
                ?? configuration["VoiceLive:Endpoint"]
                ?? Environment.GetEnvironmentVariable("AZURE_VOICELIVE_ENDPOINT");

            var model = parseResult.GetValue(modelOption)
                ?? configuration["VoiceLive:Model"]
                ?? Environment.GetEnvironmentVariable("AZURE_VOICELIVE_MODEL")
                ?? "gpt-realtime";

            var voice = parseResult.GetValue(voiceOption)
                ?? configuration["VoiceLive:Voice"]
                ?? Environment.GetEnvironmentVariable("AZURE_VOICELIVE_VOICE")
                ?? "en-US-AvaNeural";

            var useTokenCredential = parseResult.GetValue(useTokenCredentialOption);
            var verbose = parseResult.GetValue(verboseOption);

            if (string.IsNullOrEmpty(endpoint))
            {
                Console.WriteLine("Error: No endpoint provided. Set AZURE_VOICELIVE_ENDPOINT or use --endpoint.");
                return 1;
            }

            if (string.IsNullOrEmpty(apiKey) && !useTokenCredential)
            {
                Console.WriteLine("Error: No authentication provided.");
                Console.WriteLine("Set AZURE_VOICELIVE_API_KEY, or use --use-token-credential for DefaultAzureCredential.");
                return 1;
            }

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(verbose ? LogLevel.Debug : LogLevel.Information);
            });

            var logger = loggerFactory.CreateLogger<SampleProgram>();

            if (!CheckAudioSystem(logger))
                return 1;

            try
            {
                // MCP requires API version 2026-01-01-preview
                var clientOptions = new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW);

                VoiceLiveClient client;
                if (useTokenCredential)
                {
                    client = new VoiceLiveClient(new Uri(endpoint), new DefaultAzureCredential(), clientOptions);
                    logger.LogInformation("Using DefaultAzureCredential");
                }
                else
                {
                    client = new VoiceLiveClient(new Uri(endpoint), new AzureKeyCredential(apiKey!), clientOptions);
                    logger.LogInformation("Using API key credential");
                }

                var instructions = "You are a helpful voice assistant with access to MCP tools. "
                    + "You can look up information from wikis and Azure documentation to answer questions. "
                    + "Respond conversationally and concisely.";

                using var assistant = new MCPVoiceAssistant(client, model, voice, instructions, loggerFactory);

                using var cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true;
                    cts.Cancel();
                };

                await assistant.StartAsync(cts.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nVoice assistant shut down. Goodbye!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                if (IsWebSocketUnauthorized(ex))
                {
                    PrintUnauthorizedTroubleshooting(endpoint, model, useTokenCredential);
                }

                return 1;
            }

            return 0;
        }

        private static bool CheckAudioSystem(ILogger logger)
        {
            try
            {
                using (var waveIn = new WaveInEvent
                {
                    WaveFormat = new WaveFormat(24000, 16, 1),
                    BufferMilliseconds = 50
                })
                {
                    waveIn.DataAvailable += (_, __) => { };
                    waveIn.StartRecording();
                    waveIn.StopRecording();
                }

                var buffer = new BufferedWaveProvider(new WaveFormat(24000, 16, 1))
                {
                    BufferDuration = TimeSpan.FromMilliseconds(200)
                };

                using (var waveOut = new WaveOutEvent { DesiredLatency = 100 })
                {
                    waveOut.Init(buffer);
                    waveOut.Play();
                    waveOut.Stop();
                }

                logger.LogInformation("Audio system check passed.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Audio system check failed: {ex.Message}");
                return false;
            }
        }

        private static bool IsWebSocketUnauthorized(Exception ex)
        {
            if (ex is WebSocketException webSocketException && webSocketException.Message.Contains("status code '401'", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return ex.InnerException is WebSocketException inner
                && inner.Message.Contains("status code '401'", StringComparison.OrdinalIgnoreCase);
        }

        private static void PrintUnauthorizedTroubleshooting(string endpoint, string model, bool useTokenCredential)
        {
            Console.WriteLine();
            Console.WriteLine("VoiceLive authentication failed (HTTP 401 during websocket handshake).");
            Console.WriteLine("Verify the following settings:");
            Console.WriteLine($"  - Endpoint: {endpoint}");
            Console.WriteLine($"  - Model: {model}");
            Console.WriteLine($"  - Auth mode: {(useTokenCredential ? "DefaultAzureCredential" : "API key")}");
            Console.WriteLine();
            Console.WriteLine("Common fixes:");
            Console.WriteLine("  1) Use a VoiceLive endpoint in this format:");
            Console.WriteLine("     https://<your-resource>.services.ai.azure.com/");
            Console.WriteLine("  2) Ensure the API key comes from the same Azure AI resource as the endpoint.");
            Console.WriteLine("  3) Ensure the model is available on that resource (for example gpt-realtime).");
            Console.WriteLine("  4) If using --use-token-credential, verify you're logged in to the right tenant/subscription and have access to the resource.");
        }
    }
}
