# AcsWebSocketAuthenticator Design Document Update

## Overview
Based on Fariba's feedback, the WebSocket helper design has been updated to give customers full control over WebSocket configuration while Azure Communication Services only handles authentication.

## New Design: AcsWebSocketAuthenticator

### Key Design Principles
1. **Customer Control**: Customers own and configure the WebSocket instance
2. **Authentication Only**: ACS only adds authentication headers
3. **Header Persistence**: Headers are permanently stored in WebSocket.Options
4. **Multi-Scenario Support**: Works for media streaming, transcription, any WebSocket use case
5. **Flexible Authentication**: Supports multiple authentication methods

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

    // Main authentication method
    public async Task AuthenticateWebSocketAsync(ClientWebSocket webSocket, Uri streamUrl, CancellationToken cancellationToken = default);
    
    // Helper methods for customer control
    public void AddCustomHeader(ClientWebSocket webSocket, string headerName, string headerValue);
    public void ConfigureWebSocketOptions(ClientWebSocket webSocket, TimeSpan? keepAliveInterval = null, int? receiveBufferSize = null, int? sendBufferSize = null, string subProtocol = null);
    
    // Extensibility for custom authentication
    protected virtual Task AuthenticateCustomAsync(ClientWebSocket webSocket, Uri streamUrl, CancellationToken cancellationToken = default);
}
```

### CallAutomationClient Integration

```csharp
public class CallAutomationClient
{
    // New method to get authenticator
    public virtual AcsWebSocketAuthenticator GetWebSocketAuthenticator();
}
```

## Authentication Methods

### 1. HMAC Authentication (Direct)
```csharp
var authenticator = new AcsWebSocketAuthenticator(keyCredential, acsEndpoint);
```

### 2. Azure AD Token Authentication (Direct)
```csharp
var authenticator = new AcsWebSocketAuthenticator(tokenCredential, acsEndpoint);
```

### 3. CallAutomationClient Integration (Recommended)
```csharp
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
// OR
var authenticator = new AcsWebSocketAuthenticator(callAutomationClient);
```

### 4. Custom Authentication
```csharp
public class CustomAuthenticator : AcsWebSocketAuthenticator
{
    protected override async Task AuthenticateCustomAsync(ClientWebSocket webSocket, Uri streamUrl, CancellationToken cancellationToken)
    {
        // Custom authentication logic
        webSocket.Options.SetRequestHeader("Custom-Auth", "MyToken");
    }
}
```

## Usage Patterns

### Basic Flow
```csharp
// Step 1: Create authenticator
var authenticator = callAutomationClient.GetWebSocketAuthenticator();

// Step 2: Create and configure WebSocket (customer control)
var webSocket = new ClientWebSocket();
webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
webSocket.Options.SetBuffer(4096, 4096);

// Step 3: Add custom headers (optional)
authenticator.AddCustomHeader(webSocket, "X-App-Name", "MyApp");

// Step 4: Add authentication headers
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);

// Step 5: Connect (all headers sent automatically)
await webSocket.ConnectAsync(streamUrl, cancellationToken);

// Step 6: Use WebSocket (customer control)
// ... media streaming, transcription, etc.
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

// Add authentication
await authenticator.AuthenticateWebSocketAsync(webSocket, mediaStreamUrl);

// Connect and stream
await webSocket.ConnectAsync(mediaStreamUrl, cancellationToken);
while (webSocket.State == WebSocketState.Open)
{
    var buffer = new byte[1024];
    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
    // Process audio data...
}
```

## Authentication Headers Added

### HMAC Authentication Headers
- `Authorization`: HMAC-SHA256 signature with signed headers
- `x-ms-date`: RFC 1123 timestamp
- `x-ms-content-sha256`: SHA256 hash of empty content
- `X-FORWARDED-HOST`: ACS endpoint
- `User-Agent`: Client version information

### CallAutomationClient Integration
- Tries HMAC authentication first (using `GetCurrentHmacTokenDirectAsync()`)
- Falls back to AAD Bearer token (using `GetCurrentAadTokenDirectAsync()`)
- Preserves existing authentication configuration

## Header Persistence Mechanism

### How Headers Are Stored
1. `AuthenticateWebSocketAsync()` calls `webSocket.Options.SetRequestHeader(name, value)`
2. Headers are stored in `ClientWebSocket.Options.Headers` (internal collection)
3. Headers become part of the WebSocket's configuration state
4. Headers persist until WebSocket is disposed

### How Headers Are Sent
1. Customer calls `webSocket.ConnectAsync(streamUrl)`
2. .NET Framework reads ALL headers from `webSocket.Options.Headers`
3. .NET creates HTTP WebSocket upgrade request with ALL stored headers
4. Server receives and validates authentication headers
5. WebSocket connection established (authenticated)

### Guarantee
? Headers are guaranteed to be sent because they're part of WebSocket state  
? No reference parameters needed - headers stored by value  
? Works across all .NET versions (Standard 2.0, .NET 8/9/10, Framework 4.6.2/4.7)  

## Migration from WebSocketConnectionHelper

### Old Pattern (Removed)
```csharp
// Old - removed
var helper = callAutomationClient.GetWebSocketConnectionHelper();
var webSocket = await helper.ConnectToAcsWebSocketAsync(streamUrl);
```

### New Pattern (Current)
```csharp
// New - customer control
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
var webSocket = new ClientWebSocket();

// Customer configures WebSocket
webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);

// ACS adds authentication
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);

// Customer connects and uses
await webSocket.ConnectAsync(streamUrl, cancellationToken);
```

## Benefits of New Design

### For Customers
? **Full WebSocket Control**: Configure options, manage lifecycle, handle connections  
? **Flexible Authentication**: Multiple auth methods, easy to extend  
? **Custom Headers**: Add application-specific headers alongside authentication  
? **Universal Support**: Works for any WebSocket scenario (media, transcription, custom)  
? **Multi-Framework**: Compatible with all supported .NET versions  

### For Azure Communication Services
? **Focused Responsibility**: Only handles authentication, not WebSocket management  
? **Backward Compatible**: Integrates with existing CallAutomationClient authentication  
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
