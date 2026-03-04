# AcsWebSocketAuthenticator Design Documentation

## Overview

The `AcsWebSocketAuthenticator` is a new design that replaces the previous `WebSocketConnectionHelper` to provide customers with full control over WebSocket connections while Azure Communication Services handles authentication complexity.

## Design Goals

1. **Customer Control**: Give customers full control over WebSocket configuration, lifecycle, and management
2. **Authentication Focus**: ACS focuses solely on authentication, not connection management
3. **Flexibility**: Support multiple authentication methods and scenarios
4. **Extensibility**: Allow customers to implement custom authentication
5. **Compatibility**: Work across all supported .NET frameworks

## Architecture

### Before: WebSocketConnectionHelper (Removed)
```
CallAutomationClient ? WebSocketConnectionHelper ? ClientWebSocket (ACS Managed)
                                ?
                        ACS controls connection lifecycle
```

### After: AcsWebSocketAuthenticator (Current)
```
CallAutomationClient ? AcsWebSocketAuthenticator ? Headers ? Customer-Managed ClientWebSocket
                                ?
                        Customer controls connection lifecycle
```

## Key Changes

### Removed Components
- `WebSocketConnectionHelper` class
- `GetWebSocketConnectionHelper()` method from CallAutomationClient
- `ConnectToAcsMediaStreamingWebsocketAsync()` and related methods

### Added Components
- `AcsWebSocketAuthenticator` class
- `GetWebSocketAuthenticator()` method on CallAutomationClient
- Multiple authentication constructor options
- Helper methods for WebSocket configuration

## Authentication Methods

### 1. CallAutomationClient Integration (Recommended)
```csharp
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
// Uses existing CallAutomationClient authentication (HMAC or AAD)
```

### 2. Direct HMAC Authentication
```csharp
var authenticator = new AcsWebSocketAuthenticator(keyCredential, acsEndpoint);
// Direct HMAC signature authentication
```

### 3. Direct Azure AD Token Authentication
```csharp
var authenticator = new AcsWebSocketAuthenticator(tokenCredential, acsEndpoint);
// Direct Azure AD Bearer token authentication
```

### 4. Custom Authentication
```csharp
public class CustomAuthenticator : AcsWebSocketAuthenticator
{
    protected override async Task AuthenticateCustomAsync(...)
    {
        // Custom authentication logic
    }
}
```

## Header Persistence Mechanism

### How Authentication Headers Are Added
1. `AuthenticateWebSocketAsync()` calls `webSocket.Options.SetRequestHeader(name, value)`
2. Headers are stored in `ClientWebSocket.Options.Headers` internal collection
3. Headers become part of the WebSocket's configuration state
4. Headers persist until WebSocket is disposed

### How Headers Are Sent
1. Customer calls `webSocket.ConnectAsync(streamUrl)`
2. .NET Framework automatically reads ALL headers from `webSocket.Options.Headers`
3. .NET includes all stored headers in the HTTP WebSocket upgrade request
4. Server receives and validates authentication headers
5. WebSocket connection established with proper authentication

### Authentication Headers Added

#### HMAC Authentication
- `Authorization`: HMAC-SHA256 signature with signed headers
- `x-ms-date`: RFC 1123 timestamp
- `x-ms-content-sha256`: SHA256 hash of empty content
- `X-FORWARDED-HOST`: ACS endpoint
- `User-Agent`: Client version information

#### CallAutomationClient Integration
- Tries HMAC authentication first (using `GetCurrentHmacTokenDirectAsync()`)
- Falls back to AAD Bearer token (using `GetCurrentAadTokenDirectAsync()`)
- Preserves existing authentication configuration

## Usage Patterns

### Basic Media Streaming
```csharp
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
var webSocket = new ClientWebSocket();

// Customer configures WebSocket
webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
webSocket.Options.SetBuffer(4096, 4096);

// ACS adds authentication
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);

// Customer connects and uses
await webSocket.ConnectAsync(streamUrl, cancellationToken);

// Customer handles all WebSocket operations
while (webSocket.State == WebSocketState.Open)
{
    // Media streaming logic
}
```

### Advanced Configuration
```csharp
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
var webSocket = new ClientWebSocket();

// Configure WebSocket using helper
authenticator.ConfigureWebSocketOptions(webSocket,
    keepAliveInterval: TimeSpan.FromSeconds(30),
    receiveBufferSize: 8192,
    sendBufferSize: 4096,
    subProtocol: "audio-stream");

// Add custom application headers
authenticator.AddCustomHeader(webSocket, "X-App-Name", "MyApp");
authenticator.AddCustomHeader(webSocket, "X-Session-ID", sessionId);

// Authenticate
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);

// Connect
await webSocket.ConnectAsync(streamUrl, cancellationToken);
```

## Migration Guide

### Breaking Changes
- `WebSocketConnectionHelper` class removed
- `GetWebSocketConnectionHelper()` method removed
- Connection management methods removed

### Migration Steps
1. Replace `GetWebSocketConnectionHelper()` with `GetWebSocketAuthenticator()`
2. Create `ClientWebSocket` instance yourself
3. Configure WebSocket options as needed
4. Call `AuthenticateWebSocketAsync()` to add auth headers
5. Call `webSocket.ConnectAsync()` to establish connection
6. Handle WebSocket operations in your code

### Before (Removed)
```csharp
var helper = callAutomationClient.GetWebSocketConnectionHelper();
var webSocket = await helper.ConnectToAcsMediaStreamingWebsocketAsync(streamUrl);
// Use webSocket...
```

### After (Current)
```csharp
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
var webSocket = new ClientWebSocket();

// Configure as needed
webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);

// Authenticate
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);

// Connect
await webSocket.ConnectAsync(streamUrl, cancellationToken);

// Use webSocket...
```

## Benefits

### For Customers
- **Full Control**: Complete control over WebSocket configuration and lifecycle
- **Flexibility**: Use for any WebSocket scenario (media, transcription, custom)
- **Performance**: Optimize WebSocket settings for specific use cases
- **Debugging**: Direct access to WebSocket for troubleshooting
- **Integration**: Easy integration with existing WebSocket code

### For Azure Communication Services
- **Focused Responsibility**: Only handles authentication, not connection management
- **Reduced Complexity**: Simpler API surface focused on authentication
- **Better Testability**: Clear separation of concerns
- **Extensibility**: Easy to add new authentication methods

## Technical Implementation

### Multi-Framework Support
- .NET Standard 2.0: Base compatibility
- .NET Framework 4.6.2+: Full support
- .NET 8/9/10: Latest features and performance

### Security
- HMAC signatures with SHA256
- Azure AD Bearer token support
- Secure header handling
- No credential storage in authenticator

### Performance
- Minimal overhead - only adds headers
- No connection management overhead
- Customer-optimized WebSocket configuration
- Efficient authentication token reuse

## Future Enhancements

### Potential Additions
- Certificate-based authentication
- Custom signature algorithms
- Token refresh capabilities
- Connection retry helpers (optional)
- WebSocket connection pools (optional)

### Backward Compatibility
- New features will be additive
- Existing authentication methods will remain supported
- Migration guides for any breaking changes

## Testing Strategy

### Unit Tests
- Authentication header generation
- Multiple authentication methods
- Custom authentication scenarios
- WebSocket configuration helpers

### Integration Tests
- End-to-end WebSocket connections
- Media streaming scenarios
- Transcription scenarios
- Error handling and fallback

### Performance Tests
- Authentication overhead measurement
- Header persistence verification
- Memory usage analysis
- Connection establishment timing

## Summary

The `AcsWebSocketAuthenticator` design provides the optimal balance between customer control and Azure Communication Services expertise. Customers get full flexibility over WebSocket management while ACS handles the complex authentication requirements, resulting in a more powerful and flexible solution for real-time communication scenarios.
