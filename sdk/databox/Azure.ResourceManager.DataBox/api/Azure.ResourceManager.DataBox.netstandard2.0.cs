namespace Azure.ResourceManager.DataBox
{
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
    public partial class DataBoxJobData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DataBoxJobData(Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType transferType, Azure.ResourceManager.DataBox.Models.DataBoxSku sku) { }
        public string CancellationReason { get { throw null; } }
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
    }
    public partial class DataBoxJobResource : Azure.ResourceManager.ArmResource
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
    public partial class AddressValidationOutput
    {
        internal AddressValidationOutput() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress> AlternateAddresses { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.AddressValidationStatus? ValidationStatus { get { throw null; } }
    }
    public partial class AddressValidationResult : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult
    {
        internal AddressValidationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress> AlternateAddresses { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.AddressValidationStatus? ValidationStatus { get { throw null; } }
    }
    public enum AddressValidationStatus
    {
        Valid = 0,
        Invalid = 1,
        Ambiguous = 2,
    }
    public partial class ApplianceNetworkConfiguration
    {
        internal ApplianceNetworkConfiguration() { }
        public string MacAddress { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public static partial class ArmDataBoxModelFactory
    {
        public static Azure.ResourceManager.DataBox.Models.AddressValidationResult AddressValidationResult(Azure.ResponseError error = null, Azure.ResourceManager.DataBox.Models.AddressValidationStatus? validationStatus = default(Azure.ResourceManager.DataBox.Models.AddressValidationStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress> alternateAddresses = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration ApplianceNetworkConfiguration(string name = null, string macAddress = null) { throw null; }
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
        public static Azure.ResourceManager.DataBox.DataBoxJobData DataBoxJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType transferType = Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType.ImportToAzure, bool? isCancellable = default(bool?), bool? isDeletable = default(bool?), bool? isShippingAddressEditable = default(bool?), Azure.ResourceManager.DataBox.Models.ReverseShippingDetailsEditStatus? reverseShippingDetailsUpdate = default(Azure.ResourceManager.DataBox.Models.ReverseShippingDetailsEditStatus?), Azure.ResourceManager.DataBox.Models.ReverseTransportPreferenceEditStatus? reverseTransportPreferenceUpdate = default(Azure.ResourceManager.DataBox.Models.ReverseTransportPreferenceEditStatus?), bool? isPrepareToShipEnabled = default(bool?), Azure.ResourceManager.DataBox.Models.DataBoxStageName? status = default(Azure.ResourceManager.DataBox.Models.DataBoxStageName?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), Azure.ResponseError error = null, Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails details = null, string cancellationReason = null, Azure.ResourceManager.DataBox.Models.JobDeliveryType? deliveryType = default(Azure.ResourceManager.DataBox.Models.JobDeliveryType?), System.DateTimeOffset? deliveryInfoScheduledOn = default(System.DateTimeOffset?), bool? isCancellableWithoutFee = default(bool?), Azure.ResourceManager.DataBox.Models.DataBoxSku sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxJobDetails DataBoxJobDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxJobStage> jobStages = null, Azure.ResourceManager.DataBox.Models.DataBoxContactDetails contactDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress shippingAddress = null, Azure.ResourceManager.DataBox.Models.PackageShippingDetails deliveryPackage = null, Azure.ResourceManager.DataBox.Models.PackageShippingDetails returnPackage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataImportDetails> dataImportDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataExportDetails> dataExportDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences preferences = null, Azure.ResourceManager.DataBox.Models.ReverseShippingDetails reverseShippingDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CopyLogDetails> copyLogDetails = null, string reverseShipmentLabelSasKey = null, string chainOfCustodySasKey = null, Azure.ResourceManager.DataBox.Models.DeviceErasureDetails deviceErasureDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey keyEncryptionKey = null, int? expectedDataSizeInTerabytes = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> actions = null, Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob lastMitigationActionOnJob = null, Azure.ResourceManager.DataBox.Models.DataCenterAddressResult dataCenterAddress = null, Azure.ResourceManager.DataBox.Models.DataCenterCode? dataCenterCode = default(Azure.ResourceManager.DataBox.Models.DataCenterCode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress> copyProgress = null, string devicePassword = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataboxJobSecrets DataboxJobSecrets(Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode dataCenterAccessSecurityCode = null, Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxSecret> podSecrets = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxJobStage DataBoxJobStage(Azure.ResourceManager.DataBox.Models.DataBoxStageName? stageName = default(Azure.ResourceManager.DataBox.Models.DataBoxStageName?), string displayName = null, Azure.ResourceManager.DataBox.Models.DataBoxStageStatus? stageStatus = default(Azure.ResourceManager.DataBox.Models.DataBoxStageStatus?), System.DateTimeOffset? stageTime = default(System.DateTimeOffset?), System.BinaryData jobStageDetails = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxSecret DataBoxSecret(string deviceSerialNumber = null, string devicePassword = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration> networkConfigurations = null, string encodedValidationCertPubKey = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxAccountCredentialDetails> accountCredentialDetails = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxShipmentPickUpResult DataBoxShipmentPickUpResult(string confirmationNumber = null, System.DateTimeOffset? readyBy = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxSkuCapacity DataBoxSkuCapacity(string usable = null, string maximum = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxSkuCost DataBoxSkuCost(System.Guid? meterId = default(System.Guid?), string meterType = null, double? multiplier = default(double?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxSkuInformation DataBoxSkuInformation(Azure.ResourceManager.DataBox.Models.DataBoxSku sku = null, bool? isEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataLocationToServiceLocationMap> dataLocationToServiceLocationMap = null, Azure.ResourceManager.DataBox.Models.DataBoxSkuCapacity capacity = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxSkuCost> costs = null, System.Collections.Generic.IEnumerable<string> apiVersions = null, Azure.ResourceManager.DataBox.Models.SkuDisabledReason? disabledReason = default(Azure.ResourceManager.DataBox.Models.SkuDisabledReason?), string disabledReasonMessage = null, string requiredFeature = null, System.Collections.Generic.IEnumerable<string> countriesWithinCommerceBoundary = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult DataBoxValidationInputResult(Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataBoxValidationResult DataBoxValidationResult(Azure.ResourceManager.DataBox.Models.OverallValidationStatus? status = default(Azure.ResourceManager.DataBox.Models.OverallValidationStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult> individualResponseDetails = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode DataCenterAccessSecurityCode(string reverseDataCenterAccessCode = null, string forwardDataCenterAccessCode = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataCenterAddressInstructionResult DataCenterAddressInstructionResult(System.Collections.Generic.IEnumerable<string> supportedCarriersForReturnShipment = null, Azure.Core.AzureLocation? dataCenterAzureLocation = default(Azure.Core.AzureLocation?), string communicationInstruction = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataCenterAddressLocationResult DataCenterAddressLocationResult(System.Collections.Generic.IEnumerable<string> supportedCarriersForReturnShipment = null, Azure.Core.AzureLocation? dataCenterAzureLocation = default(Azure.Core.AzureLocation?), string contactPersonName = null, string company = null, string street1 = null, string street2 = null, string street3 = null, string city = null, string state = null, string zip = null, string country = null, string phone = null, string phoneExtension = null, string addressType = null, string additionalShippingInformation = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataCenterAddressResult DataCenterAddressResult(System.Collections.Generic.IEnumerable<string> supportedCarriersForReturnShipment = null, Azure.Core.AzureLocation? dataCenterAzureLocation = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataLocationToServiceLocationMap DataLocationToServiceLocationMap(Azure.Core.AzureLocation? dataLocation = default(Azure.Core.AzureLocation?), Azure.Core.AzureLocation? serviceLocation = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DataTransferDetailsValidationResult DataTransferDetailsValidationResult(Azure.ResponseError error = null, Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? status = default(Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.DeviceErasureDetails DeviceErasureDetails(Azure.ResourceManager.DataBox.Models.DataBoxStageStatus? deviceErasureStatus = default(Azure.ResourceManager.DataBox.Models.DataBoxStageStatus?), string erasureOrDestructionCertificateSasKey = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.ExportDiskDetails ExportDiskDetails(string manifestFile = null, string manifestHash = null, string backupManifestCloudPath = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.GranularCopyProgress GranularCopyProgress(string storageAccountName = null, Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType? transferType = default(Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType?), Azure.ResourceManager.DataBox.Models.DataAccountType? dataAccountType = default(Azure.ResourceManager.DataBox.Models.DataAccountType?), Azure.Core.ResourceIdentifier accountId = null, long? bytesProcessed = default(long?), long? totalBytesToProcess = default(long?), long? filesProcessed = default(long?), long? totalFilesToProcess = default(long?), long? invalidFilesProcessed = default(long?), long? invalidFileBytesUploaded = default(long?), long? renamedContainerCount = default(long?), long? filesErroredOut = default(long?), long? directoriesErroredOut = default(long?), long? invalidDirectoriesProcessed = default(long?), bool? isEnumerationInProgress = default(bool?), Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> actions = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.ImportDiskDetails ImportDiskDetails(string manifestFile = null, string manifestHash = null, string bitLockerKey = null, string backupManifestCloudPath = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.JobSecrets JobSecrets(Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode dataCenterAccessSecurityCode = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob LastMitigationActionOnJob(System.DateTimeOffset? actionPerformedOn = default(System.DateTimeOffset?), bool? isPerformedByCustomer = default(bool?), Azure.ResourceManager.DataBox.Models.CustomerResolutionCode? customerResolution = default(Azure.ResourceManager.DataBox.Models.CustomerResolutionCode?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.PackageShippingDetails PackageShippingDetails(System.Uri trackingUri = null, string carrierName = null, string trackingId = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.PreferencesValidationResult PreferencesValidationResult(Azure.ResponseError error = null, Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? status = default(Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.RegionConfigurationResult RegionConfigurationResult(System.Collections.Generic.IEnumerable<System.DateTimeOffset> scheduleAvailabilityResponseAvailableDates = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.TransportAvailabilityDetails> transportAvailabilityDetails = null, Azure.ResourceManager.DataBox.Models.DataCenterAddressResult dataCenterAddressResponse = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.ReverseShippingDetails ReverseShippingDetails(Azure.ResourceManager.DataBox.Models.ContactInfo contactDetails = null, Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress shippingAddress = null, bool? isUpdated = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.ShareCredentialDetails ShareCredentialDetails(string shareName = null, Azure.ResourceManager.DataBox.Models.ShareDestinationFormatType? shareType = default(Azure.ResourceManager.DataBox.Models.ShareDestinationFormatType?), string userName = null, string password = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxAccessProtocol> supportedAccessProtocols = null) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.SkuAvailabilityValidationResult SkuAvailabilityValidationResult(Azure.ResponseError error = null, Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? status = default(Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.SubscriptionIsAllowedToCreateJobValidationResult SubscriptionIsAllowedToCreateJobValidationResult(Azure.ResponseError error = null, Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? status = default(Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.TransportAvailabilityDetails TransportAvailabilityDetails(Azure.ResourceManager.DataBox.Models.TransportShipmentType? shipmentType = default(Azure.ResourceManager.DataBox.Models.TransportShipmentType?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.TransportPreferences TransportPreferences(Azure.ResourceManager.DataBox.Models.TransportShipmentType preferredShipmentType = Azure.ResourceManager.DataBox.Models.TransportShipmentType.CustomerManaged, bool? isUpdated = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.UnencryptedCredentials UnencryptedCredentials(string jobName = null, Azure.ResourceManager.DataBox.Models.JobSecrets jobSecrets = null) { throw null; }
    }
    public partial class AvailableSkusContent
    {
        public AvailableSkusContent(Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType transferType, string country, Azure.Core.AzureLocation location) { }
        public string Country { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.DataBoxSkuName> SkuNames { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType TransferType { get { throw null; } }
    }
    public partial class AzureFileFilterDetails
    {
        public AzureFileFilterDetails() { }
        public System.Collections.Generic.IList<string> FilePathList { get { throw null; } }
        public System.Collections.Generic.IList<string> FilePrefixList { get { throw null; } }
        public System.Collections.Generic.IList<string> FileShareList { get { throw null; } }
    }
    public partial class BlobFilterDetails
    {
        public BlobFilterDetails() { }
        public System.Collections.Generic.IList<string> BlobPathList { get { throw null; } }
        public System.Collections.Generic.IList<string> BlobPrefixList { get { throw null; } }
        public System.Collections.Generic.IList<string> ContainerList { get { throw null; } }
    }
    public partial class ContactInfo
    {
        public ContactInfo(string contactName, string phone) { }
        public string ContactName { get { throw null; } set { } }
        public string Mobile { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
        public string PhoneExtension { get { throw null; } set { } }
    }
    public abstract partial class CopyLogDetails
    {
        protected CopyLogDetails() { }
    }
    public partial class CreateJobValidationContent : Azure.ResourceManager.DataBox.Models.DataBoxValidationContent
    {
        public CreateJobValidationContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent> individualRequestDetails) : base (default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent>)) { }
    }
    public partial class CreateOrderLimitForSubscriptionValidationContent : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent
    {
        public CreateOrderLimitForSubscriptionValidationContent(Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType) { }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName DeviceType { get { throw null; } }
    }
    public partial class CreateOrderLimitForSubscriptionValidationResult : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult
    {
        internal CreateOrderLimitForSubscriptionValidationResult() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? Status { get { throw null; } }
    }
    public partial class CustomerDiskJobSecrets : Azure.ResourceManager.DataBox.Models.JobSecrets
    {
        internal CustomerDiskJobSecrets() { }
        public string CarrierAccountNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxDiskSecret> DiskSecrets { get { throw null; } }
    }
    public enum CustomerResolutionCode
    {
        None = 0,
        MoveToCleanUpDevice = 1,
        Resume = 2,
        Restart = 3,
        ReachOutToOperation = 4,
    }
    public abstract partial class DataAccountDetails
    {
        protected DataAccountDetails() { }
        public string SharePassword { get { throw null; } set { } }
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
    public partial class DataBoxAccountCopyLogDetails : Azure.ResourceManager.DataBox.Models.CopyLogDetails
    {
        internal DataBoxAccountCopyLogDetails() { }
        public string AccountName { get { throw null; } }
        public string CopyLogLink { get { throw null; } }
        public string CopyVerboseLogLink { get { throw null; } }
    }
    public partial class DataBoxAccountCredentialDetails
    {
        internal DataBoxAccountCredentialDetails() { }
        public string AccountConnectionString { get { throw null; } }
        public string AccountName { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataAccountType? DataAccountType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.ShareCredentialDetails> ShareCredentialDetails { get { throw null; } }
    }
    public abstract partial class DataBoxBasicJobDetails
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
    }
    public partial class DataBoxContactDetails
    {
        public DataBoxContactDetails(string contactName, string phone, System.Collections.Generic.IEnumerable<string> emailList) { }
        public string ContactName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailList { get { throw null; } }
        public string Mobile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.NotificationPreference> NotificationPreference { get { throw null; } }
        public string Phone { get { throw null; } set { } }
        public string PhoneExtension { get { throw null; } set { } }
    }
    public partial class DataBoxCopyProgress
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
    public partial class DataBoxCustomerDiskCopyLogDetails : Azure.ResourceManager.DataBox.Models.CopyLogDetails
    {
        internal DataBoxCustomerDiskCopyLogDetails() { }
        public string ErrorLogLink { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public string VerboseLogLink { get { throw null; } }
    }
    public partial class DataBoxCustomerDiskCopyProgress : Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress
    {
        internal DataBoxCustomerDiskCopyProgress() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus? CopyStatus { get { throw null; } }
        public string SerialNumber { get { throw null; } }
    }
    public partial class DataBoxCustomerDiskJobDetails : Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails
    {
        public DataBoxCustomerDiskJobDetails(Azure.ResourceManager.DataBox.Models.DataBoxContactDetails contactDetails, Azure.ResourceManager.DataBox.Models.PackageCarrierDetails returnToCustomerPackageDetails) : base (default(Azure.ResourceManager.DataBox.Models.DataBoxContactDetails)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyProgress> CopyProgress { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.PackageCarrierInfo DeliverToDataCenterPackageDetails { get { throw null; } }
        public bool? EnableManifestBackup { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataBox.Models.ExportDiskDetails> ExportDiskDetails { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataBox.Models.ImportDiskDetails> ImportDiskDetails { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.PackageCarrierDetails ReturnToCustomerPackageDetails { get { throw null; } set { } }
    }
    public partial class DataBoxDiskCopyLogDetails : Azure.ResourceManager.DataBox.Models.CopyLogDetails
    {
        internal DataBoxDiskCopyLogDetails() { }
        public string DiskSerialNumber { get { throw null; } }
        public string ErrorLogLink { get { throw null; } }
        public string VerboseLogLink { get { throw null; } }
    }
    public partial class DataBoxDiskCopyProgress
    {
        internal DataBoxDiskCopyProgress() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> Actions { get { throw null; } }
        public long? BytesCopied { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus? Status { get { throw null; } }
    }
    public partial class DataBoxDiskGranularCopyLogDetails : Azure.ResourceManager.DataBox.Models.GranularCopyLogDetails
    {
        internal DataBoxDiskGranularCopyLogDetails() { }
        public Azure.Core.ResourceIdentifier AccountId { get { throw null; } }
        public string ErrorLogLink { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public string VerboseLogLink { get { throw null; } }
    }
    public partial class DataBoxDiskGranularCopyProgress : Azure.ResourceManager.DataBox.Models.GranularCopyProgress
    {
        internal DataBoxDiskGranularCopyProgress() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxCopyStatus? CopyStatus { get { throw null; } }
        public string SerialNumber { get { throw null; } }
    }
    public partial class DataBoxDiskJobDetails : Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails
    {
        public DataBoxDiskJobDetails(Azure.ResourceManager.DataBox.Models.DataBoxContactDetails contactDetails) : base (default(Azure.ResourceManager.DataBox.Models.DataBoxContactDetails)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyProgress> CopyProgress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> DisksAndSizeDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyLogDetails> GranularCopyLogDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyProgress> GranularCopyProgress { get { throw null; } }
        public string Passkey { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, int> PreferredDisks { get { throw null; } }
    }
    public partial class DataBoxDiskJobSecrets : Azure.ResourceManager.DataBox.Models.JobSecrets
    {
        internal DataBoxDiskJobSecrets() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxDiskSecret> DiskSecrets { get { throw null; } }
        public bool? IsPasskeyUserDefined { get { throw null; } }
        public string Passkey { get { throw null; } }
    }
    public partial class DataBoxDiskSecret
    {
        internal DataBoxDiskSecret() { }
        public string BitLockerKey { get { throw null; } }
        public string DiskSerialNumber { get { throw null; } }
    }
    public enum DataBoxDoubleEncryption
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DataBoxEncryptionPreferences
    {
        public DataBoxEncryptionPreferences() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxDoubleEncryption? DoubleEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.HardwareEncryption? HardwareEncryption { get { throw null; } set { } }
    }
    public partial class DataBoxHeavyAccountCopyLogDetails : Azure.ResourceManager.DataBox.Models.CopyLogDetails
    {
        internal DataBoxHeavyAccountCopyLogDetails() { }
        public string AccountName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> CopyLogLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> CopyVerboseLogLink { get { throw null; } }
    }
    public partial class DataBoxHeavyJobDetails : Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails
    {
        public DataBoxHeavyJobDetails(Azure.ResourceManager.DataBox.Models.DataBoxContactDetails contactDetails) : base (default(Azure.ResourceManager.DataBox.Models.DataBoxContactDetails)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress> CopyProgress { get { throw null; } }
        public string DevicePassword { get { throw null; } set { } }
    }
    public partial class DataBoxHeavyJobSecrets : Azure.ResourceManager.DataBox.Models.JobSecrets
    {
        internal DataBoxHeavyJobSecrets() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxHeavySecret> CabinetPodSecrets { get { throw null; } }
    }
    public partial class DataBoxHeavySecret
    {
        internal DataBoxHeavySecret() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxAccountCredentialDetails> AccountCredentialDetails { get { throw null; } }
        public string DevicePassword { get { throw null; } }
        public string DeviceSerialNumber { get { throw null; } }
        public string EncodedValidationCertPubKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration> NetworkConfigurations { get { throw null; } }
    }
    public partial class DataBoxJobCancellationReason
    {
        public DataBoxJobCancellationReason(string reason) { }
        public string Reason { get { throw null; } }
    }
    public partial class DataBoxJobDetails : Azure.ResourceManager.DataBox.Models.DataBoxBasicJobDetails
    {
        public DataBoxJobDetails(Azure.ResourceManager.DataBox.Models.DataBoxContactDetails contactDetails) : base (default(Azure.ResourceManager.DataBox.Models.DataBoxContactDetails)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxCopyProgress> CopyProgress { get { throw null; } }
        public string DevicePassword { get { throw null; } set { } }
    }
    public partial class DataBoxJobPatch
    {
        public DataBoxJobPatch() { }
        public Azure.ResourceManager.DataBox.Models.UpdateJobDetails Details { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataboxJobSecrets : Azure.ResourceManager.DataBox.Models.JobSecrets
    {
        internal DataboxJobSecrets() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxSecret> PodSecrets { get { throw null; } }
    }
    public partial class DataBoxJobStage
    {
        internal DataBoxJobStage() { }
        public string DisplayName { get { throw null; } }
        public System.BinaryData JobStageDetails { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxStageName? StageName { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxStageStatus? StageStatus { get { throw null; } }
        public System.DateTimeOffset? StageTime { get { throw null; } }
    }
    public enum DataBoxJobTransferType
    {
        ImportToAzure = 0,
        ExportFromAzure = 1,
    }
    public partial class DataBoxKeyEncryptionKey
    {
        public DataBoxKeyEncryptionKey(Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKeyType kekType) { }
        public Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKeyType KekType { get { throw null; } set { } }
        public System.Uri KekUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KekVaultResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxManagedIdentity ManagedIdentity { get { throw null; } set { } }
    }
    public enum DataBoxKeyEncryptionKeyType
    {
        MicrosoftManaged = 0,
        CustomerManaged = 1,
    }
    public partial class DataBoxManagedIdentity
    {
        public DataBoxManagedIdentity() { }
        public string IdentityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityId { get { throw null; } set { } }
    }
    public partial class DataBoxOrderPreferences
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
    }
    public partial class DataBoxScheduleAvailabilityContent : Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent
    {
        public DataBoxScheduleAvailabilityContent(Azure.Core.AzureLocation storageLocation) : base (default(Azure.Core.AzureLocation)) { }
    }
    public partial class DataBoxSecret
    {
        internal DataBoxSecret() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxAccountCredentialDetails> AccountCredentialDetails { get { throw null; } }
        public string DevicePassword { get { throw null; } }
        public string DeviceSerialNumber { get { throw null; } }
        public string EncodedValidationCertPubKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration> NetworkConfigurations { get { throw null; } }
    }
    public partial class DataBoxShipmentPickUpResult
    {
        internal DataBoxShipmentPickUpResult() { }
        public string ConfirmationNumber { get { throw null; } }
        public System.DateTimeOffset? ReadyBy { get { throw null; } }
    }
    public partial class DataBoxShippingAddress
    {
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
    }
    public enum DataBoxShippingAddressType
    {
        None = 0,
        Residential = 1,
        Commercial = 2,
    }
    public partial class DataBoxSku
    {
        public DataBoxSku(Azure.ResourceManager.DataBox.Models.DataBoxSkuName name) { }
        public string DisplayName { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName Name { get { throw null; } set { } }
    }
    public partial class DataBoxSkuCapacity
    {
        internal DataBoxSkuCapacity() { }
        public string Maximum { get { throw null; } }
        public string Usable { get { throw null; } }
    }
    public partial class DataBoxSkuCost
    {
        internal DataBoxSkuCost() { }
        public System.Guid? MeterId { get { throw null; } }
        public string MeterType { get { throw null; } }
        public double? Multiplier { get { throw null; } }
    }
    public partial class DataBoxSkuInformation
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
    public partial class DataBoxStorageAccountDetails : Azure.ResourceManager.DataBox.Models.DataAccountDetails
    {
        public DataBoxStorageAccountDetails(Azure.Core.ResourceIdentifier storageAccountId) { }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
    }
    public partial class DataBoxValidateAddressContent : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent
    {
        public DataBoxValidateAddressContent(Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress shippingAddress, Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType) { }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName DeviceType { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress ShippingAddress { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.TransportPreferences TransportPreferences { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.DataBox.Models.TransportShipmentType? TransportPreferencesPreferredShipmentType { get { throw null; } set { } }
    }
    public abstract partial class DataBoxValidationContent
    {
        protected DataBoxValidationContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent> individualRequestDetails) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent> IndividualRequestDetails { get { throw null; } }
    }
    public abstract partial class DataBoxValidationInputContent
    {
        protected DataBoxValidationInputContent() { }
    }
    public abstract partial class DataBoxValidationInputResult
    {
        protected DataBoxValidationInputResult() { }
        public Azure.ResponseError Error { get { throw null; } }
    }
    public partial class DataBoxValidationResult
    {
        internal DataBoxValidationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult> IndividualResponseDetails { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.OverallValidationStatus? Status { get { throw null; } }
    }
    public enum DataBoxValidationStatus
    {
        Valid = 0,
        Invalid = 1,
        Skipped = 2,
    }
    public partial class DataCenterAccessSecurityCode
    {
        internal DataCenterAccessSecurityCode() { }
        public string ForwardDataCenterAccessCode { get { throw null; } }
        public string ReverseDataCenterAccessCode { get { throw null; } }
    }
    public partial class DataCenterAddressContent
    {
        public DataCenterAddressContent(Azure.Core.AzureLocation storageLocation, Azure.ResourceManager.DataBox.Models.DataBoxSkuName skuName) { }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName SkuName { get { throw null; } }
        public Azure.Core.AzureLocation StorageLocation { get { throw null; } }
    }
    public partial class DataCenterAddressInstructionResult : Azure.ResourceManager.DataBox.Models.DataCenterAddressResult
    {
        internal DataCenterAddressInstructionResult() { }
        public string CommunicationInstruction { get { throw null; } }
    }
    public partial class DataCenterAddressLocationResult : Azure.ResourceManager.DataBox.Models.DataCenterAddressResult
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
    }
    public abstract partial class DataCenterAddressResult
    {
        protected DataCenterAddressResult() { }
        public Azure.Core.AzureLocation? DataCenterAzureLocation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedCarriersForReturnShipment { get { throw null; } }
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
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode AUH20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode BJB { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode BJS20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode BL20 { get { throw null; } }
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
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode CWL20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode CYS04 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode DSM05 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode DUB07 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode FRA22 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode HKG20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode JNB21 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode JNB22 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode LON24 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode MAA01 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode MEL23 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode MNZ21 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode MWH01 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode ORK70 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode OSA02 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode OSA20 { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.DataCenterCode OSA22 { get { throw null; } }
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
    public partial class DataExportDetails
    {
        public DataExportDetails(Azure.ResourceManager.DataBox.Models.TransferConfiguration transferConfiguration, Azure.ResourceManager.DataBox.Models.DataAccountDetails accountDetails) { }
        public Azure.ResourceManager.DataBox.Models.DataAccountDetails AccountDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.LogCollectionLevel? LogCollectionLevel { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.TransferConfiguration TransferConfiguration { get { throw null; } set { } }
    }
    public partial class DataImportDetails
    {
        public DataImportDetails(Azure.ResourceManager.DataBox.Models.DataAccountDetails accountDetails) { }
        public Azure.ResourceManager.DataBox.Models.DataAccountDetails AccountDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.LogCollectionLevel? LogCollectionLevel { get { throw null; } set { } }
    }
    public partial class DataLocationToServiceLocationMap
    {
        internal DataLocationToServiceLocationMap() { }
        public Azure.Core.AzureLocation? DataLocation { get { throw null; } }
        public Azure.Core.AzureLocation? ServiceLocation { get { throw null; } }
    }
    public partial class DataTransferDetailsValidationContent : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent
    {
        public DataTransferDetailsValidationContent(Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType, Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType transferType) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.DataExportDetails> DataExportDetails { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.DataImportDetails> DataImportDetails { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName DeviceType { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType TransferType { get { throw null; } }
    }
    public partial class DataTransferDetailsValidationResult : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult
    {
        internal DataTransferDetailsValidationResult() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? Status { get { throw null; } }
    }
    public partial class DeviceErasureDetails
    {
        internal DeviceErasureDetails() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxStageStatus? DeviceErasureStatus { get { throw null; } }
        public string ErasureOrDestructionCertificateSasKey { get { throw null; } }
    }
    public partial class DiskScheduleAvailabilityContent : Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent
    {
        public DiskScheduleAvailabilityContent(Azure.Core.AzureLocation storageLocation, int expectedDataSizeInTerabytes) : base (default(Azure.Core.AzureLocation)) { }
        public int ExpectedDataSizeInTerabytes { get { throw null; } }
    }
    public partial class ExportDiskDetails
    {
        internal ExportDiskDetails() { }
        public string BackupManifestCloudPath { get { throw null; } }
        public string ManifestFile { get { throw null; } }
        public string ManifestHash { get { throw null; } }
    }
    public partial class FilterFileDetails
    {
        public FilterFileDetails(Azure.ResourceManager.DataBox.Models.FilterFileType filterFileType, string filterFilePath) { }
        public string FilterFilePath { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.FilterFileType FilterFileType { get { throw null; } set { } }
    }
    public enum FilterFileType
    {
        AzureBlob = 0,
        AzureFile = 1,
    }
    public abstract partial class GranularCopyLogDetails
    {
        protected GranularCopyLogDetails() { }
    }
    public partial class GranularCopyProgress
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
    }
    public enum HardwareEncryption
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class HeavyScheduleAvailabilityContent : Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent
    {
        public HeavyScheduleAvailabilityContent(Azure.Core.AzureLocation storageLocation) : base (default(Azure.Core.AzureLocation)) { }
    }
    public partial class ImportDiskDetails
    {
        public ImportDiskDetails(string manifestFile, string manifestHash, string bitLockerKey) { }
        public string BackupManifestCloudPath { get { throw null; } }
        public string BitLockerKey { get { throw null; } set { } }
        public string ManifestFile { get { throw null; } set { } }
        public string ManifestHash { get { throw null; } set { } }
    }
    public enum JobDeliveryType
    {
        NonScheduled = 0,
        Scheduled = 1,
    }
    public abstract partial class JobSecrets
    {
        protected JobSecrets() { }
        public Azure.ResourceManager.DataBox.Models.DataCenterAccessSecurityCode DataCenterAccessSecurityCode { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
    }
    public partial class LastMitigationActionOnJob
    {
        internal LastMitigationActionOnJob() { }
        public System.DateTimeOffset? ActionPerformedOn { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.CustomerResolutionCode? CustomerResolution { get { throw null; } }
        public bool? IsPerformedByCustomer { get { throw null; } }
    }
    public enum LogCollectionLevel
    {
        Error = 0,
        Verbose = 1,
    }
    public partial class ManagedDiskDetails : Azure.ResourceManager.DataBox.Models.DataAccountDetails
    {
        public ManagedDiskDetails(Azure.Core.ResourceIdentifier resourceGroupId, Azure.Core.ResourceIdentifier stagingStorageAccountId) { }
        public Azure.Core.ResourceIdentifier ResourceGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StagingStorageAccountId { get { throw null; } set { } }
    }
    public partial class MarkDevicesShippedContent
    {
        public MarkDevicesShippedContent(Azure.ResourceManager.DataBox.Models.PackageCarrierInfo deliverToDataCenterPackageDetails) { }
        public Azure.ResourceManager.DataBox.Models.PackageCarrierInfo DeliverToDataCenterPackageDetails { get { throw null; } }
    }
    public partial class MitigateJobContent
    {
        public MitigateJobContent() { }
        public MitigateJobContent(Azure.ResourceManager.DataBox.Models.CustomerResolutionCode customerResolutionCode) { }
        public Azure.ResourceManager.DataBox.Models.CustomerResolutionCode CustomerResolutionCode { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> SerialNumberCustomerResolutionMap { get { throw null; } }
    }
    public partial class NotificationPreference
    {
        public NotificationPreference(Azure.ResourceManager.DataBox.Models.NotificationStageName stageName, bool sendNotification) { }
        public bool SendNotification { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.NotificationStageName StageName { get { throw null; } set { } }
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
    public partial class PackageCarrierDetails
    {
        public PackageCarrierDetails() { }
        public string CarrierAccountNumber { get { throw null; } set { } }
        public string CarrierName { get { throw null; } set { } }
        public string TrackingId { get { throw null; } set { } }
    }
    public partial class PackageCarrierInfo
    {
        public PackageCarrierInfo() { }
        public string CarrierName { get { throw null; } set { } }
        public string TrackingId { get { throw null; } set { } }
    }
    public partial class PackageShippingDetails
    {
        internal PackageShippingDetails() { }
        public string CarrierName { get { throw null; } }
        public string TrackingId { get { throw null; } }
        public System.Uri TrackingUri { get { throw null; } }
    }
    public partial class PreferencesValidationContent : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent
    {
        public PreferencesValidationContent(Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType) { }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName DeviceType { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences Preference { get { throw null; } set { } }
    }
    public partial class PreferencesValidationResult : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult
    {
        internal PreferencesValidationResult() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? Status { get { throw null; } }
    }
    public partial class RegionConfigurationContent
    {
        public RegionConfigurationContent() { }
        public Azure.ResourceManager.DataBox.Models.DataCenterAddressContent DataCenterAddressRequest { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityContent ScheduleAvailabilityRequest { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName? TransportAvailabilityRequestSkuName { get { throw null; } set { } }
    }
    public partial class RegionConfigurationResult
    {
        internal RegionConfigurationResult() { }
        public Azure.ResourceManager.DataBox.Models.DataCenterAddressResult DataCenterAddressResponse { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.DateTimeOffset> ScheduleAvailabilityResponseAvailableDates { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.TransportAvailabilityDetails> TransportAvailabilityDetails { get { throw null; } }
    }
    public partial class ReverseShippingDetails
    {
        public ReverseShippingDetails() { }
        public Azure.ResourceManager.DataBox.Models.ContactInfo ContactDetails { get { throw null; } set { } }
        public bool? IsUpdated { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress ShippingAddress { get { throw null; } set { } }
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
    public abstract partial class ScheduleAvailabilityContent
    {
        protected ScheduleAvailabilityContent(Azure.Core.AzureLocation storageLocation) { }
        public string Country { get { throw null; } set { } }
        public Azure.Core.AzureLocation StorageLocation { get { throw null; } }
    }
    public partial class ShareCredentialDetails
    {
        internal ShareCredentialDetails() { }
        public string Password { get { throw null; } }
        public string ShareName { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.ShareDestinationFormatType? ShareType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxAccessProtocol> SupportedAccessProtocols { get { throw null; } }
        public string UserName { get { throw null; } }
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
    public partial class ShipmentPickUpContent
    {
        public ShipmentPickUpContent(System.DateTimeOffset startOn, System.DateTimeOffset endOn, string shipmentLocation) { }
        public System.DateTimeOffset EndOn { get { throw null; } }
        public string ShipmentLocation { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
    }
    public partial class SkuAvailabilityValidationContent : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent
    {
        public SkuAvailabilityValidationContent(Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType, Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType transferType, string country, Azure.Core.AzureLocation location) { }
        public string Country { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName DeviceType { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxJobTransferType TransferType { get { throw null; } }
    }
    public partial class SkuAvailabilityValidationResult : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult
    {
        internal SkuAvailabilityValidationResult() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? Status { get { throw null; } }
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
    public partial class SubscriptionIsAllowedToCreateJobValidationContent : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputContent
    {
        public SubscriptionIsAllowedToCreateJobValidationContent() { }
    }
    public partial class SubscriptionIsAllowedToCreateJobValidationResult : Azure.ResourceManager.DataBox.Models.DataBoxValidationInputResult
    {
        internal SubscriptionIsAllowedToCreateJobValidationResult() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxValidationStatus? Status { get { throw null; } }
    }
    public partial class TransferAllDetails
    {
        public TransferAllDetails(Azure.ResourceManager.DataBox.Models.DataAccountType dataAccountType) { }
        public Azure.ResourceManager.DataBox.Models.DataAccountType DataAccountType { get { throw null; } set { } }
        public bool? TransferAllBlobs { get { throw null; } set { } }
        public bool? TransferAllFiles { get { throw null; } set { } }
    }
    public partial class TransferConfiguration
    {
        public TransferConfiguration(Azure.ResourceManager.DataBox.Models.TransferConfigurationType transferConfigurationType) { }
        public Azure.ResourceManager.DataBox.Models.TransferAllDetails TransferAllDetailsInclude { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.TransferConfigurationType TransferConfigurationType { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.TransferFilterDetails TransferFilterDetailsInclude { get { throw null; } set { } }
    }
    public enum TransferConfigurationType
    {
        TransferAll = 0,
        TransferUsingFilter = 1,
    }
    public partial class TransferFilterDetails
    {
        public TransferFilterDetails(Azure.ResourceManager.DataBox.Models.DataAccountType dataAccountType) { }
        public Azure.ResourceManager.DataBox.Models.AzureFileFilterDetails AzureFileFilterDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.BlobFilterDetails BlobFilterDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataAccountType DataAccountType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.FilterFileDetails> FilterFileDetails { get { throw null; } }
    }
    public partial class TransportAvailabilityDetails
    {
        internal TransportAvailabilityDetails() { }
        public Azure.ResourceManager.DataBox.Models.TransportShipmentType? ShipmentType { get { throw null; } }
    }
    public partial class TransportPreferences
    {
        public TransportPreferences(Azure.ResourceManager.DataBox.Models.TransportShipmentType preferredShipmentType) { }
        public bool? IsUpdated { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.TransportShipmentType PreferredShipmentType { get { throw null; } set { } }
    }
    public enum TransportShipmentType
    {
        CustomerManaged = 0,
        MicrosoftManaged = 1,
    }
    public partial class UnencryptedCredentials
    {
        internal UnencryptedCredentials() { }
        public string JobName { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.JobSecrets JobSecrets { get { throw null; } }
    }
    public partial class UpdateJobDetails
    {
        public UpdateJobDetails() { }
        public Azure.ResourceManager.DataBox.Models.DataBoxContactDetails ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxKeyEncryptionKey KeyEncryptionKey { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxOrderPreferences Preferences { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.PackageCarrierDetails ReturnToCustomerPackageDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.ReverseShippingDetails ReverseShippingDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxShippingAddress ShippingAddress { get { throw null; } set { } }
    }
}
