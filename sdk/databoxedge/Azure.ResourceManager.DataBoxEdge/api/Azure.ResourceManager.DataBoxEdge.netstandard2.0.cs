namespace Azure.ResourceManager.DataBoxEdge
{
    public partial class BandwidthScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>, System.Collections.IEnumerable
    {
        protected BandwidthScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.BandwidthScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.BandwidthScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BandwidthScheduleData : Azure.ResourceManager.Models.ResourceData
    {
        public BandwidthScheduleData(System.TimeSpan startOn, System.TimeSpan stopOn, int rateInMbps, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDayOfWeek> days) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDayOfWeek> Days { get { throw null; } }
        public int RateInMbps { get { throw null; } set { } }
        public System.TimeSpan StartOn { get { throw null; } set { } }
        public System.TimeSpan StopOn { get { throw null; } set { } }
    }
    public partial class BandwidthScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BandwidthScheduleResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.BandwidthScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.BandwidthScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.BandwidthScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxEdgeAlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeAlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeAlertResource>, System.Collections.IEnumerable
    {
        protected DataBoxEdgeAlertCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeAlertResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeAlertResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeAlertResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeAlertResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeAlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeAlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeAlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeAlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataBoxEdgeAlertData : Azure.ResourceManager.Models.ResourceData
    {
        public DataBoxEdgeAlertData() { }
        public string AlertType { get { throw null; } }
        public System.DateTimeOffset? AppearedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> DetailedInformation { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAlertErrorDetails ErrorDetails { get { throw null; } }
        public string Recommendation { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAlertSeverity? Severity { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class DataBoxEdgeAlertResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataBoxEdgeAlertResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeAlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeAlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeAlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxEdgeDeviceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>, System.Collections.IEnumerable
    {
        protected DataBoxEdgeDeviceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deviceName, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deviceName, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> Get(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>> GetAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataBoxEdgeDeviceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DataBoxEdgeDeviceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleType> ConfiguredRoleTypes { get { throw null; } }
        public string Culture { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus? DataBoxEdgeDeviceStatus { get { throw null; } }
        public string Description { get { throw null; } }
        public string DeviceHcsVersion { get { throw null; } }
        public long? DeviceLocalCapacity { get { throw null; } }
        public string DeviceModel { get { throw null; } }
        public string DeviceSoftwareVersion { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceType? DeviceType { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeProfileSubscription EdgeSubscription { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind? Kind { get { throw null; } }
        public string ModelDescription { get { throw null; } }
        public int? NodeCount { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataResidencyType? ResidencyType { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeResourceMoveDetails ResourceMoveDetails { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSku Sku { get { throw null; } set { } }
        public string TimeZone { get { throw null; } }
    }
    public partial class DataBoxEdgeDeviceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataBoxEdgeDeviceResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CheckResourceCreationFeasibility(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.Models.DeviceCapacityRequestContent content, string capacityName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CheckResourceCreationFeasibilityAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.Models.DeviceCapacityRequestContent content, string capacityName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdateSecuritySettings(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSecuritySettings securitySettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateSecuritySettingsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSecuritySettings securitySettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DownloadUpdates(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DownloadUpdatesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.GenerateCertResult> GenerateCertificate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.GenerateCertResult>> GenerateCertificateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> GetBandwidthSchedule(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>> GetBandwidthScheduleAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.BandwidthScheduleCollection GetBandwidthSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeAlertResource> GetDataBoxEdgeAlert(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeAlertResource>> GetDataBoxEdgeAlertAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeAlertCollection GetDataBoxEdgeAlerts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeJobResource> GetDataBoxEdgeJob(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeJobResource>> GetDataBoxEdgeJobAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeJobCollection GetDataBoxEdgeJobs() { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeOrderResource GetDataBoxEdgeOrder() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource> GetDataBoxEdgeRole(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource>> GetDataBoxEdgeRoleAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleCollection GetDataBoxEdgeRoles() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource> GetDataBoxEdgeShare(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource>> GetDataBoxEdgeShareAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareCollection GetDataBoxEdgeShares() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource> GetDataBoxEdgeStorageAccount(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource>> GetDataBoxEdgeStorageAccountAsync(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource> GetDataBoxEdgeStorageAccountCredential(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource>> GetDataBoxEdgeStorageAccountCredentialAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialCollection GetDataBoxEdgeStorageAccountCredentials() { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCollection GetDataBoxEdgeStorageAccounts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource> GetDataBoxEdgeTrigger(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource>> GetDataBoxEdgeTriggerAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerCollection GetDataBoxEdgeTriggers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource> GetDataBoxEdgeUser(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource>> GetDataBoxEdgeUserAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserCollection GetDataBoxEdgeUsers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceCapacityInfo> GetDeviceCapacityInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceCapacityInfo>> GetDeviceCapacityInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingResource GetDiagnosticProactiveLogCollectionSetting() { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingResource GetDiagnosticRemoteSupportSetting() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNode> GetEdgeNodes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNode> GetEdgeNodesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceExtendedInfo> GetExtendedInformation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceExtendedInfo>> GetExtendedInformationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceNetworkSettings> GetNetworkSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceNetworkSettings>> GetNetworkSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceUpdateSummary> GetUpdateSummary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceUpdateSummary>> GetUpdateSummaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation InstallUpdates(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InstallUpdatesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ScanForUpdates(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ScanForUpdatesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerSupportPackage(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.Models.TriggerSupportPackageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerSupportPackageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.Models.TriggerSupportPackageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> Update(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>> UpdateAsync(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceExtendedInfo> UpdateExtendedInformation(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceExtendedInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceExtendedInfo>> UpdateExtendedInformationAsync(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceExtendedInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.UploadCertificateResponse> UploadCertificate(Azure.ResourceManager.DataBoxEdge.Models.UploadCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.UploadCertificateResponse>> UploadCertificateAsync(Azure.ResourceManager.DataBoxEdge.Models.UploadCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DataBoxEdgeExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.DataBoxEdge.Models.AvailableDataBoxEdgeSku> GetAvailableSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.Models.AvailableDataBoxEdgeSku> GetAvailableSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource GetBandwidthScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DataBoxEdgeAlertResource GetDataBoxEdgeAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> GetDataBoxEdgeDevice(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>> GetDataBoxEdgeDeviceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource GetDataBoxEdgeDeviceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceCollection GetDataBoxEdgeDevices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> GetDataBoxEdgeDevices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> GetDataBoxEdgeDevicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DataBoxEdgeJobResource GetDataBoxEdgeJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DataBoxEdgeOrderResource GetDataBoxEdgeOrderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource GetDataBoxEdgeRoleAddonResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource GetDataBoxEdgeRoleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource GetDataBoxEdgeShareResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource GetDataBoxEdgeStorageAccountCredentialResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource GetDataBoxEdgeStorageAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource GetDataBoxEdgeStorageContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource GetDataBoxEdgeTriggerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource GetDataBoxEdgeUserResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingResource GetDiagnosticProactiveLogCollectionSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingResource GetDiagnosticRemoteSupportSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationResource GetMonitoringMetricConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DataBoxEdgeJobCollection : Azure.ResourceManager.ArmCollection
    {
        protected DataBoxEdgeJobCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeJobResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeJobResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxEdgeJobData : Azure.ResourceManager.Models.ResourceData
    {
        internal DataBoxEdgeJobData() { }
        public Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage? CurrentStage { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.UpdateDownloadProgress DownloadProgress { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobErrorDetails Error { get { throw null; } }
        public string ErrorManifestFile { get { throw null; } }
        public string Folder { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.UpdateInstallProgress InstallProgress { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobType? JobType { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public Azure.Core.ResourceIdentifier RefreshedEntityId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobStatus? Status { get { throw null; } }
        public int? TotalRefreshErrors { get { throw null; } }
    }
    public partial class DataBoxEdgeJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataBoxEdgeJobResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxEdgeOrderData : Azure.ResourceManager.Models.ResourceData
    {
        public DataBoxEdgeOrderData() { }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeContactDetails ContactInformation { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderStatus CurrentStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeTrackingInfo> DeliveryTrackingInfo { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderStatus> OrderHistory { get { throw null; } }
        public string OrderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeTrackingInfo> ReturnTrackingInfo { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShipmentType? ShipmentType { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShippingAddress ShippingAddress { get { throw null; } set { } }
    }
    public partial class DataBoxEdgeOrderResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataBoxEdgeOrderResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeOrderData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeOrderResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeOrderData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeOrderResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeOrderData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeOrderResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeOrderResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataCenterAccessCode> GetDataCenterAccessCode(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataCenterAccessCode>> GetDataCenterAccessCodeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxEdgeRoleAddonCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource>, System.Collections.IEnumerable
    {
        protected DataBoxEdgeRoleAddonCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string addonName, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string addonName, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource> Get(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource>> GetAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataBoxEdgeRoleAddonData : Azure.ResourceManager.Models.ResourceData
    {
        public DataBoxEdgeRoleAddonData() { }
    }
    public partial class DataBoxEdgeRoleAddonResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataBoxEdgeRoleAddonResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string roleName, string addonName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxEdgeRoleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource>, System.Collections.IEnumerable
    {
        protected DataBoxEdgeRoleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataBoxEdgeRoleData : Azure.ResourceManager.Models.ResourceData
    {
        public DataBoxEdgeRoleData() { }
    }
    public partial class DataBoxEdgeRoleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataBoxEdgeRoleResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource> GetDataBoxEdgeRoleAddon(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonResource>> GetDataBoxEdgeRoleAddonAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonCollection GetDataBoxEdgeRoleAddons() { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationResource GetMonitoringMetricConfiguration() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxEdgeShareCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource>, System.Collections.IEnumerable
    {
        protected DataBoxEdgeShareCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataBoxEdgeShareData : Azure.ResourceManager.Models.ResourceData
    {
        public DataBoxEdgeShareData(Azure.ResourceManager.DataBoxEdge.Models.ShareStatus shareStatus, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShareMonitoringStatus monitoringStatus, Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol accessProtocol) { }
        public Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol AccessProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerInfo AzureContainerInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.ClientAccessRight> ClientAccessRights { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataPolicy? DataPolicy { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShareMonitoringStatus MonitoringStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRefreshDetails RefreshDetails { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMountPointMap> ShareMappings { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.ShareStatus ShareStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.UserAccessRight> UserAccessRights { get { throw null; } }
    }
    public partial class DataBoxEdgeShareResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataBoxEdgeShareResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Refresh(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RefreshAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxEdgeStorageAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource>, System.Collections.IEnumerable
    {
        protected DataBoxEdgeStorageAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageAccountName, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageAccountName, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource> Get(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource>> GetAsync(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataBoxEdgeStorageAccountCredentialCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource>, System.Collections.IEnumerable
    {
        protected DataBoxEdgeStorageAccountCredentialCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataBoxEdgeStorageAccountCredentialData : Azure.ResourceManager.Models.ResourceData
    {
        public DataBoxEdgeStorageAccountCredentialData(string alias, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountSslStatus sslStatus, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountType accountType) { }
        public Azure.ResourceManager.DataBoxEdge.Models.AsymmetricEncryptedSecret AccountKey { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountType AccountType { get { throw null; } set { } }
        public string Alias { get { throw null; } set { } }
        public string BlobDomainName { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountSslStatus SslStatus { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class DataBoxEdgeStorageAccountCredentialResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataBoxEdgeStorageAccountCredentialResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountCredentialData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxEdgeStorageAccountData : Azure.ResourceManager.Models.ResourceData
    {
        public DataBoxEdgeStorageAccountData(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataPolicy dataPolicy) { }
        public string BlobEndpoint { get { throw null; } }
        public int? ContainerCount { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataPolicy DataPolicy { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountCredentialId { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountStatus? StorageAccountStatus { get { throw null; } set { } }
    }
    public partial class DataBoxEdgeStorageAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataBoxEdgeStorageAccountResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string storageAccountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource> GetDataBoxEdgeStorageContainer(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource>> GetDataBoxEdgeStorageContainerAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerCollection GetDataBoxEdgeStorageContainers() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxEdgeStorageContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource>, System.Collections.IEnumerable
    {
        protected DataBoxEdgeStorageContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string containerName, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string containerName, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource> Get(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource>> GetAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataBoxEdgeStorageContainerData : Azure.ResourceManager.Models.ResourceData
    {
        public DataBoxEdgeStorageContainerData(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerDataFormat dataFormat) { }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerStatus? ContainerStatus { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerDataFormat DataFormat { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRefreshDetails RefreshDetails { get { throw null; } }
    }
    public partial class DataBoxEdgeStorageContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataBoxEdgeStorageContainerResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string storageAccountName, string containerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Refresh(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RefreshAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeStorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxEdgeTriggerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource>, System.Collections.IEnumerable
    {
        protected DataBoxEdgeTriggerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataBoxEdgeTriggerData : Azure.ResourceManager.Models.ResourceData
    {
        public DataBoxEdgeTriggerData() { }
    }
    public partial class DataBoxEdgeTriggerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataBoxEdgeTriggerResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxEdgeUserCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource>, System.Collections.IEnumerable
    {
        protected DataBoxEdgeUserCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataBoxEdgeUserData : Azure.ResourceManager.Models.ResourceData
    {
        public DataBoxEdgeUserData(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUserType userType) { }
        public Azure.ResourceManager.DataBoxEdge.Models.AsymmetricEncryptedSecret EncryptedPassword { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.ShareAccessRight> ShareAccessRights { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUserType UserType { get { throw null; } set { } }
    }
    public partial class DataBoxEdgeUserResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataBoxEdgeUserResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiagnosticProactiveLogCollectionSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public DiagnosticProactiveLogCollectionSettingData(Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent userConsent) { }
        public Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent UserConsent { get { throw null; } set { } }
    }
    public partial class DiagnosticProactiveLogCollectionSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiagnosticProactiveLogCollectionSettingResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiagnosticRemoteSupportSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public DiagnosticRemoteSupportSettingData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteSupportSettings> RemoteSupportSettingsList { get { throw null; } }
    }
    public partial class DiagnosticRemoteSupportSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiagnosticRemoteSupportSettingResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MonitoringMetricConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public MonitoringMetricConfigurationData(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMetricConfiguration> metricConfigurations) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMetricConfiguration> MetricConfigurations { get { throw null; } }
    }
    public partial class MonitoringMetricConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitoringMetricConfigurationResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string roleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public partial class AsymmetricEncryptedSecret
    {
        public AsymmetricEncryptedSecret(string value, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeEncryptionAlgorithm encryptionAlgorithm) { }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeEncryptionAlgorithm EncryptionAlgorithm { get { throw null; } set { } }
        public string EncryptionCertThumbprint { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class AvailableDataBoxEdgeSku
    {
        internal AvailableDataBoxEdgeSku() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuAvailability? Availability { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuCost> Costs { get { throw null; } }
        public string Family { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName? Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShipmentType> ShipmentTypes { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuSignupOption? SignupOption { get { throw null; } }
        public string Size { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier? Tier { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuVersion? Version { get { throw null; } }
    }
    public partial class ClientAccessRight
    {
        public ClientAccessRight(string client, Azure.ResourceManager.DataBoxEdge.Models.EdgeClientPermissionType accessPermission) { }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeClientPermissionType AccessPermission { get { throw null; } set { } }
        public string Client { get { throw null; } set { } }
    }
    public partial class CloudEdgeManagementRole : Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleData
    {
        public CloudEdgeManagementRole() { }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeProfileSubscription EdgeSubscription { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleStatus? LocalManagementStatus { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleStatus? RoleStatus { get { throw null; } set { } }
    }
    public partial class CniConfig
    {
        internal CniConfig() { }
        public string CniConfigType { get { throw null; } }
        public string PodSubnet { get { throw null; } }
        public string ServiceSubnet { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class DataBoxEdgeAlertErrorDetails
    {
        internal DataBoxEdgeAlertErrorDetails() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public int? Occurrences { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeAlertSeverity : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAlertSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeAlertSeverity(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAlertSeverity Critical { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAlertSeverity Informational { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAlertSeverity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAlertSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAlertSeverity left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAlertSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAlertSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAlertSeverity left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAlertSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeAuthenticationType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAuthenticationType AzureActiveDirectory { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAuthenticationType Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAuthenticationType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAuthenticationType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeContactDetails
    {
        public DataBoxEdgeContactDetails(string contactPerson, string companyName, string phone, System.Collections.Generic.IEnumerable<string> emailList) { }
        public string CompanyName { get { throw null; } set { } }
        public string ContactPerson { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailList { get { throw null; } }
        public string Phone { get { throw null; } set { } }
    }
    public partial class DataBoxEdgeDataCenterAccessCode
    {
        internal DataBoxEdgeDataCenterAccessCode() { }
        public string AuthCode { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeDataPolicy : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeDataPolicy(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataPolicy Cloud { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataPolicy Local { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataPolicy left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataPolicy left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeDataResidencyType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataResidencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeDataResidencyType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataResidencyType GeoZoneReplication { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataResidencyType ZoneReplication { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataResidencyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataResidencyType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataResidencyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataResidencyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataResidencyType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDataResidencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeDayOfWeek : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDayOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeDayOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDayOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDayOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDayOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDayOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDayOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDayOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDayOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDayOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDayOfWeek left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDayOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDayOfWeek left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeDeviceCapacityInfo : Azure.ResourceManager.Models.ResourceData
    {
        public DataBoxEdgeDeviceCapacityInfo() { }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeClusterCapacityViewInfo ClusterComputeCapacityInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeClusterStorageViewInfo ClusterStorageCapacityInfo { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataBoxEdge.Models.HostCapacity> NodeCapacityInfos { get { throw null; } }
        public System.DateTimeOffset? TimeStamp { get { throw null; } set { } }
    }
    public partial class DataBoxEdgeDeviceExtendedInfo : Azure.ResourceManager.Models.ResourceData
    {
        public DataBoxEdgeDeviceExtendedInfo() { }
        public string ChannelIntegrityKeyName { get { throw null; } set { } }
        public string ChannelIntegrityKeyVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ClientSecretStoreId { get { throw null; } set { } }
        public System.Uri ClientSecretStoreUri { get { throw null; } set { } }
        public string CloudWitnessContainerName { get { throw null; } }
        public string CloudWitnessStorageAccountName { get { throw null; } }
        public string CloudWitnessStorageEndpoint { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeClusterWitnessType? ClusterWitnessType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceSecret> DeviceSecrets { get { throw null; } }
        public string EncryptionKey { get { throw null; } set { } }
        public string EncryptionKeyThumbprint { get { throw null; } set { } }
        public string FileShareWitnessLocation { get { throw null; } }
        public string FileShareWitnessUsername { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeKeyVaultSyncStatus? KeyVaultSyncStatus { get { throw null; } set { } }
        public string ResourceKey { get { throw null; } }
    }
    public partial class DataBoxEdgeDeviceExtendedInfoPatch
    {
        public DataBoxEdgeDeviceExtendedInfoPatch() { }
        public string ChannelIntegrityKeyName { get { throw null; } set { } }
        public string ChannelIntegrityKeyVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ClientSecretStoreId { get { throw null; } set { } }
        public System.Uri ClientSecretStoreUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeKeyVaultSyncStatus? SyncStatus { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeDeviceKind : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeDeviceKind(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind AzureDataBoxGateway { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind AzureModularDataCentre { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind AzureStackEdge { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind AzureStackHub { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeDeviceNetworkSettings : Azure.ResourceManager.Models.ResourceData
    {
        public DataBoxEdgeDeviceNetworkSettings() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapter> NetworkAdapters { get { throw null; } }
    }
    public partial class DataBoxEdgeDevicePatch
    {
        public DataBoxEdgeDevicePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubscriptionId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataBoxEdgeDeviceSecret
    {
        internal DataBoxEdgeDeviceSecret() { }
        public Azure.ResourceManager.DataBoxEdge.Models.AsymmetricEncryptedSecret EncryptedSecret { get { throw null; } }
        public string KeyVaultId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeDeviceStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeDeviceStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus Maintenance { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus NeedsAttention { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus Online { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus PartiallyDisconnected { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus ReadyToSetup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeDeviceType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeDeviceType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceType DataBoxEdgeDevice { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeDeviceUpdateSummary : Azure.ResourceManager.Models.ResourceData
    {
        public DataBoxEdgeDeviceUpdateSummary() { }
        public System.DateTimeOffset? DeviceLastScannedOn { get { throw null; } set { } }
        public string DeviceVersionNumber { get { throw null; } set { } }
        public string FriendlyDeviceVersionName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier InProgressDownloadJobId { get { throw null; } }
        public System.DateTimeOffset? InProgressDownloadJobStartedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier InProgressInstallJobId { get { throw null; } }
        public System.DateTimeOffset? InProgressInstallJobStartedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier LastCompletedDownloadJobId { get { throw null; } }
        public System.DateTimeOffset? LastCompletedDownloadJobOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier LastCompletedInstallJobId { get { throw null; } }
        public System.DateTimeOffset? LastCompletedInstallJobOn { get { throw null; } }
        public System.DateTimeOffset? LastCompletedScanJobOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobStatus? LastDownloadJobStatus { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobStatus? LastInstallJobStatus { get { throw null; } }
        public System.DateTimeOffset? LastSuccessfulInstallJobOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastSuccessfulScanJobOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateOperation? OngoingUpdateOperation { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior? RebootBehavior { get { throw null; } }
        public int? TotalNumberOfUpdatesAvailable { get { throw null; } }
        public int? TotalNumberOfUpdatesPendingDownload { get { throw null; } }
        public int? TotalNumberOfUpdatesPendingInstall { get { throw null; } }
        public int? TotalTimeInMinutes { get { throw null; } }
        public double? TotalUpdateSizeInBytes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateDetails> Updates { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> UpdateTitles { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeDownloadPhase : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDownloadPhase>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeDownloadPhase(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDownloadPhase Downloading { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDownloadPhase Initializing { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDownloadPhase Unknown { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDownloadPhase Verifying { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDownloadPhase other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDownloadPhase left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDownloadPhase right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDownloadPhase (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDownloadPhase left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDownloadPhase right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeEncryptionAlgorithm : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeEncryptionAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeEncryptionAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeEncryptionAlgorithm Aes256 { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeEncryptionAlgorithm None { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeEncryptionAlgorithm RsaesPkcs1V1_5 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeEncryptionAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeEncryptionAlgorithm left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeEncryptionAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeEncryptionAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeEncryptionAlgorithm left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeEncryptionAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeEtcdInfo
    {
        internal DataBoxEdgeEtcdInfo() { }
        public string EtcdInfoType { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class DataBoxEdgeIPv4Config
    {
        internal DataBoxEdgeIPv4Config() { }
        public string Gateway { get { throw null; } }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public string Subnet { get { throw null; } }
    }
    public partial class DataBoxEdgeIPv6Config
    {
        internal DataBoxEdgeIPv6Config() { }
        public string Gateway { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public int? PrefixLength { get { throw null; } }
    }
    public partial class DataBoxEdgeJobErrorDetails
    {
        internal DataBoxEdgeJobErrorDetails() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobErrorItem> ErrorDetails { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class DataBoxEdgeJobErrorItem
    {
        internal DataBoxEdgeJobErrorItem() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Recommendations { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeJobStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeJobStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobStatus Paused { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobStatus Running { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeJobType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeJobType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobType Backup { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobType DownloadUpdates { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobType InstallUpdates { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobType Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobType RefreshContainer { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobType RefreshShare { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobType Restore { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobType ScanForUpdates { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobType TriggerSupportPackage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeJobType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeLoadBalancerConfig
    {
        internal DataBoxEdgeLoadBalancerConfig() { }
        public string LoadBalancerConfigType { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class DataBoxEdgeMetricConfiguration
    {
        public DataBoxEdgeMetricConfiguration(Azure.Core.ResourceIdentifier resourceId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMetricCounterSet> counterSets) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMetricCounterSet> CounterSets { get { throw null; } }
        public string MdmAccount { get { throw null; } set { } }
        public string MetricNameSpace { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class DataBoxEdgeMetricCounter
    {
        public DataBoxEdgeMetricCounter(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMetricDimension> AdditionalDimensions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMetricDimension> DimensionFilter { get { throw null; } }
        public string Instance { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class DataBoxEdgeMetricCounterSet
    {
        public DataBoxEdgeMetricCounterSet(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMetricCounter> counters) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMetricCounter> Counters { get { throw null; } }
    }
    public partial class DataBoxEdgeMetricDimension
    {
        public DataBoxEdgeMetricDimension(string sourceType, string sourceName) { }
        public string SourceName { get { throw null; } set { } }
        public string SourceType { get { throw null; } set { } }
    }
    public partial class DataBoxEdgeMountPointMap
    {
        public DataBoxEdgeMountPointMap(Azure.Core.ResourceIdentifier shareId) { }
        public string MountPoint { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMountType? MountType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleId { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleType? RoleType { get { throw null; } }
        public Azure.Core.ResourceIdentifier ShareId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeMountType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeMountType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMountType HostPath { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMountType Volume { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMountType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMountType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeNetworkAdapter
    {
        internal DataBoxEdgeNetworkAdapter() { }
        public string AdapterId { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterPosition AdapterPosition { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterDhcpStatus? DhcpStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DnsServers { get { throw null; } }
        public int? Index { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeIPv4Config IPv4Configuration { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeIPv6Config IPv6Configuration { get { throw null; } }
        public string IPv6LinkLocalAddress { get { throw null; } }
        public string Label { get { throw null; } }
        public long? LinkSpeed { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string NetworkAdapterName { get { throw null; } }
        public System.Guid? NodeId { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterRdmaStatus? RdmaStatus { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeNetworkAdapterDhcpStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterDhcpStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeNetworkAdapterDhcpStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterDhcpStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterDhcpStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterDhcpStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterDhcpStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterDhcpStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterDhcpStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterDhcpStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterDhcpStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeNetworkAdapterPosition
    {
        internal DataBoxEdgeNetworkAdapterPosition() { }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkGroup? NetworkGroup { get { throw null; } }
        public int? Port { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeNetworkAdapterRdmaStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterRdmaStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeNetworkAdapterRdmaStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterRdmaStatus Capable { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterRdmaStatus Incapable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterRdmaStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterRdmaStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterRdmaStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterRdmaStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterRdmaStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterRdmaStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeNetworkAdapterStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeNetworkAdapterStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterStatus Active { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterStatus Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkAdapterStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeNetworkGroup : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkGroup>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeNetworkGroup(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkGroup None { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkGroup NonRdma { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkGroup Rdma { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkGroup other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkGroup left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkGroup right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkGroup (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkGroup left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNetworkGroup right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeNode : Azure.ResourceManager.Models.ResourceData
    {
        public DataBoxEdgeNode() { }
        public string NodeChassisSerialNumber { get { throw null; } }
        public string NodeDisplayName { get { throw null; } }
        public string NodeFriendlySoftwareVersion { get { throw null; } }
        public string NodeHcsVersion { get { throw null; } }
        public System.Guid? NodeInstanceId { get { throw null; } }
        public string NodeSerialNumber { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNodeStatus? NodeStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeNodeStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNodeStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeNodeStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNodeStatus Down { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNodeStatus Rebooting { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNodeStatus ShuttingDown { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNodeStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNodeStatus Up { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNodeStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNodeStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNodeStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNodeStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNodeStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeNodeStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeOrderState : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeOrderState(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState Arriving { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState AwaitingDrop { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState AwaitingFulfillment { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState AwaitingPickup { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState AwaitingPreparation { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState AwaitingReturnShipment { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState AwaitingShipment { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState CollectedAtMicrosoft { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState Declined { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState Delivered { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState LostDevice { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState PickupCompleted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState ReplacementRequested { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState ReturnInitiated { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState Shipped { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState ShippedBack { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState Untracked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeOrderStatus
    {
        internal DataBoxEdgeOrderStatus() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AdditionalOrderDetails { get { throw null; } }
        public string Comments { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOrderState Status { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeTrackingInfo TrackingInformation { get { throw null; } }
        public System.DateTimeOffset? UpdateOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeOSPlatformType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOSPlatformType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeOSPlatformType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOSPlatformType Linux { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOSPlatformType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOSPlatformType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOSPlatformType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOSPlatformType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOSPlatformType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOSPlatformType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOSPlatformType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeRefreshDetails
    {
        public DataBoxEdgeRefreshDetails() { }
        public string ErrorManifestFile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier InProgressRefreshJobId { get { throw null; } set { } }
        public System.DateTimeOffset? LastCompletedRefreshJobTimeInUtc { get { throw null; } set { } }
        public string LastJob { get { throw null; } set { } }
    }
    public partial class DataBoxEdgeResourceMoveDetails
    {
        internal DataBoxEdgeResourceMoveDetails() { }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeResourceMoveStatus? OperationInProgress { get { throw null; } }
        public System.DateTimeOffset? OperationInProgressLockTimeoutInUtc { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeResourceMoveStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeResourceMoveStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeResourceMoveStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeResourceMoveStatus None { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeResourceMoveStatus ResourceMoveFailed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeResourceMoveStatus ResourceMoveInProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeResourceMoveStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeResourceMoveStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeResourceMoveStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeResourceMoveStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeResourceMoveStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeResourceMoveStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeRoleAddonProvisioningState : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleAddonProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeRoleAddonProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleAddonProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleAddonProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleAddonProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleAddonProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleAddonProvisioningState Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleAddonProvisioningState Reconfiguring { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleAddonProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleAddonProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleAddonProvisioningState left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleAddonProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleAddonProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleAddonProvisioningState left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleAddonProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeRoleSinkInfo
    {
        public DataBoxEdgeRoleSinkInfo(Azure.Core.ResourceIdentifier roleId) { }
        public Azure.Core.ResourceIdentifier RoleId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeRoleStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeRoleStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeRoleType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeRoleType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleType Asa { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleType CloudEdgeManagement { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleType Cognitive { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleType Functions { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleType IoT { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleType Kubernetes { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleType Mec { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeSecuritySettings : Azure.ResourceManager.Models.ResourceData
    {
        public DataBoxEdgeSecuritySettings(Azure.ResourceManager.DataBoxEdge.Models.AsymmetricEncryptedSecret deviceAdminPassword) { }
        public Azure.ResourceManager.DataBoxEdge.Models.AsymmetricEncryptedSecret DeviceAdminPassword { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeShareMonitoringStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShareMonitoringStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeShareMonitoringStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShareMonitoringStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShareMonitoringStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShareMonitoringStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShareMonitoringStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShareMonitoringStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShareMonitoringStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShareMonitoringStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShareMonitoringStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeShipmentType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShipmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeShipmentType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShipmentType NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShipmentType SelfPickup { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShipmentType ShippedToCustomer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShipmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShipmentType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShipmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShipmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShipmentType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeShipmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeShippingAddress
    {
        public DataBoxEdgeShippingAddress(string country) { }
        public string AddressLine1 { get { throw null; } set { } }
        public string AddressLine2 { get { throw null; } set { } }
        public string AddressLine3 { get { throw null; } set { } }
        public string City { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
    }
    public partial class DataBoxEdgeSku
    {
        public DataBoxEdgeSku() { }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName? Name { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeSkuAvailability : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuAvailability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeSkuAvailability(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuAvailability Available { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuAvailability Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuAvailability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuAvailability left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuAvailability right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuAvailability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuAvailability left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuAvailability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeSkuCapability
    {
        internal DataBoxEdgeSkuCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class DataBoxEdgeSkuCost
    {
        internal DataBoxEdgeSkuCost() { }
        public string ExtendedUnit { get { throw null; } }
        public string MeterId { get { throw null; } }
        public long? Quantity { get { throw null; } }
    }
    public partial class DataBoxEdgeSkuLocationInfo
    {
        internal DataBoxEdgeSkuLocationInfo() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Sites { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeSkuName : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeSkuName(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName Edge { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EdgeMRMini { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EdgeMRTcp { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EdgePBase { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EdgePHigh { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EdgePRBase { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EdgePRBaseUps { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EP2_128Gpu1Mx1W { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EP2_128_1T4Mx1W { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EP2_256Gpu2Mx1 { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EP2_256_2T4W { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EP2_64_1VpuW { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EP2_64_Mx1W { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName Gateway { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName Gpu { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName Management { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName RcaLarge { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName RcaSmall { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName Rdc { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName TcaLarge { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName TcaSmall { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName Tdc { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName Tea1Node { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName Tea1NodeHeater { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName Tea1NodeUps { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName Tea1NodeUpsHeater { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName Tea4NodeHeater { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName Tea4NodeUpsHeater { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName Tma { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeSkuSignupOption : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuSignupOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeSkuSignupOption(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuSignupOption Available { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuSignupOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuSignupOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuSignupOption left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuSignupOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuSignupOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuSignupOption left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuSignupOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeSkuTier : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeSkuVersion : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeSkuVersion(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuVersion Preview { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuVersion Stable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuVersion left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuVersion left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeStorageAccountSslStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountSslStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeStorageAccountSslStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountSslStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountSslStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountSslStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountSslStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountSslStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountSslStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountSslStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountSslStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeStorageAccountStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeStorageAccountStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountStatus NeedsAttention { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountStatus OK { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeStorageAccountType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountType BlobStorage { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountType GeneralPurposeStorage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeStorageContainerDataFormat : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerDataFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeStorageContainerDataFormat(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerDataFormat AzureFile { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerDataFormat BlockBlob { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerDataFormat PageBlob { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerDataFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerDataFormat left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerDataFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerDataFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerDataFormat left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerDataFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeStorageContainerInfo
    {
        public DataBoxEdgeStorageContainerInfo(Azure.Core.ResourceIdentifier storageAccountCredentialId, string containerName, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerDataFormat dataFormat) { }
        public string ContainerName { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerDataFormat DataFormat { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountCredentialId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeStorageContainerStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeStorageContainerStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerStatus NeedsAttention { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerStatus OK { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeStorageContainerStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeSubscriptionState : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSubscriptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeSubscriptionState(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSubscriptionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSubscriptionState Registered { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSubscriptionState Suspended { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSubscriptionState Unregistered { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSubscriptionState Warned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSubscriptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSubscriptionState left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSubscriptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSubscriptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSubscriptionState left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSubscriptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeTrackingInfo
    {
        internal DataBoxEdgeTrackingInfo() { }
        public string CarrierName { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public string TrackingId { get { throw null; } }
        public System.Uri TrackingUri { get { throw null; } }
    }
    public partial class DataBoxEdgeUpdateDetails
    {
        internal DataBoxEdgeUpdateDetails() { }
        public int? EstimatedInstallTimeInMins { get { throw null; } }
        public string FriendlyVersionNumber { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact? InstallationImpact { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior? RebootBehavior { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateStatus? Status { get { throw null; } }
        public string TargetVersion { get { throw null; } }
        public double? UpdateSizeInBytes { get { throw null; } }
        public string UpdateTitle { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateType? UpdateType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeUpdateOperation : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeUpdateOperation(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateOperation Download { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateOperation Install { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateOperation None { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateOperation Scan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateOperation left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateOperation left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeUpdateStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeUpdateStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateStatus DownloadCompleted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateStatus DownloadPending { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateStatus DownloadStarted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateStatus InstallCompleted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateStatus InstallStarted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeUpdateType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeUpdateType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateType Firmware { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateType Kubernetes { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateType Software { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUpdateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeUserType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUserType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeUserType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUserType Arm { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUserType LocalManagement { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUserType Share { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUserType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUserType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUserType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUserType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUserType left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeUserType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeVmMemory
    {
        public DataBoxEdgeVmMemory() { }
        public long? CurrentMemoryUsageInMB { get { throw null; } set { } }
        public long? StartupMemoryInMB { get { throw null; } set { } }
    }
    public partial class DeviceCapacityRequestContent
    {
        public DeviceCapacityRequestContent(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> vmPlacementQuery) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> VmPlacementQuery { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.VmPlacementRequestResult> VmPlacementResults { get { throw null; } }
    }
    public partial class EdgeArcAddon : Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonData
    {
        public EdgeArcAddon(string subscriptionId, string resourceGroupName, string resourceName, Azure.Core.AzureLocation resourceLocation) { }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOSPlatformType? HostPlatform { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType? HostPlatformType { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleAddonProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGroupName { get { throw null; } set { } }
        public Azure.Core.AzureLocation ResourceLocation { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeClientPermissionType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.EdgeClientPermissionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeClientPermissionType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeClientPermissionType NoAccess { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeClientPermissionType ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeClientPermissionType ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.EdgeClientPermissionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.EdgeClientPermissionType left, Azure.ResourceManager.DataBoxEdge.Models.EdgeClientPermissionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.EdgeClientPermissionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.EdgeClientPermissionType left, Azure.ResourceManager.DataBoxEdge.Models.EdgeClientPermissionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeClusterCapacityViewInfo
    {
        public EdgeClusterCapacityViewInfo() { }
        public string Fqdn { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeClusterGpuCapacity GpuCapacity { get { throw null; } set { } }
        public System.DateTimeOffset? LastRefreshedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeClusterMemoryCapacity MemoryCapacity { get { throw null; } set { } }
        public long? TotalProvisionedNonHpnCores { get { throw null; } set { } }
    }
    public partial class EdgeClusterGpuCapacity
    {
        public EdgeClusterGpuCapacity() { }
        public int? GpuFreeUnitsCount { get { throw null; } set { } }
        public int? GpuReservedForFailoverUnitsCount { get { throw null; } set { } }
        public int? GpuTotalUnitsCount { get { throw null; } set { } }
        public string GpuType { get { throw null; } set { } }
        public int? GpuUsedUnitsCount { get { throw null; } set { } }
    }
    public partial class EdgeClusterMemoryCapacity
    {
        public EdgeClusterMemoryCapacity() { }
        public double? ClusterFailoverMemoryInMB { get { throw null; } set { } }
        public double? ClusterFragmentationMemoryInMB { get { throw null; } set { } }
        public double? ClusterFreeMemoryInMB { get { throw null; } set { } }
        public double? ClusterHyperVReserveMemoryMb { get { throw null; } set { } }
        public double? ClusterInfraVmMemoryInMB { get { throw null; } set { } }
        public double? ClusterMemoryUsedByVmsInMB { get { throw null; } set { } }
        public double? ClusterNonFailoverVmInMB { get { throw null; } set { } }
        public double? ClusterTotalMemoryInMB { get { throw null; } set { } }
        public double? ClusterUsedMemoryInMB { get { throw null; } set { } }
    }
    public partial class EdgeClusterStorageViewInfo
    {
        public EdgeClusterStorageViewInfo() { }
        public double? ClusterFreeStorageInMB { get { throw null; } set { } }
        public double? ClusterTotalStorageInMB { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeClusterWitnessType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.EdgeClusterWitnessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeClusterWitnessType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeClusterWitnessType Cloud { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeClusterWitnessType FileShare { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeClusterWitnessType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.EdgeClusterWitnessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.EdgeClusterWitnessType left, Azure.ResourceManager.DataBoxEdge.Models.EdgeClusterWitnessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.EdgeClusterWitnessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.EdgeClusterWitnessType left, Azure.ResourceManager.DataBoxEdge.Models.EdgeClusterWitnessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeComputeResourceInfo
    {
        public EdgeComputeResourceInfo(int processorCount, long memoryInGB) { }
        public long MemoryInGB { get { throw null; } set { } }
        public int ProcessorCount { get { throw null; } set { } }
    }
    public partial class EdgeFileEventTrigger : Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerData
    {
        public EdgeFileEventTrigger(Azure.ResourceManager.DataBoxEdge.Models.EdgeFileSourceInfo sourceInfo, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleSinkInfo sinkInfo) { }
        public string CustomContextTag { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SinkInfoRoleId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceInfoShareId { get { throw null; } set { } }
    }
    public partial class EdgeFileSourceInfo
    {
        public EdgeFileSourceInfo(Azure.Core.ResourceIdentifier shareId) { }
        public Azure.Core.ResourceIdentifier ShareId { get { throw null; } set { } }
    }
    public partial class EdgeIotAddon : Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleAddonData
    {
        public EdgeIotAddon(Azure.ResourceManager.DataBoxEdge.Models.EdgeIotDeviceInfo iotDeviceDetails, Azure.ResourceManager.DataBoxEdge.Models.EdgeIotDeviceInfo iotEdgeDeviceDetails) { }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOSPlatformType? HostPlatform { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType? HostPlatformType { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeIotDeviceInfo IotDeviceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeIotDeviceInfo IotEdgeDeviceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleAddonProvisioningState? ProvisioningState { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class EdgeIotDeviceInfo
    {
        public EdgeIotDeviceInfo(string deviceId, string iotHostHub) { }
        public string DeviceId { get { throw null; } set { } }
        public string IotHostHub { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IotHostHubId { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.AsymmetricEncryptedSecret SymmetricKeyConnectionString { get { throw null; } set { } }
    }
    public partial class EdgeIotRole : Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleData
    {
        public EdgeIotRole() { }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeComputeResourceInfo ComputeResource { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOSPlatformType? HostPlatform { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType? HostPlatformType { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeIotDeviceInfo IotDeviceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.IotEdgeAgentInfo IotEdgeAgentInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeIotDeviceInfo IotEdgeDeviceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleStatus? RoleStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMountPointMap> ShareMappings { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeKeyVaultSyncStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.EdgeKeyVaultSyncStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeKeyVaultSyncStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeKeyVaultSyncStatus KeyVaultNotConfigured { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeKeyVaultSyncStatus KeyVaultNotSynced { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeKeyVaultSyncStatus KeyVaultSynced { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeKeyVaultSyncStatus KeyVaultSyncFailed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeKeyVaultSyncStatus KeyVaultSyncing { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeKeyVaultSyncStatus KeyVaultSyncPending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.EdgeKeyVaultSyncStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.EdgeKeyVaultSyncStatus left, Azure.ResourceManager.DataBoxEdge.Models.EdgeKeyVaultSyncStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.EdgeKeyVaultSyncStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.EdgeKeyVaultSyncStatus left, Azure.ResourceManager.DataBoxEdge.Models.EdgeKeyVaultSyncStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeKubernetesClusterInfo
    {
        public EdgeKubernetesClusterInfo(string version) { }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeEtcdInfo EtcdInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesNodeInfo> Nodes { get { throw null; } }
        public string Version { get { throw null; } set { } }
    }
    public partial class EdgeKubernetesIPConfiguration
    {
        internal EdgeKubernetesIPConfiguration() { }
        public string IPAddress { get { throw null; } }
        public string Port { get { throw null; } }
    }
    public partial class EdgeKubernetesNodeInfo
    {
        internal EdgeKubernetesNodeInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesIPConfiguration> IPConfiguration { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesNodeType? NodeType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeKubernetesNodeType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesNodeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeKubernetesNodeType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesNodeType Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesNodeType Master { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesNodeType Worker { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesNodeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesNodeType left, Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesNodeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesNodeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesNodeType left, Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesNodeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeKubernetesRole : Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleData
    {
        public EdgeKubernetesRole() { }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeOSPlatformType? HostPlatform { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType? HostPlatformType { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesClusterInfo KubernetesClusterInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesRoleResources KubernetesRoleResources { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleStatus? RoleStatus { get { throw null; } set { } }
    }
    public partial class EdgeKubernetesRoleCompute
    {
        public EdgeKubernetesRoleCompute(string vmProfile) { }
        public long? MemoryInBytes { get { throw null; } }
        public int? ProcessorCount { get { throw null; } }
        public string VmProfile { get { throw null; } set { } }
    }
    public partial class EdgeKubernetesRoleNetwork
    {
        internal EdgeKubernetesRoleNetwork() { }
        public Azure.ResourceManager.DataBoxEdge.Models.CniConfig CniConfig { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeLoadBalancerConfig LoadBalancerConfig { get { throw null; } }
    }
    public partial class EdgeKubernetesRoleResources
    {
        public EdgeKubernetesRoleResources(Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesRoleCompute compute) { }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesRoleCompute Compute { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesRoleNetwork Network { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesRoleStorage Storage { get { throw null; } set { } }
    }
    public partial class EdgeKubernetesRoleStorage
    {
        public EdgeKubernetesRoleStorage() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeMountPointMap> Endpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesRoleStorageClassInfo> StorageClasses { get { throw null; } }
    }
    public partial class EdgeKubernetesRoleStorageClassInfo
    {
        internal EdgeKubernetesRoleStorageClassInfo() { }
        public string KubernetesRoleStorageClassInfoType { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus? PosixCompliant { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeKubernetesState : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeKubernetesState(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesState Created { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesState Creating { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesState Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesState Reconfiguring { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesState left, Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesState left, Azure.ResourceManager.DataBoxEdge.Models.EdgeKubernetesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeProfileSubscription
    {
        internal EdgeProfileSubscription() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string LocationPlacementId { get { throw null; } }
        public string QuotaId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.SubscriptionRegisteredFeatures> RegisteredFeatures { get { throw null; } }
        public string RegistrationDate { get { throw null; } }
        public System.Guid? RegistrationId { get { throw null; } }
        public string SerializedDetails { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSubscriptionState? State { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeRemoteApplicationAccessLevel : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationAccessLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeRemoteApplicationAccessLevel(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationAccessLevel FullAccess { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationAccessLevel None { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationAccessLevel ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationAccessLevel ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationAccessLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationAccessLevel left, Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationAccessLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationAccessLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationAccessLevel left, Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationAccessLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeRemoteApplicationType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeRemoteApplicationType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationType AllApplications { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationType LocalUI { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationType Powershell { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationType Wac { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationType left, Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationType left, Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeRemoteSupportSettings
    {
        public EdgeRemoteSupportSettings() { }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationAccessLevel? AccessLevel { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeRemoteApplicationType? RemoteApplicationType { get { throw null; } set { } }
    }
    public partial class GenerateCertResult
    {
        internal GenerateCertResult() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public string PrivateKey { get { throw null; } }
        public string PublicKey { get { throw null; } }
    }
    public partial class HostCapacity
    {
        public HostCapacity() { }
        public int? AvailableGpuCount { get { throw null; } set { } }
        public long? EffectiveAvailableMemoryInMBOnHost { get { throw null; } set { } }
        public string GpuType { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.NumaNodeInfo> NumaNodesData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeVmMemory> VmUsedMemory { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostPlatformType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostPlatformType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType KubernetesCluster { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType LinuxVm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType left, Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType left, Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageRepositoryCredential
    {
        public ImageRepositoryCredential(System.Uri imageRepositoryUri, string userName) { }
        public System.Uri ImageRepositoryUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.AsymmetricEncryptedSecret Password { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InstallationImpact : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstallationImpact(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact DeviceRebooted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact KubernetesWorkloadsDown { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact left, Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact left, Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InstallRebootBehavior : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstallRebootBehavior(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior NeverReboots { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior RequestReboot { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior RequiresReboot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior left, Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior left, Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotEdgeAgentInfo
    {
        public IotEdgeAgentInfo(string imageName, string tag) { }
        public string ImageName { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.ImageRepositoryCredential ImageRepository { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
    }
    public partial class MecRole : Azure.ResourceManager.DataBoxEdge.DataBoxEdgeRoleData
    {
        public MecRole() { }
        public Azure.ResourceManager.DataBoxEdge.Models.AsymmetricEncryptedSecret ConnectionString { get { throw null; } set { } }
        public string ControllerEndpoint { get { throw null; } set { } }
        public string ResourceUniqueId { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleStatus? RoleStatus { get { throw null; } set { } }
    }
    public partial class NumaNodeInfo
    {
        public NumaNodeInfo() { }
        public long? EffectiveAvailableMemoryInMB { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> FreeVCpuIndexesForHpn { get { throw null; } }
        public int? LogicalCoreCountPerCore { get { throw null; } set { } }
        public int? NumaNodeIndex { get { throw null; } set { } }
        public long? TotalMemoryInMB { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> VCpuIndexesForHpn { get { throw null; } }
        public System.Collections.Generic.IList<int> VCpuIndexesForRoot { get { throw null; } }
    }
    public partial class PeriodicTimerEventTrigger : Azure.ResourceManager.DataBoxEdge.DataBoxEdgeTriggerData
    {
        public PeriodicTimerEventTrigger(Azure.ResourceManager.DataBoxEdge.Models.PeriodicTimerSourceInfo sourceInfo, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeRoleSinkInfo sinkInfo) { }
        public string CustomContextTag { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SinkInfoRoleId { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.PeriodicTimerSourceInfo SourceInfo { get { throw null; } set { } }
    }
    public partial class PeriodicTimerSourceInfo
    {
        public PeriodicTimerSourceInfo(System.DateTimeOffset startOn, string schedule) { }
        public string Schedule { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        public string Topic { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PosixComplianceStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PosixComplianceStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus Enabled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus left, Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus left, Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProactiveDiagnosticsConsent : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProactiveDiagnosticsConsent(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent left, Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent left, Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareAccessProtocol : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareAccessProtocol(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol Nfs { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol Smb { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol left, Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol left, Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ShareAccessRight
    {
        internal ShareAccessRight() { }
        public Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType AccessType { get { throw null; } }
        public Azure.Core.ResourceIdentifier ShareId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareAccessType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareAccessType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType Change { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType Custom { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType Read { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType left, Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType left, Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.ShareStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareStatus NeedsAttention { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareStatus OK { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.ShareStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.ShareStatus left, Azure.ResourceManager.DataBoxEdge.Models.ShareStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.ShareStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.ShareStatus left, Azure.ResourceManager.DataBoxEdge.Models.ShareStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubscriptionRegisteredFeatures
    {
        internal SubscriptionRegisteredFeatures() { }
        public string Name { get { throw null; } }
        public string State { get { throw null; } }
    }
    public partial class TriggerSupportPackageContent : Azure.ResourceManager.Models.ResourceData
    {
        public TriggerSupportPackageContent() { }
        public string Include { get { throw null; } set { } }
        public System.DateTimeOffset? MaximumTimeStamp { get { throw null; } set { } }
        public System.DateTimeOffset? MinimumTimeStamp { get { throw null; } set { } }
    }
    public partial class UpdateDownloadProgress
    {
        internal UpdateDownloadProgress() { }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDownloadPhase? DownloadPhase { get { throw null; } }
        public int? NumberOfUpdatesDownloaded { get { throw null; } }
        public int? NumberOfUpdatesToDownload { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public double? TotalBytesDownloaded { get { throw null; } }
        public double? TotalBytesToDownload { get { throw null; } }
    }
    public partial class UpdateInstallProgress
    {
        internal UpdateInstallProgress() { }
        public int? NumberOfUpdatesInstalled { get { throw null; } }
        public int? NumberOfUpdatesToInstall { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateOperationStage : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateOperationStage(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage DownloadComplete { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage DownloadFailed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage DownloadStarted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage Failure { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage Initial { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage InstallComplete { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage InstallFailed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage InstallStarted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage RebootInitiated { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage RescanComplete { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage RescanFailed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage RescanStarted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage ScanComplete { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage ScanFailed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage ScanStarted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage Success { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage left, Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage left, Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UploadCertificateContent
    {
        public UploadCertificateContent(string certificate) { }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string Certificate { get { throw null; } }
    }
    public partial class UploadCertificateResponse
    {
        internal UploadCertificateResponse() { }
        public string AadAudience { get { throw null; } }
        public string AadAuthority { get { throw null; } }
        public System.Guid? AadTenantId { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeAuthenticationType? AuthType { get { throw null; } }
        public string AzureManagementEndpointAudience { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public System.Guid? ServicePrincipalClientId { get { throw null; } }
        public System.Guid? ServicePrincipalObjectId { get { throw null; } }
    }
    public partial class UserAccessRight
    {
        public UserAccessRight(Azure.Core.ResourceIdentifier userId, Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType accessType) { }
        public Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType AccessType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserId { get { throw null; } set { } }
    }
    public partial class VmPlacementRequestResult
    {
        public VmPlacementRequestResult() { }
        public bool? IsFeasible { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public string MessageCode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VmSize { get { throw null; } }
    }
}
