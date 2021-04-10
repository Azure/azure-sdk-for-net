namespace Azure.Security.KeyVault.Administration
{
    public partial class BackupOperation : Azure.Operation<Azure.Security.KeyVault.Administration.BackupResult>
    {
        protected BackupOperation() { }
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
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition> CreateOrUpdateRoleDefinition(string roleDefinitionDescription, Azure.Security.KeyVault.Administration.KeyVaultPermission permissions, Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope roleScope = default(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope), System.Guid? roleDefinitionName = default(System.Guid?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition>> CreateOrUpdateRoleDefinitionAsync(string roleDefinitionDescription, Azure.Security.KeyVault.Administration.KeyVaultPermission permissions, Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope roleScope = default(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope), System.Guid? roleDefinitionName = default(System.Guid?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment> CreateRoleAssignment(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope roleScope, string roleDefinitionId, string principalId, System.Guid? roleAssignmentName = default(System.Guid?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment>> CreateRoleAssignmentAsync(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope roleScope, string roleDefinitionId, string principalId, System.Guid? roleAssignmentName = default(System.Guid?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment> DeleteRoleAssignment(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope roleScope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment>> DeleteRoleAssignmentAsync(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope roleScope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition> DeleteRoleDefinition(System.Guid roleDefinitionName, Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition>> DeleteRoleDefinitionAsync(System.Guid roleDefinitionName, Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment> GetRoleAssignment(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope roleScope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment>> GetRoleAssignmentAsync(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope roleScope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment> GetRoleAssignments(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment> GetRoleAssignmentsAsync(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition> GetRoleDefinition(System.Guid roleDefinitionName, Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition>> GetRoleDefinitionAsync(System.Guid roleDefinitionName, Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition> GetRoleDefinitions(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition> GetRoleDefinitionsAsync(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KeyVaultAdministrationClientOptions : Azure.Core.ClientOptions
    {
        public KeyVaultAdministrationClientOptions(Azure.Security.KeyVault.Administration.KeyVaultAdministrationClientOptions.ServiceVersion version = Azure.Security.KeyVault.Administration.KeyVaultAdministrationClientOptions.ServiceVersion.V7_2) { }
        public Azure.Security.KeyVault.Administration.KeyVaultAdministrationClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V7_2 = 1,
        }
    }
    public static partial class KeyVaultAdministrationModelFactory
    {
        public static Azure.Security.KeyVault.Administration.BackupOperation BackupOperation(Azure.Response response, Azure.Security.KeyVault.Administration.KeyVaultBackupClient client, string id, System.Uri blobContainerUri, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string errorMessage = null) { throw null; }
        public static Azure.Security.KeyVault.Administration.BackupResult BackupResult(System.Uri folderUri, System.DateTimeOffset startTime, System.DateTimeOffset endTime) { throw null; }
        public static Azure.Security.KeyVault.Administration.RestoreOperation RestoreOperation(Azure.Response response, Azure.Security.KeyVault.Administration.KeyVaultBackupClient client, string id, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string errorMessage = null) { throw null; }
        public static Azure.Security.KeyVault.Administration.RestoreResult RestoreResult(System.DateTimeOffset startTime, System.DateTimeOffset endTime) { throw null; }
        public static Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment RoleAssignment(string id, string name, string type, Azure.Security.KeyVault.Administration.KeyVaultRoleAssignmentPropertiesWithScope properties) { throw null; }
        public static Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition RoleDefinition(string id, string name, string type, string roleName, string description, string roleType, System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.KeyVaultPermission> permissions, System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope> assignableScopes) { throw null; }
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
        public System.Collections.Generic.IList<string> Actions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction> DataActions { get { throw null; } }
        public System.Collections.Generic.IList<string> NotActions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction> NotDataActions { get { throw null; } }
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
        public Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope? Scope { get { throw null; } }
    }
    public partial class KeyVaultRoleDefinition
    {
        public KeyVaultRoleDefinition() { }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope> AssignableScopes { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.KeyVaultPermission> Permissions { get { throw null; } }
        public string RoleName { get { throw null; } set { } }
        public Azure.Security.KeyVault.Administration.Models.KeyVaultRoleType? RoleType { get { throw null; } set { } }
        public Azure.Security.KeyVault.Administration.Models.KeyVaultRoleDefinitionType? Type { get { throw null; } }
    }
    public partial class RestoreOperation : Azure.Operation<Azure.Security.KeyVault.Administration.RestoreResult>
    {
        protected RestoreOperation() { }
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
        protected SelectiveKeyRestoreOperation() { }
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
namespace Azure.Security.KeyVault.Administration.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultDataAction : System.IEquatable<Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultDataAction(string value) { throw null; }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction BackupHsmKeys { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction CreateHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction DecryptHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction DeleteHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction DeleteRoleAssignment { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction DownloadHsmSecurityDomain { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction EncryptHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction ExportHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction GetRoleAssignment { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction ImportHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction PurgeDeletedHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction ReadDeletedHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction ReadHsmBackupStatus { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction ReadHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction ReadHsmRestoreStatus { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction ReadHsmSecurityDomainStatus { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction ReadHsmSecurityDomainTransferKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction ReadRoleDefinition { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction RecoverDeletedHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction RestoreHsmKeys { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction SignHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction StartHsmBackup { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction StartHsmRestore { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction UnwrapHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction UploadHsmSecurityDomain { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction VerifyHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction WrapHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction WriteHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction WriteRoleAssignment { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction left, Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction left, Azure.Security.KeyVault.Administration.Models.KeyVaultDataAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultRoleDefinitionType : System.IEquatable<Azure.Security.KeyVault.Administration.Models.KeyVaultRoleDefinitionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultRoleDefinitionType(string value) { throw null; }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultRoleDefinitionType MicrosoftAuthorizationRoleDefinitions { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleDefinitionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleDefinitionType left, Azure.Security.KeyVault.Administration.Models.KeyVaultRoleDefinitionType right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Administration.Models.KeyVaultRoleDefinitionType (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleDefinitionType left, Azure.Security.KeyVault.Administration.Models.KeyVaultRoleDefinitionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultRoleScope : System.IEquatable<Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultRoleScope(string value) { throw null; }
        public KeyVaultRoleScope(System.Uri resourceId) { throw null; }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope Global { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope Keys { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope left, Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope left, Azure.Security.KeyVault.Administration.Models.KeyVaultRoleScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultRoleType : System.IEquatable<Azure.Security.KeyVault.Administration.Models.KeyVaultRoleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultRoleType(string value) { throw null; }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultRoleType BuiltInRole { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.Models.KeyVaultRoleType CustomRole { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleType left, Azure.Security.KeyVault.Administration.Models.KeyVaultRoleType right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Administration.Models.KeyVaultRoleType (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Administration.Models.KeyVaultRoleType left, Azure.Security.KeyVault.Administration.Models.KeyVaultRoleType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
