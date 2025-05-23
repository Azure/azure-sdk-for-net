namespace Microsoft.Azure.Functions.Worker
{
    public sealed partial class AddConnectionToGroupAction : Microsoft.Azure.Functions.Worker.WebPubSubAction
    {
        public AddConnectionToGroupAction() { }
        public string ConnectionId { get { throw null; } set { } }
        public string Group { get { throw null; } set { } }
    }
    public sealed partial class AddUserToGroupAction : Microsoft.Azure.Functions.Worker.WebPubSubAction
    {
        public AddUserToGroupAction() { }
        public string Group { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public sealed partial class CloseAllConnectionsAction : Microsoft.Azure.Functions.Worker.WebPubSubAction
    {
        public CloseAllConnectionsAction() { }
        public System.Collections.Generic.IList<string> Excluded { get { throw null; } set { } }
        public string Reason { get { throw null; } set { } }
    }
    public sealed partial class CloseClientConnectionAction : Microsoft.Azure.Functions.Worker.WebPubSubAction
    {
        public CloseClientConnectionAction() { }
        public string ConnectionId { get { throw null; } set { } }
        public string Reason { get { throw null; } set { } }
    }
    public sealed partial class CloseGroupConnectionsAction : Microsoft.Azure.Functions.Worker.WebPubSubAction
    {
        public CloseGroupConnectionsAction() { }
        public System.Collections.Generic.IList<string> Excluded { get { throw null; } set { } }
        public string Group { get { throw null; } set { } }
        public string Reason { get { throw null; } set { } }
    }
    public sealed partial class ConnectedEventRequest : Microsoft.Azure.Functions.Worker.WebPubSubEventRequest
    {
        public ConnectedEventRequest() { }
    }
    public sealed partial class ConnectEventRequest : Microsoft.Azure.Functions.Worker.WebPubSubEventRequest
    {
        public ConnectEventRequest() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("claims")]
        public System.Collections.Generic.IReadOnlyDictionary<string, string[]> Claims { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("clientCertificates")]
        public System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Functions.Worker.WebPubSubClientCertificate> ClientCertificates { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("headers")]
        public System.Collections.Generic.IReadOnlyDictionary<string, string[]> Headers { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("query")]
        public System.Collections.Generic.IReadOnlyDictionary<string, string[]> Query { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("subprotocols")]
        public System.Collections.Generic.IReadOnlyList<string> Subprotocols { get { throw null; } set { } }
        public static Microsoft.Azure.Functions.Worker.EventErrorResponse CreateErrorResponse(Microsoft.Azure.Functions.Worker.WebPubSubErrorCode code, string message) { throw null; }
        public static Microsoft.Azure.Functions.Worker.ConnectEventResponse CreateResponse(string userId, System.Collections.Generic.IEnumerable<string> groups, string subprotocol, System.Collections.Generic.IEnumerable<string> roles) { throw null; }
    }
    public partial class ConnectEventResponse : Microsoft.Azure.Functions.Worker.WebPubSubEventResponse
    {
        public ConnectEventResponse() { }
        public ConnectEventResponse(string userId, System.Collections.Generic.IEnumerable<string> groups, string subprotocol, System.Collections.Generic.IEnumerable<string> roles) { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("states")]
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> ConnectionStates { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("groups")]
        public string[] Groups { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("roles")]
        public string[] Roles { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("subprotocol")]
        public string Subprotocol { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("userId")]
        public string UserId { get { throw null; } set { } }
        public void ClearStates() { }
        public void SetState(string key, System.BinaryData value) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void SetState(string key, object value) { }
    }
    public sealed partial class DisconnectedEventRequest : Microsoft.Azure.Functions.Worker.WebPubSubEventRequest
    {
        public DisconnectedEventRequest() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("reason")]
        public string Reason { get { throw null; } set { } }
    }
    public partial class EventErrorResponse : Microsoft.Azure.Functions.Worker.WebPubSubEventResponse
    {
        public EventErrorResponse() { }
        public EventErrorResponse(Microsoft.Azure.Functions.Worker.WebPubSubErrorCode code, string message = null) { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("code")]
        public Microsoft.Azure.Functions.Worker.WebPubSubErrorCode Code { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("errorMessage")]
        public string ErrorMessage { get { throw null; } set { } }
    }
    public sealed partial class GrantPermissionAction : Microsoft.Azure.Functions.Worker.WebPubSubAction
    {
        public GrantPermissionAction() { }
        public string ConnectionId { get { throw null; } set { } }
        public Microsoft.Azure.Functions.Worker.WebPubSubPermission Permission { get { throw null; } set { } }
        public string TargetName { get { throw null; } set { } }
    }
    public sealed partial class PreflightRequest : Microsoft.Azure.Functions.Worker.WebPubSubEventRequest
    {
        public PreflightRequest() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("isValid")]
        public bool IsValid { get { throw null; } set { } }
    }
    public sealed partial class RemoveConnectionFromGroupAction : Microsoft.Azure.Functions.Worker.WebPubSubAction
    {
        public RemoveConnectionFromGroupAction() { }
        public string ConnectionId { get { throw null; } set { } }
        public string Group { get { throw null; } set { } }
    }
    public sealed partial class RemoveUserFromAllGroupsAction : Microsoft.Azure.Functions.Worker.WebPubSubAction
    {
        public RemoveUserFromAllGroupsAction() { }
        public string UserId { get { throw null; } set { } }
    }
    public sealed partial class RemoveUserFromGroupAction : Microsoft.Azure.Functions.Worker.WebPubSubAction
    {
        public RemoveUserFromGroupAction() { }
        public string Group { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public sealed partial class RevokePermissionAction : Microsoft.Azure.Functions.Worker.WebPubSubAction
    {
        public RevokePermissionAction() { }
        public string ConnectionId { get { throw null; } set { } }
        public Microsoft.Azure.Functions.Worker.WebPubSubPermission Permission { get { throw null; } set { } }
        public string TargetName { get { throw null; } set { } }
    }
    public sealed partial class SendToAllAction : Microsoft.Azure.Functions.Worker.WebPubSubAction
    {
        public SendToAllAction() { }
        public System.BinaryData Data { get { throw null; } set { } }
        public Microsoft.Azure.Functions.Worker.WebPubSubDataType DataType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Excluded { get { throw null; } set { } }
    }
    public partial class SendToConnectionAction : Microsoft.Azure.Functions.Worker.WebPubSubAction
    {
        public SendToConnectionAction() { }
        public string ConnectionId { get { throw null; } set { } }
        public System.BinaryData Data { get { throw null; } set { } }
        public Microsoft.Azure.Functions.Worker.WebPubSubDataType DataType { get { throw null; } set { } }
    }
    public partial class SendToGroupAction : Microsoft.Azure.Functions.Worker.WebPubSubAction
    {
        public SendToGroupAction() { }
        public System.BinaryData Data { get { throw null; } set { } }
        public Microsoft.Azure.Functions.Worker.WebPubSubDataType DataType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Excluded { get { throw null; } set { } }
        public string Group { get { throw null; } set { } }
    }
    public sealed partial class SendToUserAction : Microsoft.Azure.Functions.Worker.WebPubSubAction
    {
        public SendToUserAction() { }
        public System.BinaryData Data { get { throw null; } set { } }
        public Microsoft.Azure.Functions.Worker.WebPubSubDataType DataType { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public sealed partial class UserEventRequest : Microsoft.Azure.Functions.Worker.WebPubSubEventRequest
    {
        public UserEventRequest() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("data")]
        public System.BinaryData Data { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("dataType")]
        public Microsoft.Azure.Functions.Worker.WebPubSubDataType DataType { get { throw null; } set { } }
        public static Microsoft.Azure.Functions.Worker.EventErrorResponse CreateErrorResponse(Microsoft.Azure.Functions.Worker.WebPubSubErrorCode code, string message) { throw null; }
        public static Microsoft.Azure.Functions.Worker.UserEventResponse CreateResponse(System.BinaryData data, Microsoft.Azure.Functions.Worker.WebPubSubDataType dataType) { throw null; }
        public static Microsoft.Azure.Functions.Worker.UserEventResponse CreateResponse(string data, Microsoft.Azure.Functions.Worker.WebPubSubDataType dataType = Microsoft.Azure.Functions.Worker.WebPubSubDataType.Text) { throw null; }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class UserEventResponse : Microsoft.Azure.Functions.Worker.WebPubSubEventResponse
    {
        public UserEventResponse() { }
        public UserEventResponse(System.BinaryData data, Microsoft.Azure.Functions.Worker.WebPubSubDataType dataType) { }
        public UserEventResponse(string data, Microsoft.Azure.Functions.Worker.WebPubSubDataType dataType = Microsoft.Azure.Functions.Worker.WebPubSubDataType.Text) { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("states")]
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> ConnectionStates { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("data")]
        public System.BinaryData Data { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("dataType")]
        public Microsoft.Azure.Functions.Worker.WebPubSubDataType DataType { get { throw null; } set { } }
        public void ClearStates() { }
        public void SetState(string key, System.BinaryData value) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void SetState(string key, object value) { }
    }
    public abstract partial class WebPubSubAction
    {
        protected WebPubSubAction() { }
        public string ActionName { get { throw null; } }
    }
    public sealed partial class WebPubSubClientCertificate
    {
        public WebPubSubClientCertificate() { }
        public string Thumbprint { get { throw null; } set { } }
    }
    public sealed partial class WebPubSubConnection
    {
        public WebPubSubConnection() { }
        public string AccessToken { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("baseUrl")]
        public System.Uri BaseUri { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("url")]
        public System.Uri Uri { get { throw null; } set { } }
    }
    public sealed partial class WebPubSubConnectionContext
    {
        public WebPubSubConnectionContext() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("connectionId")]
        public string ConnectionId { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("states")]
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> ConnectionStates { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("eventName")]
        public string EventName { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("eventType")]
        public Microsoft.Azure.Functions.Worker.WebPubSubEventType EventType { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("headers")]
        public System.Collections.Generic.IReadOnlyDictionary<string, string[]> Headers { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("hub")]
        public string Hub { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("origin")]
        public string Origin { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("signature")]
        public string Signature { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("userId")]
        public string UserId { get { throw null; } set { } }
    }
    public sealed partial class WebPubSubConnectionInputAttribute : Microsoft.Azure.Functions.Worker.Extensions.Abstractions.InputBindingAttribute
    {
        public WebPubSubConnectionInputAttribute() { }
        public string Connection { get { throw null; } set { } }
        public string Hub { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public sealed partial class WebPubSubContext
    {
        public WebPubSubContext() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("errorMessage")]
        public string ErrorMessage { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("hasError")]
        public bool HasError { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("isPreflight")]
        public bool IsPreflight { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("request")]
        public Microsoft.Azure.Functions.Worker.WebPubSubEventRequest Request { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("response")]
        public Microsoft.Azure.Functions.Worker.WebPubSubSimpleResponse Response { get { throw null; } set { } }
    }
    public sealed partial class WebPubSubContextInputAttribute : Microsoft.Azure.Functions.Worker.Extensions.Abstractions.InputBindingAttribute
    {
        public WebPubSubContextInputAttribute() { }
        public WebPubSubContextInputAttribute(params string[] connections) { }
        public string[] Connections { get { throw null; } set { } }
    }
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
    public enum WebPubSubDataType
    {
        Binary = 0,
        Json = 1,
        Text = 2,
    }
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
    public enum WebPubSubErrorCode
    {
        Unauthorized = 0,
        UserError = 1,
        ServerError = 2,
    }
    public abstract partial class WebPubSubEventRequest
    {
        protected WebPubSubEventRequest() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("connectionContext")]
        public Microsoft.Azure.Functions.Worker.WebPubSubConnectionContext ConnectionContext { get { throw null; } set { } }
    }
    public abstract partial class WebPubSubEventResponse
    {
        protected WebPubSubEventResponse() { }
    }
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
    public enum WebPubSubEventType
    {
        System = 0,
        User = 1,
    }
    public sealed partial class WebPubSubOutputAttribute : Microsoft.Azure.Functions.Worker.Extensions.Abstractions.OutputBindingAttribute
    {
        public WebPubSubOutputAttribute() { }
        public string Connection { get { throw null; } set { } }
        public string Hub { get { throw null; } set { } }
    }
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
    public enum WebPubSubPermission
    {
        SendToGroup = 1,
        JoinLeaveGroup = 2,
    }
    public sealed partial class WebPubSubSimpleResponse
    {
        public WebPubSubSimpleResponse() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("body")]
        public string Body { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("headers")]
        public System.Collections.Generic.Dictionary<string, string[]> Headers { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("status")]
        public int Status { get { throw null; } set { } }
    }
    public sealed partial class WebPubSubTriggerAttribute : Microsoft.Azure.Functions.Worker.Extensions.Abstractions.TriggerBindingAttribute
    {
        public WebPubSubTriggerAttribute(Microsoft.Azure.Functions.Worker.WebPubSubEventType eventType, string eventName) { }
        public WebPubSubTriggerAttribute(Microsoft.Azure.Functions.Worker.WebPubSubEventType eventType, string eventName, params string[] connections) { }
        public WebPubSubTriggerAttribute(string hub, Microsoft.Azure.Functions.Worker.WebPubSubEventType eventType, string eventName) { }
        public WebPubSubTriggerAttribute(string hub, Microsoft.Azure.Functions.Worker.WebPubSubEventType eventType, string eventName, params string[] connections) { }
        public string[] Connections { get { throw null; } }
        public string EventName { get { throw null; } }
        public Microsoft.Azure.Functions.Worker.WebPubSubEventType EventType { get { throw null; } }
        public string Hub { get { throw null; } }
    }
}
