namespace Azure.ResourceManager.DataBox
{
    public partial class AzureResourceManagerDataBoxContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDataBoxContext() { }
        public static Azure.ResourceManager.DataBox.AzureResourceManagerDataBoxContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class DataBoxExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.DataBox.Models.DataBoxSkuInformation> GetAvailableSkus(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.AvailableSkusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataBox.Models.DataBoxSkuInformation> GetAvailableSkusAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.AvailableSkusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataBox.DataBoxJobResource> GetDataBoxJob(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.DataBoxJobResource>> GetDataBoxJobAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataBox.DataBoxJobResource GetDataBoxJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBox.DataBoxJobCollection GetDataBoxJobs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataBox.DataBoxJobResource> GetDataBoxJobs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataBox.DataBoxJobResource> GetDataBoxJobsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataBox.Models.RegionConfigurationResult> GetRegionConfiguration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.RegionConfigurationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataBox.Models.RegionConfigurationResult> GetRegionConfiguration(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.RegionConfigurationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.Models.RegionConfigurationResult>> GetRegionConfigurationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.RegionConfigurationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.Models.RegionConfigurationResult>> GetRegionConfigurationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.RegionConfigurationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataBox.Models.AddressValidationOutput> ValidateAddress(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.DataBoxValidateAddressContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.Models.AddressValidationOutput>> ValidateAddressAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.DataBoxValidateAddressContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataBox.Models.DataBoxValidationResult> ValidateInputs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.DataBoxValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataBox.Models.DataBoxValidationResult> ValidateInputs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.DataBoxValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.Models.DataBoxValidationResult>> ValidateInputsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.DataBoxValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.Models.DataBoxValidationResult>> ValidateInputsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.DataBoxValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBox.DataBoxJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.DataBoxJobResource>, System.Collections.IEnumerable
    {
        protected DataBoxJobCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBox.DataBoxJobResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.DataBox.DataBoxJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBox.DataBoxJobResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.DataBox.DataBoxJobData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.DataBoxJobResource> Get(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBox.DataBoxJobResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBox.DataBoxJobResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.DataBoxJobResource>> GetAsync(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataBox.DataBoxJobResource> GetIfExists(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataBox.DataBoxJobResource>> GetIfExistsAsync(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBox.DataBoxJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBox.DataBoxJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBox.DataBoxJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.DataBoxJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataBoxJobData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.DataBoxJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.DataBoxJobData>
    {
        public DataBoxJobData(Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType transferType, Azure.ResourceManager.DataBox.Models.DataBoxSku sku) { }
        public bool? AreAllDevicesLost { get { throw null; } }
        public string CancellationReason { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxStageName? DelayedStage { get { throw null; } }
        public System.DateTimeOffset? DeliveryInfoScheduledOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.JobDeliveryType? DeliveryType { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails Details { get { throw null; } set { } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsCancellable { get { throw null; } }
        public bool? IsCancellableWithoutFee { get { throw null; } }
        public bool? IsDeletable { get { throw null; } }
        public bool? IsPrepareToShipEnabled { get { throw null; } }
        public bool? IsShippingAddressEditable { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.ReverseShippingDetailsEditStatus? ReverseShippingDetailsUpdate { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.ReverseTransportPreferenceEditStatus? ReverseTransportPreferenceUpdate { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxStageName? Status { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType TransferType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.DataBoxJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.DataBoxJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.DataBoxJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.DataBoxJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.DataBoxJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.DataBoxJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.DataBoxJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxJobResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.DataBoxJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.DataBoxJobData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataBoxJobResource() { }
        public virtual Azure.ResourceManager.DataBox.DataBoxJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.DataBoxJobResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.DataBoxJobResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.Models.DataBoxShipmentPickUpResult> BookShipmentPickUp(Azure.ResourceManager.DataBox.Models.ShipmentPickUpContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.Models.DataBoxShipmentPickUpResult>> BookShipmentPickUpAsync(Azure.ResourceManager.DataBox.Models.ShipmentPickUpContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Cancel(Azure.ResourceManager.DataBox.Models.DataBoxJobCancellationReason cancellationReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(Azure.ResourceManager.DataBox.Models.DataBoxJobCancellationReason cancellationReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string jobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.DataBoxJobResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.DataBoxJobResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBox.Models.UnencryptedCredentials> GetCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBox.Models.UnencryptedCredentials> GetCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response MarkDevicesShipped(Azure.ResourceManager.DataBox.Models.MarkDevicesShippedContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> MarkDevicesShippedAsync(Azure.ResourceManager.DataBox.Models.MarkDevicesShippedContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Mitigate(Azure.ResourceManager.DataBox.Models.MitigateJobContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> MitigateAsync(Azure.ResourceManager.DataBox.Models.MitigateJobContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.DataBoxJobResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.DataBoxJobResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.DataBoxJobResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.DataBoxJobResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DataBox.DataBoxJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.DataBoxJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.DataBoxJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.DataBoxJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.DataBoxJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.DataBoxJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.DataBoxJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBox.DataBoxJobResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBox.Models.DataBoxJobPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBox.DataBoxJobResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBox.Models.DataBoxJobPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataBox.Mocking
{
    public partial class MockableDataBoxArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDataBoxArmClient() { }
        public virtual Azure.ResourceManager.DataBox.DataBoxJobResource GetDataBoxJobResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDataBoxResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDataBoxResourceGroupResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBox.Models.DataBoxSkuInformation> GetAvailableSkus(Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.AvailableSkusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBox.Models.DataBoxSkuInformation> GetAvailableSkusAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.AvailableSkusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.DataBoxJobResource> GetDataBoxJob(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.DataBoxJobResource>> GetDataBoxJobAsync(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBox.DataBoxJobCollection GetDataBoxJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.Models.RegionConfigurationResult> GetRegionConfiguration(Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.RegionConfigurationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.Models.RegionConfigurationResult>> GetRegionConfigurationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.RegionConfigurationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.Models.DataBoxValidationResult> ValidateInputs(Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.DataBoxValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.Models.DataBoxValidationResult>> ValidateInputsAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.DataBoxValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableDataBoxSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDataBoxSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBox.DataBoxJobResource> GetDataBoxJobs(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBox.DataBoxJobResource> GetDataBoxJobsAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.Models.RegionConfigurationResult> GetRegionConfiguration(Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.RegionConfigurationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.Models.RegionConfigurationResult>> GetRegionConfigurationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.RegionConfigurationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.Models.AddressValidationOutput> ValidateAddress(Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.DataBoxValidateAddressContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.Models.AddressValidationOutput>> ValidateAddressAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.DataBoxValidateAddressContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.Models.DataBoxValidationResult> ValidateInputs(Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.DataBoxValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.Models.DataBoxValidationResult>> ValidateInputsAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.DataBoxValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataBox.Models
{
    public partial class AddressValidationOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.AddressValidationOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.AddressValidationOutput>
    {
        internal AddressValidationOutput() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress> AlternateAddresses { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.AddressValidationStatus? ValidationStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.AddressValidationOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.AddressValidationOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.AddressValidationOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.AddressValidationOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.AddressValidationOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.AddressValidationOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.AddressValidationOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AddressValidationResult : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.AddressValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.AddressValidationResult>
    {
        internal AddressValidationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress> AlternateAddresses { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.AddressValidationStatus? ValidationStatus { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.AddressValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.AddressValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.AddressValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.AddressValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.AddressValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.AddressValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.AddressValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AddressValidationStatus
    {
        Valid = 0,
        Invalid = 1,
        Ambiguous = 2,
    }
    public partial class ApplianceNetworkConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration>
    {
        internal ApplianceNetworkConfiguration() { }
        public string MacAddress { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmDataBoxModelFactory
    {
        public static Azure.ResourceManager.DataBox.Models.AddressValidationResult AddressValidationResult(Azure.ResponseError error = null, Azure.ResourceManager.DataBox.Models.AddressValidationStatus? validationStatus = default(Azure.ResourceManager.DataBox.Models.AddressValidationStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress> alternateAddresses = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration ApplianceNetworkConfiguration(string name = null, string macAddress = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.AvailableSkusContent AvailableSkusContent(Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType transferType = Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType.ImportToAzure, string country = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxSkuName> skuNames = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationContent CreateOrderLimitForSubscriptionValidationContent(Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationContent CreateOrderLimitForSubscriptionValidationContent(Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType = Azure.ResourceManager.DataBox.Models.DataBoxSkuName.DataBox, Azure.ResourceManager.DataBox.Models.DeviceModelName? model = default(Azure.ResourceManager.DataBox.Models.DeviceModelName?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationResult CreateOrderLimitForSubscriptionValidationResult(Azure.ResponseError error = null, Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? status = default(Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.CustomerDiskJobSecrets CustomerDiskJobSecrets(Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode dataCenterAccessSecurityCode = null, Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxDiskSecret> diskSecrets = null, string carrierAccountNumber = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxAccountCopyLogDetails DataBoxAccountCopyLogDetails(string accountName = null, string copyLogLink = null, string copyVerboseLogLink = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxAccountCredentialDetails DataBoxAccountCredentialDetails(string accountName = null, Azure.ResourceManager.DataBox.Models.DataAccountType? dataAccountType = default(Azure.ResourceManager.DataBox.Models.DataAccountType?), string accountConnectionString = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.ShareCredentialDetails> shareCredentialDetails = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails DataBoxBasicJobDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxJobStage> jobStages = null, Azure.ResourceManager.DataBox.Models.DataBoxContactDetails contactDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress shippingAddress = null, Azure.ResourceManager.DataBox.Models.PackageShippingDetails deliveryPackage = null, Azure.ResourceManager.DataBox.Models.PackageShippingDetails returnPackage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataImportDetails> dataImportDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataExportDetails> dataExportDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences preferences = null, Azure.ResourceManager.DataBox.Models.ReverseShippingDetails reverseShippingDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CopyLogDetails> copyLogDetails = null, string reverseShipmentLabelSasKey = null, string chainOfCustodySasKey = null, Azure.ResourceManager.DataBox.Models.DeviceErasureDetails deviceErasureDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey keyEncryptionKey = null, int? expectedDataSizeInTerabytes = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> actions = null, Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob lastMitigationActionOnJob = null, Azure.ResourceManager.DataBox.Models.DataCenterAddressResult dataCenterAddress = null, Azure.ResourceManager.DataBox.Models.DataCenterCode? dataCenterCode = default(Azure.ResourceManager.DataBox.Models.DataCenterCode?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress DataBoxCopyProgress(string storageAccountName = null, Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType? transferType = default(Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType?), Azure.ResourceManager.DataBox.Models.DataAccountType? dataAccountType = default(Azure.ResourceManager.DataBox.Models.DataAccountType?), Azure.Core.ResourceIdentifier accountId = null, long? bytesProcessed = default(long?), long? totalBytesToProcess = default(long?), long? filesProcessed = default(long?), long? totalFilesToProcess = default(long?), long? invalidFilesProcessed = default(long?), long? invalidFileBytesUploaded = default(long?), long? renamedContainerCount = default(long?), long? filesErroredOut = default(long?), long? directoriesErroredOut = default(long?), long? invalidDirectoriesProcessed = default(long?), bool? isEnumerationInProgress = default(bool?), Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> actions = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyLogDetails DataBoxCustomerDiskCopyLogDetails(string serialNumber = null, string errorLogLink = null, string verboseLogLink = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyProgress DataBoxCustomerDiskCopyProgress(string storageAccountName = null, Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType? transferType = default(Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType?), Azure.ResourceManager.DataBox.Models.DataAccountType? dataAccountType = default(Azure.ResourceManager.DataBox.Models.DataAccountType?), Azure.Core.ResourceIdentifier accountId = null, long? bytesProcessed = default(long?), long? totalBytesToProcess = default(long?), long? filesProcessed = default(long?), long? totalFilesToProcess = default(long?), long? invalidFilesProcessed = default(long?), long? invalidFileBytesUploaded = default(long?), long? renamedContainerCount = default(long?), long? filesErroredOut = default(long?), long? directoriesErroredOut = default(long?), long? invalidDirectoriesProcessed = default(long?), bool? isEnumerationInProgress = default(bool?), Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> actions = null, string serialNumber = null, Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus? copyStatus = default(Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskJobDetails DataBoxCustomerDiskJobDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxJobStage> jobStages = null, Azure.ResourceManager.DataBox.Models.DataBoxContactDetails contactDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress shippingAddress = null, Azure.ResourceManager.DataBox.Models.PackageShippingDetails deliveryPackage = null, Azure.ResourceManager.DataBox.Models.PackageShippingDetails returnPackage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataImportDetails> dataImportDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataExportDetails> dataExportDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences preferences = null, Azure.ResourceManager.DataBox.Models.ReverseShippingDetails reverseShippingDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CopyLogDetails> copyLogDetails = null, string reverseShipmentLabelSasKey = null, string chainOfCustodySasKey = null, Azure.ResourceManager.DataBox.Models.DeviceErasureDetails deviceErasureDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey keyEncryptionKey = null, int? expectedDataSizeInTerabytes = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> actions = null, Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob lastMitigationActionOnJob = null, Azure.ResourceManager.DataBox.Models.DataCenterAddressResult dataCenterAddress = null, Azure.ResourceManager.DataBox.Models.DataCenterCode? dataCenterCode = default(Azure.ResourceManager.DataBox.Models.DataCenterCode?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataBox.Models.ImportDiskDetails> importDiskDetails = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataBox.Models.ExportDiskDetails> exportDiskDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyProgress> copyProgress = null, Azure.ResourceManager.DataBox.Models.PackageCarrierInfo deliverToDataCenterPackageDetails = null, Azure.ResourceManager.DataBox.Models.PackageCarrierDetails returnToCustomerPackageDetails = null, bool? enableManifestBackup = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyLogDetails DataBoxDiskCopyLogDetails(string diskSerialNumber = null, string errorLogLink = null, string verboseLogLink = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyProgress DataBoxDiskCopyProgress(string serialNumber = null, long? bytesCopied = default(long?), int? percentComplete = default(int?), Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus? status = default(Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus?), Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> actions = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyLogDetails DataBoxDiskGranularCopyLogDetails(string serialNumber = null, Azure.Core.ResourceIdentifier accountId = null, string errorLogLink = null, string verboseLogLink = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyProgress DataBoxDiskGranularCopyProgress(string storageAccountName = null, Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType? transferType = default(Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType?), Azure.ResourceManager.DataBox.Models.DataAccountType? dataAccountType = default(Azure.ResourceManager.DataBox.Models.DataAccountType?), Azure.Core.ResourceIdentifier accountId = null, long? bytesProcessed = default(long?), long? totalBytesToProcess = default(long?), long? filesProcessed = default(long?), long? totalFilesToProcess = default(long?), long? invalidFilesProcessed = default(long?), long? invalidFileBytesUploaded = default(long?), long? renamedContainerCount = default(long?), long? filesErroredOut = default(long?), long? directoriesErroredOut = default(long?), long? invalidDirectoriesProcessed = default(long?), bool? isEnumerationInProgress = default(bool?), Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> actions = null, string serialNumber = null, Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus? copyStatus = default(Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxDiskJobDetails DataBoxDiskJobDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxJobStage> jobStages = null, Azure.ResourceManager.DataBox.Models.DataBoxContactDetails contactDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress shippingAddress = null, Azure.ResourceManager.DataBox.Models.PackageShippingDetails deliveryPackage = null, Azure.ResourceManager.DataBox.Models.PackageShippingDetails returnPackage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataImportDetails> dataImportDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataExportDetails> dataExportDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences preferences = null, Azure.ResourceManager.DataBox.Models.ReverseShippingDetails reverseShippingDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CopyLogDetails> copyLogDetails = null, string reverseShipmentLabelSasKey = null, string chainOfCustodySasKey = null, Azure.ResourceManager.DataBox.Models.DeviceErasureDetails deviceErasureDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey keyEncryptionKey = null, int? expectedDataSizeInTerabytes = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> actions = null, Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob lastMitigationActionOnJob = null, Azure.ResourceManager.DataBox.Models.DataCenterAddressResult dataCenterAddress = null, Azure.ResourceManager.DataBox.Models.DataCenterCode? dataCenterCode = default(Azure.ResourceManager.DataBox.Models.DataCenterCode?), System.Collections.Generic.IDictionary<string, int> preferredDisks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyProgress> copyProgress = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyProgress> granularCopyProgress = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyLogDetails> granularCopyLogDetails = null, System.Collections.Generic.IReadOnlyDictionary<string, int> disksAndSizeDetails = null, string passkey = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxDiskJobSecrets DataBoxDiskJobSecrets(Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode dataCenterAccessSecurityCode = null, Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxDiskSecret> diskSecrets = null, string passkey = null, bool? isPasskeyUserDefined = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxDiskSecret DataBoxDiskSecret(string diskSerialNumber = null, string bitLockerKey = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxHeavyAccountCopyLogDetails DataBoxHeavyAccountCopyLogDetails(string accountName = null, System.Collections.Generic.IEnumerable<string> copyLogLink = null, System.Collections.Generic.IEnumerable<string> copyVerboseLogLink = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobDetails DataBoxHeavyJobDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxJobStage> jobStages = null, Azure.ResourceManager.DataBox.Models.DataBoxContactDetails contactDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress shippingAddress = null, Azure.ResourceManager.DataBox.Models.PackageShippingDetails deliveryPackage = null, Azure.ResourceManager.DataBox.Models.PackageShippingDetails returnPackage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataImportDetails> dataImportDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataExportDetails> dataExportDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences preferences = null, Azure.ResourceManager.DataBox.Models.ReverseShippingDetails reverseShippingDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CopyLogDetails> copyLogDetails = null, string reverseShipmentLabelSasKey = null, string chainOfCustodySasKey = null, Azure.ResourceManager.DataBox.Models.DeviceErasureDetails deviceErasureDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey keyEncryptionKey = null, int? expectedDataSizeInTerabytes = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> actions = null, Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob lastMitigationActionOnJob = null, Azure.ResourceManager.DataBox.Models.DataCenterAddressResult dataCenterAddress = null, Azure.ResourceManager.DataBox.Models.DataCenterCode? dataCenterCode = default(Azure.ResourceManager.DataBox.Models.DataCenterCode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress> copyProgress = null, string devicePassword = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobSecrets DataBoxHeavyJobSecrets(Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode dataCenterAccessSecurityCode = null, Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxHeavySecret> cabinetPodSecrets = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxHeavySecret DataBoxHeavySecret(string deviceSerialNumber = null, string devicePassword = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration> networkConfigurations = null, string encodedValidationCertPubKey = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxAccountCredentialDetails> accountCredentialDetails = null) { throw null; }
        public static Azure.ResourceManager.DataBox.DataBoxJobData DataBoxJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType transferType = Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType.ImportToAzure, bool? isCancellable = default(bool?), bool? isDeletable = default(bool?), bool? isShippingAddressEditable = default(bool?), Azure.ResourceManager.DataBox.Models.ReverseShippingDetailsEditStatus? reverseShippingDetailsUpdate = default(Azure.ResourceManager.DataBox.Models.ReverseShippingDetailsEditStatus?), Azure.ResourceManager.DataBox.Models.ReverseTransportPreferenceEditStatus? reverseTransportPreferenceUpdate = default(Azure.ResourceManager.DataBox.Models.ReverseTransportPreferenceEditStatus?), bool? isPrepareToShipEnabled = default(bool?), Azure.ResourceManager.DataBox.Models.DataBoxStageName? status = default(Azure.ResourceManager.DataBox.Models.DataBoxStageName?), Azure.ResourceManager.DataBox.Models.DataBoxStageName? delayedStage = default(Azure.ResourceManager.DataBox.Models.DataBoxStageName?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), Azure.ResponseError error = null, Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails details = null, string cancellationReason = null, Azure.ResourceManager.DataBox.Models.JobDeliveryType? deliveryType = default(Azure.ResourceManager.DataBox.Models.JobDeliveryType?), System.DateTimeOffset? deliveryInfoScheduledOn = default(System.DateTimeOffset?), bool? isCancellableWithoutFee = default(bool?), bool? areAllDevicesLost = default(bool?), Azure.ResourceManager.DataBox.Models.DataBoxSku sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DataBox.DataBoxJobData DataBoxJobData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType transferType, bool? isCancellable, bool? isDeletable, bool? isShippingAddressEditable, Azure.ResourceManager.DataBox.Models.ReverseShippingDetailsEditStatus? reverseShippingDetailsUpdate, Azure.ResourceManager.DataBox.Models.ReverseTransportPreferenceEditStatus? reverseTransportPreferenceUpdate, bool? isPrepareToShipEnabled, Azure.ResourceManager.DataBox.Models.DataBoxStageName? status, System.DateTimeOffset? startOn, Azure.ResponseError error, Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails details, string cancellationReason, Azure.ResourceManager.DataBox.Models.JobDeliveryType? deliveryType, System.DateTimeOffset? deliveryInfoScheduledOn, bool? isCancellableWithoutFee, Azure.ResourceManager.DataBox.Models.DataBoxSku sku, Azure.ResourceManager.Models.ManagedServiceIdentity identity) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxJobDetails DataBoxJobDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxJobStage> jobStages = null, Azure.ResourceManager.DataBox.Models.DataBoxContactDetails contactDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress shippingAddress = null, Azure.ResourceManager.DataBox.Models.PackageShippingDetails deliveryPackage = null, Azure.ResourceManager.DataBox.Models.PackageShippingDetails returnPackage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataImportDetails> dataImportDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataExportDetails> dataExportDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences preferences = null, Azure.ResourceManager.DataBox.Models.ReverseShippingDetails reverseShippingDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CopyLogDetails> copyLogDetails = null, string reverseShipmentLabelSasKey = null, string chainOfCustodySasKey = null, Azure.ResourceManager.DataBox.Models.DeviceErasureDetails deviceErasureDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey keyEncryptionKey = null, int? expectedDataSizeInTerabytes = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> actions = null, Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob lastMitigationActionOnJob = null, Azure.ResourceManager.DataBox.Models.DataCenterAddressResult dataCenterAddress = null, Azure.ResourceManager.DataBox.Models.DataCenterCode? dataCenterCode = default(Azure.ResourceManager.DataBox.Models.DataCenterCode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress> copyProgress = null, string devicePassword = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This class is method and will be removed in a future release.Please use DataBoxJobSecrets instead.", false)]
        public static Azure.ResourceManager.DataBox.Models.DataboxJobSecrets DataboxJobSecrets(Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode dataCenterAccessSecurityCode, Azure.ResponseError error, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxSecret> podSecrets) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxJobSecrets DataBoxJobSecrets(Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode dataCenterAccessSecurityCode = null, Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxSecret> podSecrets = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DataBox.Models.DataBoxJobStage DataBoxJobStage(Azure.ResourceManager.DataBox.Models.DataBoxStageName? stageName, string displayName, Azure.ResourceManager.DataBox.Models.DataBoxStageStatus? stageStatus, System.DateTimeOffset? stageTime, System.BinaryData jobStageDetails) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxJobStage DataBoxJobStage(Azure.ResourceManager.DataBox.Models.DataBoxStageName? stageName = default(Azure.ResourceManager.DataBox.Models.DataBoxStageName?), string displayName = null, Azure.ResourceManager.DataBox.Models.DataBoxStageStatus? stageStatus = default(Azure.ResourceManager.DataBox.Models.DataBoxStageStatus?), System.DateTimeOffset? stageTime = default(System.DateTimeOffset?), System.BinaryData jobStageDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.JobDelayDetails> delayInformation = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DataBox.Models.DataBoxScheduleAvailabilityContent DataBoxScheduleAvailabilityContent(Azure.Core.AzureLocation storageLocation, string country) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxScheduleAvailabilityContent DataBoxScheduleAvailabilityContent(Azure.Core.AzureLocation storageLocation = default(Azure.Core.AzureLocation), string country = null, Azure.ResourceManager.DataBox.Models.DeviceModelName? model = default(Azure.ResourceManager.DataBox.Models.DeviceModelName?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxSecret DataBoxSecret(string deviceSerialNumber = null, string devicePassword = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration> networkConfigurations = null, string encodedValidationCertPubKey = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxAccountCredentialDetails> accountCredentialDetails = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxShipmentPickUpResult DataBoxShipmentPickUpResult(string confirmationNumber = null, System.DateTimeOffset? readyBy = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DataBox.Models.DataBoxSkuCapacity DataBoxSkuCapacity(string usable, string maximum) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxSkuCapacity DataBoxSkuCapacity(string usable = null, string maximum = null, string individualSkuUsable = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxSkuCost DataBoxSkuCost(System.Guid? meterId = default(System.Guid?), string meterType = null, double? multiplier = default(double?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxSkuInformation DataBoxSkuInformation(Azure.ResourceManager.DataBox.Models.DataBoxSku sku = null, bool? isEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataLocationToServiceLocationMap> dataLocationToServiceLocationMap = null, Azure.ResourceManager.DataBox.Models.DataBoxSkuCapacity capacity = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxSkuCost> costs = null, System.Collections.Generic.IEnumerable<string> apiVersions = null, Azure.ResourceManager.DataBox.Models.SkuDisabledReason? disabledReason = default(Azure.ResourceManager.DataBox.Models.SkuDisabledReason?), string disabledReasonMessage = null, string requiredFeature = null, System.Collections.Generic.IEnumerable<string> countriesWithinCommerceBoundary = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DataBox.Models.DataBoxValidateAddressContent DataBoxValidateAddressContent(Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress shippingAddress, Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType, Azure.ResourceManager.DataBox.Models.TransportPreferences transportPreferences) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxValidateAddressContent DataBoxValidateAddressContent(Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress shippingAddress = null, Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType = Azure.ResourceManager.DataBox.Models.DataBoxSkuName.DataBox, Azure.ResourceManager.DataBox.Models.TransportPreferences transportPreferences = null, Azure.ResourceManager.DataBox.Models.DeviceModelName? model = default(Azure.ResourceManager.DataBox.Models.DeviceModelName?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult DataBoxValidationInputResult(Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxValidationResult DataBoxValidationResult(Azure.ResourceManager.DataBox.Models.OverallValidationStatus? status = default(Azure.ResourceManager.DataBox.Models.OverallValidationStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult> individualResponseDetails = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode DataCenterAccessSecurityCode(string reverseDataCenterAccessCode = null, string forwardDataCenterAccessCode = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataCenterAddressContent DataCenterAddressContent(Azure.Core.AzureLocation storageLocation = default(Azure.Core.AzureLocation), Azure.ResourceManager.DataBox.Models.DataBoxSkuName skuName = Azure.ResourceManager.DataBox.Models.DataBoxSkuName.DataBox, Azure.ResourceManager.DataBox.Models.DeviceModelName? model = default(Azure.ResourceManager.DataBox.Models.DeviceModelName?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataCenterAddressInstructionResult DataCenterAddressInstructionResult(System.Collections.Generic.IEnumerable<string> supportedCarriersForReturnShipment = null, Azure.Core.AzureLocation? dataCenterAzureLocation = default(Azure.Core.AzureLocation?), string communicationInstruction = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataCenterAddressLocationResult DataCenterAddressLocationResult(System.Collections.Generic.IEnumerable<string> supportedCarriersForReturnShipment = null, Azure.Core.AzureLocation? dataCenterAzureLocation = default(Azure.Core.AzureLocation?), string contactPersonName = null, string company = null, string street1 = null, string street2 = null, string street3 = null, string city = null, string state = null, string zip = null, string country = null, string phone = null, string phoneExtension = null, string addressType = null, string additionalShippingInformation = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataCenterAddressResult DataCenterAddressResult(System.Collections.Generic.IEnumerable<string> supportedCarriersForReturnShipment = null, Azure.Core.AzureLocation? dataCenterAzureLocation = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataLocationToServiceLocationMap DataLocationToServiceLocationMap(Azure.Core.AzureLocation? dataLocation = default(Azure.Core.AzureLocation?), Azure.Core.AzureLocation? serviceLocation = default(Azure.Core.AzureLocation?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationContent DataTransferDetailsValidationContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataExportDetails> dataExportDetails, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataImportDetails> dataImportDetails, Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType, Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType transferType) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationContent DataTransferDetailsValidationContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataExportDetails> dataExportDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataImportDetails> dataImportDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType = Azure.ResourceManager.DataBox.Models.DataBoxSkuName.DataBox, Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType transferType = Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType.ImportToAzure, Azure.ResourceManager.DataBox.Models.DeviceModelName? model = default(Azure.ResourceManager.DataBox.Models.DeviceModelName?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationResult DataTransferDetailsValidationResult(Azure.ResponseError error = null, Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? status = default(Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DeviceCapabilityDetails DeviceCapabilityDetails(Azure.ResourceManager.DataBox.Models.HardwareEncryption? hardwareEncryption = default(Azure.ResourceManager.DataBox.Models.HardwareEncryption?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DeviceErasureDetails DeviceErasureDetails(Azure.ResourceManager.DataBox.Models.DataBoxStageStatus? deviceErasureStatus = default(Azure.ResourceManager.DataBox.Models.DataBoxStageStatus?), string erasureOrDestructionCertificateSasKey = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DataBox.Models.DiskScheduleAvailabilityContent DiskScheduleAvailabilityContent(Azure.Core.AzureLocation storageLocation, string country, int expectedDataSizeInTerabytes) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DiskScheduleAvailabilityContent DiskScheduleAvailabilityContent(Azure.Core.AzureLocation storageLocation = default(Azure.Core.AzureLocation), string country = null, Azure.ResourceManager.DataBox.Models.DeviceModelName? model = default(Azure.ResourceManager.DataBox.Models.DeviceModelName?), int expectedDataSizeInTerabytes = 0) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.ExportDiskDetails ExportDiskDetails(string manifestFile = null, string manifestHash = null, string backupManifestCloudPath = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.GranularCopyProgress GranularCopyProgress(string storageAccountName = null, Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType? transferType = default(Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType?), Azure.ResourceManager.DataBox.Models.DataAccountType? dataAccountType = default(Azure.ResourceManager.DataBox.Models.DataAccountType?), Azure.Core.ResourceIdentifier accountId = null, long? bytesProcessed = default(long?), long? totalBytesToProcess = default(long?), long? filesProcessed = default(long?), long? totalFilesToProcess = default(long?), long? invalidFilesProcessed = default(long?), long? invalidFileBytesUploaded = default(long?), long? renamedContainerCount = default(long?), long? filesErroredOut = default(long?), long? directoriesErroredOut = default(long?), long? invalidDirectoriesProcessed = default(long?), bool? isEnumerationInProgress = default(bool?), Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> actions = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DataBox.Models.HeavyScheduleAvailabilityContent HeavyScheduleAvailabilityContent(Azure.Core.AzureLocation storageLocation, string country) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.HeavyScheduleAvailabilityContent HeavyScheduleAvailabilityContent(Azure.Core.AzureLocation storageLocation = default(Azure.Core.AzureLocation), string country = null, Azure.ResourceManager.DataBox.Models.DeviceModelName? model = default(Azure.ResourceManager.DataBox.Models.DeviceModelName?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.ImportDiskDetails ImportDiskDetails(string manifestFile = null, string manifestHash = null, string bitLockerKey = null, string backupManifestCloudPath = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.JobDelayDetails JobDelayDetails(Azure.ResourceManager.DataBox.Models.DelayNotificationStatus? status = default(Azure.ResourceManager.DataBox.Models.DelayNotificationStatus?), Azure.ResourceManager.DataBox.Models.PortalDelayErrorCode? errorCode = default(Azure.ResourceManager.DataBox.Models.PortalDelayErrorCode?), string description = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? resolutionOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.JobSecrets JobSecrets(Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode dataCenterAccessSecurityCode = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob LastMitigationActionOnJob(System.DateTimeOffset? actionPerformedOn = default(System.DateTimeOffset?), bool? isPerformedByCustomer = default(bool?), Azure.ResourceManager.DataBox.Models.CustomerResolutionCode? customerResolution = default(Azure.ResourceManager.DataBox.Models.CustomerResolutionCode?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.MitigateJobContent MitigateJobContent(Azure.ResourceManager.DataBox.Models.CustomerResolutionCode customerResolutionCode = Azure.ResourceManager.DataBox.Models.CustomerResolutionCode.None, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> serialNumberCustomerResolutionMap = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.PackageShippingDetails PackageShippingDetails(System.Uri trackingUri = null, string carrierName = null, string trackingId = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DataBox.Models.PreferencesValidationContent PreferencesValidationContent(Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences preference, Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.PreferencesValidationContent PreferencesValidationContent(Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences preference = null, Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType = Azure.ResourceManager.DataBox.Models.DataBoxSkuName.DataBox, Azure.ResourceManager.DataBox.Models.DeviceModelName? model = default(Azure.ResourceManager.DataBox.Models.DeviceModelName?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.PreferencesValidationResult PreferencesValidationResult(Azure.ResponseError error = null, Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? status = default(Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DataBox.Models.RegionConfigurationResult RegionConfigurationResult(System.Collections.Generic.IEnumerable<System.DateTimeOffset> scheduleAvailabilityResponseAvailableDates, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.TransportAvailabilityDetails> transportAvailabilityDetails, Azure.ResourceManager.DataBox.Models.DataCenterAddressResult dataCenterAddressResponse) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.RegionConfigurationResult RegionConfigurationResult(System.Collections.Generic.IEnumerable<System.DateTimeOffset> scheduleAvailabilityResponseAvailableDates = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.TransportAvailabilityDetails> transportAvailabilityDetails = null, Azure.ResourceManager.DataBox.Models.DataCenterAddressResult dataCenterAddressResponse = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DeviceCapabilityDetails> deviceCapabilityDetails = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.ReverseShippingDetails ReverseShippingDetails(Azure.ResourceManager.DataBox.Models.ContactInfo contactDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress shippingAddress = null, bool? isUpdated = default(bool?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent ScheduleAvailabilityContent(Azure.Core.AzureLocation storageLocation, string country) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent ScheduleAvailabilityContent(Azure.Core.AzureLocation storageLocation = default(Azure.Core.AzureLocation), string country = null, Azure.ResourceManager.DataBox.Models.DeviceModelName? model = default(Azure.ResourceManager.DataBox.Models.DeviceModelName?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.ShareCredentialDetails ShareCredentialDetails(string shareName = null, Azure.ResourceManager.DataBox.Models.ShareDestinationFormatType? shareType = default(Azure.ResourceManager.DataBox.Models.ShareDestinationFormatType?), string userName = null, string password = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxAccessProtocol> supportedAccessProtocols = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationContent SkuAvailabilityValidationContent(Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType, Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType transferType, string country, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationContent SkuAvailabilityValidationContent(Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType = Azure.ResourceManager.DataBox.Models.DataBoxSkuName.DataBox, Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType transferType = Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType.ImportToAzure, string country = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DataBox.Models.DeviceModelName? model = default(Azure.ResourceManager.DataBox.Models.DeviceModelName?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationResult SkuAvailabilityValidationResult(Azure.ResponseError error = null, Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? status = default(Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationResult SubscriptionIsAllowedToCreateJobValidationResult(Azure.ResponseError error = null, Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? status = default(Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.TransportAvailabilityDetails TransportAvailabilityDetails(Azure.ResourceManager.DataBox.Models.TransportShipmentType? shipmentType = default(Azure.ResourceManager.DataBox.Models.TransportShipmentType?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.TransportPreferences TransportPreferences(Azure.ResourceManager.DataBox.Models.TransportShipmentType preferredShipmentType = Azure.ResourceManager.DataBox.Models.TransportShipmentType.CustomerManaged, bool? isUpdated = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.UnencryptedCredentials UnencryptedCredentials(string jobName = null, Azure.ResourceManager.DataBox.Models.JobSecrets jobSecrets = null) { throw null; }
    }
    public partial class AvailableSkusContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.AvailableSkusContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.AvailableSkusContent>
    {
        public AvailableSkusContent(Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType transferType, string country, Azure.Core.AzureLocation location) { }
        public string Country { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.DataBoxSkuName> SkuNames { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType TransferType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.AvailableSkusContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.AvailableSkusContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.AvailableSkusContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.AvailableSkusContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.AvailableSkusContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.AvailableSkusContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.AvailableSkusContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFileFilterDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.AzureFileFilterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.AzureFileFilterDetails>
    {
        public AzureFileFilterDetails() { }
        public System.Collections.Generic.IList<string> FilePathList { get { throw null; } }
        public System.Collections.Generic.IList<string> FilePrefixList { get { throw null; } }
        public System.Collections.Generic.IList<string> FileShareList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.AzureFileFilterDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.AzureFileFilterDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.AzureFileFilterDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.AzureFileFilterDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.AzureFileFilterDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.AzureFileFilterDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.AzureFileFilterDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobFilterDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.BlobFilterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.BlobFilterDetails>
    {
        public BlobFilterDetails() { }
        public System.Collections.Generic.IList<string> BlobPathList { get { throw null; } }
        public System.Collections.Generic.IList<string> BlobPrefixList { get { throw null; } }
        public System.Collections.Generic.IList<string> ContainerList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.BlobFilterDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.BlobFilterDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.BlobFilterDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.BlobFilterDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.BlobFilterDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.BlobFilterDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.BlobFilterDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContactInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ContactInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ContactInfo>
    {
        public ContactInfo(string contactName, string phone) { }
        public string ContactName { get { throw null; } set { } }
        public string Mobile { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
        public string PhoneExtension { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ContactInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ContactInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ContactInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ContactInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ContactInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ContactInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ContactInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class CopyLogDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.CopyLogDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CopyLogDetails>
    {
        protected CopyLogDetails() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.CopyLogDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.CopyLogDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.CopyLogDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.CopyLogDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CopyLogDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CopyLogDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CopyLogDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateJobValidationContent : Azure.ResourceManager.DataBox.Models.DataBoxValidationContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.CreateJobValidationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CreateJobValidationContent>
    {
        public CreateJobValidationContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent> individualRequestDetails) : base (default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent>)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.CreateJobValidationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.CreateJobValidationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.CreateJobValidationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.CreateJobValidationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CreateJobValidationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CreateJobValidationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CreateJobValidationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateOrderLimitForSubscriptionValidationContent : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationContent>
    {
        public CreateOrderLimitForSubscriptionValidationContent(Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType) { }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName DeviceType { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DeviceModelName? Model { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateOrderLimitForSubscriptionValidationResult : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationResult>
    {
        internal CreateOrderLimitForSubscriptionValidationResult() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CreateOrderLimitForSubscriptionValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomerDiskJobSecrets : Azure.ResourceManager.DataBox.Models.JobSecrets, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.CustomerDiskJobSecrets>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CustomerDiskJobSecrets>
    {
        internal CustomerDiskJobSecrets() { }
        public string CarrierAccountNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxDiskSecret> DiskSecrets { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.CustomerDiskJobSecrets System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.CustomerDiskJobSecrets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.CustomerDiskJobSecrets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.CustomerDiskJobSecrets System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CustomerDiskJobSecrets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CustomerDiskJobSecrets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.CustomerDiskJobSecrets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum CustomerResolutionCode
    {
        None = 0,
        MoveToCleanUpDevice = 1,
        Resume = 2,
        Restart = 3,
        ReachOutToOperation = 4,
    }
    public abstract partial class DataAccountDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataAccountDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataAccountDetails>
    {
        protected DataAccountDetails() { }
        public string SharePassword { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataAccountDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataAccountDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataAccountDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataAccountDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataAccountDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataAccountDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataAccountDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DataAccountType
    {
        StorageAccount = 0,
        ManagedDisk = 1,
    }
    public enum DataBoxAccessProtocol
    {
        Smb = 0,
        Nfs = 1,
    }
    public partial class DataBoxAccountCopyLogDetails : Azure.ResourceManager.DataBox.Models.CopyLogDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxAccountCopyLogDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxAccountCopyLogDetails>
    {
        internal DataBoxAccountCopyLogDetails() { }
        public string AccountName { get { throw null; } }
        public string CopyLogLink { get { throw null; } }
        public string CopyVerboseLogLink { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxAccountCopyLogDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxAccountCopyLogDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxAccountCopyLogDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxAccountCopyLogDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxAccountCopyLogDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxAccountCopyLogDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxAccountCopyLogDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxAccountCredentialDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxAccountCredentialDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxAccountCredentialDetails>
    {
        internal DataBoxAccountCredentialDetails() { }
        public string AccountConnectionString { get { throw null; } }
        public string AccountName { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataAccountType? DataAccountType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.ShareCredentialDetails> ShareCredentialDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxAccountCredentialDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxAccountCredentialDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxAccountCredentialDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxAccountCredentialDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxAccountCredentialDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxAccountCredentialDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxAccountCredentialDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataBoxBasicJobDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails>
    {
        protected DataBoxBasicJobDetails(Azure.ResourceManager.DataBox.Models.DataBoxContactDetails contactDetails) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> Actions { get { throw null; } }
        public string ChainOfCustodySasKey { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxContactDetails ContactDetails { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.CopyLogDetails> CopyLogDetails { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataCenterAddressResult DataCenterAddress { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataCenterCode? DataCenterCode { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.DataExportDetails> DataExportDetails { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.DataImportDetails> DataImportDetails { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.PackageShippingDetails DeliveryPackage { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DeviceErasureDetails DeviceErasureDetails { get { throw null; } }
        public int? ExpectedDataSizeInTerabytes { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxJobStage> JobStages { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey KeyEncryptionKey { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob LastMitigationActionOnJob { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences Preferences { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.PackageShippingDetails ReturnPackage { get { throw null; } }
        public string ReverseShipmentLabelSasKey { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.ReverseShippingDetails ReverseShippingDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress ShippingAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxContactDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxContactDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxContactDetails>
    {
        public DataBoxContactDetails(string contactName, string phone, System.Collections.Generic.IEnumerable<string> emailList) { }
        public string ContactName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailList { get { throw null; } }
        public string Mobile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.NotificationPreference> NotificationPreference { get { throw null; } }
        public string Phone { get { throw null; } set { } }
        public string PhoneExtension { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxContactDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxContactDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxContactDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxContactDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxContactDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxContactDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxContactDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxCopyProgress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress>
    {
        internal DataBoxCopyProgress() { }
        public Azure.Core.ResourceIdentifier AccountId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> Actions { get { throw null; } }
        public long? BytesProcessed { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataAccountType? DataAccountType { get { throw null; } }
        public long? DirectoriesErroredOut { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public long? FilesErroredOut { get { throw null; } }
        public long? FilesProcessed { get { throw null; } }
        public long? InvalidDirectoriesProcessed { get { throw null; } }
        public long? InvalidFileBytesUploaded { get { throw null; } }
        public long? InvalidFilesProcessed { get { throw null; } }
        public bool? IsEnumerationInProgress { get { throw null; } }
        public long? RenamedContainerCount { get { throw null; } }
        public string StorageAccountName { get { throw null; } }
        public long? TotalBytesToProcess { get { throw null; } }
        public long? TotalFilesToProcess { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType? TransferType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxCopyStatus : System.IEquatable<Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxCopyStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus CompletedWithErrors { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus DeviceFormatted { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus DeviceMetadataModified { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus DriveCorrupted { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus DriveNotDetected { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus DriveNotReceived { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus HardwareError { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus MetadataFilesModifiedOrRemoved { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus NotReturned { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus OtherServiceError { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus OtherUserError { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus StorageAccountNotAccessible { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus UnsupportedData { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus UnsupportedDrive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus left, Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus left, Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxCustomerDiskCopyLogDetails : Azure.ResourceManager.DataBox.Models.CopyLogDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyLogDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyLogDetails>
    {
        internal DataBoxCustomerDiskCopyLogDetails() { }
        public string ErrorLogLink { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public string VerboseLogLink { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyLogDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyLogDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyLogDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyLogDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyLogDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyLogDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyLogDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxCustomerDiskCopyProgress : Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyProgress>
    {
        internal DataBoxCustomerDiskCopyProgress() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus? CopyStatus { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyProgress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyProgress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxCustomerDiskJobDetails : Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskJobDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskJobDetails>
    {
        public DataBoxCustomerDiskJobDetails(Azure.ResourceManager.DataBox.Models.DataBoxContactDetails contactDetails, Azure.ResourceManager.DataBox.Models.PackageCarrierDetails returnToCustomerPackageDetails) : base (default(Azure.ResourceManager.DataBox.Models.DataBoxContactDetails)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyProgress> CopyProgress { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.PackageCarrierInfo DeliverToDataCenterPackageDetails { get { throw null; } }
        public bool? EnableManifestBackup { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataBox.Models.ExportDiskDetails> ExportDiskDetails { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataBox.Models.ImportDiskDetails> ImportDiskDetails { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.PackageCarrierDetails ReturnToCustomerPackageDetails { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskJobDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskJobDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskJobDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskJobDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskJobDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskJobDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskJobDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxDiskCopyLogDetails : Azure.ResourceManager.DataBox.Models.CopyLogDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyLogDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyLogDetails>
    {
        internal DataBoxDiskCopyLogDetails() { }
        public string DiskSerialNumber { get { throw null; } }
        public string ErrorLogLink { get { throw null; } }
        public string VerboseLogLink { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyLogDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyLogDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyLogDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyLogDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyLogDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyLogDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyLogDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxDiskCopyProgress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyProgress>
    {
        internal DataBoxDiskCopyProgress() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> Actions { get { throw null; } }
        public long? BytesCopied { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyProgress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyProgress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxDiskGranularCopyLogDetails : Azure.ResourceManager.DataBox.Models.GranularCopyLogDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyLogDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyLogDetails>
    {
        internal DataBoxDiskGranularCopyLogDetails() { }
        public Azure.Core.ResourceIdentifier AccountId { get { throw null; } }
        public string ErrorLogLink { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public string VerboseLogLink { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyLogDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyLogDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyLogDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyLogDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyLogDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyLogDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyLogDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxDiskGranularCopyProgress : Azure.ResourceManager.DataBox.Models.GranularCopyProgress, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyProgress>
    {
        internal DataBoxDiskGranularCopyProgress() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus? CopyStatus { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyProgress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyProgress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxDiskJobDetails : Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskJobDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskJobDetails>
    {
        public DataBoxDiskJobDetails(Azure.ResourceManager.DataBox.Models.DataBoxContactDetails contactDetails) : base (default(Azure.ResourceManager.DataBox.Models.DataBoxContactDetails)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyProgress> CopyProgress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> DisksAndSizeDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyLogDetails> GranularCopyLogDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyProgress> GranularCopyProgress { get { throw null; } }
        public string Passkey { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, int> PreferredDisks { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxDiskJobDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskJobDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskJobDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxDiskJobDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskJobDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskJobDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskJobDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxDiskJobSecrets : Azure.ResourceManager.DataBox.Models.JobSecrets, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskJobSecrets>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskJobSecrets>
    {
        internal DataBoxDiskJobSecrets() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxDiskSecret> DiskSecrets { get { throw null; } }
        public bool? IsPasskeyUserDefined { get { throw null; } }
        public string Passkey { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxDiskJobSecrets System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskJobSecrets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskJobSecrets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxDiskJobSecrets System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskJobSecrets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskJobSecrets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskJobSecrets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxDiskSecret : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskSecret>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskSecret>
    {
        internal DataBoxDiskSecret() { }
        public string BitLockerKey { get { throw null; } }
        public string DiskSerialNumber { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxDiskSecret System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskSecret>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskSecret>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxDiskSecret System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskSecret>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskSecret>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxDiskSecret>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DataBoxDoubleEncryption
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DataBoxEncryptionPreferences : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxEncryptionPreferences>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxEncryptionPreferences>
    {
        public DataBoxEncryptionPreferences() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxDoubleEncryption? DoubleEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.HardwareEncryption? HardwareEncryption { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxEncryptionPreferences System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxEncryptionPreferences>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxEncryptionPreferences>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxEncryptionPreferences System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxEncryptionPreferences>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxEncryptionPreferences>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxEncryptionPreferences>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxHeavyAccountCopyLogDetails : Azure.ResourceManager.DataBox.Models.CopyLogDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyAccountCopyLogDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyAccountCopyLogDetails>
    {
        internal DataBoxHeavyAccountCopyLogDetails() { }
        public string AccountName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> CopyLogLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> CopyVerboseLogLink { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxHeavyAccountCopyLogDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyAccountCopyLogDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyAccountCopyLogDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxHeavyAccountCopyLogDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyAccountCopyLogDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyAccountCopyLogDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyAccountCopyLogDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxHeavyJobDetails : Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobDetails>
    {
        public DataBoxHeavyJobDetails(Azure.ResourceManager.DataBox.Models.DataBoxContactDetails contactDetails) : base (default(Azure.ResourceManager.DataBox.Models.DataBoxContactDetails)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress> CopyProgress { get { throw null; } }
        public string DevicePassword { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxHeavyJobSecrets : Azure.ResourceManager.DataBox.Models.JobSecrets, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobSecrets>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobSecrets>
    {
        internal DataBoxHeavyJobSecrets() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxHeavySecret> CabinetPodSecrets { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobSecrets System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobSecrets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobSecrets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobSecrets System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobSecrets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobSecrets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavyJobSecrets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxHeavySecret : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavySecret>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavySecret>
    {
        internal DataBoxHeavySecret() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxAccountCredentialDetails> AccountCredentialDetails { get { throw null; } }
        public string DevicePassword { get { throw null; } }
        public string DeviceSerialNumber { get { throw null; } }
        public string EncodedValidationCertPubKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration> NetworkConfigurations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxHeavySecret System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavySecret>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavySecret>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxHeavySecret System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavySecret>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavySecret>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxHeavySecret>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxJobCancellationReason : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxJobCancellationReason>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobCancellationReason>
    {
        public DataBoxJobCancellationReason(string reason) { }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxJobCancellationReason System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxJobCancellationReason>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxJobCancellationReason>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxJobCancellationReason System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobCancellationReason>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobCancellationReason>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobCancellationReason>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxJobDetails : Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxJobDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobDetails>
    {
        public DataBoxJobDetails(Azure.ResourceManager.DataBox.Models.DataBoxContactDetails contactDetails) : base (default(Azure.ResourceManager.DataBox.Models.DataBoxContactDetails)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress> CopyProgress { get { throw null; } }
        public string DevicePassword { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxJobDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxJobDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxJobDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxJobDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxJobPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxJobPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobPatch>
    {
        public DataBoxJobPatch() { }
        public Azure.ResourceManager.DataBox.Models.UpdateJobDetails Details { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxJobPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxJobPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxJobPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxJobPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxJobSecrets : Azure.ResourceManager.DataBox.Models.JobSecrets, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxJobSecrets>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobSecrets>
    {
        internal DataBoxJobSecrets() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxSecret> PodSecrets { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxJobSecrets System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxJobSecrets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxJobSecrets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxJobSecrets System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobSecrets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobSecrets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobSecrets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is obsolete and will be removed in a future release.Please use DataBoxJobSecrets instead.", false)]
    public partial class DataboxJobSecrets : Azure.ResourceManager.DataBox.Models.JobSecrets, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataboxJobSecrets>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataboxJobSecrets>
    {
        internal DataboxJobSecrets() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxSecret> PodSecrets { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataboxJobSecrets System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataboxJobSecrets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataboxJobSecrets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataboxJobSecrets System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataboxJobSecrets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataboxJobSecrets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataboxJobSecrets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxJobStage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxJobStage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobStage>
    {
        internal DataBoxJobStage() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.JobDelayDetails> DelayInformation { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.BinaryData JobStageDetails { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxStageName? StageName { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxStageStatus? StageStatus { get { throw null; } }
        public System.DateTimeOffset? StageTime { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxJobStage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxJobStage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxJobStage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxJobStage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobStage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobStage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxJobStage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DataBoxJobTransferType
    {
        ImportToAzure = 0,
        ExportFromAzure = 1,
    }
    public partial class DataBoxKeyEncryptionKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey>
    {
        public DataBoxKeyEncryptionKey(Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKeyType kekType) { }
        public Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKeyType KekType { get { throw null; } set { } }
        public System.Uri KekUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KekVaultResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxManagedIdentity ManagedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DataBoxKeyEncryptionKeyType
    {
        MicrosoftManaged = 0,
        CustomerManaged = 1,
    }
    public partial class DataBoxManagedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxManagedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxManagedIdentity>
    {
        public DataBoxManagedIdentity() { }
        public string IdentityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxManagedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxManagedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxManagedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxManagedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxManagedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxManagedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxManagedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxOrderPreferences : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences>
    {
        public DataBoxOrderPreferences() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.DataBox.Models.DataBoxDoubleEncryption? DoubleEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxEncryptionPreferences EncryptionPreferences { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PreferredDataCenterRegion { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.TransportPreferences ReverseTransportPreferences { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> StorageAccountAccessTierPreferences { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.TransportPreferences TransportPreferences { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.DataBox.Models.TransportShipmentType? TransportPreferencesPreferredShipmentType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxScheduleAvailabilityContent : Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxScheduleAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxScheduleAvailabilityContent>
    {
        public DataBoxScheduleAvailabilityContent(Azure.Core.AzureLocation storageLocation) : base (default(Azure.Core.AzureLocation)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxScheduleAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxScheduleAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxScheduleAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxScheduleAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxScheduleAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxScheduleAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxScheduleAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxSecret : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxSecret>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSecret>
    {
        internal DataBoxSecret() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxAccountCredentialDetails> AccountCredentialDetails { get { throw null; } }
        public string DevicePassword { get { throw null; } }
        public string DeviceSerialNumber { get { throw null; } }
        public string EncodedValidationCertPubKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration> NetworkConfigurations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxSecret System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxSecret>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxSecret>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxSecret System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSecret>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSecret>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSecret>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxShipmentPickUpResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxShipmentPickUpResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxShipmentPickUpResult>
    {
        internal DataBoxShipmentPickUpResult() { }
        public string ConfirmationNumber { get { throw null; } }
        public System.DateTimeOffset? ReadyBy { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxShipmentPickUpResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxShipmentPickUpResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxShipmentPickUpResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxShipmentPickUpResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxShipmentPickUpResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxShipmentPickUpResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxShipmentPickUpResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxShippingAddress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress>
    {
        public DataBoxShippingAddress(string streetAddress1, string country) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public DataBoxShippingAddress(string streetAddress1, string country, string postalCode) { }
        public Azure.ResourceManager.DataBox.Models.DataBoxShippingAddressType? AddressType { get { throw null; } set { } }
        public string City { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public bool? SkipAddressValidation { get { throw null; } set { } }
        public string StateOrProvince { get { throw null; } set { } }
        public string StreetAddress1 { get { throw null; } set { } }
        public string StreetAddress2 { get { throw null; } set { } }
        public string StreetAddress3 { get { throw null; } set { } }
        public string TaxIdentificationNumber { get { throw null; } set { } }
        public string ZipExtendedCode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DataBoxShippingAddressType
    {
        None = 0,
        Residential = 1,
        Commercial = 2,
    }
    public partial class DataBoxSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSku>
    {
        public DataBoxSku(Azure.ResourceManager.DataBox.Models.DataBoxSkuName name) { }
        public string DisplayName { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DeviceModelName? Model { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxSkuCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuCapacity>
    {
        internal DataBoxSkuCapacity() { }
        public string IndividualSkuUsable { get { throw null; } }
        public string Maximum { get { throw null; } }
        public string Usable { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxSkuCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxSkuCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxSkuCost : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuCost>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuCost>
    {
        internal DataBoxSkuCost() { }
        public System.Guid? MeterId { get { throw null; } }
        public string MeterType { get { throw null; } }
        public double? Multiplier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxSkuCost System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuCost>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuCost>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxSkuCost System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuCost>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuCost>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuCost>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxSkuInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuInformation>
    {
        internal DataBoxSkuInformation() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuCapacity Capacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxSkuCost> Costs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> CountriesWithinCommerceBoundary { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataLocationToServiceLocationMap> DataLocationToServiceLocationMap { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.SkuDisabledReason? DisabledReason { get { throw null; } }
        public string DisabledReasonMessage { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public string RequiredFeature { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSku Sku { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxSkuInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxSkuInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxSkuInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DataBoxSkuName
    {
        DataBox = 0,
        DataBoxDisk = 1,
        DataBoxHeavy = 2,
        DataBoxCustomerDisk = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxStageName : System.IEquatable<Azure.ResourceManager.DataBox.Models.DataBoxStageName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxStageName(string value) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName Aborted { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName AtAzureDataCenter { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName AwaitingShipmentDetails { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName Cancelled { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName Completed { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName CompletedWithErrors { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName CompletedWithWarnings { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName Created { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName DataCopy { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName Delivered { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName DeviceOrdered { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName DevicePrepared { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName Dispatched { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName FailedIssueDetectedAtAzureDataCenter { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName FailedIssueReportedAtCustomer { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName PickedUp { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName PreparingToShipFromAzureDataCenter { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName ReadyToDispatchFromAzureDataCenter { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName ReadyToReceiveAtAzureDataCenter { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName ShippedToAzureDataCenter { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataBoxStageName ShippedToCustomer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBox.Models.DataBoxStageName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBox.Models.DataBoxStageName left, Azure.ResourceManager.DataBox.Models.DataBoxStageName right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBox.Models.DataBoxStageName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBox.Models.DataBoxStageName left, Azure.ResourceManager.DataBox.Models.DataBoxStageName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum DataBoxStageStatus
    {
        None = 0,
        InProgress = 1,
        Succeeded = 2,
        Failed = 3,
        Cancelled = 4,
        Cancelling = 5,
        SucceededWithErrors = 6,
        WaitingForCustomerAction = 7,
        SucceededWithWarnings = 8,
        WaitingForCustomerActionForKek = 9,
        WaitingForCustomerActionForCleanUp = 10,
        CustomerActionPerformedForCleanUp = 11,
        CustomerActionPerformed = 12,
    }
    public partial class DataBoxStorageAccountDetails : Azure.ResourceManager.DataBox.Models.DataAccountDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxStorageAccountDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxStorageAccountDetails>
    {
        public DataBoxStorageAccountDetails(Azure.Core.ResourceIdentifier storageAccountId) { }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxStorageAccountDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxStorageAccountDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxStorageAccountDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxStorageAccountDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxStorageAccountDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxStorageAccountDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxStorageAccountDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxValidateAddressContent : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxValidateAddressContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidateAddressContent>
    {
        public DataBoxValidateAddressContent(Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress shippingAddress, Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType) { }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName DeviceType { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DeviceModelName? Model { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress ShippingAddress { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.TransportPreferences TransportPreferences { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.DataBox.Models.TransportShipmentType? TransportPreferencesPreferredShipmentType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxValidateAddressContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxValidateAddressContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxValidateAddressContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxValidateAddressContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidateAddressContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidateAddressContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidateAddressContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataBoxValidationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationContent>
    {
        protected DataBoxValidationContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent> individualRequestDetails) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent> IndividualRequestDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxValidationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxValidationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataBoxValidationInputContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent>
    {
        protected DataBoxValidationInputContent() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataBoxValidationInputResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult>
    {
        protected DataBoxValidationInputResult() { }
        public Azure.ResponseError Error { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoxValidationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationResult>
    {
        internal DataBoxValidationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult> IndividualResponseDetails { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.OverallValidationStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataBoxValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataBoxValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DataBoxValidationStatus
    {
        Valid = 0,
        Invalid = 1,
        Skipped = 2,
    }
    public partial class DataCenterAccessSecurityCode : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode>
    {
        internal DataCenterAccessSecurityCode() { }
        public string ForwardDataCenterAccessCode { get { throw null; } }
        public string ReverseDataCenterAccessCode { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataCenterAddressContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressContent>
    {
        public DataCenterAddressContent(Azure.Core.AzureLocation storageLocation, Azure.ResourceManager.DataBox.Models.DataBoxSkuName skuName) { }
        public Azure.ResourceManager.DataBox.Models.DeviceModelName? Model { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName SkuName { get { throw null; } }
        public Azure.Core.AzureLocation StorageLocation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataCenterAddressContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataCenterAddressContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataCenterAddressInstructionResult : Azure.ResourceManager.DataBox.Models.DataCenterAddressResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressInstructionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressInstructionResult>
    {
        internal DataCenterAddressInstructionResult() { }
        public string CommunicationInstruction { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataCenterAddressInstructionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressInstructionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressInstructionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataCenterAddressInstructionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressInstructionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressInstructionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressInstructionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataCenterAddressLocationResult : Azure.ResourceManager.DataBox.Models.DataCenterAddressResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressLocationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressLocationResult>
    {
        internal DataCenterAddressLocationResult() { }
        public string AdditionalShippingInformation { get { throw null; } }
        public string AddressType { get { throw null; } }
        public string City { get { throw null; } }
        public string Company { get { throw null; } }
        public string ContactPersonName { get { throw null; } }
        public string Country { get { throw null; } }
        public string Phone { get { throw null; } }
        public string PhoneExtension { get { throw null; } }
        public string State { get { throw null; } }
        public string Street1 { get { throw null; } }
        public string Street2 { get { throw null; } }
        public string Street3 { get { throw null; } }
        public string Zip { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataCenterAddressLocationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressLocationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressLocationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataCenterAddressLocationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressLocationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressLocationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressLocationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataCenterAddressResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressResult>
    {
        protected DataCenterAddressResult() { }
        public Azure.Core.AzureLocation? DataCenterAzureLocation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedCarriersForReturnShipment { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataCenterAddressResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataCenterAddressResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataCenterAddressResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataCenterCode : System.IEquatable<Azure.ResourceManager.DataBox.Models.DataCenterCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataCenterCode(string value) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode AdHoc { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode AM2 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode AMS06 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode AMS20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode AMS25 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode AUH20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode BJB { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode BJS20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode BL20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode BL24 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode BL7 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode BN1 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode BN7 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode BOM01 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode BY1 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode BY2 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode BY21 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode BY24 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode CBR20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode CH1 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode CPQ02 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode CPQ20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode CPQ21 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode CWL20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode CYS04 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode DSM05 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode DSM11 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode DUB07 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode DXB23 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode FRA22 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode HKG20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode IdC5 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode JNB21 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode JNB22 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode LON24 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode MAA01 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode MEL23 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode MNZ21 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode MWH01 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode NTG20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode ORK70 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode OSA02 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode OSA20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode OSA22 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode OSA23 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode PAR22 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode PNQ01 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode PUS20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode SEL20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode SEL21 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode SG2 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode SHA03 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode SIN20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode SN5 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode SN6 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode SN8 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode SSE90 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode SVG20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode SYD03 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode SYD23 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode TYO01 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode TYO22 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode TYO23 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode YQB20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode YTO20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode YTO21 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode ZRH20 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBox.Models.DataCenterCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBox.Models.DataCenterCode left, Azure.ResourceManager.DataBox.Models.DataCenterCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBox.Models.DataCenterCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBox.Models.DataCenterCode left, Azure.ResourceManager.DataBox.Models.DataCenterCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataExportDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataExportDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataExportDetails>
    {
        public DataExportDetails(Azure.ResourceManager.DataBox.Models.TransferConfiguration transferConfiguration, Azure.ResourceManager.DataBox.Models.DataAccountDetails accountDetails) { }
        public Azure.ResourceManager.DataBox.Models.DataAccountDetails AccountDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.LogCollectionLevel? LogCollectionLevel { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.TransferConfiguration TransferConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataExportDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataExportDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataExportDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataExportDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataExportDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataExportDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataExportDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataImportDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataImportDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataImportDetails>
    {
        public DataImportDetails(Azure.ResourceManager.DataBox.Models.DataAccountDetails accountDetails) { }
        public Azure.ResourceManager.DataBox.Models.DataAccountDetails AccountDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.LogCollectionLevel? LogCollectionLevel { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataImportDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataImportDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataImportDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataImportDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataImportDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataImportDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataImportDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataLocationToServiceLocationMap : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataLocationToServiceLocationMap>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataLocationToServiceLocationMap>
    {
        internal DataLocationToServiceLocationMap() { }
        public Azure.Core.AzureLocation? DataLocation { get { throw null; } }
        public Azure.Core.AzureLocation? ServiceLocation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataLocationToServiceLocationMap System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataLocationToServiceLocationMap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataLocationToServiceLocationMap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataLocationToServiceLocationMap System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataLocationToServiceLocationMap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataLocationToServiceLocationMap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataLocationToServiceLocationMap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataTransferDetailsValidationContent : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationContent>
    {
        public DataTransferDetailsValidationContent(Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType, Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType transferType) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.DataExportDetails> DataExportDetails { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.DataImportDetails> DataImportDetails { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName DeviceType { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DeviceModelName? Model { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType TransferType { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataTransferDetailsValidationResult : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationResult>
    {
        internal DataTransferDetailsValidationResult() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DelayNotificationStatus : System.IEquatable<Azure.ResourceManager.DataBox.Models.DelayNotificationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DelayNotificationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DelayNotificationStatus Active { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DelayNotificationStatus Resolved { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBox.Models.DelayNotificationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBox.Models.DelayNotificationStatus left, Azure.ResourceManager.DataBox.Models.DelayNotificationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBox.Models.DelayNotificationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBox.Models.DelayNotificationStatus left, Azure.ResourceManager.DataBox.Models.DelayNotificationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceCapabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DeviceCapabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DeviceCapabilityContent>
    {
        public DeviceCapabilityContent() { }
        public Azure.ResourceManager.DataBox.Models.DeviceModelName? Model { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName? SkuName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DeviceCapabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DeviceCapabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DeviceCapabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DeviceCapabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DeviceCapabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DeviceCapabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DeviceCapabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceCapabilityDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DeviceCapabilityDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DeviceCapabilityDetails>
    {
        internal DeviceCapabilityDetails() { }
        public Azure.ResourceManager.DataBox.Models.HardwareEncryption? HardwareEncryption { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DeviceCapabilityDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DeviceCapabilityDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DeviceCapabilityDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DeviceCapabilityDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DeviceCapabilityDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DeviceCapabilityDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DeviceCapabilityDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceErasureDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DeviceErasureDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DeviceErasureDetails>
    {
        internal DeviceErasureDetails() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxStageStatus? DeviceErasureStatus { get { throw null; } }
        public string ErasureOrDestructionCertificateSasKey { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DeviceErasureDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DeviceErasureDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DeviceErasureDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DeviceErasureDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DeviceErasureDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DeviceErasureDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DeviceErasureDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DeviceModelName
    {
        DataBox = 0,
        DataBoxDisk = 1,
        DataBoxHeavy = 2,
        DataBoxCustomerDisk = 3,
        AzureDataBox120 = 4,
        AzureDataBox525 = 5,
    }
    public partial class DiskScheduleAvailabilityContent : Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DiskScheduleAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DiskScheduleAvailabilityContent>
    {
        public DiskScheduleAvailabilityContent(Azure.Core.AzureLocation storageLocation, int expectedDataSizeInTerabytes) : base (default(Azure.Core.AzureLocation)) { }
        public int ExpectedDataSizeInTerabytes { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DiskScheduleAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DiskScheduleAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.DiskScheduleAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.DiskScheduleAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DiskScheduleAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DiskScheduleAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.DiskScheduleAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportDiskDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ExportDiskDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ExportDiskDetails>
    {
        internal ExportDiskDetails() { }
        public string BackupManifestCloudPath { get { throw null; } }
        public string ManifestFile { get { throw null; } }
        public string ManifestHash { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ExportDiskDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ExportDiskDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ExportDiskDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ExportDiskDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ExportDiskDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ExportDiskDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ExportDiskDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FilterFileDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.FilterFileDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.FilterFileDetails>
    {
        public FilterFileDetails(Azure.ResourceManager.DataBox.Models.FilterFileType filterFileType, string filterFilePath) { }
        public string FilterFilePath { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.FilterFileType FilterFileType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.FilterFileDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.FilterFileDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.FilterFileDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.FilterFileDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.FilterFileDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.FilterFileDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.FilterFileDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum FilterFileType
    {
        AzureBlob = 0,
        AzureFile = 1,
    }
    public abstract partial class GranularCopyLogDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.GranularCopyLogDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.GranularCopyLogDetails>
    {
        protected GranularCopyLogDetails() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.GranularCopyLogDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.GranularCopyLogDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.GranularCopyLogDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.GranularCopyLogDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.GranularCopyLogDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.GranularCopyLogDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.GranularCopyLogDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GranularCopyProgress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.GranularCopyProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.GranularCopyProgress>
    {
        internal GranularCopyProgress() { }
        public Azure.Core.ResourceIdentifier AccountId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> Actions { get { throw null; } }
        public long? BytesProcessed { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataAccountType? DataAccountType { get { throw null; } }
        public long? DirectoriesErroredOut { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public long? FilesErroredOut { get { throw null; } }
        public long? FilesProcessed { get { throw null; } }
        public long? InvalidDirectoriesProcessed { get { throw null; } }
        public long? InvalidFileBytesUploaded { get { throw null; } }
        public long? InvalidFilesProcessed { get { throw null; } }
        public bool? IsEnumerationInProgress { get { throw null; } }
        public long? RenamedContainerCount { get { throw null; } }
        public string StorageAccountName { get { throw null; } }
        public long? TotalBytesToProcess { get { throw null; } }
        public long? TotalFilesToProcess { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType? TransferType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.GranularCopyProgress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.GranularCopyProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.GranularCopyProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.GranularCopyProgress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.GranularCopyProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.GranularCopyProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.GranularCopyProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum HardwareEncryption
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class HeavyScheduleAvailabilityContent : Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.HeavyScheduleAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.HeavyScheduleAvailabilityContent>
    {
        public HeavyScheduleAvailabilityContent(Azure.Core.AzureLocation storageLocation) : base (default(Azure.Core.AzureLocation)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.HeavyScheduleAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.HeavyScheduleAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.HeavyScheduleAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.HeavyScheduleAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.HeavyScheduleAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.HeavyScheduleAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.HeavyScheduleAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportDiskDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ImportDiskDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ImportDiskDetails>
    {
        public ImportDiskDetails(string manifestFile, string manifestHash, string bitLockerKey) { }
        public string BackupManifestCloudPath { get { throw null; } }
        public string BitLockerKey { get { throw null; } set { } }
        public string ManifestFile { get { throw null; } set { } }
        public string ManifestHash { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ImportDiskDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ImportDiskDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ImportDiskDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ImportDiskDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ImportDiskDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ImportDiskDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ImportDiskDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JobDelayDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.JobDelayDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.JobDelayDetails>
    {
        internal JobDelayDetails() { }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.PortalDelayErrorCode? ErrorCode { get { throw null; } }
        public System.DateTimeOffset? ResolutionOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DelayNotificationStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.JobDelayDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.JobDelayDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.JobDelayDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.JobDelayDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.JobDelayDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.JobDelayDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.JobDelayDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum JobDeliveryType
    {
        NonScheduled = 0,
        Scheduled = 1,
    }
    public abstract partial class JobSecrets : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.JobSecrets>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.JobSecrets>
    {
        protected JobSecrets() { }
        public Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode DataCenterAccessSecurityCode { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.JobSecrets System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.JobSecrets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.JobSecrets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.JobSecrets System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.JobSecrets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.JobSecrets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.JobSecrets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LastMitigationActionOnJob : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob>
    {
        internal LastMitigationActionOnJob() { }
        public System.DateTimeOffset? ActionPerformedOn { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.CustomerResolutionCode? CustomerResolution { get { throw null; } }
        public bool? IsPerformedByCustomer { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum LogCollectionLevel
    {
        Error = 0,
        Verbose = 1,
    }
    public partial class ManagedDiskDetails : Azure.ResourceManager.DataBox.Models.DataAccountDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ManagedDiskDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ManagedDiskDetails>
    {
        public ManagedDiskDetails(Azure.Core.ResourceIdentifier resourceGroupId, Azure.Core.ResourceIdentifier stagingStorageAccountId) { }
        public Azure.Core.ResourceIdentifier ResourceGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StagingStorageAccountId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ManagedDiskDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ManagedDiskDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ManagedDiskDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ManagedDiskDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ManagedDiskDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ManagedDiskDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ManagedDiskDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarkDevicesShippedContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.MarkDevicesShippedContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.MarkDevicesShippedContent>
    {
        public MarkDevicesShippedContent(Azure.ResourceManager.DataBox.Models.PackageCarrierInfo deliverToDataCenterPackageDetails) { }
        public Azure.ResourceManager.DataBox.Models.PackageCarrierInfo DeliverToDataCenterPackageDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.MarkDevicesShippedContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.MarkDevicesShippedContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.MarkDevicesShippedContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.MarkDevicesShippedContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.MarkDevicesShippedContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.MarkDevicesShippedContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.MarkDevicesShippedContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MitigateJobContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.MitigateJobContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.MitigateJobContent>
    {
        public MitigateJobContent() { }
        public MitigateJobContent(Azure.ResourceManager.DataBox.Models.CustomerResolutionCode customerResolutionCode) { }
        public Azure.ResourceManager.DataBox.Models.CustomerResolutionCode CustomerResolutionCode { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> SerialNumberCustomerResolutionMap { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.MitigateJobContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.MitigateJobContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.MitigateJobContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.MitigateJobContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.MitigateJobContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.MitigateJobContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.MitigateJobContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationPreference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.NotificationPreference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.NotificationPreference>
    {
        public NotificationPreference(Azure.ResourceManager.DataBox.Models.NotificationStageName stageName, bool sendNotification) { }
        public bool SendNotification { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.NotificationStageName StageName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.NotificationPreference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.NotificationPreference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.NotificationPreference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.NotificationPreference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.NotificationPreference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.NotificationPreference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.NotificationPreference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationStageName : System.IEquatable<Azure.ResourceManager.DataBox.Models.NotificationStageName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationStageName(string value) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.NotificationStageName AtAzureDataCenter { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.NotificationStageName Created { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.NotificationStageName DataCopy { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.NotificationStageName Delivered { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.NotificationStageName DevicePrepared { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.NotificationStageName Dispatched { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.NotificationStageName PickedUp { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.NotificationStageName ShippedToCustomer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBox.Models.NotificationStageName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBox.Models.NotificationStageName left, Azure.ResourceManager.DataBox.Models.NotificationStageName right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBox.Models.NotificationStageName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBox.Models.NotificationStageName left, Azure.ResourceManager.DataBox.Models.NotificationStageName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum OverallValidationStatus
    {
        AllValidToProceed = 0,
        InputsRevisitRequired = 1,
        CertainInputValidationsSkipped = 2,
    }
    public partial class PackageCarrierDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.PackageCarrierDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PackageCarrierDetails>
    {
        public PackageCarrierDetails() { }
        public string CarrierAccountNumber { get { throw null; } set { } }
        public string CarrierName { get { throw null; } set { } }
        public string TrackingId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.PackageCarrierDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.PackageCarrierDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.PackageCarrierDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.PackageCarrierDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PackageCarrierDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PackageCarrierDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PackageCarrierDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PackageCarrierInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.PackageCarrierInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PackageCarrierInfo>
    {
        public PackageCarrierInfo() { }
        public string CarrierName { get { throw null; } set { } }
        public string TrackingId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.PackageCarrierInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.PackageCarrierInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.PackageCarrierInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.PackageCarrierInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PackageCarrierInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PackageCarrierInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PackageCarrierInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PackageShippingDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.PackageShippingDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PackageShippingDetails>
    {
        internal PackageShippingDetails() { }
        public string CarrierName { get { throw null; } }
        public string TrackingId { get { throw null; } }
        public System.Uri TrackingUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.PackageShippingDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.PackageShippingDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.PackageShippingDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.PackageShippingDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PackageShippingDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PackageShippingDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PackageShippingDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortalDelayErrorCode : System.IEquatable<Azure.ResourceManager.DataBox.Models.PortalDelayErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortalDelayErrorCode(string value) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.PortalDelayErrorCode ActiveOrderLimitBreachedDelay { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.PortalDelayErrorCode HighDemandDelay { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.PortalDelayErrorCode InternalIssueDelay { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.PortalDelayErrorCode LargeNumberOfFilesDelay { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBox.Models.PortalDelayErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBox.Models.PortalDelayErrorCode left, Azure.ResourceManager.DataBox.Models.PortalDelayErrorCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBox.Models.PortalDelayErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBox.Models.PortalDelayErrorCode left, Azure.ResourceManager.DataBox.Models.PortalDelayErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PreferencesValidationContent : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.PreferencesValidationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PreferencesValidationContent>
    {
        public PreferencesValidationContent(Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType) { }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName DeviceType { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DeviceModelName? Model { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences Preference { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.PreferencesValidationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.PreferencesValidationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.PreferencesValidationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.PreferencesValidationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PreferencesValidationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PreferencesValidationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PreferencesValidationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PreferencesValidationResult : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.PreferencesValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PreferencesValidationResult>
    {
        internal PreferencesValidationResult() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.PreferencesValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.PreferencesValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.PreferencesValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.PreferencesValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PreferencesValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PreferencesValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.PreferencesValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegionConfigurationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.RegionConfigurationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.RegionConfigurationContent>
    {
        public RegionConfigurationContent() { }
        public Azure.ResourceManager.DataBox.Models.DataCenterAddressContent DataCenterAddressRequest { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DeviceCapabilityContent DeviceCapabilityRequest { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent ScheduleAvailabilityRequest { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.TransportAvailabilityContent TransportAvailabilityRequest { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName? TransportAvailabilityRequestSkuName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.RegionConfigurationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.RegionConfigurationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.RegionConfigurationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.RegionConfigurationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.RegionConfigurationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.RegionConfigurationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.RegionConfigurationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegionConfigurationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.RegionConfigurationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.RegionConfigurationResult>
    {
        internal RegionConfigurationResult() { }
        public Azure.ResourceManager.DataBox.Models.DataCenterAddressResult DataCenterAddressResponse { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DeviceCapabilityDetails> DeviceCapabilityDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.DateTimeOffset> ScheduleAvailabilityResponseAvailableDates { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.TransportAvailabilityDetails> TransportAvailabilityDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.RegionConfigurationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.RegionConfigurationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.RegionConfigurationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.RegionConfigurationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.RegionConfigurationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.RegionConfigurationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.RegionConfigurationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReverseShippingDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ReverseShippingDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ReverseShippingDetails>
    {
        public ReverseShippingDetails() { }
        public Azure.ResourceManager.DataBox.Models.ContactInfo ContactDetails { get { throw null; } set { } }
        public bool? IsUpdated { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress ShippingAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ReverseShippingDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ReverseShippingDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ReverseShippingDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ReverseShippingDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ReverseShippingDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ReverseShippingDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ReverseShippingDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ReverseShippingDetailsEditStatus
    {
        Enabled = 0,
        Disabled = 1,
        NotSupported = 2,
    }
    public enum ReverseTransportPreferenceEditStatus
    {
        Enabled = 0,
        Disabled = 1,
        NotSupported = 2,
    }
    public abstract partial class ScheduleAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent>
    {
        protected ScheduleAvailabilityContent(Azure.Core.AzureLocation storageLocation) { }
        public string Country { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DeviceModelName? Model { get { throw null; } set { } }
        public Azure.Core.AzureLocation StorageLocation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShareCredentialDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ShareCredentialDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ShareCredentialDetails>
    {
        internal ShareCredentialDetails() { }
        public string Password { get { throw null; } }
        public string ShareName { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.ShareDestinationFormatType? ShareType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxAccessProtocol> SupportedAccessProtocols { get { throw null; } }
        public string UserName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ShareCredentialDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ShareCredentialDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ShareCredentialDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ShareCredentialDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ShareCredentialDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ShareCredentialDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ShareCredentialDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ShareDestinationFormatType
    {
        UnknownType = 0,
        Hcs = 1,
        BlockBlob = 2,
        PageBlob = 3,
        AzureFile = 4,
        ManagedDisk = 5,
    }
    public partial class ShipmentPickUpContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ShipmentPickUpContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ShipmentPickUpContent>
    {
        public ShipmentPickUpContent(System.DateTimeOffset startOn, System.DateTimeOffset endOn, string shipmentLocation) { }
        public System.DateTimeOffset EndOn { get { throw null; } }
        public string ShipmentLocation { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ShipmentPickUpContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ShipmentPickUpContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.ShipmentPickUpContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.ShipmentPickUpContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ShipmentPickUpContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ShipmentPickUpContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.ShipmentPickUpContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuAvailabilityValidationContent : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationContent>
    {
        public SkuAvailabilityValidationContent(Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType, Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType transferType, string country, Azure.Core.AzureLocation location) { }
        public string Country { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName DeviceType { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DeviceModelName? Model { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType TransferType { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuAvailabilityValidationResult : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationResult>
    {
        internal SkuAvailabilityValidationResult() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SkuDisabledReason
    {
        None = 0,
        Country = 1,
        Region = 2,
        Feature = 3,
        OfferType = 4,
        NoSubscriptionInfo = 5,
    }
    public partial class SubscriptionIsAllowedToCreateJobValidationContent : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationContent>
    {
        public SubscriptionIsAllowedToCreateJobValidationContent() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionIsAllowedToCreateJobValidationResult : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationResult>
    {
        internal SubscriptionIsAllowedToCreateJobValidationResult() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransferAllDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransferAllDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransferAllDetails>
    {
        public TransferAllDetails(Azure.ResourceManager.DataBox.Models.DataAccountType dataAccountType) { }
        public Azure.ResourceManager.DataBox.Models.DataAccountType DataAccountType { get { throw null; } set { } }
        public bool? TransferAllBlobs { get { throw null; } set { } }
        public bool? TransferAllFiles { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.TransferAllDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransferAllDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransferAllDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.TransferAllDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransferAllDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransferAllDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransferAllDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransferConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransferConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransferConfiguration>
    {
        public TransferConfiguration(Azure.ResourceManager.DataBox.Models.TransferConfigurationType transferConfigurationType) { }
        public Azure.ResourceManager.DataBox.Models.TransferAllDetails TransferAllDetailsInclude { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.TransferConfigurationType TransferConfigurationType { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.TransferFilterDetails TransferFilterDetailsInclude { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.TransferConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransferConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransferConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.TransferConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransferConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransferConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransferConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum TransferConfigurationType
    {
        TransferAll = 0,
        TransferUsingFilter = 1,
    }
    public partial class TransferFilterDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransferFilterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransferFilterDetails>
    {
        public TransferFilterDetails(Azure.ResourceManager.DataBox.Models.DataAccountType dataAccountType) { }
        public Azure.ResourceManager.DataBox.Models.AzureFileFilterDetails AzureFileFilterDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.BlobFilterDetails BlobFilterDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataAccountType DataAccountType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.FilterFileDetails> FilterFileDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.TransferFilterDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransferFilterDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransferFilterDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.TransferFilterDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransferFilterDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransferFilterDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransferFilterDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransportAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransportAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransportAvailabilityContent>
    {
        public TransportAvailabilityContent() { }
        public Azure.ResourceManager.DataBox.Models.DeviceModelName? Model { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName? SkuName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.TransportAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransportAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransportAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.TransportAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransportAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransportAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransportAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransportAvailabilityDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransportAvailabilityDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransportAvailabilityDetails>
    {
        internal TransportAvailabilityDetails() { }
        public Azure.ResourceManager.DataBox.Models.TransportShipmentType? ShipmentType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.TransportAvailabilityDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransportAvailabilityDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransportAvailabilityDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.TransportAvailabilityDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransportAvailabilityDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransportAvailabilityDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransportAvailabilityDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransportPreferences : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransportPreferences>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransportPreferences>
    {
        public TransportPreferences(Azure.ResourceManager.DataBox.Models.TransportShipmentType preferredShipmentType) { }
        public bool? IsUpdated { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.TransportShipmentType PreferredShipmentType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.TransportPreferences System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransportPreferences>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.TransportPreferences>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.TransportPreferences System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransportPreferences>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransportPreferences>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.TransportPreferences>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum TransportShipmentType
    {
        CustomerManaged = 0,
        MicrosoftManaged = 1,
    }
    public partial class UnencryptedCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.UnencryptedCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.UnencryptedCredentials>
    {
        internal UnencryptedCredentials() { }
        public string JobName { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.JobSecrets JobSecrets { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.UnencryptedCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.UnencryptedCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.UnencryptedCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.UnencryptedCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.UnencryptedCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.UnencryptedCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.UnencryptedCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateJobDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.UpdateJobDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.UpdateJobDetails>
    {
        public UpdateJobDetails() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxContactDetails ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey KeyEncryptionKey { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences Preferences { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.PackageCarrierDetails ReturnToCustomerPackageDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.ReverseShippingDetails ReverseShippingDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress ShippingAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.UpdateJobDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.UpdateJobDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataBox.Models.UpdateJobDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataBox.Models.UpdateJobDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.UpdateJobDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.UpdateJobDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataBox.Models.UpdateJobDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
