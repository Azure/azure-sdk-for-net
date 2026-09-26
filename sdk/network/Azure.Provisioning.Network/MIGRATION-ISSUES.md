# Azure.Provisioning.Network TypeSpec Migration Status

This report describes the current state of the
`Azure.Provisioning.Network` migration to the TypeSpec provisioning emitter.
It reflects the generated code and API surface in SDK PR
[Azure/azure-sdk-for-net#63070](https://github.com/Azure/azure-sdk-for-net/pull/63070).

## Current generation inputs

- Spec PR:
  [Azure/azure-rest-api-specs#46412](https://github.com/Azure/azure-rest-api-specs/pull/46412)
- Spec commit: `e9e18475a15e4ecb49d58f6d5d385be0d47afb90`
- Provisioning emitter:
  `@azure-typespec/http-client-csharp-provisioning`
  `1.0.0-alpha.20260916.3`
- TypeSpec compiler: `1.15.0`
- `Microsoft.Network` API version: `2025-05-01`
- `Microsoft.Compute` API version: `2018-10-01`

The spec PR has been updated with the latest `main`. Its `client.tsp` removes
the C# `@@clientName` decorators that renamed `RoutingConfiguration` and
`PropagatedRouteTable` to their `Nfv` variants. Its `tspconfig.yaml` adds the
provisioning emitter configuration, pins provisioning Network to `2025-05-01`,
and pins both emitters' Compute input to `2018-10-01`. Management Network is
not pinned and resolves to `2026-01-01`.

Both `Azure.Provisioning.Network` and `Azure.ResourceManager.Network` pin the
same spec commit, and both libraries were regenerated from that commit.

## Validation status

Provisioning regeneration from the current pinned commit succeeded on
2026-09-26 in **6m44.51s**, using the package's `GenerateCode` target without
a local spec override. The management naming cleanup is included in this
commit.

**Provisioning API export and compilation now fail before ApiCompat runs.**
Existing custom forwarding aliases still refer to the former generated names.
The shared C# naming corrections changed those names, while the custom aliases
occupy the corrected names and prevent their corresponding public properties
from being generated. For example, custom `PacketCapture.IsContinuousCapture`
still forwards to the now-absent `ContinuousCapture`.

There are **53 compiler diagnostics per framework** (159 across all three),
in 24 existing custom partial classes:

| Diagnostic | Per framework | Across three frameworks | Meaning |
|---|---:|---:|---|
| `CS0103` | 32 | 96 | A forwarding target no longer exists |
| `CS0118` | 9 | 27 | A former property name resolves to a type used as a variable |
| `CS0119` | 12 | 36 | A former property name resolves to a type used as a value |
| **Total** | **53** | **159** | |

Affected custom classes (diagnostics per framework):

| Class | Diagnostics |
|---|---:|
| `CustomIPPrefix` | 2 |
| `ExpressRouteCircuitPeering` | 1 |
| `ExpressRouteConnection` | 2 |
| `ExpressRouteCrossConnection` | 2 |
| `ExpressRouteGateway` | 2 |
| `ApplicationGatewayBackendSettings` | 4 |
| `ApplicationGatewayPrivateLinkIPConfiguration` | 2 |
| `ApplicationGatewayProbe` | 6 |
| `ApplicationGatewayRequestRoutingRule` | 2 |
| `ConnectionMonitorEndpointFilter` | 2 |
| `ConnectionMonitorEndpointFilterItem` | 2 |
| `ConnectionMonitorOutput` | 2 |
| `ContainerNetworkInterfaceIPConfiguration` | 1 |
| `GatewayLoadBalancerTunnelInterface` | 2 |
| `LoadBalancerBackendAddress` | 2 |
| `NvaInterfaceConfigurationsProperties` | 2 |
| `PrivateEndpointIPConfiguration` | 1 |
| `RoutingRuleRouteDestination` | 2 |
| `VirtualApplianceIPConfiguration` | 2 |
| `VirtualNetworkEncryption` | 2 |
| `PacketCapture` | 2 |
| `SubnetResource` | 4 |
| `VirtualNetwork` | 2 |
| `VirtualNetworkPeering` | 2 |

No provisioning customizations were changed in this regeneration step. These
aliases need reconciliation with the corrected generated names before API
export and compatibility comparison can complete. The three API listing files
are unchanged from before regeneration and are **not** a current export.

The number of resolved or newly introduced provisioning ApiCompat issues is
**not yet measurable**: compiler diagnostics are not ApiCompat diagnostics.
Do not subtract the 53 compiler errors from the 204 baseline compatibility
diagnostics.

Management API export and an explicitly ApiCompat-enabled build passed for
all three frameworks with zero warnings/errors; all 27 focused management
compatibility tests passed. Management-only changes were committed and pushed
as `4de362e98b3b533ce3282c40cee6ab167cbaa26e`. Provisioning changes remain
uncommitted.

### Measured pre-regeneration baseline

Immediately before this regeneration, the provisioning source compiled for
`netstandard2.0`, `net8.0`, and `net10.0`. An ApiCompat-enabled build confirmed
the following unique differences against the released package, using spec
commit `a3a076f131f1a11a5748c6eb21bc0b09092c9e6a`:

| Diagnostic | Per framework | Across three frameworks | Meaning |
|---|---:|---:|---|
| `CP0001` | 0 | 0 | Removed public types |
| `CP0002` | 180 | 540 | Removed or incompatible public member signatures |
| `CP0011` | 24 | 72 | Changed enum numeric values |
| **Total** | **204** | **612** | |

These diagnostics describe the pre-regeneration compatibility backlog, not
the current generated source. They are not C# compilation or generation
failures.

The previously recorded non-live test project restores successfully, but tests
do not yet execute.
After bypassing the separately measured ApiCompat gate with
`RunApiCompat=false`, test compilation reports four migration issues across its
target frameworks:

- A `WritableSubResource` value cannot be assigned to
  `BicepValue<NetworkSubResource>`.
- `SubnetResource.PrivateEndpointNetworkPolicy` is absent.
- `SubnetResource.PrivateLinkServiceNetworkPolicy` is absent.
- `NetworkSecurityGroup.Id` is now read-only.

Those test compilation results were not remeasured after this regeneration:
the source project itself currently fails compilation.

## Pre-regeneration provisioning compatibility inventory

The counts and API shapes below describe the last successfully compiled
baseline. They must be remeasured after reconciling the custom forwarding
aliases with the current generation.

### Removed public types

The current API has 629 public types, compared with 589 in the pre-migration
API. It adds 40 public types and removes none.

### Removed and changed members

ApiCompat reports an old getter or setter as missing when a property's type
changes because the accessor return or parameter type is part of its member
signature. Therefore, `CP0002` does not necessarily mean that the property
itself disappeared.

Comparing the released and generated APIs by declaring type and property name
places the remaining 180 `CP0002` diagnostics per framework into these
mutually exclusive semantic categories:

| Semantic change | Diagnostics | Logical API surface | Meaning |
|---|---:|---:|---|
| Property type changed | 47 | 44 properties | The property remains under the same name, but its generated type differs from the released type. |
| Property missing | 61 | 57 properties | No property with the released name exists. These are renamed-and-type-changed properties, flattened wrappers, or properties that are actually absent. |
| Property became read-only | 48 | 48 properties | The property and getter remain with the released type, but the setter is absent. |
| Enum member missing | 24 | 24 fields | Values are missing from nine retained enums, including TLS cipher/protocol values and compatibility values for DDoS, VPN, IPsec, WAF, and load-balancer models. |
| **Total** | **180** | **173 members** | |

The 57 remaining missing property names break down further as follows:

| Missing-name family | Diagnostics | Properties | Details |
|---|---:|---:|---|
| Renamed and type changed | 50 | 49 | Includes 47 `ResourceType` properties that now appear as `Type`/`string`, plus `ConnectionMonitorEndpoint.EndpointType` and `CustomIPPrefix.ChildCustomIPPrefixList`. |
| Flattened wrapper missing | 3 | 2 | `LoadBalancerInboundNatPool.Properties` and `LoadBalancingRule.Properties` require separate wrapper compatibility work. |
| Actually absent | 8 | 6 | Four `SystemData` getters and two `AdditionalProperties` bags have no generated equivalent. |
| **Total** | **61** | **57** | |

The 44 remaining property type changes break down further as follows:

| Type-change family | Diagnostics | Properties | Details |
|---|---:|---:|---|
| Resource-reference shape changed | 15 | 15 | Released `WritableSubResource` or `SubResource` collections became `NetworkSubResource` or newer service-specific model collections. |
| Strong scalar or collection element type became `string` | 29 | 26 | Includes `ResourceIdentifier`, `ResourceType`, `BinaryData`, `Guid`, `AzureLocation`, `IPAddress`, and `Uri` values or collections. |
| Other value/model type changes | 3 | 3 | `BicepList<string>` became `BicepList<int>`, `BicepValue<string>` became `BicepValue<double>`, and `ManagedServiceIdentity` became `InternalNetworkManagedServiceIdentity`. |
| **Total** | **47** | **44** | |

Regeneration against the current local TypeSpec project also surfaced three
additional missing getter-only properties that were not present in the prior
diagnostic inventory: `ConnectionMonitor.SystemData`,
`PacketCapture.SystemData`, and `RouteMap.SystemData`. They are classified as
missing properties and remain unmitigated.

The 24 `CP0011` diagnostics are a separate enum-ordering problem. Existing
members changed numeric values in six enums:

- `ApplicationGatewayCustomErrorStatusCode` (9 members)
- `FirewallPolicyIntrusionDetectionProfileType` (4 members)
- `LoadBalancerBackendAddressAdminState` (3 members)
- `ManagedRuleSensitivityType` (3 members)
- `VpnAuthenticationType` (3 members)
- `IPsecIntegrity` (2 members)

These categories count ApiCompat diagnostics separately from logical members.
A released read/write property contributes two `CP0002` diagnostics when both
accessors are absent or incompatible.

## Resolved migration work

### ETag semantic types

The 139 ETag property type changes are resolved through 135 C#-scoped
`@@alternateType(..., Azure.Core.eTag, "csharp")` customizations in
`client.tsp`. Some TypeSpec properties project onto more than one provisioning
type, so 135 customizations restore 139 released properties. For example,
`ApplicationGateway.ETag` is generated again as:

```csharp
public BicepValue<ETag> ETag { get; }
```

No ETag-related ApiCompat diagnostics remain.

### Same-type property renames

This subsection records the pre-regeneration alias mapping. Some generated
names below have now been corrected by the shared C# naming cleanup; the
existing aliases are the source of the current compilation blockers above.

Forty-one released properties were renamed by the TypeSpec-based generation
while retaining the same public type and Bicep path. Hidden obsolete custom
properties now forward directly to their generated counterparts:

| Type | Released property | Generated property |
|---|---|---|
| `ApplicationGateway` | `AvailabilityZones` | `Zones` |
| `ApplicationGatewayBackendSettings` | `IsL4ClientIPPreservationEnabled` | `EnableL4ClientIPPreservation` |
| `ApplicationGatewayBackendSettings` | `TimeoutInSeconds` | `Timeout` |
| `ApplicationGatewayPrivateEndpointConnection` | `ConnectionState` | `PrivateLinkServiceConnectionState` |
| `ApplicationGatewayPrivateLinkIPConfiguration` | `IsPrimary` | `Primary` |
| `ApplicationGatewayProbe` | `IntervalInSeconds` | `Interval` |
| `ApplicationGatewayProbe` | `IsProbeProxyProtocolHeaderEnabled` | `EnableProbeProxyProtocolHeader` |
| `ApplicationGatewayProbe` | `TimeoutInSeconds` | `Timeout` |
| `ApplicationGatewayRequestRoutingRule` | `EntraJwtValidationConfigId` | `EntraJWTValidationConfig` |
| `ConnectionMonitor` | `StartOn` | `StartsOn` |
| `ConnectionMonitorEndpointFilter` | `FilterType` | `Type` |
| `ConnectionMonitorEndpointFilterItem` | `ItemType` | `Type` |
| `ConnectionMonitorOutput` | `OutputType` | `Type` |
| `ConnectionMonitorTestConfiguration` | `DisableTraceRoute` | `IcmpDisableTraceRoute` |
| `ContainerNetworkInterfaceIPConfiguration` | `ContainerNetworkInterfaceIpConfigurationType` | `Type` |
| `CustomIPPrefix` | `ParentCustomIPPrefixId` | `CustomIPPrefixParent` |
| `ExpressRouteCircuitPeering` | `ExpressRouteConnectionId` | `ExpressRouteConnection` |
| `ExpressRouteConnection` | `ExpressRouteCircuitPeeringId` | `ExpressRouteCircuitPeering` |
| `ExpressRouteCrossConnection` | `ExpressRouteCircuitId` | `ExpressRouteCircuit` |
| `ExpressRouteGateway` | `ExpressRouteConnectionList` | `ExpressRouteConnections` |
| `ExpressRouteGateway` | `VirtualHubId` | `VirtualHub` |
| `FlowLog` | `TrafficAnalyticsConfiguration` | `NetworkWatcherFlowAnalyticsConfiguration` |
| `GatewayLoadBalancerTunnelInterface` | `InterfaceType` | `Type` |
| `LoadBalancerBackendAddress` | `LoadBalancerFrontendIPConfigurationId` | `LoadBalancerFrontendIPConfiguration` |
| `NetworkPrivateEndpointConnection` | `ConnectionState` | `PrivateLinkServiceConnectionState` |
| `NetworkPrivateLinkServiceConnection` | `ConnectionState` | `PrivateLinkServiceConnectionState` |
| `NetworkVirtualApplianceConnection` | `ConnectionRoutingConfiguration` | `RoutingConfiguration` |
| `NvaInterfaceConfigurationsProperties` | `PropertiesType` | `Type` |
| `P2SConnectionConfiguration` | `ConfigurationPolicyGroups` | `ConfigurationPolicyGroupAssociations` |
| `PacketCapture` | `IsContinuousCapture` | `ContinuousCapture` |
| `PrivateEndpointIPConfiguration` | `PrivateEndpointIPConfigurationType` | `Type` |
| `RoutingRuleRouteDestination` | `DestinationType` | `Type` |
| `SubnetResource` | `PrivateEndpointNetworkPolicy` | `PrivateEndpointNetworkPolicies` |
| `SubnetResource` | `PrivateLinkServiceNetworkPolicy` | `PrivateLinkServiceNetworkPolicies` |
| `TunnelConnectionHealth` | `LastConnectionEstablishedOn` | `LastConnectionEstablishedUtcTime` |
| `VirtualApplianceIPConfiguration` | `IsPrimary` | `VirtualApplianceIPPrimary` |
| `VirtualHub` | `Routes` | `RouteTableRoutes` |
| `VirtualNetwork` | `PrivateEndpointVnetPolicy` | `PrivateEndpointVNetPolicies` |
| `VirtualNetworkEncryption` | `IsEnabled` | `Enabled` |
| `VirtualNetworkGateway` | `Active` | `ActiveActive` |
| `VirtualNetworkPeering` | `AreCompleteVnetsPeered` | `PeerCompleteVnets` |

These aliases remove 77 `CP0002` diagnostics per framework. None of the
released property names in this table remain in the ApiCompat output.

### Management SDK compatibility

The related `Azure.ResourceManager.Network` TypeSpec migration was completed
and merged through
[Azure/azure-sdk-for-net#63027](https://github.com/Azure/azure-sdk-for-net/pull/63027).
The management package uses SDK-side `[CodeGenType]` customizations and
compatibility classes for the routing configuration model family so the
shared TypeSpec names remain correct for provisioning while the released
management dual-surface API remains unchanged.

The merged management work includes:

- Excluding six deprecated Compute-backed Cloud Services operations from C#
  generation to avoid duplicate `NetworkInterface` resource projections
- Restoring the released management APIs through hidden, obsolete compatibility
  customizations
- Restoring the legacy `BastionHostResource.Update` overloads
- Preserving the legacy enum-shaped
  `HubVirtualNetworkConnectionData.EnableOnlyIPv6Peering` API while generating
  the current Boolean service property
- Preserving released Network Manager connection APIs and resource hierarchies

Management generation, API export, build, ApiCompat, and tests passed before
that PR was merged.

### Resource names

SDK-side `[CodeGenType]` customizations restore the released names for three
resources:

| TypeSpec-generated name | Public SDK name |
|---|---|
| `Probe` | `ProbeResource` |
| `Route` | `RouteResource` |
| `Subnet` | `SubnetResource` |

This resolves the corresponding `AZC0012` analyzer failures.

### Scope-specific Network Manager connections

The TypeSpec emitter consolidates the released
`ManagementGroupNetworkManagerConnection` and
`SubscriptionNetworkManagerConnection` resources into the generated
`NetworkManagerConnection`. Both released scope-specific resources are
restored under `src/Custom` with their original public API, property paths,
`BicepValue<ETag>` property type, ARM resource type, and API version. They are
hidden with `EditorBrowsable(Never)` and marked obsolete in favor of
`NetworkManagerConnection`.

Restoring these resources reduces the removed-type diagnostics from 10 to 8.

### Unreferenced compatibility types

Five released types were unreferenced by every other public or internal
provisioning type:

- `DdosCustomPolicyTriggerSensitivityOverride`
- `ProtocolCustomSettings`
- `PropagatedRouteTableNfv`
- `RoutingConfigurationNfv`
- `RoutingConfigurationNfvSubResource`

The enum and four empty constructs are restored under `src/Custom/Models` with
their released names and members. They are hidden with
`EditorBrowsable(Never)` and marked obsolete. The populated generated routing
models remain `PropagatedRouteTable` and `RoutingConfiguration`.

Restoring these unreferenced types reduces the removed-type diagnostics from 8
to 3.

### Colliding enum client names

Three TypeSpec enums retain their released provisioning names through
SDK-side `[CodeGenType]` customizations:

| TypeSpec enum | C# `clientName` target | Released provisioning type |
|---|---|---|
| `ConnectionMonitorType` | `ConnectionMonitorEndpointType` | `ConnectionMonitorType` |
| `DdosSettingsProtectionMode` | `DdosSettingsProtectionCoverage` | `DdosSettingsProtectionMode` |
| `DdosTrafficType` | `DdosCustomPolicyProtocol` | `DdosTrafficType` |

The mappings are required for more than naming compatibility. Each
`clientName` target was already a different released provisioning enum:

- `ConnectionMonitorEndpointType` describes endpoint kinds such as
  `AzureVm`, `AzureVNet`, and `ExternalAddress`.
- `DdosSettingsProtectionCoverage` contains `Basic` and `Standard`.
- `DdosCustomPolicyProtocol` contains `Tcp`, `Udp`, and `Syn`.

Allowing generation to apply the `clientName` values directly replaces those
three existing enums with unrelated values. The customizations instead make
`ConnectionMonitor.ConnectionMonitorType`,
`ConnectionMonitorResultProperties.ConnectionMonitorType`,
`DdosSettings.ProtectionMode`, and `TrafficDetectionRule.TrafficType` use their
released enum types. Separate custom declarations preserve the three original
collision-target enums and their distinct values.

This restores all three removed types and 15 removed members. ApiCompat now
reports no `CP0001` diagnostics.

### Child-resource model promotions

Four released inline data models now have first-class child-resource
counterparts:

| Legacy construct | Current resource | Parent |
|---|---|---|
| `ExpressRouteLinkData` | `ExpressRouteLink` | `ExpressRoutePort` |
| `PeerExpressRouteCircuitConnectionData` | `PeerExpressRouteCircuitConnection` | `ExpressRouteCircuitPeering` |
| `VpnSiteLinkConnectionData` | `VpnSiteLinkConnection` | `VpnConnection` |
| `VpnSiteLinkData` | `VpnSiteLink` | `VpnSite` |

The released `ProvisionableConstruct` types and their original parent
collection properties are preserved as hidden, obsolete custom APIs. The
generated resource collections remain available under distinct names:

- `ExpressRoutePort.LinkResources`
- `ExpressRouteCircuitPeering.PeeredConnectionResources`
- `VpnConnection.VpnLinkConnectionResources`
- `VpnSite.VpnSiteLinkResources`

The old and new collection shapes serialize to the same ARM property paths.
Callers should use one shape or the other for a given parent. ApiCompat reports
no remaining diagnostics for these four types or their parent properties.

### Flow log format model

The released provisioning `FlowLogProperties` construct represented only the
nested `properties.format` object in the ARM payload:

```json
{
  "properties": {
    "format": {
      "type": "JSON",
      "version": 2
    }
  }
}
```

TypeSpec names this nested shape `FlowLogFormatParameters`. It is distinct from
both the complete Flow Log resource-properties envelope
`FlowLogPropertiesFormat` and the separate Network Watcher operation model
`FlowLogProperties`.

An SDK-side `[CodeGenType("FlowLogFormatParameters")]` customization restores
the provisioning name `FlowLogProperties`, and `[CodeGenMember("Type")]`
restores `FormatType`. `FlowLog.Format`, `FlowLogProperties.FormatType`, and
`FlowLogProperties.Version` therefore preserve the released API while still
serializing to `properties.format.type` and `properties.format.version`.
ApiCompat reports no remaining Flow Log diagnostics, and the prior
`FlowLogProperties` test-compilation error is resolved.

### Routing configuration model names

The shared TypeSpec models are named `RoutingConfiguration` and
`PropagatedRouteTable`. Two C# `@@clientName` customizations previously renamed
them to `RoutingConfigurationNfv` and `PropagatedRouteTableNfv` for every C#
emitter. Those decorators were removed because the provisioning library's
released populated models use the plain names.

The management SDK preserves its released dual surface with SDK-side
customizations:

- Generated native models remain `RoutingConfigurationNfv` and
  `PropagatedRouteTableNfv` through `[CodeGenType]`.
- `RoutingConfiguration` and `PropagatedRouteTable` remain compatibility
  subclasses.
- The generator retains `PropagatedRouteTableNfv.Ids` as
  `IList<RoutingConfigurationNfvSubResource>` without a member customization.

The released management `RoutingConfigurationNfv` also exposed
`AssociatedRouteTableResourceUri`, `InboundRouteMapResourceUri`, and
`OutboundRouteMapResourceUri`. Those properties previously serialized through
nested `resourceUri` fields, while TypeSpec defines standard `SubResource`
values with nested `id` fields. The compatibility properties have no current
wire behavior, so they are hidden with `EditorBrowsable(Never)` and marked
obsolete in favor of `AssociatedRouteTableId`, `InboundRouteMapId`, and
`OutboundRouteMapId`. `RoutingConfigurationNfvSubResource.ResourceUri` remains
functional for `PropagatedRouteTableNfv.Ids` and serializes as `id`.

The management package builds against version 1.17.0 with zero ApiCompat
diagnostics. Provisioning generation now directly produces
`RoutingConfiguration` and `PropagatedRouteTable`, and affected resource
properties use `RoutingConfiguration`. The prior provisioning rename
diagnostics are resolved.

`PropagatedRouteTable.Ids` still uses `BicepList<NetworkSubResource>` instead of
the released `BicepList<WritableSubResource>`. This is a separate property-type
compatibility issue and remains one of the four test-compilation blockers.

### Historical resource versions

The TypeSpec emitter generates the current `V2025_05_01` resource version.
Thirty-one partial classes under `src/Custom` restore the historical
`ResourceVersions` constants for released resource types.

These customizations restore 1,882 legacy constants. The exported API contains
all 2,000 version fields from the pre-migration API plus 15 fields introduced
by the new generation. This eliminated 5,646 `CP0002` diagnostics across the
three target frameworks.

### Cloud Services projection collision

The following operations are excluded from the C# scope:

- `NetworkInterfaces.getCloudServiceNetworkInterface`
- `NetworkInterfaces.listCloudServiceRoleInstanceNetworkInterfaces`
- `NetworkInterfacesOperationGroup.listCloudServiceNetworkInterfaces`
- `PublicIPAddresses.getCloudServicePublicIPAddress`
- `PublicIPAddresses.listCloudServiceRoleInstancePublicIPAddresses`
- `PublicIPAddressesOperationGroup.listCloudServicePublicIPAddresses`

Without these exclusions, the provisioning emitter attempts to project both
`microsoft.Compute/cloudServices/roleInstances/networkInterfaces` and
`Microsoft.Network/networkInterfaces` as `NetworkInterface` and terminates on
the duplicate class name.

## Current generated-code scope

The package currently contains:

- 825 generated C# files
- 53 customization files under `src/Custom`
- 629 public API types in the `net8.0` API listing

Compared with SDK `main`, the generated tree contains:

- 573 modified files
- 253 added files
- 16 deleted files

The migration adds 40 public types, including 17 resource types:

- `ApplicationGatewayAvailableSslOptionsInfo`
- `ApplicationGatewayWafDynamicManifest`
- `AzureWebCategory`
- `CloudServiceSwap`
- `DefaultSecurityRule`
- `ExpressRouteLink`
- `ExpressRoutePortsLocation`
- `ExpressRouteProviderPort`
- `NetworkSecurityPerimeterLinkReference`
- `NetworkManagerConnection`
- `NetworkVirtualApplianceSku`
- `PeerExpressRouteCircuitConnection`
- `VirtualMachineScaleSetNetworkInterface`
- `VirtualMachineScaleSetNetworkInterfaceIPConfiguration`
- `VirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddress`
- `VpnSiteLink`
- `VpnSiteLinkConnection`

## Deferred work

The following work remains intentionally deferred until the provisioning API
compatibility approach is reviewed:

- Mitigation of the remaining 180 incompatible-member diagnostics
- Restoration of the six affected enums' released member ordering
- Revalidation and resolution of the remaining test-compilation issues,
  followed by unit and live test validation
- Changelog finalization

The current CI failures on the SDK PR are consistent with this unfinished
compatibility phase; the migration should not be treated as release-ready until
ApiCompat and the affected tests pass normally.
