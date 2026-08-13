---
page_type: sample
languages:
- csharp
products:
- azure
- azure-ai-services
urlFragment: agentserver-voice-bridge-echo
name: Voice Bridge echo hosted agent
description: A runnable model-free hosted agent that demonstrates the selected Voice Live Bridge Protocol 1.0 surface.
---

# Voice Bridge echo hosted agent

This is a runnable, model-free hosted agent. Voice Live owns audio, speech
recognition, synthesis, VAD, and turn-taking. The container receives text and
control events through `/invocations_ws` and explicitly sends every outbound
message.

The sample starts response work in application-owned tasks. The handler remains
free to receive `barge_in`, `response.timeout`, and cancellation events while an
echo is streaming.

## Run locally

From the repository root, start the hosted agent:

```dotnetcli
dotnet run --project samples/agentserver/voice-bridge-echo/VoiceBridgeEcho.csproj
```

It listens on `http://localhost:8088` and exposes the Bridge endpoint at
`ws://localhost:8088/invocations_ws`.

In another terminal, run the included fake-Bridge smoke client:

```powershell
pwsh samples/agentserver/voice-bridge-echo/scripts/smoke-test.ps1
```

The script verifies this real wire flow:

1. `session.start` -> `session.ready`
2. `user.message` -> `response.created`
3. one or more `response.output_text.delta` messages
4. `response.output_text.done` -> `response.done`

## Capability commands

Speak or send these strings as the completed `user.message` text:

| Input | Behavior |
|---|---|
| Any text | Streams `Echo: ...`, then sends item and response completion. |
| `/stream text` | Explicit streaming echo. |
| `/done text` | Non-streaming echo using one `response.output_text.done`. |
| `/voice text` | Non-streaming echo with a per-item synthesis `voice` patch. |
| `/none` | Declines the input with `response.none`. |
| `/proactive text` | Declines the command input, requests proactive admission, then speaks after `response.accepted`. |
| `/cancel text` | Opens a response, emits a delta, then sends `response.cancel`. |
| `/error` | Sends a response-scoped `error`. |
| `/session-error` | Sends a session-scoped `error`. |
| `/end` | Sends `end_call` in drain mode. |
| `/end-now` | Sends `end_call` in immediate mode. |
| `/help` | Returns this command summary. |

Set `VOICE_SAMPLE_REJECT_START=true` before startup to demonstrate
`session.rejected`. Otherwise the agent validates `protocol_version` and sends
`session.ready`.

The handler implements every selected inbound callback:

- `user.message` and `user.no_input` create or decline responses;
- `user.speech_started` is logged;
- `barge_in` cancels application-owned echo work;
- `response.accepted` starts admitted proactive output;
- `response.dropped` releases a proactive request;
- `response.cancelled` completes the self-cancel flow;
- `response.timeout` cancels work by response or pending input ID;
- `session.end` cancels all remaining work; and
- `OnConnectionTerminating` performs final cooperative cancellation.

Together, the commands and callbacks exercise all selected Protocol 1.0 outbound
types: `session.ready`, `session.rejected`, `response.created`, `response.none`,
`response.output_text.delta`, `response.output_text.done`, `response.done`,
`response.cancel`, `end_call`, and `error`.

## Build the container

From the sample directory:

```dotnetcli
dotnet publish -c Release -o publish
docker build -t voice-bridge-echo:latest .
docker run --rm -p 8088:8088 voice-bridge-echo:latest
```

Push the image to the registry used by your Foundry project. Deploy with the
declarations in `agent.manifest.yaml`: `invocations_ws`,
`voiceLiveCompatible: "true"`, and exact `bridgeProtocolVersion: "1.0"` select
the typed Bridge contract.

## Ownership

The sample owns response and item IDs, application tasks, and cancellation. The
library validates and relays one message at a time. Voice Live owns proactive
admission, media, turn arbitration, response deadlines, and cross-message
protocol validation.
