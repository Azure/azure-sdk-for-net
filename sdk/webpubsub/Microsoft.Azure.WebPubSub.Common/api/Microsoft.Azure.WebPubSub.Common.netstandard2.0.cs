namespace Microsoft.Azure.WebPubSub.Common
{
    public sealed partial class ConnectedEventRequest : Microsoft.Azure.WebPubSub.Common.WebPubSubEventRequest
    {
        internal ConnectedEventRequest() : base (default(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext)) { }
    }
    public sealed partial class ConnectEventRequest : Microsoft.Azure.WebPubSub.Common.WebPubSubEventRequest
    {
        internal ConnectEventRequest() : base (default(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext)) { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("claims")]
        public System.Collections.ObjectModel.ReadOnlyDictionary<string, string[]> Claims { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("clientCertificates")]
        public System.Collections.Generic.IReadOnlyList<Microsoft.Azure.WebPubSub.Common.WebPubSubClientCertificate> ClientCertificates { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("query")]
        public System.Collections.ObjectModel.ReadOnlyDictionary<string, string[]> Query { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("subprotocols")]
        public System.Collections.Generic.IReadOnlyList<string> Subprotocols { get { throw null; } }
        public Microsoft.Azure.WebPubSub.Common.EventErrorResponse CreateErrorResponse(Microsoft.Azure.WebPubSub.Common.WebPubSubErrorCode code, string message) { throw null; }
        public Microsoft.Azure.WebPubSub.Common.ConnectEventResponse CreateResponse(string userId, System.Collections.Generic.IEnumerable<string> groups, string subprotocol, System.Collections.Generic.IEnumerable<string> roles) { throw null; }
    }
    public partial class ConnectEventResponse : Microsoft.Azure.WebPubSub.Common.WebPubSubEventResponse
    {
        public ConnectEventResponse() { }
        public ConnectEventResponse(string userId, System.Collections.Generic.IEnumerable<string> groups, string subprotocol, System.Collections.Generic.IEnumerable<string> roles) { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("groups")]
        public string[] Groups { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("roles")]
        public string[] Roles { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("subprotocol")]
        public string Subprotocol { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("userId")]
        public string UserId { get { throw null; } set { } }
        public void ClearStates() { }
        public void SetState(string key, object value) { }
    }
    public sealed partial class DisconnectedEventRequest : Microsoft.Azure.WebPubSub.Common.WebPubSubEventRequest
    {
        internal DisconnectedEventRequest() : base (default(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext)) { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("reason")]
        public string Reason { get { throw null; } }
    }
    public partial class EventErrorResponse : Microsoft.Azure.WebPubSub.Common.WebPubSubEventResponse
    {
        public EventErrorResponse() { }
        public EventErrorResponse(Microsoft.Azure.WebPubSub.Common.WebPubSubErrorCode code, string message = null) { }
        [System.Text.Json.Serialization.JsonConverterAttribute(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("code")]
        public Microsoft.Azure.WebPubSub.Common.WebPubSubErrorCode Code { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("errorMessage")]
        public string ErrorMessage { get { throw null; } set { } }
    }
    public enum MessageDataType
    {
        Binary = 0,
        Json = 1,
        Text = 2,
    }
    public sealed partial class UserEventRequest : Microsoft.Azure.WebPubSub.Common.WebPubSubEventRequest
    {
        internal UserEventRequest() : base (default(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext)) { }
        [System.Text.Json.Serialization.JsonConverterAttribute(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("dataType")]
        public Microsoft.Azure.WebPubSub.Common.MessageDataType DataType { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("message")]
        public System.BinaryData Message { get { throw null; } }
        public Microsoft.Azure.WebPubSub.Common.EventErrorResponse CreateErrorResponse(Microsoft.Azure.WebPubSub.Common.WebPubSubErrorCode code, string message) { throw null; }
        public Microsoft.Azure.WebPubSub.Common.UserEventResponse CreateResponse(System.BinaryData message, Microsoft.Azure.WebPubSub.Common.MessageDataType dataType) { throw null; }
        public Microsoft.Azure.WebPubSub.Common.UserEventResponse CreateResponse(string message, Microsoft.Azure.WebPubSub.Common.MessageDataType dataType = Microsoft.Azure.WebPubSub.Common.MessageDataType.Text) { throw null; }
    }
    public partial class UserEventResponse : Microsoft.Azure.WebPubSub.Common.WebPubSubEventResponse
    {
        public UserEventResponse() { }
        public UserEventResponse(System.BinaryData message, Microsoft.Azure.WebPubSub.Common.MessageDataType dataType) { }
        public UserEventResponse(string message, Microsoft.Azure.WebPubSub.Common.MessageDataType dataType = Microsoft.Azure.WebPubSub.Common.MessageDataType.Text) { }
        [System.Text.Json.Serialization.JsonConverterAttribute(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("dataType")]
        public Microsoft.Azure.WebPubSub.Common.MessageDataType DataType { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("message")]
        public System.BinaryData Message { get { throw null; } set { } }
        public void ClearStates() { }
        public void SetState(string key, object value) { }
    }
    public sealed partial class ValidationRequest : Microsoft.Azure.WebPubSub.Common.WebPubSubEventRequest
    {
        internal ValidationRequest() : base (default(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext)) { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("isValid")]
        public bool IsValid { get { throw null; } }
    }
    public sealed partial class WebPubSubClientCertificate
    {
        public WebPubSubClientCertificate(string thumbprint) { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("thumbprint")]
        public string Thumbprint { get { throw null; } }
    }
    public partial class WebPubSubConnectionContext
    {
        public WebPubSubConnectionContext() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("connectionId")]
        public string ConnectionId { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("eventName")]
        public string EventName { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("eventType")]
        public Microsoft.Azure.WebPubSub.Common.WebPubSubEventType EventType { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("headers")]
        public System.Collections.ObjectModel.ReadOnlyDictionary<string, string[]> Headers { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("hub")]
        public string Hub { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("origin")]
        public string Origin { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("signature")]
        public string Signature { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("states")]
        public System.Collections.ObjectModel.ReadOnlyDictionary<string, object> States { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("userId")]
        public string UserId { get { throw null; } }
    }
    public enum WebPubSubErrorCode
    {
        Unauthorized = 0,
        UserError = 1,
        ServerError = 2,
    }
    public abstract partial class WebPubSubEventRequest
    {
        protected WebPubSubEventRequest(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext context) { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("connectionContext")]
        public Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext ConnectionContext { get { throw null; } }
    }
    public abstract partial class WebPubSubEventResponse
    {
        protected WebPubSubEventResponse() { }
    }
    public enum WebPubSubEventType
    {
        System = 0,
        User = 1,
    }
}
