# Azure.Provisioning.Network Migration Status

## Current inputs and validation

The package is **not release-ready**.

- SDK PR: [#63070](https://github.com/Azure/azure-sdk-for-net/pull/63070).
- Spec PR: [Azure/azure-rest-api-specs#46412](https://github.com/Azure/azure-rest-api-specs/pull/46412).
- Both packages pin spec commit `10cc3507fbf3e21725a786942eb9b52fcbdda8ac`. The completed baseline includes the provisioning Name/TLS batch and management TLS/Pfs validation.
- Provisioning emitter: `@azure-typespec/http-client-csharp-provisioning@1.0.0-alpha.20260916.3`; TypeSpec compiler: `1.15.0`.
- Provisioning API versions remain Network `2025-05-01` and Compute `2018-10-01`.
- Compatibility baselines: provisioning `1.1.0`; management `1.17.0`.
- Management TLS/Pfs corrections are published through `f45f23cb499`; provisioning TLS, Pfs, ID-setter, and Name-setter corrections are published through `257dbee6ff8`.
- Current batch: 15 usage-gated provisioning setters are restored; regeneration, compilation, and API export succeeded, and ApiCompat confirms all 15 missing setters are resolved without new diagnostics. All six existing `BasicNetworkTests` pass on `net10.0`; no tests were added. Management's disconnected `ContainerNetworkInterface.ContainerId` customization was removed separately at the user's request; regeneration succeeded in 30m08s and restored a generated getter forwarding through `Properties.ContainerId`. Compilation and API export pass, but management ApiCompat now reports the removed setter on each framework.

| Area | Latest result |
|---|---|
| Provisioning generation | Latest usage-setter batch succeeded via `dotnet build /t:GenerateCode` at `10cc3507fbf` in 8m18s. |
| Provisioning compilation | Succeeds before the ApiCompat gate on `netstandard2.0`, `net8.0`, and `net10.0`. |
| Provisioning API export | Export build and API-listing normalization succeeded for all three targets at the current pin. |
| Provisioning ApiCompat | **4 diagnostics per framework**, all `CP0002`: 15 removed, zero added compared with the previous 19-diagnostic Name/TLS batch. Only the deliberately deferred setter and three wrapper accessors remain. |
| Provisioning existing tests | All six `BasicNetworkTests` pass on `net10.0`. These are existing scenario tests, not dedicated coverage of every restored setter. No tests were added or modified. |
| Management TLS/Pfs validation | Before the ContainerId customization removal, build, API export, and ApiCompat against 1.17.0 passed on all three targets. Runtime checks confirmed all four TLS aliases and the Pfs alias retain wire values and equality; only aliases are hidden and obsolete. |
| Management ContainerId removal | Generation, compilation, and API export pass on all three targets. ApiCompat reports exactly one `CP0002` per framework: missing `ContainerNetworkInterface.ContainerId.set` against 1.17.0. No other management compatibility diagnostics are present. |
| Management Pfs correction | Regeneration succeeded on the single-node retry after MSB4166. Generated `Pfs` uses the original `"PFSMM"` wire value; custom `PFSMM` forwards to it. Committed and pushed in `f45f23cb499`. |

The earlier TLS naming regression is resolved by `Custom/EnumValueCustomizations.cs`:
`TLSv13` is restored with EBN, ordinal `3`, and wire name `TLSv1_3`; canonical
`Tls1_3` is also explicitly pinned to `3` so reserving the alias cannot shift it.
Neither member is obsolete. Runtime checks verify both names serialize as
`TLSv1_3`, and only `TLSv13` is hidden.

## Remaining API compatibility issues

Counts reflect the comparison at `10cc3507fbf` after the usage-setter batch and are
deduplicated per framework, not summed across the three targets.
No `CP0001` (removed type) or `CP0011` (changed enum ordinal) diagnostics remain.

| Category | Diagnostics | Affected members |
|---|---:|---:|
| Missing enum members | 0 | 0 fields |
| Properties losing setters | 1 | 1 property |
| Missing wrapper-property accessors | 3 | 2 properties |
| **Total** | **4** | **3** |

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

Only `RouteResource.HasBgpOverride` retains its getter but lacks its released public setter.
The wrapper setter above is not included in this count. This inventory does not
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
| `RouteResource` | `HasBgpOverride` | 1 |
| **Total** | | **1** |

### Enclosing-type settability investigation

All findings below use the pinned TypeSpec source and saved provisioning
`tspCodeModel.json`, not assumptions based on management's public signatures.
The enclosing ARM resources are deployable: their properties models have
`isSettable: true`. Read-only collection/reference edges make these five nested
models, and their properties models, `isSettable: false`:

| Nested provisioning model | Read-only incoming TypeSpec path | Spec source |
|---|---|---|
| `ContainerNetworkInterface` | `NetworkProfile.properties.containerNetworkInterfaces[]` | `Network/models.tsp`, `NetworkProfilePropertiesFormat.containerNetworkInterfaces`, line 16243 |
| `NetworkIPConfiguration` (`Common.IPConfiguration`) | `Subnet.properties.ipConfigurations[]` and `PublicIPAddress.properties.ipConfiguration` | `Common/main.tsp`, lines 1181 and 1393 |
| `ResourceNavigationLink` | `Subnet.properties.resourceNavigationLinks[]` | `Common/main.tsp`, line 1200 |
| `ServiceAssociationLink` | `Subnet.properties.serviceAssociationLinks[]` | `Common/main.tsp`, line 1206 |
| `VirtualNetworkApplianceIPConfiguration` | `VirtualNetworkAppliance.properties.ipConfigurations[]` | `Network/models.tsp`, line 28083 |

Each edge has `@visibility(Lifecycle.Read)`. The emitter's
`collectReachableTypes` propagates `isSettable && !property.readOnly`; the
generator's `ProvisioningModelProvider` emits setters only when
`!property.IsReadOnly && _hasSettableUsage`. No writable incoming path exists
for these five models in the saved graph. This is an enclosing-usage restriction,
not a read-only declaration on the 15 leaf properties listed below.

| Public provisioning property | TypeSpec leaf / Bicep path relative to the nested model | Finding and customization |
|---|---|---|
| `ContainerNetworkInterface.ContainerId` | `properties.container.id`; `Container extends Common.SubResource` | Both `container` and inherited `id` are writable. Restore the 1.1.0 setter by assigning the registered nested ID value. |
| `NetworkIPConfiguration.PrivateIPAddress` | `properties.privateIPAddress` | Writable leaf; restore setter through the existing Bicep value. |
| `NetworkIPConfiguration.PrivateIPAllocationMethod` | `properties.privateIPAllocationMethod` | Writable leaf; restore setter through the existing Bicep value. |
| `NetworkIPConfiguration.PublicIPAddress` | `properties.publicIPAddress` | Writable model reference; restore assignment through `AssignOrReplace` on the registered inner field. |
| `NetworkIPConfiguration.Subnet` | `properties.subnet` | Writable model reference; restore assignment through `AssignOrReplace` on the registered inner field. |
| `ResourceNavigationLink.Link` | `properties.link` | Writable leaf; restore setter through the existing Bicep value. |
| `ResourceNavigationLink.LinkedResourceType` | `properties.linkedResourceType` | Writable leaf; restore setter through the existing Bicep value. |
| `ServiceAssociationLink.AllowDelete` | `properties.allowDelete` | Writable leaf; restore setter through the existing Bicep value. |
| `ServiceAssociationLink.Link` | `properties.link` | Writable leaf; restore setter through the existing Bicep value. |
| `ServiceAssociationLink.LinkedResourceType` | `properties.linkedResourceType` | Writable leaf; restore setter through the existing Bicep value. |
| `ServiceAssociationLink.Locations` | `properties.locations` | Writable collection; restore assignment using the registered list's `Assign`, retaining literal and expression support. |
| `VirtualNetworkApplianceIPConfiguration.Primary` | `properties.primary` | Writable leaf; restore setter through the existing Bicep value. |
| `VirtualNetworkApplianceIPConfiguration.PrivateIPAddress` | `properties.privateIPAddress` | Writable leaf; restore setter through the existing Bicep value. |
| `VirtualNetworkApplianceIPConfiguration.PrivateIPAddressVersion` | `properties.privateIPAddressVersion` | Writable leaf; restore setter through the existing Bicep value. |
| `VirtualNetworkApplianceIPConfiguration.PrivateIPAllocationMethod` | `properties.privateIPAllocationMethod` | Writable leaf; restore setter through the existing Bicep value. |
| `RouteResource.HasBgpOverride` | `properties.hasBgpOverride` | **Not usage-gated**: `Common.RoutePropertiesFormat` is settable, but this leaf explicitly has `@visibility(Lifecycle.Read)` (`Common/main.tsp`, line 3983). Its registration is `isOutput: true`. Leave unchanged pending a separate compatibility decision. |
| `LoadBalancerInboundNatPool.Properties` | `properties` | **Not usage-gated**: TypeSpec retains a writable wrapper (`Common/main.tsp`, line 3536). Generated provisioning has internal get/set; flattening removes public visibility, accounting for two missing accessors. Leave unchanged. |
| `LoadBalancingRule.Properties` | `properties` | **Not usage-gated**: writable wrapper in `Common/LoadBalancingRule.tsp`. Generated provisioning has internal get/set; released provisioning exposed a public getter, accounting for one missing accessor. Leave unchanged. |

Leaf declarations are in `Common/main.tsp` (`IPConfigurationPropertiesFormat`,
`ResourceNavigationLinkFormat`, `ServiceAssociationLinkPropertiesFormat`,
`SubResource`) and `Network/models.tsp`
(`ContainerNetworkInterfacePropertiesFormat`, `Container`,
`VirtualNetworkApplianceIpConfigurationProperties`).

The customizations preserve the released 1.1.0 assignment APIs without changing
TypeSpec visibility or making the enclosing service collections writable.
Each type-specific custom file explains the read-only incoming path and
compatibility reason. Getters and setters share the generated, registered
properties model; no disconnected storage or duplicate Bicep-path registration
is introduced. Two internal helpers in `Custom/Models/IPConfigurationPropertiesFormat.cs`
allow resource-model replacement while retaining the registered field and path.
No new unit tests are added.

### Management disconnected-property follow-up

The management audit identified custom public members using storage separate
from the `Properties` object read/written by generated serializers. ApiCompat
does not detect that disconnected behavior. The completed generation batch
replaced the usage-only cases; the explicitly read-only route property remains
deferred. Do not copy the disconnected-storage pattern into provisioning.

All file paths below are relative to
`sdk/network/Azure.ResourceManager.Network/src/Customization/`.

| Management type and audited members | Removed customization file (unless noted) | Current status |
|---|---|---|
| `ResourceNavigationLink`: `Link`, `LinkedResourceType` | `Models/ResourceNavigationLink.MissingSetterCompatibility.cs` | Resolved: generated accessors use `Properties.Link` and `Properties.LinkedResourceType`. |
| `ServiceAssociationLink`: `AllowDelete`, `Link`, `LinkedResourceType` | `Models/ServiceAssociationLink.MissingSetterCompatibility.cs` | Resolved: generated accessors use matching fields in `Properties`. |
| `ServiceAssociationLink.Locations` | `ServiceAssociationLink.RemainingMemberCompatibility.cs` | Resolved: generated getter initializes `Properties` and returns its connected `IList<AzureLocation>`. |
| `VirtualNetworkApplianceIPConfiguration`: `Primary`, `PrivateIPAddress`, `PrivateIPAddressVersion`, `PrivateIPAllocationMethod` | `Models/VirtualNetworkApplianceIPConfiguration.MissingSetterCompatibility.cs` | Resolved: generated accessors use matching fields in `Properties`. |
| `RouteData.HasBgpOverride` | `RouteData.MissingSetterCompatibility.cs` (retained) | Deferred: the custom auto-property is disconnected. The generated leaf is explicitly read-only and omitted in wire-write mode, so its setter requires a separate semantic decision. |

Of these **11 management members**, ten are now generated and connected; only
`RouteData.HasBgpOverride` remains deferred. Separately,
`ContainerNetworkInterface.ContainerId` now has a connected generated getter
and setter at `properties.container.id`. The earlier missing-setter CP0002 is
resolved without restoring its disconnected customization or suppressing the
diagnostic. The four `NetworkIPConfiguration` members were resolved as well.

`LoadBalancerInboundNatPool.Properties` and `LoadBalancingRuleData.Properties`
are **not disconnected**: their custom backing fields are accessed by the same
`Properties` property that generated constructors assign and serializers write.
Their provisioning issues are public-wrapper visibility, not the disconnected
scalar/member pattern above. The separate additional-properties limitation
remains documented below.

### Generated management IP configuration setter correction

The four disconnected `NetworkIPConfiguration` properties were removed from
`Models/NetworkIPConfiguration.MissingSetterCompatibility.cs`. The correction
applies usage to the outer model, not a redundant inner-model override:

```typespec
@@usage(
  Common.IPConfiguration,
  Azure.ClientGenerator.Core.Usage.input | Azure.ClientGenerator.Core.Usage.output,
  "csharp"
);
```

Applying usage only to `IPConfigurationPropertiesFormat` restored inner setters
but left `NetworkIPConfiguration.Properties` getter-only. The flattening
generator requires both wrapper and leaf setters, so all four public setters
were still missing. Moving the override to `Common.IPConfiguration` propagates
input usage to its properties model and restores both levels.

The initial local regeneration succeeded in 14m22s. All four public properties now
have generated getters and setters connected to the same `Properties` object
that serialization uses. Each setter initializes that object when null, so the
parameterless constructor works without independent backing storage.
The follow-up batch also removed its custom constructor; public
`NetworkIPConfiguration()` is now generated. `ProvisioningState` remains
getter-only, and the four setter signatures are unchanged. Full pinned-source
validation results are recorded below.

This correction is now published in spec commit
`fe3bb76076cccb801f23f2cf2c53aba30a13e06d`, pinned by the management package.
Provisioning was not regenerated and retains its earlier `10cc3507fbf` pin.

### Batched management usage correction (completed)

The follow-up audit covers custom constructors, missing-setter compatibility
files, and related collection declarations. Confirmed cases were applied
together, including removal of the custom `NetworkIPConfiguration()` constructor.
The batch uses C# input/output usage on outer models, allowing usage to propagate
to their properties and writable child models. No HTTP operation or explicit
`@visibility(Lifecycle.Read)` is changed.

| Confirmed model graph | Correction included in the batch |
|---|---|
| `Common.IPConfiguration`, `Common.ResourceNavigationLink`, `Common.ServiceAssociationLink` | Generate public constructors and connected writable leaves; replace the separate `ServiceAssociationLink.Locations` list with generated storage. |
| `ContainerNetworkInterface`, `VirtualNetworkApplianceIpConfiguration` | Generate constructors and setters for writable leaves, including `ContainerId`; preserve explicitly read-only state and related-resource collections. |
| `BgpServiceCommunity` / `BGPCommunity` | Generate constructors and writable service/community fields through parent input usage. |
| `ExpressRouteServiceProvider` / `ExpressRouteServiceProviderBandwidthsOffered` | Generate constructors and offered-bandwidth fields; preserve read-only provisioning state. |
| `ApplicationGatewayFirewallRuleSet` / rule groups / rules | Generated writable fields and preserved `RuleSet()`, `RuleGroup(string, IEnumerable<Rule>)`, and `Rule(int)` signatures. The group constructor initializes the required rules collection. |
| `ApplicationGatewaySslPredefinedPolicy` | Generate constructor and connected `MinProtocolVersion`; retain the separate `ResourceType` compatibility alias. |
| `PeerExpressRouteCircuitConnection`, `ExpressRouteProviderPort` | Generated writable connection/port leaves. Retained `ExpressRouteProviderPortData(AzureLocation)` alongside the generated parameterless constructor. |
| `VirtualNetworkGatewayConnectionListEntity` | Generated its fourteen writable leaves. Retained the `WritableSubResource localNetworkGateway2` overload and updated its delegation to the generated all-properties constructor; it differs from the generated required gateway-reference overload. |
| `ApplicationGatewayPrivateLinkResource`, `AzureFirewallFqdnTag`, `ExpressRoutePortsLocation` / bandwidths, `NetworkVirtualApplianceSku` / instances | Generate matching public constructors without making explicitly read-only service values writable. |
| `PrivateEndpointIPConfiguration.PrivateIPAddress`, `BackendAddressPoolData.Location` | Removed redundant outer compatibility properties without adding usage overrides; generated accessors now forward to the existing correctly typed writable inner properties. |

These are **not equivalent usage-only cases** and remain outside this batch:

- `RouteData.HasBgpOverride`, the provisioning-state compatibility setters on
  `IpamPoolProperties`, `StaticCidrProperties`,
  `ReachabilityAnalysisIntentProperties`, `ReachabilityAnalysisRunProperties`,
  and `NetworkVerifierWorkspaceProperties`, and
  `NetworkSecurityPerimeterLinkReferenceData.Status`: the service properties
  are explicitly read-only. Adding input usage is not a visibility override.
- Protected parameterless constructors on abstract discriminator models are a
  different compatibility concern. For example, `FirewallPolicyRule` already
  has generated input setters, but its generated discriminator constructor is
  `private protected FirewallPolicyRule(FirewallPolicyRuleType)`.
- `FlowLogProperties()` preserves an extra parameterless overload; the model
  already has a generated public constructor requiring `storageId` and
  `enabled`. Input usage cannot remove those required arguments.
- Existing renamed-property aliases, replacement types, and public wrapper
  visibility customizations are not automatically redundant merely because a
  custom property has a setter. For example, the deprecated
  `NetworkVirtualApplianceConnectionData.ConnectionRoutingConfiguration`
  alias requires a separate forwarding/type-compatibility decision.

After the customization MCP timed out, the user authorized direct source edits.
The batch removed 35 custom files in addition to the earlier IP configuration
setter file, and added 15 C# usage overrides alongside the existing override.
Generated files were produced only by `dotnet build /t:GenerateCode`.

The spec changes were committed and pushed as
`fe3bb76076cccb801f23f2cf2c53aba30a13e06d`; the management pin was updated
before regenerating from that remote commit without `LocalSpecRepo`.
Pinned generation completed in 16m14s; all 3,684 generated files matched the
validated local trial. Release build and ApiCompat against 1.17.0 passed on
netstandard2.0, net8.0, and net10.0 with zero warnings/errors. API export passed
on all three targets; normalized listings matched the local trial.

Compared with the previously committed SDK surface, public changes are additive:
`ExpressRouteProviderPortData()`, `Container()`, the gateway connection
constructor accepting `(VirtualNetworkGatewayConnectionType, ResourceIdentifier)`,
and setters for `ContainerId`, firewall-rule `ParanoiaLevel`, rule-set
`DisplayName`, and gateway-connection `RoutingConfiguration`. There are no
`IReadOnlyList`/`IList` signature changes. Explicitly read-only leaves remain
read-only. No new unit tests were added. Provisioning
generation and its pin remain unchanged.

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
| TLS names | Provisioning generates `Tls1_0` through `Tls1_3` with ordinals 0-3 and unchanged wire strings, plus the hidden `TLSv13 = 3` compatibility alias without Obsolete. Management retains all four uppercase aliases as EBN + Obsolete in a dedicated custom file; TLS validation passes. |
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
