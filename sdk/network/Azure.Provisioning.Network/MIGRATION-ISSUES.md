# Azure.Provisioning.Network TypeSpec Migration Report

## Scope

This report describes issues observed after a fresh TypeSpec generation of
`Azure.Provisioning.Network`. No breaking-change mitigations were applied, and no
source changes were made after generation to mitigate the reported problems.

Generation used:

- `@azure-typespec/http-client-csharp-provisioning` version
  `1.0.0-alpha.20260914.6`
- `@typespec/compiler` version `1.15.0`
- `Microsoft.Network` API version `2025-05-01`
- `Microsoft.Compute` API version `2018-10-01`
- Azure REST API specs commit `4ab86f6985d73c4fa4812a79cbdd334f47ef9837`

## Spec changes required for generation

The upstream spec commit referenced by `tsp-location.yaml` does not contain the
local provisioning-emitter configuration used for this generation. A spec
change must be committed and the SDK's `tsp-location.yaml` updated to that commit
before the generated output is reproducible remotely.

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

## Build and API export results

Three SDK-side `[CodeGenType]` customizations restore the shipped resource names:

| TypeSpec-generated name | Restored SDK name |
|---|---|
| `Probe` | `ProbeResource` |
| `Route` | `RouteResource` |
| `Subnet` | `SubnetResource` |

These customizations eliminate the `AZC0012` analyzer errors. The generated C#
code compiles for `netstandard2.0`, `net8.0`, and `net10.0`, but the normal build
still fails on the intentionally unmitigated API compatibility differences.

API compatibility reports the following diagnostics across the three target
frameworks:

| Diagnostic | Total | Per target framework | Meaning |
|---|---:|---:|---|
| `CP0001` | 42 | 14 | Removed public types |
| `CP0002` | 6,906 | 2,302 | Removed public members |
| `CP0011` | 72 | 24 | Changed public member types |

The standard package-scoped API export succeeded with its normal
`RunApiCompat=false` setting, producing updated API listings for all three target
frameworks.

## Baseline public types no longer generated

A comparison of the previous and freshly exported
`api/Azure.Provisioning.Network.net10.0.cs` listings found these 14 baseline
public types missing:

- `ConnectionMonitorType`
- `DdosCustomPolicyTriggerSensitivityOverride`
- `DdosSettingsProtectionMode`
- `DdosTrafficType`
- `ExpressRouteLinkData`
- `FlowLogProperties`
- `ManagementGroupNetworkManagerConnection`
- `PeerExpressRouteCircuitConnectionData`
- `PropagatedRouteTable`
- `ProtocolCustomSettings`
- `RoutingConfiguration`
- `RoutingConfigurationNfvSubResource`
- `VpnSiteLinkConnectionData`
- `VpnSiteLinkData`

Several are apparent renames:

| Baseline type | Fresh generated type |
|---|---|
| `ExpressRouteLinkData` | `ExpressRouteLink` |
| `FlowLogProperties` | `FlowLogPropertiesFormat` |
| `PeerExpressRouteCircuitConnectionData` | `PeerExpressRouteCircuitConnection` |
| `VpnSiteLinkConnectionData` | `VpnSiteLinkConnection` |
| `VpnSiteLinkData` | `VpnSiteLink` |

The other missing types have no confirmed one-to-one replacement at the
generation stage.

## New public types

A comparison of the previous and freshly exported API listings found these 40
new public types:

- `ApplicationGatewayAvailableSslOptionsInfo`
- `ApplicationGatewayFirewallManifestRuleSet`
- `ApplicationGatewayFirewallRule`
- `ApplicationGatewayFirewallRuleGroup`
- `ApplicationGatewayForContainersReferenceDefinition`
- `ApplicationGatewayRuleSetStatusOption`
- `ApplicationGatewayTierType`
- `ApplicationGatewayWafDynamicManifest`
- `ApplicationGatewayWafRuleActionType`
- `ApplicationGatewayWafRuleSensitivityType`
- `ApplicationGatewayWafRuleStateType`
- `AzureWebCategory`
- `CloudServiceSwap`
- `ConnectionMonitorCreateOrUpdateContent`
- `DefaultSecurityRule`
- `EndpointType`
- `ExpressRouteLink`
- `ExpressRoutePortsLocation`
- `ExpressRoutePortsLocationBandwidths`
- `ExpressRouteProviderPort`
- `FlowLogFormatParameters`
- `FlowLogPropertiesFormat`
- `InternetIngressPublicIpsProperties`
- `ManagedServiceIdentityUserAssignedIdentities`
- `NetworkManagedServiceIdentity`
- `NetworkSecurityPerimeterLinkReference`
- `NetworkSubResource`
- `NetworkVirtualApplianceSku`
- `NetworkVirtualApplianceSkuInstances`
- `PacketCaptureCreateOrUpdateContent`
- `PeerExpressRouteCircuitConnection`
- `ReferencedPublicIPAddress`
- `ResourceIdentityType`
- `SwapSlotType`
- `VirtualMachineScaleSetNetworkInterface`
- `VirtualMachineScaleSetNetworkInterfaceIPConfiguration`
- `VirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddress`
- `VpnSiteLink`
- `VpnSiteLinkConnection`

## Historical resource versions removed

The TypeSpec emitter generates only `V2025_05_01` for the following existing
resource classes. The listed count is the number of previously public
`ResourceVersions` constants removed from each class.

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
| `PublicIPAddress` | 69 |
| `PublicIPPrefix` | 47 |
| `RouteTable` | 69 |
| `SecurityRule` | 69 |
| `ServiceEndpointPolicy` | 53 |
| `ServiceEndpointPolicyDefinition` | 53 |
| `VirtualNetwork` | 69 |
| `VirtualNetworkPeering` | 69 |
| `VirtualNetworkTap` | 46 |

No resource-version compatibility shims were added.

## Generation diagnostics

Generation completed successfully but emitted these diagnostics:

- The temporary TypeSpec dependency installation reported one high-severity npm
  vulnerability.
- `grep` was unavailable in the Windows generation environment.
- `tsp-client` warned that `emitter-output-dir` was missing even though it was
  present in the local provisioning-emitter options.
- TypeSpec reported compilation diagnostics but did not print their details
  without debug logging.

## Work intentionally not performed

Per the requested stopping point, the following remain pending:

- Unit and live tests
- Breaking-change mitigations
- Changelog updates
- Commit and pull request creation
