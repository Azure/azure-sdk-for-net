# Investigation: back-compat scenarios that could be automated through generated code

Tracks [#61063](https://github.com/Azure/azure-sdk-for-net/issues/61063).

## Purpose

When an existing library — **management-plane** (`Azure.ResourceManager.*`) or **data-plane**
(`Azure.*` client libraries) — is migrated from AutoRest/Swagger generation to TypeSpec
generation, the newly generated public API surface almost never matches the previously shipped
surface exactly. To avoid breaking changes, migration authors hand-write compatibility code
under each package's `src/Custom/` folder.

This document is an investigation of that hand-written back-compat code across **both planes**.
It catalogs the recurring **scenarios**, and for each one records whether the generator could
produce the same code automatically. Scenarios that the generator *can* automate are documented
here as **valid cases** — candidates for a generator feature or TypeSpec customization so that
future migrations do not need to hand-write them.

The taxonomy in [Scenarios](#scenarios) was built from the management-plane survey; the
[Data-plane libraries](#data-plane-libraries) section then cross-checks the same scenarios
against data-plane custom code and records the data-plane–specific automation gaps.

## Scope and method

- **In scope:** hand-written back-compat code under `sdk/**/src/Custom/` in TypeSpec-migrated
  libraries (those that already have a `tsp-location.yaml`):
  - **Management plane** — `Azure.ResourceManager.*`; 84 such packages surveyed. This is the
    primary source for the scenario taxonomy below.
  - **Data plane** — `Azure.*` client libraries; 14 such packages surveyed. Covered in the
    [Data-plane libraries](#data-plane-libraries) section.
- **Out of scope:** generated code under `Generated/`, non-migrated libraries, and provisioning
  libraries (`Azure.Provisioning.*`). Provisioning has its own compatibility tracking, e.g.
  enum shims in [#60442](https://github.com/Azure/azure-sdk-for-net/issues/60442).
- **Method:** every distinct *kind* of hand-written customization under `src/Custom/` was
  identified and, for each, we assessed whether it is deterministic enough to be emitted by
  the generator (given information the generator already has, or given the previous public API
  contract that CI already tracks for breaking-change detection). The management-plane
  (`Azure.Generator.Management`) and data-plane (`Azure.Generator`) generators share the same
  underlying `Microsoft.TypeSpec.Generator` customization primitives (`[CodeGenType]`,
  `[CodeGenMember]`, `[CodeGenSuppress]`, `[CodeGenSerialization]`), so the same scenarios
  recur in both planes.

The customization mechanisms observed are: `[CodeGenType]`, `[CodeGenMember]`,
`[CodeGenSuppress]` / `[assembly: CodeGenSuppressType]`, `[CodeGenSerialization]`,
`[WirePath]`, restored base types (`: ResourceData`), `[Obsolete]` +
`[EditorBrowsable(Never)]` shims, custom property getters/setters, custom constructors,
model-factory overloads, and hand-written enum / extensible-enum types.

## What the generator already automates today

Several back-compat behaviors are *already* produced by the **management** generator, so the
categories below focus on what still requires hand-written custom code. Existing automation
for reference:

- **Known-type renaming** (`Sku`, `PrivateEndpointConnection`, `PrivateLinkResource`, …) —
  `generator/Azure.Generator.Management/src/Visitors/NameVisitor.cs`.
- **Model factory backward-compat overloads** —
  `generator/Azure.Generator.Management/src/Visitors/ModelFactoryVisitor.cs` and
  `ModelFactoryBackwardCompatHelper.cs`.
- **Base-type / inheritance restoration plumbing** —
  `generator/Azure.Generator.Management/src/Visitors/InheritableSystemObjectModelVisitor.cs`.
- **Property flattening** —
  `generator/Azure.Generator.Management/src/Visitors/FlattenPropertyVisitor.cs`.
- **`CodeGenResourceData` / `CodeGenTagPatchHook` custom attributes** — see
  [custom-code-attributes.md](./custom-code-attributes.md).

The scenarios below name the specific *gaps* where custom code is still required, and whether
each gap is a valid candidate for further automation.

The **data-plane** generator (`Azure.Generator`) automates far less of this today — notably it
has *no* known-type renaming, inheritance-restoration, or model-factory backward-compat
overload emission. It does rename the model factory itself
(`generator/Azure.Generator/src/Visitors/ModelFactoryRenamerVisitor.cs`), which is actually the
*cause* of several data-plane shims rather than a back-compat helper. The
[Data-plane libraries](#data-plane-libraries) section details these gaps.

## Legend

- ✅ **Automatable** — deterministic; the generator could emit this from information it has (or
  from the previous-contract data CI already consumes) without per-library semantic judgement.
- 🟡 **Partially automatable** — the generator could emit the *boilerplate* (attribute,
  suppression, overload skeleton), but a human must still supply mapping/transform intent.
- ❌ **Not automatable** — requires domain/business logic that cannot be inferred.

---

## Scenarios

### 1. Type rename back to the previously shipped name — ✅ Automatable

**What the custom code does:** applies `[CodeGenType("OldGeneratedName")]` to a partial so the
generated type keeps the name the library shipped previously. Extremely common for
discriminator `Unknown*` types and `*UpdateProperties` models whose TypeSpec name differs from
the AutoRest name.

**Citations:**
- `sdk/astronomer/Azure.ResourceManager.Astro/src/Custom/Models/AstroOrganizationUpdateProperties.cs:10` — `[CodeGenType("OrganizationResourceUpdateProperties")]`
- `sdk/cosmosdb/Azure.ResourceManager.CosmosDB/src/Custom/Models/UnknownBackupPolicy.cs:13`
- `sdk/eventhub/Azure.ResourceManager.EventHubs/src/Custom/Models/UnknownApplicationGroupPolicy.cs`
- `sdk/standbypool/Azure.ResourceManager.StandbyPool/src/Custom/Models/StandbyVirtualMachinePoolUpdateProperties.cs:7`

**Automation approach:** the previous public contract (already tracked for breaking-change
detection) provides the old name; a name-mapping step could apply it automatically, extending
the existing `NameVisitor`. This is the single most frequent custom-code pattern in the survey.

### 2. Restore a removed base type (`: ResourceData`, other bases) — ✅ Automatable

**What the custom code does:** re-declares a partial with a base type that TypeSpec generation
dropped (most often `Azure.ResourceManager.Models.ResourceData`, sometimes another model). The
generator strips the inherited `id`/`name`/`type` from the wrapper.

**Citations:**
- `sdk/cosmosdb/Azure.ResourceManager.CosmosDB/src/Custom/Models/RestorableMongoDBDatabase.cs:12` (comment explicitly documents that the generator picks up the base from the partial)
- `sdk/appconfiguration/Azure.ResourceManager.AppConfiguration/src/Custom/Models/AppConfigurationPrivateEndpointConnectionReference.cs:11` (`// add this customization to bring back its base type`)
- `sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Custom/Models/ArcSettings.cs`
- `sdk/sqlmanagement/Azure.ResourceManager.Sql/src/Custom/Models/ManagedInstanceQuery.cs:19`

**Automation approach:** the old contract records the previous base type. Combined with the
existing `InheritableSystemObjectModelVisitor` (whose header notes it is a temporary bridge
until MTG supports inheritable system-model replacement), the base could be re-applied from the
old contract without a hand-written partial.

### 3. Renamed-type "alias" that inherits the new type — ✅ Automatable

**What the custom code does:** for a *renamed resource/collection/resource-data* type, keeps
the old type name as an `[Obsolete]` + `[EditorBrowsable(Never)]` subclass of the new type
(often with interface stubs that throw `NotSupportedException`), so old source still compiles.

**Citations:**
- `sdk/azurestackhci/Azure.ResourceManager.Hci/src/Custom/PublisherCollection.cs:16` — `[Obsolete] public partial class PublisherCollection : HciClusterPublisherCollection`
- `sdk/azurestackhci/Azure.ResourceManager.Hci/src/Custom/UpdateSummaryResource.cs`
- `sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/FrontendResource.cs:27`

**Automation approach:** when the generator renames a type, it can additionally emit the
deprecated alias subclass + forwarding/throwing stubs from a template. The rename source and
Obsolete-message template are the only inputs.

### 4. Renamed property shim (`[Obsolete]` alias forwarding to new name) — ✅ Automatable

**What the custom code does:** adds a property under the old name marked `[Obsolete]` +
`[EditorBrowsable(Never)]` whose getter/setter forwards to the renamed property.

**Citations:**
- `sdk/certificateregistration/Azure.ResourceManager.CertificateRegistration/src/Custom/AppServiceCertificateOrderData.cs:17` — `ProductType` forwards to `CertificateProductType`
- `sdk/artifactsigning/Azure.ResourceManager.ArtifactSigning/src/Custom/ArtifactSigningCertificateProfileData.cs`
- `sdk/lambdatesthyperexecute/Azure.ResourceManager.LambdaTestHyperExecute/src/Custom/LambdaTestHyperExecuteOfferPartnerProperties.cs:14` — `LicensesSubscribed` forwards to `SubscribedLicensesCount`

**Automation approach:** a `@clientName`-style rename that also emits an obsolete forwarding
shim (rather than a hard rename) makes this automatic. Requires only old-name → new-name.
The Obsolete message follows the repo template ("This property is deprecated … Please use XXX
instead").

### 5. Method rename shim / overload forwarding (`[EditorBrowsable(Never)]`) — ✅ Automatable

**What the custom code does:** keeps an old method name or an old parameter arity as a hidden
overload that forwards to the new method (e.g. an overload without `WaitUntil`, or without a
newly added optional parameter, calling the canonical method with a default).

**Citations:**
- `sdk/healthbot/Azure.ResourceManager.HealthBot/src/Custom/HealthBotResource.cs:56` — `Update(patch)` forwards to `Update(WaitUntil.Completed, patch)`
- `sdk/elastic/Azure.ResourceManager.Elastic/src/Custom/ElasticMonitorResource.cs:42`
- `sdk/edgeorder/Azure.ResourceManager.EdgeOrder/src/Custom/EdgeOrderItemCollection.cs:40`
- `sdk/durabletask/Azure.ResourceManager.DurableTask/src/Custom/DurableTaskSchedulerResource.cs:22`

**Automation approach:** deterministic when the new method is a superset of the old signature
(added optional/`WaitUntil` parameter) or a pure rename. The old contract supplies the missing
overloads to synthesize as hidden forwarders.

### 6. Extensible-enum / enum value re-addition — ✅ Automatable

**What the custom code does:** re-declares removed extensible-enum values (`readonly partial
struct` static members) or a legacy hand-written `enum` type marked `[Obsolete]` for values the
service dropped but that shipped previously.

**Citations:**
- `sdk/costmanagement/Azure.ResourceManager.CostManagement/src/Custom/Models/OperationStatusType.cs`
- `sdk/batch/Azure.ResourceManager.Batch/src/Custom/Models/BatchCertificateVisibility.cs:10`
- `sdk/batch/Azure.ResourceManager.Batch/src/Custom/Models/BatchAccountCertificateProvisioningState.cs:12`

**Automation approach:** the old contract lists the removed enum members; re-emitting them
(with the standard extensible-enum boilerplate) is fully mechanical. Cross-references the
provisioning enum work in [#60442](https://github.com/Azure/azure-sdk-for-net/issues/60442).

### 7. Collection initialization in the parameterless constructor — ✅ Automatable

**What the custom code does:** adds a constructor that initializes `ChangeTrackingList` /
`ChangeTrackingDictionary` collection properties that the generator did not initialize.

**Citations:**
- `sdk/appcomplianceautomation/Azure.ResourceManager.AppComplianceAutomation/src/Custom/Models/AppComplianceReportSnapshotProperties.cs:17`

**Automation approach:** standard, non-semantic pattern; the generator can initialize
change-tracking collections in the default constructor.

### 8. Read-only collection / immutable surface preservation — ✅ Automatable

**What the custom code does:** re-exposes a collection or dictionary as `IReadOnlyList<T>` /
`IReadOnlyDictionary<K,V>` where the generator now models it mutably, matching the previously
shipped (read-only) surface.

**Citations:**
- `sdk/batch/Azure.ResourceManager.Batch/src/Custom/BatchAccountData.cs:11` — read-only `Tags`
- `sdk/reservations/Azure.ResourceManager.Reservations/src/Custom/Models/AvailableScopesProperties.cs:15`
- `sdk/support/Azure.ResourceManager.Support/src/Custom/ProblemClassificationData.cs:17`

**Automation approach:** the old contract records the property's declared type; when only the
mutability/collection-interface changed, the generator can preserve the read-only facade.

### 9. `IJsonModel<TData>` forwarding on resources — ✅ Automatable

**What the custom code does:** implements `IJsonModel<FooData>` on `FooResource` by delegating
to the resource's `Data`, restoring the prior ability to serialize a resource as its data type.

**Citations:**
- `sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/FrontendResource.Serialization.cs`
- `sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/src/Custom/AssociationResource.Serialization.cs`

**Automation approach:** a uniform template keyed on the resource → data relationship the
generator already knows; no per-library logic.

### 10. `[assembly: CodeGenSuppressType]` for shared/common types — 🟡 Partially

**What the custom code does:** suppresses generation of a type that is owned by a shared
package (e.g. `SubResource`) to avoid duplicate/conflicting definitions.

**Citations:**
- `sdk/resources/Azure.ResourceManager.Resources/src/Custom/Models/SubResource.cs:11`

**Why not fully automatable:** the generator could suppress types it recognizes as
common-types, but *ownership* (which package provides the canonical type) is a cross-package
decision that needs a curated allowlist.

### 11. `[CodeGenSuppress]` of a specific overload + custom replacement — 🟡 Partially

**What the custom code does:** suppresses one generated method/constructor signature and
supplies a hand-written replacement with the old signature/behavior.

**Citations:**
- `sdk/deviceprovisioningservices/Azure.ResourceManager.DeviceProvisioningServices/src/Custom/DeviceProvisioningServicesPrivateEndpointConnectionResource.cs:19`
- `sdk/sphere/Azure.ResourceManager.Sphere/src/Custom/SphereDeviceGroupCollection.cs:13`
- `sdk/consumption/Azure.ResourceManager.Consumption/src/Custom/ArmConsumptionModelFactory.cs:20`

**Why not fully automatable:** the generator can emit the suppression + a forwarding skeleton
when the change is a pure signature superset, but replacements that change behavior need human
intent. Where the replacement is only "call the new method with defaults," this collapses into
scenario 5 (automatable).

### 12. Property flatten/unflatten wrapper (custom get/set over nested model) — 🟡 Partially

**What the custom code does:** re-exposes a property at the level the old API had it, wrapping a
now-nested (or now-flattened) generated property via custom get/set, sometimes lazily creating
the nested object on set.

**Citations:**
- `sdk/eventhub/Azure.ResourceManager.EventHubs/src/Custom/EventHubsClusterData.cs:31` — `ConfidentialComputeMode` wraps `Properties.PlatformCapabilitiesConfidentialComputeMode`
- `sdk/securitycenter/Azure.ResourceManager.SecurityCenter/src/Custom/Models/DefenderForDatabasesGcpOffering.cs:12`
- `sdk/maps/Azure.ResourceManager.Maps/src/Custom/MapsCreatorPatch.cs:11`

**Why not fully automatable:** the existing `FlattenPropertyVisitor` already automates the
common single-level flatten. The residual custom code handles nullability nuances, lazy
allocation, and multi-hop paths where the exact projection must be specified. A per-property
"flatten path" hint would move most of these to automatable.

### 13. Model-factory overload with parameter adaptation — 🟡 Partially

**What the custom code does:** adds an `ArmXxxModelFactory` overload matching the old parameter
list (fewer params, `int?` vs `int`, `string` vs `ResourceIdentifier`, different order) that
forwards to the generated overload.

**Citations:**
- `sdk/cosmosdb/Azure.ResourceManager.CosmosDB/src/Custom/ArmCosmosDBModelFactory.cs:21`
- `sdk/dnsresolver/Azure.ResourceManager.DnsResolver/src/Custom/ArmDnsResolverModelFactory.cs:28`
- `sdk/netapp/Azure.ResourceManager.NetApp/src/Custom/ArmNetAppModelFactory.cs:31`

**Why not fully automatable:** `ModelFactoryVisitor` + `ModelFactoryBackwardCompatHelper`
already synthesize additive/nullability overloads from the last contract. Remaining custom code
covers non-trivial type coercions (`string` ↔ `ResourceIdentifier`) and parameter reordering
that need a type-conversion rule.

### 14. Back-compat constructor with an old signature — 🟡 Partially

**What the custom code does:** provides a constructor whose parameters match a previously
shipped signature, converting to the new field shape (e.g. `WritableSubResource` → `SubResource`,
adding a required `AzureLocation`).

**Citations:**
- `sdk/dnsresolver/Azure.ResourceManager.DnsResolver/src/Custom/InboundEndpointIPConfiguration.cs:17`
- `sdk/netapp/Azure.ResourceManager.NetApp/src/Custom/NetAppBackupData.cs:36`
- `sdk/resourcegraph/Azure.ResourceManager.ResourceGraph/src/Custom/Models/Facet.cs:14` (protected forwarding ctor for polymorphic subclassing)

**Why not fully automatable:** forwarding-only constructors (protected parameterless / arity
supersets) are automatable from the old contract; constructors that convert between types need
a conversion rule.

### 15. Wire-name preservation via `[WirePath]` / `[CodeGenSerialization]` name-only — 🟡 Partially

**What the custom code does:** pins a property's JSON wire name (or `etag`/casing) so the wire
format is unchanged after a C# property rename.

**Citations:**
- `sdk/operationalinsights/Azure.ResourceManager.OperationalInsights/src/Custom/Models/OperationalInsightsWorkspacePatch.cs:13` — `[CodeGenSerialization(nameof(ETag), "etag")]`
- `sdk/nginx/Azure.ResourceManager.Nginx/src/Custom/Models/NginxConfigurationFile.cs` — `[CodeGenSerialization(nameof(ContentHash), "contentHash")]`

**Why not fully automatable:** a name-only wire mapping is mechanical *if* a rename decorator
also records the original wire name; today it is separated into a manual attribute.

### 16. Custom serialization transform hooks — ❌ Not automatable

**What the custom code does:** `[CodeGenSerialization(..., SerializationValueHook, DeserializationValueHook)]`
with hand-written hook methods, or a full `JsonModelWriteCore` / `IJsonModel<T>` override, to
reshape the payload (nested restructuring, type coercion) for the old wire contract.

**Citations:**
- `sdk/resources/Azure.ResourceManager.Resources.Deployments/src/Custom/Models/ArmDeploymentPropertiesExtended.cs:19`
- `sdk/oracle/Azure.ResourceManager.OracleDatabase/src/Custom/OracleSubscriptionData.cs:15`
- `sdk/containerservice/Azure.ResourceManager.ContainerService/src/Custom/OSOptionProfileData.Serialization.cs:23`

**Why not automatable:** the transform is domain logic; the generator cannot infer how to map
old ↔ new payload shapes.

### 17. Type-conversion helpers between incompatible types — ❌ Not automatable

**What the custom code does:** hand-written converters between fundamentally different types
that a property changed to (e.g. `ManagedServiceIdentity` ↔ legacy `Identity`).

**Citations:**
- `sdk/hybridcompute/Azure.ResourceManager.HybridCompute/src/Custom/HybridComputeMachineData.cs:13`

**Why not automatable:** requires knowledge of the semantic equivalence between the two types.

### 18. `NotSupportedException` shims for fully removed APIs — ❌ Not automatable (as behavior)

**What the custom code does:** keeps a removed type/property present for source compatibility
but throws `NotSupportedException` at runtime (removed from the service, so no valid behavior
exists).

**Citations:**
- `sdk/securitycenter/Azure.ResourceManager.SecurityCenter/src/Custom/Models/PathRecommendation.cs:18`
- `sdk/reservations/Azure.ResourceManager.Reservations/src/Custom/Models/ReservationPurchaseContent.cs:17`
- `sdk/containerregistry/Azure.ResourceManager.ContainerRegistry/src/Custom/ContainerRegistry.Tasks/ContainerRegistryTaskRunResource.cs:26`

**Why not automatable:** the *skeleton* (deprecated type + throwing members) is templatable, but
deciding that an API should be a throwing shim rather than removed is a human breaking-change
policy decision, and there is no generated code to derive it from (the type no longer exists in
the spec).

---

## Data-plane libraries

The 14 TypeSpec-migrated data-plane packages with `src/Custom/` were surveyed the same way.
The **same scenario taxonomy applies** — data-plane back-compat code is dominated by type
renames, model-factory rename shims, re-added extensible enums, property-type shims,
parameter-type overloads, and restored constructors. The clearest example is
`Azure.AI.Agents.Persistent`, which collects its shims in a dedicated `src/Custom/BackwardCompat/`
folder; the patterns below also recur across `Azure.AI.Extensions.OpenAI`,
`Azure.AI.AgentServer.Responses`, `Azure.AI.Projects.Agents`, `Azure.Analytics.Purview.DataMap`,
`Azure.Compute.Batch`, and `Azure.AI.Vision.ImageAnalysis`.

The key structural difference from the management plane is that the data-plane generator
(`Azure.Generator`) does **not** yet ship the back-compat automation the management generator
has (no `NameVisitor` known-type renaming, no `ModelFactoryVisitor` overloads, no
inheritance-restoration), so scenarios that are already automated for management libraries are
still hand-written for data-plane libraries.

### D1. Public type rename via `[CodeGenType]` — ✅ Automatable (same as scenario 1)

**What the custom code does:** applies `[CodeGenType("NewGeneratedName")]` to an empty partial
so a generated type keeps the previously shipped name.

**Citations:**
- `sdk/ai/Azure.AI.Extensions.OpenAI/src/Custom/CodeGenStubs.cs:9` —
  `[CodeGenType("WorkflowActionOutputItemStatus")] … AgentWorkflowPreviewActionStatus`
- `sdk/ai/Azure.AI.Extensions.OpenAI/src/Custom/CodeGenStubs.cs:10-12` — three more rename stubs.

**Automation:** identical to management scenario 1 — deterministic given the previous
public contract. The data-plane generator has no known-type/rename visitor at all, so this is
a net-new automation opportunity for `Azure.Generator`.

### D2. Model-factory rename back-compat shims — ✅ Automatable (same as scenarios 5 / 13)

**What the custom code does:** the generated model factory is renamed (by
`ModelFactoryRenamerVisitor`) from the previously shipped `*ModelFactory` name to
`{ResourceProviderName}ModelFactory`, so a hand-written static partial restores the old factory
name and forwards each method to the new class.

**Citations:**
- `sdk/ai/Azure.AI.Agents.Persistent/src/Custom/BackwardCompat/ModelFactoryShims.cs:17,24-25` —
  `PersistentAgentsModelFactory` forwards to `AgentsPersistentModelFactory`.
- `sdk/agentserver/Azure.AI.AgentServer.Responses/src/Custom/ResponsesModelFactory.cs` and
  `AgentServerResponsesModelFactory.cs` — old/new factory pair.
- Similar model-factory renames are handled with `[CodeGenType]` on the factory itself in
  `Azure.Analytics.Purview.DataMap` (`AnalyticsPurviewDataMapModelFactory.cs:8` —
  `[CodeGenType("PurviewDataMapModelFactory")]`), `Azure.Compute.Batch`
  (`ComputeBatchModelFactory.cs:9` — `[CodeGenType("BatchModelFactory")]`), and
  `Azure.AI.Vision.ImageAnalysis` (`AIVisionImageAnalysisModelFactory.cs:8` —
  `[CodeGenType("VisionImageAnalysisModelFactory")]`); `Azure.AI.Projects.Agents`
  (`ProjectsAgentsModelFactory.cs`) hand-writes a factory partial.

**Automation:** deterministic. `ModelFactoryRenamerVisitor.cs:18` already knows both the old
name (the type's original name) and the new name, so the generator could emit the hidden
forwarding overloads under the old name automatically — the same capability
`Azure.Generator.Management/src/Visitors/ModelFactoryVisitor.cs` already provides for management
libraries. This is the single highest-value data-plane gap because the rename is generator-caused.

### D3. Re-add internalized / removed extensible enums — ✅ Automatable (same as scenario 6)

**What the custom code does:** re-declares extensible-enum structs that shipped in the prior GA
but the new emitter internalized or dropped.

**Citations:**
- `sdk/ai/Azure.AI.Agents.Persistent/src/Custom/BackwardCompat/MissingTypes.cs:12,38,64,90,116,142,168,194`
  — eight re-added `readonly partial struct` extensible enums (`AzureFunctionBindingType`, …).

**Automation:** deterministic given the previous contract (the shipped members are known);
mirrors management scenario 6.

### D4. Property-type shims via `[CodeGenSuppress]` + restore — 🟡 Partially (same as scenario 12)

**What the custom code does:** suppresses a generated `string` property and restores the
previously shipped extensible-enum-typed property.

**Citations:**
- `sdk/ai/Azure.AI.Agents.Persistent/src/Custom/BackwardCompat/PropertyShims.cs:25-32` —
  `[CodeGenSuppress("Type")]` + restored `AzureFunctionBindingType Type` property.

**Automation:** the suppression + property skeleton is boilerplate the generator could emit, but
the string→enum mapping is a per-property hint. Same verdict as management scenario 12.

### D5. Parameter-type back-compat overloads — 🟡 Partially (same as scenarios 5 / 11)

**What the custom code does:** the new generator changed a parameter type (e.g.
`IReadOnlyDictionary<string,string>` → `IDictionary<string,string>`); a hidden overload keeps
the old signature and delegates.

**Citations:**
- `sdk/ai/Azure.AI.Agents.Persistent/src/Custom/BackwardCompat/ClientMethodShims.cs:6,35-53` —
  `CreateAgent`/`CreateAgentAsync` overloads accepting the old `IReadOnlyDictionary` signature.

**Automation:** the generator can emit the overload skeleton, but the parameter-type adaptation
(the `ToDict` conversion) is a per-parameter hint. Same verdict as management scenario 11.

### D6. Restored constructor signatures — 🟡 Partially (same as scenario 14)

**What the custom code does:** suppresses the generated private-protected discriminator ctor and
restores the previously shipped parameterless `protected` constructor.

**Citations:**
- `sdk/ai/Azure.AI.Agents.Persistent/src/Custom/BackwardCompat/AbstractTypeConstructors.cs:14-17`
  — `[CodeGenSuppress("MessageContent")]` + `protected MessageContent()`.

**Automation:** the suppression + ctor skeleton is boilerplate, but the delegated argument
(`this((string)null)` vs `this(default(MessageBlockType))`) is a per-type hint. Same verdict as
management scenario 14.

**Data-plane takeaway:** every data-plane back-compat scenario observed maps onto an existing
management-plane scenario; none are unique to the data plane. The distinguishing fact is that
`Azure.Generator` has not yet adopted the automation `Azure.Generator.Management` already ships,
so D1–D3 (renames, model-factory forwarders, re-added enums) are the highest-value data-plane
automation targets, and D2 is especially compelling because the model-factory rename is
generator-caused.

---

## Summary

| # | Scenario | Mechanism | Automatable? |
|---|----------|-----------|--------------|
| 1 | Type rename to old name | `[CodeGenType]` | ✅ |
| 2 | Restore removed base type | `partial : ResourceData` | ✅ |
| 3 | Renamed-type deprecated alias | subclass + `[Obsolete]` | ✅ |
| 4 | Renamed property shim | forwarding `[Obsolete]` property | ✅ |
| 5 | Method rename / overload forwarder | hidden forwarding overload | ✅ |
| 6 | Enum / extensible-enum value re-add | static members | ✅ |
| 7 | Collection init in ctor | `ChangeTrackingList` init | ✅ |
| 8 | Read-only collection surface | `IReadOnly*` facade | ✅ |
| 9 | `IJsonModel<TData>` forwarding | delegate to `Data` | ✅ |
| 10 | Suppress shared/common type | `[assembly: CodeGenSuppressType]` | 🟡 |
| 11 | Suppress overload + replacement | `[CodeGenSuppress]` | 🟡 |
| 12 | Flatten/unflatten wrapper | custom get/set | 🟡 |
| 13 | Model-factory overload adaptation | `ArmXxxModelFactory` overload | 🟡 |
| 14 | Back-compat constructor | old-signature ctor | 🟡 |
| 15 | Wire-name preservation | `[WirePath]` / `[CodeGenSerialization]` name | 🟡 |
| 16 | Custom serialization transform | serialization hooks / overrides | ❌ |
| 17 | Incompatible type converters | hand-written converters | ❌ |
| 18 | Removed-API throwing shims | `NotSupportedException` stubs | ❌ |

**Valid cases (candidates for generator automation):** scenarios 1–9 are deterministic and are
the highest-value targets, because they are also the most frequent custom-code patterns in the
survey. They share a single enabler: the generator (or an emitter step) consuming the
**previous public contract** that CI already tracks for breaking-change detection, plus a small
set of rename/flatten hints, to emit renames, deprecated aliases/forwarders, restored bases,
read-only facades, and re-added enum values automatically.

Scenarios 10–15 are partially automatable: the generator can emit the boilerplate, but a
per-item hint (ownership allowlist, flatten path, or type-conversion rule) is required.

Scenarios 16–18 remain hand-written because they encode domain logic or breaking-change policy
that cannot be derived from the spec.

**Data plane:** the data-plane survey (see [Data-plane libraries](#data-plane-libraries))
surfaced no scenarios outside this taxonomy — every data-plane shift maps onto one of the
scenarios above (D1→1, D2→5/13, D3→6, D4→12, D5→5/11, D6→14). The difference is coverage: the
data-plane generator (`Azure.Generator`) has not yet adopted the management generator's
automation, so renames (D1), model-factory forwarders (D2), and re-added enums (D3) are still
hand-written there and are the highest-value data-plane automation targets. D2 is the strongest
candidate because the model-factory rename is generator-caused
(`Azure.Generator/src/Visitors/ModelFactoryRenamerVisitor.cs`).
