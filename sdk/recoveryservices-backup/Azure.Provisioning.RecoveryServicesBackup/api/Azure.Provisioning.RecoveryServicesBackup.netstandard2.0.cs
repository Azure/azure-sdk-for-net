namespace Azure.Provisioning.RecoveryServicesBackup
{
    public enum AcquireStorageAccountLock
    {
        Acquire = 0,
        NotAcquire = 1,
    }
    public partial class BackupCommonSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupCommonSettings() { }
        public Azure.Provisioning.BicepValue<bool> IsCompression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSqlCompression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeZone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BackupCreateMode
    {
        Invalid = 0,
        Default = 1,
        Recover = 2,
    }
    public enum BackupDataSourceType
    {
        Invalid = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VM")]
        Vm = 1,
        FileFolder = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzureSqlDb")]
        AzureSqlDB = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQLDB")]
        SqlDB = 4,
        Exchange = 5,
        Sharepoint = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VMwareVM")]
        VMwareVm = 7,
        SystemState = 8,
        Client = 9,
        GenericDataSource = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQLDataBase")]
        SqlDatabase = 11,
        AzureFileShare = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SAPHanaDatabase")]
        SapHanaDatabase = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SAPAseDatabase")]
        SapAseDatabase = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SAPHanaDBInstance")]
        SapHanaDBInstance = 15,
    }
    public partial class BackupDay : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupDay() { }
        public Azure.Provisioning.BicepValue<int> Date { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsLast { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BackupDayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    public enum BackupEncryptionAtRestType
    {
        Invalid = 0,
        MicrosoftManaged = 1,
        CustomerManaged = 2,
    }
    public partial class BackupEngine : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BackupEngine() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupGenericEngine Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RecoveryServicesBackup.BackupEngine FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01;
            public static readonly string V2025_08_01;
            public static readonly string V2026_01_01;
        }
    }
    public partial class BackupEngineExtendedInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupEngineExtendedInfo() { }
        public Azure.Provisioning.BicepValue<double> AvailableDiskSpace { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> AzureProtectedInstances { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> DiskCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ProtectedItemsCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ProtectedServersCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RefreshedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<double> UsedDiskSpace { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackupErrorDetail : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupErrorDetail() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Recommendations { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackupGenericEngine : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupGenericEngine() { }
        public Azure.Provisioning.BicepValue<string> AzureBackupAgentVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BackupEngineId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BackupEngineState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupManagementType> BackupManagementType { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> CanReRegister { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DpmVersion { get { throw null; } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupEngineExtendedInfo ExtendedInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> HealthStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAzureBackupAgentUpgradeAvailable { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsDpmUpgradeAvailable { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RegistrationStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackupGenericJob : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupGenericJob() { }
        public Azure.Provisioning.BicepValue<string> ActivityId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupManagementType> BackupManagementType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EntityFriendlyName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Operation { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackupGenericProtectedItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupGenericProtectedItem() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupManagementType> BackupManagementType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BackupSetName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupCreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DeferredDeletedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DeferredDeleteTimeRemaining { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchiveEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDeferredDeleteScheduleUpcoming { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsRehydrate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsScheduledForDeferredDelete { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastRecoverOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PolicyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ResourceGuardOperationRequests { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SoftDeleteRetentionPeriodInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VaultId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupDataSourceType> WorkloadType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackupGenericProtectionContainer : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupGenericProtectionContainer() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupManagementType> BackupManagementType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HealthStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProtectableObjectType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RegistrationStatus { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackupGenericProtectionIntent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupGenericProtectionIntent() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupManagementType> BackupManagementType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ItemId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PolicyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupProtectionStatus> ProtectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackupGenericProtectionPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupGenericProtectionPolicy() { }
        public Azure.Provisioning.BicepValue<int> ProtectedItemsCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ResourceGuardOperationRequests { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackupGenericRecoveryPoint : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupGenericRecoveryPoint() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackupHourlySchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupHourlySchedule() { }
        public Azure.Provisioning.BicepValue<int> Interval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ScheduleWindowDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ScheduleWindowStartsOn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BackupItemType
    {
        Invalid = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VM")]
        Vm = 1,
        FileFolder = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzureSqlDb")]
        AzureSqlDB = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQLDB")]
        SqlDB = 4,
        Exchange = 5,
        Sharepoint = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VMwareVM")]
        VMwareVm = 7,
        SystemState = 8,
        Client = 9,
        GenericDataSource = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQLDataBase")]
        SqlDatabase = 11,
        AzureFileShare = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SAPHanaDatabase")]
        SapHanaDatabase = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SAPAseDatabase")]
        SapAseDatabase = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SAPHanaDBInstance")]
        SapHanaDBInstance = 15,
    }
    public partial class BackupJob : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BackupJob() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupGenericJob Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RecoveryServicesBackup.BackupJob FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01;
            public static readonly string V2025_08_01;
            public static readonly string V2026_01_01;
        }
    }
    public enum BackupManagementType
    {
        Invalid = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzureIaasVM")]
        AzureIaasVm = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MAB")]
        Mab = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DPM")]
        Dpm = 3,
        AzureBackupServer = 4,
        AzureSql = 5,
        AzureStorage = 6,
        AzureWorkload = 7,
        DefaultBackup = 8,
    }
    public enum BackupMonthOfYear
    {
        Invalid = 0,
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12,
    }
    public partial class BackupPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BackupPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RecoveryServicesBackup.BackupPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01;
            public static readonly string V2025_08_01;
            public static readonly string V2026_01_01;
        }
    }
    public partial class BackupPrivateEndpointConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupPrivateEndpointConnectionProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.VaultSubResourceType> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.RecoveryServicesBackupPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BackupPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Deleting = 1,
        Failed = 2,
        Pending = 3,
    }
    public partial class BackupProtectedItem : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BackupProtectedItem(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupProtectionContainer Parent { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectedItem Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RecoveryServicesBackup.BackupProtectedItem FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01;
            public static readonly string V2025_08_01;
            public static readonly string V2026_01_01;
        }
    }
    public partial class BackupProtectionContainer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BackupProtectionContainer(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionContainer Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RecoveryServicesBackup.BackupProtectionContainer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01;
            public static readonly string V2025_08_01;
            public static readonly string V2026_01_01;
        }
    }
    public partial class BackupProtectionIntent : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BackupProtectionIntent(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionIntent Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RecoveryServicesBackup.BackupProtectionIntent FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01;
            public static readonly string V2025_08_01;
            public static readonly string V2026_01_01;
        }
    }
    public partial class BackupProtectionPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BackupProtectionPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionPolicy Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RecoveryServicesBackup.BackupProtectionPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01;
            public static readonly string V2025_08_01;
            public static readonly string V2026_01_01;
        }
    }
    public enum BackupProtectionState
    {
        Invalid = 0,
        IRPending = 1,
        Protected = 2,
        ProtectionError = 3,
        ProtectionStopped = 4,
        ProtectionPaused = 5,
        BackupsSuspended = 6,
    }
    public enum BackupProtectionStatus
    {
        Invalid = 0,
        NotProtected = 1,
        Protecting = 2,
        Protected = 3,
        ProtectionFailed = 4,
    }
    public partial class BackupRecoveryPoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal BackupRecoveryPoint() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupProtectedItem Parent { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupGenericRecoveryPoint Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RecoveryServicesBackup.BackupRecoveryPoint FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01;
            public static readonly string V2025_08_01;
            public static readonly string V2026_01_01;
        }
    }
    public partial class BackupResourceConfig : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BackupResourceConfig(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupResourceConfigProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RecoveryServicesBackup.BackupResourceConfig FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01;
            public static readonly string V2025_08_01;
            public static readonly string V2026_01_01;
        }
    }
    public partial class BackupResourceConfigProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupResourceConfigProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.VaultDedupState> DedupState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableCrossRegionRestore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupStorageType> StorageModelType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupStorageType> StorageType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupStorageTypeState> StorageTypeState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.VaultXcoolState> XcoolState { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackupResourceEncryptionConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupResourceEncryptionConfig() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupEncryptionAtRestType> EncryptionAtRestType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.InfrastructureEncryptionState> InfrastructureEncryptionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.LastUpdateStatus> LastUpdateStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackupResourceEncryptionConfigExtended : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BackupResourceEncryptionConfigExtended(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RecoveryServicesBackup.BackupResourceEncryptionConfigExtended FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01;
            public static readonly string V2025_08_01;
            public static readonly string V2026_01_01;
        }
    }
    public partial class BackupResourceEncryptionConfigExtendedProperties : Azure.Provisioning.RecoveryServicesBackup.BackupResourceEncryptionConfig
    {
        public BackupResourceEncryptionConfigExtendedProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> UserAssignedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseSystemAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackupResourceVaultConfig : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BackupResourceVaultConfig(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupResourceVaultConfigProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RecoveryServicesBackup.BackupResourceVaultConfig FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01;
            public static readonly string V2025_08_01;
            public static readonly string V2026_01_01;
        }
    }
    public partial class BackupResourceVaultConfigProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupResourceVaultConfigProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.EnhancedSecurityState> EnhancedSecurityState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSoftDeleteFeatureStateEditable { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ResourceGuardOperationRequests { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.SoftDeleteFeatureState> SoftDeleteFeatureState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SoftDeleteRetentionPeriodInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupStorageType> StorageModelType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupStorageType> StorageType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupStorageTypeState> StorageTypeState { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackupRetentionPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupRetentionPolicy() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackupSchedulePolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupSchedulePolicy() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackupServerContainer : Azure.Provisioning.RecoveryServicesBackup.DpmContainer
    {
        public BackupServerContainer() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackupServerEngine : Azure.Provisioning.RecoveryServicesBackup.BackupGenericEngine
    {
        public BackupServerEngine() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BackupStorageType
    {
        Invalid = 0,
        GeoRedundant = 1,
        LocallyRedundant = 2,
        ZoneRedundant = 3,
        ReadAccessGeoZoneRedundant = 4,
    }
    public enum BackupStorageTypeState
    {
        Invalid = 0,
        Locked = 1,
        Unlocked = 2,
    }
    public partial class BackupTieringPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupTieringPolicy() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.RetentionDurationType> DurationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DurationValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.TieringMode> TieringMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackupWeeklySchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackupWeeklySchedule() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.BackupDayOfWeek> ScheduleRunDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.DateTimeOffset> ScheduleRunTimes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BackupWeekOfMonth
    {
        First = 0,
        Second = 1,
        Third = 2,
        Fourth = 3,
        Last = 4,
        Invalid = 5,
    }
    public enum BackupWorkloadType
    {
        Invalid = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VM")]
        Vm = 1,
        FileFolder = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzureSqlDb")]
        AzureSqlDB = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQLDB")]
        SqlDB = 4,
        Exchange = 5,
        Sharepoint = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VMwareVM")]
        VMwareVm = 7,
        SystemState = 8,
        Client = 9,
        GenericDataSource = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQLDataBase")]
        SqlDatabase = 11,
        AzureFileShare = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SAPHanaDatabase")]
        SapHanaDatabase = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SAPAseDatabase")]
        SapAseDatabase = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SAPHanaDBInstance")]
        SapHanaDBInstance = 15,
    }
    public partial class BekDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BekDetails() { }
        public Azure.Provisioning.BicepValue<string> SecretData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> SecretUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SecretVaultId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerIdentityInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerIdentityInfo() { }
        public Azure.Provisioning.BicepValue<System.Guid> AadTenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Audience { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UniqueName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DailyRetentionSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DailyRetentionSchedule() { }
        public Azure.Provisioning.RecoveryServicesBackup.RetentionDuration RetentionDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.DateTimeOffset> RetentionTimes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DiskExclusionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiskExclusionProperties() { }
        public Azure.Provisioning.BicepList<int> DiskLunList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsInclusionList { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DiskInformation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiskInformation() { }
        public Azure.Provisioning.BicepValue<int> Lun { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DistributedNodesInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DistributedNodesInfo() { }
        public Azure.Provisioning.RecoveryServicesBackup.BackupErrorDetail ErrorDetail { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DpmBackupEngine : Azure.Provisioning.RecoveryServicesBackup.BackupGenericEngine
    {
        public DpmBackupEngine() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DpmBackupJob : Azure.Provisioning.RecoveryServicesBackup.BackupGenericJob
    {
        public DpmBackupJob() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.JobSupportedAction> ActionsInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ContainerType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DpmServerName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.DpmErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.Provisioning.RecoveryServicesBackup.DpmBackupJobExtendedInfo ExtendedInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> WorkloadType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DpmBackupJobExtendedInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DpmBackupJobExtendedInfo() { }
        public Azure.Provisioning.BicepValue<string> DynamicErrorMessage { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> PropertyBag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.DpmBackupJobTaskDetails> TasksList { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DpmBackupJobTaskDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DpmBackupJobTaskDetails() { }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TaskId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DpmContainer : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionContainer
    {
        public DpmContainer() { }
        public Azure.Provisioning.BicepValue<bool> CanReRegister { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DpmAgentVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DpmServers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExtendedInfoLastRefreshedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsUpgradeAvailable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ProtectedItemCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProtectionStatus { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DpmErrorInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DpmErrorInfo() { }
        public Azure.Provisioning.BicepValue<string> ErrorString { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Recommendations { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DpmProtectedItem : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectedItem
    {
        public DpmProtectedItem() { }
        public Azure.Provisioning.BicepValue<string> BackupEngineName { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.DpmProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.ProtectedItemState> ProtectionState { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DpmProtectedItemExtendedInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DpmProtectedItemExtendedInfo() { }
        public Azure.Provisioning.BicepValue<string> DiskStorageUsedInBytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCollocated { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPresentOnCloud { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsProtected { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LastBackupStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastRefreshedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> OldestRecoverOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> OnPremiseLatestRecoverOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> OnPremiseOldestRecoverOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> OnPremiseRecoveryPointCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ProtectableObjectLoadPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProtectionGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RecoveryPointCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TotalDiskStorageSizeInBytes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EnhancedSecurityState
    {
        Invalid = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public partial class FileshareProtectedItem : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectedItem
    {
        public FileshareProtectedItem() { }
        public Azure.Provisioning.RecoveryServicesBackup.FileshareProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.RecoveryServicesBackup.KpiResourceHealthDetails> KpisHealths { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastBackupOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LastBackupStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupProtectionState> ProtectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProtectionStatus { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FileshareProtectedItemExtendedInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FileshareProtectedItemExtendedInfo() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> OldestRecoverOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RecoveryPointCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ResourceStateSyncOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FileShareProtectionPolicy : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionPolicy
    {
        public FileShareProtectionPolicy() { }
        public Azure.Provisioning.RecoveryServicesBackup.BackupRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupSchedulePolicy SchedulePolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeZone { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.VaultRetentionPolicy VaultRetentionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupWorkloadType> WorkLoadType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FileShareRecoveryPoint : Azure.Provisioning.RecoveryServicesBackup.BackupGenericRecoveryPoint
    {
        public FileShareRecoveryPoint() { }
        public Azure.Provisioning.BicepValue<System.Uri> FileShareSnapshotUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RecoveryPointOn { get { throw null; } }
        public Azure.Provisioning.RecoveryServicesBackup.RecoveryPointProperties RecoveryPointProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> RecoveryPointSizeInGB { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.RecoveryPointTierInformation> RecoveryPointTierDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RecoveryPointType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GenericContainer : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionContainer
    {
        public GenericContainer() { }
        public Azure.Provisioning.RecoveryServicesBackup.GenericContainerExtendedInfo ExtendedInformation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FabricName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GenericContainerExtendedInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GenericContainerExtendedInfo() { }
        public Azure.Provisioning.RecoveryServicesBackup.ContainerIdentityInfo ContainerIdentityInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RawCertData { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ServiceEndpoints { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GenericProtectedItem : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectedItem
    {
        public GenericProtectedItem() { }
        public Azure.Provisioning.BicepValue<string> FabricName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ProtectedItemId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupProtectionState> ProtectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> SourceAssociations { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GenericProtectionPolicy : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionPolicy
    {
        public GenericProtectionPolicy() { }
        public Azure.Provisioning.BicepValue<string> FabricName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.SubProtectionPolicy> SubProtectionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeZone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GenericRecoveryPoint : Azure.Provisioning.RecoveryServicesBackup.BackupGenericRecoveryPoint
    {
        public GenericRecoveryPoint() { }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RecoveryPointAdditionalInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RecoveryPointOn { get { throw null; } }
        public Azure.Provisioning.RecoveryServicesBackup.RecoveryPointProperties RecoveryPointProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RecoveryPointType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IaasClassicComputeVmContainer : Azure.Provisioning.RecoveryServicesBackup.IaasVmContainer
    {
        public IaasClassicComputeVmContainer() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IaasClassicComputeVmProtectedItem : Azure.Provisioning.RecoveryServicesBackup.IaasVmProtectedItem
    {
        public IaasClassicComputeVmProtectedItem() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IaasComputeVmContainer : Azure.Provisioning.RecoveryServicesBackup.IaasVmContainer
    {
        public IaasComputeVmContainer() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IaasComputeVmProtectedItem : Azure.Provisioning.RecoveryServicesBackup.IaasVmProtectedItem
    {
        public IaasComputeVmProtectedItem() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IaasVmBackupExtendedProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IaasVmBackupExtendedProperties() { }
        public Azure.Provisioning.RecoveryServicesBackup.DiskExclusionProperties DiskExclusionProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LinuxVmApplicationName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IaasVmBackupJob : Azure.Provisioning.RecoveryServicesBackup.BackupGenericJob
    {
        public IaasVmBackupJob() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.JobSupportedAction> ActionsInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.IaasVmErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.Provisioning.RecoveryServicesBackup.IaasVmBackupJobExtendedInfo ExtendedInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsUserTriggered { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VirtualMachineVersion { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IaasVmBackupJobExtendedInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IaasVmBackupJobExtendedInfo() { }
        public Azure.Provisioning.BicepValue<string> DynamicErrorMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EstimatedRemainingDurationValue { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> InternalPropertyBag { get { throw null; } }
        public Azure.Provisioning.BicepValue<double> ProgressPercentage { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> PropertyBag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.IaasVmBackupJobTaskDetails> TasksList { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IaasVmBackupJobTaskDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IaasVmBackupJobTaskDetails() { }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InstanceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<double> ProgressPercentage { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TaskExecutionDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TaskId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IaasVmBackupJobV2 : Azure.Provisioning.RecoveryServicesBackup.BackupGenericJob
    {
        public IaasVmBackupJobV2() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.JobSupportedAction> ActionsInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.IaasVmErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.Provisioning.RecoveryServicesBackup.IaasVmBackupJobExtendedInfo ExtendedInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VirtualMachineVersion { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IaasVmContainer : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionContainer
    {
        public IaasVmContainer() { }
        public Azure.Provisioning.BicepValue<string> ResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualMachineId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VirtualMachineVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IaasVmErrorInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IaasVmErrorInfo() { }
        public Azure.Provisioning.BicepValue<int> ErrorCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ErrorString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ErrorTitle { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Recommendations { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IaasVmHealthDetails : Azure.Provisioning.RecoveryServicesBackup.ResourceHealthDetails
    {
        public IaasVmHealthDetails() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IaasVmPolicyType
    {
        Invalid = 0,
        V1 = 1,
        V2 = 2,
    }
    public partial class IaasVmProtectedItem : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectedItem
    {
        public IaasVmProtectedItem() { }
        public Azure.Provisioning.RecoveryServicesBackup.IaasVmProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.IaasVmBackupExtendedProperties ExtendedProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.IaasVmHealthDetails> HealthDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.IaasVmProtectedItemHealthStatus> HealthStatus { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.RecoveryServicesBackup.KpiResourceHealthDetails> KpisHealths { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastBackupOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LastBackupStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProtectedItemDataId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupProtectionState> ProtectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProtectionStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualMachineId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IaasVmProtectedItemExtendedInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IaasVmProtectedItemExtendedInfo() { }
        public Azure.Provisioning.BicepValue<bool> IsPolicyInconsistent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NewestRecoverOnInArchive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> OldestRecoverOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> OldestRecoverOnInArchive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> OldestRecoverOnInVault { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RecoveryPointCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IaasVmProtectedItemHealthStatus
    {
        Passed = 0,
        ActionRequired = 1,
        ActionSuggested = 2,
        Invalid = 3,
    }
    public partial class IaasVmProtectionPolicy : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionPolicy
    {
        public IaasVmProtectionPolicy() { }
        public Azure.Provisioning.RecoveryServicesBackup.InstantRPAdditionalDetails InstantRPDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> InstantRPRetentionRangeInDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.IaasVmPolicyType> PolicyType { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupSchedulePolicy SchedulePolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.IaasVmSnapshotConsistencyType> SnapshotConsistencyType { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.RecoveryServicesBackup.BackupTieringPolicy> TieringPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeZone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IaasVmRecoveryPoint : Azure.Provisioning.RecoveryServicesBackup.BackupGenericRecoveryPoint
    {
        public IaasVmRecoveryPoint() { }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsInstantIlrSessionActive { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsManagedVirtualMachine { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsPrivateAccessEnabledOnAnyDisk { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsSourceVmEncrypted { get { throw null; } }
        public Azure.Provisioning.RecoveryServicesBackup.KeyAndSecretDetails KeyAndSecret { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> OriginalStorageAccountOption { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OSType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RecoveryPointAdditionalInfo { get { throw null; } }
        public Azure.Provisioning.RecoveryServicesBackup.RecoveryPointDiskConfiguration RecoveryPointDiskConfiguration { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.RecoveryServicesBackup.RecoveryPointMoveReadinessInfo> RecoveryPointMoveReadinessInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RecoveryPointOn { get { throw null; } }
        public Azure.Provisioning.RecoveryServicesBackup.RecoveryPointProperties RecoveryPointProperties { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.RecoveryPointTierInformationV2> RecoveryPointTierDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RecoveryPointType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecurityType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SourceVmStorageType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VirtualMachineSize { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IaasVmSnapshotConsistencyType
    {
        OnlyCrashConsistent = 0,
    }
    public enum InfrastructureEncryptionState
    {
        Invalid = 0,
        Disabled = 1,
        Enabled = 2,
    }
    public partial class InquiryValidation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public InquiryValidation() { }
        public Azure.Provisioning.BicepValue<string> AdditionalDetail { get { throw null; } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupErrorDetail ErrorDetail { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ProtectableItemCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InstantRPAdditionalDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public InstantRPAdditionalDetails() { }
        public Azure.Provisioning.BicepValue<string> AzureBackupRGNamePrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureBackupRGNameSuffix { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum JobSupportedAction
    {
        Invalid = 0,
        Cancellable = 1,
        Retriable = 2,
    }
    public partial class KekDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KekDetails() { }
        public Azure.Provisioning.BicepValue<string> KeyBackupData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> KeyVaultId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KeyAndSecretDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyAndSecretDetails() { }
        public Azure.Provisioning.RecoveryServicesBackup.BekDetails BekDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> EncryptionMechanism { get { throw null; } }
        public Azure.Provisioning.RecoveryServicesBackup.KekDetails KekDetails { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KpiResourceHealthDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KpiResourceHealthDetails() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.ResourceHealthDetails> ResourceHealthDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.ResourceHealthStatus> ResourceHealthStatus { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LastBackupStatus
    {
        Invalid = 0,
        Healthy = 1,
        Unhealthy = 2,
        IRPending = 3,
    }
    public enum LastUpdateStatus
    {
        Invalid = 0,
        NotEnabled = 1,
        PartiallySucceeded = 2,
        PartiallyFailed = 3,
        Failed = 4,
        Succeeded = 5,
        Initialized = 6,
        FirstInitialization = 7,
    }
    public partial class LogSchedulePolicy : Azure.Provisioning.RecoveryServicesBackup.BackupSchedulePolicy
    {
        public LogSchedulePolicy() { }
        public Azure.Provisioning.BicepValue<int> ScheduleFrequencyInMins { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LongTermRetentionPolicy : Azure.Provisioning.RecoveryServicesBackup.BackupRetentionPolicy
    {
        public LongTermRetentionPolicy() { }
        public Azure.Provisioning.RecoveryServicesBackup.DailyRetentionSchedule DailySchedule { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.MonthlyRetentionSchedule MonthlySchedule { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.WeeklyRetentionSchedule WeeklySchedule { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.YearlyRetentionSchedule YearlySchedule { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LongTermSchedulePolicy : Azure.Provisioning.RecoveryServicesBackup.BackupSchedulePolicy
    {
        public LongTermSchedulePolicy() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MabBackupJob : Azure.Provisioning.RecoveryServicesBackup.BackupGenericJob
    {
        public MabBackupJob() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.JobSupportedAction> ActionsInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.MabErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.Provisioning.RecoveryServicesBackup.MabBackupJobExtendedInfo ExtendedInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MabServerName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.MabServerType> MabServerType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupWorkloadType> WorkloadType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MabBackupJobExtendedInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MabBackupJobExtendedInfo() { }
        public Azure.Provisioning.BicepValue<string> DynamicErrorMessage { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> PropertyBag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.MabBackupJobTaskDetails> TasksList { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MabBackupJobTaskDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MabBackupJobTaskDetails() { }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TaskId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MabContainer : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionContainer
    {
        public MabContainer() { }
        public Azure.Provisioning.BicepValue<string> AgentVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> CanReRegister { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerHealthState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ContainerId { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.MabContainerExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.MabContainerHealthDetails> MabContainerHealthDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ProtectedItemCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MabContainerExtendedInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MabContainerExtendedInfo() { }
        public Azure.Provisioning.BicepList<string> BackupItems { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupItemType> BackupItemType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LastBackupStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastRefreshedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MabContainerHealthDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MabContainerHealthDetails() { }
        public Azure.Provisioning.BicepValue<int> Code { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Recommendations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MabErrorInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MabErrorInfo() { }
        public Azure.Provisioning.BicepValue<string> ErrorString { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Recommendations { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MabFileFolderProtectedItem : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectedItem
    {
        public MabFileFolderProtectedItem() { }
        public Azure.Provisioning.BicepValue<string> ComputerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> DeferredDeleteSyncTimeInUTC { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.MabFileFolderProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastBackupOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LastBackupStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProtectionState { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MabFileFolderProtectedItemExtendedInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MabFileFolderProtectedItemExtendedInfo() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastRefreshedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> OldestRecoverOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RecoveryPointCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MabProtectionPolicy : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionPolicy
    {
        public MabProtectionPolicy() { }
        public Azure.Provisioning.RecoveryServicesBackup.BackupRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupSchedulePolicy SchedulePolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MabServerType
    {
        Invalid = 0,
        Unknown = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IaasVMContainer")]
        IaasVmContainer = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IaasVMServiceContainer")]
        IaasVmServiceContainer = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DPMContainer")]
        DpmContainer = 4,
        AzureBackupServerContainer = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="MABContainer")]
        MabContainer = 6,
        Cluster = 7,
        AzureSqlContainer = 8,
        Windows = 9,
        VCenter = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VMAppContainer")]
        VmAppContainer = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQLAGWorkLoadContainer")]
        SqlAvailabilityGroupWorkLoadContainer = 12,
        StorageContainer = 13,
        GenericContainer = 14,
    }
    public partial class MonthlyRetentionSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonthlyRetentionSchedule() { }
        public Azure.Provisioning.RecoveryServicesBackup.RetentionDuration RetentionDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.BackupDay> RetentionScheduleDailyDaysOfTheMonth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.RetentionScheduleFormat> RetentionScheduleFormatType { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.WeeklyRetentionFormat RetentionScheduleWeekly { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.DateTimeOffset> RetentionTimes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PointInTimeRange : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PointInTimeRange() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndsOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartsOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PrivateEndpointConnectionStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Disconnected = 3,
    }
    public enum ProtectedItemState
    {
        Invalid = 0,
        IRPending = 1,
        Protected = 2,
        ProtectionError = 3,
        ProtectionStopped = 4,
        ProtectionPaused = 5,
        BackupsSuspended = 6,
    }
    public partial class RecoveryPointDiskConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecoveryPointDiskConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.DiskInformation> ExcludedDiskList { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.DiskInformation> IncludedDiskList { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> NumberOfDisksAttachedToVm { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> NumberOfDisksIncludedInBackup { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RecoveryPointMoveReadinessInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecoveryPointMoveReadinessInfo() { }
        public Azure.Provisioning.BicepValue<string> AdditionalInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsReadyForMove { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RecoveryPointProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecoveryPointProperties() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpireOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsSoftDeleted { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RuleName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RecoveryPointTierInformation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecoveryPointTierInformation() { }
        public Azure.Provisioning.BicepDictionary<string> ExtendedInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.RecoveryPointTierStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.RecoveryPointTierType> TierType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RecoveryPointTierInformationV2 : Azure.Provisioning.RecoveryServicesBackup.RecoveryPointTierInformation
    {
        public RecoveryPointTierInformationV2() { }
        public new Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.RecoveryPointTierStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.RecoveryPointTierType> Type { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RecoveryPointTierStatus
    {
        Invalid = 0,
        Valid = 1,
        Disabled = 2,
        Deleted = 3,
        Rehydrated = 4,
    }
    public enum RecoveryPointTierType
    {
        Invalid = 0,
        InstantRP = 1,
        HardenedRP = 2,
        ArchivedRP = 3,
    }
    public partial class RecoveryServicesBackupPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RecoveryServicesBackupPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.PrivateEndpointConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RecoveryServiceVaultProtectionIntent : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionIntent
    {
        public RecoveryServiceVaultProtectionIntent() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResourceGuardOperationDetail : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceGuardOperationDetail() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DefaultResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VaultCriticalOperation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResourceGuardProxy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ResourceGuardProxy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.ResourceGuardProxyProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.RecoveryServicesBackup.ResourceGuardProxy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_02_01;
            public static readonly string V2025_08_01;
            public static readonly string V2026_01_01;
        }
    }
    public partial class ResourceGuardProxyProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceGuardProxyProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.ResourceGuardOperationDetail> ResourceGuardOperationDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceGuardResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResourceHealthDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceHealthDetails() { }
        public Azure.Provisioning.BicepValue<int> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Recommendations { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ResourceHealthStatus
    {
        Healthy = 0,
        TransientDegraded = 1,
        PersistentDegraded = 2,
        TransientUnhealthy = 3,
        PersistentUnhealthy = 4,
        Invalid = 5,
    }
    public partial class ResourceProtectionIntent : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionIntent
    {
        public ResourceProtectionIntent() { }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RestorePointType
    {
        Invalid = 0,
        Full = 1,
        Log = 2,
        Differential = 3,
        Incremental = 4,
        SnapshotFull = 5,
        SnapshotCopyOnlyFull = 6,
    }
    public partial class RetentionDuration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RetentionDuration() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.RetentionDurationType> DurationType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RetentionDurationType
    {
        Invalid = 0,
        Days = 1,
        Weeks = 2,
        Months = 3,
        Years = 4,
    }
    public enum RetentionScheduleFormat
    {
        Invalid = 0,
        Daily = 1,
        Weekly = 2,
    }
    public enum ScheduleRunType
    {
        Invalid = 0,
        Daily = 1,
        Weekly = 2,
        Hourly = 3,
    }
    public partial class SimpleRetentionPolicy : Azure.Provisioning.RecoveryServicesBackup.BackupRetentionPolicy
    {
        public SimpleRetentionPolicy() { }
        public Azure.Provisioning.RecoveryServicesBackup.RetentionDuration RetentionDuration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SimpleSchedulePolicy : Azure.Provisioning.RecoveryServicesBackup.BackupSchedulePolicy
    {
        public SimpleSchedulePolicy() { }
        public Azure.Provisioning.RecoveryServicesBackup.BackupHourlySchedule HourlySchedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.BackupDayOfWeek> ScheduleRunDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.ScheduleRunType> ScheduleRunFrequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.DateTimeOffset> ScheduleRunTimes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ScheduleWeeklyFrequency { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SimpleSchedulePolicyV2 : Azure.Provisioning.RecoveryServicesBackup.BackupSchedulePolicy
    {
        public SimpleSchedulePolicyV2() { }
        public Azure.Provisioning.RecoveryServicesBackup.BackupHourlySchedule HourlySchedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.ScheduleRunType> ScheduleRunFrequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.DateTimeOffset> ScheduleRunTimes { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupWeeklySchedule WeeklySchedule { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SnapshotBackupAdditionalDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SnapshotBackupAdditionalDetails() { }
        public Azure.Provisioning.BicepValue<string> InstantRPDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> InstantRpRetentionRangeInDays { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.UserAssignedManagedIdentityDetails UserAssignedManagedIdentityDetails { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SoftDeleteFeatureState
    {
        Invalid = 0,
        Enabled = 1,
        Disabled = 2,
        AlwaysON = 3,
    }
    public partial class SqlAvailabilityGroupWorkloadProtectionContainer : Azure.Provisioning.RecoveryServicesBackup.WorkloadContainer
    {
        public SqlAvailabilityGroupWorkloadProtectionContainer() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlContainer : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionContainer
    {
        public SqlContainer() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlDataDirectory : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlDataDirectory() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.SqlDataDirectoryType> DirectoryType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LogicalName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SqlDataDirectoryType
    {
        Invalid = 0,
        Data = 1,
        Log = 2,
    }
    public partial class SqlProtectedItem : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectedItem
    {
        public SqlProtectedItem() { }
        public Azure.Provisioning.RecoveryServicesBackup.SqlProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProtectedItemDataId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.ProtectedItemState> ProtectionState { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlProtectedItemExtendedInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlProtectedItemExtendedInfo() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> OldestRecoverOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RecoveryPointCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlProtectionPolicy : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionPolicy
    {
        public SqlProtectionPolicy() { }
        public Azure.Provisioning.RecoveryServicesBackup.BackupRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageBackupJob : Azure.Provisioning.RecoveryServicesBackup.BackupGenericJob
    {
        public StorageBackupJob() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.JobSupportedAction> ActionsInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.StorageErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.Provisioning.RecoveryServicesBackup.StorageBackupJobExtendedInfo ExtendedInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsUserTriggered { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StorageAccountName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StorageAccountVersion { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageBackupJobExtendedInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageBackupJobExtendedInfo() { }
        public Azure.Provisioning.BicepValue<string> DynamicErrorMessage { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> PropertyBag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.StorageBackupJobTaskDetails> TasksList { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageBackupJobTaskDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageBackupJobTaskDetails() { }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TaskId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageContainer : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionContainer
    {
        public StorageContainer() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.AcquireStorageAccountLock> AcquireStorageAccountLock { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.WorkloadOperationType> OperationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ProtectedItemCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StorageErrorInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageErrorInfo() { }
        public Azure.Provisioning.BicepValue<int> ErrorCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ErrorString { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Recommendations { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SubProtectionPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SubProtectionPolicy() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.SubProtectionPolicyType> PolicyType { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupSchedulePolicy SchedulePolicy { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.SnapshotBackupAdditionalDetails SnapshotBackupAdditionalDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.RecoveryServicesBackup.BackupTieringPolicy> TieringPolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SubProtectionPolicyType
    {
        Invalid = 0,
        Full = 1,
        Differential = 2,
        Log = 3,
        CopyOnlyFull = 4,
        Incremental = 5,
        SnapshotFull = 6,
        SnapshotCopyOnlyFull = 7,
    }
    public enum TieringMode
    {
        Invalid = 0,
        TierRecommended = 1,
        TierAfter = 2,
        DoNotTier = 3,
    }
    public partial class UserAssignedManagedIdentityDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UserAssignedManagedIdentityDetails() { }
        public Azure.Provisioning.BicepValue<string> IdentityArmId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IdentityName { get { throw null; } set { } }
        public Azure.Provisioning.Resources.UserAssignedIdentityDetails UserAssignedIdentityProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VaultBackupJob : Azure.Provisioning.RecoveryServicesBackup.BackupGenericJob
    {
        public VaultBackupJob() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.JobSupportedAction> ActionsInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.VaultBackupJobErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> ExtendedInfoPropertyBag { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VaultBackupJobErrorInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VaultBackupJobErrorInfo() { }
        public Azure.Provisioning.BicepValue<int> ErrorCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ErrorString { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Recommendations { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VaultDedupState
    {
        Invalid = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public partial class VaultRetentionPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VaultRetentionPolicy() { }
        public Azure.Provisioning.BicepValue<int> SnapshotRetentionInDays { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupRetentionPolicy VaultRetention { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VaultSubResourceType
    {
        AzureBackup = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AzureBackup_secondary")]
        AzureBackupSecondary = 1,
        AzureSiteRecovery = 2,
    }
    public enum VaultXcoolState
    {
        Invalid = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public partial class VmAppContainerProtectionContainer : Azure.Provisioning.RecoveryServicesBackup.WorkloadContainer
    {
        public VmAppContainerProtectionContainer() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VmWorkloadProtectedItem : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectedItem
    {
        public VmWorkloadProtectedItem() { }
        public Azure.Provisioning.RecoveryServicesBackup.VmWorkloadProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.RecoveryServicesBackup.KpiResourceHealthDetails> KpisHealths { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupErrorDetail LastBackupErrorDetail { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastBackupOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.LastBackupStatus> LastBackupStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.DistributedNodesInfo> NodesList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ParentName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ParentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProtectedItemDataSourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.VmWorkloadProtectedItemHealthStatus> ProtectedItemHealthStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupProtectionState> ProtectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProtectionStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ServerName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VmWorkloadProtectedItemExtendedInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VmWorkloadProtectedItemExtendedInfo() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NewestRecoverOnInArchive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> OldestRecoverOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> OldestRecoverOnInArchive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> OldestRecoverOnInVault { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RecoveryModel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RecoveryPointCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VmWorkloadProtectedItemHealthStatus
    {
        Invalid = 0,
        Healthy = 1,
        Unhealthy = 2,
        NotReachable = 3,
        IRPending = 4,
    }
    public partial class VmWorkloadProtectionPolicy : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionPolicy
    {
        public VmWorkloadProtectionPolicy() { }
        public Azure.Provisioning.BicepValue<bool> DoesMakePolicyConsistent { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.BackupCommonSettings Settings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.SubProtectionPolicy> SubProtectionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupWorkloadType> WorkLoadType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VmWorkloadSapAseDatabaseProtectedItem : Azure.Provisioning.RecoveryServicesBackup.VmWorkloadProtectedItem
    {
        public VmWorkloadSapAseDatabaseProtectedItem() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VmWorkloadSapHanaDatabaseProtectedItem : Azure.Provisioning.RecoveryServicesBackup.VmWorkloadProtectedItem
    {
        public VmWorkloadSapHanaDatabaseProtectedItem() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VmWorkloadSapHanaDBInstanceProtectedItem : Azure.Provisioning.RecoveryServicesBackup.VmWorkloadProtectedItem
    {
        public VmWorkloadSapHanaDBInstanceProtectedItem() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VmWorkloadSqlDatabaseProtectedItem : Azure.Provisioning.RecoveryServicesBackup.VmWorkloadProtectedItem
    {
        public VmWorkloadSqlDatabaseProtectedItem() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WeeklyRetentionFormat : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WeeklyRetentionFormat() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.BackupDayOfWeek> DaysOfTheWeek { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.BackupWeekOfMonth> WeeksOfTheMonth { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WeeklyRetentionSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WeeklyRetentionSchedule() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.BackupDayOfWeek> DaysOfTheWeek { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.RetentionDuration RetentionDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.DateTimeOffset> RetentionTimes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadAutoProtectionIntent : Azure.Provisioning.RecoveryServicesBackup.RecoveryServiceVaultProtectionIntent
    {
        public WorkloadAutoProtectionIntent() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadBackupJob : Azure.Provisioning.RecoveryServicesBackup.BackupGenericJob
    {
        public WorkloadBackupJob() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.JobSupportedAction> ActionsInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Duration { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.WorkloadErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.Provisioning.RecoveryServicesBackup.WorkloadBackupJobExtendedInfo ExtendedInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> WorkloadType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadBackupJobExtendedInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkloadBackupJobExtendedInfo() { }
        public Azure.Provisioning.BicepValue<string> DynamicErrorMessage { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> PropertyBag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.WorkloadBackupJobTaskDetails> TasksList { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadBackupJobTaskDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkloadBackupJobTaskDetails() { }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TaskId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadContainer : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionContainer
    {
        public WorkloadContainer() { }
        public Azure.Provisioning.RecoveryServicesBackup.WorkloadContainerExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.WorkloadOperationType> OperationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.BackupWorkloadType> WorkloadType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadContainerAutoProtectionIntent : Azure.Provisioning.RecoveryServicesBackup.BackupGenericProtectionIntent
    {
        public WorkloadContainerAutoProtectionIntent() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadContainerExtendedInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkloadContainerExtendedInfo() { }
        public Azure.Provisioning.BicepValue<string> HostServerName { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.WorkloadContainerInquiryInfo InquiryInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.DistributedNodesInfo> NodesList { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadContainerInquiryInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkloadContainerInquiryInfo() { }
        public Azure.Provisioning.RecoveryServicesBackup.BackupErrorDetail ErrorDetail { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.WorkloadInquiryDetails> InquiryDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadErrorInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkloadErrorInfo() { }
        public Azure.Provisioning.BicepValue<string> AdditionalDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ErrorCode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ErrorString { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ErrorTitle { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Recommendations { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadInquiryDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkloadInquiryDetails() { }
        public Azure.Provisioning.RecoveryServicesBackup.InquiryValidation InquiryValidation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> ItemCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkloadInquiryDetailsType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WorkloadItemType
    {
        Invalid = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQLInstance")]
        SqlInstance = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQLDataBase")]
        SqlDatabase = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SAPHanaSystem")]
        SapHanaSystem = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SAPHanaDatabase")]
        SapHanaDatabase = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SAPAseSystem")]
        SapAseSystem = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SAPAseDatabase")]
        SapAseDatabase = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SAPHanaDBInstance")]
        SapHanaDBInstance = 7,
    }
    public enum WorkloadOperationType
    {
        Invalid = 0,
        Register = 1,
        Reregister = 2,
        Rehydrate = 3,
    }
    public partial class WorkloadPointInTimeRecoveryPoint : Azure.Provisioning.RecoveryServicesBackup.WorkloadRecoveryPoint
    {
        public WorkloadPointInTimeRecoveryPoint() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.PointInTimeRange> TimeRanges { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadRecoveryPoint : Azure.Provisioning.RecoveryServicesBackup.BackupGenericRecoveryPoint
    {
        public WorkloadRecoveryPoint() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RecoveryPointCreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.RecoveryServicesBackup.RecoveryPointMoveReadinessInfo> RecoveryPointMoveReadinessInfo { get { throw null; } }
        public Azure.Provisioning.RecoveryServicesBackup.RecoveryPointProperties RecoveryPointProperties { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.RecoveryPointTierInformationV2> RecoveryPointTierDetails { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.RestorePointType> RestorePointType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadSapAsePointInTimeRecoveryPoint : Azure.Provisioning.RecoveryServicesBackup.WorkloadPointInTimeRecoveryPoint
    {
        public WorkloadSapAsePointInTimeRecoveryPoint() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadSapAseRecoveryPoint : Azure.Provisioning.RecoveryServicesBackup.WorkloadRecoveryPoint
    {
        public WorkloadSapAseRecoveryPoint() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadSapHanaPointInTimeRecoveryPoint : Azure.Provisioning.RecoveryServicesBackup.WorkloadPointInTimeRecoveryPoint
    {
        public WorkloadSapHanaPointInTimeRecoveryPoint() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadSapHanaRecoveryPoint : Azure.Provisioning.RecoveryServicesBackup.WorkloadRecoveryPoint
    {
        public WorkloadSapHanaRecoveryPoint() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadSqlAutoProtectionIntent : Azure.Provisioning.RecoveryServicesBackup.WorkloadAutoProtectionIntent
    {
        public WorkloadSqlAutoProtectionIntent() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.WorkloadItemType> WorkloadItemType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadSqlPointInTimeRecoveryPoint : Azure.Provisioning.RecoveryServicesBackup.WorkloadSqlRecoveryPoint
    {
        public WorkloadSqlPointInTimeRecoveryPoint() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.PointInTimeRange> TimeRanges { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadSqlRecoveryPoint : Azure.Provisioning.RecoveryServicesBackup.WorkloadRecoveryPoint
    {
        public WorkloadSqlRecoveryPoint() { }
        public Azure.Provisioning.RecoveryServicesBackup.WorkloadSqlRecoveryPointExtendedInfo ExtendedInfo { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkloadSqlRecoveryPointExtendedInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkloadSqlRecoveryPointExtendedInfo() { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DataDirectoryInfoCapturedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.SqlDataDirectory> DataDirectoryPaths { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class YearlyRetentionSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public YearlyRetentionSchedule() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.BackupMonthOfYear> MonthsOfYear { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.RetentionDuration RetentionDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.RecoveryServicesBackup.BackupDay> RetentionScheduleDailyDaysOfTheMonth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.RecoveryServicesBackup.RetentionScheduleFormat> RetentionScheduleFormatType { get { throw null; } set { } }
        public Azure.Provisioning.RecoveryServicesBackup.WeeklyRetentionFormat RetentionScheduleWeekly { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.DateTimeOffset> RetentionTimes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
