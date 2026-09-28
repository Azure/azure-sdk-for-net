# Azure.Provisioning.Network Migration Status

## Generation inputs

- SDK PR: [#63070](https://github.com/Azure/azure-sdk-for-net/pull/63070)
- Spec PR: [Azure/azure-rest-api-specs#46412](https://github.com/Azure/azure-rest-api-specs/pull/46412)
- Provisioning spec commit: `45eb28b7d30eebfb5820bac7573f03a1fc1f2eb3`. This incorporates the canonical cipher-suite names, preserving the prior enum customizations and API version.
- Management spec pin: `a0e861add6ddb55f23a1cf5a30630b067be701d7` for canonical SSL protocol names. These protocol customizations are pending regeneration; current generated management code and successful validation correspond to `45eb28b7d30eebfb5820bac7573f03a1fc1f2eb3`.
- Management naming and compatibility changes committed and pushed through SDK commit `d8ed7895674`; the newer SSL protocol changes remain uncommitted and require regeneration before compilation.
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
| Provisioning ApiCompat | 58 diagnostics per framework; normal package builds fail this gate. Cipher-suite name corrections remove exactly 12 diagnostics per framework from the previous 70, with zero additions. |
| Standard test project | Blocked by the read-only `NetworkSecurityGroup.Id` assignment listed below. |
| Management compilation and API export | Passed for all three frameworks at `45eb28b7d30`, including canonical cipher names. The newer SSL protocol customizations still require regeneration and validation. |
| Management ApiCompat | Passed against released 1.17.0 for all three frameworks at `45eb28b7d30`, with zero warnings or errors. SSL protocol changes are not yet validated. |
| Management strong-type regeneration | Not a no-op: seven internal property types change and six model-factory overloads are added; existing public signatures are retained. |
| Recommended property names | `IsPrimary`, `DisableTraceRoute`, and `ConfigurationPolicyGroups` match management. Agreed naming exceptions are listed below. |

## Remaining API compatibility issues

Counts are per target framework. The same diagnostic set is reported for all
three frameworks.

| Diagnostic | Count | Meaning |
|---|---:|---|
| `CP0001` | 0 | Removed public types |
| `CP0002` | 58 | Removed or incompatible public member signatures |
| `CP0011` | 0 | Changed enum numeric values |
| **Total** | **58** | |

A changed property type can produce missing-getter and missing-setter
diagnostics even when the property name still exists. Diagnostic counts
therefore differ from logical member counts.

### Removed or incompatible members

| Category | Diagnostics | Affected members |
|---|---:|---:|
| Property missing | 3 | 2 properties |
| Property became read-only | 51 | 51 properties |
| Enum member missing | 4 | 4 fields |
| **Total** | **58** | **57** |

Missing properties:

| Category | Diagnostics | Properties | Details |
|---|---:|---:|---|
| Flattened wrapper missing | 3 | 2 | `LoadBalancerInboundNatPool.Properties` and `LoadBalancingRule.Properties`. |

The legacy `VirtualNetworkAppliance.BandwidthInGbps` and
`ManagedRuleSetRuleGroup.Rules` signatures are now restored; they no longer
contribute missing-member or changed-type diagnostics.

### Missing enum members: next target

All four fields below existed in the released 1.1.0 API and still produce
`CP0002`. This inventory identifies missing public names, not necessarily
removed service wire values; renamed equivalents and original wire names must
be checked before choosing compatibility customizations.

The three SSL protocol entries are confirmed renames of `TLSv10`, `TLSv11`,
and `TLSv12`. Exact C# `clientName` mappings for `Tls1_0` through `Tls1_3`
are prepared in the newer management spec pin, but have not been incorporated
into provisioning.

| Enum | Missing member |
|---|---|
| `ApplicationGatewaySslProtocol` | `Tls1_0` |
| `ApplicationGatewaySslProtocol` | `Tls1_1` |
| `ApplicationGatewaySslProtocol` | `Tls1_2` |
| `PfsGroup` | `Pfs` |

### Resolved cipher-suite names

All 12 missing `ApplicationGatewaySslCipherSuite` members were renames, not
removed service values. Exact C# `clientName` mappings restore the released
`TlsECDiffieHellman...` names in generated code. Management retains the
uppercase names as custom forwarding properties with `EditorBrowsable(Never)`
and `Obsolete` in its dedicated `ApplicationGatewaySslCipherSuite.cs` file.

Provisioning regeneration from `45eb28b7d30` restores these 12 members. All
28 generated cipher-suite member names, numeric values, and `DataMember`
wire strings match the released 1.1.0 API. Scoped API export succeeds on all
three frameworks. Exact comparison with the previous 70-diagnostic baseline
removes only the 12 cipher-suite missing-member diagnostics per framework,
with zero additions, leaving 58 `CP0002` diagnostics per framework.

### Properties losing setters

These 51 properties retain getters but lose their released public setters,
producing one `CP0002` each. They are grouped by declaring type below; every
listed property is affected. The missing `LoadBalancerInboundNatPool.Properties`
setter is counted separately with the missing wrapper properties, not here.
This is a compatibility inventory, not a decision to make service output-only
properties writable.

| Declaring type | Properties losing setters | Count |
|---|---|---:|
| `ApplicationSecurityGroup` | `Id` | 1 |
| `BackendAddressPool` | `Id` | 1 |
| `ContainerNetworkInterface` | `ContainerId`, `Name` | 2 |
| `FirewallPolicy` | `Id` | 1 |
| `FirewallPolicyDraft` | `Name` | 1 |
| `FirewallPolicyRuleCollectionGroupDraft` | `Name` | 1 |
| `FlowLog` | `Id` | 1 |
| `InboundNatRule` | `Id` | 1 |
| `LoadBalancer` | `Id` | 1 |
| `NatGateway` | `Id` | 1 |
| `NetworkInterface` | `Id` | 1 |
| `NetworkInterfaceTapConfiguration` | `Id` | 1 |
| `NetworkIPConfiguration` | `Name`, `PrivateIPAddress`, `PrivateIPAllocationMethod`, `PublicIPAddress`, `Subnet` | 5 |
| `NetworkPrivateEndpointConnection` | `Id` | 1 |
| `NetworkSecurityGroup` | `Id` | 1 |
| `NetworkWatcher` | `Id` | 1 |
| `PolicySignaturesOverridesForIdps` | `Name` | 1 |
| `PrivateDnsZoneGroup` | `Id` | 1 |
| `PrivateEndpoint` | `Id` | 1 |
| `PrivateLinkService` | `Id` | 1 |
| `PublicIPAddress` | `Id` | 1 |
| `PublicIPPrefix` | `Id` | 1 |
| `ResourceNavigationLink` | `Link`, `LinkedResourceType`, `Name` | 3 |
| `RouteResource` | `HasBgpOverride`, `Id` | 2 |
| `RouteTable` | `Id` | 1 |
| `SecurityRule` | `Id` | 1 |
| `ServiceAssociationLink` | `AllowDelete`, `Link`, `LinkedResourceType`, `Locations`, `Name` | 5 |
| `ServiceEndpointPolicy` | `Id` | 1 |
| `ServiceEndpointPolicyDefinition` | `Id` | 1 |
| `SubnetResource` | `Id` | 1 |
| `VirtualNetwork` | `Id` | 1 |
| `VirtualNetworkApplianceIPConfiguration` | `Name`, `Primary`, `PrivateIPAddress`, `PrivateIPAddressVersion`, `PrivateIPAllocationMethod` | 5 |
| `VirtualNetworkPeering` | `Id` | 1 |
| `VirtualNetworkTap` | `Id` | 1 |
| `VpnLinkConnectionSharedKey` | `Name` | 1 |
| **Total** | | **51** |

### Resolved enum numeric values

Eleven assembly-level `CodeGenEnumValue` attributes in
`src/Custom/EnumValueCustomizations.cs` restore eight missing members and all
24 changed numeric values across six enums. Missing slots are reserved so
unaffected members receive their original ordinals without individual
attributes.

| Enum | Numeric-value diagnostics resolved | Missing members restored |
|---|---:|---|
| `ApplicationGatewayCustomErrorStatusCode` | 9 | `HttpStatus499` |
| `FirewallPolicyIntrusionDetectionProfileType` | 4 | `Basic`, `Standard`, `Advanced` |
| `LoadBalancerBackendAddressAdminState` | 3 | `Drain` |
| `ManagedRuleSensitivityType` | 3 | `None` |
| `VpnAuthenticationType` | 3 | `Aad` |
| `IPsecIntegrity` | 2 | `Sha384` |
| **Total** | **24** | **8 members** |

API export succeeds for all three targets. Comparing the post-enum ApiCompat
diagnostics against the previous 102-per-framework baseline removes exactly
32 diagnostics per framework and adds none. The remaining 70 are all
`CP0002`; no `CP0011` diagnostics remain.

### Deferred provisioning API-version bump

The provisioning Network API-version bump from `2025-05-01` remains deferred.
The exact target version must be confirmed before the bump. The user subsequently
approved restoring the legacy rules and bandwidth APIs independently of that
version change, and those compatibility fixes are now applied.

Swagger and TypeSpec agree that `rules` changes from `string[]` to `int32[]` in
`2026-01-01`, and `bandwidthInGbps` changes from `string` to `float64` in
`2025-07-01`. However, regeneration with saved inputs already produces `int32[]`
and `float64` in `tspCodeModel.json` with provisioning configured for `2025-05-01`.
The mismatch precedes C# generation; its cause within version selection or the
shared code-model pipeline is not yet established.

Generated `BandwidthGbps` and `RuleIds` retain their numeric types. Their legacy
counterparts emit strings at the original wire paths without conversion. This
restores compatibility but does not resolve the version-selection mismatch:
callers must use value shapes appropriate for the selected service API version.

## Compatibility customizations

### Shared managed identity

One C# model-level `alternateType` maps `Common.ManagedServiceIdentity` to
`Azure.ResourceManager.CommonTypes.ManagedServiceIdentity`. All twelve removed
property-level overrides referenced that same source model; there were no
exceptions. The model override also covers `Common.FlowLog.identity`.

Regeneration restores the released `FlowLog.Identity` get/set property using
`Azure.Provisioning.Resources.ManagedServiceIdentity`. The unused generated
`InternalNetworkManagedServiceIdentity`, `ManagedServiceIdentityUserAssignedIdentities`,
and `ResourceIdentityType` types are removed. Combined system/user-assigned
identity input, user-assigned identity dictionaries, and strongly typed GUID
output references retain their expected Bicep paths.

The identity getter compatibility diagnostic was removed. The inherited bandwidth
rename added a missing `BandwidthInGbps` setter diagnostic, leaving that round at
107 diagnostics per framework. The remaining bandwidth getter diagnostic was
unchanged. Management regeneration for the identity substitution produced no code
or public API changes. The later endpoint correction below reduces provisioning
to 105 diagnostics per framework.

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
argument after the property rename. Provisioning has picked up the numeric
property rename, and its independent string compatibility property is now
restored as described below.

### Batched provisioning rules, bandwidth, and monitor enum

The earlier batch regenerated from spec commit `624fe8233d0` and restored:

- `VirtualNetworkAppliance.BandwidthInGbps`: `BicepValue<string>` with both
  accessors, its own backing field, `EditorBrowsable(Never)`, and `Obsolete`
  directing callers to `BandwidthGbps`.
- `ManagedRuleSetRuleGroup.Rules`: getter-only `BicepList<string>` with its own
  backing field, `EditorBrowsable(Never)`, and `Obsolete` directing callers to
  the generated `BicepList<int> RuleIds`.

Both legacy properties remain functional Bicep inputs, as explicitly requested.
They do not parse strings or forward to the numeric properties. Bandwidth is
registered on its nested properties model so emitting a legacy value does not
discard sibling properties. Rules retains the `rules` path. Setting both old
and new forms produces an explicit error during Bicep compilation instead of
silently overwriting one value at their shared path.

**Deferred: simplify the legacy Rules backing field.** The requested direction
is to replace the custom conflict-detecting list with ordinary
`DefineListProperty<string>(nameof(Rules), new string[] { "rules" })`
registration. Callers should populate only `Rules` or `RuleIds`. However,
`ProvisionableConstruct.CompileProperties` resolves duplicate Bicep paths in
property registration order, not modification order: ordinary registration
would let `Rules` win whenever both collections are populated, even when
`RuleIds` was modified last. True last-modified-wins behavior is not provided by
normal registration. This change is deferred pending a decision; the current
conflict-detecting implementation remains unchanged.

The redundant custom `ConnectionMonitorType` enum is deleted. Its generated
replacement retains `MultiEndpoint = 0` and `SingleSourceDestination = 1`, the
same Bicep strings, and the unchanged public monitor property type.

Focused checks cover signatures and attributes, unset defaults, literal and
expression inputs, independent storage, sibling properties, conflict detection
in both assignment orders and through cached property handles, nested rules,
enum values, and the unchanged `2025-05-01` resource API version.

The exact ApiCompat comparison against the previous 105-diagnostic baseline
removes only the `BandwidthInGbps` getter/setter and the string `Rules` getter:
three diagnostics per framework, zero additions. The remaining total is 102 per
framework. Compilation and API export pass on all three targets. Provisioning
changes remain uncommitted for review.

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

Before alignment to `15c9bb43ffc`, `CustomIPPrefix.ParentCustomIPPrefixId` emitted:

```bicep
customIpPrefixParent: '<resource-id>'
```

The service expects this nested object:

```bicep
customIpPrefixParent: {
  id: '<resource-id>'
}
```

The whole-property `alternateType` was removed, retaining the strong type
mapping on the inner `SubResource.id`. The replacement C# `clientName` is
`ParentCustomIPPrefix`, so safe flattening preserves `ParentCustomIPPrefixId`.
The management custom serialization hooks and all Network client `access`
decorators were removed in the same batch.

Provisioning regeneration from `15c9bb43ffc` now registers a
`NetworkSubResource` model at `customIpPrefixParent`; the public flattened
property forwards to its `Id`, rather than registering a scalar at the object
path. No provisioning-only path workaround was added. Compilation and API
export pass, and all 70 ApiCompat diagnostics per framework are unchanged.
The generated structure is corrected; a focused runtime Bicep assertion for
this shape is still pending. ApiCompat does not detect serialization issues.

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

### Connection monitor endpoint naming correction in management

The management spec now names `Microsoft.Network.EndpointType` as
`ConnectionMonitorEndpointType` and `ConnectionMonitorEndpoint.type` as
`EndpointType`. `ConnectionMonitorType` retains its monitor-category name.
Provisioning has now regenerated from this spec commit. The obsolete
`CodeGenType("ConnectionMonitorEndpointType")` mapping on its custom
`ConnectionMonitorType` enum was removed: that mapping compensated for the
previous wrong spec name and would otherwise redirect endpoint properties to the
monitor-category enum.

Provisioning `ConnectionMonitorEndpoint.EndpointType` again uses
`BicepValue<ConnectionMonitorEndpointType>` with both accessors. The previous
migration-only `Type` property and `EndpointType` enum are no longer generated.
All nine released endpoint enum ordinals and Bicep wire strings are unchanged,
as are the monitor-category property type and Network API version `2025-05-01`.
An exact comparison against the previous 107-diagnostic baseline removes only
the endpoint property's getter and setter diagnostics, with zero additions on
every target framework. Build/API export and the focused Bicep checks pass;
the remaining 105 ApiCompat diagnostics are unchanged.

Management `ConnectionMonitorEndpoint.Type` forwards to `EndpointType`. Both
the legacy property and its `EndpointType` struct are hidden with
`EditorBrowsable(Never)` and marked obsolete. The legacy endpoint factory now
forwards its type argument instead of discarding it. Scratch checks cover known
and unknown values, nulls, default struct values, serialization round trips,
endpoint factories, deprecation attributes, and monitor deserialization.

The public backing model accidentally shipped a `ConnectionMonitorEndpointType?`
getter named `ConnectionMonitorType`. Its signature is now preserved as a hidden,
obsolete alias, while `[CodeGenMember("ConnectionMonitorType")]` maps the correctly
typed `MonitorType` property to the unchanged `connectionMonitorType` wire field.
The alias reads the canonical value and has no independent storage or serialization.

Custom `ConnectionMonitorData.ConnectionMonitorType` reads `Properties?.MonitorType`
and retains the original `ConnectionMonitorType?` resource API. Suppressions prevent
automatic flattening of either backing name, so no extra `MonitorType` appears on
the resource and the deprecated backing enum is not exposed there.

All historical monitor factory signatures are retained and forward their type
arguments to the canonical backing constructor. Correctly typed overloads are
additive; the new backing-model overload requires its arguments so parameterless
calls to the historical overload remain unambiguous. Scratch checks exercised all
six monitor factory overloads with both known monitor values, an unknown value,
and null, as well as the backing alias and unchanged wire field. API compatibility
passes without new suppressions on all three frameworks.

The spec now generates `AzureVm`, `AzureArcVm`, and `AzureVmss` with the original
.NET casing. Uppercase `AzureVM`, `AzureArcVM`, and `AzureVMSS` remain hidden,
obsolete aliases that forward to those generated values. The service strings are
unchanged. The two historical monitor-category values on the endpoint enum remain
for compatibility. Detailed comments explain these customizations in the SDK.

Changelog finalization and release validation remain pending.
