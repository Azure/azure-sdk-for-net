namespace Azure.ResourceManager.ExtendedLocation
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.ExtendedLocation.CustomLocation GetCustomLocation(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class CustomLocation : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CustomLocation() { }
        public virtual Azure.ResourceManager.ExtendedLocation.CustomLocationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocation.CustomLocation> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocation.CustomLocation>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocation.CustomLocation> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocation.CustomLocation>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ExtendedLocation.Models.EnabledResourceType> GetEnabledResourceTypes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ExtendedLocation.Models.EnabledResourceType> GetEnabledResourceTypesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocation.CustomLocation> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocation.CustomLocation>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocation.CustomLocation> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocation.CustomLocation>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocation.CustomLocation> Update(Azure.ResourceManager.ExtendedLocation.Models.PatchableCustomLocationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocation.CustomLocation>> UpdateAsync(Azure.ResourceManager.ExtendedLocation.Models.PatchableCustomLocationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CustomLocationCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ExtendedLocation.CustomLocation>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ExtendedLocation.CustomLocation>, System.Collections.IEnumerable
    {
        protected CustomLocationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ExtendedLocation.CustomLocation> CreateOrUpdate(bool waitForCompletion, string resourceName, Azure.ResourceManager.ExtendedLocation.CustomLocationData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ExtendedLocation.CustomLocation>> CreateOrUpdateAsync(bool waitForCompletion, string resourceName, Azure.ResourceManager.ExtendedLocation.CustomLocationData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocation.CustomLocation> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ExtendedLocation.CustomLocation> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ExtendedLocation.CustomLocation> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocation.CustomLocation>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ExtendedLocation.CustomLocation> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ExtendedLocation.CustomLocation>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ExtendedLocation.CustomLocation> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ExtendedLocation.CustomLocation>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ExtendedLocation.CustomLocation> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ExtendedLocation.CustomLocation>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CustomLocationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CustomLocationData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ExtendedLocation.Models.CustomLocationPropertiesAuthentication Authentication { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ClusterExtensionIds { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public string HostResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ExtendedLocation.Models.HostType? HostType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.ExtendedLocation.CustomLocationCollection GetCustomLocations(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.ExtendedLocation.CustomLocation> GetCustomLocations(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ExtendedLocation.CustomLocation> GetCustomLocationsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class TenantExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.ExtendedLocation.Models.CustomLocationOperation> GetOperationsCustomLocations(this Azure.ResourceManager.Resources.Tenant tenant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ExtendedLocation.Models.CustomLocationOperation> GetOperationsCustomLocationsAsync(this Azure.ResourceManager.Resources.Tenant tenant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ExtendedLocation.Models
{
    public partial class CustomLocationOperation
    {
        internal CustomLocationOperation() { }
        public string Description { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Origin { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class CustomLocationPropertiesAuthentication
    {
        public CustomLocationPropertiesAuthentication() { }
        public string Type { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class EnabledResourceType : Azure.ResourceManager.Models.ResourceData
    {
        public EnabledResourceType() { }
        public string ClusterExtensionId { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ExtendedLocation.Models.EnabledResourceTypePropertiesTypesMetadataItem> TypesMetadata { get { throw null; } }
    }
    public partial class EnabledResourceTypePropertiesTypesMetadataItem
    {
        public EnabledResourceTypePropertiesTypesMetadataItem() { }
        public string ApiVersion { get { throw null; } set { } }
        public string ResourceProviderNamespace { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostType : System.IEquatable<Azure.ResourceManager.ExtendedLocation.Models.HostType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostType(string value) { throw null; }
        public static Azure.ResourceManager.ExtendedLocation.Models.HostType Kubernetes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ExtendedLocation.Models.HostType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ExtendedLocation.Models.HostType left, Azure.ResourceManager.ExtendedLocation.Models.HostType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ExtendedLocation.Models.HostType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ExtendedLocation.Models.HostType left, Azure.ResourceManager.ExtendedLocation.Models.HostType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PatchableCustomLocationData
    {
        public PatchableCustomLocationData() { }
        public Azure.ResourceManager.ExtendedLocation.Models.CustomLocationPropertiesAuthentication Authentication { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ClusterExtensionIds { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public string HostResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ExtendedLocation.Models.HostType? HostType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
