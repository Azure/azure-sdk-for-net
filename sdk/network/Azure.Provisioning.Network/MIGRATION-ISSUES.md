# Azure.Provisioning.Network TypeSpec Migration Status

This report describes the current state of the
`Azure.Provisioning.Network` migration to the TypeSpec provisioning emitter.
It reflects the generated code and API surface in SDK PR
[Azure/azure-sdk-for-net#63070](https://github.com/Azure/azure-sdk-for-net/pull/63070).

## Current generation inputs

- Spec PR:
  [Azure/azure-rest-api-specs#46412](https://github.com/Azure/azure-rest-api-specs/pull/46412)
- Spec commit: `f5132f8a007ad9fd37adbc4bceb8f1281fbab9cb`
- Provisioning emitter:
  `@azure-typespec/http-client-csharp-provisioning`
  `1.0.0-alpha.20260916.3`
- TypeSpec compiler: `1.15.0`
- `Microsoft.Network` API version: `2025-05-01`
- `Microsoft.Compute` API version: `2018-10-01`

The spec PR has been updated with the latest `main`. Its `client.tsp` is
identical to `main`; its only Network-specific diff is `tspconfig.yaml`, which
adds the provisioning emitter configuration and pins the management and
provisioning API versions.

Both `Azure.Provisioning.Network` and `Azure.ResourceManager.Network` pin the
same spec commit. Regenerating both libraries from that commit completed
without producing additional generated-code changes.

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
| `CP0001` | 10 | 30 | Removed public types |
| `CP0002` | 411 | 1,233 | Removed public members |
| `CP0011` | 24 | 72 | Changed public member types |
| **Total** | **445** | **1,335** | |

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

The current API has 619 public types, compared with 589 in the pre-migration
API. It adds 40 public types and removes these 10:

- `ConnectionMonitorType`
- `DdosCustomPolicyTriggerSensitivityOverride`
- `DdosSettingsProtectionMode`
- `DdosTrafficType`
- `ManagementGroupNetworkManagerConnection`
- `PropagatedRouteTable`
- `ProtocolCustomSettings`
- `RoutingConfiguration`
- `RoutingConfigurationNfvSubResource`
- `SubscriptionNetworkManagerConnection`

Several removed models have clear generated successors:

| Removed type | Current generated type | Current shape |
|---|---|---|
| `PropagatedRouteTable` | `PropagatedRouteTableNfv` | Construct |
| `RoutingConfiguration` / `RoutingConfigurationNfvSubResource` | `RoutingConfigurationNfv` | Construct |

These successors do not by themselves preserve the released API. Compatibility
work must decide whether to restore adapters, aliases, or obsolete stubs for
each removed type.

`ManagementGroupNetworkManagerConnection` and
`SubscriptionNetworkManagerConnection` remain the highest-priority removed
resource types. Their ARM resource type,
`Microsoft.Network/networkManagerConnections`, is now represented by the
generated `NetworkManagerConnection`, but the two released scope-specific
resource classes are absent.

### Removed and changed members

The remaining 411 `CP0002` and 24 `CP0011` diagnostics per framework cover
removed members and changed property types on otherwise retained public types.
They have not yet been broadly mitigated. The ApiCompat output should be used
as the source of truth when this phase begins.

## Resolved migration work

### Management SDK compatibility

The related `Azure.ResourceManager.Network` TypeSpec migration was completed
and merged through
[Azure/azure-sdk-for-net#63027](https://github.com/Azure/azure-sdk-for-net/pull/63027).
The provisioning migration has no management-package code delta from current
SDK `main`; it changes only the management package's `tsp-location.yaml` pin.

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

- 574 modified files
- 253 added files
- 15 deleted files

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
