namespace Azure.Security.KeyVault.Administration
{
    public partial class CreateOrUpdateRoleDefinitionOptions
    {
        public CreateOrUpdateRoleDefinitionOptions(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope) { }
        public CreateOrUpdateRoleDefinitionOptions(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, System.Guid roleDefinitionName) { }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.KeyVaultRoleScope> AssignableScopes { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.KeyVaultPermission> Permissions { get { throw null; } }
        public System.Guid RoleDefinitionName { get { throw null; } }
        public string RoleName { get { throw null; } set { } }
        public Azure.Security.KeyVault.Administration.KeyVaultRoleScope RoleScope { get { throw null; } }
    }
    public partial class KeyVaultAccessControlClient
    {
        protected KeyVaultAccessControlClient() { }
        public KeyVaultAccessControlClient(System.Uri vaultUri, Azure.Core.TokenCredential credential) { }
        public KeyVaultAccessControlClient(System.Uri vaultUri, Azure.Core.TokenCredential credential, Azure.Security.KeyVault.Administration.KeyVaultAdministrationClientOptions options) { }
        public virtual System.Uri VaultUri { get { throw null; } }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition> CreateOrUpdateRoleDefinition(Azure.Security.KeyVault.Administration.CreateOrUpdateRoleDefinitionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition> CreateOrUpdateRoleDefinition(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, System.Guid? roleDefinitionName = default(System.Guid?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition>> CreateOrUpdateRoleDefinitionAsync(Azure.Security.KeyVault.Administration.CreateOrUpdateRoleDefinitionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition>> CreateOrUpdateRoleDefinitionAsync(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, System.Guid? roleDefinitionName = default(System.Guid?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment> CreateRoleAssignment(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, string roleDefinitionId, string principalId, System.Guid? roleAssignmentName = default(System.Guid?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment>> CreateRoleAssignmentAsync(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, string roleDefinitionId, string principalId, System.Guid? roleAssignmentName = default(System.Guid?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRoleAssignment(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoleAssignmentAsync(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRoleDefinition(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, System.Guid roleDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoleDefinitionAsync(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, System.Guid roleDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment> GetRoleAssignment(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment>> GetRoleAssignmentAsync(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, string roleAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment> GetRoleAssignments(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment> GetRoleAssignmentsAsync(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition> GetRoleDefinition(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, System.Guid roleDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition>> GetRoleDefinitionAsync(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, System.Guid roleDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition> GetRoleDefinitions(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition> GetRoleDefinitionsAsync(Azure.Security.KeyVault.Administration.KeyVaultRoleScope roleScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Security.KeyVault.Administration.KeyVaultBackupOperation BackupOperation(Azure.Response response, Azure.Security.KeyVault.Administration.KeyVaultBackupClient client, string id, System.Uri blobContainerUri, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string errorMessage = null) { throw null; }
        public static Azure.Security.KeyVault.Administration.KeyVaultBackupResult BackupResult(System.Uri folderUri, System.DateTimeOffset startTime, System.DateTimeOffset endTime) { throw null; }
        public static Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment KeyVaultRoleAssignment(string id = null, string name = null, string type = null, Azure.Security.KeyVault.Administration.KeyVaultRoleAssignmentProperties properties = null) { throw null; }
        public static Azure.Security.KeyVault.Administration.KeyVaultRoleAssignmentProperties KeyVaultRoleAssignmentProperties(Azure.Security.KeyVault.Administration.KeyVaultRoleScope? scope = default(Azure.Security.KeyVault.Administration.KeyVaultRoleScope?), string roleDefinitionId = null, string principalId = null) { throw null; }
        public static Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition KeyVaultRoleDefinition(string id = null, string name = null, Azure.Security.KeyVault.Administration.KeyVaultRoleDefinitionType? type = default(Azure.Security.KeyVault.Administration.KeyVaultRoleDefinitionType?), string roleName = null, string description = null, Azure.Security.KeyVault.Administration.KeyVaultRoleType? roleType = default(Azure.Security.KeyVault.Administration.KeyVaultRoleType?), System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.KeyVaultPermission> permissions = null, System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.KeyVaultRoleScope> assignableScopes = null) { throw null; }
        public static Azure.Security.KeyVault.Administration.KeyVaultRestoreOperation RestoreOperation(Azure.Response response, Azure.Security.KeyVault.Administration.KeyVaultBackupClient client, string id, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string errorMessage = null) { throw null; }
        public static Azure.Security.KeyVault.Administration.KeyVaultRestoreResult RestoreResult(System.DateTimeOffset startTime, System.DateTimeOffset endTime) { throw null; }
        public static Azure.Security.KeyVault.Administration.KeyVaultRoleAssignment RoleAssignment(string id, string name, string type, Azure.Security.KeyVault.Administration.KeyVaultRoleAssignmentProperties properties) { throw null; }
        public static Azure.Security.KeyVault.Administration.KeyVaultRoleDefinition RoleDefinition(string id, string name, string type, string roleName, string description, string roleType, System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.KeyVaultPermission> permissions, System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.KeyVaultRoleScope> assignableScopes) { throw null; }
        public static Azure.Security.KeyVault.Administration.KeyVaultRestoreResult SelectiveKeyRestoreResult(System.DateTimeOffset startTime, System.DateTimeOffset endTime) { throw null; }
    }
    public partial class KeyVaultBackupClient
    {
        protected KeyVaultBackupClient() { }
        public KeyVaultBackupClient(System.Uri vaultUri, Azure.Core.TokenCredential credential) { }
        public KeyVaultBackupClient(System.Uri vaultUri, Azure.Core.TokenCredential credential, Azure.Security.KeyVault.Administration.KeyVaultAdministrationClientOptions options) { }
        public virtual System.Uri VaultUri { get { throw null; } }
        public virtual Azure.Security.KeyVault.Administration.KeyVaultBackupOperation StartBackup(System.Uri blobStorageUri, string sasToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Administration.KeyVaultBackupOperation> StartBackupAsync(System.Uri blobStorageUri, string sasToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Administration.KeyVaultRestoreOperation StartRestore(System.Uri folderUri, string sasToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Administration.KeyVaultRestoreOperation> StartRestoreAsync(System.Uri folderUri, string sasToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Security.KeyVault.Administration.KeyVaultSelectiveKeyRestoreOperation StartSelectiveKeyRestore(string keyName, System.Uri folderUri, string sasToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Security.KeyVault.Administration.KeyVaultSelectiveKeyRestoreOperation> StartSelectiveKeyRestoreAsync(string keyName, System.Uri folderUri, string sasToken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KeyVaultBackupOperation : Azure.Operation<Azure.Security.KeyVault.Administration.KeyVaultBackupResult>
    {
        protected KeyVaultBackupOperation() { }
        public KeyVaultBackupOperation(Azure.Security.KeyVault.Administration.KeyVaultBackupClient client, string id) { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public override Azure.Security.KeyVault.Administration.KeyVaultBackupResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultBackupResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultBackupResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class KeyVaultBackupResult
    {
        internal KeyVaultBackupResult() { }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public System.Uri FolderUri { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultDataAction : System.IEquatable<Azure.Security.KeyVault.Administration.KeyVaultDataAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultDataAction(string value) { throw null; }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction BackupHsmKeys { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction CreateHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction DecryptHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction DeleteHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction DeleteRoleAssignment { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction DownloadHsmSecurityDomain { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction EncryptHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction ExportHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction GetRoleAssignment { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction ImportHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction PurgeDeletedHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction ReadDeletedHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction ReadHsmBackupStatus { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction ReadHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction ReadHsmRestoreStatus { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction ReadHsmSecurityDomainStatus { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction ReadHsmSecurityDomainTransferKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction ReadRoleDefinition { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction RecoverDeletedHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction RestoreHsmKeys { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction SignHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction StartHsmBackup { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction StartHsmRestore { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction UnwrapHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction UploadHsmSecurityDomain { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction VerifyHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction WrapHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction WriteHsmKey { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultDataAction WriteRoleAssignment { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Administration.KeyVaultDataAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Administration.KeyVaultDataAction left, Azure.Security.KeyVault.Administration.KeyVaultDataAction right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Administration.KeyVaultDataAction (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Administration.KeyVaultDataAction left, Azure.Security.KeyVault.Administration.KeyVaultDataAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultPermission
    {
        public KeyVaultPermission() { }
        public System.Collections.Generic.IList<string> Actions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.KeyVaultDataAction> DataActions { get { throw null; } }
        public System.Collections.Generic.IList<string> NotActions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.KeyVaultDataAction> NotDataActions { get { throw null; } }
    }
    public partial class KeyVaultRestoreOperation : Azure.Operation<Azure.Security.KeyVault.Administration.KeyVaultRestoreResult>
    {
        protected KeyVaultRestoreOperation() { }
        public KeyVaultRestoreOperation(Azure.Security.KeyVault.Administration.KeyVaultBackupClient client, string id) { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public override Azure.Security.KeyVault.Administration.KeyVaultRestoreResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRestoreResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultRestoreResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class KeyVaultRestoreResult
    {
        internal KeyVaultRestoreResult() { }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
    }
    public partial class KeyVaultRoleAssignment
    {
        internal KeyVaultRoleAssignment() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Security.KeyVault.Administration.KeyVaultRoleAssignmentProperties Properties { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class KeyVaultRoleAssignmentProperties
    {
        internal KeyVaultRoleAssignmentProperties() { }
        public string PrincipalId { get { throw null; } }
        public string RoleDefinitionId { get { throw null; } }
        public Azure.Security.KeyVault.Administration.KeyVaultRoleScope? Scope { get { throw null; } }
    }
    public partial class KeyVaultRoleDefinition
    {
        public KeyVaultRoleDefinition() { }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.KeyVaultRoleScope> AssignableScopes { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Security.KeyVault.Administration.KeyVaultPermission> Permissions { get { throw null; } }
        public string RoleName { get { throw null; } set { } }
        public Azure.Security.KeyVault.Administration.KeyVaultRoleType? RoleType { get { throw null; } set { } }
        public Azure.Security.KeyVault.Administration.KeyVaultRoleDefinitionType? Type { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultRoleDefinitionType : System.IEquatable<Azure.Security.KeyVault.Administration.KeyVaultRoleDefinitionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultRoleDefinitionType(string value) { throw null; }
        public static Azure.Security.KeyVault.Administration.KeyVaultRoleDefinitionType MicrosoftAuthorizationRoleDefinitions { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Administration.KeyVaultRoleDefinitionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Administration.KeyVaultRoleDefinitionType left, Azure.Security.KeyVault.Administration.KeyVaultRoleDefinitionType right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Administration.KeyVaultRoleDefinitionType (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Administration.KeyVaultRoleDefinitionType left, Azure.Security.KeyVault.Administration.KeyVaultRoleDefinitionType right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultRoleType : System.IEquatable<Azure.Security.KeyVault.Administration.KeyVaultRoleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultRoleType(string value) { throw null; }
        public static Azure.Security.KeyVault.Administration.KeyVaultRoleType BuiltInRole { get { throw null; } }
        public static Azure.Security.KeyVault.Administration.KeyVaultRoleType CustomRole { get { throw null; } }
        public bool Equals(Azure.Security.KeyVault.Administration.KeyVaultRoleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Security.KeyVault.Administration.KeyVaultRoleType left, Azure.Security.KeyVault.Administration.KeyVaultRoleType right) { throw null; }
        public static implicit operator Azure.Security.KeyVault.Administration.KeyVaultRoleType (string value) { throw null; }
        public static bool operator !=(Azure.Security.KeyVault.Administration.KeyVaultRoleType left, Azure.Security.KeyVault.Administration.KeyVaultRoleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultSelectiveKeyRestoreOperation : Azure.Operation<Azure.Security.KeyVault.Administration.KeyVaultSelectiveKeyRestoreResult>
    {
        protected KeyVaultSelectiveKeyRestoreOperation() { }
        public KeyVaultSelectiveKeyRestoreOperation(Azure.Security.KeyVault.Administration.KeyVaultBackupClient client, string id) { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public override Azure.Security.KeyVault.Administration.KeyVaultSelectiveKeyRestoreResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultSelectiveKeyRestoreResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Security.KeyVault.Administration.KeyVaultSelectiveKeyRestoreResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class KeyVaultSelectiveKeyRestoreResult
    {
        internal KeyVaultSelectiveKeyRestoreResult() { }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
    }
}
