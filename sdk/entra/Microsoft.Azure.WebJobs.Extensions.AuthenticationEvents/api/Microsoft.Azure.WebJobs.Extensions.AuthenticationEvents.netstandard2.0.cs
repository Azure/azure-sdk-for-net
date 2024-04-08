namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    public abstract partial class ActionableCloudEventResponse<T> : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.ActionableResponse<T> where T : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.WebJobsAuthenticationEventsAction
    {
        protected ActionableCloudEventResponse() { }
        internal abstract string DataTypeIdentifier { get; }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("oDataType")]
        public string ODataType { get { throw null; } }
    }
    public abstract partial class ActionableResponse<T> : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthenticationEventResponse where T : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.WebJobsAuthenticationEventsAction
    {
        protected ActionableResponse() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("actions")]
        public System.Collections.Generic.List<T> Actions { get { throw null; } set { } }
    }
    public abstract partial class AuthenticationEventData
    {
        protected AuthenticationEventData() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("authenticationEventListenerId")]
        public System.Guid AuthenticationEventListenerId { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("customAuthenticationExtensionId")]
        public System.Guid CustomAuthenticationExtensionId { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("tenantId")]
        public System.Guid TenantId { get { throw null; } set { } }
    }
    public enum AuthenticationEventDefinition
    {
        [Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthenticationEventMetadataAttribute(typeof(Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.TokenIssuanceStartRequest), "microsoft.graph.authenticationEvent.TokenIssuanceStart", "TokenIssuanceStart", "CloudEventActionableTemplate.json")]
        TokenIssuanceStart = 0,
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Field, AllowMultiple=false)]
    public partial class AuthenticationEventMetadataAttribute : System.Attribute
    {
        internal AuthenticationEventMetadataAttribute() { }
        public string EventNamespace { get { throw null; } set { } }
    }
    public abstract partial class AuthenticationEventRequestBase
    {
        internal AuthenticationEventRequestBase() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("queryParameters")]
        public System.Collections.Generic.Dictionary<string, string> QueryParameters { get { throw null; } }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonConverterAttribute(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("requestStatus")]
        public Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.RequestStatusType RequestStatus { get { throw null; } }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("statusMessage")]
        public string StatusMessage { get { throw null; } set { } }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("type")]
        public string Type { get { throw null; } set { } }
        public abstract Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthenticationEventResponse Completed();
        public abstract Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthenticationEventResponse Failed(System.Exception exception);
        public override string ToString() { throw null; }
    }
    public abstract partial class AuthenticationEventRequest<TResponse, TData> : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthenticationEventRequestBase where TResponse : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthenticationEventResponse, new() where TData : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthenticationEventData
    {
        internal AuthenticationEventRequest() { }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("data")]
        public TData Data { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("response")]
        public TResponse Response { get { throw null; } set { } }
        public override Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthenticationEventResponse Completed() { throw null; }
        public override Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthenticationEventResponse Failed(System.Exception exception) { throw null; }
    }
    public abstract partial class AuthenticationEventResponse : System.Net.Http.HttpResponseMessage
    {
        protected AuthenticationEventResponse() { }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public string Body { get { throw null; } set { } }
        internal abstract void BuildJsonElement();
    }
    public partial class AuthenticationEventResponseHandler : Microsoft.Azure.WebJobs.Host.Bindings.IValueBinder, Microsoft.Azure.WebJobs.Host.Bindings.IValueProvider
    {
        internal AuthenticationEventResponseHandler() { }
        public Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthenticationEventRequestBase Request { get { throw null; } }
        public Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthenticationEventResponse Response { get { throw null; } }
        public System.Type Type { get { throw null; } }
        public System.Threading.Tasks.Task<object> GetValueAsync() { throw null; }
        public System.Threading.Tasks.Task SetValueAsync(object result, System.Threading.CancellationToken cancellationToken) { throw null; }
        public string ToInvokeString() { throw null; }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute(TriggerHandlesReturnValue=true)]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    public partial class AuthenticationEventsTriggerAttribute : System.Attribute
    {
        public AuthenticationEventsTriggerAttribute() { }
        public string AudienceAppId { get { throw null; } set { } }
        public string AuthorityUrl { get { throw null; } set { } }
        public string AuthorizedPartyAppId { get { throw null; } set { } }
    }
    public partial class AuthenticationEventWebJobsStartup : Microsoft.Azure.WebJobs.Hosting.IWebJobsStartup
    {
        public AuthenticationEventWebJobsStartup() { }
        public void Configure(Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { }
    }
    public sealed partial class EventTriggerMetrics
    {
        internal EventTriggerMetrics() { }
        public const string MetricsHeader = "User-Agent";
        public const string ProductName = "AuthenticationEvents";
        public static string Framework { get { throw null; } }
        public static Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.EventTriggerMetrics Instance { get { throw null; } }
        public static string Platform { get { throw null; } }
        public static string ProductVersion { get { throw null; } }
    }
    public enum RequestStatusType
    {
        Failed = 0,
        TokenInvalid = 1,
        Successful = 2,
        ValidationError = 3,
    }
    public abstract partial class WebJobsAuthenticationEventsAction
    {
        public WebJobsAuthenticationEventsAction() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("actionType")]
        internal abstract string ActionType { get; }
        internal abstract Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthenticationEventJsonElement BuildActionBody();
        internal abstract void FromJson(Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthenticationEventJsonElement actionBody);
    }
    public abstract partial class WebJobsAuthenticationEventsCloudEventRequest<TResponse, TData> : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthenticationEventRequest<TResponse, TData> where TResponse : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthenticationEventResponse, new() where TData : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.WebJobsAuthenticationEventsTypedData
    {
        internal WebJobsAuthenticationEventsCloudEventRequest() { }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("oDataType")]
        public string ODataType { get { throw null; } set { } }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("source")]
        public string Source { get { throw null; } set { } }
    }
    public abstract partial class WebJobsAuthenticationEventsTypedData : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthenticationEventData
    {
        protected WebJobsAuthenticationEventsTypedData() { }
    }
    public enum WebJobsAuthenticationEventType
    {
        OnTokenIssuanceStart = 0,
    }
}
namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart
{
    public partial class ProvideClaimsForToken : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.TokenIssuanceAction
    {
        public ProvideClaimsForToken() { }
        public ProvideClaimsForToken(params Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.WebjobsAuthenticationEventsTokenClaim[] claim) { }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("claims")]
        public System.Collections.Generic.List<Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.WebjobsAuthenticationEventsTokenClaim> Claims { get { throw null; } }
        public void AddClaim(string Id, params string[] Values) { }
    }
    public abstract partial class TokenIssuanceAction : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.WebJobsAuthenticationEventsAction
    {
        public TokenIssuanceAction() { }
    }
    public partial class TokenIssuanceStartData : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.WebJobsAuthenticationEventsTypedData
    {
        public TokenIssuanceStartData() { }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("authenticationContext")]
        public Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.WebJobsAuthenticationEventsContext AuthenticationContext { get { throw null; } set { } }
    }
    public partial class TokenIssuanceStartRequest : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.WebJobsAuthenticationEventsCloudEventRequest<Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.TokenIssuanceStartResponse, Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.TokenIssuanceStartData>
    {
        public TokenIssuanceStartRequest(System.Net.Http.HttpRequestMessage request) { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("tokenClaims")]
        public System.Collections.Generic.Dictionary<string, string> TokenClaims { get { throw null; } }
    }
    public partial class TokenIssuanceStartResponse : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.ActionableCloudEventResponse<Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.TokenIssuanceAction>
    {
        public TokenIssuanceStartResponse() { }
    }
    public partial class WebJobsAuthenticationEventsContext
    {
        public WebJobsAuthenticationEventsContext() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("client")]
        public Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.WebJobsAuthenticationEventsContextClient Client { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("clientServicePrincipal")]
        public Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.WebJobsAuthenticationEventsContextServicePrincipal ClientServicePrincipal { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("correlationId")]
        public System.Guid CorrelationId { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("protocol")]
        public string Protocol { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("resourceServicePrincipal")]
        public Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.WebJobsAuthenticationEventsContextServicePrincipal ResourceServicePrincipal { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("user")]
        public Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.WebJobsAuthenticationEventsContextUser User { get { throw null; } set { } }
    }
    public partial class WebJobsAuthenticationEventsContextClient
    {
        public WebJobsAuthenticationEventsContextClient() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("ip")]
        public string Ip { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("locale")]
        public string Locale { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("market")]
        public string Market { get { throw null; } set { } }
    }
    public partial class WebJobsAuthenticationEventsContextServicePrincipal
    {
        public WebJobsAuthenticationEventsContextServicePrincipal() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("appDisplayName")]
        public string AppDisplayName { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("appId")]
        public System.Guid AppId { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("displayName")]
        public string DisplayName { get { throw null; } set { } }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("id")]
        public System.Guid Id { get { throw null; } set { } }
    }
    public partial class WebJobsAuthenticationEventsContextUser
    {
        public WebJobsAuthenticationEventsContextUser() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("companyName")]
        public string CompanyName { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("createdDateTime")]
        public string CreatedDateTime { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("displayName")]
        public string DisplayName { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("givenName")]
        public string GivenName { get { throw null; } set { } }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("id")]
        public System.Guid Id { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("mail")]
        public string Mail { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("onPremisesSamAccountName")]
        public string OnPremisesSamAccountName { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("onPremisesSecurityIdentifier")]
        public string OnPremisesSecurityIdentifier { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("onPremiseUserPrincipalName")]
        public string OnPremiseUserPrincipalName { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("preferredDataLocation")]
        public string PreferredDataLocation { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("preferredLanguage")]
        public string PreferredLanguage { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("surname")]
        public string Surname { get { throw null; } set { } }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("userPrincipalName")]
        public string UserPrincipalName { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("userType")]
        public string UserType { get { throw null; } set { } }
    }
    public partial class WebjobsAuthenticationEventsTokenClaim
    {
        public WebjobsAuthenticationEventsTokenClaim(string id, params string[] values) { }
        [System.ComponentModel.DataAnnotations.RequiredAttribute(AllowEmptyStrings=false)]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("id")]
        public string Id { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("values")]
        public string[] Values { get { throw null; } set { } }
    }
}
