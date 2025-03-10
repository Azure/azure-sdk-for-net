namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public static partial class Category
    {
        public const string Connections = "connections";
        public const string Messages = "messages";
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public static partial class Event
    {
        public const string Connected = "connected";
        public const string Disconnected = "disconnected";
    }
    [Newtonsoft.Json.JsonConverterAttribute(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum GroupAction
    {
        [System.Runtime.Serialization.EnumMemberAttribute(Value="add")]
        Add = 0,
        [System.Runtime.Serialization.EnumMemberAttribute(Value="remove")]
        Remove = 1,
        [System.Runtime.Serialization.EnumMemberAttribute(Value="removeAll")]
        RemoveAll = 2,
    }
    public partial class InvocationContext
    {
        public InvocationContext() { }
        public object[] Arguments { get { throw null; } set { } }
        public string Category { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Claims { get { throw null; } set { } }
        public string ConnectionId { get { throw null; } set { } }
        public string Error { get { throw null; } set { } }
        public string Event { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Headers { get { throw null; } set { } }
        public string Hub { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Query { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public static partial class InvocationContextExtensions
    {
        public static Microsoft.Azure.SignalR.Management.ClientManager GetClientManager(this Microsoft.Azure.WebJobs.Extensions.SignalRService.InvocationContext invocationContext) { throw null; }
        public static System.Threading.Tasks.Task<Microsoft.AspNetCore.SignalR.IHubClients> GetClientsAsync(this Microsoft.Azure.WebJobs.Extensions.SignalRService.InvocationContext invocationContext) { throw null; }
        public static System.Threading.Tasks.Task<Microsoft.AspNetCore.SignalR.IGroupManager> GetGroupsAsync(this Microsoft.Azure.WebJobs.Extensions.SignalRService.InvocationContext invocationContext) { throw null; }
        public static System.Threading.Tasks.Task<Microsoft.Azure.SignalR.Management.IUserGroupManager> GetUserGroupManagerAsync(this Microsoft.Azure.WebJobs.Extensions.SignalRService.InvocationContext invocationContext) { throw null; }
    }
    public partial interface ISecurityTokenValidator
    {
        Microsoft.Azure.WebJobs.Extensions.SignalRService.SecurityTokenResult ValidateToken(Microsoft.AspNetCore.Http.HttpRequest request);
    }
    public partial interface IServiceHubContextStore
    {
        Microsoft.Azure.SignalR.Management.IServiceManager ServiceManager { get; }
        System.Threading.Tasks.ValueTask<Microsoft.Azure.SignalR.Management.IServiceHubContext> GetAsync(string hubName);
    }
    public partial interface ISignalRConnectionInfoConfigurer
    {
        System.Func<Microsoft.Azure.WebJobs.Extensions.SignalRService.SecurityTokenResult, Microsoft.AspNetCore.Http.HttpRequest, Microsoft.Azure.WebJobs.Extensions.SignalRService.SignalRConnectionDetail, Microsoft.Azure.WebJobs.Extensions.SignalRService.SignalRConnectionDetail> Configure { get; set; }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    public abstract partial class NegotiationBaseAttribute : System.Attribute
    {
        protected NegotiationBaseAttribute() { }
        public string[] ClaimTypeList { get { throw null; } set { } }
        public string ConnectionStringSetting { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string HubName { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string IdToken { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string UserId { get { throw null; } set { } }
    }
    public sealed partial class SecurityTokenResult
    {
        internal SecurityTokenResult() { }
        [Newtonsoft.Json.JsonPropertyAttribute("exception")]
        public System.Exception Exception { get { throw null; } }
        public System.Security.Claims.ClaimsPrincipal Principal { get { throw null; } }
        [Newtonsoft.Json.JsonPropertyAttribute("status")]
        public Microsoft.Azure.WebJobs.Extensions.SignalRService.SecurityTokenStatus Status { get { throw null; } }
        public static Microsoft.Azure.WebJobs.Extensions.SignalRService.SecurityTokenResult Empty() { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.SignalRService.SecurityTokenResult Error(System.Exception ex) { throw null; }
        public static Microsoft.Azure.WebJobs.Extensions.SignalRService.SecurityTokenResult Success(System.Security.Claims.ClaimsPrincipal principal) { throw null; }
    }
    public enum SecurityTokenStatus
    {
        Valid = 0,
        Error = 1,
        Empty = 2,
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    public partial class SecurityTokenValidationAttribute : System.Attribute
    {
        public SecurityTokenValidationAttribute() { }
    }
    public abstract partial class ServerlessHub : System.IDisposable
    {
        protected ServerlessHub(Microsoft.Azure.SignalR.Management.IServiceHubContext hubContext = null, Microsoft.Azure.SignalR.Management.IServiceManager serviceManager = null) { }
        public Microsoft.Azure.SignalR.Management.ClientManager ClientManager { get { throw null; } }
        public Microsoft.AspNetCore.SignalR.IHubClients Clients { get { throw null; } }
        public Microsoft.AspNetCore.SignalR.IGroupManager Groups { get { throw null; } }
        public string HubName { get { throw null; } }
        public Microsoft.Azure.SignalR.Management.IUserGroupManager UserGroups { get { throw null; } }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected System.Collections.Generic.IList<System.Security.Claims.Claim> GetClaims(string jwt) { throw null; }
        protected Microsoft.Azure.WebJobs.Extensions.SignalRService.SignalRConnectionInfo Negotiate(string userId = null, System.Collections.Generic.IList<System.Security.Claims.Claim> claims = null, System.TimeSpan? lifetime = default(System.TimeSpan?)) { throw null; }
        protected System.Threading.Tasks.Task<Microsoft.Azure.WebJobs.Extensions.SignalRService.SignalRConnectionInfo> NegotiateAsync(Microsoft.Azure.SignalR.Management.NegotiationOptions options) { throw null; }
        [System.AttributeUsageAttribute(System.AttributeTargets.Class)]
        protected internal partial class SignalRConnectionAttribute : System.Attribute, Microsoft.Azure.WebJobs.IConnectionProvider
        {
            public SignalRConnectionAttribute(string connectionStringSetting) { }
            public string Connection { get { throw null; } set { } }
        }
    }
    public abstract partial class ServerlessHub<T> where T : class
    {
        protected ServerlessHub() { }
        protected ServerlessHub(Microsoft.Azure.SignalR.Management.ServiceHubContext<T> serviceHubContext) { }
        public Microsoft.Azure.SignalR.Management.ClientManager ClientManager { get { throw null; } }
        public Microsoft.AspNetCore.SignalR.IHubClients<T> Clients { get { throw null; } }
        public Microsoft.Azure.SignalR.Management.GroupManager Groups { get { throw null; } }
        public string HubName { get { throw null; } }
        public Microsoft.Azure.SignalR.Management.UserGroupManager UserGroups { get { throw null; } }
        protected System.Collections.Generic.IList<System.Security.Claims.Claim> GetClaims(string jwt) { throw null; }
        protected System.Threading.Tasks.Task<Microsoft.Azure.WebJobs.Extensions.SignalRService.SignalRConnectionInfo> NegotiateAsync(Microsoft.Azure.SignalR.Management.NegotiationOptions options) { throw null; }
    }
    public partial class SignalRAsyncCollector<T> : Microsoft.Azure.WebJobs.IAsyncCollector<T>
    {
        internal SignalRAsyncCollector() { }
        public System.Threading.Tasks.Task AddAsync(T item, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task FlushAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    public partial class SignalRAttribute : System.Attribute
    {
        public SignalRAttribute() { }
        public string ConnectionStringSetting { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string HubName { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Class)]
    public partial class SignalRConnectionAttribute : System.Attribute, Microsoft.Azure.WebJobs.IConnectionProvider
    {
        public SignalRConnectionAttribute(string connection) { }
        public string Connection { get { throw null; } set { } }
    }
    public partial class SignalRConnectionDetail
    {
        public SignalRConnectionDetail() { }
        public System.Collections.Generic.IList<System.Security.Claims.Claim> Claims { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public partial class SignalRConnectionInfo
    {
        public SignalRConnectionInfo() { }
        [Newtonsoft.Json.JsonPropertyAttribute("accessToken")]
        public string AccessToken { get { throw null; } set { } }
        [Newtonsoft.Json.JsonPropertyAttribute("url")]
        public string Url { get { throw null; } set { } }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    public partial class SignalRConnectionInfoAttribute : Microsoft.Azure.WebJobs.Extensions.SignalRService.NegotiationBaseAttribute
    {
        public SignalRConnectionInfoAttribute() { }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    public partial class SignalREndpointsAttribute : System.Attribute
    {
        public SignalREndpointsAttribute() { }
        public string ConnectionStringSetting { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string HubName { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Method, AllowMultiple=true, Inherited=true)]
    public abstract partial class SignalRFilterAttribute : Microsoft.Azure.WebJobs.Host.FunctionInvocationFilterAttribute
    {
        protected SignalRFilterAttribute() { }
        public abstract System.Threading.Tasks.Task FilterAsync(Microsoft.Azure.WebJobs.Extensions.SignalRService.InvocationContext invocationContext, System.Threading.CancellationToken cancellationToken);
        public override System.Threading.Tasks.Task OnExecutingAsync(Microsoft.Azure.WebJobs.Host.FunctionExecutingContext executingContext, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public static partial class SignalRFunctionsHostBuilderExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddDefaultAuth(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Microsoft.IdentityModel.Tokens.TokenValidationParameters> configureTokenValidationParameters, System.Func<Microsoft.Azure.WebJobs.Extensions.SignalRService.SecurityTokenResult, Microsoft.AspNetCore.Http.HttpRequest, Microsoft.Azure.WebJobs.Extensions.SignalRService.SignalRConnectionDetail, Microsoft.Azure.WebJobs.Extensions.SignalRService.SignalRConnectionDetail> configurer = null) { throw null; }
    }
    [Newtonsoft.Json.JsonObjectAttribute]
    public partial class SignalRGroupAction
    {
        public SignalRGroupAction() { }
        [Newtonsoft.Json.JsonPropertyAttribute("action")]
        [Newtonsoft.Json.JsonRequiredAttribute]
        public Microsoft.Azure.WebJobs.Extensions.SignalRService.GroupAction Action { get { throw null; } set { } }
        [Newtonsoft.Json.JsonPropertyAttribute("connectionId")]
        public string ConnectionId { get { throw null; } set { } }
        [Newtonsoft.Json.JsonPropertyAttribute("endpoints")]
        public Microsoft.Azure.SignalR.ServiceEndpoint[] Endpoints { get { throw null; } set { } }
        [Newtonsoft.Json.JsonPropertyAttribute("groupName")]
        public string GroupName { get { throw null; } set { } }
        [Newtonsoft.Json.JsonPropertyAttribute("userId")]
        public string UserId { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    public partial class SignalRIgnoreAttribute : System.Attribute
    {
        public SignalRIgnoreAttribute() { }
    }
    [Newtonsoft.Json.JsonObjectAttribute]
    public partial class SignalRMessage
    {
        public SignalRMessage() { }
        [Newtonsoft.Json.JsonPropertyAttribute("arguments")]
        [Newtonsoft.Json.JsonRequiredAttribute]
        public object[] Arguments { get { throw null; } set { } }
        [Newtonsoft.Json.JsonPropertyAttribute("connectionId")]
        public string ConnectionId { get { throw null; } set { } }
        [Newtonsoft.Json.JsonPropertyAttribute("endpoints")]
        public Microsoft.Azure.SignalR.ServiceEndpoint[] Endpoints { get { throw null; } set { } }
        [Newtonsoft.Json.JsonPropertyAttribute("groupName")]
        public string GroupName { get { throw null; } set { } }
        [Newtonsoft.Json.JsonPropertyAttribute("target")]
        [Newtonsoft.Json.JsonRequiredAttribute]
        public string Target { get { throw null; } set { } }
        [Newtonsoft.Json.JsonPropertyAttribute("userId")]
        public string UserId { get { throw null; } set { } }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    public partial class SignalRNegotiationAttribute : Microsoft.Azure.WebJobs.Extensions.SignalRService.NegotiationBaseAttribute
    {
        public SignalRNegotiationAttribute() { }
    }
    public partial class SignalROptions : Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter
    {
        public SignalROptions() { }
        public System.TimeSpan? HttpClientTimeout { get { throw null; } set { } }
        public Azure.Core.Serialization.ObjectSerializer? JsonObjectSerializer { get { throw null; } set { } }
        public Microsoft.AspNetCore.SignalR.Protocol.IHubProtocol? MessagePackHubProtocol { get { throw null; } set { } }
        public Microsoft.Azure.SignalR.Management.ServiceManagerRetryOptions? RetryOptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Microsoft.Azure.SignalR.ServiceEndpoint> ServiceEndpoints { get { throw null; } }
        public Microsoft.Azure.SignalR.Management.ServiceTransportType ServiceTransportType { get { throw null; } set { } }
        string Microsoft.Azure.WebJobs.Hosting.IOptionsFormatter.Format() { throw null; }
    }
    public partial class SignalROutputConverter
    {
        public SignalROutputConverter() { }
        public object ConvertToSignalROutput(object input) { throw null; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    public partial class SignalRParameterAttribute : System.Attribute
    {
        public SignalRParameterAttribute() { }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute(TriggerHandlesReturnValue=true)]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    public partial class SignalRTriggerAttribute : System.Attribute
    {
        public SignalRTriggerAttribute() { }
        public SignalRTriggerAttribute(string hubName, string category, string @event) { }
        public SignalRTriggerAttribute(string hubName, string category, string @event, params string[] parameterNames) { }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string Category { get { throw null; } }
        public string ConnectionStringSetting { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string Event { get { throw null; } }
        [Microsoft.Azure.WebJobs.Description.AutoResolveAttribute]
        public string HubName { get { throw null; } }
        public string[] ParameterNames { get { throw null; } }
    }
    public static partial class SignalRTriggerCategories
    {
        public const string Connections = "connections";
        public const string Messages = "messages";
    }
    public static partial class SignalRTriggerEvents
    {
        public const string Connected = "connected";
        public const string Disconnected = "disconnected";
    }
    public partial class SignalRTriggerException : System.Exception
    {
        public SignalRTriggerException() { }
        public SignalRTriggerException(string message) { }
        public SignalRTriggerException(string message, System.Exception innerException) { }
    }
    public static partial class SignalRWebJobsBuilderExtensions
    {
        public static Microsoft.Azure.WebJobs.IWebJobsBuilder AddSignalR(this Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { throw null; }
    }
    public partial class SignalRWebJobsStartup : Microsoft.Azure.WebJobs.Hosting.IWebJobsStartup
    {
        public SignalRWebJobsStartup() { }
        public void Configure(Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { }
    }
    public static partial class StaticServiceHubContextStore
    {
        public static Microsoft.Azure.WebJobs.Extensions.SignalRService.IServiceHubContextStore Get(string connectionStringSetting = "AzureSignalRConnectionString") { throw null; }
    }
}
