namespace Azure.Provisioning.ResourceConnector
{
    public enum ApplianceDistro
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="AKSEdge")]
        AksEdge = 0,
    }
    public partial class ApplianceEvent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplianceEvent() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Severity { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> Timestamp { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Type { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplianceNetworkProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplianceNetworkProfile() { }
        public Azure.Provisioning.BicepValue<string> DnsVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GatewayVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProxyVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ApplianceProvider
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="VMWare")]
        VMware = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HCI")]
        Hci = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SCVMM")]
        Scvmm = 2,
    }
    public enum ApplianceStatus
    {
        WaitingForHeartbeat = 0,
        Validating = 1,
        Connecting = 2,
        Connected = 3,
        Running = 4,
        PreparingForUpgrade = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ETCDSnapshotFailed")]
        EtcdSnapshotFailed = 6,
        UpgradePrerequisitesCompleted = 7,
        ValidatingSFSConnectivity = 8,
        ValidatingImageDownload = 9,
        ValidatingImageUpload = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ValidatingETCDHealth")]
        ValidatingEtcdHealth = 11,
        PreUpgrade = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UpgradingKVAIO")]
        UpgradingKvaio = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="WaitingForKVAIO")]
        WaitingForKvaio = 14,
        ImagePending = 15,
        ImageProvisioning = 16,
        ImageProvisioned = 17,
        ImageDownloading = 18,
        ImageDownloaded = 19,
        ImageDeprovisioning = 20,
        ImageUnknown = 21,
        UpdatingCloudOperator = 22,
        WaitingForCloudOperator = 23,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UpdatingCAPI")]
        UpdatingCapi = 24,
        UpdatingCluster = 25,
        PostUpgrade = 26,
        UpgradeComplete = 27,
        UpgradeClusterExtensionFailedToDelete = 28,
        UpgradeFailed = 29,
        Offline = 30,
        None = 31,
        NetworkProxyUpdatePreparing = 32,
        NetworkProxyUpdating = 33,
        NetworkProxyUpdateComplete = 34,
        NetworkProxyUpdateFailed = 35,
        [System.Runtime.Serialization.DataMemberAttribute(Name="NetworkDNSUpdatePreparing")]
        NetworkDnsUpdatePreparing = 36,
        [System.Runtime.Serialization.DataMemberAttribute(Name="NetworkDNSUpdating")]
        NetworkDnsUpdating = 37,
        [System.Runtime.Serialization.DataMemberAttribute(Name="NetworkDNSUpdateComplete")]
        NetworkDnsUpdateComplete = 38,
        [System.Runtime.Serialization.DataMemberAttribute(Name="NetworkDNSUpdateFailed")]
        NetworkDnsUpdateFailed = 39,
        ArcGatewayUpdatePreparing = 40,
        ArcGatewayUpdating = 41,
        ArcGatewayUpdateComplete = 42,
        ArcGatewayUpdateFailed = 43,
    }
    public partial class ResourceConnectorAppliance : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ResourceConnectorAppliance(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ResourceConnector.ApplianceDistro> Distro { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ResourceConnector.ApplianceEvent> Events { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ResourceConnector.ApplianceProvider> InfrastructureConfigProvider { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ResourceConnector.ApplianceNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PublicKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ResourceConnector.ApplianceStatus> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ResourceConnector.ResourceConnectorAppliance FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2022_10_27;
            public static readonly string V2025_03_01_PREVIEW;
        }
    }
}
