# Azure.Provisioning.Network TypeSpec Migration Status

This report describes the current state of the
`Azure.Provisioning.Network` migration to the TypeSpec provisioning emitter.
It reflects the generated code and API surface in SDK PR
[Azure/azure-sdk-for-net#63070](https://github.com/Azure/azure-sdk-for-net/pull/63070).

## Current generation inputs

- Spec PR:
  [Azure/azure-rest-api-specs#46412](https://github.com/Azure/azure-rest-api-specs/pull/46412)
- Spec commit: `a3a076f131f1a11a5748c6eb21bc0b09092c9e6a`
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

The current generated provisioning source compiles for `netstandard2.0`,
`net8.0`, and `net10.0`.

The following checks pass:

- TypeSpec validation for the Network project
- Provisioning and management SDK generation
- `dotnet format` for both Network SDK projects
- Network service API export, with zero warnings and errors
- `git diff --check`

The normal `Azure.Provisioning.Network` package build remains blocked by
intentional, unmitigated ApiCompat differences. ApiCompat reports the following
unique differences for each target framework:

| Diagnostic | Per framework | Across three frameworks | Meaning |
|---|---:|---:|---|
| `CP0001` | 8 | 24 | Removed public types |
| `CP0002` | 408 | 1,224 | Removed public members |
| `CP0011` | 24 | 72 | Changed public member types |
| **Total** | **440** | **1,320** | |

These diagnostics are the remaining provisioning compatibility backlog. They
are not C# compilation or generation failures.

The non-live test project restores successfully, but tests do not yet execute.
After bypassing the separately measured ApiCompat gate with
`RunApiCompat=false`, test compilation reports four migration issues across its
target frameworks:

- A `WritableSubResource` value cannot be assigned to
  `BicepValue<NetworkSubResource>`.
- `SubnetResource.PrivateEndpointNetworkPolicy` is absent.
- `SubnetResource.PrivateLinkServiceNetworkPolicy` is absent.
- `NetworkSecurityGroup.Id` is now read-only.

No test failures have been observed because compilation stops before test
execution.

## Remaining provisioning compatibility work

### Removed public types

The current API has 621 public types, compared with 589 in the pre-migration
API. It adds 40 public types and removes these 8:

- `ConnectionMonitorType`
- `DdosCustomPolicyTriggerSensitivityOverride`
- `DdosSettingsProtectionMode`
- `DdosTrafficType`
- `PropagatedRouteTableNfv`
- `ProtocolCustomSettings`
- `RoutingConfigurationNfv`
- `RoutingConfigurationNfvSubResource`

`PropagatedRouteTableNfv`, `RoutingConfigurationNfv`, and
`RoutingConfigurationNfvSubResource` were empty and unreferenced constructs in
the released provisioning API. The populated generated models now use the
released `PropagatedRouteTable` and `RoutingConfiguration` names directly.
Compatibility work must still decide whether the three empty NFV types should
be restored as hidden obsolete stubs.

### Removed and changed members

The remaining 408 `CP0002` and 24 `CP0011` diagnostics per framework cover
removed members and changed property types on otherwise retained public types.
They have not yet been broadly mitigated. The ApiCompat output should be used
as the source of truth when this phase begins.

## Resolved migration work

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

- 828 generated C# files
- 40 customization files under `src/Custom`
- 619 public API types in the `net8.0` API listing

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

- Mitigation of the 10 removed public types
- Mitigation of the remaining removed and changed members
- Resolution of the four current test-compilation issues, followed by unit and
  live test validation
- Changelog finalization

The current CI failures on the SDK PR are consistent with this unfinished
compatibility phase; the migration should not be treated as release-ready until
ApiCompat and the affected tests pass normally.
