namespace Azure.ResourceManager.PowerBIDedicated
{
    public partial class AutoScaleVCoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource>, System.Collections.IEnumerable
    {
        protected AutoScaleVCoreCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vcoreName, Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vcoreName, Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vcoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vcoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> Get(string vcoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource>> GetAsync(string vcoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> GetIfExists(string vcoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource>> GetIfExistsAsync(string vcoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutoScaleVCoreData : Azure.ResourceManager.PowerBIDedicated.Models.PowerBIDedicatedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreData>
    {
        public AutoScaleVCoreData(Azure.Core.AzureLocation location, Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCoreSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public int? CapacityLimit { get { throw null; } set { } }
        public string CapacityObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.PowerBIDedicated.Models.VCoreProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCoreSku Sku { get { throw null; } set { } }
        Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutoScaleVCoreResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutoScaleVCoreResource() { }
        public virtual Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vcoreName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> Update(Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCorePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource>> UpdateAsync(Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCorePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedCapacityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource>, System.Collections.IEnumerable
    {
        protected DedicatedCapacityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dedicatedCapacityName, Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dedicatedCapacityName, Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dedicatedCapacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dedicatedCapacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> Get(string dedicatedCapacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource>> GetAsync(string dedicatedCapacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> GetIfExists(string dedicatedCapacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource>> GetIfExistsAsync(string dedicatedCapacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DedicatedCapacityData : Azure.ResourceManager.PowerBIDedicated.Models.PowerBIDedicatedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityData>
    {
        public DedicatedCapacityData(Azure.Core.AzureLocation location, Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku sku) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<string> AdministrationMembers { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.PowerBIDedicated.Models.Mode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.PowerBIDedicated.Models.State? State { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedCapacityResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DedicatedCapacityResource() { }
        public virtual Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string dedicatedCapacityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PowerBIDedicated.Models.SkuDetails> GetSkusForCapacity(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PowerBIDedicated.Models.SkuDetails> GetSkusForCapacityAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Resume(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResumeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Suspend(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SuspendAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PowerBIDedicated.Models.DedicatedCapacityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PowerBIDedicated.Models.DedicatedCapacityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PowerBIDedicatedExtensions
    {
        public static Azure.Response<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityResult> CheckNameAvailabilityCapacity(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityResult>> CheckNameAvailabilityCapacityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> GetAutoScaleVCore(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vcoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource>> GetAutoScaleVCoreAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vcoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource GetAutoScaleVCoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreCollection GetAutoScaleVCores(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> GetAutoScaleVCores(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> GetAutoScaleVCoresAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityCollection GetDedicatedCapacities(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> GetDedicatedCapacities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> GetDedicatedCapacitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> GetDedicatedCapacity(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dedicatedCapacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource>> GetDedicatedCapacityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string dedicatedCapacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource GetDedicatedCapacityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku> GetSkusCapacities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku> GetSkusCapacitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PowerBIDedicated.Mocking
{
    public partial class MockablePowerBIDedicatedArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePowerBIDedicatedArmClient() { }
        public virtual Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource GetAutoScaleVCoreResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource GetDedicatedCapacityResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePowerBIDedicatedResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePowerBIDedicatedResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> GetAutoScaleVCore(string vcoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource>> GetAutoScaleVCoreAsync(string vcoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreCollection GetAutoScaleVCores() { throw null; }
        public virtual Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityCollection GetDedicatedCapacities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> GetDedicatedCapacity(string dedicatedCapacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource>> GetDedicatedCapacityAsync(string dedicatedCapacityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockablePowerBIDedicatedSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePowerBIDedicatedSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityResult> CheckNameAvailabilityCapacity(Azure.Core.AzureLocation location, Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityResult>> CheckNameAvailabilityCapacityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> GetAutoScaleVCores(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreResource> GetAutoScaleVCoresAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> GetDedicatedCapacities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityResource> GetDedicatedCapacitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku> GetSkusCapacities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku> GetSkusCapacitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PowerBIDedicated.Models
{
    public static partial class ArmPowerBIDedicatedModelFactory
    {
        public static Azure.ResourceManager.PowerBIDedicated.AutoScaleVCoreData AutoScaleVCoreData(string id = null, string name = null, string resourceType = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.PowerBIDedicated.Models.SystemData systemData = null, Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCoreSku sku = null, int? capacityLimit = default(int?), string capacityObjectId = null, Azure.ResourceManager.PowerBIDedicated.Models.VCoreProvisioningState? provisioningState = default(Azure.ResourceManager.PowerBIDedicated.Models.VCoreProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityResult CheckCapacityNameAvailabilityResult(bool? nameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.PowerBIDedicated.DedicatedCapacityData DedicatedCapacityData(string id = null, string name = null, string resourceType = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.PowerBIDedicated.Models.SystemData systemData = null, Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku sku = null, System.Collections.Generic.IEnumerable<string> administrationMembers = null, Azure.ResourceManager.PowerBIDedicated.Models.Mode? mode = default(Azure.ResourceManager.PowerBIDedicated.Models.Mode?), System.Guid? tenantId = default(System.Guid?), string friendlyName = null, Azure.ResourceManager.PowerBIDedicated.Models.State? state = default(Azure.ResourceManager.PowerBIDedicated.Models.State?), Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState? provisioningState = default(Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PowerBIDedicated.Models.DedicatedCapacityPatch DedicatedCapacityPatch(Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku sku = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IEnumerable<string> administrationMembers = null, Azure.ResourceManager.PowerBIDedicated.Models.Mode? mode = default(Azure.ResourceManager.PowerBIDedicated.Models.Mode?), System.Guid? tenantId = default(System.Guid?), string friendlyName = null) { throw null; }
        public static Azure.ResourceManager.PowerBIDedicated.Models.PowerBIDedicatedResourceData PowerBIDedicatedResourceData(string id = null, string name = null, string resourceType = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.PowerBIDedicated.Models.SystemData systemData = null) { throw null; }
        public static Azure.ResourceManager.PowerBIDedicated.Models.SkuDetails SkuDetails(string resourceType = null, Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku sku = null) { throw null; }
    }
    public partial class AutoScaleVCorePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCorePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCorePatch>
    {
        public AutoScaleVCorePatch() { }
        public int? CapacityLimit { get { throw null; } set { } }
        public Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCoreSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCorePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCorePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCorePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCorePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCorePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCorePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCorePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutoScaleVCoreSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCoreSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCoreSku>
    {
        public AutoScaleVCoreSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.PowerBIDedicated.Models.VCoreSkuTier? Tier { get { throw null; } set { } }
        Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCoreSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCoreSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCoreSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCoreSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCoreSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCoreSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.AutoScaleVCoreSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapacityProvisioningState : System.IEquatable<Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapacityProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState Paused { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState Pausing { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState Preparing { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState Resuming { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState Scaling { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState Suspended { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState Suspending { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState left, Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState left, Azure.ResourceManager.PowerBIDedicated.Models.CapacityProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CapacitySku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku>
    {
        public CapacitySku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.PowerBIDedicated.Models.CapacitySkuTier? Tier { get { throw null; } set { } }
        Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapacitySkuTier : System.IEquatable<Azure.ResourceManager.PowerBIDedicated.Models.CapacitySkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapacitySkuTier(string value) { throw null; }
        public static Azure.ResourceManager.PowerBIDedicated.Models.CapacitySkuTier AutoPremiumHost { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.CapacitySkuTier PbieAzure { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.CapacitySkuTier Premium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PowerBIDedicated.Models.CapacitySkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PowerBIDedicated.Models.CapacitySkuTier left, Azure.ResourceManager.PowerBIDedicated.Models.CapacitySkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.PowerBIDedicated.Models.CapacitySkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PowerBIDedicated.Models.CapacitySkuTier left, Azure.ResourceManager.PowerBIDedicated.Models.CapacitySkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckCapacityNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityContent>
    {
        public CheckCapacityNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckCapacityNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityResult>
    {
        internal CheckCapacityNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
        Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.CheckCapacityNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedCapacityPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.DedicatedCapacityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.DedicatedCapacityPatch>
    {
        public DedicatedCapacityPatch() { }
        public System.Collections.Generic.IList<string> AdministrationMembers { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.PowerBIDedicated.Models.Mode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        Azure.ResourceManager.PowerBIDedicated.Models.DedicatedCapacityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.DedicatedCapacityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.DedicatedCapacityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerBIDedicated.Models.DedicatedCapacityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.DedicatedCapacityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.DedicatedCapacityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.DedicatedCapacityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityType : System.IEquatable<Azure.ResourceManager.PowerBIDedicated.Models.IdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityType(string value) { throw null; }
        public static Azure.ResourceManager.PowerBIDedicated.Models.IdentityType Application { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.IdentityType Key { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.IdentityType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.IdentityType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PowerBIDedicated.Models.IdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PowerBIDedicated.Models.IdentityType left, Azure.ResourceManager.PowerBIDedicated.Models.IdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PowerBIDedicated.Models.IdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PowerBIDedicated.Models.IdentityType left, Azure.ResourceManager.PowerBIDedicated.Models.IdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Mode : System.IEquatable<Azure.ResourceManager.PowerBIDedicated.Models.Mode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Mode(string value) { throw null; }
        public static Azure.ResourceManager.PowerBIDedicated.Models.Mode Gen1 { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.Mode Gen2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PowerBIDedicated.Models.Mode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PowerBIDedicated.Models.Mode left, Azure.ResourceManager.PowerBIDedicated.Models.Mode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PowerBIDedicated.Models.Mode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PowerBIDedicated.Models.Mode left, Azure.ResourceManager.PowerBIDedicated.Models.Mode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PowerBIDedicatedResourceData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.PowerBIDedicatedResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.PowerBIDedicatedResourceData>
    {
        public PowerBIDedicatedResourceData(Azure.Core.AzureLocation location) { }
        public string Id { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.PowerBIDedicated.Models.SystemData SystemData { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.PowerBIDedicated.Models.PowerBIDedicatedResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.PowerBIDedicatedResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.PowerBIDedicatedResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerBIDedicated.Models.PowerBIDedicatedResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.PowerBIDedicatedResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.PowerBIDedicatedResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.PowerBIDedicatedResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.SkuDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.SkuDetails>
    {
        internal SkuDetails() { }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.PowerBIDedicated.Models.CapacitySku Sku { get { throw null; } }
        Azure.ResourceManager.PowerBIDedicated.Models.SkuDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.SkuDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.SkuDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerBIDedicated.Models.SkuDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.SkuDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.SkuDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.SkuDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct State : System.IEquatable<Azure.ResourceManager.PowerBIDedicated.Models.State>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public State(string value) { throw null; }
        public static Azure.ResourceManager.PowerBIDedicated.Models.State Deleting { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.State Failed { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.State Paused { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.State Pausing { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.State Preparing { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.State Provisioning { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.State Resuming { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.State Scaling { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.State Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.State Suspended { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.State Suspending { get { throw null; } }
        public static Azure.ResourceManager.PowerBIDedicated.Models.State Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PowerBIDedicated.Models.State other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PowerBIDedicated.Models.State left, Azure.ResourceManager.PowerBIDedicated.Models.State right) { throw null; }
        public static implicit operator Azure.ResourceManager.PowerBIDedicated.Models.State (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PowerBIDedicated.Models.State left, Azure.ResourceManager.PowerBIDedicated.Models.State right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SystemData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.SystemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.SystemData>
    {
        public SystemData() { }
        public string CreatedBy { get { throw null; } set { } }
        public Azure.ResourceManager.PowerBIDedicated.Models.IdentityType? CreatedByType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public Azure.ResourceManager.PowerBIDedicated.Models.IdentityType? LastModifiedByType { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        Azure.ResourceManager.PowerBIDedicated.Models.SystemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.SystemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PowerBIDedicated.Models.SystemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PowerBIDedicated.Models.SystemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.SystemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.SystemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PowerBIDedicated.Models.SystemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VCoreProvisioningState : System.IEquatable<Azure.ResourceManager.PowerBIDedicated.Models.VCoreProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VCoreProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PowerBIDedicated.Models.VCoreProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PowerBIDedicated.Models.VCoreProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PowerBIDedicated.Models.VCoreProvisioningState left, Azure.ResourceManager.PowerBIDedicated.Models.VCoreProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PowerBIDedicated.Models.VCoreProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PowerBIDedicated.Models.VCoreProvisioningState left, Azure.ResourceManager.PowerBIDedicated.Models.VCoreProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VCoreSkuTier : System.IEquatable<Azure.ResourceManager.PowerBIDedicated.Models.VCoreSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VCoreSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.PowerBIDedicated.Models.VCoreSkuTier AutoScale { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PowerBIDedicated.Models.VCoreSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PowerBIDedicated.Models.VCoreSkuTier left, Azure.ResourceManager.PowerBIDedicated.Models.VCoreSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.PowerBIDedicated.Models.VCoreSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PowerBIDedicated.Models.VCoreSkuTier left, Azure.ResourceManager.PowerBIDedicated.Models.VCoreSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
}
