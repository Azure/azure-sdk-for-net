# AcsWebSocketAuthenticator Design Document

## Overview
Based on Fariba's feedback, the WebSocket helper design has been updated to give customers full control over WebSocket configuration while Azure Communication Services only handles authentication. The `AcsWebSocketAuthenticator` replaces the removed `WebSocketConnectionHelper` with a focused, authentication-only approach.

## Design Principles
1. **Customer Control**: Customers own and configure the `ClientWebSocket` instance
2. **Authentication Only**: ACS only adds authentication headers — no connection management
3. **Header Persistence**: Headers are permanently stored in `WebSocket.Options` and sent on `ConnectAsync`
4. **Multi-Scenario Support**: Works for media streaming, transcription, or any custom WebSocket use case
5. **Flexible Authentication**: Supports HMAC, Azure AD, CallAutomationClient-backed, and custom authentication
6. **Multi-Framework**: Compatible with .NET Standard 2.0, .NET 8/9/10, .NET Framework 4.6.2/4.7

---

## Architecture

```
???????????????????????????????????????????????????????????????????????????????
?  Customer Code                                                              ?
?                                                                             ?
?  1. var authenticator = callAutomationClient.GetWebSocketAuthenticator();   ?
?  2. var webSocket = new ClientWebSocket();                                  ?
?  3. webSocket.Options.KeepAliveInterval = ...;  // Customer configures      ?
?  4. await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);   ?
?  5. await webSocket.ConnectAsync(streamUrl, ct);  // Customer connects      ?
?  6. // Customer handles all WebSocket I/O                                   ?
???????????????????????????????????????????????????????????????????????????????
         ?                           ?
         ?                           ?
???????????????????????   ??????????????????????????????????????????????????
? AcsWebSocketAuth.   ?   ? ClientWebSocket.Options.Headers                ?
?                     ?   ?                                                ?
? AuthenticateWebSock ?????  Authorization: HMAC-SHA256 ... / Bearer ...   ?
? etAsync()           ?   ?  x-ms-date: <timestamp>                       ?
?                     ?   ?  x-ms-content-sha256: <hash>                  ?
? Internally calls:   ?   ?  User-Agent: Azure-Communication-...          ?
? - CallAutomation    ?   ?  X-FORWARDED-HOST: <endpoint> (HMAC only)     ?
?   Client pipeline   ?   ?                                                ?
?   to get auth info  ?   ?  (All sent automatically on ConnectAsync)     ?
???????????????????????   ??????????????????????????????????????????????????
```

---

## API Surface

### AcsWebSocketAuthenticator Class

```csharp
public class AcsWebSocketAuthenticator
{
    // Constructors
    public AcsWebSocketAuthenticator(AzureKeyCredential keyCredential, string acsEndpoint);
    public AcsWebSocketAuthenticator(TokenCredential tokenCredential, string acsEndpoint);
    public AcsWebSocketAuthenticator(CallAutomationClient callAutomationClient);
    public AcsWebSocketAuthenticator(); // For custom authentication

    // Main authentication method — adds auth headers to WebSocket.Options
    public async Task AuthenticateWebSocketAsync(
        ClientWebSocket webSocket, Uri streamUrl, CancellationToken cancellationToken = default);

    // Helper: add custom headers alongside auth headers
    public void AddCustomHeader(ClientWebSocket webSocket, string headerName, string headerValue);

    // Helper: configure WebSocket options (keep-alive, buffers, subprotocol)
    public void ConfigureWebSocketOptions(
        ClientWebSocket webSocket,
        TimeSpan? keepAliveInterval = null,
        int? receiveBufferSize = null,
        int? sendBufferSize = null,
        string subProtocol = null);

    // Extensibility point for custom authentication
    protected virtual Task AuthenticateCustomAsync(
        ClientWebSocket webSocket, Uri streamUrl, CancellationToken cancellationToken = default);
}
```

### CallAutomationClient Integration

```csharp
public class CallAutomationClient
{
    /// <summary>
    /// Gets an AcsWebSocketAuthenticator that leverages this client's existing
    /// authentication configuration (HMAC or AAD).
    /// </summary>
    public virtual AcsWebSocketAuthenticator GetWebSocketAuthenticator();
}
```

### Internal Supporting Types

```csharp
// Authentication mode enum (internal)
internal enum AuthenticationMode
{
    AadToken,  // Retrieve Bearer token from pipeline
    Hmac       // Retrieve HMAC signature + date + content hash
}

// HMAC authentication info container (internal)
internal class HmacTokenInfo
{
    public string? HmacSignature { get; set; }
    public string? Date { get; set; }
    public string? ContentSha256 { get; set; }
    public string? RawAuthorizationHeader { get; set; }
    public bool HasValidHmacInfo { get; }
    public Dictionary<string, string>? ToWebSocketHeaders();
    public string? ToBase64Token();
}
```

---

## Authentication Methods

### 1. CallAutomationClient Integration (Recommended)
```csharp
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
// OR
var authenticator = new AcsWebSocketAuthenticator(callAutomationClient);
```
**Internal flow:**
1. Calls `CallAutomationClient.GetCurrentHmacTokenDirectAsync()` first
2. If HMAC info is valid (`HasValidHmacInfo == true`), uses `HmacTokenInfo.ToWebSocketHeaders()` to set headers
3. Falls back to `CallAutomationClient.GetCurrentAadTokenDirectAsync()` for Bearer token
4. If both fail, continues without auth (server may still accept based on configuration)

**How token retrieval works internally:**
- `GetAuthenticationInfoInternalAsync(AuthenticationMode, CancellationToken)` creates a lightweight HEAD request
- Sends it through the `HttpPipeline` — this triggers auth policies to add headers
- Extracts the `Authorization`, `x-ms-date`, `x-ms-content-sha256` headers from the request
- Returns either AAD token string or `HmacTokenInfo` depending on mode

### 2. Direct HMAC Authentication
```csharp
var authenticator = new AcsWebSocketAuthenticator(keyCredential, acsEndpoint);
```
**Headers added:**
- `Authorization`: `HMAC-SHA256 SignedHeaders=x-ms-date;host;x-ms-content-sha256&Signature=<sig>`
- `x-ms-date`: RFC 1123 timestamp
- `x-ms-content-sha256`: SHA256 hash of empty body (WebSocket has no request body)
- `X-FORWARDED-HOST`: ACS endpoint
- `User-Agent`: `Azure-Communication-CallAutomation/<version>`

### 3. Direct Azure AD Token Authentication
```csharp
var authenticator = new AcsWebSocketAuthenticator(tokenCredential, acsEndpoint);
```
**Headers added:**
- `Authorization`: `Bearer <token>` (scope: `https://communication.azure.com/.default`)
- `User-Agent`: `Azure-Communication-CallAutomation/<version>`

### 4. Custom Authentication (Extensibility)
```csharp
public class CustomAuthenticator : AcsWebSocketAuthenticator
{
    protected override async Task AuthenticateCustomAsync(
        ClientWebSocket webSocket, Uri streamUrl, CancellationToken cancellationToken)
    {
        webSocket.Options.SetRequestHeader("Custom-Auth", "MyToken");
        await Task.CompletedTask;
    }
}
```

---

## Usage Patterns

### Basic Flow (Recommended)
```csharp
// Step 1: Create authenticator from existing client
var authenticator = callAutomationClient.GetWebSocketAuthenticator();

// Step 2: Create and configure WebSocket (customer owns this)
var webSocket = new ClientWebSocket();
webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
webSocket.Options.SetBuffer(4096, 4096);

// Step 3: Add custom headers (optional)
authenticator.AddCustomHeader(webSocket, "X-App-Name", "MyApp");

// Step 4: Add authentication headers (modifies webSocket.Options.Headers)
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);

// Step 5: Connect — all headers (auth + custom) sent automatically
await webSocket.ConnectAsync(streamUrl, cancellationToken);

// Step 6: Use WebSocket (customer control)
while (webSocket.State == WebSocketState.Open)
{
    var buffer = new byte[4096];
    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
    // Process media streaming / transcription data...
}
```

### Media Streaming Example
```csharp
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
var webSocket = new ClientWebSocket();

// Configure for media streaming
authenticator.ConfigureWebSocketOptions(webSocket,
    keepAliveInterval: TimeSpan.FromSeconds(30),
    receiveBufferSize: 8192,
    subProtocol: "audio-stream");

// Authenticate and connect
await authenticator.AuthenticateWebSocketAsync(webSocket, mediaStreamUrl);
await webSocket.ConnectAsync(mediaStreamUrl, cancellationToken);

// Stream audio
while (webSocket.State == WebSocketState.Open)
{
    var buffer = new byte[1024];
    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
    // Process audio data...
}
```

### Direct HMAC Example (No CallAutomationClient)
```csharp
var keyCredential = new AzureKeyCredential("<access-key>");
var authenticator = new AcsWebSocketAuthenticator(keyCredential, "my-resource.communication.azure.com");

var webSocket = new ClientWebSocket();
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);
await webSocket.ConnectAsync(streamUrl, cancellationToken);
```

---

## Authentication Flow Detail (CallAutomationClient Path)

```
AuthenticateWebSocketAsync(webSocket, streamUrl)
    ?
    ??? AddCommonHeaders: User-Agent
    ?
    ??? Try HMAC first:
    ?     CallAutomationClient.GetCurrentHmacTokenDirectAsync()
    ?       ??? GetAuthenticationInfoInternalAsync(AuthenticationMode.Hmac)
    ?             ??? Create lightweight HEAD request
    ?             ??? Send through HttpPipeline (triggers CustomHMACAuthenticationPolicy)
    ?             ??? Extract Authorization, x-ms-date, x-ms-content-sha256 from request headers
    ?             ??? Return HmacTokenInfo { HmacSignature, Date, ContentSha256, RawAuthorizationHeader }
    ?     If HasValidHmacInfo:
    ?       ??? ToWebSocketHeaders() ? set Authorization, x-ms-date, x-ms-content-sha256
    ?
    ??? Fallback to AAD:
          CallAutomationClient.GetCurrentAadTokenDirectAsync()
            ??? GetAuthenticationInfoInternalAsync(AuthenticationMode.AadToken)
                  ??? Create lightweight HEAD request
                  ??? Send through HttpPipeline (triggers BearerTokenAuthenticationPolicy)
                  ??? Extract Authorization header
                  ??? ExtractAadTokenInternal() ? parse "Bearer <token>"
          If token is valid:
            ??? Set Authorization: Bearer <token>
```

---

## Header Persistence Mechanism

### How Headers Are Stored
1. `AuthenticateWebSocketAsync()` calls `webSocket.Options.SetRequestHeader(name, value)`
2. Headers are stored in `ClientWebSocket.Options` internal header collection
3. Headers become part of the WebSocket's immutable configuration state
4. Headers persist until the `ClientWebSocket` instance is disposed

### How Headers Are Sent
1. Customer calls `webSocket.ConnectAsync(streamUrl)`
2. .NET reads ALL headers from `webSocket.Options`
3. .NET creates the HTTP WebSocket upgrade request including ALL stored headers
4. Server receives and validates authentication headers
5. WebSocket connection established (authenticated)

### Guarantees
? Headers are guaranteed to be sent — they're part of WebSocket state  
? No reference parameters needed — headers stored by value in Options  
? Works across all .NET versions (Standard 2.0, .NET 8/9/10, Framework 4.6.2/4.7)  
? Thread-safe — headers set before ConnectAsync, read-only after  

---

## Migration from WebSocketConnectionHelper

### Old Pattern (Removed)
```csharp
// Old - ACS managed the WebSocket lifecycle
var helper = callAutomationClient.GetWebSocketConnectionHelper();
var webSocket = await helper.ConnectToAcsWebSocketAsync(streamUrl);
```

### New Pattern (Current)
```csharp
// New - Customer controls WebSocket lifecycle, ACS only adds auth
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
var webSocket = new ClientWebSocket();

// Customer configures as needed
webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);

// ACS adds authentication headers
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);

// Customer connects and manages
await webSocket.ConnectAsync(streamUrl, cancellationToken);
```

---

## Error Handling

| Scenario | Behavior |
|----------|----------|
| `webSocket` is null | `ArgumentNullException` thrown |
| `streamUrl` is null | `ArgumentNullException` thrown |
| HMAC token retrieval fails | Silently falls back to AAD token |
| AAD token retrieval fails | Continues without auth (server may reject) |
| No auth configured (default ctor) | Calls `AuthenticateCustomAsync` (no-op by default) |
| `headerName` is null/empty in `AddCustomHeader` | `ArgumentException` thrown |
| Pipeline HEAD request fails | Exception caught internally, returns empty/default token info |

---

## Benefits

### For Customers
? **Full WebSocket Control**: Configure options, manage lifecycle, handle reconnections  
? **Flexible Authentication**: HMAC, AAD, CallAutomationClient-backed, or custom  
? **Custom Headers**: Add application-specific headers alongside authentication  
? **Universal Support**: Works for media streaming, transcription, or any WebSocket scenario  
? **Multi-Framework**: .NET Standard 2.0, .NET 8/9/10, .NET Framework 4.6.2/4.7  
? **Debuggable**: Direct access to WebSocket for troubleshooting  

### For Azure Communication Services
? **Focused Responsibility**: Only handles authentication, not WebSocket management  
? **Backward Compatible**: Integrates with existing CallAutomationClient pipeline auth  
? **Extensible**: Custom authentication via inheritance  
? **Testable**: Internal token methods are virtual for mocking in tests  
? **Extensible**: Easy to add new authentication methods  
? **Testable**: Clear separation of concerns  

## Implementation Status

### Completed
- ? `AcsWebSocketAuthenticator` class with all authentication methods
- ? HMAC authentication implementation
- ? Azure AD token authentication
- ? CallAutomationClient integration
- ? Custom authentication extensibility
- ? Helper methods for WebSocket configuration
- ? Multi-framework compatibility (.NET Standard 2.0, .NET 8/9/10)
- ? Comprehensive documentation and examples
- ? Unit tests and demonstrations

### Architecture Decision
The design follows Fariba's vision of customer control by:
1. Removing WebSocketConnectionHelper that controlled connections
2. Creating AcsWebSocketAuthenticator that only handles authentication
3. Giving customers full control over WebSocket configuration and lifecycle
4. Making authentication a separate, focused concern

This approach provides maximum flexibility while maintaining authentication security and ease of use.
