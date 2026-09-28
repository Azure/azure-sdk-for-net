# Azure.Provisioning.Network Migration Status

## Current inputs and validation

The package is **not release-ready**.

- SDK PR: [#63070](https://github.com/Azure/azure-sdk-for-net/pull/63070).
- Spec PR: [Azure/azure-rest-api-specs#46412](https://github.com/Azure/azure-rest-api-specs/pull/46412).
- Both packages pin spec commit `10cc3507fbf3e21725a786942eb9b52fcbdda8ac`. Both regenerations succeeded, including the provisioning Name/TLS batch; management validation passed.
- Provisioning emitter: `@azure-typespec/http-client-csharp-provisioning@1.0.0-alpha.20260916.3`; TypeSpec compiler: `1.15.0`.
- Provisioning API versions remain Network `2025-05-01` and Compute `2018-10-01`.
- Compatibility baselines: provisioning `1.1.0`; management `1.17.0`.
- Management TLS/Pfs corrections are published through `f45f23cb499`. This provisioning batch adds TLS, Pfs, ID-setter, and Name-setter compatibility changes on top of `e081ebd62d9`.

| Area | Latest result |
|---|---|
| Provisioning generation | Succeeded via `dotnet build /t:GenerateCode` at `10cc3507fbf` in 13m39s, including 26 ID setters, nine Name setters, and the TLSv13 alias. |
| Provisioning compilation | Succeeds before the ApiCompat gate on `netstandard2.0`, `net8.0`, and `net10.0`. |
| Provisioning API export | Export build and API-listing normalization succeeded for all three targets at the current pin. |
| Provisioning ApiCompat | **19 diagnostics per framework**, all `CP0002`: ten removed (nine Name setters and `TLSv13`), zero added compared with the previous 29-diagnostic ID-setter batch. |
| Management TLS/Pfs validation | At `10cc3507fbf`, build, API export, and ApiCompat against 1.17.0 pass on all three targets. Runtime checks confirm all four TLS aliases and the Pfs alias retain wire values and equality; only aliases are hidden and obsolete. |
| Management Pfs correction | Regeneration succeeded on the single-node retry after MSB4166. Generated `Pfs` uses the original `"PFSMM"` wire value; custom `PFSMM` forwards to it. Committed and pushed in `f45f23cb499`. |

The earlier TLS naming regression is resolved by `Custom/EnumValueCustomizations.cs`:
`TLSv13` is restored with EBN, ordinal `3`, and wire name `TLSv1_3`; canonical
`Tls1_3` is also explicitly pinned to `3` so reserving the alias cannot shift it.
Neither member is obsolete. Runtime checks verify both names serialize as
`TLSv1_3`, and only `TLSv13` is hidden.

## Remaining API compatibility issues

Counts reflect the comparison at `10cc3507fbf` after the Name/TLS batch and are
deduplicated per framework, not summed across the three targets.
No `CP0001` (removed type) or `CP0011` (changed enum ordinal) diagnostics remain.

| Category | Diagnostics | Affected members |
|---|---:|---:|
| Missing enum members | 0 | 0 fields |
| Properties losing setters | 16 | 16 properties |
| Missing wrapper-property accessors | 3 | 2 properties |
| **Total** | **19** | **18** |

### Enum compatibility

No missing enum members or changed enum ordinals remain in provisioning.

`PfsGroup` has a confirmed management wire-value regression from the original
TypeSpec migration, commit `d9545d39976` (#59847). Immediately before that
commit, generated `Pfs` used `"PFSMM"`, matching released provisioning.
The migration replaced it with a custom `Pfs` constructing `"PFS"` while
generating `PFSMM` for `"PFSMM"`. The incorrect customization persists in
management 1.17.0 and currently has neither EBN nor Obsolete. Restoring the
pre-migration behavior requires `"PFSMM"`, not `"PFS"`; ApiCompat does not
detect this string-value regression.

The fix is validated and published in management: exact C# `clientName` maps TypeSpec
`PFSMM` to generated `Pfs`, and dedicated custom file `PfsGroup.cs` retains
`PFSMM` as an EBN + Obsolete forwarding alias. The incorrect custom `"PFS"`
construction is removed. Management generation and validation succeeded;
provisioning regeneration at the same commit has restored `Pfs = 8` with wire
value `PFSMM`, removing its missing-member diagnostic.

### Missing wrapper-property accessors

| Property | Missing accessors | Diagnostics |
|---|---|---:|
| `LoadBalancerInboundNatPool.Properties` | Getter and setter | 2 |
| `LoadBalancingRule.Properties` | Getter | 1 |

### Properties losing setters

Each property below retains its getter but lacks its released public setter.
The wrapper setter above is not included in these 16. This inventory does not
imply that service output-only properties should become writable.

All 26 previously missing `Id` setters now have validated package-level
customizations. The generator unconditionally treats resource `id`
as output-only, although released Network types support writable IDs for input
and reference usages; see [#63430](https://github.com/Azure/azure-sdk-for-net/issues/63430).
Each workaround restores both the setter and writable registration at the original
`id` Bicep path, with a justification and issue link in its type-specific custom
file. Adding a setter alone would still throw when assigning an output-only value.
Other setters and genuinely output-only IDs are unchanged. All 26 corresponding
ApiCompat diagnostics are eliminated on all three target frameworks.

All nine previously missing `Name` setters now have regenerated and validated
customizations. For `ContainerNetworkInterface`, `NetworkIPConfiguration`,
`ResourceNavigationLink`, `ServiceAssociationLink`, and
`VirtualNetworkApplianceIPConfiguration`, TypeSpec does not mark `name` read-only
and management exposes a setter; provisioning's model-level writable-usage gate
removed it. Their customizations restore the released setter and `name` path.
The other four (`FirewallPolicyDraft`, `FirewallPolicyRuleCollectionGroupDraft`,
`PolicySignaturesOverridesForIdps`, and `VpnLinkConnectionSharedKey`) are singleton
resources: their customizations retain the required `"default"` value while
restoring the released assignment API, including Bicep expressions. This does
not imply the service accepts arbitrary singleton names. Each custom file
documents the reason. All nine corresponding ApiCompat diagnostics are eliminated
on all three targets.

| Declaring type | Properties losing setters | Count |
|---|---|---:|
| `ContainerNetworkInterface` | `ContainerId` | 1 |
| `NetworkIPConfiguration` | `PrivateIPAddress`, `PrivateIPAllocationMethod`, `PublicIPAddress`, `Subnet` | 4 |
| `ResourceNavigationLink` | `Link`, `LinkedResourceType` | 2 |
| `RouteResource` | `HasBgpOverride` | 1 |
| `ServiceAssociationLink` | `AllowDelete`, `Link`, `LinkedResourceType`, `Locations` | 4 |
| `VirtualNetworkApplianceIPConfiguration` | `Primary`, `PrivateIPAddress`, `PrivateIPAddressVersion`, `PrivateIPAllocationMethod` | 4 |
| **Total** | | **16** |

## Other outstanding issues and deferred decisions

### API-version and property-type mismatch

The Network API-version bump from `2025-05-01` is deferred; the target version
requires confirmation. Swagger and TypeSpec place the `rules` change from
`string[]` to `int32[]` in `2026-01-01`, and `bandwidthInGbps` from `string` to
`float64` in `2025-07-01`. Saved provisioning code-model inputs nevertheless
already contain these numeric types with `2025-05-01` configured. The mismatch
precedes C# generation; its cause in version selection or the code-model
pipeline is not established.

Generated `RuleIds` and `BandwidthGbps` remain numeric. Legacy `Rules` and
`BandwidthInGbps` have independent string storage and emit their original
wire paths without conversion. These compatibility APIs do not resolve the
version-selection issue.

### Deferred simplification of Rules

The requested direction is ordinary
`DefineListProperty<string>(nameof(Rules), new string[] { "rules" })`
registration instead of the custom conflict-detecting list. Callers should
populate only `Rules` or `RuleIds`. Normal compilation resolves duplicate
paths in registration order, not modification order: `Rules` would win if
both are populated, even if `RuleIds` was modified last.

This decision is deferred. The current implementation still throws when both
old and new forms are populated. The analogous bandwidth conflict guard also
remains. No last-modified-wins behavior is implemented.

### Additional-properties support

[Issue #60666](https://github.com/Azure/azure-sdk-for-net/issues/60666) tracks
generator support. The restored
`LoadBalancerInboundNatPoolProperties.AdditionalProperties` and
`LoadBalancingRuleProperties.AdditionalProperties` are compatibility-only
`BicepDictionary<BinaryData>` auto-properties: neither literals nor expressions
are emitted to Bicep. They are not registered at a wire path.

### Parent-prefix Bicep shape: runtime verification pending

The incorrect whole-object `alternateType` and management serialization hooks
were removed. Safe flattening now retains `ParentCustomIPPrefixId` using the
client name `ParentCustomIPPrefix` and an inner strongly typed `SubResource.id`.
Provisioning registers a nested `NetworkSubResource`, not a scalar at
`customIpPrefixParent`. The intended shape is:

```bicep
customIpPrefixParent: {
  id: '<resource-id>'
}
```

Generated structure is corrected; a focused runtime Bicep assertion remains
pending. No provisioning-only path workaround was added.

### Safe-flatten naming workaround

[Issue #60921](https://github.com/Azure/azure-sdk-for-net/issues/60921) tracks
boolean naming with `BicepValue<bool>`. Local `CodeGenMember` workarounds expose
`VirtualApplianceIPConfiguration.IsPrimary` and
`ConnectionMonitorTestConfiguration.DisableTraceRoute` without hiding or
deprecating them. The shared generator issue remains open.

### Release preparation

Changelog finalization and release validation remain pending.

## Retained compatibility decisions

This section records current behavior, not additional unresolved diagnostics.

| Area | Applied behavior |
|---|---|
| Cipher-suite names | All 28 provisioning names, ordinals, and wire strings match 1.1.0. Twelve ECDHE names are restored through exact `clientName`; management preserves uppercase aliases as EBN + Obsolete in a dedicated custom file. |
| TLS names | Provisioning now generates `Tls1_0` through `Tls1_3` with ordinals 0-3 and unchanged wire strings. The first three missing-member diagnostics are resolved; the missing released `TLSv13` name is tracked above. Management retains all four uppercase aliases as EBN + Obsolete in a dedicated custom file; build and ApiCompat pass. |
| Enum ordinals | Eleven `CodeGenEnumValue` attributes restore all 24 ordinal diagnostics and eight absent names across six enums, retaining wire strings and reserving slots rather than pinning every member. |
| Managed identity | A shared model-level `alternateType` restores `FlowLog.Identity` to `ManagedServiceIdentity` with both accessors. Redundant internal identity types are removed. |
| Strong property types | All 26 affected properties regain strong types (`ResourceIdentifier`, `ResourceType`, `AzureLocation`, `Guid`, `IPAddress`, `Uri`, `BinaryData`). Three `BinaryData` fields use TypeSpec `unknown`, not base64 encoding. |
| Management strong types | Seven internal property types changed; six factory overloads were added while retaining old signatures. This was intentionally not a no-op generated-code diff. |
| Resource-reference collections | Fifteen collection changes are restored through `CodeGenMember`, retaining setters, output behavior, and object-shaped ID references. |
| Resource type aliases | Thirty-five hidden, obsolete getter-only aliases forward to generated `Type`. Twelve additional output-only `ResourceType` properties and `DdosProtectionPlan.SystemData` retain backing fields and original paths with EBN but no Obsolete. |
| Child custom prefixes | `ChildCustomIPPrefixList` retains its own output-only backing field as a hidden, obsolete `BicepList<WritableSubResource>`; generated `ChildCustomIPPrefixes` remains preferred. |
| Legacy rules and bandwidth | Provisioning's independent string properties are functional Bicep inputs with EBN + Obsolete. Management's legacy rules list preserves arbitrary strings supplied to its factory without serializing them; numeric `RuleIds` is canonical. Management bandwidth converts the old string API to the numeric value using invariant culture and rejects invalid input. |
| Endpoint and monitor types | `ConnectionMonitorEndpoint.EndpointType` is restored with both accessors and the correct nine-value enum. Monitor-category `ConnectionMonitorType` remains distinct; its redundant custom enum was removed. |
| Management monitor compatibility | Deprecated endpoint/backing aliases and historical factories retain signatures and forward values. Canonical `MonitorType` controls serialization. Correctly cased `AzureVm`, `AzureArcVm`, and `AzureVmss` are generated; uppercase aliases are hidden and obsolete. |
| Preferred properties | Prefer `ConfigurationPolicyGroups` and `RoutingConfiguration`; legacy aliases forward to them. Accepted exceptions retain `StartsOn`, `ExpressRouteConnections`, and separate `*Resources` collections on the four previously reviewed types. |

Restored enum names from the ordinal batch: `HttpStatus499`;
`Basic`, `Standard`, `Advanced`; `Drain`; `None` on
`ManagedRuleSensitivityType`; `Aad`; and `Sha384`. No ordinal diagnostics
remain. Existing migration decisions must not be discarded when addressing
the outstanding setters or wrapper properties.
