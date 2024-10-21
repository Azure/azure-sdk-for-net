namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class AddConnectionToGroupAction : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubAction
    {
        public AddConnectionToGroupAction() { }
        public string ConnectionId { get { throw null; } set { } }
        public string Group { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class AddUserToGroupAction : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubAction
    {
        public AddUserToGroupAction() { }
        public string Group { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class CloseAllConnectionsAction : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubAction
    {
        public CloseAllConnectionsAction() { }
        public System.Collections.Generic.IList<string> Excluded { get { throw null; } set { } }
        public string Reason { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class CloseClientConnectionAction : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubAction
    {
        public CloseClientConnectionAction() { }
        public string ConnectionId { get { throw null; } set { } }
        public string Reason { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class CloseGroupConnectionsAction : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubAction
    {
        public CloseGroupConnectionsAction() { }
        public System.Collections.Generic.IList<string> Excluded { get { throw null; } set { } }
        public string Group { get { throw null; } set { } }
        public string Reason { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class GrantPermissionAction : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubAction
    {
        public GrantPermissionAction() { }
        public string ConnectionId { get { throw null; } set { } }
        public Azure.Messaging.WebPubSub.WebPubSubPermission Permission { get { throw null; } set { } }
        public string TargetName { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class RemoveConnectionFromGroupAction : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubAction
    {
        public RemoveConnectionFromGroupAction() { }
        public string ConnectionId { get { throw null; } set { } }
        public string Group { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class RemoveUserFromAllGroupsAction : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubAction
    {
        public RemoveUserFromAllGroupsAction() { }
        public string UserId { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class RemoveUserFromGroupAction : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubAction
    {
        public RemoveUserFromGroupAction() { }
        public string Group { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class RevokePermissionAction : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubAction
    {
        public RevokePermissionAction() { }
        public string ConnectionId { get { throw null; } set { } }
        public Azure.Messaging.WebPubSub.WebPubSubPermission Permission { get { throw null; } set { } }
        public string TargetName { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToAllAction : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubAction
    {
        public SendToAllAction() { }
        public System.BinaryData Data { get { throw null; } set { } }
        public Microsoft.Azure.WebPubSub.Common.WebPubSubDataType DataType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Excluded { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToConnectionAction : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubAction
    {
        public SendToConnectionAction() { }
        public string ConnectionId { get { throw null; } set { } }
        public System.BinaryData Data { get { throw null; } set { } }
        public Microsoft.Azure.WebPubSub.Common.WebPubSubDataType DataType { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToGroupAction : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubAction
    {
        public SendToGroupAction() { }
        public System.BinaryData Data { get { throw null; } set { } }
        public Microsoft.Azure.WebPubSub.Common.WebPubSubDataType DataType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Excluded { get { throw null; } set { } }
        public string Group { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToUserAction : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubAction
    {
        public SendToUserAction() { }
        public System.BinaryData Data { get { throw null; } set { } }
        public Microsoft.Azure.WebPubSub.Common.WebPubSubDataType DataType { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public abstract partial class WebPubSubAction
    {
        protected WebPubSubAction() { }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.AddConnectionToGroupAction CreateAddConnectionToGroupAction(string connectionId, string group) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.AddUserToGroupAction CreateAddUserToGroupAction(string userId, string group) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.CloseAllConnectionsAction CreateCloseAllConnectionsAction(System.Collections.Generic.IEnumerable<string> excluded = null, string reason = null) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.CloseClientConnectionAction CreateCloseClientConnectionAction(string connectionId, string reason = null) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.CloseGroupConnectionsAction CreateCloseGroupConnectionsAction(string group, System.Collections.Generic.IEnumerable<string> excluded = null, string reason = null) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.GrantPermissionAction CreateGrantPermissionAction(string connectionId, Azure.Messaging.WebPubSub.WebPubSubPermission permission, string targetName) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.RemoveConnectionFromGroupAction CreateRemoveConnectionFromGroupAction(string connectionId, string group) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.RemoveUserFromAllGroupsAction CreateRemoveUserFromAllGroupsAction(string userId) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.RemoveUserFromGroupAction CreateRemoveUserFromGroupAction(string userId, string group) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.RevokePermissionAction CreateRevokePermissionAction(string connectionId, Azure.Messaging.WebPubSub.WebPubSubPermission permission, string targetName) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.SendToAllAction CreateSendToAllAction(System.BinaryData data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType, System.Collections.Generic.IEnumerable<string> excluded = null) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.SendToAllAction CreateSendToAllAction(string data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType = Microsoft.Azure.WebPubSub.Common.WebPubSubDataType.Text, System.Collections.Generic.IEnumerable<string> excluded = null) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.SendToConnectionAction CreateSendToConnectionAction(string connectionId, System.BinaryData data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.SendToConnectionAction CreateSendToConnectionAction(string connectionId, string data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType = Microsoft.Azure.WebPubSub.Common.WebPubSubDataType.Text) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.SendToGroupAction CreateSendToGroupAction(string group, System.BinaryData data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType, System.Collections.Generic.IEnumerable<string> excluded = null) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.SendToGroupAction CreateSendToGroupAction(string group, string data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType = Microsoft.Azure.WebPubSub.Common.WebPubSubDataType.Text, System.Collections.Generic.IEnumerable<string> excluded = null) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.SendToUserAction CreateSendToUserAction(string userId, System.BinaryData data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.SendToUserAction CreateSendToUserAction(string userId, string data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType = Microsoft.Azure.WebPubSub.Common.WebPubSubDataType.Text) { throw null; }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    public partial class WebPubSubAttribute : System.Attribute
    {
        public WebPubSubAttribute() { }
        [Microsoft.Azure.WebJobs.Description.ConnectionStringAttribute]
        public string Connection { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string Hub { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class WebPubSubConnection
    {
        public WebPubSubConnection(System.Uri uri) { }
        public string AccessToken { get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute("baseUrl")]
        public System.Uri BaseUri { get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute("url")]
        public System.Uri Uri { get { throw null; } }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    public partial class WebPubSubConnectionAttribute : System.Attribute
    {
        public WebPubSubConnectionAttribute() { }
        public Azure.Messaging.WebPubSub.WebPubSubClientProtocol ClientProtocol { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.ConnectionStringAttribute]
        public string Connection { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string Hub { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string UserId { get { throw null; } set { } }
    }
    public partial class WebPubSubContext
    {
        internal WebPubSubContext() { }
        [Newtonsoft.Json.JsonPropertyAttribute("errorMessage")]
        public string ErrorMessage { get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute("hasError")]
        public bool HasError { get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute("isPreflight")]
        public bool IsPreflight { get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute("request")]
        public Microsoft.Azure.WebPubSub.Common.WebPubSubEventRequest Request { get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute("response")]
        public System.Net.Http.HttpResponseMessage Response { get { throw null; } }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    public partial class WebPubSubContextAttribute : System.Attribute
    {
        public WebPubSubContextAttribute() { }
        public WebPubSubContextAttribute(params string[] connections) { }
        public string[] Connections { get { throw null; } set { } }
    }
    public partial class WebPubSubFunctionsOptions : Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter
    {
        public WebPubSubFunctionsOptions() { }
        public string ConnectionString { get { throw null; } set { } }
        public string Hub { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        string Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter.Format() { throw null; }
    }
    public enum WebPubSubTriggerAcceptedClientProtocols
    {
        All = 0,
        WebPubSub = 1,
        Mqtt = 2,
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute(TriggerHandlesReturnValue=true)]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    public partial class WebPubSubTriggerAttribute : System.Attribute
    {
        public WebPubSubTriggerAttribute(Microsoft.Azure.WebPubSub.Common.WebPubSubEventType eventType, string eventName) { }
        public WebPubSubTriggerAttribute(Microsoft.Azure.WebPubSub.Common.WebPubSubEventType eventType, string eventName, params string[] connections) { }
        public WebPubSubTriggerAttribute(string hub, Microsoft.Azure.WebPubSub.Common.WebPubSubEventType eventType, string eventName) { }
        public WebPubSubTriggerAttribute(string hub, Microsoft.Azure.WebPubSub.Common.WebPubSubEventType eventType, string eventName, params string[] connections) { }
        public Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubTriggerAcceptedClientProtocols ClientProtocols { get { throw null; } set { } }
        public string[] Connections { get { throw null; } }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public string EventName { get { throw null; } }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public Microsoft.Azure.WebPubSub.Common.WebPubSubEventType EventType { get { throw null; } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string Hub { get { throw null; } }
    }
}
namespace Microsoft.Extensions.Hosting
{
    public static partial class WebPubSubJobsBuilderExtensions
    {
        public static Microsoft.Azure.WebJobs.IWebJobsBuilder AddWebPubSub(this Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { throw null; }
    }
}
