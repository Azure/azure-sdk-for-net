## AcsWebSocketAuthenticator - Header Value Demonstration

This document demonstrates how the `AcsWebSocketAuthenticator` adds authentication headers to WebSocket connections and how these values persist through the connection process.

### Key Concept: Headers Are Stored in WebSocket.Options

When you call `authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl)`, the authentication headers are **permanently stored** in the `webSocket.Options` internal collection. These headers will be **automatically sent** when you call `webSocket.ConnectAsync()`.

### Example Usage and Header Flow

```csharp
// Step 1: Create authenticator and WebSocket
var keyCredential = new AzureKeyCredential("base64-encoded-key");
var acsEndpoint = "https://your-acs.communication.azure.com";
var authenticator = new AcsWebSocketAuthenticator(keyCredential, acsEndpoint);
var webSocket = new ClientWebSocket();
var streamUrl = new Uri("wss://your-acs.communication.azure.com/stream");

// Step 2: Configure WebSocket options (optional)
webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
webSocket.Options.SetBuffer(4096, 4096);

// Step 3: Add custom headers (optional)
authenticator.AddCustomHeader(webSocket, "X-App-Name", "MyMediaApp");
authenticator.AddCustomHeader(webSocket, "X-Session-ID", "session-123");

// Step 4: Add authentication headers
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);
```

### What Headers Are Added

After calling `AuthenticateWebSocketAsync()`, the following headers are stored in `webSocket.Options`:

#### HMAC Authentication Headers:
- **Authorization**: `HMAC-SHA256 SignedHeaders=x-ms-date;host;x-ms-content-sha256&Signature=[calculated-signature]`
- **x-ms-date**: Current UTC timestamp in RFC 1123 format
- **x-ms-content-sha256**: SHA256 hash of empty content (for WebSocket)
- **X-FORWARDED-HOST**: Your ACS endpoint URL
- **User-Agent**: Azure Communication CallAutomation client version

#### Example Header Values:
```
Authorization: HMAC-SHA256 SignedHeaders=x-ms-date;host;x-ms-content-sha256&Signature=abcd1234efgh5678...
x-ms-date: Mon, 15 Jan 2024 10:30:45 GMT
x-ms-content-sha256: 47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=
X-FORWARDED-HOST: https://your-acs.communication.azure.com
User-Agent: Azure-Communication-CallAutomation/1.3.0
X-App-Name: MyMediaApp
X-Session-ID: session-123
```

### Header Persistence Guarantee

#### ? Headers Are Guaranteed to Persist Because:
1. **Stored in WebSocket Instance**: Headers are saved in `webSocket.Options.Headers` (internal collection)
2. **Part of WebSocket State**: The headers become part of the WebSocket's configuration
3. **.NET Framework Guarantee**: When `ConnectAsync()` is called, .NET automatically includes ALL headers
4. **No Reference Parameters**: Headers are stored by value, not by reference

#### ? Connection Process:
```csharp
// Headers are now stored in webSocket.Options
await webSocket.ConnectAsync(streamUrl, cancellationToken);

// What happens internally:
// 1. .NET reads ALL headers from webSocket.Options.Headers
// 2. .NET creates HTTP WebSocket upgrade request
// 3. .NET adds ALL stored headers to the HTTP request
// 4. Server receives and validates authentication headers
// 5. WebSocket connection established (authenticated!)
```

### Verification: Headers Are There

While you can't directly access the headers collection in all .NET versions, you can verify the authentication works by:

1. **Successful Connection**: If `ConnectAsync()` succeeds, headers were sent correctly
2. **Server Authentication**: Server accepts the connection = authentication headers were valid
3. **No Exceptions**: No authentication exceptions = headers were properly formatted and sent

### Complete Working Example

```csharp
public async Task ConnectAuthenticatedWebSocket()
{
    // Setup
    var callAutomationClient = new CallAutomationClient(connectionString);
    var authenticator = callAutomationClient.GetWebSocketAuthenticator();
    var webSocket = new ClientWebSocket();
    var streamUrl = new Uri("wss://your-acs.communication.azure.com/stream");

    try
    {
        // Configure WebSocket
        webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
        
        // Add custom headers
        authenticator.AddCustomHeader(webSocket, "X-App-Name", "MyApp");
        
        // Add authentication headers (stored in webSocket.Options)
        await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);
        
        // Connect (all headers sent automatically)
        await webSocket.ConnectAsync(streamUrl, cancellationToken);
        
        // Success! WebSocket is now authenticated and ready for use
        Console.WriteLine($"Connected! State: {webSocket.State}");
        
        // Use WebSocket for media streaming, transcription, etc.
        while (webSocket.State == WebSocketState.Open)
        {
            var buffer = new byte[1024];
            var result = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), cancellationToken);
            
            // Process received data...
        }
    }
    finally
    {
        if (webSocket.State == WebSocketState.Open)
        {
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, 
                "", cancellationToken);
        }
        webSocket.Dispose();
    }
}
```

### Benefits of This Design

? **Customer Control**: Full control over WebSocket configuration and lifecycle  
? **Header Safety**: Headers guaranteed to be sent - no reference issues  
? **Flexibility**: Works for media streaming, transcription, any WebSocket scenario  
? **Authentication Integration**: Leverages existing CallAutomationClient auth  
? **Multi-Framework**: Works on .NET Standard 2.0, .NET 8, .NET 9, .NET 10  

### Summary

The `AcsWebSocketAuthenticator` safely adds authentication headers to your WebSocket by storing them in the `webSocket.Options` internal collection. These headers persist until the WebSocket is disposed and are automatically sent during connection. You maintain full control over the WebSocket while ACS handles the authentication complexity.
