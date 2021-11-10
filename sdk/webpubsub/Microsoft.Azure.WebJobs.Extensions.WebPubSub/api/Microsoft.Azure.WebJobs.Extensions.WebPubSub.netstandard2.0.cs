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
    public partial class CloseAllConnections : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public CloseAllConnections() { }
        public System.Collections.Generic.IList<string> Excluded { get { throw null; } set { } }
        public string Reason { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class CloseClientConnection : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public CloseClientConnection() { }
        public string ConnectionId { get { throw null; } set { } }
        public string Reason { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class CloseGroupConnections : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public CloseGroupConnections() { }
        public System.Collections.Generic.IList<string> Excluded { get { throw null; } set { } }
        public string Group { get { throw null; } set { } }
        public string Reason { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class GrantPermission : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public GrantPermission() { }
        public string ConnectionId { get { throw null; } set { } }
        public Azure.Messaging.WebPubSub.WebPubSubPermission Permission { get { throw null; } set { } }
        public string TargetName { get { throw null; } set { } }
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
    public partial class RevokePermission : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public RevokePermission() { }
        public string ConnectionId { get { throw null; } set { } }
        public Azure.Messaging.WebPubSub.WebPubSubPermission Permission { get { throw null; } set { } }
        public string TargetName { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToAll : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public SendToAll() { }
        public System.BinaryData Data { get { throw null; } set { } }
        public Microsoft.Azure.WebPubSub.Common.WebPubSubDataType DataType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Excluded { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToConnection : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public SendToConnection() { }
        public string ConnectionId { get { throw null; } set { } }
        public System.BinaryData Data { get { throw null; } set { } }
        public Microsoft.Azure.WebPubSub.Common.WebPubSubDataType DataType { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToGroup : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public SendToGroup() { }
        public System.BinaryData Data { get { throw null; } set { } }
        public Microsoft.Azure.WebPubSub.Common.WebPubSubDataType DataType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Excluded { get { throw null; } set { } }
        public string Group { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToUser : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public SendToUser() { }
        public System.BinaryData Data { get { throw null; } set { } }
        public Microsoft.Azure.WebPubSub.Common.WebPubSubDataType DataType { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
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
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public abstract partial class WebPubSubOperation
    {
        protected WebPubSubOperation() { }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.AddConnectionToGroup AddConnectionToGroup(string connectionId, string group) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.AddUserToGroup AddUserToGroup(string userId, string group) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.CloseAllConnections CloseAllConnections(System.Collections.Generic.IList<string> excluded, string reason) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.CloseClientConnection CloseClientConnection(string connectionId, string reason) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.CloseGroupConnections CloseGroupConnections(string group, System.Collections.Generic.IList<string> excluded, string reason) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.GrantPermission GrantPermission(string connectionId, Azure.Messaging.WebPubSub.WebPubSubPermission permission, string targetName) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.RemoveConnectionFromGroup RemoveConnectionFromGroup(string connectionId, string group) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.RemoveUserFromAllGroups RemoveUserFromAllGroups(string userId) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.RemoveUserFromGroup RemoveUserFromGroup(string userId, string group) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.RevokePermission RevokePermission(string connectionId, Azure.Messaging.WebPubSub.WebPubSubPermission permission, string targetName) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.SendToAll SendToAll(System.BinaryData data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType, System.Collections.Generic.IList<string> excluded = null) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.SendToAll SendToAll(string data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType = Microsoft.Azure.WebPubSub.Common.WebPubSubDataType.Text, System.Collections.Generic.IList<string> excluded = null) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.SendToConnection SendToConnection(string connectionId, System.BinaryData data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.SendToConnection SendToConnection(string connectionId, string data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType = Microsoft.Azure.WebPubSub.Common.WebPubSubDataType.Text) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.SendToGroup SendToGroup(string group, System.BinaryData data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType, System.Collections.Generic.IList<string> excluded = null) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.SendToGroup SendToGroup(string group, string data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType = Microsoft.Azure.WebPubSub.Common.WebPubSubDataType.Text, System.Collections.Generic.IList<string> excluded = null) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.SendToUser SendToUser(string userId, System.BinaryData data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.WebPubSub.SendToUser SendToUser(string userId, string data, Microsoft.Azure.WebPubSub.Common.WebPubSubDataType dataType = Microsoft.Azure.WebPubSub.Common.WebPubSubDataType.Text) { throw null; }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute(TriggerHandlesReturnValue=true)]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    public partial class WebPubSubTriggerAttribute : System.Attribute
    {
        public WebPubSubTriggerAttribute(Microsoft.Azure.WebPubSub.Common.WebPubSubEventType eventType, string eventName) { }
        public WebPubSubTriggerAttribute(Microsoft.Azure.WebPubSub.Common.WebPubSubEventType eventType, string eventName, params string[] connections) { }
        public WebPubSubTriggerAttribute(string hub, Microsoft.Azure.WebPubSub.Common.WebPubSubEventType eventType, string eventName) { }
        public WebPubSubTriggerAttribute(string hub, Microsoft.Azure.WebPubSub.Common.WebPubSubEventType eventType, string eventName, params string[] connections) { }
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
