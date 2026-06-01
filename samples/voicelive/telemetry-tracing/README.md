---
page_type: sample
languages:
- csharp
products:
- azure
- azure-ai-voicelive
name: Azure VoiceLive telemetry tracing sample for .NET
description: Sample demonstrating automatic OpenTelemetry tracing for Azure VoiceLive sessions.
---

# VoiceLive Telemetry Tracing Sample

This sample demonstrates the telemetry experience for Azure VoiceLive in .NET:

- Registers an OpenTelemetry tracer provider with console exporter
- Builds a VoiceLive client with no telemetry-specific client configuration
- Starts a VoiceLive session and triggers representative operations
- Prints emitted spans to the console

## What this sample shows

Telemetry in Azure VoiceLive is automatic when an OpenTelemetry provider is present.

- The SDK emits spans for connect, send, receive, and close operations.
- If no OpenTelemetry provider is configured, tracing is a no-op.
- This sample does not configure or demonstrate content recording.

## Prerequisites

- .NET 10.0 or later
- Azure VoiceLive endpoint and API key, or Azure Core credential flow (`DefaultAzureCredential` in the `Azure.Identity` namespace)

## Setup

Set environment variables for one of the auth flows:

API key flow:

```bash
export AZURE_VOICELIVE_ENDPOINT="wss://api.voicelive.com/v1"
export AZURE_VOICELIVE_API_KEY="your-api-key"
```

Azure Core credential flow:

```bash
export AZURE_VOICELIVE_ENDPOINT="wss://<your-resource>.services.ai.azure.com/api/voice-live"
export AZURE_VOICELIVE_USE_TOKEN_CREDENTIAL=true
```

## Run

```bash
dotnet run --project samples/voicelive/telemetry-tracing/TelemetryTracingSample.csproj
```

Optional arguments:

- `--endpoint <url>` override endpoint
- `--api-key <key>` override api key
- `--use-token-credential` use `DefaultAzureCredential` instead of API key
- `--model <name>` override model (default: `gpt-realtime`)
- `--timeout-seconds <n>` wait limit for `response.done` (default: `20`)

## Expected output

You should see span output similar to:

```text
'send session.update' : {gen_ai.operation.name=send, gen_ai.voice.event_type=session.update, ...}
'recv session.created' : {gen_ai.operation.name=recv, gen_ai.voice.event_type=session.created, ...}
'recv response.done' : {gen_ai.usage.input_tokens=..., gen_ai.usage.output_tokens=..., ...}
'close' : {gen_ai.operation.name=close, ...}
'connect gpt-realtime' : {gen_ai.voice.session_id=..., gen_ai.voice.turn_count=..., ...}
```
