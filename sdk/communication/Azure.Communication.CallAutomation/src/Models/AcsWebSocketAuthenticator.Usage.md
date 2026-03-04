# AcsWebSocketAuthenticator Usage Guide

The `AcsWebSocketAuthenticator` provides authentication for WebSocket connections to Azure Communication Services. It supports multiple authentication methods while giving customers full control over WebSocket configuration.

## Usage Patterns

### 1. Using CallAutomationClient (Recommended)

This approach leverages the existing authentication configuration from your CallAutomationClient and automatically tries HMAC authentication first, then falls back to AAD token authentication.

```csharp
// Create CallAutomationClient
var callAutomationClient = new CallAutomationClient(connectionString);

// Get authenticator from client
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
// Or create directly: var authenticator = new AcsWebSocketAuthenticator(callAutomationClient);

// Create and configure WebSocket
var webSocket = new ClientWebSocket();
webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
webSocket.Options.SetBuffer(4096, 4096);

// Add authentication headers (uses CallAutomationClient's auth)
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl, cancellationToken);

// Connect to WebSocket
await webSocket.ConnectAsync(streamUrl, cancellationToken);

// Use WebSocket for media streaming, transcription, etc.
// ... your WebSocket communication code ...

webSocket.Dispose();
```

### 2. Direct HMAC Authentication

```csharp
// Create authenticator with key credential
var authenticator = new AcsWebSocketAuthenticator(keyCredential, acsEndpoint);

var webSocket = new ClientWebSocket();
// Configure WebSocket options as needed
webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);

// Add HMAC authentication headers
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl, cancellationToken);

// Connect and use WebSocket
await webSocket.ConnectAsync(streamUrl, cancellationToken);
```

### 3. Direct AAD Token Authentication

```csharp
// Create authenticator with token credential
var authenticator = new AcsWebSocketAuthenticator(tokenCredential, acsEndpoint);

var webSocket = new ClientWebSocket();
// Configure WebSocket options
webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);

// Add Bearer token authentication headers
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl, cancellationToken);

// Connect and use WebSocket
await webSocket.ConnectAsync(streamUrl, cancellationToken);
```

### 4. Custom Authentication

```csharp
public class CustomWebSocketAuthenticator : AcsWebSocketAuthenticator
{
    protected override async Task AuthenticateCustomAsync(
        ClientWebSocket webSocket, 
        Uri streamUrl, 
        CancellationToken cancellationToken = default)
    {
        // Add your custom authentication headers
        webSocket.Options.SetRequestHeader("Custom-Auth", "MyCustomToken");
        webSocket.Options.SetRequestHeader("X-Custom-Header", "CustomValue");
        
        await Task.CompletedTask;
    }
}

// Usage
var authenticator = new CustomWebSocketAuthenticator();
var webSocket = new ClientWebSocket();

await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl, cancellationToken);
await webSocket.ConnectAsync(streamUrl, cancellationToken);
```

### 5. Adding Custom Headers to Any Authentication Method

```csharp
var authenticator = new AcsWebSocketAuthenticator(callAutomationClient);
var webSocket = new ClientWebSocket();

// Add custom headers before authentication
authenticator.AddCustomHeader(webSocket, "X-Custom-Header", "MyValue");

// Configure WebSocket options using the helper method
authenticator.ConfigureWebSocketOptions(
    webSocket,
    keepAliveInterval: TimeSpan.FromSeconds(30),
    receiveBufferSize: 8192,
    sendBufferSize: 8192,
    subProtocol: "my-protocol");

// Authenticate (this preserves custom headers and configuration)
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl, cancellationToken);

// Connect
await webSocket.ConnectAsync(streamUrl, cancellationToken);
```

## Key Benefits

1. **Customer Control**: Full control over WebSocket configuration, connection management, and lifetime
2. **Multiple Auth Methods**: Supports HMAC, AAD token, CallAutomationClient integration, and custom authentication
3. **Backward Compatibility**: Works with existing CallAutomationClient authentication infrastructure
4. **Flexibility**: Works for media streaming, transcription, and any WebSocket scenario
5. **Extensibility**: Easy to extend with custom authentication methods

## Migration from WebSocketConnectionHelper

If you were previously using `WebSocketConnectionHelper`, you can easily migrate:

```csharp
// Old approach
var helper = callAutomationClient.GetWebSocketConnectionHelper();
var webSocket = await helper.ConnectToAcsWebSocketAsync(streamUrl, cancellationToken);

// New approach (gives you more control)
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
var webSocket = new ClientWebSocket();

// You can now configure the WebSocket before connecting
webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
webSocket.Options.SetBuffer(4096, 4096);

await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl, cancellationToken);
await webSocket.ConnectAsync(streamUrl, cancellationToken);
```

The new approach gives you full control while still leveraging the same authentication infrastructure.
