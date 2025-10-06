namespace Azure.ResourceManager.Migration.Assessment
{
    public partial class AzureResourceManagerMigrationAssessmentContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMigrationAssessmentContext() { }
        public static Azure.ResourceManager.Migration.Assessment.AzureResourceManagerMigrationAssessmentContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class MigrationAssessedMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessedMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource> Get(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource>> GetAsync(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource> GetIfExists(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource>> GetIfExistsAsync(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessedMachineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData>
    {
        public MigrationAssessedMachineData() { }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType? BootType { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent> CostComponents { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterMachineArmId { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterManagementServerArmId { get { throw null; } }
        public string DatacenterManagementServerName { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDisk> Disks { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError> Errors { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineProcessorInfo HostProcessor { get { throw null; } set { } }
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
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus ProductSupportStatus { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize? RecommendedSize { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType? TypePropertiesType { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessedMachineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessedMachineResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string assessedMachineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessedSqlDatabaseV2Collection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource>, System.Collections.IEnumerable
    {
        protected MigrationAssessedSqlDatabaseV2Collection() { }
        public virtual Azure.Response<bool> Exists(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource> Get(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource>> GetAsync(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource> GetIfExists(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource>> GetIfExistsAsync(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessedSqlDatabaseV2Data : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data>
    {
        public MigrationAssessedSqlDatabaseV2Data() { }
        public Azure.Core.ResourceIdentifier AssessedSqlInstanceArmId { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails AzureSqlDBSuitabilityDetails { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails AzureSqlMISuitabilityDetails { get { throw null; } }
        public double? BufferCacheSizeInMB { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel? CompatibilityLevel { get { throw null; } }
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
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus ProductSupportStatus { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? RecommendedAzureSqlTargetType { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability? RecommendedSuitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } }
        public Azure.Core.ResourceIdentifier SqlDatabaseSdsArmId { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessedSqlDatabaseV2Resource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessedSqlDatabaseV2Resource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string assessedSqlDatabaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessedSqlInstanceV2Collection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource>, System.Collections.IEnumerable
    {
        protected MigrationAssessedSqlInstanceV2Collection() { }
        public virtual Azure.Response<bool> Exists(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource> Get(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource>> GetAsync(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource> GetIfExists(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource>> GetIfExistsAsync(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessedSqlInstanceV2Data : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data>
    {
        public MigrationAssessedSqlInstanceV2Data() { }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityReplicaSummary AvailabilityReplicaSummary { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails AzureSqlDBSuitabilityDetails { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails AzureSqlMISuitabilityDetails { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails AzureSqlVmSuitabilityDetails { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDatabaseSummary DatabaseSummary { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadata FciMetadata { get { throw null; } }
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
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus ProductSupportStatus { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? RecommendedAzureSqlTargetType { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability? RecommendedSuitability { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning> RecommendedTargetReasonings { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } }
        public string SqlEdition { get { throw null; } }
        public Azure.Core.ResourceIdentifier SqlInstanceSdsArmId { get { throw null; } }
        public string SqlVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceStorageDetails> StorageTypeBasedDetails { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessedSqlInstanceV2Resource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessedSqlInstanceV2Resource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string assessedSqlInstanceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessedSqlMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessedSqlMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource> Get(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource>> GetAsync(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource> GetIfExists(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource>> GetIfExistsAsync(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessedSqlMachineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData>
    {
        public MigrationAssessedSqlMachineData() { }
        public string BiosGuid { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType? BootType { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent> CostComponents { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterMachineArmId { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterManagementServerArmId { get { throw null; } }
        public string DatacenterManagementServerName { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDataDisk> Disks { get { throw null; } }
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
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus ProductSupportStatus { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily? RecommendedVmFamily { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize? RecommendedVmSize { get { throw null; } }
        public double? RecommendedVmSizeMegabytesOfMemory { get { throw null; } }
        public int? RecommendedVmSizeNumberOfCores { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? SecuritySuitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceSummary> SqlInstances { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType? TypePropertiesType { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessedSqlMachineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessedSqlMachineResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string assessedSqlMachineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessedSqlRecommendedEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessedSqlRecommendedEntityCollection() { }
        public virtual Azure.Response<bool> Exists(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource> Get(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource>> GetAsync(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource> GetIfExists(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource>> GetIfExistsAsync(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessedSqlRecommendedEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData>
    {
        public MigrationAssessedSqlRecommendedEntityData() { }
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
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus ProductSupportStatus { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? RecommendedAzureSqlTargetType { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability? RecommendedSuitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } }
        public string SqlEdition { get { throw null; } }
        public string SqlVersion { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessedSqlRecommendedEntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessedSqlRecommendedEntityResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string recommendedAssessedEntityName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource> Get(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource>> GetAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource> GetIfExists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource>> GetIfExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData>
    {
        public MigrationAssessmentData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> AssessmentErrorSummary { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType? AssessmentType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType> AzureDiskTypes { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentHybridUseBenefit? AzureHybridUseBenefit { get { throw null; } set { } }
        public Azure.Core.AzureLocation? AzureLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode? AzureOfferCode { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentPricingTier? AzurePricingTier { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentStorageRedundancy? AzureStorageRedundancy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily> AzureVmFamilies { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent> CostComponents { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency? Currency { get { throw null; } set { } }
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
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance? ReservedInstance { get { throw null; } set { } }
        public double? ScalingFactor { get { throw null; } set { } }
        public string SchemaVersion { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage? Stage { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> SuitabilitySummary { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange? TimeRange { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmUptime VmUptime { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class MigrationAssessmentExtensions
    {
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource GetMigrationAssessedMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource GetMigrationAssessedSqlDatabaseV2Resource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource GetMigrationAssessedSqlInstanceV2Resource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource GetMigrationAssessedSqlMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource GetMigrationAssessedSqlRecommendedEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource GetMigrationAssessmentGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource GetMigrationAssessmentHyperVCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource GetMigrationAssessmentImportCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource GetMigrationAssessmentMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource GetMigrationAssessmentOptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource GetMigrationAssessmentPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource GetMigrationAssessmentPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> GetMigrationAssessmentProject(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource>> GetMigrationAssessmentProjectAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource GetMigrationAssessmentProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectCollection GetMigrationAssessmentProjects(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> GetMigrationAssessmentProjects(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> GetMigrationAssessmentProjectsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource GetMigrationAssessmentProjectSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource GetMigrationAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource GetMigrationAssessmentServerCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource GetMigrationAssessmentSqlCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource GetMigrationAssessmentVMwareCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource GetMigrationAvsAssessedMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource GetMigrationAvsAssessmentOptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource GetMigrationAvsAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource GetMigrationSqlAssessmentOptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource GetMigrationSqlAssessmentV2Resource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource GetMigrationSqlAssessmentV2SummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType> SupportedAssessmentTypes { get { throw null; } }
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
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource> GetMigrationAssessment(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource>> GetMigrationAssessmentAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentCollection GetMigrationAssessments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource> GetMigrationAvsAssessment(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource>> GetMigrationAvsAssessmentAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentCollection GetMigrationAvsAssessments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource> GetMigrationSqlAssessmentV2(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource>> GetMigrationSqlAssessmentV2Async(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Collection GetMigrationSqlAssessmentV2s() { throw null; }
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
        public Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType? BootType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatacenterManagementServerArmId { get { throw null; } }
        public string DatacenterManagementServerName { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.Core.ResourceIdentifier DiscoveryMachineArmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentDisk> Disks { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError> Errors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Groups { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineProcessorInfo HostProcessor { get { throw null; } }
        public double? MegabytesOfMemory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentNetworkAdapter> NetworkAdapters { get { throw null; } }
        public int? NumberOfCores { get { throw null; } }
        public string OperatingSystemName { get { throw null; } }
        public string OperatingSystemType { get { throw null; } }
        public string OperatingSystemVersion { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus ProductSupportStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SqlInstances { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> WebApplications { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentWorkloadSummary WorkloadSummary { get { throw null; } }
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
    public partial class MigrationAssessmentOptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentOptionCollection() { }
        public virtual Azure.Response<bool> Exists(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource> Get(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource>> GetAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource> GetIfExists(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource>> GetIfExistsAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentOptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData>
    {
        public MigrationAssessmentOptionData() { }
        public System.Collections.Generic.IReadOnlyList<string> PremiumDiskVmFamilies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReservedInstanceSupportedCurrencies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReservedInstanceSupportedLocations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReservedInstanceSupportedOffers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReservedInstanceVmFamilies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SavingsPlanSupportedLocations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SavingsPlanVmFamilies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.UltraDiskAssessmentConfig> UltraDiskVmFamilies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamilyConfig> VmFamilies { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentOptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentOptionResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string assessmentOptionsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MigrationAssessmentProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> GetIfExists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource>> GetIfExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentProjectData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData>
    {
        public MigrationAssessmentProjectData(Azure.Core.AzureLocation location) { }
        public Azure.Core.ResourceIdentifier AssessmentSolutionId { get { throw null; } set { } }
        public System.DateTimeOffset? CreateOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier CustomerStorageAccountArmId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CustomerWorkspaceId { get { throw null; } set { } }
        public string CustomerWorkspaceLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentProjectStatus? ProjectStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public string ServiceEndpoint { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentProjectResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentProjectResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource> GetMigrationAssessmentOption(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource>> GetMigrationAssessmentOptionAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionCollection GetMigrationAssessmentOptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource> GetMigrationAssessmentPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource>> GetMigrationAssessmentPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionCollection GetMigrationAssessmentPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource> GetMigrationAssessmentPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource>> GetMigrationAssessmentPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceCollection GetMigrationAssessmentPrivateLinkResources() { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryCollection GetMigrationAssessmentProjectSummaries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource> GetMigrationAssessmentProjectSummary(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource>> GetMigrationAssessmentProjectSummaryAsync(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource> GetMigrationAssessmentServerCollector(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource>> GetMigrationAssessmentServerCollectorAsync(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorCollection GetMigrationAssessmentServerCollectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource> GetMigrationAssessmentSqlCollector(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource>> GetMigrationAssessmentSqlCollectorAsync(string collectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorCollection GetMigrationAssessmentSqlCollectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource> GetMigrationAssessmentVMwareCollector(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource>> GetMigrationAssessmentVMwareCollectorAsync(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorCollection GetMigrationAssessmentVMwareCollectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource> GetMigrationAvsAssessmentOption(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource>> GetMigrationAvsAssessmentOptionAsync(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionCollection GetMigrationAvsAssessmentOptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource> GetMigrationSqlAssessmentOption(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource>> GetMigrationSqlAssessmentOptionAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionCollection GetMigrationSqlAssessmentOptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProjectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationAssessmentProjectSummaryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource>, System.Collections.IEnumerable
    {
        protected MigrationAssessmentProjectSummaryCollection() { }
        public virtual Azure.Response<bool> Exists(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource> Get(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource>> GetAsync(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource> GetIfExists(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource>> GetIfExistsAsync(string projectSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAssessmentProjectSummaryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData>
    {
        public MigrationAssessmentProjectSummaryData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary> ErrorSummaryAffectedEntities { get { throw null; } }
        public System.DateTimeOffset? LastAssessedOn { get { throw null; } }
        public int? NumberOfAssessments { get { throw null; } }
        public int? NumberOfGroups { get { throw null; } }
        public int? NumberOfImportMachines { get { throw null; } }
        public int? NumberOfMachines { get { throw null; } }
        public int? NumberOfPrivateEndpointConnections { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentProjectSummaryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentProjectSummaryResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string projectSummaryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAssessmentResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri> DownloadUrl(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri>> DownloadUrlAsync(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource> GetMigrationAssessedMachine(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource>> GetMigrationAssessedMachineAsync(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineCollection GetMigrationAssessedMachines() { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class MigrationAvsAssessedMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource>, System.Collections.IEnumerable
    {
        protected MigrationAvsAssessedMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource> Get(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource> GetAll(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource> GetAllAsync(string filter = null, int? pageSize = default(int?), string continuationToken = null, int? totalRecordCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource>> GetAsync(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource> GetIfExists(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource>> GetIfExistsAsync(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAvsAssessedMachineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData>
    {
        public MigrationAvsAssessedMachineData() { }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType? BootType { get { throw null; } }
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
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType? TypePropertiesType { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAvsAssessedMachineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAvsAssessedMachineResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string avsAssessedMachineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAvsAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource>, System.Collections.IEnumerable
    {
        protected MigrationAvsAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource> Get(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource>> GetAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource> GetIfExists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource>> GetIfExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAvsAssessmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData>
    {
        public MigrationAvsAssessmentData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> AssessmentErrorSummary { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType? AssessmentType { get { throw null; } }
        public Azure.Core.AzureLocation? AzureLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode? AzureOfferCode { get { throw null; } set { } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public double? CpuUtilization { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency? Currency { get { throw null; } set { } }
        public double? DedupeCompression { get { throw null; } set { } }
        public double? DiscountPercentage { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel? FailuresToTolerateAndRaidLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType? GroupType { get { throw null; } }
        public bool? IsStretchClusterEnabled { get { throw null; } set { } }
        public string LimitingFactor { get { throw null; } }
        public double? MemOvercommit { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsNodeType? NodeType { get { throw null; } set { } }
        public int? NumberOfMachines { get { throw null; } }
        public int? NumberOfNodes { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization? Percentile { get { throw null; } set { } }
        public System.DateTimeOffset? PerfDataEndOn { get { throw null; } set { } }
        public System.DateTimeOffset? PerfDataStartOn { get { throw null; } set { } }
        public System.DateTimeOffset? PricesQueriedOn { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? ProvisioningState { get { throw null; } set { } }
        public double? RamUtilization { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance? ReservedInstance { get { throw null; } set { } }
        public double? ScalingFactor { get { throw null; } set { } }
        public string SchemaVersion { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage? Stage { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus? Status { get { throw null; } }
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
        Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAvsAssessmentOptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource>, System.Collections.IEnumerable
    {
        protected MigrationAvsAssessmentOptionCollection() { }
        public virtual Azure.Response<bool> Exists(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource> Get(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource>> GetAsync(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource> GetIfExists(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource>> GetIfExistsAsync(string avsAssessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationAvsAssessmentOptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData>
    {
        public MigrationAvsAssessmentOptionData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsSkuConfig> AvsNodes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel> FailuresToTolerateAndRaidLevelValues { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsNodeType> ReservedInstanceAvsNodes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency> ReservedInstanceSupportedCurrencies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> ReservedInstanceSupportedLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode> ReservedInstanceSupportedOffers { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAvsAssessmentOptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAvsAssessmentOptionResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string avsAssessmentOptionsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAvsAssessmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationAvsAssessmentResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri> DownloadUrl(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri>> DownloadUrlAsync(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource> GetMigrationAvsAssessedMachine(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource>> GetMigrationAvsAssessedMachineAsync(string avsAssessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineCollection GetMigrationAvsAssessedMachines() { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationSqlAssessmentOptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource>, System.Collections.IEnumerable
    {
        protected MigrationSqlAssessmentOptionCollection() { }
        public virtual Azure.Response<bool> Exists(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource> Get(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource>> GetAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource> GetIfExists(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource>> GetIfExistsAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationSqlAssessmentOptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData>
    {
        public MigrationSqlAssessmentOptionData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily> PremiumDiskVmFamilies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType> ReservedInstanceSqlTargets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency> ReservedInstanceSupportedCurrencies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> ReservedInstanceSupportedLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> ReservedInstanceSupportedLocationsForIaas { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode> ReservedInstanceSupportedOffers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily> ReservedInstanceVmFamilies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> SavingsPlanSupportedLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> SavingsPlanSupportedLocationsForPaas { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode> SavingsPlanSupportedOffers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily> SavingsPlanVmFamilies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.SqlPaasTargetConfig> SqlSkus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode> SupportedOffers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamilyConfig> VmFamilies { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationSqlAssessmentOptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationSqlAssessmentOptionResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string assessmentOptionsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationSqlAssessmentV2Collection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource>, System.Collections.IEnumerable
    {
        protected MigrationSqlAssessmentV2Collection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource> Get(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource>> GetAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource> GetIfExists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource>> GetIfExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationSqlAssessmentV2Data : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data>
    {
        public MigrationSqlAssessmentV2Data() { }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType? AssessmentType { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AsyncCommitModeIntent? AsyncCommitModeIntent { get { throw null; } set { } }
        public Azure.Core.AzureLocation? AzureLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode? AzureOfferCode { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode? AzureOfferCodeForVm { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSecurityOfferingType? AzureSecurityOfferingType { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDBSettings AzureSqlDatabaseSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlMISettings AzureSqlManagedInstanceSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily> AzureSqlVmInstanceSeries { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency? Currency { get { throw null; } set { } }
        public Azure.Core.AzureLocation? DisasterRecoveryLocation { get { throw null; } set { } }
        public double? DiscountPercentage { get { throw null; } set { } }
        public string EASubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentEntityUptime EntityUptime { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentEnvironmentType? EnvironmentType { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType? GroupType { get { throw null; } set { } }
        public bool? IsHadrAssessmentEnabled { get { throw null; } set { } }
        public bool? IsInternetAccessAvailable { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MultiSubnetIntent? MultiSubnetIntent { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.SqlOptimizationLogic? OptimizationLogic { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentOSLicense? OSLicense { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization? Percentile { get { throw null; } set { } }
        public System.DateTimeOffset? PerfDataEndOn { get { throw null; } set { } }
        public System.DateTimeOffset? PerfDataStartOn { get { throw null; } set { } }
        public System.DateTimeOffset? PricesQueriedOn { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance? ReservedInstance { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance? ReservedInstanceForVm { get { throw null; } set { } }
        public double? ScalingFactor { get { throw null; } set { } }
        public string SchemaVersion { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? SizingCriterion { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServerLicense? SqlServerLicense { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage? Stage { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange? TimeRange { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationSqlAssessmentV2Resource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationSqlAssessmentV2Resource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri> DownloadUrl(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri>> DownloadUrlAsync(Azure.WaitUntil waitUntil, System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource> GetMigrationAssessedSqlDatabaseV2(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource>> GetMigrationAssessedSqlDatabaseV2Async(string assessedSqlDatabaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Collection GetMigrationAssessedSqlDatabaseV2s() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource> GetMigrationAssessedSqlInstanceV2(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource>> GetMigrationAssessedSqlInstanceV2Async(string assessedSqlInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Collection GetMigrationAssessedSqlInstanceV2s() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource> GetMigrationAssessedSqlMachine(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource>> GetMigrationAssessedSqlMachineAsync(string assessedSqlMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineCollection GetMigrationAssessedSqlMachines() { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityCollection GetMigrationAssessedSqlRecommendedEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource> GetMigrationAssessedSqlRecommendedEntity(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource>> GetMigrationAssessedSqlRecommendedEntityAsync(string recommendedAssessedEntityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryCollection GetMigrationSqlAssessmentV2Summaries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource> GetMigrationSqlAssessmentV2Summary(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource>> GetMigrationSqlAssessmentV2SummaryAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationSqlAssessmentV2SummaryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource>, System.Collections.IEnumerable
    {
        protected MigrationSqlAssessmentV2SummaryCollection() { }
        public virtual Azure.Response<bool> Exists(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource> Get(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource>> GetAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource> GetIfExists(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource>> GetIfExistsAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationSqlAssessmentV2SummaryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData>
    {
        public MigrationSqlAssessmentV2SummaryData() { }
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
        Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationSqlAssessmentV2SummaryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationSqlAssessmentV2SummaryResource() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string summaryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Migration.Assessment.Mocking
{
    public partial class MockableMigrationAssessmentArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMigrationAssessmentArmClient() { }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineResource GetMigrationAssessedMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Resource GetMigrationAssessedSqlDatabaseV2Resource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Resource GetMigrationAssessedSqlInstanceV2Resource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineResource GetMigrationAssessedSqlMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityResource GetMigrationAssessedSqlRecommendedEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupResource GetMigrationAssessmentGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorResource GetMigrationAssessmentHyperVCollectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorResource GetMigrationAssessmentImportCollectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineResource GetMigrationAssessmentMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionResource GetMigrationAssessmentOptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionResource GetMigrationAssessmentPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResource GetMigrationAssessmentPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource GetMigrationAssessmentProjectResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryResource GetMigrationAssessmentProjectSummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentResource GetMigrationAssessmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorResource GetMigrationAssessmentServerCollectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorResource GetMigrationAssessmentSqlCollectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorResource GetMigrationAssessmentVMwareCollectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineResource GetMigrationAvsAssessedMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionResource GetMigrationAvsAssessmentOptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentResource GetMigrationAvsAssessmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionResource GetMigrationSqlAssessmentOptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Resource GetMigrationSqlAssessmentV2Resource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryResource GetMigrationSqlAssessmentV2SummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMigrationAssessmentResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMigrationAssessmentResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> GetMigrationAssessmentProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource>> GetMigrationAssessmentProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectCollection GetMigrationAssessmentProjects() { throw null; }
    }
    public partial class MockableMigrationAssessmentSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMigrationAssessmentSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> GetMigrationAssessmentProjects(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectResource> GetMigrationAssessmentProjectsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Migration.Assessment.Models
{
    public static partial class ArmMigrationAssessmentModelFactory
    {
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedNetworkAdapter AssessedNetworkAdapter(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail?), Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityExplanation?), double? monthlyBandwidthCosts = default(double?), double? netGigabytesTransmittedPerMonth = default(double?), string displayName = null, string macAddress = null, System.Collections.Generic.IEnumerable<string> ipAddresses = null, double? megabytesPerSecondReceived = default(double?), double? megabytesPerSecondTransmitted = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDatabaseSummary AssessedSqlInstanceDatabaseSummary(int? numberOfUserDatabases = default(int?), double? totalDatabaseSizeInMB = default(double?), double? largestDatabaseSizeInMB = default(double?), int? totalDiscoveredUserDatabases = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDiskDetails AssessedSqlInstanceDiskDetails(string diskId = null, double? diskSizeInMB = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceStorageDetails AssessedSqlInstanceStorageDetails(string storageType = null, double? diskSizeInMB = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceSummary AssessedSqlInstanceSummary(string instanceId = null, string instanceName = null, Azure.Core.ResourceIdentifier sqlInstanceSdsArmId = null, string sqlInstanceEntityId = null, string sqlEdition = null, string sqlVersion = null, bool? isClustered = default(bool?), bool? isHighAvailabilityEnabled = default(bool?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciState? sqlFciState = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciState?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentAzureSqlIaasSkuDto AssessmentAzureSqlIaasSkuDto(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSkuDto virtualMachineSize = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto> dataDiskSizes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto> logDiskSizes = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? azureSqlTargetType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent AssessmentCostComponent(Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponentName? name = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponentName?), double? value = default(double?), string description = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary AssessmentErrorSummary(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType? assessmentType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType?), int? count = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto AssessmentManagedDiskSkuDto(Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskType? diskType = default(Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskType?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize? diskSize = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize?), Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskRedundancy? diskRedundancy = default(Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskRedundancy?), double? storageCost = default(double?), double? recommendedSizeInGib = default(double?), double? recommendedThroughputInMbps = default(double?), double? recommendedIops = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus AssessmentProductSupportStatus(string currentVersion = null, string servicePackStatus = null, string esuStatus = null, string supportStatus = null, int? eta = default(int?), string currentEsuYear = null, System.DateTimeOffset? mainstreamEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? extendedSupportEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? extendedSecurityUpdateYear1EndOn = default(System.DateTimeOffset?), System.DateTimeOffset? extendedSecurityUpdateYear2EndOn = default(System.DateTimeOffset?), System.DateTimeOffset? extendedSecurityUpdateYear3EndOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentReportDownloadUri AssessmentReportDownloadUri(System.Uri assessmentReportUri = null, System.DateTimeOffset expireOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadata AssessmentSqlFciMetadata(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState? state = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState?), bool? isMultiSubnet = default(bool?), int? fciSharedDiskCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPaasSkuDto AssessmentSqlPaasSkuDto(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier? azureSqlServiceTier = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier? azureSqlComputeTier = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration? azureSqlHardwareGeneration = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration?), double? storageMaxSizeInMB = default(double?), double? predictedDataSizeInMB = default(double?), double? predictedLogSizeInMB = default(double?), int? cores = default(int?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? azureSqlTargetType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamilyConfig AssessmentVmFamilyConfig(string familyName = null, System.Collections.Generic.IEnumerable<string> targetLocations = null, System.Collections.Generic.IEnumerable<string> category = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSkuDto AssessmentVmSkuDto(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily? azureVmFamily = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily?), int? cores = default(int?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize? azureSkuName = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize?), int? availableCores = default(int?), int? maxNetworkInterfaces = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentWorkloadSummary AssessmentWorkloadSummary(int? oracleInstances = default(int?), int? springApps = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedDisk AvsAssessedDisk(string name = null, string displayName = null, double? gigabytesProvisioned = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedNetworkAdapter AvsAssessedNetworkAdapter(string macAddress = null, System.Collections.Generic.IEnumerable<string> ipAddresses = null, string displayName = null, double? megabytesPerSecondReceived = default(double?), double? megabytesPerSecondTransmitted = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.ImpactedAssessmentObject ImpactedAssessmentObject(string objectName = null, string objectType = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDataDisk MigrationAssessedDataDisk(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize? recommendedDiskSize = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType? recommendedDiskType = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType?), int? recommendedDiskSizeGigabytes = default(int?), double? recommendDiskThroughputInMbps = default(double?), double? recommendedDiskIops = default(double?), double? monthlyStorageCost = default(double?), string name = null, string displayName = null, double? gigabytesProvisioned = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDisk MigrationAssessedDisk(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize? recommendedDiskSize = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType? recommendedDiskType = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType?), int? gigabytesForRecommendedDiskSize = default(int?), double? recommendDiskThroughputInMbps = default(double?), double? recommendedDiskIops = default(double?), double? monthlyStorageCost = default(double?), string name = null, string displayName = null, double? gigabytesProvisioned = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessedMachineData MigrationAssessedMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError> errors = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDisk> disks = null, double? monthlyUltraStorageCost = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineProcessorInfo hostProcessor = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent> costComponents = null, Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus productSupportStatus = null, double? monthlyBandwidthCost = default(double?), double? monthlyStorageCost = default(double?), double? monthlyPremiumStorageCost = default(double?), double? monthlyStandardSsdStorageCost = default(double?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.AssessedNetworkAdapter> networkAdapters = null, Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize? recommendedSize = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize?), int? numberOfCoresForRecommendedSize = default(int?), double? megabytesOfMemoryForRecommendedSize = default(double?), double? monthlyComputeCostForRecommendedSize = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType? typePropertiesType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType?), Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType? bootType = default(Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType?), string operatingSystemType = null, string operatingSystemName = null, string operatingSystemVersion = null, Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture? operatingSystemArchitecture = default(Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string displayName = null, string description = null, Azure.Core.ResourceIdentifier datacenterMachineArmId = null, Azure.Core.ResourceIdentifier datacenterManagementServerArmId = null, string datacenterManagementServerName = null, double? megabytesOfMemory = default(double?), int? numberOfCores = default(int?), double? confidenceRatingInPercentage = default(double?), double? percentageCoresUtilization = default(double?), double? percentageMemoryUtilization = default(double?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlDatabaseV2Data MigrationAssessedSqlDatabaseV2Data(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? recommendedAzureSqlTargetType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType?), Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability? recommendedSuitability = default(Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability?), double? bufferCacheSizeInMB = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus productSupportStatus = null, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlMISuitabilityDetails = null, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlDBSuitabilityDetails = null, bool? isDatabaseHighlyAvailable = default(bool?), Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityGroupDataOverview linkedAvailabilityGroupOverview = null, Azure.Core.ResourceIdentifier machineArmId = null, Azure.Core.ResourceIdentifier assessedSqlInstanceArmId = null, string machineName = null, string instanceName = null, string databaseName = null, double? databaseSizeInMB = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel? compatibilityLevel = default(Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel?), Azure.Core.ResourceIdentifier sqlDatabaseSdsArmId = null, double? percentageCoresUtilization = default(double?), double? megabytesPerSecondOfRead = default(double?), double? megabytesPerSecondOfWrite = default(double?), double? numberOfReadOperationsPerSecond = default(double?), double? numberOfWriteOperationsPerSecond = default(double?), double? confidenceRatingInPercentage = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlInstanceV2Data MigrationAssessedSqlInstanceV2Data(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, double? memoryInUseInMB = default(double?), bool? hasScanOccurred = default(bool?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? recommendedAzureSqlTargetType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType?), Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability? recommendedSuitability = default(Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability?), Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlMISuitabilityDetails = null, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlDBSuitabilityDetails = null, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails azureSqlVmSuitabilityDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceStorageDetails> storageTypeBasedDetails = null, Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus productSupportStatus = null, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadata fciMetadata = null, Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityReplicaSummary availabilityReplicaSummary = null, bool? isClustered = default(bool?), bool? isHighAvailabilityEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning> recommendedTargetReasonings = null, Azure.Core.ResourceIdentifier machineArmId = null, string machineName = null, string instanceName = null, Azure.Core.ResourceIdentifier sqlInstanceSdsArmId = null, string sqlEdition = null, string sqlVersion = null, int? numberOfCoresAllocated = default(int?), double? percentageCoresUtilization = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDiskDetails> logicalDisks = null, Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceDatabaseSummary databaseSummary = null, double? confidenceRatingInPercentage = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlMachineData MigrationAssessedSqlMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string biosGuid = null, string fqdn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlInstanceSummary> sqlInstances = null, Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize? recommendedVmSize = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily? recommendedVmFamily = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus productSupportStatus = null, int? recommendedVmSizeNumberOfCores = default(int?), double? recommendedVmSizeMegabytesOfMemory = default(double?), double? monthlyComputeCost = default(double?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDataDisk> disks = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessedNetworkAdapter> networkAdapters = null, double? monthlyBandwidthCost = default(double?), double? monthlyStorageCost = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent> costComponents = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? securitySuitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline> migrationGuidelines = null, Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType? bootType = default(Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType?), string operatingSystemType = null, string operatingSystemName = null, string operatingSystemVersion = null, Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture? operatingSystemArchitecture = default(Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string displayName = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType? typePropertiesType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType?), string description = null, Azure.Core.ResourceIdentifier datacenterMachineArmId = null, Azure.Core.ResourceIdentifier datacenterManagementServerArmId = null, string datacenterManagementServerName = null, double? megabytesOfMemory = default(double?), int? numberOfCores = default(int?), double? confidenceRatingInPercentage = default(double?), double? percentageCoresUtilization = default(double?), double? percentageMemoryUtilization = default(double?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessedSqlRecommendedEntityData MigrationAssessedSqlRecommendedEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string machineName = null, string instanceName = null, Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus productSupportStatus = null, int? dbCount = default(int?), int? discoveredDBCount = default(int?), bool? hasScanOccurred = default(bool?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? recommendedAzureSqlTargetType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType?), Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability? recommendedSuitability = default(Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability?), Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlMISuitabilityDetails = null, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails azureSqlDBSuitabilityDetails = null, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails azureSqlVmSuitabilityDetails = null, Azure.Core.ResourceIdentifier assessedSqlEntityArmId = null, bool? isClustered = default(bool?), bool? isHighAvailabilityEnabled = default(bool?), string sqlEdition = null, string sqlVersion = null, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentData MigrationAssessmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), System.Collections.Generic.IReadOnlyDictionary<string, int> assessmentErrorSummary = null, double? monthlyUltraStorageCost = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent> costComponents = null, string eaSubscriptionId = null, Azure.ResourceManager.Migration.Assessment.Models.AssessmentPricingTier? azurePricingTier = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentPricingTier?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentStorageRedundancy? azureStorageRedundancy = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentStorageRedundancy?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance? reservedInstance = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentHybridUseBenefit? azureHybridUseBenefit = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentHybridUseBenefit?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType> azureDiskTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily> azureVmFamilies = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionBySupportStatus = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionByServicePackInsight = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionByOSName = null, double? monthlyComputeCost = default(double?), double? monthlyBandwidthCost = default(double?), double? monthlyStorageCost = default(double?), double? monthlyPremiumStorageCost = default(double?), double? monthlyStandardSsdStorageCost = default(double?), System.Collections.Generic.IReadOnlyDictionary<string, int> suitabilitySummary = null, int? numberOfMachines = default(int?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmUptime vmUptime = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType? groupType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType? assessmentType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType?), Azure.Core.AzureLocation? azureLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode? azureOfferCode = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency? currency = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency?), double? scalingFactor = default(double?), Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization? percentile = default(Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange? timeRange = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange?), System.DateTimeOffset? perfDataStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? perfDataEndOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage? stage = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage?), double? discountPercentage = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion?), double? confidenceRatingInPercentage = default(double?), System.DateTimeOffset? pricesQueriedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus? status = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus?), string schemaVersion = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentDisk MigrationAssessmentDisk(double? gigabytesAllocated = default(double?), string displayName = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError MigrationAssessmentError(int? id = default(int?), string code = null, string runAsAccountId = null, string applianceName = null, string message = null, string summaryMessage = null, string agentScenario = null, string possibleCauses = null, string recommendedAction = null, string severity = null, System.Collections.Generic.IReadOnlyDictionary<string, string> messageParameters = null, System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string impactedAssessmentType = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentGroupData MigrationAssessmentGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupStatus? groupStatus = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupStatus?), int? machineCount = default(int?), System.Collections.Generic.IEnumerable<string> assessments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType> supportedAssessmentTypes = null, bool? areAssessmentsRunning = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType? groupType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentHyperVCollectorData MigrationAssessmentHyperVCollectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase agentProperties = null, string discoverySiteId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentImportCollectorData MigrationAssessmentImportCollectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), string discoverySiteId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentMachineData MigrationAssessmentMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.AssessmentWorkloadSummary workloadSummary = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError> errors = null, Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineProcessorInfo hostProcessor = null, Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus productSupportStatus = null, Azure.Core.ResourceIdentifier discoveryMachineArmId = null, Azure.Core.ResourceIdentifier datacenterManagementServerArmId = null, string datacenterManagementServerName = null, Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType? bootType = default(Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType?), string displayName = null, double? megabytesOfMemory = default(double?), int? numberOfCores = default(int?), string operatingSystemType = null, string operatingSystemName = null, string operatingSystemVersion = null, string description = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentDisk> disks = null, System.Collections.Generic.IEnumerable<string> groups = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentNetworkAdapter> networkAdapters = null, System.Collections.Generic.IEnumerable<string> sqlInstances = null, System.Collections.Generic.IEnumerable<string> webApplications = null, System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentNetworkAdapter MigrationAssessmentNetworkAdapter(string macAddress = null, System.Collections.Generic.IEnumerable<string> ipAddresses = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentOptionData MigrationAssessmentOptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamilyConfig> vmFamilies = null, System.Collections.Generic.IEnumerable<string> reservedInstanceVmFamilies = null, System.Collections.Generic.IEnumerable<string> reservedInstanceSupportedLocations = null, System.Collections.Generic.IEnumerable<string> reservedInstanceSupportedCurrencies = null, System.Collections.Generic.IEnumerable<string> reservedInstanceSupportedOffers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.UltraDiskAssessmentConfig> ultraDiskVmFamilies = null, System.Collections.Generic.IEnumerable<string> premiumDiskVmFamilies = null, System.Collections.Generic.IEnumerable<string> savingsPlanVmFamilies = null, System.Collections.Generic.IEnumerable<string> savingsPlanSupportedLocations = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData MigrationAssessmentPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateLinkResourceData MigrationAssessmentPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectData MigrationAssessmentProjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), System.DateTimeOffset? createOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string serviceEndpoint = null, Azure.Core.ResourceIdentifier assessmentSolutionId = null, Azure.ResourceManager.Migration.Assessment.Models.AssessmentProjectStatus? projectStatus = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentProjectStatus?), Azure.Core.ResourceIdentifier customerWorkspaceId = null, string customerWorkspaceLocation = null, string publicNetworkAccess = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.MigrationAssessmentPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.Core.ResourceIdentifier customerStorageAccountArmId = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentProjectSummaryData MigrationAssessmentProjectSummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary> errorSummaryAffectedEntities = null, int? numberOfPrivateEndpointConnections = default(int?), int? numberOfGroups = default(int?), int? numberOfMachines = default(int?), int? numberOfImportMachines = default(int?), int? numberOfAssessments = default(int?), System.DateTimeOffset? lastAssessedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentServerCollectorData MigrationAssessmentServerCollectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase agentProperties = null, string discoverySiteId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentSqlCollectorData MigrationAssessmentSqlCollectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase agentProperties = null, string discoverySiteId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAssessmentVMwareCollectorData MigrationAssessmentVMwareCollectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), Azure.ResourceManager.Migration.Assessment.Models.CollectorAgentPropertiesBase agentProperties = null, string discoverySiteId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessedMachineData MigrationAvsAssessedMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentError> errors = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedDisk> disks = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.AvsAssessedNetworkAdapter> networkAdapters = null, double? storageInUseGB = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityExplanation?), Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migration.Assessment.Models.AvsVmSuitabilityDetail?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType? typePropertiesType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType?), Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType? bootType = default(Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType?), string operatingSystemType = null, string operatingSystemName = null, string operatingSystemVersion = null, Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture? operatingSystemArchitecture = default(Azure.ResourceManager.Migration.Assessment.Models.GuestOperatingSystemArchitecture?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string displayName = null, string description = null, Azure.Core.ResourceIdentifier datacenterMachineArmId = null, Azure.Core.ResourceIdentifier datacenterManagementServerArmId = null, string datacenterManagementServerName = null, double? megabytesOfMemory = default(double?), int? numberOfCores = default(int?), double? confidenceRatingInPercentage = default(double?), double? percentageCoresUtilization = default(double?), double? percentageMemoryUtilization = default(double?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentData MigrationAvsAssessmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), System.Collections.Generic.IReadOnlyDictionary<string, int> assessmentErrorSummary = null, Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel? failuresToTolerateAndRaidLevel = default(Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel?), double? vcpuOversubscription = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsNodeType? nodeType = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsNodeType?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance? reservedInstance = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance?), double? totalMonthlyCost = default(double?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), Azure.ResourceManager.Migration.Assessment.Models.AvsSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migration.Assessment.Models.AvsSuitabilityExplanation?), int? numberOfNodes = default(int?), double? cpuUtilization = default(double?), double? ramUtilization = default(double?), double? storageUtilization = default(double?), double? totalCpuCores = default(double?), double? totalRamInGB = default(double?), double? totalStorageInGB = default(double?), int? numberOfMachines = default(int?), System.Collections.Generic.IReadOnlyDictionary<string, int> suitabilitySummary = null, double? memOvercommit = default(double?), double? dedupeCompression = default(double?), string limitingFactor = null, bool? isStretchClusterEnabled = default(bool?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType? groupType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType? assessmentType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType?), Azure.Core.AzureLocation? azureLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode? azureOfferCode = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency? currency = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency?), double? scalingFactor = default(double?), Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization? percentile = default(Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange? timeRange = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange?), System.DateTimeOffset? perfDataStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? perfDataEndOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage? stage = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage?), double? discountPercentage = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion?), double? confidenceRatingInPercentage = default(double?), System.DateTimeOffset? pricesQueriedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus? status = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus?), string schemaVersion = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationAvsAssessmentOptionData MigrationAvsAssessmentOptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsSkuConfig> avsNodes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.FttAndRaidLevel> failuresToTolerateAndRaidLevelValues = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsNodeType> reservedInstanceAvsNodes = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> reservedInstanceSupportedLocations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency> reservedInstanceSupportedCurrencies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode> reservedInstanceSupportedOffers = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationGuidelineContext MigrationGuidelineContext(string contextKey = null, string contextValue = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentOptionData MigrationSqlAssessmentOptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamilyConfig> vmFamilies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily> reservedInstanceVmFamilies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily> premiumDiskVmFamilies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily> savingsPlanVmFamilies = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> savingsPlanSupportedLocations = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> savingsPlanSupportedLocationsForPaas = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> reservedInstanceSupportedLocationsForIaas = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode> savingsPlanSupportedOffers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlPaasTargetConfig> sqlSkus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType> reservedInstanceSqlTargets = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> reservedInstanceSupportedLocations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency> reservedInstanceSupportedCurrencies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode> reservedInstanceSupportedOffers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode> supportedOffers = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2Data MigrationSqlAssessmentV2Data(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? provisioningState = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentOSLicense? osLicense = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentOSLicense?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentEnvironmentType? environmentType = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentEnvironmentType?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentEntityUptime entityUptime = null, Azure.ResourceManager.Migration.Assessment.Models.SqlOptimizationLogic? optimizationLogic = default(Azure.ResourceManager.Migration.Assessment.Models.SqlOptimizationLogic?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance? reservedInstanceForVm = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode? azureOfferCodeForVm = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode?), string eaSubscriptionId = null, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlMISettings azureSqlManagedInstanceSettings = null, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDBSettings azureSqlDatabaseSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily> azureSqlVmInstanceSeries = null, Azure.ResourceManager.Migration.Assessment.Models.MultiSubnetIntent? multiSubnetIntent = default(Azure.ResourceManager.Migration.Assessment.Models.MultiSubnetIntent?), Azure.ResourceManager.Migration.Assessment.Models.AsyncCommitModeIntent? asyncCommitModeIntent = default(Azure.ResourceManager.Migration.Assessment.Models.AsyncCommitModeIntent?), bool? isInternetAccessAvailable = default(bool?), Azure.Core.AzureLocation? disasterRecoveryLocation = default(Azure.Core.AzureLocation?), bool? isHadrAssessmentEnabled = default(bool?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentSecurityOfferingType? azureSecurityOfferingType = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSecurityOfferingType?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance? reservedInstance = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServerLicense? sqlServerLicense = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServerLicense?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType? groupType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentGroupType?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType? assessmentType = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType?), Azure.Core.AzureLocation? azureLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode? azureOfferCode = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency? currency = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency?), double? scalingFactor = default(double?), Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization? percentile = default(Azure.ResourceManager.Migration.Assessment.Models.PercentileOfUtilization?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange? timeRange = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentTimeRange?), System.DateTimeOffset? perfDataStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? perfDataEndOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage? stage = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage?), double? discountPercentage = default(double?), Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion? sizingCriterion = default(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSizingCriterion?), double? confidenceRatingInPercentage = default(double?), System.DateTimeOffset? pricesQueriedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus? status = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus?), string schemaVersion = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.MigrationSqlAssessmentV2SummaryData MigrationSqlAssessmentV2SummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2SummaryDetails> assessmentSummary = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionBySupportStatus = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionByServicePackInsight = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionBySqlVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, int> distributionBySqlEdition = null, System.Collections.Generic.IReadOnlyDictionary<string, int> instanceDistributionBySizingCriterion = null, System.Collections.Generic.IReadOnlyDictionary<string, int> databaseDistributionBySizingCriterion = null, int? numberOfMachines = default(int?), int? numberOfSqlInstances = default(int?), int? numberOfSuccessfullyDiscoveredSqlInstances = default(int?), int? numberOfSqlDatabases = default(int?), int? numberOfFciInstances = default(int?), int? numberOfSqlAvailabilityGroups = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto SharedResourcesDto(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto> sharedDataDisks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto> sharedLogDisks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto> sharedTempDBDisks = null, int? numberOfMounts = default(int?), Azure.ResourceManager.Migration.Assessment.Models.QuorumWitnessDtoQuorumWitnessType? quorumWitnessType = default(Azure.ResourceManager.Migration.Assessment.Models.QuorumWitnessDtoQuorumWitnessType?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlAssessedNetworkAdapter SqlAssessedNetworkAdapter(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail? suitabilityDetail = default(Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail?), Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityExplanation? suitabilityExplanation = default(Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityExplanation?), double? monthlyBandwidthCosts = default(double?), double? netGigabytesTransmittedPerMonth = default(double?), string name = null, string displayName = null, string macAddress = null, System.Collections.Generic.IEnumerable<string> ipAddresses = null, double? megabytesPerSecondReceived = default(double?), double? megabytesPerSecondTransmitted = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue SqlAssessmentMigrationIssue(string issueId = null, Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssueCategory? issueCategory = default(Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssueCategory?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.ImpactedAssessmentObject> impactedObjects = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2IaasSuitabilityDetails SqlAssessmentV2IaasSuitabilityDetails(Azure.ResourceManager.Migration.Assessment.Models.AssessmentAzureSqlIaasSkuDto azureSqlSku = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAzureSqlIaasSkuDto> replicaAzureSqlSku = null, Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto sharedResources = null, double? monthlyComputeCost = default(double?), double? monthlyStorageCost = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent> costComponents = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? securitySuitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), bool? shouldProvisionReplicas = default(bool?), Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode? skuReplicationMode = default(Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline> migrationGuidelines = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning> recommendationReasonings = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? migrationTargetPlatform = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue> migrationIssues = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2PaasSuitabilityDetails SqlAssessmentV2PaasSuitabilityDetails(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPaasSkuDto azureSqlSku = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPaasSkuDto> replicaAzureSqlSku = null, Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto sharedResources = null, double? monthlyComputeCost = default(double?), double? monthlyStorageCost = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent> costComponents = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? securitySuitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), bool? shouldProvisionReplicas = default(bool?), Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode? skuReplicationMode = default(Azure.ResourceManager.Migration.Assessment.Models.SkuReplicationMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline> migrationGuidelines = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning> recommendationReasonings = null, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? migrationTargetPlatform = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType?), Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? suitability = default(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue> migrationIssues = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentV2SummaryDetails SqlAssessmentV2SummaryDetails(System.Collections.Generic.IReadOnlyDictionary<string, int> suitabilitySummary = null, double? monthlyComputeCost = default(double?), double? monthlyStorageCost = default(double?), double? monthlyLicenseCost = default(double?), double? confidenceScore = default(double?), double? monthlySecurityCost = default(double?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityGroupDataOverview SqlAvailabilityGroupDataOverview(string availabilityGroupId = null, string availabilityGroupName = null, Azure.Core.ResourceIdentifier sqlAvailabilityGroupSdsArmId = null, string sqlAvailabilityGroupEntityId = null, string sqlAvailabilityReplicaId = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlAvailabilityReplicaSummary SqlAvailabilityReplicaSummary(int? numberOfSynchronousReadReplicas = default(int?), int? numberOfSynchronousNonReadReplicas = default(int?), int? numberOfAsynchronousReadReplicas = default(int?), int? numberOfAsynchronousNonReadReplicas = default(int?), int? numberOfPrimaryReplicas = default(int?)) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline SqlMigrationGuideline(string guidelineId = null, Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuidelineCategory? migrationGuidelineCategory = default(Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuidelineCategory?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.MigrationGuidelineContext> migrationGuidelineContext = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning SqlRecommendationReasoning(string reasoningId = null, string reasoningString = null, string reasoningCategory = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoningContext> contextParameters = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoningContext SqlRecommendationReasoningContext(string contextKey = null, string contextValue = null) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.UltraDiskAssessmentConfig UltraDiskAssessmentConfig(string familyName = null, System.Collections.Generic.IEnumerable<string> targetLocations = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessedDatabaseCompatibilityLevel : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessedDatabaseCompatibilityLevel(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel CompatLevel100 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel CompatLevel110 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel CompatLevel120 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel CompatLevel130 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel CompatLevel140 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel CompatLevel150 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel CompatLevel80 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel CompatLevel90 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel left, Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel left, Azure.ResourceManager.Migration.Assessment.Models.AssessedDatabaseCompatibilityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessedMachineBootType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessedMachineBootType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType Bios { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType Efi { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType left, Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType left, Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineBootType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessedMachineProcessorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineProcessorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineProcessorInfo>
    {
        public AssessedMachineProcessorInfo() { }
        public string Name { get { throw null; } set { } }
        public int? NumberOfCoresPerSocket { get { throw null; } set { } }
        public int? NumberOfSockets { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineProcessorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineProcessorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineProcessorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineProcessorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineProcessorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineProcessorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessedMachineProcessorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
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
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciState? SqlFciState { get { throw null; } }
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
    public readonly partial struct AssessedSqlRecommendedSuitability : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessedSqlRecommendedSuitability(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability ConditionallySuitableForSqlDB { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability ConditionallySuitableForSqlMI { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability ConditionallySuitableForSqlVm { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability ConditionallySuitableForVm { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability NotSuitable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability PotentiallySuitableForVm { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability ReadinessUnknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability SuitableForSqlDB { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability SuitableForSqlMI { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability SuitableForSqlVm { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability SuitableForVm { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability left, Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability left, Azure.ResourceManager.Migration.Assessment.Models.AssessedSqlRecommendedSuitability right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentAvsNodeType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsNodeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentAvsNodeType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsNodeType Av36 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsNodeType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsNodeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsNodeType left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsNodeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsNodeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsNodeType left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsNodeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessmentAvsSkuConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsSkuConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsSkuConfig>
    {
        public AssessmentAvsSkuConfig() { }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsNodeType? NodeType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> TargetLocations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsSkuConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsSkuConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsSkuConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsSkuConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsSkuConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsSkuConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAvsSkuConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessmentAzureSqlIaasSkuDto : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAzureSqlIaasSkuDto>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAzureSqlIaasSkuDto>
    {
        internal AssessmentAzureSqlIaasSkuDto() { }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? AzureSqlTargetType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto> DataDiskSizes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto> LogDiskSizes { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSkuDto VirtualMachineSize { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentAzureSqlIaasSkuDto System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAzureSqlIaasSkuDto>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAzureSqlIaasSkuDto>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentAzureSqlIaasSkuDto System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAzureSqlIaasSkuDto>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAzureSqlIaasSkuDto>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAzureSqlIaasSkuDto>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessmentCostComponent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent>
    {
        public AssessmentCostComponent() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponentName? Name { get { throw null; } }
        public double? Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentCostComponentName : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponentName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentCostComponentName(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponentName MonthlyAzureHybridCostSavings { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponentName MonthlyPremiumV2StorageCost { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponentName MonthlySecurityCost { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponentName Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponentName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponentName left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponentName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponentName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponentName left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponentName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentCurrency : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentCurrency(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency ARS { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency AUD { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency BRL { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency CAD { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency CHF { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency CNY { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency DKK { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency EUR { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency GBP { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency HKD { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency IdR { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency INR { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency JPY { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency KRW { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency MXN { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency MYR { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency NOK { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency NZD { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency RUB { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency SAR { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency SEK { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency TRY { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency TWD { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency USD { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency ZAR { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentCurrency right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentDiskSize : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentDiskSize(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize PremiumP1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize PremiumP10 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize PremiumP15 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize PremiumP2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize PremiumP20 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize PremiumP3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize PremiumP30 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize PremiumP4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize PremiumP40 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize PremiumP50 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize PremiumP6 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize PremiumP60 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize PremiumP70 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize PremiumP80 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize PremiumV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardS10 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardS15 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardS20 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardS30 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardS4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardS40 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardS50 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardS6 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardS60 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardS70 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardS80 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardSsdE1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardSsdE10 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardSsdE15 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardSsdE2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardSsdE20 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardSsdE3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardSsdE30 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardSsdE4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardSsdE40 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardSsdE50 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardSsdE6 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardSsdE60 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardSsdE70 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize StandardSsdE80 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize Ultra { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentDiskSuitabilityDetail : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentDiskSuitabilityDetail(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail DiskGigabytesConsumedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail DiskGigabytesConsumedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail DiskGigabytesProvisionedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail DiskGigabytesProvisionedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail MegabytesPerSecondOfReadMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail MegabytesPerSecondOfReadOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail MegabytesPerSecondOfWriteMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail MegabytesPerSecondOfWriteOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail None { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail NumberOfReadOperationsPerSecondMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail NumberOfReadOperationsPerSecondOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail NumberOfWriteOperationsPerSecondMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail NumberOfWriteOperationsPerSecondOutOfRange { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentDiskType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentDiskType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType Premium { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType PremiumV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType Standard { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType StandardOrPremium { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType StandardSsd { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType Ultra { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessmentEntityUptime : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentEntityUptime>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentEntityUptime>
    {
        public AssessmentEntityUptime() { }
        public int? DaysPerMonth { get { throw null; } set { } }
        public int? HoursPerDay { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentEntityUptime System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentEntityUptime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentEntityUptime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentEntityUptime System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentEntityUptime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentEntityUptime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentEntityUptime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType? AssessmentType { get { throw null; } }
        public int? Count { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentErrorSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentHybridUseBenefit : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentHybridUseBenefit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentHybridUseBenefit(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentHybridUseBenefit No { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentHybridUseBenefit Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentHybridUseBenefit Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentHybridUseBenefit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentHybridUseBenefit left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentHybridUseBenefit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentHybridUseBenefit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentHybridUseBenefit left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentHybridUseBenefit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessmentManagedDiskSkuDto : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto>
    {
        internal AssessmentManagedDiskSkuDto() { }
        public Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskRedundancy? DiskRedundancy { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize? DiskSize { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskType? DiskType { get { throw null; } }
        public double? RecommendedIops { get { throw null; } }
        public double? RecommendedSizeInGib { get { throw null; } }
        public double? RecommendedThroughputInMbps { get { throw null; } }
        public double? StorageCost { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentOfferCode : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentOfferCode(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode EA { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0003P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0022P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0023P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0025P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0029P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0036P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0044P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0059P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0060P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0062P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0063P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0064P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0111P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0120P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0121P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0122P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0123P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0124P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0125P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0126P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0127P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0128P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0129P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0130P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0144P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0148P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0149P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZR0243P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZRDE0003P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZRDE0044P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSAZRUSGOV0003P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSMCAZR0044P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSMCAZR0059P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSMCAZR0060P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSMCAZR0063P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSMCAZR0120P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSMCAZR0121P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSMCAZR0125P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode MSMCAZR0128P { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode SavingsPlan1Year { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode SavingsPlan3Year { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentOfferCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentPricingTier : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentPricingTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentPricingTier(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentPricingTier Basic { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentPricingTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentPricingTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentPricingTier left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentPricingTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentPricingTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentPricingTier left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentPricingTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessmentProductSupportStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus>
    {
        internal AssessmentProductSupportStatus() { }
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
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentProductSupportStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct AssessmentReservedInstance : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentReservedInstance(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance None { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance RI1Year { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance RI3Year { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentReservedInstance right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentSecurityOfferingType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSecurityOfferingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentSecurityOfferingType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSecurityOfferingType Mdc { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSecurityOfferingType No { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSecurityOfferingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSecurityOfferingType left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSecurityOfferingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentSecurityOfferingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSecurityOfferingType left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSecurityOfferingType right) { throw null; }
        public override string ToString() { throw null; }
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
    public readonly partial struct AssessmentSqlDataBaseType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDataBaseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentSqlDataBaseType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDataBaseType Automatic { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDataBaseType ElasticPool { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDataBaseType SingleDatabase { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDataBaseType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDataBaseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDataBaseType left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDataBaseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDataBaseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDataBaseType left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDataBaseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessmentSqlDBSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDBSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDBSettings>
    {
        public AssessmentSqlDBSettings() { }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier? AzureSqlComputeTier { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDataBaseType? AzureSqlDataBaseType { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPurchaseModel? AzureSqlPurchaseModel { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier? AzureSqlServiceTier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDBSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDBSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDBSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDBSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDBSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDBSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlDBSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessmentSqlFciMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadata>
    {
        internal AssessmentSqlFciMetadata() { }
        public int? FciSharedDiskCount { get { throw null; } }
        public bool? IsMultiSubnet { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentSqlFciMetadataState : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentSqlFciMetadataState(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState Failed { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState Inherited { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState Initializing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState Offline { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState OfflinePending { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState Online { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState OnlinePending { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState Pending { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciMetadataState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentSqlFciState : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentSqlFciState(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciState Active { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciState NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciState Passive { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciState left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciState left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlFciState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentSqlInstanceType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlInstanceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentSqlInstanceType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlInstanceType Automatic { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlInstanceType InstancePools { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlInstanceType SingleInstance { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlInstanceType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlInstanceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlInstanceType left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlInstanceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlInstanceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlInstanceType left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlInstanceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessmentSqlMISettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlMISettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlMISettings>
    {
        public AssessmentSqlMISettings() { }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlInstanceType? AzureSqlInstanceType { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier? AzureSqlServiceTier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlMISettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlMISettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlMISettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlMISettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlMISettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlMISettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlMISettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessmentSqlPaasSkuDto : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPaasSkuDto>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPaasSkuDto>
    {
        internal AssessmentSqlPaasSkuDto() { }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier? AzureSqlComputeTier { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration? AzureSqlHardwareGeneration { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier? AzureSqlServiceTier { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? AzureSqlTargetType { get { throw null; } }
        public int? Cores { get { throw null; } }
        public double? PredictedDataSizeInMB { get { throw null; } }
        public double? PredictedLogSizeInMB { get { throw null; } }
        public double? StorageMaxSizeInMB { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPaasSkuDto System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPaasSkuDto>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPaasSkuDto>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPaasSkuDto System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPaasSkuDto>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPaasSkuDto>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPaasSkuDto>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentSqlPurchaseModel : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPurchaseModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentSqlPurchaseModel(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPurchaseModel Dtu { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPurchaseModel Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPurchaseModel VCore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPurchaseModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPurchaseModel left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPurchaseModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPurchaseModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPurchaseModel left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPurchaseModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentSqlServerLicense : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServerLicense>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentSqlServerLicense(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServerLicense No { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServerLicense Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServerLicense Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServerLicense other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServerLicense left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServerLicense right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServerLicense (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServerLicense left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServerLicense right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentSqlServiceTier : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentSqlServiceTier(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier Automatic { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier BusinessCritical { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier HyperScale { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentStorageRedundancy : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentStorageRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentStorageRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentStorageRedundancy GeoRedundant { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentStorageRedundancy LocallyRedundant { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentStorageRedundancy ReadAccessGeoRedundant { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentStorageRedundancy Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentStorageRedundancy ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentStorageRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentStorageRedundancy left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentStorageRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentStorageRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentStorageRedundancy left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentStorageRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentSuitabilityExplanation : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentSuitabilityExplanation(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation DiskSizeGreaterThanSupported { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation InternalErrorOccurredForDiskEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation NoDiskSizeFoundForSelectedRedundancy { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation NoDiskSizeFoundInSelectedLocation { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation NoEAPriceFoundForDiskSize { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation NoSuitableDiskSizeForIops { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation NoSuitableDiskSizeForThroughput { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation right) { throw null; }
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
    public readonly partial struct AssessmentVmFamily : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentVmFamily(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Av2Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily BasicA0A4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Dadsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Dasv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Dasv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Dav4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily DCSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Ddsv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Ddsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Ddv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Ddv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily DSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily DSSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily DSv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Dsv3Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Dsv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Dsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Dv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Dv3Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Dv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Dv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Eadsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Easv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Easv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Eav4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Ebdsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Ebsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Edsv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Edsv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Edv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Edv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Esv3Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Esv4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Esv5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Ev3Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Ev4Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Ev5Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily FSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily FsSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Fsv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily GSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily GSSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily HSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily LsSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Lsv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Mdsv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily MSeries { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Msv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Mv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily StandardA0A7 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily StandardA8A11 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessmentVmFamilyConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamilyConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamilyConfig>
    {
        internal AssessmentVmFamilyConfig() { }
        public System.Collections.Generic.IReadOnlyList<string> Category { get { throw null; } }
        public string FamilyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TargetLocations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamilyConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamilyConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamilyConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamilyConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamilyConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamilyConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamilyConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentVmSize : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentVmSize(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize BasicA0 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize BasicA1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize BasicA2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize BasicA3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize BasicA4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA0 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA10 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA11 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA1V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA2MV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA2V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA4MV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA4V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA6 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA7 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA8 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA8MV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA8V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardA9 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD11 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD11V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD12 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD12V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD13 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD13V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD14 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD14V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD15V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD16AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD16AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD16AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD16AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD16DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD16DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD16DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD16DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD16SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD16SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD16SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD16V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD16V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD16V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD1V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD2AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD2AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD2AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD2AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD2DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD2DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD2DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD2DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD2SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD2SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD2SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD2V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD2V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD2V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD2V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD32AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD32AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD32AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD32AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD32DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD32DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD32DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD32DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD32SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD32SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD32SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD32V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD32V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD32V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD3V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD48AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD48AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD48AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD48AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD48DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD48DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD48DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD48DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD48SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD48SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD48V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD48V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD4AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD4AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD4AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD4AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD4DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD4DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD4DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD4DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD4SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD4SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD4SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD4V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD4V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD4V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD4V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD5V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD64AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD64AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD64AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD64AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD64DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD64DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD64DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD64DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD64SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD64SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD64SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD64V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD64V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD64V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD8AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD8AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD8AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD8AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD8DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD8DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD8DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD8DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD8SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD8SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD8SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD8V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD8V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD8V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD96AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD96AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD96AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD96AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD96DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD96DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD96SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardD96V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDC2S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDC4S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS11 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS111V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS11V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS12 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS121V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS122V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS12V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS13 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS132V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS134V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS13V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS14 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS144V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS148V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS14V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS15V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS1V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS2V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS3V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS4V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardDS5V2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE104IdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE104IdV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE104IsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE104IV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE164AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE164AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE164AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE164DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE164DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE164SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE164SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE164SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE168AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE168AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE168AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE168DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE168DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE168SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE168SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE168SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE16AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE16AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE16AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE16AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE16BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE16BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE16DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE16DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE16DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE16DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE16SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE16SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE16SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE16V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE16V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE16V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE20AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE20AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE20AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE20AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE20DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE20DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE20DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE20DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE20SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE20SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE20SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE20V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE20V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE20V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE2AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE2AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE2AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE2AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE2BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE2BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE2DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE2DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE2DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE2DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE2SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE2SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE2SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE2V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE2V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE2V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE3216AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE3216AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE3216AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE3216DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE3216DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE3216SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE3216SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE3216SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE328AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE328AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE328AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE328DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE328DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE328SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE328SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE328SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE32AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE32AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE32AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE32AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE32BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE32BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE32DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE32DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE32DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE32DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE32SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE32SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE32SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE32V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE32V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE32V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE42AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE42AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE42AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE42DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE42DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE42SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE42SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE42SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE48AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE48AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE48AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE48AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE48BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE48BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE48DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE48DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE48DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE48DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE48SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE48SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE48SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE48V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE48V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE48V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE4AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE4AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE4AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE4AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE4BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE4BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE4DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE4DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE4DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE4DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE4SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE4SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE4SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE4V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE4V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE4V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE6416AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE6416AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE6416AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE6416DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE6416DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE6416SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE6416SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE6416SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE6432AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE6432AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE6432AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE6432DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE6432DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE6432SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE6432SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE6432SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64IsV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64IV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE64V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE80IdsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE80IsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE82AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE82AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE82AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE82DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE82DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE82SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE82SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE82SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE84AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE84AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE84AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE84DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE84DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE84SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE84SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE84SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE8AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE8AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE8AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE8AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE8BdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE8BsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE8DsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE8DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE8DV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE8DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE8SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE8SV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE8SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE8V3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE8V4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE8V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE9624AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE9624AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE9624AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE9624DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE9624SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE9648AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE9648AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE9648AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE9648DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE9648SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE96AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE96AsV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE96AsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE96AV4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE96DsV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE96DV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE96SV5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardE96V5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF16 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF16S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF16SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF1S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF2S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF2SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF32SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF48SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF4S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF4SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF64SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF72SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF8 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF8S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardF8SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardG1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardG2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardG3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardG4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardG5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardGS1 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardGS2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardGS3 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardGS4 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardGS44 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardGS48 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardGS5 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardGS516 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardGS58 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardH16 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardH16M { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardH16Mr { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardH16R { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardH8 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardH8M { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardL16S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardL16SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardL32S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardL32SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardL48SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardL4S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardL64SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardL80SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardL8S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardL8SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM128 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM12832Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM12864Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM128DmsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM128DsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM128M { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM128Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM128MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM128S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM128SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM164Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM168Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM16Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM192IdmsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM192IdsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM192ImsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM192IsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM208MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM208SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM3216Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM328Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM32DmsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM32Ls { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM32Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM32MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM32Ts { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM416208MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM416208SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM416MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM416SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM64 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM6416Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM6432Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM64DmsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM64DsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM64Ls { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM64M { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM64Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM64MsV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM64S { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM64SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM82Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM84Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize StandardM8Ms { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessmentVmSkuDto : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSkuDto>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSkuDto>
    {
        internal AssessmentVmSkuDto() { }
        public int? AvailableCores { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSize? AzureSkuName { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmFamily? AzureVmFamily { get { throw null; } }
        public int? Cores { get { throw null; } }
        public int? MaxNetworkInterfaces { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSkuDto System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSkuDto>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSkuDto>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSkuDto System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSkuDto>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSkuDto>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSkuDto>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentVmSuitabilityDetail : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentVmSuitabilityDetail(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail CannotReportBandwidthCosts { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail CannotReportComputeCost { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail CannotReportStorageCost { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail None { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail PercentageOfCoresUtilizedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail PercentageOfCoresUtilizedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail PercentageOfMemoryUtilizedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail PercentageOfMemoryUtilizedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail RecommendedSizeHasLessNetworkAdapters { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentVmSuitabilityExplanation : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentVmSuitabilityExplanation(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation BootTypeNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation BootTypeUnknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation CheckCentOSVersion { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation CheckCoreOSLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation CheckDebianLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation CheckOpenSuseLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation CheckOracleLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation CheckRedHatLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation CheckSuseLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation CheckUbuntuLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation CheckWindowsServer2008R2Version { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation EndorsedWithConditionsLinuxDistributions { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation GuestOperatingSystemArchitectureNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation GuestOperatingSystemNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation GuestOperatingSystemUnknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation InternalErrorOccurredDuringComputeEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation InternalErrorOccurredDuringNetworkEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation InternalErrorOccurredDuringStorageEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation MoreDisksThanSupported { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation NoEAPriceFoundForVmSize { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation NoGuestOperatingSystemConditionallySupported { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation NoSuitableVmSizeFound { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation NoVmSizeForBasicPricingTier { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation NoVmSizeForSelectedAzureLocation { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation NoVmSizeForSelectedPricingTier { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation NoVmSizeForStandardPricingTier { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation NoVmSizeFoundForOfferCurrencyReservedInstance { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation NoVmSizeInSelectedFamilyFound { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation NoVmSizeSupportsNetworkPerformance { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation NoVmSizeSupportsStoragePerformance { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation OneOrMoreAdaptersNotSuitable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation OneOrMoreDisksNotSuitable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation UnendorsedLinuxDistributions { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation WindowsClientVersionsConditionallySupported { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation WindowsOSNoLongerUnderMSSupport { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation WindowsServerVersionConditionallySupported { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation WindowsServerVersionsSupportedWithCaveat { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation left, Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmSuitabilityExplanation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssessmentVmUptime : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmUptime>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmUptime>
    {
        public AssessmentVmUptime() { }
        public int? DaysPerMonth { get { throw null; } set { } }
        public int? HoursPerDay { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmUptime System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmUptime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmUptime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmUptime System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmUptime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmUptime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentVmUptime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessmentWorkloadSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentWorkloadSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentWorkloadSummary>
    {
        internal AssessmentWorkloadSummary() { }
        public int? OracleInstances { get { throw null; } }
        public int? SpringApps { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentWorkloadSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentWorkloadSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentWorkloadSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.AssessmentWorkloadSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentWorkloadSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentWorkloadSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.AssessmentWorkloadSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct ManagedDiskSkuDtoDiskRedundancy : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedDiskSkuDtoDiskRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskRedundancy Lrs { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskRedundancy Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskRedundancy Zrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskRedundancy left, Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskRedundancy left, Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedDiskSkuDtoDiskType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedDiskSkuDtoDiskType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskType Premium { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskType PremiumV2 { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskType Standard { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskType StandardOrPremium { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskType StandardSsd { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskType Ultra { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskType left, Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskType left, Azure.ResourceManager.Migration.Assessment.Models.ManagedDiskSkuDtoDiskType right) { throw null; }
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
    public partial class MigrationAssessedDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDataDisk>
    {
        internal MigrationAssessedDataDisk() { }
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
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize? RecommendedDiskSize { get { throw null; } }
        public int? RecommendedDiskSizeGigabytes { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType? RecommendedDiskType { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationAssessedDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDisk>
    {
        internal MigrationAssessedDisk() { }
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
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSize? RecommendedDiskSize { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskType? RecommendedDiskType { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentCloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentDiskSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationAssessedMachineType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationAssessedMachineType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType AssessedMachine { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType AvsAssessedMachine { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType SqlAssessedMachine { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessedMachineType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class MigrationAssessmentProjectPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProjectPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProjectPatch>
    {
        public MigrationAssessmentProjectPatch() { }
        public Azure.Core.ResourceIdentifier AssessmentSolutionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CustomerStorageAccountArmId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CustomerWorkspaceId { get { throw null; } set { } }
        public string CustomerWorkspaceLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentProjectStatus? ProjectStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProjectPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProjectPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProjectPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProjectPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProjectPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProjectPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentProjectPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct MigrationAssessmentStage : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationAssessmentStage(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage Approved { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage InProgress { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage UnderReview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationAssessmentStatus : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationAssessmentStatus(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus Created { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus OutDated { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus OutOfSync { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus Updated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentStatus right) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationAssessmentType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationAssessmentType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType AvsAssessment { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType MachineAssessment { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType SqlAssessment { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType WebAppAssessment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType left, Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentType right) { throw null; }
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
    public readonly partial struct NetworkAdapterSuitabilityDetail : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkAdapterSuitabilityDetail(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail MegabytesOfDataRecievedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail MegabytesOfDataRecievedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail MegabytesOfDataTransmittedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail MegabytesOfDataTransmittedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail left, Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail left, Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkAdapterSuitabilityExplanation : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityExplanation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkAdapterSuitabilityExplanation(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityExplanation InternalErrorOccurred { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityExplanation NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityExplanation Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityExplanation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityExplanation left, Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityExplanation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityExplanation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityExplanation left, Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityExplanation right) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuorumWitnessDtoQuorumWitnessType : System.IEquatable<Azure.ResourceManager.Migration.Assessment.Models.QuorumWitnessDtoQuorumWitnessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuorumWitnessDtoQuorumWitnessType(string value) { throw null; }
        public static Azure.ResourceManager.Migration.Assessment.Models.QuorumWitnessDtoQuorumWitnessType Cloud { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.QuorumWitnessDtoQuorumWitnessType Disk { get { throw null; } }
        public static Azure.ResourceManager.Migration.Assessment.Models.QuorumWitnessDtoQuorumWitnessType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migration.Assessment.Models.QuorumWitnessDtoQuorumWitnessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migration.Assessment.Models.QuorumWitnessDtoQuorumWitnessType left, Azure.ResourceManager.Migration.Assessment.Models.QuorumWitnessDtoQuorumWitnessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migration.Assessment.Models.QuorumWitnessDtoQuorumWitnessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migration.Assessment.Models.QuorumWitnessDtoQuorumWitnessType left, Azure.ResourceManager.Migration.Assessment.Models.QuorumWitnessDtoQuorumWitnessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SharedResourcesDto : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SharedResourcesDto>
    {
        internal SharedResourcesDto() { }
        public int? NumberOfMounts { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.QuorumWitnessDtoQuorumWitnessType? QuorumWitnessType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto> SharedDataDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto> SharedLogDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentManagedDiskSkuDto> SharedTempDBDisks { get { throw null; } }
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
        public Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.NetworkAdapterSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
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
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentAzureSqlIaasSkuDto AzureSqlSku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent> CostComponents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline> MigrationGuidelines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue> MigrationIssues { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? MigrationTargetPlatform { get { throw null; } }
        public double? MonthlyComputeCost { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning> RecommendationReasonings { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentAzureSqlIaasSkuDto> ReplicaAzureSqlSku { get { throw null; } }
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
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPaasSkuDto AzureSqlSku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentCostComponent> CostComponents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.SqlMigrationGuideline> MigrationGuidelines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.SqlAssessmentMigrationIssue> MigrationIssues { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? MigrationTargetPlatform { get { throw null; } }
        public double? MonthlyComputeCost { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.SqlRecommendationReasoning> RecommendationReasonings { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlPaasSkuDto> ReplicaAzureSqlSku { get { throw null; } }
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
    public partial class SqlPaasTargetConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlPaasTargetConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlPaasTargetConfig>
    {
        public SqlPaasTargetConfig() { }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentComputeTier? ComputeTier { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentHardwareGeneration? HardwareGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Migration.Assessment.Models.AssessmentSqlServiceTier? ServiceTier { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> TargetLocations { get { throw null; } }
        public Azure.ResourceManager.Migration.Assessment.Models.MigrationAssessmentTargetType? TargetType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlPaasTargetConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlPaasTargetConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Migration.Assessment.Models.SqlPaasTargetConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Migration.Assessment.Models.SqlPaasTargetConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlPaasTargetConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlPaasTargetConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Migration.Assessment.Models.SqlPaasTargetConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
}
