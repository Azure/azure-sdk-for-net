namespace Azure.Analytics.Synapse.AccessControl
{
    public partial class SynapseAccessControlClient
    {
        protected SynapseAccessControlClient() { }
        public SynapseAccessControlClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Synapse.AccessControl.SynapseAdministrationClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CheckPrincipalAccess(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckPrincipalAccessAsync(Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Synapse.AccessControl.SynapseRoleAssignment> CreateRoleAssignment(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope roleScope, string roleDefinitionId, string principalId, System.Guid? roleAssignmentName = default(System.Guid?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateRoleAssignment(string roleAssignmentId, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateRoleAssignmentAsync(string roleAssignmentId, Azure.Core.RequestContent content, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response DeleteRoleAssignmentById(string roleAssignmentId, string scope = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoleAssignmentByIdAsync(string roleAssignmentId, string scope = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetRoleAssignmentById(string roleAssignmentId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRoleAssignmentByIdAsync(string roleAssignmentId, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response GetRoleDefinitionById(string roleDefinitionId, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRoleDefinitionByIdAsync(string roleDefinitionId, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response ListRoleAssignments(string roleId = null, string principalId = null, string scope = null, string continuationToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListRoleAssignmentsAsync(string roleId = null, string principalId = null, string scope = null, string continuationToken = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response ListRoleDefinitions(bool? isBuiltIn = default(bool?), string scope = null, Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListRoleDefinitionsAsync(bool? isBuiltIn = default(bool?), string scope = null, Azure.RequestOptions options = null) { throw null; }
        public virtual Azure.Response ListScopes(Azure.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ListScopesAsync(Azure.RequestOptions options = null) { throw null; }
    }
    public partial class SynapseAdministrationClientOptions : Azure.Core.ClientOptions
    {
        public SynapseAdministrationClientOptions(Azure.Analytics.Synapse.AccessControl.SynapseAdministrationClientOptions.ServiceVersion version = Azure.Analytics.Synapse.AccessControl.SynapseAdministrationClientOptions.ServiceVersion.V2020_08_01_preview) { }
        public enum ServiceVersion
        {
            V2020_08_01_preview = 1,
        }
    }
    public partial class SynapseRoleAssignment
    {
        public SynapseRoleAssignment(string id, Azure.Analytics.Synapse.AccessControl.SynapseRoleAssignmentProperties properties) { }
        public string Id { get { throw null; } }
        public Azure.Analytics.Synapse.AccessControl.SynapseRoleAssignmentProperties Properties { get { throw null; } }
    }
    public partial class SynapseRoleAssignmentProperties
    {
        public SynapseRoleAssignmentProperties(string principalId, string roleDefinitionId, Azure.Analytics.Synapse.AccessControl.SynapseRoleScope? scope = default(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope?)) { }
        public string PrincipalId { get { throw null; } }
        public string RoleDefinitionId { get { throw null; } }
        public Azure.Analytics.Synapse.AccessControl.SynapseRoleScope? Scope { get { throw null; } }
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
        public static implicit operator Azure.Analytics.Synapse.AccessControl.SynapseRoleScope (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Synapse.AccessControl.SynapseRoleScope left, Azure.Analytics.Synapse.AccessControl.SynapseRoleScope right) { throw null; }
        public override string ToString() { throw null; }
    }
}
