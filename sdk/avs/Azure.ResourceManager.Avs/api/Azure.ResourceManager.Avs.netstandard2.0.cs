namespace Azure.ResourceManager.Avs
{
    public partial class AvsCloudLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsCloudLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsCloudLinkResource>, System.Collections.IEnumerable
    {
        protected AvsCloudLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsCloudLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudLinkName, Azure.ResourceManager.Avs.AvsCloudLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsCloudLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudLinkName, Azure.ResourceManager.Avs.AvsCloudLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsCloudLinkResource> Get(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AvsCloudLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsCloudLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsCloudLinkResource>> GetAsync(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.AvsCloudLinkResource> GetIfExists(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.AvsCloudLinkResource>> GetIfExistsAsync(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.AvsCloudLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsCloudLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.AvsCloudLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsCloudLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsCloudLinkData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsCloudLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsCloudLinkData>
    {
        public AvsCloudLinkData() { }
        public Azure.Core.ResourceIdentifier LinkedCloud { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsCloudLinkProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus? Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsCloudLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsCloudLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsCloudLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsCloudLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsCloudLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsCloudLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsCloudLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsCloudLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsCloudLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsCloudLinkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsCloudLinkResource() { }
        public virtual Azure.ResourceManager.Avs.AvsCloudLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string cloudLinkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsCloudLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsCloudLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.AvsCloudLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsCloudLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsCloudLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsCloudLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsCloudLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsCloudLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsCloudLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsCloudLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AvsCloudLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsCloudLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AvsCloudLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class AvsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaAvailabilityResult> CheckAvsQuotaAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaAvailabilityResult>> CheckAvsQuotaAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult> CheckAvsTrialAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Avs.Models.AvsSku sku = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult> CheckAvsTrialAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult>> CheckAvsTrialAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Avs.Models.AvsSku sku = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult>> CheckAvsTrialAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.ResourceManager.Avs.AvsCloudLinkResource GetAvsCloudLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.AvsHostResource GetAvsHostResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource> GetAvsPrivateCloud(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource GetAvsPrivateCloudAddonResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> GetAvsPrivateCloudAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource GetAvsPrivateCloudClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource GetAvsPrivateCloudClusterVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource GetAvsPrivateCloudDatastoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudResource GetAvsPrivateCloudResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudCollection GetAvsPrivateClouds(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Avs.AvsPrivateCloudResource> GetAvsPrivateClouds(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsPrivateCloudResource> GetAvsPrivateCloudsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Avs.AvsProvisionedNetworkResource GetAvsProvisionedNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPureStoragePolicyResource GetAvsPureStoragePolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Avs.Models.AvsResourceSku> GetAvsSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Avs.Models.AvsResourceSku> GetAvsSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource GetExpressRouteAuthorizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.GlobalReachConnectionResource GetGlobalReachConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.HcxEnterpriseSiteResource GetHcxEnterpriseSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.IscsiPathResource GetIscsiPathResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.LicenseResource GetLicenseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.MaintenanceResource GetMaintenanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.PlacementPolicyResource GetPlacementPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptCmdletResource GetScriptCmdletResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptExecutionResource GetScriptExecutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptPackageResource GetScriptPackageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource GetWorkloadNetworkDhcpResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource GetWorkloadNetworkDnsServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource GetWorkloadNetworkDnsZoneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource GetWorkloadNetworkGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource GetWorkloadNetworkPortMirroringProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource GetWorkloadNetworkPublicIPResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkResource GetWorkloadNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource GetWorkloadNetworkSegmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource GetWorkloadNetworkVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource GetWorkloadNetworkVmGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class AvsHostCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsHostResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsHostResource>, System.Collections.IEnumerable
    {
        protected AvsHostCollection() { }
        public virtual Azure.Response<bool> Exists(string hostId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hostId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsHostResource> Get(string hostId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AvsHostResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsHostResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsHostResource>> GetAsync(string hostId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.AvsHostResource> GetIfExists(string hostId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.AvsHostResource>> GetIfExistsAsync(string hostId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.AvsHostResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsHostResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.AvsHostResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsHostResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsHostData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsHostData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsHostData>
    {
        internal AvsHostData() { }
        public Azure.ResourceManager.Avs.Models.AvsHostProperties Properties { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsSku Sku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsHostData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsHostData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsHostData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsHostData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsHostData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsHostData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsHostData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsHostResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsHostData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsHostData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsHostResource() { }
        public virtual Azure.ResourceManager.Avs.AvsHostData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string clusterName, string hostId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsHostResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsHostResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.AvsHostData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsHostData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsHostData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsHostData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsHostData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsHostData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsHostData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsPrivateCloudAddonCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>, System.Collections.IEnumerable
    {
        protected AvsPrivateCloudAddonCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string addonName, Azure.ResourceManager.Avs.AvsPrivateCloudAddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string addonName, Azure.ResourceManager.Avs.AvsPrivateCloudAddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> Get(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>> GetAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> GetIfExists(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>> GetIfExistsAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsPrivateCloudAddonData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudAddonData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudAddonData>
    {
        public AvsPrivateCloudAddonData() { }
        public Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPrivateCloudAddonData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudAddonData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudAddonData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPrivateCloudAddonData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudAddonData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudAddonData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudAddonData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsPrivateCloudAddonResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudAddonData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudAddonData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsPrivateCloudAddonResource() { }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudAddonData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string addonName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.AvsPrivateCloudAddonData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudAddonData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudAddonData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPrivateCloudAddonData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudAddonData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudAddonData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudAddonData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AvsPrivateCloudAddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AvsPrivateCloudAddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AvsPrivateCloudClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>, System.Collections.IEnumerable
    {
        protected AvsPrivateCloudClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Avs.AvsPrivateCloudClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Avs.AvsPrivateCloudClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsPrivateCloudClusterData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterData>
    {
        public AvsPrivateCloudClusterData(Azure.ResourceManager.Avs.Models.AvsSku sku) { }
        public int? ClusterId { get { throw null; } }
        public int? ClusterSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Hosts { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsSku Sku { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string SkuName { get { throw null; } set { } }
        public string VsanDatastoreName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPrivateCloudClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPrivateCloudClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsPrivateCloudClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsPrivateCloudClusterResource() { }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsHostResource> GetAvsHost(string hostId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsHostResource>> GetAvsHostAsync(string hostId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsHostCollection GetAvsHosts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource> GetAvsPrivateCloudClusterVirtualMachine(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource>> GetAvsPrivateCloudClusterVirtualMachineAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineCollection GetAvsPrivateCloudClusterVirtualMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> GetAvsPrivateCloudDatastore(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>> GetAvsPrivateCloudDatastoreAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreCollection GetAvsPrivateCloudDatastores() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.Models.AvsClusterZoneListResult> GetClusterZones(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.AvsClusterZoneListResult>> GetClusterZonesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.PlacementPolicyCollection GetPlacementPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.PlacementPolicyResource> GetPlacementPolicy(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.PlacementPolicyResource>> GetPlacementPolicyAsync(string placementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.Models.AvsClusterZone> GetZones(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.Models.AvsClusterZone> GetZonesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.AvsPrivateCloudClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPrivateCloudClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AvsPrivateCloudClusterVirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource>, System.Collections.IEnumerable
    {
        protected AvsPrivateCloudClusterVirtualMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource> Get(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource>> GetAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource> GetIfExists(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource>> GetIfExistsAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsPrivateCloudClusterVirtualMachineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData>
    {
        public AvsPrivateCloudClusterVirtualMachineData() { }
        public string DisplayName { get { throw null; } }
        public string FolderPath { get { throw null; } }
        public string MoRefId { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsVirtualMachineProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState? RestrictMovement { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsPrivateCloudClusterVirtualMachineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsPrivateCloudClusterVirtualMachineResource() { }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string clusterName, string virtualMachineId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestrictMovement(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterVirtualMachineRestrictMovement restrictMovement, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestrictMovementAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterVirtualMachineRestrictMovement restrictMovement, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsPrivateCloudCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudResource>, System.Collections.IEnumerable
    {
        protected AvsPrivateCloudCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateCloudName, Azure.ResourceManager.Avs.AvsPrivateCloudData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateCloudName, Azure.ResourceManager.Avs.AvsPrivateCloudData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource> Get(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AvsPrivateCloudResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsPrivateCloudResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> GetAsync(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.AvsPrivateCloudResource> GetIfExists(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> GetIfExistsAsync(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsPrivateCloudData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudData>
    {
        public AvsPrivateCloudData(Azure.Core.AzureLocation location, Azure.ResourceManager.Avs.Models.AvsSku sku) { }
        public Azure.ResourceManager.Avs.Models.PrivateCloudAvailabilityProperties Availability { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.ExpressRouteCircuit Circuit { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsDnsZoneType? DnsZoneType { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.CustomerManagedEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsPrivateCloudEndpoints Endpoints { get { throw null; } }
        public System.Collections.Generic.IList<string> ExtendedNetworkBlocks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ExternalCloudLinks { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.SingleSignOnIdentitySource> IdentitySources { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.InternetConnectivityState? Internet { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsManagementCluster ManagementCluster { get { throw null; } set { } }
        public string ManagementNetwork { get { throw null; } }
        public string NetworkBlock { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum? NsxPublicIPQuotaRaised { get { throw null; } }
        public string NsxtCertificateThumbprint { get { throw null; } }
        public string NsxtPassword { get { throw null; } set { } }
        public string ProvisioningNetwork { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ExpressRouteCircuit SecondaryCircuit { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsSku Sku { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string SkuName { get { throw null; } set { } }
        public string VCenterCertificateThumbprint { get { throw null; } }
        public string VCenterPassword { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.VcfLicense VcfLicense { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualNetworkId { get { throw null; } set { } }
        public string VMotionNetwork { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPrivateCloudData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPrivateCloudData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsPrivateCloudDatastoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>, System.Collections.IEnumerable
    {
        protected AvsPrivateCloudDatastoreCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string datastoreName, Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string datastoreName, Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> Get(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>> GetAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> GetIfExists(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>> GetIfExistsAsync(string datastoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsPrivateCloudDatastoreData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData>
    {
        public AvsPrivateCloudDatastoreData() { }
        public Azure.ResourceManager.Avs.Models.DiskPoolVolume DiskPoolVolume { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ElasticSanVolumeTargetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetAppVolumeId { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsPureStorageVolume PureStorageVolume { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.DatastoreStatus? Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsPrivateCloudDatastoreResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsPrivateCloudDatastoreResource() { }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string clusterName, string datastoreName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AvsPrivateCloudResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsPrivateCloudResource() { }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.Models.AdminCredentials> GetAdminCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.AdminCredentials>> GetAdminCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsCloudLinkResource> GetAvsCloudLink(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsCloudLinkResource>> GetAvsCloudLinkAsync(string cloudLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsCloudLinkCollection GetAvsCloudLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource> GetAvsPrivateCloudAddon(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource>> GetAvsPrivateCloudAddonAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudAddonCollection GetAvsPrivateCloudAddons() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource> GetAvsPrivateCloudCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource>> GetAvsPrivateCloudClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudClusterCollection GetAvsPrivateCloudClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsProvisionedNetworkResource> GetAvsProvisionedNetwork(string provisionedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsProvisionedNetworkResource>> GetAvsProvisionedNetworkAsync(string provisionedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsProvisionedNetworkCollection GetAvsProvisionedNetworks() { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsPureStoragePolicyCollection GetAvsPureStoragePolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource> GetAvsPureStoragePolicy(string storagePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource>> GetAvsPureStoragePolicyAsync(string storagePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Avs.LicenseResource> GetLicense(Azure.ResourceManager.Avs.Models.LicenseName licenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.LicenseResource>> GetLicenseAsync(Azure.ResourceManager.Avs.Models.LicenseName licenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.LicenseCollection GetLicenses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.MaintenanceResource> GetMaintenance(string maintenanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.MaintenanceResource>> GetMaintenanceAsync(string maintenanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.MaintenanceCollection GetMaintenances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource> GetScriptExecution(string scriptExecutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptExecutionResource>> GetScriptExecutionAsync(string scriptExecutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.ScriptExecutionCollection GetScriptExecutions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.ScriptPackageResource> GetScriptPackage(string scriptPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.ScriptPackageResource>> GetScriptPackageAsync(string scriptPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.ScriptPackageCollection GetScriptPackages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.Models.VcfLicense> GetVcfLicense(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.VcfLicense>> GetVcfLicenseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkResource GetWorkloadNetwork() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release.", false)]
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkResource> GetWorkloadNetwork(Azure.ResourceManager.Avs.Models.WorkloadNetworkName workloadNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release.", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkResource>> GetWorkloadNetworkAsync(Azure.ResourceManager.Avs.Models.WorkloadNetworkName workloadNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource> GetWorkloadNetworkDhcp(string dhcpId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource>> GetWorkloadNetworkDhcpAsync(string dhcpId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDhcpCollection GetWorkloadNetworkDhcps() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource> GetWorkloadNetworkDnsService(string dnsServiceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource>> GetWorkloadNetworkDnsServiceAsync(string dnsServiceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceCollection GetWorkloadNetworkDnsServices() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource> GetWorkloadNetworkDnsZone(string dnsZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource>> GetWorkloadNetworkDnsZoneAsync(string dnsZoneId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneCollection GetWorkloadNetworkDnsZones() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource> GetWorkloadNetworkGateway(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource>> GetWorkloadNetworkGatewayAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkGatewayCollection GetWorkloadNetworkGateways() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> GetWorkloadNetworkPortMirroringProfile(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>> GetWorkloadNetworkPortMirroringProfileAsync(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileCollection GetWorkloadNetworkPortMirroringProfiles() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource> GetWorkloadNetworkPublicIP(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource>> GetWorkloadNetworkPublicIPAsync(string publicIPId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPublicIPCollection GetWorkloadNetworkPublicIPs() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release.", false)]
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkCollection GetWorkloadNetworks() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource> GetWorkloadNetworkSegment(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource>> GetWorkloadNetworkSegmentAsync(string segmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkSegmentCollection GetWorkloadNetworkSegments() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource> GetWorkloadNetworkVirtualMachine(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource>> GetWorkloadNetworkVirtualMachineAsync(string virtualMachineId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineCollection GetWorkloadNetworkVirtualMachines() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource> GetWorkloadNetworkVmGroup(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource>> GetWorkloadNetworkVmGroupAsync(string vmGroupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkVmGroupCollection GetWorkloadNetworkVmGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RotateNsxtPassword(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RotateNsxtPasswordAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RotateVCenterPassword(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RotateVCenterPasswordAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.AvsPrivateCloudData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPrivateCloudData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPrivateCloudData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPrivateCloudData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.AvsPrivateCloudPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.AvsPrivateCloudPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AvsProvisionedNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsProvisionedNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsProvisionedNetworkResource>, System.Collections.IEnumerable
    {
        protected AvsProvisionedNetworkCollection() { }
        public virtual Azure.Response<bool> Exists(string provisionedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string provisionedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsProvisionedNetworkResource> Get(string provisionedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AvsProvisionedNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsProvisionedNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsProvisionedNetworkResource>> GetAsync(string provisionedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.AvsProvisionedNetworkResource> GetIfExists(string provisionedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.AvsProvisionedNetworkResource>> GetIfExistsAsync(string provisionedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.AvsProvisionedNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsProvisionedNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.AvsProvisionedNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsProvisionedNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsProvisionedNetworkData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsProvisionedNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsProvisionedNetworkData>
    {
        internal AvsProvisionedNetworkData() { }
        public Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsProvisionedNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsProvisionedNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsProvisionedNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsProvisionedNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsProvisionedNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsProvisionedNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsProvisionedNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsProvisionedNetworkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsProvisionedNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsProvisionedNetworkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsProvisionedNetworkResource() { }
        public virtual Azure.ResourceManager.Avs.AvsProvisionedNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string provisionedNetworkName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsProvisionedNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsProvisionedNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.AvsProvisionedNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsProvisionedNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsProvisionedNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsProvisionedNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsProvisionedNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsProvisionedNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsProvisionedNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsPureStoragePolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource>, System.Collections.IEnumerable
    {
        protected AvsPureStoragePolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storagePolicyName, Azure.ResourceManager.Avs.AvsPureStoragePolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storagePolicyName, Azure.ResourceManager.Avs.AvsPureStoragePolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storagePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storagePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource> Get(string storagePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource>> GetAsync(string storagePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource> GetIfExists(string storagePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource>> GetIfExistsAsync(string storagePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvsPureStoragePolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPureStoragePolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPureStoragePolicyData>
    {
        public AvsPureStoragePolicyData() { }
        public Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPureStoragePolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPureStoragePolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPureStoragePolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPureStoragePolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPureStoragePolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPureStoragePolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPureStoragePolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsPureStoragePolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPureStoragePolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPureStoragePolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvsPureStoragePolicyResource() { }
        public virtual Azure.ResourceManager.Avs.AvsPureStoragePolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string storagePolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.AvsPureStoragePolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPureStoragePolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.AvsPureStoragePolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.AvsPureStoragePolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPureStoragePolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPureStoragePolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.AvsPureStoragePolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AvsPureStoragePolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.AvsPureStoragePolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.AvsPureStoragePolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerAvsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerAvsContext() { }
        public static Azure.ResourceManager.Avs.AzureResourceManagerAvsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
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
        public Azure.Core.ResourceIdentifier ExpressRouteAuthorizationId { get { throw null; } }
        public string ExpressRouteAuthorizationKey { get { throw null; } }
        public Azure.Core.ResourceIdentifier ExpressRouteId { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState? ProvisioningState { get { throw null; } }
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
        public string AddressPrefix { get { throw null; } }
        public string AuthorizationKey { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus? CircuitConnectionStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier ExpressRouteId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PeerExpressRouteCircuit { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState? ProvisioningState { get { throw null; } }
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
        public string ActivationKey { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus? Status { get { throw null; } }
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
    public partial class IscsiPathData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.IscsiPathData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.IscsiPathData>
    {
        public IscsiPathData() { }
        public string NetworkBlock { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState? ProvisioningState { get { throw null; } }
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
    public partial class LicenseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.LicenseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.LicenseResource>, System.Collections.IEnumerable
    {
        protected LicenseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.LicenseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.LicenseName licenseName, Azure.ResourceManager.Avs.LicenseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.LicenseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.Models.LicenseName licenseName, Azure.ResourceManager.Avs.LicenseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Avs.Models.LicenseName licenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Avs.Models.LicenseName licenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.LicenseResource> Get(Azure.ResourceManager.Avs.Models.LicenseName licenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.LicenseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.LicenseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.LicenseResource>> GetAsync(Azure.ResourceManager.Avs.Models.LicenseName licenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.LicenseResource> GetIfExists(Azure.ResourceManager.Avs.Models.LicenseName licenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.LicenseResource>> GetIfExistsAsync(Azure.ResourceManager.Avs.Models.LicenseName licenseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.LicenseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.LicenseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.LicenseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.LicenseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LicenseData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.LicenseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.LicenseData>
    {
        public LicenseData() { }
        public Azure.ResourceManager.Avs.Models.LicenseProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.LicenseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.LicenseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.LicenseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.LicenseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.LicenseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.LicenseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.LicenseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LicenseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.LicenseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.LicenseData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LicenseResource() { }
        public virtual Azure.ResourceManager.Avs.LicenseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, Azure.ResourceManager.Avs.Models.LicenseName licenseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.LicenseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.LicenseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.Models.LicenseProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.LicenseProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.LicenseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.LicenseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.LicenseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.LicenseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.LicenseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.LicenseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.LicenseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.LicenseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.LicenseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.LicenseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.LicenseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MaintenanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.MaintenanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.MaintenanceResource>, System.Collections.IEnumerable
    {
        protected MaintenanceCollection() { }
        public virtual Azure.Response<bool> Exists(string maintenanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string maintenanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.MaintenanceResource> Get(string maintenanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.MaintenanceResource> GetAll(Azure.ResourceManager.Avs.Models.MaintenanceStateName? stateName = default(Azure.ResourceManager.Avs.Models.MaintenanceStateName?), Azure.ResourceManager.Avs.Models.MaintenanceStatusFilter? status = default(Azure.ResourceManager.Avs.Models.MaintenanceStatusFilter?), System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.MaintenanceResource> GetAllAsync(Azure.ResourceManager.Avs.Models.MaintenanceStateName? stateName = default(Azure.ResourceManager.Avs.Models.MaintenanceStateName?), Azure.ResourceManager.Avs.Models.MaintenanceStatusFilter? status = default(Azure.ResourceManager.Avs.Models.MaintenanceStatusFilter?), System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.MaintenanceResource>> GetAsync(string maintenanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.MaintenanceResource> GetIfExists(string maintenanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.MaintenanceResource>> GetIfExistsAsync(string maintenanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.MaintenanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.MaintenanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.MaintenanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.MaintenanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MaintenanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.MaintenanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.MaintenanceData>
    {
        internal MaintenanceData() { }
        public Azure.ResourceManager.Avs.Models.MaintenanceProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.MaintenanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.MaintenanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.MaintenanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.MaintenanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.MaintenanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.MaintenanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.MaintenanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaintenanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.MaintenanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.MaintenanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaintenanceResource() { }
        public virtual Azure.ResourceManager.Avs.MaintenanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string maintenanceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.MaintenanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.MaintenanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.MaintenanceResource> InitiateChecks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.MaintenanceResource>> InitiateChecksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.MaintenanceResource> Reschedule(Azure.ResourceManager.Avs.Models.MaintenanceReschedule body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.MaintenanceResource>> RescheduleAsync(Azure.ResourceManager.Avs.Models.MaintenanceReschedule body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.MaintenanceResource> Schedule(Azure.ResourceManager.Avs.Models.MaintenanceSchedule body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.MaintenanceResource>> ScheduleAsync(Azure.ResourceManager.Avs.Models.MaintenanceSchedule body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.MaintenanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.MaintenanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.MaintenanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.MaintenanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.MaintenanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.MaintenanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.MaintenanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public ScriptCmdletData() { }
        public Azure.ResourceManager.Avs.Models.ScriptCmdletAudience? Audience { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.ScriptParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ScriptCmdletProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan? Timeout { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<string> Errors { get { throw null; } }
        public string FailureReason { get { throw null; } set { } }
        public System.DateTimeOffset? FinishedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails> HiddenParameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Information { get { throw null; } }
        public System.BinaryData NamedOutputs { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Output { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails> Parameters { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState? ProvisioningState { get { throw null; } }
        public string Retention { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ScriptCmdletId { get { throw null; } set { } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public System.DateTimeOffset? SubmittedOn { get { throw null; } }
        public string Timeout { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Warnings { get { throw null; } }
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
        public ScriptPackageData() { }
        public string Company { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ScriptPackageProvisioningState? ProvisioningState { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public string Version { get { throw null; } }
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
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is obsolete and will be removed in a future release.", false)]
    public partial class WorkloadNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Avs.Models.WorkloadNetworkName workloadNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Avs.Models.WorkloadNetworkName workloadNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkResource> Get(Azure.ResourceManager.Avs.Models.WorkloadNetworkName workloadNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkResource>> GetAsync(Azure.ResourceManager.Avs.Models.WorkloadNetworkName workloadNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkResource> GetIfExists(Azure.ResourceManager.Avs.Models.WorkloadNetworkName workloadNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkResource>> GetIfExistsAsync(Azure.ResourceManager.Avs.Models.WorkloadNetworkName workloadNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkData>
    {
        public WorkloadNetworkData() { }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState? ProvisioningState { get { throw null; } }
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
        public string DefaultDnsZone { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Net.IPAddress DnsServiceIP { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FqdnZones { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.DnsServiceLogLevel? LogLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.DnsServiceStatus? Status { get { throw null; } }
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
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Net.IPAddress> DnsServerIPs { get { throw null; } }
        public long? DnsServices { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Domain { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public System.Net.IPAddress SourceIP { get { throw null; } set { } }
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
        public WorkloadNetworkGatewayData() { }
        public string DisplayName { get { throw null; } set { } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState? ProvisioningState { get { throw null; } }
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
    public partial class WorkloadNetworkPortMirroringProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>, System.Collections.IEnumerable
    {
        protected WorkloadNetworkPortMirroringProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string portMirroringId, Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string portMirroringId, Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> Get(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>> GetAsync(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> GetIfExists(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>> GetIfExistsAsync(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadNetworkPortMirroringProfileData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData>
    {
        public WorkloadNetworkPortMirroringProfileData() { }
        public string Destination { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection? Direction { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus? Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadNetworkPortMirroringProfileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadNetworkPortMirroringProfileResource() { }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, string portMirroringId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string DisplayName { get { throw null; } set { } }
        public long? NumberOfPublicIPs { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState? ProvisioningState { get { throw null; } }
        public string PublicIPBlock { get { throw null; } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateCloudName, Azure.ResourceManager.Avs.Models.WorkloadNetworkName workloadNetworkName) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource> GetWorkloadNetworkPortMirroringProfile(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource>> GetWorkloadNetworkPortMirroringProfileAsync(string portMirroringId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileCollection GetWorkloadNetworkPortMirroringProfiles() { throw null; }
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
        public string ConnectedGateway { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif> PortVif { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentSubnet Subnet { get { throw null; } set { } }
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
        public WorkloadNetworkVirtualMachineData() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType? VmType { get { throw null; } }
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
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Members { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState? ProvisioningState { get { throw null; } }
        public long? Revision { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus? Status { get { throw null; } }
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
        public virtual Azure.ResourceManager.Avs.AvsCloudLinkResource GetAvsCloudLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsHostResource GetAvsHostResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudAddonResource GetAvsPrivateCloudAddonResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudClusterResource GetAvsPrivateCloudClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineResource GetAvsPrivateCloudClusterVirtualMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreResource GetAvsPrivateCloudDatastoreResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudResource GetAvsPrivateCloudResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsProvisionedNetworkResource GetAvsProvisionedNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsPureStoragePolicyResource GetAvsPureStoragePolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.ExpressRouteAuthorizationResource GetExpressRouteAuthorizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.GlobalReachConnectionResource GetGlobalReachConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.HcxEnterpriseSiteResource GetHcxEnterpriseSiteResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.IscsiPathResource GetIscsiPathResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.LicenseResource GetLicenseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.MaintenanceResource GetMaintenanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.PlacementPolicyResource GetPlacementPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.ScriptCmdletResource GetScriptCmdletResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.ScriptExecutionResource GetScriptExecutionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.ScriptPackageResource GetScriptPackageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDhcpResource GetWorkloadNetworkDhcpResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceResource GetWorkloadNetworkDnsServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneResource GetWorkloadNetworkDnsZoneResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkGatewayResource GetWorkloadNetworkGatewayResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileResource GetWorkloadNetworkPortMirroringProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkPublicIPResource GetWorkloadNetworkPublicIPResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkResource GetWorkloadNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkSegmentResource GetWorkloadNetworkSegmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineResource GetWorkloadNetworkVirtualMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Avs.WorkloadNetworkVmGroupResource GetWorkloadNetworkVmGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAvsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAvsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource> GetAvsPrivateCloud(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.AvsPrivateCloudResource>> GetAvsPrivateCloudAsync(string privateCloudName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Avs.AvsPrivateCloudCollection GetAvsPrivateClouds() { throw null; }
    }
    public partial class MockableAvsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAvsSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaAvailabilityResult> CheckAvsQuotaAvailability(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaAvailabilityResult>> CheckAvsQuotaAvailabilityAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult> CheckAvsTrialAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.Avs.Models.AvsSku sku = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult> CheckAvsTrialAvailability(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult>> CheckAvsTrialAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Avs.Models.AvsSku sku = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult>> CheckAvsTrialAvailabilityAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.AvsPrivateCloudResource> GetAvsPrivateClouds(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.AvsPrivateCloudResource> GetAvsPrivateCloudsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Avs.Models.AvsResourceSku> GetAvsSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Avs.Models.AvsResourceSku> GetAvsSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Avs.Models
{
    public partial class AddonArcProperties : Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonArcProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonArcProperties>
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
    public partial class AddonHcxProperties : Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonHcxProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonHcxProperties>
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
    public partial class AddonSrmProperties : Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonSrmProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonSrmProperties>
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
    public partial class AddonVrProperties : Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AddonVrProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AddonVrProperties>
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
        public string VCenterPassword { get { throw null; } }
        public string VCenterUsername { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AdminCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AdminCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AdminCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AdminCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AdminCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AdminCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AdminCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmAvsModelFactory
    {
        public static Azure.ResourceManager.Avs.Models.AddonArcProperties AddonArcProperties(Azure.ResourceManager.Avs.Models.AddonProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AddonProvisioningState?), string vCenter = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AddonHcxProperties AddonHcxProperties(Azure.ResourceManager.Avs.Models.AddonProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AddonProvisioningState?), string offer = null, string managementNetwork = null, string uplinkNetwork = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AddonSrmProperties AddonSrmProperties(Azure.ResourceManager.Avs.Models.AddonProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AddonProvisioningState?), string licenseKey = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AddonVrProperties AddonVrProperties(Azure.ResourceManager.Avs.Models.AddonProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AddonProvisioningState?), int vrsCount = 0) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AdminCredentials AdminCredentials(string nsxtUsername = null, string nsxtPassword = null, string vCenterUsername = null, string vCenterPassword = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileRescheduleOperation AvailableWindowForMaintenanceWhileRescheduleOperation(System.DateTimeOffset startsOn = default(System.DateTimeOffset), System.DateTimeOffset endsOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileScheduleOperation AvailableWindowForMaintenanceWhileScheduleOperation(System.DateTimeOffset startsOn = default(System.DateTimeOffset), System.DateTimeOffset endsOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.Avs.AvsCloudLinkData AvsCloudLinkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.AvsCloudLinkProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsCloudLinkProvisioningState?), Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus? status = default(Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus?), Azure.Core.ResourceIdentifier linkedCloud = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsClusterZone AvsClusterZone(System.Collections.Generic.IEnumerable<string> hosts = null, string zone = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsClusterZoneListResult AvsClusterZoneListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.AvsClusterZone> zones = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsEncryptionKeyVaultProperties AvsEncryptionKeyVaultProperties(string keyName = null, string keyVersion = null, string autoDetectedKeyVersion = null, System.Uri keyVaultUri = null, Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus? keyState = default(Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus?), Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType? versionType = default(Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType?)) { throw null; }
        public static Azure.ResourceManager.Avs.AvsHostData AvsHostData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.AvsHostProperties properties = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Avs.Models.AvsSku sku = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsHostProperties AvsHostProperties(string kind = null, Azure.ResourceManager.Avs.Models.AvsHostProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsHostProvisioningState?), string displayName = null, string moRefId = null, string fqdn = null, Azure.ResourceManager.Avs.Models.AvsHostMaintenance? maintenance = default(Azure.ResourceManager.Avs.Models.AvsHostMaintenance?), string faultDomain = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsManagementCluster AvsManagementCluster(int? clusterSize = default(int?), Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState?), int? clusterId = default(int?), System.Collections.Generic.IEnumerable<string> hosts = null, string vsanDatastoreName = null) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudAddonData AvsPrivateCloudAddonData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties AvsPrivateCloudAddonProperties(string addonType = null, Azure.ResourceManager.Avs.Models.AddonProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AddonProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Avs.AvsPrivateCloudClusterData AvsPrivateCloudClusterData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.Avs.Models.AvsSku sku, int? clusterSize = default(int?), Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState?), int? clusterId = default(int?), System.Collections.Generic.IEnumerable<string> hosts = null, string vsanDatastoreName = null) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudClusterData AvsPrivateCloudClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? clusterSize = default(int?), Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState?), int? clusterId = default(int?), System.Collections.Generic.IEnumerable<string> hosts = null, string vsanDatastoreName = null, Azure.ResourceManager.Avs.Models.AvsSku sku = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Avs.AvsPrivateCloudClusterData AvsPrivateCloudClusterData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string sku, int? clusterSize, Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState? provisioningState, int? clusterId, System.Collections.Generic.IEnumerable<string> hosts) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudClusterVirtualMachineData AvsPrivateCloudClusterVirtualMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.AvsVirtualMachineProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsVirtualMachineProvisioningState?), string displayName = null, string moRefId = null, string folderPath = null, Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState? restrictMovement = default(Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState?)) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudData AvsPrivateCloudData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Avs.Models.AvsManagementCluster managementCluster = null, Azure.ResourceManager.Avs.Models.InternetConnectivityState? internet = default(Azure.ResourceManager.Avs.Models.InternetConnectivityState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.SingleSignOnIdentitySource> identitySources = null, Azure.ResourceManager.Avs.Models.PrivateCloudAvailabilityProperties availability = null, Azure.ResourceManager.Avs.Models.CustomerManagedEncryption encryption = null, System.Collections.Generic.IEnumerable<string> extendedNetworkBlocks = null, Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState?), Azure.ResourceManager.Avs.Models.ExpressRouteCircuit circuit = null, Azure.ResourceManager.Avs.Models.AvsPrivateCloudEndpoints endpoints = null, string networkBlock = null, string managementNetwork = null, string provisioningNetwork = null, string vMotionNetwork = null, string vCenterPassword = null, string nsxtPassword = null, string vCenterCertificateThumbprint = null, string nsxtCertificateThumbprint = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> externalCloudLinks = null, Azure.ResourceManager.Avs.Models.ExpressRouteCircuit secondaryCircuit = null, Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum? nsxPublicIPQuotaRaised = default(Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum?), Azure.Core.ResourceIdentifier virtualNetworkId = null, Azure.ResourceManager.Avs.Models.AvsDnsZoneType? dnsZoneType = default(Azure.ResourceManager.Avs.Models.AvsDnsZoneType?), Azure.ResourceManager.Avs.Models.VcfLicense vcfLicense = null, Azure.ResourceManager.Avs.Models.AvsSku sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Avs.AvsPrivateCloudData AvsPrivateCloudData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string sku, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Avs.Models.AvsManagementCluster managementCluster, Azure.ResourceManager.Avs.Models.InternetConnectivityState? internet, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.SingleSignOnIdentitySource> identitySources, Azure.ResourceManager.Avs.Models.PrivateCloudAvailabilityProperties availability, Azure.ResourceManager.Avs.Models.CustomerManagedEncryption encryption, System.Collections.Generic.IEnumerable<string> extendedNetworkBlocks, Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState? provisioningState, Azure.ResourceManager.Avs.Models.ExpressRouteCircuit circuit, Azure.ResourceManager.Avs.Models.AvsPrivateCloudEndpoints endpoints, string networkBlock, string managementNetwork, string provisioningNetwork, string vMotionNetwork, string vCenterPassword, string nsxtPassword, string vCenterCertificateThumbprint, string nsxtCertificateThumbprint, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> externalCloudLinks, Azure.ResourceManager.Avs.Models.ExpressRouteCircuit secondaryCircuit, Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum? nsxPublicIPQuotaRaised) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Avs.AvsPrivateCloudData AvsPrivateCloudData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string skuName = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Avs.Models.AvsManagementCluster managementCluster = null, Azure.ResourceManager.Avs.Models.InternetConnectivityState? internet = default(Azure.ResourceManager.Avs.Models.InternetConnectivityState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.SingleSignOnIdentitySource> identitySources = null, Azure.ResourceManager.Avs.Models.PrivateCloudAvailabilityProperties availability = null, Azure.ResourceManager.Avs.Models.CustomerManagedEncryption encryption = null, Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState?), Azure.ResourceManager.Avs.Models.ExpressRouteCircuit circuit = null, Azure.ResourceManager.Avs.Models.AvsPrivateCloudEndpoints endpoints = null, string networkBlock = null, string managementNetwork = null, string provisioningNetwork = null, string vMotionNetwork = null, string vCenterPassword = null, string nsxtPassword = null, string vCenterCertificateThumbprint = null, string nsxtCertificateThumbprint = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> externalCloudLinks = null, Azure.ResourceManager.Avs.Models.ExpressRouteCircuit secondaryCircuit = null, Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum? nsxPublicIPQuotaRaised = default(Azure.ResourceManager.Avs.Models.NsxPublicIPQuotaRaisedEnum?)) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPrivateCloudDatastoreData AvsPrivateCloudDatastoreData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState?), Azure.Core.ResourceIdentifier netAppVolumeId = null, Azure.ResourceManager.Avs.Models.DiskPoolVolume diskPoolVolume = null, Azure.Core.ResourceIdentifier elasticSanVolumeTargetId = null, Azure.ResourceManager.Avs.Models.AvsPureStorageVolume pureStorageVolume = null, Azure.ResourceManager.Avs.Models.DatastoreStatus? status = default(Azure.ResourceManager.Avs.Models.DatastoreStatus?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudEndpoints AvsPrivateCloudEndpoints(string nsxtManager = null, string vcsa = null, string hcxCloudManager = null, string nsxtManagerIP = null, string vcenterIP = null, string hcxCloudManagerIP = null) { throw null; }
        public static Azure.ResourceManager.Avs.AvsProvisionedNetworkData AvsProvisionedNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProperties AvsProvisionedNetworkProperties(Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProvisioningState?), string addressPrefix = null, Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkType? networkType = default(Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkType?)) { throw null; }
        public static Azure.ResourceManager.Avs.AvsPureStoragePolicyData AvsPureStoragePolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProperties AvsPureStoragePolicyProperties(string storagePolicyDefinition = null, string storagePoolId = null, Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsResourceSku AvsResourceSku(Azure.ResourceManager.Avs.Models.AvsResourceSkuResourceType resourceType = default(Azure.ResourceManager.Avs.Models.AvsResourceSkuResourceType), string name = null, string tier = null, string size = null, string family = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.AvsResourceSkuLocationInfo> locationInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.AvsResourceSkuCapabilities> capabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictions> restrictions = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsResourceSkuCapabilities AvsResourceSkuCapabilities(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsResourceSkuLocationInfo AvsResourceSkuLocationInfo(Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.AvsResourceSkuZoneDetails> zoneDetails = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionInfo AvsResourceSkuRestrictionInfo(System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictions AvsResourceSkuRestrictions(Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsType? type = default(Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsType?), System.Collections.Generic.IEnumerable<string> values = null, Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionInfo restrictionInfo = null, Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsReasonCode? reasonCode = default(Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsReasonCode?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsResourceSkuZoneDetails AvsResourceSkuZoneDetails(System.Collections.Generic.IEnumerable<string> name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.AvsResourceSkuCapabilities> capabilities = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaAvailabilityResult AvsSubscriptionQuotaAvailabilityResult(System.Collections.Generic.IReadOnlyDictionary<string, int> hostsRemaining = null, Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled? quotaEnabled = default(Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult AvsSubscriptionTrialAvailabilityResult(Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus? status = default(Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus?), int? availableHosts = default(int?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.BlockedDatesConstraintTimeRange BlockedDatesConstraintTimeRange(System.DateTimeOffset startsOn = default(System.DateTimeOffset), System.DateTimeOffset endsOn = default(System.DateTimeOffset), string reason = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.BlockedWhileRescheduleOperation BlockedWhileRescheduleOperation(Azure.ResourceManager.Avs.Models.BlockedDatesConstraintCategory category = default(Azure.ResourceManager.Avs.Models.BlockedDatesConstraintCategory), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.BlockedDatesConstraintTimeRange> timeRanges = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.BlockedWhileScheduleOperation BlockedWhileScheduleOperation(Azure.ResourceManager.Avs.Models.BlockedDatesConstraintCategory category = default(Azure.ResourceManager.Avs.Models.BlockedDatesConstraintCategory), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.BlockedDatesConstraintTimeRange> timeRanges = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.CommonClusterProperties CommonClusterProperties(int? clusterSize = default(int?), Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState?), int? clusterId = default(int?), System.Collections.Generic.IEnumerable<string> hosts = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.DiskPoolVolume DiskPoolVolume(Azure.Core.ResourceIdentifier targetId = null, string lunName = null, Azure.ResourceManager.Avs.Models.LunMountMode? mountOption = default(Azure.ResourceManager.Avs.Models.LunMountMode?), string path = null) { throw null; }
        public static Azure.ResourceManager.Avs.ExpressRouteAuthorizationData ExpressRouteAuthorizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.ExpressRouteAuthorizationProvisioningState?), Azure.Core.ResourceIdentifier expressRouteAuthorizationId = null, string expressRouteAuthorizationKey = null, Azure.Core.ResourceIdentifier expressRouteId = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ExpressRouteCircuit ExpressRouteCircuit(string primarySubnet = null, string secondarySubnet = null, Azure.Core.ResourceIdentifier expressRouteId = null, Azure.Core.ResourceIdentifier expressRoutePrivatePeeringId = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.GeneralAvsHostProperties GeneralAvsHostProperties(Azure.ResourceManager.Avs.Models.AvsHostProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsHostProvisioningState?), string displayName = null, string moRefId = null, string fqdn = null, Azure.ResourceManager.Avs.Models.AvsHostMaintenance? maintenance = default(Azure.ResourceManager.Avs.Models.AvsHostMaintenance?), string faultDomain = null) { throw null; }
        public static Azure.ResourceManager.Avs.GlobalReachConnectionData GlobalReachConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.GlobalReachConnectionProvisioningState?), string addressPrefix = null, string authorizationKey = null, Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus? circuitConnectionStatus = default(Azure.ResourceManager.Avs.Models.GlobalReachConnectionStatus?), Azure.Core.ResourceIdentifier peerExpressRouteCircuit = null, Azure.Core.ResourceIdentifier expressRouteId = null) { throw null; }
        public static Azure.ResourceManager.Avs.HcxEnterpriseSiteData HcxEnterpriseSiteData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteProvisioningState?), string activationKey = null, Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus? status = default(Azure.ResourceManager.Avs.Models.HcxEnterpriseSiteStatus?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResource ImpactedMaintenanceResource(string id = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResourceError> errors = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResourceError ImpactedMaintenanceResourceError(string errorCode = null, string name = null, string details = null, System.Collections.Generic.IEnumerable<string> resolutionSteps = null, bool? actionRequired = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Avs.IscsiPathData IscsiPathData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.IscsiPathProvisioningState?), string networkBlock = null) { throw null; }
        public static Azure.ResourceManager.Avs.LicenseData LicenseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.LicenseProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.LicenseProperties LicenseProperties(string kind = null, Azure.ResourceManager.Avs.Models.LicenseProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.LicenseProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Avs.MaintenanceData MaintenanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.MaintenanceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.MaintenanceFailedCheck MaintenanceFailedCheck(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResource> impactedResources = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.MaintenanceProperties MaintenanceProperties(Azure.ResourceManager.Avs.Models.MaintenanceType? component = default(Azure.ResourceManager.Avs.Models.MaintenanceType?), string displayName = null, int? clusterId = default(int?), string infoLink = null, string impact = null, bool? scheduledByMicrosoft = default(bool?), Azure.ResourceManager.Avs.Models.MaintenanceState state = null, System.DateTimeOffset? scheduledStartOn = default(System.DateTimeOffset?), long? estimatedDurationInMinutes = default(long?), Azure.ResourceManager.Avs.Models.MaintenanceProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.MaintenanceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.MaintenanceManagementOperation> operations = null, Azure.ResourceManager.Avs.Models.MaintenanceReadiness maintenanceReadiness = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.MaintenanceReadiness MaintenanceReadiness(Azure.ResourceManager.Avs.Models.MaintenanceCheckType type = default(Azure.ResourceManager.Avs.Models.MaintenanceCheckType), Azure.ResourceManager.Avs.Models.MaintenanceReadinessStatus status = default(Azure.ResourceManager.Avs.Models.MaintenanceReadinessStatus), string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.MaintenanceFailedCheck> failedChecks = null, System.DateTimeOffset? lastUpdated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperation MaintenanceReadinessRefreshOperation(bool? isDisabled = default(bool?), string disabledReason = null, Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperationStatus? status = default(Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperationStatus?), bool? refreshedByMicrosoft = default(bool?), string message = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.MaintenanceState MaintenanceState(Azure.ResourceManager.Avs.Models.MaintenanceStateName? name = default(Azure.ResourceManager.Avs.Models.MaintenanceStateName?), string message = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Avs.PlacementPolicyData PlacementPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.PlacementPolicyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PlacementPolicyProperties PlacementPolicyProperties(string type = null, Azure.ResourceManager.Avs.Models.PlacementPolicyState? state = default(Azure.ResourceManager.Avs.Models.PlacementPolicyState?), string displayName = null, Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.RescheduleOperation RescheduleOperation(bool? isDisabled = default(bool?), string disabledReason = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.RescheduleOperationConstraint> constraints = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ScheduleOperation ScheduleOperation(bool? isDisabled = default(bool?), string disabledReason = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ScheduleOperationConstraint> constraints = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.SchedulingWindow SchedulingWindow(System.DateTimeOffset startsOn = default(System.DateTimeOffset), System.DateTimeOffset endsOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptCmdletData ScriptCmdletData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.ScriptCmdletProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.ScriptCmdletProvisioningState?), string description = null, System.TimeSpan? timeout = default(System.TimeSpan?), Azure.ResourceManager.Avs.Models.ScriptCmdletAudience? audience = default(Azure.ResourceManager.Avs.Models.ScriptCmdletAudience?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ScriptParameter> parameters = null) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptExecutionData ScriptExecutionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier scriptCmdletId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails> hiddenParameters = null, string failureReason = null, string timeout = null, string retention = null, System.DateTimeOffset? submittedOn = default(System.DateTimeOffset?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? finishedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.ScriptExecutionProvisioningState?), System.Collections.Generic.IEnumerable<string> output = null, System.BinaryData namedOutputs = null, System.Collections.Generic.IEnumerable<string> information = null, System.Collections.Generic.IEnumerable<string> warnings = null, System.Collections.Generic.IEnumerable<string> errors = null) { throw null; }
        public static Azure.ResourceManager.Avs.ScriptPackageData ScriptPackageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.ScriptPackageProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.ScriptPackageProvisioningState?), string description = null, string version = null, string company = null, System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ScriptParameter ScriptParameter(Azure.ResourceManager.Avs.Models.ScriptParameterType? parameterType = default(Azure.ResourceManager.Avs.Models.ScriptParameterType?), string name = null, string description = null, Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus? visibility = default(Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus?), Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus? optional = default(Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.SpecializedAvsHostProperties SpecializedAvsHostProperties(Azure.ResourceManager.Avs.Models.AvsHostProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.AvsHostProvisioningState?), string displayName = null, string moRefId = null, string fqdn = null, Azure.ResourceManager.Avs.Models.AvsHostMaintenance? maintenance = default(Azure.ResourceManager.Avs.Models.AvsHostMaintenance?), string faultDomain = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.Vcf5License Vcf5License(Azure.ResourceManager.Avs.Models.LicenseProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.LicenseProvisioningState?), string licenseKey = null, int cores = 0, System.DateTimeOffset endOn = default(System.DateTimeOffset), string broadcomSiteId = null, string broadcomContractNumber = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.Label> labels = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VcfLicense VcfLicense(string kind = null, Azure.ResourceManager.Avs.Models.LicenseProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.LicenseProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties VmHostPlacementPolicyProperties(Azure.ResourceManager.Avs.Models.PlacementPolicyState? state = default(Azure.ResourceManager.Avs.Models.PlacementPolicyState?), string displayName = null, Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> vmMembers = null, System.Collections.Generic.IEnumerable<string> hostMembers = null, Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType affinityType = default(Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType), Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength? affinityStrength = default(Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength?), Azure.ResourceManager.Avs.Models.AzureHybridBenefitType? azureHybridBenefitType = default(Azure.ResourceManager.Avs.Models.AzureHybridBenefitType?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties VmPlacementPolicyProperties(Azure.ResourceManager.Avs.Models.PlacementPolicyState? state = default(Azure.ResourceManager.Avs.Models.PlacementPolicyState?), string displayName = null, Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.PlacementPolicyProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> vmMembers = null, Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType affinityType = default(Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VmwareFirewallLicenseProperties VmwareFirewallLicenseProperties(Azure.ResourceManager.Avs.Models.LicenseProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.LicenseProvisioningState?), string licenseKey = null, int cores = 0, System.DateTimeOffset endOn = default(System.DateTimeOffset), string broadcomSiteId = null, string broadcomContractNumber = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.Label> labels = null) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkData WorkloadNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDhcpData WorkloadNetworkDhcpData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity properties = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpEntity WorkloadNetworkDhcpEntity(string dhcpType = null, string displayName = null, System.Collections.Generic.IEnumerable<string> segments = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState?), long? revision = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpRelay WorkloadNetworkDhcpRelay(string displayName = null, System.Collections.Generic.IEnumerable<string> segments = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState?), long? revision = default(long?), System.Collections.Generic.IEnumerable<string> serverAddresses = null) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpServer WorkloadNetworkDhcpServer(string displayName = null, System.Collections.Generic.IEnumerable<string> segments = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkDhcpProvisioningState?), long? revision = default(long?), string serverAddress = null, long? leaseTime = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDnsServiceData WorkloadNetworkDnsServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, System.Net.IPAddress dnsServiceIP = null, string defaultDnsZone = null, System.Collections.Generic.IEnumerable<string> fqdnZones = null, Azure.ResourceManager.Avs.Models.DnsServiceLogLevel? logLevel = default(Azure.ResourceManager.Avs.Models.DnsServiceLogLevel?), Azure.ResourceManager.Avs.Models.DnsServiceStatus? status = default(Azure.ResourceManager.Avs.Models.DnsServiceStatus?), Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsServiceProvisioningState?), long? revision = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkDnsZoneData WorkloadNetworkDnsZoneData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, System.Collections.Generic.IEnumerable<string> domain = null, System.Collections.Generic.IEnumerable<System.Net.IPAddress> dnsServerIPs = null, System.Net.IPAddress sourceIP = null, long? dnsServices = default(long?), Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkDnsZoneProvisioningState?), long? revision = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkGatewayData WorkloadNetworkGatewayData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState?), string displayName = null, string path = null) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkPortMirroringProfileData WorkloadNetworkPortMirroringProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection? direction = default(Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection?), string source = null, string destination = null, Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus? status = default(Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus?), Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState?), long? revision = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkPublicIPData WorkloadNetworkPublicIPData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, long? numberOfPublicIPs = default(long?), string publicIPBlock = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkPublicIPProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkSegmentData WorkloadNetworkSegmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string connectedGateway = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentSubnet subnet = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif> portVif = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus? status = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus?), Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentProvisioningState?), long? revision = default(long?)) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentPortVif WorkloadNetworkSegmentPortVif(string portName = null) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkVirtualMachineData WorkloadNetworkVirtualMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkProvisioningState?), string displayName = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType? vmType = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType?)) { throw null; }
        public static Azure.ResourceManager.Avs.WorkloadNetworkVmGroupData WorkloadNetworkVmGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, System.Collections.Generic.IEnumerable<string> members = null, Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus? status = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus?), Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState? provisioningState = default(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupProvisioningState?), long? revision = default(long?)) { throw null; }
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
    public partial class AvailableWindowForMaintenanceWhileRescheduleOperation : Azure.ResourceManager.Avs.Models.RescheduleOperationConstraint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileRescheduleOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileRescheduleOperation>
    {
        internal AvailableWindowForMaintenanceWhileRescheduleOperation() { }
        public System.DateTimeOffset EndsOn { get { throw null; } }
        public System.DateTimeOffset StartsOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileRescheduleOperation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileRescheduleOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileRescheduleOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileRescheduleOperation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileRescheduleOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileRescheduleOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileRescheduleOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailableWindowForMaintenanceWhileScheduleOperation : Azure.ResourceManager.Avs.Models.ScheduleOperationConstraint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileScheduleOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileScheduleOperation>
    {
        internal AvailableWindowForMaintenanceWhileScheduleOperation() { }
        public System.DateTimeOffset EndsOn { get { throw null; } }
        public System.DateTimeOffset StartsOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileScheduleOperation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileScheduleOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileScheduleOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileScheduleOperation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileScheduleOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileScheduleOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvailableWindowForMaintenanceWhileScheduleOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsCloudLinkProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsCloudLinkProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsCloudLinkProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsCloudLinkProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsCloudLinkProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsCloudLinkProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsCloudLinkProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsCloudLinkProvisioningState left, Azure.ResourceManager.Avs.Models.AvsCloudLinkProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsCloudLinkProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsCloudLinkProvisioningState left, Azure.ResourceManager.Avs.Models.AvsCloudLinkProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsCloudLinkStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsCloudLinkStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus Failed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus left, Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus left, Azure.ResourceManager.Avs.Models.AvsCloudLinkStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsClusterZone : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsClusterZone>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsClusterZone>
    {
        internal AvsClusterZone() { }
        public System.Collections.Generic.IReadOnlyList<string> Hosts { get { throw null; } }
        public string Zone { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsClusterZone System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsClusterZone>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsClusterZone>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsClusterZone System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsClusterZone>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsClusterZone>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsClusterZone>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsClusterZoneListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsClusterZoneListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsClusterZoneListResult>
    {
        internal AvsClusterZoneListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.AvsClusterZone> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsClusterZoneListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsClusterZoneListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsClusterZoneListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsClusterZoneListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsClusterZoneListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsClusterZoneListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsClusterZoneListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsDnsZoneType : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsDnsZoneType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsDnsZoneType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsDnsZoneType Private { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsDnsZoneType Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsDnsZoneType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsDnsZoneType left, Azure.ResourceManager.Avs.Models.AvsDnsZoneType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsDnsZoneType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsDnsZoneType left, Azure.ResourceManager.Avs.Models.AvsDnsZoneType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsEncryptionKeyStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsEncryptionKeyStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus AccessDenied { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus Connected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus left, Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus left, Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsEncryptionKeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsEncryptionKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsEncryptionKeyVaultProperties>
    {
        public AvsEncryptionKeyVaultProperties() { }
        public string AutoDetectedKeyVersion { get { throw null; } }
        public string KeyName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsEncryptionKeyStatus? KeyState { get { throw null; } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType? VersionType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsEncryptionKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsEncryptionKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsEncryptionKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsEncryptionKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsEncryptionKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsEncryptionKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsEncryptionKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsEncryptionState : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsEncryptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsEncryptionState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsEncryptionState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsEncryptionState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsEncryptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsEncryptionState left, Azure.ResourceManager.Avs.Models.AvsEncryptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsEncryptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsEncryptionState left, Azure.ResourceManager.Avs.Models.AvsEncryptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsEncryptionVersionType : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsEncryptionVersionType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType AutoDetected { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType Fixed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType left, Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType left, Azure.ResourceManager.Avs.Models.AvsEncryptionVersionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsHostMaintenance : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsHostMaintenance>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsHostMaintenance(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsHostMaintenance Replacement { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsHostMaintenance Upgrade { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsHostMaintenance other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsHostMaintenance left, Azure.ResourceManager.Avs.Models.AvsHostMaintenance right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsHostMaintenance (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsHostMaintenance left, Azure.ResourceManager.Avs.Models.AvsHostMaintenance right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class AvsHostProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsHostProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsHostProperties>
    {
        protected AvsHostProperties() { }
        public string DisplayName { get { throw null; } }
        public string FaultDomain { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsHostMaintenance? Maintenance { get { throw null; } }
        public string MoRefId { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsHostProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsHostProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsHostProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsHostProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsHostProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsHostProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsHostProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsHostProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsHostProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsHostProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsHostProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsHostProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsHostProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsHostProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsHostProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsHostProvisioningState left, Azure.ResourceManager.Avs.Models.AvsHostProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsHostProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsHostProvisioningState left, Azure.ResourceManager.Avs.Models.AvsHostProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsManagementCluster : Azure.ResourceManager.Avs.Models.CommonClusterProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsManagementCluster>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsManagementCluster>
    {
        public AvsManagementCluster() { }
        public string VsanDatastoreName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsManagementCluster System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsManagementCluster>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsManagementCluster>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsManagementCluster System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsManagementCluster>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsManagementCluster>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsManagementCluster>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsPlacementPolicyAffinityType : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsPlacementPolicyAffinityType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType Affinity { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType AntiAffinity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType left, Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType left, Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class AvsPrivateCloudAddonProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties>
    {
        protected AvsPrivateCloudAddonProperties() { }
        public Azure.ResourceManager.Avs.Models.AddonProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudAddonProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsPrivateCloudClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterPatch>
    {
        public AvsPrivateCloudClusterPatch() { }
        public int? ClusterSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Hosts { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsSku Sku { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsPrivateCloudClusterProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsPrivateCloudClusterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState left, Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState left, Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsPrivateCloudClusterVirtualMachineRestrictMovement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterVirtualMachineRestrictMovement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterVirtualMachineRestrictMovement>
    {
        public AvsPrivateCloudClusterVirtualMachineRestrictMovement() { }
        public Azure.ResourceManager.Avs.Models.VirtualMachineRestrictMovementState? RestrictMovement { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterVirtualMachineRestrictMovement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterVirtualMachineRestrictMovement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterVirtualMachineRestrictMovement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterVirtualMachineRestrictMovement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterVirtualMachineRestrictMovement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterVirtualMachineRestrictMovement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterVirtualMachineRestrictMovement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsPrivateCloudDatastoreProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsPrivateCloudDatastoreProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState left, Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState left, Azure.ResourceManager.Avs.Models.AvsPrivateCloudDatastoreProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsPrivateCloudEndpoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudEndpoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudEndpoints>
    {
        internal AvsPrivateCloudEndpoints() { }
        public string HcxCloudManager { get { throw null; } }
        public string HcxCloudManagerIP { get { throw null; } }
        public string NsxtManager { get { throw null; } }
        public string NsxtManagerIP { get { throw null; } }
        public string VcenterIP { get { throw null; } }
        public string Vcsa { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsPrivateCloudEndpoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudEndpoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudEndpoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsPrivateCloudEndpoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudEndpoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudEndpoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudEndpoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsPrivateCloudPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudPatch>
    {
        public AvsPrivateCloudPatch() { }
        public Azure.ResourceManager.Avs.Models.PrivateCloudAvailabilityProperties Availability { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsDnsZoneType? DnsZoneType { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.CustomerManagedEncryption Encryption { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExtendedNetworkBlocks { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.SingleSignOnIdentitySource> IdentitySources { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.InternetConnectivityState? Internet { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsManagementCluster ManagementCluster { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsPrivateCloudPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsPrivateCloudPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPrivateCloudPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsPrivateCloudProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsPrivateCloudProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState left, Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState left, Azure.ResourceManager.Avs.Models.AvsPrivateCloudProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsProvisionedNetworkProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProperties>
    {
        internal AvsProvisionedNetworkProperties() { }
        public string AddressPrefix { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkType? NetworkType { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsProvisionedNetworkProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsProvisionedNetworkProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProvisioningState left, Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProvisioningState left, Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsProvisionedNetworkType : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsProvisionedNetworkType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkType EsxManagement { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkType EsxReplication { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkType HcxManagement { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkType HcxUplink { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkType VcenterManagement { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkType Vmotion { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkType Vsan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkType left, Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkType left, Azure.ResourceManager.Avs.Models.AvsProvisionedNetworkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsPureStoragePolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProperties>
    {
        public AvsPureStoragePolicyProperties(string storagePolicyDefinition, string storagePoolId) { }
        public Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProvisioningState? ProvisioningState { get { throw null; } }
        public string StoragePolicyDefinition { get { throw null; } set { } }
        public string StoragePoolId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsPureStoragePolicyProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsPureStoragePolicyProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProvisioningState left, Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProvisioningState left, Azure.ResourceManager.Avs.Models.AvsPureStoragePolicyProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsPureStorageVolume : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPureStorageVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPureStorageVolume>
    {
        public AvsPureStorageVolume(Azure.Core.ResourceIdentifier storagePoolId, int sizeGb) { }
        public int SizeGb { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StoragePoolId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsPureStorageVolume System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPureStorageVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsPureStorageVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsPureStorageVolume System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPureStorageVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPureStorageVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsPureStorageVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsResourceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSku>
    {
        internal AvsResourceSku() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.AvsResourceSkuCapabilities> Capabilities { get { throw null; } }
        public string Family { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.AvsResourceSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsResourceSkuResourceType ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictions> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsResourceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsResourceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsResourceSkuCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuCapabilities>
    {
        internal AvsResourceSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsResourceSkuCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsResourceSkuCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsResourceSkuLocationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuLocationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuLocationInfo>
    {
        internal AvsResourceSkuLocationInfo() { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.AvsResourceSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsResourceSkuLocationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuLocationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuLocationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsResourceSkuLocationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuLocationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuLocationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuLocationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsResourceSkuResourceType : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsResourceSkuResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsResourceSkuResourceType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsResourceSkuResourceType PrivateClouds { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsResourceSkuResourceType PrivateCloudsClusters { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsResourceSkuResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsResourceSkuResourceType left, Azure.ResourceManager.Avs.Models.AvsResourceSkuResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsResourceSkuResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsResourceSkuResourceType left, Azure.ResourceManager.Avs.Models.AvsResourceSkuResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsResourceSkuRestrictionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionInfo>
    {
        internal AvsResourceSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsResourceSkuRestrictions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictions>
    {
        internal AvsResourceSkuRestrictions() { }
        public Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsType? Type { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsResourceSkuRestrictionsReasonCode : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsResourceSkuRestrictionsReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsReasonCode QuotaId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsReasonCode left, Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsReasonCode left, Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsResourceSkuRestrictionsType : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsResourceSkuRestrictionsType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsType Location { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsType Zone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsType left, Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsType left, Azure.ResourceManager.Avs.Models.AvsResourceSkuRestrictionsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsResourceSkuZoneDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuZoneDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuZoneDetails>
    {
        internal AvsResourceSkuZoneDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.AvsResourceSkuCapabilities> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsResourceSkuZoneDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuZoneDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuZoneDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsResourceSkuZoneDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuZoneDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuZoneDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsResourceSkuZoneDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class AvsSubscriptionQuotaAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaAvailabilityResult>
    {
        internal AvsSubscriptionQuotaAvailabilityResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> HostsRemaining { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled? QuotaEnabled { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsSubscriptionQuotaEnabled : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsSubscriptionQuotaEnabled(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled left, Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled left, Azure.ResourceManager.Avs.Models.AvsSubscriptionQuotaEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsSubscriptionTrialAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult>
    {
        internal AvsSubscriptionTrialAvailabilityResult() { }
        public int? AvailableHosts { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsSubscriptionTrialStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsSubscriptionTrialStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus TrialAvailable { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus TrialDisabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus TrialUsed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus left, Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus left, Azure.ResourceManager.Avs.Models.AvsSubscriptionTrialStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsVirtualMachineProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.AvsVirtualMachineProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsVirtualMachineProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.AvsVirtualMachineProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsVirtualMachineProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.AvsVirtualMachineProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.AvsVirtualMachineProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.AvsVirtualMachineProvisioningState left, Azure.ResourceManager.Avs.Models.AvsVirtualMachineProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.AvsVirtualMachineProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.AvsVirtualMachineProvisioningState left, Azure.ResourceManager.Avs.Models.AvsVirtualMachineProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlockedDatesConstraintCategory : System.IEquatable<Azure.ResourceManager.Avs.Models.BlockedDatesConstraintCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlockedDatesConstraintCategory(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.BlockedDatesConstraintCategory HiPriorityEvent { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.BlockedDatesConstraintCategory Holiday { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.BlockedDatesConstraintCategory QuotaExhausted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.BlockedDatesConstraintCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.BlockedDatesConstraintCategory left, Azure.ResourceManager.Avs.Models.BlockedDatesConstraintCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.BlockedDatesConstraintCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.BlockedDatesConstraintCategory left, Azure.ResourceManager.Avs.Models.BlockedDatesConstraintCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BlockedDatesConstraintTimeRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.BlockedDatesConstraintTimeRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.BlockedDatesConstraintTimeRange>
    {
        internal BlockedDatesConstraintTimeRange() { }
        public System.DateTimeOffset EndsOn { get { throw null; } }
        public string Reason { get { throw null; } }
        public System.DateTimeOffset StartsOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.BlockedDatesConstraintTimeRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.BlockedDatesConstraintTimeRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.BlockedDatesConstraintTimeRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.BlockedDatesConstraintTimeRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.BlockedDatesConstraintTimeRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.BlockedDatesConstraintTimeRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.BlockedDatesConstraintTimeRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlockedWhileRescheduleOperation : Azure.ResourceManager.Avs.Models.RescheduleOperationConstraint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.BlockedWhileRescheduleOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.BlockedWhileRescheduleOperation>
    {
        internal BlockedWhileRescheduleOperation() { }
        public Azure.ResourceManager.Avs.Models.BlockedDatesConstraintCategory Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.BlockedDatesConstraintTimeRange> TimeRanges { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.BlockedWhileRescheduleOperation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.BlockedWhileRescheduleOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.BlockedWhileRescheduleOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.BlockedWhileRescheduleOperation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.BlockedWhileRescheduleOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.BlockedWhileRescheduleOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.BlockedWhileRescheduleOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlockedWhileScheduleOperation : Azure.ResourceManager.Avs.Models.ScheduleOperationConstraint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.BlockedWhileScheduleOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.BlockedWhileScheduleOperation>
    {
        internal BlockedWhileScheduleOperation() { }
        public Azure.ResourceManager.Avs.Models.BlockedDatesConstraintCategory Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.BlockedDatesConstraintTimeRange> TimeRanges { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.BlockedWhileScheduleOperation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.BlockedWhileScheduleOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.BlockedWhileScheduleOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.BlockedWhileScheduleOperation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.BlockedWhileScheduleOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.BlockedWhileScheduleOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.BlockedWhileScheduleOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommonClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.CommonClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.CommonClusterProperties>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public CommonClusterProperties() { }
        public int? ClusterId { get { throw null; } }
        public int? ClusterSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Hosts { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.AvsPrivateCloudClusterProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.CommonClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.CommonClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.CommonClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.CommonClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.CommonClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.CommonClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.CommonClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomerManagedEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.CustomerManagedEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.CustomerManagedEncryption>
    {
        public CustomerManagedEncryption() { }
        public Azure.ResourceManager.Avs.Models.AvsEncryptionKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsEncryptionState? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.CustomerManagedEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.CustomerManagedEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.CustomerManagedEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.CustomerManagedEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.CustomerManagedEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.CustomerManagedEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.CustomerManagedEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public DiskPoolVolume(Azure.Core.ResourceIdentifier targetId, string lunName) { }
        public string LunName { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.LunMountMode? MountOption { get { throw null; } set { } }
        public string Path { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.DiskPoolVolume System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.DiskPoolVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.DiskPoolVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.DiskPoolVolume System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.DiskPoolVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.DiskPoolVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.DiskPoolVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsServiceLogLevel : System.IEquatable<Azure.ResourceManager.Avs.Models.DnsServiceLogLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsServiceLogLevel(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevel Debug { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevel Error { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevel Fatal { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevel Info { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceLogLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.DnsServiceLogLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.DnsServiceLogLevel left, Azure.ResourceManager.Avs.Models.DnsServiceLogLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.DnsServiceLogLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.DnsServiceLogLevel left, Azure.ResourceManager.Avs.Models.DnsServiceLogLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsServiceStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.DnsServiceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsServiceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.DnsServiceStatus Failure { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.DnsServiceStatus Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.DnsServiceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.DnsServiceStatus left, Azure.ResourceManager.Avs.Models.DnsServiceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.DnsServiceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.DnsServiceStatus left, Azure.ResourceManager.Avs.Models.DnsServiceStatus right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ExpressRouteCircuit : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ExpressRouteCircuit>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ExpressRouteCircuit>
    {
        public ExpressRouteCircuit() { }
        public Azure.Core.ResourceIdentifier ExpressRouteId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ExpressRoutePrivatePeeringId { get { throw null; } }
        public string PrimarySubnet { get { throw null; } }
        public string SecondarySubnet { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ExpressRouteCircuit System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ExpressRouteCircuit>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ExpressRouteCircuit>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ExpressRouteCircuit System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ExpressRouteCircuit>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ExpressRouteCircuit>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ExpressRouteCircuit>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeneralAvsHostProperties : Azure.ResourceManager.Avs.Models.AvsHostProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.GeneralAvsHostProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.GeneralAvsHostProperties>
    {
        internal GeneralAvsHostProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.GeneralAvsHostProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.GeneralAvsHostProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.GeneralAvsHostProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.GeneralAvsHostProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.GeneralAvsHostProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.GeneralAvsHostProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.GeneralAvsHostProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ImpactedMaintenanceResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResource>
    {
        internal ImpactedMaintenanceResource() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResourceError> Errors { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImpactedMaintenanceResourceError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResourceError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResourceError>
    {
        internal ImpactedMaintenanceResourceError() { }
        public bool? ActionRequired { get { throw null; } }
        public string Details { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ResolutionSteps { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResourceError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResourceError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResourceError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResourceError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResourceError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResourceError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResourceError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InternetConnectivityState : System.IEquatable<Azure.ResourceManager.Avs.Models.InternetConnectivityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InternetConnectivityState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.InternetConnectivityState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.InternetConnectivityState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.InternetConnectivityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.InternetConnectivityState left, Azure.ResourceManager.Avs.Models.InternetConnectivityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.InternetConnectivityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.InternetConnectivityState left, Azure.ResourceManager.Avs.Models.InternetConnectivityState right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class Label : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Label>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Label>
    {
        public Label(string key, string value) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.Label System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Label>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Label>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.Label System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Label>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Label>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Label>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LicenseName : System.IEquatable<Azure.ResourceManager.Avs.Models.LicenseName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseName(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.LicenseName VmwareFirewall { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.LicenseName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.LicenseName left, Azure.ResourceManager.Avs.Models.LicenseName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.LicenseName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.LicenseName left, Azure.ResourceManager.Avs.Models.LicenseName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class LicenseProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.LicenseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.LicenseProperties>
    {
        protected LicenseProperties() { }
        public Azure.ResourceManager.Avs.Models.LicenseProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.LicenseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.LicenseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.LicenseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.LicenseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.LicenseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.LicenseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.LicenseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LicenseProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.LicenseProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.LicenseProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.LicenseProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.LicenseProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.LicenseProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.LicenseProvisioningState left, Azure.ResourceManager.Avs.Models.LicenseProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.LicenseProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.LicenseProvisioningState left, Azure.ResourceManager.Avs.Models.LicenseProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LunMountMode : System.IEquatable<Azure.ResourceManager.Avs.Models.LunMountMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LunMountMode(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.LunMountMode Attach { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.LunMountMode Mount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.LunMountMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.LunMountMode left, Azure.ResourceManager.Avs.Models.LunMountMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.LunMountMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.LunMountMode left, Azure.ResourceManager.Avs.Models.LunMountMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceCheckType : System.IEquatable<Azure.ResourceManager.Avs.Models.MaintenanceCheckType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceCheckType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.MaintenanceCheckType Precheck { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceCheckType Preflight { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.MaintenanceCheckType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.MaintenanceCheckType left, Azure.ResourceManager.Avs.Models.MaintenanceCheckType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.MaintenanceCheckType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.MaintenanceCheckType left, Azure.ResourceManager.Avs.Models.MaintenanceCheckType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MaintenanceFailedCheck : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceFailedCheck>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceFailedCheck>
    {
        internal MaintenanceFailedCheck() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.ImpactedMaintenanceResource> ImpactedResources { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.MaintenanceFailedCheck System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceFailedCheck>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceFailedCheck>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.MaintenanceFailedCheck System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceFailedCheck>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceFailedCheck>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceFailedCheck>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MaintenanceManagementOperation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceManagementOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceManagementOperation>
    {
        protected MaintenanceManagementOperation() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.MaintenanceManagementOperation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceManagementOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceManagementOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.MaintenanceManagementOperation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceManagementOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceManagementOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceManagementOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaintenanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceProperties>
    {
        internal MaintenanceProperties() { }
        public int? ClusterId { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.MaintenanceType? Component { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public long? EstimatedDurationInMinutes { get { throw null; } }
        public string Impact { get { throw null; } }
        public string InfoLink { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.MaintenanceReadiness MaintenanceReadiness { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.MaintenanceManagementOperation> Operations { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.MaintenanceProvisioningState? ProvisioningState { get { throw null; } }
        public bool? ScheduledByMicrosoft { get { throw null; } }
        public System.DateTimeOffset? ScheduledStartOn { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.MaintenanceState State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.MaintenanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.MaintenanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.MaintenanceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.MaintenanceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.MaintenanceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.MaintenanceProvisioningState left, Azure.ResourceManager.Avs.Models.MaintenanceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.MaintenanceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.MaintenanceProvisioningState left, Azure.ResourceManager.Avs.Models.MaintenanceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MaintenanceReadiness : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceReadiness>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceReadiness>
    {
        internal MaintenanceReadiness() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.MaintenanceFailedCheck> FailedChecks { get { throw null; } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.MaintenanceReadinessStatus Status { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.MaintenanceCheckType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.MaintenanceReadiness System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceReadiness>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceReadiness>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.MaintenanceReadiness System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceReadiness>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceReadiness>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceReadiness>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaintenanceReadinessRefreshOperation : Azure.ResourceManager.Avs.Models.MaintenanceManagementOperation, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperation>
    {
        internal MaintenanceReadinessRefreshOperation() { }
        public string DisabledReason { get { throw null; } }
        public bool? IsDisabled { get { throw null; } }
        public string Message { get { throw null; } }
        public bool? RefreshedByMicrosoft { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperationStatus? Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceReadinessRefreshOperationStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceReadinessRefreshOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperationStatus NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperationStatus NotStarted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperationStatus left, Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperationStatus left, Azure.ResourceManager.Avs.Models.MaintenanceReadinessRefreshOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceReadinessStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.MaintenanceReadinessStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceReadinessStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.MaintenanceReadinessStatus DataNotAvailable { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceReadinessStatus NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceReadinessStatus NotReady { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceReadinessStatus Ready { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.MaintenanceReadinessStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.MaintenanceReadinessStatus left, Azure.ResourceManager.Avs.Models.MaintenanceReadinessStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.MaintenanceReadinessStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.MaintenanceReadinessStatus left, Azure.ResourceManager.Avs.Models.MaintenanceReadinessStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MaintenanceReschedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceReschedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceReschedule>
    {
        public MaintenanceReschedule() { }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? RescheduleOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.MaintenanceReschedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceReschedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceReschedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.MaintenanceReschedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceReschedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceReschedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceReschedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaintenanceSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceSchedule>
    {
        public MaintenanceSchedule() { }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? ScheduleOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.MaintenanceSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.MaintenanceSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaintenanceState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceState>
    {
        internal MaintenanceState() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.MaintenanceStateName? Name { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.MaintenanceState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.MaintenanceState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.MaintenanceState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.MaintenanceState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceStateName : System.IEquatable<Azure.ResourceManager.Avs.Models.MaintenanceStateName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceStateName(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.MaintenanceStateName Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceStateName Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceStateName InProgress { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceStateName NotScheduled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceStateName Scheduled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceStateName Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.MaintenanceStateName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.MaintenanceStateName left, Azure.ResourceManager.Avs.Models.MaintenanceStateName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.MaintenanceStateName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.MaintenanceStateName left, Azure.ResourceManager.Avs.Models.MaintenanceStateName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceStatusFilter : System.IEquatable<Azure.ResourceManager.Avs.Models.MaintenanceStatusFilter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceStatusFilter(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.MaintenanceStatusFilter Active { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceStatusFilter Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.MaintenanceStatusFilter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.MaintenanceStatusFilter left, Azure.ResourceManager.Avs.Models.MaintenanceStatusFilter right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.MaintenanceStatusFilter (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.MaintenanceStatusFilter left, Azure.ResourceManager.Avs.Models.MaintenanceStatusFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceType : System.IEquatable<Azure.ResourceManager.Avs.Models.MaintenanceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.MaintenanceType ESXI { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceType NSXT { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.MaintenanceType VCSA { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.MaintenanceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.MaintenanceType left, Azure.ResourceManager.Avs.Models.MaintenanceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.MaintenanceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.MaintenanceType left, Azure.ResourceManager.Avs.Models.MaintenanceType right) { throw null; }
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
    public readonly partial struct ParameterOptionalityStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterOptionalityStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus Optional { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus left, Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus left, Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParameterVisibilityStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterVisibilityStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus Hidden { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus Visible { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus left, Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus left, Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlacementPolicyPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PlacementPolicyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PlacementPolicyPatch>
    {
        public PlacementPolicyPatch() { }
        public Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength? AffinityStrength { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AzureHybridBenefitType? AzureHybridBenefitType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> HostMembers { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.PlacementPolicyState? State { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> VmMembers { get { throw null; } }
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
    public readonly partial struct PortMirroringProfileDirection : System.IEquatable<Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortMirroringProfileDirection(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection Bidirectional { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection Egress { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection Ingress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection left, Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection left, Azure.ResourceManager.Avs.Models.PortMirroringProfileDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortMirroringProfileStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortMirroringProfileStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus Failure { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus left, Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus left, Azure.ResourceManager.Avs.Models.PortMirroringProfileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateCloudAvailabilityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PrivateCloudAvailabilityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PrivateCloudAvailabilityProperties>
    {
        public PrivateCloudAvailabilityProperties() { }
        public int? SecondaryZone { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvailabilityStrategy? Strategy { get { throw null; } set { } }
        public int? Zone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PrivateCloudAvailabilityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PrivateCloudAvailabilityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PrivateCloudAvailabilityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PrivateCloudAvailabilityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PrivateCloudAvailabilityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PrivateCloudAvailabilityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PrivateCloudAvailabilityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PSCredentialExecutionParameterDetails : Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameterDetails>
    {
        public PSCredentialExecutionParameterDetails(string name) : base (default(string)) { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameterDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameterDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameterDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameterDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameterDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameterDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.PSCredentialExecutionParameterDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RescheduleOperation : Azure.ResourceManager.Avs.Models.MaintenanceManagementOperation, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.RescheduleOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.RescheduleOperation>
    {
        internal RescheduleOperation() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.RescheduleOperationConstraint> Constraints { get { throw null; } }
        public string DisabledReason { get { throw null; } }
        public bool? IsDisabled { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.RescheduleOperation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.RescheduleOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.RescheduleOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.RescheduleOperation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.RescheduleOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.RescheduleOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.RescheduleOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RescheduleOperationConstraint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.RescheduleOperationConstraint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.RescheduleOperationConstraint>
    {
        protected RescheduleOperationConstraint() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.RescheduleOperationConstraint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.RescheduleOperationConstraint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.RescheduleOperationConstraint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.RescheduleOperationConstraint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.RescheduleOperationConstraint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.RescheduleOperationConstraint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.RescheduleOperationConstraint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduleOperation : Azure.ResourceManager.Avs.Models.MaintenanceManagementOperation, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScheduleOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScheduleOperation>
    {
        internal ScheduleOperation() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Avs.Models.ScheduleOperationConstraint> Constraints { get { throw null; } }
        public string DisabledReason { get { throw null; } }
        public bool? IsDisabled { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScheduleOperation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScheduleOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScheduleOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScheduleOperation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScheduleOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScheduleOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScheduleOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ScheduleOperationConstraint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScheduleOperationConstraint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScheduleOperationConstraint>
    {
        protected ScheduleOperationConstraint() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScheduleOperationConstraint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScheduleOperationConstraint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScheduleOperationConstraint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScheduleOperationConstraint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScheduleOperationConstraint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScheduleOperationConstraint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScheduleOperationConstraint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchedulingWindow : Azure.ResourceManager.Avs.Models.ScheduleOperationConstraint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.SchedulingWindow>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.SchedulingWindow>
    {
        internal SchedulingWindow() { }
        public System.DateTimeOffset EndsOn { get { throw null; } }
        public System.DateTimeOffset StartsOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.SchedulingWindow System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.SchedulingWindow>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.SchedulingWindow>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.SchedulingWindow System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.SchedulingWindow>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.SchedulingWindow>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.SchedulingWindow>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class ScriptExecutionParameterDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails>
    {
        protected ScriptExecutionParameterDetails(string name) { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Avs.Models.ParameterOptionalityStatus? Optional { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ScriptParameterType? ParameterType { get { throw null; } }
        public Azure.ResourceManager.Avs.Models.ParameterVisibilityStatus? Visibility { get { throw null; } }
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
    public partial class ScriptSecureStringExecutionParameterDetails : Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameterDetails>
    {
        public ScriptSecureStringExecutionParameterDetails(string name) : base (default(string)) { }
        public string SecureValue { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameterDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameterDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameterDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameterDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameterDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameterDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptSecureStringExecutionParameterDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScriptStringExecutionParameterDetails : Azure.ResourceManager.Avs.Models.ScriptExecutionParameterDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameterDetails>
    {
        public ScriptStringExecutionParameterDetails(string name) : base (default(string)) { }
        public string Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameterDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameterDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameterDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameterDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameterDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameterDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.ScriptStringExecutionParameterDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SingleSignOnIdentitySource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.SingleSignOnIdentitySource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.SingleSignOnIdentitySource>
    {
        public SingleSignOnIdentitySource() { }
        public string Alias { get { throw null; } set { } }
        public string BaseGroupDN { get { throw null; } set { } }
        public string BaseUserDN { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public System.Uri PrimaryServer { get { throw null; } set { } }
        public System.Uri SecondaryServer { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.SslCertificateStatus? Ssl { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.SingleSignOnIdentitySource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.SingleSignOnIdentitySource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.SingleSignOnIdentitySource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.SingleSignOnIdentitySource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.SingleSignOnIdentitySource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.SingleSignOnIdentitySource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.SingleSignOnIdentitySource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpecializedAvsHostProperties : Azure.ResourceManager.Avs.Models.AvsHostProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.SpecializedAvsHostProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.SpecializedAvsHostProperties>
    {
        internal SpecializedAvsHostProperties() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.SpecializedAvsHostProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.SpecializedAvsHostProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.SpecializedAvsHostProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.SpecializedAvsHostProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.SpecializedAvsHostProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.SpecializedAvsHostProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.SpecializedAvsHostProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SslCertificateStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.SslCertificateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SslCertificateStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.SslCertificateStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.SslCertificateStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.SslCertificateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.SslCertificateStatus left, Azure.ResourceManager.Avs.Models.SslCertificateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.SslCertificateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.SslCertificateStatus left, Azure.ResourceManager.Avs.Models.SslCertificateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Vcf5License : Azure.ResourceManager.Avs.Models.VcfLicense, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Vcf5License>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Vcf5License>
    {
        public Vcf5License(int cores, System.DateTimeOffset endOn) { }
        public string BroadcomContractNumber { get { throw null; } set { } }
        public string BroadcomSiteId { get { throw null; } set { } }
        public int Cores { get { throw null; } set { } }
        public System.DateTimeOffset EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.Label> Labels { get { throw null; } }
        public string LicenseKey { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.Vcf5License System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Vcf5License>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.Vcf5License>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.Vcf5License System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Vcf5License>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Vcf5License>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.Vcf5License>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VcfLicense : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VcfLicense>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VcfLicense>
    {
        protected VcfLicense() { }
        public Azure.ResourceManager.Avs.Models.LicenseProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.VcfLicense System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VcfLicense>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VcfLicense>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.VcfLicense System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VcfLicense>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VcfLicense>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VcfLicense>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct VmHostPlacementPolicyAffinityStrength : System.IEquatable<Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmHostPlacementPolicyAffinityStrength(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength Must { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength Should { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength left, Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength left, Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmHostPlacementPolicyProperties : Azure.ResourceManager.Avs.Models.PlacementPolicyProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties>
    {
        public VmHostPlacementPolicyProperties(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> vmMembers, System.Collections.Generic.IEnumerable<string> hostMembers, Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType affinityType) { }
        public Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyAffinityStrength? AffinityStrength { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType AffinityType { get { throw null; } set { } }
        public Azure.ResourceManager.Avs.Models.AzureHybridBenefitType? AzureHybridBenefitType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> HostMembers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> VmMembers { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmHostPlacementPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmPlacementPolicyProperties : Azure.ResourceManager.Avs.Models.PlacementPolicyProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties>
    {
        public VmPlacementPolicyProperties(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> vmMembers, Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType affinityType) { }
        public Azure.ResourceManager.Avs.Models.AvsPlacementPolicyAffinityType AffinityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> VmMembers { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmPlacementPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmwareFirewallLicenseProperties : Azure.ResourceManager.Avs.Models.LicenseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VmwareFirewallLicenseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmwareFirewallLicenseProperties>
    {
        public VmwareFirewallLicenseProperties(int cores, System.DateTimeOffset endOn) { }
        public string BroadcomContractNumber { get { throw null; } set { } }
        public string BroadcomSiteId { get { throw null; } set { } }
        public int Cores { get { throw null; } set { } }
        public System.DateTimeOffset EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Avs.Models.Label> Labels { get { throw null; } }
        public string LicenseKey { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.VmwareFirewallLicenseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VmwareFirewallLicenseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Avs.Models.VmwareFirewallLicenseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Avs.Models.VmwareFirewallLicenseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmwareFirewallLicenseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmwareFirewallLicenseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Avs.Models.VmwareFirewallLicenseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkName : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkName(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkName left, Azure.ResourceManager.Avs.Models.WorkloadNetworkName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkName left, Azure.ResourceManager.Avs.Models.WorkloadNetworkName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkPortMirroringProfileProvisioningState : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkPortMirroringProfileProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState left, Azure.ResourceManager.Avs.Models.WorkloadNetworkPortMirroringProfileProvisioningState right) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkSegmentStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkSegmentStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus Failure { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus left, Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus left, Azure.ResourceManager.Avs.Models.WorkloadNetworkSegmentStatus right) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkVmGroupStatus : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkVmGroupStatus(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus Failure { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus left, Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus left, Azure.ResourceManager.Avs.Models.WorkloadNetworkVmGroupStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadNetworkVmType : System.IEquatable<Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadNetworkVmType(string value) { throw null; }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType Edge { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType Regular { get { throw null; } }
        public static Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType Service { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType left, Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType left, Azure.ResourceManager.Avs.Models.WorkloadNetworkVmType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
