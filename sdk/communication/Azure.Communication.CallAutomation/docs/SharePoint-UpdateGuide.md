# Key Updates for SharePoint Design Document

## Main Changes to Update in Your Design Doc

### 1. **Class Name Change**
- **Old**: `WebSocketConnectionHelper`
- **New**: `AcsWebSocketAuthenticator`

### 2. **Design Philosophy Update**
- **Old**: Helper manages WebSocket connections and authentication
- **New**: Authenticator ONLY handles authentication, customer controls WebSocket

### 3. **API Surface Changes**

#### Removed Methods
```csharp
// REMOVE these from design doc:
public async Task<ClientWebSocket> ConnectToAcsMediaStreamingWebsocketAsync(Uri transportUri, CancellationToken cancellationToken = default)
public ClientWebSocket ConnectToAcsMediaStreamingWebsocket(Uri transportUri, CancellationToken cancellationToken = default)
public async Task<ClientWebSocket> ConnectToAcsTranscriptionWebsocketAsync(Uri transportUri, CancellationToken cancellationToken = default)
public ClientWebSocket ConnectToAcsTranscriptionWebsocket(Uri transportUri, CancellationToken cancellationToken = default)
```

#### New API Surface
```csharp
// ADD these to design doc:
public class AcsWebSocketAuthenticator
{
    // Multiple constructor options
    public AcsWebSocketAuthenticator(AzureKeyCredential keyCredential, string acsEndpoint);
    public AcsWebSocketAuthenticator(TokenCredential tokenCredential, string acsEndpoint);
    public AcsWebSocketAuthenticator(CallAutomationClient callAutomationClient);
    public AcsWebSocketAuthenticator(); // For custom authentication

    // Main authentication method
    public async Task AuthenticateWebSocketAsync(ClientWebSocket webSocket, Uri streamUrl, CancellationToken cancellationToken = default);
    
    // Helper methods
    public void AddCustomHeader(ClientWebSocket webSocket, string headerName, string headerValue);
    public void ConfigureWebSocketOptions(ClientWebSocket webSocket, TimeSpan? keepAliveInterval = null, int? receiveBufferSize = null, int? sendBufferSize = null, string subProtocol = null);
    
    // Extensibility
    protected virtual Task AuthenticateCustomAsync(ClientWebSocket webSocket, Uri streamUrl, CancellationToken cancellationToken = default);
}

// Updated CallAutomationClient method
public virtual AcsWebSocketAuthenticator GetWebSocketAuthenticator(); // Changed from GetWebSocketConnectionHelper()
```

### 4. **Updated Usage Examples**

#### Replace Old Example
```csharp
// OLD - remove from design doc
var helper = callAutomationClient.GetWebSocketConnectionHelper();
var webSocket = await helper.ConnectToAcsMediaStreamingWebsocketAsync(transportUri);
```

#### With New Examples
```csharp
// NEW - add to design doc

// Method 1: CallAutomationClient Integration (Recommended)
var authenticator = callAutomationClient.GetWebSocketAuthenticator();
var webSocket = new ClientWebSocket();
webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);
await webSocket.ConnectAsync(streamUrl, cancellationToken);

// Method 2: Direct HMAC Authentication
var authenticator = new AcsWebSocketAuthenticator(keyCredential, acsEndpoint);
var webSocket = new ClientWebSocket();
await authenticator.AuthenticateWebSocketAsync(webSocket, streamUrl);
await webSocket.ConnectAsync(streamUrl, cancellationToken);

// Method 3: Custom Authentication
public class CustomAuthenticator : AcsWebSocketAuthenticator
{
    protected override async Task AuthenticateCustomAsync(ClientWebSocket webSocket, Uri streamUrl, CancellationToken cancellationToken)
    {
        webSocket.Options.SetRequestHeader("Custom-Auth", "MyToken");
    }
}
```

### 5. **Key Benefits to Emphasize**

Update your benefits section to highlight:

? **Customer Control**: Full control over WebSocket configuration and lifecycle  
? **Authentication Focus**: ACS only handles authentication, not connection management  
? **Flexible Integration**: Works with existing CallAutomationClient auth  
? **Universal Support**: Same authenticator for media streaming, transcription, any WebSocket scenario  
? **Header Safety**: Headers guaranteed to persist and be sent during connection  
? **Multi-Framework**: Works on .NET Standard 2.0, .NET 8/9/10, Framework 4.6.2+  

### 6. **Architecture Diagram Update**

Update your architecture diagram to show:
1. **Customer** creates and owns `ClientWebSocket`
2. **AcsWebSocketAuthenticator** only adds authentication headers to WebSocket.Options
3. **Customer** calls `webSocket.ConnectAsync()` with headers automatically included
4. **ACS Service** receives authenticated WebSocket connection

### 7. **Header Persistence Explanation**

Add this technical explanation:

> **How Headers Persist**: When `AuthenticateWebSocketAsync()` is called, authentication headers are stored in the `ClientWebSocket.Options.Headers` internal collection. These headers become part of the WebSocket's configuration state and are automatically sent by .NET Framework when `ConnectAsync()` is called. This guarantees headers are not lost and provides a clean separation between authentication (ACS responsibility) and WebSocket management (customer responsibility).

### 8. **Remove Connection-Specific Sections**

Remove any sections about:
- Media streaming vs transcription differences
- Connection management
- WebSocket lifecycle management (this is now customer responsibility)

### 9. **Add Extensibility Section**

Add information about custom authentication scenarios and how customers can extend the authenticator for their specific needs.

## Copy-Paste Ready Content

You can copy the content from the `AcsWebSocketAuthenticator-DesignUpdate.md` file I created above and paste it into your SharePoint document, replacing the existing WebSocketConnectionHelper design sections.
