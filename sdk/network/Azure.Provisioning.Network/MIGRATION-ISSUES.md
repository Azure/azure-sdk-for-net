# Azure.Provisioning.Network TypeSpec Migration Report

This report tracks migration progress. Remaining issues are listed first, reference and reproduction details are secondary, and completed work is recorded last.

# Remaining issues

## Build and API export results

The generated C# code compiles for `netstandard2.0`, `net8.0`, and `net10.0`,
but the normal build still fails on the intentionally unmitigated API
compatibility differences.

API compatibility reports the following diagnostics across the three target
frameworks:

| Diagnostic | Total | Per target framework | Meaning |
|---|---:|---:|---|
| `CP0001` | 42 | 14 | Removed public types |
| `CP0002` | 1,260 | 420 | Removed public members |
| `CP0011` | 72 | 24 | Changed public member types |

The standard package-scoped API export succeeded with its normal
`RunApiCompat=false` setting, producing updated API listings for all three target
frameworks.

## Resource compatibility

Resource identity was compared by the ARM resource type passed to each
`ProvisionableResource` constructor, rather than by C# class name.

- The baseline has 118 public resource classes representing 117 ARM resource
  types.
- The new generation has 133 public resource classes representing 133 ARM
  resource types.
- **No baseline ARM resource type is missing.**
- One baseline resource class is no longer generated because two classes that
  shared the same ARM resource type were consolidated:

| Missing baseline resource class | Current resource class | ARM resource type |
|---|---|---|
| `ManagementGroupNetworkManagerConnection` | `SubscriptionNetworkManagerConnection` | `Microsoft.Network/networkManagerConnections` |

Restoring or otherwise resolving `ManagementGroupNetworkManagerConnection` is
the highest-priority resource compatibility issue. Although its ARM resource
type remains represented, the management-group-scoped public resource class is
missing.

## Missing non-resource models

After separating resources, 13 baseline public non-resource types remain
missing:

- `ConnectionMonitorType`
- `DdosCustomPolicyTriggerSensitivityOverride`
- `DdosSettingsProtectionMode`
- `DdosTrafficType`
- `ExpressRouteLinkData`
- `FlowLogProperties`
- `PeerExpressRouteCircuitConnectionData`
- `PropagatedRouteTable`
- `ProtocolCustomSettings`
- `RoutingConfiguration`
- `RoutingConfigurationNfvSubResource`
- `VpnSiteLinkConnectionData`
- `VpnSiteLinkData`

Five have likely replacements. Four former data models now correspond to newly
generated resources, while one model appears renamed:

| Baseline non-resource model | Likely current replacement | Change |
|---|---|---|
| `ExpressRouteLinkData` | `ExpressRouteLink` | Promoted to resource `Microsoft.Network/ExpressRoutePorts/links` |
| `FlowLogProperties` | `FlowLogPropertiesFormat` | Model rename |
| `PeerExpressRouteCircuitConnectionData` | `PeerExpressRouteCircuitConnection` | Promoted to resource `Microsoft.Network/expressRouteCircuits/peerings/peerConnections` |
| `VpnSiteLinkConnectionData` | `VpnSiteLinkConnection` | Promoted to resource `Microsoft.Network/vpnGateways/vpnConnections/vpnLinkConnections` |
| `VpnSiteLinkData` | `VpnSiteLink` | Promoted to resource `Microsoft.Network/vpnSites/vpnSiteLinks` |

These replacements are not yet confirmed to be API-compatible. The other eight
missing models have no confirmed one-to-one replacement.

## Work intentionally not performed

Per the requested stopping point, the following remain pending:

- Unit and live tests
- Broad `Azure.Provisioning.Network` breaking-change mitigation
- Changelog updates

# Reference details

## Added resources

The new generation adds 16 ARM resource types:

| Public resource class | ARM resource type |
|---|---|
| `VirtualMachineScaleSetNetworkInterface` | `Microsoft.Compute/virtualMachineScaleSets/virtualMachines/networkInterfaces` |
| `VirtualMachineScaleSetNetworkInterfaceIPConfiguration` | `Microsoft.Compute/virtualMachineScaleSets/virtualMachines/networkInterfaces/ipConfigurations` |
| `VirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddress` | `Microsoft.Compute/virtualMachineScaleSets/virtualMachines/networkInterfaces/ipconfigurations/publicipaddresses` |
| `ApplicationGatewayAvailableSslOptionsInfo` | `Microsoft.Network/applicationGatewayAvailableSslOptions` |
| `AzureWebCategory` | `Microsoft.Network/azureWebCategories` |
| `CloudServiceSwap` | `Microsoft.Network/cloudServiceSlots` |
| `PeerExpressRouteCircuitConnection` | `Microsoft.Network/expressRouteCircuits/peerings/peerConnections` |
| `ExpressRouteLink` | `Microsoft.Network/ExpressRoutePorts/links` |
| `ExpressRoutePortsLocation` | `Microsoft.Network/ExpressRoutePortsLocations` |
| `ExpressRouteProviderPort` | `Microsoft.Network/expressRouteProviderPorts` |
| `ApplicationGatewayWafDynamicManifest` | `Microsoft.Network/locations/applicationGatewayWafDynamicManifests` |
| `DefaultSecurityRule` | `Microsoft.Network/networkSecurityGroups/defaultSecurityRules` |
| `NetworkSecurityPerimeterLinkReference` | `Microsoft.Network/networkSecurityPerimeters/linkReferences` |
| `NetworkVirtualApplianceSku` | `Microsoft.Network/networkVirtualApplianceSkus` |
| `VpnSiteLinkConnection` | `Microsoft.Network/vpnGateways/vpnConnections/vpnLinkConnections` |
| `VpnSiteLink` | `Microsoft.Network/vpnSites/vpnSiteLinks` |

## Added non-resource models

The new generation adds 24 public non-resource types:

- `ApplicationGatewayFirewallManifestRuleSet`
- `ApplicationGatewayFirewallRule`
- `ApplicationGatewayFirewallRuleGroup`
- `ApplicationGatewayForContainersReferenceDefinition`
- `ApplicationGatewayRuleSetStatusOption`
- `ApplicationGatewayTierType`
- `ApplicationGatewayWafRuleActionType`
- `ApplicationGatewayWafRuleSensitivityType`
- `ApplicationGatewayWafRuleStateType`
- `ConnectionMonitorCreateOrUpdateContent`
- `EndpointType`
- `ExpressRoutePortsLocationBandwidths`
- `FlowLogFormatParameters`
- `FlowLogPropertiesFormat`
- `InternetIngressPublicIpsProperties`
- `ManagedServiceIdentityUserAssignedIdentities`
- `NetworkManagedServiceIdentity`
- `NetworkSubResource`
- `NetworkVirtualApplianceSkuInstances`
- `PacketCaptureCreateOrUpdateContent`
- `ReferencedPublicIPAddress`
- `ResourceIdentityType`
- `SwapSlotType`
- `NetworkWritableResourceData`

## Scope

This report describes issues observed after fresh TypeSpec generation of
`Azure.Provisioning.Network` and the related regeneration of
`Azure.ResourceManager.Network`. Broad provisioning breaking-change mitigation
remains deferred; only the requested resource-name, resource-version, and
deprecated management API compatibility changes have been applied.

Generation used:

- `@azure-typespec/http-client-csharp-provisioning` version
  `1.0.0-alpha.20260914.6`
- `@typespec/compiler` version `1.15.0`
- `Microsoft.Network` API version `2025-05-01`
- `Microsoft.Compute` API version `2018-10-01`
- Azure REST API specs commit `13c6ef00a1f2f708fc7a90069312f7977a06fe7d`
- Draft spec PR
  [Azure/azure-rest-api-specs#46412](https://github.com/Azure/azure-rest-api-specs/pull/46412)

## Generation diagnostics

Generation completed successfully but emitted these diagnostics:

- The temporary TypeSpec dependency installation reported one high-severity npm
  vulnerability.
- `grep` was unavailable in the Windows generation environment.
- `tsp-client` warned that `emitter-output-dir` was missing even though it was
  present in the local provisioning-emitter options.
- TypeSpec reported compilation diagnostics but did not print their details
  without debug logging.

# Resolved work

## Resource names restored

Three SDK-side `[CodeGenType]` customizations restore the shipped resource names:

| TypeSpec-generated name | Restored SDK name |
|---|---|
| `Probe` | `ProbeResource` |
| `Route` | `RouteResource` |
| `Subnet` | `SubnetResource` |

These customizations eliminate the `AZC0012` analyzer errors.

## Spec changes required for generation

The provisioning-emitter configuration and required C# customizations are
committed in the draft spec PR. Both the provisioning and management SDK
`tsp-location.yaml` files pin the PR head commit, so generation is reproducible.

The following six deprecated Compute-backed Cloud Services operations also had
to be excluded from the C# scope:

- `NetworkInterfaces.getCloudServiceNetworkInterface`
- `NetworkInterfaces.listCloudServiceRoleInstanceNetworkInterfaces`
- `NetworkInterfacesOperationGroup.listCloudServiceNetworkInterfaces`
- `PublicIPAddresses.getCloudServicePublicIPAddress`
- `PublicIPAddresses.listCloudServiceRoleInstancePublicIPAddresses`
- `PublicIPAddressesOperationGroup.listCloudServicePublicIPAddresses`

Without these exclusions, the provisioning emitter crashes because
`microsoft.Compute/cloudServices/roleInstances/networkInterfaces` and
`Microsoft.Network/networkInterfaces` both project to the class name
`NetworkInterface`.

## Generated source churn

The fresh generation produced 828 C# files:

- 575 tracked generated files were modified.
- 14 tracked generated files were deleted.
- 253 generated files are new and untracked.
- The new files include 16 top-level resource files, 232 model files, and 5
  internal generator-support files.

The three checked-in API listings were subsequently exported with API
compatibility checks disabled. Each framework listing changed by 1,380 additions
and 2,885 deletions, for a combined 4,140 additions and 8,655 deletions.

## Historical resource versions restored

The TypeSpec emitter generates only `V2025_05_01` for the following existing
resource classes. SDK-side partial classes restore every previously public
`ResourceVersions` constant. Each partial class is kept in its own file under
`src/Custom`, mirroring the corresponding top-level generated resource file.

The listed count is the number of legacy constants restored for each class.

| Resource class | Historical versions removed |
|---|---:|
| `ApplicationSecurityGroup` | 56 |
| `BackendAddressPool` | 69 |
| `FirewallPolicy` | 40 |
| `FlowLog` | 56 |
| `FrontendIPConfiguration` | 69 |
| `InboundNatRule` | 69 |
| `LoadBalancer` | 69 |
| `LoadBalancingRule` | 69 |
| `NatGateway` | 44 |
| `NetworkInterface` | 69 |
| `NetworkInterfaceIPConfiguration` | 69 |
| `NetworkInterfaceTapConfiguration` | 69 |
| `NetworkPrivateEndpointConnection` | 46 |
| `NetworkSecurityGroup` | 69 |
| `NetworkWatcher` | 69 |
| `OutboundRule` | 69 |
| `PrivateDnsZoneGroup` | 42 |
| `PrivateEndpoint` | 42 |
| `PrivateLinkService` | 46 |
| `ProbeResource` | 69 |
| `PublicIPAddress` | 69 |
| `PublicIPPrefix` | 47 |
| `RouteResource` | 69 |
| `RouteTable` | 69 |
| `SecurityRule` | 69 |
| `ServiceEndpointPolicy` | 53 |
| `ServiceEndpointPolicyDefinition` | 53 |
| `SubnetResource` | 69 |
| `VirtualNetwork` | 69 |
| `VirtualNetworkPeering` | 69 |
| `VirtualNetworkTap` | 46 |

In total, 1,882 legacy constants were restored. The exported API contains all
2,000 version fields from the pre-migration API and 15 additional fields from
the new generation. Restoring these constants removed 5,646 `CP0002` failures
across the three target frameworks.

## Management SDK regeneration

The six Cloud Services exclusions also remove public APIs from
`Azure.ResourceManager.Network`. Regenerating the management SDK initially
reported 17 unique `CP0002` removals:

- 14 deprecated Cloud Services extension and mockable-resource-group methods
- Two legacy `BastionHostResource.Update` overloads accepting
  `NetworkTagsObject`
- The legacy `HubVirtualNetworkConnectionData.EnableOnlyIPv6Peering` property

The removed APIs are restored in per-type customization files and marked with
both `[EditorBrowsable(EditorBrowsableState.Never)]` and `[Obsolete]`. Deprecated
Cloud Services operations use the package's existing unsupported compatibility
shim pattern and throw `NotSupportedException`.

The current service model represents `enableOnlyIPv6Peering` as a Boolean. A
C#-only `@@clientName` customization emits the new property as
`EnableOnlyIPv6PeeringValue`, allowing the old enum-typed property to remain as
an obsolete adapter without changing the wire name.

After these changes, the normal `Azure.ResourceManager.Network` build and
ApiCompat checks succeed for `netstandard2.0`, `net8.0`, and `net10.0`. The
service-scoped API export also succeeds for both Network packages.
