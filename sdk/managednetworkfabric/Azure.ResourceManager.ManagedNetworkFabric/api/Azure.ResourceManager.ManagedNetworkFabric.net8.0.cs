namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class AzureResourceManagerManagedNetworkFabricContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerManagedNetworkFabricContext() { }
        public static Azure.ResourceManager.ManagedNetworkFabric.AzureResourceManagerManagedNetworkFabricContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ManagedNetworkFabricExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> GetNetworkDevice(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> GetNetworkDeviceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource GetNetworkDeviceInterfaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource GetNetworkDeviceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceCollection GetNetworkDevices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> GetNetworkDevices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> GetNetworkDevicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource> GetNetworkDeviceSku(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string networkDeviceSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource>> GetNetworkDeviceSkuAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string networkDeviceSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource GetNetworkDeviceSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuCollection GetNetworkDeviceSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> GetNetworkFabric(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> GetNetworkFabricAccessControlList(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accessControlListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource>> GetNetworkFabricAccessControlListAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accessControlListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource GetNetworkFabricAccessControlListResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListCollection GetNetworkFabricAccessControlLists(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> GetNetworkFabricAccessControlLists(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> GetNetworkFabricAccessControlListsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> GetNetworkFabricAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> GetNetworkFabricController(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkFabricControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> GetNetworkFabricControllerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkFabricControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource GetNetworkFabricControllerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerCollection GetNetworkFabricControllers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> GetNetworkFabricControllers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> GetNetworkFabricControllersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource GetNetworkFabricExternalNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource GetNetworkFabricInternalNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource> GetNetworkFabricInternetGateway(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string internetGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource>> GetNetworkFabricInternetGatewayAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string internetGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource GetNetworkFabricInternetGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> GetNetworkFabricInternetGatewayRule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string internetGatewayRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource>> GetNetworkFabricInternetGatewayRuleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string internetGatewayRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource GetNetworkFabricInternetGatewayRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleCollection GetNetworkFabricInternetGatewayRules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> GetNetworkFabricInternetGatewayRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> GetNetworkFabricInternetGatewayRulesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayCollection GetNetworkFabricInternetGateways(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource> GetNetworkFabricInternetGateways(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource> GetNetworkFabricInternetGatewaysAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityCollection GetNetworkFabricIPCommunities(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> GetNetworkFabricIPCommunities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> GetNetworkFabricIPCommunitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> GetNetworkFabricIPCommunity(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource>> GetNetworkFabricIPCommunityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource GetNetworkFabricIPCommunityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityCollection GetNetworkFabricIPExtendedCommunities(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> GetNetworkFabricIPExtendedCommunities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> GetNetworkFabricIPExtendedCommunitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> GetNetworkFabricIPExtendedCommunity(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipExtendedCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource>> GetNetworkFabricIPExtendedCommunityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipExtendedCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource GetNetworkFabricIPExtendedCommunityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> GetNetworkFabricIPPrefix(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource>> GetNetworkFabricIPPrefixAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixCollection GetNetworkFabricIPPrefixes(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> GetNetworkFabricIPPrefixes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> GetNetworkFabricIPPrefixesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource GetNetworkFabricIPPrefixResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> GetNetworkFabricL2IsolationDomain(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l2IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource>> GetNetworkFabricL2IsolationDomainAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l2IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource GetNetworkFabricL2IsolationDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainCollection GetNetworkFabricL2IsolationDomains(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> GetNetworkFabricL2IsolationDomains(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> GetNetworkFabricL2IsolationDomainsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> GetNetworkFabricL3IsolationDomain(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l3IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource>> GetNetworkFabricL3IsolationDomainAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l3IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource GetNetworkFabricL3IsolationDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainCollection GetNetworkFabricL3IsolationDomains(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> GetNetworkFabricL3IsolationDomains(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> GetNetworkFabricL3IsolationDomainsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> GetNetworkFabricNeighborGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string neighborGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource>> GetNetworkFabricNeighborGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string neighborGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource GetNetworkFabricNeighborGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupCollection GetNetworkFabricNeighborGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> GetNetworkFabricNeighborGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> GetNetworkFabricNeighborGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource GetNetworkFabricResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyCollection GetNetworkFabricRoutePolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> GetNetworkFabricRoutePolicies(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> GetNetworkFabricRoutePoliciesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> GetNetworkFabricRoutePolicy(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource>> GetNetworkFabricRoutePolicyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource GetNetworkFabricRoutePolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricCollection GetNetworkFabrics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> GetNetworkFabrics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> GetNetworkFabricsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource> GetNetworkFabricSku(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string networkFabricSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource>> GetNetworkFabricSkuAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string networkFabricSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource GetNetworkFabricSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuCollection GetNetworkFabricSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> GetNetworkPacketBroker(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkPacketBrokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> GetNetworkPacketBrokerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkPacketBrokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource GetNetworkPacketBrokerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerCollection GetNetworkPacketBrokers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> GetNetworkPacketBrokers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> GetNetworkPacketBrokersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> GetNetworkRack(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> GetNetworkRackAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource GetNetworkRackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkRackCollection GetNetworkRacks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> GetNetworkRacks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> GetNetworkRacksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> GetNetworkTap(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkTapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> GetNetworkTapAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkTapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource GetNetworkTapResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> GetNetworkTapRule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkTapRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> GetNetworkTapRuleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string networkTapRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource GetNetworkTapRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleCollection GetNetworkTapRules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> GetNetworkTapRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> GetNetworkTapRulesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkTapCollection GetNetworkTaps(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> GetNetworkTaps(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> GetNetworkTapsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource GetNetworkToNetworkInterconnectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class NetworkDeviceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>, System.Collections.IEnumerable
    {
        protected NetworkDeviceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkDeviceName, Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkDeviceName, Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> Get(string networkDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> GetAsync(string networkDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> GetIfExists(string networkDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> GetIfExistsAsync(string networkDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkDeviceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData>
    {
        public NetworkDeviceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        public string HostName { get { throw null; } set { } }
        public System.Net.IPAddress ManagementIPv4Address { get { throw null; } }
        public string ManagementIPv6Address { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole? NetworkDeviceRole { get { throw null; } }
        public string NetworkDeviceSku { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkRackId { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        public string SerialNumber { get { throw null; } set { } }
        public string Version { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkDeviceInterfaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource>, System.Collections.IEnumerable
    {
        protected NetworkDeviceInterfaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkInterfaceName, Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkInterfaceName, Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource> Get(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource>> GetAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource> GetIfExists(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource>> GetIfExistsAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkDeviceInterfaceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData>
    {
        public NetworkDeviceInterfaceData() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public string ConnectedTo { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceType? InterfaceType { get { throw null; } }
        public System.Net.IPAddress IPv4Address { get { throw null; } }
        public string IPv6Address { get { throw null; } }
        public string PhysicalIdentifier { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkDeviceInterfaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkDeviceInterfaceResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkDeviceName, string networkInterfaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkDeviceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkDeviceResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkDeviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource> GetNetworkDeviceInterface(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource>> GetNetworkDeviceInterfaceAsync(string networkInterfaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceCollection GetNetworkDeviceInterfaces() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> Reboot(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> RebootAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> RefreshConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> RefreshConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateDeviceAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateDeviceAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> Upgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricUpdateVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> UpgradeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricUpdateVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkDeviceSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource>, System.Collections.IEnumerable
    {
        protected NetworkDeviceSkuCollection() { }
        public virtual Azure.Response<bool> Exists(string networkDeviceSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkDeviceSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource> Get(string networkDeviceSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource>> GetAsync(string networkDeviceSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource> GetIfExists(string networkDeviceSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource>> GetIfExistsAsync(string networkDeviceSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkDeviceSkuData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData>
    {
        public NetworkDeviceSkuData(string model) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceProperties> Interfaces { get { throw null; } }
        public string Manufacturer { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName> SupportedRoleTypes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedVersionProperties> SupportedVersions { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkDeviceSkuResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkDeviceSkuResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string networkDeviceSkuName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricAccessControlListCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricAccessControlListCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accessControlListName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accessControlListName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accessControlListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accessControlListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> Get(string accessControlListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource>> GetAsync(string accessControlListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> GetIfExists(string accessControlListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource>> GetIfExistsAsync(string accessControlListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricAccessControlListData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData>
    {
        public NetworkFabricAccessControlListData(Azure.Core.AzureLocation location) { }
        public System.Uri AclsUri { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType? ConfigurationType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration> DynamicMatchConfigurations { get { throw null; } }
        public System.DateTimeOffset? LastSyncedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchConfiguration> MatchConfigurations { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricAccessControlListResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricAccessControlListResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accessControlListName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> Resync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> ResyncAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAccessControlListPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAccessControlListPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult> ValidateConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult>> ValidateConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFabricCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkFabricName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkFabricName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> Get(string networkFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> GetAsync(string networkFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> GetIfExists(string networkFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> GetIfExistsAsync(string networkFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricControllerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricControllerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkFabricControllerName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkFabricControllerName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkFabricControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkFabricControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> Get(string networkFabricControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> GetAsync(string networkFabricControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> GetIfExists(string networkFabricControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> GetIfExistsAsync(string networkFabricControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricControllerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData>
    {
        public NetworkFabricControllerData(Azure.Core.AzureLocation location) { }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation> InfrastructureExpressRouteConnections { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerServices InfrastructureServices { get { throw null; } }
        public string IPv4AddressSpace { get { throw null; } set { } }
        public string IPv6AddressSpace { get { throw null; } set { } }
        public bool? IsWorkloadManagementNetwork { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled? IsWorkloadManagementNetworkEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ManagedResourceGroupConfiguration ManagedResourceGroupConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> NetworkFabricIds { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerSKU? NfcSku { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> TenantInternetGatewayIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation> WorkloadExpressRouteConnections { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerServices WorkloadServices { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricControllerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricControllerResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkFabricControllerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFabricData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData>
    {
        public NetworkFabricData(Azure.Core.AzureLocation location, string networkFabricSku, Azure.Core.ResourceIdentifier networkFabricControllerId, int serverCountPerRack, string ipv4Prefix, long fabricAsn, Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerConfiguration terminalServerConfiguration, Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationProperties managementNetworkConfiguration) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        public long FabricAsn { get { throw null; } set { } }
        public string FabricVersion { get { throw null; } }
        public string IPv4Prefix { get { throw null; } set { } }
        public string IPv6Prefix { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> L2IsolationDomains { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> L3IsolationDomains { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationProperties ManagementNetworkConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkFabricControllerId { get { throw null; } set { } }
        public string NetworkFabricSku { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        public int? RackCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Racks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RouterIds { get { throw null; } }
        public int ServerCountPerRack { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerConfiguration TerminalServerConfiguration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricExternalNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricExternalNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string externalNetworkName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string externalNetworkName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string externalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string externalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource> Get(string externalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource>> GetAsync(string externalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource> GetIfExists(string externalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource>> GetIfExistsAsync(string externalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricExternalNetworkData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData>
    {
        public NetworkFabricExternalNetworkData(Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption peeringOption) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy ExportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExportRoutePolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy ImportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ImportRoutePolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkToNetworkInterconnectId { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkOptionAProperties OptionAProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.L3OptionBProperties OptionBProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption PeeringOption { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricExternalNetworkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricExternalNetworkResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string l3IsolationDomainName, string externalNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricExternalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricExternalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> UpdateStaticRouteBfdAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> UpdateStaticRouteBfdAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFabricInternalNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricInternalNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string internalNetworkName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string internalNetworkName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string internalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string internalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource> Get(string internalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource>> GetAsync(string internalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource> GetIfExists(string internalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource>> GetIfExistsAsync(string internalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricInternalNetworkData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData>
    {
        public NetworkFabricInternalNetworkData(int vlanId) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkBgpConfiguration BgpConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet> ConnectedIPv4Subnets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet> ConnectedIPv6Subnets { get { throw null; } }
        public Azure.Core.ResourceIdentifier EgressAclId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy ExportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExportRoutePolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfigurationExtension? Extension { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy ImportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ImportRoutePolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IngressAclId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled? IsMonitoringEnabled { get { throw null; } set { } }
        public int? Mtu { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkStaticRouteConfiguration StaticRouteConfiguration { get { throw null; } set { } }
        public int VlanId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricInternalNetworkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricInternalNetworkResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string l3IsolationDomainName, string internalNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternalNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> UpdateBgpAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> UpdateBgpAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> UpdateStaticRouteBfdAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> UpdateStaticRouteBfdAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFabricInternetGatewayCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricInternetGatewayCollection() { }
        public virtual Azure.Response<bool> Exists(string internetGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string internetGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource> Get(string internetGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource>> GetAsync(string internetGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource> GetIfExists(string internetGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource>> GetIfExistsAsync(string internetGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricInternetGatewayData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData>
    {
        public NetworkFabricInternetGatewayData(Azure.Core.AzureLocation location, Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayType typePropertiesType, Azure.Core.ResourceIdentifier networkFabricControllerId) { }
        public string Annotation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier InternetGatewayRuleId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("IPv4Address is deprecated, use IPV4Address instead")]
        public System.Net.IPAddress IPv4Address { get { throw null; } }
        public string IPV4Address { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkFabricControllerId { get { throw null; } set { } }
        public int? Port { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayType TypePropertiesType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricInternetGatewayResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricInternetGatewayResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string internetGatewayName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFabricInternetGatewayRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricInternetGatewayRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string internetGatewayRuleName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string internetGatewayRuleName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string internetGatewayRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string internetGatewayRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> Get(string internetGatewayRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource>> GetAsync(string internetGatewayRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> GetIfExists(string internetGatewayRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource>> GetIfExistsAsync(string internetGatewayRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricInternetGatewayRuleData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData>
    {
        public NetworkFabricInternetGatewayRuleData(Azure.Core.AzureLocation location, Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRules ruleProperties) { }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> InternetGatewayIds { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRules RuleProperties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricInternetGatewayRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricInternetGatewayRuleResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string internetGatewayRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFabricIPCommunityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricIPCommunityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ipCommunityName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ipCommunityName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ipCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ipCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> Get(string ipCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource>> GetAsync(string ipCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> GetIfExists(string ipCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource>> GetIfExistsAsync(string ipCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricIPCommunityData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData>
    {
        public NetworkFabricIPCommunityData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityRule> IPCommunityRules { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricIPCommunityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricIPCommunityResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ipCommunityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPCommunityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPCommunityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFabricIPExtendedCommunityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricIPExtendedCommunityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ipExtendedCommunityName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ipExtendedCommunityName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ipExtendedCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ipExtendedCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> Get(string ipExtendedCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource>> GetAsync(string ipExtendedCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> GetIfExists(string ipExtendedCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource>> GetIfExistsAsync(string ipExtendedCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricIPExtendedCommunityData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData>
    {
        public NetworkFabricIPExtendedCommunityData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityRule> ipExtendedCommunityRules) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityRule> IPExtendedCommunityRules { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricIPExtendedCommunityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricIPExtendedCommunityResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ipExtendedCommunityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPExtendedCommunityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPExtendedCommunityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFabricIPPrefixCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricIPPrefixCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ipPrefixName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ipPrefixName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ipPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ipPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> Get(string ipPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource>> GetAsync(string ipPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> GetIfExists(string ipPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource>> GetIfExistsAsync(string ipPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricIPPrefixData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData>
    {
        public NetworkFabricIPPrefixData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRule> IPPrefixRules { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricIPPrefixResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricIPPrefixResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ipPrefixName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPPrefixPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPPrefixPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFabricL2IsolationDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricL2IsolationDomainCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string l2IsolationDomainName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string l2IsolationDomainName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string l2IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string l2IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> Get(string l2IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource>> GetAsync(string l2IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> GetIfExists(string l2IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource>> GetIfExistsAsync(string l2IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricL2IsolationDomainData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData>
    {
        public NetworkFabricL2IsolationDomainData(Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier networkFabricId, int vlanId) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        public int? Mtu { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkFabricId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        public int VlanId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricL2IsolationDomainResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricL2IsolationDomainResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> CommitConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> CommitConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string l2IsolationDomainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL2IsolationDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL2IsolationDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult> ValidateConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult>> ValidateConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFabricL3IsolationDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricL3IsolationDomainCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string l3IsolationDomainName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string l3IsolationDomainName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string l3IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string l3IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> Get(string l3IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource>> GetAsync(string l3IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> GetIfExists(string l3IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource>> GetIfExistsAsync(string l3IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricL3IsolationDomainData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData>
    {
        public NetworkFabricL3IsolationDomainData(Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier networkFabricId) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? AdministrativeState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRouteConfiguration AggregateRouteConfiguration { get { throw null; } set { } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnetRoutePolicy ConnectedSubnetRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkFabricId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet? RedistributeConnectedSubnets { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute? RedistributeStaticRoutes { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricL3IsolationDomainResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricL3IsolationDomainResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> CommitConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> CommitConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string l3IsolationDomainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource> GetNetworkFabricExternalNetwork(string externalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource>> GetNetworkFabricExternalNetworkAsync(string externalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkCollection GetNetworkFabricExternalNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource> GetNetworkFabricInternalNetwork(string internalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource>> GetNetworkFabricInternalNetworkAsync(string internalNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkCollection GetNetworkFabricInternalNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL3IsolationDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL3IsolationDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult> ValidateConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult>> ValidateConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFabricNeighborGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricNeighborGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string neighborGroupName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string neighborGroupName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string neighborGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string neighborGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> Get(string neighborGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource>> GetAsync(string neighborGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> GetIfExists(string neighborGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource>> GetIfExistsAsync(string neighborGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricNeighborGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData>
    {
        public NetworkFabricNeighborGroupData(Azure.Core.AzureLocation location) { }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborGroupDestination Destination { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> NetworkTapIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> NetworkTapRuleIds { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricNeighborGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricNeighborGroupResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string neighborGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricNeighborGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricNeighborGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFabricResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> CommitConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> CommitConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkFabricName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult> Deprovision(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult>> DeprovisionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> GetNetworkToNetworkInterconnect(string networkToNetworkInterconnectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>> GetNetworkToNetworkInterconnectAsync(string networkToNetworkInterconnectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectCollection GetNetworkToNetworkInterconnects() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult> GetTopology(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult>> GetTopologyAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult> Provision(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult>> ProvisionAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> RefreshConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> RefreshConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> UpdateInfraManagementBfdConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> UpdateInfraManagementBfdConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> UpdateWorkloadManagementBfdConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> UpdateWorkloadManagementBfdConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> Upgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricUpdateVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> UpgradeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricUpdateVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult> ValidateConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult>> ValidateConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFabricRoutePolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricRoutePolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string routePolicyName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string routePolicyName, Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> Get(string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource>> GetAsync(string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> GetIfExists(string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource>> GetIfExistsAsync(string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricRoutePolicyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData>
    {
        public NetworkFabricRoutePolicyData(Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier networkFabricId) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType? AddressFamilyType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType? DefaultAction { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkFabricId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyStatementProperties> Statements { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricRoutePolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricRoutePolicyResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> CommitConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> CommitConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string routePolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricRoutePolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricRoutePolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult> ValidateConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult>> ValidateConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkFabricSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource>, System.Collections.IEnumerable
    {
        protected NetworkFabricSkuCollection() { }
        public virtual Azure.Response<bool> Exists(string networkFabricSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkFabricSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource> Get(string networkFabricSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource>> GetAsync(string networkFabricSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource> GetIfExists(string networkFabricSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource>> GetIfExistsAsync(string networkFabricSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkFabricSkuData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData>
    {
        public NetworkFabricSkuData() { }
        public string Details { get { throw null; } }
        public int? MaxComputeRacks { get { throw null; } set { } }
        public int? MaximumServerCount { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedVersions { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricSkuType? TypePropertiesType { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricSkuResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkFabricSkuResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string networkFabricSkuName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkPacketBrokerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>, System.Collections.IEnumerable
    {
        protected NetworkPacketBrokerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkPacketBrokerName, Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkPacketBrokerName, Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkPacketBrokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkPacketBrokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> Get(string networkPacketBrokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> GetAsync(string networkPacketBrokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> GetIfExists(string networkPacketBrokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> GetIfExistsAsync(string networkPacketBrokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkPacketBrokerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData>
    {
        public NetworkPacketBrokerData(Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier networkFabricId) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> NeighborGroupIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> NetworkDeviceIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkFabricId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> NetworkTapIds { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> SourceInterfaceIds { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkPacketBrokerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkPacketBrokerResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkPacketBrokerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkPacketBrokerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkPacketBrokerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkRackCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>, System.Collections.IEnumerable
    {
        protected NetworkRackCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkRackName, Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkRackName, Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> Get(string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> GetAsync(string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> GetIfExists(string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> GetIfExistsAsync(string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkRackData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData>
    {
        public NetworkRackData(Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier networkFabricId) { }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> NetworkDevices { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkFabricId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType? NetworkRackType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkRackResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkRackResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkRackName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkTapCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>, System.Collections.IEnumerable
    {
        protected NetworkTapCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkTapName, Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkTapName, Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkTapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkTapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> Get(string networkTapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> GetAsync(string networkTapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> GetIfExists(string networkTapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> GetIfExistsAsync(string networkTapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkTapData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData>
    {
        public NetworkTapData(Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier networkPacketBrokerId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPropertiesDestinationsItem> destinations) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPropertiesDestinationsItem> Destinations { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkPacketBrokerId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPollingType? PollingType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceTapRuleId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkTapResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkTapResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkTapName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> Resync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> ResyncAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkTapRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>, System.Collections.IEnumerable
    {
        protected NetworkTapRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkTapRuleName, Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkTapRuleName, Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkTapRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkTapRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> Get(string networkTapRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> GetAsync(string networkTapRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> GetIfExists(string networkTapRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> GetIfExistsAsync(string networkTapRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkTapRuleData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData>
    {
        public NetworkTapRuleData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? AdministrativeState { get { throw null; } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType? ConfigurationType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration> DynamicMatchConfigurations { get { throw null; } }
        public System.DateTimeOffset? LastSyncedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchConfiguration> MatchConfigurations { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkTapId { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond? PollingIntervalInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        public System.Uri TapRulesUri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkTapRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkTapRuleResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkTapRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> Resync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> ResyncAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult> ValidateConfiguration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult>> ValidateConfigurationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkToNetworkInterconnectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>, System.Collections.IEnumerable
    {
        protected NetworkToNetworkInterconnectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string networkToNetworkInterconnectName, Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string networkToNetworkInterconnectName, Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string networkToNetworkInterconnectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string networkToNetworkInterconnectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> Get(string networkToNetworkInterconnectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>> GetAsync(string networkToNetworkInterconnectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> GetIfExists(string networkToNetworkInterconnectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>> GetIfExistsAsync(string networkToNetworkInterconnectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkToNetworkInterconnectData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData>
    {
        public NetworkToNetworkInterconnectData(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue useOptionB) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? AdministrativeState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        public Azure.Core.ResourceIdentifier EgressAclId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicyInformation ExportRoutePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicyInformation ImportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IngressAclId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType? IsManagementType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration Layer2Configuration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NniType? NniType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NpbStaticRouteConfiguration NpbStaticRouteConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectOptionBLayer3Configuration OptionBLayer3Configuration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue UseOptionB { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkToNetworkInterconnectResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkToNetworkInterconnectResource() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string networkFabricName, string networkToNetworkInterconnectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> UpdateAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> UpdateAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult> UpdateNpbStaticRouteBfdAdministrativeState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>> UpdateNpbStaticRouteBfdAdministrativeStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ManagedNetworkFabric.Mocking
{
    public partial class MockableManagedNetworkFabricArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableManagedNetworkFabricArmClient() { }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceResource GetNetworkDeviceInterfaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource GetNetworkDeviceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource GetNetworkDeviceSkuResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource GetNetworkFabricAccessControlListResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource GetNetworkFabricControllerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkResource GetNetworkFabricExternalNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkResource GetNetworkFabricInternalNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource GetNetworkFabricInternetGatewayResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource GetNetworkFabricInternetGatewayRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource GetNetworkFabricIPCommunityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource GetNetworkFabricIPExtendedCommunityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource GetNetworkFabricIPPrefixResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource GetNetworkFabricL2IsolationDomainResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource GetNetworkFabricL3IsolationDomainResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource GetNetworkFabricNeighborGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource GetNetworkFabricResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource GetNetworkFabricRoutePolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource GetNetworkFabricSkuResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource GetNetworkPacketBrokerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource GetNetworkRackResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource GetNetworkTapResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource GetNetworkTapRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectResource GetNetworkToNetworkInterconnectResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableManagedNetworkFabricResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableManagedNetworkFabricResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> GetNetworkDevice(string networkDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource>> GetNetworkDeviceAsync(string networkDeviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceCollection GetNetworkDevices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> GetNetworkFabric(string networkFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> GetNetworkFabricAccessControlList(string accessControlListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource>> GetNetworkFabricAccessControlListAsync(string accessControlListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListCollection GetNetworkFabricAccessControlLists() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource>> GetNetworkFabricAsync(string networkFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> GetNetworkFabricController(string networkFabricControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource>> GetNetworkFabricControllerAsync(string networkFabricControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerCollection GetNetworkFabricControllers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource> GetNetworkFabricInternetGateway(string internetGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource>> GetNetworkFabricInternetGatewayAsync(string internetGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> GetNetworkFabricInternetGatewayRule(string internetGatewayRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource>> GetNetworkFabricInternetGatewayRuleAsync(string internetGatewayRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleCollection GetNetworkFabricInternetGatewayRules() { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayCollection GetNetworkFabricInternetGateways() { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityCollection GetNetworkFabricIPCommunities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> GetNetworkFabricIPCommunity(string ipCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource>> GetNetworkFabricIPCommunityAsync(string ipCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityCollection GetNetworkFabricIPExtendedCommunities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> GetNetworkFabricIPExtendedCommunity(string ipExtendedCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource>> GetNetworkFabricIPExtendedCommunityAsync(string ipExtendedCommunityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> GetNetworkFabricIPPrefix(string ipPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource>> GetNetworkFabricIPPrefixAsync(string ipPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixCollection GetNetworkFabricIPPrefixes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> GetNetworkFabricL2IsolationDomain(string l2IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource>> GetNetworkFabricL2IsolationDomainAsync(string l2IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainCollection GetNetworkFabricL2IsolationDomains() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> GetNetworkFabricL3IsolationDomain(string l3IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource>> GetNetworkFabricL3IsolationDomainAsync(string l3IsolationDomainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainCollection GetNetworkFabricL3IsolationDomains() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> GetNetworkFabricNeighborGroup(string neighborGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource>> GetNetworkFabricNeighborGroupAsync(string neighborGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupCollection GetNetworkFabricNeighborGroups() { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyCollection GetNetworkFabricRoutePolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> GetNetworkFabricRoutePolicy(string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource>> GetNetworkFabricRoutePolicyAsync(string routePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricCollection GetNetworkFabrics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> GetNetworkPacketBroker(string networkPacketBrokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource>> GetNetworkPacketBrokerAsync(string networkPacketBrokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerCollection GetNetworkPacketBrokers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> GetNetworkRack(string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource>> GetNetworkRackAsync(string networkRackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkRackCollection GetNetworkRacks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> GetNetworkTap(string networkTapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource>> GetNetworkTapAsync(string networkTapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> GetNetworkTapRule(string networkTapRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource>> GetNetworkTapRuleAsync(string networkTapRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleCollection GetNetworkTapRules() { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkTapCollection GetNetworkTaps() { throw null; }
    }
    public partial class MockableManagedNetworkFabricSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableManagedNetworkFabricSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> GetNetworkDevices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceResource> GetNetworkDevicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource> GetNetworkDeviceSku(string networkDeviceSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuResource>> GetNetworkDeviceSkuAsync(string networkDeviceSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuCollection GetNetworkDeviceSkus() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> GetNetworkFabricAccessControlLists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListResource> GetNetworkFabricAccessControlListsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> GetNetworkFabricControllers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerResource> GetNetworkFabricControllersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> GetNetworkFabricInternetGatewayRules(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleResource> GetNetworkFabricInternetGatewayRulesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource> GetNetworkFabricInternetGateways(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayResource> GetNetworkFabricInternetGatewaysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> GetNetworkFabricIPCommunities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityResource> GetNetworkFabricIPCommunitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> GetNetworkFabricIPExtendedCommunities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityResource> GetNetworkFabricIPExtendedCommunitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> GetNetworkFabricIPPrefixes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixResource> GetNetworkFabricIPPrefixesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> GetNetworkFabricL2IsolationDomains(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainResource> GetNetworkFabricL2IsolationDomainsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> GetNetworkFabricL3IsolationDomains(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainResource> GetNetworkFabricL3IsolationDomainsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> GetNetworkFabricNeighborGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupResource> GetNetworkFabricNeighborGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> GetNetworkFabricRoutePolicies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyResource> GetNetworkFabricRoutePoliciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> GetNetworkFabrics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricResource> GetNetworkFabricsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource> GetNetworkFabricSku(string networkFabricSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuResource>> GetNetworkFabricSkuAsync(string networkFabricSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuCollection GetNetworkFabricSkus() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> GetNetworkPacketBrokers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerResource> GetNetworkPacketBrokersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> GetNetworkRacks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkRackResource> GetNetworkRacksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> GetNetworkTapRules(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleResource> GetNetworkTapRulesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> GetNetworkTaps(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetworkFabric.NetworkTapResource> GetNetworkTapsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    public partial class AccessControlListAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListAction>
    {
        public AccessControlListAction() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType? AclActionType { get { throw null; } set { } }
        public string CounterName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessControlListMatchCondition : Azure.ResourceManager.ManagedNetworkFabric.Models.CommonMatchConditions, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchCondition>
    {
        public AccessControlListMatchCondition() { }
        public System.Collections.Generic.IList<string> DscpMarkings { get { throw null; } }
        public System.Collections.Generic.IList<string> EtherTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> Fragments { get { throw null; } }
        public System.Collections.Generic.IList<string> IPLengths { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPortCondition PortCondition { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TtlValues { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessControlListMatchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchConfiguration>
    {
        public AccessControlListMatchConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListAction> Actions { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPAddressType? IPAddressType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchCondition> MatchConditions { get { throw null; } }
        public string MatchConfigurationName { get { throw null; } set { } }
        public long? SequenceNumber { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessControlListPortCondition : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPortCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPortCondition>
    {
        public AccessControlListPortCondition(Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol layer4Protocol) : base (default(Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol)) { }
        public System.Collections.Generic.IList<string> Flags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPortCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPortCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPortCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPortCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPortCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPortCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListPortCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AclActionType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AclActionType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType Count { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType Drop { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType Log { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.AclActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ActionIPCommunityProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityAddOperationProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPCommunityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPCommunityProperties>
    {
        public ActionIPCommunityProperties() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> DeleteIPCommunityIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> SetIPCommunityIds { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPCommunityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPCommunityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPCommunityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPCommunityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPCommunityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPCommunityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPCommunityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ActionIPExtendedCommunityProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityAddOperationProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPExtendedCommunityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPExtendedCommunityProperties>
    {
        public ActionIPExtendedCommunityProperties() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> DeleteIPExtendedCommunityIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> SetIPExtendedCommunityIds { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPExtendedCommunityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPExtendedCommunityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPExtendedCommunityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPExtendedCommunityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPExtendedCommunityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPExtendedCommunityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPExtendedCommunityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AddressFamilyType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AddressFamilyType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType IPv4 { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType left, Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType left, Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdministrativeEnableState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeEnableState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdministrativeEnableState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeEnableState Disable { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeEnableState Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeEnableState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeEnableState left, Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeEnableState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeEnableState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeEnableState left, Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeEnableState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AggregateRoute : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRoute>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRoute>
    {
        public AggregateRoute(string prefix) { }
        public string Prefix { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRoute System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRoute>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRoute>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRoute System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRoute>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRoute>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRoute>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AggregateRouteConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRouteConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRouteConfiguration>
    {
        public AggregateRouteConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRoute> IPv4Routes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRoute> IPv6Routes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRouteConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRouteConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRouteConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRouteConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRouteConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRouteConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRouteConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllowASOverride : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllowASOverride(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride Disable { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride left, Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride left, Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AnnotationResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResourceProperties>
    {
        public AnnotationResourceProperties() { }
        public string Annotation { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmManagedNetworkFabricModelFactory
    {
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration(Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState?), int? intervalInMilliSeconds = default(int?), int? multiplier = default(int?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.BgpConfiguration BgpConfiguration(string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration bfdConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue? defaultRouteOriginate = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue?), int? allowAS = default(int?), Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride? allowASOverride = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride?), long? fabricAsn = default(long?), long? peerAsn = default(long?), System.Collections.Generic.IEnumerable<string> ipv4ListenRangePrefixes = null, System.Collections.Generic.IEnumerable<string> ipv6ListenRangePrefixes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress> ipv4NeighborAddress = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress> ipv6NeighborAddress = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult DeviceUpdateCommonPostActionResult(Azure.ResponseError error = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?), System.Collections.Generic.IEnumerable<string> successfulDevices = null, System.Collections.Generic.IEnumerable<string> failedDevices = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkOptionAProperties ExternalNetworkOptionAProperties(string primaryIPv4Prefix = null, string primaryIPv6Prefix = null, string secondaryIPv4Prefix = null, string secondaryIPv6Prefix = null, int? mtu = default(int?), int? vlanId = default(int?), long? fabricAsn = default(long?), long? peerAsn = default(long?), Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration bfdConfiguration = null, Azure.Core.ResourceIdentifier ingressAclId = null, Azure.Core.ResourceIdentifier egressAclId = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPatchOptionAProperties ExternalNetworkPatchOptionAProperties(string primaryIPv4Prefix = null, string primaryIPv6Prefix = null, string secondaryIPv4Prefix = null, string secondaryIPv6Prefix = null, int? mtu = default(int?), int? vlanId = default(int?), long? fabricAsn = default(long?), long? peerAsn = default(long?), Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration bfdConfiguration = null, Azure.Core.ResourceIdentifier ingressAclId = null, Azure.Core.ResourceIdentifier egressAclId = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkBgpConfiguration InternalNetworkBgpConfiguration(string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration bfdConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue? defaultRouteOriginate = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue?), int? allowAS = default(int?), Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride? allowASOverride = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride?), long? fabricAsn = default(long?), long? peerAsn = default(long?), System.Collections.Generic.IEnumerable<string> ipv4ListenRangePrefixes = null, System.Collections.Generic.IEnumerable<string> ipv6ListenRangePrefixes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress> ipv4NeighborAddress = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress> ipv6NeighborAddress = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress NeighborAddress(string address = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceData NetworkDeviceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, string hostName = null, string serialNumber = null, string version = null, string networkDeviceSku = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole? networkDeviceRole = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole?), Azure.Core.ResourceIdentifier networkRackId = null, System.Net.IPAddress managementIPv4Address = null, string managementIPv6Address = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceInterfaceData NetworkDeviceInterfaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string annotation = null, string physicalIdentifier = null, string connectedTo = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceType? interfaceType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceType?), System.Net.IPAddress ipv4Address = null, string ipv6Address = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkDeviceSkuData NetworkDeviceSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string model = null, string manufacturer = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedVersionProperties> supportedVersions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName> supportedRoleTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceProperties> interfaces = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData NetworkFabricAccessControlListData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string annotation, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType? configurationType, System.Uri aclsUri, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchConfiguration> matchConfigurations, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration> dynamicMatchConfigurations, System.DateTimeOffset? lastSyncedOn, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricAccessControlListData NetworkFabricAccessControlListData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType? configurationType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType?), System.Uri aclsUri = null, Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType? defaultAction = default(Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchConfiguration> matchConfigurations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration> dynamicMatchConfigurations = null, System.DateTimeOffset? lastSyncedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricControllerData NetworkFabricControllerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation> infrastructureExpressRouteConnections = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation> workloadExpressRouteConnections = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerServices infrastructureServices = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerServices workloadServices = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> networkFabricIds = null, bool? isWorkloadManagementNetwork = default(bool?), Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled? isWorkloadManagementNetworkEnabled = default(Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> tenantInternetGatewayIds = null, string ipv4AddressSpace = null, string ipv6AddressSpace = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerSKU? nfcSku = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerSKU?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerServices NetworkFabricControllerServices(System.Collections.Generic.IEnumerable<string> ipv4AddressSpaces = null, System.Collections.Generic.IEnumerable<string> ipv6AddressSpaces = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricData NetworkFabricData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, string networkFabricSku = null, string fabricVersion = null, System.Collections.Generic.IEnumerable<string> routerIds = null, Azure.Core.ResourceIdentifier networkFabricControllerId = null, int? rackCount = default(int?), int serverCountPerRack = 0, string ipv4Prefix = null, string ipv6Prefix = null, long fabricAsn = (long)0, Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerConfiguration terminalServerConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationProperties managementNetworkConfiguration = null, System.Collections.Generic.IEnumerable<string> racks = null, System.Collections.Generic.IEnumerable<string> l2IsolationDomains = null, System.Collections.Generic.IEnumerable<string> l3IsolationDomains = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricErrorResult NetworkFabricErrorResult(Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricExternalNetworkData NetworkFabricExternalNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string annotation = null, Azure.Core.ResourceIdentifier importRoutePolicyId = null, Azure.Core.ResourceIdentifier exportRoutePolicyId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy importRoutePolicy = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy exportRoutePolicy = null, Azure.Core.ResourceIdentifier networkToNetworkInterconnectId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption peeringOption = default(Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption), Azure.ResourceManager.ManagedNetworkFabric.Models.L3OptionBProperties optionBProperties = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkOptionAProperties optionAProperties = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternalNetworkData NetworkFabricInternalNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string annotation = null, int? mtu = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet> connectedIPv4Subnets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet> connectedIPv6Subnets = null, Azure.Core.ResourceIdentifier importRoutePolicyId = null, Azure.Core.ResourceIdentifier exportRoutePolicyId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy importRoutePolicy = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy exportRoutePolicy = null, Azure.Core.ResourceIdentifier ingressAclId = null, Azure.Core.ResourceIdentifier egressAclId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled? isMonitoringEnabled = default(Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled?), Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfigurationExtension? extension = default(Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfigurationExtension?), int vlanId = 0, Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkBgpConfiguration bgpConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkStaticRouteConfiguration staticRouteConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData NetworkFabricInternetGatewayData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string annotation, Azure.Core.ResourceIdentifier internetGatewayRuleId, System.Net.IPAddress ipv4Address, int? port, Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayType typePropertiesType, Azure.Core.ResourceIdentifier networkFabricControllerId, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayData NetworkFabricInternetGatewayData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.Core.ResourceIdentifier internetGatewayRuleId = null, string ipV4Address = null, int? port = default(int?), Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayType typePropertiesType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayType), Azure.Core.ResourceIdentifier networkFabricControllerId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData NetworkFabricInternetGatewayRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRules ruleProperties = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> internetGatewayIds = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPCommunityData NetworkFabricIPCommunityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityRule> ipCommunityRules = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPExtendedCommunityData NetworkFabricIPExtendedCommunityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityRule> ipExtendedCommunityRules = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricIPPrefixData NetworkFabricIPPrefixData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRule> ipPrefixRules = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL2IsolationDomainData NetworkFabricL2IsolationDomainData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.Core.ResourceIdentifier networkFabricId = null, int vlanId = 0, int? mtu = default(int?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricL3IsolationDomainData NetworkFabricL3IsolationDomainData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet? redistributeConnectedSubnets = default(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet?), Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute? redistributeStaticRoutes = default(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute?), Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRouteConfiguration aggregateRouteConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnetRoutePolicy connectedSubnetRoutePolicy = null, Azure.Core.ResourceIdentifier networkFabricId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricNeighborGroupData NetworkFabricNeighborGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborGroupDestination destination = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> networkTapIds = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> networkTapRuleIds = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData NetworkFabricRoutePolicyData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string annotation, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyStatementProperties> statements, Azure.Core.ResourceIdentifier networkFabricId, Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType? addressFamilyType, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricRoutePolicyData NetworkFabricRoutePolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType? defaultAction = default(Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyStatementProperties> statements = null, Azure.Core.ResourceIdentifier networkFabricId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType? addressFamilyType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.AddressFamilyType?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkFabricSkuData NetworkFabricSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricSkuType? typePropertiesType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricSkuType?), int? maxComputeRacks = default(int?), int? maximumServerCount = default(int?), System.Collections.Generic.IEnumerable<string> supportedVersions = null, string details = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkPacketBrokerData NetworkPacketBrokerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier networkFabricId = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> networkDeviceIds = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> sourceInterfaceIds = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> networkTapIds = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> neighborGroupIds = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkRackData NetworkRackData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType? networkRackType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType?), Azure.Core.ResourceIdentifier networkFabricId = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> networkDevices = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkTapData NetworkTapData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.Core.ResourceIdentifier networkPacketBrokerId = null, Azure.Core.ResourceIdentifier sourceTapRuleId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPropertiesDestinationsItem> destinations = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPollingType? pollingType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPollingType?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkTapRuleData NetworkTapRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string annotation = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType? configurationType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType?), System.Uri tapRulesUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchConfiguration> matchConfigurations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration> dynamicMatchConfigurations = null, Azure.Core.ResourceIdentifier networkTapId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond? pollingIntervalInSeconds = default(Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond?), System.DateTimeOffset? lastSyncedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.NetworkToNetworkInterconnectData NetworkToNetworkInterconnectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NniType? nniType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NniType?), Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType? isManagementType = default(Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue useOptionB = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue), Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration layer2Configuration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectOptionBLayer3Configuration optionBLayer3Configuration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NpbStaticRouteConfiguration npbStaticRouteConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicyInformation importRoutePolicy = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicyInformation exportRoutePolicy = null, Azure.Core.ResourceIdentifier egressAclId = null, Azure.Core.ResourceIdentifier ingressAclId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState?), Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectOptionBLayer3Configuration NetworkToNetworkInterconnectOptionBLayer3Configuration(string primaryIPv4Prefix = null, string primaryIPv6Prefix = null, string secondaryIPv4Prefix = null, string secondaryIPv6Prefix = null, long? peerAsn = default(long?), int? vlanId = default(int?), long? fabricAsn = default(long?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPatch NetworkToNetworkInterconnectPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration layer2Configuration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBLayer3Configuration optionBLayer3Configuration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NpbStaticRouteConfiguration npbStaticRouteConfiguration = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicyInformation importRoutePolicy = null, Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicyInformation exportRoutePolicy = null, Azure.Core.ResourceIdentifier egressAclId = null, Azure.Core.ResourceIdentifier ingressAclId = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBLayer3Configuration OptionBLayer3Configuration(string primaryIPv4Prefix = null, string primaryIPv6Prefix = null, string secondaryIPv4Prefix = null, string secondaryIPv6Prefix = null, long? peerAsn = default(long?), int? vlanId = default(int?), long? fabricAsn = default(long?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult StateUpdateCommonPostActionResult(Azure.ResponseError error = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerConfiguration TerminalServerConfiguration(string username = null, string password = null, string serialNumber = null, Azure.Core.ResourceIdentifier networkDeviceId = null, string primaryIPv4Prefix = null, string primaryIPv6Prefix = null, string secondaryIPv4Prefix = null, string secondaryIPv6Prefix = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult ValidateConfigurationResult(Azure.ResponseError error = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? configurationState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState?), System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties VpnConfigurationProperties(Azure.Core.ResourceIdentifier networkToNetworkInterconnectId = null, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? administrativeState = default(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState?), Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption peeringOption = default(Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption), Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties optionBProperties = null, Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationOptionAProperties optionAProperties = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BfdAdministrativeState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BfdAdministrativeState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState Disabled { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState Enabled { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState Mat { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState Rma { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState left, Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState left, Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BfdConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration>
    {
        public BfdConfiguration() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BfdAdministrativeState? AdministrativeState { get { throw null; } }
        public int? IntervalInMilliSeconds { get { throw null; } set { } }
        public int? Multiplier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BgpConfiguration : Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResourceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.BgpConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.BgpConfiguration>
    {
        public BgpConfiguration() { }
        public int? AllowAS { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AllowASOverride? AllowASOverride { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue? DefaultRouteOriginate { get { throw null; } set { } }
        public long? FabricAsn { get { throw null; } }
        public System.Collections.Generic.IList<string> IPv4ListenRangePrefixes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress> IPv4NeighborAddress { get { throw null; } }
        public System.Collections.Generic.IList<string> IPv6ListenRangePrefixes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress> IPv6NeighborAddress { get { throw null; } }
        public long? PeerAsn { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.BgpConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.BgpConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.BgpConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.BgpConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.BgpConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.BgpConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.BgpConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommonDynamicMatchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration>
    {
        public CommonDynamicMatchConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.MatchConfigurationIPGroupProperties> IPGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.PortGroupProperties> PortGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.VlanGroupProperties> VlanGroups { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommonMatchConditions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonMatchConditions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonMatchConditions>
    {
        public CommonMatchConditions() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchCondition IPCondition { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProtocolTypes { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.VlanMatchCondition VlanMatchCondition { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.CommonMatchConditions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonMatchConditions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonMatchConditions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.CommonMatchConditions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonMatchConditions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonMatchConditions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonMatchConditions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunityActionType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunityActionType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType Deny { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType Permit { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectedSubnet : Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResourceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet>
    {
        public ConnectedSubnet(string prefix) { }
        public string Prefix { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedSubnetRoutePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnetRoutePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnetRoutePolicy>
    {
        public ConnectedSubnetRoutePolicy() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.L3ExportRoutePolicy ExportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExportRoutePolicyId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnetRoutePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnetRoutePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnetRoutePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnetRoutePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnetRoutePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnetRoutePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnetRoutePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceUpdateCommonPostActionResult : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricErrorResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult>
    {
        internal DeviceUpdateCommonPostActionResult() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FailedDevices { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SuccessfulDevices { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.DeviceUpdateCommonPostActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportRoutePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy>
    {
        public ExportRoutePolicy() { }
        public Azure.Core.ResourceIdentifier ExportIPv4RoutePolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExportIPv6RoutePolicyId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportRoutePolicyInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicyInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicyInformation>
    {
        public ExportRoutePolicyInformation() { }
        public Azure.Core.ResourceIdentifier ExportIPv4RoutePolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExportIPv6RoutePolicyId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicyInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicyInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicyInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicyInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicyInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicyInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicyInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExpressRouteConnectionInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation>
    {
        public ExpressRouteConnectionInformation(Azure.Core.ResourceIdentifier expressRouteCircuitId) { }
        public string ExpressRouteAuthorizationKey { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExpressRouteCircuitId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExternalNetworkOptionAProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3IPPrefixProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkOptionAProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkOptionAProperties>
    {
        public ExternalNetworkOptionAProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EgressAclId { get { throw null; } set { } }
        public long? FabricAsn { get { throw null; } }
        public Azure.Core.ResourceIdentifier IngressAclId { get { throw null; } set { } }
        public int? Mtu { get { throw null; } set { } }
        public long? PeerAsn { get { throw null; } set { } }
        public int? VlanId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkOptionAProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkOptionAProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkOptionAProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkOptionAProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkOptionAProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkOptionAProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkOptionAProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExternalNetworkPatchOptionAProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3IPPrefixProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPatchOptionAProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPatchOptionAProperties>
    {
        public ExternalNetworkPatchOptionAProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EgressAclId { get { throw null; } set { } }
        public long? FabricAsn { get { throw null; } }
        public Azure.Core.ResourceIdentifier IngressAclId { get { throw null; } set { } }
        public int? Mtu { get { throw null; } set { } }
        public long? PeerAsn { get { throw null; } set { } }
        public int? VlanId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPatchOptionAProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPatchOptionAProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPatchOptionAProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPatchOptionAProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPatchOptionAProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPatchOptionAProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPatchOptionAProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportRoutePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy>
    {
        public ImportRoutePolicy() { }
        public Azure.Core.ResourceIdentifier ImportIPv4RoutePolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ImportIPv6RoutePolicyId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportRoutePolicyInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicyInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicyInformation>
    {
        public ImportRoutePolicyInformation() { }
        public Azure.Core.ResourceIdentifier ImportIPv4RoutePolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ImportIPv6RoutePolicyId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicyInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicyInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicyInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicyInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicyInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicyInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicyInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InternalNetworkBgpConfiguration : Azure.ResourceManager.ManagedNetworkFabric.Models.BgpConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkBgpConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkBgpConfiguration>
    {
        public InternalNetworkBgpConfiguration() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkBgpConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkBgpConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkBgpConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkBgpConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkBgpConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkBgpConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkBgpConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InternalNetworkStaticRouteConfiguration : Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkStaticRouteConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkStaticRouteConfiguration>
    {
        public InternalNetworkStaticRouteConfiguration() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfigurationExtension? Extension { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkStaticRouteConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkStaticRouteConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkStaticRouteConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkStaticRouteConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkStaticRouteConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkStaticRouteConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternalNetworkStaticRouteConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InternetGatewayRuleAction : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InternetGatewayRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction Allow { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction left, Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction left, Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InternetGatewayRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRules>
    {
        public InternetGatewayRules(Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction action, System.Collections.Generic.IEnumerable<string> addressList) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRuleAction Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AddressList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InternetGatewayType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InternetGatewayType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayType Infrastructure { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayType Workload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayType left, Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayType left, Azure.ResourceManager.ManagedNetworkFabric.Models.InternetGatewayType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPCommunityAddOperationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityAddOperationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityAddOperationProperties>
    {
        public IPCommunityAddOperationProperties() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> AddIPCommunityIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityAddOperationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityAddOperationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityAddOperationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityAddOperationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityAddOperationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityAddOperationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityAddOperationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IPCommunityIdList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityIdList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityIdList>
    {
        public IPCommunityIdList() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> IPCommunityIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityIdList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityIdList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityIdList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityIdList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityIdList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityIdList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityIdList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IPCommunityRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityRule>
    {
        public IPCommunityRule(Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType action, long sequenceNumber, System.Collections.Generic.IEnumerable<string> communityMembers) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CommunityMembers { get { throw null; } }
        public long SequenceNumber { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity> WellKnownCommunities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IPExtendedCommunityAddOperationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityAddOperationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityAddOperationProperties>
    {
        public IPExtendedCommunityAddOperationProperties() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> AddIPExtendedCommunityIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityAddOperationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityAddOperationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityAddOperationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityAddOperationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityAddOperationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityAddOperationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityAddOperationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IPExtendedCommunityRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityRule>
    {
        public IPExtendedCommunityRule(Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType action, long sequenceNumber, System.Collections.Generic.IEnumerable<string> routeTargets) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RouteTargets { get { throw null; } }
        public long SequenceNumber { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IPMatchCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchCondition>
    {
        public IPMatchCondition() { }
        public System.Collections.Generic.IList<string> IPGroupNames { get { throw null; } }
        public System.Collections.Generic.IList<string> IPPrefixValues { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchConditionPrefixType? PrefixType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType? SourceDestinationType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPMatchConditionPrefixType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchConditionPrefixType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPMatchConditionPrefixType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchConditionPrefixType LongestPrefix { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchConditionPrefixType Prefix { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchConditionPrefixType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchConditionPrefixType left, Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchConditionPrefixType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchConditionPrefixType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchConditionPrefixType left, Azure.ResourceManager.ManagedNetworkFabric.Models.IPMatchConditionPrefixType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPPrefixRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRule>
    {
        public IPPrefixRule(Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType action, long sequenceNumber, string networkPrefix) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType Action { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRuleCondition? Condition { get { throw null; } set { } }
        public string NetworkPrefix { get { throw null; } set { } }
        public long SequenceNumber { get { throw null; } set { } }
        public string SubnetMaskLength { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPPrefixRuleCondition : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRuleCondition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPPrefixRuleCondition(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRuleCondition EqualTo { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRuleCondition GreaterThanOrEqualTo { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRuleCondition LesserThanOrEqualTo { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRuleCondition Range { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRuleCondition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRuleCondition left, Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRuleCondition right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRuleCondition (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRuleCondition left, Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRuleCondition right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsManagementType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsManagementType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsManagementType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsMonitoringEnabled : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsMonitoringEnabled(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsolationDomainEncapsulationType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainEncapsulationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsolationDomainEncapsulationType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainEncapsulationType Gre { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainEncapsulationType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainEncapsulationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainEncapsulationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainEncapsulationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainEncapsulationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainEncapsulationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainEncapsulationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IsolationDomainProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainProperties>
    {
        public IsolationDomainProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainEncapsulationType? Encapsulation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> NeighborGroupIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsWorkloadManagementNetworkEnabled : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsWorkloadManagementNetworkEnabled(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled left, Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class L3ExportRoutePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.L3ExportRoutePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.L3ExportRoutePolicy>
    {
        public L3ExportRoutePolicy() { }
        public Azure.Core.ResourceIdentifier ExportIPv4RoutePolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExportIPv6RoutePolicyId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.L3ExportRoutePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.L3ExportRoutePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.L3ExportRoutePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.L3ExportRoutePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.L3ExportRoutePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.L3ExportRoutePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.L3ExportRoutePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class L3OptionBProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.L3OptionBProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.L3OptionBProperties>
    {
        public L3OptionBProperties() { }
        public System.Collections.Generic.IList<string> ExportRouteTargets { get { throw null; } }
        public System.Collections.Generic.IList<string> ImportRouteTargets { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RouteTargetInformation RouteTargets { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.L3OptionBProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.L3OptionBProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.L3OptionBProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.L3OptionBProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.L3OptionBProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.L3OptionBProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.L3OptionBProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Layer2Configuration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration>
    {
        public Layer2Configuration() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> Interfaces { get { throw null; } }
        public int? Mtu { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Layer3IPPrefixProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3IPPrefixProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3IPPrefixProperties>
    {
        public Layer3IPPrefixProperties() { }
        public string PrimaryIPv4Prefix { get { throw null; } set { } }
        public string PrimaryIPv6Prefix { get { throw null; } set { } }
        public string SecondaryIPv4Prefix { get { throw null; } set { } }
        public string SecondaryIPv6Prefix { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3IPPrefixProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3IPPrefixProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3IPPrefixProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3IPPrefixProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3IPPrefixProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3IPPrefixProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3IPPrefixProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Layer4Protocol : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Layer4Protocol(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol left, Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol left, Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedResourceGroupConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagedResourceGroupConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagedResourceGroupConfiguration>
    {
        public ManagedResourceGroupConfiguration() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ManagedResourceGroupConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagedResourceGroupConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagedResourceGroupConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ManagedResourceGroupConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagedResourceGroupConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagedResourceGroupConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagedResourceGroupConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagementNetworkConfigurationPatchableProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationPatchableProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationPatchableProperties>
    {
        public ManagementNetworkConfigurationPatchableProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableProperties InfrastructureVpnConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableProperties WorkloadVpnConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationPatchableProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationPatchableProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationPatchableProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationPatchableProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationPatchableProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationPatchableProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationPatchableProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagementNetworkConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationProperties>
    {
        public ManagementNetworkConfigurationProperties(Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties infrastructureVpnConfiguration, Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties workloadVpnConfiguration) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties InfrastructureVpnConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties WorkloadVpnConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MatchConfigurationIPGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.MatchConfigurationIPGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.MatchConfigurationIPGroupProperties>
    {
        public MatchConfigurationIPGroupProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPAddressType? IPAddressType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IPPrefixes { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.MatchConfigurationIPGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.MatchConfigurationIPGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.MatchConfigurationIPGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.MatchConfigurationIPGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.MatchConfigurationIPGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.MatchConfigurationIPGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.MatchConfigurationIPGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeighborAddress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress>
    {
        public NeighborAddress() { }
        public string Address { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborAddress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeighborGroupDestination : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborGroupDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborGroupDestination>
    {
        public NeighborGroupDestination() { }
        public System.Collections.Generic.IList<System.Net.IPAddress> IPv4Addresses { get { throw null; } }
        public System.Collections.Generic.IList<string> IPv6Addresses { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborGroupDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborGroupDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborGroupDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborGroupDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborGroupDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborGroupDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborGroupDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkDeviceAdministrativeState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceAdministrativeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkDeviceAdministrativeState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceAdministrativeState GracefulQuarantine { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceAdministrativeState Quarantine { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceAdministrativeState Resync { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceAdministrativeState Rma { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceAdministrativeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceAdministrativeState left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceAdministrativeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceAdministrativeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceAdministrativeState left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceAdministrativeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkDeviceInterfacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfacePatch>
    {
        public NetworkDeviceInterfacePatch() { }
        public string Annotation { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkDeviceInterfaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceProperties>
    {
        public NetworkDeviceInterfaceProperties() { }
        public string Identifier { get { throw null; } set { } }
        public string InterfaceType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedConnectorProperties> SupportedConnectorTypes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkDeviceInterfaceType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkDeviceInterfaceType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceType Data { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceType Management { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceInterfaceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkDevicePatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDevicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDevicePatch>
    {
        public NetworkDevicePatch() { }
        public string Annotation { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDevicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDevicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDevicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDevicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDevicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDevicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDevicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkDeviceRebootContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootContent>
    {
        public NetworkDeviceRebootContent() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootType? RebootType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkDeviceRebootType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkDeviceRebootType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootType GracefulRebootWithoutZtp { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootType GracefulRebootWithZtp { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootType UngracefulRebootWithoutZtp { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootType UngracefulRebootWithZtp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRebootType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkDeviceRole : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkDeviceRole(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole CE { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole Management { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole Npb { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole ToR { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole TS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkDeviceRoleName : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkDeviceRoleName(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName CE { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName Management { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName Npb { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName ToR { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName TS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceRoleName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkFabricAccessControlListPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAccessControlListPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAccessControlListPatch>
    {
        public NetworkFabricAccessControlListPatch() { }
        public System.Uri AclsUri { get { throw null; } set { } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType? ConfigurationType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration> DynamicMatchConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.AccessControlListMatchConfiguration> MatchConfigurations { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAccessControlListPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAccessControlListPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAccessControlListPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAccessControlListPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAccessControlListPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAccessControlListPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAccessControlListPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkFabricAdministrativeState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkFabricAdministrativeState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState Disabled { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState Enabled { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState Mat { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState Rma { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkFabricBooleanValue : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkFabricBooleanValue(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkFabricConfigurationState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkFabricConfigurationState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState DeferredControl { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState Deprovisioned { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState Deprovisioning { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState ErrorDeprovisioning { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState ErrorProvisioning { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState Failed { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState Provisioned { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState Rejected { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkFabricConfigurationType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkFabricConfigurationType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType File { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType Inline { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkFabricControllerPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPatch>
    {
        public NetworkFabricControllerPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation> InfrastructureExpressRouteConnections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ExpressRouteConnectionInformation> WorkloadExpressRouteConnections { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricControllerServices : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerServices>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerServices>
    {
        internal NetworkFabricControllerServices() { }
        public System.Collections.Generic.IReadOnlyList<string> IPv4AddressSpaces { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPv6AddressSpaces { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerServices System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerServices>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerServices>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerServices System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerServices>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerServices>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerServices>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkFabricControllerSKU : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerSKU>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkFabricControllerSKU(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerSKU Basic { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerSKU HighPerformance { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerSKU Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerSKU other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerSKU left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerSKU right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerSKU (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerSKU left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricControllerSKU right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkFabricErrorResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricErrorResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricErrorResult>
    {
        internal NetworkFabricErrorResult() { }
        public Azure.ResponseError Error { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricErrorResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricErrorResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricErrorResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricErrorResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricErrorResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricErrorResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricErrorResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricExternalNetworkPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricExternalNetworkPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricExternalNetworkPatch>
    {
        public NetworkFabricExternalNetworkPatch() { }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy ExportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExportRoutePolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy ImportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ImportRoutePolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExternalNetworkPatchOptionAProperties OptionAProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.L3OptionBProperties OptionBProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption? PeeringOption { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricExternalNetworkPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricExternalNetworkPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricExternalNetworkPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricExternalNetworkPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricExternalNetworkPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricExternalNetworkPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricExternalNetworkPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricInternalNetworkPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternalNetworkPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternalNetworkPatch>
    {
        public NetworkFabricInternalNetworkPatch() { }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BgpConfiguration BgpConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet> ConnectedIPv4Subnets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnet> ConnectedIPv6Subnets { get { throw null; } }
        public Azure.Core.ResourceIdentifier EgressAclId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicy ExportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExportRoutePolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicy ImportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ImportRoutePolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IngressAclId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IsMonitoringEnabled? IsMonitoringEnabled { get { throw null; } set { } }
        public int? Mtu { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfiguration StaticRouteConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternalNetworkPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternalNetworkPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternalNetworkPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternalNetworkPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternalNetworkPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternalNetworkPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternalNetworkPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricInternetGatewayPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayPatch>
    {
        public NetworkFabricInternetGatewayPatch() { }
        public Azure.Core.ResourceIdentifier InternetGatewayRuleId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricInternetGatewayRulePatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayRulePatch>
    {
        public NetworkFabricInternetGatewayRulePatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayRulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayRulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayRulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayRulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayRulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayRulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricInternetGatewayRulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkFabricIPAddressType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPAddressType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkFabricIPAddressType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPAddressType IPv4 { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPAddressType IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPAddressType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPAddressType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPAddressType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPAddressType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPAddressType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPAddressType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkFabricIPCommunityPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPCommunityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPCommunityPatch>
    {
        public NetworkFabricIPCommunityPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityRule> IPCommunityRules { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPCommunityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPCommunityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPCommunityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPCommunityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPCommunityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPCommunityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPCommunityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricIPExtendedCommunityPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPExtendedCommunityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPExtendedCommunityPatch>
    {
        public NetworkFabricIPExtendedCommunityPatch() { }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.IPExtendedCommunityRule> IPExtendedCommunityRules { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPExtendedCommunityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPExtendedCommunityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPExtendedCommunityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPExtendedCommunityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPExtendedCommunityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPExtendedCommunityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPExtendedCommunityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricIPPrefixPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPPrefixPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPPrefixPatch>
    {
        public NetworkFabricIPPrefixPatch() { }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.IPPrefixRule> IPPrefixRules { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPPrefixPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPPrefixPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPPrefixPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPPrefixPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPPrefixPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPPrefixPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPPrefixPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricL2IsolationDomainPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL2IsolationDomainPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL2IsolationDomainPatch>
    {
        public NetworkFabricL2IsolationDomainPatch() { }
        public string Annotation { get { throw null; } set { } }
        public int? Mtu { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL2IsolationDomainPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL2IsolationDomainPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL2IsolationDomainPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL2IsolationDomainPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL2IsolationDomainPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL2IsolationDomainPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL2IsolationDomainPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricL3IsolationDomainPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL3IsolationDomainPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL3IsolationDomainPatch>
    {
        public NetworkFabricL3IsolationDomainPatch() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AggregateRouteConfiguration AggregateRouteConfiguration { get { throw null; } set { } }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ConnectedSubnetRoutePolicy ConnectedSubnetRoutePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet? RedistributeConnectedSubnets { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute? RedistributeStaticRoutes { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL3IsolationDomainPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL3IsolationDomainPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL3IsolationDomainPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL3IsolationDomainPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL3IsolationDomainPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL3IsolationDomainPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricL3IsolationDomainPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricNeighborGroupPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricNeighborGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricNeighborGroupPatch>
    {
        public NetworkFabricNeighborGroupPatch() { }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NeighborGroupDestination Destination { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricNeighborGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricNeighborGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricNeighborGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricNeighborGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricNeighborGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricNeighborGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricNeighborGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatch>
    {
        public NetworkFabricPatch() { }
        public string Annotation { get { throw null; } set { } }
        public long? FabricAsn { get { throw null; } set { } }
        public string IPv4Prefix { get { throw null; } set { } }
        public string IPv6Prefix { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ManagementNetworkConfigurationPatchableProperties ManagementNetworkConfiguration { get { throw null; } set { } }
        public int? RackCount { get { throw null; } set { } }
        public int? ServerCountPerRack { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatchablePropertiesTerminalServerConfiguration TerminalServerConfiguration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricPatchablePropertiesTerminalServerConfiguration : Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerPatchableProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatchablePropertiesTerminalServerConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatchablePropertiesTerminalServerConfiguration>
    {
        public NetworkFabricPatchablePropertiesTerminalServerConfiguration() { }
        public string PrimaryIPv4Prefix { get { throw null; } set { } }
        public string PrimaryIPv6Prefix { get { throw null; } set { } }
        public string SecondaryIPv4Prefix { get { throw null; } set { } }
        public string SecondaryIPv6Prefix { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatchablePropertiesTerminalServerConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatchablePropertiesTerminalServerConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatchablePropertiesTerminalServerConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatchablePropertiesTerminalServerConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatchablePropertiesTerminalServerConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatchablePropertiesTerminalServerConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPatchablePropertiesTerminalServerConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkFabricPortCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortCondition>
    {
        public NetworkFabricPortCondition(Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol layer4Protocol) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.Layer4Protocol Layer4Protocol { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PortGroupNames { get { throw null; } }
        public System.Collections.Generic.IList<string> Ports { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortType? PortType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkFabricPortType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkFabricPortType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortType DestinationPort { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortType SourcePort { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkFabricProvisioningState : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkFabricProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkFabricRoutePolicyPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricRoutePolicyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricRoutePolicyPatch>
    {
        public NetworkFabricRoutePolicyPatch() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.CommunityActionType? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyStatementProperties> Statements { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricRoutePolicyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricRoutePolicyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricRoutePolicyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricRoutePolicyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricRoutePolicyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricRoutePolicyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricRoutePolicyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkFabricSkuType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricSkuType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkFabricSkuType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricSkuType MultiRack { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricSkuType SingleRack { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricSkuType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricSkuType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricSkuType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricSkuType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricSkuType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricSkuType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkFabricUpdateVersionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricUpdateVersionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricUpdateVersionContent>
    {
        public NetworkFabricUpdateVersionContent() { }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricUpdateVersionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricUpdateVersionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricUpdateVersionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricUpdateVersionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricUpdateVersionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricUpdateVersionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricUpdateVersionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkFabricValidateAction : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricValidateAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkFabricValidateAction(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricValidateAction Cabling { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricValidateAction Configuration { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricValidateAction Connectivity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricValidateAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricValidateAction left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricValidateAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricValidateAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricValidateAction left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricValidateAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkPacketBrokerPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkPacketBrokerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkPacketBrokerPatch>
    {
        public NetworkPacketBrokerPatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkPacketBrokerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkPacketBrokerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkPacketBrokerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkPacketBrokerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkPacketBrokerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkPacketBrokerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkPacketBrokerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkRackPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch>
    {
        public NetworkRackPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkRackType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkRackType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType Aggregate { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType Combined { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType Compute { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkTapDestinationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationProperties>
    {
        public NetworkTapDestinationProperties() { }
        public Azure.Core.ResourceIdentifier DestinationId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DestinationTapRuleId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationType? DestinationType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.IsolationDomainProperties IsolationDomainProperties { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkTapDestinationType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkTapDestinationType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationType Direct { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationType IsolationDomain { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkTapEncapsulationType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapEncapsulationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkTapEncapsulationType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapEncapsulationType GTPv1 { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapEncapsulationType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapEncapsulationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapEncapsulationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapEncapsulationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapEncapsulationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapEncapsulationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapEncapsulationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkTapPatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatch>
    {
        public NetworkTapPatch() { }
        public string Annotation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatchableParametersDestinationsItem> Destinations { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPollingType? PollingType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkTapPatchableParametersDestinationsItem : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatchableParametersDestinationsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatchableParametersDestinationsItem>
    {
        public NetworkTapPatchableParametersDestinationsItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatchableParametersDestinationsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatchableParametersDestinationsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatchableParametersDestinationsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatchableParametersDestinationsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatchableParametersDestinationsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatchableParametersDestinationsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPatchableParametersDestinationsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkTapPollingType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPollingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkTapPollingType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPollingType Pull { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPollingType Push { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPollingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPollingType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPollingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPollingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPollingType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPollingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkTapPropertiesDestinationsItem : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapDestinationProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPropertiesDestinationsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPropertiesDestinationsItem>
    {
        public NetworkTapPropertiesDestinationsItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPropertiesDestinationsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPropertiesDestinationsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPropertiesDestinationsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPropertiesDestinationsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPropertiesDestinationsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPropertiesDestinationsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapPropertiesDestinationsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkTapRuleAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleAction>
    {
        public NetworkTapRuleAction() { }
        public Azure.Core.ResourceIdentifier DestinationId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue? IsTimestampEnabled { get { throw null; } set { } }
        public string MatchConfigurationName { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType? TapRuleActionType { get { throw null; } set { } }
        public string Truncate { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkTapRuleMatchCondition : Azure.ResourceManager.ManagedNetworkFabric.Models.CommonMatchConditions, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchCondition>
    {
        public NetworkTapRuleMatchCondition() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapEncapsulationType? EncapsulationType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricPortCondition PortCondition { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkTapRuleMatchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchConfiguration>
    {
        public NetworkTapRuleMatchConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleAction> Actions { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricIPAddressType? IPAddressType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchCondition> MatchConditions { get { throw null; } }
        public string MatchConfigurationName { get { throw null; } set { } }
        public long? SequenceNumber { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkTapRulePatch : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkRackPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRulePatch>
    {
        public NetworkTapRulePatch() { }
        public string Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationType? ConfigurationType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.CommonDynamicMatchConfiguration> DynamicMatchConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRuleMatchConfiguration> MatchConfigurations { get { throw null; } }
        public System.Uri TapRulesUri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkTapRulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkToNetworkInterconnectOptionBLayer3Configuration : Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBLayer3Configuration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectOptionBLayer3Configuration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectOptionBLayer3Configuration>
    {
        public NetworkToNetworkInterconnectOptionBLayer3Configuration() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectOptionBLayer3Configuration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectOptionBLayer3Configuration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectOptionBLayer3Configuration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectOptionBLayer3Configuration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectOptionBLayer3Configuration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectOptionBLayer3Configuration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectOptionBLayer3Configuration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkToNetworkInterconnectPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPatch>
    {
        public NetworkToNetworkInterconnectPatch() { }
        public Azure.Core.ResourceIdentifier EgressAclId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ExportRoutePolicyInformation ExportRoutePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ImportRoutePolicyInformation ImportRoutePolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IngressAclId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.Layer2Configuration Layer2Configuration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NpbStaticRouteConfiguration NpbStaticRouteConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBLayer3Configuration OptionBLayer3Configuration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkToNetworkInterconnectPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NniType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.NniType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NniType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NniType CE { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.NniType Npb { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.NniType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.NniType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NniType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.NniType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.NniType left, Azure.ResourceManager.ManagedNetworkFabric.Models.NniType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NpbStaticRouteConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NpbStaticRouteConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NpbStaticRouteConfiguration>
    {
        public NpbStaticRouteConfiguration() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteProperties> IPv4Routes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteProperties> IPv6Routes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NpbStaticRouteConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NpbStaticRouteConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NpbStaticRouteConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.NpbStaticRouteConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NpbStaticRouteConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NpbStaticRouteConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.NpbStaticRouteConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OptionAProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAProperties>
    {
        public OptionAProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration { get { throw null; } set { } }
        public int? Mtu { get { throw null; } set { } }
        public long? PeerAsn { get { throw null; } set { } }
        public int? VlanId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OptionBLayer3Configuration : Azure.ResourceManager.ManagedNetworkFabric.Models.Layer3IPPrefixProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBLayer3Configuration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBLayer3Configuration>
    {
        public OptionBLayer3Configuration() { }
        public long? FabricAsn { get { throw null; } }
        public long? PeerAsn { get { throw null; } set { } }
        public int? VlanId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBLayer3Configuration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBLayer3Configuration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBLayer3Configuration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBLayer3Configuration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBLayer3Configuration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBLayer3Configuration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBLayer3Configuration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OptionBProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties>
    {
        public OptionBProperties() { }
        public System.Collections.Generic.IList<string> ExportRouteTargets { get { throw null; } }
        public System.Collections.Generic.IList<string> ImportRouteTargets { get { throw null; } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RouteTargetInformation RouteTargets { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringOption : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringOption(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption OptionA { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption OptionB { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption left, Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption left, Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PollingIntervalInSecond : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond>
    {
        private readonly int _dummyPrimitive;
        public PollingIntervalInSecond(int value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond Ninety { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond OneHundredTwenty { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond Sixty { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond Thirty { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond left, Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond (int value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond left, Azure.ResourceManager.ManagedNetworkFabric.Models.PollingIntervalInSecond right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PortGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.PortGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.PortGroupProperties>
    {
        public PortGroupProperties() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Ports { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.PortGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.PortGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.PortGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.PortGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.PortGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.PortGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.PortGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedistributeConnectedSubnet : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedistributeConnectedSubnet(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet left, Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet left, Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeConnectedSubnet right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RedistributeStaticRoute : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RedistributeStaticRoute(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute False { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute left, Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute left, Azure.ResourceManager.ManagedNetworkFabric.Models.RedistributeStaticRoute right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutePolicyActionType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutePolicyActionType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType Continue { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType Deny { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType Permit { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutePolicyConditionType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutePolicyConditionType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType And { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType Or { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoutePolicyStatementProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.AnnotationResourceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyStatementProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyStatementProperties>
    {
        public RoutePolicyStatementProperties(long sequenceNumber, Azure.ResourceManager.ManagedNetworkFabric.Models.StatementConditionProperties condition, Azure.ResourceManager.ManagedNetworkFabric.Models.StatementActionProperties action) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.StatementActionProperties Action { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.StatementConditionProperties Condition { get { throw null; } set { } }
        public long SequenceNumber { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyStatementProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyStatementProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyStatementProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyStatementProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyStatementProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyStatementProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyStatementProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouteTargetInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.RouteTargetInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.RouteTargetInformation>
    {
        public RouteTargetInformation() { }
        public System.Collections.Generic.IList<string> ExportIPv4RouteTargets { get { throw null; } }
        public System.Collections.Generic.IList<string> ExportIPv6RouteTargets { get { throw null; } }
        public System.Collections.Generic.IList<string> ImportIPv4RouteTargets { get { throw null; } }
        public System.Collections.Generic.IList<string> ImportIPv6RouteTargets { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.RouteTargetInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.RouteTargetInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.RouteTargetInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.RouteTargetInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.RouteTargetInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.RouteTargetInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.RouteTargetInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceDestinationType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceDestinationType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType DestinationIP { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType SourceIP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType left, Azure.ResourceManager.ManagedNetworkFabric.Models.SourceDestinationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StatementActionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StatementActionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StatementActionProperties>
    {
        public StatementActionProperties(Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType actionType) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyActionType ActionType { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPCommunityProperties IPCommunityProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.ActionIPExtendedCommunityProperties IPExtendedCommunityProperties { get { throw null; } set { } }
        public long? LocalPreference { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.StatementActionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StatementActionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StatementActionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.StatementActionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StatementActionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StatementActionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StatementActionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StatementConditionProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.IPCommunityIdList, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StatementConditionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StatementConditionProperties>
    {
        public StatementConditionProperties() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> IPExtendedCommunityIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier IPPrefixId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.RoutePolicyConditionType? RoutePolicyConditionType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.StatementConditionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StatementConditionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StatementConditionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.StatementConditionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StatementConditionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StatementConditionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StatementConditionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StateUpdateCommonPostActionResult : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricErrorResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>
    {
        internal StateUpdateCommonPostActionResult() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StateUpdateCommonPostActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StaticRouteConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfiguration>
    {
        public StaticRouteConfiguration() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.BfdConfiguration BfdConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteProperties> IPv4Routes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteProperties> IPv6Routes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StaticRouteConfigurationExtension : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfigurationExtension>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StaticRouteConfigurationExtension(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfigurationExtension NoExtension { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfigurationExtension Npb { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfigurationExtension other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfigurationExtension left, Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfigurationExtension right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfigurationExtension (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfigurationExtension left, Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteConfigurationExtension right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StaticRouteProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteProperties>
    {
        public StaticRouteProperties(string prefix, System.Collections.Generic.IEnumerable<string> nextHop) { }
        public System.Collections.Generic.IList<string> NextHop { get { throw null; } }
        public string Prefix { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.StaticRouteProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportedConnectorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedConnectorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedConnectorProperties>
    {
        public SupportedConnectorProperties() { }
        public string ConnectorType { get { throw null; } set { } }
        public int? MaxSpeedInMbps { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedConnectorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedConnectorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedConnectorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedConnectorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedConnectorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedConnectorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedConnectorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportedVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedVersionProperties>
    {
        public SupportedVersionProperties() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricBooleanValue? IsDefault { get { throw null; } set { } }
        public string VendorFirmwareVersion { get { throw null; } set { } }
        public string VendorOSVersion { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.SupportedVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TapRuleActionType : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TapRuleActionType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType Count { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType Drop { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType Goto { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType Log { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType Mirror { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType Redirect { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType Replicate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType left, Azure.ResourceManager.ManagedNetworkFabric.Models.TapRuleActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TerminalServerConfiguration : Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerPatchableProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerConfiguration>
    {
        public TerminalServerConfiguration() { }
        public Azure.Core.ResourceIdentifier NetworkDeviceId { get { throw null; } }
        public string PrimaryIPv4Prefix { get { throw null; } set { } }
        public string PrimaryIPv6Prefix { get { throw null; } set { } }
        public string SecondaryIPv4Prefix { get { throw null; } set { } }
        public string SecondaryIPv6Prefix { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TerminalServerPatchableProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerPatchableProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerPatchableProperties>
    {
        public TerminalServerPatchableProperties() { }
        public string Password { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerPatchableProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerPatchableProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerPatchableProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerPatchableProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerPatchableProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerPatchableProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.TerminalServerPatchableProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateAdministrativeStateContent : Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateOnResources, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent>
    {
        public UpdateAdministrativeStateContent() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.AdministrativeEnableState? State { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateAdministrativeStateOnResources : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateOnResources>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateOnResources>
    {
        public UpdateAdministrativeStateOnResources() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateOnResources System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateOnResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateOnResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateOnResources System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateOnResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateOnResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateOnResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateDeviceAdministrativeStateContent : Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateAdministrativeStateOnResources, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateDeviceAdministrativeStateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateDeviceAdministrativeStateContent>
    {
        public UpdateDeviceAdministrativeStateContent() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkDeviceAdministrativeState? State { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateDeviceAdministrativeStateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateDeviceAdministrativeStateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateDeviceAdministrativeStateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateDeviceAdministrativeStateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateDeviceAdministrativeStateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateDeviceAdministrativeStateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.UpdateDeviceAdministrativeStateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateConfigurationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationContent>
    {
        public ValidateConfigurationContent() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricValidateAction? ValidateAction { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidateConfigurationResult : Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricErrorResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult>
    {
        internal ValidateConfigurationResult() { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricConfigurationState? ConfigurationState { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.ValidateConfigurationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VlanGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VlanGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VlanGroupProperties>
    {
        public VlanGroupProperties() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Vlans { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.VlanGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VlanGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VlanGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.VlanGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VlanGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VlanGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VlanGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VlanMatchCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VlanMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VlanMatchCondition>
    {
        public VlanMatchCondition() { }
        public System.Collections.Generic.IList<string> InnerVlans { get { throw null; } }
        public System.Collections.Generic.IList<string> VlanGroupNames { get { throw null; } }
        public System.Collections.Generic.IList<string> Vlans { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.VlanMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VlanMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VlanMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.VlanMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VlanMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VlanMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VlanMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VpnConfigurationOptionAProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationOptionAProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationOptionAProperties>
    {
        public VpnConfigurationOptionAProperties() { }
        public string PrimaryIPv4Prefix { get { throw null; } set { } }
        public string PrimaryIPv6Prefix { get { throw null; } set { } }
        public string SecondaryIPv4Prefix { get { throw null; } set { } }
        public string SecondaryIPv6Prefix { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationOptionAProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationOptionAProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationOptionAProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationOptionAProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationOptionAProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationOptionAProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationOptionAProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VpnConfigurationPatchableOptionAProperties : Azure.ResourceManager.ManagedNetworkFabric.Models.OptionAProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableOptionAProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableOptionAProperties>
    {
        public VpnConfigurationPatchableOptionAProperties() { }
        public string PrimaryIPv4Prefix { get { throw null; } set { } }
        public string PrimaryIPv6Prefix { get { throw null; } set { } }
        public string SecondaryIPv4Prefix { get { throw null; } set { } }
        public string SecondaryIPv6Prefix { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableOptionAProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableOptionAProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableOptionAProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableOptionAProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableOptionAProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableOptionAProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableOptionAProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VpnConfigurationPatchableProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableProperties>
    {
        public VpnConfigurationPatchableProperties() { }
        public Azure.Core.ResourceIdentifier NetworkToNetworkInterconnectId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableOptionAProperties OptionAProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties OptionBProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption? PeeringOption { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationPatchableProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VpnConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties>
    {
        public VpnConfigurationProperties(Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption peeringOption) { }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.NetworkFabricAdministrativeState? AdministrativeState { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkToNetworkInterconnectId { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationOptionAProperties OptionAProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.OptionBProperties OptionBProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetworkFabric.Models.PeeringOption PeeringOption { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ManagedNetworkFabric.Models.VpnConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WellKnownCommunity : System.IEquatable<Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WellKnownCommunity(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity GShut { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity Internet { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity LocalAS { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity NoAdvertise { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity NoExport { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity left, Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity left, Azure.ResourceManager.ManagedNetworkFabric.Models.WellKnownCommunity right) { throw null; }
        public override string ToString() { throw null; }
    }
}
