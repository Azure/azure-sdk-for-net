namespace Azure.ResourceManager.DevOpsInfrastructure
{
    public partial class AzureResourceManagerDevOpsInfrastructureContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDevOpsInfrastructureContext() { }
        public static Azure.ResourceManager.DevOpsInfrastructure.AzureResourceManagerDevOpsInfrastructureContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class DevOpsInfrastructureExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityResult> CheckNameAvailabilityPool(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailability body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityPoolAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailability body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> GetDevOpsPool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource>> GetDevOpsPoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource GetDevOpsPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolCollection GetDevOpsPools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> GetDevOpsPools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> GetDevOpsPoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsImageVersion> GetImageVersionsByImage(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsImageVersion> GetImageVersionsByImageAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSku> GetSkusByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSku> GetSkusByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuota> GetUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuota> GetUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevOpsPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource>, System.Collections.IEnumerable
    {
        protected DevOpsPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> Get(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource>> GetAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> GetIfExists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource>> GetIfExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevOpsPoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData>
    {
        public DevOpsPoolData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevOpsPoolResource() { }
        public virtual Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string poolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteResources(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDeleteResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteResourcesAsync(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDeleteResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetails> GetResourceDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetails> GetResourceDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DevOpsInfrastructure.Mocking
{
    public partial class MockableDevOpsInfrastructureArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDevOpsInfrastructureArmClient() { }
        public virtual Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource GetDevOpsPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDevOpsInfrastructureResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDevOpsInfrastructureResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> GetDevOpsPool(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource>> GetDevOpsPoolAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolCollection GetDevOpsPools() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsImageVersion> GetImageVersionsByImage(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsImageVersion> GetImageVersionsByImageAsync(string imageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableDevOpsInfrastructureSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDevOpsInfrastructureSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityResult> CheckNameAvailabilityPool(Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailability body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityPoolAsync(Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailability body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> GetDevOpsPools(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolResource> GetDevOpsPoolsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSku> GetSkusByLocation(string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSku> GetSkusByLocationAsync(string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuota> GetUsages(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuota> GetUsagesAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DevOpsInfrastructure.Models
{
    public static partial class ArmDevOpsInfrastructureModelFactory
    {
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityResult CheckNameAvailabilityResult(Azure.ResourceManager.DevOpsInfrastructure.Models.AvailabilityStatus available = default(Azure.ResourceManager.DevOpsInfrastructure.Models.AvailabilityStatus), string message = null, string name = null, Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityReason reason = default(Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityReason)) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsImageVersion DevOpsImageVersion(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string imageVersion = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsNetworkProfile DevOpsNetworkProfile(string subnetId = null, int? staticIPAddressCount = default(int?), System.Collections.Generic.IEnumerable<string> ipAddresses = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.DevOpsPoolData DevOpsPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolVmImage DevOpsPoolVmImage(string resourceId = null, string wellKnownImageName = null, System.Collections.Generic.IEnumerable<string> aliases = null, string buffer = null, Azure.ResourceManager.DevOpsInfrastructure.Models.EphemeralType? ephemeralType = default(Azure.ResourceManager.DevOpsInfrastructure.Models.EphemeralType?), bool? isEphemeral = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetails DevOpsResourceDetails(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetailsProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetailsProperties DevOpsResourceDetailsProperties(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus status = default(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus), string image = null, string imageVersion = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuota DevOpsResourceQuota(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuotaName name = null, Azure.Core.ResourceIdentifier id = null, string unit = null, long currentValue = (long)0, long limit = (long)0) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuotaName DevOpsResourceQuotaName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSku DevOpsResourceSku(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSkuProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSkuProperties DevOpsResourceSkuProperties(string resourceType = null, string tier = null, string size = null, string family = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo> locationInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities> capabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictions> restrictions = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities ResourceSkuCapabilities(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo ResourceSkuLocationInfo(Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails> zoneDetails = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionInfo ResourceSkuRestrictionInfo(System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictions ResourceSkuRestrictions(Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsType? restrictionsType = default(Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsType?), System.Collections.Generic.IEnumerable<string> values = null, Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionInfo restrictionInfo = null, Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsReasonCode? reasonCode = default(Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsReasonCode?)) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails ResourceSkuZoneDetails(System.Collections.Generic.IEnumerable<string> name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities> capabilities = null) { throw null; }
    }
    public partial class AutomaticResourcePredictionsProfile : Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile>
    {
        public AutomaticResourcePredictionsProfile() { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.PredictionPreference? PredictionPreference { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.AutomaticResourcePredictionsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailabilityStatus : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.AvailabilityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailabilityStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.AvailabilityStatus Available { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.AvailabilityStatus Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.AvailabilityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.AvailabilityStatus left, Azure.ResourceManager.DevOpsInfrastructure.Models.AvailabilityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.AvailabilityStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.AvailabilityStatus left, Azure.ResourceManager.DevOpsInfrastructure.Models.AvailabilityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateStoreNameOption : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.CertificateStoreNameOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateStoreNameOption(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.CertificateStoreNameOption My { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.CertificateStoreNameOption Root { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.CertificateStoreNameOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.CertificateStoreNameOption left, Azure.ResourceManager.DevOpsInfrastructure.Models.CertificateStoreNameOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.CertificateStoreNameOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.CertificateStoreNameOption left, Azure.ResourceManager.DevOpsInfrastructure.Models.CertificateStoreNameOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailability>
    {
        public CheckNameAvailability(string name, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureResourceType type) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureResourceType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameAvailabilityReason : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameAvailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityResult>
    {
        internal CheckNameAvailabilityResult() { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.AvailabilityStatus Available { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityReason Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.CheckNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsAzureOrganizationProfile : Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganizationProfile, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureOrganizationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureOrganizationProfile>
    {
        public DevOpsAzureOrganizationProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganization> organizations) { }
        public string Alias { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganization> Organizations { get { throw null; } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionProfile PermissionProfile { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureOrganizationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureOrganizationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureOrganizationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureOrganizationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureOrganizationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureOrganizationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureOrganizationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsAzurePermissionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionProfile>
    {
        public DevOpsAzurePermissionProfile(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionType kind) { }
        public System.Collections.Generic.IList<string> Groups { get { throw null; } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionType Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Users { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevOpsAzurePermissionType : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevOpsAzurePermissionType(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionType CreatorOnly { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionType Inherit { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionType SpecificAccounts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionType left, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionType left, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzurePermissionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevOpsAzureSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku>
    {
        public DevOpsAzureSku(string name) { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDisk>
    {
        public DevOpsDataDisk() { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDiskCachingType? Caching { get { throw null; } set { } }
        public int? DiskSizeGiB { get { throw null; } set { } }
        public string DriveLetter { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageAccountType? StorageAccountType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevOpsDataDiskCachingType : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDiskCachingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevOpsDataDiskCachingType(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDiskCachingType None { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDiskCachingType ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDiskCachingType ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDiskCachingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDiskCachingType left, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDiskCachingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDiskCachingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDiskCachingType left, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDiskCachingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevOpsDeleteResourcesDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDeleteResourcesDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDeleteResourcesDetails>
    {
        public DevOpsDeleteResourcesDetails(System.Collections.Generic.IEnumerable<string> resourceIds) { }
        public System.Collections.Generic.IList<string> ResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDeleteResourcesDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDeleteResourcesDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDeleteResourcesDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDeleteResourcesDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDeleteResourcesDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDeleteResourcesDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDeleteResourcesDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DevOpsFabricProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsFabricProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsFabricProfile>
    {
        protected DevOpsFabricProfile() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsFabricProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsFabricProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsFabricProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsFabricProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsFabricProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsFabricProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsFabricProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsGitHubOrganization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganization>
    {
        public DevOpsGitHubOrganization(System.Uri uri) { }
        public System.Collections.Generic.IList<string> Repositories { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsGitHubOrganizationProfile : Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganizationProfile, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganizationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganizationProfile>
    {
        public DevOpsGitHubOrganizationProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganization> organizations) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganization> Organizations { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganizationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganizationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganizationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganizationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganizationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganizationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsGitHubOrganizationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsImageVersion : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsImageVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsImageVersion>
    {
        internal DevOpsImageVersion() { }
        public string ImageVersion { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsImageVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsImageVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsImageVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsImageVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsImageVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsImageVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsImageVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevOpsInfrastructureProvisioningState : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevOpsInfrastructureProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureProvisioningState left, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureProvisioningState left, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevOpsInfrastructureResourceType : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevOpsInfrastructureResourceType(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureResourceType MicrosoftDevOpsInfrastructurePools { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureResourceType left, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureResourceType left, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevOpsLogonType : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsLogonType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevOpsLogonType(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsLogonType Interactive { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsLogonType Service { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsLogonType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsLogonType left, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsLogonType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsLogonType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsLogonType left, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsLogonType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevOpsNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsNetworkProfile>
    {
        public DevOpsNetworkProfile(string subnetId) { }
        public System.Collections.Generic.IReadOnlyList<string> IPAddresses { get { throw null; } }
        public int? StaticIPAddressCount { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsOrganization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganization>
    {
        public DevOpsOrganization(System.Uri uri) { }
        public string Alias { get { throw null; } set { } }
        public bool? OpenAccess { get { throw null; } set { } }
        public int? Parallelism { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Projects { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DevOpsOrganizationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganizationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganizationProfile>
    {
        protected DevOpsOrganizationProfile() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganizationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganizationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganizationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganizationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganizationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganizationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganizationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOSProfile>
    {
        public DevOpsOSProfile() { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsLogonType? LogonType { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings SecretsManagementSettings { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DevOpsPoolAgentProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolAgentProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolAgentProfile>
    {
        protected DevOpsPoolAgentProfile() { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions ResourcePredictions { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile ResourcePredictionsProfile { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolAgentProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolAgentProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolAgentProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolAgentProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolAgentProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolAgentProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolAgentProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsPoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolPatch>
    {
        public DevOpsPoolPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.PoolUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsPoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolProperties>
    {
        public DevOpsPoolProperties(int maximumConcurrency, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganizationProfile organizationProfile, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolAgentProfile agentProfile, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsFabricProfile fabricProfile, string devCenterProjectResourceId) { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolAgentProfile AgentProfile { get { throw null; } set { } }
        public string DevCenterProjectResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsFabricProfile FabricProfile { get { throw null; } set { } }
        public int MaximumConcurrency { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganizationProfile OrganizationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string RuntimeWorkFolder { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsPoolVmImage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolVmImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolVmImage>
    {
        public DevOpsPoolVmImage() { }
        public System.Collections.Generic.IList<string> Aliases { get { throw null; } }
        public string Buffer { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.EphemeralType? EphemeralType { get { throw null; } set { } }
        public bool? IsEphemeral { get { throw null; } }
        public string ResourceId { get { throw null; } set { } }
        public string WellKnownImageName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolVmImage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolVmImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolVmImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolVmImage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolVmImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolVmImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolVmImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsResourceDetails : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetails>
    {
        internal DevOpsResourceDetails() { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetailsProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsResourceDetailsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetailsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetailsProperties>
    {
        internal DevOpsResourceDetailsProperties() { }
        public string Image { get { throw null; } }
        public string ImageVersion { get { throw null; } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetailsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetailsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetailsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetailsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetailsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetailsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceDetailsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsResourceQuota : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuota>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuota>
    {
        internal DevOpsResourceQuota() { }
        public long CurrentValue { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public long Limit { get { throw null; } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuotaName Name { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuota System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuota>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuota>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuota System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuota>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuota>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuota>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsResourceQuotaName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuotaName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuotaName>
    {
        internal DevOpsResourceQuotaName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuotaName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuotaName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuotaName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuotaName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuotaName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuotaName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceQuotaName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsResourceSku : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSku>
    {
        internal DevOpsResourceSku() { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSkuProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsResourceSkuProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSkuProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSkuProperties>
    {
        internal DevOpsResourceSkuProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities> Capabilities { get { throw null; } }
        public string Family { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictions> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSkuProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSkuProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSkuProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSkuProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSkuProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSkuProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceSkuProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevOpsResourceStatus : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevOpsResourceStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus Allocated { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus Leased { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus NotReady { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus PendingReimage { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus PendingReturn { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus Ready { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus Reimaging { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus Returned { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus left, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus left, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsResourceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevOpsStateful : Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolAgentProfile, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStateful>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStateful>
    {
        public DevOpsStateful() { }
        public string GracePeriodTimeSpan { get { throw null; } set { } }
        public string MaxAgentLifetime { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStateful System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStateful>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStateful>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStateful System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStateful>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStateful>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStateful>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsStatelessAgentProfile : Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolAgentProfile, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStatelessAgentProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStatelessAgentProfile>
    {
        public DevOpsStatelessAgentProfile() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStatelessAgentProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStatelessAgentProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStatelessAgentProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStatelessAgentProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStatelessAgentProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStatelessAgentProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStatelessAgentProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevOpsStorageAccountType : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevOpsStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageAccountType PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageAccountType PremiumZrs { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageAccountType StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageAccountType StandardSsdLrs { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageAccountType StandardSsdZrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageAccountType left, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageAccountType left, Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevOpsStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageProfile>
    {
        public DevOpsStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsDataDisk> DataDisks { get { throw null; } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.OSDiskStorageAccountType? OSDiskStorageAccountType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevOpsVmssFabricProfile : Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsFabricProfile, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsVmssFabricProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsVmssFabricProfile>
    {
        public DevOpsVmssFabricProfile(Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsAzureSku sku, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolVmImage> images) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolVmImage> Images { get { throw null; } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOSProfile OSProfile { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsStorageProfile StorageProfile { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsVmssFabricProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsVmssFabricProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsVmssFabricProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsVmssFabricProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsVmssFabricProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsVmssFabricProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsVmssFabricProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EphemeralType : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.EphemeralType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EphemeralType(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.EphemeralType Automatic { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.EphemeralType CacheDisk { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.EphemeralType ResourceDisk { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevOpsInfrastructure.Models.EphemeralType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevOpsInfrastructure.Models.EphemeralType left, Azure.ResourceManager.DevOpsInfrastructure.Models.EphemeralType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevOpsInfrastructure.Models.EphemeralType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevOpsInfrastructure.Models.EphemeralType left, Azure.ResourceManager.DevOpsInfrastructure.Models.EphemeralType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManualResourcePredictionsProfile : Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile>
    {
        public ManualResourcePredictionsProfile() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ManualResourcePredictionsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSDiskStorageAccountType : System.IEquatable<Azure.ResourceManager.DevOpsInfrastructure.Models.OSDiskStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSDiskStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.OSDiskStorageAccountType Premium { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.OSDiskStorageAccountType Standard { get { throw null; } }
        public static Azure.ResourceManager.DevOpsInfrastructure.Models.OSDiskStorageAccountType StandardSsd { get { throw null; } }
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
    public partial class PoolUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolUpdateProperties>
    {
        public PoolUpdateProperties() { }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsPoolAgentProfile AgentProfile { get { throw null; } set { } }
        public string DevCenterProjectResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsFabricProfile FabricProfile { get { throw null; } set { } }
        public int? MaximumConcurrency { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsOrganizationProfile OrganizationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.DevOpsInfrastructureProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string RuntimeWorkFolder { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.PoolUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.PoolUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.PoolUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ResourcePredictions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions>
    {
        public ResourcePredictions() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ResourcePredictionsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile>
    {
        protected ResourcePredictionsProfile() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourcePredictionsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities>
    {
        internal ResourceSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuLocationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo>
    {
        internal ResourceSkuLocationInfo() { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuLocationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuRestrictionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionInfo>
    {
        internal ResourceSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuRestrictionsType? RestrictionsType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.ResourceSkuZoneDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretsManagementSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings>
    {
        public SecretsManagementSettings(System.Collections.Generic.IEnumerable<System.Uri> observedCertificates, bool keyExportable) { }
        public string CertificateStoreLocation { get { throw null; } set { } }
        public Azure.ResourceManager.DevOpsInfrastructure.Models.CertificateStoreNameOption? CertificateStoreName { get { throw null; } set { } }
        public bool KeyExportable { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Uri> ObservedCertificates { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevOpsInfrastructure.Models.SecretsManagementSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
