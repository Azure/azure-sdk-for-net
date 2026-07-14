// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.VoiceLive;
using Azure.Core;
using Azure.Identity;
using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace Azure.AI.VoiceLive.Samples;

internal static class Program
{
    private static int s_spanCount;
    private static int s_sourceMatchCount;

    public static async Task<int> Main(string[] args)
    {
        if (Array.Exists(args, arg => string.Equals(arg, "--help", StringComparison.OrdinalIgnoreCase)))
        {
            PrintUsage();
            return 0;
        }

        string endpoint = GetArgValue(args, "--endpoint")
            ?? Environment.GetEnvironmentVariable("AZURE_VOICELIVE_ENDPOINT")
            ?? "wss://api.voicelive.com/v1";

        string? apiKey = GetArgValue(args, "--api-key")
            ?? Environment.GetEnvironmentVariable("AZURE_VOICELIVE_API_KEY");

        bool useTokenCredential = HasArg(args, "--use-token-credential")
            || string.Equals(Environment.GetEnvironmentVariable("AZURE_VOICELIVE_USE_TOKEN_CREDENTIAL"), "true", StringComparison.OrdinalIgnoreCase);

        bool enableOtelConsoleExporter = HasArg(args, "--otel-console-exporter")
            || string.Equals(Environment.GetEnvironmentVariable("AZURE_VOICELIVE_OTEL_CONSOLE_EXPORTER"), "true", StringComparison.OrdinalIgnoreCase);

        string model = GetArgValue(args, "--model") ?? "gpt-realtime";

        int timeoutSeconds = 20;
        string? timeoutArg = GetArgValue(args, "--timeout-seconds");
        if (!string.IsNullOrEmpty(timeoutArg) && int.TryParse(timeoutArg, out int parsedTimeout))
            timeoutSeconds = Math.Max(5, parsedTimeout);

        // Keep API key as default auth path, but allow explicit or implicit credential auth.
        if (!useTokenCredential && string.IsNullOrWhiteSpace(apiKey))
        {
            Console.WriteLine("No API key detected; using DefaultAzureCredential.");
            useTokenCredential = true;
        }

        // Register an OpenTelemetry provider before constructing the VoiceLive client.
        TracerProviderBuilder tracerBuilder = Sdk.CreateTracerProviderBuilder()
            .AddSource("Azure.AI.VoiceLive");

        if (enableOtelConsoleExporter)
        {
            tracerBuilder.AddConsoleExporter();
            Console.WriteLine("OpenTelemetry ConsoleExporter enabled (duplicate-style span dump).");
        }

        using TracerProvider tracerProvider = tracerBuilder.Build();

        using var traceListener = EnableVoiceLiveConsoleTracing();

        Console.WriteLine($"VoiceLive SDK assembly: {typeof(VoiceLiveClient).Assembly.FullName}");

        VoiceLiveClient client = CreateClient(endpoint, apiKey, useTokenCredential);

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(timeoutSeconds));

        try
        {
            Console.WriteLine("Starting VoiceLive session with tracing enabled...");
            VoiceLiveSession session = await client.StartSessionAsync(model, cts.Token).ConfigureAwait(false);

            await session.ConfigureSessionAsync(new VoiceLiveSessionOptions
            {
                Instructions = "You are a concise assistant. Reply briefly.",
                Model = model
            }, cts.Token).ConfigureAwait(false);

            await session.StartResponseAsync(cts.Token).ConfigureAwait(false);

            await foreach (SessionUpdate update in session.GetUpdatesAsync(cts.Token).ConfigureAwait(false))
            {
                Console.WriteLine($"Event: {update.GetType().Name}");
                if (update is SessionUpdateResponseDone)
                {
                    break;
                }
            }

            await session.CloseAsync(cts.Token).ConfigureAwait(false);
            int spanCount = Volatile.Read(ref s_spanCount);
            Console.WriteLine($"Session closed. Captured spans: {spanCount}.");
            if (spanCount == 0)
            {
                int sourceMatches = Volatile.Read(ref s_sourceMatchCount);
                Console.WriteLine($"No spans were captured. ActivitySources matching 'VoiceLive' observed: {sourceMatches}.");
                Console.WriteLine("If this is 0, the runtime likely isn't emitting VoiceLive ActivitySource spans from the loaded SDK build.");
            }
            return 0;
        }
        catch (OperationCanceledException)
        {
            Console.Error.WriteLine("Timed out waiting for VoiceLive events. Try increasing --timeout-seconds.");
            return 2;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Sample failed: {ex.Message}");
            return 1;
        }
    }

    private static VoiceLiveClient CreateClient(string endpoint, string? apiKey, bool useTokenCredential)
    {
        if (useTokenCredential)
        {
            return new VoiceLiveClient(new Uri(endpoint), new DefaultAzureCredential());
        }

        AzureKeyCredential keyCredential = new(apiKey!);
        return new VoiceLiveClient(new Uri(endpoint), keyCredential);
    }

    private static IDisposable EnableVoiceLiveConsoleTracing()
    {
        var listener = new ActivityListener
        {
            // Listen to all sources so source-name drift won't suppress tracing in this sample.
            ShouldListenTo = source =>
            {
                if (source.Name.Contains("VoiceLive", StringComparison.OrdinalIgnoreCase))
                {
                    Interlocked.Increment(ref s_sourceMatchCount);
                    Console.WriteLine($"ActivitySource detected: {source.Name}");
                }
                return true;
            },
            Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded,
            SampleUsingParentId = (ref ActivityCreationOptions<string> _) => ActivitySamplingResult.AllDataAndRecorded,
            ActivityStopped = activity =>
            {
                Interlocked.Increment(ref s_spanCount);
                Console.WriteLine($"Span: '{activity.DisplayName}' {FormatTags(activity.TagObjects)}");
                foreach (ActivityEvent evt in activity.Events)
                {
                    Console.WriteLine($"  Event '{evt.Name}': {FormatTags(evt.Tags)}");
                }
            }
        };

        ActivitySource.AddActivityListener(listener);
        Console.WriteLine("VoiceLive ActivitySource console tracing enabled.");
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

    private static bool HasArg(string[] args, string key)
        => Array.Exists(args, arg => string.Equals(arg, key, StringComparison.OrdinalIgnoreCase));

    private static string? GetArgValue(string[] args, string key)
    {
        for (int i = 0; i < args.Length - 1; i++)
        {
            if (string.Equals(args[i], key, StringComparison.OrdinalIgnoreCase))
                return args[i + 1];
        }
        return null;
    }

    private static void PrintUsage()
    {
        Console.WriteLine("VoiceLive OpenTelemetry tracing sample");
        Console.WriteLine("Options:");
        Console.WriteLine("  --endpoint <url>             VoiceLive endpoint URL");
        Console.WriteLine("  --api-key <key>              VoiceLive API key");
        Console.WriteLine("  --use-token-credential       Use DefaultAzureCredential instead of API key");
        Console.WriteLine("  --model <name>               VoiceLive model (default: gpt-realtime)");
        Console.WriteLine("  --timeout-seconds <n>        Wait limit for response.done (default: 20)");
        Console.WriteLine("  --otel-console-exporter      Enable OpenTelemetry ConsoleExporter output");
        Console.WriteLine("  --help                       Show this help");
    }
}
