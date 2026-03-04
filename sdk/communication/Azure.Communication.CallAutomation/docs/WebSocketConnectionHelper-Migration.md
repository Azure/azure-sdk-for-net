# Migration Guide: WebSocketConnectionHelper to AcsWebSocketAuthenticator

## Overview

In Azure Communication Services Call Automation 1.2.0-beta.1, we've replaced `WebSocketConnectionHelper` with `AcsWebSocketAuthenticator` to give you full control over WebSocket connections while we handle authentication complexity.

## What Changed

### Removed (Breaking Changes)
- ? `WebSocketConnectionHelper` class
- ? `CallAutomationClient.GetWebSocketConnectionHelper()`
- ? `ConnectToAcsMediaStreamingWebsocketAsync()`
- ? `ConnectToAcsTranscriptionWebsocketAsync()`
- ? All automatic connection management

### Added (New Features)  
- ? `AcsWebSocketAuthenticator` class
- ? `CallAutomationClient.GetWebSocketAuthenticator()`
- ? Multiple authentication methods (HMAC, AAD, Custom)
- ? WebSocket configuration helpers
- ? Full customer control over WebSocket lifecycle

## Migration Examples

### Media Streaming

#### Before (Removed)
```csharp
// This no longer works in 1.2.0-beta.1+
var helper = callAutomationClient.GetWebSocketConnectionHelper();
var webSocket = await helper.ConnectToAcsMediaStreamingWebsocketAsync(mediaStreamUrl);

// WebSocket was managed by ACS
while (webSocket.State == WebSocketState.Open)
{
    var buffer = new byte[1024];
    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
    ProcessAudioData(buffer, result.Count);
}
```

#### After (Current)
```csharp
// New approach with full control
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
var webSocket = new ClientWebSocket();

// YOU control WebSocket configuration
webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
webSocket.Options.SetBuffer(4096, 4096);

// ACS handles authentication
await authenticator.AuthenticateWebSocketAsync(webSocket, mediaStreamUrl);

// YOU control connection
await webSocket.ConnectAsync(mediaStreamUrl, cancellationToken);

// YOU control WebSocket operations
while (webSocket.State == WebSocketState.Open)
{
    var buffer = new byte[1024];
    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
    ProcessAudioData(buffer, result.Count);
}

// YOU control cleanup
await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", cancellationToken);
webSocket.Dispose();
```

### Transcription

#### Before (Removed)
```csharp
var helper = callAutomationClient.GetWebSocketConnectionHelper();
var webSocket = await helper.ConnectToAcsTranscriptionWebsocketAsync(transcriptionUrl);

// Handle transcription messages
```

#### After (Current)
```csharp
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
var webSocket = new ClientWebSocket();

// Configure for transcription (you have control)
authenticator.ConfigureWebSocketOptions(webSocket,
    keepAliveInterval: TimeSpan.FromSeconds(30),
    subProtocol: "transcription");

// Add custom headers if needed
authenticator.AddCustomHeader(webSocket, "X-App-Name", "TranscriptionApp");

// Authenticate and connect
await authenticator.AuthenticateWebSocketAsync(webSocket, transcriptionUrl);
await webSocket.ConnectAsync(transcriptionUrl, cancellationToken);

// Handle transcription messages (you have full control)
```

## Advanced Migration Patterns

### Custom WebSocket Configuration

#### Before (Limited Options)
```csharp
// Limited control over WebSocket settings
var helper = callAutomationClient.GetWebSocketConnectionHelper();
var webSocket = await helper.ConnectToAcsMediaStreamingWebsocketAsync(streamUrl);
```

#### After (Full Control)
```csharp
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
var webSocket = new ClientWebSocket();

// Full control over all WebSocket settings
webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(45);
webSocket.Options.SetBuffer(receiveBufferSize: 8192, sendBufferSize: 4096);
webSocket.Options.AddSubProtocol("my-custom-protocol");
webSocket.Options.SetRequestHeader("X-Custom-Header", "MyValue");

// Optional: Use helper for common configurations
authenticator.ConfigureWebSocketOptions(webSocket,
    keepAliveInterval: TimeSpan.FromSeconds(45),
    receiveBufferSize: 8192,
    sendBufferSize: 4096,
    subProtocol: "my-custom-protocol");

await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);
await webSocket.ConnectAsync(streamUrl, cancellationToken);
```

### Error Handling

#### Before (Limited Control)
```csharp
try
{
    var webSocket = await helper.ConnectToAcsMediaStreamingWebsocketAsync(streamUrl);
    // Use webSocket
}
catch (Exception ex)
{
    // Limited error handling options
}
```

#### After (Full Control)
```csharp
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
var webSocket = new ClientWebSocket();

try
{
    // Configure WebSocket
    webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);

    // Authenticate (may throw auth-related exceptions)
    await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);

    // Connect (may throw connection-related exceptions)  
    await webSocket.ConnectAsync(streamUrl, cancellationToken);

    // Use WebSocket with full control over error handling
    while (webSocket.State == WebSocketState.Open)
    {
        try
        {
            var buffer = new byte[1024];
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
            
            if (result.MessageType == WebSocketMessageType.Close)
            {
                break;
            }
            
            ProcessMessage(buffer, result);
        }
        catch (WebSocketException wsEx)
        {
            // Handle WebSocket-specific errors
            Console.WriteLine($"WebSocket error: {wsEx.Message}");
            break;
        }
    }
}
catch (AuthenticationException authEx)
{
    // Handle authentication errors
    Console.WriteLine($"Authentication failed: {authEx.Message}");
}
catch (WebSocketException wsEx)
{
    // Handle connection errors
    Console.WriteLine($"Connection failed: {wsEx.Message}");
}
finally
{
    // Clean up (you control this)
    if (webSocket.State == WebSocketState.Open)
    {
        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", cancellationToken);
    }
    webSocket.Dispose();
}
```

## Authentication Options

### Use CallAutomationClient Authentication (Recommended)
```csharp
// Leverages existing CallAutomationClient authentication
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
```

### Direct HMAC Authentication
```csharp
var keyCredential = new AzureKeyCredential("your-access-key");
var acsEndpoint = "https://your-resource.communication.azure.com";
var authenticator = new AcsWebSocketAuthenticator(keyCredential, acsEndpoint);
```

### Direct Azure AD Authentication
```csharp
var tokenCredential = new DefaultAzureCredential();
var acsEndpoint = "https://your-resource.communication.azure.com";  
var authenticator = new AcsWebSocketAuthenticator(tokenCredential, acsEndpoint);
```

### Custom Authentication
```csharp
public class MyCustomAuthenticator : AcsWebSocketAuthenticator
{
    protected override async Task AuthenticateCustomAsync(
        ClientWebSocket webSocket, 
        Uri streamUrl, 
        CancellationToken cancellationToken)
    {
        // Add your custom authentication headers
        webSocket.Options.SetRequestHeader("Authorization", $"Bearer {GetMyCustomToken()}");
        webSocket.Options.SetRequestHeader("X-Custom-Auth", "my-auth-value");
    }
}

var authenticator = new MyCustomAuthenticator();
```

## Benefits of Migration

### Before Migration (Limited)
- ? ACS controlled WebSocket lifecycle
- ? Limited configuration options
- ? Fixed connection patterns
- ? Limited error handling
- ? One-size-fits-all approach

### After Migration (Full Control)
- ? **Full WebSocket Control**: You configure, connect, and manage WebSocket
- ? **Authentication Handled**: ACS handles complex authentication
- ? **Multiple Auth Methods**: HMAC, AAD, or custom authentication
- ? **Flexible Configuration**: Optimize WebSocket for your use case
- ? **Better Error Handling**: Direct access to WebSocket errors
- ? **Performance Optimization**: Configure buffers, timeouts, protocols
- ? **Universal Support**: Same pattern for media, transcription, any WebSocket scenario

## Common Migration Issues

### Issue 1: Missing WebSocket Configuration
```csharp
// ? Might not work optimally
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);
await webSocket.ConnectAsync(streamUrl, cancellationToken);

// ? Better - configure for your needs
webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
webSocket.Options.SetBuffer(4096, 4096);
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);
await webSocket.ConnectAsync(streamUrl, cancellationToken);
```

### Issue 2: Not Handling WebSocket Cleanup
```csharp
// ? Resource leak
var webSocket = new ClientWebSocket();
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);
await webSocket.ConnectAsync(streamUrl, cancellationToken);
// Missing cleanup

// ? Proper cleanup
var webSocket = new ClientWebSocket();
try
{
    await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);
    await webSocket.ConnectAsync(streamUrl, cancellationToken);
    // Use webSocket
}
finally
{
    if (webSocket.State == WebSocketState.Open)
    {
        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", cancellationToken);
    }
    webSocket.Dispose();
}
```

### Issue 3: Not Leveraging New Flexibility
```csharp
// ? Not taking advantage of new capabilities
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
var webSocket = new ClientWebSocket();
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);
await webSocket.ConnectAsync(streamUrl, cancellationToken);

// ? Leverage new capabilities
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
var webSocket = new ClientWebSocket();

// Add application-specific headers
authenticator.AddCustomHeader(webSocket, "X-App-Name", "MyMediaApp");
authenticator.AddCustomHeader(webSocket, "X-Session-ID", sessionId);

// Optimize for your scenario
authenticator.ConfigureWebSocketOptions(webSocket,
    keepAliveInterval: TimeSpan.FromSeconds(30),
    receiveBufferSize: 8192, // Larger buffer for media
    subProtocol: "audio-stream");

await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);
await webSocket.ConnectAsync(streamUrl, cancellationToken);
```

## Testing Your Migration

### Unit Tests
```csharp
[Test]
public async Task WebSocket_Authentication_Works()
{
    var authenticator = new AcsWebSocketAuthenticator(mockCallAutomationClient);
    var webSocket = new ClientWebSocket();
    
    await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);
    
    // Verify headers were added (integration test would verify connection)
    Assert.AreEqual(WebSocketState.None, webSocket.State);
}
```

### Integration Tests  
```csharp
[Test]
public async Task WebSocket_Connection_Works_EndToEnd()
{
    var authenticator = callAutomationClient.GetWebSocketAuthenticator();
    var webSocket = new ClientWebSocket();
    
    await authenticator.AuthenticateWebSocketAsync(webSocket, realStreamUrl);
    await webSocket.ConnectAsync(realStreamUrl, cancellationToken);
    
    Assert.AreEqual(WebSocketState.Open, webSocket.State);
    
    // Test actual communication
    var buffer = new byte[1024];
    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
    Assert.IsTrue(result.Count > 0);
}
```

## Summary

The migration from `WebSocketConnectionHelper` to `AcsWebSocketAuthenticator` gives you:

1. **Complete Control**: You own the WebSocket lifecycle
2. **Better Performance**: Optimize configuration for your scenario  
3. **Enhanced Flexibility**: Support any WebSocket use case
4. **Improved Debugging**: Direct access to WebSocket state and errors
5. **Future-Proof**: Extensible design for new authentication methods

While the migration requires code changes, the new design provides significantly more power and flexibility for building robust real-time communication applications.
