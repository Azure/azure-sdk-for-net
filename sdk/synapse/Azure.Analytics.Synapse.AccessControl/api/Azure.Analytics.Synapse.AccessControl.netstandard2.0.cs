namespace Azure.Analytics.Synapse.AccessControl
{
    public partial class AccessControlClient
    {
        protected AccessControlClient() { }
        public AccessControlClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public AccessControlClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.AccessControl.AccessControlClientOptions options) { }
        public virtual Azure.Response<Azure.Analytics.Synapse.AccessControl.Models.RoleAssignmentDetails> CreateRoleAssignment(Azure.Analytics.Synapse.AccessControl.Models.RoleAssignmentOptions createRoleAssignmentOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.AccessControl.Models.RoleAssignmentDetails>> CreateRoleAssignmentAsync(Azure.Analytics.Synapse.AccessControl.Models.RoleAssignmentOptions createRoleAssignmentOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRoleAssignmentById(string roleAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoleAssignmentByIdAsync(string roleAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<string>> GetCallerRoleAssignments(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<string>>> GetCallerRoleAssignmentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.AccessControl.Models.RoleAssignmentDetails> GetRoleAssignmentById(string roleAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.AccessControl.Models.RoleAssignmentDetails>> GetRoleAssignmentByIdAsync(string roleAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.AccessControl.Models.RoleAssignmentDetails>> GetRoleAssignments(string roleId = null, string principalId = null, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.AccessControl.Models.RoleAssignmentDetails>>> GetRoleAssignmentsAsync(string roleId = null, string principalId = null, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.AccessControl.Models.SynapseRole> GetRoleDefinitionById(string roleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.AccessControl.Models.SynapseRole>> GetRoleDefinitionByIdAsync(string roleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.AccessControl.Models.SynapseRole> GetRoleDefinitions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.AccessControl.Models.SynapseRole> GetRoleDefinitionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AccessControlClientOptions : Azure.Core.ClientOptions
    {
        public AccessControlClientOptions(Azure.Analytics.Synapse.AccessControl.AccessControlClientOptions.ServiceVersion serviceVersion = Azure.Analytics.Synapse.AccessControl.AccessControlClientOptions.ServiceVersion.V2020_02_01_preview) { }
        public enum ServiceVersion
        {
            V2020_02_01_preview = 1,
        }
    }
}
namespace Azure.Analytics.Synapse.AccessControl.Models
{
    public partial class RoleAssignmentDetails
    {
        internal RoleAssignmentDetails() { }
        public string Id { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public string RoleId { get { throw null; } }
    }
    public partial class RoleAssignmentOptions
    {
        public RoleAssignmentOptions(string roleId, string principalId) { }
        public string PrincipalId { get { throw null; } }
        public string RoleId { get { throw null; } }
    }
    public partial class RolesListResponse
    {
        internal RolesListResponse() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Synapse.AccessControl.Models.SynapseRole> Value { get { throw null; } }
    }
    public partial class SynapseRole
    {
        internal SynapseRole() { }
        public string Id { get { throw null; } }
        public bool IsBuiltIn { get { throw null; } }
        public string Name { get { throw null; } }
    }
}
