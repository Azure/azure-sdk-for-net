namespace Azure.ResourceManager.Avs
{
    public partial class AddonCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AddonResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AddonResource>, System.Collections.IEnumerable
    {
        protected AddonCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AddonResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string addonName, Azure.ResourceManager.Avs.AddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AddonResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string addonName, Azure.ResourceManager.Avs.AddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AddonResource> Get(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AddonResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AddonResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AddonResource>> GetAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.AddonResource> GetIfExists(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.AddonResource>> GetIfExistsAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.AddonResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AddonResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.AddonResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AddonResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AddonData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AddonData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AddonData>
    {
        public AddonData() { }
        public Azure.ResourceManager.Avs.Models.AddonProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AddonData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AddonData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AddonData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AddonData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AddonData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AddonData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AddonData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AddonResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AddonData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AddonData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AddonResource() { }
        public virtual Azure.ResourceManager.Avs.AddonData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string addonName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AddonResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AddonResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.AddonData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AddonData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AddonData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AddonData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AddonData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AddonData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AddonData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AddonResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AddonResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class AvsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Avs.Models.Quota> CheckQuotaAvailabilityLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.Quota>> CheckQuotaAvailabilityLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Avs.Models.Trial> CheckTrialAvailabilityLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Avs.Models.AvsSku sku = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.Trial>> CheckTrialAvailabilityLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.Avs.Models.AvsSku sku = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Avs.AddonResource GetAddonResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.CloudLinkResource GetCloudLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.ClusterResource GetClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.DatastoreResource GetDatastoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource GetExpressRouteAuthorizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.GlobalReachConnectionResource GetGlobalReachConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.HcxEnterpriseSiteResource GetHcxEnterpriseSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.HostResource GetHostResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.IscsiPathResource GetIscsiPathResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.PlacementPolicyResource GetPlacementPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource> GetPrivateCloud(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource>> GetPrivateCloudAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Avs.PrivateCloudResource GetPrivateCloudResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.PrivateCloudCollection GetPrivateClouds(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Avs.PrivateCloudResource> GetPrivateClouds(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Avs.PrivateCloudResource> GetPrivateCloudsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Avs.ProvisionedNetworkResource GetProvisionedNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.PureStoragePolicyResource GetPureStoragePolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptCmdletResource GetScriptCmdletResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptExecutionResource GetScriptExecutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptPackageResource GetScriptPackageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Avs.Models.ResourceSku> GetSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Avs.Models.ResourceSku> GetSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Avs.VirtualMachineResource GetVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource GetWorkloadNetworkDhcpResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource GetWorkloadNetworkDnsServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource GetWorkloadNetworkDnsZoneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource GetWorkloadNetworkGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource GetWorkloadNetworkPortMirroringResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource GetWorkloadNetworkPublicIPResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkResource GetWorkloadNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource GetWorkloadNetworkSegmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource GetWorkloadNetworkVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource GetWorkloadNetworkVmGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class AzureResourceManagerAvsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerAvsContext() { }
        public static Azure.ResourceManager.Avs.AzureResourceManagerAvsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CloudLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.CloudLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.CloudLinkResource>, System.Collections.IEnumerable
    {
        protected CloudLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.CloudLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudLinkName, Azure.ResourceManager.Avs.CloudLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.CloudLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudLinkName, Azure.ResourceManager.Avs.CloudLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.CloudLinkResource> Get(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.CloudLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.CloudLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.CloudLinkResource>> GetAsync(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.CloudLinkResource> GetIfExists(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.CloudLinkResource>> GetIfExistsAsync(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.CloudLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.CloudLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.CloudLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.CloudLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudLinkData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.CloudLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.CloudLinkData>
    {
        public CloudLinkData() { }
        public Azure.ResourceManager.Avs.Models.CloudLinkProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.CloudLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.CloudLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.CloudLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.CloudLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.CloudLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.CloudLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.CloudLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.CloudLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.CloudLinkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudLinkResource() { }
        public virtual Azure.ResourceManager.Avs.CloudLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string cloudLinkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.CloudLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.CloudLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.CloudLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.CloudLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.CloudLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.CloudLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.CloudLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.CloudLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.CloudLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.CloudLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.CloudLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.CloudLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.CloudLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ClusterResource>, System.Collections.IEnumerable
    {
        protected ClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Avs.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Avs.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.ClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.ClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.ClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.ClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.ClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.ClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ClusterData>
    {
        public ClusterData(Azure.ResourceManager.Avs.Models.AvsSku sku) { }
        public Azure.ResourceManager.Avs.Models.ClusterProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterResource() { }
        public virtual Azure.ResourceManager.Avs.ClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.DatastoreResource> GetDatastore(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.DatastoreResource>> GetDatastoreAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.DatastoreCollection GetDatastores() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.HostResource> GetHost(string hostId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.HostResource>> GetHostAsync(string hostId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.HostCollection GetHosts() { throw null; }
        public virtual Azure.ResourceManager.Avs.PlacementPolicyCollection GetPlacementPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PlacementPolicyResource> GetPlacementPolicy(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PlacementPolicyResource>> GetPlacementPolicyAsync(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.VirtualMachineResource> GetVirtualMachine(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.VirtualMachineResource>> GetVirtualMachineAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.VirtualMachineCollection GetVirtualMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.Models.ClusterZoneList> GetZones(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.ClusterZoneList>> GetZonesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.ClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatastoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.DatastoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.DatastoreResource>, System.Collections.IEnumerable
    {
        protected DatastoreCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.DatastoreResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string datastoreName, Azure.ResourceManager.Avs.DatastoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.DatastoreResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string datastoreName, Azure.ResourceManager.Avs.DatastoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.DatastoreResource> Get(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.DatastoreResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.DatastoreResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.DatastoreResource>> GetAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.DatastoreResource> GetIfExists(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.DatastoreResource>> GetIfExistsAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.DatastoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.DatastoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.DatastoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.DatastoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatastoreData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.DatastoreData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.DatastoreData>
    {
        public DatastoreData() { }
        public Azure.ResourceManager.Avs.Models.DatastoreProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.DatastoreData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.DatastoreData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.DatastoreData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.DatastoreData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.DatastoreData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.DatastoreData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.DatastoreData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatastoreResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.DatastoreData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.DatastoreData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatastoreResource() { }
        public virtual Azure.ResourceManager.Avs.DatastoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string clusterName, string datastoreName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.DatastoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.DatastoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.DatastoreData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.DatastoreData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.DatastoreData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.DatastoreData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.DatastoreData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.DatastoreData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.DatastoreData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.DatastoreResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.DatastoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.DatastoreResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.DatastoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExpressRouteAuthorizationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>, System.Collections.IEnumerable
    {
        protected ExpressRouteAuthorizationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationName, Azure.ResourceManager.Avs.ExpressRouteAuthorizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationName, Azure.ResourceManager.Avs.ExpressRouteAuthorizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> Get(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>> GetAsync(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> GetIfExists(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>> GetIfExistsAsync(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExpressRouteAuthorizationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ExpressRouteAuthorizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ExpressRouteAuthorizationData>
    {
        public ExpressRouteAuthorizationData() { }
        public Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ExpressRouteAuthorizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ExpressRouteAuthorizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ExpressRouteAuthorizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ExpressRouteAuthorizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ExpressRouteAuthorizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ExpressRouteAuthorizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ExpressRouteAuthorizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExpressRouteAuthorizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ExpressRouteAuthorizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ExpressRouteAuthorizationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExpressRouteAuthorizationResource() { }
        public virtual Azure.ResourceManager.Avs.ExpressRouteAuthorizationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string authorizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.ExpressRouteAuthorizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ExpressRouteAuthorizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ExpressRouteAuthorizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ExpressRouteAuthorizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ExpressRouteAuthorizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ExpressRouteAuthorizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ExpressRouteAuthorizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.ExpressRouteAuthorizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.ExpressRouteAuthorizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GlobalReachConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.GlobalReachConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.GlobalReachConnectionResource>, System.Collections.IEnumerable
    {
        protected GlobalReachConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.GlobalReachConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string globalReachConnectionName, Azure.ResourceManager.Avs.GlobalReachConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.GlobalReachConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string globalReachConnectionName, Azure.ResourceManager.Avs.GlobalReachConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string globalReachConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string globalReachConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.GlobalReachConnectionResource> Get(string globalReachConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.GlobalReachConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.GlobalReachConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.GlobalReachConnectionResource>> GetAsync(string globalReachConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.GlobalReachConnectionResource> GetIfExists(string globalReachConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.GlobalReachConnectionResource>> GetIfExistsAsync(string globalReachConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.GlobalReachConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.GlobalReachConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.GlobalReachConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.GlobalReachConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GlobalReachConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.GlobalReachConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.GlobalReachConnectionData>
    {
        public GlobalReachConnectionData() { }
        public Azure.ResourceManager.Avs.Models.GlobalReachConnectionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.GlobalReachConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.GlobalReachConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.GlobalReachConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.GlobalReachConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.GlobalReachConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.GlobalReachConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.GlobalReachConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GlobalReachConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.GlobalReachConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.GlobalReachConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GlobalReachConnectionResource() { }
        public virtual Azure.ResourceManager.Avs.GlobalReachConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string globalReachConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.GlobalReachConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.GlobalReachConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.GlobalReachConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.GlobalReachConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.GlobalReachConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.GlobalReachConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.GlobalReachConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.GlobalReachConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.GlobalReachConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.GlobalReachConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.GlobalReachConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.GlobalReachConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.GlobalReachConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HcxEnterpriseSiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>, System.Collections.IEnumerable
    {
        protected HcxEnterpriseSiteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hcxEnterpriseSiteName, Azure.ResourceManager.Avs.HcxEnterpriseSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hcxEnterpriseSiteName, Azure.ResourceManager.Avs.HcxEnterpriseSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hcxEnterpriseSiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hcxEnterpriseSiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> Get(string hcxEnterpriseSiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>> GetAsync(string hcxEnterpriseSiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> GetIfExists(string hcxEnterpriseSiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>> GetIfExistsAsync(string hcxEnterpriseSiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HcxEnterpriseSiteData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.HcxEnterpriseSiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.HcxEnterpriseSiteData>
    {
        public HcxEnterpriseSiteData() { }
        public Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.HcxEnterpriseSiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.HcxEnterpriseSiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.HcxEnterpriseSiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.HcxEnterpriseSiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.HcxEnterpriseSiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.HcxEnterpriseSiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.HcxEnterpriseSiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HcxEnterpriseSiteResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.HcxEnterpriseSiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.HcxEnterpriseSiteData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HcxEnterpriseSiteResource() { }
        public virtual Azure.ResourceManager.Avs.HcxEnterpriseSiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string hcxEnterpriseSiteName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.HcxEnterpriseSiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.HcxEnterpriseSiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.HcxEnterpriseSiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.HcxEnterpriseSiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.HcxEnterpriseSiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.HcxEnterpriseSiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.HcxEnterpriseSiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.HcxEnterpriseSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.HcxEnterpriseSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HostCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.HostResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.HostResource>, System.Collections.IEnumerable
    {
        protected HostCollection() { }
        public virtual Azure.Response<bool> Exists(string hostId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hostId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.HostResource> Get(string hostId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.HostResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.HostResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.HostResource>> GetAsync(string hostId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.HostResource> GetIfExists(string hostId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.HostResource>> GetIfExistsAsync(string hostId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.HostResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.HostResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.HostResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.HostResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HostData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.HostData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.HostData>
    {
        internal HostData() { }
        public Azure.ResourceManager.Avs.Models.HostProperties Properties { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsSku Sku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.HostData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.HostData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.HostData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.HostData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.HostData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.HostData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.HostData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HostResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.HostData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.HostData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HostResource() { }
        public virtual Azure.ResourceManager.Avs.HostData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string clusterName, string hostId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.HostResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.HostResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.HostData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.HostData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.HostData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.HostData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.HostData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.HostData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.HostData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IscsiPathData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.IscsiPathData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.IscsiPathData>
    {
        public IscsiPathData() { }
        public Azure.ResourceManager.Avs.Models.IscsiPathProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.IscsiPathData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.IscsiPathData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.IscsiPathData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.IscsiPathData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.IscsiPathData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.IscsiPathData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.IscsiPathData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IscsiPathResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.IscsiPathData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.IscsiPathData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IscsiPathResource() { }
        public virtual Azure.ResourceManager.Avs.IscsiPathData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.IscsiPathResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.IscsiPathData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.IscsiPathResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.IscsiPathData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.IscsiPathResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.IscsiPathResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.IscsiPathData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.IscsiPathData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.IscsiPathData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.IscsiPathData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.IscsiPathData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.IscsiPathData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.IscsiPathData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlacementPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.PlacementPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.PlacementPolicyResource>, System.Collections.IEnumerable
    {
        protected PlacementPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PlacementPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string placementPolicyName, Azure.ResourceManager.Avs.PlacementPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PlacementPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string placementPolicyName, Azure.ResourceManager.Avs.PlacementPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PlacementPolicyResource> Get(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.PlacementPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.PlacementPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PlacementPolicyResource>> GetAsync(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.PlacementPolicyResource> GetIfExists(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.PlacementPolicyResource>> GetIfExistsAsync(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.PlacementPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.PlacementPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.PlacementPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.PlacementPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PlacementPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PlacementPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PlacementPolicyData>
    {
        public PlacementPolicyData() { }
        public Azure.ResourceManager.Avs.Models.PlacementPolicyProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.PlacementPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PlacementPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PlacementPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.PlacementPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PlacementPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PlacementPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PlacementPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlacementPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PlacementPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PlacementPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PlacementPolicyResource() { }
        public virtual Azure.ResourceManager.Avs.PlacementPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string clusterName, string placementPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PlacementPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PlacementPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.PlacementPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PlacementPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PlacementPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.PlacementPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PlacementPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PlacementPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PlacementPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PlacementPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.PlacementPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PlacementPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.PlacementPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateCloudCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.PrivateCloudResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.PrivateCloudResource>, System.Collections.IEnumerable
    {
        protected PrivateCloudCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PrivateCloudResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateCloudName, Azure.ResourceManager.Avs.PrivateCloudData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PrivateCloudResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateCloudName, Azure.ResourceManager.Avs.PrivateCloudData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource> Get(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.PrivateCloudResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.PrivateCloudResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource>> GetAsync(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.PrivateCloudResource> GetIfExists(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.PrivateCloudResource>> GetIfExistsAsync(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.PrivateCloudResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.PrivateCloudResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.PrivateCloudResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.PrivateCloudResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateCloudData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PrivateCloudData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PrivateCloudData>
    {
        public PrivateCloudData(Azure.Core.AzureLocation location, Azure.ResourceManager.Avs.Models.AvsSku sku) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.PrivateCloudProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.PrivateCloudData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PrivateCloudData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PrivateCloudData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.PrivateCloudData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PrivateCloudData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PrivateCloudData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PrivateCloudData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateCloudResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PrivateCloudData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PrivateCloudData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateCloudResource() { }
        public virtual Azure.ResourceManager.Avs.PrivateCloudData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AddonResource> GetAddon(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AddonResource>> GetAddonAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.AddonCollection GetAddons() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.Models.AdminCredentials> GetAdminCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.AdminCredentials>> GetAdminCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.CloudLinkResource> GetCloudLink(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.CloudLinkResource>> GetCloudLinkAsync(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.CloudLinkCollection GetCloudLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ClusterResource> GetCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ClusterResource>> GetClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.ClusterCollection GetClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource> GetExpressRouteAuthorization(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource>> GetExpressRouteAuthorizationAsync(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.ExpressRouteAuthorizationCollection GetExpressRouteAuthorizations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.GlobalReachConnectionResource> GetGlobalReachConnection(string globalReachConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.GlobalReachConnectionResource>> GetGlobalReachConnectionAsync(string globalReachConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.GlobalReachConnectionCollection GetGlobalReachConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource> GetHcxEnterpriseSite(string hcxEnterpriseSiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.HcxEnterpriseSiteResource>> GetHcxEnterpriseSiteAsync(string hcxEnterpriseSiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.HcxEnterpriseSiteCollection GetHcxEnterpriseSites() { throw null; }
        public virtual Azure.ResourceManager.Avs.IscsiPathResource GetIscsiPath() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ProvisionedNetworkResource> GetProvisionedNetwork(string provisionedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ProvisionedNetworkResource>> GetProvisionedNetworkAsync(string provisionedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.ProvisionedNetworkCollection GetProvisionedNetworks() { throw null; }
        public virtual Azure.ResourceManager.Avs.PureStoragePolicyCollection GetPureStoragePolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PureStoragePolicyResource> GetPureStoragePolicy(string storagePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PureStoragePolicyResource>> GetPureStoragePolicyAsync(string storagePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource> GetScriptExecution(string scriptExecutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource>> GetScriptExecutionAsync(string scriptExecutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.ScriptExecutionCollection GetScriptExecutions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptPackageResource> GetScriptPackage(string scriptPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptPackageResource>> GetScriptPackageAsync(string scriptPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.ScriptPackageCollection GetScriptPackages() { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkResource GetWorkloadNetwork() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RotateNsxtPassword(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RotateNsxtPasswordAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RotateVcenterPassword(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RotateVcenterPasswordAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.PrivateCloudData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PrivateCloudData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PrivateCloudData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.PrivateCloudData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PrivateCloudData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PrivateCloudData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PrivateCloudData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PrivateCloudResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.PrivateCloudPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PrivateCloudResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.PrivateCloudPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProvisionedNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ProvisionedNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ProvisionedNetworkResource>, System.Collections.IEnumerable
    {
        protected ProvisionedNetworkCollection() { }
        public virtual Azure.Response<bool> Exists(string provisionedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string provisionedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ProvisionedNetworkResource> Get(string provisionedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.ProvisionedNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.ProvisionedNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ProvisionedNetworkResource>> GetAsync(string provisionedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.ProvisionedNetworkResource> GetIfExists(string provisionedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.ProvisionedNetworkResource>> GetIfExistsAsync(string provisionedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.ProvisionedNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ProvisionedNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.ProvisionedNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ProvisionedNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProvisionedNetworkData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ProvisionedNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ProvisionedNetworkData>
    {
        internal ProvisionedNetworkData() { }
        public Azure.ResourceManager.Avs.Models.ProvisionedNetworkProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ProvisionedNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ProvisionedNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ProvisionedNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ProvisionedNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ProvisionedNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ProvisionedNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ProvisionedNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvisionedNetworkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ProvisionedNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ProvisionedNetworkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProvisionedNetworkResource() { }
        public virtual Azure.ResourceManager.Avs.ProvisionedNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string provisionedNetworkName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ProvisionedNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ProvisionedNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.ProvisionedNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ProvisionedNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ProvisionedNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ProvisionedNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ProvisionedNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ProvisionedNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ProvisionedNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStoragePolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.PureStoragePolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.PureStoragePolicyResource>, System.Collections.IEnumerable
    {
        protected PureStoragePolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PureStoragePolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storagePolicyName, Azure.ResourceManager.Avs.PureStoragePolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PureStoragePolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storagePolicyName, Azure.ResourceManager.Avs.PureStoragePolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storagePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storagePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PureStoragePolicyResource> Get(string storagePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.PureStoragePolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.PureStoragePolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PureStoragePolicyResource>> GetAsync(string storagePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.PureStoragePolicyResource> GetIfExists(string storagePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.PureStoragePolicyResource>> GetIfExistsAsync(string storagePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.PureStoragePolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.PureStoragePolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.PureStoragePolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.PureStoragePolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PureStoragePolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PureStoragePolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PureStoragePolicyData>
    {
        public PureStoragePolicyData() { }
        public Azure.ResourceManager.Avs.Models.PureStoragePolicyProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.PureStoragePolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PureStoragePolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PureStoragePolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.PureStoragePolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PureStoragePolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PureStoragePolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PureStoragePolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStoragePolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PureStoragePolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PureStoragePolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PureStoragePolicyResource() { }
        public virtual Azure.ResourceManager.Avs.PureStoragePolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string storagePolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PureStoragePolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PureStoragePolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.PureStoragePolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PureStoragePolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.PureStoragePolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.PureStoragePolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PureStoragePolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PureStoragePolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.PureStoragePolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PureStoragePolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.PureStoragePolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.PureStoragePolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.PureStoragePolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScriptCmdletCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ScriptCmdletResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ScriptCmdletResource>, System.Collections.IEnumerable
    {
        protected ScriptCmdletCollection() { }
        public virtual Azure.Response<bool> Exists(string scriptCmdletName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scriptCmdletName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptCmdletResource> Get(string scriptCmdletName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.ScriptCmdletResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.ScriptCmdletResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptCmdletResource>> GetAsync(string scriptCmdletName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.ScriptCmdletResource> GetIfExists(string scriptCmdletName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.ScriptCmdletResource>> GetIfExistsAsync(string scriptCmdletName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.ScriptCmdletResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ScriptCmdletResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.ScriptCmdletResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ScriptCmdletResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScriptCmdletData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptCmdletData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptCmdletData>
    {
        internal ScriptCmdletData() { }
        public Azure.ResourceManager.Avs.Models.ScriptCmdletProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ScriptCmdletData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptCmdletData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptCmdletData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ScriptCmdletData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptCmdletData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptCmdletData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptCmdletData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScriptCmdletResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptCmdletData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptCmdletData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScriptCmdletResource() { }
        public virtual Azure.ResourceManager.Avs.ScriptCmdletData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string scriptPackageName, string scriptCmdletName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptCmdletResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptCmdletResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.ScriptCmdletData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptCmdletData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptCmdletData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ScriptCmdletData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptCmdletData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptCmdletData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptCmdletData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScriptExecutionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ScriptExecutionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ScriptExecutionResource>, System.Collections.IEnumerable
    {
        protected ScriptExecutionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ScriptExecutionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scriptExecutionName, Azure.ResourceManager.Avs.ScriptExecutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ScriptExecutionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scriptExecutionName, Azure.ResourceManager.Avs.ScriptExecutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scriptExecutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scriptExecutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource> Get(string scriptExecutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.ScriptExecutionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.ScriptExecutionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource>> GetAsync(string scriptExecutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.ScriptExecutionResource> GetIfExists(string scriptExecutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.ScriptExecutionResource>> GetIfExistsAsync(string scriptExecutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.ScriptExecutionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ScriptExecutionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.ScriptExecutionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ScriptExecutionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScriptExecutionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptExecutionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptExecutionData>
    {
        public ScriptExecutionData() { }
        public Azure.ResourceManager.Avs.Models.ScriptExecutionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ScriptExecutionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptExecutionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptExecutionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ScriptExecutionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptExecutionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptExecutionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptExecutionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScriptExecutionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptExecutionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptExecutionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScriptExecutionResource() { }
        public virtual Azure.ResourceManager.Avs.ScriptExecutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string scriptExecutionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource> GetExecutionLogs(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ScriptOutputStreamType> scriptOutputStreamType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource>> GetExecutionLogsAsync(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ScriptOutputStreamType> scriptOutputStreamType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.ScriptExecutionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptExecutionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptExecutionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ScriptExecutionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptExecutionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptExecutionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptExecutionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ScriptExecutionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.ScriptExecutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.ScriptExecutionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.ScriptExecutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScriptPackageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ScriptPackageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ScriptPackageResource>, System.Collections.IEnumerable
    {
        protected ScriptPackageCollection() { }
        public virtual Azure.Response<bool> Exists(string scriptPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scriptPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptPackageResource> Get(string scriptPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.ScriptPackageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.ScriptPackageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptPackageResource>> GetAsync(string scriptPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.ScriptPackageResource> GetIfExists(string scriptPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.ScriptPackageResource>> GetIfExistsAsync(string scriptPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.ScriptPackageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.ScriptPackageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.ScriptPackageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.ScriptPackageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScriptPackageData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptPackageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptPackageData>
    {
        internal ScriptPackageData() { }
        public Azure.ResourceManager.Avs.Models.ScriptPackageProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ScriptPackageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptPackageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptPackageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ScriptPackageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptPackageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptPackageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptPackageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScriptPackageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptPackageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptPackageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScriptPackageResource() { }
        public virtual Azure.ResourceManager.Avs.ScriptPackageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string scriptPackageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptPackageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptPackageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptCmdletResource> GetScriptCmdlet(string scriptCmdletName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptCmdletResource>> GetScriptCmdletAsync(string scriptCmdletName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.ScriptCmdletCollection GetScriptCmdlets() { throw null; }
        Azure.ResourceManager.Avs.ScriptPackageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptPackageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.ScriptPackageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.ScriptPackageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptPackageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptPackageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.ScriptPackageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.VirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.VirtualMachineResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.VirtualMachineResource> Get(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.VirtualMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.VirtualMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.VirtualMachineResource>> GetAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.VirtualMachineResource> GetIfExists(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.VirtualMachineResource>> GetIfExistsAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.VirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.VirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.VirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.VirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.VirtualMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.VirtualMachineData>
    {
        internal VirtualMachineData() { }
        public Azure.ResourceManager.Avs.Models.VirtualMachineProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.VirtualMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.VirtualMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.VirtualMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.VirtualMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.VirtualMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.VirtualMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.VirtualMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.VirtualMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.VirtualMachineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineResource() { }
        public virtual Azure.ResourceManager.Avs.VirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string clusterName, string virtualMachineId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.VirtualMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.VirtualMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestrictMovement(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovement restrictMovement, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestrictMovementAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovement restrictMovement, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.VirtualMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.VirtualMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.VirtualMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.VirtualMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.VirtualMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.VirtualMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.VirtualMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkData>
    {
        internal WorkloadNetworkData() { }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState? WorkloadNetworkProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkDhcpCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkDhcpCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dhcpId, Azure.ResourceManager.Avs.WorkloadNetworkDhcpData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dhcpId, Azure.ResourceManager.Avs.WorkloadNetworkDhcpData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dhcpId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dhcpId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> Get(string dhcpId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>> GetAsync(string dhcpId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> GetIfExists(string dhcpId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>> GetIfExistsAsync(string dhcpId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkDhcpData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDhcpData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDhcpData>
    {
        public WorkloadNetworkDhcpData() { }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkDhcpData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDhcpData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDhcpData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkDhcpData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDhcpData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDhcpData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDhcpData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkDhcpResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDhcpData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDhcpData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkDhcpResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDhcpData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string dhcpId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.WorkloadNetworkDhcpData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDhcpData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDhcpData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkDhcpData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDhcpData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDhcpData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDhcpData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkDhcpData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkDhcpData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadNetworkDnsServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkDnsServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dnsServiceId, Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dnsServiceId, Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dnsServiceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsServiceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> Get(string dnsServiceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>> GetAsync(string dnsServiceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> GetIfExists(string dnsServiceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>> GetIfExistsAsync(string dnsServiceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkDnsServiceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData>
    {
        public WorkloadNetworkDnsServiceData() { }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkDnsServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkDnsServiceResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string dnsServiceId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadNetworkDnsZoneCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkDnsZoneCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dnsZoneId, Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dnsZoneId, Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dnsZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> Get(string dnsZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>> GetAsync(string dnsZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> GetIfExists(string dnsZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>> GetIfExistsAsync(string dnsZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkDnsZoneData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData>
    {
        public WorkloadNetworkDnsZoneData() { }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkDnsZoneResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkDnsZoneResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string dnsZoneId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadNetworkGatewayCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkGatewayCollection() { }
        public virtual Azure.Response<bool> Exists(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource> Get(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource>> GetAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource> GetIfExists(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource>> GetIfExistsAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkGatewayData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkGatewayData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkGatewayData>
    {
        internal WorkloadNetworkGatewayData() { }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkGatewayProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkGatewayData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkGatewayData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkGatewayData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkGatewayData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkGatewayData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkGatewayData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkGatewayData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkGatewayResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkGatewayData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkGatewayData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkGatewayResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkGatewayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string gatewayId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.WorkloadNetworkGatewayData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkGatewayData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkGatewayData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkGatewayData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkGatewayData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkGatewayData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkGatewayData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkPortMirroringCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkPortMirroringCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string portMirroringId, Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string portMirroringId, Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> Get(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>> GetAsync(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> GetIfExists(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>> GetIfExistsAsync(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkPortMirroringData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData>
    {
        public WorkloadNetworkPortMirroringData() { }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkPortMirroringResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkPortMirroringResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string portMirroringId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadNetworkPublicIPCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkPublicIPCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string publicIPId, Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string publicIPId, Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> Get(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>> GetAsync(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> GetIfExists(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>> GetIfExistsAsync(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkPublicIPData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData>
    {
        public WorkloadNetworkPublicIPData() { }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkPublicIPResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkPublicIPResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string publicIPId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadNetworkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> GetWorkloadNetworkDhcp(string dhcpId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>> GetWorkloadNetworkDhcpAsync(string dhcpId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDhcpCollection GetWorkloadNetworkDhcps() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> GetWorkloadNetworkDnsService(string dnsServiceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>> GetWorkloadNetworkDnsServiceAsync(string dnsServiceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceCollection GetWorkloadNetworkDnsServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> GetWorkloadNetworkDnsZone(string dnsZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>> GetWorkloadNetworkDnsZoneAsync(string dnsZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneCollection GetWorkloadNetworkDnsZones() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource> GetWorkloadNetworkGateway(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource>> GetWorkloadNetworkGatewayAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkGatewayCollection GetWorkloadNetworkGateways() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource> GetWorkloadNetworkPortMirroring(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource>> GetWorkloadNetworkPortMirroringAsync(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringCollection GetWorkloadNetworkPortMirrorings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> GetWorkloadNetworkPublicIP(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>> GetWorkloadNetworkPublicIPAsync(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPublicIPCollection GetWorkloadNetworkPublicIPs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> GetWorkloadNetworkSegment(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>> GetWorkloadNetworkSegmentAsync(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkSegmentCollection GetWorkloadNetworkSegments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource> GetWorkloadNetworkVirtualMachine(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource>> GetWorkloadNetworkVirtualMachineAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineCollection GetWorkloadNetworkVirtualMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> GetWorkloadNetworkVmGroup(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>> GetWorkloadNetworkVmGroupAsync(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkVmGroupCollection GetWorkloadNetworkVmGroups() { throw null; }
        Azure.ResourceManager.Avs.WorkloadNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkSegmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkSegmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string segmentId, Azure.ResourceManager.Avs.WorkloadNetworkSegmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string segmentId, Azure.ResourceManager.Avs.WorkloadNetworkSegmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> Get(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>> GetAsync(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> GetIfExists(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>> GetIfExistsAsync(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkSegmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkSegmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkSegmentData>
    {
        public WorkloadNetworkSegmentData() { }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkSegmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkSegmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkSegmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkSegmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkSegmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkSegmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkSegmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkSegmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkSegmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkSegmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkSegmentResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkSegmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string segmentId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.WorkloadNetworkSegmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkSegmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkSegmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkSegmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkSegmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkSegmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkSegmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkSegmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkSegmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadNetworkVirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkVirtualMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource> Get(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource>> GetAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource> GetIfExists(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource>> GetIfExistsAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkVirtualMachineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData>
    {
        internal WorkloadNetworkVirtualMachineData() { }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkVirtualMachineProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkVirtualMachineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkVirtualMachineResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string virtualMachineId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkVmGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkVmGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vmGroupId, Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vmGroupId, Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> Get(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>> GetAsync(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> GetIfExists(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>> GetIfExistsAsync(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkVmGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData>
    {
        public WorkloadNetworkVmGroupData() { }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkVmGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkVmGroupResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string vmGroupId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Avs.Mocking
{
    public partial class MockableAvsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAvsArmClient() { }
        public virtual Azure.ResourceManager.Avs.AddonResource GetAddonResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.CloudLinkResource GetCloudLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.ClusterResource GetClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.DatastoreResource GetDatastoreResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource GetExpressRouteAuthorizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.GlobalReachConnectionResource GetGlobalReachConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.HcxEnterpriseSiteResource GetHcxEnterpriseSiteResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.HostResource GetHostResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.IscsiPathResource GetIscsiPathResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.PlacementPolicyResource GetPlacementPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.PrivateCloudResource GetPrivateCloudResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.ProvisionedNetworkResource GetProvisionedNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.PureStoragePolicyResource GetPureStoragePolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.ScriptCmdletResource GetScriptCmdletResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.ScriptExecutionResource GetScriptExecutionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.ScriptPackageResource GetScriptPackageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.VirtualMachineResource GetVirtualMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource GetWorkloadNetworkDhcpResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource GetWorkloadNetworkDnsServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource GetWorkloadNetworkDnsZoneResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource GetWorkloadNetworkGatewayResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringResource GetWorkloadNetworkPortMirroringResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource GetWorkloadNetworkPublicIPResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkResource GetWorkloadNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource GetWorkloadNetworkSegmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource GetWorkloadNetworkVirtualMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource GetWorkloadNetworkVmGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAvsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAvsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource> GetPrivateCloud(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PrivateCloudResource>> GetPrivateCloudAsync(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.PrivateCloudCollection GetPrivateClouds() { throw null; }
    }
    public partial class MockableAvsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAvsSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Avs.Models.Quota> CheckQuotaAvailabilityLocation(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.Quota>> CheckQuotaAvailabilityLocationAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.Models.Trial> CheckTrialAvailabilityLocation(string location, Azure.ResourceManager.Avs.Models.AvsSku sku = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.Trial>> CheckTrialAvailabilityLocationAsync(string location, Azure.ResourceManager.Avs.Models.AvsSku sku = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.PrivateCloudResource> GetPrivateClouds(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.PrivateCloudResource> GetPrivateCloudsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.Models.ResourceSku> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.Models.ResourceSku> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Avs.Models
{
    public partial class AddonArcProperties : Azure.ResourceManager.Avs.Models.AddonProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonArcProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonArcProperties>
    {
        public AddonArcProperties() { }
        public string VCenter { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AddonArcProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonArcProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonArcProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AddonArcProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonArcProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonArcProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonArcProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AddonHcxProperties : Azure.ResourceManager.Avs.Models.AddonProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonHcxProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonHcxProperties>
    {
        public AddonHcxProperties(string offer) { }
        public string ManagementNetwork { get { throw null; } set { } }
        public string Offer { get { throw null; } set { } }
        public string UplinkNetwork { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AddonHcxProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonHcxProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonHcxProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AddonHcxProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonHcxProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonHcxProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonHcxProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AddonProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonProperties>
    {
        protected AddonProperties() { }
        public Azure.ResourceManager.Avs.Models.AddonProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AddonProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AddonProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AddonProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.AddonProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AddonProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AddonProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AddonProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AddonProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AddonProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AddonProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AddonProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AddonProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AddonProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AddonProvisioningState left, Azure.ResourceManager.Avs.Models.AddonProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AddonProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AddonProvisioningState left, Azure.ResourceManager.Avs.Models.AddonProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AddonSrmProperties : Azure.ResourceManager.Avs.Models.AddonProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonSrmProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonSrmProperties>
    {
        public AddonSrmProperties() { }
        public string LicenseKey { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AddonSrmProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonSrmProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonSrmProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AddonSrmProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonSrmProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonSrmProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonSrmProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AddonVrProperties : Azure.ResourceManager.Avs.Models.AddonProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonVrProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonVrProperties>
    {
        public AddonVrProperties(int vrsCount) { }
        public int VrsCount { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AddonVrProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonVrProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonVrProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AddonVrProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonVrProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonVrProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonVrProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdminCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AdminCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AdminCredentials>
    {
        internal AdminCredentials() { }
        public string NsxtPassword { get { throw null; } }
        public string NsxtUsername { get { throw null; } }
        public string VcenterPassword { get { throw null; } }
        public string VcenterUsername { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AdminCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AdminCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AdminCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AdminCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AdminCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AdminCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AdminCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AffinityStrength : System.IEquatable<Azure.ResourceManager.Avs.Models.AffinityStrength>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AffinityStrength(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AffinityStrength Must { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AffinityStrength Should { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AffinityStrength other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AffinityStrength left, Azure.ResourceManager.Avs.Models.AffinityStrength right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AffinityStrength (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AffinityStrength left, Azure.ResourceManager.Avs.Models.AffinityStrength right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AffinityType : System.IEquatable<Azure.ResourceManager.Avs.Models.AffinityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AffinityType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AffinityType Affinity { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AffinityType AntiAffinity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AffinityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AffinityType left, Azure.ResourceManager.Avs.Models.AffinityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AffinityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AffinityType left, Azure.ResourceManager.Avs.Models.AffinityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmAvsModelFactory
    {
        public static Azure.ResourceManager.Avs.Models.AddonArcProperties AddonArcProperties(Azure.ResourceManager.Avs.Models.AddonProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AddonProvisioningState?), string vCenter = null) { throw null; }
        public static Azure.ResourceManager.Avs.AddonData AddonData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.AddonProperties properties = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Avs.Models.AddonHcxProperties AddonHcxProperties(Azure.ResourceManager.Avs.Models.AddonProvisioningState? provisioningState, string offer) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AddonHcxProperties AddonHcxProperties(Azure.ResourceManager.Avs.Models.AddonProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AddonProvisioningState?), string offer = null, string managementNetwork = null, string uplinkNetwork = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AddonProperties AddonProperties(string addonType = null, Azure.ResourceManager.Avs.Models.AddonProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AddonProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AddonSrmProperties AddonSrmProperties(Azure.ResourceManager.Avs.Models.AddonProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AddonProvisioningState?), string licenseKey = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AddonVrProperties AddonVrProperties(Azure.ResourceManager.Avs.Models.AddonProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AddonProvisioningState?), int vrsCount = 0) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AdminCredentials AdminCredentials(string nsxtUsername = null, string nsxtPassword = null, string vcenterUsername = null, string vcenterPassword = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.Circuit Circuit(string primarySubnet = null, string secondarySubnet = null, string expressRouteId = null, string expressRoutePrivatePeeringId = null) { throw null; }
        public static Azure.ResourceManager.Avs.CloudLinkData CloudLinkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.CloudLinkProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.CloudLinkProperties CloudLinkProperties(Azure.ResourceManager.Avs.Models.CloudLinkProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.CloudLinkProvisioningState?), Azure.ResourceManager.Avs.Models.CloudLinkStatus? status = default(Azure.ResourceManager.Avs.Models.CloudLinkStatus?), string linkedCloud = null) { throw null; }
        public static Azure.ResourceManager.Avs.ClusterData ClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.ClusterProperties properties = null, Azure.ResourceManager.Avs.Models.AvsSku sku = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ClusterProperties ClusterProperties(int? clusterSize = default(int?), Azure.ResourceManager.Avs.Models.ClusterProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.ClusterProvisioningState?), int? clusterId = default(int?), System.Collections.Generic.IEnumerable<string> hosts = null, string vsanDatastoreName = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ClusterZone ClusterZone(System.Collections.Generic.IEnumerable<string> hosts = null, string zone = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ClusterZoneList ClusterZoneList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ClusterZone> zones = null) { throw null; }
        public static Azure.ResourceManager.Avs.DatastoreData DatastoreData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.DatastoreProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.DatastoreProperties DatastoreProperties(Azure.ResourceManager.Avs.Models.DatastoreProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.DatastoreProvisioningState?), Azure.Core.ResourceIdentifier netAppVolumeId = null, Azure.ResourceManager.Avs.Models.DiskPoolVolume diskPoolVolume = null, Azure.Core.ResourceIdentifier elasticSanVolumeTargetId = null, Azure.ResourceManager.Avs.Models.PureStorageVolume pureStorageVolume = null, Azure.ResourceManager.Avs.Models.DatastoreStatus? status = default(Azure.ResourceManager.Avs.Models.DatastoreStatus?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.DiskPoolVolume DiskPoolVolume(string targetId = null, string lunName = null, Azure.ResourceManager.Avs.Models.MountOptionEnum? mountOption = default(Azure.ResourceManager.Avs.Models.MountOptionEnum?), string path = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.EncryptionKeyVaultProperties EncryptionKeyVaultProperties(string keyName = null, string keyVersion = null, string autoDetectedKeyVersion = null, string keyVaultUri = null, Azure.ResourceManager.Avs.Models.EncryptionKeyStatus? keyState = default(Azure.ResourceManager.Avs.Models.EncryptionKeyStatus?), Azure.ResourceManager.Avs.Models.EncryptionVersionType? versionType = default(Azure.ResourceManager.Avs.Models.EncryptionVersionType?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.Endpoints Endpoints(string nsxtManager = null, string vcsa = null, string hcxCloudManager = null, string nsxtManagerIP = null, string vcenterIP = null, string hcxCloudManagerIP = null) { throw null; }
        public static Azure.ResourceManager.Avs.ExpressRouteAuthorizationData ExpressRouteAuthorizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProperties ExpressRouteAuthorizationProperties(Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState?), string expressRouteAuthorizationId = null, string expressRouteAuthorizationKey = null, string expressRouteId = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.GeneralHostProperties GeneralHostProperties(Azure.ResourceManager.Avs.Models.HostProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.HostProvisioningState?), string displayName = null, string moRefId = null, string fqdn = null, Azure.ResourceManager.Avs.Models.HostMaintenance? maintenance = default(Azure.ResourceManager.Avs.Models.HostMaintenance?), string faultDomain = null) { throw null; }
        public static Azure.ResourceManager.Avs.GlobalReachConnectionData GlobalReachConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.GlobalReachConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.GlobalReachConnectionProperties GlobalReachConnectionProperties(Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState?), string addressPrefix = null, string authorizationKey = null, Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus? circuitConnectionStatus = default(Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus?), string peerExpressRouteCircuit = null, string expressRouteId = null) { throw null; }
        public static Azure.ResourceManager.Avs.HcxEnterpriseSiteData HcxEnterpriseSiteData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProperties HcxEnterpriseSiteProperties(Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProvisioningState?), string activationKey = null, Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus? status = default(Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus?)) { throw null; }
        public static Azure.ResourceManager.Avs.HostData HostData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.HostProperties properties = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Avs.Models.AvsSku sku = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.HostProperties HostProperties(string kind = null, Azure.ResourceManager.Avs.Models.HostProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.HostProvisioningState?), string displayName = null, string moRefId = null, string fqdn = null, Azure.ResourceManager.Avs.Models.HostMaintenance? maintenance = default(Azure.ResourceManager.Avs.Models.HostMaintenance?), string faultDomain = null) { throw null; }
        public static Azure.ResourceManager.Avs.IscsiPathData IscsiPathData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.IscsiPathProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.IscsiPathProperties IscsiPathProperties(Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState?), string networkBlock = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ManagementCluster ManagementCluster(int? clusterSize = default(int?), Azure.ResourceManager.Avs.Models.ClusterProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.ClusterProvisioningState?), int? clusterId = default(int?), System.Collections.Generic.IEnumerable<string> hosts = null, string vsanDatastoreName = null) { throw null; }
        public static Azure.ResourceManager.Avs.PlacementPolicyData PlacementPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.PlacementPolicyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyProperties PlacementPolicyProperties(string type = null, Azure.ResourceManager.Avs.Models.PlacementPolicyState? state = default(Azure.ResourceManager.Avs.Models.PlacementPolicyState?), string displayName = null, Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Avs.PrivateCloudData PrivateCloudData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Avs.Models.PrivateCloudProperties properties = null, Azure.ResourceManager.Avs.Models.AvsSku sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PrivateCloudProperties PrivateCloudProperties(Azure.ResourceManager.Avs.Models.ManagementCluster managementCluster = null, Azure.ResourceManager.Avs.Models.InternetEnum? internet = default(Azure.ResourceManager.Avs.Models.InternetEnum?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.IdentitySource> identitySources = null, Azure.ResourceManager.Avs.Models.AvailabilityProperties availability = null, Azure.ResourceManager.Avs.Models.Encryption encryption = null, System.Collections.Generic.IEnumerable<string> extendedNetworkBlocks = null, Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState?), Azure.ResourceManager.Avs.Models.Circuit circuit = null, Azure.ResourceManager.Avs.Models.Endpoints endpoints = null, string networkBlock = null, string managementNetwork = null, string provisioningNetwork = null, string vmotionNetwork = null, string vcenterPassword = null, string nsxtPassword = null, string vcenterCertificateThumbprint = null, string nsxtCertificateThumbprint = null, System.Collections.Generic.IEnumerable<string> externalCloudLinks = null, Azure.ResourceManager.Avs.Models.Circuit secondaryCircuit = null, Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum? nsxPublicIPQuotaRaised = default(Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum?), Azure.Core.ResourceIdentifier virtualNetworkId = null, Azure.ResourceManager.Avs.Models.DnsZoneType? dnsZoneType = default(Azure.ResourceManager.Avs.Models.DnsZoneType?)) { throw null; }
        public static Azure.ResourceManager.Avs.ProvisionedNetworkData ProvisionedNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.ProvisionedNetworkProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ProvisionedNetworkProperties ProvisionedNetworkProperties(Azure.ResourceManager.Avs.Models.ProvisionedNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.ProvisionedNetworkProvisioningState?), string addressPrefix = null, Azure.ResourceManager.Avs.Models.ProvisionedNetworkType? networkType = default(Azure.ResourceManager.Avs.Models.ProvisionedNetworkType?)) { throw null; }
        public static Azure.ResourceManager.Avs.PureStoragePolicyData PureStoragePolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.PureStoragePolicyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PureStoragePolicyProperties PureStoragePolicyProperties(string storagePolicyDefinition = null, string storagePoolId = null, Azure.ResourceManager.Avs.Models.PureStoragePolicyProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.PureStoragePolicyProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.Quota Quota(System.Collections.Generic.IReadOnlyDictionary<string, int> hostsRemaining = null, Azure.ResourceManager.Avs.Models.QuotaEnabled? quotaEnabled = default(Azure.ResourceManager.Avs.Models.QuotaEnabled?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ResourceSku ResourceSku(Azure.ResourceManager.Avs.Models.ResourceSkuResourceType resourceType = default(Azure.ResourceManager.Avs.Models.ResourceSkuResourceType), string name = null, string tier = null, string size = null, string family = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ResourceSkuLocationInfo> locationInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ResourceSkuCapabilities> capabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictions> restrictions = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ResourceSkuCapabilities ResourceSkuCapabilities(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ResourceSkuLocationInfo ResourceSkuLocationInfo(Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ResourceSkuZoneDetails> zoneDetails = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionInfo ResourceSkuRestrictionInfo(System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ResourceSkuRestrictions ResourceSkuRestrictions(Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsType? type = default(Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsType?), System.Collections.Generic.IEnumerable<string> values = null, Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionInfo restrictionInfo = null, Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsReasonCode? reasonCode = default(Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsReasonCode?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ResourceSkuZoneDetails ResourceSkuZoneDetails(System.Collections.Generic.IEnumerable<string> name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ResourceSkuCapabilities> capabilities = null) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptCmdletData ScriptCmdletData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.ScriptCmdletProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ScriptCmdletProperties ScriptCmdletProperties(Azure.ResourceManager.Avs.Models.ScriptCmdletProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.ScriptCmdletProvisioningState?), string description = null, string timeout = null, Azure.ResourceManager.Avs.Models.ScriptCmdletAudience? audience = default(Azure.ResourceManager.Avs.Models.ScriptCmdletAudience?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ScriptParameter> parameters = null) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptExecutionData ScriptExecutionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.ScriptExecutionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ScriptExecutionProperties ScriptExecutionProperties(string scriptCmdletId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ScriptExecutionParameter> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ScriptExecutionParameter> hiddenParameters = null, string failureReason = null, string timeout = null, string retention = null, System.DateTimeOffset? submittedOn = default(System.DateTimeOffset?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? finishedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState?), System.Collections.Generic.IEnumerable<string> output = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Avs.Models.ScriptExecutionPropertiesNamedOutput> namedOutputs = null, System.Collections.Generic.IEnumerable<string> information = null, System.Collections.Generic.IEnumerable<string> warnings = null, System.Collections.Generic.IEnumerable<string> errors = null) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptPackageData ScriptPackageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.ScriptPackageProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ScriptPackageProperties ScriptPackageProperties(Azure.ResourceManager.Avs.Models.ScriptPackageProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.ScriptPackageProvisioningState?), string description = null, string version = null, string company = null, string uri = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ScriptParameter ScriptParameter(Azure.ResourceManager.Avs.Models.ScriptParameterType? type = default(Azure.ResourceManager.Avs.Models.ScriptParameterType?), string name = null, string description = null, Azure.ResourceManager.Avs.Models.VisibilityParameterEnum? visibility = default(Azure.ResourceManager.Avs.Models.VisibilityParameterEnum?), Azure.ResourceManager.Avs.Models.OptionalParamEnum? optional = default(Azure.ResourceManager.Avs.Models.OptionalParamEnum?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.SpecializedHostProperties SpecializedHostProperties(Azure.ResourceManager.Avs.Models.HostProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.HostProvisioningState?), string displayName = null, string moRefId = null, string fqdn = null, Azure.ResourceManager.Avs.Models.HostMaintenance? maintenance = default(Azure.ResourceManager.Avs.Models.HostMaintenance?), string faultDomain = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.Trial Trial(Azure.ResourceManager.Avs.Models.TrialStatus? status = default(Azure.ResourceManager.Avs.Models.TrialStatus?), int? availableHosts = default(int?)) { throw null; }
        public static Azure.ResourceManager.Avs.VirtualMachineData VirtualMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.VirtualMachineProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VirtualMachineProperties VirtualMachineProperties(Azure.ResourceManager.Avs.Models.VirtualMachineProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.VirtualMachineProvisioningState?), string displayName = null, string moRefId = null, string folderPath = null, Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState? restrictMovement = default(Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties VmHostPlacementPolicyProperties(Azure.ResourceManager.Avs.Models.PlacementPolicyState? state = default(Azure.ResourceManager.Avs.Models.PlacementPolicyState?), string displayName = null, Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState?), System.Collections.Generic.IEnumerable<string> vmMembers = null, System.Collections.Generic.IEnumerable<string> hostMembers = null, Azure.ResourceManager.Avs.Models.AffinityType affinityType = default(Azure.ResourceManager.Avs.Models.AffinityType), Azure.ResourceManager.Avs.Models.AffinityStrength? affinityStrength = default(Azure.ResourceManager.Avs.Models.AffinityStrength?), Azure.ResourceManager.Avs.Models.AzureHybridBenefitType? azureHybridBenefitType = default(Azure.ResourceManager.Avs.Models.AzureHybridBenefitType?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties VmPlacementPolicyProperties(Azure.ResourceManager.Avs.Models.PlacementPolicyState? state = default(Azure.ResourceManager.Avs.Models.PlacementPolicyState?), string displayName = null, Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState?), System.Collections.Generic.IEnumerable<string> vmMembers = null, Azure.ResourceManager.Avs.Models.AffinityType affinityType = default(Azure.ResourceManager.Avs.Models.AffinityType)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Avs.WorkloadNetworkData WorkloadNetworkData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkData WorkloadNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState? workloadNetworkProvisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDhcpData WorkloadNetworkDhcpData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity WorkloadNetworkDhcpEntity(string dhcpType = null, string displayName = null, System.Collections.Generic.IEnumerable<string> segments = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState?), long? revision = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpRelay WorkloadNetworkDhcpRelay(string displayName = null, System.Collections.Generic.IEnumerable<string> segments = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState?), long? revision = default(long?), System.Collections.Generic.IEnumerable<string> serverAddresses = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpServer WorkloadNetworkDhcpServer(string displayName = null, System.Collections.Generic.IEnumerable<string> segments = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState?), long? revision = default(long?), string serverAddress = null, long? leaseTime = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData WorkloadNetworkDnsServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProperties WorkloadNetworkDnsServiceProperties(string displayName = null, string dnsServiceIP = null, string defaultDnsZone = null, System.Collections.Generic.IEnumerable<string> fqdnZones = null, Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum? logLevel = default(Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum?), Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum? status = default(Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum?), Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState?), long? revision = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData WorkloadNetworkDnsZoneData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProperties WorkloadNetworkDnsZoneProperties(string displayName = null, System.Collections.Generic.IEnumerable<string> domain = null, System.Collections.Generic.IEnumerable<string> dnsServerIPs = null, string sourceIP = null, long? dnsServices = default(long?), Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState?), long? revision = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkGatewayData WorkloadNetworkGatewayData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkGatewayProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkGatewayProperties WorkloadNetworkGatewayProperties(Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState?), string displayName = null, string path = null) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringData WorkloadNetworkPortMirroringData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProperties WorkloadNetworkPortMirroringProperties(string displayName = null, Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum? direction = default(Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum?), string source = null, string destination = null, Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum? status = default(Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum?), Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState?), long? revision = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData WorkloadNetworkPublicIPData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProperties WorkloadNetworkPublicIPProperties(string displayName = null, long? numberOfPublicIPs = default(long?), string publicIPBlock = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkSegmentData WorkloadNetworkSegmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif WorkloadNetworkSegmentPortVif(string portName = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProperties WorkloadNetworkSegmentProperties(string displayName = null, string connectedGateway = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentSubnet subnet = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif> portVif = null, Azure.ResourceManager.Avs.Models.SegmentStatusEnum? status = default(Azure.ResourceManager.Avs.Models.SegmentStatusEnum?), Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState?), long? revision = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData WorkloadNetworkVirtualMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkVirtualMachineProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVirtualMachineProperties WorkloadNetworkVirtualMachineProperties(Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState?), string displayName = null, Azure.ResourceManager.Avs.Models.VmTypeEnum? vmType = default(Azure.ResourceManager.Avs.Models.VmTypeEnum?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData WorkloadNetworkVmGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProperties WorkloadNetworkVmGroupProperties(string displayName = null, System.Collections.Generic.IEnumerable<string> members = null, Azure.ResourceManager.Avs.Models.VmGroupStatusEnum? status = default(Azure.ResourceManager.Avs.Models.VmGroupStatusEnum?), Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState?), long? revision = default(long?)) { throw null; }
    }
    public partial class AvailabilityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvailabilityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvailabilityProperties>
    {
        public AvailabilityProperties() { }
        public int? SecondaryZone { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvailabilityStrategy? Strategy { get { throw null; } set { } }
        public int? Zone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvailabilityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvailabilityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvailabilityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvailabilityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvailabilityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvailabilityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvailabilityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailabilityStrategy : System.IEquatable<Azure.ResourceManager.Avs.Models.AvailabilityStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailabilityStrategy(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvailabilityStrategy DualZone { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvailabilityStrategy SingleZone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvailabilityStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvailabilityStrategy left, Azure.ResourceManager.Avs.Models.AvailabilityStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvailabilityStrategy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvailabilityStrategy left, Azure.ResourceManager.Avs.Models.AvailabilityStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsSku>
    {
        public AvsSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsSkuTier? Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AvsSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureHybridBenefitType : System.IEquatable<Azure.ResourceManager.Avs.Models.AzureHybridBenefitType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureHybridBenefitType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AzureHybridBenefitType None { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AzureHybridBenefitType SqlHost { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AzureHybridBenefitType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AzureHybridBenefitType left, Azure.ResourceManager.Avs.Models.AzureHybridBenefitType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AzureHybridBenefitType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AzureHybridBenefitType left, Azure.ResourceManager.Avs.Models.AzureHybridBenefitType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Circuit : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Circuit>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Circuit>
    {
        public Circuit() { }
        public string ExpressRouteId { get { throw null; } }
        public string ExpressRoutePrivatePeeringId { get { throw null; } }
        public string PrimarySubnet { get { throw null; } }
        public string SecondarySubnet { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.Circuit System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Circuit>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Circuit>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.Circuit System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Circuit>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Circuit>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Circuit>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudLinkProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.CloudLinkProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.CloudLinkProperties>
    {
        public CloudLinkProperties() { }
        public string LinkedCloud { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.CloudLinkProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.CloudLinkStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.CloudLinkProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.CloudLinkProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.CloudLinkProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.CloudLinkProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.CloudLinkProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.CloudLinkProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.CloudLinkProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudLinkProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.CloudLinkProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudLinkProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.CloudLinkProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.CloudLinkProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.CloudLinkProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.CloudLinkProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.CloudLinkProvisioningState left, Azure.ResourceManager.Avs.Models.CloudLinkProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.CloudLinkProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.CloudLinkProvisioningState left, Azure.ResourceManager.Avs.Models.CloudLinkProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudLinkStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.CloudLinkStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudLinkStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.CloudLinkStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.CloudLinkStatus Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.CloudLinkStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.CloudLinkStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.CloudLinkStatus Failed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.CloudLinkStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.CloudLinkStatus left, Azure.ResourceManager.Avs.Models.CloudLinkStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.CloudLinkStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.CloudLinkStatus left, Azure.ResourceManager.Avs.Models.CloudLinkStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ClusterPatch>
    {
        public ClusterPatch() { }
        public int? ClusterSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Hosts { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsSku Sku { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ClusterProperties>
    {
        public ClusterProperties() { }
        public int? ClusterId { get { throw null; } }
        public int? ClusterSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Hosts { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ClusterProvisioningState? ProvisioningState { get { throw null; } }
        public string VsanDatastoreName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.ClusterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ClusterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ClusterProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ClusterProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ClusterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ClusterProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ClusterProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ClusterProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ClusterProvisioningState left, Azure.ResourceManager.Avs.Models.ClusterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ClusterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ClusterProvisioningState left, Azure.ResourceManager.Avs.Models.ClusterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterZone : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ClusterZone>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ClusterZone>
    {
        internal ClusterZone() { }
        public System.Collections.Generic.IReadOnlyList<string> Hosts { get { throw null; } }
        public string Zone { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ClusterZone System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ClusterZone>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ClusterZone>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ClusterZone System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ClusterZone>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ClusterZone>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ClusterZone>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterZoneList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ClusterZoneList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ClusterZoneList>
    {
        internal ClusterZoneList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.ClusterZone> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ClusterZoneList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ClusterZoneList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ClusterZoneList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ClusterZoneList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ClusterZoneList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ClusterZoneList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ClusterZoneList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatastoreProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.DatastoreProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.DatastoreProperties>
    {
        public DatastoreProperties() { }
        public Azure.ResourceManager.Avs.Models.DiskPoolVolume DiskPoolVolume { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ElasticSanVolumeTargetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetAppVolumeId { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.DatastoreProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.PureStorageVolume PureStorageVolume { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.DatastoreStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.DatastoreProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.DatastoreProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.DatastoreProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.DatastoreProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.DatastoreProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.DatastoreProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.DatastoreProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatastoreProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.DatastoreProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatastoreProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.DatastoreProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.DatastoreProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.DatastoreProvisioningState left, Azure.ResourceManager.Avs.Models.DatastoreProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.DatastoreProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.DatastoreProvisioningState left, Azure.ResourceManager.Avs.Models.DatastoreProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatastoreStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.DatastoreStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatastoreStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.DatastoreStatus Accessible { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreStatus Attached { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreStatus DeadOrError { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreStatus Detached { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreStatus Inaccessible { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreStatus LostCommunication { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DatastoreStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.DatastoreStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.DatastoreStatus left, Azure.ResourceManager.Avs.Models.DatastoreStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.DatastoreStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.DatastoreStatus left, Azure.ResourceManager.Avs.Models.DatastoreStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskPoolVolume : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.DiskPoolVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.DiskPoolVolume>
    {
        public DiskPoolVolume(string targetId, string lunName) { }
        public string LunName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.MountOptionEnum? MountOption { get { throw null; } set { } }
        public string Path { get { throw null; } }
        public string TargetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.DiskPoolVolume System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.DiskPoolVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.DiskPoolVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.DiskPoolVolume System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.DiskPoolVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.DiskPoolVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.DiskPoolVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsServiceLogLevelEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsServiceLogLevelEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum DEBUG { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum ERROR { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum FATAL { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum INFO { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum WARNING { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum left, Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum left, Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsServiceStatusEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsServiceStatusEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum FAILURE { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum SUCCESS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum left, Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum left, Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsZoneType : System.IEquatable<Azure.ResourceManager.Avs.Models.DnsZoneType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsZoneType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.DnsZoneType Private { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsZoneType Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.DnsZoneType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.DnsZoneType left, Azure.ResourceManager.Avs.Models.DnsZoneType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.DnsZoneType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.DnsZoneType left, Azure.ResourceManager.Avs.Models.DnsZoneType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Encryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Encryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Encryption>
    {
        public Encryption() { }
        public Azure.ResourceManager.Avs.Models.EncryptionKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.EncryptionState? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.Encryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Encryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Encryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.Encryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Encryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Encryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Encryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionKeyStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.EncryptionKeyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionKeyStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.EncryptionKeyStatus AccessDenied { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.EncryptionKeyStatus Connected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.EncryptionKeyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.EncryptionKeyStatus left, Azure.ResourceManager.Avs.Models.EncryptionKeyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.EncryptionKeyStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.EncryptionKeyStatus left, Azure.ResourceManager.Avs.Models.EncryptionKeyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionKeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.EncryptionKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.EncryptionKeyVaultProperties>
    {
        public EncryptionKeyVaultProperties() { }
        public string AutoDetectedKeyVersion { get { throw null; } }
        public string KeyName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.EncryptionKeyStatus? KeyState { get { throw null; } }
        public string KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.EncryptionVersionType? VersionType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.EncryptionKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.EncryptionKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.EncryptionKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.EncryptionKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.EncryptionKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.EncryptionKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.EncryptionKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionState : System.IEquatable<Azure.ResourceManager.Avs.Models.EncryptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.EncryptionState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.EncryptionState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.EncryptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.EncryptionState left, Azure.ResourceManager.Avs.Models.EncryptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.EncryptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.EncryptionState left, Azure.ResourceManager.Avs.Models.EncryptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionVersionType : System.IEquatable<Azure.ResourceManager.Avs.Models.EncryptionVersionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionVersionType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.EncryptionVersionType AutoDetected { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.EncryptionVersionType Fixed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.EncryptionVersionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.EncryptionVersionType left, Azure.ResourceManager.Avs.Models.EncryptionVersionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.EncryptionVersionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.EncryptionVersionType left, Azure.ResourceManager.Avs.Models.EncryptionVersionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Endpoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Endpoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Endpoints>
    {
        internal Endpoints() { }
        public string HcxCloudManager { get { throw null; } }
        public string HcxCloudManagerIP { get { throw null; } }
        public string NsxtManager { get { throw null; } }
        public string NsxtManagerIP { get { throw null; } }
        public string VcenterIP { get { throw null; } }
        public string Vcsa { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.Endpoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Endpoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Endpoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.Endpoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Endpoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Endpoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Endpoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExpressRouteAuthorizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProperties>
    {
        public ExpressRouteAuthorizationProperties() { }
        public string ExpressRouteAuthorizationId { get { throw null; } }
        public string ExpressRouteAuthorizationKey { get { throw null; } }
        public string ExpressRouteId { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpressRouteAuthorizationProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpressRouteAuthorizationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState left, Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState left, Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GeneralHostProperties : Azure.ResourceManager.Avs.Models.HostProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.GeneralHostProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.GeneralHostProperties>
    {
        internal GeneralHostProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.GeneralHostProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.GeneralHostProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.GeneralHostProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.GeneralHostProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.GeneralHostProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.GeneralHostProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.GeneralHostProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GlobalReachConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.GlobalReachConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.GlobalReachConnectionProperties>
    {
        public GlobalReachConnectionProperties() { }
        public string AddressPrefix { get { throw null; } }
        public string AuthorizationKey { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus? CircuitConnectionStatus { get { throw null; } }
        public string ExpressRouteId { get { throw null; } set { } }
        public string PeerExpressRouteCircuit { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.GlobalReachConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.GlobalReachConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.GlobalReachConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.GlobalReachConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.GlobalReachConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.GlobalReachConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.GlobalReachConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GlobalReachConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GlobalReachConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState left, Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState left, Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GlobalReachConnectionStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GlobalReachConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus Connecting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus Disconnected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus left, Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus left, Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HcxEnterpriseSiteProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProperties>
    {
        public HcxEnterpriseSiteProperties() { }
        public string ActivationKey { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcxEnterpriseSiteProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcxEnterpriseSiteProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProvisioningState left, Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProvisioningState left, Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HcxEnterpriseSiteStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HcxEnterpriseSiteStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus Available { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus Consumed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus Deactivated { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus Deleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus left, Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus left, Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostMaintenance : System.IEquatable<Azure.ResourceManager.Avs.Models.HostMaintenance>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostMaintenance(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.HostMaintenance Replacement { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.HostMaintenance Upgrade { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.HostMaintenance other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.HostMaintenance left, Azure.ResourceManager.Avs.Models.HostMaintenance right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.HostMaintenance (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.HostMaintenance left, Azure.ResourceManager.Avs.Models.HostMaintenance right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class HostProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.HostProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.HostProperties>
    {
        protected HostProperties() { }
        public string DisplayName { get { throw null; } }
        public string FaultDomain { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.HostMaintenance? Maintenance { get { throw null; } }
        public string MoRefId { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.HostProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.HostProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.HostProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.HostProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.HostProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.HostProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.HostProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.HostProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.HostProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.HostProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.HostProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.HostProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.HostProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.HostProvisioningState left, Azure.ResourceManager.Avs.Models.HostProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.HostProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.HostProvisioningState left, Azure.ResourceManager.Avs.Models.HostProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IdentitySource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.IdentitySource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.IdentitySource>
    {
        public IdentitySource() { }
        public string Alias { get { throw null; } set { } }
        public string BaseGroupDN { get { throw null; } set { } }
        public string BaseUserDN { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string PrimaryServer { get { throw null; } set { } }
        public string SecondaryServer { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.SslEnum? Ssl { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.IdentitySource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.IdentitySource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.IdentitySource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.IdentitySource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.IdentitySource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.IdentitySource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.IdentitySource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InternetEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.InternetEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InternetEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.InternetEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.InternetEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.InternetEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.InternetEnum left, Azure.ResourceManager.Avs.Models.InternetEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.InternetEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.InternetEnum left, Azure.ResourceManager.Avs.Models.InternetEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IscsiPathProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.IscsiPathProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.IscsiPathProperties>
    {
        public IscsiPathProperties(string networkBlock) { }
        public string NetworkBlock { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.IscsiPathProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.IscsiPathProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.IscsiPathProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.IscsiPathProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.IscsiPathProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.IscsiPathProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.IscsiPathProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IscsiPathProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IscsiPathProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState left, Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState left, Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagementCluster : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ManagementCluster>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ManagementCluster>
    {
        public ManagementCluster() { }
        public int? ClusterId { get { throw null; } }
        public int? ClusterSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Hosts { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ClusterProvisioningState? ProvisioningState { get { throw null; } }
        public string VsanDatastoreName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ManagementCluster System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ManagementCluster>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ManagementCluster>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ManagementCluster System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ManagementCluster>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ManagementCluster>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ManagementCluster>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MountOptionEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.MountOptionEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MountOptionEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.MountOptionEnum ATTACH { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MountOptionEnum MOUNT { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.MountOptionEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.MountOptionEnum left, Azure.ResourceManager.Avs.Models.MountOptionEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.MountOptionEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.MountOptionEnum left, Azure.ResourceManager.Avs.Models.MountOptionEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NsxPublicIPQuotaRaisedEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NsxPublicIPQuotaRaisedEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum left, Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum left, Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OptionalParamEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.OptionalParamEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OptionalParamEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.OptionalParamEnum Optional { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.OptionalParamEnum Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.OptionalParamEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.OptionalParamEnum left, Azure.ResourceManager.Avs.Models.OptionalParamEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.OptionalParamEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.OptionalParamEnum left, Azure.ResourceManager.Avs.Models.OptionalParamEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlacementPolicyPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PlacementPolicyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PlacementPolicyPatch>
    {
        public PlacementPolicyPatch() { }
        public Azure.ResourceManager.Avs.Models.AffinityStrength? AffinityStrength { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AzureHybridBenefitType? AzureHybridBenefitType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> HostMembers { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.PlacementPolicyState? State { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VmMembers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PlacementPolicyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PlacementPolicyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PlacementPolicyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PlacementPolicyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PlacementPolicyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PlacementPolicyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PlacementPolicyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class PlacementPolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PlacementPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PlacementPolicyProperties>
    {
        protected PlacementPolicyProperties() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.PlacementPolicyState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PlacementPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PlacementPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PlacementPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PlacementPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PlacementPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PlacementPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PlacementPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlacementPolicyProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlacementPolicyProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState left, Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState left, Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlacementPolicyState : System.IEquatable<Azure.ResourceManager.Avs.Models.PlacementPolicyState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlacementPolicyState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.PlacementPolicyState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.PlacementPolicyState left, Azure.ResourceManager.Avs.Models.PlacementPolicyState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.PlacementPolicyState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.PlacementPolicyState left, Azure.ResourceManager.Avs.Models.PlacementPolicyState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortMirroringDirectionEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortMirroringDirectionEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum BIDIRECTIONAL { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum EGRESS { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum INGRESS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum left, Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum left, Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortMirroringStatusEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortMirroringStatusEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum FAILURE { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum SUCCESS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum left, Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum left, Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateCloudPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PrivateCloudPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PrivateCloudPatch>
    {
        public PrivateCloudPatch() { }
        public Azure.ResourceManager.Avs.Models.AvailabilityProperties Availability { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.DnsZoneType? DnsZoneType { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.Encryption Encryption { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExtendedNetworkBlocks { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.IdentitySource> IdentitySources { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.InternetEnum? Internet { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.ManagementCluster ManagementCluster { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PrivateCloudPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PrivateCloudPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PrivateCloudPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PrivateCloudPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PrivateCloudPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PrivateCloudPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PrivateCloudPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateCloudProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PrivateCloudProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PrivateCloudProperties>
    {
        public PrivateCloudProperties(Azure.ResourceManager.Avs.Models.ManagementCluster managementCluster, string networkBlock) { }
        public Azure.ResourceManager.Avs.Models.AvailabilityProperties Availability { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.Circuit Circuit { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.DnsZoneType? DnsZoneType { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.Endpoints Endpoints { get { throw null; } }
        public System.Collections.Generic.IList<string> ExtendedNetworkBlocks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ExternalCloudLinks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.IdentitySource> IdentitySources { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.InternetEnum? Internet { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.ManagementCluster ManagementCluster { get { throw null; } set { } }
        public string ManagementNetwork { get { throw null; } }
        public string NetworkBlock { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum? NsxPublicIPQuotaRaised { get { throw null; } }
        public string NsxtCertificateThumbprint { get { throw null; } }
        public string NsxtPassword { get { throw null; } set { } }
        public string ProvisioningNetwork { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.Circuit SecondaryCircuit { get { throw null; } set { } }
        public string VcenterCertificateThumbprint { get { throw null; } }
        public string VcenterPassword { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualNetworkId { get { throw null; } set { } }
        public string VmotionNetwork { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PrivateCloudProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PrivateCloudProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PrivateCloudProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PrivateCloudProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PrivateCloudProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PrivateCloudProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PrivateCloudProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateCloudProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateCloudProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState left, Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState left, Azure.ResourceManager.Avs.Models.PrivateCloudProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProvisionedNetworkProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ProvisionedNetworkProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ProvisionedNetworkProperties>
    {
        internal ProvisionedNetworkProperties() { }
        public string AddressPrefix { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ProvisionedNetworkType? NetworkType { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ProvisionedNetworkProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ProvisionedNetworkProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ProvisionedNetworkProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ProvisionedNetworkProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ProvisionedNetworkProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ProvisionedNetworkProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ProvisionedNetworkProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ProvisionedNetworkProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisionedNetworkProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.ProvisionedNetworkProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisionedNetworkProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ProvisionedNetworkProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ProvisionedNetworkProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ProvisionedNetworkProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ProvisionedNetworkProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ProvisionedNetworkProvisioningState left, Azure.ResourceManager.Avs.Models.ProvisionedNetworkProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ProvisionedNetworkProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ProvisionedNetworkProvisioningState left, Azure.ResourceManager.Avs.Models.ProvisionedNetworkProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisionedNetworkType : System.IEquatable<Azure.ResourceManager.Avs.Models.ProvisionedNetworkType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisionedNetworkType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ProvisionedNetworkType EsxManagement { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ProvisionedNetworkType EsxReplication { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ProvisionedNetworkType HcxManagement { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ProvisionedNetworkType HcxUplink { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ProvisionedNetworkType VcenterManagement { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ProvisionedNetworkType Vmotion { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ProvisionedNetworkType Vsan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ProvisionedNetworkType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ProvisionedNetworkType left, Azure.ResourceManager.Avs.Models.ProvisionedNetworkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ProvisionedNetworkType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ProvisionedNetworkType left, Azure.ResourceManager.Avs.Models.ProvisionedNetworkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PSCredentialExecutionParameter : Azure.ResourceManager.Avs.Models.ScriptExecutionParameter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameter>
    {
        public PSCredentialExecutionParameter(string name) : base (default(string)) { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PureStoragePolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PureStoragePolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PureStoragePolicyProperties>
    {
        public PureStoragePolicyProperties(string storagePolicyDefinition, string storagePoolId) { }
        public Azure.ResourceManager.Avs.Models.PureStoragePolicyProvisioningState? ProvisioningState { get { throw null; } }
        public string StoragePolicyDefinition { get { throw null; } set { } }
        public string StoragePoolId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PureStoragePolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PureStoragePolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PureStoragePolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PureStoragePolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PureStoragePolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PureStoragePolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PureStoragePolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PureStoragePolicyProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.PureStoragePolicyProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PureStoragePolicyProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PureStoragePolicyProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PureStoragePolicyProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PureStoragePolicyProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PureStoragePolicyProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PureStoragePolicyProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.PureStoragePolicyProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.PureStoragePolicyProvisioningState left, Azure.ResourceManager.Avs.Models.PureStoragePolicyProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.PureStoragePolicyProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.PureStoragePolicyProvisioningState left, Azure.ResourceManager.Avs.Models.PureStoragePolicyProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PureStorageVolume : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PureStorageVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PureStorageVolume>
    {
        public PureStorageVolume(Azure.Core.ResourceIdentifier storagePoolId, int sizeGb) { }
        public int SizeGb { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StoragePoolId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PureStorageVolume System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PureStorageVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PureStorageVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PureStorageVolume System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PureStorageVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PureStorageVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PureStorageVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Quota : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Quota>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Quota>
    {
        internal Quota() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> HostsRemaining { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.QuotaEnabled? QuotaEnabled { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.Quota System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Quota>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Quota>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.Quota System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Quota>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Quota>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Quota>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuotaEnabled : System.IEquatable<Azure.ResourceManager.Avs.Models.QuotaEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuotaEnabled(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.QuotaEnabled Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.QuotaEnabled Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.QuotaEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.QuotaEnabled left, Azure.ResourceManager.Avs.Models.QuotaEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.QuotaEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.QuotaEnabled left, Azure.ResourceManager.Avs.Models.QuotaEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSku>
    {
        internal ResourceSku() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.ResourceSkuCapabilities> Capabilities { get { throw null; } }
        public string Family { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.ResourceSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ResourceSkuResourceType ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictions> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ResourceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ResourceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSkuCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuCapabilities>
    {
        internal ResourceSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ResourceSkuCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSkuCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSkuCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ResourceSkuCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuLocationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSkuLocationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuLocationInfo>
    {
        internal ResourceSkuLocationInfo() { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.ResourceSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ResourceSkuLocationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSkuLocationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSkuLocationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ResourceSkuLocationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuLocationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuLocationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuLocationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceSkuResourceType : System.IEquatable<Azure.ResourceManager.Avs.Models.ResourceSkuResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceSkuResourceType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ResourceSkuResourceType PrivateClouds { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ResourceSkuResourceType PrivateCloudsClusters { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ResourceSkuResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ResourceSkuResourceType left, Azure.ResourceManager.Avs.Models.ResourceSkuResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ResourceSkuResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ResourceSkuResourceType left, Azure.ResourceManager.Avs.Models.ResourceSkuResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceSkuRestrictionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionInfo>
    {
        internal ResourceSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuRestrictions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictions>
    {
        internal ResourceSkuRestrictions() { }
        public Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsType? Type { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ResourceSkuRestrictions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ResourceSkuRestrictions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceSkuRestrictionsReasonCode : System.IEquatable<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceSkuRestrictionsReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsReasonCode QuotaId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsReasonCode left, Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsReasonCode left, Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceSkuRestrictionsType : System.IEquatable<Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceSkuRestrictionsType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsType Location { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsType Zone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsType left, Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsType left, Azure.ResourceManager.Avs.Models.ResourceSkuRestrictionsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceSkuZoneDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSkuZoneDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuZoneDetails>
    {
        internal ResourceSkuZoneDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.ResourceSkuCapabilities> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ResourceSkuZoneDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSkuZoneDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ResourceSkuZoneDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ResourceSkuZoneDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuZoneDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuZoneDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ResourceSkuZoneDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptCmdletAudience : System.IEquatable<Azure.ResourceManager.Avs.Models.ScriptCmdletAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptCmdletAudience(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ScriptCmdletAudience Any { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptCmdletAudience Automation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ScriptCmdletAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ScriptCmdletAudience left, Azure.ResourceManager.Avs.Models.ScriptCmdletAudience right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ScriptCmdletAudience (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ScriptCmdletAudience left, Azure.ResourceManager.Avs.Models.ScriptCmdletAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptCmdletProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptCmdletProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptCmdletProperties>
    {
        internal ScriptCmdletProperties() { }
        public Azure.ResourceManager.Avs.Models.ScriptCmdletAudience? Audience { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.ScriptParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ScriptCmdletProvisioningState? ProvisioningState { get { throw null; } }
        public string Timeout { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptCmdletProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptCmdletProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptCmdletProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptCmdletProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptCmdletProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptCmdletProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptCmdletProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptCmdletProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.ScriptCmdletProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptCmdletProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ScriptCmdletProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptCmdletProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptCmdletProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ScriptCmdletProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ScriptCmdletProvisioningState left, Azure.ResourceManager.Avs.Models.ScriptCmdletProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ScriptCmdletProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ScriptCmdletProvisioningState left, Azure.ResourceManager.Avs.Models.ScriptCmdletProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ScriptExecutionParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptExecutionParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptExecutionParameter>
    {
        protected ScriptExecutionParameter(string name) { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptExecutionParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptExecutionParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptExecutionParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptExecutionParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptExecutionParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptExecutionParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptExecutionParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScriptExecutionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptExecutionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptExecutionProperties>
    {
        public ScriptExecutionProperties(string timeout) { }
        public System.Collections.Generic.IReadOnlyList<string> Errors { get { throw null; } }
        public string FailureReason { get { throw null; } set { } }
        public System.DateTimeOffset? FinishedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.ScriptExecutionParameter> HiddenParameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Information { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Avs.Models.ScriptExecutionPropertiesNamedOutput> NamedOutputs { get { throw null; } }
        public System.Collections.Generic.IList<string> Output { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.ScriptExecutionParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState? ProvisioningState { get { throw null; } }
        public string Retention { get { throw null; } set { } }
        public string ScriptCmdletId { get { throw null; } set { } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public System.DateTimeOffset? SubmittedOn { get { throw null; } }
        public string Timeout { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptExecutionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptExecutionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptExecutionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptExecutionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptExecutionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptExecutionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptExecutionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScriptExecutionPropertiesNamedOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptExecutionPropertiesNamedOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptExecutionPropertiesNamedOutput>
    {
        public ScriptExecutionPropertiesNamedOutput() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptExecutionPropertiesNamedOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptExecutionPropertiesNamedOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptExecutionPropertiesNamedOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptExecutionPropertiesNamedOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptExecutionPropertiesNamedOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptExecutionPropertiesNamedOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptExecutionPropertiesNamedOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptExecutionProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptExecutionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState Cancelling { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState left, Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState left, Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptOutputStreamType : System.IEquatable<Azure.ResourceManager.Avs.Models.ScriptOutputStreamType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptOutputStreamType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ScriptOutputStreamType Error { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptOutputStreamType Information { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptOutputStreamType Output { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptOutputStreamType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ScriptOutputStreamType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ScriptOutputStreamType left, Azure.ResourceManager.Avs.Models.ScriptOutputStreamType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ScriptOutputStreamType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ScriptOutputStreamType left, Azure.ResourceManager.Avs.Models.ScriptOutputStreamType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptPackageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptPackageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptPackageProperties>
    {
        internal ScriptPackageProperties() { }
        public string Company { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ScriptPackageProvisioningState? ProvisioningState { get { throw null; } }
        public string Uri { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptPackageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptPackageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptPackageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptPackageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptPackageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptPackageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptPackageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptPackageProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.ScriptPackageProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptPackageProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ScriptPackageProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptPackageProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptPackageProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ScriptPackageProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ScriptPackageProvisioningState left, Azure.ResourceManager.Avs.Models.ScriptPackageProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ScriptPackageProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ScriptPackageProvisioningState left, Azure.ResourceManager.Avs.Models.ScriptPackageProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptParameter>
    {
        internal ScriptParameter() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.OptionalParamEnum? Optional { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ScriptParameterType? Type { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.VisibilityParameterEnum? Visibility { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptParameterType : System.IEquatable<Azure.ResourceManager.Avs.Models.ScriptParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptParameterType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ScriptParameterType Bool { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptParameterType Credential { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptParameterType Int { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptParameterType SecureString { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ScriptParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ScriptParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ScriptParameterType left, Azure.ResourceManager.Avs.Models.ScriptParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ScriptParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ScriptParameterType left, Azure.ResourceManager.Avs.Models.ScriptParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptSecureStringExecutionParameter : Azure.ResourceManager.Avs.Models.ScriptExecutionParameter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameter>
    {
        public ScriptSecureStringExecutionParameter(string name) : base (default(string)) { }
        public string SecureValue { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScriptStringExecutionParameter : Azure.ResourceManager.Avs.Models.ScriptExecutionParameter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameter>
    {
        public ScriptStringExecutionParameter(string name) : base (default(string)) { }
        public string Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SegmentStatusEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.SegmentStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SegmentStatusEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.SegmentStatusEnum FAILURE { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.SegmentStatusEnum SUCCESS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.SegmentStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.SegmentStatusEnum left, Azure.ResourceManager.Avs.Models.SegmentStatusEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.SegmentStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.SegmentStatusEnum left, Azure.ResourceManager.Avs.Models.SegmentStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SpecializedHostProperties : Azure.ResourceManager.Avs.Models.HostProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.SpecializedHostProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.SpecializedHostProperties>
    {
        internal SpecializedHostProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.SpecializedHostProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.SpecializedHostProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.SpecializedHostProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.SpecializedHostProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.SpecializedHostProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.SpecializedHostProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.SpecializedHostProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SslEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.SslEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SslEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.SslEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.SslEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.SslEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.SslEnum left, Azure.ResourceManager.Avs.Models.SslEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.SslEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.SslEnum left, Azure.ResourceManager.Avs.Models.SslEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Trial : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Trial>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Trial>
    {
        internal Trial() { }
        public int? AvailableHosts { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.TrialStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.Trial System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Trial>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Trial>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.Trial System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Trial>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Trial>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Trial>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrialStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.TrialStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrialStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.TrialStatus TrialAvailable { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.TrialStatus TrialDisabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.TrialStatus TrialUsed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.TrialStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.TrialStatus left, Azure.ResourceManager.Avs.Models.TrialStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.TrialStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.TrialStatus left, Azure.ResourceManager.Avs.Models.TrialStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VirtualMachineProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VirtualMachineProperties>
    {
        internal VirtualMachineProperties() { }
        public string DisplayName { get { throw null; } }
        public string FolderPath { get { throw null; } }
        public string MoRefId { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.VirtualMachineProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState? RestrictMovement { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.VirtualMachineProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VirtualMachineProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VirtualMachineProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.VirtualMachineProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VirtualMachineProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VirtualMachineProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VirtualMachineProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.VirtualMachineProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VirtualMachineProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.VirtualMachineProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.VirtualMachineProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.VirtualMachineProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.VirtualMachineProvisioningState left, Azure.ResourceManager.Avs.Models.VirtualMachineProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.VirtualMachineProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.VirtualMachineProvisioningState left, Azure.ResourceManager.Avs.Models.VirtualMachineProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineRestrictMovement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovement>
    {
        public VirtualMachineRestrictMovement() { }
        public Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState? RestrictMovement { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineRestrictMovementState : System.IEquatable<Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineRestrictMovementState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState left, Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState left, Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VisibilityParameterEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.VisibilityParameterEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VisibilityParameterEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VisibilityParameterEnum Hidden { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.VisibilityParameterEnum Visible { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.VisibilityParameterEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.VisibilityParameterEnum left, Azure.ResourceManager.Avs.Models.VisibilityParameterEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.VisibilityParameterEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.VisibilityParameterEnum left, Azure.ResourceManager.Avs.Models.VisibilityParameterEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGroupStatusEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.VmGroupStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGroupStatusEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VmGroupStatusEnum FAILURE { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.VmGroupStatusEnum SUCCESS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.VmGroupStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.VmGroupStatusEnum left, Azure.ResourceManager.Avs.Models.VmGroupStatusEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.VmGroupStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.VmGroupStatusEnum left, Azure.ResourceManager.Avs.Models.VmGroupStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmHostPlacementPolicyProperties : Azure.ResourceManager.Avs.Models.PlacementPolicyProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties>
    {
        public VmHostPlacementPolicyProperties(System.Collections.Generic.IEnumerable<string> vmMembers, System.Collections.Generic.IEnumerable<string> hostMembers, Azure.ResourceManager.Avs.Models.AffinityType affinityType) { }
        public Azure.ResourceManager.Avs.Models.AffinityStrength? AffinityStrength { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AffinityType AffinityType { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AzureHybridBenefitType? AzureHybridBenefitType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> HostMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> VmMembers { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmPlacementPolicyProperties : Azure.ResourceManager.Avs.Models.PlacementPolicyProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties>
    {
        public VmPlacementPolicyProperties(System.Collections.Generic.IEnumerable<string> vmMembers, Azure.ResourceManager.Avs.Models.AffinityType affinityType) { }
        public Azure.ResourceManager.Avs.Models.AffinityType AffinityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VmMembers { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmTypeEnum : System.IEquatable<Azure.ResourceManager.Avs.Models.VmTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmTypeEnum(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VmTypeEnum EDGE { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.VmTypeEnum REGULAR { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.VmTypeEnum SERVICE { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.VmTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.VmTypeEnum left, Azure.ResourceManager.Avs.Models.VmTypeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.VmTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.VmTypeEnum left, Azure.ResourceManager.Avs.Models.VmTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class WorkloadNetworkDhcpEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity>
    {
        protected WorkloadNetworkDhcpEntity() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Segments { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkDhcpProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkDhcpProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkloadNetworkDhcpRelay : Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpRelay>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpRelay>
    {
        public WorkloadNetworkDhcpRelay() { }
        public System.Collections.Generic.IList<string> ServerAddresses { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpRelay System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpRelay>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpRelay>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpRelay System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpRelay>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpRelay>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpRelay>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkDhcpServer : Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpServer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpServer>
    {
        public WorkloadNetworkDhcpServer() { }
        public long? LeaseTime { get { throw null; } set { } }
        public string ServerAddress { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpServer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpServer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpServer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpServer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpServer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpServer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpServer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkDnsServiceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProperties>
    {
        public WorkloadNetworkDnsServiceProperties() { }
        public string DefaultDnsZone { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string DnsServiceIP { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FqdnZones { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.DnsServiceLogLevelEnum? LogLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.DnsServiceStatusEnum? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkDnsServiceProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkDnsServiceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkloadNetworkDnsZoneProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProperties>
    {
        public WorkloadNetworkDnsZoneProperties() { }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServerIPs { get { throw null; } }
        public long? DnsServices { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Domain { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public string SourceIP { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkDnsZoneProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkDnsZoneProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkloadNetworkGatewayProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkGatewayProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkGatewayProperties>
    {
        internal WorkloadNetworkGatewayProperties() { }
        public string DisplayName { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkGatewayProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkGatewayProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkGatewayProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkGatewayProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkGatewayProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkGatewayProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkGatewayProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkPortMirroringProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProperties>
    {
        public WorkloadNetworkPortMirroringProperties() { }
        public string Destination { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.PortMirroringDirectionEnum? Direction { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.PortMirroringStatusEnum? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkPortMirroringProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkPortMirroringProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkloadNetworkPublicIPProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProperties>
    {
        public WorkloadNetworkPublicIPProperties() { }
        public string DisplayName { get { throw null; } set { } }
        public long? NumberOfPublicIPs { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState? ProvisioningState { get { throw null; } }
        public string PublicIPBlock { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkPublicIPProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkPublicIPProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkloadNetworkSegmentPortVif : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif>
    {
        internal WorkloadNetworkSegmentPortVif() { }
        public string PortName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkSegmentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProperties>
    {
        public WorkloadNetworkSegmentProperties() { }
        public string ConnectedGateway { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif> PortVif { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.SegmentStatusEnum? Status { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentSubnet Subnet { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkSegmentProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkSegmentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkloadNetworkSegmentSubnet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentSubnet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentSubnet>
    {
        public WorkloadNetworkSegmentSubnet() { }
        public System.Collections.Generic.IList<string> DhcpRanges { get { throw null; } }
        public string GatewayAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentSubnet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentSubnet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentSubnet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentSubnet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentSubnet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentSubnet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentSubnet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkVirtualMachineProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkVirtualMachineProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkVirtualMachineProperties>
    {
        internal WorkloadNetworkVirtualMachineProperties() { }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.VmTypeEnum? VmType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkVirtualMachineProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkVirtualMachineProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkVirtualMachineProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkVirtualMachineProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkVirtualMachineProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkVirtualMachineProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkVirtualMachineProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkVmGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProperties>
    {
        public WorkloadNetworkVmGroupProperties() { }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Members { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.VmGroupStatusEnum? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkVmGroupProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkVmGroupProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
