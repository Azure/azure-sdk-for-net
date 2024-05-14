namespace Azure.ResourceManager.ServiceLinker
{
    public partial class LinkerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LinkerResource() { }
        public virtual Azure.ResourceManager.ServiceLinker.LinkerResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string linkerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult> GetConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult>> GetConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.LinkerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.LinkerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ServiceLinker.Models.LinkerResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult> Validate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult>> ValidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LinkerResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceLinker.LinkerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.LinkerResource>, System.Collections.IEnumerable
    {
        protected LinkerResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.LinkerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string linkerName, Azure.ResourceManager.ServiceLinker.LinkerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.LinkerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string linkerName, Azure.ResourceManager.ServiceLinker.LinkerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource> Get(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceLinker.LinkerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceLinker.LinkerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource>> GetAsync(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceLinker.LinkerResource> GetIfExists(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceLinker.LinkerResource>> GetIfExistsAsync(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceLinker.LinkerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceLinker.LinkerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceLinker.LinkerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.LinkerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LinkerResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public LinkerResourceData() { }
        public Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo AuthInfo { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerClientType? ClientType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SecretStoreKeyVaultId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType? SolutionType { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo TargetService { get { throw null; } set { } }
    }
    public static partial class ServiceLinkerExtensions
    {
        public static Azure.ResourceManager.ServiceLinker.LinkerResource GetLinkerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource> GetLinkerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource> GetLinkerResource(this Azure.ResourceManager.ArmResource armResource, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource>> GetLinkerResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource>> GetLinkerResourceAsync(this Azure.ResourceManager.ArmResource armResource, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.LinkerResourceCollection GetLinkerResources(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.LinkerResourceCollection GetLinkerResources(this Azure.ResourceManager.ArmResource armResource) { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceLinker.Mocking
{
    public partial class MockableServiceLinkerArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceLinkerArmClient() { }
        public virtual Azure.ResourceManager.ServiceLinker.LinkerResource GetLinkerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource> GetLinkerResource(Azure.Core.ResourceIdentifier scope, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource>> GetLinkerResourceAsync(Azure.Core.ResourceIdentifier scope, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceLinker.LinkerResourceCollection GetLinkerResources(Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class MockableServiceLinkerArmResource : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceLinkerArmResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource> GetLinkerResource(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource>> GetLinkerResourceAsync(string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceLinker.LinkerResourceCollection GetLinkerResources() { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceLinker.Models
{
    public static partial class ArmServiceLinkerModelFactory
    {
        public static Azure.ResourceManager.ServiceLinker.LinkerResourceData LinkerResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo targetService = null, Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo authInfo = null, Azure.ResourceManager.ServiceLinker.Models.LinkerClientType? clientType = default(Azure.ResourceManager.ServiceLinker.Models.LinkerClientType?), string provisioningState = null, Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType? solutionType = default(Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType?), Azure.Core.ResourceIdentifier secretStoreKeyVaultId = null, string scope = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerValidateOperationResult LinkerValidateOperationResult(Azure.Core.ResourceIdentifier resourceId = null, string status = null, string linkerName = null, bool? isConnectionAvailable = default(bool?), System.DateTimeOffset? reportStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? reportEndOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier sourceId = null, Azure.Core.ResourceIdentifier targetId = null, Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType? authType = default(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultItemInfo> validationDetail = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultItemInfo LinkerValidationResultItemInfo(string name = null, string description = null, Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus? result = default(Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus?), string errorMessage = null, string errorCode = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration SourceConfiguration(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.SourceConfigurationResult SourceConfigurationResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration> configurations = null) { throw null; }
    }
    public abstract partial class AuthBaseInfo
    {
        protected AuthBaseInfo() { }
    }
    public partial class AzureKeyVaultProperties : Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties
    {
        public AzureKeyVaultProperties() { }
        public bool? DoesConnectAsKubernetesCsiDriver { get { throw null; } set { } }
    }
    public abstract partial class AzureResourceBaseProperties
    {
        protected AzureResourceBaseProperties() { }
    }
    public partial class AzureResourceInfo : Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo
    {
        public AzureResourceInfo() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.AzureResourceBaseProperties ResourceProperties { get { throw null; } set { } }
    }
    public partial class ConfluentBootstrapServerInfo : Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo
    {
        public ConfluentBootstrapServerInfo() { }
        public string Endpoint { get { throw null; } set { } }
    }
    public partial class ConfluentSchemaRegistryInfo : Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo
    {
        public ConfluentSchemaRegistryInfo() { }
        public string Endpoint { get { throw null; } set { } }
    }
    public partial class KeyVaultSecretReferenceSecretInfo : Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo
    {
        public KeyVaultSecretReferenceSecretInfo() { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class KeyVaultSecretUriSecretInfo : Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo
    {
        public KeyVaultSecretUriSecretInfo() { }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkerAuthType : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkerAuthType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType Secret { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType ServicePrincipalCertificate { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType ServicePrincipalSecret { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType SystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType UserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType left, Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType left, Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkerClientType : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.LinkerClientType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkerClientType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType Django { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType Dotnet { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType Go { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType Java { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType Nodejs { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType None { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType Php { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType Python { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType Ruby { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerClientType SpringBoot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.LinkerClientType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.LinkerClientType left, Azure.ResourceManager.ServiceLinker.Models.LinkerClientType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerClientType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.LinkerClientType left, Azure.ResourceManager.ServiceLinker.Models.LinkerClientType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinkerResourcePatch
    {
        public LinkerResourcePatch() { }
        public Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo AuthInfo { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerClientType? ClientType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SecretStoreKeyVaultId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType? SolutionType { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.TargetServiceBaseInfo TargetService { get { throw null; } set { } }
    }
    public partial class LinkerValidateOperationResult
    {
        internal LinkerValidateOperationResult() { }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerAuthType? AuthType { get { throw null; } }
        public bool? IsConnectionAvailable { get { throw null; } }
        public string LinkerName { get { throw null; } }
        public System.DateTimeOffset? ReportEndOn { get { throw null; } }
        public System.DateTimeOffset? ReportStartOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceId { get { throw null; } }
        public string Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultItemInfo> ValidationDetail { get { throw null; } }
    }
    public partial class LinkerValidationResultItemInfo
    {
        internal LinkerValidationResultItemInfo() { }
        public string Description { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus? Result { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkerValidationResultStatus : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkerValidationResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus Failure { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus Success { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus left, Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus left, Azure.ResourceManager.ServiceLinker.Models.LinkerValidationResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RawValueSecretInfo : Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo
    {
        public RawValueSecretInfo() { }
        public string Value { get { throw null; } set { } }
    }
    public partial class SecretAuthInfo : Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo
    {
        public SecretAuthInfo() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.SecretBaseInfo SecretInfo { get { throw null; } set { } }
    }
    public abstract partial class SecretBaseInfo
    {
        protected SecretBaseInfo() { }
    }
    public partial class ServicePrincipalCertificateAuthInfo : Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo
    {
        public ServicePrincipalCertificateAuthInfo(string clientId, System.Guid principalId, string certificate) { }
        public string Certificate { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public System.Guid PrincipalId { get { throw null; } set { } }
    }
    public partial class ServicePrincipalSecretAuthInfo : Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo
    {
        public ServicePrincipalSecretAuthInfo(string clientId, System.Guid principalId, string secret) { }
        public string ClientId { get { throw null; } set { } }
        public System.Guid PrincipalId { get { throw null; } set { } }
        public string Secret { get { throw null; } set { } }
    }
    public partial class SourceConfiguration
    {
        internal SourceConfiguration() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class SourceConfigurationResult
    {
        internal SourceConfigurationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ServiceLinker.Models.SourceConfiguration> Configurations { get { throw null; } }
    }
    public partial class SystemAssignedIdentityAuthInfo : Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo
    {
        public SystemAssignedIdentityAuthInfo() { }
    }
    public abstract partial class TargetServiceBaseInfo
    {
        protected TargetServiceBaseInfo() { }
    }
    public partial class UserAssignedIdentityAuthInfo : Azure.ResourceManager.ServiceLinker.Models.AuthBaseInfo
    {
        public UserAssignedIdentityAuthInfo() { }
        public string ClientId { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VnetSolutionType : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VnetSolutionType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType PrivateLink { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType ServiceEndpoint { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType left, Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType left, Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
