namespace Azure.Messaging.WebPubSub
{
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public sealed partial class ClientCertificateInfo
    {
        public ClientCertificateInfo(string thumbprint) { }
        public string Thumbprint { get { throw null; } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class ConnectedEventRequest : Azure.Messaging.WebPubSub.ServiceRequest
    {
        public ConnectedEventRequest() : base (default(bool), default(bool), default(bool), default(bool), default(string)) { }
        public override string Name { get { throw null; } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public sealed partial class ConnectEventRequest : Azure.Messaging.WebPubSub.ServiceRequest
    {
        public ConnectEventRequest(System.Collections.Generic.IDictionary<string, string[]> claims, System.Collections.Generic.IDictionary<string, string[]> query, string[] subprotocols, Azure.Messaging.WebPubSub.ClientCertificateInfo[] clientCertificateInfos) : base (default(bool), default(bool), default(bool), default(bool), default(string)) { }
        public System.Collections.Generic.IDictionary<string, string[]> Claims { get { throw null; } }
        public Azure.Messaging.WebPubSub.ClientCertificateInfo[] ClientCertificates { get { throw null; } }
        public override string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string[]> Query { get { throw null; } }
        public string[] Subprotocols { get { throw null; } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public sealed partial class DisconnectedEventRequest : Azure.Messaging.WebPubSub.ServiceRequest
    {
        public DisconnectedEventRequest(string reason) : base (default(bool), default(bool), default(bool), default(bool), default(string)) { }
        public override string Name { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public sealed partial class InvalidRequest : Azure.Messaging.WebPubSub.ServiceRequest
    {
        public InvalidRequest(System.Net.HttpStatusCode statusCode, string message = null) : base (default(bool), default(bool), default(bool), default(bool), default(string)) { }
        public override string Name { get { throw null; } }
    }
    [Newtonsoft.Json.JsonConverterAttribute(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum MessageDataType
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value="binary")]
        Binary = 0,
        [System.Runtime.Serialization.EnumMemberAttribute(Value="json")]
        Json = 1,
        [System.Runtime.Serialization.EnumMemberAttribute(Value="text")]
        Text = 2,
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public sealed partial class MessageEventRequest : Azure.Messaging.WebPubSub.ServiceRequest
    {
        public MessageEventRequest(System.BinaryData message, Azure.Messaging.WebPubSub.MessageDataType dataType) : base (default(bool), default(bool), default(bool), default(bool), default(string)) { }
        public Azure.Messaging.WebPubSub.MessageDataType DataType { get { throw null; } }
        public System.BinaryData Message { get { throw null; } }
        public override string Name { get { throw null; } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public abstract partial class ServiceRequest
    {
        public ServiceRequest(bool isValidationRequest, bool valid, bool unauthorized, bool badRequest, string error = null) { }
        public bool BadRequest { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public bool IsValidationRequest { get { throw null; } }
        public abstract string Name { get; }
        public bool Unauthorized { get { throw null; } }
        public bool Valid { get { throw null; } }
    }
    public sealed partial class ValidationRequest : Azure.Messaging.WebPubSub.ServiceRequest
    {
        public ValidationRequest(bool valid) : base (default(bool), default(bool), default(bool), default(bool), default(string)) { }
        public override string Name { get { throw null; } }
    }
}
namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class AddConnectionToGroup : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public AddConnectionToGroup() { }
        public string ConnectionId { get { throw null; } set { } }
        public string Group { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class AddUserToGroup : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public AddUserToGroup() { }
        public string Group { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class CloseClientConnection : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public CloseClientConnection() { }
        public string ConnectionId { get { throw null; } set { } }
        public string Reason { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class ConnectionContext
    {
        public ConnectionContext() { }
        public string ConnectionId { get { throw null; } }
        public string EventName { get { throw null; } }
        public Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubEventType EventType { get { throw null; } }
        public System.Collections.Generic.Dictionary<string, Microsoft.Extensions.Primitives.StringValues> Headers { get { throw null; } }
        public string Hub { get { throw null; } }
        public string Signature { get { throw null; } }
        public string UserId { get { throw null; } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class ConnectResponse : Microsoft.Azure.WebJobs.Extensions.WebPubSub.ServiceResponse
    {
        public ConnectResponse() { }
        [Newtonsoft.Json.JsonPropertyAttribute(Required=Newtonsoft.Json.Required.Default)]
        public string[] Groups { get { throw null; } set { } }
        [Newtonsoft.Json.JsonPropertyAttribute(Required=Newtonsoft.Json.Required.Default)]
        public string[] Roles { get { throw null; } set { } }
        [Newtonsoft.Json.JsonPropertyAttribute(Required=Newtonsoft.Json.Required.Default)]
        public string Subprotocol { get { throw null; } set { } }
        [Newtonsoft.Json.JsonPropertyAttribute(Required=Newtonsoft.Json.Required.Default)]
        public string UserId { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class ErrorResponse : Microsoft.Azure.WebJobs.Extensions.WebPubSub.ServiceResponse
    {
        [Newtonsoft.Json.JsonConstructorAttribute]
        public ErrorResponse() { }
        public ErrorResponse(Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubErrorCode code, string message = null) { }
        [Newtonsoft.Json.JsonPropertyAttribute(Required=Newtonsoft.Json.Required.Always)]
        public Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubErrorCode Code { get { throw null; } set { } }
        [Newtonsoft.Json.JsonPropertyAttribute(Required=Newtonsoft.Json.Required.Default)]
        public string ErrorMessage { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class GrantGroupPermission : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public GrantGroupPermission() { }
        public string ConnectionId { get { throw null; } set { } }
        public Azure.Messaging.WebPubSub.WebPubSubPermission Permission { get { throw null; } set { } }
        public string TargetName { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class MessageResponse : Microsoft.Azure.WebJobs.Extensions.WebPubSub.ServiceResponse
    {
        public MessageResponse() { }
        public Azure.Messaging.WebPubSub.MessageDataType DataType { get { throw null; } set { } }
        [Newtonsoft.Json.JsonPropertyAttribute(Required=Newtonsoft.Json.Required.Always)]
        public System.BinaryData Message { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class RemoveConnectionFromGroup : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public RemoveConnectionFromGroup() { }
        public string ConnectionId { get { throw null; } set { } }
        public string Group { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class RemoveUserFromAllGroups : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public RemoveUserFromAllGroups() { }
        public string UserId { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class RemoveUserFromGroup : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public RemoveUserFromGroup() { }
        public string Group { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class RevokeGroupPermission : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public RevokeGroupPermission() { }
        public string ConnectionId { get { throw null; } set { } }
        public Azure.Messaging.WebPubSub.WebPubSubPermission Permission { get { throw null; } set { } }
        public string TargetName { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToAll : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public SendToAll() { }
        public Azure.Messaging.WebPubSub.MessageDataType DataType { get { throw null; } set { } }
        public string[] Excluded { get { throw null; } set { } }
        public System.BinaryData Message { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToConnection : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public SendToConnection() { }
        public string ConnectionId { get { throw null; } set { } }
        public Azure.Messaging.WebPubSub.MessageDataType DataType { get { throw null; } set { } }
        public System.BinaryData Message { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToGroup : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public SendToGroup() { }
        public Azure.Messaging.WebPubSub.MessageDataType DataType { get { throw null; } set { } }
        public string[] Excluded { get { throw null; } set { } }
        public string Group { get { throw null; } set { } }
        public System.BinaryData Message { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToUser : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public SendToUser() { }
        public Azure.Messaging.WebPubSub.MessageDataType DataType { get { throw null; } set { } }
        public System.BinaryData Message { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public abstract partial class ServiceResponse
    {
        protected ServiceResponse() { }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    public partial class WebPubSubAttribute : System.Attribute
    {
        public WebPubSubAttribute() { }
        [Microsoft.Azure.WebJobs.Description.ConnectionStringAttribute]
        public string ConnectionStringSetting { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string Hub { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class WebPubSubConnection
    {
        public WebPubSubConnection(System.Uri url) { }
        public string AccessToken { get { throw null; } }
        public string BaseUrl { get { throw null; } }
        public string Url { get { throw null; } }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    public partial class WebPubSubConnectionAttribute : System.Attribute
    {
        public WebPubSubConnectionAttribute() { }
        [Microsoft.Azure.WebJobs.Description.ConnectionStringAttribute]
        public string ConnectionStringSetting { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string Hub { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string UserId { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonConverterAttribute(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum WebPubSubErrorCode
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value="unauthorized")]
        Unauthorized = 0,
        [System.Runtime.Serialization.EnumMemberAttribute(Value="userError")]
        UserError = 1,
        [System.Runtime.Serialization.EnumMemberAttribute(Value="serverError")]
        ServerError = 2,
    }
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum WebPubSubEventType
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value="system")]
        System = 0,
        [System.Runtime.Serialization.EnumMemberAttribute(Value="user")]
        User = 1,
    }
    public static partial class WebPubSubJobsBuilderExtensions
    {
        public static Microsoft.Azure.WebJobs.IWebJobsBuilder AddWebPubSub(this Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { throw null; }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public abstract partial class WebPubSubOperation
    {
        protected WebPubSubOperation() { }
        public string OperationKind { get { throw null; } set { } }
    }
    public partial class WebPubSubOptions : Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter
    {
        public WebPubSubOptions() { }
        public string Hub { get { throw null; } set { } }
        public string Format() { throw null; }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class WebPubSubRequest
    {
        internal WebPubSubRequest() { }
        public Microsoft.Azure.WebJobs.Extensions.WebPubSub.ConnectionContext ConnectionContext { get { throw null; } }
        public Azure.Messaging.WebPubSub.ServiceRequest Request { get { throw null; } }
        public System.Net.Http.HttpResponseMessage Response { get { throw null; } }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    public partial class WebPubSubRequestAttribute : System.Attribute
    {
        public WebPubSubRequestAttribute() { }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute(TriggerHandlesReturnValue=true)]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    public partial class WebPubSubTriggerAttribute : System.Attribute
    {
        public WebPubSubTriggerAttribute(Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubEventType eventType, string eventName) { }
        public WebPubSubTriggerAttribute(string hub, Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubEventType eventType, string eventName) { }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public string EventName { get { throw null; } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubEventType EventType { get { throw null; } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string Hub { get { throw null; } }
    }
    public partial class WebPubSubWebJobsStartup : Microsoft.Azure.WebJobs.Hosting.IWebJobsStartup
    {
        public WebPubSubWebJobsStartup() { }
        public void Configure(Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { }
    }
}
