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
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceIPConfigurationData> BackendIPConfigurations { get { throw null; } }
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
    public partial class ApplicationSecurityGroupData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ApplicationSecurityGroupData() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BackendAddressPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public BackendAddressPool(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceIPConfigurationData> BackendIPConfigurations { get { throw null; } }
        public Azure.Provisioning.Network.BackendAddressPoolData Data { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DrainPeriodInSeconds { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> InboundNatRules { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.LoadBalancerBackendAddress> LoadBalancerBackendAddresses { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> LoadBalancingRules { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> OutboundRuleId { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> OutboundRules { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.BackendAddressSyncMode> SyncMode { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.GatewayLoadBalancerTunnelInterface> TunnelInterfaces { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualNetworkId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Network.BackendAddressPool FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
    }
    public partial class BackendAddressPoolData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BackendAddressPoolData() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceIPConfigurationData> BackendIPConfigurations { get { throw null; } }
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
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.BackendAddressSyncMode> SyncMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.GatewayLoadBalancerTunnelInterface> TunnelInterfaces { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualNetworkId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class FlowLogData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FlowLogData() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnabledFilteringCriteria { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Network.FlowLogProperties Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Network.RetentionPolicyParameters RetentionPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TargetResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TargetResourceId { get { throw null; } set { } }
        public Azure.Provisioning.Network.TrafficAnalyticsConfigurationProperties TrafficAnalyticsConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class FrontendIPConfigurationData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FrontendIPConfigurationData() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> GatewayLoadBalancerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> InboundNatPools { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> InboundNatRules { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> LoadBalancingRules { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> OutboundRules { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPVersion> PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.PublicIPAddressData PublicIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PublicIPPrefixId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Network.SubnetData Subnet { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class InboundNatRuleData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public InboundNatRuleData() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> BackendAddressPoolId { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkInterfaceIPConfigurationData BackendIPConfiguration { get { throw null; } }
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
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.LoadBalancingTransportProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
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
    public enum LoadBalancingTransportProtocol
    {
        Udp = 0,
        Tcp = 1,
        All = 2,
    }
    public partial class NatGatewayData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NatGatewayData() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IdleTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> PublicIPAddresses { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> PublicIPAddressesV6 { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> PublicIPPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> PublicIPPrefixesV6 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NatGatewaySkuName> SkuName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceVirtualNetworkId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> Subnets { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class NetworkInterfaceData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkInterfaceData() { }
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
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceIPConfigurationData> IPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MacAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkInterfaceMigrationPhase> MigrationPhase { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Network.NetworkSecurityGroupData NetworkSecurityGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkInterfaceNicType> NicType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Primary { get { throw null; } }
        public Azure.Provisioning.Network.PrivateEndpointData PrivateEndpoint { get { throw null; } }
        public Azure.Provisioning.Network.PrivateLinkServiceData PrivateLinkService { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceTapConfigurationData> TapConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualMachineId { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> VnetEncryptionSupported { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> WorkloadType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class NetworkInterfaceIPConfigurationData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkInterfaceIPConfigurationData() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationGatewayBackendAddressPool> ApplicationGatewayBackendAddressPools { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationSecurityGroupData> ApplicationSecurityGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> GatewayLoadBalancerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.BackendAddressPoolData> LoadBalancerBackendAddressPools { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.InboundNatRuleData> LoadBalancerInboundNatRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Primary { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PrivateIPAddressPrefixLength { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPVersion> PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties PrivateLinkConnectionProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Network.PublicIPAddressData PublicIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } set { } }
        public Azure.Provisioning.Network.SubnetData Subnet { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualNetworkTapData> VirtualNetworkTaps { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class NetworkInterfaceTapConfigurationData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkInterfaceTapConfigurationData() { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Network.VirtualNetworkTapData VirtualNetworkTap { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
        public Azure.Provisioning.Network.PublicIPAddressData PublicIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Network.SubnetData Subnet { get { throw null; } set { } }
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
        public Azure.Provisioning.Network.SubnetData Subnet { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NetworkIPVersion
    {
        IPv4 = 0,
        IPv6 = 1,
    }
    public partial class NetworkPrivateEndpointConnectionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkPrivateEndpointConnectionData() { }
        public Azure.Provisioning.Network.NetworkPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LinkIdentifier { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Network.PrivateEndpointData PrivateEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrivateEndpointLocation { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class NetworkSecurityGroupData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkSecurityGroupData() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SecurityRuleData> DefaultSecurityRules { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FlowLogData> FlowLogs { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> FlushConnection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceData> NetworkInterfaces { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SecurityRuleData> SecurityRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SubnetData> Subnets { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateEndpointData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateEndpointData() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationSecurityGroupData> ApplicationSecurityGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.CustomDnsConfigProperties> CustomDnsConfigs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomNetworkInterfaceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.PrivateEndpointIPConfiguration> IPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkPrivateLinkServiceConnection> ManualPrivateLinkServiceConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceData> NetworkInterfaces { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkPrivateLinkServiceConnection> PrivateLinkServiceConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Network.SubnetData Subnet { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class PrivateLinkServiceData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateLinkServiceData() { }
        public Azure.Provisioning.BicepValue<string> Alias { get { throw null; } }
        public Azure.Provisioning.BicepList<string> AutoApprovalSubscriptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DestinationIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableProxyProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Fqdns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.PrivateLinkServiceIPConfiguration> IPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FrontendIPConfigurationData> LoadBalancerFrontendIPConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceData> NetworkInterfaces { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> VisibilitySubscriptions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
        public Azure.Provisioning.Network.SubnetData Subnet { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PublicIPAddressData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PublicIPAddressData() { }
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
        public Azure.Provisioning.Network.PublicIPAddressData LinkedPublicIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PublicIPAddressMigrationPhase> MigrationPhase { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.Network.NatGatewayData NatGateway { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPVersion> PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkIPAllocationMethod> PublicIPAllocationMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PublicIPPrefixId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.Network.PublicIPAddressData ServicePublicIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.Network.PublicIPAddressSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class RouteData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RouteData() { }
        public Azure.Provisioning.BicepValue<string> AddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> HasBgpOverride { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NextHopIPAddress { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.RouteNextHopType> NextHopType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } set { } }
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
    public partial class RouteTableData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RouteTableData() { }
        public Azure.Provisioning.BicepValue<bool> DisableBgpRoutePropagation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.RouteData> Routes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SubnetData> Subnets { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SecurityRuleAccess
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class SecurityRuleData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecurityRuleData() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityRuleAccess> Access { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DestinationAddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationAddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationSecurityGroupData> DestinationApplicationSecurityGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DestinationPortRange { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DestinationPortRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityRuleDirection> Direction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SecurityRuleProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceAddressPrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourceAddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ApplicationSecurityGroupData> SourceApplicationSecurityGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourcePortRange { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SourcePortRanges { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class ServiceEndpointPolicyData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceEndpointPolicyData() { }
        public Azure.Provisioning.BicepList<string> ContextualServiceEndpointPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ServiceAlias { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ServiceEndpointPolicyDefinitionData> ServiceEndpointPolicyDefinitions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SubnetData> Subnets { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceEndpointPolicyDefinitionData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceEndpointPolicyDefinitionData() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Service { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Core.ResourceIdentifier> ServiceResources { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class SubnetData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SubnetData() { }
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
        public Azure.Provisioning.Network.NetworkSecurityGroupData NetworkSecurityGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkPrivateEndpointNetworkPolicy> PrivateEndpointNetworkPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.PrivateEndpointData> PrivateEndpoints { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkPrivateLinkServiceNetworkPolicy> PrivateLinkServiceNetworkPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Purpose { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ResourceNavigationLink> ResourceNavigationLinks { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } set { } }
        public Azure.Provisioning.Network.RouteTableData RouteTable { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ServiceAssociationLink> ServiceAssociationLinks { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ServiceEndpointPolicyData> ServiceEndpointPolicies { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.ServiceEndpointProperties> ServiceEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.SharingScope> SharingScope { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
        public Azure.Provisioning.BicepList<string> AddressPrefixes { get { throw null; } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace AddressSpace { get { throw null; } }
        public Azure.Provisioning.Network.VirtualNetworkBgpCommunities BgpCommunities { get { throw null; } }
        public Azure.Provisioning.Network.VirtualNetworkData Data { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DdosProtectionPlanId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> DefaultPublicNatGatewayId { get { throw null; } }
        public Azure.Provisioning.BicepList<string> DhcpOptionsDnsServers { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> EnableDdosProtection { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> EnableVmProtection { get { throw null; } }
        public Azure.Provisioning.Network.VirtualNetworkEncryption Encryption { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FlowLogData> FlowLogs { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> FlowTimeoutInMinutes { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> IPAllocations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PrivateEndpointVnetPolicy> PrivateEndpointVnetPolicy { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SubnetData> Subnets { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualNetworkPeeringData> VirtualNetworkPeerings { get { throw null; } }
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
    public partial class VirtualNetworkData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkData() { }
        public Azure.Provisioning.BicepList<string> AddressPrefixes { get { throw null; } set { } }
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
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.FlowLogData> FlowLogs { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> FlowTimeoutInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> IPAllocations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.PrivateEndpointVnetPolicy> PrivateEndpointVnetPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.SubnetData> Subnets { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.VirtualNetworkPeeringData> VirtualNetworkPeerings { get { throw null; } set { } }
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
    public partial class VirtualNetworkPeeringData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkPeeringData() { }
        public Azure.Provisioning.BicepValue<bool> AllowForwardedTraffic { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowGatewayTransit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowVirtualNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AreCompleteVnetsPeered { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DoNotVerifyRemoteGateways { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableOnlyIPv6Peering { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LocalAddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace LocalAddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LocalSubnetNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> LocalVirtualNetworkAddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace LocalVirtualNetworkAddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkPeeringState> PeeringState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.VirtualNetworkPeeringLevel> PeeringSyncLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RemoteAddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace RemoteAddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkBgpCommunities RemoteBgpCommunities { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RemoteSubnetNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RemoteVirtualNetworkAddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkAddressSpace RemoteVirtualNetworkAddressSpace { get { throw null; } set { } }
        public Azure.Provisioning.Network.VirtualNetworkEncryption RemoteVirtualNetworkEncryption { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> RemoteVirtualNetworkId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseRemoteGateways { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
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
    public partial class VirtualNetworkTapData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VirtualNetworkTapData() { }
        public Azure.Provisioning.Network.FrontendIPConfigurationData DestinationLoadBalancerFrontEndIPConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.Network.NetworkInterfaceIPConfigurationData DestinationNetworkInterfaceIPConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DestinationPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Network.NetworkInterfaceTapConfigurationData> NetworkInterfaceTapConfigurations { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Network.NetworkProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> ResourceGuid { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceType> ResourceType { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
