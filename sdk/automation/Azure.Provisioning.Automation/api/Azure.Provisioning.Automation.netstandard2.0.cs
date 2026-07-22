namespace Azure.Provisioning.Automation
{
    public partial class AutomationAccount : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationAccount(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Uri> AutomationHybridServiceUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationEncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPublicNetworkAccessAllowed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LastModifiedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Automation.AutomationPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.AutomationAccountState> State { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationAccount FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class AutomationAccountModule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationAccountModule(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> ActivityCount { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationContentLink ContentLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationModuleErrorInfo Error { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsComposite { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsGlobal { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.AutomationModuleProvisioningState> ModuleProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SizeInBytes { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationAccountModule FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class AutomationAccountPython2Package : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationAccountPython2Package(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> ActivityCount { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationContentLink ContentLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationModuleErrorInfo Error { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsComposite { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsGlobal { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.AutomationModuleProvisioningState> ModuleProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SizeInBytes { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationAccountPython2Package FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public enum AutomationAccountState
    {
        Ok = 0,
        Unavailable = 1,
        Suspended = 2,
    }
    public partial class AutomationAdvancedSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomationAdvancedSchedule() { }
        public Azure.Provisioning.BicepList<int> MonthDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Automation.AutomationAdvancedScheduleMonthlyOccurrence> MonthlyOccurrences { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> WeekDays { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutomationAdvancedScheduleMonthlyOccurrence : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomationAdvancedScheduleMonthlyOccurrence() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.AutomationDayOfWeek> Day { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Occurrence { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutomationCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationCertificate(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsExportable { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ThumbprintString { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationCertificate FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class AutomationConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ConnectionTypeName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> FieldDefinitionValues { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class AutomationConnectionFieldDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomationConnectionFieldDefinition() { }
        public Azure.Provisioning.BicepValue<string> FieldDefinitionType { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEncrypted { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsOptional { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutomationConnectionType : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationConnectionType(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Automation.AutomationConnectionFieldDefinition> FieldDefinitions { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsGlobal { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationConnectionType FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class AutomationContentHash : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomationContentHash() { }
        public Azure.Provisioning.BicepValue<string> Algorithm { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutomationContentLink : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomationContentLink() { }
        public Azure.Provisioning.Automation.AutomationContentHash ContentHash { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutomationContentSource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomationContentSource() { }
        public Azure.Provisioning.Automation.AutomationContentHash Hash { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.AutomationContentSourceType> SourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AutomationContentSourceType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="embeddedContent")]
        EmbeddedContent = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="uri")]
        Uri = 1,
    }
    public partial class AutomationCredential : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationCredential(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationCredential FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public enum AutomationDayOfWeek
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
    }
    public partial class AutomationEncryptionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomationEncryptionProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.EncryptionKeySourceType> KeySource { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> UserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutomationJob : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationJob(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Exception { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> JobId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastStatusModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.JobProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RunbookName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RunOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuntimeEnvironmentName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.AutomationJobStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StatusDetails { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationJob FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class AutomationJobSchedule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationJobSchedule(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> JobScheduleId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RunbookName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RunOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScheduleName { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationJobSchedule FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public enum AutomationJobStatus
    {
        New = 0,
        Activating = 1,
        Running = 2,
        Completed = 3,
        Failed = 4,
        Stopped = 5,
        Blocked = 6,
        Suspended = 7,
        Disconnected = 8,
        Suspending = 9,
        Stopping = 10,
        Resuming = 11,
        Removing = 12,
    }
    public partial class AutomationKeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomationKeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyvaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutomationModuleErrorInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomationModuleErrorInfo() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AutomationModuleProvisioningState
    {
        Created = 0,
        Creating = 1,
        StartingImportModuleRunbook = 2,
        RunningImportModuleRunbook = 3,
        ContentRetrieved = 4,
        ContentDownloaded = 5,
        ContentValidated = 6,
        ConnectionTypeImported = 7,
        ContentStored = 8,
        ModuleDataStored = 9,
        ActivitiesStored = 10,
        ModuleImportRunbookComplete = 11,
        Succeeded = 12,
        Failed = 13,
        Canceled = 14,
        Updating = 15,
    }
    public partial class AutomationPackage : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationPackage(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Automation.AutomationContentLink ContentLink { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationPackageErrorInfo Error { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDefault { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationRuntimeEnvironment Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.AutomationPackageProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData ResourceSystemData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SizeInBytes { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationPackage FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class AutomationPackageErrorInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomationPackageErrorInfo() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AutomationPackageProvisioningState
    {
        Created = 0,
        Creating = 1,
        StartingImportModuleRunbook = 2,
        RunningImportModuleRunbook = 3,
        ContentRetrieved = 4,
        ContentDownloaded = 5,
        ContentValidated = 6,
        ConnectionTypeImported = 7,
        ContentStored = 8,
        ModuleDataStored = 9,
        ActivitiesStored = 10,
        ModuleImportRunbookComplete = 11,
        Succeeded = 12,
        Failed = 13,
        Canceled = 14,
        Updating = 15,
    }
    public partial class AutomationPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Automation.AutomationPrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class AutomationPrivateLinkServiceConnectionStateProperty : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomationPrivateLinkServiceConnectionStateProperty() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutomationPython3Package : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationPython3Package(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> ActivityCount { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationContentLink ContentLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationModuleErrorInfo Error { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsComposite { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsGlobal { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.AutomationModuleProvisioningState> ModuleProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> SizeInBytes { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationPython3Package FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class AutomationResponseError : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomationResponseError() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutomationRunbook : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationRunbook(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationRunbookDraft Draft { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLogProgressEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLogVerboseEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> JobCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LastModifiedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> LogActivityTrace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> OutputTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Automation.RunbookParameterDefinition> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.RunbookProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationContentLink PublishContentLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.AutomationRunbookType> RunbookType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuntimeEnvironment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.RunbookState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationRunbook FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class AutomationRunbookDraft : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomationRunbookDraft() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationContentLink DraftContentLink { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsInEditMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> OutputTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Automation.RunbookParameterDefinition> Parameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AutomationRunbookType
    {
        Script = 0,
        Graph = 1,
        PowerShellWorkflow = 2,
        PowerShell = 3,
        GraphPowerShellWorkflow = 4,
        GraphPowerShell = 5,
        Python2 = 6,
        Python3 = 7,
        Python = 8,
        PowerShell72 = 9,
    }
    public partial class AutomationRuntimeEnvironment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationRuntimeEnvironment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepDictionary<string> DefaultPackages { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Language { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationRuntimeEnvironment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class AutomationSchedule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationSchedule(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Automation.AutomationAdvancedSchedule AdvancedSchedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> ExpireInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.AutomationScheduleFrequency> Frequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Interval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> NextRunInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NextRunOn { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> StartInMinutes { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TimeZone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationSchedule FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public enum AutomationScheduleFrequency
    {
        OneTime = 0,
        Day = 1,
        Hour = 2,
        Week = 3,
        Month = 4,
        Minute = 5,
    }
    public partial class AutomationSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomationSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.AutomationSkuName> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AutomationSkuName
    {
        Free = 0,
        Basic = 1,
    }
    public partial class AutomationSourceControl : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationSourceControl(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Branch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FolderPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAutoPublishRunbookEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAutoSyncEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> RepoUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.SourceControlSourceType> SourceType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationSourceControl FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class AutomationVariable : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationVariable(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEncrypted { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationVariable FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class AutomationWatcher : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationWatcher(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ExecutionFrequencyInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastModifiedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptName { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ScriptParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptRunOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationWatcher FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class AutomationWebhook : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AutomationWebhook(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastInvokedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LastModifiedBy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RunbookName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RunOn { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.AutomationWebhook FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class AzureQueryProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureQueryProperties() { }
        public Azure.Provisioning.BicepList<string> Locations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.Automation.QueryTagSettingsProperties TagSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectionTypeAssociationProperty : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectionTypeAssociationProperty() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DscConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DscConfiguration(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLogVerboseEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> JobCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NodeConfigurationCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Automation.DscConfigurationParameterDefinition> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.DscConfigurationProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationContentSource Source { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.DscConfigurationState> State { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.DscConfiguration FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class DscConfigurationAssociationProperty : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DscConfigurationAssociationProperty() { }
        public Azure.Provisioning.BicepValue<string> ConfigurationName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DscConfigurationParameterDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DscConfigurationParameterDefinition() { }
        public Azure.Provisioning.BicepValue<string> DefaultValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DscConfigurationParameterType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMandatory { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Position { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DscConfigurationProvisioningState
    {
        Succeeded = 0,
    }
    public enum DscConfigurationState
    {
        New = 0,
        Edit = 1,
        Published = 2,
    }
    public partial class DscNode : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DscNode(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AccountId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Automation.DscNodeExtensionHandlerAssociationProperty> ExtensionHandler { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastSeenOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NamePropertiesNodeConfigurationName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeId { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RegistrationOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> TotalCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.DscNode FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class DscNodeConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DscNodeConfiguration(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ConfigurationName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsIncrementNodeConfigurationBuildRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> NodeCount { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.DscNodeConfiguration FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class DscNodeExtensionHandlerAssociationProperty : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DscNodeExtensionHandlerAssociationProperty() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EncryptionKeySourceType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.Automation")]
        MicrosoftAutomation = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.Keyvault")]
        MicrosoftKeyvault = 1,
    }
    public partial class HybridRunbookWorker : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public HybridRunbookWorker(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastSeenOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Automation.HybridRunbookWorkerGroup Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RegisteredOn { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VmResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.HybridWorkerType> WorkerType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.HybridRunbookWorker FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public partial class HybridRunbookWorkerGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public HybridRunbookWorkerGroup(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> CredentialName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.HybridWorkerGroup> GroupType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.HybridRunbookWorkerGroup FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public enum HybridWorkerGroup
    {
        User = 0,
        System = 1,
    }
    public enum HybridWorkerType
    {
        HybridV1 = 0,
        HybridV2 = 1,
    }
    public enum JobProvisioningState
    {
        Failed = 0,
        Succeeded = 1,
        Suspended = 2,
        Processing = 3,
    }
    public enum LinuxUpdateClassification
    {
        Unclassified = 0,
        Critical = 1,
        Security = 2,
        Other = 3,
    }
    public partial class LinuxUpdateConfigurationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LinuxUpdateConfigurationProperties() { }
        public Azure.Provisioning.BicepList<string> ExcludedPackageNameMasks { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.LinuxUpdateClassification> IncludedPackageClassifications { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> IncludedPackageNameMasks { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RebootSetting { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NonAzureQueryProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NonAzureQueryProperties() { }
        public Azure.Provisioning.BicepValue<string> FunctionAlias { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum QueryTagOperator
    {
        All = 0,
        Any = 1,
    }
    public partial class QueryTagSettingsProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QueryTagSettingsProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.QueryTagOperator> FilterOperator { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.BicepList<string>> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RunbookParameterDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RunbookParameterDefinition() { }
        public Azure.Provisioning.BicepValue<string> DefaultValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsMandatory { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Position { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RunbookParameterType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RunbookProvisioningState
    {
        Succeeded = 0,
    }
    public enum RunbookState
    {
        New = 0,
        Edit = 1,
        Published = 2,
    }
    public partial class SoftwareUpdateConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SoftwareUpdateConfiguration(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> CreatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.Automation.AutomationResponseError Error { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastModifiedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Automation.AutomationAccount Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Automation.SoftwareUpdateConfigurationScheduleProperties ScheduleInfo { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.Automation.SoftwareUpdateConfigurationTasks Tasks { get { throw null; } set { } }
        public Azure.Provisioning.Automation.SoftwareUpdateConfigurationSpecificProperties UpdateConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Automation.SoftwareUpdateConfiguration FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_10_23;
        }
    }
    public enum SoftwareUpdateConfigurationOperatingSystemType
    {
        Windows = 0,
        Linux = 1,
    }
    public partial class SoftwareUpdateConfigurationScheduleProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SoftwareUpdateConfigurationScheduleProperties() { }
        public Azure.Provisioning.Automation.AutomationAdvancedSchedule AdvancedSchedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> ExpireInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.AutomationScheduleFrequency> Frequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> Interval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastModifiedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> NextRunInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NextRunOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> StartInMinutes { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeZone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SoftwareUpdateConfigurationSpecificProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SoftwareUpdateConfigurationSpecificProperties() { }
        public Azure.Provisioning.BicepList<string> AzureVirtualMachines { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } set { } }
        public Azure.Provisioning.Automation.LinuxUpdateConfigurationProperties Linux { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NonAzureComputerNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.SoftwareUpdateConfigurationOperatingSystemType> OperatingSystem { get { throw null; } set { } }
        public Azure.Provisioning.Automation.SoftwareUpdateConfigurationTargetProperties Targets { get { throw null; } set { } }
        public Azure.Provisioning.Automation.WindowsUpdateConfigurationProperties Windows { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SoftwareUpdateConfigurationTargetProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SoftwareUpdateConfigurationTargetProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Automation.AzureQueryProperties> AzureQueries { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Automation.NonAzureQueryProperties> NonAzureQueries { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SoftwareUpdateConfigurationTaskProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SoftwareUpdateConfigurationTaskProperties() { }
        public Azure.Provisioning.BicepDictionary<string> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SoftwareUpdateConfigurationTasks : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SoftwareUpdateConfigurationTasks() { }
        public Azure.Provisioning.Automation.SoftwareUpdateConfigurationTaskProperties PostTask { get { throw null; } set { } }
        public Azure.Provisioning.Automation.SoftwareUpdateConfigurationTaskProperties PreTask { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SourceControlSourceType
    {
        VsoGit = 0,
        VsoTfvc = 1,
        GitHub = 2,
    }
    public enum WindowsUpdateClassification
    {
        Unclassified = 0,
        Critical = 1,
        Security = 2,
        UpdateRollup = 3,
        FeaturePack = 4,
        ServicePack = 5,
        Definition = 6,
        Tools = 7,
        Updates = 8,
    }
    public partial class WindowsUpdateConfigurationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WindowsUpdateConfigurationProperties() { }
        public Azure.Provisioning.BicepList<string> ExcludedKBNumbers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> IncludedKBNumbers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Automation.WindowsUpdateClassification> IncludedUpdateClassifications { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RebootSetting { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
