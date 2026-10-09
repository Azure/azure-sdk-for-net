# ARM provider schema comparison: Azure.ResourceManager.Network

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

140 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 0 matching normalized patterns; 140 legacy-only; 0 resolve-only |
| Raw resource ID patterns | 140 legacy-only raw; 0 resolve-only raw; 0 raw mismatches removed by variable-name normalization |
| Resource type / hierarchy | 0 matching normalized patterns differ |
| Resource model | 0 matching normalized patterns differ |
| CRUD operations | 0 matching normalized patterns differ |
| List/action operations | 0 matching normalized patterns differ |
| Non-resource methods | 0 legacy-only; 741 resolve-only |


### Legacy-only normalized resource ID patterns

- `/providers/Microsoft.Management/managementGroups/{}/providers/Microsoft.Network/networkManagerConnections/{}`
- `/subscriptions/{}/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default`
- `/subscriptions/{}/providers/Microsoft.Network/azureWebCategories/{}`
- `/subscriptions/{}/providers/Microsoft.Network/ExpressRoutePortsLocations/{}`
- `/subscriptions/{}/providers/Microsoft.Network/expressRouteProviderPorts/{}`
- `/subscriptions/{}/providers/Microsoft.Network/locations/{}/applicationGatewayWafDynamicManifests/dafault`
- `/subscriptions/{}/providers/Microsoft.Network/networkManagerConnections/{}`
- `/subscriptions/{}/providers/Microsoft.Network/networkVirtualApplianceSkus/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/microsoft.Compute/cloudServices/{}/providers/Microsoft.Network/cloudServiceSlots/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/microsoft.Compute/cloudServices/{}/roleInstances/{}/networkInterfaces/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/microsoft.Compute/cloudServices/{}/roleInstances/{}/networkInterfaces/{}/ipconfigurations/{}/publicipaddresses/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}/networkInterfaces/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}/networkInterfaces/{}/ipConfigurations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}/networkInterfaces/{}/ipconfigurations/{}/publicipaddresses/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationGateways/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationGateways/{}/privateEndpointConnections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/ApplicationGatewayWebApplicationFirewallPolicies/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationSecurityGroups/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/azureFirewalls/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/bastionHosts/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/connections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/customIpPrefixes/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/ddosCustomPolicies/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/ddosProtectionPlans/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dscpConfigurations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/expressRouteCircuits/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/expressRouteCircuits/{}/authorizations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/expressRouteCircuits/{}/peerings/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/expressRouteCircuits/{}/peerings/{}/connections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/expressRouteCircuits/{}/peerings/{}/peerConnections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/expressRouteCrossConnections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/expressRouteCrossConnections/{}/peerings/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/expressRouteGateways/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/expressRouteGateways/{}/expressRouteConnections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/ExpressRoutePorts/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/expressRoutePorts/{}/authorizations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/ExpressRoutePorts/{}/links/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/firewallPolicies/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/firewallPolicies/{}/firewallPolicyDrafts/default`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/firewallPolicies/{}/ruleCollectionGroups/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/firewallPolicies/{}/ruleCollectionGroups/{}/ruleCollectionGroupDrafts/default`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/firewallPolicies/{}/signatureOverrides/default`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/interconnectGroups/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/interconnectGroups/{}/subgroups/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/IpAllocations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/ipGroups/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/loadBalancers/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/loadBalancers/{}/backendAddressPools/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/loadBalancers/{}/frontendIPConfigurations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/loadBalancers/{}/inboundNatRules/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/loadBalancers/{}/loadBalancingRules/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/loadBalancers/{}/outboundRules/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/loadBalancers/{}/probes/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/localNetworkGateways/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/natGateways/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkInterfaces/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkInterfaces/{}/ipConfigurations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkInterfaces/{}/tapConfigurations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/commits/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/connectivityConfigurations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/ipamPools/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/ipamPools/{}/staticCidrs/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/networkGroups/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/networkGroups/{}/staticMembers/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/routingConfigurations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/routingConfigurations/{}/ruleCollections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/routingConfigurations/{}/ruleCollections/{}/rules/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/scopeConnections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/securityAdminConfigurations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/securityAdminConfigurations/{}/ruleCollections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/securityAdminConfigurations/{}/ruleCollections/{}/rules/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/securityUserConfigurations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/securityUserConfigurations/{}/ruleCollections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/securityUserConfigurations/{}/ruleCollections/{}/rules/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/verifierWorkspaces/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/verifierWorkspaces/{}/reachabilityAnalysisIntents/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/verifierWorkspaces/{}/reachabilityAnalysisRuns/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkProfiles/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkSecurityGroups/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkSecurityGroups/{}/defaultSecurityRules/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkSecurityGroups/{}/securityRules/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkSecurityPerimeters/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkSecurityPerimeters/{}/linkReferences/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkSecurityPerimeters/{}/links/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkSecurityPerimeters/{}/loggingConfigurations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkSecurityPerimeters/{}/profiles/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkSecurityPerimeters/{}/profiles/{}/accessRules/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkSecurityPerimeters/{}/resourceAssociations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkVirtualAppliances/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkVirtualAppliances/{}/inboundSecurityRules/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkVirtualAppliances/{}/networkVirtualApplianceConnections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkVirtualAppliances/{}/virtualApplianceSites/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkWatchers/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkWatchers/{}/connectionMonitors/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkWatchers/{}/flowLogs/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkWatchers/{}/packetCaptures/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/p2svpnGateways/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateEndpoints/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateEndpoints/{}/privateDnsZoneGroups/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateLinkServices/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/privateLinkServices/{}/privateEndpointConnections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/publicIPAddresses/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/publicIPPrefixes/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/routeFilters/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/routeFilters/{}/routeFilterRules/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/routeTables/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/routeTables/{}/routes/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/securityPartnerProviders/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/serviceEndpointPolicies/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/serviceEndpointPolicies/{}/serviceEndpointPolicyDefinitions/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/serviceGateways/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/bgpConnections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/connectionPolicies/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/hubRouteTables/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/hubVirtualNetworkConnections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/ipConfigurations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/routeMaps/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/routeTables/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/routingIntent/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualNetworkAppliances/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualNetworkGateways/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualNetworkGateways/{}/natRules/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualNetworks/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualNetworks/{}/subnets/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualNetworks/{}/virtualNetworkPeerings/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualNetworkTaps/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualRouters/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualRouters/{}/peerings/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualWans/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/vpnGateways/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/vpnGateways/{}/natRules/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/vpnGateways/{}/vpnConnections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/vpnGateways/{}/vpnConnections/{}/vpnLinkConnections/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/vpnGateways/{}/vpnConnections/{}/vpnLinkConnections/{}/sharedKeys/default`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/vpnServerConfigurations/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/vpnServerConfigurations/{}/configurationPolicyGroups/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/vpnSites/{}`
- `/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/vpnSites/{}/vpnSiteLinks/{}`


### resolveArmResources-only normalized resource ID patterns

None.


### Resource type / hierarchy differences

None.


### Resource model differences

None.


### CRUD operation differences

None.


### List/action operation differences

None.


### Legacy-only non-resource methods

None.


### resolveArmResources-only non-resource methods

- `Microsoft.Compute.NetworkInterfaceIPConfigurations.getVirtualMachineScaleSetIpConfiguration (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}/networkInterfaces/{}/ipConfigurations/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Compute.NetworkInterfaceIPConfigurations.listVirtualMachineScaleSetIpConfigurations (/subscriptions/{}/resourceGroups/{}/providers/microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}/networkInterfaces/{}/ipConfigurations) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Compute.NetworkInterfaces.getVirtualMachineScaleSetNetworkInterface (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}/networkInterfaces/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Compute.NetworkInterfaces.listVirtualMachineScaleSetVMNetworkInterfaces (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}/networkInterfaces) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Compute.PublicIPAddresses.getVirtualMachineScaleSetPublicIPAddress (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}/networkInterfaces/{}/ipconfigurations/{}/publicipaddresses/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Compute.PublicIPAddresses.listVirtualMachineScaleSetVMPublicIPAddresses (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Compute/virtualMachineScaleSets/{}/virtualMachines/{}/networkInterfaces/{}/ipconfigurations/{}/publicipaddresses) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.AdminRuleCollections.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/securityAdminConfigurations/{}/ruleCollections/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.AdminRuleCollections.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/securityAdminConfigurations/{}/ruleCollections/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.AdminRuleCollections.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/securityAdminConfigurations/{}/ruleCollections/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.AdminRuleCollections.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/securityAdminConfigurations/{}/ruleCollections) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationGatewayAvailableSslOptionsOperationGroup.getSslPredefinedPolicy (/subscriptions/{}/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default/predefinedPolicies/{}) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.ApplicationGatewayAvailableSslOptionsOperationGroup.listAvailableSslOptions (/subscriptions/{}/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.ApplicationGatewayAvailableSslOptionsOperationGroup.listAvailableSslPredefinedPolicies (/subscriptions/{}/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default/predefinedPolicies) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.ApplicationGatewayPrivateEndpointConnections.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationGateways/{}/privateEndpointConnections/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationGatewayPrivateEndpointConnections.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationGateways/{}/privateEndpointConnections/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationGatewayPrivateEndpointConnections.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationGateways/{}/privateEndpointConnections) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationGatewayPrivateEndpointConnections.update (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationGateways/{}/privateEndpointConnections/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationGateways.applicationGatewayPrivateLinkResourcesList (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationGateways/{}/privateLinkResources) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationGateways.backendHealth (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationGateways/{}/backendhealth) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationGateways.backendHealthOnDemand (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationGateways/{}/getBackendHealthOnDemand) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationGateways.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationGateways/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationGateways.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationGateways/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationGateways.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationGateways/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationGateways.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationGateways) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationGateways.listAll (/subscriptions/{}/providers/Microsoft.Network/applicationGateways) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.ApplicationGateways.start (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationGateways/{}/start) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationGateways.stop (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationGateways/{}/stop) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationGateways.updateTags (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationGateways/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationGatewayWafDynamicManifestResults.applicationGatewayWafDynamicManifestsGet (/subscriptions/{}/providers/Microsoft.Network/locations/{}/applicationGatewayWafDynamicManifests) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.ApplicationGatewayWafDynamicManifestResults.get (/subscriptions/{}/providers/Microsoft.Network/locations/{}/applicationGatewayWafDynamicManifests/dafault) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.ApplicationSecurityGroups.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationSecurityGroups/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationSecurityGroups.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationSecurityGroups/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationSecurityGroups.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationSecurityGroups/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationSecurityGroups.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationSecurityGroups) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ApplicationSecurityGroups.listAll (/subscriptions/{}/providers/Microsoft.Network/applicationSecurityGroups) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.ApplicationSecurityGroups.updateTags (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/applicationSecurityGroups/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.AzureFirewalls.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/azureFirewalls/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.AzureFirewalls.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/azureFirewalls/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.AzureFirewalls.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/azureFirewalls/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.AzureFirewalls.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/azureFirewalls) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.AzureFirewalls.listAll (/subscriptions/{}/providers/Microsoft.Network/azureFirewalls) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.AzureFirewalls.listLearnedPrefixes (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/azureFirewalls/{}/learnedIPPrefixes) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.AzureFirewalls.packetCapture (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/azureFirewalls/{}/packetCapture) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.AzureFirewalls.packetCaptureOperation (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/azureFirewalls/{}/packetCaptureOperation) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.AzureFirewalls.updateTags (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/azureFirewalls/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.AzureWebCategories.get (/subscriptions/{}/providers/Microsoft.Network/azureWebCategories/{}) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.AzureWebCategories.listBySubscription (/subscriptions/{}/providers/Microsoft.Network/azureWebCategories) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.BackendAddressPools.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/loadBalancers/{}/backendAddressPools/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BackendAddressPools.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/loadBalancers/{}/backendAddressPools/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BackendAddressPools.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/loadBalancers/{}/backendAddressPools/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BackendAddressPools.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/loadBalancers/{}/backendAddressPools) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BackendAddressPools.listInboundNatRulePortMappings (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/loadBalancers/{}/backendAddressPools/{}/queryInboundNatRulePortMapping) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BaseAdminRules.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/securityAdminConfigurations/{}/ruleCollections/{}/rules/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BaseAdminRules.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/securityAdminConfigurations/{}/ruleCollections/{}/rules/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BaseAdminRules.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/securityAdminConfigurations/{}/ruleCollections/{}/rules/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BaseAdminRules.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/securityAdminConfigurations/{}/ruleCollections/{}/rules) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BastionHosts.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/bastionHosts/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BastionHosts.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/bastionHosts/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BastionHosts.deleteBastionShareableLink (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/bastionHosts/{}/deleteShareableLinks) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BastionHosts.deleteBastionShareableLinkByToken (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/bastionHosts/{}/deleteShareableLinksByToken) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BastionHosts.disconnectActiveSessions (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/bastionHosts/{}/disconnectActiveSessions) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BastionHosts.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/bastionHosts/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BastionHosts.getActiveSessions (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/bastionHosts/{}/getActiveSessions) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BastionHosts.getBastionShareableLink (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/bastionHosts/{}/getShareableLinks) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BastionHosts.list (/subscriptions/{}/providers/Microsoft.Network/bastionHosts) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.BastionHosts.listByResourceGroup (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/bastionHosts) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BastionHosts.putBastionShareableLink (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/bastionHosts/{}/createShareableLinks) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BastionHosts.updateTags (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/bastionHosts/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BgpConnections.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/bgpConnections/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BgpConnections.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/bgpConnections/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BgpConnections.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/bgpConnections/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BgpConnections.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/bgpConnections) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BgpConnections.listAdvertisedRoutes (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/bgpConnections/{}/advertisedRoutes) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.BgpConnections.listLearnedRoutes (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/bgpConnections/{}/learnedRoutes) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Commits.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/commits/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Commits.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/commits/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Commits.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/commits/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.Commits.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/commits) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectionMonitorResults.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkWatchers/{}/connectionMonitors/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectionMonitorResults.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkWatchers/{}/connectionMonitors/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectionMonitorResults.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkWatchers/{}/connectionMonitors/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectionMonitorResults.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkWatchers/{}/connectionMonitors) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectionMonitorResults.stop (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkWatchers/{}/connectionMonitors/{}/stop) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectionMonitorResults.updateTags (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkWatchers/{}/connectionMonitors/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectionPolicies.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/connectionPolicies/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectionPolicies.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/connectionPolicies/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectionPolicies.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/connectionPolicies/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectionPolicies.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/virtualHubs/{}/connectionPolicies) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectionSharedKeyResults.getAllSharedKeys (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/vpnGateways/{}/vpnConnections/{}/vpnLinkConnections/{}/sharedKeys) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectionSharedKeyResults.getDefaultSharedKey (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/vpnGateways/{}/vpnConnections/{}/vpnLinkConnections/{}/sharedKeys/default) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectionSharedKeyResults.listDefaultSharedKey (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/vpnGateways/{}/vpnConnections/{}/vpnLinkConnections/{}/sharedKeys/default/listSharedKey) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectionSharedKeyResults.setOrInitDefaultSharedKey (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/vpnGateways/{}/vpnConnections/{}/vpnLinkConnections/{}/sharedKeys/default) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectivityConfigurations.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/connectivityConfigurations/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectivityConfigurations.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/connectivityConfigurations/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectivityConfigurations.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/connectivityConfigurations/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.ConnectivityConfigurations.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkManagers/{}/connectivityConfigurations) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.CustomIpPrefixes.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/customIpPrefixes/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.CustomIpPrefixes.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/customIpPrefixes/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.CustomIpPrefixes.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/customIpPrefixes/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.CustomIpPrefixes.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/customIpPrefixes) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.CustomIpPrefixes.listAll (/subscriptions/{}/providers/Microsoft.Network/customIpPrefixes) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.CustomIpPrefixes.updateTags (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/customIpPrefixes/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.DdosCustomPolicies.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/ddosCustomPolicies/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.DdosCustomPolicies.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/ddosCustomPolicies/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.DdosCustomPolicies.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/ddosCustomPolicies/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.DdosCustomPolicies.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/ddosCustomPolicies) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.DdosCustomPolicies.listAll (/subscriptions/{}/providers/Microsoft.Network/ddosCustomPolicies) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.DdosCustomPolicies.updateTags (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/ddosCustomPolicies/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.DdosProtectionPlans.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/ddosProtectionPlans/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.DdosProtectionPlans.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/ddosProtectionPlans/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.DdosProtectionPlans.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/ddosProtectionPlans/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.DdosProtectionPlans.list (/subscriptions/{}/providers/Microsoft.Network/ddosProtectionPlans) Subscription [/subscriptions/{}: Microsoft.Resources/subscriptions]`
- `Microsoft.Network.DdosProtectionPlans.listByResourceGroup (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/ddosProtectionPlans) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.DdosProtectionPlans.updateTags (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/ddosProtectionPlans/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.DefaultSecurityRules.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkSecurityGroups/{}/defaultSecurityRules/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.DefaultSecurityRules.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/networkSecurityGroups/{}/defaultSecurityRules) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.DscpConfigurations.createOrUpdate (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dscpConfigurations/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.DscpConfigurations.delete (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dscpConfigurations/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.DscpConfigurations.get (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dscpConfigurations/{}) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- `Microsoft.Network.DscpConfigurations.list (/subscriptions/{}/resourceGroups/{}/providers/Microsoft.Network/dscpConfigurations) ResourceGroup [/subscriptions/{}/resourceGroups/{}: Microsoft.Resources/resourceGroups]`
- ... 621 more
