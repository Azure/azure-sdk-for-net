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

/// <summary>
/// FILE: SampleProgram.cs
/// </summary>
/// <remarks>
/// DESCRIPTION:
///     This sample demonstrates sophisticated customer service capabilities using the VoiceLive SDK
///     with function calling. The bot can handle complex customer inquiries including order status,
///     account information, returns, and support scheduling through natural voice conversations.
///
/// FEATURES DEMONSTRATED:
///     - Strongly-typed function calling using SDK's FunctionTool
///     - Real-time customer service operations with external system integration
///     - Professional voice configuration for customer-facing interactions
///     - Robust error handling and graceful degradation
///     - Clean separation between SDK protocol handling and business logic
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
///     - System.Text.Json
/// </remarks>
public class SampleProgram
{
    /// <summary>
    /// Main entry point for the customer service bot sample.
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
        var rootCommand = new RootCommand("Customer Service Bot using Azure VoiceLive SDK with Function Calling");

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
            () => "en-US-JennyNeural",
            "Voice to use for the customer service bot");

        var instructionsOption = new Option<string>(
            "--instructions",
            () => "You are a professional customer service representative for TechCorp. You have access to customer databases and order systems. Always be polite, helpful, and efficient. When customers ask about orders, accounts, or need to schedule service, use the available tools to provide accurate, real-time information. Keep your responses concise but thorough.",
            "System instructions for the customer service bot");

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
            await RunCustomerServiceBotAsync(apiKey, endpoint, model, voice, instructions, useTokenCredential, verbose).ConfigureAwait(false);
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

    private static async Task RunCustomerServiceBotAsync(
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

            // Create customer service functions implementation
            var functions = new CustomerServiceFunctions(loggerFactory.CreateLogger<CustomerServiceFunctions>());

            // Create and start customer service bot
            using var bot = new CustomerServiceBot(
                client,
                model,
                voice,
                instructions,
                functions,
                loggerFactory);

            // Setup cancellation token for graceful shutdown
            using var cancellationTokenSource = new CancellationTokenSource();
            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                logger.LogInformation("Received shutdown signal");
                cancellationTokenSource.Cancel();
            };

            // Display welcome message
            DisplayWelcomeMessage();

            // Start the customer service bot
            await bot.StartAsync(cancellationTokenSource.Token).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\n👋 Customer service bot shut down. Thank you for using TechCorp support!");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Fatal error");
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }

    private static void DisplayWelcomeMessage()
    {
        Console.WriteLine();
        Console.WriteLine("🏢 Welcome to TechCorp Customer Service");
        Console.WriteLine("======================================");
        Console.WriteLine();
        Console.WriteLine("I can help you with:");
        Console.WriteLine("• 📦 Order status and tracking");
        Console.WriteLine("• 👤 Account information and history");
        Console.WriteLine("• 🔄 Returns and exchanges");
        Console.WriteLine("• 📞 Scheduling technical support calls");
        Console.WriteLine("• 🚚 Updating shipping addresses");
        Console.WriteLine();
        Console.WriteLine("Sample data available:");
        Console.WriteLine("• Orders: ORD-2024-001, ORD-2024-002, ORD-2024-003");
        Console.WriteLine("• Customers: john.smith@email.com, sarah.johnson@email.com");
        Console.WriteLine("• Products: LAPTOP-001, MOUSE-001, MONITOR-001");
        Console.WriteLine();
        Console.WriteLine("Try saying things like:");
        Console.WriteLine("• \"What's the status of order ORD-2024-001?\"");
        Console.WriteLine("• \"I need to return a defective laptop\"");
        Console.WriteLine("• \"Can you look up my account info for john.smith@email.com?\"");
        Console.WriteLine("• \"I need to schedule a technical support call\"");
        Console.WriteLine();
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
