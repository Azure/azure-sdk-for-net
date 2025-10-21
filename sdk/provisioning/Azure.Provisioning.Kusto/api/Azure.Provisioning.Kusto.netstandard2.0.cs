namespace Azure.Provisioning.Kusto
{
    public partial class AcceptedAudience : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AcceptedAudience() { }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BlobStorageEventType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.Storage.BlobCreated")]
        MicrosoftStorageBlobCreated = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.Storage.BlobRenamed")]
        MicrosoftStorageBlobRenamed = 1,
    }
    public enum EventHubMessagesCompressionType
    {
        None = 0,
        GZip = 1,
    }
    public partial class KustoAttachedDatabaseConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KustoAttachedDatabaseConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> AttachedDatabaseNames { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ClusterResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DatabaseNameOverride { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DatabaseNamePrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoDatabaseDefaultPrincipalsModificationKind> DefaultPrincipalsModificationKind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Kusto.KustoCluster? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.Kusto.KustoDatabaseTableLevelSharingProperties TableLevelSharingProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Kusto.KustoAttachedDatabaseConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_09_07;
            public static readonly string V2019_11_09;
            public static readonly string V2020_02_15;
            public static readonly string V2020_06_14;
            public static readonly string V2020_09_18;
            public static readonly string V2021_01_01;
            public static readonly string V2021_08_27;
            public static readonly string V2022_02_01;
            public static readonly string V2022_07_07;
            public static readonly string V2022_11_11;
            public static readonly string V2022_12_29;
            public static readonly string V2023_05_02;
            public static readonly string V2023_08_15;
            public static readonly string V2024_04_13;
        }
    }
    public partial class KustoCalloutPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KustoCalloutPolicy() { }
        public Azure.Provisioning.BicepValue<string> CalloutId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoCalloutPolicyCalloutType> CalloutType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CalloutUriRegex { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoCalloutPolicyOutboundAccess> OutboundAccess { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KustoCalloutPolicyCalloutType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="kusto")]
        Kusto = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="sql")]
        Sql = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="cosmosdb")]
        Cosmosdb = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="external_data")]
        ExternalData = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="azure_digital_twins")]
        AzureDigitalTwins = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="sandbox_artifacts")]
        SandboxArtifacts = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="webapi")]
        Webapi = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="mysql")]
        Mysql = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="postgresql")]
        Postgresql = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="genevametrics")]
        Genevametrics = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="azure_openai")]
        AzureOpenai = 10,
    }
    public enum KustoCalloutPolicyOutboundAccess
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class KustoCluster : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KustoCluster(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Kusto.AcceptedAudience> AcceptedAudiences { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AllowedFqdnList { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AllowedIPRangeList { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Kusto.KustoCalloutPolicy> CalloutPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ClusterUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> DataIngestionUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoClusterEngineType> EngineType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAutoStopEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDiskEncryptionEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDoubleEncryptionEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPurgeEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsStreamingIngestEnabled { get { throw null; } set { } }
        public Azure.Provisioning.Kusto.KustoKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Kusto.KustoLanguageExtension> LanguageExtensionsValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.Kusto.MigrationClusterProperties MigrationCluster { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Kusto.OptimizedAutoscale OptimizedAutoscale { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Kusto.KustoPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoClusterPublicIPType> PublicIPType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoClusterPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoClusterNetworkAccessFlag> RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.Kusto.KustoSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoClusterState> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StateReason { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Kusto.KustoClusterTrustedExternalTenant> TrustedExternalTenants { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VirtualClusterGraduationProperties { get { throw null; } set { } }
        public Azure.Provisioning.Kusto.KustoClusterVirtualNetworkConfiguration VirtualNetworkConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoClusterZoneStatus> ZoneStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Kusto.KustoCluster FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_01_21;
            public static readonly string V2019_05_15;
            public static readonly string V2019_09_07;
            public static readonly string V2019_11_09;
            public static readonly string V2020_02_15;
            public static readonly string V2020_06_14;
            public static readonly string V2020_09_18;
            public static readonly string V2021_01_01;
            public static readonly string V2021_08_27;
            public static readonly string V2022_02_01;
            public static readonly string V2022_07_07;
            public static readonly string V2022_11_11;
            public static readonly string V2022_12_29;
            public static readonly string V2023_05_02;
            public static readonly string V2023_08_15;
            public static readonly string V2024_04_13;
        }
    }
    public enum KustoClusterEngineType
    {
        V2 = 0,
        V3 = 1,
    }
    public enum KustoClusterNetworkAccessFlag
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class KustoClusterPrincipalAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KustoClusterPrincipalAssignment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Guid> AadObjectId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ClusterPrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Kusto.KustoCluster? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrincipalName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoPrincipalAssignmentType> PrincipalType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoClusterPrincipalRole> Role { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Kusto.KustoClusterPrincipalAssignment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_11_09;
            public static readonly string V2020_02_15;
            public static readonly string V2020_06_14;
            public static readonly string V2020_09_18;
            public static readonly string V2021_01_01;
            public static readonly string V2021_08_27;
            public static readonly string V2022_02_01;
            public static readonly string V2022_07_07;
            public static readonly string V2022_11_11;
            public static readonly string V2022_12_29;
            public static readonly string V2023_05_02;
            public static readonly string V2023_08_15;
            public static readonly string V2024_04_13;
        }
    }
    public enum KustoClusterPrincipalRole
    {
        AllDatabasesAdmin = 0,
        AllDatabasesViewer = 1,
        AllDatabasesMonitor = 2,
    }
    public enum KustoClusterPublicIPType
    {
        IPv4 = 0,
        DualStack = 1,
    }
    public enum KustoClusterPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum KustoClusterState
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
        Migrated = 9,
    }
    public partial class KustoClusterTrustedExternalTenant : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KustoClusterTrustedExternalTenant() { }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KustoClusterVirtualNetworkConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KustoClusterVirtualNetworkConfiguration() { }
        public Azure.Provisioning.BicepValue<string> DataManagementPublicIPId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnginePublicIPId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoClusterVnetState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KustoClusterVnetState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum KustoClusterZoneStatus
    {
        NonZonal = 0,
        ZonalInconsistency = 1,
        Zonal = 2,
    }
    public partial class KustoCosmosDBDataConnection : Azure.Provisioning.Kusto.KustoDataConnection
    {
        public KustoCosmosDBDataConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CosmosDBAccountResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CosmosDBContainer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CosmosDBDatabase { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ManagedIdentityObjectId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedIdentityResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MappingRuleName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RetrievalStartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KustoDatabase : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KustoDatabase(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Kusto.KustoCluster? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Kusto.KustoDatabase FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_01_21;
            public static readonly string V2019_05_15;
            public static readonly string V2019_09_07;
            public static readonly string V2019_11_09;
            public static readonly string V2020_02_15;
            public static readonly string V2020_06_14;
            public static readonly string V2020_09_18;
            public static readonly string V2021_01_01;
            public static readonly string V2021_08_27;
            public static readonly string V2022_02_01;
            public static readonly string V2022_07_07;
            public static readonly string V2022_11_11;
            public static readonly string V2022_12_29;
            public static readonly string V2023_05_02;
            public static readonly string V2023_08_15;
            public static readonly string V2024_04_13;
        }
    }
    public enum KustoDatabaseCallerRole
    {
        Admin = 0,
        None = 1,
    }
    public enum KustoDatabaseDefaultPrincipalsModificationKind
    {
        Union = 0,
        Replace = 1,
        None = 2,
    }
    public partial class KustoDatabasePrincipalAssignment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KustoDatabasePrincipalAssignment(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Guid> AadObjectId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DatabasePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Kusto.KustoDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrincipalName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoPrincipalAssignmentType> PrincipalType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoDatabasePrincipalRole> Role { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Kusto.KustoDatabasePrincipalAssignment FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_11_09;
            public static readonly string V2020_02_15;
            public static readonly string V2020_06_14;
            public static readonly string V2020_09_18;
            public static readonly string V2021_01_01;
            public static readonly string V2021_08_27;
            public static readonly string V2022_02_01;
            public static readonly string V2022_07_07;
            public static readonly string V2022_11_11;
            public static readonly string V2022_12_29;
            public static readonly string V2023_05_02;
            public static readonly string V2023_08_15;
            public static readonly string V2024_04_13;
        }
    }
    public enum KustoDatabasePrincipalRole
    {
        Admin = 0,
        Ingestor = 1,
        Monitor = 2,
        User = 3,
        UnrestrictedViewer = 4,
        Viewer = 5,
    }
    public enum KustoDatabasePrincipalsModificationKind
    {
        Union = 0,
        Replace = 1,
        None = 2,
    }
    public enum KustoDatabaseRouting
    {
        Single = 0,
        Multi = 1,
    }
    public enum KustoDatabaseShareOrigin
    {
        Direct = 0,
        DataShare = 1,
        Other = 2,
    }
    public partial class KustoDatabaseTableLevelSharingProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KustoDatabaseTableLevelSharingProperties() { }
        public Azure.Provisioning.BicepList<string> ExternalTablesToExclude { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ExternalTablesToInclude { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> FunctionsToExclude { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> FunctionsToInclude { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> MaterializedViewsToExclude { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> MaterializedViewsToInclude { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TablesToExclude { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TablesToInclude { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KustoDataConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KustoDataConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Kusto.KustoDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Kusto.KustoDataConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_01_21;
            public static readonly string V2019_05_15;
            public static readonly string V2019_09_07;
            public static readonly string V2019_11_09;
            public static readonly string V2020_02_15;
            public static readonly string V2020_06_14;
            public static readonly string V2020_09_18;
            public static readonly string V2021_01_01;
            public static readonly string V2021_08_27;
            public static readonly string V2022_02_01;
            public static readonly string V2022_07_07;
            public static readonly string V2022_11_11;
            public static readonly string V2022_12_29;
            public static readonly string V2023_05_02;
            public static readonly string V2023_08_15;
            public static readonly string V2024_04_13;
        }
    }
    public partial class KustoEventGridDataConnection : Azure.Provisioning.Kusto.KustoDataConnection
    {
        public KustoEventGridDataConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.BlobStorageEventType> BlobStorageEventType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConsumerGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoDatabaseRouting> DatabaseRouting { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoEventGridDataFormat> DataFormat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> EventGridResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> EventHubResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsFirstRecordIgnored { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ManagedIdentityObjectId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedIdentityResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MappingRuleName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageAccountResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KustoEventGridDataFormat
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="MULTIJSON")]
        MultiJson = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="JSON")]
        Json = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CSV")]
        Csv = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TSV")]
        Tsv = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SCSV")]
        Scsv = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SOHSV")]
        Sohsv = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PSV")]
        Psv = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TXT")]
        Txt = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RAW")]
        Raw = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SINGLEJSON")]
        SingleJson = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AVRO")]
        Avro = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TSVE")]
        Tsve = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PARQUET")]
        Parquet = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ORC")]
        Orc = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="APACHEAVRO")]
        ApacheAvro = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="W3CLOGFILE")]
        W3CLogFile = 15,
    }
    public partial class KustoEventHubDataConnection : Azure.Provisioning.Kusto.KustoDataConnection
    {
        public KustoEventHubDataConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.EventHubMessagesCompressionType> Compression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConsumerGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoDatabaseRouting> DatabaseRouting { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoEventHubDataFormat> DataFormat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> EventHubResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EventSystemProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ManagedIdentityObjectId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedIdentityResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MappingRuleName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RetrievalStartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KustoEventHubDataFormat
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="MULTIJSON")]
        MultiJson = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="JSON")]
        Json = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CSV")]
        Csv = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TSV")]
        Tsv = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SCSV")]
        Scsv = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SOHSV")]
        Sohsv = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PSV")]
        Psv = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TXT")]
        Txt = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RAW")]
        Raw = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SINGLEJSON")]
        SingleJson = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AVRO")]
        Avro = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TSVE")]
        Tsve = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PARQUET")]
        Parquet = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ORC")]
        Orc = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="APACHEAVRO")]
        ApacheAvro = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="W3CLOGFILE")]
        W3CLogFile = 15,
    }
    public partial class KustoIotHubDataConnection : Azure.Provisioning.Kusto.KustoDataConnection
    {
        public KustoIotHubDataConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ConsumerGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoDatabaseRouting> DatabaseRouting { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoIotHubDataFormat> DataFormat { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> EventSystemProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> IotHubResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MappingRuleName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RetrievalStartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SharedAccessPolicyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KustoIotHubDataFormat
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="MULTIJSON")]
        MultiJson = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="JSON")]
        Json = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="CSV")]
        Csv = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TSV")]
        Tsv = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SCSV")]
        Scsv = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SOHSV")]
        Sohsv = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PSV")]
        Psv = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TXT")]
        Txt = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="RAW")]
        Raw = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SINGLEJSON")]
        SingleJson = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AVRO")]
        Avro = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TSVE")]
        Tsve = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PARQUET")]
        Parquet = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ORC")]
        Orc = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="APACHEAVRO")]
        ApacheAvro = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="W3CLOGFILE")]
        W3CLogFile = 15,
    }
    public partial class KustoKeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KustoKeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> KeyVaultUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KustoLanguageExtension : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KustoLanguageExtension() { }
        public Azure.Provisioning.BicepValue<string> LanguageExtensionCustomImageName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoLanguageExtensionImageName> LanguageExtensionImageName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoLanguageExtensionName> LanguageExtensionName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KustoLanguageExtensionImageName
    {
        Python3_6_5 = 0,
        Python3_9_12 = 1,
        Python3_9_12IncludeDeepLearning = 2,
        Python3_10_8 = 3,
        R = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Python3_10_8_DL")]
        Python3108DL = 5,
        PythonCustomImage = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Python3_11_7")]
        Python3117 = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Python3_11_7_DL")]
        Python3117DL = 8,
    }
    public enum KustoLanguageExtensionName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="PYTHON")]
        Python = 0,
        R = 1,
    }
    public partial class KustoManagedPrivateEndpoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KustoManagedPrivateEndpoint(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Kusto.KustoCluster? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateLinkResourceRegion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RequestMessage { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Kusto.KustoManagedPrivateEndpoint FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_08_27;
            public static readonly string V2022_02_01;
            public static readonly string V2022_07_07;
            public static readonly string V2022_11_11;
            public static readonly string V2022_12_29;
            public static readonly string V2023_05_02;
            public static readonly string V2023_08_15;
            public static readonly string V2024_04_13;
        }
    }
    public enum KustoPrincipalAssignmentType
    {
        App = 0,
        Group = 1,
        User = 2,
    }
    public partial class KustoPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KustoPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Kusto.KustoPrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Kusto.KustoCluster? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Kusto.KustoPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_01_21;
            public static readonly string V2019_05_15;
            public static readonly string V2019_09_07;
            public static readonly string V2019_11_09;
            public static readonly string V2020_02_15;
            public static readonly string V2020_06_14;
            public static readonly string V2020_09_18;
            public static readonly string V2021_01_01;
            public static readonly string V2021_08_27;
            public static readonly string V2022_02_01;
            public static readonly string V2022_07_07;
            public static readonly string V2022_11_11;
            public static readonly string V2022_12_29;
            public static readonly string V2023_05_02;
            public static readonly string V2023_08_15;
            public static readonly string V2024_04_13;
        }
    }
    public partial class KustoPrivateLinkServiceConnectionStateProperty : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KustoPrivateLinkServiceConnectionStateProperty() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KustoProvisioningState
    {
        Running = 0,
        Creating = 1,
        Deleting = 2,
        Succeeded = 3,
        Failed = 4,
        Moving = 5,
        Canceled = 6,
    }
    public partial class KustoReadOnlyFollowingDatabase : Azure.Provisioning.Kusto.KustoDatabase
    {
        public KustoReadOnlyFollowingDatabase(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AttachedDatabaseConfigurationName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoDatabaseShareOrigin> DatabaseShareOrigin { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> HotCachePeriod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LeaderClusterResourceId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> OriginalDatabaseName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoDatabasePrincipalsModificationKind> PrincipalsModificationKind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> SoftDeletePeriod { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> StatisticsSize { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SuspensionStartOn { get { throw null; } }
        public Azure.Provisioning.Kusto.KustoDatabaseTableLevelSharingProperties TableLevelSharingProperties { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KustoReadWriteDatabase : Azure.Provisioning.Kusto.KustoDatabase
    {
        public KustoReadWriteDatabase(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(string)) { }
        public Azure.Provisioning.BicepValue<System.TimeSpan> HotCachePeriod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsFollowed { get { throw null; } }
        public Azure.Provisioning.Kusto.KustoKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> SoftDeletePeriod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> StatisticsSize { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> SuspensionStartOn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KustoScript : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public KustoScript(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ForceUpdateTag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Kusto.KustoDatabase? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.PrincipalPermissionsAction> PrincipalPermissionsAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ScriptContent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoScriptLevel> ScriptLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ScriptUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptUriSasToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ShouldContinueOnErrors { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Kusto.KustoScript FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2021_01_01;
            public static readonly string V2021_08_27;
            public static readonly string V2022_02_01;
            public static readonly string V2022_07_07;
            public static readonly string V2022_11_11;
            public static readonly string V2022_12_29;
            public static readonly string V2023_05_02;
            public static readonly string V2023_08_15;
            public static readonly string V2024_04_13;
        }
    }
    public enum KustoScriptLevel
    {
        Database = 0,
        Cluster = 1,
    }
    public partial class KustoSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KustoSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KustoSkuName
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Dev(No SLA)_Standard_D11_v2")]
        DevNoSlaStandardD11V2 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Dev(No SLA)_Standard_E2a_v4")]
        DevNoSlaStandardE2aV4 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D11_v2")]
        StandardD11V2 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D12_v2")]
        StandardD12V2 = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D13_v2")]
        StandardD13V2 = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D14_v2")]
        StandardD14V2 = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D32d_v4")]
        StandardD32dV4 = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D16d_v5")]
        StandardD16dV5 = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_D32d_v5")]
        StandardD32dV5 = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS13_v2+1TB_PS")]
        StandardDS13V21TBPS = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS13_v2+2TB_PS")]
        StandardDS13V22TBPS = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS14_v2+3TB_PS")]
        StandardDS14V23TBPS = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_DS14_v2+4TB_PS")]
        StandardDS14V24TBPS = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_L4s")]
        StandardL4s = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_L8s")]
        StandardL8s = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_L16s")]
        StandardL16s = 15,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_L8s_v2")]
        StandardL8sV2 = 16,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_L16s_v2")]
        StandardL16sV2 = 17,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_L8s_v3")]
        StandardL8sV3 = 18,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_L16s_v3")]
        StandardL16sV3 = 19,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_L32s_v3")]
        StandardL32sV3 = 20,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_L8as_v3")]
        StandardL8asV3 = 21,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_L16as_v3")]
        StandardL16asV3 = 22,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_L32as_v3")]
        StandardL32asV3 = 23,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E64i_v3")]
        StandardE64iV3 = 24,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E80ids_v4")]
        StandardE80idsV4 = 25,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E2a_v4")]
        StandardE2aV4 = 26,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E4a_v4")]
        StandardE4aV4 = 27,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E8a_v4")]
        StandardE8aV4 = 28,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E16a_v4")]
        StandardE16aV4 = 29,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E8as_v4+1TB_PS")]
        StandardE8asV41TBPS = 30,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E8as_v4+2TB_PS")]
        StandardE8asV42TBPS = 31,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E16as_v4+3TB_PS")]
        StandardE16asV43TBPS = 32,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E16as_v4+4TB_PS")]
        StandardE16asV44TBPS = 33,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E8as_v5+1TB_PS")]
        StandardE8asV51TBPS = 34,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E8as_v5+2TB_PS")]
        StandardE8asV52TBPS = 35,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E16as_v5+3TB_PS")]
        StandardE16asV53TBPS = 36,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E16as_v5+4TB_PS")]
        StandardE16asV54TBPS = 37,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E2ads_v5")]
        StandardE2adsV5 = 38,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E4ads_v5")]
        StandardE4adsV5 = 39,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E8ads_v5")]
        StandardE8adsV5 = 40,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E16ads_v5")]
        StandardE16adsV5 = 41,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_EC8as_v5+1TB_PS")]
        StandardEC8asV51TBPS = 42,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_EC8as_v5+2TB_PS")]
        StandardEC8asV52TBPS = 43,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_EC16as_v5+3TB_PS")]
        StandardEC16asV53TBPS = 44,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_EC16as_v5+4TB_PS")]
        StandardEC16asV54TBPS = 45,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_EC8ads_v5")]
        StandardEC8adsV5 = 46,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_EC16ads_v5")]
        StandardEC16adsV5 = 47,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E8s_v4+1TB_PS")]
        StandardE8sV41TBPS = 48,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E8s_v4+2TB_PS")]
        StandardE8sV42TBPS = 49,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E16s_v4+3TB_PS")]
        StandardE16sV43TBPS = 50,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E16s_v4+4TB_PS")]
        StandardE16sV44TBPS = 51,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E8s_v5+1TB_PS")]
        StandardE8sV51TBPS = 52,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E8s_v5+2TB_PS")]
        StandardE8sV52TBPS = 53,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E16s_v5+3TB_PS")]
        StandardE16sV53TBPS = 54,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E16s_v5+4TB_PS")]
        StandardE16sV54TBPS = 55,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E2d_v4")]
        StandardE2dV4 = 56,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E4d_v4")]
        StandardE4dV4 = 57,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E8d_v4")]
        StandardE8dV4 = 58,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E16d_v4")]
        StandardE16dV4 = 59,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E2d_v5")]
        StandardE2dV5 = 60,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E4d_v5")]
        StandardE4dV5 = 61,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E8d_v5")]
        StandardE8dV5 = 62,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_E16d_v5")]
        StandardE16dV5 = 63,
    }
    public enum KustoSkuTier
    {
        Basic = 0,
        Standard = 1,
    }
    public partial class MigrationClusterProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MigrationClusterProperties() { }
        public Azure.Provisioning.BicepValue<System.Uri> DataIngestionUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.MigrationClusterRole> Role { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MigrationClusterRole
    {
        Source = 0,
        Destination = 1,
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
    public enum PrincipalPermissionsAction
    {
        RetainPermissionOnScriptCompletion = 0,
        RemovePermissionOnScriptCompletion = 1,
    }
    public partial class SandboxCustomImage : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SandboxCustomImage(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> BaseImageName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.SandboxCustomImageLanguage> Language { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LanguageVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Kusto.KustoCluster? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Kusto.KustoProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RequirementsFileContent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Kusto.SandboxCustomImage FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2023_08_15;
            public static readonly string V2024_04_13;
        }
    }
    public enum SandboxCustomImageLanguage
    {
        Python = 0,
    }
}
