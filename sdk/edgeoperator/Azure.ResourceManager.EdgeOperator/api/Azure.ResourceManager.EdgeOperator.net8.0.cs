namespace Azure.ResourceManager.EdgeOperator
{
    public partial class AzureResourceManagerEdgeOperatorContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerEdgeOperatorContext() { }
        public static Azure.ResourceManager.EdgeOperator.AzureResourceManagerEdgeOperatorContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BillingConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationData>
    {
        public BillingConfigurationData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOperator.BillingConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOperator.BillingConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingConfigurationResource() { }
        public virtual Azure.ResourceManager.EdgeOperator.BillingConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOperator.BillingConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOperator.BillingConfigurationData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeOperator.BillingConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeOperator.BillingConfigurationData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOperator.BillingConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOperator.BillingConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource> GetBillingConfigurationSnapshot(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource>> GetBillingConfigurationSnapshotAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotCollection GetBillingConfigurationSnapshots() { throw null; }
        Azure.ResourceManager.EdgeOperator.BillingConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOperator.BillingConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingConfigurationSnapshotCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource>, System.Collections.IEnumerable
    {
        protected BillingConfigurationSnapshotCollection() { }
        public virtual Azure.Response<bool> Exists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource> Get(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource>> GetAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource> GetIfExists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource>> GetIfExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BillingConfigurationSnapshotData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData>
    {
        internal BillingConfigurationSnapshotData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingConfigurationSnapshotResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingConfigurationSnapshotResource() { }
        public virtual Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string snapshotName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class EdgeOperatorExtensions
    {
        public static Azure.ResourceManager.EdgeOperator.BillingConfigurationResource GetBillingConfiguration(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.EdgeOperator.BillingConfigurationResource GetBillingConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource GetBillingConfigurationSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeOperator.Mocking
{
    public partial class MockableEdgeOperatorArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeOperatorArmClient() { }
        public virtual Azure.ResourceManager.EdgeOperator.BillingConfigurationResource GetBillingConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotResource GetBillingConfigurationSnapshotResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableEdgeOperatorSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeOperatorSubscriptionResource() { }
        public virtual Azure.ResourceManager.EdgeOperator.BillingConfigurationResource GetBillingConfiguration() { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeOperator.Models
{
    public static partial class ArmEdgeOperatorModelFactory
    {
        public static Azure.ResourceManager.EdgeOperator.Models.BenefitPlans BenefitPlans(Azure.ResourceManager.EdgeOperator.Models.BenefitPlanStatus? azureHybridWindowsServerBenefit = default(Azure.ResourceManager.EdgeOperator.Models.BenefitPlanStatus?), int? windowsServerVmCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.EdgeOperator.BillingConfigurationData BillingConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationProperties properties = null, string eTag = null) { throw null; }
        public static Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationDetails BillingConfigurationDetails(Azure.ResourceManager.EdgeOperator.Models.AutoRenew autoRenew = default(Azure.ResourceManager.EdgeOperator.Models.AutoRenew), Azure.ResourceManager.EdgeOperator.Models.BillingStatus billingStatus = default(Azure.ResourceManager.EdgeOperator.Models.BillingStatus), Azure.ResourceManager.EdgeOperator.Models.BillingPeriodDetails current = null, Azure.ResourceManager.EdgeOperator.Models.BillingPeriodDetails upcoming = null) { throw null; }
        public static Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationProperties BillingConfigurationProperties(Azure.Core.ResourceIdentifier resourceId = null, string resourceName = null, string stampId = null, string location = null, Azure.ResourceManager.EdgeOperator.Models.BillingModel billingModel = default(Azure.ResourceManager.EdgeOperator.Models.BillingModel), Azure.ResourceManager.EdgeOperator.Models.ConnectionIntent connectionIntent = default(Azure.ResourceManager.EdgeOperator.Models.ConnectionIntent), string cloud = null, Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationDetails billingConfiguration = null, Azure.ResourceManager.EdgeOperator.Models.BenefitPlans benefitPlans = null, Azure.ResourceManager.EdgeOperator.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeOperator.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EdgeOperator.BillingConfigurationSnapshotData BillingConfigurationSnapshotData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationProperties properties = null, string eTag = null) { throw null; }
        public static Azure.ResourceManager.EdgeOperator.Models.BillingPeriodDetails BillingPeriodDetails(int cores = 0, Azure.ResourceManager.EdgeOperator.Models.PricingModel pricingModel = default(Azure.ResourceManager.EdgeOperator.Models.PricingModel), System.DateTimeOffset startOn = default(System.DateTimeOffset), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoRenew : System.IEquatable<Azure.ResourceManager.EdgeOperator.Models.AutoRenew>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoRenew(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOperator.Models.AutoRenew Disabled { get { throw null; } }
        public static Azure.ResourceManager.EdgeOperator.Models.AutoRenew Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOperator.Models.AutoRenew other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOperator.Models.AutoRenew left, Azure.ResourceManager.EdgeOperator.Models.AutoRenew right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOperator.Models.AutoRenew (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOperator.Models.AutoRenew? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOperator.Models.AutoRenew left, Azure.ResourceManager.EdgeOperator.Models.AutoRenew right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BenefitPlans : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.BenefitPlans>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.BenefitPlans>
    {
        public BenefitPlans() { }
        public Azure.ResourceManager.EdgeOperator.Models.BenefitPlanStatus? AzureHybridWindowsServerBenefit { get { throw null; } set { } }
        public int? WindowsServerVmCount { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOperator.Models.BenefitPlans JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOperator.Models.BenefitPlans PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOperator.Models.BenefitPlans System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.BenefitPlans>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.BenefitPlans>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOperator.Models.BenefitPlans System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.BenefitPlans>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.BenefitPlans>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.BenefitPlans>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BenefitPlanStatus : System.IEquatable<Azure.ResourceManager.EdgeOperator.Models.BenefitPlanStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BenefitPlanStatus(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOperator.Models.BenefitPlanStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.EdgeOperator.Models.BenefitPlanStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOperator.Models.BenefitPlanStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOperator.Models.BenefitPlanStatus left, Azure.ResourceManager.EdgeOperator.Models.BenefitPlanStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOperator.Models.BenefitPlanStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOperator.Models.BenefitPlanStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOperator.Models.BenefitPlanStatus left, Azure.ResourceManager.EdgeOperator.Models.BenefitPlanStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingConfigurationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationDetails>
    {
        public BillingConfigurationDetails(Azure.ResourceManager.EdgeOperator.Models.AutoRenew autoRenew, Azure.ResourceManager.EdgeOperator.Models.BillingStatus billingStatus, Azure.ResourceManager.EdgeOperator.Models.BillingPeriodDetails current) { }
        public Azure.ResourceManager.EdgeOperator.Models.AutoRenew AutoRenew { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOperator.Models.BillingStatus BillingStatus { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOperator.Models.BillingPeriodDetails Current { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOperator.Models.BillingPeriodDetails Upcoming { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationProperties>
    {
        public BillingConfigurationProperties(Azure.Core.ResourceIdentifier resourceId, string resourceName, string stampId, string location, Azure.ResourceManager.EdgeOperator.Models.BillingModel billingModel, Azure.ResourceManager.EdgeOperator.Models.ConnectionIntent connectionIntent, Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationDetails billingConfiguration) { }
        public Azure.ResourceManager.EdgeOperator.Models.BenefitPlans BenefitPlans { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationDetails BillingConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOperator.Models.BillingModel BillingModel { get { throw null; } set { } }
        public string Cloud { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOperator.Models.ConnectionIntent ConnectionIntent { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOperator.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        public string StampId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.BillingConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingModel : System.IEquatable<Azure.ResourceManager.EdgeOperator.Models.BillingModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingModel(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOperator.Models.BillingModel Capacity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOperator.Models.BillingModel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOperator.Models.BillingModel left, Azure.ResourceManager.EdgeOperator.Models.BillingModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOperator.Models.BillingModel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOperator.Models.BillingModel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOperator.Models.BillingModel left, Azure.ResourceManager.EdgeOperator.Models.BillingModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingPeriodDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.BillingPeriodDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.BillingPeriodDetails>
    {
        public BillingPeriodDetails(int cores, Azure.ResourceManager.EdgeOperator.Models.PricingModel pricingModel, System.DateTimeOffset startOn) { }
        public int Cores { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeOperator.Models.PricingModel PricingModel { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeOperator.Models.BillingPeriodDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOperator.Models.BillingPeriodDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOperator.Models.BillingPeriodDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.BillingPeriodDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.BillingPeriodDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOperator.Models.BillingPeriodDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.BillingPeriodDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.BillingPeriodDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.BillingPeriodDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingStatus : System.IEquatable<Azure.ResourceManager.EdgeOperator.Models.BillingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingStatus(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOperator.Models.BillingStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.EdgeOperator.Models.BillingStatus Enabled { get { throw null; } }
        public static Azure.ResourceManager.EdgeOperator.Models.BillingStatus Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOperator.Models.BillingStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOperator.Models.BillingStatus left, Azure.ResourceManager.EdgeOperator.Models.BillingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOperator.Models.BillingStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOperator.Models.BillingStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOperator.Models.BillingStatus left, Azure.ResourceManager.EdgeOperator.Models.BillingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionIntent : System.IEquatable<Azure.ResourceManager.EdgeOperator.Models.ConnectionIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionIntent(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOperator.Models.ConnectionIntent Connected { get { throw null; } }
        public static Azure.ResourceManager.EdgeOperator.Models.ConnectionIntent Disconnected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOperator.Models.ConnectionIntent other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOperator.Models.ConnectionIntent left, Azure.ResourceManager.EdgeOperator.Models.ConnectionIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOperator.Models.ConnectionIntent (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOperator.Models.ConnectionIntent? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOperator.Models.ConnectionIntent left, Azure.ResourceManager.EdgeOperator.Models.ConnectionIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PricingModel : System.IEquatable<Azure.ResourceManager.EdgeOperator.Models.PricingModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PricingModel(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOperator.Models.PricingModel Annual { get { throw null; } }
        public static Azure.ResourceManager.EdgeOperator.Models.PricingModel Trial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOperator.Models.PricingModel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOperator.Models.PricingModel left, Azure.ResourceManager.EdgeOperator.Models.PricingModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOperator.Models.PricingModel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOperator.Models.PricingModel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOperator.Models.PricingModel left, Azure.ResourceManager.EdgeOperator.Models.PricingModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.EdgeOperator.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOperator.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EdgeOperator.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EdgeOperator.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOperator.Models.ResourceProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOperator.Models.ResourceProvisioningState left, Azure.ResourceManager.EdgeOperator.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOperator.Models.ResourceProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOperator.Models.ResourceProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOperator.Models.ResourceProvisioningState left, Azure.ResourceManager.EdgeOperator.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
