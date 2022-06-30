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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.Models.ValidateOperationResult> Validate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceLinker.Models.ValidateOperationResult>> ValidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceLinker.LinkerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceLinker.LinkerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceLinker.LinkerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceLinker.LinkerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LinkerResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public LinkerResourceData() { }
        public Azure.ResourceManager.ServiceLinker.Models.AuthInfoBase AuthInfo { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.ClientType? ClientType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public string SecretStoreKeyVaultId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType? SolutionType { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.TargetServiceBase TargetService { get { throw null; } set { } }
    }
    public static partial class ServiceLinkerExtensions
    {
        public static Azure.ResourceManager.ServiceLinker.LinkerResource GetLinkerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource> GetLinkerResource(this Azure.ResourceManager.ArmResource armResource, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceLinker.LinkerResource>> GetLinkerResourceAsync(this Azure.ResourceManager.ArmResource armResource, string linkerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.LinkerResourceCollection GetLinkerResources(this Azure.ResourceManager.ArmResource armResource) { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceLinker.Models
{
    public partial class AuthInfoBase
    {
        public AuthInfoBase() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthType : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.AuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.AuthType Secret { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.AuthType ServicePrincipalCertificate { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.AuthType ServicePrincipalSecret { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.AuthType SystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.AuthType UserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.AuthType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.AuthType left, Azure.ResourceManager.ServiceLinker.Models.AuthType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.AuthType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.AuthType left, Azure.ResourceManager.ServiceLinker.Models.AuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureKeyVaultProperties : Azure.ResourceManager.ServiceLinker.Models.AzureResourcePropertiesBase
    {
        public AzureKeyVaultProperties() { }
        public bool? ConnectAsKubernetesCsiDriver { get { throw null; } set { } }
    }
    public partial class AzureResource : Azure.ResourceManager.ServiceLinker.Models.TargetServiceBase
    {
        public AzureResource() { }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.AzureResourcePropertiesBase ResourceProperties { get { throw null; } set { } }
    }
    public partial class AzureResourcePropertiesBase
    {
        public AzureResourcePropertiesBase() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientType : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.ClientType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClientType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.ClientType Django { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.ClientType Dotnet { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.ClientType Go { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.ClientType Java { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.ClientType Nodejs { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.ClientType None { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.ClientType Php { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.ClientType Python { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.ClientType Ruby { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.ClientType SpringBoot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.ClientType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.ClientType left, Azure.ResourceManager.ServiceLinker.Models.ClientType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.ClientType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.ClientType left, Azure.ResourceManager.ServiceLinker.Models.ClientType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfluentBootstrapServer : Azure.ResourceManager.ServiceLinker.Models.TargetServiceBase
    {
        public ConfluentBootstrapServer() { }
        public string Endpoint { get { throw null; } set { } }
    }
    public partial class ConfluentSchemaRegistry : Azure.ResourceManager.ServiceLinker.Models.TargetServiceBase
    {
        public ConfluentSchemaRegistry() { }
        public string Endpoint { get { throw null; } set { } }
    }
    public partial class KeyVaultSecretReferenceSecretInfo : Azure.ResourceManager.ServiceLinker.Models.SecretInfoBase
    {
        public KeyVaultSecretReferenceSecretInfo() { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class KeyVaultSecretUriSecretInfo : Azure.ResourceManager.ServiceLinker.Models.SecretInfoBase
    {
        public KeyVaultSecretUriSecretInfo() { }
        public string Value { get { throw null; } set { } }
    }
    public partial class LinkerResourcePatch
    {
        public LinkerResourcePatch() { }
        public Azure.ResourceManager.ServiceLinker.Models.AuthInfoBase AuthInfo { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.ClientType? ClientType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public string SecretStoreKeyVaultId { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.VnetSolutionType? SolutionType { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.TargetServiceBase TargetService { get { throw null; } set { } }
    }
    public partial class SecretAuthInfo : Azure.ResourceManager.ServiceLinker.Models.AuthInfoBase
    {
        public SecretAuthInfo() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceLinker.Models.SecretInfoBase SecretInfo { get { throw null; } set { } }
    }
    public partial class SecretInfoBase
    {
        public SecretInfoBase() { }
    }
    public partial class ServicePrincipalCertificateAuthInfo : Azure.ResourceManager.ServiceLinker.Models.AuthInfoBase
    {
        public ServicePrincipalCertificateAuthInfo(string clientId, string principalId, string certificate) { }
        public string Certificate { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
    }
    public partial class ServicePrincipalSecretAuthInfo : Azure.ResourceManager.ServiceLinker.Models.AuthInfoBase
    {
        public ServicePrincipalSecretAuthInfo(string clientId, string principalId, string secret) { }
        public string ClientId { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
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
    public partial class SystemAssignedIdentityAuthInfo : Azure.ResourceManager.ServiceLinker.Models.AuthInfoBase
    {
        public SystemAssignedIdentityAuthInfo() { }
    }
    public partial class TargetServiceBase
    {
        public TargetServiceBase() { }
    }
    public partial class UserAssignedIdentityAuthInfo : Azure.ResourceManager.ServiceLinker.Models.AuthInfoBase
    {
        public UserAssignedIdentityAuthInfo() { }
        public string ClientId { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class ValidateOperationResult
    {
        internal ValidateOperationResult() { }
        public Azure.ResourceManager.ServiceLinker.Models.AuthType? AuthType { get { throw null; } }
        public bool? IsConnectionAvailable { get { throw null; } }
        public string LinkerName { get { throw null; } }
        public System.DateTimeOffset? ReportEndTimeUtc { get { throw null; } }
        public System.DateTimeOffset? ReportStartTimeUtc { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string SourceId { get { throw null; } }
        public string Status { get { throw null; } }
        public string TargetId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ServiceLinker.Models.ValidationResultItem> ValidationDetail { get { throw null; } }
    }
    public partial class ValidationResultItem
    {
        internal ValidationResultItem() { }
        public string Description { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ServiceLinker.Models.ValidationResultStatus? Result { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationResultStatus : System.IEquatable<Azure.ResourceManager.ServiceLinker.Models.ValidationResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.ServiceLinker.Models.ValidationResultStatus Failure { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.ValidationResultStatus Success { get { throw null; } }
        public static Azure.ResourceManager.ServiceLinker.Models.ValidationResultStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceLinker.Models.ValidationResultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceLinker.Models.ValidationResultStatus left, Azure.ResourceManager.ServiceLinker.Models.ValidationResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceLinker.Models.ValidationResultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceLinker.Models.ValidationResultStatus left, Azure.ResourceManager.ServiceLinker.Models.ValidationResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValueSecretInfo : Azure.ResourceManager.ServiceLinker.Models.SecretInfoBase
    {
        public ValueSecretInfo() { }
        public string Value { get { throw null; } set { } }
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
