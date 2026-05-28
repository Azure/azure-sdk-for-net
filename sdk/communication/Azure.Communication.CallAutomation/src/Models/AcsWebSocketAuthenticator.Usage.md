# AcsWebSocketAuthenticator

Authenticates WebSocket connections to Azure Communication Services media streaming and transcription endpoints.

## High-Level Architecture

```
┌─────────────────────────────────────────────────────────────────────────┐
│                        Your Application                                  │
│                                                                         │
│  ┌──────────────────────┐      ┌──────────────────────────────────┐    │
│  │ CallAutomationClient │─────>│ AcsWebSocketAuthenticator        │    │
│  │                      │      │                                  │    │
│  │ • Connection String  │      │ • AuthenticateWebSocketAsync()   │    │
│  │   (HMAC key + ACS    │      │   Sets headers on ClientWebSocket│    │
│  │    endpoint)          │      │                                  │    │
│  │ • TokenCredential    │      │ • Supports: HMAC, AAD, Custom   │    │
│  │   (AAD)              │      └──────────────┬───────────────────┘    │
│  └──────────────────────┘                     │                         │
│                                               │ Sets headers:           │
│                                               │  • Authorization        │
│                                               │  • X-Ms-Host            │
│                                               │  • date                 │
│                                               │  • x-ms-content-sha256  │
│                                               ▼                         │
│  ┌──────────────────────────────────────────────────────────────┐      │
│  │ ClientWebSocket                                               │      │
│  │  .Options.Headers ← auth headers injected here               │      │
│  │  .ConnectAsync(streamUrl) ← you call this after auth         │      │
│  └──────────────────────────────┬───────────────────────────────┘      │
└─────────────────────────────────┼───────────────────────────────────────┘
                                  │ WSS upgrade request
                                  │ (includes auth headers)
                                  ▼
┌─────────────────────────────────────────────────────────────────────────┐
│  ACS Media Platform (wss://...mediapaas.infra.teams.microsoft.com)      │
│                                                                         │
│  • Validates Authorization header against ACS resource (X-Ms-Host)      │
│  • Returns 101 Switching Protocols on success                           │
│  • Streams audio frames (PCM 16kHz/24kHz mono)                          │
└─────────────────────────────────────────────────────────────────────────┘
```

## Quick Start (Recommended)

```csharp
var client = new CallAutomationClient(connectionString);
// Or with PMA: new CallAutomationClient(pmaEndpoint, connectionString);

var authenticator = client.GetWebSocketAuthenticator();
var ws = new ClientWebSocket();

var streamUrl = new Uri(callConnectionProperties.MediaStreamingSubscription.StreamUrl);
await authenticator.AuthenticateWebSocketAsync(ws, streamUrl);
await ws.ConnectAsync(streamUrl, CancellationToken.None);
```

## Authentication Methods

| Method | Constructor | When to Use |
|--------|-------------|-------------|
| **HMAC** | `new AcsWebSocketAuthenticator(keyCredential, acsEndpoint)` | Have access key directly |
| **AAD** | `new AcsWebSocketAuthenticator(tokenCredential, acsEndpoint)` | Using Entra ID / managed identity |
| **Client** | `client.GetWebSocketAuthenticator()` | Already have a `CallAutomationClient` |
| **Custom** | Override `AuthenticateCustomAsync` | Non-standard auth scenarios |

## HMAC Signature Format

```
Headers set:
  Authorization: HMAC-SHA256 SignedHeaders=date;host;x-ms-content-sha256&Signature=<sig>
  date:                 <RFC 1123 UTC timestamp>
  x-ms-content-sha256:  <SHA256 of empty string>
  X-Ms-Host:            <ACS resource host, e.g. myresource.communication.azure.com>

StringToSign = "GET\n{streamUrl.PathAndQuery}\n{date};{acsHost};{contentHash}"
Signature    = Base64(HMAC-SHA256(Base64Decode(accessKey), UTF8(StringToSign)))
```

## End-to-End Example

```csharp
// 1. Answer call with media streaming
var answerOptions = new AnswerCallOptions(incomingCallContext, callbackUri)
{
    MediaStreamingOptions = new MediaStreamingOptions(
        new Uri("wss://placeholder"),
        MediaStreamingContent.Audio,
        MediaStreamingAudioChannel.Mixed,
        MediaStreamingTransport.Websocket)
    { StartMediaStreaming = true }
};
var answerResult = await client.AnswerCallAsync(answerOptions);

// 2. Authenticate and connect WebSocket
var streamUrl = new Uri(answerResult.Value.CallConnectionProperties
    .MediaStreamingSubscription.StreamUrl);

var authenticator = client.GetWebSocketAuthenticator();
var ws = new ClientWebSocket();
ws.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);

await authenticator.AuthenticateWebSocketAsync(ws, streamUrl);
await ws.ConnectAsync(streamUrl, CancellationToken.None);

// 3. Receive audio
var buffer = new byte[64 * 1024];
while (ws.State == WebSocketState.Open)
{
    var result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
    if (result.MessageType == WebSocketMessageType.Close) break;
    // Process audio frames...
}
```

## Custom Headers

```csharp
var authenticator = client.GetWebSocketAuthenticator();
var ws = new ClientWebSocket();

authenticator.AddCustomHeader(ws, "X-App-Name", "MyMediaApp");
await authenticator.AuthenticateWebSocketAsync(ws, streamUrl);
await ws.ConnectAsync(streamUrl, CancellationToken.None);
```

## Key Points

- **You own the WebSocket** — configure options, manage lifecycle, handle reconnection
- **Signature targets the stream URL** — not the ACS resource endpoint
- **PMA endpoint ≠ ACS endpoint** — the authenticator resolves the correct ACS host from the connection string
- **Call `AuthenticateWebSocketAsync` before `ConnectAsync`** — headers are stored in `WebSocket.Options` and sent during the HTTP upgrade
