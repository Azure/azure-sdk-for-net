namespace Azure.ResourceManager.DeviceOnboarding
{
    public static partial class DeviceOnboardingExtensions
    {
        public static Azure.ResourceManager.DeviceOnboarding.DeviceStateResource GetDeviceState(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.DeviceStateResource GetDeviceStateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> GetDiscoveryService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string discoveryServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource>> GetDiscoveryServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string discoveryServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource GetDiscoveryServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceCollection GetDiscoveryServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> GetDiscoveryServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> GetDiscoveryServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> GetOnboardingService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string onboardingServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource>> GetOnboardingServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string onboardingServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource GetOnboardingServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.OnboardingServiceCollection GetOnboardingServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> GetOnboardingServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> GetOnboardingServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource GetOwnershipVoucherPublicKeyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.PolicyResource GetPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DeviceStateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.DeviceStateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.DeviceStateData>
    {
        public DeviceStateData() { }
        public Azure.ResourceManager.DeviceOnboarding.Models.DeviceStateProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.DeviceStateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.DeviceStateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.DeviceStateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.DeviceStateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.DeviceStateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.DeviceStateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.DeviceStateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceStateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.DeviceStateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.DeviceStateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceStateResource() { }
        public virtual Azure.ResourceManager.DeviceOnboarding.DeviceStateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.DeviceStateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceOnboarding.DeviceStateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.DeviceStateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceOnboarding.DeviceStateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.DeviceStateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.DeviceStateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PrepareForOnboarding(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceOnboarding.Models.PrepareForOnboardingProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PrepareForOnboardingAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceOnboarding.Models.PrepareForOnboardingProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceOnboarding.DeviceStateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.DeviceStateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.DeviceStateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.DeviceStateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.DeviceStateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.DeviceStateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.DeviceStateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.DeviceStateResource> Update(Azure.ResourceManager.DeviceOnboarding.DeviceStateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.DeviceStateResource>> UpdateAsync(Azure.ResourceManager.DeviceOnboarding.DeviceStateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiscoveryServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource>, System.Collections.IEnumerable
    {
        protected DiscoveryServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string discoveryServiceName, Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string discoveryServiceName, Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string discoveryServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string discoveryServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> Get(string discoveryServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource>> GetAsync(string discoveryServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> GetIfExists(string discoveryServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource>> GetIfExistsAsync(string discoveryServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiscoveryServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData>
    {
        public DiscoveryServiceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryServiceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiscoveryServiceResource() { }
        public virtual Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string discoveryServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource> GetOwnershipVoucherPublicKey(string ownershipVoucherPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource>> GetOwnershipVoucherPublicKeyAsync(string ownershipVoucherPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyCollection GetOwnershipVoucherPublicKeys() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnboardingServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource>, System.Collections.IEnumerable
    {
        protected OnboardingServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string onboardingServiceName, Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string onboardingServiceName, Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string onboardingServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string onboardingServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> Get(string onboardingServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource>> GetAsync(string onboardingServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> GetIfExists(string onboardingServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource>> GetIfExistsAsync(string onboardingServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OnboardingServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData>
    {
        public OnboardingServiceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DeviceOnboarding.Models.OnboardingServiceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnboardingServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OnboardingServiceResource() { }
        public virtual Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string onboardingServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceOnboarding.PolicyCollection GetPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.PolicyResource> GetPolicy(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.PolicyResource>> GetPolicyAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OwnershipVoucherPublicKeyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource>, System.Collections.IEnumerable
    {
        protected OwnershipVoucherPublicKeyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ownershipVoucherPublicKeyName, Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ownershipVoucherPublicKeyName, Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ownershipVoucherPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ownershipVoucherPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource> Get(string ownershipVoucherPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource>> GetAsync(string ownershipVoucherPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource> GetIfExists(string ownershipVoucherPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource>> GetIfExistsAsync(string ownershipVoucherPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OwnershipVoucherPublicKeyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData>
    {
        public OwnershipVoucherPublicKeyData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherPublicKeyProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OwnershipVoucherPublicKeyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OwnershipVoucherPublicKeyResource() { }
        public virtual Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string discoveryServiceName, string ownershipVoucherPublicKeyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceOnboarding.PolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceOnboarding.PolicyResource>, System.Collections.IEnumerable
    {
        protected PolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.PolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.DeviceOnboarding.PolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.PolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.DeviceOnboarding.PolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.PolicyResource> Get(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceOnboarding.PolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceOnboarding.PolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.PolicyResource>> GetAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceOnboarding.PolicyResource> GetIfExists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceOnboarding.PolicyResource>> GetIfExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceOnboarding.PolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceOnboarding.PolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceOnboarding.PolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceOnboarding.PolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PolicyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.PolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.PolicyData>
    {
        public PolicyData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.PolicyProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.PolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.PolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.PolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.PolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.PolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.PolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.PolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.PolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.PolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PolicyResource() { }
        public virtual Azure.ResourceManager.DeviceOnboarding.PolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.PolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.PolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string onboardingServiceName, string policyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.PolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.PolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.PolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.PolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.PolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.PolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceOnboarding.PolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.PolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.PolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.PolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.PolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.PolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.PolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.PolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceOnboarding.PolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DeviceOnboarding.Mocking
{
    public partial class MockableDeviceOnboardingArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDeviceOnboardingArmClient() { }
        public virtual Azure.ResourceManager.DeviceOnboarding.DeviceStateResource GetDeviceState(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.DeviceOnboarding.DeviceStateResource GetDeviceStateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource GetDiscoveryServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource GetOnboardingServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyResource GetOwnershipVoucherPublicKeyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceOnboarding.PolicyResource GetPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDeviceOnboardingResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDeviceOnboardingResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> GetDiscoveryService(string discoveryServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource>> GetDiscoveryServiceAsync(string discoveryServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceCollection GetDiscoveryServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> GetOnboardingService(string onboardingServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource>> GetOnboardingServiceAsync(string onboardingServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceOnboarding.OnboardingServiceCollection GetOnboardingServices() { throw null; }
    }
    public partial class MockableDeviceOnboardingSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDeviceOnboardingSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> GetDiscoveryServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceResource> GetDiscoveryServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> GetOnboardingServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceOnboarding.OnboardingServiceResource> GetOnboardingServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DeviceOnboarding.Models
{
    public partial class AllocatedEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocatedEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocatedEndpoint>
    {
        public AllocatedEndpoint(string name, Azure.ResourceManager.DeviceOnboarding.Models.EndpointType endpointType, string hostName) { }
        public Azure.ResourceManager.DeviceOnboarding.Models.EndpointType EndpointType { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.AllocatedEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocatedEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocatedEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.AllocatedEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocatedEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocatedEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocatedEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AllocationEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationEndpoint>
    {
        public AllocationEndpoint(Azure.Core.ResourceIdentifier resourceId, string hostName) { }
        public string HostName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.AllocationEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.AllocationEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AllocationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRule>
    {
        protected AllocationRule(string name, Azure.ResourceManager.DeviceOnboarding.Models.EndpointType endpointType) { }
        public Azure.ResourceManager.DeviceOnboarding.Models.EndpointType EndpointType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.AllocationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.AllocationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AllocationRulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRulePatch>
    {
        protected AllocationRulePatch() { }
        public Azure.ResourceManager.DeviceOnboarding.Models.EndpointType? EndpointType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.AllocationRulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.AllocationRulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmDeviceOnboardingModelFactory
    {
        public static Azure.ResourceManager.DeviceOnboarding.Models.CaConfig CaConfig(string name = null, Azure.ResourceManager.DeviceOnboarding.Models.CertificateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.CertificateProperties CertificateProperties(Azure.ResourceManager.DeviceOnboarding.Models.SupportedKeyType keyType = default(Azure.ResourceManager.DeviceOnboarding.Models.SupportedKeyType), string subject = null, int? validityPeriodInDays = default(int?), System.DateTimeOffset? validityNotBefore = default(System.DateTimeOffset?), System.DateTimeOffset? validityNotAfter = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnection DeviceOnboardingPrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DeviceOnboarding.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateLinkServiceConnectionState DeviceOnboardingPrivateLinkServiceConnectionState(Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointServiceConnectionStatus? status = default(Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointServiceConnectionStatus?), string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.DeviceStateData DeviceStateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DeviceOnboarding.Models.DeviceStateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.DeviceStateProperties DeviceStateProperties(string registrationId = null, Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryOption? discoveryEnabled = default(Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryOption?), Azure.ResourceManager.DeviceOnboarding.Models.OnboardingStatus onboardingStatus = default(Azure.ResourceManager.DeviceOnboarding.Models.OnboardingStatus), Azure.Core.ResourceIdentifier policyResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceOnboarding.Models.AllocatedEndpoint> allocatedEndpoints = null, Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState?), System.DateTimeOffset? onboardUntilOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.DiscoveryServiceData DiscoveryServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryServiceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryServiceProperties DiscoveryServiceProperties(Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState?), string deviceEndpointHostName = null) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.FdoBootstrapAuthenticationRule FdoBootstrapAuthenticationRule(System.Collections.Generic.IEnumerable<byte[]> secp256R1Default = null, Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherStorage ownershipVoucherStorage = null, System.Uri rendezvousEndpoint = null) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.OnboardingServiceData OnboardingServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceOnboarding.Models.OnboardingServiceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.OnboardingServiceProperties OnboardingServiceProperties(Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState?), string defaultHostName = null, bool enableCertificateManagement = false, Azure.ResourceManager.DeviceOnboarding.Models.PublicNetworkAccessOption? publicNetworkAccess = default(Azure.ResourceManager.DeviceOnboarding.Models.PublicNetworkAccessOption?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnection> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.OwnershipVoucherPublicKeyData OwnershipVoucherPublicKeyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherPublicKeyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherPublicKeyProperties OwnershipVoucherPublicKeyProperties(Azure.ResourceManager.DeviceOnboarding.Models.PublicKeyDetails publicKeyDetails = null, Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.PatchFdoBootstrapAuthenticationRule PatchFdoBootstrapAuthenticationRule(System.Collections.Generic.IEnumerable<byte[]> secp256R1Default = null, Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherStorage ownershipVoucherStorage = null, System.Uri rendezvousEndpoint = null) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.PatchX509Certificate PatchX509Certificate(byte[] certificate = null, string thumbprint = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.PolicyData PolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceOnboarding.Models.PolicyProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchProperties PolicyPatchProperties(string description = null, Azure.ResourceManager.DeviceOnboarding.Models.PolicyStatusOption? status = default(Azure.ResourceManager.DeviceOnboarding.Models.PolicyStatusOption?), Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState?), Azure.ResourceManager.DeviceOnboarding.Models.PatchBootstrapAuthenticationRule bootstrapAuthentication = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRulePatch> allocations = null, Azure.ResourceManager.DeviceOnboarding.Models.JitRulePatchUpdate jit = null, Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchResourceDetails resourceDetails = null, Azure.ResourceManager.DeviceOnboarding.Models.PatchSelectedIdentity selectedIdentity = null) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.PolicyProperties PolicyProperties(string description = null, Azure.ResourceManager.DeviceOnboarding.Models.PolicyStatusOption status = default(Azure.ResourceManager.DeviceOnboarding.Models.PolicyStatusOption), Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState?), Azure.ResourceManager.DeviceOnboarding.Models.BootstrapAuthenticationRule bootstrapAuthentication = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRule> allocations = null, Azure.ResourceManager.DeviceOnboarding.Models.JitRule jit = null, Azure.ResourceManager.DeviceOnboarding.Models.PolicyResourceDetails resourceDetails = null, Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentity selectedIdentity = null) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.PrivateEndpointConnectionProperties PrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.X509Certificate X509Certificate(byte[] certificate = null, string thumbprint = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?)) { throw null; }
    }
    public abstract partial class BootstrapAuthenticationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.BootstrapAuthenticationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.BootstrapAuthenticationRule>
    {
        protected BootstrapAuthenticationRule() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.BootstrapAuthenticationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.BootstrapAuthenticationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.BootstrapAuthenticationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.BootstrapAuthenticationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.BootstrapAuthenticationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.BootstrapAuthenticationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.BootstrapAuthenticationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CaConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.CaConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.CaConfig>
    {
        public CaConfig(Azure.ResourceManager.DeviceOnboarding.Models.CertificateProperties properties) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DeviceOnboarding.Models.CertificateProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.CaConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.CaConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.CaConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.CaConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.CaConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.CaConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.CaConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CertificateIssuanceRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.CertificateIssuanceRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.CertificateIssuanceRule>
    {
        public CertificateIssuanceRule(Azure.ResourceManager.DeviceOnboarding.Models.SupportedIssuingAuthority issuingAuthority, Azure.ResourceManager.DeviceOnboarding.Models.CaConfig certificateAuthorityConfiguration, Azure.ResourceManager.DeviceOnboarding.Models.CertPolicyConfig leafCertificateConfiguration, int renewalInterval) { }
        public Azure.ResourceManager.DeviceOnboarding.Models.CaConfig CertificateAuthorityConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.SupportedIssuingAuthority IssuingAuthority { get { throw null; } set { } }
        public int? LeafCertificateValidityPeriodInDays { get { throw null; } set { } }
        public int RenewalInterval { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.CertificateIssuanceRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.CertificateIssuanceRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.CertificateIssuanceRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.CertificateIssuanceRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.CertificateIssuanceRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.CertificateIssuanceRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.CertificateIssuanceRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CertificateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.CertificateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.CertificateProperties>
    {
        public CertificateProperties(Azure.ResourceManager.DeviceOnboarding.Models.SupportedKeyType keyType) { }
        public Azure.ResourceManager.DeviceOnboarding.Models.SupportedKeyType KeyType { get { throw null; } set { } }
        public string Subject { get { throw null; } }
        public System.DateTimeOffset? ValidityNotAfter { get { throw null; } }
        public System.DateTimeOffset? ValidityNotBefore { get { throw null; } }
        public int? ValidityPeriodInDays { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.CertificateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.CertificateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.CertificateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.CertificateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.CertificateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.CertificateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.CertificateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CertPolicyConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.CertPolicyConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.CertPolicyConfig>
    {
        public CertPolicyConfig(int validityPeriodInDays) { }
        public int ValidityPeriodInDays { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.CertPolicyConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.CertPolicyConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.CertPolicyConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.CertPolicyConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.CertPolicyConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.CertPolicyConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.CertPolicyConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceOnboardingPrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnection>
    {
        internal DeviceOnboardingPrivateEndpointConnection() { }
        public Azure.ResourceManager.DeviceOnboarding.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceOnboardingPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceOnboardingPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceOnboardingPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceOnboardingPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceOnboardingPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateLinkServiceConnectionState>
    {
        internal DeviceOnboardingPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointServiceConnectionStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryNamespacePolicyResourceDetails : Azure.ResourceManager.DeviceOnboarding.Models.PolicyResourceDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryNamespacePolicyResourceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryNamespacePolicyResourceDetails>
    {
        public DeviceRegistryNamespacePolicyResourceDetails() { }
        public Azure.Core.ResourceIdentifier JitNamespaceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.IdentityInfo OperationalIdentityInfo { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ResourceMetadataCustomAttributes { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryNamespacePolicyResourceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryNamespacePolicyResourceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryNamespacePolicyResourceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryNamespacePolicyResourceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryNamespacePolicyResourceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryNamespacePolicyResourceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryNamespacePolicyResourceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceRegistryPolicyResourceDetails : Azure.ResourceManager.DeviceOnboarding.Models.PolicyResourceDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryPolicyResourceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryPolicyResourceDetails>
    {
        public DeviceRegistryPolicyResourceDetails() { }
        public Azure.ResourceManager.DeviceOnboarding.Models.IdentityInfo OperationalIdentityInfo { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ResourceMetadataCustomAttributes { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryPolicyResourceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryPolicyResourceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryPolicyResourceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryPolicyResourceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryPolicyResourceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryPolicyResourceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceRegistryPolicyResourceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceStateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceStateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceStateProperties>
    {
        public DeviceStateProperties(string registrationId, Azure.ResourceManager.DeviceOnboarding.Models.OnboardingStatus onboardingStatus, Azure.Core.ResourceIdentifier policyResourceId) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceOnboarding.Models.AllocatedEndpoint> AllocatedEndpoints { get { throw null; } }
        public Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryOption? DiscoveryEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.OnboardingStatus OnboardingStatus { get { throw null; } set { } }
        public System.DateTimeOffset? OnboardUntilOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RegistrationId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.DeviceStateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceStateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceStateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.DeviceStateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceStateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceStateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DeviceStateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoveryOption : System.IEquatable<Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoveryOption(string value) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryOption False { get { throw null; } }
        public static Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryOption True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryOption left, Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryOption left, Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscoveryServiceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryServiceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryServiceProperties>
    {
        public DiscoveryServiceProperties() { }
        public string DeviceEndpointHostName { get { throw null; } }
        public Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryServiceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryServiceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryServiceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryServiceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryServiceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryServiceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.DiscoveryServiceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointType : System.IEquatable<Azure.ResourceManager.DeviceOnboarding.Models.EndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointType(string value) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.EndpointType MicrosoftEventGridNamespace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceOnboarding.Models.EndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceOnboarding.Models.EndpointType left, Azure.ResourceManager.DeviceOnboarding.Models.EndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceOnboarding.Models.EndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceOnboarding.Models.EndpointType left, Azure.ResourceManager.DeviceOnboarding.Models.EndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EvenlyDistributedAllocationRule : Azure.ResourceManager.DeviceOnboarding.Models.AllocationRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.EvenlyDistributedAllocationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.EvenlyDistributedAllocationRule>
    {
        public EvenlyDistributedAllocationRule(string name, Azure.ResourceManager.DeviceOnboarding.Models.EndpointType endpointType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceOnboarding.Models.AllocationEndpoint> endpoints) : base (default(string), default(Azure.ResourceManager.DeviceOnboarding.Models.EndpointType)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceOnboarding.Models.AllocationEndpoint> Endpoints { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.EvenlyDistributedAllocationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.EvenlyDistributedAllocationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.EvenlyDistributedAllocationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.EvenlyDistributedAllocationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.EvenlyDistributedAllocationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.EvenlyDistributedAllocationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.EvenlyDistributedAllocationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FdoBootstrapAuthenticationRule : Azure.ResourceManager.DeviceOnboarding.Models.BootstrapAuthenticationRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.FdoBootstrapAuthenticationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.FdoBootstrapAuthenticationRule>
    {
        public FdoBootstrapAuthenticationRule() { }
        public Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherStorage OwnershipVoucherStorage { get { throw null; } set { } }
        public System.Uri RendezvousEndpoint { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<byte[]> Secp256R1Default { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.FdoBootstrapAuthenticationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.FdoBootstrapAuthenticationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.FdoBootstrapAuthenticationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.FdoBootstrapAuthenticationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.FdoBootstrapAuthenticationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.FdoBootstrapAuthenticationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.FdoBootstrapAuthenticationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputePolicyResourceDetails : Azure.ResourceManager.DeviceOnboarding.Models.PolicyResourceDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.HybridComputePolicyResourceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.HybridComputePolicyResourceDetails>
    {
        public HybridComputePolicyResourceDetails() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.HybridComputePolicyResourceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.HybridComputePolicyResourceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.HybridComputePolicyResourceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.HybridComputePolicyResourceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.HybridComputePolicyResourceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.HybridComputePolicyResourceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.HybridComputePolicyResourceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IdentityInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.IdentityInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.IdentityInfo>
    {
        public IdentityInfo(string deviceTemplateId, string staticGroupId) { }
        public Azure.ResourceManager.DeviceOnboarding.Models.CertificateIssuanceRule CertificateIssuance { get { throw null; } set { } }
        public string DeviceTemplateId { get { throw null; } set { } }
        public string StaticGroupId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.IdentityInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.IdentityInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.IdentityInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.IdentityInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.IdentityInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.IdentityInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.IdentityInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JitRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.JitRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.JitRule>
    {
        public JitRule(int priority, string subscriptionId, string resourceGroupName) { }
        public int Priority { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.JitRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.JitRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.JitRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.JitRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.JitRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.JitRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.JitRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JitRulePatchUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.JitRulePatchUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.JitRulePatchUpdate>
    {
        public JitRulePatchUpdate() { }
        public int? Priority { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.JitRulePatchUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.JitRulePatchUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.JitRulePatchUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.JitRulePatchUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.JitRulePatchUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.JitRulePatchUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.JitRulePatchUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnboardingServiceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.OnboardingServiceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.OnboardingServiceProperties>
    {
        public OnboardingServiceProperties(bool enableCertificateManagement) { }
        public string DefaultHostName { get { throw null; } }
        public bool EnableCertificateManagement { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DeviceOnboarding.Models.PublicNetworkAccessOption? PublicNetworkAccess { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.OnboardingServiceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.OnboardingServiceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.OnboardingServiceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.OnboardingServiceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.OnboardingServiceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.OnboardingServiceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.OnboardingServiceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnboardingStatus : System.IEquatable<Azure.ResourceManager.DeviceOnboarding.Models.OnboardingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnboardingStatus(string value) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.OnboardingStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DeviceOnboarding.Models.OnboardingStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DeviceOnboarding.Models.OnboardingStatus Provisioned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceOnboarding.Models.OnboardingStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceOnboarding.Models.OnboardingStatus left, Azure.ResourceManager.DeviceOnboarding.Models.OnboardingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceOnboarding.Models.OnboardingStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceOnboarding.Models.OnboardingStatus left, Azure.ResourceManager.DeviceOnboarding.Models.OnboardingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OwnershipVoucherPublicKeyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherPublicKeyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherPublicKeyProperties>
    {
        public OwnershipVoucherPublicKeyProperties(Azure.ResourceManager.DeviceOnboarding.Models.PublicKeyDetails publicKeyDetails) { }
        public Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DeviceOnboarding.Models.PublicKeyDetails PublicKeyDetails { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherPublicKeyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherPublicKeyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherPublicKeyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherPublicKeyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherPublicKeyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherPublicKeyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherPublicKeyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class OwnershipVoucherStorage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherStorage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherStorage>
    {
        protected OwnershipVoucherStorage() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherStorage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherStorage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherStorage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherStorage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherStorage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherStorage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherStorage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatchAllocationEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchAllocationEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchAllocationEndpoint>
    {
        public PatchAllocationEndpoint() { }
        public string HostName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchAllocationEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchAllocationEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchAllocationEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchAllocationEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchAllocationEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchAllocationEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchAllocationEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class PatchBootstrapAuthenticationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchBootstrapAuthenticationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchBootstrapAuthenticationRule>
    {
        protected PatchBootstrapAuthenticationRule() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchBootstrapAuthenticationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchBootstrapAuthenticationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchBootstrapAuthenticationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchBootstrapAuthenticationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchBootstrapAuthenticationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchBootstrapAuthenticationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchBootstrapAuthenticationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatchDeviceRegistryNamespacePolicyResourceDetails : Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchResourceDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryNamespacePolicyResourceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryNamespacePolicyResourceDetails>
    {
        public PatchDeviceRegistryNamespacePolicyResourceDetails() { }
        public Azure.Core.ResourceIdentifier JitNamespaceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.IdentityInfo OperationalIdentityInfo { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ResourceMetadataCustomAttributes { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryNamespacePolicyResourceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryNamespacePolicyResourceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryNamespacePolicyResourceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryNamespacePolicyResourceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryNamespacePolicyResourceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryNamespacePolicyResourceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryNamespacePolicyResourceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatchDeviceRegistryPolicyResourceDetails : Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchResourceDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryPolicyResourceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryPolicyResourceDetails>
    {
        public PatchDeviceRegistryPolicyResourceDetails() { }
        public Azure.ResourceManager.DeviceOnboarding.Models.IdentityInfo OperationalIdentityInfo { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ResourceMetadataCustomAttributes { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryPolicyResourceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryPolicyResourceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryPolicyResourceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryPolicyResourceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryPolicyResourceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryPolicyResourceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchDeviceRegistryPolicyResourceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatchEvenlyDistributedAllocationRule : Azure.ResourceManager.DeviceOnboarding.Models.AllocationRulePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchEvenlyDistributedAllocationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchEvenlyDistributedAllocationRule>
    {
        public PatchEvenlyDistributedAllocationRule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceOnboarding.Models.PatchAllocationEndpoint> Endpoints { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchEvenlyDistributedAllocationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchEvenlyDistributedAllocationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchEvenlyDistributedAllocationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchEvenlyDistributedAllocationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchEvenlyDistributedAllocationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchEvenlyDistributedAllocationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchEvenlyDistributedAllocationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatchFdoBootstrapAuthenticationRule : Azure.ResourceManager.DeviceOnboarding.Models.PatchBootstrapAuthenticationRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchFdoBootstrapAuthenticationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchFdoBootstrapAuthenticationRule>
    {
        public PatchFdoBootstrapAuthenticationRule() { }
        public Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherStorage OwnershipVoucherStorage { get { throw null; } set { } }
        public System.Uri RendezvousEndpoint { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<byte[]> Secp256R1Default { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchFdoBootstrapAuthenticationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchFdoBootstrapAuthenticationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchFdoBootstrapAuthenticationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchFdoBootstrapAuthenticationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchFdoBootstrapAuthenticationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchFdoBootstrapAuthenticationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchFdoBootstrapAuthenticationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatchHybridComputePolicyResourceDetails : Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchResourceDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchHybridComputePolicyResourceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchHybridComputePolicyResourceDetails>
    {
        public PatchHybridComputePolicyResourceDetails() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchHybridComputePolicyResourceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchHybridComputePolicyResourceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchHybridComputePolicyResourceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchHybridComputePolicyResourceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchHybridComputePolicyResourceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchHybridComputePolicyResourceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchHybridComputePolicyResourceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatchSelectedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchSelectedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchSelectedIdentity>
    {
        public PatchSelectedIdentity() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentityType? Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchSelectedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchSelectedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchSelectedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchSelectedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchSelectedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchSelectedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchSelectedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatchX509BootstrapAuthenticationRule : Azure.ResourceManager.DeviceOnboarding.Models.PatchBootstrapAuthenticationRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchX509BootstrapAuthenticationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchX509BootstrapAuthenticationRule>
    {
        public PatchX509BootstrapAuthenticationRule() { }
        public Azure.ResourceManager.DeviceOnboarding.Models.PatchX509Certificate PrimaryCertificate { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.PatchX509Certificate SecondaryCertificate { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchX509BootstrapAuthenticationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchX509BootstrapAuthenticationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchX509BootstrapAuthenticationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchX509BootstrapAuthenticationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchX509BootstrapAuthenticationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchX509BootstrapAuthenticationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchX509BootstrapAuthenticationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PatchX509Certificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchX509Certificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchX509Certificate>
    {
        public PatchX509Certificate() { }
        public byte[] Certificate { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchX509Certificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchX509Certificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchX509Certificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PatchX509Certificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchX509Certificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchX509Certificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PatchX509Certificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatch>
    {
        public PolicyPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchProperties>
    {
        public PolicyPatchProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRulePatch> Allocations { get { throw null; } }
        public Azure.ResourceManager.DeviceOnboarding.Models.PatchBootstrapAuthenticationRule BootstrapAuthentication { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.JitRulePatchUpdate Jit { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchResourceDetails ResourceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.PatchSelectedIdentity SelectedIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.PolicyStatusOption? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class PolicyPatchResourceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchResourceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchResourceDetails>
    {
        protected PolicyPatchResourceDetails() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchResourceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchResourceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchResourceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchResourceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchResourceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchResourceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyPatchResourceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyProperties>
    {
        public PolicyProperties(Azure.ResourceManager.DeviceOnboarding.Models.PolicyStatusOption status, Azure.ResourceManager.DeviceOnboarding.Models.BootstrapAuthenticationRule bootstrapAuthentication, Azure.ResourceManager.DeviceOnboarding.Models.PolicyResourceDetails resourceDetails) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceOnboarding.Models.AllocationRule> Allocations { get { throw null; } }
        public Azure.ResourceManager.DeviceOnboarding.Models.BootstrapAuthenticationRule BootstrapAuthentication { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.JitRule Jit { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DeviceOnboarding.Models.PolicyResourceDetails ResourceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentity SelectedIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.PolicyStatusOption Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class PolicyResourceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyResourceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyResourceDetails>
    {
        protected PolicyResourceDetails() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PolicyResourceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyResourceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyResourceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PolicyResourceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyResourceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyResourceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PolicyResourceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyStatusOption : System.IEquatable<Azure.ResourceManager.DeviceOnboarding.Models.PolicyStatusOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyStatusOption(string value) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.PolicyStatusOption Disabled { get { throw null; } }
        public static Azure.ResourceManager.DeviceOnboarding.Models.PolicyStatusOption Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceOnboarding.Models.PolicyStatusOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceOnboarding.Models.PolicyStatusOption left, Azure.ResourceManager.DeviceOnboarding.Models.PolicyStatusOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceOnboarding.Models.PolicyStatusOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceOnboarding.Models.PolicyStatusOption left, Azure.ResourceManager.DeviceOnboarding.Models.PolicyStatusOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrepareForOnboardingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PrepareForOnboardingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PrepareForOnboardingProperties>
    {
        public PrepareForOnboardingProperties(System.TimeSpan ttl) { }
        public System.TimeSpan Ttl { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PrepareForOnboardingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PrepareForOnboardingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PrepareForOnboardingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PrepareForOnboardingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PrepareForOnboardingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PrepareForOnboardingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PrepareForOnboardingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PrivateEndpointConnectionProperties>
    {
        internal PrivateEndpointConnectionProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.DeviceOnboarding.Models.DeviceOnboardingPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState left, Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState left, Azure.ResourceManager.DeviceOnboarding.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class PublicKeyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PublicKeyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PublicKeyDetails>
    {
        protected PublicKeyDetails() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PublicKeyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PublicKeyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.PublicKeyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.PublicKeyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PublicKeyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PublicKeyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.PublicKeyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccessOption : System.IEquatable<Azure.ResourceManager.DeviceOnboarding.Models.PublicNetworkAccessOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccessOption(string value) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.PublicNetworkAccessOption Disabled { get { throw null; } }
        public static Azure.ResourceManager.DeviceOnboarding.Models.PublicNetworkAccessOption Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceOnboarding.Models.PublicNetworkAccessOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceOnboarding.Models.PublicNetworkAccessOption left, Azure.ResourceManager.DeviceOnboarding.Models.PublicNetworkAccessOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceOnboarding.Models.PublicNetworkAccessOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceOnboarding.Models.PublicNetworkAccessOption left, Azure.ResourceManager.DeviceOnboarding.Models.PublicNetworkAccessOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelectedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentity>
    {
        public SelectedIdentity(Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentityType type) { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentityType Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelectedIdentityType : System.IEquatable<Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelectedIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentityType left, Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentityType left, Azure.ResourceManager.DeviceOnboarding.Models.SelectedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageAccountOwnershipVoucherStorage : Azure.ResourceManager.DeviceOnboarding.Models.OwnershipVoucherStorage, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.StorageAccountOwnershipVoucherStorage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.StorageAccountOwnershipVoucherStorage>
    {
        public StorageAccountOwnershipVoucherStorage(Azure.Core.ResourceIdentifier resourceId, System.Uri containerUri) { }
        public System.Uri ContainerUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.StorageAccountOwnershipVoucherStorage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.StorageAccountOwnershipVoucherStorage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.StorageAccountOwnershipVoucherStorage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.StorageAccountOwnershipVoucherStorage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.StorageAccountOwnershipVoucherStorage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.StorageAccountOwnershipVoucherStorage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.StorageAccountOwnershipVoucherStorage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SupportedIssuingAuthority : System.IEquatable<Azure.ResourceManager.DeviceOnboarding.Models.SupportedIssuingAuthority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportedIssuingAuthority(string value) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.SupportedIssuingAuthority FirstParty { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceOnboarding.Models.SupportedIssuingAuthority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceOnboarding.Models.SupportedIssuingAuthority left, Azure.ResourceManager.DeviceOnboarding.Models.SupportedIssuingAuthority right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceOnboarding.Models.SupportedIssuingAuthority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceOnboarding.Models.SupportedIssuingAuthority left, Azure.ResourceManager.DeviceOnboarding.Models.SupportedIssuingAuthority right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SupportedKeyType : System.IEquatable<Azure.ResourceManager.DeviceOnboarding.Models.SupportedKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportedKeyType(string value) { throw null; }
        public static Azure.ResourceManager.DeviceOnboarding.Models.SupportedKeyType ECC { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceOnboarding.Models.SupportedKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceOnboarding.Models.SupportedKeyType left, Azure.ResourceManager.DeviceOnboarding.Models.SupportedKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceOnboarding.Models.SupportedKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceOnboarding.Models.SupportedKeyType left, Azure.ResourceManager.DeviceOnboarding.Models.SupportedKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class X509BootstrapAuthenticationRule : Azure.ResourceManager.DeviceOnboarding.Models.BootstrapAuthenticationRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.X509BootstrapAuthenticationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.X509BootstrapAuthenticationRule>
    {
        public X509BootstrapAuthenticationRule(Azure.ResourceManager.DeviceOnboarding.Models.X509Certificate primaryCertificate) { }
        public Azure.ResourceManager.DeviceOnboarding.Models.X509Certificate PrimaryCertificate { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceOnboarding.Models.X509Certificate SecondaryCertificate { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.X509BootstrapAuthenticationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.X509BootstrapAuthenticationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.X509BootstrapAuthenticationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.X509BootstrapAuthenticationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.X509BootstrapAuthenticationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.X509BootstrapAuthenticationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.X509BootstrapAuthenticationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class X509Certificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.X509Certificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.X509Certificate>
    {
        public X509Certificate(byte[] certificate) { }
        public byte[] Certificate { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.X509Certificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.X509Certificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.X509Certificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.X509Certificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.X509Certificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.X509Certificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.X509Certificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class X5ChainPublicKeyDetails : Azure.ResourceManager.DeviceOnboarding.Models.PublicKeyDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.X5ChainPublicKeyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.X5ChainPublicKeyDetails>
    {
        public X5ChainPublicKeyDetails(System.Collections.Generic.IEnumerable<byte[]> x5Chain) { }
        public System.Collections.Generic.IList<byte[]> X5Chain { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.X5ChainPublicKeyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.X5ChainPublicKeyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceOnboarding.Models.X5ChainPublicKeyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceOnboarding.Models.X5ChainPublicKeyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.X5ChainPublicKeyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.X5ChainPublicKeyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceOnboarding.Models.X5ChainPublicKeyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
