namespace Azure.Provisioning.DataBox
{
    public partial class AzureFileFilterDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureFileFilterDetails() { }
        public Azure.Provisioning.BicepList<string> FilePathList { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> FilePrefixList { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> FileShareList { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BlobFilterDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BlobFilterDetails() { }
        public Azure.Provisioning.BicepList<string> BlobPathList { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> BlobPrefixList { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ContainerList { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContactInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContactInfo() { }
        public Azure.Provisioning.BicepValue<string> ContactName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Mobile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Phone { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PhoneExtension { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CopyLogDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CopyLogDetails() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CustomerResolutionCode
    {
        None = 0,
        MoveToCleanUpDevice = 1,
        Resume = 2,
        Restart = 3,
        ReachOutToOperation = 4,
    }
    public partial class DataAccountDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataAccountDetails() { }
        public Azure.Provisioning.BicepValue<string> SharePassword { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataAccountType
    {
        StorageAccount = 0,
        ManagedDisk = 1,
    }
    public partial class DataBoxAccountCopyLogDetails : Azure.Provisioning.DataBox.CopyLogDetails
    {
        public DataBoxAccountCopyLogDetails() { }
        public Azure.Provisioning.BicepValue<string> AccountName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CopyLogLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CopyVerboseLogLink { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataBoxBasicJobDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataBoxBasicJobDetails() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataBox.CustomerResolutionCode> Actions { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ChainOfCustodySasKey { get { throw null; } }
        public Azure.Provisioning.DataBox.DataBoxContactDetails ContactDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataBox.CopyLogDetails> CopyLogDetails { get { throw null; } }
        public Azure.Provisioning.DataBox.DataCenterAddressResult DataCenterAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataCenterCode> DataCenterCode { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataBox.DataExportDetails> DataExportDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataBox.DataImportDetails> DataImportDetails { get { throw null; } set { } }
        public Azure.Provisioning.DataBox.PackageShippingDetails DeliveryPackage { get { throw null; } }
        public Azure.Provisioning.DataBox.DeviceErasureDetails DeviceErasureDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ExpectedDataSizeInTerabytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataBox.DataBoxJobStage> JobStages { get { throw null; } }
        public Azure.Provisioning.DataBox.DataBoxKeyEncryptionKey KeyEncryptionKey { get { throw null; } set { } }
        public Azure.Provisioning.DataBox.LastMitigationActionOnJob LastMitigationActionOnJob { get { throw null; } }
        public Azure.Provisioning.DataBox.DataBoxOrderPreferences Preferences { get { throw null; } set { } }
        public Azure.Provisioning.DataBox.PackageShippingDetails ReturnPackage { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReverseShipmentLabelSasKey { get { throw null; } }
        public Azure.Provisioning.DataBox.ReverseShippingDetails ReverseShippingDetails { get { throw null; } set { } }
        public Azure.Provisioning.DataBox.DataBoxShippingAddress ShippingAddress { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataBoxContactDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataBoxContactDetails() { }
        public Azure.Provisioning.BicepValue<string> ContactName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EmailList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Mobile { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataBox.NotificationPreference> NotificationPreference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Phone { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PhoneExtension { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataBoxCopyProgress : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataBoxCopyProgress() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AccountId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataBox.CustomerResolutionCode> Actions { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> BytesProcessed { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataAccountType> DataAccountType { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> DirectoriesErroredOut { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> Error { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> FilesErroredOut { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> FilesProcessed { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> InvalidDirectoriesProcessed { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> InvalidFileBytesUploaded { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> InvalidFilesProcessed { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnumerationInProgress { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> RenamedContainerCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StorageAccountName { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TotalBytesToProcess { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TotalFilesToProcess { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataBoxJobTransferType> TransferType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataBoxCopyStatus
    {
        NotStarted = 0,
        InProgress = 1,
        Completed = 2,
        CompletedWithErrors = 3,
        Failed = 4,
        NotReturned = 5,
        HardwareError = 6,
        DeviceFormatted = 7,
        DeviceMetadataModified = 8,
        StorageAccountNotAccessible = 9,
        UnsupportedData = 10,
        DriveNotReceived = 11,
        UnsupportedDrive = 12,
        OtherServiceError = 13,
        OtherUserError = 14,
        DriveNotDetected = 15,
        DriveCorrupted = 16,
        MetadataFilesModifiedOrRemoved = 17,
    }
    public partial class DataBoxCustomerDiskCopyLogDetails : Azure.Provisioning.DataBox.CopyLogDetails
    {
        public DataBoxCustomerDiskCopyLogDetails() { }
        public Azure.Provisioning.BicepValue<string> ErrorLogLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SerialNumber { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VerboseLogLink { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataBoxCustomerDiskCopyProgress : Azure.Provisioning.DataBox.DataBoxCopyProgress
    {
        public DataBoxCustomerDiskCopyProgress() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataBoxCopyStatus> CopyStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SerialNumber { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataBoxCustomerDiskJobDetails : Azure.Provisioning.DataBox.DataBoxBasicJobDetails
    {
        public DataBoxCustomerDiskJobDetails() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataBox.DataBoxCustomerDiskCopyProgress> CopyProgress { get { throw null; } }
        public Azure.Provisioning.DataBox.PackageCarrierInfo DeliverToDataCenterPackageDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> EnableManifestBackup { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.DataBox.ExportDiskDetails> ExportDiskDetails { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.DataBox.ImportDiskDetails> ImportDiskDetails { get { throw null; } set { } }
        public Azure.Provisioning.DataBox.PackageCarrierDetails ReturnToCustomerPackageDetails { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataBoxDiskCopyLogDetails : Azure.Provisioning.DataBox.CopyLogDetails
    {
        public DataBoxDiskCopyLogDetails() { }
        public Azure.Provisioning.BicepValue<string> DiskSerialNumber { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ErrorLogLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VerboseLogLink { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataBoxDiskCopyProgress : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataBoxDiskCopyProgress() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataBox.CustomerResolutionCode> Actions { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> BytesCopied { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> Error { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PercentComplete { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SerialNumber { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataBoxCopyStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataBoxDiskGranularCopyLogDetails : Azure.Provisioning.DataBox.GranularCopyLogDetails
    {
        public DataBoxDiskGranularCopyLogDetails() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AccountId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ErrorLogLink { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SerialNumber { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VerboseLogLink { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataBoxDiskGranularCopyProgress : Azure.Provisioning.DataBox.GranularCopyProgress
    {
        public DataBoxDiskGranularCopyProgress() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataBoxCopyStatus> CopyStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SerialNumber { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataBoxDiskJobDetails : Azure.Provisioning.DataBox.DataBoxBasicJobDetails
    {
        public DataBoxDiskJobDetails() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataBox.DataBoxDiskCopyProgress> CopyProgress { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<int> DisksAndSizeDetails { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataBox.DataBoxDiskGranularCopyLogDetails> GranularCopyLogDetails { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataBox.DataBoxDiskGranularCopyProgress> GranularCopyProgress { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Passkey { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<int> PreferredDisks { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataBoxDoubleEncryption
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DataBoxEncryptionPreferences : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataBoxEncryptionPreferences() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataBoxDoubleEncryption> DoubleEncryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.HardwareEncryption> HardwareEncryption { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataBoxHeavyAccountCopyLogDetails : Azure.Provisioning.DataBox.CopyLogDetails
    {
        public DataBoxHeavyAccountCopyLogDetails() { }
        public Azure.Provisioning.BicepValue<string> AccountName { get { throw null; } }
        public Azure.Provisioning.BicepList<string> CopyLogLink { get { throw null; } }
        public Azure.Provisioning.BicepList<string> CopyVerboseLogLink { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataBoxHeavyJobDetails : Azure.Provisioning.DataBox.DataBoxBasicJobDetails
    {
        public DataBoxHeavyJobDetails() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataBox.DataBoxCopyProgress> CopyProgress { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DevicePassword { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataBoxJob : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataBoxJob(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AreAllDevicesLost { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CancellationReason { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataBoxStageName> DelayedStage { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DeliveryInfoScheduledOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.JobDeliveryType> DeliveryType { get { throw null; } set { } }
        public Azure.Provisioning.DataBox.DataBoxBasicJobDetails Details { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> Error { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCancellable { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsCancellableWithoutFee { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDeletable { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsPrepareToShipEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsShippingAddressEditable { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.ReverseShippingDetailsEditStatus> ReverseShippingDetailsUpdate { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.ReverseTransportPreferenceEditStatus> ReverseTransportPreferenceUpdate { get { throw null; } }
        public Azure.Provisioning.DataBox.DataBoxSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataBoxStageName> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataBoxJobTransferType> TransferType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DataBox.DataBoxJob FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_07_01;
        }
    }
    public partial class DataBoxJobDetails : Azure.Provisioning.DataBox.DataBoxBasicJobDetails
    {
        public DataBoxJobDetails() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataBox.DataBoxCopyProgress> CopyProgress { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DevicePassword { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataBoxJobStage : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataBoxJobStage() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataBox.JobDelayDetails> DelayInformation { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> JobStageDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataBoxStageName> StageName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StageOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataBoxStageStatus> StageStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataBoxJobTransferType
    {
        ImportToAzure = 0,
        ExportFromAzure = 1,
    }
    public partial class DataBoxKeyEncryptionKey : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataBoxKeyEncryptionKey() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataBoxKeyEncryptionKeyType> KekType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KekUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> KekVaultResourceId { get { throw null; } set { } }
        public Azure.Provisioning.DataBox.DataBoxManagedIdentity ManagedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataBoxKeyEncryptionKeyType
    {
        MicrosoftManaged = 0,
        CustomerManaged = 1,
    }
    public partial class DataBoxManagedIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataBoxManagedIdentity() { }
        public Azure.Provisioning.BicepValue<string> IdentityType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UserAssignedResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataBoxOrderPreferences : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataBoxOrderPreferences() { }
        public Azure.Provisioning.DataBox.DataBoxEncryptionPreferences EncryptionPreferences { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PreferredDataCenterRegion { get { throw null; } set { } }
        public Azure.Provisioning.DataBox.TransportPreferences ReverseTransportPreferences { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> StorageAccountAccessTierPreferences { get { throw null; } set { } }
        public Azure.Provisioning.DataBox.TransportPreferences TransportPreferences { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataBoxShippingAddress : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataBoxShippingAddress() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataBoxShippingAddressType> AddressType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> City { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CompanyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Country { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PostalCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SkipAddressValidation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StateOrProvince { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StreetAddress1 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StreetAddress2 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StreetAddress3 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TaxIdentificationNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ZipExtendedCode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataBoxShippingAddressType
    {
        None = 0,
        Residential = 1,
        Commercial = 2,
    }
    public partial class DataBoxSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataBoxSku() { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DeviceModelName> Model { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataBoxSkuName> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataBoxSkuName
    {
        DataBox = 0,
        DataBoxDisk = 1,
        DataBoxHeavy = 2,
        DataBoxCustomerDisk = 3,
    }
    public enum DataBoxStageName
    {
        DeviceOrdered = 0,
        DevicePrepared = 1,
        Dispatched = 2,
        Delivered = 3,
        PickedUp = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AtAzureDC")]
        AtAzureDataCenter = 5,
        DataCopy = 6,
        Completed = 7,
        CompletedWithErrors = 8,
        Cancelled = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Failed_IssueReportedAtCustomer")]
        FailedIssueReportedAtCustomer = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Failed_IssueDetectedAtAzureDC")]
        FailedIssueDetectedAtAzureDataCenter = 11,
        Aborted = 12,
        CompletedWithWarnings = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ReadyToDispatchFromAzureDC")]
        ReadyToDispatchFromAzureDataCenter = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ReadyToReceiveAtAzureDC")]
        ReadyToReceiveAtAzureDataCenter = 15,
        Created = 16,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ShippedToAzureDC")]
        ShippedToAzureDataCenter = 17,
        AwaitingShipmentDetails = 18,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PreparingToShipFromAzureDC")]
        PreparingToShipFromAzureDataCenter = 19,
        ShippedToCustomer = 20,
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
    public partial class DataBoxStorageAccountDetails : Azure.Provisioning.DataBox.DataAccountDetails
    {
        public DataBoxStorageAccountDetails() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageAccountId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCenterAddressInstructionResult : Azure.Provisioning.DataBox.DataCenterAddressResult
    {
        public DataCenterAddressInstructionResult() { }
        public Azure.Provisioning.BicepValue<string> CommunicationInstruction { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCenterAddressLocationResult : Azure.Provisioning.DataBox.DataCenterAddressResult
    {
        public DataCenterAddressLocationResult() { }
        public Azure.Provisioning.BicepValue<string> AdditionalShippingInformation { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> AddressType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> City { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Company { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ContactPersonName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Country { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Phone { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PhoneExtension { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Street1 { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Street2 { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Street3 { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Zip { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCenterAddressResult : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCenterAddressResult() { }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> DataCenterAzureLocation { get { throw null; } }
        public Azure.Provisioning.BicepList<string> SupportedCarriersForReturnShipment { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataCenterCode
    {
        Invalid = 0,
        BY2 = 1,
        BY1 = 2,
        ORK70 = 3,
        AM2 = 4,
        AMS20 = 5,
        BY21 = 6,
        BY24 = 7,
        MWH01 = 8,
        AMS06 = 9,
        SSE90 = 10,
        SYD03 = 11,
        SYD23 = 12,
        CBR20 = 13,
        YTO20 = 14,
        CWL20 = 15,
        LON24 = 16,
        BOM01 = 17,
        BL20 = 18,
        BL7 = 19,
        SEL20 = 20,
        TYO01 = 21,
        BN1 = 22,
        SN5 = 23,
        CYS04 = 24,
        TYO22 = 25,
        YTO21 = 26,
        YQB20 = 27,
        FRA22 = 28,
        MAA01 = 29,
        CPQ02 = 30,
        CPQ20 = 31,
        SIN20 = 32,
        HKG20 = 33,
        SG2 = 34,
        MEL23 = 35,
        SEL21 = 36,
        OSA20 = 37,
        SHA03 = 38,
        BJB = 39,
        JNB22 = 40,
        JNB21 = 41,
        MNZ21 = 42,
        SN8 = 43,
        AUH20 = 44,
        ZRH20 = 45,
        PUS20 = 46,
        AdHoc = 47,
        CH1 = 48,
        DSM05 = 49,
        DUB07 = 50,
        PNQ01 = 51,
        SVG20 = 52,
        OSA02 = 53,
        OSA22 = 54,
        PAR22 = 55,
        BN7 = 56,
        SN6 = 57,
        BJS20 = 58,
        BL24 = 59,
        IDC5 = 60,
        TYO23 = 61,
        NTG20 = 62,
        DXB23 = 63,
        DSM11 = 64,
        AMS25 = 65,
        CPQ21 = 66,
        OSA23 = 67,
    }
    public partial class DataExportDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataExportDetails() { }
        public Azure.Provisioning.DataBox.DataAccountDetails AccountDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.LogCollectionLevel> LogCollectionLevel { get { throw null; } set { } }
        public Azure.Provisioning.DataBox.TransferConfiguration TransferConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataImportDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataImportDetails() { }
        public Azure.Provisioning.DataBox.DataAccountDetails AccountDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.LogCollectionLevel> LogCollectionLevel { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DelayNotificationStatus
    {
        Active = 0,
        Resolved = 1,
    }
    public partial class DeviceErasureDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeviceErasureDetails() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataBoxStageStatus> DeviceErasureStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ErasureOrDestructionCertificateSasKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecureErasureCertificateSasKey { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class ExportDiskDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExportDiskDetails() { }
        public Azure.Provisioning.BicepValue<string> BackupManifestCloudPath { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ManifestFile { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ManifestHash { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FilterFileDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FilterFileDetails() { }
        public Azure.Provisioning.BicepValue<string> FilterFilePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.FilterFileType> FilterFileType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FilterFileType
    {
        AzureBlob = 0,
        AzureFile = 1,
    }
    public partial class GranularCopyLogDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GranularCopyLogDetails() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GranularCopyProgress : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GranularCopyProgress() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AccountId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataBox.CustomerResolutionCode> Actions { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> BytesProcessed { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataAccountType> DataAccountType { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> DirectoriesErroredOut { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> Error { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> FilesErroredOut { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> FilesProcessed { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> InvalidDirectoriesProcessed { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> InvalidFileBytesUploaded { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> InvalidFilesProcessed { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnumerationInProgress { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> RenamedContainerCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StorageAccountName { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TotalBytesToProcess { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> TotalFilesToProcess { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataBoxJobTransferType> TransferType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HardwareEncryption
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ImportDiskDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImportDiskDetails() { }
        public Azure.Provisioning.BicepValue<string> BackupManifestCloudPath { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BitLockerKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManifestFile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManifestHash { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JobDelayDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JobDelayDetails() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.PortalDelayErrorCode> ErrorCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ResolutionOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DelayNotificationStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum JobDeliveryType
    {
        NonScheduled = 0,
        Scheduled = 1,
    }
    public partial class LastMitigationActionOnJob : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LastMitigationActionOnJob() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ActionPerformedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.CustomerResolutionCode> CustomerResolution { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsPerformedByCustomer { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LogCollectionLevel
    {
        Error = 0,
        Verbose = 1,
    }
    public partial class ManagedDiskDetails : Azure.Provisioning.DataBox.DataAccountDetails
    {
        public ManagedDiskDetails() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceGroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StagingStorageAccountId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NotificationPreference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NotificationPreference() { }
        public Azure.Provisioning.BicepValue<bool> SendNotification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.NotificationStageName> StageName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NotificationStageName
    {
        DevicePrepared = 0,
        Dispatched = 1,
        Delivered = 2,
        PickedUp = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AtAzureDC")]
        AtAzureDataCenter = 4,
        DataCopy = 5,
        Created = 6,
        ShippedToCustomer = 7,
    }
    public partial class PackageCarrierDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PackageCarrierDetails() { }
        public Azure.Provisioning.BicepValue<string> CarrierAccountNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CarrierName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TrackingId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PackageCarrierInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PackageCarrierInfo() { }
        public Azure.Provisioning.BicepValue<string> CarrierName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TrackingId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PackageShippingDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PackageShippingDetails() { }
        public Azure.Provisioning.BicepValue<string> CarrierName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TrackingId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> TrackingUri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PortalDelayErrorCode
    {
        InternalIssueDelay = 0,
        ActiveOrderLimitBreachedDelay = 1,
        HighDemandDelay = 2,
        LargeNumberOfFilesDelay = 3,
    }
    public partial class ReverseShippingDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReverseShippingDetails() { }
        public Azure.Provisioning.DataBox.ContactInfo ContactDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsUpdated { get { throw null; } }
        public Azure.Provisioning.DataBox.DataBoxShippingAddress ShippingAddress { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class TransferAllDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TransferAllDetails() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataAccountType> DataAccountType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TransferAllBlobs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TransferAllFiles { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TransferConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TransferConfiguration() { }
        public Azure.Provisioning.DataBox.TransferAllDetails TransferAllDetailsInclude { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.TransferConfigurationType> TransferConfigurationType { get { throw null; } set { } }
        public Azure.Provisioning.DataBox.TransferFilterDetails TransferFilterDetailsInclude { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum TransferConfigurationType
    {
        TransferAll = 0,
        TransferUsingFilter = 1,
    }
    public partial class TransferFilterDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TransferFilterDetails() { }
        public Azure.Provisioning.DataBox.AzureFileFilterDetails AzureFileFilterDetails { get { throw null; } set { } }
        public Azure.Provisioning.DataBox.BlobFilterDetails BlobFilterDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.DataAccountType> DataAccountType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataBox.FilterFileDetails> FilterFileDetails { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TransportPreferences : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TransportPreferences() { }
        public Azure.Provisioning.BicepValue<bool> IsUpdated { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataBox.TransportShipmentType> PreferredShipmentType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum TransportShipmentType
    {
        CustomerManaged = 0,
        MicrosoftManaged = 1,
    }
}
