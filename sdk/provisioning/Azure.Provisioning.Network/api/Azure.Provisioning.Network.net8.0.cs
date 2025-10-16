namespace Azure.Provisioning.Network
{
    public partial class ApplicationGatewayBackendAddress : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayBackendAddress() { }
        public Azure.Provisioning.BicepValue<string> Fqdn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPAddress { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayBackendAddressPool : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayBackendAddressPool() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayBackendAddress> BackendAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceIPConfiguration> BackendIPConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationGatewayIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationGatewayIPConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApplicationSecurityGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ApplicationSecurityGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ApplicationSecurityGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public enum AutoLearnPrivateRangesMode
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum AzureFirewallThreatIntelMode
    {
        Alert = 0,
        Deny = 1,
        Off = 2,
    }
    public partial class BackendAddressPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BackendAddressPool(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceIPConfiguration> BackendIPConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> DrainPeriodInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> InboundNatRules { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.LoadBalancerBackendAddress> LoadBalancerBackendAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> LoadBalancingRules { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> OutboundRuleId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> OutboundRules { get { throw null; } }
        public Azure.Provisioning.Network.LoadBalancer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.BackendAddressSyncMode> SyncMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.GatewayLoadBalancerTunnelInterface> TunnelInterfaces { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualNetworkId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.BackendAddressPool FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public enum BackendAddressSyncMode
    {
        Automatic = 0,
        Manual = 1,
    }
    public partial class CustomDnsConfigProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomDnsConfigProperties() { }
        public Azure.Provisioning.BicepValue<string> Fqdn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> IPAddresses { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DdosSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DdosSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DdosProtectionPlanId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.DdosSettingsProtectionMode> ProtectionMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DdosSettingsProtectionCoverage
    {
        Basic = 0,
        Standard = 1,
    }
    public enum DdosSettingsProtectionMode
    {
        VirtualNetworkInherited = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public partial class DnsSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DnsSettings() { }
        public Azure.Provisioning.BicepValue<bool> EnableProxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequireProxyForNetworkRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Servers { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FirewallPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowSqlRedirect { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BasePolicyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> ChildPolicies { get { throw null; } }
        public Azure.Provisioning.Network.DnsSettings DnsSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Network.FirewallPolicyExplicitProxy ExplicitProxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> Firewalls { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicyInsights Insights { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicyIntrusionDetection IntrusionDetection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> RuleCollectionGroups { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.FirewallPolicySkuTier> SkuTier { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicySnat Snat { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.AzureFirewallThreatIntelMode> ThreatIntelMode { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicyThreatIntelWhitelist ThreatIntelWhitelist { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicyCertificateAuthority TransportSecurityCertificateAuthority { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.FirewallPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
            public static readonly string V2025_03_01;
        }
    }
    public partial class FirewallPolicyCertificateAuthority : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyCertificateAuthority() { }
        public Azure.Provisioning.BicepValue<string> KeyVaultSecretId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicyExplicitProxy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyExplicitProxy() { }
        public Azure.Provisioning.BicepValue<bool> EnableExplicitProxy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePacFile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpsPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PacFile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PacFilePort { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicyInsights : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyInsights() { }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.Network.FirewallPolicyLogAnalyticsResources LogAnalyticsResources { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionDays { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicyIntrusionDetection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyIntrusionDetection() { }
        public Azure.Provisioning.Network.FirewallPolicyIntrusionDetectionConfiguration Configuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.FirewallPolicyIntrusionDetectionStateType> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.FirewallPolicyIntrusionDetectionProfileType> Profile { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicyIntrusionDetectionBypassTrafficSpecifications : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyIntrusionDetectionBypassTrafficSpecifications() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationIPGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationPorts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.FirewallPolicyIntrusionDetectionProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceIPGroups { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicyIntrusionDetectionConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyIntrusionDetectionConfiguration() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FirewallPolicyIntrusionDetectionBypassTrafficSpecifications> BypassTrafficSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PrivateRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FirewallPolicyIntrusionDetectionSignatureSpecification> SignatureOverrides { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FirewallPolicyIntrusionDetectionProfileType
    {
        Basic = 0,
        Standard = 1,
        Advanced = 2,
        Extended = 3,
    }
    public enum FirewallPolicyIntrusionDetectionProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="TCP")]
        Tcp = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="UDP")]
        Udp = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ICMP")]
        Icmp = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ANY")]
        Any = 3,
    }
    public partial class FirewallPolicyIntrusionDetectionSignatureSpecification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyIntrusionDetectionSignatureSpecification() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.FirewallPolicyIntrusionDetectionStateType> Mode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FirewallPolicyIntrusionDetectionStateType
    {
        Off = 0,
        Alert = 1,
        Deny = 2,
    }
    public partial class FirewallPolicyLogAnalyticsResources : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyLogAnalyticsResources() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DefaultWorkspaceIdId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FirewallPolicyLogAnalyticsWorkspace> Workspaces { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicyLogAnalyticsWorkspace : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyLogAnalyticsWorkspace() { }
        public Azure.Provisioning.BicepValue<string> Region { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WorkspaceIdId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FirewallPolicySkuTier
    {
        Standard = 0,
        Premium = 1,
        Basic = 2,
    }
    public partial class FirewallPolicySnat : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicySnat() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.AutoLearnPrivateRangesMode> AutoLearnPrivateRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PrivateRanges { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FirewallPolicyThreatIntelWhitelist : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FirewallPolicyThreatIntelWhitelist() { }
        public Azure.Provisioning.BicepList<string> Fqdns { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> IPAddresses { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FlowLog : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FlowLog(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnabledFilteringCriteria { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Network.FlowLogProperties Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkWatcher? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.RetentionPolicyParameters RetentionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TargetResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Network.TrafficAnalyticsConfigurationProperties TrafficAnalyticsConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.FlowLog FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public enum FlowLogFormatType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="JSON")]
        Json = 0,
    }
    public partial class FlowLogProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FlowLogProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.FlowLogFormatType> FormatType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FrontendIPConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public FrontendIPConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> GatewayLoadBalancerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> InboundNatPools { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> InboundNatRules { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> LoadBalancingRules { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> OutboundRules { get { throw null; } }
        public Azure.Provisioning.Network.LoadBalancer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPVersion> PrivateIPAddressVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.PublicIPAddress PublicIPAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PublicIPPrefixId { get { throw null; } }
        public Azure.Provisioning.Network.SubnetResource Subnet { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.FrontendIPConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class GatewayLoadBalancerTunnelInterface : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GatewayLoadBalancerTunnelInterface() { }
        public Azure.Provisioning.BicepValue<int> Identifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.GatewayLoadBalancerTunnelInterfaceType> InterfaceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.GatewayLoadBalancerTunnelProtocol> Protocol { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GatewayLoadBalancerTunnelInterfaceType
    {
        None = 0,
        Internal = 1,
        External = 2,
    }
    public enum GatewayLoadBalancerTunnelProtocol
    {
        None = 0,
        Native = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="VXLAN")]
        Vxlan = 2,
    }
    public partial class InboundNatRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public InboundNatRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BackendAddressPoolId { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkInterfaceIPConfiguration BackendIPConfiguration { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> BackendPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableFloatingIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableTcpReset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FrontendIPConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FrontendPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FrontendPortRangeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FrontendPortRangeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.LoadBalancer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadBalancingTransportProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.InboundNatRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public enum IPAddressDeleteOption
    {
        Delete = 0,
        Detach = 1,
    }
    public partial class IpamPoolPrefixAllocation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IpamPoolPrefixAllocation() { }
        public Azure.Provisioning.BicepList<string> AllocatedAddressPrefixes { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NumberOfIPAddresses { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IPTag : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IPTag() { }
        public Azure.Provisioning.BicepValue<string> IPTagType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tag { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LoadBalancer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public LoadBalancer(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.BackendAddressPool> BackendAddressPools { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FrontendIPConfiguration> FrontendIPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.LoadBalancerInboundNatPool> InboundNatPools { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.InboundNatRule> InboundNatRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.LoadBalancingRule> LoadBalancingRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.OutboundRule> OutboundRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ProbeResource> Probes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Network.LoadBalancerSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.LoadBalancer FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class LoadBalancerBackendAddress : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LoadBalancerBackendAddress() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadBalancerBackendAddressAdminState> AdminState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NatRulePortMapping> InboundNatRulesPortMapping { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LoadBalancerFrontendIPConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NetworkInterfaceIPConfigurationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualNetworkId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LoadBalancerBackendAddressAdminState
    {
        Drain = 0,
        None = 1,
        Up = 2,
        Down = 3,
    }
    public partial class LoadBalancerInboundNatPool : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LoadBalancerInboundNatPool() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.LoadBalancerInboundNatPoolProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LoadBalancerInboundNatPoolProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LoadBalancerInboundNatPoolProperties() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> BackendPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableFloatingIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableTcpReset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FrontendIPConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FrontendPortRangeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FrontendPortRangeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadBalancingTransportProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LoadBalancerOutboundRuleProtocol
    {
        Tcp = 0,
        Udp = 1,
        All = 2,
    }
    public partial class LoadBalancerSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LoadBalancerSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadBalancerSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadBalancerSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LoadBalancerSkuName
    {
        Basic = 0,
        Standard = 1,
        Gateway = 2,
    }
    public enum LoadBalancerSkuTier
    {
        Regional = 0,
        Global = 1,
    }
    public partial class LoadBalancingRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public LoadBalancingRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Network.LoadBalancer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Network.LoadBalancingRuleProperties Properties { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.LoadBalancingRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class LoadBalancingRuleProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LoadBalancingRuleProperties() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BackendAddressPoolId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> BackendAddressPools { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> BackendPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableOutboundSnat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableConnectionTracking { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableFloatingIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableTcpReset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> FrontendIPConfigurationId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FrontendPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadDistribution> LoadDistribution { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ProbeId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadBalancingTransportProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LoadBalancingTransportProtocol
    {
        Udp = 0,
        Tcp = 1,
        All = 2,
    }
    public enum LoadDistribution
    {
        Default = 0,
        SourceIP = 1,
        SourceIPProtocol = 2,
    }
    public partial class NatGateway : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NatGateway(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> PublicIPAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> PublicIPAddressesV6 { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> PublicIPPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> PublicIPPrefixesV6 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NatGatewaySkuName> SkuName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceVirtualNetworkId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> Subnets { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NatGateway FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public enum NatGatewaySkuName
    {
        Standard = 0,
        StandardV2 = 1,
    }
    public partial class NatRulePortMapping : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NatRulePortMapping() { }
        public Azure.Provisioning.BicepValue<int> BackendPort { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> FrontendPort { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InboundNatRuleName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkInterface : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkInterface(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkInterfaceAuxiliaryMode> AuxiliaryMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkInterfaceAuxiliarySku> AuxiliarySku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DefaultOutboundConnectivityEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> DisableTcpStateTracking { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkInterfaceDnsSettings DnsSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DscpConfigurationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> EnableAcceleratedNetworking { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableIPForwarding { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> HostedWorkloads { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceIPConfiguration> IPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MacAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkInterfaceMigrationPhase> MigrationPhase { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkSecurityGroup NetworkSecurityGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkInterfaceNicType> NicType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Primary { get { throw null; } }
        public Azure.Provisioning.Network.PrivateEndpoint PrivateEndpoint { get { throw null; } }
        public Azure.Provisioning.Network.PrivateLinkService PrivateLinkService { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceTapConfiguration> TapConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualMachineId { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> VnetEncryptionSupported { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> WorkloadType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkInterface FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public enum NetworkInterfaceAuxiliaryMode
    {
        None = 0,
        MaxConnections = 1,
        Floating = 2,
        AcceleratedConnections = 3,
    }
    public enum NetworkInterfaceAuxiliarySku
    {
        None = 0,
        A1 = 1,
        A2 = 2,
        A4 = 3,
        A8 = 4,
    }
    public partial class NetworkInterfaceDnsSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkInterfaceDnsSettings() { }
        public Azure.Provisioning.BicepList<string> AppliedDnsServers { get { throw null; } }
        public Azure.Provisioning.BicepList<string> DnsServers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InternalDnsNameLabel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InternalDomainNameSuffix { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> InternalFqdn { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkInterfaceIPConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkInterfaceIPConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayBackendAddressPool> ApplicationGatewayBackendAddressPools { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationSecurityGroup> ApplicationSecurityGroups { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> GatewayLoadBalancerId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.BackendAddressPool> LoadBalancerBackendAddressPools { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.InboundNatRule> LoadBalancerInboundNatRules { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Network.NetworkInterface? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Primary { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PrivateIPAddressPrefixLength { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPVersion> PrivateIPAddressVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get { throw null; } }
        public Azure.Provisioning.Network.NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties PrivateLinkConnectionProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.PublicIPAddress PublicIPAddress { get { throw null; } }
        public Azure.Provisioning.Network.SubnetResource Subnet { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualNetworkTap> VirtualNetworkTaps { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkInterfaceIPConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties() { }
        public Azure.Provisioning.BicepList<string> Fqdns { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RequiredMemberName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NetworkInterfaceMigrationPhase
    {
        None = 0,
        Prepare = 1,
        Commit = 2,
        Abort = 3,
        Committed = 4,
    }
    public enum NetworkInterfaceNicType
    {
        Standard = 0,
        Elastic = 1,
    }
    public partial class NetworkInterfaceTapConfiguration : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkInterfaceTapConfiguration(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkInterface? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.VirtualNetworkTap VirtualNetworkTap { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkInterfaceTapConfiguration FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public enum NetworkIPAllocationMethod
    {
        Static = 0,
        Dynamic = 1,
    }
    public partial class NetworkIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkIPConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.PublicIPAddress PublicIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Network.SubnetResource Subnet { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkIPConfigurationProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkIPConfigurationProfile() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Network.SubnetResource Subnet { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NetworkIPVersion
    {
        IPv4 = 0,
        IPv6 = 1,
    }
    public partial class NetworkPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Network.NetworkPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LinkIdentifier { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.PrivateLinkService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Network.PrivateEndpoint PrivateEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrivateEndpointLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class NetworkPrivateLinkServiceConnection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkPrivateLinkServiceConnection() { }
        public Azure.Provisioning.Network.NetworkPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkServiceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RequestMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NetworkProvisioningState
    {
        Failed = 0,
        Succeeded = 1,
        Canceled = 2,
        Creating = 3,
        Updating = 4,
        Deleting = 5,
    }
    public partial class NetworkSecurityGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkSecurityGroup(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SecurityRule> DefaultSecurityRules { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FlowLog> FlowLogs { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> FlushConnection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterface> NetworkInterfaces { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SecurityRule> SecurityRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SubnetResource> Subnets { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkSecurityGroup FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class NetworkWatcher : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public NetworkWatcher(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.NetworkWatcher FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class OutboundRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public OutboundRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> AllocatedOutboundPorts { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BackendAddressPoolId { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> EnableTcpReset { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> FrontendIPConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Network.LoadBalancer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadBalancerOutboundRuleProtocol> Protocol { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.OutboundRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class PrivateEndpoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PrivateEndpoint(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationSecurityGroup> ApplicationSecurityGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.CustomDnsConfigProperties> CustomDnsConfigs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomNetworkInterfaceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.PrivateEndpointIPConfiguration> IPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkPrivateLinkServiceConnection> ManualPrivateLinkServiceConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterface> NetworkInterfaces { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkPrivateLinkServiceConnection> PrivateLinkServiceConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.SubnetResource Subnet { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.PrivateEndpoint FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class PrivateEndpointIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateEndpointIPConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MemberName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateEndpointIPConfigurationType { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> PrivateIPAddress { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PrivateEndpointVnetPolicy
    {
        Disabled = 0,
        Basic = 1,
    }
    public partial class PrivateLinkService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PrivateLinkService(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Alias { get { throw null; } }
        public Azure.Provisioning.BicepList<string> AutoApprovalSubscriptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DestinationIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableProxyProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Fqdns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.PrivateLinkServiceIPConfiguration> IPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FrontendIPConfiguration> LoadBalancerFrontendIPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterface> NetworkInterfaces { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> VisibilitySubscriptions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.PrivateLinkService FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class PrivateLinkServiceIPConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateLinkServiceIPConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Primary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPVersion> PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Network.SubnetResource Subnet { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ProbeNoHealthyBackendsBehavior
    {
        AllProbedDown = 0,
        AllProbedUp = 1,
    }
    public enum ProbeProtocol
    {
        Http = 0,
        Tcp = 1,
        Https = 2,
    }
    public partial class ProbeResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ProbeResource(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> IntervalInSeconds { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> LoadBalancingRules { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ProbeNoHealthyBackendsBehavior> NoHealthyBackendsBehavior { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> NumberOfProbes { get { throw null; } }
        public Azure.Provisioning.Network.LoadBalancer? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> ProbeThreshold { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.ProbeProtocol> Protocol { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RequestPath { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ProbeResource FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class PublicIPAddress : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PublicIPAddress(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Network.DdosSettings DdosSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.IPAddressDeleteOption> DeleteOption { get { throw null; } set { } }
        public Azure.Provisioning.Network.PublicIPAddressDnsSettings DnsSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPAddress { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkIPConfiguration IPConfiguration { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.IPTag> IPTags { get { throw null; } set { } }
        public Azure.Provisioning.Network.PublicIPAddress LinkedPublicIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PublicIPAddressMigrationPhase> MigrationPhase { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NatGateway NatGateway { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPVersion> PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PublicIPAllocationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PublicIPPrefixId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Network.PublicIPAddress ServicePublicIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.Network.PublicIPAddressSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.PublicIPAddress FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class PublicIPAddressDnsSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PublicIPAddressDnsSettings() { }
        public Azure.Provisioning.BicepValue<string> DomainNameLabel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PublicIPAddressDnsSettingsDomainNameLabelScope> DomainNameLabelScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Fqdn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReverseFqdn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PublicIPAddressDnsSettingsDomainNameLabelScope
    {
        TenantReuse = 0,
        SubscriptionReuse = 1,
        ResourceGroupReuse = 2,
        NoReuse = 3,
    }
    public enum PublicIPAddressMigrationPhase
    {
        None = 0,
        Prepare = 1,
        Commit = 2,
        Abort = 3,
        Committed = 4,
    }
    public partial class PublicIPAddressSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PublicIPAddressSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PublicIPAddressSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PublicIPAddressSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PublicIPAddressSkuName
    {
        Basic = 0,
        Standard = 1,
        StandardV2 = 2,
    }
    public enum PublicIPAddressSkuTier
    {
        Regional = 0,
        Global = 1,
    }
    public partial class PublicIPPrefix : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PublicIPPrefix(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CustomIPPrefixId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IPPrefix { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.IPTag> IPTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> LoadBalancerFrontendIPConfigurationId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NatGateway NatGateway { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PrefixLength { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.SubResource> PublicIPAddresses { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPVersion> PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.Network.PublicIPPrefixSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.PublicIPPrefix FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class PublicIPPrefixSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PublicIPPrefixSku() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PublicIPPrefixSkuName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PublicIPPrefixSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PublicIPPrefixSkuName
    {
        Standard = 0,
        StandardV2 = 1,
    }
    public enum PublicIPPrefixSkuTier
    {
        Regional = 0,
        Global = 1,
    }
    public partial class ResourceNavigationLink : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResourceNavigationLink() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Link { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> LinkedResourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RetentionPolicyParameters : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RetentionPolicyParameters() { }
        public Azure.Provisioning.BicepValue<int> Days { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RouteNextHopType
    {
        VirtualNetworkGateway = 0,
        VnetLocal = 1,
        Internet = 2,
        VirtualAppliance = 3,
        None = 4,
    }
    public partial class RouteResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RouteResource(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> HasBgpOverride { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NextHopIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.RouteNextHopType> NextHopType { get { throw null; } set { } }
        public Azure.Provisioning.Network.RouteTable? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.RouteResource FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class RouteTable : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public RouteTable(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> DisableBgpRoutePropagation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.RouteResource> Routes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SubnetResource> Subnets { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.RouteTable FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class SecurityRule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SecurityRule(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityRuleAccess> Access { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DestinationAddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationAddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationSecurityGroup> DestinationApplicationSecurityGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DestinationPortRange { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationPortRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityRuleDirection> Direction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkSecurityGroup? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityRuleProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SourceAddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceAddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationSecurityGroup> SourceApplicationSecurityGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourcePortRange { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourcePortRanges { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.SecurityRule FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public enum SecurityRuleAccess
    {
        Allow = 0,
        Deny = 1,
    }
    public enum SecurityRuleDirection
    {
        Inbound = 0,
        Outbound = 1,
    }
    public enum SecurityRuleProtocol
    {
        Tcp = 0,
        Udp = 1,
        Icmp = 2,
        Esp = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="*")]
        Asterisk = 4,
        Ah = 5,
    }
    public partial class ServiceAssociationLink : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceAssociationLink() { }
        public Azure.Provisioning.BicepValue<bool> AllowDelete { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Link { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> LinkedResourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.AzureLocation> Locations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceDelegation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceDelegation() { }
        public Azure.Provisioning.BicepList<string> Actions { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceEndpointPolicy : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceEndpointPolicy(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<string> ContextualServiceEndpointPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ServiceAlias { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ServiceEndpointPolicyDefinition> ServiceEndpointPolicyDefinitions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SubnetResource> Subnets { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ServiceEndpointPolicy FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class ServiceEndpointPolicyDefinition : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ServiceEndpointPolicyDefinition(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.ServiceEndpointPolicy? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Service { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> ServiceResources { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.ServiceEndpointPolicyDefinition FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class ServiceEndpointProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceEndpointProperties() { }
        public Azure.Provisioning.BicepList<Azure.Core.AzureLocation> Locations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NetworkIdentifierId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Service { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SharingScope
    {
        Tenant = 0,
        DelegatedServices = 1,
    }
    public partial class SubnetResource : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SubnetResource(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayIPConfiguration> ApplicationGatewayIPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DefaultOutboundAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ServiceDelegation> Delegations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> IPAllocations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.IpamPoolPrefixAllocation> IpamPoolPrefixAllocations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkIPConfigurationProfile> IPConfigurationProfiles { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkIPConfiguration> IPConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> NatGatewayId { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkSecurityGroup NetworkSecurityGroup { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetwork? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkPrivateEndpointNetworkPolicy> PrivateEndpointNetworkPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.PrivateEndpoint> PrivateEndpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkPrivateLinkServiceNetworkPolicy> PrivateLinkServiceNetworkPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Purpose { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ResourceNavigationLink> ResourceNavigationLinks { get { throw null; } }
        public Azure.Provisioning.Network.RouteTable RouteTable { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ServiceAssociationLink> ServiceAssociationLinks { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ServiceEndpointPolicy> ServiceEndpointPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ServiceEndpointProperties> ServiceEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SharingScope> SharingScope { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.SubnetResource FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public enum SyncRemoteAddressSpace
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="true")]
        True = 0,
    }
    public partial class TrafficAnalyticsConfigurationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TrafficAnalyticsConfigurationProperties() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TrafficAnalyticsIntervalInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceRegion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> WorkspaceResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualNetwork : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualNetwork(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace AddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkBgpCommunities BgpCommunities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DdosProtectionPlanId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DefaultPublicNatGatewayId { get { throw null; } }
        public Azure.Provisioning.BicepList<string> DhcpOptionsDnsServers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableDdosProtection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableVmProtection { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkEncryption Encryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FlowLog> FlowLogs { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> FlowTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> IPAllocations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PrivateEndpointVnetPolicy> PrivateEndpointVnetPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SubnetResource> Subnets { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualNetworkPeering> VirtualNetworkPeerings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VirtualNetwork FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public partial class VirtualNetworkAddressSpace : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkAddressSpace() { }
        public Azure.Provisioning.BicepList<string> AddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.IpamPoolPrefixAllocation> IpamPoolPrefixAllocations { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualNetworkBgpCommunities : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkBgpCommunities() { }
        public Azure.Provisioning.BicepValue<string> RegionalCommunity { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VirtualNetworkCommunity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VirtualNetworkEncryption : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkEncryption() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkEncryptionEnforcement> Enforcement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VirtualNetworkEncryptionEnforcement
    {
        DropUnencrypted = 0,
        AllowUnencrypted = 1,
    }
    public partial class VirtualNetworkPeering : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualNetworkPeering(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowForwardedTraffic { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowGatewayTransit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowVirtualNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AreCompleteVnetsPeered { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DoNotVerifyRemoteGateways { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableOnlyIPv6Peering { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace LocalAddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LocalSubnetNames { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace LocalVirtualNetworkAddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetwork? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkPeeringState> PeeringState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkPeeringLevel> PeeringSyncLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace RemoteAddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkBgpCommunities RemoteBgpCommunities { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RemoteSubnetNames { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace RemoteVirtualNetworkAddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkEncryption RemoteVirtualNetworkEncryption { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RemoteVirtualNetworkId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> UseRemoteGateways { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VirtualNetworkPeering FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2015_06_15;
            public static readonly string V2016_03_30;
            public static readonly string V2016_06_01;
            public static readonly string V2016_07_01;
            public static readonly string V2016_08_01;
            public static readonly string V2016_09_01;
            public static readonly string V2016_10_01;
            public static readonly string V2016_11_01;
            public static readonly string V2016_12_01;
            public static readonly string V2017_03_01;
            public static readonly string V2017_04_01;
            public static readonly string V2017_06_01;
            public static readonly string V2017_08_01;
            public static readonly string V2017_09_01;
            public static readonly string V2017_10_01;
            public static readonly string V2017_11_01;
            public static readonly string V2018_01_01;
            public static readonly string V2018_02_01;
            public static readonly string V2018_03_01;
            public static readonly string V2018_04_01;
            public static readonly string V2018_05_01;
            public static readonly string V2018_06_01;
            public static readonly string V2018_07_01;
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
    public enum VirtualNetworkPeeringLevel
    {
        FullyInSync = 0,
        RemoteNotInSync = 1,
        LocalNotInSync = 2,
        LocalAndRemoteNotInSync = 3,
    }
    public enum VirtualNetworkPeeringState
    {
        Initiated = 0,
        Connected = 1,
        Disconnected = 2,
    }
    public enum VirtualNetworkPrivateEndpointNetworkPolicy
    {
        Enabled = 0,
        Disabled = 1,
        NetworkSecurityGroupEnabled = 2,
        RouteTableEnabled = 3,
    }
    public enum VirtualNetworkPrivateLinkServiceNetworkPolicy
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class VirtualNetworkTap : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public VirtualNetworkTap(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Network.FrontendIPConfiguration DestinationLoadBalancerFrontEndIPConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkInterfaceIPConfiguration DestinationNetworkInterfaceIPConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DestinationPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceTapConfiguration> NetworkInterfaceTapConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.VirtualNetworkTap FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_08_01;
            public static readonly string V2018_10_01;
            public static readonly string V2018_11_01;
            public static readonly string V2018_12_01;
            public static readonly string V2019_02_01;
            public static readonly string V2019_04_01;
            public static readonly string V2019_06_01;
            public static readonly string V2019_07_01;
            public static readonly string V2019_08_01;
            public static readonly string V2019_09_01;
            public static readonly string V2019_11_01;
            public static readonly string V2019_12_01;
            public static readonly string V2020_01_01;
            public static readonly string V2020_03_01;
            public static readonly string V2020_04_01;
            public static readonly string V2020_05_01;
            public static readonly string V2020_06_01;
            public static readonly string V2020_07_01;
            public static readonly string V2020_08_01;
            public static readonly string V2020_11_01;
            public static readonly string V2021_01_01;
            public static readonly string V2021_02_01;
            public static readonly string V2021_03_01;
            public static readonly string V2021_04_01;
            public static readonly string V2021_05_01;
            public static readonly string V2021_06_01;
            public static readonly string V2021_08_01;
            public static readonly string V2021_12_01;
            public static readonly string V2022_01_01;
            public static readonly string V2022_05_01;
            public static readonly string V2022_07_01;
            public static readonly string V2022_09_01;
            public static readonly string V2022_11_01;
            public static readonly string V2023_02_01;
            public static readonly string V2023_04_01;
            public static readonly string V2023_05_01;
            public static readonly string V2023_06_01;
            public static readonly string V2023_09_01;
            public static readonly string V2023_11_01;
            public static readonly string V2024_01_01;
            public static readonly string V2024_03_01;
            public static readonly string V2024_05_01;
            public static readonly string V2024_07_01;
            public static readonly string V2024_10_01;
            public static readonly string V2025_01_01;
        }
    }
}
