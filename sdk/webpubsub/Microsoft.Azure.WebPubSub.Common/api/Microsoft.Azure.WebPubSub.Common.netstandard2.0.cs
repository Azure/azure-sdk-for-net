namespace Microsoft.Azure.WebPubSub.Common
{
    public partial class ConnectedEventRequest : Microsoft.Azure.WebPubSub.Common.WebPubSubEventRequest
    {
        public ConnectedEventRequest(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext context) : base (default(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext)) { }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class ConnectEventRequest : Microsoft.Azure.WebPubSub.Common.WebPubSubEventRequest
    {
        public ConnectEventRequest(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext context, System.Collections.Generic.IReadOnlyDictionary<string, string[]> claims, System.Collections.Generic.IReadOnlyDictionary<string, string[]> query, System.Collections.Generic.IEnumerable<string> subprotocols, System.Collections.Generic.IEnumerable<Microsoft.Azure.WebPubSub.Common.WebPubSubClientCertificate> certificates) : base (default(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext)) { }
        public ConnectEventRequest(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext context, System.Collections.Generic.IReadOnlyDictionary<string, string[]> claims, System.Collections.Generic.IReadOnlyDictionary<string, string[]> query, System.Collections.Generic.IEnumerable<string> subprotocols, System.Collections.Generic.IEnumerable<Microsoft.Azure.WebPubSub.Common.WebPubSubClientCertificate> certificates, System.Collections.Generic.IReadOnlyDictionary<string, string[]> headers) : base (default(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext)) { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="claims")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("claims")]
        public System.Collections.Generic.IReadOnlyDictionary<string, string[]> Claims { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="clientCertificates")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("clientCertificates")]
        public System.Collections.Generic.IReadOnlyList<Microsoft.Azure.WebPubSub.Common.WebPubSubClientCertificate> ClientCertificates { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="headers")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("headers")]
        public System.Collections.Generic.IReadOnlyDictionary<string, string[]> Headers { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="query")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("query")]
        public System.Collections.Generic.IReadOnlyDictionary<string, string[]> Query { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="subprotocols")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("subprotocols")]
        public System.Collections.Generic.IReadOnlyList<string> Subprotocols { get { throw null; } }
        public virtual Microsoft.Azure.WebPubSub.Common.EventErrorResponse CreateErrorResponse(Microsoft.Azure.WebPubSub.Common.WebPubSubErrorCode code, string message) { throw null; }
        public Microsoft.Azure.WebPubSub.Common.ConnectEventResponse CreateResponse(string userId, System.Collections.Generic.IEnumerable<string> groups, string subprotocol, System.Collections.Generic.IEnumerable<string> roles) { throw null; }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class ConnectEventResponse : Microsoft.Azure.WebPubSub.Common.WebPubSubEventResponse
    {
        public ConnectEventResponse() { }
        public ConnectEventResponse(string userId, System.Collections.Generic.IEnumerable<string> groups, string subprotocol, System.Collections.Generic.IEnumerable<string> roles) { }
        [System.Runtime.Serialization.IgnoreDataMemberAttribute]
        [System.Text.Json.Serialization.JsonIgnoreAttribute]
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> ConnectionStates { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="groups")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("groups")]
        public string[] Groups { get { throw null; } set { } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="roles")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("roles")]
        public string[] Roles { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.Serialization.IgnoreDataMemberAttribute]
        [System.Text.Json.Serialization.JsonIgnoreAttribute]
        public System.Collections.Generic.IReadOnlyDictionary<string, object> States { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="subprotocol")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("subprotocol")]
        public string Subprotocol { get { throw null; } set { } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="userId")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("userId")]
        public string UserId { get { throw null; } set { } }
        public void ClearStates() { }
        public void SetState(string key, System.BinaryData value) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void SetState(string key, object value) { }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class DisconnectedEventRequest : Microsoft.Azure.WebPubSub.Common.WebPubSubEventRequest
    {
        public DisconnectedEventRequest(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext context, string reason) : base (default(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext)) { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="reason")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("reason")]
        public string Reason { get { throw null; } }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class EventErrorResponse : Microsoft.Azure.WebPubSub.Common.WebPubSubEventResponse
    {
        public EventErrorResponse() { }
        public EventErrorResponse(Microsoft.Azure.WebPubSub.Common.WebPubSubErrorCode code, string message = null) { }
        [System.Runtime.Serialization.IgnoreDataMemberAttribute]
        [System.Text.Json.Serialization.JsonIgnoreAttribute]
        public Microsoft.Azure.WebPubSub.Common.WebPubSubErrorCode Code { get { throw null; } set { } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="errorMessage")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("errorMessage")]
        public string ErrorMessage { get { throw null; } set { } }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class MqttConnectEventErrorResponse : Microsoft.Azure.WebPubSub.Common.EventErrorResponse
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public MqttConnectEventErrorResponse(Microsoft.Azure.WebPubSub.Common.MqttConnectEventErrorResponseProperties mqtt) { }
        public MqttConnectEventErrorResponse(Microsoft.Azure.WebPubSub.Common.MqttV311ConnectReturnCode code, string? reason) { }
        public MqttConnectEventErrorResponse(Microsoft.Azure.WebPubSub.Common.MqttV500ConnectReasonCode code, string? reason) { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="mqtt")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("mqtt")]
        public Microsoft.Azure.WebPubSub.Common.MqttConnectEventErrorResponseProperties Mqtt { get { throw null; } }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class MqttConnectEventErrorResponseProperties
    {
        public MqttConnectEventErrorResponseProperties(Microsoft.Azure.WebPubSub.Common.MqttV311ConnectReturnCode code) { }
        public MqttConnectEventErrorResponseProperties(Microsoft.Azure.WebPubSub.Common.MqttV500ConnectReasonCode code) { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="code")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("code")]
        public int Code { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="reason")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("reason")]
        public string? Reason { get { throw null; } set { } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="userProperties")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("userProperties")]
        public System.Collections.Generic.IReadOnlyList<Microsoft.Azure.WebPubSub.Common.MqttUserProperty>? UserProperties { get { throw null; } set { } }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class MqttConnectEventRequest : Microsoft.Azure.WebPubSub.Common.ConnectEventRequest
    {
        public MqttConnectEventRequest(Microsoft.Azure.WebPubSub.Common.MqttConnectionContext context, System.Collections.Generic.IReadOnlyDictionary<string, string[]> claims, System.Collections.Generic.IReadOnlyDictionary<string, string[]> query, System.Collections.Generic.IEnumerable<Microsoft.Azure.WebPubSub.Common.WebPubSubClientCertificate> certificates, System.Collections.Generic.IReadOnlyDictionary<string, string[]> headers, Microsoft.Azure.WebPubSub.Common.MqttConnectProperties mqtt) : base (default(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext), default(System.Collections.Generic.IReadOnlyDictionary<string, string[]>), default(System.Collections.Generic.IReadOnlyDictionary<string, string[]>), default(System.Collections.Generic.IEnumerable<string>), default(System.Collections.Generic.IEnumerable<Microsoft.Azure.WebPubSub.Common.WebPubSubClientCertificate>)) { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="mqtt")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("mqtt")]
        public Microsoft.Azure.WebPubSub.Common.MqttConnectProperties Mqtt { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Microsoft.Azure.WebPubSub.Common.EventErrorResponse CreateErrorResponse(Microsoft.Azure.WebPubSub.Common.WebPubSubErrorCode code, string? message = null) { throw null; }
        public Microsoft.Azure.WebPubSub.Common.MqttConnectEventResponse CreateMqttResponse(string userId, System.Collections.Generic.IEnumerable<string> groups, System.Collections.Generic.IEnumerable<string> roles) { throw null; }
        public Microsoft.Azure.WebPubSub.Common.MqttConnectEventErrorResponse CreateMqttV311ErrorResponse(Microsoft.Azure.WebPubSub.Common.MqttV311ConnectReturnCode code, string? message = null) { throw null; }
        public Microsoft.Azure.WebPubSub.Common.MqttConnectEventErrorResponse CreateMqttV50ErrorResponse(Microsoft.Azure.WebPubSub.Common.MqttV500ConnectReasonCode code, string? message = null) { throw null; }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public sealed partial class MqttConnectEventResponse : Microsoft.Azure.WebPubSub.Common.ConnectEventResponse
    {
        public MqttConnectEventResponse() { }
        public MqttConnectEventResponse(string? userId, System.Collections.Generic.IEnumerable<string>? groups, System.Collections.Generic.IEnumerable<string>? roles) { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="mqtt")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("mqtt")]
        public Microsoft.Azure.WebPubSub.Common.MqttConnectEventResponseProperties? Mqtt { get { throw null; } set { } }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class MqttConnectEventResponseProperties
    {
        public MqttConnectEventResponseProperties() { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="userProperties")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("userProperties")]
        public System.Collections.Generic.IReadOnlyList<Microsoft.Azure.WebPubSub.Common.MqttUserProperty>? UserProperties { get { throw null; } set { } }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class MqttConnectionContext : Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext
    {
        public MqttConnectionContext(Microsoft.Azure.WebPubSub.Common.WebPubSubEventType eventType, string eventName, string hub, string connectionId, string physicalConnectionId, string? sessionId, string? userId = null, string? signature = null, string? origin = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData>? connectionStates = null, System.Collections.Generic.IReadOnlyDictionary<string, string[]>? headers = null) : base (default(Microsoft.Azure.WebPubSub.Common.WebPubSubEventType), default(string), default(string), default(string), default(string), default(string), default(string), default(System.Collections.Generic.IReadOnlyDictionary<string, object>), default(System.Collections.Generic.IReadOnlyDictionary<string, string[]>)) { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="physicalConnectionId")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("physicalConnectionId")]
        public string PhysicalConnectionId { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="sessionId")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("sessionId")]
        public string? SessionId { get { throw null; } }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class MqttConnectProperties
    {
        internal MqttConnectProperties() { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="password")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("password")]
        public string? Password { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="protocolVersion")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("protocolVersion")]
        public Microsoft.Azure.WebPubSub.Common.MqttProtocolVersion ProtocolVersion { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="username")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("username")]
        public string? Username { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="userProperties")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("userProperties")]
        public System.Collections.Generic.IReadOnlyList<Microsoft.Azure.WebPubSub.Common.MqttUserProperty>? UserProperties { get { throw null; } }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class MqttDisconnectedEventRequest : Microsoft.Azure.WebPubSub.Common.DisconnectedEventRequest
    {
        public MqttDisconnectedEventRequest(Microsoft.Azure.WebPubSub.Common.MqttConnectionContext context, string reason, Microsoft.Azure.WebPubSub.Common.MqttDisconnectedEventRequestProperties mqtt) : base (default(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext), default(string)) { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="mqtt")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("mqtt")]
        public Microsoft.Azure.WebPubSub.Common.MqttDisconnectedEventRequestProperties Mqtt { get { throw null; } }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class MqttDisconnectedEventRequestProperties
    {
        internal MqttDisconnectedEventRequestProperties() { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="disconnectPacket")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("disconnectPacket")]
        public Microsoft.Azure.WebPubSub.Common.MqttDisconnectPacketProperties? DisconnectPacket { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="initiatedByClient")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("initiatedByClient")]
        public bool InitiatedByClient { get { throw null; } }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class MqttDisconnectPacketProperties
    {
        internal MqttDisconnectPacketProperties() { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="code")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("code")]
        public Microsoft.Azure.WebPubSub.Common.MqttDisconnectReasonCode Code { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="userProperties")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("userProperties")]
        public System.Collections.Generic.IReadOnlyList<Microsoft.Azure.WebPubSub.Common.MqttUserProperty>? UserProperties { get { throw null; } }
    }
    public enum MqttDisconnectReasonCode : byte
    {
        NormalDisconnection = (byte)0,
        DisconnectWithWillMessage = (byte)4,
        UnspecifiedError = (byte)128,
        MalformedPacket = (byte)129,
        ProtocolError = (byte)130,
        ImplementationSpecificError = (byte)131,
        NotAuthorized = (byte)135,
        ServerBusy = (byte)137,
        ServerShuttingDown = (byte)139,
        KeepAliveTimeout = (byte)141,
        SessionTakenOver = (byte)142,
        TopicFilterInvalid = (byte)143,
        TopicNameInvalid = (byte)144,
        ReceiveMaximumExceeded = (byte)147,
        TopicAliasInvalid = (byte)148,
        PacketTooLarge = (byte)149,
        MessageRateTooHigh = (byte)150,
        QuotaExceeded = (byte)151,
        AdministrativeAction = (byte)152,
        PayloadFormatInvalid = (byte)153,
        RetainNotSupported = (byte)154,
        QosNotSupported = (byte)155,
        UseAnotherServer = (byte)156,
        ServerMoved = (byte)157,
        SharedSubscriptionsNotSupported = (byte)158,
        ConnectionRateExceeded = (byte)159,
        MaximumConnectTime = (byte)160,
        SubscriptionIdentifiersNotSupported = (byte)161,
        WildcardSubscriptionsNotSupported = (byte)162,
    }
    public enum MqttProtocolVersion
    {
        V311 = 4,
        V500 = 5,
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class MqttUserProperty : System.IEquatable<Microsoft.Azure.WebPubSub.Common.MqttUserProperty>
    {
        protected MqttUserProperty(Microsoft.Azure.WebPubSub.Common.MqttUserProperty original) { }
        public MqttUserProperty(string name, string value) { }
        protected virtual System.Type EqualityContract { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="name")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("name")]
        public string Name { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="value")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("value")]
        public string Value { get { throw null; } }
        public virtual bool Equals(Microsoft.Azure.WebPubSub.Common.MqttUserProperty? other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Microsoft.Azure.WebPubSub.Common.MqttUserProperty? left, Microsoft.Azure.WebPubSub.Common.MqttUserProperty? right) { throw null; }
        public static bool operator !=(Microsoft.Azure.WebPubSub.Common.MqttUserProperty? left, Microsoft.Azure.WebPubSub.Common.MqttUserProperty? right) { throw null; }
        protected virtual bool PrintMembers(System.Text.StringBuilder builder) { throw null; }
        public override string ToString() { throw null; }
        public virtual Microsoft.Azure.WebPubSub.Common.MqttUserProperty <Clone>$() { throw null; }
    }
    public enum MqttV311ConnectReturnCode : byte
    {
        UnacceptableProtocolVersion = (byte)1,
        IdentifierRejected = (byte)2,
        ServerUnavailable = (byte)3,
        BadUsernameOrPassword = (byte)4,
        NotAuthorized = (byte)5,
    }
    public enum MqttV500ConnectReasonCode : byte
    {
        UnspecifiedError = (byte)128,
        MalformedPacket = (byte)129,
        ProtocolError = (byte)130,
        ImplementationSpecificError = (byte)131,
        UnsupportedProtocolVersion = (byte)132,
        ClientIdentifierNotValid = (byte)133,
        BadUserNameOrPassword = (byte)134,
        NotAuthorized = (byte)135,
        ServerUnavailable = (byte)136,
        ServerBusy = (byte)137,
        Banned = (byte)138,
        BadAuthenticationMethod = (byte)140,
        TopicNameInvalid = (byte)144,
        PacketTooLarge = (byte)149,
        QuotaExceeded = (byte)151,
        PayloadFormatInvalid = (byte)153,
        RetainNotSupported = (byte)154,
        QosNotSupported = (byte)155,
        UseAnotherServer = (byte)156,
        ServerMoved = (byte)157,
        ConnectionRateExceeded = (byte)159,
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public sealed partial class PreflightRequest : Microsoft.Azure.WebPubSub.Common.WebPubSubEventRequest
    {
        public PreflightRequest(bool isValid) : base (default(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext)) { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="isValid")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("isValid")]
        public bool IsValid { get { throw null; } }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public sealed partial class UserEventRequest : Microsoft.Azure.WebPubSub.Common.WebPubSubEventRequest
    {
        public UserEventRequest(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext context, System.BinaryData data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType) : base (default(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext)) { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="data")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("data")]
        public System.BinaryData Data { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="dataType")]
        [System.Text.Json.Serialization.JsonConverterAttribute(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("dataType")]
        public Microsoft.Azure.WebPubSub.Common.WebPubSubDataType DataType { get { throw null; } }
        public Microsoft.Azure.WebPubSub.Common.EventErrorResponse CreateErrorResponse(Microsoft.Azure.WebPubSub.Common.WebPubSubErrorCode code, string message) { throw null; }
        public Microsoft.Azure.WebPubSub.Common.UserEventResponse CreateResponse(System.BinaryData data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType) { throw null; }
        public Microsoft.Azure.WebPubSub.Common.UserEventResponse CreateResponse(string data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType = Microsoft.Azure.WebPubSub.Common.WebPubSubDataType.Text) { throw null; }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class UserEventResponse : Microsoft.Azure.WebPubSub.Common.WebPubSubEventResponse
    {
        public UserEventResponse() { }
        public UserEventResponse(System.BinaryData data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType) { }
        public UserEventResponse(string data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType = Microsoft.Azure.WebPubSub.Common.WebPubSubDataType.Text) { }
        [System.Runtime.Serialization.IgnoreDataMemberAttribute]
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> ConnectionStates { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="data")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("data")]
        public System.BinaryData Data { get { throw null; } set { } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="dataType")]
        [System.Text.Json.Serialization.JsonConverterAttribute(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("dataType")]
        public Microsoft.Azure.WebPubSub.Common.WebPubSubDataType DataType { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.Serialization.IgnoreDataMemberAttribute]
        public System.Collections.Generic.IReadOnlyDictionary<string, object> States { get { throw null; } }
        public void ClearStates() { }
        public void SetState(string key, System.BinaryData value) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void SetState(string key, object value) { }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public sealed partial class WebPubSubClientCertificate
    {
        public WebPubSubClientCertificate(string thumbprint) { }
        public WebPubSubClientCertificate(string thumbprint, string? content) { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="content")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("content")]
        public string? Content { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("thumbprint")]
        public string Thumbprint { get { throw null; } }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class WebPubSubConnectionContext
    {
        public WebPubSubConnectionContext(Microsoft.Azure.WebPubSub.Common.WebPubSubEventType eventType, string eventName, string hub, string connectionId, string userId = null, string signature = null, string origin = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> connectionStates = null, System.Collections.Generic.IReadOnlyDictionary<string, string[]> headers = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public WebPubSubConnectionContext(Microsoft.Azure.WebPubSub.Common.WebPubSubEventType eventType, string eventName, string hub, string connectionId, string userId, string signature, string origin, System.Collections.Generic.IReadOnlyDictionary<string, object> states, System.Collections.Generic.IReadOnlyDictionary<string, string[]> headers) { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="connectionId")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("connectionId")]
        public string ConnectionId { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="states")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("states")]
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> ConnectionStates { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="eventName")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("eventName")]
        public string EventName { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="eventType")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("eventType")]
        public Microsoft.Azure.WebPubSub.Common.WebPubSubEventType EventType { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="headers")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("headers")]
        public System.Collections.Generic.IReadOnlyDictionary<string, string[]> Headers { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="hub")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("hub")]
        public string Hub { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="origin")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("origin")]
        public string Origin { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="signature")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("signature")]
        public string Signature { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.Serialization.IgnoreDataMemberAttribute]
        [System.Text.Json.Serialization.JsonIgnoreAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("states")]
        public System.Collections.Generic.IReadOnlyDictionary<string, object> States { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="userId")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("userId")]
        public string UserId { get { throw null; } }
    }
    public enum WebPubSubDataType
    {
        Binary = 0,
        Json = 1,
        Text = 2,
    }
    public enum WebPubSubErrorCode
    {
        Unauthorized = 0,
        UserError = 1,
        ServerError = 2,
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public abstract partial class WebPubSubEventRequest
    {
        protected WebPubSubEventRequest(Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext context) { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="connectionContext")]
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
