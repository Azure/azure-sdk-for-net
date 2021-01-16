namespace Azure.Security.KeyVault.Administration
{
    public partial class BackupOperation : Azure.Operation<Azure.Security.KeyVault.Administration.BackupResult>
    {
        public BackupOperation(Azure.Security.KeyVault.Administration.KeyVaultBackupClient client, string id) { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public override Azure.Security.KeyVault.Administration.BackupResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Administration.BackupResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Administration.BackupResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class BackupResult
    {
        internal BackupResult() { }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public System.Uri FolderUri { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
    }
    public partial class KeyVaultAccessControlClient
    {
        protected KeyVaultAccessControlClient() { }
        public KeyVaultAccessControlClient(System.Uri vaultUri, Azure.Core.TokenCredential credential) { }
        public KeyVaultAccessControlClient(System.Uri vaultUri, Azure.Core.TokenCredential credential, Azure.Security.KeyVault.Administration.KeyVaultAdministrationClientOptions options) { }
        public virtual System.Uri VaultUri { get { throw null; } }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment> CreateRoleAssignment(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, string roleDefinitionId, string principalId, System.Guid? roleAssignmentName = default(System.Guid?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment>> CreateRoleAssignmentAsync(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, string roleDefinitionId, string principalId, System.Guid? roleAssignmentName = default(System.Guid?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment> DeleteRoleAssignment(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment>> DeleteRoleAssignmentAsync(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment> GetRoleAssignment(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment>> GetRoleAssignmentAsync(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment> GetRoleAssignments(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment> GetRoleAssignmentsAsync(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition> GetRoleDefinitions(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition> GetRoleDefinitionsAsync(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KeyVaultAdministrationClientOptions : Azure.Core.ClientOptions
    {
        public KeyVaultAdministrationClientOptions(Azure.Security.KeyVault.Administration.KeyVaultAdministrationClientOptions.ServiceVersion version = Azure.Security.KeyVault.Administration.KeyVaultAdministrationClientOptions.ServiceVersion.V7_2_Preview) { }
        public Azure.Security.KeyVault.Administration.KeyVaultAdministrationClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V7_2_Preview = 1,
        }
    }
    public static partial class KeyVaultAdministrationModelFactory
    {
        public static Azure.Security.KeyVault.Administration.BackupOperation BackupOperation(Azure.Response response, Azure.Security.KeyVault.Administration.KeyVaultBackupClient client, string id, System.Uri blobContainerUri, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string errorMessage = null) { throw null; }
        public static Azure.Security.KeyVault.Administration.BackupResult BackupResult(System.Uri folderUri, System.DateTimeOffset startTime, System.DateTimeOffset endTime) { throw null; }
        public static Azure.Security.KeyVault.Administration.RestoreOperation RestoreOperation(Azure.Response response, Azure.Security.KeyVault.Administration.KeyVaultBackupClient client, string id, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string errorMessage = null) { throw null; }
        public static Azure.Security.KeyVault.Administration.RestoreResult RestoreResult(System.DateTimeOffset startTime, System.DateTimeOffset endTime) { throw null; }
        public static Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment RoleAssignment(string id, string name, string type, Azure.Security.KeyVault.Administration.KeyVaultRoleAssignmentPropertiesWithScope properties) { throw null; }
        public static Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition RoleDefinition(string id, string name, string type, string roleName, string description, string roleType, System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.KeyVaultPermission> permissions, System.Collections.Generic.IList<string> assignableScopes) { throw null; }
        public static Azure.Security.KeyVault.Administration.RestoreResult SelectiveKeyRestoreResult(System.DateTimeOffset startTime, System.DateTimeOffset endTime) { throw null; }
    }
    public partial class KeyVaultBackupClient
    {
        protected KeyVaultBackupClient() { }
        public KeyVaultBackupClient(System.Uri vaultUri, Azure.Core.TokenCredential credential) { }
        public KeyVaultBackupClient(System.Uri vaultUri, Azure.Core.TokenCredential credential, Azure.Security.KeyVault.Administration.KeyVaultAdministrationClientOptions options) { }
        public virtual System.Uri VaultUri { get { throw null; } }
        public virtual Azure.Security.KeyVault.Administration.BackupOperation StartBackup(System.Uri blobStorageUri, string sasToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Administration.BackupOperation> StartBackupAsync(System.Uri blobStorageUri, string sasToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Administration.RestoreOperation StartRestore(System.Uri folderUri, string sasToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Administration.RestoreOperation> StartRestoreAsync(System.Uri folderUri, string sasToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Administration.SelectiveKeyRestoreOperation StartSelectiveRestore(string keyName, System.Uri folderUri, string sasToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Administration.SelectiveKeyRestoreOperation> StartSelectiveRestoreAsync(string keyName, System.Uri folderUri, string sasToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KeyVaultPermission
    {
        public KeyVaultPermission() { }
        public System.Collections.Generic.IList<string> AllowedActions { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedDataActions { get { throw null; } }
        public System.Collections.Generic.IList<string> DeniedActions { get { throw null; } }
        public System.Collections.Generic.IList<string> DeniedDataActions { get { throw null; } }
    }
    public partial class KeyVaultRoleAssignment
    {
        internal KeyVaultRoleAssignment() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Security.KeyVault.Administration.KeyVaultRoleAssignmentPropertiesWithScope Properties { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class KeyVaultRoleAssignmentPropertiesWithScope
    {
        internal KeyVaultRoleAssignmentPropertiesWithScope() { }
        public string PrincipalId { get { throw null; } }
        public string RoleDefinitionId { get { throw null; } }
        public string Scope { get { throw null; } }
    }
    public partial class KeyVaultRoleDefinition
    {
        public KeyVaultRoleDefinition() { }
        public System.Collections.Generic.IList<string> AssignableScopes { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.KeyVaultPermission> Permissions { get { throw null; } }
        public string RoleName { get { throw null; } set { } }
        public string RoleType { get { throw null; } set { } }
        public string Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultRoleScope : System.IEquatable<Azure.Security.KeyVault.Administration.KeyVaultRoleScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultRoleScope(string value) { throw null; }
        public KeyVaultRoleScope(System.Uri resourceId) { throw null; }
        public static Azure.Security.KeyVault.Administration.KeyVaultRoleScope Global { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultRoleScope Keys { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Administration.KeyVaultRoleScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Administration.KeyVaultRoleScope left, Azure.Security.KeyVault.Administration.KeyVaultRoleScope right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Administration.KeyVaultRoleScope (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Administration.KeyVaultRoleScope left, Azure.Security.KeyVault.Administration.KeyVaultRoleScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestoreOperation : Azure.Operation<Azure.Security.KeyVault.Administration.RestoreResult>
    {
        public RestoreOperation(Azure.Security.KeyVault.Administration.KeyVaultBackupClient client, string id) { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public override Azure.Security.KeyVault.Administration.RestoreResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Administration.RestoreResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Administration.RestoreResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class RestoreResult
    {
        internal RestoreResult() { }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
    }
    public partial class SelectiveKeyRestoreOperation : Azure.Operation<Azure.Security.KeyVault.Administration.SelectiveKeyRestoreResult>
    {
        public SelectiveKeyRestoreOperation(Azure.Security.KeyVault.Administration.KeyVaultBackupClient client, string id) { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public override Azure.Security.KeyVault.Administration.SelectiveKeyRestoreResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Administration.SelectiveKeyRestoreResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Administration.SelectiveKeyRestoreResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class SelectiveKeyRestoreResult
    {
        internal SelectiveKeyRestoreResult() { }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
    }
}
