namespace Azure.Analytics.Synapse.AccessControl
{
    public partial class AccessControlClientOptions : Azure.Core.ClientOptions
    {
        public AccessControlClientOptions(Azure.Analytics.Synapse.AccessControl.AccessControlClientOptions.ServiceVersion version = Azure.Analytics.Synapse.AccessControl.AccessControlClientOptions.ServiceVersion.V2020_08_01_preview) { }
        public enum ServiceVersion
        {
            V2020_08_01_preview = 1,
        }
    }
    public partial class RoleAssignmentsClient
    {
        protected RoleAssignmentsClient() { }
        public RoleAssignmentsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.AccessControl.AccessControlClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.AccessControl.Models.CheckPrincipalAccessResponse> CheckPrincipalAccess(Azure.Analytics.Synapse.AccessControl.Models.SubjectInfo subject, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.AccessControl.Models.RequiredAction> actions, string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.AccessControl.Models.CheckPrincipalAccessResponse>> CheckPrincipalAccessAsync(Azure.Analytics.Synapse.AccessControl.Models.SubjectInfo subject, System.Collections.Generic.IEnumerable<Azure.Analytics.Synapse.AccessControl.Models.RequiredAction> actions, string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.AccessControl.Models.RoleAssignmentDetails> CreateRoleAssignment(string roleAssignmentId, System.Guid roleId, System.Guid principalId, string scope, string principalType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.AccessControl.Models.RoleAssignmentDetails>> CreateRoleAssignmentAsync(string roleAssignmentId, System.Guid roleId, System.Guid principalId, string scope, string principalType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRoleAssignmentById(string roleAssignmentId, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoleAssignmentByIdAsync(string roleAssignmentId, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.AccessControl.Models.RoleAssignmentDetails> GetRoleAssignmentById(string roleAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.AccessControl.Models.RoleAssignmentDetails>> GetRoleAssignmentByIdAsync(string roleAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.AccessControl.Models.RoleAssignmentDetailsList> ListRoleAssignments(string roleId = null, string principalId = null, string scope = null, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.AccessControl.Models.RoleAssignmentDetailsList>> ListRoleAssignmentsAsync(string roleId = null, string principalId = null, string scope = null, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleDefinitionsClient
    {
        protected RoleDefinitionsClient() { }
        public RoleDefinitionsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.AccessControl.AccessControlClientOptions options = null) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.AccessControl.Models.SynapseRoleDefinition> GetRoleDefinitionById(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.AccessControl.Models.SynapseRoleDefinition>> GetRoleDefinitionByIdAsync(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.AccessControl.Models.SynapseRoleDefinition>> ListRoleDefinitions(bool? isBuiltIn = default(bool?), string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.AccessControl.Models.SynapseRoleDefinition>>> ListRoleDefinitionsAsync(bool? isBuiltIn = default(bool?), string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<string>> ListScopes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<string>>> ListScopesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Analytics.Synapse.AccessControl.Models
{
    public partial class CheckAccessDecision
    {
        internal CheckAccessDecision() { }
        public string AccessDecision { get { throw null; } }
        public string ActionId { get { throw null; } }
        public Azure.Analytics.Synapse.AccessControl.Models.RoleAssignmentDetails RoleAssignment { get { throw null; } }
    }
    public partial class CheckPrincipalAccessResponse
    {
        internal CheckPrincipalAccessResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.AccessControl.Models.CheckAccessDecision> AccessDecisions { get { throw null; } }
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
    }
    public partial class RoleAssignmentDetailsList
    {
        internal RoleAssignmentDetailsList() { }
        public int? Count { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.AccessControl.Models.RoleAssignmentDetails> Value { get { throw null; } }
    }
    public partial class SubjectInfo
    {
        public SubjectInfo(System.Guid principalId) { }
        public System.Collections.Generic.IList<System.Guid> GroupIds { get { throw null; } }
        public System.Guid PrincipalId { get { throw null; } }
    }
    public partial class SynapseRbacPermission
    {
        internal SynapseRbacPermission() { }
        public System.Collections.Generic.IReadOnlyList<string> Actions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DataActions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NotActions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NotDataActions { get { throw null; } }
    }
    public partial class SynapseRoleDefinition
    {
        internal SynapseRoleDefinition() { }
        public string AvailabilityStatus { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Guid? Id { get { throw null; } }
        public bool? IsBuiltIn { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.AccessControl.Models.SynapseRbacPermission> Permissions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Scopes { get { throw null; } }
    }
}
