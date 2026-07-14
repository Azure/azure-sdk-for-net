// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics;
using Azure.AI.VoiceLive.Samples;
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
    ///     Demonstrates how to use the VoiceLive SDK with Azure AI Foundry agents (Agent V2 API).
    ///     The agent session connects to a pre-configured agent rather than using inline instructions,
    ///     enabling voice access to agents with tools, knowledge bases, and custom behaviors.
    ///
    /// USAGE:
    ///     dotnet run
    ///
    ///     Required environment variables:
    ///     1) AZURE_VOICELIVE_ENDPOINT - The Azure VoiceLive endpoint
    ///     2) AGENT_NAME               - The Azure AI Foundry agent name
    ///     3) AGENT_PROJECT_NAME       - The Azure AI Foundry project name
    ///
    ///     Optional environment variables:
    ///     4) AGENT_VERSION                     - Specific agent version (defaults to latest)
    ///     5) AGENT_VOICE                       - Voice for the assistant (default: en-US-AvaNeural)
    ///     6) FOUNDRY_RESOURCE_OVERRIDE         - Override Foundry resource endpoint
    ///     7) AGENT_AUTH_IDENTITY_CLIENT_ID     - Managed identity client ID for authentication
    ///
    ///     Note: Agent sessions require DefaultAzureCredential — API key authentication is not supported.
    ///
    /// REQUIREMENTS:
    ///     - Azure.AI.VoiceLive
    ///     - Azure.Core (DefaultAzureCredential in Azure.Identity namespace)
    ///     - NAudio
    ///     - Microsoft.Extensions.Configuration
    ///     - System.CommandLine
    /// </remarks>
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var rootCommand = new RootCommand("Agent Voice Assistant using Azure VoiceLive SDK");

            var endpointOption = new Option<string?>("--endpoint")
            {
                Description = "Azure VoiceLive endpoint (or set AZURE_VOICELIVE_ENDPOINT)"
            };
            var agentNameOption = new Option<string?>("--agent-name")
            {
                Description = "Azure AI Foundry agent name (or set AGENT_NAME)"
            };
            var agentProjectOption = new Option<string?>("--agent-project")
            {
                Description = "Azure AI Foundry project name (or set AGENT_PROJECT_NAME)"
            };
            var agentVersionOption = new Option<string?>("--agent-version")
            {
                Description = "Agent version (or set AGENT_VERSION)"
            };
            var voiceOption = new Option<string?>("--voice")
            {
                Description = "Voice for the assistant (or set AGENT_VOICE)"
            };
            var foundryOverrideOption = new Option<string?>("--foundry-resource-override")
            {
                Description = "Override Foundry resource endpoint (or set FOUNDRY_RESOURCE_OVERRIDE)"
            };
            var authIdentityOption = new Option<string?>("--auth-identity-client-id")
            {
                Description = "Managed identity client ID (or set AGENT_AUTH_IDENTITY_CLIENT_ID)"
            };
            var verboseOption = new Option<bool>("--verbose")
            {
                Description = "Enable verbose logging"
            };
            var showTracesOption = new Option<bool>("--show-traces")
            {
                Description = "Print VoiceLive telemetry spans to console"
            };

            rootCommand.Add(endpointOption);
            rootCommand.Add(agentNameOption);
            rootCommand.Add(agentProjectOption);
            rootCommand.Add(agentVersionOption);
            rootCommand.Add(voiceOption);
            rootCommand.Add(foundryOverrideOption);
            rootCommand.Add(authIdentityOption);
            rootCommand.Add(verboseOption);
            rootCommand.Add(showTracesOption);

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

            var endpoint = parseResult.GetValue(endpointOption)
                ?? configuration["VoiceLive:Endpoint"]
                ?? Environment.GetEnvironmentVariable("AZURE_VOICELIVE_ENDPOINT");

            var agentName = parseResult.GetValue(agentNameOption)
                ?? configuration["Agent:Name"]
                ?? Environment.GetEnvironmentVariable("AGENT_NAME");

            var agentProject = parseResult.GetValue(agentProjectOption)
                ?? configuration["Agent:ProjectName"]
                ?? Environment.GetEnvironmentVariable("AGENT_PROJECT_NAME");

            var agentVersion = parseResult.GetValue(agentVersionOption)
                ?? configuration["Agent:Version"]
                ?? Environment.GetEnvironmentVariable("AGENT_VERSION");

            var voice = parseResult.GetValue(voiceOption)
                ?? configuration["Agent:Voice"]
                ?? Environment.GetEnvironmentVariable("AGENT_VOICE")
                ?? "en-US-AvaNeural";

            var foundryOverride = parseResult.GetValue(foundryOverrideOption)
                ?? configuration["Agent:FoundryResourceOverride"]
                ?? Environment.GetEnvironmentVariable("FOUNDRY_RESOURCE_OVERRIDE");

            var authIdentityClientId = parseResult.GetValue(authIdentityOption)
                ?? configuration["Agent:AuthIdentityClientId"]
                ?? Environment.GetEnvironmentVariable("AGENT_AUTH_IDENTITY_CLIENT_ID");

            var verbose = parseResult.GetValue(verboseOption);
            var showTraces = parseResult.GetValue(showTracesOption)
                || string.Equals(Environment.GetEnvironmentVariable("VOICELIVE_ENABLE_CONSOLE_TRACING"), "true", StringComparison.OrdinalIgnoreCase);

            if (string.IsNullOrEmpty(endpoint))
            {
                Console.WriteLine("Error: No endpoint provided. Set AZURE_VOICELIVE_ENDPOINT or use --endpoint.");
                return 1;
            }

            if (string.IsNullOrEmpty(agentName) || string.IsNullOrEmpty(agentProject))
            {
                Console.WriteLine("Error: Agent name and project name are required.");
                Console.WriteLine("Set AGENT_NAME and AGENT_PROJECT_NAME, or use --agent-name and --agent-project.");
                return 1;
            }

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(verbose ? LogLevel.Debug : LogLevel.Information);
            });

            using var traceListener = EnableVoiceLiveConsoleTracing(showTraces);

            var logger = loggerFactory.CreateLogger<Program>();

            if (!CheckAudioSystem(logger))
                return 1;

            try
            {
                var credential = new DefaultAzureCredential();
                var client = new VoiceLiveClient(new Uri(endpoint), credential, new VoiceLiveClientOptions());

                var agentConfig = new AgentSessionConfig(agentName, agentProject)
                {
                    AgentVersion = agentVersion,
                    FoundryResourceOverride = string.IsNullOrEmpty(foundryOverride) ? null : foundryOverride,
                    AuthenticationIdentityClientId = authIdentityClientId
                };

                using var assistant = new AgentVoiceAssistant(client, agentConfig, voice, loggerFactory);

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
                return 1;
            }

            return 0;
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
    }
}
