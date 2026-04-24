// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// TELEMETRY VALIDATION SAMPLE
// ----------------------------
// Mirrors sample_voicelive_with_console_tracing.py for side-by-side span comparison.
//
// SETUP:
//   $env:AZURE_VOICELIVE_ENDPOINT = "wss://..."
//   $env:AZURE_VOICELIVE_API_KEY  = "your-key"       # or omit and use DefaultAzureCredential
//   $env:AZURE_VOICELIVE_MODEL    = "gpt-4o-realtime-preview"
//   $env:OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT = "true"   # optional: capture content
//
// RUN:
//   dotnet run
//
// COMPARE WITH PYTHON:
//   python sample_voicelive_with_console_tracing.py

using Azure;
using Azure.AI.VoiceLive;
using Azure.Identity;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

// ---------------------------------------------------------------------------
// 1. Wire up OpenTelemetry → Console exporter (mirrors Python ConsoleSpanExporter)
// ---------------------------------------------------------------------------
using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("voicelive-telemetry-validation"))
    .AddSource("Azure.AI.VoiceLive")   // must match ActivitySource name in VoiceLiveTracer
    .AddConsoleExporter()
    .Build();

// ---------------------------------------------------------------------------
// 2. Read config from environment (same vars as the Python sample)
// ---------------------------------------------------------------------------
string endpoint = Environment.GetEnvironmentVariable("AZURE_VOICELIVE_ENDPOINT")
    ?? Environment.GetEnvironmentVariable("AI_SERVICES_ENDPOINT")
    ?? throw new InvalidOperationException("Set AZURE_VOICELIVE_ENDPOINT or AI_SERVICES_ENDPOINT");
string? apiKey  = Environment.GetEnvironmentVariable("AZURE_VOICELIVE_API_KEY");
string model    = Environment.GetEnvironmentVariable("AZURE_VOICELIVE_MODEL")
    ?? Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME")
    ?? "gpt-4o-realtime-preview";

// Agent-centric connection (preferred when agent vars are set)
string? agentName   = Environment.GetEnvironmentVariable("TEST_AGENT_NAME");
string? projectName = Environment.GetEnvironmentVariable("AGENT_PROJECT_NAME");

// ---------------------------------------------------------------------------
// 3. Create client
// ---------------------------------------------------------------------------
VoiceLiveClient client = apiKey is not null
    ? new VoiceLiveClient(new Uri(endpoint), new AzureKeyCredential(apiKey))
    : new VoiceLiveClient(new Uri(endpoint), new DefaultAzureCredential());

// ---------------------------------------------------------------------------
// 4. Connect, configure, send a text turn, read until response.done
// ---------------------------------------------------------------------------
VoiceLiveSession session;
if (!string.IsNullOrEmpty(agentName) && !string.IsNullOrEmpty(projectName))
{
    Console.Error.WriteLine($"[sample] Connecting to {endpoint} with agent '{agentName}' in project '{projectName}'");
    var agentConfig = new AgentSessionConfig(agentName, projectName);
    session = await client.StartSessionAsync(agentConfig).ConfigureAwait(false);
}
else
{
    Console.Error.WriteLine($"[sample] Connecting to {endpoint} with model {model}");
    session = await client.StartSessionAsync(model).ConfigureAwait(false);
}
await using var _ = session;

if (string.IsNullOrEmpty(agentName))
{
    // Model sessions: configure text-only modality (no audio hardware needed)
    var sessionOptions = new VoiceLiveSessionOptions
    {
        Model = model,
        Instructions = "You are a helpful assistant. Say hello briefly.",
        TurnDetection = new ServerVadTurnDetection
        {
            Threshold = 0.5f,
            PrefixPadding = TimeSpan.FromMilliseconds(300),
            SilenceDuration = TimeSpan.FromMilliseconds(500),
        },
        OutputAudioFormat = OutputAudioFormat.Pcm16,
    };
    sessionOptions.Modalities.Clear();
    sessionOptions.Modalities.Add(InteractionModality.Text);

    await session.ConfigureSessionAsync(sessionOptions).ConfigureAwait(false);
    Console.Error.WriteLine("[sample] session.update sent (text modality)");
}

// Wait for session.created before sending any items
await session.WaitForUpdateAsync<SessionUpdateSessionCreated>().ConfigureAwait(false);
Console.Error.WriteLine("[sample] session.created received");

// Send a user text message
var userItem = new UserMessageItem([new InputTextContentPart("Hello, tell me a joke")]);
await session.AddItemAsync(userItem).ConfigureAwait(false);
await session.StartResponseAsync().ConfigureAwait(false);
Console.Error.WriteLine("[sample] user message + response.create sent");

// Read events until we get response.done (or error), then stop
await foreach (SessionUpdate update in session.GetUpdatesAsync().ConfigureAwait(false))
{
    Console.Error.WriteLine($"[sample] recv: {update.GetType().Name}");
    if (update is SessionUpdateResponseDone)
    {
        Console.Error.WriteLine("[sample] response.done — stopping");
        break;
    }
    if (update is SessionUpdateError err)
    {
        Console.Error.WriteLine($"[sample] error received — stopping");
        break;
    }
}

Console.Error.WriteLine("[sample] Done. Spans above were exported to stdout by ConsoleExporter.");
// TracerProvider.Dispose() (via `using`) flushes remaining spans before process exits.
