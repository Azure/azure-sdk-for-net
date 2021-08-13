namespace Azure.Analytics.Synapse.AccessControl
{
    public partial class SynapseAccessControlClient
    {
        protected SynapseAccessControlClient() { }
        public SynapseAccessControlClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.AccessControl.SynapseAdministrationClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CheckPrincipalAccess(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckPrincipalAccessAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.AccessControl.SynapseRoleAssignment> CreateRoleAssignment(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope roleScope, string roleDefinitionId, string principalId, System.Guid? roleAssignmentName = default(System.Guid?)) { throw null; }
        public virtual Azure.Response CreateRoleAssignment(string roleAssignmentId, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.AccessControl.SynapseRoleAssignment>> CreateRoleAssignmentAsync(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope roleScope, string roleDefinitionId, string principalId, System.Guid? roleAssignmentName = default(System.Guid?)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateRoleAssignmentAsync(string roleAssignmentId, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteRoleAssignment(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope roleScope, string roleAssignmentName) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoleAssignmentAsync(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope roleScope, string roleAssignmentName) { throw null; }
        public virtual Azure.Response DeleteRoleAssignmentById(string roleAssignmentId, string scope = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoleAssignmentByIdAsync(string roleAssignmentId, string scope = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.AccessControl.SynapseRoleAssignment> GetRoleAssignment(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope roleScope, string roleAssignmentName) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.AccessControl.SynapseRoleAssignment>> GetRoleAssignmentAsync(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope roleScope, string roleAssignmentName) { throw null; }
        public virtual Azure.Response GetRoleAssignmentById(string roleAssignmentId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRoleAssignmentByIdAsync(string roleAssignmentId, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.AccessControl.SynapseRoleAssignment> GetRoleAssignments(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope? roleScope = default(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope?)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.AccessControl.SynapseRoleAssignment> GetRoleAssignmentsAsync(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope? roleScope = default(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope?)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.AccessControl.SynapseRoleDefinition> GetRoleDefinition(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope roleScope, System.Guid roleDefinitionName) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Synapse.AccessControl.SynapseRoleDefinition>> GetRoleDefinitionAsync(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope roleScope, System.Guid roleDefinitionName) { throw null; }
        public virtual Azure.Response GetRoleDefinitionById(string roleDefinitionId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRoleDefinitionByIdAsync(string roleDefinitionId, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Synapse.AccessControl.SynapseRoleDefinition> GetRoleDefinitions(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope roleScope) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Synapse.AccessControl.SynapseRoleDefinition> GetRoleDefinitionsAsync(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope roleScope) { throw null; }
        public virtual Azure.Response ListRoleAssignments(string roleId = null, string principalId = null, string scope = null, string continuationToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListRoleAssignmentsAsync(string roleId = null, string principalId = null, string scope = null, string continuationToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response ListRoleDefinitions(bool? isBuiltIn = default(bool?), string scope = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListRoleDefinitionsAsync(bool? isBuiltIn = default(bool?), string scope = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response ListScopes(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListScopesAsync(Azure.RequestOptions options = null) { throw null; }
    }
    public partial class SynapseAdministrationClientOptions : Azure.Core.ClientOptions
    {
        public SynapseAdministrationClientOptions(Azure.Analytics.Synapse.AccessControl.SynapseAdministrationClientOptions.ServiceVersion version = Azure.Analytics.Synapse.AccessControl.SynapseAdministrationClientOptions.ServiceVersion.V2020_12_01) { }
        public enum ServiceVersion
        {
            V2020_12_01 = 1,
        }
    }
    public partial class SynapsePermission
    {
        public SynapsePermission(System.Collections.Generic.IList<string> actions, System.Collections.Generic.IList<string> notActions, System.Collections.Generic.IList<string> dataActions, System.Collections.Generic.IList<string> notDataActions) { }
        public System.Collections.Generic.IList<string> Actions { get { throw null; } }
        public System.Collections.Generic.IList<string> DataActions { get { throw null; } }
        public System.Collections.Generic.IList<string> NotActions { get { throw null; } }
        public System.Collections.Generic.IList<string> NotDataActions { get { throw null; } }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.Synapse.AccessControl.SynapsePermission permission) { throw null; }
    }
    public partial class SynapseRoleAssignment
    {
        public SynapseRoleAssignment(string id, Azure.Analytics.Synapse.AccessControl.SynapseRoleAssignmentProperties properties) { }
        public string Id { get { throw null; } }
        public Azure.Analytics.Synapse.AccessControl.SynapseRoleAssignmentProperties Properties { get { throw null; } }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.Synapse.AccessControl.SynapseRoleAssignment value) { throw null; }
    }
    public partial class SynapseRoleAssignmentProperties
    {
        public SynapseRoleAssignmentProperties(string principalId, string roleDefinitionId, Azure.Analytics.Synapse.AccessControl.SynapseRoleScope? scope = default(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope?)) { }
        public string PrincipalId { get { throw null; } }
        public string RoleDefinitionId { get { throw null; } }
        public Azure.Analytics.Synapse.AccessControl.SynapseRoleScope? Scope { get { throw null; } }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.Synapse.AccessControl.SynapseRoleAssignmentProperties value) { throw null; }
    }
    public partial class SynapseRoleDefinition
    {
        public SynapseRoleDefinition(string id, string name, string description, System.Collections.Generic.IList<Azure.Analytics.Synapse.AccessControl.SynapsePermission> permissions, System.Collections.Generic.IList<Azure.Analytics.Synapse.AccessControl.SynapseRoleScope> assignableScopes) { }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.AccessControl.SynapseRoleScope> AssignableScopes { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Synapse.AccessControl.SynapsePermission> Permissions { get { throw null; } }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.Synapse.AccessControl.SynapseRoleDefinition value) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseRoleScope : System.IEquatable<Azure.Analytics.Synapse.AccessControl.SynapseRoleScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseRoleScope(string value) { throw null; }
        public static Azure.Analytics.Synapse.AccessControl.SynapseRoleScope Global { get { throw null; } }
        public bool Equals(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope left, Azure.Analytics.Synapse.AccessControl.SynapseRoleScope right) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Analytics.Synapse.AccessControl.SynapseRoleScope scope) { throw null; }
        public static implicit operator Azure.Analytics.Synapse.AccessControl.SynapseRoleScope (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope left, Azure.Analytics.Synapse.AccessControl.SynapseRoleScope right) { throw null; }
        public override string ToString() { throw null; }
    }
}
