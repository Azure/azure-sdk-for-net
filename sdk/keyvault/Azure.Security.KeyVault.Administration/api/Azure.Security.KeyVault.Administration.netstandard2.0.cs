namespace Azure.Security.KeyVault.Administration
{
    public partial class KeyVaultAccessControlClient
    {
        protected KeyVaultAccessControlClient() { }
        public KeyVaultAccessControlClient(System.Uri vaultUri, Azure.Core.TokenCredential credential) { }
        public KeyVaultAccessControlClient(System.Uri vaultUri, Azure.Core.TokenCredential credential, Azure.Security.KeyVault.Administration.KeyVaultAccessControlClientOptions options) { }
        public virtual System.Uri VaultUri { get { throw null; } }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.Models.RoleAssignment> CreateRoleAssignment(Azure.Security.KeyVault.Administration.RoleAssignmentScope roleScope, Azure.Security.KeyVault.Administration.Models.RoleAssignmentProperties properties, System.Guid name = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.Models.RoleAssignment>> CreateRoleAssignmentAsync(Azure.Security.KeyVault.Administration.RoleAssignmentScope roleScope, Azure.Security.KeyVault.Administration.Models.RoleAssignmentProperties properties, System.Guid name = default(System.Guid), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.Models.RoleAssignment> DeleteRoleAssignment(Azure.Security.KeyVault.Administration.RoleAssignmentScope roleScope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.Models.RoleAssignment>> DeleteRoleAssignmentAsync(Azure.Security.KeyVault.Administration.RoleAssignmentScope roleScope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.Models.RoleAssignment> GetRoleAssignment(Azure.Security.KeyVault.Administration.RoleAssignmentScope roleScope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.Models.RoleAssignment>> GetRoleAssignmentAsync(Azure.Security.KeyVault.Administration.RoleAssignmentScope roleScope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Administration.Models.RoleAssignment> GetRoleAssignments(Azure.Security.KeyVault.Administration.RoleAssignmentScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Administration.Models.RoleAssignment> GetRoleAssignmentsAsync(Azure.Security.KeyVault.Administration.RoleAssignmentScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Administration.Models.RoleDefinition> GetRoleDefinitions(Azure.Security.KeyVault.Administration.RoleAssignmentScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Administration.Models.RoleDefinition> GetRoleDefinitionsAsync(Azure.Security.KeyVault.Administration.RoleAssignmentScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KeyVaultAccessControlClientOptions : Azure.Core.ClientOptions
    {
        public KeyVaultAccessControlClientOptions(Azure.Security.KeyVault.Administration.KeyVaultAccessControlClientOptions.ServiceVersion version = Azure.Security.KeyVault.Administration.KeyVaultAccessControlClientOptions.ServiceVersion.V7_2_Preview) { }
        public Azure.Security.KeyVault.Administration.KeyVaultAccessControlClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V7_2_Preview = 1,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleAssignmentScope : System.IEquatable<Azure.Security.KeyVault.Administration.RoleAssignmentScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleAssignmentScope(string value) { throw null; }
        public RoleAssignmentScope(System.Uri ResourceId) { throw null; }
        public static Azure.Security.KeyVault.Administration.RoleAssignmentScope Global { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.RoleAssignmentScope Keys { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Administration.RoleAssignmentScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Administration.RoleAssignmentScope left, Azure.Security.KeyVault.Administration.RoleAssignmentScope right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Administration.RoleAssignmentScope (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Administration.RoleAssignmentScope left, Azure.Security.KeyVault.Administration.RoleAssignmentScope right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.Security.KeyVault.Administration.Models
{
    public static partial class KeyVaultModelFactory
    {
        public static Azure.Security.KeyVault.Administration.Models.RoleAssignment RoleAssignment(string id, string name, string type, Azure.Security.KeyVault.Administration.Models.RoleAssignmentPropertiesWithScope properties) { throw null; }
        public static Azure.Security.KeyVault.Administration.Models.RoleDefinition RoleDefinition(string id, string name, string type, string roleName, string description, string roleType, System.Collections.Generic.IReadOnlyList<Azure.Security.KeyVault.Administration.Models.KeyVaultPermission> permissions, System.Collections.Generic.IReadOnlyList<string> assignableScopes) { throw null; }
    }
    public partial class KeyVaultPermission
    {
        internal KeyVaultPermission() { }
        public System.Collections.Generic.IReadOnlyList<string> Actions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DataActions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NotActions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NotDataActions { get { throw null; } }
    }
    public partial class RoleAssignment
    {
        internal RoleAssignment() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Security.KeyVault.Administration.Models.RoleAssignmentPropertiesWithScope Properties { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class RoleAssignmentProperties
    {
        public RoleAssignmentProperties(string roleDefinitionId, string principalId) { }
        public string PrincipalId { get { throw null; } }
        public string RoleDefinitionId { get { throw null; } }
    }
    public partial class RoleAssignmentPropertiesWithScope
    {
        internal RoleAssignmentPropertiesWithScope() { }
        public string PrincipalId { get { throw null; } }
        public string RoleDefinitionId { get { throw null; } }
        public string Scope { get { throw null; } }
    }
    public partial class RoleDefinition
    {
        internal RoleDefinition() { }
        public System.Collections.Generic.IReadOnlyList<string> AssignableScopes { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Security.KeyVault.Administration.Models.KeyVaultPermission> Permissions { get { throw null; } }
        public string RoleName { get { throw null; } }
        public string RoleType { get { throw null; } }
        public string Type { get { throw null; } }
    }
}
