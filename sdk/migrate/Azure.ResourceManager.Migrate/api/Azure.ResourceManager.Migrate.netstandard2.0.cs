namespace Azure.ResourceManager.Migrate
{
    public partial class AssessedMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.AssessedMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.AssessedMachineResource>, System.Collections.IEnumerable
    {
        protected AssessedMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedMachineResource> Get(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.AssessedMachineResource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.AssessedMachineResource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedMachineResource>> GetAsync(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.AssessedMachineResource> GetIfExists(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.AssessedMachineResource>> GetIfExistsAsync(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.AssessedMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.AssessedMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.AssessedMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.AssessedMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssessedMachineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.AssessedMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedMachineData>
    {
        public AssessedMachineData() { }
        public Azure.ResourceManager.Migrate.Models.MachineBootType? BootType { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.CostComponent> CostComponents { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterMachineArmId { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterManagementServerArmId { get { throw null; } }
        public string DatacenterManagementServerName { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.AssessedDisk> Disks { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.MigrateError> Errors { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ProcessorInfo HostProcessor { get { throw null; } set { } }
        public double? MegabytesOfMemory { get { throw null; } }
        public double? MegabytesOfMemoryForRecommendedSize { get { throw null; } }
        public double? MonthlyBandwidthCost { get { throw null; } }
        public double? MonthlyComputeCostForRecommendedSize { get { throw null; } }
        public double? MonthlyPremiumStorageCost { get { throw null; } }
        public double? MonthlyStandardSsdStorageCost { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public double? MonthlyUltraStorageCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.AssessedNetworkAdapter> NetworkAdapters { get { throw null; } }
        public int? NumberOfCores { get { throw null; } }
        public int? NumberOfCoresForRecommendedSize { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture? OperatingSystemArchitecture { get { throw null; } }
        public string OperatingSystemName { get { throw null; } }
        public string OperatingSystemType { get { throw null; } }
        public string OperatingSystemVersion { get { throw null; } }
        public double? PercentageCoresUtilization { get { throw null; } }
        public double? PercentageMemoryUtilization { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ProductSupportStatus ProductSupportStatus { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureVmSize? RecommendedSize { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessedMachineType? TypePropertiesType { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Migrate.AssessedMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.AssessedMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.AssessedMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.AssessedMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssessedMachineResource() { }
        public virtual Azure.ResourceManager.Migrate.AssessedMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string assessedMachineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AssessedSqlDatabaseV2Collection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource>, System.Collections.IEnumerable
    {
        protected AssessedSqlDatabaseV2Collection() { }
        public virtual Azure.Response<bool> Exists(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource> Get(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource>> GetAsync(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource> GetIfExists(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource>> GetIfExistsAsync(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssessedSqlDatabaseV2Data : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Data>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Data>
    {
        public AssessedSqlDatabaseV2Data() { }
        public Azure.Core.ResourceIdentifier AssessedSqlInstanceArmId { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails AzureSqlDBSuitabilityDetails { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails AzureSqlMISuitabilityDetails { get { throw null; } }
        public double? BufferCacheSizeInMB { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.CompatibilityLevel? CompatibilityLevel { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public double? DatabaseSizeInMB { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public bool? IsDatabaseHighlyAvailable { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.SqlAvailabilityGroupDataOverview LinkedAvailabilityGroupOverview { get { throw null; } }
        public Azure.Core.ResourceIdentifier MachineArmId { get { throw null; } }
        public string MachineName { get { throw null; } }
        public double? MegabytesPerSecondOfRead { get { throw null; } }
        public double? MegabytesPerSecondOfWrite { get { throw null; } }
        public double? NumberOfReadOperationsPerSecond { get { throw null; } }
        public double? NumberOfWriteOperationsPerSecond { get { throw null; } }
        public double? PercentageCoresUtilization { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ProductSupportStatus ProductSupportStatus { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateTargetType? RecommendedAzureSqlTargetType { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.RecommendedSuitability? RecommendedSuitability { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } }
        public Azure.Core.ResourceIdentifier SqlDatabaseSdsArmId { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Data System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Data>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Data>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Data System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Data>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Data>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Data>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlDatabaseV2Resource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssessedSqlDatabaseV2Resource() { }
        public virtual Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Data Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string assessedSqlDatabaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AssessedSqlInstanceV2Collection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource>, System.Collections.IEnumerable
    {
        protected AssessedSqlInstanceV2Collection() { }
        public virtual Azure.Response<bool> Exists(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource> Get(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource>> GetAsync(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource> GetIfExists(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource>> GetIfExistsAsync(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssessedSqlInstanceV2Data : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Data>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Data>
    {
        public AssessedSqlInstanceV2Data() { }
        public Azure.ResourceManager.Migrate.Models.SqlAvailabilityReplicaSummary AvailabilityReplicaSummary { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails AzureSqlDBSuitabilityDetails { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails AzureSqlMISuitabilityDetails { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.SqlAssessmentV2IaasSuitabilityDetails AzureSqlVmSuitabilityDetails { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDatabaseSummary DatabaseSummary { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.SqlFciMetadata FciMetadata { get { throw null; } }
        public bool? HasScanOccurred { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public bool? IsClustered { get { throw null; } }
        public bool? IsHighAvailabilityEnabled { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDiskDetails> LogicalDisks { get { throw null; } }
        public Azure.Core.ResourceIdentifier MachineArmId { get { throw null; } }
        public string MachineName { get { throw null; } }
        public double? MemoryInUseInMB { get { throw null; } }
        public int? NumberOfCoresAllocated { get { throw null; } }
        public double? PercentageCoresUtilization { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ProductSupportStatus ProductSupportStatus { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateTargetType? RecommendedAzureSqlTargetType { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.RecommendedSuitability? RecommendedSuitability { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoning> RecommendedTargetReasonings { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } }
        public string SqlEdition { get { throw null; } }
        public Azure.Core.ResourceIdentifier SqlInstanceSdsArmId { get { throw null; } }
        public string SqlVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceStorageDetails> StorageTypeBasedDetails { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Data System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Data>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Data>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Data System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Data>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Data>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Data>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlInstanceV2Resource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssessedSqlInstanceV2Resource() { }
        public virtual Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Data Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string assessedSqlInstanceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AssessedSqlMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.AssessedSqlMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.AssessedSqlMachineResource>, System.Collections.IEnumerable
    {
        protected AssessedSqlMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlMachineResource> Get(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.AssessedSqlMachineResource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.AssessedSqlMachineResource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlMachineResource>> GetAsync(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.AssessedSqlMachineResource> GetIfExists(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.AssessedSqlMachineResource>> GetIfExistsAsync(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.AssessedSqlMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.AssessedSqlMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.AssessedSqlMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.AssessedSqlMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssessedSqlMachineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.AssessedSqlMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedSqlMachineData>
    {
        public AssessedSqlMachineData() { }
        public string BiosGuid { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MachineBootType? BootType { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.CostComponent> CostComponents { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterMachineArmId { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterManagementServerArmId { get { throw null; } }
        public string DatacenterManagementServerName { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.AssessedDataDisk> Disks { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public double? MegabytesOfMemory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.SqlMigrationGuideline> MigrationGuidelines { get { throw null; } }
        public double? MonthlyBandwidthCost { get { throw null; } }
        public double? MonthlyComputeCost { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.SqlAssessedNetworkAdapter> NetworkAdapters { get { throw null; } }
        public int? NumberOfCores { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture? OperatingSystemArchitecture { get { throw null; } }
        public string OperatingSystemName { get { throw null; } }
        public string OperatingSystemType { get { throw null; } }
        public string OperatingSystemVersion { get { throw null; } }
        public double? PercentageCoresUtilization { get { throw null; } }
        public double? PercentageMemoryUtilization { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ProductSupportStatus ProductSupportStatus { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureVmFamily? RecommendedVmFamily { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureVmSize? RecommendedVmSize { get { throw null; } }
        public double? RecommendedVmSizeMegabytesOfMemory { get { throw null; } }
        public int? RecommendedVmSizeNumberOfCores { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? SecuritySuitability { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceSummary> SqlInstances { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessedMachineType? TypePropertiesType { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Migrate.AssessedSqlMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.AssessedSqlMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.AssessedSqlMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.AssessedSqlMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedSqlMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedSqlMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedSqlMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssessedSqlMachineResource() { }
        public virtual Azure.ResourceManager.Migrate.AssessedSqlMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string assessedSqlMachineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AssessedSqlRecommendedEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource>, System.Collections.IEnumerable
    {
        protected AssessedSqlRecommendedEntityCollection() { }
        public virtual Azure.Response<bool> Exists(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource> Get(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource>> GetAsync(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource> GetIfExists(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource>> GetIfExistsAsync(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssessedSqlRecommendedEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityData>
    {
        public AssessedSqlRecommendedEntityData() { }
        public Azure.Core.ResourceIdentifier AssessedSqlEntityArmId { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails AzureSqlDBSuitabilityDetails { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails AzureSqlMISuitabilityDetails { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.SqlAssessmentV2IaasSuitabilityDetails AzureSqlVmSuitabilityDetails { get { throw null; } }
        public int? DBCount { get { throw null; } }
        public int? DiscoveredDBCount { get { throw null; } }
        public bool? HasScanOccurred { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public bool? IsClustered { get { throw null; } }
        public bool? IsHighAvailabilityEnabled { get { throw null; } }
        public string MachineName { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ProductSupportStatus ProductSupportStatus { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateTargetType? RecommendedAzureSqlTargetType { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.RecommendedSuitability? RecommendedSuitability { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } }
        public string SqlEdition { get { throw null; } }
        public string SqlVersion { get { throw null; } }
        Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlRecommendedEntityResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssessedSqlRecommendedEntityResource() { }
        public virtual Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string recommendedAssessedEntityName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateAssessmentResource>, System.Collections.IEnumerable
    {
        protected MigrateAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migrate.MigrateAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migrate.MigrateAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentResource> Get(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateAssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateAssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentResource>> GetAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateAssessmentResource> GetIfExists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateAssessmentResource>> GetIfExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateAssessmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAssessmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAssessmentData>
    {
        public MigrateAssessmentData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> AssessmentErrorSummary { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessmentType? AssessmentType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.AzureDiskType> AzureDiskTypes { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit? AzureHybridUseBenefit { get { throw null; } set { } }
        public Azure.Core.AzureLocation? AzureLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureOfferCode? AzureOfferCode { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzurePricingTier? AzurePricingTier { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy? AzureStorageRedundancy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.AzureVmFamily> AzureVmFamilies { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.CostComponent> CostComponents { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureCurrency? Currency { get { throw null; } set { } }
        public double? DiscountPercentage { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> DistributionByOSName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> DistributionByServicePackInsight { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> DistributionBySupportStatus { get { throw null; } }
        public string EASubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrateGroupType? GroupType { get { throw null; } }
        public double? MonthlyBandwidthCost { get { throw null; } }
        public double? MonthlyComputeCost { get { throw null; } }
        public double? MonthlyPremiumStorageCost { get { throw null; } }
        public double? MonthlyStandardSsdStorageCost { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public double? MonthlyUltraStorageCost { get { throw null; } }
        public int? NumberOfMachines { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.PercentileOfUtilization? Percentile { get { throw null; } set { } }
        public System.DateTimeOffset? PerfDataEndOn { get { throw null; } set { } }
        public System.DateTimeOffset? PerfDataStartOn { get { throw null; } set { } }
        public System.DateTimeOffset? PricesQueriedOn { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureReservedInstance? ReservedInstance { get { throw null; } set { } }
        public double? ScalingFactor { get { throw null; } set { } }
        public string SchemaVersion { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AssessmentStage? Stage { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessmentStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> SuitabilitySummary { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessmentTimeRange? TimeRange { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.VmUptime VmUptime { get { throw null; } set { } }
        Azure.ResourceManager.Migrate.MigrateAssessmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAssessmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAssessmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateAssessmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAssessmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAssessmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAssessmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateAssessmentOptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource>, System.Collections.IEnumerable
    {
        protected MigrateAssessmentOptionCollection() { }
        public virtual Azure.Response<bool> Exists(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource> Get(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource>> GetAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource> GetIfExists(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource>> GetIfExistsAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateAssessmentOptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAssessmentOptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAssessmentOptionData>
    {
        public MigrateAssessmentOptionData() { }
        public System.Collections.Generic.IReadOnlyList<string> PremiumDiskVmFamilies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReservedInstanceSupportedCurrencies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReservedInstanceSupportedLocations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReservedInstanceSupportedOffers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReservedInstanceVmFamilies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SavingsPlanSupportedLocations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SavingsPlanVmFamilies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.UltraDiskAssessmentConfig> UltraDiskVmFamilies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.VmFamilyConfig> VmFamilies { get { throw null; } }
        Azure.ResourceManager.Migrate.MigrateAssessmentOptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAssessmentOptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAssessmentOptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateAssessmentOptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAssessmentOptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAssessmentOptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAssessmentOptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateAssessmentOptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateAssessmentOptionResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateAssessmentOptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string assessmentOptionsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateAssessmentProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource>, System.Collections.IEnumerable
    {
        protected MigrateAssessmentProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.MigrateAssessmentProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.MigrateAssessmentProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> GetIfExists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource>> GetIfExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateAssessmentProjectData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAssessmentProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAssessmentProjectData>
    {
        public MigrateAssessmentProjectData(Azure.Core.AzureLocation location) { }
        public string AssessmentSolutionId { get { throw null; } set { } }
        public System.DateTimeOffset? CreateOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier CustomerStorageAccountArmId { get { throw null; } set { } }
        public string CustomerWorkspaceId { get { throw null; } set { } }
        public string CustomerWorkspaceLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessmentProjectStatus? ProjectStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public string ServiceEndpoint { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Migrate.MigrateAssessmentProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAssessmentProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAssessmentProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateAssessmentProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAssessmentProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAssessmentProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAssessmentProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateAssessmentProjectResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateAssessmentProjectResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateAssessmentProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource> GetMigrateAssessmentOption(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource>> GetMigrateAssessmentOptionAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateAssessmentOptionCollection GetMigrateAssessmentOptions() { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryCollection GetMigrateAssessmentProjectSummaries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource> GetMigrateAssessmentProjectSummary(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource>> GetMigrateAssessmentProjectSummaryAsync(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource> GetMigrateAvsAssessmentOption(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource>> GetMigrateAvsAssessmentOptionAsync(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionCollection GetMigrateAvsAssessmentOptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateGroupResource> GetMigrateGroup(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateGroupResource>> GetMigrateGroupAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateGroupCollection GetMigrateGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource> GetMigrateHyperVCollector(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource>> GetMigrateHyperVCollectorAsync(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateHyperVCollectorCollection GetMigrateHyperVCollectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateImportCollectorResource> GetMigrateImportCollector(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateImportCollectorResource>> GetMigrateImportCollectorAsync(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateImportCollectorCollection GetMigrateImportCollectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateMachineResource> GetMigrateMachine(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateMachineResource>> GetMigrateMachineAsync(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateMachineCollection GetMigrateMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> GetMigratePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>> GetMigratePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionCollection GetMigratePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateLinkResource> GetMigratePrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateLinkResource>> GetMigratePrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigratePrivateLinkResourceCollection GetMigratePrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateServerCollectorResource> GetMigrateServerCollector(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateServerCollectorResource>> GetMigrateServerCollectorAsync(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateServerCollectorCollection GetMigrateServerCollectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource> GetMigrateSqlAssessmentOption(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource>> GetMigrateSqlAssessmentOptionAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionCollection GetMigrateSqlAssessmentOptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource> GetMigrateSqlCollector(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource>> GetMigrateSqlCollectorAsync(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateSqlCollectorCollection GetMigrateSqlCollectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource> GetMigrateVMwareCollector(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource>> GetMigrateVMwareCollectorAsync(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateVMwareCollectorCollection GetMigrateVMwareCollectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.MigrateAssessmentProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.MigrateAssessmentProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateAssessmentProjectSummaryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource>, System.Collections.IEnumerable
    {
        protected MigrateAssessmentProjectSummaryCollection() { }
        public virtual Azure.Response<bool> Exists(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource> Get(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource>> GetAsync(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource> GetIfExists(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource>> GetIfExistsAsync(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateAssessmentProjectSummaryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryData>
    {
        public MigrateAssessmentProjectSummaryData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.AssessmentErrorSummary> ErrorSummaryAffectedEntities { get { throw null; } }
        public System.DateTimeOffset? LastAssessedOn { get { throw null; } }
        public int? NumberOfAssessments { get { throw null; } }
        public int? NumberOfGroups { get { throw null; } }
        public int? NumberOfImportMachines { get { throw null; } }
        public int? NumberOfMachines { get { throw null; } }
        public int? NumberOfPrivateEndpointConnections { get { throw null; } }
        Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateAssessmentProjectSummaryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateAssessmentProjectSummaryResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string projectSummaryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateAssessmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateAssessmentResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.AssessmentReportDownloadUri> DownloadUrl(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.AssessmentReportDownloadUri>> DownloadUrlAsync(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedMachineResource> GetAssessedMachine(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedMachineResource>> GetAssessedMachineAsync(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.AssessedMachineCollection GetAssessedMachines() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateAssessmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateAssessmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateAvsAssessedMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource>, System.Collections.IEnumerable
    {
        protected MigrateAvsAssessedMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource> Get(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource>> GetAsync(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource> GetIfExists(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource>> GetIfExistsAsync(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateAvsAssessedMachineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineData>
    {
        public MigrateAvsAssessedMachineData() { }
        public Azure.ResourceManager.Migrate.Models.MachineBootType? BootType { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterMachineArmId { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterManagementServerArmId { get { throw null; } }
        public string DatacenterManagementServerName { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.AvsAssessedDisk> Disks { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.MigrateError> Errors { get { throw null; } }
        public double? MegabytesOfMemory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.AvsAssessedNetworkAdapter> NetworkAdapters { get { throw null; } }
        public int? NumberOfCores { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture? OperatingSystemArchitecture { get { throw null; } }
        public string OperatingSystemName { get { throw null; } }
        public string OperatingSystemType { get { throw null; } }
        public string OperatingSystemVersion { get { throw null; } }
        public double? PercentageCoresUtilization { get { throw null; } }
        public double? PercentageMemoryUtilization { get { throw null; } }
        public double? StorageInUseGB { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessedMachineType? TypePropertiesType { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateAvsAssessedMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateAvsAssessedMachineResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string avsAssessedMachineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateAvsAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource>, System.Collections.IEnumerable
    {
        protected MigrateAvsAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migrate.MigrateAvsAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migrate.MigrateAvsAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource> Get(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource>> GetAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource> GetIfExists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource>> GetIfExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateAvsAssessmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAvsAssessmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAvsAssessmentData>
    {
        public MigrateAvsAssessmentData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> AssessmentErrorSummary { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessmentType? AssessmentType { get { throw null; } }
        public Azure.Core.AzureLocation? AzureLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureOfferCode? AzureOfferCode { get { throw null; } set { } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public double? CpuUtilization { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureCurrency? Currency { get { throw null; } set { } }
        public double? DedupeCompression { get { throw null; } set { } }
        public double? DiscountPercentage { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.FttAndRaidLevel? FailuresToTolerateAndRaidLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrateGroupType? GroupType { get { throw null; } }
        public bool? IsStretchClusterEnabled { get { throw null; } set { } }
        public string LimitingFactor { get { throw null; } }
        public double? MemOvercommit { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AvsNodeType? NodeType { get { throw null; } set { } }
        public int? NumberOfMachines { get { throw null; } }
        public int? NumberOfNodes { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.PercentileOfUtilization? Percentile { get { throw null; } set { } }
        public System.DateTimeOffset? PerfDataEndOn { get { throw null; } set { } }
        public System.DateTimeOffset? PerfDataStartOn { get { throw null; } set { } }
        public System.DateTimeOffset? PricesQueriedOn { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? ProvisioningState { get { throw null; } set { } }
        public double? RamUtilization { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureReservedInstance? ReservedInstance { get { throw null; } set { } }
        public double? ScalingFactor { get { throw null; } set { } }
        public string SchemaVersion { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AssessmentStage? Stage { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessmentStatus? Status { get { throw null; } }
        public double? StorageUtilization { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AvsSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> SuitabilitySummary { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessmentTimeRange? TimeRange { get { throw null; } set { } }
        public double? TotalCpuCores { get { throw null; } }
        public double? TotalMonthlyCost { get { throw null; } }
        public double? TotalRamInGB { get { throw null; } }
        public double? TotalStorageInGB { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public double? VcpuOversubscription { get { throw null; } set { } }
        Azure.ResourceManager.Migrate.MigrateAvsAssessmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAvsAssessmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAvsAssessmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateAvsAssessmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAvsAssessmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAvsAssessmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAvsAssessmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateAvsAssessmentOptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource>, System.Collections.IEnumerable
    {
        protected MigrateAvsAssessmentOptionCollection() { }
        public virtual Azure.Response<bool> Exists(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource> Get(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource>> GetAsync(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource> GetIfExists(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource>> GetIfExistsAsync(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateAvsAssessmentOptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionData>
    {
        public MigrateAvsAssessmentOptionData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.AvsSkuConfig> AvsNodes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.FttAndRaidLevel> FailuresToTolerateAndRaidLevelValues { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.AvsNodeType> ReservedInstanceAvsNodes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.AzureCurrency> ReservedInstanceSupportedCurrencies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> ReservedInstanceSupportedLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.AzureOfferCode> ReservedInstanceSupportedOffers { get { throw null; } }
        Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateAvsAssessmentOptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateAvsAssessmentOptionResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string avsAssessmentOptionsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateAvsAssessmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateAvsAssessmentResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateAvsAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.AssessmentReportDownloadUri> DownloadUrl(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.AssessmentReportDownloadUri>> DownloadUrlAsync(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource> GetMigrateAvsAssessedMachine(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource>> GetMigrateAvsAssessedMachineAsync(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineCollection GetMigrateAvsAssessedMachines() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateAvsAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateAvsAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MigrateExtensions
    {
        public static Azure.ResourceManager.Migrate.AssessedMachineResource GetAssessedMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource GetAssessedSqlDatabaseV2Resource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource GetAssessedSqlInstanceV2Resource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.AssessedSqlMachineResource GetAssessedSqlMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource GetAssessedSqlRecommendedEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource GetMigrateAssessmentOptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> GetMigrateAssessmentProject(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource>> GetMigrateAssessmentProjectAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource GetMigrateAssessmentProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateAssessmentProjectCollection GetMigrateAssessmentProjects(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> GetMigrateAssessmentProjects(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> GetMigrateAssessmentProjectsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource GetMigrateAssessmentProjectSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateAssessmentResource GetMigrateAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource GetMigrateAvsAssessedMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource GetMigrateAvsAssessmentOptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource GetMigrateAvsAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateGroupResource GetMigrateGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource GetMigrateHyperVCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateImportCollectorResource GetMigrateImportCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateMachineResource GetMigrateMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource GetMigratePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigratePrivateLinkResource GetMigratePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateServerCollectorResource GetMigrateServerCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource GetMigrateSqlAssessmentOptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource GetMigrateSqlAssessmentV2Resource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource GetMigrateSqlAssessmentV2SummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateSqlCollectorResource GetMigrateSqlCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource GetMigrateVMwareCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MigrateGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateGroupResource>, System.Collections.IEnumerable
    {
        protected MigrateGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string groupName, Azure.ResourceManager.Migrate.MigrateGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string groupName, Azure.ResourceManager.Migrate.MigrateGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateGroupResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateGroupResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateGroupResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateGroupResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateGroupData>
    {
        public MigrateGroupData() { }
        public bool? AreAssessmentsRunning { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Assessments { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateGroupStatus? GroupStatus { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateGroupType? GroupType { get { throw null; } set { } }
        public int? MachineCount { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.AssessmentType> SupportedAssessmentTypes { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Migrate.MigrateGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateGroupResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentResource> GetMigrateAssessment(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentResource>> GetMigrateAssessmentAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateAssessmentCollection GetMigrateAssessments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource> GetMigrateAvsAssessment(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource>> GetMigrateAvsAssessmentAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateAvsAssessmentCollection GetMigrateAvsAssessments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource> GetMigrateSqlAssessmentV2(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource>> GetMigrateSqlAssessmentV2Async(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Collection GetMigrateSqlAssessmentV2s() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateGroupResource> UpdateMachines(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateGroupResource>> UpdateMachinesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateHyperVCollectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource>, System.Collections.IEnumerable
    {
        protected MigrateHyperVCollectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hyperVCollectorName, Azure.ResourceManager.Migrate.MigrateHyperVCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hyperVCollectorName, Azure.ResourceManager.Migrate.MigrateHyperVCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource> Get(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource>> GetAsync(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource> GetIfExists(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource>> GetIfExistsAsync(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateHyperVCollectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateHyperVCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateHyperVCollectorData>
    {
        public MigrateHyperVCollectorData() { }
        public Azure.ResourceManager.Migrate.Models.CollectorAgentPropertiesBase AgentProperties { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DiscoverySiteId { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Migrate.MigrateHyperVCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateHyperVCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateHyperVCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateHyperVCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateHyperVCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateHyperVCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateHyperVCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateHyperVCollectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateHyperVCollectorResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateHyperVCollectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string hyperVCollectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateHyperVCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateHyperVCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateImportCollectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateImportCollectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateImportCollectorResource>, System.Collections.IEnumerable
    {
        protected MigrateImportCollectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateImportCollectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string importCollectorName, Azure.ResourceManager.Migrate.MigrateImportCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateImportCollectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string importCollectorName, Azure.ResourceManager.Migrate.MigrateImportCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateImportCollectorResource> Get(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateImportCollectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateImportCollectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateImportCollectorResource>> GetAsync(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateImportCollectorResource> GetIfExists(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateImportCollectorResource>> GetIfExistsAsync(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateImportCollectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateImportCollectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateImportCollectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateImportCollectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateImportCollectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateImportCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateImportCollectorData>
    {
        public MigrateImportCollectorData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DiscoverySiteId { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Migrate.MigrateImportCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateImportCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateImportCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateImportCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateImportCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateImportCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateImportCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateImportCollectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateImportCollectorResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateImportCollectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string importCollectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateImportCollectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateImportCollectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateImportCollectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateImportCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateImportCollectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateImportCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateMachineResource>, System.Collections.IEnumerable
    {
        protected MigrateMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateMachineResource> Get(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateMachineResource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateMachineResource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateMachineResource>> GetAsync(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateMachineResource> GetIfExists(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateMachineResource>> GetIfExistsAsync(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateMachineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateMachineData>
    {
        public MigrateMachineData() { }
        public Azure.ResourceManager.Migrate.Models.MachineBootType? BootType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterManagementServerArmId { get { throw null; } }
        public string DatacenterManagementServerName { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.Core.ResourceIdentifier DiscoveryMachineArmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.MigrateDisk> Disks { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.MigrateError> Errors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Groups { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ProcessorInfo HostProcessor { get { throw null; } }
        public double? MegabytesOfMemory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.MigrateNetworkAdapter> NetworkAdapters { get { throw null; } }
        public int? NumberOfCores { get { throw null; } }
        public string OperatingSystemName { get { throw null; } }
        public string OperatingSystemType { get { throw null; } }
        public string OperatingSystemVersion { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ProductSupportStatus ProductSupportStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SqlInstances { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> WebApplications { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.WorkloadSummary WorkloadSummary { get { throw null; } }
        Azure.ResourceManager.Migrate.MigrateMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateMachineResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string machineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigratePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected MigratePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigratePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData>
    {
        public MigratePrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Migrate.Models.MigratePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigratePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigratePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigratePrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigratePrivateLinkResource() { }
        public virtual Azure.ResourceManager.Migrate.MigratePrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigratePrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigratePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigratePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected MigratePrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigratePrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigratePrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigratePrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigratePrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigratePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigratePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigratePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigratePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigratePrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigratePrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigratePrivateLinkResourceData>
    {
        public MigratePrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        Azure.ResourceManager.Migrate.MigratePrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigratePrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigratePrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigratePrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigratePrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigratePrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigratePrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateServerCollectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateServerCollectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateServerCollectorResource>, System.Collections.IEnumerable
    {
        protected MigrateServerCollectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateServerCollectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverCollectorName, Azure.ResourceManager.Migrate.MigrateServerCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateServerCollectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverCollectorName, Azure.ResourceManager.Migrate.MigrateServerCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateServerCollectorResource> Get(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateServerCollectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateServerCollectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateServerCollectorResource>> GetAsync(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateServerCollectorResource> GetIfExists(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateServerCollectorResource>> GetIfExistsAsync(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateServerCollectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateServerCollectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateServerCollectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateServerCollectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateServerCollectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateServerCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateServerCollectorData>
    {
        public MigrateServerCollectorData() { }
        public Azure.ResourceManager.Migrate.Models.CollectorAgentPropertiesBase AgentProperties { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DiscoverySiteId { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Migrate.MigrateServerCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateServerCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateServerCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateServerCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateServerCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateServerCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateServerCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateServerCollectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateServerCollectorResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateServerCollectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string serverCollectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateServerCollectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateServerCollectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateServerCollectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateServerCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateServerCollectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateServerCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateSqlAssessmentOptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource>, System.Collections.IEnumerable
    {
        protected MigrateSqlAssessmentOptionCollection() { }
        public virtual Azure.Response<bool> Exists(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource> Get(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource>> GetAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource> GetIfExists(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource>> GetIfExistsAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateSqlAssessmentOptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionData>
    {
        public MigrateSqlAssessmentOptionData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.AzureVmFamily> PremiumDiskVmFamilies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.MigrateTargetType> ReservedInstanceSqlTargets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.AzureCurrency> ReservedInstanceSupportedCurrencies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> ReservedInstanceSupportedLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> ReservedInstanceSupportedLocationsForIaas { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.AzureOfferCode> ReservedInstanceSupportedOffers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.AzureVmFamily> ReservedInstanceVmFamilies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> SavingsPlanSupportedLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> SavingsPlanSupportedLocationsForPaas { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.AzureOfferCode> SavingsPlanSupportedOffers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.AzureVmFamily> SavingsPlanVmFamilies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.SqlPaaSTargetConfig> SqlSkus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.AzureOfferCode> SupportedOffers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.VmFamilyConfig> VmFamilies { get { throw null; } }
        Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlAssessmentOptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateSqlAssessmentOptionResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string assessmentOptionsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateSqlAssessmentV2Collection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource>, System.Collections.IEnumerable
    {
        protected MigrateSqlAssessmentV2Collection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Data data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Data data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource> Get(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource>> GetAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource> GetIfExists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource>> GetIfExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateSqlAssessmentV2Data : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Data>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Data>
    {
        public MigrateSqlAssessmentV2Data() { }
        public Azure.ResourceManager.Migrate.Models.AssessmentType? AssessmentType { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AsyncCommitModeIntent? AsyncCommitModeIntent { get { throw null; } set { } }
        public Azure.Core.AzureLocation? AzureLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureOfferCode? AzureOfferCode { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureOfferCode? AzureOfferCodeForVm { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureSecurityOfferingType? AzureSecurityOfferingType { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.SqlDBSettings AzureSqlDatabaseSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.SqlMISettings AzureSqlManagedInstanceSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.AzureVmFamily> AzureSqlVmInstanceSeries { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureCurrency? Currency { get { throw null; } set { } }
        public Azure.Core.AzureLocation? DisasterRecoveryLocation { get { throw null; } set { } }
        public double? DiscountPercentage { get { throw null; } set { } }
        public string EASubscriptionId { get { throw null; } set { } }
        public bool? EnableHadrAssessment { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.EntityUptime EntityUptime { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AssessmentEnvironmentType? EnvironmentType { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrateGroupType? GroupType { get { throw null; } set { } }
        public bool? IsInternetAccessAvailable { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MultiSubnetIntent? MultiSubnetIntent { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.SqlOptimizationLogic? OptimizationLogic { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrateOSLicense? OSLicense { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.PercentileOfUtilization? Percentile { get { throw null; } set { } }
        public System.DateTimeOffset? PerfDataEndOn { get { throw null; } set { } }
        public System.DateTimeOffset? PerfDataStartOn { get { throw null; } set { } }
        public System.DateTimeOffset? PricesQueriedOn { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureReservedInstance? ReservedInstance { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureReservedInstance? ReservedInstanceForVm { get { throw null; } set { } }
        public double? ScalingFactor { get { throw null; } set { } }
        public string SchemaVersion { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.SqlServerLicense? SqlServerLicense { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AssessmentStage? Stage { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessmentStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessmentTimeRange? TimeRange { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Data System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Data>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Data>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Data System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Data>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Data>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Data>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlAssessmentV2Resource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateSqlAssessmentV2Resource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Data Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.AssessmentReportDownloadUri> DownloadUrl(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.Models.AssessmentReportDownloadUri>> DownloadUrlAsync(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource> GetAssessedSqlDatabaseV2(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource>> GetAssessedSqlDatabaseV2Async(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Collection GetAssessedSqlDatabaseV2s() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource> GetAssessedSqlInstanceV2(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource>> GetAssessedSqlInstanceV2Async(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Collection GetAssessedSqlInstanceV2s() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlMachineResource> GetAssessedSqlMachine(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlMachineResource>> GetAssessedSqlMachineAsync(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.AssessedSqlMachineCollection GetAssessedSqlMachines() { throw null; }
        public virtual Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityCollection GetAssessedSqlRecommendedEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource> GetAssessedSqlRecommendedEntity(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource>> GetAssessedSqlRecommendedEntityAsync(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryCollection GetMigrateSqlAssessmentV2Summaries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource> GetMigrateSqlAssessmentV2Summary(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource>> GetMigrateSqlAssessmentV2SummaryAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Data data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Data data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateSqlAssessmentV2SummaryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource>, System.Collections.IEnumerable
    {
        protected MigrateSqlAssessmentV2SummaryCollection() { }
        public virtual Azure.Response<bool> Exists(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource> Get(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource>> GetAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource> GetIfExists(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource>> GetIfExistsAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateSqlAssessmentV2SummaryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryData>
    {
        public MigrateSqlAssessmentV2SummaryData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.SqlAssessmentV2SummaryDetails> AssessmentSummary { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> DatabaseDistributionBySizingCriterion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> DistributionByServicePackInsight { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> DistributionBySqlEdition { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> DistributionBySqlVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> DistributionBySupportStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> InstanceDistributionBySizingCriterion { get { throw null; } }
        public int? NumberOfFciInstances { get { throw null; } }
        public int? NumberOfMachines { get { throw null; } }
        public int? NumberOfSqlAvailabilityGroups { get { throw null; } }
        public int? NumberOfSqlDatabases { get { throw null; } }
        public int? NumberOfSqlInstances { get { throw null; } }
        public int? NumberOfSuccessfullyDiscoveredSqlInstances { get { throw null; } }
        Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlAssessmentV2SummaryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateSqlAssessmentV2SummaryResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string summaryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateSqlCollectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource>, System.Collections.IEnumerable
    {
        protected MigrateSqlCollectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string collectorName, Azure.ResourceManager.Migrate.MigrateSqlCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string collectorName, Azure.ResourceManager.Migrate.MigrateSqlCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource> Get(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource>> GetAsync(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource> GetIfExists(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource>> GetIfExistsAsync(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateSqlCollectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateSqlCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateSqlCollectorData>
    {
        public MigrateSqlCollectorData() { }
        public Azure.ResourceManager.Migrate.Models.CollectorAgentPropertiesBase AgentProperties { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DiscoverySiteId { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Migrate.MigrateSqlCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateSqlCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateSqlCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateSqlCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateSqlCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateSqlCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateSqlCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateSqlCollectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateSqlCollectorResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateSqlCollectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string collectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateSqlCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateSqlCollectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateSqlCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrateVMwareCollectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource>, System.Collections.IEnumerable
    {
        protected MigrateVMwareCollectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vmWareCollectorName, Azure.ResourceManager.Migrate.MigrateVMwareCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vmWareCollectorName, Azure.ResourceManager.Migrate.MigrateVMwareCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource> Get(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource>> GetAsync(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource> GetIfExists(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource>> GetIfExistsAsync(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrateVMwareCollectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateVMwareCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateVMwareCollectorData>
    {
        public MigrateVMwareCollectorData() { }
        public Azure.ResourceManager.Migrate.Models.CollectorAgentPropertiesBase AgentProperties { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DiscoverySiteId { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Migrate.MigrateVMwareCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateVMwareCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.MigrateVMwareCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.MigrateVMwareCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateVMwareCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateVMwareCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.MigrateVMwareCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateVMwareCollectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrateVMwareCollectorResource() { }
        public virtual Azure.ResourceManager.Migrate.MigrateVMwareCollectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string vmWareCollectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateVMwareCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigrateVMwareCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Migrate.Mocking
{
    public partial class MockableMigrateArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMigrateArmClient() { }
        public virtual Azure.ResourceManager.Migrate.AssessedMachineResource GetAssessedMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Resource GetAssessedSqlDatabaseV2Resource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Resource GetAssessedSqlInstanceV2Resource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.AssessedSqlMachineResource GetAssessedSqlMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityResource GetAssessedSqlRecommendedEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateAssessmentOptionResource GetMigrateAssessmentOptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource GetMigrateAssessmentProjectResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryResource GetMigrateAssessmentProjectSummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateAssessmentResource GetMigrateAssessmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineResource GetMigrateAvsAssessedMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionResource GetMigrateAvsAssessmentOptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateAvsAssessmentResource GetMigrateAvsAssessmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateGroupResource GetMigrateGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateHyperVCollectorResource GetMigrateHyperVCollectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateImportCollectorResource GetMigrateImportCollectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateMachineResource GetMigrateMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource GetMigratePrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigratePrivateLinkResource GetMigratePrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateServerCollectorResource GetMigrateServerCollectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionResource GetMigrateSqlAssessmentOptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Resource GetMigrateSqlAssessmentV2Resource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryResource GetMigrateSqlAssessmentV2SummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateSqlCollectorResource GetMigrateSqlCollectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateVMwareCollectorResource GetMigrateVMwareCollectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMigrateResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMigrateResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> GetMigrateAssessmentProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource>> GetMigrateAssessmentProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigrateAssessmentProjectCollection GetMigrateAssessmentProjects() { throw null; }
    }
    public partial class MockableMigrateSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMigrateSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> GetMigrateAssessmentProjects(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigrateAssessmentProjectResource> GetMigrateAssessmentProjectsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Migrate.Models
{
    public static partial class ArmMigrateModelFactory
    {
        public static Azure.ResourceManager.Migrate.Models.AssessedDataDisk AssessedDataDisk(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? suitability = default(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability?), Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation?), Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail?), Azure.ResourceManager.Migrate.Models.AzureDiskSize? recommendedDiskSize = default(Azure.ResourceManager.Migrate.Models.AzureDiskSize?), Azure.ResourceManager.Migrate.Models.AzureDiskType? recommendedDiskType = default(Azure.ResourceManager.Migrate.Models.AzureDiskType?), int? recommendedDiskSizeGigabytes = default(int?), double? recommendDiskThroughputInMbps = default(double?), double? recommendedDiskIops = default(double?), double? monthlyStorageCost = default(double?), string name = null, string displayName = null, double? gigabytesProvisioned = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessedDisk AssessedDisk(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? suitability = default(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability?), Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation?), Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail?), Azure.ResourceManager.Migrate.Models.AzureDiskSize? recommendedDiskSize = default(Azure.ResourceManager.Migrate.Models.AzureDiskSize?), Azure.ResourceManager.Migrate.Models.AzureDiskType? recommendedDiskType = default(Azure.ResourceManager.Migrate.Models.AzureDiskType?), int? gigabytesForRecommendedDiskSize = default(int?), double? recommendDiskThroughputInMbps = default(double?), double? recommendedDiskIops = default(double?), double? monthlyStorageCost = default(double?), string name = null, string displayName = null, double? gigabytesProvisioned = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migrate.AssessedMachineData AssessedMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.MigrateError> errors = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.AssessedDisk> disks = null, double? monthlyUltraStorageCost = default(double?), Azure.ResourceManager.Migrate.Models.ProcessorInfo hostProcessor = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.CostComponent> costComponents = null, Azure.ResourceManager.Migrate.Models.ProductSupportStatus productSupportStatus = null, double? monthlyBandwidthCost = default(double?), double? monthlyStorageCost = default(double?), double? monthlyPremiumStorageCost = default(double?), double? monthlyStandardSsdStorageCost = default(double?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.AssessedNetworkAdapter> networkAdapters = null, Azure.ResourceManager.Migrate.Models.AzureVmSize? recommendedSize = default(Azure.ResourceManager.Migrate.Models.AzureVmSize?), int? numberOfCoresForRecommendedSize = default(int?), double? megabytesOfMemoryForRecommendedSize = default(double?), double? monthlyComputeCostForRecommendedSize = default(double?), Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation?), Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail?), Azure.ResourceManager.Migrate.Models.AssessedMachineType? typePropertiesType = default(Azure.ResourceManager.Migrate.Models.AssessedMachineType?), Azure.ResourceManager.Migrate.Models.MachineBootType? bootType = default(Azure.ResourceManager.Migrate.Models.MachineBootType?), string operatingSystemType = null, string operatingSystemName = null, string operatingSystemVersion = null, Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture? operatingSystemArchitecture = default(Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string displayName = null, string description = null, Azure.Core.ResourceIdentifier datacenterMachineArmId = null, Azure.Core.ResourceIdentifier datacenterManagementServerArmId = null, string datacenterManagementServerName = null, double? megabytesOfMemory = default(double?), int? numberOfCores = default(int?), double? confidenceRatingInPercentage = default(double?), double? percentageCoresUtilization = default(double?), double? percentageMemoryUtilization = default(double?), Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? suitability = default(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessedNetworkAdapter AssessedNetworkAdapter(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? suitability = default(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability?), Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail?), Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation?), double? monthlyBandwidthCosts = default(double?), double? netGigabytesTransmittedPerMonth = default(double?), string displayName = null, string macAddress = null, System.Collections.Generic.IEnumerable<string> ipAddresses = null, double? megabytesPerSecondReceived = default(double?), double? megabytesPerSecondTransmitted = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migrate.AssessedSqlDatabaseV2Data AssessedSqlDatabaseV2Data(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migrate.Models.MigrateTargetType? recommendedAzureSqlTargetType = default(Azure.ResourceManager.Migrate.Models.MigrateTargetType?), Azure.ResourceManager.Migrate.Models.RecommendedSuitability? recommendedSuitability = default(Azure.ResourceManager.Migrate.Models.RecommendedSuitability?), double? bufferCacheSizeInMB = default(double?), Azure.ResourceManager.Migrate.Models.ProductSupportStatus productSupportStatus = null, Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlMISuitabilityDetails = null, Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlDBSuitabilityDetails = null, bool? isDatabaseHighlyAvailable = default(bool?), Azure.ResourceManager.Migrate.Models.SqlAvailabilityGroupDataOverview linkedAvailabilityGroupOverview = null, Azure.Core.ResourceIdentifier machineArmId = null, Azure.Core.ResourceIdentifier assessedSqlInstanceArmId = null, string machineName = null, string instanceName = null, string databaseName = null, double? databaseSizeInMB = default(double?), Azure.ResourceManager.Migrate.Models.CompatibilityLevel? compatibilityLevel = default(Azure.ResourceManager.Migrate.Models.CompatibilityLevel?), Azure.Core.ResourceIdentifier sqlDatabaseSdsArmId = null, double? percentageCoresUtilization = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?), double? confidenceRatingInPercentage = default(double?), Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDatabaseSummary AssessedSqlInstanceDatabaseSummary(int? numberOfUserDatabases = default(int?), double? totalDatabaseSizeInMB = default(double?), double? largestDatabaseSizeInMB = default(double?), int? totalDiscoveredUserDatabases = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDiskDetails AssessedSqlInstanceDiskDetails(string diskId = null, double? diskSizeInMB = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceStorageDetails AssessedSqlInstanceStorageDetails(string storageType = null, double? diskSizeInMB = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceSummary AssessedSqlInstanceSummary(string instanceId = null, string instanceName = null, Azure.Core.ResourceIdentifier sqlInstanceSdsArmId = null, string sqlInstanceEntityId = null, string sqlEdition = null, string sqlVersion = null, bool? isClustered = default(bool?), bool? isHighAvailabilityEnabled = default(bool?), Azure.ResourceManager.Migrate.Models.SqlFciState? sqlFciState = default(Azure.ResourceManager.Migrate.Models.SqlFciState?)) { throw null; }
        public static Azure.ResourceManager.Migrate.AssessedSqlInstanceV2Data AssessedSqlInstanceV2Data(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, double? memoryInUseInMB = default(double?), bool? hasScanOccurred = default(bool?), Azure.ResourceManager.Migrate.Models.MigrateTargetType? recommendedAzureSqlTargetType = default(Azure.ResourceManager.Migrate.Models.MigrateTargetType?), Azure.ResourceManager.Migrate.Models.RecommendedSuitability? recommendedSuitability = default(Azure.ResourceManager.Migrate.Models.RecommendedSuitability?), Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlMISuitabilityDetails = null, Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlDBSuitabilityDetails = null, Azure.ResourceManager.Migrate.Models.SqlAssessmentV2IaasSuitabilityDetails azureSqlVmSuitabilityDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceStorageDetails> storageTypeBasedDetails = null, Azure.ResourceManager.Migrate.Models.ProductSupportStatus productSupportStatus = null, Azure.ResourceManager.Migrate.Models.SqlFciMetadata fciMetadata = null, Azure.ResourceManager.Migrate.Models.SqlAvailabilityReplicaSummary availabilityReplicaSummary = null, bool? isClustered = default(bool?), bool? isHighAvailabilityEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoning> recommendedTargetReasonings = null, Azure.Core.ResourceIdentifier machineArmId = null, string machineName = null, string instanceName = null, Azure.Core.ResourceIdentifier sqlInstanceSdsArmId = null, string sqlEdition = null, string sqlVersion = null, int? numberOfCoresAllocated = default(int?), double? percentageCoresUtilization = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDiskDetails> logicalDisks = null, Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDatabaseSummary databaseSummary = null, double? confidenceRatingInPercentage = default(double?), Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migrate.AssessedSqlMachineData AssessedSqlMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string biosGuid = null, string fqdn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceSummary> sqlInstances = null, Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail?), Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation?), Azure.ResourceManager.Migrate.Models.AzureVmSize? recommendedVmSize = default(Azure.ResourceManager.Migrate.Models.AzureVmSize?), Azure.ResourceManager.Migrate.Models.AzureVmFamily? recommendedVmFamily = default(Azure.ResourceManager.Migrate.Models.AzureVmFamily?), Azure.ResourceManager.Migrate.Models.ProductSupportStatus productSupportStatus = null, int? recommendedVmSizeNumberOfCores = default(int?), double? recommendedVmSizeMegabytesOfMemory = default(double?), double? monthlyComputeCost = default(double?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.AssessedDataDisk> disks = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.SqlAssessedNetworkAdapter> networkAdapters = null, double? monthlyBandwidthCost = default(double?), double? monthlyStorageCost = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.CostComponent> costComponents = null, Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? securitySuitability = default(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.SqlMigrationGuideline> migrationGuidelines = null, Azure.ResourceManager.Migrate.Models.MachineBootType? bootType = default(Azure.ResourceManager.Migrate.Models.MachineBootType?), string operatingSystemType = null, string operatingSystemName = null, string operatingSystemVersion = null, Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture? operatingSystemArchitecture = default(Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string displayName = null, Azure.ResourceManager.Migrate.Models.AssessedMachineType? typePropertiesType = default(Azure.ResourceManager.Migrate.Models.AssessedMachineType?), string description = null, Azure.Core.ResourceIdentifier datacenterMachineArmId = null, Azure.Core.ResourceIdentifier datacenterManagementServerArmId = null, string datacenterManagementServerName = null, double? megabytesOfMemory = default(double?), int? numberOfCores = default(int?), double? confidenceRatingInPercentage = default(double?), double? percentageCoresUtilization = default(double?), double? percentageMemoryUtilization = default(double?), Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? suitability = default(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability?), Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion?)) { throw null; }
        public static Azure.ResourceManager.Migrate.AssessedSqlRecommendedEntityData AssessedSqlRecommendedEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string machineName = null, string instanceName = null, Azure.ResourceManager.Migrate.Models.ProductSupportStatus productSupportStatus = null, int? dbCount = default(int?), int? discoveredDBCount = default(int?), bool? hasScanOccurred = default(bool?), Azure.ResourceManager.Migrate.Models.MigrateTargetType? recommendedAzureSqlTargetType = default(Azure.ResourceManager.Migrate.Models.MigrateTargetType?), Azure.ResourceManager.Migrate.Models.RecommendedSuitability? recommendedSuitability = default(Azure.ResourceManager.Migrate.Models.RecommendedSuitability?), Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlMISuitabilityDetails = null, Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlDBSuitabilityDetails = null, Azure.ResourceManager.Migrate.Models.SqlAssessmentV2IaasSuitabilityDetails azureSqlVmSuitabilityDetails = null, Azure.Core.ResourceIdentifier assessedSqlEntityArmId = null, bool? isClustered = default(bool?), bool? isHighAvailabilityEnabled = default(bool?), string sqlEdition = null, string sqlVersion = null, Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessmentErrorSummary AssessmentErrorSummary(Azure.ResourceManager.Migrate.Models.AssessmentType? assessmentType = default(Azure.ResourceManager.Migrate.Models.AssessmentType?), int? count = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessmentReportDownloadUri AssessmentReportDownloadUri(System.Uri assessmentReportUri = null, System.DateTimeOffset expireOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AvsAssessedDisk AvsAssessedDisk(string name = null, string displayName = null, double? gigabytesProvisioned = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AvsAssessedNetworkAdapter AvsAssessedNetworkAdapter(string macAddress = null, System.Collections.Generic.IEnumerable<string> ipAddresses = null, string displayName = null, double? megabytesPerSecondReceived = default(double?), double? megabytesPerSecondTransmitted = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto AzureManagedDiskSkuDto(Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskType? diskType = default(Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskType?), Azure.ResourceManager.Migrate.Models.AzureDiskSize? diskSize = default(Azure.ResourceManager.Migrate.Models.AzureDiskSize?), Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskRedundancy? diskRedundancy = default(Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskRedundancy?), double? storageCost = default(double?), double? recommendedSizeInGib = default(double?), double? recommendedThroughputInMbps = default(double?), double? recommendedIops = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlIaasSkuDto AzureSqlIaasSkuDto(Azure.ResourceManager.Migrate.Models.AzureVmSkuDto virtualMachineSize = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto> dataDiskSizes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto> logDiskSizes = null, Azure.ResourceManager.Migrate.Models.MigrateTargetType? azureSqlTargetType = default(Azure.ResourceManager.Migrate.Models.MigrateTargetType?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlPaasSkuDto AzureSqlPaasSkuDto(Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier? azureSqlServiceTier = default(Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier?), Azure.ResourceManager.Migrate.Models.MigrateComputeTier? azureSqlComputeTier = default(Azure.ResourceManager.Migrate.Models.MigrateComputeTier?), Azure.ResourceManager.Migrate.Models.MigrateHardwareGeneration? azureSqlHardwareGeneration = default(Azure.ResourceManager.Migrate.Models.MigrateHardwareGeneration?), double? storageMaxSizeInMB = default(double?), double? predictedDataSizeInMB = default(double?), double? predictedLogSizeInMB = default(double?), int? cores = default(int?), Azure.ResourceManager.Migrate.Models.MigrateTargetType? azureSqlTargetType = default(Azure.ResourceManager.Migrate.Models.MigrateTargetType?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSkuDto AzureVmSkuDto(Azure.ResourceManager.Migrate.Models.AzureVmFamily? azureVmFamily = default(Azure.ResourceManager.Migrate.Models.AzureVmFamily?), int? cores = default(int?), Azure.ResourceManager.Migrate.Models.AzureVmSize? azureSkuName = default(Azure.ResourceManager.Migrate.Models.AzureVmSize?), int? availableCores = default(int?), int? maxNetworkInterfaces = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.CostComponent CostComponent(Azure.ResourceManager.Migrate.Models.CostComponentName? name = default(Azure.ResourceManager.Migrate.Models.CostComponentName?), double? value = default(double?), string description = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.ImpactedAssessmentObject ImpactedAssessmentObject(string objectName = null, string objectType = null) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateAssessmentData MigrateAssessmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? provisioningState = default(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState?), System.Collections.Generic.IReadOnlyDictionary<string, int> assessmentErrorSummary = null, double? monthlyUltraStorageCost = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.CostComponent> costComponents = null, string eaSubscriptionId = null, Azure.ResourceManager.Migrate.Models.AzurePricingTier? azurePricingTier = default(Azure.ResourceManager.Migrate.Models.AzurePricingTier?), Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy? azureStorageRedundancy = default(Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy?), Azure.ResourceManager.Migrate.Models.AzureReservedInstance? reservedInstance = default(Azure.ResourceManager.Migrate.Models.AzureReservedInstance?), Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit? azureHybridUseBenefit = default(Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureDiskType> azureDiskTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureVmFamily> azureVmFamilies = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionBySupportStatus = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionByServicePackInsight = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionByOSName = null, double? monthlyComputeCost = default(double?), double? monthlyBandwidthCost = default(double?), double? monthlyStorageCost = default(double?), double? monthlyPremiumStorageCost = default(double?), double? monthlyStandardSsdStorageCost = default(double?), System.Collections.Generic.IReadOnlyDictionary<string, int> suitabilitySummary = null, int? numberOfMachines = default(int?), Azure.ResourceManager.Migrate.Models.VmUptime vmUptime = null, Azure.ResourceManager.Migrate.Models.MigrateGroupType? groupType = default(Azure.ResourceManager.Migrate.Models.MigrateGroupType?), Azure.ResourceManager.Migrate.Models.AssessmentType? assessmentType = default(Azure.ResourceManager.Migrate.Models.AssessmentType?), Azure.Core.AzureLocation? azureLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Migrate.Models.AzureOfferCode? azureOfferCode = default(Azure.ResourceManager.Migrate.Models.AzureOfferCode?), Azure.ResourceManager.Migrate.Models.AzureCurrency? currency = default(Azure.ResourceManager.Migrate.Models.AzureCurrency?), double? scalingFactor = default(double?), Azure.ResourceManager.Migrate.Models.PercentileOfUtilization? percentile = default(Azure.ResourceManager.Migrate.Models.PercentileOfUtilization?), Azure.ResourceManager.Migrate.Models.AssessmentTimeRange? timeRange = default(Azure.ResourceManager.Migrate.Models.AssessmentTimeRange?), System.DateTimeOffset? perfDataStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? perfDataEndOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migrate.Models.AssessmentStage? stage = default(Azure.ResourceManager.Migrate.Models.AssessmentStage?), double? discountPercentage = default(double?), Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion?), double? confidenceRatingInPercentage = default(double?), System.DateTimeOffset? pricesQueriedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migrate.Models.AssessmentStatus? status = default(Azure.ResourceManager.Migrate.Models.AssessmentStatus?), string schemaVersion = null) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateAssessmentOptionData MigrateAssessmentOptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.VmFamilyConfig> vmFamilies = null, System.Collections.Generic.IEnumerable<string> reservedInstanceVmFamilies = null, System.Collections.Generic.IEnumerable<string> reservedInstanceSupportedLocations = null, System.Collections.Generic.IEnumerable<string> reservedInstanceSupportedCurrencies = null, System.Collections.Generic.IEnumerable<string> reservedInstanceSupportedOffers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.UltraDiskAssessmentConfig> ultraDiskVmFamilies = null, System.Collections.Generic.IEnumerable<string> premiumDiskVmFamilies = null, System.Collections.Generic.IEnumerable<string> savingsPlanVmFamilies = null, System.Collections.Generic.IEnumerable<string> savingsPlanSupportedLocations = null) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateAssessmentProjectData MigrateAssessmentProjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? provisioningState = default(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState?), System.DateTimeOffset? createOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string serviceEndpoint = null, string assessmentSolutionId = null, Azure.ResourceManager.Migrate.Models.AssessmentProjectStatus? projectStatus = default(Azure.ResourceManager.Migrate.Models.AssessmentProjectStatus?), string customerWorkspaceId = null, string customerWorkspaceLocation = null, string publicNetworkAccess = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData> privateEndpointConnections = null, Azure.Core.ResourceIdentifier customerStorageAccountArmId = null) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateAssessmentProjectSummaryData MigrateAssessmentProjectSummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AssessmentErrorSummary> errorSummaryAffectedEntities = null, int? numberOfPrivateEndpointConnections = default(int?), int? numberOfGroups = default(int?), int? numberOfMachines = default(int?), int? numberOfImportMachines = default(int?), int? numberOfAssessments = default(int?), System.DateTimeOffset? lastAssessedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateAvsAssessedMachineData MigrateAvsAssessedMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.MigrateError> errors = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.AvsAssessedDisk> disks = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.AvsAssessedNetworkAdapter> networkAdapters = null, double? storageInUseGB = default(double?), Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityExplanation?), Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityDetail?), Azure.ResourceManager.Migrate.Models.AssessedMachineType? typePropertiesType = default(Azure.ResourceManager.Migrate.Models.AssessedMachineType?), Azure.ResourceManager.Migrate.Models.MachineBootType? bootType = default(Azure.ResourceManager.Migrate.Models.MachineBootType?), string operatingSystemType = null, string operatingSystemName = null, string operatingSystemVersion = null, Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture? operatingSystemArchitecture = default(Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string displayName = null, string description = null, Azure.Core.ResourceIdentifier datacenterMachineArmId = null, Azure.Core.ResourceIdentifier datacenterManagementServerArmId = null, string datacenterManagementServerName = null, double? megabytesOfMemory = default(double?), int? numberOfCores = default(int?), double? confidenceRatingInPercentage = default(double?), double? percentageCoresUtilization = default(double?), double? percentageMemoryUtilization = default(double?), Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? suitability = default(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability?)) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateAvsAssessmentData MigrateAvsAssessmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? provisioningState = default(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState?), System.Collections.Generic.IReadOnlyDictionary<string, int> assessmentErrorSummary = null, Azure.ResourceManager.Migrate.Models.FttAndRaidLevel? failuresToTolerateAndRaidLevel = default(Azure.ResourceManager.Migrate.Models.FttAndRaidLevel?), double? vcpuOversubscription = default(double?), Azure.ResourceManager.Migrate.Models.AvsNodeType? nodeType = default(Azure.ResourceManager.Migrate.Models.AvsNodeType?), Azure.ResourceManager.Migrate.Models.AzureReservedInstance? reservedInstance = default(Azure.ResourceManager.Migrate.Models.AzureReservedInstance?), double? totalMonthlyCost = default(double?), Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? suitability = default(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability?), Azure.ResourceManager.Migrate.Models.AvsSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migrate.Models.AvsSuitabilityExplanation?), int? numberOfNodes = default(int?), double? cpuUtilization = default(double?), double? ramUtilization = default(double?), double? storageUtilization = default(double?), double? totalCpuCores = default(double?), double? totalRamInGB = default(double?), double? totalStorageInGB = default(double?), int? numberOfMachines = default(int?), System.Collections.Generic.IReadOnlyDictionary<string, int> suitabilitySummary = null, double? memOvercommit = default(double?), double? dedupeCompression = default(double?), string limitingFactor = null, bool? isStretchClusterEnabled = default(bool?), Azure.ResourceManager.Migrate.Models.MigrateGroupType? groupType = default(Azure.ResourceManager.Migrate.Models.MigrateGroupType?), Azure.ResourceManager.Migrate.Models.AssessmentType? assessmentType = default(Azure.ResourceManager.Migrate.Models.AssessmentType?), Azure.Core.AzureLocation? azureLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Migrate.Models.AzureOfferCode? azureOfferCode = default(Azure.ResourceManager.Migrate.Models.AzureOfferCode?), Azure.ResourceManager.Migrate.Models.AzureCurrency? currency = default(Azure.ResourceManager.Migrate.Models.AzureCurrency?), double? scalingFactor = default(double?), Azure.ResourceManager.Migrate.Models.PercentileOfUtilization? percentile = default(Azure.ResourceManager.Migrate.Models.PercentileOfUtilization?), Azure.ResourceManager.Migrate.Models.AssessmentTimeRange? timeRange = default(Azure.ResourceManager.Migrate.Models.AssessmentTimeRange?), System.DateTimeOffset? perfDataStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? perfDataEndOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migrate.Models.AssessmentStage? stage = default(Azure.ResourceManager.Migrate.Models.AssessmentStage?), double? discountPercentage = default(double?), Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion?), double? confidenceRatingInPercentage = default(double?), System.DateTimeOffset? pricesQueriedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migrate.Models.AssessmentStatus? status = default(Azure.ResourceManager.Migrate.Models.AssessmentStatus?), string schemaVersion = null) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateAvsAssessmentOptionData MigrateAvsAssessmentOptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AvsSkuConfig> avsNodes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.FttAndRaidLevel> failuresToTolerateAndRaidLevelValues = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AvsNodeType> reservedInstanceAvsNodes = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> reservedInstanceSupportedLocations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureCurrency> reservedInstanceSupportedCurrencies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureOfferCode> reservedInstanceSupportedOffers = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateDisk MigrateDisk(double? gigabytesAllocated = default(double?), string displayName = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateError MigrateError(int? id = default(int?), string code = null, string runAsAccountId = null, string applianceName = null, string message = null, string summaryMessage = null, string agentScenario = null, string possibleCauses = null, string recommendedAction = null, string severity = null, System.Collections.Generic.IReadOnlyDictionary<string, string> messageParameters = null, System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string impactedAssessmentType = null) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateGroupData MigrateGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? provisioningState = default(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState?), Azure.ResourceManager.Migrate.Models.MigrateGroupStatus? groupStatus = default(Azure.ResourceManager.Migrate.Models.MigrateGroupStatus?), int? machineCount = default(int?), System.Collections.Generic.IEnumerable<string> assessments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AssessmentType> supportedAssessmentTypes = null, bool? areAssessmentsRunning = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migrate.Models.MigrateGroupType? groupType = default(Azure.ResourceManager.Migrate.Models.MigrateGroupType?)) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateHyperVCollectorData MigrateHyperVCollectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? provisioningState = default(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState?), Azure.ResourceManager.Migrate.Models.CollectorAgentPropertiesBase agentProperties = null, string discoverySiteId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateImportCollectorData MigrateImportCollectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? provisioningState = default(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState?), string discoverySiteId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateMachineData MigrateMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migrate.Models.WorkloadSummary workloadSummary = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.MigrateError> errors = null, Azure.ResourceManager.Migrate.Models.ProcessorInfo hostProcessor = null, Azure.ResourceManager.Migrate.Models.ProductSupportStatus productSupportStatus = null, Azure.Core.ResourceIdentifier discoveryMachineArmId = null, Azure.Core.ResourceIdentifier datacenterManagementServerArmId = null, string datacenterManagementServerName = null, Azure.ResourceManager.Migrate.Models.MachineBootType? bootType = default(Azure.ResourceManager.Migrate.Models.MachineBootType?), string displayName = null, double? megabytesOfMemory = default(double?), int? numberOfCores = default(int?), string operatingSystemType = null, string operatingSystemName = null, string operatingSystemVersion = null, string description = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.MigrateDisk> disks = null, System.Collections.Generic.IEnumerable<string> groups = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.MigrateNetworkAdapter> networkAdapters = null, System.Collections.Generic.IEnumerable<string> sqlInstances = null, System.Collections.Generic.IEnumerable<string> webApplications = null, System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateNetworkAdapter MigrateNetworkAdapter(string macAddress = null, System.Collections.Generic.IEnumerable<string> ipAddresses = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData MigratePrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Migrate.Models.MigratePrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Migrate.MigratePrivateLinkResourceData MigratePrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateServerCollectorData MigrateServerCollectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? provisioningState = default(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState?), Azure.ResourceManager.Migrate.Models.CollectorAgentPropertiesBase agentProperties = null, string discoverySiteId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateSqlAssessmentOptionData MigrateSqlAssessmentOptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.VmFamilyConfig> vmFamilies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureVmFamily> reservedInstanceVmFamilies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureVmFamily> premiumDiskVmFamilies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureVmFamily> savingsPlanVmFamilies = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> savingsPlanSupportedLocations = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> savingsPlanSupportedLocationsForPaas = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> reservedInstanceSupportedLocationsForIaas = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureOfferCode> savingsPlanSupportedOffers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.SqlPaaSTargetConfig> sqlSkus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.MigrateTargetType> reservedInstanceSqlTargets = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> reservedInstanceSupportedLocations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureCurrency> reservedInstanceSupportedCurrencies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureOfferCode> reservedInstanceSupportedOffers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureOfferCode> supportedOffers = null) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2Data MigrateSqlAssessmentV2Data(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? provisioningState = default(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState?), Azure.ResourceManager.Migrate.Models.MigrateOSLicense? osLicense = default(Azure.ResourceManager.Migrate.Models.MigrateOSLicense?), Azure.ResourceManager.Migrate.Models.AssessmentEnvironmentType? environmentType = default(Azure.ResourceManager.Migrate.Models.AssessmentEnvironmentType?), Azure.ResourceManager.Migrate.Models.EntityUptime entityUptime = null, Azure.ResourceManager.Migrate.Models.SqlOptimizationLogic? optimizationLogic = default(Azure.ResourceManager.Migrate.Models.SqlOptimizationLogic?), Azure.ResourceManager.Migrate.Models.AzureReservedInstance? reservedInstanceForVm = default(Azure.ResourceManager.Migrate.Models.AzureReservedInstance?), Azure.ResourceManager.Migrate.Models.AzureOfferCode? azureOfferCodeForVm = default(Azure.ResourceManager.Migrate.Models.AzureOfferCode?), string eaSubscriptionId = null, Azure.ResourceManager.Migrate.Models.SqlMISettings azureSqlManagedInstanceSettings = null, Azure.ResourceManager.Migrate.Models.SqlDBSettings azureSqlDatabaseSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureVmFamily> azureSqlVmInstanceSeries = null, Azure.ResourceManager.Migrate.Models.MultiSubnetIntent? multiSubnetIntent = default(Azure.ResourceManager.Migrate.Models.MultiSubnetIntent?), Azure.ResourceManager.Migrate.Models.AsyncCommitModeIntent? asyncCommitModeIntent = default(Azure.ResourceManager.Migrate.Models.AsyncCommitModeIntent?), bool? isInternetAccessAvailable = default(bool?), Azure.Core.AzureLocation? disasterRecoveryLocation = default(Azure.Core.AzureLocation?), bool? enableHadrAssessment = default(bool?), Azure.ResourceManager.Migrate.Models.AzureSecurityOfferingType? azureSecurityOfferingType = default(Azure.ResourceManager.Migrate.Models.AzureSecurityOfferingType?), Azure.ResourceManager.Migrate.Models.AzureReservedInstance? reservedInstance = default(Azure.ResourceManager.Migrate.Models.AzureReservedInstance?), Azure.ResourceManager.Migrate.Models.SqlServerLicense? sqlServerLicense = default(Azure.ResourceManager.Migrate.Models.SqlServerLicense?), Azure.ResourceManager.Migrate.Models.MigrateGroupType? groupType = default(Azure.ResourceManager.Migrate.Models.MigrateGroupType?), Azure.ResourceManager.Migrate.Models.AssessmentType? assessmentType = default(Azure.ResourceManager.Migrate.Models.AssessmentType?), Azure.Core.AzureLocation? azureLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Migrate.Models.AzureOfferCode? azureOfferCode = default(Azure.ResourceManager.Migrate.Models.AzureOfferCode?), Azure.ResourceManager.Migrate.Models.AzureCurrency? currency = default(Azure.ResourceManager.Migrate.Models.AzureCurrency?), double? scalingFactor = default(double?), Azure.ResourceManager.Migrate.Models.PercentileOfUtilization? percentile = default(Azure.ResourceManager.Migrate.Models.PercentileOfUtilization?), Azure.ResourceManager.Migrate.Models.AssessmentTimeRange? timeRange = default(Azure.ResourceManager.Migrate.Models.AssessmentTimeRange?), System.DateTimeOffset? perfDataStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? perfDataEndOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migrate.Models.AssessmentStage? stage = default(Azure.ResourceManager.Migrate.Models.AssessmentStage?), double? discountPercentage = default(double?), Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion?), double? confidenceRatingInPercentage = default(double?), System.DateTimeOffset? pricesQueriedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migrate.Models.AssessmentStatus? status = default(Azure.ResourceManager.Migrate.Models.AssessmentStatus?), string schemaVersion = null) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateSqlAssessmentV2SummaryData MigrateSqlAssessmentV2SummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.SqlAssessmentV2SummaryDetails> assessmentSummary = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionBySupportStatus = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionByServicePackInsight = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionBySqlVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionBySqlEdition = null, System.Collections.Generic.IReadOnlyDictionary<string, int> instanceDistributionBySizingCriterion = null, System.Collections.Generic.IReadOnlyDictionary<string, int> databaseDistributionBySizingCriterion = null, int? numberOfMachines = default(int?), int? numberOfSqlInstances = default(int?), int? numberOfSuccessfullyDiscoveredSqlInstances = default(int?), int? numberOfSqlDatabases = default(int?), int? numberOfFciInstances = default(int?), int? numberOfSqlAvailabilityGroups = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateSqlCollectorData MigrateSqlCollectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? provisioningState = default(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState?), Azure.ResourceManager.Migrate.Models.CollectorAgentPropertiesBase agentProperties = null, string discoverySiteId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migrate.MigrateVMwareCollectorData MigrateVMwareCollectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? provisioningState = default(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState?), Azure.ResourceManager.Migrate.Models.CollectorAgentPropertiesBase agentProperties = null, string discoverySiteId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrationGuidelineContext MigrationGuidelineContext(string contextKey = null, string contextValue = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.ProductSupportStatus ProductSupportStatus(string currentVersion = null, string servicePackStatus = null, string esuStatus = null, string supportStatus = null, int? eta = default(int?), string currentEsuYear = null, System.DateTimeOffset? mainstreamEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? extendedSupportEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? extendedSecurityUpdateYear1EndOn = default(System.DateTimeOffset?), System.DateTimeOffset? extendedSecurityUpdateYear2EndOn = default(System.DateTimeOffset?), System.DateTimeOffset? extendedSecurityUpdateYear3EndOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SharedResourcesDto SharedResourcesDto(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto> sharedDataDisks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto> sharedLogDisks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto> sharedTempDBDisks = null, int? numberOfMounts = default(int?), Azure.ResourceManager.Migrate.Models.AzureQuorumWitnessDtoQuorumWitnessType? quorumWitnessType = default(Azure.ResourceManager.Migrate.Models.AzureQuorumWitnessDtoQuorumWitnessType?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SqlAssessedNetworkAdapter SqlAssessedNetworkAdapter(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? suitability = default(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability?), Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail?), Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation?), double? monthlyBandwidthCosts = default(double?), double? netGigabytesTransmittedPerMonth = default(double?), string name = null, string displayName = null, string macAddress = null, System.Collections.Generic.IEnumerable<string> ipAddresses = null, double? megabytesPerSecondReceived = default(double?), double? megabytesPerSecondTransmitted = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssue SqlAssessmentMigrationIssue(string issueId = null, Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssueCategory? issueCategory = default(Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssueCategory?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.ImpactedAssessmentObject> impactedObjects = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SqlAssessmentV2IaasSuitabilityDetails SqlAssessmentV2IaasSuitabilityDetails(Azure.ResourceManager.Migrate.Models.AzureSqlIaasSkuDto azureSqlSku = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureSqlIaasSkuDto> replicaAzureSqlSku = null, Azure.ResourceManager.Migrate.Models.SharedResourcesDto sharedResources = null, double? monthlyComputeCost = default(double?), double? monthlyStorageCost = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.CostComponent> costComponents = null, Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? securitySuitability = default(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability?), bool? shouldProvisionReplicas = default(bool?), Azure.ResourceManager.Migrate.Models.SkuReplicationMode? skuReplicationMode = default(Azure.ResourceManager.Migrate.Models.SkuReplicationMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.SqlMigrationGuideline> migrationGuidelines = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoning> recommendationReasonings = null, Azure.ResourceManager.Migrate.Models.MigrateTargetType? migrationTargetPlatform = default(Azure.ResourceManager.Migrate.Models.MigrateTargetType?), Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? suitability = default(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssue> migrationIssues = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails SqlAssessmentV2PaasSuitabilityDetails(Azure.ResourceManager.Migrate.Models.AzureSqlPaasSkuDto azureSqlSku = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureSqlPaasSkuDto> replicaAzureSqlSku = null, Azure.ResourceManager.Migrate.Models.SharedResourcesDto sharedResources = null, double? monthlyComputeCost = default(double?), double? monthlyStorageCost = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.CostComponent> costComponents = null, Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? securitySuitability = default(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability?), bool? shouldProvisionReplicas = default(bool?), Azure.ResourceManager.Migrate.Models.SkuReplicationMode? skuReplicationMode = default(Azure.ResourceManager.Migrate.Models.SkuReplicationMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.SqlMigrationGuideline> migrationGuidelines = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoning> recommendationReasonings = null, Azure.ResourceManager.Migrate.Models.MigrateTargetType? migrationTargetPlatform = default(Azure.ResourceManager.Migrate.Models.MigrateTargetType?), Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? suitability = default(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssue> migrationIssues = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SqlAssessmentV2SummaryDetails SqlAssessmentV2SummaryDetails(System.Collections.Generic.IReadOnlyDictionary<string, int> suitabilitySummary = null, double? monthlyComputeCost = default(double?), double? monthlyStorageCost = default(double?), double? monthlyLicenseCost = default(double?), double? confidenceScore = default(double?), double? monthlySecurityCost = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SqlAvailabilityGroupDataOverview SqlAvailabilityGroupDataOverview(string availabilityGroupId = null, string availabilityGroupName = null, Azure.Core.ResourceIdentifier sqlAvailabilityGroupSdsArmId = null, string sqlAvailabilityGroupEntityId = null, string sqlAvailabilityReplicaId = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SqlAvailabilityReplicaSummary SqlAvailabilityReplicaSummary(int? numberOfSynchronousReadReplicas = default(int?), int? numberOfSynchronousNonReadReplicas = default(int?), int? numberOfAsynchronousReadReplicas = default(int?), int? numberOfAsynchronousNonReadReplicas = default(int?), int? numberOfPrimaryReplicas = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SqlFciMetadata SqlFciMetadata(Azure.ResourceManager.Migrate.Models.SqlFciMetadataState? state = default(Azure.ResourceManager.Migrate.Models.SqlFciMetadataState?), bool? isMultiSubnet = default(bool?), int? fciSharedDiskCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SqlMigrationGuideline SqlMigrationGuideline(string guidelineId = null, Azure.ResourceManager.Migrate.Models.SqlMigrationGuidelineCategory? migrationGuidelineCategory = default(Azure.ResourceManager.Migrate.Models.SqlMigrationGuidelineCategory?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.MigrationGuidelineContext> migrationGuidelineContext = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoning SqlRecommendationReasoning(string reasoningId = null, string reasoningString = null, string reasoningCategory = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoningContext> contextParameters = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoningContext SqlRecommendationReasoningContext(string contextKey = null, string contextValue = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.UltraDiskAssessmentConfig UltraDiskAssessmentConfig(string familyName = null, System.Collections.Generic.IEnumerable<string> targetLocations = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.VmFamilyConfig VmFamilyConfig(string familyName = null, System.Collections.Generic.IEnumerable<string> targetLocations = null, System.Collections.Generic.IEnumerable<string> category = null) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.WorkloadSummary WorkloadSummary(int? oracleInstances = default(int?), int? springApps = default(int?)) { throw null; }
    }
    public partial class AssessedDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedDataDisk>
    {
        internal AssessedDataDisk() { }
        public string DisplayName { get { throw null; } }
        public double? GigabytesProvisioned { get { throw null; } }
        public double? MegabytesPerSecondOfRead { get { throw null; } }
        public double? MegabytesPerSecondOfWrite { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public string Name { get { throw null; } }
        public double? NumberOfReadOperationsPerSecond { get { throw null; } }
        public double? NumberOfWriteOperationsPerSecond { get { throw null; } }
        public double? RecommendDiskThroughputInMbps { get { throw null; } }
        public double? RecommendedDiskIops { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureDiskSize? RecommendedDiskSize { get { throw null; } }
        public int? RecommendedDiskSizeGigabytes { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureDiskType? RecommendedDiskType { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.AssessedDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.AssessedDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedDisk>
    {
        internal AssessedDisk() { }
        public string DisplayName { get { throw null; } }
        public int? GigabytesForRecommendedDiskSize { get { throw null; } }
        public double? GigabytesProvisioned { get { throw null; } }
        public double? MegabytesPerSecondOfRead { get { throw null; } }
        public double? MegabytesPerSecondOfWrite { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public string Name { get { throw null; } }
        public double? NumberOfReadOperationsPerSecond { get { throw null; } }
        public double? NumberOfWriteOperationsPerSecond { get { throw null; } }
        public double? RecommendDiskThroughputInMbps { get { throw null; } }
        public double? RecommendedDiskIops { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureDiskSize? RecommendedDiskSize { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureDiskType? RecommendedDiskType { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.AssessedDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.AssessedDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessedMachineType : System.IEquatable<Azure.ResourceManager.Migrate.Models.AssessedMachineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessedMachineType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessedMachineType AssessedMachine { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessedMachineType AvsAssessedMachine { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessedMachineType SqlAssessedMachine { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessedMachineType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AssessedMachineType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AssessedMachineType left, Azure.ResourceManager.Migrate.Models.AssessedMachineType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AssessedMachineType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AssessedMachineType left, Azure.ResourceManager.Migrate.Models.AssessedMachineType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessedNetworkAdapter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedNetworkAdapter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedNetworkAdapter>
    {
        internal AssessedNetworkAdapter() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPAddresses { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public double? MegabytesPerSecondReceived { get { throw null; } }
        public double? MegabytesPerSecondTransmitted { get { throw null; } }
        public double? MonthlyBandwidthCosts { get { throw null; } }
        public double? NetGigabytesTransmittedPerMonth { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.AssessedNetworkAdapter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedNetworkAdapter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedNetworkAdapter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.AssessedNetworkAdapter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedNetworkAdapter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedNetworkAdapter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedNetworkAdapter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlInstanceDatabaseSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDatabaseSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDatabaseSummary>
    {
        internal AssessedSqlInstanceDatabaseSummary() { }
        public double? LargestDatabaseSizeInMB { get { throw null; } }
        public int? NumberOfUserDatabases { get { throw null; } }
        public double? TotalDatabaseSizeInMB { get { throw null; } }
        public int? TotalDiscoveredUserDatabases { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDatabaseSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDatabaseSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDatabaseSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDatabaseSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDatabaseSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDatabaseSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDatabaseSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlInstanceDiskDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDiskDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDiskDetails>
    {
        internal AssessedSqlInstanceDiskDetails() { }
        public string DiskId { get { throw null; } }
        public double? DiskSizeInMB { get { throw null; } }
        public double? MegabytesPerSecondOfRead { get { throw null; } }
        public double? MegabytesPerSecondOfWrite { get { throw null; } }
        public double? NumberOfReadOperationsPerSecond { get { throw null; } }
        public double? NumberOfWriteOperationsPerSecond { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDiskDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDiskDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDiskDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDiskDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDiskDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDiskDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceDiskDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlInstanceStorageDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceStorageDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceStorageDetails>
    {
        internal AssessedSqlInstanceStorageDetails() { }
        public double? DiskSizeInMB { get { throw null; } }
        public double? MegabytesPerSecondOfRead { get { throw null; } }
        public double? MegabytesPerSecondOfWrite { get { throw null; } }
        public double? NumberOfReadOperationsPerSecond { get { throw null; } }
        public double? NumberOfWriteOperationsPerSecond { get { throw null; } }
        public string StorageType { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceStorageDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceStorageDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceStorageDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceStorageDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceStorageDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceStorageDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceStorageDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlInstanceSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceSummary>
    {
        internal AssessedSqlInstanceSummary() { }
        public string InstanceId { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public bool? IsClustered { get { throw null; } }
        public bool? IsHighAvailabilityEnabled { get { throw null; } }
        public string SqlEdition { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.SqlFciState? SqlFciState { get { throw null; } }
        public string SqlInstanceEntityId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SqlInstanceSdsArmId { get { throw null; } }
        public string SqlVersion { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessedSqlInstanceSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentEnvironmentType : System.IEquatable<Azure.ResourceManager.Migrate.Models.AssessmentEnvironmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentEnvironmentType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessmentEnvironmentType Production { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentEnvironmentType Test { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AssessmentEnvironmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AssessmentEnvironmentType left, Azure.ResourceManager.Migrate.Models.AssessmentEnvironmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AssessmentEnvironmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AssessmentEnvironmentType left, Azure.ResourceManager.Migrate.Models.AssessmentEnvironmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessmentErrorSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessmentErrorSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessmentErrorSummary>
    {
        internal AssessmentErrorSummary() { }
        public Azure.ResourceManager.Migrate.Models.AssessmentType? AssessmentType { get { throw null; } }
        public int? Count { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.AssessmentErrorSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessmentErrorSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessmentErrorSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.AssessmentErrorSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessmentErrorSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessmentErrorSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessmentErrorSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentProjectStatus : System.IEquatable<Azure.ResourceManager.Migrate.Models.AssessmentProjectStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentProjectStatus(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessmentProjectStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentProjectStatus Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AssessmentProjectStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AssessmentProjectStatus left, Azure.ResourceManager.Migrate.Models.AssessmentProjectStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AssessmentProjectStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AssessmentProjectStatus left, Azure.ResourceManager.Migrate.Models.AssessmentProjectStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessmentReportDownloadUri : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessmentReportDownloadUri>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessmentReportDownloadUri>
    {
        internal AssessmentReportDownloadUri() { }
        public System.Uri AssessmentReportUri { get { throw null; } }
        public System.DateTimeOffset ExpireOn { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.AssessmentReportDownloadUri System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessmentReportDownloadUri>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AssessmentReportDownloadUri>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.AssessmentReportDownloadUri System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessmentReportDownloadUri>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessmentReportDownloadUri>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AssessmentReportDownloadUri>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentSizingCriterion : System.IEquatable<Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentSizingCriterion(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion AsOnPremises { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion PerformanceBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion left, Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion left, Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentStage : System.IEquatable<Azure.ResourceManager.Migrate.Models.AssessmentStage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentStage(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStage Approved { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStage InProgress { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStage UnderReview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AssessmentStage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AssessmentStage left, Azure.ResourceManager.Migrate.Models.AssessmentStage right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AssessmentStage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AssessmentStage left, Azure.ResourceManager.Migrate.Models.AssessmentStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentStatus : System.IEquatable<Azure.ResourceManager.Migrate.Models.AssessmentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentStatus(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStatus Created { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStatus OutDated { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStatus OutOfSync { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStatus Updated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AssessmentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AssessmentStatus left, Azure.ResourceManager.Migrate.Models.AssessmentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AssessmentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AssessmentStatus left, Azure.ResourceManager.Migrate.Models.AssessmentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentTimeRange : System.IEquatable<Azure.ResourceManager.Migrate.Models.AssessmentTimeRange>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentTimeRange(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessmentTimeRange Custom { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentTimeRange Day { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentTimeRange Month { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentTimeRange Week { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AssessmentTimeRange other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AssessmentTimeRange left, Azure.ResourceManager.Migrate.Models.AssessmentTimeRange right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AssessmentTimeRange (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AssessmentTimeRange left, Azure.ResourceManager.Migrate.Models.AssessmentTimeRange right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentType : System.IEquatable<Azure.ResourceManager.Migrate.Models.AssessmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessmentType AvsAssessment { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentType MachineAssessment { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentType SqlAssessment { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentType Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentType WebAppAssessment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AssessmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AssessmentType left, Azure.ResourceManager.Migrate.Models.AssessmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AssessmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AssessmentType left, Azure.ResourceManager.Migrate.Models.AssessmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AsyncCommitModeIntent : System.IEquatable<Azure.ResourceManager.Migrate.Models.AsyncCommitModeIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AsyncCommitModeIntent(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AsyncCommitModeIntent DisasterRecovery { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AsyncCommitModeIntent HighAvailability { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AsyncCommitModeIntent None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AsyncCommitModeIntent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AsyncCommitModeIntent left, Azure.ResourceManager.Migrate.Models.AsyncCommitModeIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AsyncCommitModeIntent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AsyncCommitModeIntent left, Azure.ResourceManager.Migrate.Models.AsyncCommitModeIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsAssessedDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AvsAssessedDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AvsAssessedDisk>
    {
        internal AvsAssessedDisk() { }
        public string DisplayName { get { throw null; } }
        public double? GigabytesProvisioned { get { throw null; } }
        public double? MegabytesPerSecondOfRead { get { throw null; } }
        public double? MegabytesPerSecondOfWrite { get { throw null; } }
        public string Name { get { throw null; } }
        public double? NumberOfReadOperationsPerSecond { get { throw null; } }
        public double? NumberOfWriteOperationsPerSecond { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.AvsAssessedDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AvsAssessedDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AvsAssessedDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.AvsAssessedDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AvsAssessedDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AvsAssessedDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AvsAssessedDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsAssessedNetworkAdapter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AvsAssessedNetworkAdapter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AvsAssessedNetworkAdapter>
    {
        internal AvsAssessedNetworkAdapter() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPAddresses { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public double? MegabytesPerSecondReceived { get { throw null; } }
        public double? MegabytesPerSecondTransmitted { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.AvsAssessedNetworkAdapter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AvsAssessedNetworkAdapter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AvsAssessedNetworkAdapter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.AvsAssessedNetworkAdapter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AvsAssessedNetworkAdapter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AvsAssessedNetworkAdapter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AvsAssessedNetworkAdapter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsNodeType : System.IEquatable<Azure.ResourceManager.Migrate.Models.AvsNodeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsNodeType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AvsNodeType AV36 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AvsNodeType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AvsNodeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AvsNodeType left, Azure.ResourceManager.Migrate.Models.AvsNodeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AvsNodeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AvsNodeType left, Azure.ResourceManager.Migrate.Models.AvsNodeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsSkuConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AvsSkuConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AvsSkuConfig>
    {
        public AvsSkuConfig() { }
        public Azure.ResourceManager.Migrate.Models.AvsNodeType? NodeType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> TargetLocations { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.AvsSkuConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AvsSkuConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AvsSkuConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.AvsSkuConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AvsSkuConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AvsSkuConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AvsSkuConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsSuitabilityExplanation : System.IEquatable<Azure.ResourceManager.Migrate.Models.AvsSuitabilityExplanation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsSuitabilityExplanation(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AvsSuitabilityExplanation NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AvsSuitabilityExplanation Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AvsSuitabilityExplanation UnsupportedLocationForSelectedNode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AvsSuitabilityExplanation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AvsSuitabilityExplanation left, Azure.ResourceManager.Migrate.Models.AvsSuitabilityExplanation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AvsSuitabilityExplanation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AvsSuitabilityExplanation left, Azure.ResourceManager.Migrate.Models.AvsSuitabilityExplanation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsVmSuitabilityDetail : System.IEquatable<Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsVmSuitabilityDetail(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityDetail None { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityDetail PercentageOfCoresUtilizedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityDetail PercentageOfCoresUtilizedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityDetail PercentageOfMemoryUtilizedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityDetail PercentageOfMemoryUtilizedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityDetail PercentageOfStorageUtilizedOutOfRange { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityDetail left, Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityDetail left, Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsVmSuitabilityExplanation : System.IEquatable<Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityExplanation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsVmSuitabilityExplanation(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityExplanation IPV6NotSupported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityExplanation NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityExplanation Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityExplanation UnsupportedOperatingSystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityExplanation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityExplanation left, Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityExplanation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityExplanation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityExplanation left, Azure.ResourceManager.Migrate.Models.AvsVmSuitabilityExplanation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureCurrency : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureCurrency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureCurrency(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency ARS { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency AUD { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency BRL { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency CAD { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency CHF { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency CNY { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency DKK { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency EUR { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency GBP { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency HKD { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency IDR { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency INR { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency JPY { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency KRW { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency MXN { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency MYR { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency NOK { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency NZD { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency RUB { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency SAR { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency SEK { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency TRY { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency TWD { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency USD { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureCurrency ZAR { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureCurrency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureCurrency left, Azure.ResourceManager.Migrate.Models.AzureCurrency right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureCurrency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureCurrency left, Azure.ResourceManager.Migrate.Models.AzureCurrency right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureDiskSize : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureDiskSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureDiskSize(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP10 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP15 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP20 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP30 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP40 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP50 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP6 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP60 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP70 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP80 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS10 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS15 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS20 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS30 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS40 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS50 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS6 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS60 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS70 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS80 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSsdE1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSsdE10 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSsdE15 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSsdE2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSsdE20 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSsdE3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSsdE30 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSsdE4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSsdE40 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSsdE50 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSsdE6 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSsdE60 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSsdE70 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSsdE80 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize Ultra { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureDiskSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureDiskSize left, Azure.ResourceManager.Migrate.Models.AzureDiskSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureDiskSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureDiskSize left, Azure.ResourceManager.Migrate.Models.AzureDiskSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureDiskSuitabilityDetail : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureDiskSuitabilityDetail(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail DiskGigabytesConsumedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail DiskGigabytesConsumedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail DiskGigabytesProvisionedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail DiskGigabytesProvisionedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail MegabytesPerSecondOfReadMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail MegabytesPerSecondOfReadOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail MegabytesPerSecondOfWriteMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail MegabytesPerSecondOfWriteOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail None { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail NumberOfReadOperationsPerSecondMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail NumberOfReadOperationsPerSecondOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail NumberOfWriteOperationsPerSecondMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail NumberOfWriteOperationsPerSecondOutOfRange { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail left, Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail left, Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureDiskSuitabilityExplanation : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureDiskSuitabilityExplanation(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation DiskSizeGreaterThanSupported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation InternalErrorOccurredForDiskEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation NoDiskSizeFoundForSelectedRedundancy { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation NoDiskSizeFoundInSelectedLocation { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation NoEAPriceFoundForDiskSize { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation NoSuitableDiskSizeForIops { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation NoSuitableDiskSizeForThroughput { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation left, Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation left, Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureDiskType : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureDiskType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskType Premium { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskType PremiumV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskType Standard { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskType StandardOrPremium { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskType StandardSsd { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskType Ultra { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureDiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureDiskType left, Azure.ResourceManager.Migrate.Models.AzureDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureDiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureDiskType left, Azure.ResourceManager.Migrate.Models.AzureDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureHybridUseBenefit : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureHybridUseBenefit(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit No { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit left, Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit left, Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureManagedDiskSkuDto : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto>
    {
        internal AzureManagedDiskSkuDto() { }
        public Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskRedundancy? DiskRedundancy { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureDiskSize? DiskSize { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskType? DiskType { get { throw null; } }
        public double? RecommendedIops { get { throw null; } }
        public double? RecommendedSizeInGib { get { throw null; } }
        public double? RecommendedThroughputInMbps { get { throw null; } }
        public double? StorageCost { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureManagedDiskSkuDtoDiskRedundancy : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureManagedDiskSkuDtoDiskRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskRedundancy Lrs { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskRedundancy Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskRedundancy Zrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskRedundancy left, Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskRedundancy left, Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureManagedDiskSkuDtoDiskType : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureManagedDiskSkuDtoDiskType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskType Premium { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskType PremiumV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskType Standard { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskType StandardOrPremium { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskType StandardSsd { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskType Ultra { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskType left, Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskType left, Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDtoDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureNetworkAdapterSuitabilityDetail : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureNetworkAdapterSuitabilityDetail(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail MegabytesOfDataReceivedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail MegabytesOfDataReceivedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail MegabytesOfDataTransmittedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail MegabytesOfDataTransmittedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail left, Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail left, Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureNetworkAdapterSuitabilityExplanation : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureNetworkAdapterSuitabilityExplanation(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation InternalErrorOccurred { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation left, Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation left, Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureOfferCode : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureOfferCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureOfferCode(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode EA { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0003P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0022P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0023P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0025P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0029P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0036P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0044P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0059P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0060P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0062P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0063P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0064P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0111P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0120P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0121P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0122P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0123P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0124P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0125P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0126P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0127P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0128P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0129P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0130P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0144P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0148P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0149P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZR0243P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZRDE0003P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZRDE0044P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSAZRUSGOV0003P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSMCAZR0044P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSMCAZR0059P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSMCAZR0060P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSMCAZR0063P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSMCAZR0120P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSMCAZR0121P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSMCAZR0125P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode MSMCAZR0128P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode SavingsPlan1Year { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode SavingsPlan3Year { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureOfferCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureOfferCode left, Azure.ResourceManager.Migrate.Models.AzureOfferCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureOfferCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureOfferCode left, Azure.ResourceManager.Migrate.Models.AzureOfferCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzurePricingTier : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzurePricingTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzurePricingTier(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzurePricingTier Basic { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzurePricingTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzurePricingTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzurePricingTier left, Azure.ResourceManager.Migrate.Models.AzurePricingTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzurePricingTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzurePricingTier left, Azure.ResourceManager.Migrate.Models.AzurePricingTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureQuorumWitnessDtoQuorumWitnessType : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureQuorumWitnessDtoQuorumWitnessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureQuorumWitnessDtoQuorumWitnessType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureQuorumWitnessDtoQuorumWitnessType Cloud { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureQuorumWitnessDtoQuorumWitnessType Disk { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureQuorumWitnessDtoQuorumWitnessType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureQuorumWitnessDtoQuorumWitnessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureQuorumWitnessDtoQuorumWitnessType left, Azure.ResourceManager.Migrate.Models.AzureQuorumWitnessDtoQuorumWitnessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureQuorumWitnessDtoQuorumWitnessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureQuorumWitnessDtoQuorumWitnessType left, Azure.ResourceManager.Migrate.Models.AzureQuorumWitnessDtoQuorumWitnessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureReservedInstance : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureReservedInstance>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureReservedInstance(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureReservedInstance None { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureReservedInstance RI1Year { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureReservedInstance RI3Year { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureReservedInstance other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureReservedInstance left, Azure.ResourceManager.Migrate.Models.AzureReservedInstance right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureReservedInstance (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureReservedInstance left, Azure.ResourceManager.Migrate.Models.AzureReservedInstance right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureSecurityOfferingType : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureSecurityOfferingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureSecurityOfferingType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureSecurityOfferingType MDC { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureSecurityOfferingType NO { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureSecurityOfferingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureSecurityOfferingType left, Azure.ResourceManager.Migrate.Models.AzureSecurityOfferingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureSecurityOfferingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureSecurityOfferingType left, Azure.ResourceManager.Migrate.Models.AzureSecurityOfferingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureSqlDataBaseType : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureSqlDataBaseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureSqlDataBaseType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlDataBaseType Automatic { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlDataBaseType ElasticPool { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlDataBaseType SingleDatabase { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlDataBaseType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureSqlDataBaseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureSqlDataBaseType left, Azure.ResourceManager.Migrate.Models.AzureSqlDataBaseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureSqlDataBaseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureSqlDataBaseType left, Azure.ResourceManager.Migrate.Models.AzureSqlDataBaseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureSqlIaasSkuDto : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AzureSqlIaasSkuDto>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AzureSqlIaasSkuDto>
    {
        internal AzureSqlIaasSkuDto() { }
        public Azure.ResourceManager.Migrate.Models.MigrateTargetType? AzureSqlTargetType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto> DataDiskSizes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto> LogDiskSizes { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureVmSkuDto VirtualMachineSize { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.AzureSqlIaasSkuDto System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AzureSqlIaasSkuDto>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AzureSqlIaasSkuDto>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.AzureSqlIaasSkuDto System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AzureSqlIaasSkuDto>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AzureSqlIaasSkuDto>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AzureSqlIaasSkuDto>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureSqlInstanceType : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureSqlInstanceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureSqlInstanceType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlInstanceType Automatic { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlInstanceType InstancePools { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlInstanceType SingleInstance { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlInstanceType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureSqlInstanceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureSqlInstanceType left, Azure.ResourceManager.Migrate.Models.AzureSqlInstanceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureSqlInstanceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureSqlInstanceType left, Azure.ResourceManager.Migrate.Models.AzureSqlInstanceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureSqlPaasSkuDto : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AzureSqlPaasSkuDto>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AzureSqlPaasSkuDto>
    {
        internal AzureSqlPaasSkuDto() { }
        public Azure.ResourceManager.Migrate.Models.MigrateComputeTier? AzureSqlComputeTier { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateHardwareGeneration? AzureSqlHardwareGeneration { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier? AzureSqlServiceTier { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateTargetType? AzureSqlTargetType { get { throw null; } }
        public int? Cores { get { throw null; } }
        public double? PredictedDataSizeInMB { get { throw null; } }
        public double? PredictedLogSizeInMB { get { throw null; } }
        public double? StorageMaxSizeInMB { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.AzureSqlPaasSkuDto System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AzureSqlPaasSkuDto>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AzureSqlPaasSkuDto>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.AzureSqlPaasSkuDto System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AzureSqlPaasSkuDto>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AzureSqlPaasSkuDto>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AzureSqlPaasSkuDto>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureSqlPurchaseModel : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureSqlPurchaseModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureSqlPurchaseModel(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlPurchaseModel Dtu { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlPurchaseModel Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlPurchaseModel VCore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureSqlPurchaseModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureSqlPurchaseModel left, Azure.ResourceManager.Migrate.Models.AzureSqlPurchaseModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureSqlPurchaseModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureSqlPurchaseModel left, Azure.ResourceManager.Migrate.Models.AzureSqlPurchaseModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureSqlServiceTier : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureSqlServiceTier(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier Automatic { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier BusinessCritical { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier HyperScale { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier left, Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier left, Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureStorageRedundancy : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureStorageRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy GeoRedundant { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy LocallyRedundant { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy ReadAccessGeoRedundant { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy left, Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy left, Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureVmFamily : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureVmFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureVmFamily(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Av2Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily BasicA0A4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Dadsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Dasv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Dasv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Dav4Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily DCSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Ddsv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Ddsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Ddv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Ddv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily DSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily DSSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily DSv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Dsv3Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Dsv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Dsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Dv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Dv3Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Dv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Dv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Eadsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Easv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Easv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Eav4Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Ebdsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Ebsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Edsv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Edsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Edv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Edv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Esv3Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Esv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Esv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Ev3Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Ev4Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Ev5Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily FSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily FsSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Fsv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily GSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily GSSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily HSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily LsSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Lsv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Mdsv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily MSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Msv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Mv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily StandardA0A7 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily StandardA8A11 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureVmFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureVmFamily left, Azure.ResourceManager.Migrate.Models.AzureVmFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureVmFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureVmFamily left, Azure.ResourceManager.Migrate.Models.AzureVmFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureVmSize : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureVmSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureVmSize(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize BasicA0 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize BasicA1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize BasicA2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize BasicA3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize BasicA4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA0 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA10 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA11 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA1V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA2MV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA2V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA4MV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA4V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA6 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA7 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA8 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA8MV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA8V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA9 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD11 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD11V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD12 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD12V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD13 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD13V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD14 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD14V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD15V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD16AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD16AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD16AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD16AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD16DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD16DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD16DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD16DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD16SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD16SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD16SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD16V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD16V4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD16V5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD1V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2V4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2V5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD32AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD32AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD32AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD32AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD32DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD32DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD32DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD32DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD32SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD32SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD32SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD32V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD32V4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD32V5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD3V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD48AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD48AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD48AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD48AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD48DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD48DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD48DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD48DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD48SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD48SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD48V4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD48V5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4V4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4V5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD5V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD64AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD64AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD64AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD64AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD64DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD64DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD64DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD64DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD64SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD64SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD64SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD64V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD64V4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD64V5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD8AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD8AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD8AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD8AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD8DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD8DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD8DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD8DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD8SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD8SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD8SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD8V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD8V4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD8V5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD96AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD96AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD96AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD96AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD96DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD96DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD96SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD96V5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDC2S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDC4S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS11 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS111V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS11V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS12 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS121V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS122V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS12V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS13 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS132V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS134V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS13V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS14 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS144V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS148V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS14V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS15V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS1V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS2V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS3V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS4V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS5V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE104IdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE104IdV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE104IsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE104IV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE164AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE164AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE164AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE164DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE164DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE164SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE164SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE164SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE168AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE168AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE168AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE168DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE168DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE168SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE168SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE168SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16V4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16V5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE20AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE20AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE20AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE20AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE20DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE20DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE20DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE20DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE20SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE20SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE20SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE20V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE20V4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE20V5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2V4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2V5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE3216AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE3216AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE3216AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE3216DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE3216DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE3216SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE3216SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE3216SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE328AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE328AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE328AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE328DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE328DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE328SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE328SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE328SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32V4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32V5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE42AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE42AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE42AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE42DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE42DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE42SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE42SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE42SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE48AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE48AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE48AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE48AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE48BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE48BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE48DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE48DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE48DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE48DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE48SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE48SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE48SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE48V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE48V4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE48V5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4V4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4V5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE6416AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE6416AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE6416AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE6416DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE6416DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE6416SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE6416SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE6416SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE6432AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE6432AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE6432AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE6432DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE6432DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE6432SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE6432SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE6432SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64IsV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64IV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64V4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64V5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE80IdsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE80IsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE82AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE82AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE82AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE82DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE82DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE82SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE82SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE82SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE84AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE84AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE84AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE84DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE84DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE84SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE84SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE84SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8V4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8V5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE9624AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE9624AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE9624AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE9624DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE9624SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE9648AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE9648AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE9648AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE9648DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE9648SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE96AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE96AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE96AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE96AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE96DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE96DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE96SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE96V5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF16 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF16S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF16SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF1S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF2S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF2SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF32SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF48SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF4S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF4SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF64SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF72SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF8 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF8S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF8SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardG1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardG2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardG3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardG4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardG5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardGS1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardGS2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardGS3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardGS4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardGS44 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardGS48 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardGS5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardGS516 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardGS58 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardH16 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardH16M { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardH16Mr { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardH16R { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardH8 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardH8M { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardL16S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardL16SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardL32S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardL32SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardL48SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardL4S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardL64SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardL80SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardL8S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardL8SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM128 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM12832Ms { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM12864Ms { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM128DmsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM128DsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM128M { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM128Ms { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM128MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM128S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM128SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM164Ms { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM168Ms { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM16Ms { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM192IdmsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM192IdsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM192ImsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM192IsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM208MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM208SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM3216Ms { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM328Ms { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM32DmsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM32Ls { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM32Ms { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM32MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM32Ts { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM416208MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM416208SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM416MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM416SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM64 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM6416Ms { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM6432Ms { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM64DmsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM64DsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM64Ls { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM64M { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM64Ms { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM64MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM64S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM64SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM82Ms { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM84Ms { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM8Ms { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureVmSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureVmSize left, Azure.ResourceManager.Migrate.Models.AzureVmSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureVmSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureVmSize left, Azure.ResourceManager.Migrate.Models.AzureVmSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureVmSkuDto : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AzureVmSkuDto>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AzureVmSkuDto>
    {
        internal AzureVmSkuDto() { }
        public int? AvailableCores { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureVmSize? AzureSkuName { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureVmFamily? AzureVmFamily { get { throw null; } }
        public int? Cores { get { throw null; } }
        public int? MaxNetworkInterfaces { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.AzureVmSkuDto System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AzureVmSkuDto>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.AzureVmSkuDto>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.AzureVmSkuDto System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AzureVmSkuDto>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AzureVmSkuDto>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.AzureVmSkuDto>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureVmSuitabilityDetail : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureVmSuitabilityDetail(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail CannotReportBandwidthCosts { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail CannotReportComputeCost { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail CannotReportStorageCost { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail None { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail PercentageOfCoresUtilizedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail PercentageOfCoresUtilizedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail PercentageOfMemoryUtilizedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail PercentageOfMemoryUtilizedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail RecommendedSizeHasLessNetworkAdapters { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail left, Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail left, Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureVmSuitabilityExplanation : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureVmSuitabilityExplanation(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation BootTypeNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation BootTypeUnknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckCentOSVersion { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckCoreOSLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckDebianLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckOpenSuseLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckOracleLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckRedHatLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckSuseLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckUbuntuLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckWindowsServer2008R2Version { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation EndorsedWithConditionsLinuxDistributions { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation GuestOperatingSystemArchitectureNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation GuestOperatingSystemNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation GuestOperatingSystemUnknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation InternalErrorOccurredDuringComputeEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation InternalErrorOccurredDuringNetworkEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation InternalErrorOccurredDuringStorageEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation MoreDisksThanSupported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoEAPriceFoundForVmSize { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoGuestOperatingSystemConditionallySupported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoSuitableVmSizeFound { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoVmSizeForBasicPricingTier { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoVmSizeForSelectedAzureLocation { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoVmSizeForSelectedPricingTier { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoVmSizeForStandardPricingTier { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoVmSizeFoundForOfferCurrencyReservedInstance { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoVmSizeInSelectedFamilyFound { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoVmSizeSupportsNetworkPerformance { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoVmSizeSupportsStoragePerformance { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation OneOrMoreAdaptersNotSuitable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation OneOrMoreDisksNotSuitable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation UnendorsedLinuxDistributions { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation WindowsClientVersionsConditionallySupported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation WindowsOSNoLongerUnderMSSupport { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation WindowsServerVersionConditionallySupported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation WindowsServerVersionsSupportedWithCaveat { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation left, Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation left, Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CollectorAgentPropertiesBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.CollectorAgentPropertiesBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CollectorAgentPropertiesBase>
    {
        public CollectorAgentPropertiesBase() { }
        public string Id { get { throw null; } set { } }
        public System.DateTimeOffset? LastHeartbeatOn { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.CollectorAgentSpnPropertiesBase SpnDetails { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.Migrate.Models.CollectorAgentPropertiesBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.CollectorAgentPropertiesBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.CollectorAgentPropertiesBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.CollectorAgentPropertiesBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CollectorAgentPropertiesBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CollectorAgentPropertiesBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CollectorAgentPropertiesBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CollectorAgentSpnPropertiesBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.CollectorAgentSpnPropertiesBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CollectorAgentSpnPropertiesBase>
    {
        public CollectorAgentSpnPropertiesBase() { }
        public string ApplicationId { get { throw null; } set { } }
        public string Audience { get { throw null; } set { } }
        public string Authority { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.Migrate.Models.CollectorAgentSpnPropertiesBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.CollectorAgentSpnPropertiesBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.CollectorAgentSpnPropertiesBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.CollectorAgentSpnPropertiesBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CollectorAgentSpnPropertiesBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CollectorAgentSpnPropertiesBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CollectorAgentSpnPropertiesBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CompatibilityLevel : System.IEquatable<Azure.ResourceManager.Migrate.Models.CompatibilityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CompatibilityLevel(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.CompatibilityLevel CompatLevel100 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.CompatibilityLevel CompatLevel110 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.CompatibilityLevel CompatLevel120 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.CompatibilityLevel CompatLevel130 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.CompatibilityLevel CompatLevel140 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.CompatibilityLevel CompatLevel150 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.CompatibilityLevel CompatLevel80 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.CompatibilityLevel CompatLevel90 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.CompatibilityLevel Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.CompatibilityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.CompatibilityLevel left, Azure.ResourceManager.Migrate.Models.CompatibilityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.CompatibilityLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.CompatibilityLevel left, Azure.ResourceManager.Migrate.Models.CompatibilityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CostComponent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.CostComponent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CostComponent>
    {
        public CostComponent() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.CostComponentName? Name { get { throw null; } }
        public double? Value { get { throw null; } set { } }
        Azure.ResourceManager.Migrate.Models.CostComponent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.CostComponent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.CostComponent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.CostComponent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CostComponent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CostComponent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.CostComponent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CostComponentName : System.IEquatable<Azure.ResourceManager.Migrate.Models.CostComponentName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CostComponentName(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.CostComponentName MonthlyAzureHybridCostSavings { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.CostComponentName MonthlyPremiumV2StorageCost { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.CostComponentName MonthlySecurityCost { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.CostComponentName Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.CostComponentName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.CostComponentName left, Azure.ResourceManager.Migrate.Models.CostComponentName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.CostComponentName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.CostComponentName left, Azure.ResourceManager.Migrate.Models.CostComponentName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityUptime : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.EntityUptime>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.EntityUptime>
    {
        public EntityUptime() { }
        public int? DaysPerMonth { get { throw null; } set { } }
        public int? HoursPerDay { get { throw null; } set { } }
        Azure.ResourceManager.Migrate.Models.EntityUptime System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.EntityUptime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.EntityUptime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.EntityUptime System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.EntityUptime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.EntityUptime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.EntityUptime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FttAndRaidLevel : System.IEquatable<Azure.ResourceManager.Migrate.Models.FttAndRaidLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FttAndRaidLevel(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.FttAndRaidLevel Ftt1Raid1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.FttAndRaidLevel Ftt1Raid5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.FttAndRaidLevel Ftt2Raid1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.FttAndRaidLevel Ftt2Raid6 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.FttAndRaidLevel Ftt3Raid1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.FttAndRaidLevel Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.FttAndRaidLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.FttAndRaidLevel left, Azure.ResourceManager.Migrate.Models.FttAndRaidLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.FttAndRaidLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.FttAndRaidLevel left, Azure.ResourceManager.Migrate.Models.FttAndRaidLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GuestOperatingSystemArchitecture : System.IEquatable<Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GuestOperatingSystemArchitecture(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture X64 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture X86 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture left, Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture left, Azure.ResourceManager.Migrate.Models.GuestOperatingSystemArchitecture right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImpactedAssessmentObject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ImpactedAssessmentObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ImpactedAssessmentObject>
    {
        internal ImpactedAssessmentObject() { }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.ImpactedAssessmentObject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ImpactedAssessmentObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ImpactedAssessmentObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.ImpactedAssessmentObject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ImpactedAssessmentObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ImpactedAssessmentObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ImpactedAssessmentObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineBootType : System.IEquatable<Azure.ResourceManager.Migrate.Models.MachineBootType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineBootType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MachineBootType Bios { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MachineBootType Efi { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MachineBootType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MachineBootType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MachineBootType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MachineBootType left, Azure.ResourceManager.Migrate.Models.MachineBootType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MachineBootType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MachineBootType left, Azure.ResourceManager.Migrate.Models.MachineBootType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrateAssessmentProjectPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateAssessmentProjectPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateAssessmentProjectPatch>
    {
        public MigrateAssessmentProjectPatch() { }
        public string AssessmentSolutionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CustomerStorageAccountArmId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CustomerWorkspaceId { get { throw null; } set { } }
        public string CustomerWorkspaceLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AssessmentProjectStatus? ProjectStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrateProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.MigrateAssessmentProjectPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateAssessmentProjectPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateAssessmentProjectPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateAssessmentProjectPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateAssessmentProjectPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateAssessmentProjectPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateAssessmentProjectPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrateCloudSuitability : System.IEquatable<Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrateCloudSuitability(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability ConditionallySuitable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability NotSuitable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability ReadinessUnknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability Suitable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability left, Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability left, Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrateComputeTier : System.IEquatable<Azure.ResourceManager.Migrate.Models.MigrateComputeTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrateComputeTier(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateComputeTier Automatic { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateComputeTier Provisioned { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateComputeTier Serverless { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateComputeTier Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MigrateComputeTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MigrateComputeTier left, Azure.ResourceManager.Migrate.Models.MigrateComputeTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrateComputeTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MigrateComputeTier left, Azure.ResourceManager.Migrate.Models.MigrateComputeTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrateDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateDisk>
    {
        internal MigrateDisk() { }
        public string DisplayName { get { throw null; } }
        public double? GigabytesAllocated { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.MigrateDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrateError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateError>
    {
        internal MigrateError() { }
        public string AgentScenario { get { throw null; } }
        public string ApplianceName { get { throw null; } }
        public string Code { get { throw null; } }
        public int? Id { get { throw null; } }
        public string ImpactedAssessmentType { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> MessageParameters { get { throw null; } }
        public string PossibleCauses { get { throw null; } }
        public string RecommendedAction { get { throw null; } }
        public string RunAsAccountId { get { throw null; } }
        public string Severity { get { throw null; } }
        public string SummaryMessage { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.MigrateError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrateGroupStatus : System.IEquatable<Azure.ResourceManager.Migrate.Models.MigrateGroupStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrateGroupStatus(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateGroupStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateGroupStatus Created { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateGroupStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateGroupStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateGroupStatus Updated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MigrateGroupStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MigrateGroupStatus left, Azure.ResourceManager.Migrate.Models.MigrateGroupStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrateGroupStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MigrateGroupStatus left, Azure.ResourceManager.Migrate.Models.MigrateGroupStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrateGroupType : System.IEquatable<Azure.ResourceManager.Migrate.Models.MigrateGroupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrateGroupType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateGroupType Default { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateGroupType Import { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MigrateGroupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MigrateGroupType left, Azure.ResourceManager.Migrate.Models.MigrateGroupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrateGroupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MigrateGroupType left, Azure.ResourceManager.Migrate.Models.MigrateGroupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrateGroupUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateContent>
    {
        public MigrateGroupUpdateContent() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrateGroupUpdateOperationType : System.IEquatable<Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrateGroupUpdateOperationType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateOperationType Add { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateOperationType Remove { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateOperationType left, Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateOperationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateOperationType left, Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrateGroupUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateProperties>
    {
        public MigrateGroupUpdateProperties() { }
        public System.Collections.Generic.IList<string> Machines { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateOperationType? OperationType { get { throw null; } set { } }
        Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateGroupUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrateHardwareGeneration : System.IEquatable<Azure.ResourceManager.Migrate.Models.MigrateHardwareGeneration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrateHardwareGeneration(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateHardwareGeneration Automatic { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateHardwareGeneration DCSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateHardwareGeneration Fsv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateHardwareGeneration Gen5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateHardwareGeneration MSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateHardwareGeneration Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MigrateHardwareGeneration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MigrateHardwareGeneration left, Azure.ResourceManager.Migrate.Models.MigrateHardwareGeneration right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrateHardwareGeneration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MigrateHardwareGeneration left, Azure.ResourceManager.Migrate.Models.MigrateHardwareGeneration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrateNetworkAdapter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateNetworkAdapter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateNetworkAdapter>
    {
        internal MigrateNetworkAdapter() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPAddresses { get { throw null; } }
        public string MacAddress { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.MigrateNetworkAdapter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateNetworkAdapter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrateNetworkAdapter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrateNetworkAdapter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateNetworkAdapter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateNetworkAdapter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrateNetworkAdapter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrateOSLicense : System.IEquatable<Azure.ResourceManager.Migrate.Models.MigrateOSLicense>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrateOSLicense(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateOSLicense No { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateOSLicense Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateOSLicense Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MigrateOSLicense other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MigrateOSLicense left, Azure.ResourceManager.Migrate.Models.MigrateOSLicense right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrateOSLicense (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MigrateOSLicense left, Azure.ResourceManager.Migrate.Models.MigrateOSLicense right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigratePrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigratePrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigratePrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigratePrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigratePrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigratePrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigratePrivateLinkServiceConnectionState>
    {
        public MigratePrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigratePrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        Azure.ResourceManager.Migrate.Models.MigratePrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigratePrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigratePrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigratePrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigratePrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigratePrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigratePrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrateProvisioningState : System.IEquatable<Azure.ResourceManager.Migrate.Models.MigrateProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrateProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState left, Azure.ResourceManager.Migrate.Models.MigrateProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrateProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MigrateProvisioningState left, Azure.ResourceManager.Migrate.Models.MigrateProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrateTargetType : System.IEquatable<Azure.ResourceManager.Migrate.Models.MigrateTargetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrateTargetType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MigrateTargetType AzureSqlDatabase { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateTargetType AzureSqlManagedInstance { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateTargetType AzureSqlVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateTargetType AzureVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateTargetType Recommended { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MigrateTargetType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MigrateTargetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MigrateTargetType left, Azure.ResourceManager.Migrate.Models.MigrateTargetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MigrateTargetType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MigrateTargetType left, Azure.ResourceManager.Migrate.Models.MigrateTargetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrationGuidelineContext : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrationGuidelineContext>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrationGuidelineContext>
    {
        internal MigrationGuidelineContext() { }
        public string ContextKey { get { throw null; } }
        public string ContextValue { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.MigrationGuidelineContext System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrationGuidelineContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.MigrationGuidelineContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.MigrationGuidelineContext System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrationGuidelineContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrationGuidelineContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.MigrationGuidelineContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MultiSubnetIntent : System.IEquatable<Azure.ResourceManager.Migrate.Models.MultiSubnetIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MultiSubnetIntent(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MultiSubnetIntent DisasterRecovery { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MultiSubnetIntent HighAvailability { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MultiSubnetIntent None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MultiSubnetIntent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MultiSubnetIntent left, Azure.ResourceManager.Migrate.Models.MultiSubnetIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MultiSubnetIntent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MultiSubnetIntent left, Azure.ResourceManager.Migrate.Models.MultiSubnetIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PercentileOfUtilization : System.IEquatable<Azure.ResourceManager.Migrate.Models.PercentileOfUtilization>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PercentileOfUtilization(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.PercentileOfUtilization Percentile50 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.PercentileOfUtilization Percentile90 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.PercentileOfUtilization Percentile95 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.PercentileOfUtilization Percentile99 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.PercentileOfUtilization other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.PercentileOfUtilization left, Azure.ResourceManager.Migrate.Models.PercentileOfUtilization right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.PercentileOfUtilization (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.PercentileOfUtilization left, Azure.ResourceManager.Migrate.Models.PercentileOfUtilization right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProcessorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ProcessorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ProcessorInfo>
    {
        public ProcessorInfo() { }
        public string Name { get { throw null; } set { } }
        public int? NumberOfCoresPerSocket { get { throw null; } set { } }
        public int? NumberOfSockets { get { throw null; } set { } }
        Azure.ResourceManager.Migrate.Models.ProcessorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ProcessorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ProcessorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.ProcessorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ProcessorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ProcessorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ProcessorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProductSupportStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ProductSupportStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ProductSupportStatus>
    {
        internal ProductSupportStatus() { }
        public string CurrentEsuYear { get { throw null; } }
        public string CurrentVersion { get { throw null; } }
        public string EsuStatus { get { throw null; } }
        public int? Eta { get { throw null; } }
        public System.DateTimeOffset? ExtendedSecurityUpdateYear1EndOn { get { throw null; } }
        public System.DateTimeOffset? ExtendedSecurityUpdateYear2EndOn { get { throw null; } }
        public System.DateTimeOffset? ExtendedSecurityUpdateYear3EndOn { get { throw null; } }
        public System.DateTimeOffset? ExtendedSupportEndOn { get { throw null; } }
        public System.DateTimeOffset? MainstreamEndOn { get { throw null; } }
        public string ServicePackStatus { get { throw null; } }
        public string SupportStatus { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.ProductSupportStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ProductSupportStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.ProductSupportStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.ProductSupportStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ProductSupportStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ProductSupportStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.ProductSupportStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendedSuitability : System.IEquatable<Azure.ResourceManager.Migrate.Models.RecommendedSuitability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendedSuitability(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.RecommendedSuitability ConditionallySuitableForSqlDB { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.RecommendedSuitability ConditionallySuitableForSqlMI { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.RecommendedSuitability ConditionallySuitableForSqlVm { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.RecommendedSuitability ConditionallySuitableForVm { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.RecommendedSuitability NotSuitable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.RecommendedSuitability PotentiallySuitableForVm { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.RecommendedSuitability ReadinessUnknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.RecommendedSuitability SuitableForSqlDB { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.RecommendedSuitability SuitableForSqlMI { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.RecommendedSuitability SuitableForSqlVm { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.RecommendedSuitability SuitableForVm { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.RecommendedSuitability Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.RecommendedSuitability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.RecommendedSuitability left, Azure.ResourceManager.Migrate.Models.RecommendedSuitability right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.RecommendedSuitability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.RecommendedSuitability left, Azure.ResourceManager.Migrate.Models.RecommendedSuitability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SharedResourcesDto : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SharedResourcesDto>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SharedResourcesDto>
    {
        internal SharedResourcesDto() { }
        public int? NumberOfMounts { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureQuorumWitnessDtoQuorumWitnessType? QuorumWitnessType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto> SharedDataDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto> SharedLogDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.AzureManagedDiskSkuDto> SharedTempDBDisks { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.SharedResourcesDto System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SharedResourcesDto>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SharedResourcesDto>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.SharedResourcesDto System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SharedResourcesDto>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SharedResourcesDto>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SharedResourcesDto>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuReplicationMode : System.IEquatable<Azure.ResourceManager.Migrate.Models.SkuReplicationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuReplicationMode(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SkuReplicationMode ActiveGeoReplication { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SkuReplicationMode FailoverGroupInstance { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SkuReplicationMode NotApplicable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.SkuReplicationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.SkuReplicationMode left, Azure.ResourceManager.Migrate.Models.SkuReplicationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.SkuReplicationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.SkuReplicationMode left, Azure.ResourceManager.Migrate.Models.SkuReplicationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlAssessedNetworkAdapter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAssessedNetworkAdapter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessedNetworkAdapter>
    {
        internal SqlAssessedNetworkAdapter() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPAddresses { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public double? MegabytesPerSecondReceived { get { throw null; } }
        public double? MegabytesPerSecondTransmitted { get { throw null; } }
        public double? MonthlyBandwidthCosts { get { throw null; } }
        public string Name { get { throw null; } }
        public double? NetGigabytesTransmittedPerMonth { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.SqlAssessedNetworkAdapter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAssessedNetworkAdapter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAssessedNetworkAdapter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.SqlAssessedNetworkAdapter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessedNetworkAdapter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessedNetworkAdapter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessedNetworkAdapter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlAssessmentMigrationIssue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssue>
    {
        internal SqlAssessmentMigrationIssue() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.ImpactedAssessmentObject> ImpactedObjects { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssueCategory? IssueCategory { get { throw null; } }
        public string IssueId { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlAssessmentMigrationIssueCategory : System.IEquatable<Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssueCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlAssessmentMigrationIssueCategory(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssueCategory Internal { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssueCategory Issue { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssueCategory Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssueCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssueCategory left, Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssueCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssueCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssueCategory left, Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssueCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlAssessmentV2IaasSuitabilityDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2IaasSuitabilityDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2IaasSuitabilityDetails>
    {
        internal SqlAssessmentV2IaasSuitabilityDetails() { }
        public Azure.ResourceManager.Migrate.Models.AzureSqlIaasSkuDto AzureSqlSku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.CostComponent> CostComponents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.SqlMigrationGuideline> MigrationGuidelines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssue> MigrationIssues { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateTargetType? MigrationTargetPlatform { get { throw null; } }
        public double? MonthlyComputeCost { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoning> RecommendationReasonings { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.AzureSqlIaasSkuDto> ReplicaAzureSqlSku { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? SecuritySuitability { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.SharedResourcesDto SharedResources { get { throw null; } }
        public bool? ShouldProvisionReplicas { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.SkuReplicationMode? SkuReplicationMode { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? Suitability { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.SqlAssessmentV2IaasSuitabilityDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2IaasSuitabilityDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2IaasSuitabilityDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.SqlAssessmentV2IaasSuitabilityDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2IaasSuitabilityDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2IaasSuitabilityDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2IaasSuitabilityDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlAssessmentV2PaasSuitabilityDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails>
    {
        internal SqlAssessmentV2PaasSuitabilityDetails() { }
        public Azure.ResourceManager.Migrate.Models.AzureSqlPaasSkuDto AzureSqlSku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.CostComponent> CostComponents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.SqlMigrationGuideline> MigrationGuidelines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.SqlAssessmentMigrationIssue> MigrationIssues { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateTargetType? MigrationTargetPlatform { get { throw null; } }
        public double? MonthlyComputeCost { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoning> RecommendationReasonings { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.AzureSqlPaasSkuDto> ReplicaAzureSqlSku { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? SecuritySuitability { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.SharedResourcesDto SharedResources { get { throw null; } }
        public bool? ShouldProvisionReplicas { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.SkuReplicationMode? SkuReplicationMode { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateCloudSuitability? Suitability { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2PaasSuitabilityDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlAssessmentV2SummaryDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2SummaryDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2SummaryDetails>
    {
        internal SqlAssessmentV2SummaryDetails() { }
        public double? ConfidenceScore { get { throw null; } }
        public double? MonthlyComputeCost { get { throw null; } }
        public double? MonthlyLicenseCost { get { throw null; } }
        public double? MonthlySecurityCost { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> SuitabilitySummary { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.SqlAssessmentV2SummaryDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2SummaryDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2SummaryDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.SqlAssessmentV2SummaryDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2SummaryDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2SummaryDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAssessmentV2SummaryDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlAvailabilityGroupDataOverview : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAvailabilityGroupDataOverview>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAvailabilityGroupDataOverview>
    {
        internal SqlAvailabilityGroupDataOverview() { }
        public string AvailabilityGroupId { get { throw null; } }
        public string AvailabilityGroupName { get { throw null; } }
        public string SqlAvailabilityGroupEntityId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SqlAvailabilityGroupSdsArmId { get { throw null; } }
        public string SqlAvailabilityReplicaId { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.SqlAvailabilityGroupDataOverview System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAvailabilityGroupDataOverview>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAvailabilityGroupDataOverview>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.SqlAvailabilityGroupDataOverview System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAvailabilityGroupDataOverview>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAvailabilityGroupDataOverview>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAvailabilityGroupDataOverview>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlAvailabilityReplicaSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAvailabilityReplicaSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAvailabilityReplicaSummary>
    {
        internal SqlAvailabilityReplicaSummary() { }
        public int? NumberOfAsynchronousNonReadReplicas { get { throw null; } }
        public int? NumberOfAsynchronousReadReplicas { get { throw null; } }
        public int? NumberOfPrimaryReplicas { get { throw null; } }
        public int? NumberOfSynchronousNonReadReplicas { get { throw null; } }
        public int? NumberOfSynchronousReadReplicas { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.SqlAvailabilityReplicaSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAvailabilityReplicaSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlAvailabilityReplicaSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.SqlAvailabilityReplicaSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAvailabilityReplicaSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAvailabilityReplicaSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlAvailabilityReplicaSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlDBSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlDBSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlDBSettings>
    {
        public SqlDBSettings() { }
        public Azure.ResourceManager.Migrate.Models.MigrateComputeTier? AzureSqlComputeTier { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureSqlDataBaseType? AzureSqlDataBaseType { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureSqlPurchaseModel? AzureSqlPurchaseModel { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier? AzureSqlServiceTier { get { throw null; } set { } }
        Azure.ResourceManager.Migrate.Models.SqlDBSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlDBSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlDBSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.SqlDBSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlDBSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlDBSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlDBSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlFciMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlFciMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlFciMetadata>
    {
        internal SqlFciMetadata() { }
        public int? FciSharedDiskCount { get { throw null; } }
        public bool? IsMultiSubnet { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.SqlFciMetadataState? State { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.SqlFciMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlFciMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlFciMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.SqlFciMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlFciMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlFciMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlFciMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlFciMetadataState : System.IEquatable<Azure.ResourceManager.Migrate.Models.SqlFciMetadataState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlFciMetadataState(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SqlFciMetadataState Failed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlFciMetadataState Inherited { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlFciMetadataState Initializing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlFciMetadataState Offline { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlFciMetadataState OfflinePending { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlFciMetadataState Online { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlFciMetadataState OnlinePending { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlFciMetadataState Pending { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlFciMetadataState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.SqlFciMetadataState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.SqlFciMetadataState left, Azure.ResourceManager.Migrate.Models.SqlFciMetadataState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.SqlFciMetadataState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.SqlFciMetadataState left, Azure.ResourceManager.Migrate.Models.SqlFciMetadataState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlFciState : System.IEquatable<Azure.ResourceManager.Migrate.Models.SqlFciState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlFciState(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SqlFciState Active { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlFciState NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlFciState Passive { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlFciState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.SqlFciState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.SqlFciState left, Azure.ResourceManager.Migrate.Models.SqlFciState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.SqlFciState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.SqlFciState left, Azure.ResourceManager.Migrate.Models.SqlFciState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlMigrationGuideline : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlMigrationGuideline>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlMigrationGuideline>
    {
        internal SqlMigrationGuideline() { }
        public string GuidelineId { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.SqlMigrationGuidelineCategory? MigrationGuidelineCategory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.MigrationGuidelineContext> MigrationGuidelineContext { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.SqlMigrationGuideline System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlMigrationGuideline>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlMigrationGuideline>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.SqlMigrationGuideline System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlMigrationGuideline>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlMigrationGuideline>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlMigrationGuideline>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlMigrationGuidelineCategory : System.IEquatable<Azure.ResourceManager.Migrate.Models.SqlMigrationGuidelineCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlMigrationGuidelineCategory(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SqlMigrationGuidelineCategory AvailabilityGroupGuideline { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlMigrationGuidelineCategory FailoverClusterInstanceGuideLine { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlMigrationGuidelineCategory General { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlMigrationGuidelineCategory Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.SqlMigrationGuidelineCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.SqlMigrationGuidelineCategory left, Azure.ResourceManager.Migrate.Models.SqlMigrationGuidelineCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.SqlMigrationGuidelineCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.SqlMigrationGuidelineCategory left, Azure.ResourceManager.Migrate.Models.SqlMigrationGuidelineCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlMISettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlMISettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlMISettings>
    {
        public SqlMISettings() { }
        public Azure.ResourceManager.Migrate.Models.AzureSqlInstanceType? AzureSqlInstanceType { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier? AzureSqlServiceTier { get { throw null; } set { } }
        Azure.ResourceManager.Migrate.Models.SqlMISettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlMISettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlMISettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.SqlMISettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlMISettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlMISettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlMISettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlOptimizationLogic : System.IEquatable<Azure.ResourceManager.Migrate.Models.SqlOptimizationLogic>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlOptimizationLogic(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SqlOptimizationLogic MinimizeCost { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlOptimizationLogic ModernizeToAzureSqlDB { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlOptimizationLogic ModernizeToAzureSqlMI { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlOptimizationLogic ModernizeToPaaS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.SqlOptimizationLogic other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.SqlOptimizationLogic left, Azure.ResourceManager.Migrate.Models.SqlOptimizationLogic right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.SqlOptimizationLogic (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.SqlOptimizationLogic left, Azure.ResourceManager.Migrate.Models.SqlOptimizationLogic right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlPaaSTargetConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlPaaSTargetConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlPaaSTargetConfig>
    {
        public SqlPaaSTargetConfig() { }
        public Azure.ResourceManager.Migrate.Models.MigrateComputeTier? ComputeTier { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.MigrateHardwareGeneration? HardwareGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureSqlServiceTier? ServiceTier { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> TargetLocations { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MigrateTargetType? TargetType { get { throw null; } set { } }
        Azure.ResourceManager.Migrate.Models.SqlPaaSTargetConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlPaaSTargetConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlPaaSTargetConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.SqlPaaSTargetConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlPaaSTargetConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlPaaSTargetConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlPaaSTargetConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlRecommendationReasoning : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoning>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoning>
    {
        internal SqlRecommendationReasoning() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoningContext> ContextParameters { get { throw null; } }
        public string ReasoningCategory { get { throw null; } }
        public string ReasoningId { get { throw null; } }
        public string ReasoningString { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoning System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoning System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlRecommendationReasoningContext : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoningContext>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoningContext>
    {
        internal SqlRecommendationReasoningContext() { }
        public string ContextKey { get { throw null; } }
        public string ContextValue { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoningContext System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoningContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoningContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoningContext System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoningContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoningContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.SqlRecommendationReasoningContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerLicense : System.IEquatable<Azure.ResourceManager.Migrate.Models.SqlServerLicense>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerLicense(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.SqlServerLicense No { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlServerLicense Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.SqlServerLicense Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.SqlServerLicense other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.SqlServerLicense left, Azure.ResourceManager.Migrate.Models.SqlServerLicense right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.SqlServerLicense (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.SqlServerLicense left, Azure.ResourceManager.Migrate.Models.SqlServerLicense right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UltraDiskAssessmentConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.UltraDiskAssessmentConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.UltraDiskAssessmentConfig>
    {
        internal UltraDiskAssessmentConfig() { }
        public string FamilyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TargetLocations { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.UltraDiskAssessmentConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.UltraDiskAssessmentConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.UltraDiskAssessmentConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.UltraDiskAssessmentConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.UltraDiskAssessmentConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.UltraDiskAssessmentConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.UltraDiskAssessmentConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmFamilyConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.VmFamilyConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.VmFamilyConfig>
    {
        internal VmFamilyConfig() { }
        public System.Collections.Generic.IReadOnlyList<string> Category { get { throw null; } }
        public string FamilyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TargetLocations { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.VmFamilyConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.VmFamilyConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.VmFamilyConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.VmFamilyConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.VmFamilyConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.VmFamilyConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.VmFamilyConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmUptime : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.VmUptime>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.VmUptime>
    {
        public VmUptime() { }
        public int? DaysPerMonth { get { throw null; } set { } }
        public int? HoursPerDay { get { throw null; } set { } }
        Azure.ResourceManager.Migrate.Models.VmUptime System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.VmUptime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.VmUptime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.VmUptime System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.VmUptime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.VmUptime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.VmUptime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.WorkloadSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.WorkloadSummary>
    {
        internal WorkloadSummary() { }
        public int? OracleInstances { get { throw null; } }
        public int? SpringApps { get { throw null; } }
        Azure.ResourceManager.Migrate.Models.WorkloadSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.WorkloadSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migrate.Models.WorkloadSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migrate.Models.WorkloadSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.WorkloadSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.WorkloadSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migrate.Models.WorkloadSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
