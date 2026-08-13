namespace Azure.Provisioning.Synapse
{
    public partial class AadAdminProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AadAdminProperties() { }
        public Azure.Provisioning.BicepValue<string> AdministratorType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Login { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sid { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ActualState
    {
        Enabling = 0,
        Enabled = 1,
        Disabling = 2,
        Disabled = 3,
        Unknown = 4,
    }
    public partial class AttachedDatabaseConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AttachedDatabaseConfiguration(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AttachedDatabaseNames { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.DefaultPrincipalsModificationKind> DefaultPrincipalsModificationKind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> KustoPoolResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.KustoPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.SynapseResourceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.Synapse.TableLevelSharingProperties TableLevelSharingProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.AttachedDatabaseConfiguration FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class AutoPauseProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutoPauseProperties() { }
        public Azure.Provisioning.BicepValue<int> DelayInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutoScaleProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutoScaleProperties() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxNodeCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinNodeCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureADOnlyAuthentication : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AzureADOnlyAuthentication(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAadOnlyAuthenticationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.StateValue> State { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.AzureADOnlyAuthentication FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class AzureSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.SynapseSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.SkuSize> Size { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BigDataPoolResourceInfo : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BigDataPoolResourceInfo(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Synapse.AutoPauseProperties AutoPause { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.AutoScaleProperties AutoScale { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CacheSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Synapse.LibraryInfo> CustomLibraries { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DefaultSparkLogFolder { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.DynamicExecutorAllocation DynamicExecutorAllocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAutotuneEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsComputeIsolationEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastSucceededTimestamp { get { throw null; } }
        public Azure.Provisioning.Synapse.LibraryRequirements LibraryRequirements { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NodeCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.NodeSize> NodeSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.NodeSizeFamily> NodeSizeFamily { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SessionLevelPackagesEnabled { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SparkConfigProperties SparkConfigProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SparkEventsFolder { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SparkVersion { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.BigDataPoolResourceInfo FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public enum BlobAuditingPolicyState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ClusterPrincipalAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ClusterPrincipalAssignment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AadObjectId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.KustoPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrincipalName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.PrincipalType> PrincipalType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.SynapseResourceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.ClusterPrincipalRole> Role { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.ClusterPrincipalAssignment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public enum ClusterPrincipalRole
    {
        AllDatabasesAdmin = 0,
        AllDatabasesViewer = 1,
    }
    public enum ColumnDataType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="image")]
        Image = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="text")]
        Text = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="uniqueidentifier")]
        Uniqueidentifier = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="date")]
        Date = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="time")]
        Time = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="datetime2")]
        Datetime2 = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="datetimeoffset")]
        Datetimeoffset = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="tinyint")]
        Tinyint = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="smallint")]
        Smallint = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="int")]
        Int = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="smalldatetime")]
        Smalldatetime = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="real")]
        Real = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="money")]
        Money = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="datetime")]
        Datetime = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="float")]
        Float = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="sql_variant")]
        SqlVariant = 15,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ntext")]
        Ntext = 16,
        [System.Runtime.Serialization.DataMemberAttribute(Name="bit")]
        Bit = 17,
        [System.Runtime.Serialization.DataMemberAttribute(Name="decimal")]
        Decimal = 18,
        [System.Runtime.Serialization.DataMemberAttribute(Name="numeric")]
        Numeric = 19,
        [System.Runtime.Serialization.DataMemberAttribute(Name="smallmoney")]
        Smallmoney = 20,
        [System.Runtime.Serialization.DataMemberAttribute(Name="bigint")]
        Bigint = 21,
        [System.Runtime.Serialization.DataMemberAttribute(Name="hierarchyid")]
        Hierarchyid = 22,
        [System.Runtime.Serialization.DataMemberAttribute(Name="geometry")]
        Geometry = 23,
        [System.Runtime.Serialization.DataMemberAttribute(Name="geography")]
        Geography = 24,
        [System.Runtime.Serialization.DataMemberAttribute(Name="varbinary")]
        Varbinary = 25,
        [System.Runtime.Serialization.DataMemberAttribute(Name="varchar")]
        Varchar = 26,
        [System.Runtime.Serialization.DataMemberAttribute(Name="binary")]
        Binary = 27,
        [System.Runtime.Serialization.DataMemberAttribute(Name="char")]
        Char = 28,
        [System.Runtime.Serialization.DataMemberAttribute(Name="timestamp")]
        Timestamp = 29,
        [System.Runtime.Serialization.DataMemberAttribute(Name="nvarchar")]
        Nvarchar = 30,
        [System.Runtime.Serialization.DataMemberAttribute(Name="nchar")]
        Nchar = 31,
        [System.Runtime.Serialization.DataMemberAttribute(Name="xml")]
        Xml = 32,
        [System.Runtime.Serialization.DataMemberAttribute(Name="sysname")]
        Sysname = 33,
    }
    public enum ConfigurationType
    {
        File = 0,
        Artifact = 1,
    }
    public enum CreateMode
    {
        Default = 0,
        PointInTimeRestore = 1,
        Recovery = 2,
        Restore = 3,
    }
    public partial class CustomerManagedKeyDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomerManagedKeyDetails() { }
        public Azure.Provisioning.Synapse.KekIdentityProperties KekIdentity { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.WorkspaceKeyDetails Key { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatabasePrincipalAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DatabasePrincipalAssignment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AadObjectId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseDatabase Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrincipalName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.PrincipalType> PrincipalType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.SynapseResourceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.DatabasePrincipalRole> Role { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.DatabasePrincipalAssignment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public enum DatabasePrincipalRole
    {
        Admin = 0,
        Ingestor = 1,
        Monitor = 2,
        User = 3,
        UnrestrictedViewer = 4,
        Viewer = 5,
    }
    public partial class DatabaseProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatabaseProperties() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.DataConnectionKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseDatabase Parent { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.DataConnectionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.DataConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public enum DataConnectionKind
    {
        EventHub = 0,
        EventGrid = 1,
        IotHub = 2,
    }
    public partial class DataConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataConnectionProperties() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataLakeStorageAccountDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataLakeStorageAccountDetails() { }
        public Azure.Provisioning.BicepValue<string> AccountUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> CreateManagedPrivateEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Filesystem { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataMaskingFunction
    {
        Default = 0,
        CCN = 1,
        Email = 2,
        Number = 3,
        SSN = 4,
        Text = 5,
    }
    public partial class DataMaskingPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataMaskingPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ApplicationPrincipals { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.DataMaskingState> DataMaskingState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExemptPrincipals { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MaskingLevel { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Synapse.SqlPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.DataMaskingPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class DataMaskingRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataMaskingRule(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AliasName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ColumnName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.DataMaskingFunction> MaskingFunction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NumberFrom { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NumberTo { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SqlPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrefixSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReplacementString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuleId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.DataMaskingRuleState> RuleState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SchemaName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SuffixSize { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.DataMaskingRule FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public enum DataMaskingRuleState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum DataMaskingState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class DataWarehouseUserActivities : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal DataWarehouseUserActivities() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> ActiveQueriesCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SqlPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.DataWarehouseUserActivities FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public enum DayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    public partial class DedicatedSQLminimalTlsSettings : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DedicatedSQLminimalTlsSettings(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MinimalTlsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.DedicatedSQLminimalTlsSettings FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public enum DefaultPrincipalsModificationKind
    {
        Union = 0,
        Replace = 1,
        None = 2,
    }
    public enum DesiredState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DynamicExecutorAllocation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DynamicExecutorAllocation() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxExecutors { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinExecutors { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EncryptionDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EncryptionDetails() { }
        public Azure.Provisioning.Synapse.CustomerManagedKeyDetails Cmk { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DoubleEncryptionEnabled { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EncryptionProtector : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public EncryptionProtector(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServerKeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.ServerKeyType> ServerKeyType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Subregion { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.EncryptionProtector FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class ExtendedServerBlobAuditingPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ExtendedServerBlobAuditingPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AuditActionsAndGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDevopsAuditEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PredicateExpression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> QueueDelayMs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.BlobAuditingPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.ExtendedServerBlobAuditingPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class ExtendedSqlPoolBlobAuditingPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ExtendedSqlPoolBlobAuditingPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AuditActionsAndGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Synapse.SqlPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PredicateExpression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> QueueDelayMs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.BlobAuditingPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.ExtendedSqlPoolBlobAuditingPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class GeoBackupPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public GeoBackupPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SqlPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.GeoBackupPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageType { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.GeoBackupPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public enum GeoBackupPolicyState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class IntegrationRuntimeResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IntegrationRuntimeResource(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IntegrationRuntimeDescription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.IntegrationRuntimeResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class IpFirewallRuleInfo : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IpFirewallRuleInfo(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> EndIpAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.ProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StartIpAddress { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.IpFirewallRuleInfo FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class KekIdentityProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KekIdentityProperties() { }
        public Azure.Provisioning.BicepValue<string> UserAssignedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> UseSystemAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KustoPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KustoPool(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> DataIngestionUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> EnablePurge { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableStreamingIngest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Synapse.LanguageExtension> LanguageExtensionsValue { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.OptimizedAutoscale OptimizedAutoscale { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.SynapseResourceProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Synapse.AzureSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.State> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StateReason { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> WorkspaceUID { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.KustoPool FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class LanguageExtension : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LanguageExtension() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.LanguageExtensionName> LanguageExtensionName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LanguageExtensionName
    {
        PYTHON = 0,
        R = 1,
    }
    public partial class LibraryInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LibraryInfo() { }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CreatorId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NamePropertiesName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Type { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UploadedTimestamp { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LibraryRequirements : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LibraryRequirements() { }
        public Azure.Provisioning.BicepValue<string> Content { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Filename { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Time { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LibraryResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal LibraryResource() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CreatorId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NamePropertiesName { get { throw null; } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningStatus { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Type { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> UploadedTimestamp { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.LibraryResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class MaintenanceWindowOptions : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal MaintenanceWindowOptions() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowMultipleMaintenanceWindowsPerCycle { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> DefaultDurationInMinutes { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Synapse.MaintenanceWindowTimeRange> MaintenanceWindowCycles { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> MinCycles { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> MinDurationInMinutes { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Synapse.SqlPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> TimeGranularityInMinutes { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.MaintenanceWindowOptions FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class MaintenanceWindows : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MaintenanceWindows(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Synapse.SqlPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Synapse.MaintenanceWindowTimeRange> TimeRanges { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.MaintenanceWindows FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class MaintenanceWindowTimeRange : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MaintenanceWindowTimeRange() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.DayOfWeek> DayOfWeek { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Duration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartTime { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedIdentity() { }
        public Azure.Provisioning.BicepValue<string> PrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.ResourceIdentityType> Type { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.Synapse.UserAssignedManagedIdentity> UserAssignedIdentities { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedIdentitySqlControlSettingsModel : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ManagedIdentitySqlControlSettingsModel(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Synapse.ManagedIdentitySqlControlSettingsModelPropertiesGrantSqlControlToManagedIdentity GrantSqlControlToManagedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.ManagedIdentitySqlControlSettingsModel FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class ManagedIdentitySqlControlSettingsModelPropertiesGrantSqlControlToManagedIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedIdentitySqlControlSettingsModelPropertiesGrantSqlControlToManagedIdentity() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.ActualState> ActualState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.DesiredState> DesiredState { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedVirtualNetworkSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedVirtualNetworkSettings() { }
        public Azure.Provisioning.BicepList<string> AllowedAadTenantIdsForLinking { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> LinkedAccessCheckOnTargetResource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> PreventDataExfiltration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NodeSize
    {
        None = 0,
        Small = 1,
        Medium = 2,
        Large = 3,
        XLarge = 4,
        XXLarge = 5,
        XXXLarge = 6,
    }
    public enum NodeSizeFamily
    {
        None = 0,
        MemoryOptimized = 1,
        HardwareAcceleratedFPGA = 2,
        HardwareAcceleratedGPU = 3,
    }
    public partial class OptimizedAutoscale : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OptimizedAutoscale() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Maximum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Minimum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PrincipalType
    {
        App = 0,
        Group = 1,
        User = 2,
    }
    public partial class PrivateEndpointConnectionForPrivateLinkHub : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal PrivateEndpointConnectionForPrivateLinkHub() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.PrivateLinkHub Parent { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.PrivateEndpointConnectionForPrivateLinkHubProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.PrivateEndpointConnectionForPrivateLinkHub FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class PrivateEndpointConnectionForPrivateLinkHubBasic : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateEndpointConnectionForPrivateLinkHubBasic() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.Synapse.PrivateEndpointConnectionProperties Properties { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateEndpointConnectionForPrivateLinkHubProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateEndpointConnectionForPrivateLinkHubProperties() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateEndpointConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateEndpointConnectionProperties() { }
        public Azure.Provisioning.BicepValue<string> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.Synapse.SynapsePrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateLinkHub : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PrivateLinkHub(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Synapse.PrivateEndpointConnectionForPrivateLinkHubBasic> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.PrivateLinkHub FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class PrivateLinkResourceOperationGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal PrivateLinkResourceOperationGroup() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapsePrivateLinkResourceProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.PrivateLinkResourceOperationGroup FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public enum ProvisioningState
    {
        Provisioning = 0,
        Succeeded = 1,
        Deleting = 2,
        Failed = 3,
        DeleteError = 4,
    }
    public partial class RecoverableSqlPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal RecoverableSqlPool() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Edition { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ElasticPoolName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastAvailableBackupOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceLevelObjective { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.RecoverableSqlPool FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class ReplicationLink : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal ReplicationLink() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsTerminationAllowed { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SqlPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartnerDatabase { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PartnerLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.ReplicationRole> PartnerRole { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PartnerServer { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PercentComplete { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReplicationMode { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.ReplicationState> ReplicationState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.ReplicationRole> Role { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.ReplicationLink FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public enum ReplicationRole
    {
        Primary = 0,
        Secondary = 1,
        NonReadableSecondary = 2,
        Source = 3,
        Copy = 4,
    }
    public enum ReplicationState
    {
        PENDING = 0,
        SEEDING = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CATCH_UP")]
        CATCHUP = 2,
        SUSPENDED = 3,
    }
    public enum ResourceIdentityType
    {
        None = 0,
        SystemAssigned = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SystemAssigned,UserAssigned")]
        SystemAssignedUserAssigned = 2,
    }
    public partial class RestorableDroppedSqlPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal RestorableDroppedSqlPool() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> DeletedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EarliestRestoreOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Edition { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ElasticPoolName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MaxSizeBytes { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceLevelObjective { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.RestorableDroppedSqlPool FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class RestorePoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal RestorePoint() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EarliestRestoreOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SqlPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RestorePointCreationOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RestorePointLabel { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.RestorePointType> RestorePointType { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.RestorePoint FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public enum RestorePointType
    {
        CONTINUOUS = 0,
        DISCRETE = 1,
    }
    public enum SecurityAlertPolicyState
    {
        New = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public partial class SensitivityLabel : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SensitivityLabel(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ColumnName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InformationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InformationTypeId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDisabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LabelId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LabelName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Synapse.SqlPoolColumn Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.SensitivityLabelRank> Rank { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SchemaName { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.SensitivityLabel FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public enum SensitivityLabelRank
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4,
    }
    public partial class ServerBlobAuditingPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServerBlobAuditingPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AuditActionsAndGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDevopsAuditEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> QueueDelayMs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.BlobAuditingPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.ServerBlobAuditingPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public enum ServerKeyType
    {
        ServiceManaged = 0,
        AzureKeyVault = 1,
    }
    public partial class ServerSecurityAlertPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServerSecurityAlertPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<string> DisabledAlerts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EmailAccountAdmins { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EmailAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.SecurityAlertPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.ServerSecurityAlertPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class ServerVulnerabilityAssessment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServerVulnerabilityAssessment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.VulnerabilityAssessmentRecurringScansProperties RecurringScans { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageContainerPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageContainerSasKey { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.ServerVulnerabilityAssessment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public enum SkuSize
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Extra small")]
        ExtraSmall = 0,
        Small = 1,
        Medium = 2,
        Large = 3,
    }
    public partial class SparkConfigProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SparkConfigProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.ConfigurationType> ConfigurationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Content { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Filename { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Time { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SparkConfigurationResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SparkConfigurationResource() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> Annotations { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> ConfigMergeRule { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Configs { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Created { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> CreatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Notes { get { throw null; } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.SparkConfigurationResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class SqlPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlPool(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Collation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.CreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaxSizeBytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RecoverableDatabaseId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RestorePointInTime { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SourceDatabaseDeletionOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceDatabaseId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.StorageAccountType> StorageAccountType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.SqlPool FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class SqlPoolBlobAuditingPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlPoolBlobAuditingPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AuditActionsAndGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Synapse.SqlPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.BlobAuditingPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.SqlPoolBlobAuditingPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class SqlPoolColumn : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SqlPoolColumn() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.ColumnDataType> ColumnType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsComputed { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SqlPoolTable Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.SqlPoolColumn FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class SqlPoolConnectionPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SqlPoolConnectionPolicy() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SqlPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProxyDnsName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProxyPort { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RedirectionState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SecurityEnabledAccess { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> State { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UseServerDefault { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Visibility { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.SqlPoolConnectionPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class SqlPoolOperationResult : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlPoolOperationResult(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Collation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.CreateMode> CreateMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaxSizeBytes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SqlPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RecoverableDatabaseId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RestorePointInTime { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SourceDatabaseDeletionOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceDatabaseId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.StorageAccountType> StorageAccountType { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.SqlPoolOperationResult FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class SqlPoolSchema : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SqlPoolSchema() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SqlPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SqlPoolSchemaProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.SqlPoolSchema FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class SqlPoolSchemaProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlPoolSchemaProperties() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlPoolSecurityAlertPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlPoolSecurityAlertPolicy(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<string> DisabledAlerts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EmailAccountAdmins { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EmailAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SqlPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.SecurityAlertPolicyState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.SqlPoolSecurityAlertPolicy FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class SqlPoolTable : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SqlPoolTable() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SqlPoolSchema Parent { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SqlPoolTableProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.SqlPoolTable FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class SqlPoolTableProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlPoolTableProperties() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlPoolVulnerabilityAssessment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlPoolVulnerabilityAssessment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SqlPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.VulnerabilityAssessmentRecurringScansProperties RecurringScans { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageContainerPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageContainerSasKey { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.SqlPoolVulnerabilityAssessment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class SqlPoolVulnerabilityAssessmentRuleBaseline : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SqlPoolVulnerabilityAssessmentRuleBaseline(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineItem> BaselineResults { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SqlPoolVulnerabilityAssessment Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.SqlPoolVulnerabilityAssessmentRuleBaseline FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class SqlPoolVulnerabilityAssessmentRuleBaselineItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlPoolVulnerabilityAssessmentRuleBaselineItem() { }
        public Azure.Provisioning.BicepList<string> Result { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum State
    {
        Creating = 0,
        Unavailable = 1,
        Running = 2,
        Deleting = 3,
        Deleted = 4,
        Stopping = 5,
        Stopped = 6,
        Starting = 7,
        Updating = 8,
    }
    public enum StateValue
    {
        Consistent = 0,
        InConsistent = 1,
        Updating = 2,
    }
    public enum StorageAccountType
    {
        GRS = 0,
        LRS = 1,
    }
    public partial class SynapseDatabase : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SynapseDatabase(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.SynapseKind> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.KustoPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.DatabaseProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.SynapseDatabase FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class SynapseKey : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SynapseKey(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsActiveCMK { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.SynapseKey FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public enum SynapseKind
    {
        ReadWrite = 0,
        ReadOnlyFollowing = 1,
    }
    public partial class SynapsePrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SynapsePrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.Synapse.SynapsePrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.SynapsePrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class SynapsePrivateLinkHubPrivateLinkResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SynapsePrivateLinkHubPrivateLinkResource() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.PrivateLinkHub Parent { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SynapsePrivateLinkResourceProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.SynapsePrivateLinkHubPrivateLinkResource FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class SynapsePrivateLinkResourceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SynapsePrivateLinkResourceProperties() { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RequiredMembers { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RequiredZoneNames { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SynapsePrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SynapsePrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SynapseResourceProvisioningState
    {
        Running = 0,
        Creating = 1,
        Deleting = 2,
        Succeeded = 3,
        Failed = 4,
        Moving = 5,
        Canceled = 6,
    }
    public partial class SynapseSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SynapseSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SynapseSkuName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Compute optimized")]
        ComputeOptimized = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Storage optimized")]
        StorageOptimized = 1,
    }
    public partial class SynapseWorkspace : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SynapseWorkspace(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AdlaResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> AzureADOnlyAuthentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ConnectivityEndpoints { get { throw null; } }
        public Azure.Provisioning.Synapse.DataLakeStorageAccountDetails DefaultDataLakeStorage { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.EncryptionDetails Encryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> ExtraProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Synapse.ManagedIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InitialWorkspaceAdminObjectId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManagedVirtualNetwork { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.ManagedVirtualNetworkSettings ManagedVirtualNetworkSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Synapse.SynapsePrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.WorkspacePublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PurviewResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.BicepDictionary<System.BinaryData>> Settings { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SqlAdministratorLogin { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlAdministratorLoginPassword { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TrustedServiceBypassEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VirtualNetworkComputeSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.WorkspaceRepositoryConfiguration WorkspaceRepositoryConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceUID { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.SynapseWorkspace FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class TableLevelSharingProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TableLevelSharingProperties() { }
        public Azure.Provisioning.BicepList<string> ExternalTablesToExclude { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ExternalTablesToInclude { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> MaterializedViewsToExclude { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> MaterializedViewsToInclude { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TablesToExclude { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TablesToInclude { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TransparentDataEncryption : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public TransparentDataEncryption(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SqlPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.TransparentDataEncryptionStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.TransparentDataEncryption FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public enum TransparentDataEncryptionStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class UserAssignedManagedIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UserAssignedManagedIdentity() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrincipalId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VulnerabilityAssessmentRecurringScansProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VulnerabilityAssessmentRecurringScansProperties() { }
        public Azure.Provisioning.BicepList<string> Emails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EmailSubscriptionAdmins { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VulnerabilityAssessmentScanError : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VulnerabilityAssessmentScanError() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VulnerabilityAssessmentScanRecord : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal VulnerabilityAssessmentScanRecord() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Synapse.VulnerabilityAssessmentScanError> Errors { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumberOfFailedSecurityChecks { get { throw null; } }
        public Azure.Provisioning.Synapse.SqlPoolVulnerabilityAssessment Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScanId { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.VulnerabilityAssessmentScanState> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StorageContainerPath { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Synapse.VulnerabilityAssessmentScanTriggerType> TriggerType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.VulnerabilityAssessmentScanRecord FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public enum VulnerabilityAssessmentScanState
    {
        Passed = 0,
        Failed = 1,
        FailedToRun = 2,
        InProgress = 3,
    }
    public enum VulnerabilityAssessmentScanTriggerType
    {
        OnDemand = 0,
        Recurring = 1,
    }
    public partial class WorkloadClassifier : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WorkloadClassifier(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Context { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EndTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Importance { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Label { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MemberName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.WorkloadGroup Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartTime { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.WorkloadClassifier FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class WorkloadGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WorkloadGroup(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Importance { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxResourcePercent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> MaxResourcePercentPerRequest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinResourcePercent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> MinResourcePercentPerRequest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.SqlPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> QueryExecutionTimeout { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.WorkloadGroup FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class WorkspaceAadAdminInfo : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WorkspaceAadAdminInfo(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AdministratorType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Login { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sid { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.WorkspaceAadAdminInfo FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
    public partial class WorkspaceKeyDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkspaceKeyDetails() { }
        public Azure.Provisioning.BicepValue<string> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WorkspacePublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class WorkspaceRepositoryConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkspaceRepositoryConfiguration() { }
        public Azure.Provisioning.BicepValue<string> AccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CollaborationBranch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LastCommitId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProjectName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RepositoryName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RootFolder { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Type { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkspaceSqlAadAdminInfo : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public WorkspaceSqlAadAdminInfo(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Synapse.SynapseWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.Synapse.AadAdminProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Synapse.WorkspaceSqlAadAdminInfo FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2021_06_01_PREVIEW;
        }
    }
}
