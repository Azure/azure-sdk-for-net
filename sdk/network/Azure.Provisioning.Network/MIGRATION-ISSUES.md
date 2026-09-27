# Azure.Provisioning.Network Migration Status

## Generation inputs

- SDK PR: [#63070](https://github.com/Azure/azure-sdk-for-net/pull/63070)
- Spec PR: [Azure/azure-rest-api-specs#46412](https://github.com/Azure/azure-rest-api-specs/pull/46412)
- Provisioning spec commit: `0aa6bd92d3113c57472f0be6ac307383f139fd0e`
- Management spec commit: `fcc3feb29d0bb5aa12829e8649deda5f8087fae9` (includes the C# numeric bandwidth rename and model-level managed identity substitution; provisioning remains pinned until its API-version bump)
- Provisioning emitter: `@azure-typespec/http-client-csharp-provisioning@1.0.0-alpha.20260916.3`
- TypeSpec compiler: `1.15.0`
- API versions: Network `2025-05-01`; Compute `2018-10-01`
- Released provisioning compatibility baseline: `1.1.0`

## Current status

The package is **not release-ready**.

| Area | Status |
|---|---|
| Provisioning generation | Succeeds from the provisioning spec commit above. |
| Provisioning compilation and API export | Pass for `netstandard2.0`, `net8.0`, and `net10.0`; API listings are current. |
| Provisioning ApiCompat | 107 diagnostics per framework; normal package builds fail this gate. |
| Standard test project | Blocked by the read-only `NetworkSecurityGroup.Id` assignment listed below. |
| Management compilation, API export, and ApiCompat | Pass; no active management ApiCompat diagnostics. |
| Management strong-type regeneration | Not a no-op: seven internal property types change and six model-factory overloads are added; existing public signatures are retained. |
| Recommended property names | `IsPrimary`, `DisableTraceRoute`, and `ConfigurationPolicyGroups` match management. Agreed naming exceptions are listed below. |

## Remaining API compatibility issues

Counts are per target framework. The same diagnostic set is reported for all
three frameworks.

| Diagnostic | Count | Meaning |
|---|---:|---|
| `CP0001` | 0 | Removed public types |
| `CP0002` | 83 | Removed or incompatible public member signatures |
| `CP0011` | 24 | Changed enum numeric values |
| **Total** | **107** | |

A changed property type can produce missing-getter and missing-setter
diagnostics even when the property name still exists. Diagnostic counts
therefore differ from logical member counts.

### Removed or incompatible members

| Category | Diagnostics | Affected members |
|---|---:|---:|
| Property type changed | 3 | 3 properties |
| Property missing | 5 | 3 properties |
| Property became read-only | 51 | 51 properties |
| Enum member missing | 24 | 24 fields |
| **Total** | **83** | **81** |

Missing properties:

| Category | Diagnostics | Properties | Details |
|---|---:|---:|---|
| Renamed and type changed | 2 | 1 | `ConnectionMonitorEndpoint.EndpointType`. |
| Flattened wrapper missing | 3 | 2 | `LoadBalancerInboundNatPool.Properties` and `LoadBalancingRule.Properties`. |

Changed property types:

| Category | Diagnostics | Properties | Details |
|---|---:|---:|---|
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

### Deferred provisioning API-version bump

Before fixing `ManagedRuleSetRuleGroup.Rules` and
`VirtualNetworkAppliance.BandwidthInGbps` compatibility, bump the provisioning
Network API version from `2025-05-01` to match the management generation version.
The exact target version must be confirmed before the bump.

Swagger and TypeSpec agree that `rules` changes from `string[]` to `int32[]` in
`2026-01-01`, and `bandwidthInGbps` changes from `string` to `float64` in
`2025-07-01`. However, regeneration with saved inputs already produces `int32[]`
and `float64` in `tspCodeModel.json` with provisioning configured for `2025-05-01`.
The mismatch precedes C# generation; its cause within version selection or the
shared code-model pipeline is not yet established.

Provisioning fixes for these two properties are intentionally deferred until the
API-version bump. The C# `clientName` customization introducing `BandwidthGbps`
for management is shared with provisioning and must be accounted for when
updating the provisioning spec pin and regenerating.

## Compatibility customizations

### Management numeric bandwidth

Management uses the C# client name `BandwidthGbps` for the numeric
`VirtualNetworkApplianceData` property while preserving the wire path
`properties.bandwidthInGbps`. The released string property `BandwidthInGbps`
forwards to it using invariant-culture parsing and round-trip formatting; null
clears the numeric value, and invalid numeric text throws rather than being
silently ignored.

Both existing management model-factory overloads retain their signatures and
populate the same numeric property. Custom factory implementations are needed
because the generated compatibility methods otherwise discard the bandwidth
argument after the property rename. Provisioning code is unchanged.

### Strong property types

C# `alternateType` customizations restore all 26 provisioning properties whose
strong types or collection element types had become `string`. The restored
types are `ResourceIdentifier`, `ResourceType`, `AzureLocation`, `Guid`,
`IPAddress`, `Uri`, and `BinaryData`. The three `BinaryData` properties use
TypeSpec `unknown`, matching the management library's existing raw-JSON
representation rather than introducing byte/base64 encoding.

The exact ApiCompat delta is 26 removed diagnostics per framework, with none
added. Three setter diagnostics formerly grouped with these type changes remain:
`ResourceNavigationLink.LinkedResourceType`, `ServiceAssociationLink.LinkedResourceType`,
and `ServiceAssociationLink.Locations`. They are now counted in the read-only
category; this change restores their types, not their missing setters.

The management public property types were already strong, but seven underlying
internal properties were still string-based. Shared TypeSpec customizations
therefore also change the following management internals and their serializers:

| Internal management model | Changed properties |
|---|---|
| `BackendAddressPoolPropertiesFormat` | `Location` |
| `NetworkVirtualAppliancePropertiesFormat` | `PrivateIPAddress` |
| `PrivateEndpointIPConfigurationProperties` | `PrivateIPAddress` |
| `ResourceNavigationLinkFormat` | `LinkedResourceType` |
| `ServiceAssociationLinkPropertiesFormat` | `LinkedResourceType`, `Locations` |
| `ServiceEndpointPolicyDefinitionPropertiesFormat` | `ServiceResources` |

`ArmNetworkModelFactory` gains six corresponding strongly typed overloads while
retaining the old overloads. Management ApiCompat passes, but the expectation of
unchanged management generated code and API output is not met. Existing
management custom compatibility members have not been changed.

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

`CustomIPPrefix.ChildCustomIPPrefixList` is restored as a hidden, obsolete,
getter-only `BicepList<WritableSubResource>` with its own backing field. It exposes
the same output-only `properties.childCustomIpPrefixes` Bicep path as the unchanged
generated `ChildCustomIPPrefixes` property, which remains the preferred API.

### Properties without generated equivalents

All fifteen properties in this category are restored with
`EditorBrowsable(Never)`, without `Obsolete`. The thirteen output properties have
their own backing fields and preserve the signatures, Bicep paths, and output
behavior from tag `Azure.Provisioning.Network_1.1.0`. The two additional-properties
bags are compatibility-only auto-properties and are not registered for Bicep
generation:

| Properties | Bicep path | Behavior |
|---|---|---|
| Twelve `ResourceType` properties listed below | `type` | Getter-only `BicepValue<ResourceType>`, output-only. |
| `DdosProtectionPlan.SystemData` | `systemData` | Getter-only `SystemData`, output-only. |
| `LoadBalancerInboundNatPoolProperties.AdditionalProperties` and `LoadBalancingRuleProperties.AdditionalProperties` | None | Writable `BicepDictionary<BinaryData>` auto-properties; values are ignored by Bicep generation. |

The restored `ResourceType` properties belong to
`ApplicationGatewayEntraJwtValidationConfig`, `ApplicationGatewayRewriteRuleSet`,
`AzureFirewallApplicationRuleCollectionData`, `AzureFirewallNatRuleCollectionData`,
`AzureFirewallNetworkRuleCollectionData`, `NetworkIPConfiguration`,
`P2SConnectionConfiguration`, `VirtualNetworkGatewayIPConfiguration`,
`VirtualNetworkGatewayPolicyGroup`, `VngClientConnectionConfiguration`,
`VpnClientRevokedCertificate`, and `VpnClientRootCertificate`.

The released dictionaries used an uppercase `AdditionalProperties` Bicep path,
but additional-properties support was never implemented. The restored properties
have no explicit backing field or Bicep definition; they satisfy API compatibility
only.

## Other outstanding issues

### Additional-properties support

[Issue #60666](https://github.com/Azure/azure-sdk-for-net/issues/60666) tracks
additional-properties support in the provisioning generator. The restored
`AdditionalProperties` properties are intentionally nonfunctional: neither
literal nor expression entries are emitted to Bicep.

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
