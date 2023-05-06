namespace Azure.Analytics.Synapse.AccessControl
{
    public partial class AccessControlClientOptions : Azure.Core.ClientOptions
    {
        public AccessControlClientOptions(Azure.Analytics.Synapse.AccessControl.AccessControlClientOptions.ServiceVersion version = Azure.Analytics.Synapse.AccessControl.AccessControlClientOptions.ServiceVersion.V2020_12_01) { }
        public enum ServiceVersion
        {
            V2020_12_01 = 1,
        }
    }
    public partial class CheckAccessDecision
    {
        internal CheckAccessDecision() { }
        public string AccessDecision { get { throw null; } }
        public string ActionId { get { throw null; } }
        public Azure.Analytics.Synapse.AccessControl.RoleAssignmentDetails RoleAssignment { get { throw null; } }
    }
    public partial class CheckPrincipalAccessRequest
    {
        public CheckPrincipalAccessRequest(Azure.Analytics.Synapse.AccessControl.SubjectInfo subject, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.AccessControl.RequiredAction> actions, string scope) { }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.AccessControl.RequiredAction> Actions { get { throw null; } }
        public string Scope { get { throw null; } }
        public Azure.Analytics.Synapse.AccessControl.SubjectInfo Subject { get { throw null; } }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.Synapse.AccessControl.CheckPrincipalAccessRequest accessRequest) { throw null; }
    }
    public partial class CheckPrincipalAccessResponse
    {
        internal CheckPrincipalAccessResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.AccessControl.CheckAccessDecision> AccessDecisions { get { throw null; } }
        public static implicit operator Azure.Analytics.Synapse.AccessControl.CheckPrincipalAccessResponse (Azure.Response response) { throw null; }
    }
    public partial class RequiredAction
    {
        public RequiredAction(string id, bool isDataAction) { }
        public string Id { get { throw null; } }
        public bool IsDataAction { get { throw null; } }
    }
    public partial class RoleAssignmentDetails
    {
        internal RoleAssignmentDetails() { }
        public string Id { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } }
        public string PrincipalType { get { throw null; } }
        public System.Guid? RoleDefinitionId { get { throw null; } }
        public string Scope { get { throw null; } }
        public static implicit operator Azure.Analytics.Synapse.AccessControl.RoleAssignmentDetails (Azure.Response response) { throw null; }
    }
    public partial class RoleAssignmentsClient
    {
        protected RoleAssignmentsClient() { }
        public RoleAssignmentsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public RoleAssignmentsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.AccessControl.AccessControlClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Analytics.Synapse.AccessControl.CheckPrincipalAccessResponse> CheckPrincipalAccess(Azure.Analytics.Synapse.AccessControl.CheckPrincipalAccessRequest checkAccessRequest) { throw null; }
        public virtual Azure.Response CheckPrincipalAccess(Azure.Core.RequestContent content, Azure.Core.ContentType contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.AccessControl.CheckPrincipalAccessResponse>> CheckPrincipalAccessAsync(Azure.Analytics.Synapse.AccessControl.CheckPrincipalAccessRequest checkAccessRequest) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckPrincipalAccessAsync(Azure.Core.RequestContent content, Azure.Core.ContentType contentType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateRoleAssignment(string roleAssignmentId, Azure.Core.RequestContent content, Azure.Core.ContentType contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateRoleAssignmentAsync(string roleAssignmentId, Azure.Core.RequestContent content, Azure.Core.ContentType contentType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteRoleAssignmentById(string roleAssignmentId, string scope = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoleAssignmentByIdAsync(string roleAssignmentId, string scope = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.AccessControl.RoleAssignmentDetails> GetRoleAssignmentById(string roleAssignmentId) { throw null; }
        public virtual Azure.Response GetRoleAssignmentById(string roleAssignmentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.AccessControl.RoleAssignmentDetails>> GetRoleAssignmentByIdAsync(string roleAssignmentId) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRoleAssignmentByIdAsync(string roleAssignmentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetRoleAssignments(string roleId = null, string principalId = null, string scope = null, string continuationToken = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRoleAssignmentsAsync(string roleId = null, string principalId = null, string scope = null, string continuationToken = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class RoleDefinitionsClient
    {
        protected RoleDefinitionsClient() { }
        public RoleDefinitionsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public RoleDefinitionsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.AccessControl.AccessControlClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetRoleDefinitionById(string roleDefinitionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRoleDefinitionByIdAsync(string roleDefinitionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetRoleDefinitions(bool? isBuiltIn = default(bool?), string scope = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRoleDefinitionsAsync(bool? isBuiltIn = default(bool?), string scope = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetScopes(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScopesAsync(Azure.RequestContext context = null) { throw null; }
    }
    public partial class SubjectInfo
    {
        public SubjectInfo(System.Guid principalId) { }
        public System.Collections.Generic.IList<System.Guid> GroupIds { get { throw null; } }
        public System.Guid PrincipalId { get { throw null; } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AccessControlClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Synapse.AccessControl.RoleAssignmentsClient, Azure.Analytics.Synapse.AccessControl.AccessControlClientOptions> AddRoleAssignmentsClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Synapse.AccessControl.RoleAssignmentsClient, Azure.Analytics.Synapse.AccessControl.AccessControlClientOptions> AddRoleAssignmentsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Synapse.AccessControl.RoleDefinitionsClient, Azure.Analytics.Synapse.AccessControl.AccessControlClientOptions> AddRoleDefinitionsClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Synapse.AccessControl.RoleDefinitionsClient, Azure.Analytics.Synapse.AccessControl.AccessControlClientOptions> AddRoleDefinitionsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
