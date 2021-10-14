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
        public RoleAssignmentsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.AccessControl.AccessControlClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CheckPrincipalAccess(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckPrincipalAccessAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response CreateRoleAssignment(string roleAssignmentId, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateRoleAssignmentAsync(string roleAssignmentId, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteRoleAssignmentById(string roleAssignmentId, string scope = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoleAssignmentByIdAsync(string roleAssignmentId, string scope = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.AccessControl.RoleAssignmentDetails> GetRoleAssignmentById(string roleAssignmentId) { throw null; }
        public virtual Azure.Response GetRoleAssignmentById(string roleAssignmentId, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.AccessControl.RoleAssignmentDetails>> GetRoleAssignmentByIdAsync(string roleAssignmentId) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRoleAssignmentByIdAsync(string roleAssignmentId, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response ListRoleAssignments(Azure.RequestOptions options, string roleId = null, string principalId = null, string scope = null, string continuationToken = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListRoleAssignmentsAsync(Azure.RequestOptions options, string roleId = null, string principalId = null, string scope = null, string continuationToken = null) { throw null; }
    }
    public partial class RoleDefinitionsClient
    {
        protected RoleDefinitionsClient() { }
        public RoleDefinitionsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.AccessControl.AccessControlClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetRoleDefinitionById(string roleDefinitionId, Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRoleDefinitionByIdAsync(string roleDefinitionId, Azure.RequestOptions options) { throw null; }
        public virtual Azure.Response ListRoleDefinitions(Azure.RequestOptions options, bool? isBuiltIn = default(bool?), string scope = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListRoleDefinitionsAsync(Azure.RequestOptions options, bool? isBuiltIn = default(bool?), string scope = null) { throw null; }
        public virtual Azure.Response ListScopes(Azure.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListScopesAsync(Azure.RequestOptions options) { throw null; }
    }
}
