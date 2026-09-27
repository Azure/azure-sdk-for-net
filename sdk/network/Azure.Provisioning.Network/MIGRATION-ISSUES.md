# Azure.Provisioning.Network Migration Status

## Generation inputs

- SDK PR: [#63070](https://github.com/Azure/azure-sdk-for-net/pull/63070)
- Spec PR: [Azure/azure-rest-api-specs#46412](https://github.com/Azure/azure-rest-api-specs/pull/46412)
- Spec commit: `6fbbece49d73e6fb44324d825f282d377b5a3978` (shared with management)
- Provisioning emitter: `@azure-typespec/http-client-csharp-provisioning@1.0.0-alpha.20260916.3`
- TypeSpec compiler: `1.15.0`
- API versions: Network `2025-05-01`; Compute `2018-10-01`
- Released provisioning compatibility baseline: `1.1.0`

## Current status

The package is **not release-ready**.

| Area | Status |
|---|---|
| Provisioning generation | Succeeds from the shared spec commit. |
| Provisioning compilation and API export | Pass for `netstandard2.0`, `net8.0`, and `net10.0`; API listings are current. |
| Provisioning ApiCompat | 151 diagnostics per framework; normal package builds fail this gate. |
| Standard test project | Blocked by the read-only `NetworkSecurityGroup.Id` assignment listed below. |
| Management compilation, API export, and ApiCompat | Pass; no active management ApiCompat diagnostics. |
| Recommended property names | `IsPrimary`, `DisableTraceRoute`, and `ConfigurationPolicyGroups` match management. Agreed naming exceptions are listed below. |

## Remaining API compatibility issues

Counts are per target framework. The same diagnostic set is reported for all
three frameworks.

| Diagnostic | Count | Meaning |
|---|---:|---|
| `CP0001` | 0 | Removed public types |
| `CP0002` | 127 | Removed or incompatible public member signatures |
| `CP0011` | 24 | Changed enum numeric values |
| **Total** | **151** | |

A changed property type can produce missing-getter and missing-setter
diagnostics even when the property name still exists. Diagnostic counts
therefore differ from logical member counts.

### Removed or incompatible members

| Category | Diagnostics | Affected members |
|---|---:|---:|
| Property type changed | 32 | 29 properties |
| Property missing | 23 | 19 properties |
| Property became read-only | 48 | 48 properties |
| Enum member missing | 24 | 24 fields |
| **Total** | **127** | **120** |

Missing properties:

| Category | Diagnostics | Properties | Details |
|---|---:|---:|---|
| Renamed and type changed | 3 | 2 | `ConnectionMonitorEndpoint.EndpointType` and `CustomIPPrefix.ChildCustomIPPrefixList`. |
| Flattened wrapper missing | 3 | 2 | `LoadBalancerInboundNatPool.Properties` and `LoadBalancingRule.Properties`. |
| No generated equivalent | 17 | 15 | Twelve `ResourceType` getters without a generated `Type` property, one `SystemData` getter, and two `AdditionalProperties` bags. |

The twelve missing `ResourceType` properties are deferred:
`ApplicationGatewayEntraJwtValidationConfig`, `ApplicationGatewayRewriteRuleSet`,
`AzureFirewallApplicationRuleCollectionData`, `AzureFirewallNatRuleCollectionData`,
`AzureFirewallNetworkRuleCollectionData`, `NetworkIPConfiguration`,
`P2SConnectionConfiguration`, `VirtualNetworkGatewayIPConfiguration`,
`VirtualNetworkGatewayPolicyGroup`, `VngClientConnectionConfiguration`,
`VpnClientRevokedCertificate`, and `VpnClientRootCertificate`.

Changed property types:

| Category | Diagnostics | Properties | Details |
|---|---:|---:|---|
| Strong type became `string` | 29 | 26 | Includes `ResourceIdentifier`, `ResourceType`, `BinaryData`, `Guid`, `AzureLocation`, `IPAddress`, and `Uri` values or collection elements. |
| Other type changes | 3 | 3 | `BicepList<string>` to `BicepList<int>`, `BicepValue<string>` to `BicepValue<double>`, and `ManagedServiceIdentity` to `InternalNetworkManagedServiceIdentity`. |

### Changed enum numeric values

| Enum | Affected members |
|---|---:|
| `ApplicationGatewayCustomErrorStatusCode` | 9 |
| `FirewallPolicyIntrusionDetectionProfileType` | 4 |
| `LoadBalancerBackendAddressAdminState` | 3 |
| `ManagedRuleSensitivityType` | 3 |
| `VpnAuthenticationType` | 3 |
| `IPsecIntegrity` | 2 |

## Compatibility customizations

### Resource type compatibility

Thirty-five provisioning models retain hidden, obsolete, getter-only
`ResourceType` aliases that forward to their generated `Type` properties.
The aliases preserve the Bicep reference and output-only behavior rather than
defining a second property at the same wire path. `Type` remains the preferred API.

Management's `NetworkResourceData.ResourceType` is also hidden and obsolete.
Its getter converts the generated `Type` value to `ResourceType?`; its setter
intentionally does nothing, as stated in its deprecation message.

### Resource-reference collections

The fifteen collection type changes are restored through `CodeGenMember`
overrides on their declaring models. Regenerated flattened properties use
`BicepList<WritableSubResource>` or `BicepList<SubResource>`, preserving their
existing setters, output-only behavior, and wire paths. Writable references
serialize as objects containing `id`, not scalar IDs.

`CustomIPPrefix.ChildCustomIPPrefixList` remains in the separate renamed-and-type-
changed category; its generated replacement is still `ChildCustomIPPrefixes`.

## Other outstanding issues

### Test compilation

`tests\BasicNetworkTests.cs:593` assigns the read-only `NetworkSecurityGroup.Id`
property. This is the remaining compilation blocker for the standard tests.

### Resource-reference Bicep shape

`CustomIPPrefix.ParentCustomIPPrefixId` emits:

```bicep
customIpPrefixParent: '<resource-id>'
```

The service expects:

```bicep
customIpPrefixParent: {
  id: '<resource-id>'
}
```

The generated property path is missing the `id` segment. This serialization
issue is not detected by ApiCompat.

### Safe-flatten property naming

[Issue #60921](https://github.com/Azure/azure-sdk-for-net/issues/60921):
Boolean-specific safe-flatten naming does not recognize `BicepValue<bool>`,
so provisioning can recommend a different name from management.

Custom `CodeGenMember` workarounds expose `VirtualApplianceIPConfiguration.IsPrimary`
and `ConnectionMonitorTestConfiguration.DisableTraceRoute` without obsolete/hidden
attributes. Neither `VirtualApplianceIPIsPrimary` nor `IcmpDisableTraceRoute` appears
in the exported API. The shared generator issue remains open.

### Property preference differences from management

There are no remaining actionable differences from the reviewed property list.

`P2SConnectionConfiguration.ConfigurationPolicyGroups` is the generated,
non-obsolete property. Its hidden, obsolete `ConfigurationPolicyGroupAssociations`
alias forwards both accessors to it. The Bicep path remains
`properties.configurationPolicyGroupAssociations`.

`NetworkVirtualApplianceConnection.ConnectionRoutingConfiguration` now has
matching deprecation direction in both libraries: prefer `RoutingConfiguration`.

Accepted differences, not pending fixes:

- `ConnectionMonitor` retains the `StartsOn` preference.
- `ExpressRouteGateway` retains the `ExpressRouteConnections` preference.
- `ExpressRouteCircuitPeering`, `ExpressRoutePort`, `VpnConnection`, and `VpnSite`
  retain the separate `*Resources` collections to preserve their legacy
  data-model collection APIs.

Changelog finalization and release validation remain pending.
