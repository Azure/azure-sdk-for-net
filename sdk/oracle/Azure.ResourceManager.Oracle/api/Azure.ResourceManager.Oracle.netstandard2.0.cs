namespace Azure.ResourceManager.Oracle
{
    public partial class CloudExadataInfrastructureCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource>, System.Collections.IEnumerable
    {
        protected CloudExadataInfrastructureCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudexadatainfrastructurename, Azure.ResourceManager.Oracle.CloudExadataInfrastructureData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudexadatainfrastructurename, Azure.ResourceManager.Oracle.CloudExadataInfrastructureData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> Get(string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource>> GetAsync(string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> GetIfExists(string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource>> GetIfExistsAsync(string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudExadataInfrastructureData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.CloudExadataInfrastructureData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.CloudExadataInfrastructureData>
    {
        public CloudExadataInfrastructureData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<string> zones) { }
        public int? ActivatedStorageCount { get { throw null; } }
        public int? AdditionalStorageCount { get { throw null; } }
        public int? AvailableStorageSizeInGbs { get { throw null; } }
        public int? ComputeCount { get { throw null; } set { } }
        public int? CpuCount { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Oracle.Models.CustomerContact> CustomerContacts { get { throw null; } }
        public int? DataStorageSizeInTbs { get { throw null; } }
        public int? DbNodeStorageSizeInGbs { get { throw null; } }
        public string DbServerVersion { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Oracle.Models.EstimatedPatchingTime EstimatedPatchingTime { get { throw null; } }
        public string LastMaintenanceRunId { get { throw null; } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.Oracle.Models.MaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public int? MaxCpuCount { get { throw null; } }
        public double? MaxDataStorageInTbs { get { throw null; } }
        public int? MaxDbNodeStorageSizeInGbs { get { throw null; } }
        public int? MaxMemoryInGbs { get { throw null; } }
        public int? MemorySizeInGbs { get { throw null; } }
        public string MonthlyDbServerVersion { get { throw null; } }
        public string MonthlyStorageServerVersion { get { throw null; } }
        public string NextMaintenanceRunId { get { throw null; } }
        public string Ocid { get { throw null; } }
        public System.Uri OciUri { get { throw null; } }
        public Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState? ProvisioningState { get { throw null; } }
        public string Shape { get { throw null; } set { } }
        public int? StorageCount { get { throw null; } set { } }
        public string StorageServerVersion { get { throw null; } }
        public string TimeCreated { get { throw null; } }
        public int? TotalStorageSizeInGbs { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.Oracle.CloudExadataInfrastructureData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.CloudExadataInfrastructureData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.CloudExadataInfrastructureData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.CloudExadataInfrastructureData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.CloudExadataInfrastructureData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.CloudExadataInfrastructureData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.CloudExadataInfrastructureData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudExadataInfrastructureResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudExadataInfrastructureResource() { }
        public virtual Azure.ResourceManager.Oracle.CloudExadataInfrastructureData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudexadatainfrastructurename) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.DbServerResource> GetDbServer(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DbServerResource>> GetDbServerAsync(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Oracle.DbServerCollection GetDbServers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructurePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructurePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudVmClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.CloudVmClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.CloudVmClusterResource>, System.Collections.IEnumerable
    {
        protected CloudVmClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.CloudVmClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudvmclustername, Azure.ResourceManager.Oracle.CloudVmClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.CloudVmClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudvmclustername, Azure.ResourceManager.Oracle.CloudVmClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.CloudVmClusterResource> Get(string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Oracle.CloudVmClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Oracle.CloudVmClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.CloudVmClusterResource>> GetAsync(string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Oracle.CloudVmClusterResource> GetIfExists(string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Oracle.CloudVmClusterResource>> GetIfExistsAsync(string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Oracle.CloudVmClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.CloudVmClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Oracle.CloudVmClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.CloudVmClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudVmClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.CloudVmClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.CloudVmClusterData>
    {
        public CloudVmClusterData(Azure.Core.AzureLocation location) { }
        public string BackupSubnetCidr { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CloudExadataInfrastructureId { get { throw null; } set { } }
        public string ClusterName { get { throw null; } set { } }
        public string CompartmentId { get { throw null; } }
        public System.Collections.Generic.IList<string> ComputeNodes { get { throw null; } }
        public int? CpuCoreCount { get { throw null; } set { } }
        public Azure.ResourceManager.Oracle.Models.DataCollectionConfig DataCollectionOptions { get { throw null; } set { } }
        public int? DataStoragePercentage { get { throw null; } set { } }
        public double? DataStorageSizeInTbs { get { throw null; } set { } }
        public int? DbNodeStorageSizeInGbs { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DbServers { get { throw null; } }
        public Azure.ResourceManager.Oracle.Models.DiskRedundancy? DiskRedundancy { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public string GiVersion { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public Azure.ResourceManager.Oracle.Models.ExadataIormConfig IormConfigCache { get { throw null; } }
        public bool? IsLocalBackupEnabled { get { throw null; } set { } }
        public bool? IsSparseDiskgroupEnabled { get { throw null; } set { } }
        public string LastUpdateHistoryEntryId { get { throw null; } }
        public Azure.ResourceManager.Oracle.Models.LicenseModel? LicenseModel { get { throw null; } set { } }
        public string LifecycleDetails { get { throw null; } }
        public long? ListenerPort { get { throw null; } }
        public int? MemorySizeInGbs { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } }
        public string Ocid { get { throw null; } }
        public System.Uri OciUri { get { throw null; } }
        public float? OcpuCount { get { throw null; } set { } }
        public Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState? ProvisioningState { get { throw null; } }
        public string ScanDnsName { get { throw null; } }
        public string ScanDnsRecordId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ScanIPIds { get { throw null; } }
        public int? ScanListenerPortTcp { get { throw null; } set { } }
        public int? ScanListenerPortTcpSsl { get { throw null; } set { } }
        public string Shape { get { throw null; } }
        public System.Collections.Generic.IList<string> SshPublicKeys { get { throw null; } }
        public int? StorageSizeInGbs { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public string SubnetOcid { get { throw null; } }
        public string SystemVersion { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> VipIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier VnetId { get { throw null; } set { } }
        public string ZoneId { get { throw null; } set { } }
        Azure.ResourceManager.Oracle.CloudVmClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.CloudVmClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.CloudVmClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.CloudVmClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.CloudVmClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.CloudVmClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.CloudVmClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudVmClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudVmClusterResource() { }
        public virtual Azure.ResourceManager.Oracle.CloudVmClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.CloudVmClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.CloudVmClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.CloudVmClusterResource> AddVms(Azure.WaitUntil waitUntil, Azure.ResourceManager.Oracle.Models.AddRemoveDbNode body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.CloudVmClusterResource>> AddVmsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Oracle.Models.AddRemoveDbNode body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudvmclustername) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.CloudVmClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.CloudVmClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.DbNodeResource> GetDbNode(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DbNodeResource>> GetDbNodeAsync(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Oracle.DbNodeCollection GetDbNodes() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Oracle.Models.PrivateIPAddressProperties> GetPrivateIPAddresses(Azure.ResourceManager.Oracle.Models.PrivateIPAddressesFilter body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Oracle.Models.PrivateIPAddressProperties> GetPrivateIPAddressesAsync(Azure.ResourceManager.Oracle.Models.PrivateIPAddressesFilter body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource> GetVirtualNetworkAddress(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource>> GetVirtualNetworkAddressAsync(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Oracle.VirtualNetworkAddressCollection GetVirtualNetworkAddresses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.CloudVmClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.CloudVmClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.CloudVmClusterResource> RemoveVms(Azure.WaitUntil waitUntil, Azure.ResourceManager.Oracle.Models.AddRemoveDbNode body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.CloudVmClusterResource>> RemoveVmsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Oracle.Models.AddRemoveDbNode body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.CloudVmClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.CloudVmClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.CloudVmClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Oracle.Models.CloudVmClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.CloudVmClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Oracle.Models.CloudVmClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DbNodeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.DbNodeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.DbNodeResource>, System.Collections.IEnumerable
    {
        protected DbNodeCollection() { }
        public virtual Azure.Response<bool> Exists(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.DbNodeResource> Get(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Oracle.DbNodeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Oracle.DbNodeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DbNodeResource>> GetAsync(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Oracle.DbNodeResource> GetIfExists(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Oracle.DbNodeResource>> GetIfExistsAsync(string dbnodeocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Oracle.DbNodeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.DbNodeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Oracle.DbNodeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.DbNodeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DbNodeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.DbNodeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DbNodeData>
    {
        public DbNodeData() { }
        public string AdditionalDetails { get { throw null; } }
        public string BackupIPId { get { throw null; } }
        public string BackupVnic2Id { get { throw null; } }
        public string BackupVnicId { get { throw null; } }
        public int? CpuCoreCount { get { throw null; } }
        public int? DbNodeStorageSizeInGbs { get { throw null; } }
        public string DbServerId { get { throw null; } }
        public string DbSystemId { get { throw null; } }
        public string FaultDomain { get { throw null; } }
        public string HostIPId { get { throw null; } }
        public string Hostname { get { throw null; } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.Oracle.Models.DbNodeMaintenanceType? MaintenanceType { get { throw null; } }
        public int? MemorySizeInGbs { get { throw null; } }
        public string Ocid { get { throw null; } }
        public Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState? ProvisioningState { get { throw null; } }
        public int? SoftwareStorageSizeInGb { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.DateTimeOffset? TimeMaintenanceWindowEnd { get { throw null; } }
        public System.DateTimeOffset? TimeMaintenanceWindowStart { get { throw null; } }
        public string Vnic2Id { get { throw null; } }
        public string VnicId { get { throw null; } }
        Azure.ResourceManager.Oracle.DbNodeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.DbNodeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.DbNodeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.DbNodeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DbNodeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DbNodeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DbNodeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DbNodeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DbNodeResource() { }
        public virtual Azure.ResourceManager.Oracle.DbNodeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudvmclustername, string dbnodeocid) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.DbNodeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DbNodeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DbServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.DbServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.DbServerResource>, System.Collections.IEnumerable
    {
        protected DbServerCollection() { }
        public virtual Azure.Response<bool> Exists(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.DbServerResource> Get(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Oracle.DbServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Oracle.DbServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DbServerResource>> GetAsync(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Oracle.DbServerResource> GetIfExists(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Oracle.DbServerResource>> GetIfExistsAsync(string dbserverocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Oracle.DbServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.DbServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Oracle.DbServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.DbServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DbServerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.DbServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DbServerData>
    {
        public DbServerData() { }
        public System.Collections.Generic.IReadOnlyList<string> AutonomousVirtualMachineIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AutonomousVmClusterIds { get { throw null; } }
        public string CompartmentId { get { throw null; } }
        public int? CpuCoreCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DbNodeIds { get { throw null; } }
        public int? DbNodeStorageSizeInGbs { get { throw null; } }
        public Azure.ResourceManager.Oracle.Models.DbServerPatchingDetails DbServerPatchingDetails { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string ExadataInfrastructureId { get { throw null; } }
        public string LifecycleDetails { get { throw null; } }
        public int? MaxCpuCount { get { throw null; } }
        public int? MaxDbNodeStorageInGbs { get { throw null; } }
        public int? MaxMemoryInGbs { get { throw null; } }
        public int? MemorySizeInGbs { get { throw null; } }
        public string Ocid { get { throw null; } }
        public Azure.ResourceManager.Oracle.Models.DbServerProvisioningState? ProvisioningState { get { throw null; } }
        public string Shape { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VmClusterIds { get { throw null; } }
        Azure.ResourceManager.Oracle.DbServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.DbServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.DbServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.DbServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DbServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DbServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DbServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DbServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DbServerResource() { }
        public virtual Azure.ResourceManager.Oracle.DbServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudexadatainfrastructurename, string dbserverocid) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.DbServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DbServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DbSystemShapeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.DbSystemShapeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.DbSystemShapeResource>, System.Collections.IEnumerable
    {
        protected DbSystemShapeCollection() { }
        public virtual Azure.Response<bool> Exists(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.DbSystemShapeResource> Get(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Oracle.DbSystemShapeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Oracle.DbSystemShapeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DbSystemShapeResource>> GetAsync(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Oracle.DbSystemShapeResource> GetIfExists(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Oracle.DbSystemShapeResource>> GetIfExistsAsync(string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Oracle.DbSystemShapeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.DbSystemShapeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Oracle.DbSystemShapeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.DbSystemShapeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DbSystemShapeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.DbSystemShapeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DbSystemShapeData>
    {
        public DbSystemShapeData() { }
        public int? AvailableCoreCount { get { throw null; } }
        public int? AvailableCoreCountPerNode { get { throw null; } }
        public int? AvailableDataStorageInTbs { get { throw null; } }
        public double? AvailableDataStoragePerServerInTbs { get { throw null; } }
        public int? AvailableDbNodePerNodeInGbs { get { throw null; } }
        public int? AvailableDbNodeStorageInGbs { get { throw null; } }
        public int? AvailableMemoryInGbs { get { throw null; } }
        public int? AvailableMemoryPerNodeInGbs { get { throw null; } }
        public int? CoreCountIncrement { get { throw null; } }
        public int? MaximumNodeCount { get { throw null; } }
        public int? MaxStorageCount { get { throw null; } }
        public int? MinCoreCountPerNode { get { throw null; } }
        public int? MinDataStorageInTbs { get { throw null; } }
        public int? MinDbNodeStoragePerNodeInGbs { get { throw null; } }
        public int? MinimumCoreCount { get { throw null; } }
        public int? MinimumNodeCount { get { throw null; } }
        public int? MinMemoryPerNodeInGbs { get { throw null; } }
        public int? MinStorageCount { get { throw null; } }
        public int? RuntimeMinimumCoreCount { get { throw null; } }
        public string ShapeFamily { get { throw null; } }
        Azure.ResourceManager.Oracle.DbSystemShapeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.DbSystemShapeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.DbSystemShapeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.DbSystemShapeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DbSystemShapeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DbSystemShapeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DbSystemShapeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DbSystemShapeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DbSystemShapeResource() { }
        public virtual Azure.ResourceManager.Oracle.DbSystemShapeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string dbsystemshapename) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.DbSystemShapeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DbSystemShapeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsPrivateViewCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.DnsPrivateViewResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.DnsPrivateViewResource>, System.Collections.IEnumerable
    {
        protected DnsPrivateViewCollection() { }
        public virtual Azure.Response<bool> Exists(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.DnsPrivateViewResource> Get(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Oracle.DnsPrivateViewResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Oracle.DnsPrivateViewResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DnsPrivateViewResource>> GetAsync(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Oracle.DnsPrivateViewResource> GetIfExists(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Oracle.DnsPrivateViewResource>> GetIfExistsAsync(string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Oracle.DnsPrivateViewResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.DnsPrivateViewResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Oracle.DnsPrivateViewResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.DnsPrivateViewResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DnsPrivateViewData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.DnsPrivateViewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DnsPrivateViewData>
    {
        public DnsPrivateViewData() { }
        public string DisplayName { get { throw null; } }
        public bool? IsProtected { get { throw null; } }
        public string Ocid { get { throw null; } }
        public Azure.ResourceManager.Oracle.Models.DnsPrivateViewsProvisioningState? ProvisioningState { get { throw null; } }
        public string Self { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.DateTimeOffset? TimeUpdated { get { throw null; } }
        Azure.ResourceManager.Oracle.DnsPrivateViewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.DnsPrivateViewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.DnsPrivateViewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.DnsPrivateViewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DnsPrivateViewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DnsPrivateViewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DnsPrivateViewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsPrivateViewResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsPrivateViewResource() { }
        public virtual Azure.ResourceManager.Oracle.DnsPrivateViewData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string dnsprivateviewocid) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.DnsPrivateViewResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DnsPrivateViewResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DnsPrivateZoneCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.DnsPrivateZoneResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.DnsPrivateZoneResource>, System.Collections.IEnumerable
    {
        protected DnsPrivateZoneCollection() { }
        public virtual Azure.Response<bool> Exists(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.DnsPrivateZoneResource> Get(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Oracle.DnsPrivateZoneResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Oracle.DnsPrivateZoneResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DnsPrivateZoneResource>> GetAsync(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Oracle.DnsPrivateZoneResource> GetIfExists(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Oracle.DnsPrivateZoneResource>> GetIfExistsAsync(string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Oracle.DnsPrivateZoneResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.DnsPrivateZoneResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Oracle.DnsPrivateZoneResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.DnsPrivateZoneResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DnsPrivateZoneData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.DnsPrivateZoneData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DnsPrivateZoneData>
    {
        public DnsPrivateZoneData() { }
        public bool? IsProtected { get { throw null; } }
        public string Ocid { get { throw null; } }
        public Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState? ProvisioningState { get { throw null; } }
        public string Self { get { throw null; } }
        public int? Serial { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string Version { get { throw null; } }
        public string ViewId { get { throw null; } }
        public Azure.ResourceManager.Oracle.Models.ZoneType? ZoneType { get { throw null; } }
        Azure.ResourceManager.Oracle.DnsPrivateZoneData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.DnsPrivateZoneData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.DnsPrivateZoneData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.DnsPrivateZoneData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DnsPrivateZoneData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DnsPrivateZoneData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.DnsPrivateZoneData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DnsPrivateZoneResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DnsPrivateZoneResource() { }
        public virtual Azure.ResourceManager.Oracle.DnsPrivateZoneData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string dnsprivatezonename) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.DnsPrivateZoneResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DnsPrivateZoneResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GiVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.GiVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.GiVersionResource>, System.Collections.IEnumerable
    {
        protected GiVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.GiVersionResource> Get(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Oracle.GiVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Oracle.GiVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.GiVersionResource>> GetAsync(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Oracle.GiVersionResource> GetIfExists(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Oracle.GiVersionResource>> GetIfExistsAsync(string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Oracle.GiVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.GiVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Oracle.GiVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.GiVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GiVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.GiVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.GiVersionData>
    {
        public GiVersionData() { }
        public string Version { get { throw null; } }
        Azure.ResourceManager.Oracle.GiVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.GiVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.GiVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.GiVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.GiVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.GiVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.GiVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GiVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GiVersionResource() { }
        public virtual Azure.ResourceManager.Oracle.GiVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string giversionname) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.GiVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.GiVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class OracleExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> GetCloudExadataInfrastructure(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource>> GetCloudExadataInfrastructureAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource GetCloudExadataInfrastructureResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Oracle.CloudExadataInfrastructureCollection GetCloudExadataInfrastructures(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> GetCloudExadataInfrastructures(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> GetCloudExadataInfrastructuresAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Oracle.CloudVmClusterResource> GetCloudVmCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.CloudVmClusterResource>> GetCloudVmClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Oracle.CloudVmClusterResource GetCloudVmClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Oracle.CloudVmClusterCollection GetCloudVmClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Oracle.CloudVmClusterResource> GetCloudVmClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Oracle.CloudVmClusterResource> GetCloudVmClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Oracle.DbNodeResource GetDbNodeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Oracle.DbServerResource GetDbServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Oracle.DbSystemShapeResource> GetDbSystemShape(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DbSystemShapeResource>> GetDbSystemShapeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Oracle.DbSystemShapeResource GetDbSystemShapeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Oracle.DbSystemShapeCollection GetDbSystemShapes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Oracle.DnsPrivateViewResource> GetDnsPrivateView(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DnsPrivateViewResource>> GetDnsPrivateViewAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Oracle.DnsPrivateViewResource GetDnsPrivateViewResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Oracle.DnsPrivateViewCollection GetDnsPrivateViews(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Oracle.DnsPrivateZoneResource> GetDnsPrivateZone(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DnsPrivateZoneResource>> GetDnsPrivateZoneAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Oracle.DnsPrivateZoneResource GetDnsPrivateZoneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Oracle.DnsPrivateZoneCollection GetDnsPrivateZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Oracle.GiVersionResource> GetGiVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.GiVersionResource>> GetGiVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Oracle.GiVersionResource GetGiVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Oracle.GiVersionCollection GetGiVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.Oracle.OracleSubscriptionResource GetOracleSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.Oracle.OracleSubscriptionResource GetOracleSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Oracle.VirtualNetworkAddressResource GetVirtualNetworkAddressResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class OracleSubscriptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.OracleSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.OracleSubscriptionData>
    {
        public OracleSubscriptionData() { }
        public string CloudAccountId { get { throw null; } }
        public Azure.ResourceManager.Oracle.Models.CloudAccountProvisioningState? CloudAccountState { get { throw null; } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Oracle.Models.OracleSubscriptionProvisioningState? ProvisioningState { get { throw null; } }
        public string SaasSubscriptionId { get { throw null; } }
        public string TermUnit { get { throw null; } set { } }
        Azure.ResourceManager.Oracle.OracleSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.OracleSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.OracleSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.OracleSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.OracleSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.OracleSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.OracleSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OracleSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OracleSubscriptionResource() { }
        public virtual Azure.ResourceManager.Oracle.OracleSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.OracleSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Oracle.OracleSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.OracleSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Oracle.OracleSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.OracleSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.OracleSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.Models.CloudAccountDetails> GetCloudAccountDetails(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.Models.CloudAccountDetails>> GetCloudAccountDetailsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.Models.SaasSubscriptionDetails> GetSaasSubscriptionDetails(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.Models.SaasSubscriptionDetails>> GetSaasSubscriptionDetailsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.OracleSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Oracle.Models.OracleSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.OracleSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Oracle.Models.OracleSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkAddressCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource>, System.Collections.IEnumerable
    {
        protected VirtualNetworkAddressCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualnetworkaddressname, Azure.ResourceManager.Oracle.VirtualNetworkAddressData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualnetworkaddressname, Azure.ResourceManager.Oracle.VirtualNetworkAddressData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource> Get(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource>> GetAsync(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource> GetIfExists(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource>> GetIfExistsAsync(string virtualnetworkaddressname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualNetworkAddressData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.VirtualNetworkAddressData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.VirtualNetworkAddressData>
    {
        public VirtualNetworkAddressData() { }
        public string Domain { get { throw null; } }
        public string IPAddress { get { throw null; } set { } }
        public string LifecycleDetails { get { throw null; } }
        public string Ocid { get { throw null; } }
        public Azure.ResourceManager.Oracle.Models.VirtualNetworkAddressProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? TimeAssigned { get { throw null; } }
        public string VmOcid { get { throw null; } set { } }
        Azure.ResourceManager.Oracle.VirtualNetworkAddressData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.VirtualNetworkAddressData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.VirtualNetworkAddressData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.VirtualNetworkAddressData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.VirtualNetworkAddressData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.VirtualNetworkAddressData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.VirtualNetworkAddressData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualNetworkAddressResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualNetworkAddressResource() { }
        public virtual Azure.ResourceManager.Oracle.VirtualNetworkAddressData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudvmclustername, string virtualnetworkaddressname) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Oracle.VirtualNetworkAddressData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Oracle.VirtualNetworkAddressResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Oracle.VirtualNetworkAddressData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Oracle.Mocking
{
    public partial class MockableOracleArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableOracleArmClient() { }
        public virtual Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource GetCloudExadataInfrastructureResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Oracle.CloudVmClusterResource GetCloudVmClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Oracle.DbNodeResource GetDbNodeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Oracle.DbServerResource GetDbServerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Oracle.DbSystemShapeResource GetDbSystemShapeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Oracle.DnsPrivateViewResource GetDnsPrivateViewResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Oracle.DnsPrivateZoneResource GetDnsPrivateZoneResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Oracle.GiVersionResource GetGiVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Oracle.OracleSubscriptionResource GetOracleSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Oracle.VirtualNetworkAddressResource GetVirtualNetworkAddressResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableOracleResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableOracleResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> GetCloudExadataInfrastructure(string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource>> GetCloudExadataInfrastructureAsync(string cloudexadatainfrastructurename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Oracle.CloudExadataInfrastructureCollection GetCloudExadataInfrastructures() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.CloudVmClusterResource> GetCloudVmCluster(string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.CloudVmClusterResource>> GetCloudVmClusterAsync(string cloudvmclustername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Oracle.CloudVmClusterCollection GetCloudVmClusters() { throw null; }
    }
    public partial class MockableOracleSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableOracleSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> GetCloudExadataInfrastructures(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Oracle.CloudExadataInfrastructureResource> GetCloudExadataInfrastructuresAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Oracle.CloudVmClusterResource> GetCloudVmClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Oracle.CloudVmClusterResource> GetCloudVmClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.DbSystemShapeResource> GetDbSystemShape(Azure.Core.AzureLocation location, string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DbSystemShapeResource>> GetDbSystemShapeAsync(Azure.Core.AzureLocation location, string dbsystemshapename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Oracle.DbSystemShapeCollection GetDbSystemShapes(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.DnsPrivateViewResource> GetDnsPrivateView(Azure.Core.AzureLocation location, string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DnsPrivateViewResource>> GetDnsPrivateViewAsync(Azure.Core.AzureLocation location, string dnsprivateviewocid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Oracle.DnsPrivateViewCollection GetDnsPrivateViews(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.DnsPrivateZoneResource> GetDnsPrivateZone(Azure.Core.AzureLocation location, string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.DnsPrivateZoneResource>> GetDnsPrivateZoneAsync(Azure.Core.AzureLocation location, string dnsprivatezonename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Oracle.DnsPrivateZoneCollection GetDnsPrivateZones(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Oracle.GiVersionResource> GetGiVersion(Azure.Core.AzureLocation location, string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Oracle.GiVersionResource>> GetGiVersionAsync(Azure.Core.AzureLocation location, string giversionname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Oracle.GiVersionCollection GetGiVersions(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.ResourceManager.Oracle.OracleSubscriptionResource GetOracleSubscription() { throw null; }
    }
}
namespace Azure.ResourceManager.Oracle.Models
{
    public partial class AddRemoveDbNode : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.AddRemoveDbNode>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.AddRemoveDbNode>
    {
        public AddRemoveDbNode(System.Collections.Generic.IEnumerable<string> dbServers) { }
        public System.Collections.Generic.IList<string> DbServers { get { throw null; } }
        Azure.ResourceManager.Oracle.Models.AddRemoveDbNode System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.AddRemoveDbNode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.AddRemoveDbNode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.Models.AddRemoveDbNode System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.AddRemoveDbNode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.AddRemoveDbNode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.AddRemoveDbNode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmOracleModelFactory
    {
        public static Azure.ResourceManager.Oracle.Models.CloudAccountDetails CloudAccountDetails(string cloudAccountName = null, string cloudAccountHomeRegion = null) { throw null; }
        public static Azure.ResourceManager.Oracle.CloudExadataInfrastructureData CloudExadataInfrastructureData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, string ocid = null, int? computeCount = default(int?), int? storageCount = default(int?), int? totalStorageSizeInGbs = default(int?), int? availableStorageSizeInGbs = default(int?), string timeCreated = null, string lifecycleDetails = null, Azure.ResourceManager.Oracle.Models.MaintenanceWindow maintenanceWindow = null, Azure.ResourceManager.Oracle.Models.EstimatedPatchingTime estimatedPatchingTime = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.Models.CustomerContact> customerContacts = null, Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState? provisioningState = default(Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState?), string shape = null, System.Uri ociUri = null, int? cpuCount = default(int?), int? maxCpuCount = default(int?), int? memorySizeInGbs = default(int?), int? maxMemoryInGbs = default(int?), int? dbNodeStorageSizeInGbs = default(int?), int? maxDbNodeStorageSizeInGbs = default(int?), int? dataStorageSizeInTbs = default(int?), double? maxDataStorageInTbs = default(double?), string dbServerVersion = null, string storageServerVersion = null, int? activatedStorageCount = default(int?), int? additionalStorageCount = default(int?), string displayName = null, string lastMaintenanceRunId = null, string nextMaintenanceRunId = null, string monthlyDbServerVersion = null, string monthlyStorageServerVersion = null) { throw null; }
        public static Azure.ResourceManager.Oracle.CloudVmClusterData CloudVmClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string ocid = null, long? listenerPort = default(long?), int? nodeCount = default(int?), int? storageSizeInGbs = default(int?), double? dataStorageSizeInTbs = default(double?), int? dbNodeStorageSizeInGbs = default(int?), int? memorySizeInGbs = default(int?), System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), string lifecycleDetails = null, string timeZone = null, string zoneId = null, string hostname = null, string domain = null, int? cpuCoreCount = default(int?), float? ocpuCount = default(float?), string clusterName = null, int? dataStoragePercentage = default(int?), bool? isLocalBackupEnabled = default(bool?), Azure.Core.ResourceIdentifier cloudExadataInfrastructureId = null, bool? isSparseDiskgroupEnabled = default(bool?), string systemVersion = null, System.Collections.Generic.IEnumerable<string> sshPublicKeys = null, Azure.ResourceManager.Oracle.Models.LicenseModel? licenseModel = default(Azure.ResourceManager.Oracle.Models.LicenseModel?), Azure.ResourceManager.Oracle.Models.DiskRedundancy? diskRedundancy = default(Azure.ResourceManager.Oracle.Models.DiskRedundancy?), System.Collections.Generic.IEnumerable<string> scanIPIds = null, System.Collections.Generic.IEnumerable<string> vipIds = null, string scanDnsName = null, int? scanListenerPortTcp = default(int?), int? scanListenerPortTcpSsl = default(int?), string scanDnsRecordId = null, string shape = null, Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState? provisioningState = default(Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState?), Azure.Core.ResourceIdentifier vnetId = null, string giVersion = null, System.Uri ociUri = null, Azure.Core.ResourceIdentifier subnetId = null, string backupSubnetCidr = null, Azure.ResourceManager.Oracle.Models.DataCollectionConfig dataCollectionOptions = null, string displayName = null, System.Collections.Generic.IEnumerable<string> computeNodes = null, Azure.ResourceManager.Oracle.Models.ExadataIormConfig iormConfigCache = null, string lastUpdateHistoryEntryId = null, System.Collections.Generic.IEnumerable<string> dbServers = null, string compartmentId = null, string subnetOcid = null) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.DbIormConfig DbIormConfig(string dbName = null, string flashCacheLimit = null, int? share = default(int?)) { throw null; }
        public static Azure.ResourceManager.Oracle.DbNodeData DbNodeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string ocid = null, string additionalDetails = null, string backupIPId = null, string backupVnic2Id = null, string backupVnicId = null, int? cpuCoreCount = default(int?), int? dbNodeStorageSizeInGbs = default(int?), string dbServerId = null, string dbSystemId = null, string faultDomain = null, string hostIPId = null, string hostname = null, Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState? provisioningState = default(Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState?), string lifecycleDetails = null, Azure.ResourceManager.Oracle.Models.DbNodeMaintenanceType? maintenanceType = default(Azure.ResourceManager.Oracle.Models.DbNodeMaintenanceType?), int? memorySizeInGbs = default(int?), int? softwareStorageSizeInGb = default(int?), System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), System.DateTimeOffset? timeMaintenanceWindowEnd = default(System.DateTimeOffset?), System.DateTimeOffset? timeMaintenanceWindowStart = default(System.DateTimeOffset?), string vnic2Id = null, string vnicId = null) { throw null; }
        public static Azure.ResourceManager.Oracle.DbServerData DbServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string ocid = null, string displayName = null, string compartmentId = null, string exadataInfrastructureId = null, string lifecycleDetails = null, int? cpuCoreCount = default(int?), Azure.ResourceManager.Oracle.Models.DbServerPatchingDetails dbServerPatchingDetails = null, int? maxMemoryInGbs = default(int?), int? dbNodeStorageSizeInGbs = default(int?), System.Collections.Generic.IEnumerable<string> vmClusterIds = null, System.Collections.Generic.IEnumerable<string> dbNodeIds = null, Azure.ResourceManager.Oracle.Models.DbServerProvisioningState? provisioningState = default(Azure.ResourceManager.Oracle.Models.DbServerProvisioningState?), int? maxCpuCount = default(int?), System.Collections.Generic.IEnumerable<string> autonomousVmClusterIds = null, System.Collections.Generic.IEnumerable<string> autonomousVirtualMachineIds = null, int? maxDbNodeStorageInGbs = default(int?), int? memorySizeInGbs = default(int?), string shape = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.DbServerPatchingDetails DbServerPatchingDetails(int? estimatedPatchDuration = default(int?), Azure.ResourceManager.Oracle.Models.DbServerPatchingStatus? patchingStatus = default(Azure.ResourceManager.Oracle.Models.DbServerPatchingStatus?), System.DateTimeOffset? timePatchingEnded = default(System.DateTimeOffset?), System.DateTimeOffset? timePatchingStarted = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Oracle.DbSystemShapeData DbSystemShapeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string shapeFamily = null, int? availableCoreCount = default(int?), int? minimumCoreCount = default(int?), int? runtimeMinimumCoreCount = default(int?), int? coreCountIncrement = default(int?), int? minStorageCount = default(int?), int? maxStorageCount = default(int?), double? availableDataStoragePerServerInTbs = default(double?), int? availableMemoryPerNodeInGbs = default(int?), int? availableDbNodePerNodeInGbs = default(int?), int? minCoreCountPerNode = default(int?), int? availableMemoryInGbs = default(int?), int? minMemoryPerNodeInGbs = default(int?), int? availableDbNodeStorageInGbs = default(int?), int? minDbNodeStoragePerNodeInGbs = default(int?), int? availableDataStorageInTbs = default(int?), int? minDataStorageInTbs = default(int?), int? minimumNodeCount = default(int?), int? maximumNodeCount = default(int?), int? availableCoreCountPerNode = default(int?)) { throw null; }
        public static Azure.ResourceManager.Oracle.DnsPrivateViewData DnsPrivateViewData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string ocid = null, string displayName = null, bool? isProtected = default(bool?), Azure.ResourceManager.Oracle.Models.DnsPrivateViewsProvisioningState? provisioningState = default(Azure.ResourceManager.Oracle.Models.DnsPrivateViewsProvisioningState?), string self = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), System.DateTimeOffset? timeUpdated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Oracle.DnsPrivateZoneData DnsPrivateZoneData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string ocid = null, bool? isProtected = default(bool?), Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState? provisioningState = default(Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState?), string self = null, int? serial = default(int?), string version = null, string viewId = null, Azure.ResourceManager.Oracle.Models.ZoneType? zoneType = default(Azure.ResourceManager.Oracle.Models.ZoneType?), System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.EstimatedPatchingTime EstimatedPatchingTime(int? estimatedDbServerPatchingTime = default(int?), int? estimatedNetworkSwitchesPatchingTime = default(int?), int? estimatedStorageServerPatchingTime = default(int?), int? totalEstimatedPatchingTime = default(int?)) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.ExadataIormConfig ExadataIormConfig(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Oracle.Models.DbIormConfig> dbPlans = null, string lifecycleDetails = null, Azure.ResourceManager.Oracle.Models.IormLifecycleState? provisioningState = default(Azure.ResourceManager.Oracle.Models.IormLifecycleState?), Azure.ResourceManager.Oracle.Models.Objective? objective = default(Azure.ResourceManager.Oracle.Models.Objective?)) { throw null; }
        public static Azure.ResourceManager.Oracle.GiVersionData GiVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string version = null) { throw null; }
        public static Azure.ResourceManager.Oracle.OracleSubscriptionData OracleSubscriptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Models.ArmPlan plan = null, Azure.ResourceManager.Oracle.Models.OracleSubscriptionProvisioningState? provisioningState = default(Azure.ResourceManager.Oracle.Models.OracleSubscriptionProvisioningState?), string saasSubscriptionId = null, string cloudAccountId = null, Azure.ResourceManager.Oracle.Models.CloudAccountProvisioningState? cloudAccountState = default(Azure.ResourceManager.Oracle.Models.CloudAccountProvisioningState?), string termUnit = null) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.PrivateIPAddressProperties PrivateIPAddressProperties(string displayName = null, string hostnameLabel = null, string ocid = null, string ipAddress = null, string subnetId = null) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.SaasSubscriptionDetails SaasSubscriptionDetails(string id = null, string subscriptionName = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), string offerId = null, string planId = null, string saasSubscriptionStatus = null, string publisherId = null, string purchaserEmailId = null, string purchaserTenantId = null, string termUnit = null, bool? isAutoRenew = default(bool?), bool? isFreeTrial = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Oracle.VirtualNetworkAddressData VirtualNetworkAddressData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string ipAddress = null, string vmOcid = null, string ocid = null, string domain = null, string lifecycleDetails = null, Azure.ResourceManager.Oracle.Models.VirtualNetworkAddressProvisioningState? provisioningState = default(Azure.ResourceManager.Oracle.Models.VirtualNetworkAddressProvisioningState?), System.DateTimeOffset? timeAssigned = default(System.DateTimeOffset?)) { throw null; }
    }
    public partial class CloudAccountDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.CloudAccountDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.CloudAccountDetails>
    {
        internal CloudAccountDetails() { }
        public string CloudAccountHomeRegion { get { throw null; } }
        public string CloudAccountName { get { throw null; } }
        Azure.ResourceManager.Oracle.Models.CloudAccountDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.CloudAccountDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.CloudAccountDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.Models.CloudAccountDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.CloudAccountDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.CloudAccountDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.CloudAccountDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudAccountProvisioningState : System.IEquatable<Azure.ResourceManager.Oracle.Models.CloudAccountProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudAccountProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.CloudAccountProvisioningState Available { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudAccountProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudAccountProvisioningState Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.CloudAccountProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.CloudAccountProvisioningState left, Azure.ResourceManager.Oracle.Models.CloudAccountProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.CloudAccountProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.CloudAccountProvisioningState left, Azure.ResourceManager.Oracle.Models.CloudAccountProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudExadataInfrastructurePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructurePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructurePatch>
    {
        public CloudExadataInfrastructurePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructurePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructurePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructurePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructurePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructurePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructurePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructurePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudExadataInfrastructureProvisioningState : System.IEquatable<Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudExadataInfrastructureProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState Available { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState MaintenanceInProgress { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState Terminated { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState Terminating { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState left, Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState left, Azure.ResourceManager.Oracle.Models.CloudExadataInfrastructureProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudVmClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.CloudVmClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.CloudVmClusterPatch>
    {
        public CloudVmClusterPatch() { }
        public System.Collections.Generic.IList<string> ComputeNodes { get { throw null; } }
        public int? CpuCoreCount { get { throw null; } set { } }
        public Azure.ResourceManager.Oracle.Models.DataCollectionConfig DataCollectionOptions { get { throw null; } set { } }
        public double? DataStorageSizeInTbs { get { throw null; } set { } }
        public int? DbNodeStorageSizeInGbs { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Oracle.Models.LicenseModel? LicenseModel { get { throw null; } set { } }
        public int? MemorySizeInGbs { get { throw null; } set { } }
        public float? OcpuCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SshPublicKeys { get { throw null; } }
        public int? StorageSizeInGbs { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Oracle.Models.CloudVmClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.CloudVmClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.CloudVmClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.Models.CloudVmClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.CloudVmClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.CloudVmClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.CloudVmClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudVmClusterProvisioningState : System.IEquatable<Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudVmClusterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState Available { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState MaintenanceInProgress { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState Terminated { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState Terminating { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState left, Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState left, Azure.ResourceManager.Oracle.Models.CloudVmClusterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomerContact : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.CustomerContact>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.CustomerContact>
    {
        public CustomerContact(string email) { }
        public string Email { get { throw null; } set { } }
        Azure.ResourceManager.Oracle.Models.CustomerContact System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.CustomerContact>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.CustomerContact>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.Models.CustomerContact System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.CustomerContact>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.CustomerContact>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.CustomerContact>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataCollectionConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.DataCollectionConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.DataCollectionConfig>
    {
        public DataCollectionConfig() { }
        public bool? IsDiagnosticsEventsEnabled { get { throw null; } set { } }
        public bool? IsHealthMonitoringEnabled { get { throw null; } set { } }
        public bool? IsIncidentLogsEnabled { get { throw null; } set { } }
        Azure.ResourceManager.Oracle.Models.DataCollectionConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.DataCollectionConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.DataCollectionConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.Models.DataCollectionConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.DataCollectionConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.DataCollectionConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.DataCollectionConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DayOfWeek : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.DayOfWeek>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.DayOfWeek>
    {
        public DayOfWeek(Azure.ResourceManager.Oracle.Models.DayOfWeekName name) { }
        public Azure.ResourceManager.Oracle.Models.DayOfWeekName Name { get { throw null; } set { } }
        Azure.ResourceManager.Oracle.Models.DayOfWeek System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.DayOfWeek>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.DayOfWeek>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.Models.DayOfWeek System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.DayOfWeek>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.DayOfWeek>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.DayOfWeek>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DayOfWeekName : System.IEquatable<Azure.ResourceManager.Oracle.Models.DayOfWeekName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DayOfWeekName(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.DayOfWeekName Friday { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DayOfWeekName Monday { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DayOfWeekName Saturday { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DayOfWeekName Sunday { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DayOfWeekName Thursday { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DayOfWeekName Tuesday { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DayOfWeekName Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.DayOfWeekName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.DayOfWeekName left, Azure.ResourceManager.Oracle.Models.DayOfWeekName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.DayOfWeekName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.DayOfWeekName left, Azure.ResourceManager.Oracle.Models.DayOfWeekName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DbIormConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.DbIormConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.DbIormConfig>
    {
        internal DbIormConfig() { }
        public string DbName { get { throw null; } }
        public string FlashCacheLimit { get { throw null; } }
        public int? Share { get { throw null; } }
        Azure.ResourceManager.Oracle.Models.DbIormConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.DbIormConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.DbIormConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.Models.DbIormConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.DbIormConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.DbIormConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.DbIormConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DbNodeMaintenanceType : System.IEquatable<Azure.ResourceManager.Oracle.Models.DbNodeMaintenanceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DbNodeMaintenanceType(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.DbNodeMaintenanceType VmdbRebootMigration { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.DbNodeMaintenanceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.DbNodeMaintenanceType left, Azure.ResourceManager.Oracle.Models.DbNodeMaintenanceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.DbNodeMaintenanceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.DbNodeMaintenanceType left, Azure.ResourceManager.Oracle.Models.DbNodeMaintenanceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DbNodeProvisioningState : System.IEquatable<Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DbNodeProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState Available { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState Starting { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState Stopped { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState Stopping { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState Terminated { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState Terminating { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState left, Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState left, Azure.ResourceManager.Oracle.Models.DbNodeProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DbServerPatchingDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.DbServerPatchingDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.DbServerPatchingDetails>
    {
        internal DbServerPatchingDetails() { }
        public int? EstimatedPatchDuration { get { throw null; } }
        public Azure.ResourceManager.Oracle.Models.DbServerPatchingStatus? PatchingStatus { get { throw null; } }
        public System.DateTimeOffset? TimePatchingEnded { get { throw null; } }
        public System.DateTimeOffset? TimePatchingStarted { get { throw null; } }
        Azure.ResourceManager.Oracle.Models.DbServerPatchingDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.DbServerPatchingDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.DbServerPatchingDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.Models.DbServerPatchingDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.DbServerPatchingDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.DbServerPatchingDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.DbServerPatchingDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DbServerPatchingStatus : System.IEquatable<Azure.ResourceManager.Oracle.Models.DbServerPatchingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DbServerPatchingStatus(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.DbServerPatchingStatus Complete { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbServerPatchingStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbServerPatchingStatus MaintenanceInProgress { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbServerPatchingStatus Scheduled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.DbServerPatchingStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.DbServerPatchingStatus left, Azure.ResourceManager.Oracle.Models.DbServerPatchingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.DbServerPatchingStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.DbServerPatchingStatus left, Azure.ResourceManager.Oracle.Models.DbServerPatchingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DbServerProvisioningState : System.IEquatable<Azure.ResourceManager.Oracle.Models.DbServerProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DbServerProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.DbServerProvisioningState Available { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbServerProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbServerProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbServerProvisioningState MaintenanceInProgress { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbServerProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbServerProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbServerProvisioningState Terminated { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbServerProvisioningState Terminating { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DbServerProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.DbServerProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.DbServerProvisioningState left, Azure.ResourceManager.Oracle.Models.DbServerProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.DbServerProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.DbServerProvisioningState left, Azure.ResourceManager.Oracle.Models.DbServerProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskRedundancy : System.IEquatable<Azure.ResourceManager.Oracle.Models.DiskRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.DiskRedundancy High { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DiskRedundancy Normal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.DiskRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.DiskRedundancy left, Azure.ResourceManager.Oracle.Models.DiskRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.DiskRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.DiskRedundancy left, Azure.ResourceManager.Oracle.Models.DiskRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsPrivateViewsProvisioningState : System.IEquatable<Azure.ResourceManager.Oracle.Models.DnsPrivateViewsProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsPrivateViewsProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.DnsPrivateViewsProvisioningState Active { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DnsPrivateViewsProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DnsPrivateViewsProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DnsPrivateViewsProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DnsPrivateViewsProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DnsPrivateViewsProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DnsPrivateViewsProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.DnsPrivateViewsProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.DnsPrivateViewsProvisioningState left, Azure.ResourceManager.Oracle.Models.DnsPrivateViewsProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.DnsPrivateViewsProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.DnsPrivateViewsProvisioningState left, Azure.ResourceManager.Oracle.Models.DnsPrivateViewsProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsPrivateZonesProvisioningState : System.IEquatable<Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsPrivateZonesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState Active { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState left, Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState left, Azure.ResourceManager.Oracle.Models.DnsPrivateZonesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EstimatedPatchingTime : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.EstimatedPatchingTime>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.EstimatedPatchingTime>
    {
        internal EstimatedPatchingTime() { }
        public int? EstimatedDbServerPatchingTime { get { throw null; } }
        public int? EstimatedNetworkSwitchesPatchingTime { get { throw null; } }
        public int? EstimatedStorageServerPatchingTime { get { throw null; } }
        public int? TotalEstimatedPatchingTime { get { throw null; } }
        Azure.ResourceManager.Oracle.Models.EstimatedPatchingTime System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.EstimatedPatchingTime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.EstimatedPatchingTime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.Models.EstimatedPatchingTime System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.EstimatedPatchingTime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.EstimatedPatchingTime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.EstimatedPatchingTime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExadataIormConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.ExadataIormConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.ExadataIormConfig>
    {
        internal ExadataIormConfig() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Oracle.Models.DbIormConfig> DbPlans { get { throw null; } }
        public string LifecycleDetails { get { throw null; } }
        public Azure.ResourceManager.Oracle.Models.Objective? Objective { get { throw null; } }
        public Azure.ResourceManager.Oracle.Models.IormLifecycleState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Oracle.Models.ExadataIormConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.ExadataIormConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.ExadataIormConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.Models.ExadataIormConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.ExadataIormConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.ExadataIormConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.ExadataIormConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IormLifecycleState : System.IEquatable<Azure.ResourceManager.Oracle.Models.IormLifecycleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IormLifecycleState(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.IormLifecycleState BootStrapping { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.IormLifecycleState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.IormLifecycleState Enabled { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.IormLifecycleState Failed { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.IormLifecycleState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.IormLifecycleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.IormLifecycleState left, Azure.ResourceManager.Oracle.Models.IormLifecycleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.IormLifecycleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.IormLifecycleState left, Azure.ResourceManager.Oracle.Models.IormLifecycleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LicenseModel : System.IEquatable<Azure.ResourceManager.Oracle.Models.LicenseModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseModel(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.LicenseModel BringYourOwnLicense { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.LicenseModel LicenseIncluded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.LicenseModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.LicenseModel left, Azure.ResourceManager.Oracle.Models.LicenseModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.LicenseModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.LicenseModel left, Azure.ResourceManager.Oracle.Models.LicenseModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MaintenanceWindow : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.MaintenanceWindow>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.MaintenanceWindow>
    {
        public MaintenanceWindow() { }
        public int? CustomActionTimeoutInMins { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Oracle.Models.DayOfWeek> DaysOfWeek { get { throw null; } }
        public System.Collections.Generic.IList<int> HoursOfDay { get { throw null; } }
        public bool? IsCustomActionTimeoutEnabled { get { throw null; } set { } }
        public bool? IsMonthlyPatchingEnabled { get { throw null; } set { } }
        public int? LeadTimeInWeeks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Oracle.Models.Month> Months { get { throw null; } }
        public Azure.ResourceManager.Oracle.Models.PatchingMode? PatchingMode { get { throw null; } set { } }
        public Azure.ResourceManager.Oracle.Models.Preference? Preference { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> WeeksOfMonth { get { throw null; } }
        Azure.ResourceManager.Oracle.Models.MaintenanceWindow System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.MaintenanceWindow>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.MaintenanceWindow>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.Models.MaintenanceWindow System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.MaintenanceWindow>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.MaintenanceWindow>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.MaintenanceWindow>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Month : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.Month>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.Month>
    {
        public Month(Azure.ResourceManager.Oracle.Models.MonthName name) { }
        public Azure.ResourceManager.Oracle.Models.MonthName Name { get { throw null; } set { } }
        Azure.ResourceManager.Oracle.Models.Month System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.Month>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.Month>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.Models.Month System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.Month>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.Month>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.Month>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonthName : System.IEquatable<Azure.ResourceManager.Oracle.Models.MonthName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonthName(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.MonthName April { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.MonthName August { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.MonthName December { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.MonthName February { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.MonthName January { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.MonthName July { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.MonthName June { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.MonthName March { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.MonthName May { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.MonthName November { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.MonthName October { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.MonthName September { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.MonthName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.MonthName left, Azure.ResourceManager.Oracle.Models.MonthName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.MonthName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.MonthName left, Azure.ResourceManager.Oracle.Models.MonthName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Objective : System.IEquatable<Azure.ResourceManager.Oracle.Models.Objective>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Objective(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.Objective Auto { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.Objective Balanced { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.Objective Basic { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.Objective HighThroughput { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.Objective LowLatency { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.Objective other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.Objective left, Azure.ResourceManager.Oracle.Models.Objective right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.Objective (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.Objective left, Azure.ResourceManager.Oracle.Models.Objective right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OracleSubscriptionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.OracleSubscriptionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.OracleSubscriptionPatch>
    {
        public OracleSubscriptionPatch() { }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        Azure.ResourceManager.Oracle.Models.OracleSubscriptionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.OracleSubscriptionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.OracleSubscriptionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.Models.OracleSubscriptionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.OracleSubscriptionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.OracleSubscriptionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.OracleSubscriptionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OracleSubscriptionProvisioningState : System.IEquatable<Azure.ResourceManager.Oracle.Models.OracleSubscriptionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OracleSubscriptionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.OracleSubscriptionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.OracleSubscriptionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.OracleSubscriptionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.OracleSubscriptionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.OracleSubscriptionProvisioningState left, Azure.ResourceManager.Oracle.Models.OracleSubscriptionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.OracleSubscriptionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.OracleSubscriptionProvisioningState left, Azure.ResourceManager.Oracle.Models.OracleSubscriptionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatchingMode : System.IEquatable<Azure.ResourceManager.Oracle.Models.PatchingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatchingMode(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.PatchingMode NonRolling { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.PatchingMode Rolling { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.PatchingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.PatchingMode left, Azure.ResourceManager.Oracle.Models.PatchingMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.PatchingMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.PatchingMode left, Azure.ResourceManager.Oracle.Models.PatchingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Preference : System.IEquatable<Azure.ResourceManager.Oracle.Models.Preference>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Preference(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.Preference CustomPreference { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.Preference NoPreference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.Preference other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.Preference left, Azure.ResourceManager.Oracle.Models.Preference right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.Preference (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.Preference left, Azure.ResourceManager.Oracle.Models.Preference right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateIPAddressesFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.PrivateIPAddressesFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.PrivateIPAddressesFilter>
    {
        public PrivateIPAddressesFilter(string subnetId, string vnicId) { }
        public string SubnetId { get { throw null; } }
        public string VnicId { get { throw null; } }
        Azure.ResourceManager.Oracle.Models.PrivateIPAddressesFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.PrivateIPAddressesFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.PrivateIPAddressesFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.Models.PrivateIPAddressesFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.PrivateIPAddressesFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.PrivateIPAddressesFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.PrivateIPAddressesFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateIPAddressProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.PrivateIPAddressProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.PrivateIPAddressProperties>
    {
        internal PrivateIPAddressProperties() { }
        public string DisplayName { get { throw null; } }
        public string HostnameLabel { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public string Ocid { get { throw null; } }
        public string SubnetId { get { throw null; } }
        Azure.ResourceManager.Oracle.Models.PrivateIPAddressProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.PrivateIPAddressProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.PrivateIPAddressProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.Models.PrivateIPAddressProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.PrivateIPAddressProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.PrivateIPAddressProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.PrivateIPAddressProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaasSubscriptionDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.SaasSubscriptionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.SaasSubscriptionDetails>
    {
        internal SaasSubscriptionDetails() { }
        public string Id { get { throw null; } }
        public bool? IsAutoRenew { get { throw null; } }
        public bool? IsFreeTrial { get { throw null; } }
        public string OfferId { get { throw null; } }
        public string PlanId { get { throw null; } }
        public string PublisherId { get { throw null; } }
        public string PurchaserEmailId { get { throw null; } }
        public string PurchaserTenantId { get { throw null; } }
        public string SaasSubscriptionStatus { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string TermUnit { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        Azure.ResourceManager.Oracle.Models.SaasSubscriptionDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.SaasSubscriptionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Oracle.Models.SaasSubscriptionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Oracle.Models.SaasSubscriptionDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.SaasSubscriptionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.SaasSubscriptionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Oracle.Models.SaasSubscriptionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualNetworkAddressProvisioningState : System.IEquatable<Azure.ResourceManager.Oracle.Models.VirtualNetworkAddressProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualNetworkAddressProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.VirtualNetworkAddressProvisioningState Available { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.VirtualNetworkAddressProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.VirtualNetworkAddressProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.VirtualNetworkAddressProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.VirtualNetworkAddressProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.VirtualNetworkAddressProvisioningState Terminated { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.VirtualNetworkAddressProvisioningState Terminating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.VirtualNetworkAddressProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.VirtualNetworkAddressProvisioningState left, Azure.ResourceManager.Oracle.Models.VirtualNetworkAddressProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.VirtualNetworkAddressProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.VirtualNetworkAddressProvisioningState left, Azure.ResourceManager.Oracle.Models.VirtualNetworkAddressProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZoneType : System.IEquatable<Azure.ResourceManager.Oracle.Models.ZoneType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZoneType(string value) { throw null; }
        public static Azure.ResourceManager.Oracle.Models.ZoneType Primary { get { throw null; } }
        public static Azure.ResourceManager.Oracle.Models.ZoneType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Oracle.Models.ZoneType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Oracle.Models.ZoneType left, Azure.ResourceManager.Oracle.Models.ZoneType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Oracle.Models.ZoneType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Oracle.Models.ZoneType left, Azure.ResourceManager.Oracle.Models.ZoneType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
