namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    [Microsoft.Azure.WebJobs.Description.BindingAttribute(TriggerHandlesReturnValue=true)]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    public partial class AuthenticationEventsTriggerAttribute : System.Attribute
    {
        public AuthenticationEventsTriggerAttribute() { }
        public string AudienceAppId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Field, AllowMultiple=false)]
    public partial class AuthEventMetadataAttribute : System.Attribute
    {
        internal AuthEventMetadataAttribute() { }
        public string EventNamespace { get { throw null; } set { } }
    }
    public partial class AuthEventResponseHandler : Microsoft.Azure.WebJobs.Host.Bindings.IValueBinder, Microsoft.Azure.WebJobs.Host.Bindings.IValueProvider
    {
        public AuthEventResponseHandler() { }
        public Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventRequestBase Request { get { throw null; } }
        public Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventResponse Response { get { throw null; } }
        public System.Type Type { get { throw null; } }
        public System.Threading.Tasks.Task<object> GetValueAsync() { throw null; }
        public System.Threading.Tasks.Task SetValueAsync(object result, System.Threading.CancellationToken cancellationToken) { throw null; }
        public string ToInvokeString() { throw null; }
    }
    public partial class AuthEventWebJobsStartup : Microsoft.Azure.WebJobs.Hosting.IWebJobsStartup
    {
        public AuthEventWebJobsStartup() { }
        public void Configure(Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { }
    }
    public enum EventDefinition
    {
        [Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthEventMetadataAttribute(typeof(Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.TokenIssuanceStartRequest), "onTokenIssuanceStartCustomExtension", "TokenIssuanceStart.preview_10_01_2021", "ResponseTemplate.json")]
        TokenIssuanceStartV20211001Preview = 0,
        [Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.AuthEventMetadataAttribute(typeof(Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.TokenIssuanceStartRequest), "microsoft.graph.authenticationEvent.TokenIssuanceStart", "TokenIssuanceStart", "CloudEventActionableTemplate.json")]
        TokenIssuanceStart = 1,
    }
    public enum EventType
    {
        OnTokenIssuanceStart = 0,
    }
    public enum RequestStatusType
    {
        Failed = 0,
        TokenInvalid = 1,
        Successful = 2,
    }
}
namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    public abstract partial class ActionableCloudEventResponse<T> : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.ActionableResponse<T> where T : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventAction
    {
        protected ActionableCloudEventResponse() { }
        internal abstract string DataTypeIdentifier { get; }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("oDataType")]
        public string ODataType { get { throw null; } }
    }
    public abstract partial class ActionableResponse<T> : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventResponse where T : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventAction
    {
        protected ActionableResponse() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("actions")]
        public System.Collections.Generic.List<T> Actions { get { throw null; } set { } }
    }
    public abstract partial class AuthEventAction
    {
        public AuthEventAction() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("actionType")]
        internal abstract string ActionType { get; }
        internal abstract Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventJsonElement BuildActionBody();
        internal abstract void FromJson(Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventJsonElement actionBody);
    }
    public abstract partial class AuthEventData
    {
        protected AuthEventData() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("authenticationEventListenerId")]
        public System.Guid AuthenticationEventListenerId { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("AuthenticationEventsId")]
        public System.Guid AuthenticationEventsId { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("tenantId")]
        public System.Guid TenantId { get { throw null; } set { } }
    }
    public abstract partial class AuthEventRequestBase
    {
        internal AuthEventRequestBase() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("queryParameters")]
        public System.Collections.Generic.Dictionary<string, string> QueryParameters { get { throw null; } }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonConverterAttribute(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("requestStatus")]
        public Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.RequestStatusType RequestStatus { get { throw null; } set { } }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("statusMessage")]
        public string StatusMessage { get { throw null; } set { } }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("type")]
        public string Type { get { throw null; } set { } }
        public abstract System.Threading.Tasks.Task<Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventResponse> Completed();
        public abstract System.Threading.Tasks.Task<Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventResponse> Failed(System.Exception exception);
        public override string ToString() { throw null; }
    }
    public abstract partial class AuthEventRequest<TResponse, TData> : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventRequestBase where TResponse : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventResponse where TData : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventData
    {
        internal AuthEventRequest() { }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("payload")]
        public TData Payload { get { throw null; } set { } }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("response")]
        public TResponse Response { get { throw null; } set { } }
        public override System.Threading.Tasks.Task<Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventResponse> Completed() { throw null; }
        public override System.Threading.Tasks.Task<Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventResponse> Failed(System.Exception exception) { throw null; }
    }
    public abstract partial class AuthEventResponse : System.Net.Http.HttpResponseMessage
    {
        protected AuthEventResponse() { }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        public string Body { get { throw null; } set { } }
        internal abstract void Invalidate();
    }
    public abstract partial class CloudEventData : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventData
    {
        protected CloudEventData() { }
    }
    public abstract partial class CloudEventRequest<TResponse, TData> : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventRequest<TResponse, TData> where TResponse : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventResponse where TData : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.CloudEventData
    {
        internal CloudEventRequest() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("oDataType")]
        public string ODataType { get { throw null; } set { } }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("source")]
        public string Source { get { throw null; } set { } }
    }
}
namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart
{
    public partial class TokenIssuanceStartRequest : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.CloudEventRequest<Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.TokenIssuanceStartResponse, Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Data.TokenIssuanceStartData>
    {
        public TokenIssuanceStartRequest(System.Net.Http.HttpRequestMessage request) { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("tokenClaims")]
        public System.Collections.Generic.Dictionary<string, string> TokenClaims { get { throw null; } }
    }
    public partial class TokenIssuanceStartResponse : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.ActionableCloudEventResponse<Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Actions.TokenIssuanceAction>
    {
        public TokenIssuanceStartResponse() { }
    }
}
namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Actions
{
    public partial class ProvideClaimsForToken : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Actions.TokenIssuanceAction
    {
        public ProvideClaimsForToken() { }
        public ProvideClaimsForToken(params Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Actions.TokenClaim[] claim) { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("claims")]
        public System.Collections.Generic.List<Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Actions.TokenClaim> Claims { get { throw null; } }
        public void AddClaim(string Id, params string[] Values) { }
    }
    public partial class TokenClaim
    {
        public TokenClaim(string id, params string[] values) { }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("id")]
        public string Id { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("values")]
        public string[] Values { get { throw null; } set { } }
    }
    public abstract partial class TokenIssuanceAction : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.AuthEventAction
    {
        public TokenIssuanceAction() { }
    }
}
namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Data
{
    public partial class AuthenticationEventContext
    {
        public AuthenticationEventContext() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("authenticationProtocol")]
        public string AuthenticationProtocol { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("client")]
        public Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Data.AuthenticationEventContextClient Client { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("clientServicePrincipal")]
        public Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Data.AuthenticationEventContextServicePrincipal ClientServicePrincipal { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("correlationId")]
        public System.Guid CorrelationId { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("resourceServicePrincipal")]
        public Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Data.AuthenticationEventContextServicePrincipal ResourceServicePrincipal { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("user")]
        public Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Data.AuthenticationEventContextUser User { get { throw null; } set { } }
    }
    public partial class AuthenticationEventContextClient
    {
        public AuthenticationEventContextClient() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("ip")]
        public string Ip { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("locale")]
        public string Locale { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("market")]
        public string Market { get { throw null; } set { } }
    }
    public partial class AuthenticationEventContextServicePrincipal
    {
        public AuthenticationEventContextServicePrincipal() { }
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
    public partial class AuthenticationEventContextUser
    {
        public AuthenticationEventContextUser() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("companyName")]
        public string CompanyName { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("country")]
        public string Country { get { throw null; } set { } }
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
    public partial class TokenIssuanceStartData : Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.CloudEventData
    {
        public TokenIssuanceStartData() { }
        [System.ComponentModel.DataAnnotations.RequiredAttribute]
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("authenticationContext")]
        public Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Data.AuthenticationEventContext AuthenticationContext { get { throw null; } set { } }
    }
}
