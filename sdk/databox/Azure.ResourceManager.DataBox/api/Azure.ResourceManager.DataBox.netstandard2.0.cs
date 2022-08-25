namespace Azure.ResourceManager.DataBox
{
    public static partial class DataBoxExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.DataBox.Models.DataBoxSkuInformation> GetAvailableSkusByResourceGroupServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.AvailableSkuContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataBox.Models.DataBoxSkuInformation> GetAvailableSkusByResourceGroupServicesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.AvailableSkuContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataBox.JobResource GetJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataBox.JobResource> GetJobResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.JobResource>> GetJobResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataBox.JobResourceCollection GetJobResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataBox.JobResource> GetJobResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataBox.JobResource> GetJobResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataBox.Models.RegionConfigurationResponse> RegionConfigurationByResourceGroupService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.RegionConfigurationRequest regionConfigurationRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.Models.RegionConfigurationResponse>> RegionConfigurationByResourceGroupServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.RegionConfigurationRequest regionConfigurationRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataBox.Models.RegionConfigurationResponse> RegionConfigurationService(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.RegionConfigurationRequest regionConfigurationRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.Models.RegionConfigurationResponse>> RegionConfigurationServiceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.RegionConfigurationRequest regionConfigurationRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataBox.Models.AddressValidationOutput> ValidateAddressService(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.ValidateAddress validateAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.Models.AddressValidationOutput>> ValidateAddressServiceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.ValidateAddress validateAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataBox.Models.ValidationResponse> ValidateInputsByResourceGroupService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.ValidationRequest validationRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.Models.ValidationResponse>> ValidateInputsByResourceGroupServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.ValidationRequest validationRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataBox.Models.ValidationResponse> ValidateInputsService(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.ValidationRequest validationRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.Models.ValidationResponse>> ValidateInputsServiceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.ValidationRequest validationRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobResource() { }
        public virtual Azure.ResourceManager.DataBox.JobResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.JobResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.JobResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.Models.ShipmentPickUpResponse> BookShipmentPickUp(Azure.ResourceManager.DataBox.Models.ShipmentPickUpContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.Models.ShipmentPickUpResponse>> BookShipmentPickUpAsync(Azure.ResourceManager.DataBox.Models.ShipmentPickUpContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Cancel(Azure.ResourceManager.DataBox.Models.CancellationReason cancellationReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(Azure.ResourceManager.DataBox.Models.CancellationReason cancellationReason, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string jobName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.JobResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.JobResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBox.Models.UnencryptedCredentials> GetCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBox.Models.UnencryptedCredentials> GetCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response MarkDevicesShipped(Azure.ResourceManager.DataBox.Models.MarkDevicesShippedContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> MarkDevicesShippedAsync(Azure.ResourceManager.DataBox.Models.MarkDevicesShippedContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Mitigate(Azure.ResourceManager.DataBox.Models.MitigateJobContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> MitigateAsync(Azure.ResourceManager.DataBox.Models.MitigateJobContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.JobResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.JobResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.JobResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.JobResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBox.JobResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBox.Models.JobResourcePatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBox.JobResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBox.Models.JobResourcePatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBox.JobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.JobResource>, System.Collections.IEnumerable
    {
        protected JobResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBox.JobResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.DataBox.JobResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBox.JobResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.DataBox.JobResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBox.JobResource> Get(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBox.JobResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBox.JobResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBox.JobResource>> GetAsync(string jobName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBox.JobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBox.JobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBox.JobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.JobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public JobResourceData(Azure.Core.AzureLocation location, Azure.ResourceManager.DataBox.Models.TransferType transferType, Azure.ResourceManager.DataBox.Models.DataBoxSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public string CancellationReason { get { throw null; } }
        public System.DateTimeOffset? DeliveryInfoScheduledOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.JobDeliveryType? DeliveryType { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.JobDetails Details { get { throw null; } set { } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsCancellable { get { throw null; } }
        public bool? IsCancellableWithoutFee { get { throw null; } }
        public bool? IsDeletable { get { throw null; } }
        public bool? IsPrepareToShipEnabled { get { throw null; } }
        public bool? IsShippingAddressEditable { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.StageName? Status { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.TransferType TransferType { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.DataBox.Models
{
    public enum AccessProtocol
    {
        SMB = 0,
        NFS = 1,
    }
    public partial class AccountCredentialDetails
    {
        internal AccountCredentialDetails() { }
        public string AccountConnectionString { get { throw null; } }
        public string AccountName { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataAccountType? DataAccountType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.ShareCredentialDetails> ShareCredentialDetails { get { throw null; } }
    }
    public enum AddressType
    {
        None = 0,
        Residential = 1,
        Commercial = 2,
    }
    public partial class AddressValidationOutput
    {
        internal AddressValidationOutput() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.ShippingAddress> AlternateAddresses { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.AddressValidationStatus? ValidationStatus { get { throw null; } }
    }
    public partial class AddressValidationProperties : Azure.ResourceManager.DataBox.Models.ValidationInputResponse
    {
        internal AddressValidationProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.ShippingAddress> AlternateAddresses { get { throw null; } }
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
    public partial class AvailableSkuContent
    {
        public AvailableSkuContent(Azure.ResourceManager.DataBox.Models.TransferType transferType, string country, Azure.Core.AzureLocation location) { }
        public string Country { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.DataBoxSkuName> SkuNames { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.TransferType TransferType { get { throw null; } }
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
    public partial class CancellationReason
    {
        public CancellationReason(string reason) { }
        public string Reason { get { throw null; } }
    }
    public partial class ContactDetails
    {
        public ContactDetails(string contactName, string phone, System.Collections.Generic.IEnumerable<string> emailList) { }
        public string ContactName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailList { get { throw null; } }
        public string Mobile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.NotificationPreference> NotificationPreference { get { throw null; } }
        public string Phone { get { throw null; } set { } }
        public string PhoneExtension { get { throw null; } set { } }
    }
    public partial class CopyLogDetails
    {
        internal CopyLogDetails() { }
    }
    public partial class CopyProgress
    {
        internal CopyProgress() { }
        public string AccountId { get { throw null; } }
        public long? BytesProcessed { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataAccountType? DataAccountType { get { throw null; } }
        public long? DirectoriesErroredOut { get { throw null; } }
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
        public Azure.ResourceManager.DataBox.Models.TransferType? TransferType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CopyStatus : System.IEquatable<Azure.ResourceManager.DataBox.Models.CopyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CopyStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus CompletedWithErrors { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus DeviceFormatted { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus DeviceMetadataModified { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus DriveCorrupted { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus DriveNotDetected { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus DriveNotReceived { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus HardwareError { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus MetadataFilesModifiedOrRemoved { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus NotReturned { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus OtherServiceError { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus OtherUserError { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus StorageAccountNotAccessible { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus UnsupportedData { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.CopyStatus UnsupportedDrive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBox.Models.CopyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBox.Models.CopyStatus left, Azure.ResourceManager.DataBox.Models.CopyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBox.Models.CopyStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBox.Models.CopyStatus left, Azure.ResourceManager.DataBox.Models.CopyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreateJobValidations : Azure.ResourceManager.DataBox.Models.ValidationRequest
    {
        public CreateJobValidations(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.ValidationInputRequest> individualRequestDetails) : base (default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.ValidationInputRequest>)) { }
    }
    public partial class CreateOrderLimitForSubscriptionValidationRequest : Azure.ResourceManager.DataBox.Models.ValidationInputRequest
    {
        public CreateOrderLimitForSubscriptionValidationRequest(Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType) { }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName DeviceType { get { throw null; } }
    }
    public partial class CreateOrderLimitForSubscriptionValidationResponseProperties : Azure.ResourceManager.DataBox.Models.ValidationInputResponse
    {
        internal CreateOrderLimitForSubscriptionValidationResponseProperties() { }
        public Azure.ResourceManager.DataBox.Models.ValidationStatus? Status { get { throw null; } }
    }
    public partial class CustomerDiskJobSecrets : Azure.ResourceManager.DataBox.Models.JobSecrets
    {
        internal CustomerDiskJobSecrets() { }
        public string CarrierAccountNumber { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DiskSecret> DiskSecrets { get { throw null; } }
    }
    public enum CustomerResolutionCode
    {
        None = 0,
        MoveToCleanUpDevice = 1,
        Resume = 2,
        Restart = 3,
        ReachOutToOperation = 4,
    }
    public partial class DataAccountDetails
    {
        public DataAccountDetails() { }
        public string SharePassword { get { throw null; } set { } }
    }
    public enum DataAccountType
    {
        StorageAccount = 0,
        ManagedDisk = 1,
    }
    public partial class DataBoxAccountCopyLogDetails : Azure.ResourceManager.DataBox.Models.CopyLogDetails
    {
        internal DataBoxAccountCopyLogDetails() { }
        public string AccountName { get { throw null; } }
        public string CopyLogLink { get { throw null; } }
        public string CopyVerboseLogLink { get { throw null; } }
    }
    public partial class DataBoxCustomerDiskCopyLogDetails : Azure.ResourceManager.DataBox.Models.CopyLogDetails
    {
        internal DataBoxCustomerDiskCopyLogDetails() { }
        public string ErrorLogLink { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public string VerboseLogLink { get { throw null; } }
    }
    public partial class DataBoxCustomerDiskCopyProgress : Azure.ResourceManager.DataBox.Models.CopyProgress
    {
        internal DataBoxCustomerDiskCopyProgress() { }
        public Azure.ResourceManager.DataBox.Models.CopyStatus? CopyStatus { get { throw null; } }
        public string SerialNumber { get { throw null; } }
    }
    public partial class DataBoxCustomerDiskJobDetails : Azure.ResourceManager.DataBox.Models.JobDetails
    {
        public DataBoxCustomerDiskJobDetails(Azure.ResourceManager.DataBox.Models.ContactDetails contactDetails, Azure.ResourceManager.DataBox.Models.PackageCarrierDetails returnToCustomerPackageDetails) : base (default(Azure.ResourceManager.DataBox.Models.ContactDetails)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxCustomerDiskCopyProgress> CopyProgress { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.PackageCarrierInfo DeliverToDcPackageDetails { get { throw null; } }
        public bool? EnableManifestBackup { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataBox.Models.ExportDiskDetails> ExportDiskDetailsCollection { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataBox.Models.ImportDiskDetails> ImportDiskDetailsCollection { get { throw null; } }
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
        public long? BytesCopied { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.CopyStatus? Status { get { throw null; } }
    }
    public partial class DataBoxDiskGranularCopyProgress : Azure.ResourceManager.DataBox.Models.GranularCopyProgress
    {
        internal DataBoxDiskGranularCopyProgress() { }
        public Azure.ResourceManager.DataBox.Models.CopyStatus? CopyStatus { get { throw null; } }
        public string SerialNumber { get { throw null; } }
    }
    public partial class DataBoxDiskJobDetails : Azure.ResourceManager.DataBox.Models.JobDetails
    {
        public DataBoxDiskJobDetails(Azure.ResourceManager.DataBox.Models.ContactDetails contactDetails) : base (default(Azure.ResourceManager.DataBox.Models.ContactDetails)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxDiskCopyProgress> CopyProgress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> DisksAndSizeDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxDiskGranularCopyProgress> GranularCopyProgress { get { throw null; } }
        public string Passkey { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, int> PreferredDisks { get { throw null; } }
    }
    public partial class DataBoxDiskJobSecrets : Azure.ResourceManager.DataBox.Models.JobSecrets
    {
        internal DataBoxDiskJobSecrets() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DiskSecret> DiskSecrets { get { throw null; } }
        public bool? IsPasskeyUserDefined { get { throw null; } }
        public string PassKey { get { throw null; } }
    }
    public partial class DataBoxHeavyAccountCopyLogDetails : Azure.ResourceManager.DataBox.Models.CopyLogDetails
    {
        internal DataBoxHeavyAccountCopyLogDetails() { }
        public string AccountName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> CopyLogLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> CopyVerboseLogLink { get { throw null; } }
    }
    public partial class DataBoxHeavyJobDetails : Azure.ResourceManager.DataBox.Models.JobDetails
    {
        public DataBoxHeavyJobDetails(Azure.ResourceManager.DataBox.Models.ContactDetails contactDetails) : base (default(Azure.ResourceManager.DataBox.Models.ContactDetails)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.CopyProgress> CopyProgress { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.AccountCredentialDetails> AccountCredentialDetails { get { throw null; } }
        public string DevicePassword { get { throw null; } }
        public string DeviceSerialNumber { get { throw null; } }
        public string EncodedValidationCertPubKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration> NetworkConfigurations { get { throw null; } }
    }
    public partial class DataBoxJobDetails : Azure.ResourceManager.DataBox.Models.JobDetails
    {
        public DataBoxJobDetails(Azure.ResourceManager.DataBox.Models.ContactDetails contactDetails) : base (default(Azure.ResourceManager.DataBox.Models.ContactDetails)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.CopyProgress> CopyProgress { get { throw null; } }
        public string DevicePassword { get { throw null; } set { } }
    }
    public partial class DataboxJobSecrets : Azure.ResourceManager.DataBox.Models.JobSecrets
    {
        internal DataboxJobSecrets() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataBoxSecret> PodSecrets { get { throw null; } }
    }
    public partial class DataBoxScheduleAvailabilityRequest : Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityRequest
    {
        public DataBoxScheduleAvailabilityRequest(string storageLocation) : base (default(string)) { }
    }
    public partial class DataBoxSecret
    {
        internal DataBoxSecret() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.AccountCredentialDetails> AccountCredentialDetails { get { throw null; } }
        public string DevicePassword { get { throw null; } }
        public string DeviceSerialNumber { get { throw null; } }
        public string EncodedValidationCertPubKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.ApplianceNetworkConfiguration> NetworkConfigurations { get { throw null; } }
    }
    public partial class DataBoxSku
    {
        public DataBoxSku(Azure.ResourceManager.DataBox.Models.DataBoxSkuName name) { }
        public string DisplayName { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName Name { get { throw null; } set { } }
    }
    public partial class DataBoxSkuInformation
    {
        internal DataBoxSkuInformation() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.SkuCapacity Capacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.SkuCost> Costs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.DataLocationToServiceLocationMap> DataLocationToServiceLocationMap { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.SkuDisabledReason? DisabledReason { get { throw null; } }
        public string DisabledReasonMessage { get { throw null; } }
        public bool? Enabled { get { throw null; } }
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
    public partial class DatacenterAddressInstructionResponse : Azure.ResourceManager.DataBox.Models.DatacenterAddressResponse
    {
        internal DatacenterAddressInstructionResponse() { }
        public string CommunicationInstruction { get { throw null; } }
    }
    public partial class DatacenterAddressLocationResponse : Azure.ResourceManager.DataBox.Models.DatacenterAddressResponse
    {
        internal DatacenterAddressLocationResponse() { }
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
    public partial class DatacenterAddressRequest
    {
        public DatacenterAddressRequest(string storageLocation, Azure.ResourceManager.DataBox.Models.DataBoxSkuName skuName) { }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName SkuName { get { throw null; } }
        public string StorageLocation { get { throw null; } }
    }
    public partial class DatacenterAddressResponse
    {
        internal DatacenterAddressResponse() { }
        public string DataCenterAzureLocation { get { throw null; } }
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
        public string DataLocation { get { throw null; } }
        public string ServiceLocation { get { throw null; } }
    }
    public partial class DataTransferDetailsValidationRequest : Azure.ResourceManager.DataBox.Models.ValidationInputRequest
    {
        public DataTransferDetailsValidationRequest(Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType, Azure.ResourceManager.DataBox.Models.TransferType transferType) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.DataExportDetails> DataExportDetails { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.DataImportDetails> DataImportDetails { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName DeviceType { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.TransferType TransferType { get { throw null; } }
    }
    public partial class DataTransferDetailsValidationResponseProperties : Azure.ResourceManager.DataBox.Models.ValidationInputResponse
    {
        internal DataTransferDetailsValidationResponseProperties() { }
        public Azure.ResourceManager.DataBox.Models.ValidationStatus? Status { get { throw null; } }
    }
    public partial class DcAccessSecurityCode
    {
        internal DcAccessSecurityCode() { }
        public string ForwardDCAccessCode { get { throw null; } }
        public string ReverseDCAccessCode { get { throw null; } }
    }
    public partial class DeviceErasureDetails
    {
        internal DeviceErasureDetails() { }
        public Azure.ResourceManager.DataBox.Models.StageStatus? DeviceErasureStatus { get { throw null; } }
        public string ErasureOrDestructionCertificateSasKey { get { throw null; } }
    }
    public partial class DiskScheduleAvailabilityRequest : Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityRequest
    {
        public DiskScheduleAvailabilityRequest(string storageLocation, int expectedDataSizeInTeraBytes) : base (default(string)) { }
        public int ExpectedDataSizeInTeraBytes { get { throw null; } }
    }
    public partial class DiskSecret
    {
        internal DiskSecret() { }
        public string BitLockerKey { get { throw null; } }
        public string DiskSerialNumber { get { throw null; } }
    }
    public enum DoubleEncryption
    {
        Enabled = 0,
        Disabled = 1,
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
    public partial class GranularCopyProgress
    {
        internal GranularCopyProgress() { }
        public string AccountId { get { throw null; } }
        public long? BytesProcessed { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataAccountType? DataAccountType { get { throw null; } }
        public long? DirectoriesErroredOut { get { throw null; } }
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
        public Azure.ResourceManager.DataBox.Models.TransferType? TransferType { get { throw null; } }
    }
    public partial class HeavyScheduleAvailabilityRequest : Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityRequest
    {
        public HeavyScheduleAvailabilityRequest(string storageLocation) : base (default(string)) { }
    }
    public partial class IdentityProperties
    {
        public IdentityProperties() { }
        public string IdentityPropertiesType { get { throw null; } set { } }
        public string UserAssignedResourceId { get { throw null; } set { } }
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
    public partial class JobDetails
    {
        public JobDetails(Azure.ResourceManager.DataBox.Models.ContactDetails contactDetails) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.CustomerResolutionCode> Actions { get { throw null; } }
        public string ChainOfCustodySasKey { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.ContactDetails ContactDetails { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.CopyLogDetails> CopyLogDetails { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DatacenterAddressResponse DatacenterAddress { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataCenterCode? DataCenterCode { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.DataExportDetails> DataExportDetails { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.DataImportDetails> DataImportDetails { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.PackageShippingDetails DeliveryPackage { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DeviceErasureDetails DeviceErasureDetails { get { throw null; } }
        public int? ExpectedDataSizeInTeraBytes { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.JobStages> JobStages { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.KeyEncryptionKey KeyEncryptionKey { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.LastMitigationActionOnJob LastMitigationActionOnJob { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.Preferences Preferences { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.PackageShippingDetails ReturnPackage { get { throw null; } }
        public string ReverseShipmentLabelSasKey { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.ShippingAddress ShippingAddress { get { throw null; } set { } }
    }
    public partial class JobResourcePatch
    {
        public JobResourcePatch() { }
        public Azure.ResourceManager.DataBox.Models.UpdateJobDetails Details { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class JobSecrets
    {
        internal JobSecrets() { }
        public Azure.ResourceManager.DataBox.Models.DcAccessSecurityCode DcAccessSecurityCode { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
    }
    public partial class JobStages
    {
        internal JobStages() { }
        public string DisplayName { get { throw null; } }
        public System.BinaryData JobStageDetails { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.StageName? StageName { get { throw null; } }
        public System.DateTimeOffset? StageOn { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.StageStatus? StageStatus { get { throw null; } }
    }
    public enum KekType
    {
        MicrosoftManaged = 0,
        CustomerManaged = 1,
    }
    public partial class KeyEncryptionKey
    {
        public KeyEncryptionKey(Azure.ResourceManager.DataBox.Models.KekType kekType) { }
        public Azure.ResourceManager.DataBox.Models.IdentityProperties IdentityProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.KekType KekType { get { throw null; } set { } }
        public System.Uri KekUri { get { throw null; } set { } }
        public string KekVaultResourceId { get { throw null; } set { } }
    }
    public partial class LastMitigationActionOnJob
    {
        internal LastMitigationActionOnJob() { }
        public System.DateTimeOffset? ActionDateTimeInUtc { get { throw null; } }
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
        public ManagedDiskDetails(string resourceGroupId, string stagingStorageAccountId) { }
        public string ResourceGroupId { get { throw null; } set { } }
        public string StagingStorageAccountId { get { throw null; } set { } }
    }
    public partial class MarkDevicesShippedContent
    {
        public MarkDevicesShippedContent(Azure.ResourceManager.DataBox.Models.PackageCarrierInfo deliverToDcPackageDetails) { }
        public Azure.ResourceManager.DataBox.Models.PackageCarrierInfo DeliverToDcPackageDetails { get { throw null; } }
    }
    public partial class MitigateJobContent
    {
        public MitigateJobContent(Azure.ResourceManager.DataBox.Models.CustomerResolutionCode customerResolutionCode) { }
        public Azure.ResourceManager.DataBox.Models.CustomerResolutionCode CustomerResolutionCode { get { throw null; } }
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
        public static Azure.ResourceManager.DataBox.Models.NotificationStageName AtAzureDC { get { throw null; } }
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
    public partial class Preferences
    {
        public Preferences() { }
        public Azure.ResourceManager.DataBox.Models.DoubleEncryption? DoubleEncryption { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PreferredDataCenterRegion { get { throw null; } }
        public System.Collections.Generic.IList<string> StorageAccountAccessTierPreferences { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.TransportShipmentType? TransportPreferencesPreferredShipmentType { get { throw null; } set { } }
    }
    public partial class PreferencesValidationRequest : Azure.ResourceManager.DataBox.Models.ValidationInputRequest
    {
        public PreferencesValidationRequest(Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType) { }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName DeviceType { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.Preferences Preference { get { throw null; } set { } }
    }
    public partial class PreferencesValidationResponseProperties : Azure.ResourceManager.DataBox.Models.ValidationInputResponse
    {
        internal PreferencesValidationResponseProperties() { }
        public Azure.ResourceManager.DataBox.Models.ValidationStatus? Status { get { throw null; } }
    }
    public partial class RegionConfigurationRequest
    {
        public RegionConfigurationRequest() { }
        public Azure.ResourceManager.DataBox.Models.DatacenterAddressRequest DatacenterAddressRequest { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.ScheduleAvailabilityRequest ScheduleAvailabilityRequest { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName? TransportAvailabilityRequestSkuName { get { throw null; } set { } }
    }
    public partial class RegionConfigurationResponse
    {
        internal RegionConfigurationResponse() { }
        public Azure.ResourceManager.DataBox.Models.DatacenterAddressResponse DatacenterAddressResponse { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.DateTimeOffset> ScheduleAvailabilityResponseAvailableDates { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.TransportAvailabilityDetails> TransportAvailabilityDetails { get { throw null; } }
    }
    public partial class ScheduleAvailabilityRequest
    {
        public ScheduleAvailabilityRequest(string storageLocation) { }
        public string Country { get { throw null; } set { } }
        public string StorageLocation { get { throw null; } }
    }
    public partial class ShareCredentialDetails
    {
        internal ShareCredentialDetails() { }
        public string Password { get { throw null; } }
        public string ShareName { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.ShareDestinationFormatType? ShareType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.AccessProtocol> SupportedAccessProtocols { get { throw null; } }
        public string UserName { get { throw null; } }
    }
    public enum ShareDestinationFormatType
    {
        UnknownType = 0,
        HCS = 1,
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
    public partial class ShipmentPickUpResponse
    {
        internal ShipmentPickUpResponse() { }
        public string ConfirmationNumber { get { throw null; } }
        public System.DateTimeOffset? ReadyByOn { get { throw null; } }
    }
    public partial class ShippingAddress
    {
        public ShippingAddress(string streetAddress1, string country, string postalCode) { }
        public Azure.ResourceManager.DataBox.Models.AddressType? AddressType { get { throw null; } set { } }
        public string City { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string StateOrProvince { get { throw null; } set { } }
        public string StreetAddress1 { get { throw null; } set { } }
        public string StreetAddress2 { get { throw null; } set { } }
        public string StreetAddress3 { get { throw null; } set { } }
        public string ZipExtendedCode { get { throw null; } set { } }
    }
    public partial class SkuAvailabilityValidationRequest : Azure.ResourceManager.DataBox.Models.ValidationInputRequest
    {
        public SkuAvailabilityValidationRequest(Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType, Azure.ResourceManager.DataBox.Models.TransferType transferType, string country, Azure.Core.AzureLocation location) { }
        public string Country { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName DeviceType { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.TransferType TransferType { get { throw null; } }
    }
    public partial class SkuAvailabilityValidationResponseProperties : Azure.ResourceManager.DataBox.Models.ValidationInputResponse
    {
        internal SkuAvailabilityValidationResponseProperties() { }
        public Azure.ResourceManager.DataBox.Models.ValidationStatus? Status { get { throw null; } }
    }
    public partial class SkuCapacity
    {
        internal SkuCapacity() { }
        public string Maximum { get { throw null; } }
        public string Usable { get { throw null; } }
    }
    public partial class SkuCost
    {
        internal SkuCost() { }
        public string MeterId { get { throw null; } }
        public string MeterType { get { throw null; } }
        public double? Multiplier { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StageName : System.IEquatable<Azure.ResourceManager.DataBox.Models.StageName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StageName(string value) { throw null; }
        public static Azure.ResourceManager.DataBox.Models.StageName Aborted { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName AtAzureDC { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName AwaitingShipmentDetails { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName Cancelled { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName Completed { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName CompletedWithErrors { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName CompletedWithWarnings { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName Created { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName DataCopy { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName Delivered { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName DeviceOrdered { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName DevicePrepared { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName Dispatched { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName FailedIssueDetectedAtAzureDC { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName FailedIssueReportedAtCustomer { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName PickedUp { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName PreparingToShipFromAzureDC { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName ReadyToDispatchFromAzureDC { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName ReadyToReceiveAtAzureDC { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName ShippedToAzureDC { get { throw null; } }
        public static Azure.ResourceManager.DataBox.Models.StageName ShippedToCustomer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBox.Models.StageName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBox.Models.StageName left, Azure.ResourceManager.DataBox.Models.StageName right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBox.Models.StageName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBox.Models.StageName left, Azure.ResourceManager.DataBox.Models.StageName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum StageStatus
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
    public partial class StorageAccountDetails : Azure.ResourceManager.DataBox.Models.DataAccountDetails
    {
        public StorageAccountDetails(string storageAccountId) { }
        public string StorageAccountId { get { throw null; } set { } }
    }
    public partial class SubscriptionIsAllowedToCreateJobValidationRequest : Azure.ResourceManager.DataBox.Models.ValidationInputRequest
    {
        public SubscriptionIsAllowedToCreateJobValidationRequest() { }
    }
    public partial class SubscriptionIsAllowedToCreateJobValidationResponseProperties : Azure.ResourceManager.DataBox.Models.ValidationInputResponse
    {
        internal SubscriptionIsAllowedToCreateJobValidationResponseProperties() { }
        public Azure.ResourceManager.DataBox.Models.ValidationStatus? Status { get { throw null; } }
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
    public enum TransferType
    {
        ImportToAzure = 0,
        ExportFromAzure = 1,
    }
    public partial class TransportAvailabilityDetails
    {
        internal TransportAvailabilityDetails() { }
        public Azure.ResourceManager.DataBox.Models.TransportShipmentType? ShipmentType { get { throw null; } }
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
        public Azure.ResourceManager.DataBox.Models.ContactDetails ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.KeyEncryptionKey KeyEncryptionKey { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.PackageCarrierDetails ReturnToCustomerPackageDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBox.Models.ShippingAddress ShippingAddress { get { throw null; } set { } }
    }
    public partial class ValidateAddress : Azure.ResourceManager.DataBox.Models.ValidationInputRequest
    {
        public ValidateAddress(Azure.ResourceManager.DataBox.Models.ShippingAddress shippingAddress, Azure.ResourceManager.DataBox.Models.DataBoxSkuName deviceType) { }
        public Azure.ResourceManager.DataBox.Models.DataBoxSkuName DeviceType { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.ShippingAddress ShippingAddress { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.TransportShipmentType? TransportPreferencesPreferredShipmentType { get { throw null; } set { } }
    }
    public partial class ValidationInputRequest
    {
        public ValidationInputRequest() { }
    }
    public partial class ValidationInputResponse
    {
        internal ValidationInputResponse() { }
        public Azure.ResponseError Error { get { throw null; } }
    }
    public partial class ValidationRequest
    {
        public ValidationRequest(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBox.Models.ValidationInputRequest> individualRequestDetails) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBox.Models.ValidationInputRequest> IndividualRequestDetails { get { throw null; } }
    }
    public partial class ValidationResponse
    {
        internal ValidationResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBox.Models.ValidationInputResponse> IndividualResponseDetails { get { throw null; } }
        public Azure.ResourceManager.DataBox.Models.OverallValidationStatus? Status { get { throw null; } }
    }
    public enum ValidationStatus
    {
        Valid = 0,
        Invalid = 1,
        Skipped = 2,
    }
}
