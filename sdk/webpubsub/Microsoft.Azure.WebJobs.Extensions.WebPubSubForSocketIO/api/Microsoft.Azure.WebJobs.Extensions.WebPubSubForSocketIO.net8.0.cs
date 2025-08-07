namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class AddSocketToRoomAction : Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.SocketIOAction
    {
        public AddSocketToRoomAction() { }
        public string Room { get { throw null; } set { } }
        public string SocketId { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class DisconnectSocketsAction : Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.SocketIOAction
    {
        public DisconnectSocketsAction() { }
        public bool CloseUnderlyingConnection { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rooms { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class RemoveSocketFromRoomAction : Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.SocketIOAction
    {
        public RemoveSocketFromRoomAction() { }
        public string Room { get { throw null; } set { } }
        public string SocketId { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToNamespaceAction : Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.SocketIOAction
    {
        public SendToNamespaceAction() { }
        public string EventName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExceptRooms { get { throw null; } set { } }
        public System.Collections.Generic.IList<object> Parameters { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToRoomsAction : Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.SocketIOAction
    {
        public SendToRoomsAction() { }
        public string EventName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExceptRooms { get { throw null; } set { } }
        public System.Collections.Generic.IList<object> Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Rooms { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToSocketAction : Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.SocketIOAction
    {
        public SendToSocketAction() { }
        public string EventName { get { throw null; } set { } }
        public System.Collections.Generic.IList<object> Parameters { get { throw null; } set { } }
        public string SocketId { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public abstract partial class SocketIOAction
    {
        protected SocketIOAction() { }
        public string Namespace { get { throw null; } set { } }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.AddSocketToRoomAction CreateAddSocketToRoomAction(string socketId, string room, string @namespace = "/") { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.DisconnectSocketsAction CreateDisconnectSocketsAction(System.Collections.Generic.IEnumerable<string> rooms, bool closeUnderlyingConnection = false, string @namespace = "/") { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.RemoveSocketFromRoomAction CreateRemoveSocketFromRoomAction(string socketId, string room, string @namespace = "/") { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.SendToNamespaceAction CreateSendToNamespaceAction(string eventName, System.Collections.Generic.IEnumerable<object> parameters, System.Collections.Generic.IList<string> exceptRooms = null, string @namespace = "/") { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.SendToRoomsAction CreateSendToRoomsAction(System.Collections.Generic.IEnumerable<string> rooms, string eventName, System.Collections.Generic.IEnumerable<object> parameters, System.Collections.Generic.IList<string> exceptRooms = null, string @namespace = "/") { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.SendToSocketAction CreateSendToSocketAction(string socketId, string eventName, System.Collections.Generic.IEnumerable<object> parameters, string @namespace = "/") { throw null; }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    public partial class SocketIOAttribute : System.Attribute
    {
        public SocketIOAttribute() { }
        public string Connection { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string Hub { get { throw null; } set { } }
    }
    public partial class SocketIOFunctionsOptions : Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter
    {
        public SocketIOFunctionsOptions() { }
        public string ConnectionString { get { throw null; } set { } }
        public string Hub { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        string Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter.Format() { throw null; }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    public partial class SocketIONegotiationAttribute : System.Attribute
    {
        public SocketIONegotiationAttribute() { }
        public string Connection { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string Hub { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string UserId { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SocketIONegotiationResult
    {
        public SocketIONegotiationResult(System.Uri uri) { }
        [Newtonsoft.Json.JsonPropertyAttribute("endpoint")]
        public System.Uri Endpoint { get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute("path")]
        public string Path { get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute("token")]
        public string Token { get { throw null; } }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    public partial class SocketIOParameterAttribute : System.Attribute
    {
        public SocketIOParameterAttribute() { }
    }
    public partial class SocketIOSocketContext : Microsoft.Azure.WebPubSub.Common.WebPubSubConnectionContext
    {
        internal SocketIOSocketContext() : base (default(Microsoft.Azure.WebPubSub.Common.WebPubSubEventType), default(string), default(string), default(string), default(string), default(string), default(string), default(System.Collections.Generic.IReadOnlyDictionary<string, object>), default(System.Collections.Generic.IReadOnlyDictionary<string, string[]>)) { }
        public string Namespace { get { throw null; } }
        public string SocketId { get { throw null; } }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute(TriggerHandlesReturnValue=true)]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    public partial class SocketIOTriggerAttribute : System.Attribute
    {
        public SocketIOTriggerAttribute(string hub, string eventName) { }
        public SocketIOTriggerAttribute(string hub, string eventName, string @namespace) { }
        public SocketIOTriggerAttribute(string hub, string eventName, string @namespace, string[] parameterNames) { }
        public SocketIOTriggerAttribute(string hub, string eventName, string[] parameterNames) { }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public string EventName { get { throw null; } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string Hub { get { throw null; } }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public string Namespace { get { throw null; } }
        public string[] ParameterNames { get { throw null; } }
    }
}
namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model
{
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class SocketIOConnectedRequest : Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model.SocketIOEventHandlerRequest
    {
        public SocketIOConnectedRequest(string @namespace, string socketId) : base (default(string), default(string)) { }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class SocketIOConnectRequest : Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model.SocketIOEventHandlerRequest
    {
        public SocketIOConnectRequest(string @namespace, string socketId, System.Collections.Generic.IReadOnlyDictionary<string, string[]> claims, System.Collections.Generic.IReadOnlyDictionary<string, string[]> query, System.Collections.Generic.IEnumerable<Microsoft.Azure.WebPubSub.Common.WebPubSubClientCertificate> certificates, System.Collections.Generic.IReadOnlyDictionary<string, string[]> headers) : base (default(string), default(string)) { }
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
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class SocketIOConnectResponse : Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model.SocketIOEventHandlerResponse
    {
        public SocketIOConnectResponse() { }
        public SocketIOConnectResponse(System.Net.HttpStatusCode statusCode) { }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class SocketIODisconnectedRequest : Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model.SocketIOEventHandlerRequest
    {
        public SocketIODisconnectedRequest(string @namespace, string socketId, string reason) : base (default(string), default(string)) { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="reason")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("reason")]
        public string Reason { get { throw null; } }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public abstract partial class SocketIOEventHandlerRequest
    {
        protected SocketIOEventHandlerRequest(string @namespace, string socketId) { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="namespace")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("namespace")]
        public string Namespace { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="socketId")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("socketId")]
        public string SocketId { get { throw null; } }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public abstract partial class SocketIOEventHandlerResponse
    {
        public SocketIOEventHandlerResponse() { }
        public SocketIOEventHandlerResponse(System.Net.HttpStatusCode statusCode) { }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class SocketIOMessageRequest : Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model.SocketIOEventHandlerRequest
    {
        public SocketIOMessageRequest(string @namespace, string socketId, string payload, string eventName, System.Collections.Generic.IList<object> arguments) : base (default(string), default(string)) { }
        [System.Runtime.Serialization.DataMemberAttribute(Name="eventName")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("eventName")]
        public string EventName { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="parameters")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("parameters")]
        public System.Collections.Generic.IList<object> Parameters { get { throw null; } }
        [System.Runtime.Serialization.DataMemberAttribute(Name="payload")]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("payload")]
        public string Payload { get { throw null; } }
    }
    [System.Runtime.Serialization.DataContractAttribute]
    public partial class SocketIOMessageResponse : Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model.SocketIOEventHandlerResponse
    {
        public SocketIOMessageResponse() { }
        public SocketIOMessageResponse(System.Collections.Generic.IList<object> parameters) { }
        public SocketIOMessageResponse(System.Net.HttpStatusCode statusCode, System.Collections.Generic.IList<object> parameters) { }
        public System.Collections.Generic.IList<object> Parameters { get { throw null; } }
    }
}
namespace Microsoft.Extensions.Hosting
{
    public static partial class SocketIOJobsBuilderExtensions
    {
        public static Microsoft.Azure.WebJobs.IWebJobsBuilder AddSocketIO(this Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { throw null; }
    }
}
