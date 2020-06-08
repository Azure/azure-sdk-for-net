namespace Azure.Security.KeyVault.Administration
{
    public partial class AccessControlClient
    {
        protected AccessControlClient() { }
        public AccessControlClient(System.Uri vaultUri, Azure.Core.TokenCredential credential) { }
        public AccessControlClient(System.Uri vaultUri, Azure.Core.TokenCredential credential, Azure.Security.KeyVault.Administration.AccessControlClientOptions options) { }
        public System.Uri VaultUri { get { throw null; } }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.Models.RoleAssignment> CreateRoleAssignment(string scope, Azure.Security.KeyVault.Administration.Models.RoleAssignmentProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.Models.RoleAssignment> CreateRoleAssignment(System.Uri scope, Azure.Security.KeyVault.Administration.Models.RoleAssignmentProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.Models.RoleAssignment>> CreateRoleAssignmentAsync(string scope, Azure.Security.KeyVault.Administration.Models.RoleAssignmentProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.Models.RoleAssignment>> CreateRoleAssignmentAsync(System.Uri scope, Azure.Security.KeyVault.Administration.Models.RoleAssignmentProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.Models.RoleAssignment> DeleteRoleAssignment(string scope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.Models.RoleAssignment> DeleteRoleAssignment(System.Uri scope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.Models.RoleAssignment>> DeleteRoleAssignmentAsync(string scope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.Models.RoleAssignment>> DeleteRoleAssignmentAsync(System.Uri scope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.Models.RoleAssignment> GetRoleAssignment(string scope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.Models.RoleAssignment>> GetRoleAssignmentAsync(string scope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Administration.Models.RoleAssignment> GetRoleAssignments(string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Administration.Models.RoleAssignment> GetRoleAssignments(System.Uri scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Administration.Models.RoleAssignment> GetRoleAssignmentsAsync(string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Administration.Models.RoleAssignment> GetRoleAssignmentsAsync(System.Uri scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Administration.Models.RoleDefinition> GetRoleDefinitions(string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Administration.Models.RoleDefinition> GetRoleDefinitions(System.Uri scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Administration.Models.RoleDefinition> GetRoleDefinitionsAsync(string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Administration.Models.RoleDefinition> GetRoleDefinitionsAsync(System.Uri scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AccessControlClientOptions : Azure.Core.ClientOptions
    {
        public AccessControlClientOptions(Azure.Security.KeyVault.Administration.AccessControlClientOptions.ServiceVersion version = Azure.Security.KeyVault.Administration.AccessControlClientOptions.ServiceVersion.V7_2_Preview) { }
        public Azure.Security.KeyVault.Administration.AccessControlClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V7_2_Preview = 1,
        }
    }
    public static partial class KeyVaultAdministrationConstants
    {
    }
}
namespace Azure.Security.KeyVault.Administration.Models
{
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
    public partial class RoleAssignmentListResult
    {
        internal RoleAssignmentListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Security.KeyVault.Administration.Models.RoleAssignment> Value { get { throw null; } }
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
    public partial class RoleDefinitionListResult
    {
        internal RoleDefinitionListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Security.KeyVault.Administration.Models.RoleDefinition> Value { get { throw null; } }
    }
}
