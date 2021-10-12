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
    public partial class GrantPermission : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public GrantPermission() { }
        public string ConnectionId { get { throw null; } set { } }
        public Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubPermission Permission { get { throw null; } set { } }
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
        public Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubPermission Permission { get { throw null; } set { } }
        public string TargetName { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToAll : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public SendToAll() { }
        public Microsoft.Azure.WebPubSub.Common.MessageDataType DataType { get { throw null; } set { } }
        public string[] Excluded { get { throw null; } set { } }
        public System.BinaryData Message { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToConnection : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public SendToConnection() { }
        public string ConnectionId { get { throw null; } set { } }
        public Microsoft.Azure.WebPubSub.Common.MessageDataType DataType { get { throw null; } set { } }
        public System.BinaryData Message { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToGroup : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public SendToGroup() { }
        public Microsoft.Azure.WebPubSub.Common.MessageDataType DataType { get { throw null; } set { } }
        public string[] Excluded { get { throw null; } set { } }
        public string Group { get { throw null; } set { } }
        public System.BinaryData Message { get { throw null; } set { } }
    }
    [Newtonsoft.Json.JsonObjectAttribute(NamingStrategyType=typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public partial class SendToUser : Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubOperation
    {
        public SendToUser() { }
        public Microsoft.Azure.WebPubSub.Common.MessageDataType DataType { get { throw null; } set { } }
        public System.BinaryData Message { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
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
    public partial class WebPubSubContext
    {
        internal WebPubSubContext() { }
        [Newtonsoft.Json.JsonPropertyAttribute("errorCode")]
        public string ErrorCode { get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute("errorMessage")]
        public string ErrorMessage { get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute("isValidationRequest")]
        public bool IsValidationRequest { get { throw null; } }
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
        public Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubValidationOptions ValidationOptions { get { throw null; } set { } }
    }
    public partial class WebPubSubFunctionsOptions : Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter
    {
        public WebPubSubFunctionsOptions() { }
        public string ConnectionString { get { throw null; } set { } }
        public string Hub { get { throw null; } set { } }
        public Microsoft.Azure.WebJobs.Extensions.WebPubSub.WebPubSubValidationOptions ValidationOptions { get { throw null; } set { } }
        public string Format() { throw null; }
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
    public enum WebPubSubPermission
    {
        SendToGroup = 1,
        JoinLeaveGroup = 2,
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute(TriggerHandlesReturnValue=true)]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    public partial class WebPubSubTriggerAttribute : System.Attribute
    {
        public WebPubSubTriggerAttribute(Microsoft.Azure.WebPubSub.Common.WebPubSubEventType eventType, string eventName) { }
        public WebPubSubTriggerAttribute(string hub, Microsoft.Azure.WebPubSub.Common.WebPubSubEventType eventType, string eventName) { }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public string EventName { get { throw null; } }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public Microsoft.Azure.WebPubSub.Common.WebPubSubEventType EventType { get { throw null; } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string Hub { get { throw null; } }
    }
    public partial class WebPubSubValidationOptions
    {
        public WebPubSubValidationOptions(System.Collections.Generic.IEnumerable<string> connectionStrings) { }
        public WebPubSubValidationOptions(params string[] connectionStrings) { }
    }
    public partial class WebPubSubWebJobsStartup : Microsoft.Azure.WebJobs.Hosting.IWebJobsStartup
    {
        public WebPubSubWebJobsStartup() { }
        public void Configure(Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { }
    }
}
