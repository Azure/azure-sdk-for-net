namespace Azure.ResourceManager.DevOpsInfrastructure
{
    public static partial class DevOpsInfrastructureExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.Models.ImageVersion> GetImageVersionsByImage(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.Models.ImageVersion> GetImageVersionsByImageAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> GetPool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.PoolResource>> GetPoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.PoolResource GetPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.PoolCollection GetPools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> GetPools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> GetPoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSku> GetSkusByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSku> GetSkusByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.Models.Quota> UsagesSubscriptionUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.Models.Quota> UsagesSubscriptionUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevOpsInfrastructure.PoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.PoolResource>, System.Collections.IEnumerable
    {
        protected PoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.DevOpsInfrastructure.PoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevOpsInfrastructure.PoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.DevOpsInfrastructure.PoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> Get(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.PoolResource>> GetAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> GetIfExists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevOpsInfrastructure.PoolResource>> GetIfExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevOpsInfrastructure.PoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.PoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.PoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.PoolData>
    {
        public PoolData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.PoolProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.DevOpsInfrastructure.PoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.PoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.PoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.PoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.PoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.PoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.PoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.PoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.PoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PoolResource() { }
        public virtual Azure.ResourceManager.DevOpsInfrastructure.PoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.PoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string poolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.PoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObject> GetResourceDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObject> GetResourceDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.PoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.PoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevOpsInfrastructure.PoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.PoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.PoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.PoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.PoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.PoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.PoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevOpsInfrastructure.PoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevOpsInfrastructure.PoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevOpsInfrastructure.PoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DevOpsInfrastructure.Mocking
{
    public partial class MockableDevOpsInfrastructureArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDevOpsInfrastructureArmClient() { }
        public virtual Azure.ResourceManager.DevOpsInfrastructure.PoolResource GetPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDevOpsInfrastructureResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDevOpsInfrastructureResourceGroupResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.Models.ImageVersion> GetImageVersionsByImage(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.Models.ImageVersion> GetImageVersionsByImageAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> GetPool(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.PoolResource>> GetPoolAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevOpsInfrastructure.PoolCollection GetPools() { throw null; }
    }
    public partial class MockableDevOpsInfrastructureSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDevOpsInfrastructureSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> GetPools(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.PoolResource> GetPoolsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSku> GetSkusByLocation(string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSku> GetSkusByLocationAsync(string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.Models.Quota> UsagesSubscriptionUsages(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.Models.Quota> UsagesSubscriptionUsagesAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DevOpsInfrastructure.Models
{
    public abstract partial class AgentProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AgentProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AgentProfile>
    {
        protected AgentProfile() { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions ResourcePredictions { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile ResourcePredictionsProfile { get { throw null; } set { } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.AgentProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AgentProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AgentProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.AgentProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AgentProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AgentProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AgentProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmDevOpsInfrastructureModelFactory
    {
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ImageVersion ImageVersion(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string version = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentity ManagedServiceIdentity(System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentityType type = default(Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentityType), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.PoolData PoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevOpsInfrastructure.Models.PoolProperties properties = null, Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.Quota Quota(Azure.Core.ResourceIdentifier id = null, string unit = null, long currentValue = (long)0, long limit = (long)0) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObject ResourceDetailsObject(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObjectProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObjectProperties ResourceDetailsObjectProperties(Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus status = default(Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus), string image = null, string imageVersion = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSku ResourceSku(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities ResourceSkuCapabilities(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo ResourceSkuLocationInfo(string location = null, System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails> zoneDetails = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuProperties ResourceSkuProperties(string resourceType = null, string tier = null, string size = null, string family = null, System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo> locationInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities> capabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictions> restrictions = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionInfo ResourceSkuRestrictionInfo(System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictions ResourceSkuRestrictions(Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsType? type = default(Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsType?), System.Collections.Generic.IEnumerable<string> values = null, Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionInfo restrictionInfo = null, Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsReasonCode? reasonCode = default(Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsReasonCode?)) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails ResourceSkuZoneDetails(System.Collections.Generic.IEnumerable<string> name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities> capabilities = null) { throw null; }
    }
    public partial class AutomaticResourcePredictionsProfile : Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile>
    {
        public AutomaticResourcePredictionsProfile() { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.PredictionPreference? PredictionPreference { get { throw null; } set { } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureDevOpsOrganizationProfile : Azure.ResourceManager.DevOpsInfrastructure.Models.OrganizationProfile, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsOrganizationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsOrganizationProfile>
    {
        public AzureDevOpsOrganizationProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.Models.Organization> organizations) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevOpsInfrastructure.Models.Organization> Organizations { get { throw null; } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionProfile PermissionProfile { get { throw null; } set { } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsOrganizationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsOrganizationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsOrganizationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsOrganizationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsOrganizationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsOrganizationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsOrganizationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureDevOpsPermissionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionProfile>
    {
        public AzureDevOpsPermissionProfile(Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionType kind) { }
        public System.Collections.Generic.IList<string> Groups { get { throw null; } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionType Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Users { get { throw null; } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureDevOpsPermissionType : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureDevOpsPermissionType(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionType CreatorOnly { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionType Inherit { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionType SpecificAccounts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionType left, Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionType left, Azure.ResourceManager.DevOpsInfrastructure.Models.AzureDevOpsPermissionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CachingType : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.CachingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CachingType(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.CachingType None { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.CachingType ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.CachingType ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.CachingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.CachingType left, Azure.ResourceManager.DevOpsInfrastructure.Models.CachingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.CachingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.CachingType left, Azure.ResourceManager.DevOpsInfrastructure.Models.CachingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DataDisk>
    {
        public DataDisk() { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.CachingType? Caching { get { throw null; } set { } }
        public int? DiskSizeGiB { get { throw null; } set { } }
        public string DriveLetter { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsAzureSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku>
    {
        public DevOpsAzureSku(string name) { }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class FabricProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.FabricProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.FabricProfile>
    {
        protected FabricProfile() { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.FabricProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.FabricProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.FabricProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.FabricProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.FabricProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.FabricProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.FabricProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitHubOrganization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganization>
    {
        public GitHubOrganization(string gitHubOrganizatioi) { }
        public string GitHubOrganizatioi { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Repositories { get { throw null; } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitHubOrganizationProfile : Azure.ResourceManager.DevOpsInfrastructure.Models.OrganizationProfile, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganizationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganizationProfile>
    {
        public GitHubOrganizationProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganization> organizations) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganization> Organizations { get { throw null; } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganizationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganizationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganizationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganizationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganizationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganizationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.GitHubOrganizationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageVersion : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ImageVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ImageVersion>
    {
        internal ImageVersion() { }
        public string Version { get { throw null; } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ImageVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ImageVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ImageVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ImageVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ImageVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ImageVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ImageVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogonType : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.LogonType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogonType(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.LogonType Interactive { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.LogonType Service { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.LogonType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.LogonType left, Azure.ResourceManager.DevOpsInfrastructure.Models.LogonType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.LogonType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.LogonType left, Azure.ResourceManager.DevOpsInfrastructure.Models.LogonType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedServiceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentity>
    {
        public ManagedServiceIdentity(Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentityType type) { }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentityType Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } set { } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentityType SystemAndUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentityType left, Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentityType left, Azure.ResourceManager.DevOpsInfrastructure.Models.ManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManualResourcePredictionsProfile : Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile>
    {
        public ManualResourcePredictionsProfile() { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Organization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Organization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Organization>
    {
        public Organization(string organizatioi) { }
        public string Organizatioi { get { throw null; } set { } }
        public int? Parallelism { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Projects { get { throw null; } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.Organization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Organization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Organization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.Organization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Organization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Organization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Organization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class OrganizationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.OrganizationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.OrganizationProfile>
    {
        protected OrganizationProfile() { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.OrganizationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.OrganizationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.OrganizationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.OrganizationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.OrganizationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.OrganizationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.OrganizationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSDiskStorageAccountType : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.OSDiskStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSDiskStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.OSDiskStorageAccountType Premium { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.OSDiskStorageAccountType Standard { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.OSDiskStorageAccountType StandardSSD { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.OSDiskStorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.OSDiskStorageAccountType left, Azure.ResourceManager.DevOpsInfrastructure.Models.OSDiskStorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.OSDiskStorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.OSDiskStorageAccountType left, Azure.ResourceManager.DevOpsInfrastructure.Models.OSDiskStorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.OSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.OSProfile>
    {
        public OSProfile() { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.LogonType? LogonType { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings SecretsManagementSettings { get { throw null; } set { } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.OSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.OSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.OSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.OSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.OSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.OSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.OSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PoolImage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolImage>
    {
        public PoolImage() { }
        public System.Collections.Generic.IList<string> Aliases { get { throw null; } }
        public string Buffer { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string WellKnownImageName { get { throw null; } set { } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.PoolImage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.PoolImage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolProperties>
    {
        public PoolProperties(int maximumConcurrency, Azure.ResourceManager.DevOpsInfrastructure.Models.OrganizationProfile organizationProfile, Azure.ResourceManager.DevOpsInfrastructure.Models.AgentProfile agentProfile, Azure.ResourceManager.DevOpsInfrastructure.Models.FabricProfile fabricProfile, string devCenterProjectResourceId) { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.AgentProfile AgentProfile { get { throw null; } set { } }
        public string DevCenterProjectResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.FabricProfile FabricProfile { get { throw null; } set { } }
        public int MaximumConcurrency { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.OrganizationProfile OrganizationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.PoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.PoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PredictionPreference : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.PredictionPreference>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PredictionPreference(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.PredictionPreference Balanced { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.PredictionPreference BestPerformance { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.PredictionPreference MoreCostEffective { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.PredictionPreference MorePerformance { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.PredictionPreference MostCostEffective { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.PredictionPreference other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.PredictionPreference left, Azure.ResourceManager.DevOpsInfrastructure.Models.PredictionPreference right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.PredictionPreference (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.PredictionPreference left, Azure.ResourceManager.DevOpsInfrastructure.Models.PredictionPreference right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.ProvisioningState left, Azure.ResourceManager.DevOpsInfrastructure.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.ProvisioningState left, Azure.ResourceManager.DevOpsInfrastructure.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Quota : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Quota>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Quota>
    {
        internal Quota() { }
        public long CurrentValue { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public long Limit { get { throw null; } }
        public string Unit { get { throw null; } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.Quota System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Quota>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Quota>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.Quota System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Quota>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Quota>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Quota>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceDetailsObject : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObject>
    {
        internal ResourceDetailsObject() { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObjectProperties Properties { get { throw null; } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceDetailsObjectProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObjectProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObjectProperties>
    {
        internal ResourceDetailsObjectProperties() { }
        public string Image { get { throw null; } }
        public string ImageVersion { get { throw null; } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus Status { get { throw null; } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObjectProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObjectProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObjectProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObjectProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObjectProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObjectProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceDetailsObjectProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourcePredictions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions>
    {
        public ResourcePredictions() { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ResourcePredictionsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile>
    {
        protected ResourcePredictionsProfile() { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSku : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSku>
    {
        internal ResourceSku() { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuProperties Properties { get { throw null; } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities>
    {
        internal ResourceSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuLocationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo>
    {
        internal ResourceSkuLocationInfo() { }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuProperties>
    {
        internal ResourceSkuProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities> Capabilities { get { throw null; } }
        public string Family { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictions> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuRestrictionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionInfo>
    {
        internal ResourceSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuRestrictions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictions>
    {
        internal ResourceSkuRestrictions() { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsType? Type { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceSkuRestrictionsReasonCode : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceSkuRestrictionsReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsReasonCode QuotaId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsReasonCode left, Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsReasonCode left, Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceSkuRestrictionsType : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceSkuRestrictionsType(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsType Location { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsType Zone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsType left, Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsType left, Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceSkuZoneDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails>
    {
        internal ResourceSkuZoneDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Name { get { throw null; } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceStatus : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus Allocated { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus Leased { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus NotReady { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus PendingReimage { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus PendingReturn { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus Ready { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus Reimaging { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus Returned { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus left, Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus left, Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecretsManagementSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings>
    {
        public SecretsManagementSettings(System.Collections.Generic.IEnumerable<System.Uri> observedCertificates, bool keyExportable) { }
        public string CertificateStoreLocation { get { throw null; } set { } }
        public bool KeyExportable { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Uri> ObservedCertificates { get { throw null; } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Stateful : Azure.ResourceManager.DevOpsInfrastructure.Models.AgentProfile, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Stateful>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Stateful>
    {
        public Stateful() { }
        public string GracePeriodTimeSpan { get { throw null; } set { } }
        public string MaxAgentLifetime { get { throw null; } set { } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.Stateful System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Stateful>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Stateful>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.Stateful System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Stateful>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Stateful>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.Stateful>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StatelessAgentProfile : Azure.ResourceManager.DevOpsInfrastructure.Models.AgentProfile, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.StatelessAgentProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.StatelessAgentProfile>
    {
        public StatelessAgentProfile() { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.StatelessAgentProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.StatelessAgentProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.StatelessAgentProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.StatelessAgentProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.StatelessAgentProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.StatelessAgentProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.StatelessAgentProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountType : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.StorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.StorageAccountType PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.StorageAccountType PremiumZRS { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.StorageAccountType StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.StorageAccountType StandardSSDLRS { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.StorageAccountType StandardSSDZRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.StorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.StorageAccountType left, Azure.ResourceManager.DevOpsInfrastructure.Models.StorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.StorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.StorageAccountType left, Azure.ResourceManager.DevOpsInfrastructure.Models.StorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.StorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.StorageProfile>
    {
        public StorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevOpsInfrastructure.Models.DataDisk> DataDisks { get { throw null; } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.OSDiskStorageAccountType? OSDiskStorageAccountType { get { throw null; } set { } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.StorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.StorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.StorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.StorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.StorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.StorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.StorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmssFabricProfile : Azure.ResourceManager.DevOpsInfrastructure.Models.FabricProfile, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.VmssFabricProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.VmssFabricProfile>
    {
        public VmssFabricProfile(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku sku, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolImage> images) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolImage> Images { get { throw null; } }
        public string NetworkSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.OSProfile OSProfile { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        Azure.ResourceManager.DevOpsInfrastructure.Models.VmssFabricProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.VmssFabricProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.VmssFabricProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.VmssFabricProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.VmssFabricProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.VmssFabricProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.VmssFabricProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
