namespace Azure.ResourceManager.Migration.Assessment
{
    public partial class AssessedMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedMachineResource>, System.Collections.IEnumerable
    {
        protected AssessedMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedMachineResource> Get(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.AssessedMachineResource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.AssessedMachineResource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedMachineResource>> GetAsync(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.AssessedMachineResource> GetIfExists(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.AssessedMachineResource>> GetIfExistsAsync(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.AssessedMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.AssessedMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssessedMachineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedMachineData>
    {
        public AssessedMachineData() { }
        public Azure.ResourceManager.Migration.Assessment.Models.MachineBootType? BootType { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.CostComponent> CostComponents { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterMachineArmId { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterManagementServerArmId { get { throw null; } }
        public string DatacenterManagementServerName { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.AssessedDisk> Disks { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError> Errors { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.ProcessorInfo HostProcessor { get { throw null; } set { } }
        public double? MegabytesOfMemory { get { throw null; } }
        public double? MegabytesOfMemoryForRecommendedSize { get { throw null; } }
        public double? MonthlyBandwidthCost { get { throw null; } }
        public double? MonthlyComputeCostForRecommendedSize { get { throw null; } }
        public double? MonthlyPremiumStorageCost { get { throw null; } }
        public double? MonthlyStandardSsdStorageCost { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public double? MonthlyUltraStorageCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.AssessedNetworkAdapter> NetworkAdapters { get { throw null; } }
        public int? NumberOfCores { get { throw null; } }
        public int? NumberOfCoresForRecommendedSize { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture? OperatingSystemArchitecture { get { throw null; } }
        public string OperatingSystemName { get { throw null; } }
        public string OperatingSystemType { get { throw null; } }
        public string OperatingSystemVersion { get { throw null; } }
        public double? PercentageCoresUtilization { get { throw null; } }
        public double? PercentageMemoryUtilization { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus ProductSupportStatus { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize? RecommendedSize { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType? TypePropertiesType { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.AssessedMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.AssessedMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedMachineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedMachineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssessedMachineResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.AssessedMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string assessedMachineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.AssessedMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.AssessedMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlDatabaseV2Collection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource>, System.Collections.IEnumerable
    {
        protected AssessedSqlDatabaseV2Collection() { }
        public virtual Azure.Response<bool> Exists(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource> Get(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource>> GetAsync(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource> GetIfExists(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource>> GetIfExistsAsync(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssessedSqlDatabaseV2Data : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data>
    {
        public AssessedSqlDatabaseV2Data() { }
        public Azure.Core.ResourceIdentifier AssessedSqlInstanceArmId { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails AzureSqlDBSuitabilityDetails { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails AzureSqlMISuitabilityDetails { get { throw null; } }
        public double? BufferCacheSizeInMB { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel? CompatibilityLevel { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public double? DatabaseSizeInMB { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public bool? IsDatabaseHighlyAvailable { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityGroupDataOverview LinkedAvailabilityGroupOverview { get { throw null; } }
        public Azure.Core.ResourceIdentifier MachineArmId { get { throw null; } }
        public string MachineName { get { throw null; } }
        public double? MegabytesPerSecondOfRead { get { throw null; } }
        public double? MegabytesPerSecondOfWrite { get { throw null; } }
        public double? NumberOfReadOperationsPerSecond { get { throw null; } }
        public double? NumberOfWriteOperationsPerSecond { get { throw null; } }
        public double? PercentageCoresUtilization { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus ProductSupportStatus { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? RecommendedAzureSqlTargetType { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability? RecommendedSuitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } }
        public Azure.Core.ResourceIdentifier SqlDatabaseSdsArmId { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlDatabaseV2Resource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssessedSqlDatabaseV2Resource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string assessedSqlDatabaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlInstanceV2Collection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource>, System.Collections.IEnumerable
    {
        protected AssessedSqlInstanceV2Collection() { }
        public virtual Azure.Response<bool> Exists(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource> Get(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource>> GetAsync(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource> GetIfExists(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource>> GetIfExistsAsync(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssessedSqlInstanceV2Data : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data>
    {
        public AssessedSqlInstanceV2Data() { }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityReplicaSummary AvailabilityReplicaSummary { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails AzureSqlDBSuitabilityDetails { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails AzureSqlMISuitabilityDetails { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails AzureSqlVmSuitabilityDetails { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDatabaseSummary DatabaseSummary { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadata FciMetadata { get { throw null; } }
        public bool? HasScanOccurred { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public bool? IsClustered { get { throw null; } }
        public bool? IsHighAvailabilityEnabled { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDiskDetails> LogicalDisks { get { throw null; } }
        public Azure.Core.ResourceIdentifier MachineArmId { get { throw null; } }
        public string MachineName { get { throw null; } }
        public double? MemoryInUseInMB { get { throw null; } }
        public int? NumberOfCoresAllocated { get { throw null; } }
        public double? PercentageCoresUtilization { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus ProductSupportStatus { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? RecommendedAzureSqlTargetType { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability? RecommendedSuitability { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning> RecommendedTargetReasonings { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } }
        public string SqlEdition { get { throw null; } }
        public Azure.Core.ResourceIdentifier SqlInstanceSdsArmId { get { throw null; } }
        public string SqlVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceStorageDetails> StorageTypeBasedDetails { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlInstanceV2Resource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssessedSqlInstanceV2Resource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string assessedSqlInstanceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource>, System.Collections.IEnumerable
    {
        protected AssessedSqlMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource> Get(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource>> GetAsync(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource> GetIfExists(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource>> GetIfExistsAsync(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssessedSqlMachineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData>
    {
        public AssessedSqlMachineData() { }
        public string BiosGuid { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MachineBootType? BootType { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.CostComponent> CostComponents { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterMachineArmId { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterManagementServerArmId { get { throw null; } }
        public string DatacenterManagementServerName { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.AssessedDataDisk> Disks { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Fqdn { get { throw null; } }
        public double? MegabytesOfMemory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline> MigrationGuidelines { get { throw null; } }
        public double? MonthlyBandwidthCost { get { throw null; } }
        public double? MonthlyComputeCost { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessedNetworkAdapter> NetworkAdapters { get { throw null; } }
        public int? NumberOfCores { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture? OperatingSystemArchitecture { get { throw null; } }
        public string OperatingSystemName { get { throw null; } }
        public string OperatingSystemType { get { throw null; } }
        public string OperatingSystemVersion { get { throw null; } }
        public double? PercentageCoresUtilization { get { throw null; } }
        public double? PercentageMemoryUtilization { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus ProductSupportStatus { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily? RecommendedVmFamily { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize? RecommendedVmSize { get { throw null; } }
        public double? RecommendedVmSizeMegabytesOfMemory { get { throw null; } }
        public int? RecommendedVmSizeNumberOfCores { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? SecuritySuitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceSummary> SqlInstances { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType? TypePropertiesType { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlMachineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssessedSqlMachineResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string assessedSqlMachineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlRecommendedEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource>, System.Collections.IEnumerable
    {
        protected AssessedSqlRecommendedEntityCollection() { }
        public virtual Azure.Response<bool> Exists(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource> Get(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource>> GetAsync(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource> GetIfExists(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource>> GetIfExistsAsync(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssessedSqlRecommendedEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData>
    {
        public AssessedSqlRecommendedEntityData() { }
        public Azure.Core.ResourceIdentifier AssessedSqlEntityArmId { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails AzureSqlDBSuitabilityDetails { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails AzureSqlMISuitabilityDetails { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails AzureSqlVmSuitabilityDetails { get { throw null; } }
        public int? DBCount { get { throw null; } }
        public int? DiscoveredDBCount { get { throw null; } }
        public bool? HasScanOccurred { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public bool? IsClustered { get { throw null; } }
        public bool? IsHighAvailabilityEnabled { get { throw null; } }
        public string MachineName { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus ProductSupportStatus { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? RecommendedAzureSqlTargetType { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability? RecommendedSuitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } }
        public string SqlEdition { get { throw null; } }
        public string SqlVersion { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlRecommendedEntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssessedSqlRecommendedEntityResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string recommendedAssessedEntityName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource> Get(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource>> GetAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource> GetIfExists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource>> GetIfExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentAssessmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData>
    {
        public MigrationAssessmentAssessmentData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> AssessmentErrorSummary { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentType? AssessmentType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType> AzureDiskTypes { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureHybridUseBenefit? AzureHybridUseBenefit { get { throw null; } set { } }
        public Azure.Core.AzureLocation? AzureLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode? AzureOfferCode { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzurePricingTier? AzurePricingTier { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureStorageRedundancy? AzureStorageRedundancy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily> AzureVmFamilies { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.CostComponent> CostComponents { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency? Currency { get { throw null; } set { } }
        public double? DiscountPercentage { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> DistributionByOSName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> DistributionByServicePackInsight { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> DistributionBySupportStatus { get { throw null; } }
        public string EASubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType? GroupType { get { throw null; } }
        public double? MonthlyBandwidthCost { get { throw null; } }
        public double? MonthlyComputeCost { get { throw null; } }
        public double? MonthlyPremiumStorageCost { get { throw null; } }
        public double? MonthlyStandardSsdStorageCost { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public double? MonthlyUltraStorageCost { get { throw null; } }
        public int? NumberOfMachines { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization? Percentile { get { throw null; } set { } }
        public System.DateTimeOffset? PerfDataEndOn { get { throw null; } set { } }
        public System.DateTimeOffset? PerfDataStartOn { get { throw null; } set { } }
        public System.DateTimeOffset? PricesQueriedOn { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance? ReservedInstance { get { throw null; } set { } }
        public double? ScalingFactor { get { throw null; } set { } }
        public string SchemaVersion { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage? Stage { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> SuitabilitySummary { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange? TimeRange { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.VmUptime VmUptime { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentAssessmentOptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentAssessmentOptionCollection() { }
        public virtual Azure.Response<bool> Exists(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource> Get(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource>> GetAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource> GetIfExists(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource>> GetIfExistsAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentAssessmentOptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData>
    {
        public MigrationAssessmentAssessmentOptionData() { }
        public System.Collections.Generic.IReadOnlyList<string> PremiumDiskVmFamilies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReservedInstanceSupportedCurrencies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReservedInstanceSupportedLocations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReservedInstanceSupportedOffers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReservedInstanceVmFamilies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SavingsPlanSupportedLocations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SavingsPlanVmFamilies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.UltraDiskAssessmentConfig> UltraDiskVmFamilies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.VmFamilyConfig> VmFamilies { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentAssessmentOptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentAssessmentOptionResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string assessmentOptionsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentAssessmentProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentAssessmentProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> GetIfExists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource>> GetIfExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentAssessmentProjectData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData>
    {
        public MigrationAssessmentAssessmentProjectData(Azure.Core.AzureLocation location) { }
        public string AssessmentSolutionId { get { throw null; } set { } }
        public System.DateTimeOffset? CreateOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier CustomerStorageAccountArmId { get { throw null; } set { } }
        public string CustomerWorkspaceId { get { throw null; } set { } }
        public string CustomerWorkspaceLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentProjectStatus? ProjectStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public string ServiceEndpoint { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentAssessmentProjectResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentAssessmentProjectResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource> GetMigrationAssessmentAssessmentOption(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource>> GetMigrationAssessmentAssessmentOptionAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionCollection GetMigrationAssessmentAssessmentOptions() { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryCollection GetMigrationAssessmentAssessmentProjectSummaries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource> GetMigrationAssessmentAssessmentProjectSummary(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource>> GetMigrationAssessmentAssessmentProjectSummaryAsync(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource> GetMigrationAssessmentAvsAssessmentOption(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource>> GetMigrationAssessmentAvsAssessmentOptionAsync(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionCollection GetMigrationAssessmentAvsAssessmentOptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource> GetMigrationAssessmentGroup(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource>> GetMigrationAssessmentGroupAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupCollection GetMigrationAssessmentGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource> GetMigrationAssessmentHyperVCollector(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource>> GetMigrationAssessmentHyperVCollectorAsync(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorCollection GetMigrationAssessmentHyperVCollectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource> GetMigrationAssessmentImportCollector(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource>> GetMigrationAssessmentImportCollectorAsync(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorCollection GetMigrationAssessmentImportCollectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource> GetMigrationAssessmentMachine(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource>> GetMigrationAssessmentMachineAsync(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineCollection GetMigrationAssessmentMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource> GetMigrationAssessmentPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource>> GetMigrationAssessmentPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionCollection GetMigrationAssessmentPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource> GetMigrationAssessmentPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource>> GetMigrationAssessmentPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceCollection GetMigrationAssessmentPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource> GetMigrationAssessmentServerCollector(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource>> GetMigrationAssessmentServerCollectorAsync(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorCollection GetMigrationAssessmentServerCollectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource> GetMigrationAssessmentSqlAssessmentOption(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource>> GetMigrationAssessmentSqlAssessmentOptionAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionCollection GetMigrationAssessmentSqlAssessmentOptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource> GetMigrationAssessmentSqlCollector(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource>> GetMigrationAssessmentSqlCollectorAsync(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorCollection GetMigrationAssessmentSqlCollectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource> GetMigrationAssessmentVMwareCollector(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource>> GetMigrationAssessmentVMwareCollectorAsync(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorCollection GetMigrationAssessmentVMwareCollectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentAssessmentProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentAssessmentProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationAssessmentAssessmentProjectSummaryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentAssessmentProjectSummaryCollection() { }
        public virtual Azure.Response<bool> Exists(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource> Get(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource>> GetAsync(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource> GetIfExists(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource>> GetIfExistsAsync(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentAssessmentProjectSummaryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData>
    {
        public MigrationAssessmentAssessmentProjectSummaryData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary> ErrorSummaryAffectedEntities { get { throw null; } }
        public System.DateTimeOffset? LastAssessedOn { get { throw null; } }
        public int? NumberOfAssessments { get { throw null; } }
        public int? NumberOfGroups { get { throw null; } }
        public int? NumberOfImportMachines { get { throw null; } }
        public int? NumberOfMachines { get { throw null; } }
        public int? NumberOfPrivateEndpointConnections { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentAssessmentProjectSummaryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentAssessmentProjectSummaryResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string projectSummaryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentAssessmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentAssessmentResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri> DownloadUrl(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri>> DownloadUrlAsync(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedMachineResource> GetAssessedMachine(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedMachineResource>> GetAssessedMachineAsync(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.AssessedMachineCollection GetAssessedMachines() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationAssessmentAvsAssessedMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentAvsAssessedMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource> Get(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource>> GetAsync(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource> GetIfExists(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource>> GetIfExistsAsync(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentAvsAssessedMachineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData>
    {
        public MigrationAssessmentAvsAssessedMachineData() { }
        public Azure.ResourceManager.Migration.Assessment.Models.MachineBootType? BootType { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterMachineArmId { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterManagementServerArmId { get { throw null; } }
        public string DatacenterManagementServerName { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedDisk> Disks { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError> Errors { get { throw null; } }
        public double? MegabytesOfMemory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedNetworkAdapter> NetworkAdapters { get { throw null; } }
        public int? NumberOfCores { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture? OperatingSystemArchitecture { get { throw null; } }
        public string OperatingSystemName { get { throw null; } }
        public string OperatingSystemType { get { throw null; } }
        public string OperatingSystemVersion { get { throw null; } }
        public double? PercentageCoresUtilization { get { throw null; } }
        public double? PercentageMemoryUtilization { get { throw null; } }
        public double? StorageInUseGB { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType? TypePropertiesType { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentAvsAssessedMachineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentAvsAssessedMachineResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string avsAssessedMachineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentAvsAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentAvsAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource> Get(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource>> GetAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource> GetIfExists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource>> GetIfExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentAvsAssessmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData>
    {
        public MigrationAssessmentAvsAssessmentData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> AssessmentErrorSummary { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentType? AssessmentType { get { throw null; } }
        public Azure.Core.AzureLocation? AzureLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode? AzureOfferCode { get { throw null; } set { } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public double? CpuUtilization { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency? Currency { get { throw null; } set { } }
        public double? DedupeCompression { get { throw null; } set { } }
        public double? DiscountPercentage { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel? FailuresToTolerateAndRaidLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType? GroupType { get { throw null; } }
        public bool? IsStretchClusterEnabled { get { throw null; } set { } }
        public string LimitingFactor { get { throw null; } }
        public double? MemOvercommit { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AvsNodeType? NodeType { get { throw null; } set { } }
        public int? NumberOfMachines { get { throw null; } }
        public int? NumberOfNodes { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization? Percentile { get { throw null; } set { } }
        public System.DateTimeOffset? PerfDataEndOn { get { throw null; } set { } }
        public System.DateTimeOffset? PerfDataStartOn { get { throw null; } set { } }
        public System.DateTimeOffset? PricesQueriedOn { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? ProvisioningState { get { throw null; } set { } }
        public double? RamUtilization { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance? ReservedInstance { get { throw null; } set { } }
        public double? ScalingFactor { get { throw null; } set { } }
        public string SchemaVersion { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage? Stage { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus? Status { get { throw null; } }
        public double? StorageUtilization { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AvsSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> SuitabilitySummary { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange? TimeRange { get { throw null; } set { } }
        public double? TotalCpuCores { get { throw null; } }
        public double? TotalMonthlyCost { get { throw null; } }
        public double? TotalRamInGB { get { throw null; } }
        public double? TotalStorageInGB { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public double? VcpuOversubscription { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentAvsAssessmentOptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentAvsAssessmentOptionCollection() { }
        public virtual Azure.Response<bool> Exists(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource> Get(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource>> GetAsync(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource> GetIfExists(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource>> GetIfExistsAsync(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentAvsAssessmentOptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData>
    {
        public MigrationAssessmentAvsAssessmentOptionData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AvsSkuConfig> AvsNodes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel> FailuresToTolerateAndRaidLevelValues { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AvsNodeType> ReservedInstanceAvsNodes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency> ReservedInstanceSupportedCurrencies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> ReservedInstanceSupportedLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode> ReservedInstanceSupportedOffers { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentAvsAssessmentOptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentAvsAssessmentOptionResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string avsAssessmentOptionsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentAvsAssessmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentAvsAssessmentResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri> DownloadUrl(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri>> DownloadUrlAsync(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource> GetMigrationAssessmentAvsAssessedMachine(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource>> GetMigrationAssessmentAvsAssessedMachineAsync(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineCollection GetMigrationAssessmentAvsAssessedMachines() { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MigrationAssessmentExtensions
    {
        public static Azure.ResourceManager.Migration.Assessment.AssessedMachineResource GetAssessedMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource GetAssessedSqlDatabaseV2Resource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource GetAssessedSqlInstanceV2Resource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource GetAssessedSqlMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource GetAssessedSqlRecommendedEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource GetMigrationAssessmentAssessmentOptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> GetMigrationAssessmentAssessmentProject(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource>> GetMigrationAssessmentAssessmentProjectAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource GetMigrationAssessmentAssessmentProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectCollection GetMigrationAssessmentAssessmentProjects(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> GetMigrationAssessmentAssessmentProjects(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> GetMigrationAssessmentAssessmentProjectsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource GetMigrationAssessmentAssessmentProjectSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource GetMigrationAssessmentAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource GetMigrationAssessmentAvsAssessedMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource GetMigrationAssessmentAvsAssessmentOptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource GetMigrationAssessmentAvsAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource GetMigrationAssessmentGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource GetMigrationAssessmentHyperVCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource GetMigrationAssessmentImportCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource GetMigrationAssessmentMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource GetMigrationAssessmentPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource GetMigrationAssessmentPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource GetMigrationAssessmentServerCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource GetMigrationAssessmentSqlAssessmentOptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource GetMigrationAssessmentSqlAssessmentV2Resource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource GetMigrationAssessmentSqlAssessmentV2SummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource GetMigrationAssessmentSqlCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource GetMigrationAssessmentVMwareCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MigrationAssessmentGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string groupName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string groupName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData>
    {
        public MigrationAssessmentGroupData() { }
        public bool? AreAssessmentsRunning { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Assessments { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupStatus? GroupStatus { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType? GroupType { get { throw null; } set { } }
        public int? MachineCount { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentType> SupportedAssessmentTypes { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentGroupResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource> GetMigrationAssessmentAssessment(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource>> GetMigrationAssessmentAssessmentAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentCollection GetMigrationAssessmentAssessments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource> GetMigrationAssessmentAvsAssessment(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource>> GetMigrationAssessmentAvsAssessmentAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentCollection GetMigrationAssessmentAvsAssessments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource> GetMigrationAssessmentSqlAssessmentV2(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource>> GetMigrationAssessmentSqlAssessmentV2Async(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Collection GetMigrationAssessmentSqlAssessmentV2s() { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource> UpdateMachines(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource>> UpdateMachinesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationAssessmentHyperVCollectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentHyperVCollectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hyperVCollectorName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hyperVCollectorName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource> Get(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource>> GetAsync(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource> GetIfExists(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource>> GetIfExistsAsync(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentHyperVCollectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData>
    {
        public MigrationAssessmentHyperVCollectorData() { }
        public Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase AgentProperties { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DiscoverySiteId { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentHyperVCollectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentHyperVCollectorResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string hyperVCollectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationAssessmentImportCollectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentImportCollectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string importCollectorName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string importCollectorName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource> Get(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource>> GetAsync(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource> GetIfExists(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource>> GetIfExistsAsync(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentImportCollectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData>
    {
        public MigrationAssessmentImportCollectorData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DiscoverySiteId { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentImportCollectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentImportCollectorResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string importCollectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationAssessmentMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource> Get(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource>> GetAsync(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource> GetIfExists(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource>> GetIfExistsAsync(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentMachineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData>
    {
        public MigrationAssessmentMachineData() { }
        public Azure.ResourceManager.Migration.Assessment.Models.MachineBootType? BootType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterManagementServerArmId { get { throw null; } }
        public string DatacenterManagementServerName { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.Core.ResourceIdentifier DiscoveryMachineArmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentDisk> Disks { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError> Errors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Groups { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.ProcessorInfo HostProcessor { get { throw null; } }
        public double? MegabytesOfMemory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentNetworkAdapter> NetworkAdapters { get { throw null; } }
        public int? NumberOfCores { get { throw null; } }
        public string OperatingSystemName { get { throw null; } }
        public string OperatingSystemType { get { throw null; } }
        public string OperatingSystemVersion { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus ProductSupportStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SqlInstances { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> WebApplications { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.WorkloadSummary WorkloadSummary { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentMachineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentMachineResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string machineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData>
    {
        public MigrationAssessmentPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationAssessmentPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData>
    {
        public MigrationAssessmentPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentServerCollectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentServerCollectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverCollectorName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverCollectorName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource> Get(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource>> GetAsync(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource> GetIfExists(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource>> GetIfExistsAsync(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentServerCollectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData>
    {
        public MigrationAssessmentServerCollectorData() { }
        public Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase AgentProperties { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DiscoverySiteId { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentServerCollectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentServerCollectorResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string serverCollectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationAssessmentSqlAssessmentOptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentSqlAssessmentOptionCollection() { }
        public virtual Azure.Response<bool> Exists(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource> Get(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource>> GetAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource> GetIfExists(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource>> GetIfExistsAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentSqlAssessmentOptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData>
    {
        public MigrationAssessmentSqlAssessmentOptionData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily> PremiumDiskVmFamilies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType> ReservedInstanceSqlTargets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency> ReservedInstanceSupportedCurrencies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> ReservedInstanceSupportedLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> ReservedInstanceSupportedLocationsForIaas { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode> ReservedInstanceSupportedOffers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily> ReservedInstanceVmFamilies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> SavingsPlanSupportedLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> SavingsPlanSupportedLocationsForPaas { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode> SavingsPlanSupportedOffers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily> SavingsPlanVmFamilies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.SqlPaaSTargetConfig> SqlSkus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode> SupportedOffers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.VmFamilyConfig> VmFamilies { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentSqlAssessmentOptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentSqlAssessmentOptionResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string assessmentOptionsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentSqlAssessmentV2Collection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentSqlAssessmentV2Collection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource> Get(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource>> GetAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource> GetIfExists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource>> GetIfExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentSqlAssessmentV2Data : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data>
    {
        public MigrationAssessmentSqlAssessmentV2Data() { }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentType? AssessmentType { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AsyncCommitModeIntent? AsyncCommitModeIntent { get { throw null; } set { } }
        public Azure.Core.AzureLocation? AzureLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode? AzureOfferCode { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode? AzureOfferCodeForVm { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureSecurityOfferingType? AzureSecurityOfferingType { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlDBSettings AzureSqlDatabaseSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlMISettings AzureSqlManagedInstanceSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily> AzureSqlVmInstanceSeries { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency? Currency { get { throw null; } set { } }
        public Azure.Core.AzureLocation? DisasterRecoveryLocation { get { throw null; } set { } }
        public double? DiscountPercentage { get { throw null; } set { } }
        public string EASubscriptionId { get { throw null; } set { } }
        public bool? EnableHadrAssessment { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.EntityUptime EntityUptime { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentEnvironmentType? EnvironmentType { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType? GroupType { get { throw null; } set { } }
        public bool? IsInternetAccessAvailable { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MultiSubnetIntent? MultiSubnetIntent { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlOptimizationLogic? OptimizationLogic { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentOSLicense? OSLicense { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization? Percentile { get { throw null; } set { } }
        public System.DateTimeOffset? PerfDataEndOn { get { throw null; } set { } }
        public System.DateTimeOffset? PerfDataStartOn { get { throw null; } set { } }
        public System.DateTimeOffset? PricesQueriedOn { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance? ReservedInstance { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance? ReservedInstanceForVm { get { throw null; } set { } }
        public double? ScalingFactor { get { throw null; } set { } }
        public string SchemaVersion { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlServerLicense? SqlServerLicense { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage? Stage { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange? TimeRange { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentSqlAssessmentV2Resource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentSqlAssessmentV2Resource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri> DownloadUrl(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri>> DownloadUrlAsync(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource> GetAssessedSqlDatabaseV2(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource>> GetAssessedSqlDatabaseV2Async(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Collection GetAssessedSqlDatabaseV2s() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource> GetAssessedSqlInstanceV2(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource>> GetAssessedSqlInstanceV2Async(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Collection GetAssessedSqlInstanceV2s() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource> GetAssessedSqlMachine(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource>> GetAssessedSqlMachineAsync(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineCollection GetAssessedSqlMachines() { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityCollection GetAssessedSqlRecommendedEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource> GetAssessedSqlRecommendedEntity(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource>> GetAssessedSqlRecommendedEntityAsync(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryCollection GetMigrationAssessmentSqlAssessmentV2Summaries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource> GetMigrationAssessmentSqlAssessmentV2Summary(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource>> GetMigrationAssessmentSqlAssessmentV2SummaryAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationAssessmentSqlAssessmentV2SummaryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentSqlAssessmentV2SummaryCollection() { }
        public virtual Azure.Response<bool> Exists(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource> Get(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource>> GetAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource> GetIfExists(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource>> GetIfExistsAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentSqlAssessmentV2SummaryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData>
    {
        public MigrationAssessmentSqlAssessmentV2SummaryData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2SummaryDetails> AssessmentSummary { get { throw null; } }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentSqlAssessmentV2SummaryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentSqlAssessmentV2SummaryResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string summaryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentSqlCollectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentSqlCollectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string collectorName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string collectorName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource> Get(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource>> GetAsync(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource> GetIfExists(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource>> GetIfExistsAsync(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentSqlCollectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData>
    {
        public MigrationAssessmentSqlCollectorData() { }
        public Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase AgentProperties { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DiscoverySiteId { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentSqlCollectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentSqlCollectorResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string collectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationAssessmentVMwareCollectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentVMwareCollectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vmWareCollectorName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vmWareCollectorName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource> Get(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource>> GetAsync(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource> GetIfExists(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource>> GetIfExistsAsync(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentVMwareCollectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData>
    {
        public MigrationAssessmentVMwareCollectorData() { }
        public Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase AgentProperties { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DiscoverySiteId { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentVMwareCollectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentVMwareCollectorResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string vmWareCollectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Migration.Assessment.Mocking
{
    public partial class MockableMigrationAssessmentArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMigrationAssessmentArmClient() { }
        public virtual Azure.ResourceManager.Migration.Assessment.AssessedMachineResource GetAssessedMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Resource GetAssessedSqlDatabaseV2Resource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Resource GetAssessedSqlInstanceV2Resource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineResource GetAssessedSqlMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityResource GetAssessedSqlRecommendedEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionResource GetMigrationAssessmentAssessmentOptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource GetMigrationAssessmentAssessmentProjectResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryResource GetMigrationAssessmentAssessmentProjectSummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentResource GetMigrationAssessmentAssessmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineResource GetMigrationAssessmentAvsAssessedMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionResource GetMigrationAssessmentAvsAssessmentOptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentResource GetMigrationAssessmentAvsAssessmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource GetMigrationAssessmentGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource GetMigrationAssessmentHyperVCollectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource GetMigrationAssessmentImportCollectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource GetMigrationAssessmentMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource GetMigrationAssessmentPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource GetMigrationAssessmentPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource GetMigrationAssessmentServerCollectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionResource GetMigrationAssessmentSqlAssessmentOptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Resource GetMigrationAssessmentSqlAssessmentV2Resource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryResource GetMigrationAssessmentSqlAssessmentV2SummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource GetMigrationAssessmentSqlCollectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource GetMigrationAssessmentVMwareCollectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMigrationAssessmentResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMigrationAssessmentResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> GetMigrationAssessmentAssessmentProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource>> GetMigrationAssessmentAssessmentProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectCollection GetMigrationAssessmentAssessmentProjects() { throw null; }
    }
    public partial class MockableMigrationAssessmentSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMigrationAssessmentSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> GetMigrationAssessmentAssessmentProjects(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectResource> GetMigrationAssessmentAssessmentProjectsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Migration.Assessment.Models
{
    public static partial class ArmMigrationAssessmentModelFactory
    {
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedDataDisk AssessedDataDisk(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation?), Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail?), Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize? recommendedDiskSize = default(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize?), Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType? recommendedDiskType = default(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType?), int? recommendedDiskSizeGigabytes = default(int?), double? recommendDiskThroughputInMbps = default(double?), double? recommendedDiskIops = default(double?), double? monthlyStorageCost = default(double?), string name = null, string displayName = null, double? gigabytesProvisioned = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedDisk AssessedDisk(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation?), Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail?), Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize? recommendedDiskSize = default(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize?), Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType? recommendedDiskType = default(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType?), int? gigabytesForRecommendedDiskSize = default(int?), double? recommendDiskThroughputInMbps = default(double?), double? recommendedDiskIops = default(double?), double? monthlyStorageCost = default(double?), string name = null, string displayName = null, double? gigabytesProvisioned = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.AssessedMachineData AssessedMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError> errors = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.AssessedDisk> disks = null, double? monthlyUltraStorageCost = default(double?), Azure.ResourceManager.Migration.Assessment.Models.ProcessorInfo hostProcessor = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.CostComponent> costComponents = null, Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus productSupportStatus = null, double? monthlyBandwidthCost = default(double?), double? monthlyStorageCost = default(double?), double? monthlyPremiumStorageCost = default(double?), double? monthlyStandardSsdStorageCost = default(double?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.AssessedNetworkAdapter> networkAdapters = null, Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize? recommendedSize = default(Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize?), int? numberOfCoresForRecommendedSize = default(int?), double? megabytesOfMemoryForRecommendedSize = default(double?), double? monthlyComputeCostForRecommendedSize = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation?), Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail?), Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType? typePropertiesType = default(Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType?), Azure.ResourceManager.Migration.Assessment.Models.MachineBootType? bootType = default(Azure.ResourceManager.Migration.Assessment.Models.MachineBootType?), string operatingSystemType = null, string operatingSystemName = null, string operatingSystemVersion = null, Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture? operatingSystemArchitecture = default(Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string displayName = null, string description = null, Azure.Core.ResourceIdentifier datacenterMachineArmId = null, Azure.Core.ResourceIdentifier datacenterManagementServerArmId = null, string datacenterManagementServerName = null, double? megabytesOfMemory = default(double?), int? numberOfCores = default(int?), double? confidenceRatingInPercentage = default(double?), double? percentageCoresUtilization = default(double?), double? percentageMemoryUtilization = default(double?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedNetworkAdapter AssessedNetworkAdapter(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail?), Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityExplanation?), double? monthlyBandwidthCosts = default(double?), double? netGigabytesTransmittedPerMonth = default(double?), string displayName = null, string macAddress = null, System.Collections.Generic.IEnumerable<string> ipAddresses = null, double? megabytesPerSecondReceived = default(double?), double? megabytesPerSecondTransmitted = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.AssessedSqlDatabaseV2Data AssessedSqlDatabaseV2Data(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? recommendedAzureSqlTargetType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType?), Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability? recommendedSuitability = default(Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability?), double? bufferCacheSizeInMB = default(double?), Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus productSupportStatus = null, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlMISuitabilityDetails = null, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlDBSuitabilityDetails = null, bool? isDatabaseHighlyAvailable = default(bool?), Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityGroupDataOverview linkedAvailabilityGroupOverview = null, Azure.Core.ResourceIdentifier machineArmId = null, Azure.Core.ResourceIdentifier assessedSqlInstanceArmId = null, string machineName = null, string instanceName = null, string databaseName = null, double? databaseSizeInMB = default(double?), Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel? compatibilityLevel = default(Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel?), Azure.Core.ResourceIdentifier sqlDatabaseSdsArmId = null, double? percentageCoresUtilization = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?), double? confidenceRatingInPercentage = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDatabaseSummary AssessedSqlInstanceDatabaseSummary(int? numberOfUserDatabases = default(int?), double? totalDatabaseSizeInMB = default(double?), double? largestDatabaseSizeInMB = default(double?), int? totalDiscoveredUserDatabases = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDiskDetails AssessedSqlInstanceDiskDetails(string diskId = null, double? diskSizeInMB = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceStorageDetails AssessedSqlInstanceStorageDetails(string storageType = null, double? diskSizeInMB = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceSummary AssessedSqlInstanceSummary(string instanceId = null, string instanceName = null, Azure.Core.ResourceIdentifier sqlInstanceSdsArmId = null, string sqlInstanceEntityId = null, string sqlEdition = null, string sqlVersion = null, bool? isClustered = default(bool?), bool? isHighAvailabilityEnabled = default(bool?), Azure.ResourceManager.Migration.Assessment.Models.SqlFciState? sqlFciState = default(Azure.ResourceManager.Migration.Assessment.Models.SqlFciState?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.AssessedSqlInstanceV2Data AssessedSqlInstanceV2Data(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, double? memoryInUseInMB = default(double?), bool? hasScanOccurred = default(bool?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? recommendedAzureSqlTargetType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType?), Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability? recommendedSuitability = default(Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability?), Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlMISuitabilityDetails = null, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlDBSuitabilityDetails = null, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails azureSqlVmSuitabilityDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceStorageDetails> storageTypeBasedDetails = null, Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus productSupportStatus = null, Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadata fciMetadata = null, Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityReplicaSummary availabilityReplicaSummary = null, bool? isClustered = default(bool?), bool? isHighAvailabilityEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning> recommendedTargetReasonings = null, Azure.Core.ResourceIdentifier machineArmId = null, string machineName = null, string instanceName = null, Azure.Core.ResourceIdentifier sqlInstanceSdsArmId = null, string sqlEdition = null, string sqlVersion = null, int? numberOfCoresAllocated = default(int?), double? percentageCoresUtilization = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDiskDetails> logicalDisks = null, Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDatabaseSummary databaseSummary = null, double? confidenceRatingInPercentage = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.AssessedSqlMachineData AssessedSqlMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string biosGuid = null, string fqdn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceSummary> sqlInstances = null, Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail?), Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation?), Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize? recommendedVmSize = default(Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize?), Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily? recommendedVmFamily = default(Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily?), Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus productSupportStatus = null, int? recommendedVmSizeNumberOfCores = default(int?), double? recommendedVmSizeMegabytesOfMemory = default(double?), double? monthlyComputeCost = default(double?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.AssessedDataDisk> disks = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessedNetworkAdapter> networkAdapters = null, double? monthlyBandwidthCost = default(double?), double? monthlyStorageCost = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.CostComponent> costComponents = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? securitySuitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline> migrationGuidelines = null, Azure.ResourceManager.Migration.Assessment.Models.MachineBootType? bootType = default(Azure.ResourceManager.Migration.Assessment.Models.MachineBootType?), string operatingSystemType = null, string operatingSystemName = null, string operatingSystemVersion = null, Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture? operatingSystemArchitecture = default(Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string displayName = null, Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType? typePropertiesType = default(Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType?), string description = null, Azure.Core.ResourceIdentifier datacenterMachineArmId = null, Azure.Core.ResourceIdentifier datacenterManagementServerArmId = null, string datacenterManagementServerName = null, double? megabytesOfMemory = default(double?), int? numberOfCores = default(int?), double? confidenceRatingInPercentage = default(double?), double? percentageCoresUtilization = default(double?), double? percentageMemoryUtilization = default(double?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.AssessedSqlRecommendedEntityData AssessedSqlRecommendedEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string machineName = null, string instanceName = null, Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus productSupportStatus = null, int? dbCount = default(int?), int? discoveredDBCount = default(int?), bool? hasScanOccurred = default(bool?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? recommendedAzureSqlTargetType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType?), Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability? recommendedSuitability = default(Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability?), Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlMISuitabilityDetails = null, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlDBSuitabilityDetails = null, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails azureSqlVmSuitabilityDetails = null, Azure.Core.ResourceIdentifier assessedSqlEntityArmId = null, bool? isClustered = default(bool?), bool? isHighAvailabilityEnabled = default(bool?), string sqlEdition = null, string sqlVersion = null, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary AssessmentErrorSummary(Azure.ResourceManager.Migration.Assessment.Models.AssessmentType? assessmentType = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentType?), int? count = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri AssessmentReportDownloadUri(System.Uri assessmentReportUri = null, System.DateTimeOffset expireOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedDisk AvsAssessedDisk(string name = null, string displayName = null, double? gigabytesProvisioned = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedNetworkAdapter AvsAssessedNetworkAdapter(string macAddress = null, System.Collections.Generic.IEnumerable<string> ipAddresses = null, string displayName = null, double? megabytesPerSecondReceived = default(double?), double? megabytesPerSecondTransmitted = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto AzureManagedDiskSkuDto(Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskType? diskType = default(Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskType?), Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize? diskSize = default(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize?), Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskRedundancy? diskRedundancy = default(Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskRedundancy?), double? storageCost = default(double?), double? recommendedSizeInGib = default(double?), double? recommendedThroughputInMbps = default(double?), double? recommendedIops = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlIaasSkuDto AzureSqlIaasSkuDto(Azure.ResourceManager.Migration.Assessment.Models.AzureVmSkuDto virtualMachineSize = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto> dataDiskSizes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto> logDiskSizes = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? azureSqlTargetType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPaasSkuDto AzureSqlPaasSkuDto(Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier? azureSqlServiceTier = default(Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier? azureSqlComputeTier = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration? azureSqlHardwareGeneration = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration?), double? storageMaxSizeInMB = default(double?), double? predictedDataSizeInMB = default(double?), double? predictedLogSizeInMB = default(double?), int? cores = default(int?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? azureSqlTargetType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSkuDto AzureVmSkuDto(Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily? azureVmFamily = default(Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily?), int? cores = default(int?), Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize? azureSkuName = default(Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize?), int? availableCores = default(int?), int? maxNetworkInterfaces = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.CostComponent CostComponent(Azure.ResourceManager.Migration.Assessment.Models.CostComponentName? name = default(Azure.ResourceManager.Migration.Assessment.Models.CostComponentName?), double? value = default(double?), string description = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.ImpactedAssessmentObject ImpactedAssessmentObject(string objectName = null, string objectType = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentData MigrationAssessmentAssessmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), System.Collections.Generic.IReadOnlyDictionary<string, int> assessmentErrorSummary = null, double? monthlyUltraStorageCost = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.CostComponent> costComponents = null, string eaSubscriptionId = null, Azure.ResourceManager.Migration.Assessment.Models.AzurePricingTier? azurePricingTier = default(Azure.ResourceManager.Migration.Assessment.Models.AzurePricingTier?), Azure.ResourceManager.Migration.Assessment.Models.AzureStorageRedundancy? azureStorageRedundancy = default(Azure.ResourceManager.Migration.Assessment.Models.AzureStorageRedundancy?), Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance? reservedInstance = default(Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance?), Azure.ResourceManager.Migration.Assessment.Models.AzureHybridUseBenefit? azureHybridUseBenefit = default(Azure.ResourceManager.Migration.Assessment.Models.AzureHybridUseBenefit?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType> azureDiskTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily> azureVmFamilies = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionBySupportStatus = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionByServicePackInsight = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionByOSName = null, double? monthlyComputeCost = default(double?), double? monthlyBandwidthCost = default(double?), double? monthlyStorageCost = default(double?), double? monthlyPremiumStorageCost = default(double?), double? monthlyStandardSsdStorageCost = default(double?), System.Collections.Generic.IReadOnlyDictionary<string, int> suitabilitySummary = null, int? numberOfMachines = default(int?), Azure.ResourceManager.Migration.Assessment.Models.VmUptime vmUptime = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType? groupType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentType? assessmentType = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentType?), Azure.Core.AzureLocation? azureLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode? azureOfferCode = default(Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode?), Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency? currency = default(Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency?), double? scalingFactor = default(double?), Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization? percentile = default(Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange? timeRange = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange?), System.DateTimeOffset? perfDataStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? perfDataEndOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage? stage = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage?), double? discountPercentage = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion?), double? confidenceRatingInPercentage = default(double?), System.DateTimeOffset? pricesQueriedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus? status = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus?), string schemaVersion = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentOptionData MigrationAssessmentAssessmentOptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.VmFamilyConfig> vmFamilies = null, System.Collections.Generic.IEnumerable<string> reservedInstanceVmFamilies = null, System.Collections.Generic.IEnumerable<string> reservedInstanceSupportedLocations = null, System.Collections.Generic.IEnumerable<string> reservedInstanceSupportedCurrencies = null, System.Collections.Generic.IEnumerable<string> reservedInstanceSupportedOffers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.UltraDiskAssessmentConfig> ultraDiskVmFamilies = null, System.Collections.Generic.IEnumerable<string> premiumDiskVmFamilies = null, System.Collections.Generic.IEnumerable<string> savingsPlanVmFamilies = null, System.Collections.Generic.IEnumerable<string> savingsPlanSupportedLocations = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectData MigrationAssessmentAssessmentProjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), System.DateTimeOffset? createOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string serviceEndpoint = null, string assessmentSolutionId = null, Azure.ResourceManager.Migration.Assessment.Models.AssessmentProjectStatus? projectStatus = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentProjectStatus?), string customerWorkspaceId = null, string customerWorkspaceLocation = null, string publicNetworkAccess = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.Core.ResourceIdentifier customerStorageAccountArmId = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAssessmentProjectSummaryData MigrationAssessmentAssessmentProjectSummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary> errorSummaryAffectedEntities = null, int? numberOfPrivateEndpointConnections = default(int?), int? numberOfGroups = default(int?), int? numberOfMachines = default(int?), int? numberOfImportMachines = default(int?), int? numberOfAssessments = default(int?), System.DateTimeOffset? lastAssessedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessedMachineData MigrationAssessmentAvsAssessedMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError> errors = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedDisk> disks = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedNetworkAdapter> networkAdapters = null, double? storageInUseGB = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityExplanation?), Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail?), Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType? typePropertiesType = default(Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType?), Azure.ResourceManager.Migration.Assessment.Models.MachineBootType? bootType = default(Azure.ResourceManager.Migration.Assessment.Models.MachineBootType?), string operatingSystemType = null, string operatingSystemName = null, string operatingSystemVersion = null, Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture? operatingSystemArchitecture = default(Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string displayName = null, string description = null, Azure.Core.ResourceIdentifier datacenterMachineArmId = null, Azure.Core.ResourceIdentifier datacenterManagementServerArmId = null, string datacenterManagementServerName = null, double? megabytesOfMemory = default(double?), int? numberOfCores = default(int?), double? confidenceRatingInPercentage = default(double?), double? percentageCoresUtilization = default(double?), double? percentageMemoryUtilization = default(double?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentData MigrationAssessmentAvsAssessmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), System.Collections.Generic.IReadOnlyDictionary<string, int> assessmentErrorSummary = null, Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel? failuresToTolerateAndRaidLevel = default(Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel?), double? vcpuOversubscription = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AvsNodeType? nodeType = default(Azure.ResourceManager.Migration.Assessment.Models.AvsNodeType?), Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance? reservedInstance = default(Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance?), double? totalMonthlyCost = default(double?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), Azure.ResourceManager.Migration.Assessment.Models.AvsSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migration.Assessment.Models.AvsSuitabilityExplanation?), int? numberOfNodes = default(int?), double? cpuUtilization = default(double?), double? ramUtilization = default(double?), double? storageUtilization = default(double?), double? totalCpuCores = default(double?), double? totalRamInGB = default(double?), double? totalStorageInGB = default(double?), int? numberOfMachines = default(int?), System.Collections.Generic.IReadOnlyDictionary<string, int> suitabilitySummary = null, double? memOvercommit = default(double?), double? dedupeCompression = default(double?), string limitingFactor = null, bool? isStretchClusterEnabled = default(bool?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType? groupType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentType? assessmentType = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentType?), Azure.Core.AzureLocation? azureLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode? azureOfferCode = default(Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode?), Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency? currency = default(Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency?), double? scalingFactor = default(double?), Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization? percentile = default(Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange? timeRange = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange?), System.DateTimeOffset? perfDataStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? perfDataEndOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage? stage = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage?), double? discountPercentage = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion?), double? confidenceRatingInPercentage = default(double?), System.DateTimeOffset? pricesQueriedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus? status = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus?), string schemaVersion = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentAvsAssessmentOptionData MigrationAssessmentAvsAssessmentOptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AvsSkuConfig> avsNodes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel> failuresToTolerateAndRaidLevelValues = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AvsNodeType> reservedInstanceAvsNodes = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> reservedInstanceSupportedLocations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency> reservedInstanceSupportedCurrencies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode> reservedInstanceSupportedOffers = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentDisk MigrationAssessmentDisk(double? gigabytesAllocated = default(double?), string displayName = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError MigrationAssessmentError(int? id = default(int?), string code = null, string runAsAccountId = null, string applianceName = null, string message = null, string summaryMessage = null, string agentScenario = null, string possibleCauses = null, string recommendedAction = null, string severity = null, System.Collections.Generic.IReadOnlyDictionary<string, string> messageParameters = null, System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string impactedAssessmentType = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData MigrationAssessmentGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupStatus? groupStatus = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupStatus?), int? machineCount = default(int?), System.Collections.Generic.IEnumerable<string> assessments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentType> supportedAssessmentTypes = null, bool? areAssessmentsRunning = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType? groupType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData MigrationAssessmentHyperVCollectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase agentProperties = null, string discoverySiteId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData MigrationAssessmentImportCollectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), string discoverySiteId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData MigrationAssessmentMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.WorkloadSummary workloadSummary = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError> errors = null, Azure.ResourceManager.Migration.Assessment.Models.ProcessorInfo hostProcessor = null, Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus productSupportStatus = null, Azure.Core.ResourceIdentifier discoveryMachineArmId = null, Azure.Core.ResourceIdentifier datacenterManagementServerArmId = null, string datacenterManagementServerName = null, Azure.ResourceManager.Migration.Assessment.Models.MachineBootType? bootType = default(Azure.ResourceManager.Migration.Assessment.Models.MachineBootType?), string displayName = null, double? megabytesOfMemory = default(double?), int? numberOfCores = default(int?), string operatingSystemType = null, string operatingSystemName = null, string operatingSystemVersion = null, string description = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentDisk> disks = null, System.Collections.Generic.IEnumerable<string> groups = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentNetworkAdapter> networkAdapters = null, System.Collections.Generic.IEnumerable<string> sqlInstances = null, System.Collections.Generic.IEnumerable<string> webApplications = null, System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentNetworkAdapter MigrationAssessmentNetworkAdapter(string macAddress = null, System.Collections.Generic.IEnumerable<string> ipAddresses = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData MigrationAssessmentPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData MigrationAssessmentPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData MigrationAssessmentServerCollectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase agentProperties = null, string discoverySiteId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentOptionData MigrationAssessmentSqlAssessmentOptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.VmFamilyConfig> vmFamilies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily> reservedInstanceVmFamilies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily> premiumDiskVmFamilies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily> savingsPlanVmFamilies = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> savingsPlanSupportedLocations = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> savingsPlanSupportedLocationsForPaas = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> reservedInstanceSupportedLocationsForIaas = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode> savingsPlanSupportedOffers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlPaaSTargetConfig> sqlSkus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType> reservedInstanceSqlTargets = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> reservedInstanceSupportedLocations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency> reservedInstanceSupportedCurrencies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode> reservedInstanceSupportedOffers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode> supportedOffers = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2Data MigrationAssessmentSqlAssessmentV2Data(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentOSLicense? osLicense = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentOSLicense?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentEnvironmentType? environmentType = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentEnvironmentType?), Azure.ResourceManager.Migration.Assessment.Models.EntityUptime entityUptime = null, Azure.ResourceManager.Migration.Assessment.Models.SqlOptimizationLogic? optimizationLogic = default(Azure.ResourceManager.Migration.Assessment.Models.SqlOptimizationLogic?), Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance? reservedInstanceForVm = default(Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance?), Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode? azureOfferCodeForVm = default(Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode?), string eaSubscriptionId = null, Azure.ResourceManager.Migration.Assessment.Models.SqlMISettings azureSqlManagedInstanceSettings = null, Azure.ResourceManager.Migration.Assessment.Models.SqlDBSettings azureSqlDatabaseSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily> azureSqlVmInstanceSeries = null, Azure.ResourceManager.Migration.Assessment.Models.MultiSubnetIntent? multiSubnetIntent = default(Azure.ResourceManager.Migration.Assessment.Models.MultiSubnetIntent?), Azure.ResourceManager.Migration.Assessment.Models.AsyncCommitModeIntent? asyncCommitModeIntent = default(Azure.ResourceManager.Migration.Assessment.Models.AsyncCommitModeIntent?), bool? isInternetAccessAvailable = default(bool?), Azure.Core.AzureLocation? disasterRecoveryLocation = default(Azure.Core.AzureLocation?), bool? enableHadrAssessment = default(bool?), Azure.ResourceManager.Migration.Assessment.Models.AzureSecurityOfferingType? azureSecurityOfferingType = default(Azure.ResourceManager.Migration.Assessment.Models.AzureSecurityOfferingType?), Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance? reservedInstance = default(Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance?), Azure.ResourceManager.Migration.Assessment.Models.SqlServerLicense? sqlServerLicense = default(Azure.ResourceManager.Migration.Assessment.Models.SqlServerLicense?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType? groupType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentType? assessmentType = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentType?), Azure.Core.AzureLocation? azureLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode? azureOfferCode = default(Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode?), Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency? currency = default(Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency?), double? scalingFactor = default(double?), Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization? percentile = default(Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange? timeRange = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange?), System.DateTimeOffset? perfDataStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? perfDataEndOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage? stage = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage?), double? discountPercentage = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion?), double? confidenceRatingInPercentage = default(double?), System.DateTimeOffset? pricesQueriedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus? status = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus?), string schemaVersion = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlAssessmentV2SummaryData MigrationAssessmentSqlAssessmentV2SummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2SummaryDetails> assessmentSummary = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionBySupportStatus = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionByServicePackInsight = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionBySqlVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionBySqlEdition = null, System.Collections.Generic.IReadOnlyDictionary<string, int> instanceDistributionBySizingCriterion = null, System.Collections.Generic.IReadOnlyDictionary<string, int> databaseDistributionBySizingCriterion = null, int? numberOfMachines = default(int?), int? numberOfSqlInstances = default(int?), int? numberOfSuccessfullyDiscoveredSqlInstances = default(int?), int? numberOfSqlDatabases = default(int?), int? numberOfFciInstances = default(int?), int? numberOfSqlAvailabilityGroups = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData MigrationAssessmentSqlCollectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase agentProperties = null, string discoverySiteId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData MigrationAssessmentVMwareCollectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase agentProperties = null, string discoverySiteId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationGuidelineContext MigrationGuidelineContext(string contextKey = null, string contextValue = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus ProductSupportStatus(string currentVersion = null, string servicePackStatus = null, string esuStatus = null, string supportStatus = null, int? eta = default(int?), string currentEsuYear = null, System.DateTimeOffset? mainstreamEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? extendedSupportEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? extendedSecurityUpdateYear1EndOn = default(System.DateTimeOffset?), System.DateTimeOffset? extendedSecurityUpdateYear2EndOn = default(System.DateTimeOffset?), System.DateTimeOffset? extendedSecurityUpdateYear3EndOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto SharedResourcesDto(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto> sharedDataDisks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto> sharedLogDisks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto> sharedTempDBDisks = null, int? numberOfMounts = default(int?), Azure.ResourceManager.Migration.Assessment.Models.AzureQuorumWitnessDtoQuorumWitnessType? quorumWitnessType = default(Azure.ResourceManager.Migration.Assessment.Models.AzureQuorumWitnessDtoQuorumWitnessType?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlAssessedNetworkAdapter SqlAssessedNetworkAdapter(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail?), Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityExplanation?), double? monthlyBandwidthCosts = default(double?), double? netGigabytesTransmittedPerMonth = default(double?), string name = null, string displayName = null, string macAddress = null, System.Collections.Generic.IEnumerable<string> ipAddresses = null, double? megabytesPerSecondReceived = default(double?), double? megabytesPerSecondTransmitted = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue SqlAssessmentMigrationIssue(string issueId = null, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssueCategory? issueCategory = default(Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssueCategory?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.ImpactedAssessmentObject> impactedObjects = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails SqlAssessmentV2IaasSuitabilityDetails(Azure.ResourceManager.Migration.Assessment.Models.AzureSqlIaasSkuDto azureSqlSku = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlIaasSkuDto> replicaAzureSqlSku = null, Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto sharedResources = null, double? monthlyComputeCost = default(double?), double? monthlyStorageCost = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.CostComponent> costComponents = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? securitySuitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), bool? shouldProvisionReplicas = default(bool?), Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode? skuReplicationMode = default(Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline> migrationGuidelines = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning> recommendationReasonings = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? migrationTargetPlatform = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue> migrationIssues = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails SqlAssessmentV2PaasSuitabilityDetails(Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPaasSkuDto azureSqlSku = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPaasSkuDto> replicaAzureSqlSku = null, Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto sharedResources = null, double? monthlyComputeCost = default(double?), double? monthlyStorageCost = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.CostComponent> costComponents = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? securitySuitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), bool? shouldProvisionReplicas = default(bool?), Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode? skuReplicationMode = default(Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline> migrationGuidelines = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning> recommendationReasonings = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? migrationTargetPlatform = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue> migrationIssues = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2SummaryDetails SqlAssessmentV2SummaryDetails(System.Collections.Generic.IReadOnlyDictionary<string, int> suitabilitySummary = null, double? monthlyComputeCost = default(double?), double? monthlyStorageCost = default(double?), double? monthlyLicenseCost = default(double?), double? confidenceScore = default(double?), double? monthlySecurityCost = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityGroupDataOverview SqlAvailabilityGroupDataOverview(string availabilityGroupId = null, string availabilityGroupName = null, Azure.Core.ResourceIdentifier sqlAvailabilityGroupSdsArmId = null, string sqlAvailabilityGroupEntityId = null, string sqlAvailabilityReplicaId = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityReplicaSummary SqlAvailabilityReplicaSummary(int? numberOfSynchronousReadReplicas = default(int?), int? numberOfSynchronousNonReadReplicas = default(int?), int? numberOfAsynchronousReadReplicas = default(int?), int? numberOfAsynchronousNonReadReplicas = default(int?), int? numberOfPrimaryReplicas = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadata SqlFciMetadata(Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState? state = default(Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState?), bool? isMultiSubnet = default(bool?), int? fciSharedDiskCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline SqlMigrationGuideline(string guidelineId = null, Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuidelineCategory? migrationGuidelineCategory = default(Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuidelineCategory?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.MigrationGuidelineContext> migrationGuidelineContext = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning SqlRecommendationReasoning(string reasoningId = null, string reasoningString = null, string reasoningCategory = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoningContext> contextParameters = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoningContext SqlRecommendationReasoningContext(string contextKey = null, string contextValue = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.UltraDiskAssessmentConfig UltraDiskAssessmentConfig(string familyName = null, System.Collections.Generic.IEnumerable<string> targetLocations = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.VmFamilyConfig VmFamilyConfig(string familyName = null, System.Collections.Generic.IEnumerable<string> targetLocations = null, System.Collections.Generic.IEnumerable<string> category = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.WorkloadSummary WorkloadSummary(int? oracleInstances = default(int?), int? springApps = default(int?)) { throw null; }
    }
    public partial class AssessedDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedDataDisk>
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
        public Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize? RecommendedDiskSize { get { throw null; } }
        public int? RecommendedDiskSizeGigabytes { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType? RecommendedDiskType { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessedDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessedDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedDisk>
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
        public Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize? RecommendedDiskSize { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType? RecommendedDiskType { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessedDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessedDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessedMachineType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessedMachineType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType AssessedMachine { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType AvsAssessedMachine { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType SqlAssessedMachine { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType left, Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType left, Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessedNetworkAdapter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedNetworkAdapter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedNetworkAdapter>
    {
        internal AssessedNetworkAdapter() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPAddresses { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public double? MegabytesPerSecondReceived { get { throw null; } }
        public double? MegabytesPerSecondTransmitted { get { throw null; } }
        public double? MonthlyBandwidthCosts { get { throw null; } }
        public double? NetGigabytesTransmittedPerMonth { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessedNetworkAdapter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedNetworkAdapter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedNetworkAdapter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessedNetworkAdapter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedNetworkAdapter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedNetworkAdapter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedNetworkAdapter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlInstanceDatabaseSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDatabaseSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDatabaseSummary>
    {
        internal AssessedSqlInstanceDatabaseSummary() { }
        public double? LargestDatabaseSizeInMB { get { throw null; } }
        public int? NumberOfUserDatabases { get { throw null; } }
        public double? TotalDatabaseSizeInMB { get { throw null; } }
        public int? TotalDiscoveredUserDatabases { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDatabaseSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDatabaseSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDatabaseSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDatabaseSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDatabaseSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDatabaseSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDatabaseSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlInstanceDiskDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDiskDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDiskDetails>
    {
        internal AssessedSqlInstanceDiskDetails() { }
        public string DiskId { get { throw null; } }
        public double? DiskSizeInMB { get { throw null; } }
        public double? MegabytesPerSecondOfRead { get { throw null; } }
        public double? MegabytesPerSecondOfWrite { get { throw null; } }
        public double? NumberOfReadOperationsPerSecond { get { throw null; } }
        public double? NumberOfWriteOperationsPerSecond { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDiskDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDiskDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDiskDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDiskDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDiskDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDiskDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDiskDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlInstanceStorageDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceStorageDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceStorageDetails>
    {
        internal AssessedSqlInstanceStorageDetails() { }
        public double? DiskSizeInMB { get { throw null; } }
        public double? MegabytesPerSecondOfRead { get { throw null; } }
        public double? MegabytesPerSecondOfWrite { get { throw null; } }
        public double? NumberOfReadOperationsPerSecond { get { throw null; } }
        public double? NumberOfWriteOperationsPerSecond { get { throw null; } }
        public string StorageType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceStorageDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceStorageDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceStorageDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceStorageDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceStorageDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceStorageDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceStorageDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessedSqlInstanceSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceSummary>
    {
        internal AssessedSqlInstanceSummary() { }
        public string InstanceId { get { throw null; } }
        public string InstanceName { get { throw null; } }
        public bool? IsClustered { get { throw null; } }
        public bool? IsHighAvailabilityEnabled { get { throw null; } }
        public string SqlEdition { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlFciState? SqlFciState { get { throw null; } }
        public string SqlInstanceEntityId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SqlInstanceSdsArmId { get { throw null; } }
        public string SqlVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentEnvironmentType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentEnvironmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentEnvironmentType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentEnvironmentType Production { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentEnvironmentType Test { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentEnvironmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentEnvironmentType left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentEnvironmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentEnvironmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentEnvironmentType left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentEnvironmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessmentErrorSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary>
    {
        internal AssessmentErrorSummary() { }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentType? AssessmentType { get { throw null; } }
        public int? Count { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentProjectStatus : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentProjectStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentProjectStatus(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentProjectStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentProjectStatus Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentProjectStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentProjectStatus left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentProjectStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentProjectStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentProjectStatus left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentProjectStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessmentReportDownloadUri : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri>
    {
        internal AssessmentReportDownloadUri() { }
        public System.Uri AssessmentReportUri { get { throw null; } }
        public System.DateTimeOffset ExpireOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentSizingCriterion : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentSizingCriterion(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion AsOnPremises { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion PerformanceBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentStage : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentStage(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage Approved { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage InProgress { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage UnderReview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentStatus : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentStatus(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus Created { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus OutDated { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus OutOfSync { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus Updated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentTimeRange : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentTimeRange(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange Custom { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange Day { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange Month { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange Week { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentType AvsAssessment { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentType MachineAssessment { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentType SqlAssessment { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentType Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentType WebAppAssessment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentType left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentType left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AsyncCommitModeIntent : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AsyncCommitModeIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AsyncCommitModeIntent(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AsyncCommitModeIntent DisasterRecovery { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AsyncCommitModeIntent HighAvailability { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AsyncCommitModeIntent None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AsyncCommitModeIntent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AsyncCommitModeIntent left, Azure.ResourceManager.Migration.Assessment.Models.AsyncCommitModeIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AsyncCommitModeIntent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AsyncCommitModeIntent left, Azure.ResourceManager.Migration.Assessment.Models.AsyncCommitModeIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsAssessedDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedDisk>
    {
        internal AvsAssessedDisk() { }
        public string DisplayName { get { throw null; } }
        public double? GigabytesProvisioned { get { throw null; } }
        public double? MegabytesPerSecondOfRead { get { throw null; } }
        public double? MegabytesPerSecondOfWrite { get { throw null; } }
        public string Name { get { throw null; } }
        public double? NumberOfReadOperationsPerSecond { get { throw null; } }
        public double? NumberOfWriteOperationsPerSecond { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvsAssessedNetworkAdapter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedNetworkAdapter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedNetworkAdapter>
    {
        internal AvsAssessedNetworkAdapter() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPAddresses { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public double? MegabytesPerSecondReceived { get { throw null; } }
        public double? MegabytesPerSecondTransmitted { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedNetworkAdapter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedNetworkAdapter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedNetworkAdapter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedNetworkAdapter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedNetworkAdapter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedNetworkAdapter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedNetworkAdapter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsNodeType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AvsNodeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsNodeType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsNodeType AV36 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsNodeType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AvsNodeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AvsNodeType left, Azure.ResourceManager.Migration.Assessment.Models.AvsNodeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AvsNodeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AvsNodeType left, Azure.ResourceManager.Migration.Assessment.Models.AvsNodeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvsSkuConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AvsSkuConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AvsSkuConfig>
    {
        public AvsSkuConfig() { }
        public Azure.ResourceManager.Migration.Assessment.Models.AvsNodeType? NodeType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> TargetLocations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AvsSkuConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AvsSkuConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AvsSkuConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AvsSkuConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AvsSkuConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AvsSkuConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AvsSkuConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsSuitabilityExplanation : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AvsSuitabilityExplanation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsSuitabilityExplanation(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsSuitabilityExplanation NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsSuitabilityExplanation Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsSuitabilityExplanation UnsupportedLocationForSelectedNode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AvsSuitabilityExplanation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AvsSuitabilityExplanation left, Azure.ResourceManager.Migration.Assessment.Models.AvsSuitabilityExplanation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AvsSuitabilityExplanation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AvsSuitabilityExplanation left, Azure.ResourceManager.Migration.Assessment.Models.AvsSuitabilityExplanation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsVmSuitabilityDetail : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsVmSuitabilityDetail(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail None { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail PercentageOfCoresUtilizedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail PercentageOfCoresUtilizedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail PercentageOfMemoryUtilizedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail PercentageOfMemoryUtilizedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail PercentageOfStorageUtilizedOutOfRange { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail left, Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail left, Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvsVmSuitabilityExplanation : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityExplanation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvsVmSuitabilityExplanation(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityExplanation IPV6NotSupported { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityExplanation NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityExplanation Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityExplanation UnsupportedOperatingSystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityExplanation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityExplanation left, Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityExplanation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityExplanation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityExplanation left, Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityExplanation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureCurrency : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureCurrency(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency ARS { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency AUD { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency BRL { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency CAD { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency CHF { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency CNY { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency DKK { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency EUR { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency GBP { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency HKD { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency IdR { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency INR { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency JPY { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency KRW { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency MXN { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency MYR { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency NOK { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency NZD { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency RUB { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency SAR { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency SEK { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency TRY { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency TWD { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency USD { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency ZAR { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency left, Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency left, Azure.ResourceManager.Migration.Assessment.Models.AzureCurrency right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureDiskSize : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureDiskSize(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize PremiumP1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize PremiumP10 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize PremiumP15 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize PremiumP2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize PremiumP20 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize PremiumP3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize PremiumP30 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize PremiumP4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize PremiumP40 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize PremiumP50 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize PremiumP6 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize PremiumP60 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize PremiumP70 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize PremiumP80 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize PremiumV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardS10 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardS15 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardS20 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardS30 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardS4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardS40 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardS50 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardS6 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardS60 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardS70 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardS80 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardSsdE1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardSsdE10 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardSsdE15 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardSsdE2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardSsdE20 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardSsdE3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardSsdE30 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardSsdE4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardSsdE40 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardSsdE50 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardSsdE6 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardSsdE60 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardSsdE70 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize StandardSsdE80 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize Ultra { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize left, Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize left, Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureDiskSuitabilityDetail : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureDiskSuitabilityDetail(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail DiskGigabytesConsumedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail DiskGigabytesConsumedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail DiskGigabytesProvisionedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail DiskGigabytesProvisionedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail MegabytesPerSecondOfReadMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail MegabytesPerSecondOfReadOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail MegabytesPerSecondOfWriteMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail MegabytesPerSecondOfWriteOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail None { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail NumberOfReadOperationsPerSecondMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail NumberOfReadOperationsPerSecondOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail NumberOfWriteOperationsPerSecondMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail NumberOfWriteOperationsPerSecondOutOfRange { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail left, Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail left, Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureDiskSuitabilityExplanation : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureDiskSuitabilityExplanation(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation DiskSizeGreaterThanSupported { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation InternalErrorOccurredForDiskEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation NoDiskSizeFoundForSelectedRedundancy { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation NoDiskSizeFoundInSelectedLocation { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation NoEAPriceFoundForDiskSize { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation NoSuitableDiskSizeForIops { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation NoSuitableDiskSizeForThroughput { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation left, Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation left, Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSuitabilityExplanation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureDiskType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureDiskType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType Premium { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType PremiumV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType Standard { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType StandardOrPremium { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType StandardSsd { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType Ultra { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType left, Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType left, Azure.ResourceManager.Migration.Assessment.Models.AzureDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureHybridUseBenefit : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureHybridUseBenefit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureHybridUseBenefit(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureHybridUseBenefit No { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureHybridUseBenefit Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureHybridUseBenefit Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureHybridUseBenefit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureHybridUseBenefit left, Azure.ResourceManager.Migration.Assessment.Models.AzureHybridUseBenefit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureHybridUseBenefit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureHybridUseBenefit left, Azure.ResourceManager.Migration.Assessment.Models.AzureHybridUseBenefit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureManagedDiskSkuDto : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto>
    {
        internal AzureManagedDiskSkuDto() { }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskRedundancy? DiskRedundancy { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureDiskSize? DiskSize { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskType? DiskType { get { throw null; } }
        public double? RecommendedIops { get { throw null; } }
        public double? RecommendedSizeInGib { get { throw null; } }
        public double? RecommendedThroughputInMbps { get { throw null; } }
        public double? StorageCost { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureManagedDiskSkuDtoDiskRedundancy : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureManagedDiskSkuDtoDiskRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskRedundancy Lrs { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskRedundancy Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskRedundancy Zrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskRedundancy left, Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskRedundancy left, Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureManagedDiskSkuDtoDiskType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureManagedDiskSkuDtoDiskType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskType Premium { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskType PremiumV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskType Standard { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskType StandardOrPremium { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskType StandardSsd { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskType Ultra { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskType left, Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskType left, Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDtoDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureNetworkAdapterSuitabilityDetail : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureNetworkAdapterSuitabilityDetail(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail MegabytesOfDataRecievedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail MegabytesOfDataRecievedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail MegabytesOfDataTransmittedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail MegabytesOfDataTransmittedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail left, Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail left, Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureNetworkAdapterSuitabilityExplanation : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityExplanation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureNetworkAdapterSuitabilityExplanation(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityExplanation InternalErrorOccurred { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityExplanation NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityExplanation Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityExplanation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityExplanation left, Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityExplanation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityExplanation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityExplanation left, Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityExplanation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureOfferCode : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureOfferCode(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode EA { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0003P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0022P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0023P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0025P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0029P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0036P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0044P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0059P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0060P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0062P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0063P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0064P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0111P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0120P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0121P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0122P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0123P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0124P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0125P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0126P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0127P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0128P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0129P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0130P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0144P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0148P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0149P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZR0243P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZRDE0003P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZRDE0044P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSAZRUSGOV0003P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSMCAZR0044P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSMCAZR0059P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSMCAZR0060P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSMCAZR0063P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSMCAZR0120P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSMCAZR0121P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSMCAZR0125P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode MSMCAZR0128P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode SavingsPlan1Year { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode SavingsPlan3Year { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode left, Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode left, Azure.ResourceManager.Migration.Assessment.Models.AzureOfferCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzurePricingTier : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzurePricingTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzurePricingTier(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzurePricingTier Basic { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzurePricingTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzurePricingTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzurePricingTier left, Azure.ResourceManager.Migration.Assessment.Models.AzurePricingTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzurePricingTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzurePricingTier left, Azure.ResourceManager.Migration.Assessment.Models.AzurePricingTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureQuorumWitnessDtoQuorumWitnessType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureQuorumWitnessDtoQuorumWitnessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureQuorumWitnessDtoQuorumWitnessType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureQuorumWitnessDtoQuorumWitnessType Cloud { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureQuorumWitnessDtoQuorumWitnessType Disk { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureQuorumWitnessDtoQuorumWitnessType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureQuorumWitnessDtoQuorumWitnessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureQuorumWitnessDtoQuorumWitnessType left, Azure.ResourceManager.Migration.Assessment.Models.AzureQuorumWitnessDtoQuorumWitnessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureQuorumWitnessDtoQuorumWitnessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureQuorumWitnessDtoQuorumWitnessType left, Azure.ResourceManager.Migration.Assessment.Models.AzureQuorumWitnessDtoQuorumWitnessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureReservedInstance : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureReservedInstance(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance None { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance RI1Year { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance RI3Year { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance left, Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance left, Azure.ResourceManager.Migration.Assessment.Models.AzureReservedInstance right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureSecurityOfferingType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureSecurityOfferingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureSecurityOfferingType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSecurityOfferingType MDC { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSecurityOfferingType NO { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureSecurityOfferingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureSecurityOfferingType left, Azure.ResourceManager.Migration.Assessment.Models.AzureSecurityOfferingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureSecurityOfferingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureSecurityOfferingType left, Azure.ResourceManager.Migration.Assessment.Models.AzureSecurityOfferingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureSqlDataBaseType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlDataBaseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureSqlDataBaseType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlDataBaseType Automatic { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlDataBaseType ElasticPool { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlDataBaseType SingleDatabase { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlDataBaseType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureSqlDataBaseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureSqlDataBaseType left, Azure.ResourceManager.Migration.Assessment.Models.AzureSqlDataBaseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureSqlDataBaseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureSqlDataBaseType left, Azure.ResourceManager.Migration.Assessment.Models.AzureSqlDataBaseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureSqlIaasSkuDto : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlIaasSkuDto>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlIaasSkuDto>
    {
        internal AzureSqlIaasSkuDto() { }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? AzureSqlTargetType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto> DataDiskSizes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto> LogDiskSizes { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureVmSkuDto VirtualMachineSize { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AzureSqlIaasSkuDto System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlIaasSkuDto>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlIaasSkuDto>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AzureSqlIaasSkuDto System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlIaasSkuDto>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlIaasSkuDto>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlIaasSkuDto>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureSqlInstanceType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlInstanceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureSqlInstanceType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlInstanceType Automatic { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlInstanceType InstancePools { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlInstanceType SingleInstance { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlInstanceType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureSqlInstanceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureSqlInstanceType left, Azure.ResourceManager.Migration.Assessment.Models.AzureSqlInstanceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureSqlInstanceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureSqlInstanceType left, Azure.ResourceManager.Migration.Assessment.Models.AzureSqlInstanceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureSqlPaasSkuDto : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPaasSkuDto>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPaasSkuDto>
    {
        internal AzureSqlPaasSkuDto() { }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier? AzureSqlComputeTier { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration? AzureSqlHardwareGeneration { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier? AzureSqlServiceTier { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? AzureSqlTargetType { get { throw null; } }
        public int? Cores { get { throw null; } }
        public double? PredictedDataSizeInMB { get { throw null; } }
        public double? PredictedLogSizeInMB { get { throw null; } }
        public double? StorageMaxSizeInMB { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPaasSkuDto System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPaasSkuDto>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPaasSkuDto>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPaasSkuDto System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPaasSkuDto>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPaasSkuDto>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPaasSkuDto>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureSqlPurchaseModel : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPurchaseModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureSqlPurchaseModel(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPurchaseModel Dtu { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPurchaseModel Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPurchaseModel VCore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPurchaseModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPurchaseModel left, Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPurchaseModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPurchaseModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPurchaseModel left, Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPurchaseModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureSqlServiceTier : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureSqlServiceTier(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier Automatic { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier BusinessCritical { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier HyperScale { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier left, Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier left, Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureStorageRedundancy : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureStorageRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureStorageRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureStorageRedundancy GeoRedundant { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureStorageRedundancy LocallyRedundant { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureStorageRedundancy ReadAccessGeoRedundant { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureStorageRedundancy Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureStorageRedundancy ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureStorageRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureStorageRedundancy left, Azure.ResourceManager.Migration.Assessment.Models.AzureStorageRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureStorageRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureStorageRedundancy left, Azure.ResourceManager.Migration.Assessment.Models.AzureStorageRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureVmFamily : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureVmFamily(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Av2Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily BasicA0A4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Dadsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Dasv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Dasv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Dav4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily DCSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Ddsv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Ddsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Ddv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Ddv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily DSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily DSSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily DSv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Dsv3Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Dsv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Dsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Dv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Dv3Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Dv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Dv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Eadsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Easv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Easv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Eav4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Ebdsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Ebsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Edsv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Edsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Edv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Edv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Esv3Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Esv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Esv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Ev3Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Ev4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Ev5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily FSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily FsSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Fsv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily GSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily GSSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily HSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily LsSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Lsv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Mdsv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily MSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Msv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Mv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily StandardA0A7 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily StandardA8A11 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily left, Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily left, Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureVmSize : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureVmSize(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize BasicA0 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize BasicA1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize BasicA2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize BasicA3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize BasicA4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA0 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA10 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA11 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA1V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA2MV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA2V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA4MV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA4V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA6 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA7 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA8 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA8MV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA8V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardA9 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD11 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD11V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD12 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD12V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD13 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD13V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD14 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD14V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD15V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD16AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD16AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD16AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD16AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD16DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD16DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD16DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD16DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD16SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD16SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD16SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD16V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD16V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD16V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD1V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD2AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD2AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD2AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD2AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD2DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD2DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD2DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD2DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD2SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD2SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD2SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD2V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD2V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD2V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD2V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD32AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD32AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD32AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD32AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD32DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD32DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD32DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD32DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD32SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD32SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD32SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD32V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD32V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD32V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD3V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD48AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD48AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD48AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD48AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD48DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD48DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD48DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD48DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD48SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD48SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD48V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD48V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD4AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD4AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD4AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD4AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD4DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD4DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD4DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD4DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD4SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD4SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD4SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD4V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD4V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD4V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD4V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD5V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD64AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD64AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD64AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD64AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD64DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD64DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD64DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD64DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD64SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD64SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD64SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD64V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD64V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD64V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD8AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD8AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD8AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD8AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD8DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD8DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD8DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD8DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD8SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD8SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD8SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD8V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD8V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD8V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD96AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD96AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD96AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD96AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD96DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD96DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD96SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardD96V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDC2S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDC4S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS11 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS111V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS11V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS12 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS121V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS122V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS12V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS13 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS132V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS134V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS13V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS14 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS144V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS148V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS14V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS15V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS1V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS2V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS3V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS4V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardDS5V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE104IdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE104IdV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE104IsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE104IV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE164AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE164AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE164AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE164DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE164DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE164SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE164SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE164SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE168AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE168AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE168AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE168DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE168DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE168SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE168SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE168SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE16AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE16AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE16AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE16AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE16BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE16BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE16DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE16DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE16DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE16DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE16SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE16SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE16SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE16V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE16V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE16V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE20AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE20AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE20AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE20AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE20DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE20DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE20DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE20DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE20SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE20SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE20SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE20V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE20V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE20V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE2AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE2AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE2AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE2AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE2BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE2BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE2DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE2DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE2DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE2DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE2SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE2SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE2SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE2V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE2V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE2V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE3216AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE3216AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE3216AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE3216DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE3216DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE3216SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE3216SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE3216SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE328AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE328AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE328AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE328DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE328DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE328SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE328SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE328SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE32AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE32AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE32AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE32AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE32BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE32BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE32DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE32DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE32DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE32DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE32SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE32SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE32SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE32V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE32V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE32V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE42AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE42AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE42AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE42DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE42DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE42SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE42SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE42SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE48AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE48AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE48AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE48AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE48BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE48BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE48DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE48DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE48DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE48DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE48SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE48SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE48SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE48V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE48V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE48V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE4AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE4AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE4AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE4AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE4BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE4BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE4DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE4DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE4DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE4DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE4SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE4SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE4SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE4V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE4V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE4V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE6416AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE6416AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE6416AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE6416DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE6416DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE6416SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE6416SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE6416SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE6432AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE6432AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE6432AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE6432DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE6432DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE6432SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE6432SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE6432SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64IsV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64IV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE64V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE80IdsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE80IsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE82AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE82AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE82AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE82DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE82DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE82SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE82SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE82SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE84AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE84AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE84AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE84DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE84DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE84SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE84SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE84SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE8AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE8AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE8AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE8AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE8BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE8BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE8DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE8DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE8DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE8DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE8SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE8SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE8SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE8V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE8V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE8V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE9624AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE9624AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE9624AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE9624DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE9624SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE9648AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE9648AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE9648AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE9648DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE9648SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE96AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE96AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE96AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE96AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE96DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE96DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE96SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardE96V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF16 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF16S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF16SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF1S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF2S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF2SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF32SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF48SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF4S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF4SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF64SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF72SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF8 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF8S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardF8SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardG1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardG2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardG3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardG4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardG5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardGS1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardGS2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardGS3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardGS4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardGS44 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardGS48 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardGS5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardGS516 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardGS58 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardH16 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardH16M { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardH16Mr { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardH16R { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardH8 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardH8M { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardL16S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardL16SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardL32S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardL32SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardL48SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardL4S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardL64SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardL80SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardL8S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardL8SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM128 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM12832Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM12864Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM128DmsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM128DsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM128M { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM128Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM128MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM128S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM128SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM164Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM168Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM16Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM192IdmsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM192IdsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM192ImsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM192IsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM208MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM208SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM3216Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM328Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM32DmsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM32Ls { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM32Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM32MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM32Ts { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM416208MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM416208SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM416MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM416SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM64 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM6416Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM6432Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM64DmsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM64DsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM64Ls { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM64M { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM64Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM64MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM64S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM64SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM82Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM84Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize StandardM8Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize left, Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize left, Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureVmSkuDto : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AzureVmSkuDto>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AzureVmSkuDto>
    {
        internal AzureVmSkuDto() { }
        public int? AvailableCores { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureVmSize? AzureSkuName { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureVmFamily? AzureVmFamily { get { throw null; } }
        public int? Cores { get { throw null; } }
        public int? MaxNetworkInterfaces { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AzureVmSkuDto System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AzureVmSkuDto>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AzureVmSkuDto>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AzureVmSkuDto System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AzureVmSkuDto>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AzureVmSkuDto>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AzureVmSkuDto>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureVmSuitabilityDetail : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureVmSuitabilityDetail(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail CannotReportBandwidthCosts { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail CannotReportComputeCost { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail CannotReportStorageCost { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail None { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail PercentageOfCoresUtilizedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail PercentageOfCoresUtilizedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail PercentageOfMemoryUtilizedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail PercentageOfMemoryUtilizedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail RecommendedSizeHasLessNetworkAdapters { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail left, Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail left, Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureVmSuitabilityExplanation : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureVmSuitabilityExplanation(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation BootTypeNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation BootTypeUnknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation CheckCentOSVersion { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation CheckCoreOSLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation CheckDebianLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation CheckOpenSuseLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation CheckOracleLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation CheckRedHatLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation CheckSuseLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation CheckUbuntuLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation CheckWindowsServer2008R2Version { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation EndorsedWithConditionsLinuxDistributions { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation GuestOperatingSystemArchitectureNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation GuestOperatingSystemNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation GuestOperatingSystemUnknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation InternalErrorOccurredDuringComputeEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation InternalErrorOccurredDuringNetworkEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation InternalErrorOccurredDuringStorageEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation MoreDisksThanSupported { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation NoEAPriceFoundForVmSize { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation NoGuestOperatingSystemConditionallySupported { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation NoSuitableVmSizeFound { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation NoVmSizeForBasicPricingTier { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation NoVmSizeForSelectedAzureLocation { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation NoVmSizeForSelectedPricingTier { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation NoVmSizeForStandardPricingTier { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation NoVmSizeFoundForOfferCurrencyReservedInstance { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation NoVmSizeInSelectedFamilyFound { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation NoVmSizeSupportsNetworkPerformance { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation NoVmSizeSupportsStoragePerformance { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation OneOrMoreAdaptersNotSuitable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation OneOrMoreDisksNotSuitable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation UnendorsedLinuxDistributions { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation WindowsClientVersionsConditionallySupported { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation WindowsOSNoLongerUnderMSSupport { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation WindowsServerVersionConditionallySupported { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation WindowsServerVersionsSupportedWithCaveat { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation left, Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation left, Azure.ResourceManager.Migration.Assessment.Models.AzureVmSuitabilityExplanation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CollectorAgentPropertiesBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase>
    {
        public CollectorAgentPropertiesBase() { }
        public string Id { get { throw null; } set { } }
        public System.DateTimeOffset? LastHeartbeatOn { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentSpnPropertiesBase SpnDetails { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CollectorAgentSpnPropertiesBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentSpnPropertiesBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentSpnPropertiesBase>
    {
        public CollectorAgentSpnPropertiesBase() { }
        public string ApplicationId { get { throw null; } set { } }
        public string Audience { get { throw null; } set { } }
        public string Authority { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentSpnPropertiesBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentSpnPropertiesBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentSpnPropertiesBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentSpnPropertiesBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentSpnPropertiesBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentSpnPropertiesBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentSpnPropertiesBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CompatibilityLevel : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CompatibilityLevel(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel CompatLevel100 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel CompatLevel110 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel CompatLevel120 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel CompatLevel130 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel CompatLevel140 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel CompatLevel150 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel CompatLevel80 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel CompatLevel90 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel left, Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel left, Azure.ResourceManager.Migration.Assessment.Models.CompatibilityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CostComponent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.CostComponent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.CostComponent>
    {
        public CostComponent() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.CostComponentName? Name { get { throw null; } }
        public double? Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.CostComponent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.CostComponent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.CostComponent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.CostComponent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.CostComponent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.CostComponent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.CostComponent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CostComponentName : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.CostComponentName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CostComponentName(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.CostComponentName MonthlyAzureHybridCostSavings { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.CostComponentName MonthlyPremiumV2StorageCost { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.CostComponentName MonthlySecurityCost { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.CostComponentName Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.CostComponentName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.CostComponentName left, Azure.ResourceManager.Migration.Assessment.Models.CostComponentName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.CostComponentName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.CostComponentName left, Azure.ResourceManager.Migration.Assessment.Models.CostComponentName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityUptime : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.EntityUptime>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.EntityUptime>
    {
        public EntityUptime() { }
        public int? DaysPerMonth { get { throw null; } set { } }
        public int? HoursPerDay { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.EntityUptime System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.EntityUptime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.EntityUptime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.EntityUptime System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.EntityUptime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.EntityUptime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.EntityUptime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FttAndRaidLevel : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FttAndRaidLevel(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel Ftt1Raid1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel Ftt1Raid5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel Ftt2Raid1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel Ftt2Raid6 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel Ftt3Raid1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel left, Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel left, Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GuestOperatingSystemArchitecture : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GuestOperatingSystemArchitecture(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture X64 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture X86 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture left, Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture left, Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImpactedAssessmentObject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.ImpactedAssessmentObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.ImpactedAssessmentObject>
    {
        internal ImpactedAssessmentObject() { }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.ImpactedAssessmentObject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.ImpactedAssessmentObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.ImpactedAssessmentObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.ImpactedAssessmentObject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.ImpactedAssessmentObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.ImpactedAssessmentObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.ImpactedAssessmentObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineBootType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.MachineBootType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineBootType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MachineBootType Bios { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MachineBootType Efi { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MachineBootType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MachineBootType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.MachineBootType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.MachineBootType left, Azure.ResourceManager.Migration.Assessment.Models.MachineBootType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.MachineBootType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.MachineBootType left, Azure.ResourceManager.Migration.Assessment.Models.MachineBootType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrateGroupUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateContent>
    {
        public MigrateGroupUpdateContent() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrateGroupUpdateOperationType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrateGroupUpdateOperationType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateOperationType Add { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateOperationType Remove { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateOperationType left, Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateOperationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateOperationType left, Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrateGroupUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateProperties>
    {
        public MigrateGroupUpdateProperties() { }
        public System.Collections.Generic.IList<string> Machines { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateOperationType? OperationType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrateGroupUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentAssessmentProjectPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentAssessmentProjectPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentAssessmentProjectPatch>
    {
        public MigrationAssessmentAssessmentProjectPatch() { }
        public string AssessmentSolutionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CustomerStorageAccountArmId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CustomerWorkspaceId { get { throw null; } set { } }
        public string CustomerWorkspaceLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentProjectStatus? ProjectStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentAssessmentProjectPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentAssessmentProjectPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentAssessmentProjectPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentAssessmentProjectPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentAssessmentProjectPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentAssessmentProjectPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentAssessmentProjectPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationAssessmentCloudSuitability : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationAssessmentCloudSuitability(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability ConditionallySuitable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability NotSuitable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability ReadinessUnknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability Suitable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationAssessmentComputeTier : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationAssessmentComputeTier(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier Automatic { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier Provisioned { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier Serverless { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrationAssessmentDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentDisk>
    {
        internal MigrationAssessmentDisk() { }
        public string DisplayName { get { throw null; } }
        public double? GigabytesAllocated { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError>
    {
        internal MigrationAssessmentError() { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationAssessmentGroupStatus : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationAssessmentGroupStatus(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupStatus Created { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupStatus Updated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupStatus left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupStatus left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationAssessmentGroupType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationAssessmentGroupType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType Default { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType Import { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationAssessmentHardwareGeneration : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationAssessmentHardwareGeneration(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration Automatic { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration DCSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration Fsv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration Gen5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration MSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrationAssessmentNetworkAdapter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentNetworkAdapter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentNetworkAdapter>
    {
        internal MigrationAssessmentNetworkAdapter() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPAddresses { get { throw null; } }
        public string MacAddress { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentNetworkAdapter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentNetworkAdapter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentNetworkAdapter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentNetworkAdapter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentNetworkAdapter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentNetworkAdapter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentNetworkAdapter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationAssessmentOSLicense : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentOSLicense>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationAssessmentOSLicense(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentOSLicense No { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentOSLicense Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentOSLicense Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentOSLicense other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentOSLicense left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentOSLicense right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentOSLicense (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentOSLicense left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentOSLicense right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationAssessmentPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationAssessmentPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationAssessmentPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationAssessmentPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrationAssessmentPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateLinkServiceConnectionState>
    {
        public MigrationAssessmentPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationAssessmentProvisioningState : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationAssessmentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationAssessmentTargetType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationAssessmentTargetType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType AzureSqlDatabase { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType AzureSqlManagedInstance { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType AzureSqlVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType AzureVirtualMachine { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType Recommended { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrationGuidelineContext : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationGuidelineContext>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationGuidelineContext>
    {
        internal MigrationGuidelineContext() { }
        public string ContextKey { get { throw null; } }
        public string ContextValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationGuidelineContext System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationGuidelineContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationGuidelineContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationGuidelineContext System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationGuidelineContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationGuidelineContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationGuidelineContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MultiSubnetIntent : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.MultiSubnetIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MultiSubnetIntent(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MultiSubnetIntent DisasterRecovery { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MultiSubnetIntent HighAvailability { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MultiSubnetIntent None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.MultiSubnetIntent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.MultiSubnetIntent left, Azure.ResourceManager.Migration.Assessment.Models.MultiSubnetIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.MultiSubnetIntent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.MultiSubnetIntent left, Azure.ResourceManager.Migration.Assessment.Models.MultiSubnetIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PercentileOfUtilization : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PercentileOfUtilization(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization Percentile50 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization Percentile90 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization Percentile95 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization Percentile99 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization left, Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization left, Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProcessorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.ProcessorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.ProcessorInfo>
    {
        public ProcessorInfo() { }
        public string Name { get { throw null; } set { } }
        public int? NumberOfCoresPerSocket { get { throw null; } set { } }
        public int? NumberOfSockets { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.ProcessorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.ProcessorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.ProcessorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.ProcessorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.ProcessorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.ProcessorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.ProcessorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProductSupportStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.ProductSupportStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendedSuitability : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendedSuitability(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability ConditionallySuitableForSqlDB { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability ConditionallySuitableForSqlMI { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability ConditionallySuitableForSqlVm { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability ConditionallySuitableForVm { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability NotSuitable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability PotentiallySuitableForVm { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability ReadinessUnknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability SuitableForSqlDB { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability SuitableForSqlMI { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability SuitableForSqlVm { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability SuitableForVm { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability left, Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability left, Azure.ResourceManager.Migration.Assessment.Models.RecommendedSuitability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SharedResourcesDto : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto>
    {
        internal SharedResourcesDto() { }
        public int? NumberOfMounts { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureQuorumWitnessDtoQuorumWitnessType? QuorumWitnessType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto> SharedDataDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto> SharedLogDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AzureManagedDiskSkuDto> SharedTempDBDisks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuReplicationMode : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuReplicationMode(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode ActiveGeoReplication { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode FailoverGroupInstance { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode NotApplicable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode left, Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode left, Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlAssessedNetworkAdapter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessedNetworkAdapter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessedNetworkAdapter>
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
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureNetworkAdapterSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlAssessedNetworkAdapter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessedNetworkAdapter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessedNetworkAdapter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlAssessedNetworkAdapter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessedNetworkAdapter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessedNetworkAdapter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessedNetworkAdapter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlAssessmentMigrationIssue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue>
    {
        internal SqlAssessmentMigrationIssue() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.ImpactedAssessmentObject> ImpactedObjects { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssueCategory? IssueCategory { get { throw null; } }
        public string IssueId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlAssessmentMigrationIssueCategory : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssueCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlAssessmentMigrationIssueCategory(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssueCategory Internal { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssueCategory Issue { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssueCategory Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssueCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssueCategory left, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssueCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssueCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssueCategory left, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssueCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlAssessmentV2IaasSuitabilityDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails>
    {
        internal SqlAssessmentV2IaasSuitabilityDetails() { }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureSqlIaasSkuDto AzureSqlSku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.CostComponent> CostComponents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline> MigrationGuidelines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue> MigrationIssues { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? MigrationTargetPlatform { get { throw null; } }
        public double? MonthlyComputeCost { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning> RecommendationReasonings { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlIaasSkuDto> ReplicaAzureSqlSku { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? SecuritySuitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto SharedResources { get { throw null; } }
        public bool? ShouldProvisionReplicas { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode? SkuReplicationMode { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? Suitability { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlAssessmentV2PaasSuitabilityDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails>
    {
        internal SqlAssessmentV2PaasSuitabilityDetails() { }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPaasSkuDto AzureSqlSku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.CostComponent> CostComponents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline> MigrationGuidelines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue> MigrationIssues { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? MigrationTargetPlatform { get { throw null; } }
        public double? MonthlyComputeCost { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning> RecommendationReasonings { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPaasSkuDto> ReplicaAzureSqlSku { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? SecuritySuitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto SharedResources { get { throw null; } }
        public bool? ShouldProvisionReplicas { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode? SkuReplicationMode { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? Suitability { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlAssessmentV2SummaryDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2SummaryDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2SummaryDetails>
    {
        internal SqlAssessmentV2SummaryDetails() { }
        public double? ConfidenceScore { get { throw null; } }
        public double? MonthlyComputeCost { get { throw null; } }
        public double? MonthlyLicenseCost { get { throw null; } }
        public double? MonthlySecurityCost { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> SuitabilitySummary { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2SummaryDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2SummaryDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2SummaryDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2SummaryDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2SummaryDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2SummaryDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2SummaryDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlAvailabilityGroupDataOverview : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityGroupDataOverview>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityGroupDataOverview>
    {
        internal SqlAvailabilityGroupDataOverview() { }
        public string AvailabilityGroupId { get { throw null; } }
        public string AvailabilityGroupName { get { throw null; } }
        public string SqlAvailabilityGroupEntityId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SqlAvailabilityGroupSdsArmId { get { throw null; } }
        public string SqlAvailabilityReplicaId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityGroupDataOverview System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityGroupDataOverview>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityGroupDataOverview>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityGroupDataOverview System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityGroupDataOverview>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityGroupDataOverview>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityGroupDataOverview>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlAvailabilityReplicaSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityReplicaSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityReplicaSummary>
    {
        internal SqlAvailabilityReplicaSummary() { }
        public int? NumberOfAsynchronousNonReadReplicas { get { throw null; } }
        public int? NumberOfAsynchronousReadReplicas { get { throw null; } }
        public int? NumberOfPrimaryReplicas { get { throw null; } }
        public int? NumberOfSynchronousNonReadReplicas { get { throw null; } }
        public int? NumberOfSynchronousReadReplicas { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityReplicaSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityReplicaSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityReplicaSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityReplicaSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityReplicaSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityReplicaSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityReplicaSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlDBSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlDBSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlDBSettings>
    {
        public SqlDBSettings() { }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier? AzureSqlComputeTier { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureSqlDataBaseType? AzureSqlDataBaseType { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureSqlPurchaseModel? AzureSqlPurchaseModel { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier? AzureSqlServiceTier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlDBSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlDBSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlDBSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlDBSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlDBSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlDBSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlDBSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlFciMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadata>
    {
        internal SqlFciMetadata() { }
        public int? FciSharedDiskCount { get { throw null; } }
        public bool? IsMultiSubnet { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlFciMetadataState : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlFciMetadataState(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState Failed { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState Inherited { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState Initializing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState Offline { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState OfflinePending { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState Online { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState OnlinePending { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState Pending { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState left, Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState left, Azure.ResourceManager.Migration.Assessment.Models.SqlFciMetadataState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlFciState : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.SqlFciState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlFciState(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlFciState Active { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlFciState NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlFciState Passive { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlFciState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.SqlFciState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.SqlFciState left, Azure.ResourceManager.Migration.Assessment.Models.SqlFciState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.SqlFciState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.SqlFciState left, Azure.ResourceManager.Migration.Assessment.Models.SqlFciState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlMigrationGuideline : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline>
    {
        internal SqlMigrationGuideline() { }
        public string GuidelineId { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuidelineCategory? MigrationGuidelineCategory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.MigrationGuidelineContext> MigrationGuidelineContext { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlMigrationGuidelineCategory : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuidelineCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlMigrationGuidelineCategory(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuidelineCategory AvailabilityGroupGuideline { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuidelineCategory FailoverCluterInstanceGuideLine { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuidelineCategory General { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuidelineCategory Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuidelineCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuidelineCategory left, Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuidelineCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuidelineCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuidelineCategory left, Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuidelineCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlMISettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlMISettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlMISettings>
    {
        public SqlMISettings() { }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureSqlInstanceType? AzureSqlInstanceType { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier? AzureSqlServiceTier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlMISettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlMISettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlMISettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlMISettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlMISettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlMISettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlMISettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlOptimizationLogic : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.SqlOptimizationLogic>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlOptimizationLogic(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlOptimizationLogic MinimizeCost { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlOptimizationLogic ModernizeToAzureSqlDB { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlOptimizationLogic ModernizeToAzureSqlMI { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlOptimizationLogic ModernizeToPaaS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.SqlOptimizationLogic other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.SqlOptimizationLogic left, Azure.ResourceManager.Migration.Assessment.Models.SqlOptimizationLogic right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.SqlOptimizationLogic (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.SqlOptimizationLogic left, Azure.ResourceManager.Migration.Assessment.Models.SqlOptimizationLogic right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlPaaSTargetConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlPaaSTargetConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlPaaSTargetConfig>
    {
        public SqlPaaSTargetConfig() { }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier? ComputeTier { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration? HardwareGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AzureSqlServiceTier? ServiceTier { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> TargetLocations { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? TargetType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlPaaSTargetConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlPaaSTargetConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlPaaSTargetConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlPaaSTargetConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlPaaSTargetConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlPaaSTargetConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlPaaSTargetConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlRecommendationReasoning : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning>
    {
        internal SqlRecommendationReasoning() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoningContext> ContextParameters { get { throw null; } }
        public string ReasoningCategory { get { throw null; } }
        public string ReasoningId { get { throw null; } }
        public string ReasoningString { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlRecommendationReasoningContext : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoningContext>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoningContext>
    {
        internal SqlRecommendationReasoningContext() { }
        public string ContextKey { get { throw null; } }
        public string ContextValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoningContext System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoningContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoningContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoningContext System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoningContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoningContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoningContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerLicense : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.SqlServerLicense>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerLicense(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlServerLicense No { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlServerLicense Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlServerLicense Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.SqlServerLicense other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.SqlServerLicense left, Azure.ResourceManager.Migration.Assessment.Models.SqlServerLicense right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.SqlServerLicense (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.SqlServerLicense left, Azure.ResourceManager.Migration.Assessment.Models.SqlServerLicense right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UltraDiskAssessmentConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.UltraDiskAssessmentConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.UltraDiskAssessmentConfig>
    {
        internal UltraDiskAssessmentConfig() { }
        public string FamilyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TargetLocations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.UltraDiskAssessmentConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.UltraDiskAssessmentConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.UltraDiskAssessmentConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.UltraDiskAssessmentConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.UltraDiskAssessmentConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.UltraDiskAssessmentConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.UltraDiskAssessmentConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmFamilyConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.VmFamilyConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.VmFamilyConfig>
    {
        internal VmFamilyConfig() { }
        public System.Collections.Generic.IReadOnlyList<string> Category { get { throw null; } }
        public string FamilyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TargetLocations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.VmFamilyConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.VmFamilyConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.VmFamilyConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.VmFamilyConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.VmFamilyConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.VmFamilyConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.VmFamilyConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmUptime : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.VmUptime>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.VmUptime>
    {
        public VmUptime() { }
        public int? DaysPerMonth { get { throw null; } set { } }
        public int? HoursPerDay { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.VmUptime System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.VmUptime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.VmUptime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.VmUptime System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.VmUptime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.VmUptime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.VmUptime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.WorkloadSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.WorkloadSummary>
    {
        internal WorkloadSummary() { }
        public int? OracleInstances { get { throw null; } }
        public int? SpringApps { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.WorkloadSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.WorkloadSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.WorkloadSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.WorkloadSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.WorkloadSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.WorkloadSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.WorkloadSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
