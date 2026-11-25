# C# Naming Rules

<!-- § anchors are shared permalinks: never rename or reuse one, and give each new rule a unique name using its section's prefix. -->

These rules cover C# naming in Azure SDK for .NET libraries, including management and data-plane
libraries. Apply the scope, exceptions, and compatibility checks below. The published guidelines
and their precedence described in [Authoritative Guidelines](repository-rules.md#authoritative-guidelines--always-consult)
continue to apply.

Related naming conventions are in [Client Design](repository-rules.md#client-design) (client
names, namespaces, and subclient factories) and [Implementation](repository-rules.md#implementation)
(paging and model-factory names).

## Framework Design Guideline Naming — Hard Rules

These are part of [H2 — Follow the .NET Framework Design Guidelines](review-quality.md#h2--follow-the-net-framework-design-guidelines):
violations are always 🔴. Consult the [Framework Design Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines/)
as written; these checks are a starting point, not the full set.

**Naming**
- <a name="fdg-naming-casing" href="#fdg-naming-casing">§</a> PascalCase for types, members, namespaces; camelCase for parameters and locals
- <a name="fdg-naming-acronyms" href="#fdg-naming-acronyms">§</a> No abbreviations or acronym soup; acronyms of 2 letters stay upper (`IO`), 3+ are Pascal
  (`Http`, `Xml`, `Uri`). `Id` and `Vm` are explicit naming exceptions
- <a name="fdg-naming-algorithm-acronyms" href="#fdg-naming-algorithm-acronyms">§</a> In management-plane libraries, for Cryptographic (or other) algorithm names follow the same
  Pascal case acronym naming conventions:
  - Advanced Encryption Standard (AES) is `Aes`.
  - Elliptic Curve Digital Signature Algorithm (ECDSA) is `ECDsa` (two-letter acronym followed
    by a three-letter acronym).
  - Elliptic Curve Diffie-Hellman (ECDH) is `ECDiffieHellman` (avoiding the four concurrent
    capital letters required by a two-letter acronym following a two-letter acronym).
- <a name="fdg-naming-unfamiliar-acronyms" href="#fdg-naming-unfamiliar-acronyms">§</a> Before recommending expansion of an unfamiliar acronym, check domain documentation and usage
  for the intended audience. Personal unfamiliarity or search-result ranking is not enough
- <a name="fdg-naming-hungarian-notation" href="#fdg-naming-hungarian-notation">§</a> No Hungarian notation; no type names in member names
- <a name="fdg-naming-vague-names" href="#fdg-naming-vague-names">§</a> No generic/vague names — `OperationResponse`, `DataCollection`, `Manager`, `Helper`,
  `Utility`, `Info` are smells
- <a name="fdg-naming-unqualified-use" href="#fdg-naming-unqualified-use">§</a> Assess public type names in normal unqualified use. Add domain context when needed for meaning,
  not a mechanical provider prefix; retain a provider name when it actually identifies the domain
  concept. In management-plane libraries, avoid mechanical `Microsoft` or `Azure` prefixes.
  Assess enum members with their enclosing enum
- <a name="fdg-naming-async-and-try" href="#fdg-naming-async-and-try">§</a> Async methods end in `Async`; `Try*` methods return `bool` with an `out` result
- <a name="fdg-naming-booleans" href="#fdg-naming-booleans">§</a> Boolean members read affirmatively (`IsEnabled`, not `IsNotDisabled`)
- <a name="fdg-naming-duration-units" href="#fdg-naming-duration-units">§</a> Numeric durations or time intervals with fixed units name those units, consistently with the
  contract and conversion logic. This does not apply to `TimeSpan` or explicitly selectable units.
  Naming the unit does not justify the numeric type; `TimeSpan` is preferred for durations (see
  [Semantic Value Types](repository-rules.md#semantic-types-fixed-unit-durations))

**Enum naming**
- <a name="fdg-naming-enum-plurality" href="#fdg-naming-enum-plurality">§</a> Use singular names for non-flags enums and plural names for flags enums. Judge actual word
  meaning and declared semantics, not a trailing `s` or numeric values
- <a name="fdg-naming-version-components" href="#fdg-naming-version-components">§</a> Keep version components unambiguous, such as `Tls1_0` for TLS 1.0. Do not guess how to split
  digits or impose underscores on an established, unambiguous naming convention

## Naming — Review-Only

<a name="naming-public-surface" href="#naming-public-surface">§</a> **Scope: public surface area only.** These are API-design rules — they apply to `public` and
`protected` types, members, and parameters, i.e. anything that shows up in the checked-in
`api/*.cs` listing. Do **not** raise them on `internal`, `private`, or `private protected`
declarations, or on local variables. If an internal declaration is the *cause* of a bad public
name, anchor the comment on the public member and reference the internal one as the cause.

<a name="naming-boolean-properties-parameters" href="#naming-boolean-properties-parameters">§</a> **In management-plane libraries, Boolean properties and parameters** read affirmatively and
start with a verb such as `Is`, `Can`, or `Has` (`IsEnabled`/`isEnabled`, not
`IsNotDisabled`/`isNotDisabled`).

<a name="naming-analyzer-coverage" href="#naming-analyzer-coverage">§</a> **Naming analyzers run only on shipping client libraries, and many projects opt out.**
`EnableClientSdkAnalyzers` defaults on only when `IsShippingClientLibrary` is true
(`Directory.Build.Common.props`), and it pulls in *both* the in-repo `Azure.SdkAnalyzers`
and the out-of-repo `Azure.ClientSdk.Analyzers` package — `AZC` rules from either source fire.
What they cover:

| Rule | Covers | Scope |
|---|---|---|
| `AZC0012` | Single-word type names | Public **types** only |
| `AZC0030`–`AZC0033` | Model names ending `Request`, `Response`, `Parameter`, `Options`, `Definition` | Public **types** only |
| `AZC0034` | Duplicate type names across the SDK | Public **types** only |
| `AZC0035` | Output model missing a model-factory method | Output models |
| `AZC0005`–`AZC0007`, `AZC0015`, `AZC0021` | Client ctor shape, client return types | Clients |
| `AZC0020` | `CancellationToken` not propagated to `RequestContext` | Methods |
| `AZC0040`, `AZC0101` | Apache.Arrow on public API; `ConfigureAwait(true)` | — |

**Two gaps keep the suffix rules below worth reviewing by hand:**

- <a name="naming-type-scoped-analyzers" href="#naming-type-scoped-analyzers">§</a> **Every naming analyzer above is type-scoped.** None of them look at member or parameter
  names, so the rules below always apply there regardless of what the build reported.
- <a name="naming-disable-enhanced-analysis" href="#naming-disable-enhanced-analysis">§</a> **`<DisableEnhancedAnalysis>true</DisableEnhancedAnalysis>` silences `AZC0030`–`AZC0034` and
  `AZC0036` project-wide**, by pulling in
  `eng/globalconfigs/disable_enhanced_analysis.globalconfig`. It is set widely — grep the
  property to see whether the project under review is one of them — mostly by heavily-generated
  libraries. In such a project type names are unchecked too, and a PR *adding* the property is a
  project-wide suppression of six diagnostics at once → 🔴 on the
  [suppression ladder](repository-rules.md#analyzers-suppression-ladder).

- <a name="naming-definition-operation-suffixes" href="#naming-definition-operation-suffixes">§</a> **`Definition` and `Operation` are narrow, reserved suffixes, not general-purpose ones.**
  `*Definition` should be removed unless the plain noun would actually collide with another
  resource's type in the same namespace. `*Operation` is reserved for operation types, such as
  those inheriting `Operation<T>`; a plain data model should not borrow it (use a descriptive
  domain name or a suitable transport suffix instead). In management-plane libraries, types
  inheriting the non-generic `Operation` may also use `*Operation`.
  Both are only partially covered by `AZC0030`–`AZC0033`, which is type-scoped and frequently
  suppressed via `DisableEnhancedAnalysis` (see above) — treat this as the hand-review backstop
  for exactly the projects where the analyzer can't help.
- <a name="naming-check-name-availability" href="#naming-check-name-availability">§</a> **`CheckNameAvailability` has a fixed naming triad.** Checking method:
  `Check<Resource/RP noun>NameAvailability`. Its request/response model follows the Content/
  Result convention below but keeps the resource/RP noun:
  `<Resource/RP noun>NameAvailability<Content|Result>`. The "why unavailable" enum:
  `<Resource/RP noun>NameUnavailableReason`. A bare `NameAvailability*`/`CheckNameAvailability*`
  without the resource/RP noun is under-specified and collides with the same pattern in sibling
  RPs.
- <a name="naming-list-operations" href="#naming-list-operations">§</a> **Remove a `ListOperations`/`ListOperationsAsync` method this PR is newly generating or
  exposing.** Older ARM generation emitted this as a side effect; every operation already has
  its own public method, so a newly-generated one is pure surface noise, not a legitimate API.
  This is not a license to hunt for pre-existing occurrences in files the PR does not touch —
  flag it only when the PR's own diff introduces or regenerates it.
- <a name="naming-get-operation-status" href="#naming-get-operation-status">§</a> **Do not expose a generated ARM `GetOperationStatus`/`GetOperationStatusAsync` method solely
  for LRO polling.** The SDK's `ArmOperation`/`Operation<T>` already manages polling. Check the
  actual operation and contract, not just its name: a distinct customer-facing status operation
  is not automatically redundant. Apply this to newly introduced or newly exposed methods, not
  already-shipped APIs; preserve GA compatibility.
- <a name="naming-required-body-parameter" href="#naming-required-body-parameter">§</a> **A PUT/PATCH body parameter this PR is newly adding should be required, not optional.** The
  body is the entire resource or patch payload — there is no meaningful "no body" call for a
  brand-new operation. Applies only to an operation the PR introduces. Do **not** suggest
  flipping an already-shipped method's body parameter from optional to required — that is
  itself the optional-to-required break already flagged under
  [Breaking Changes](repository-rules.md#breaking-changes-repo-specific-detection), and
  reverting it needs the same GA-compatibility bar, not a naming/design pass.
- <a name="naming-discriminated-base" href="#naming-discriminated-base">§</a> **When the PR introduces a new discriminated (polymorphic) hierarchy, its base type should be
  `abstract`.** A concrete, directly-instantiable base alongside its own discriminator value
  next to real subtypes is almost always an incomplete hierarchy. If the PR instead adds a new
  subtype onto an existing, already-shipped concrete base, that base's concreteness is
  pre-existing design debt, not a new-code finding — note it only as an ℹ️ observation if at
  all, never a blocking finding.

- <a name="naming-uri" href="#naming-uri">§</a> **`Url` → `Uri`, and the type is `Uri`** — no public member or parameter contains `Url`; it's
  always `Uri`. A member that holds an absolute address is typed `System.Uri`, not `string`.
  Watch for `string`-typed members whose *name* betrays a URI (`*Link`, `*Endpoint`,
  `*Address`, `*Uri`) — those are the same bug wearing a different name. A `string` shadow of a
  `Uri` property (public `internalConsentLink` parameter next to `Uri ConsentLink`) is 🔴.
- <a name="naming-timestamp-suffix" href="#naming-timestamp-suffix">§</a> **`DateTimeOffset` members end in `On` — except under `sdk/ai`, where they end in `At`.**
  `StartTime` → `StartedOn` repo-wide, `StartedAt` under `sdk/ai`. Prefer a meaningful verb form
  (`Created`/`Updated`/`Started` for completed events, `Expires` for a future event), not the
  noun (`CreationOn`). Applies to public properties and parameters. Never use `DateTime` on the
  public surface.
- <a name="naming-etag-property" href="#naming-etag-property">§</a> **Spell an entity-tag property `ETag`** when it represents an actual entity tag; use
  `Azure.ETag` for its semantic type. Do not infer this from a name alone or retype a generic
  raw-header dictionary. See [semantic value types](repository-rules.md#semantic-value-types).
- <a name="naming-response-suffix" href="#naming-response-suffix">§</a> **No `Response` suffix — use `Result`.** Applies to public **types**, properties, methods, and
  parameters. Exception: a type deriving from a third-party base whose own convention is
  `...ResponseItem` (e.g. `OpenAI.Responses.ResponseItem`) keeps the base's suffix —
  consistency with the base type wins.
- <a name="naming-request-suffix" href="#naming-request-suffix">§</a> **No `Request` suffix — use `Content`.** Same scope. `RequestContent`/`RequestContext`/
  `RequestOptions` from `Azure.Core` and `System.ClientModel` are framework types and are
  exempt. `*Parameter`/`*Parameters` is the same smell. In management-plane libraries, replace
  that suffix with `Content` or `Patch` according to the model's actual usage: use `Patch` for
  partial-update semantics, and `Content` for a request payload that is not itself a patch.
  A model nested in a PATCH body is not automatically a patch; see the management request-body
  rule below. For data-plane models, drop the suffix or use a domain noun. Do **not** reach for
  `*Options` as the replacement (see the `Options` rule below).
- <a name="naming-options-suffix" href="#naming-options-suffix">§</a> **`Options` suffix is reserved for client options and method options bags.** Two legitimate
  uses, and neither is "a serialized body model":
  1. **Client options** — `<Client>Options : ClientOptions`, client-level configuration.
  2. **A method options bag** — a type that aggregates the **query, path, header, and body**
     parameters of a single operation into one object. It shows up as a *method parameter*,
     and typically the method then takes exactly two: the options bag and a
     `CancellationToken`/`RequestContext`. An options bag spans multiple request locations, so
     it is generally not itself a single JSON body model.

  It is **not** a generic replacement suffix for a body/wire payload model. A type that
  implements `IJsonModel<T>`/`IPersistableModel<T>` — i.e. it serializes as one request or
  response body — must not be named `*Options`. For an otherwise invalid `*Options` model,
  replace `Options` with `Config` in both management and data-plane libraries; this is a
  specific suffix convention, not permission to abbreviate `configuration` elsewhere. Do not
  rename actual client options or method options bags. When cleaning up a bad suffix (`*Parameters`,
  `*Resource`, `*Request`) on a payload model, do **not** land on `*Options` — use the default
  payload suffix convention below. To tell them apart in the `api/*.cs` listing: payload models
  spell out `: System.ClientModel.Primitives.IJsonModel<T>`; a real options bag appears as a
  method parameter next to a `CancellationToken`. Renaming a payload model *to* `*Options` is a
  regression even when the old suffix was also wrong.
- <a name="naming-payload-suffix" href="#naming-payload-suffix">§</a> **Payload-model suffix defaults — only when the type is a *transport* type.** `Content` for
  an input/round-trip transport type, `Result` for an output-only one. A transport type exists
  purely to carry an operation's payload; it is not a thing in the service's domain.
  - <a name="naming-domain-nouns" href="#naming-domain-nouns">§</a> **If the type is a noun in its own right, it takes no suffix at all** — even when it is
    round-tripped. `VirtualMachine` is created and fetched, and it is simply `VirtualMachine`,
    never `VirtualMachineContent`. Same for a nested domain object like a tool connection or a
    search configuration: name it the noun. For a management model with a `Parameter` or
    `Parameters` suffix, apply the replacement rule above.
  - So "round-trip" alone never justifies `Content`. Ask first whether the type names a domain
    concept. Only reach for `Content`/`Result` when the answer is no and the type is a pure
    payload wrapper.
  - These are soft defaults — use them *unless there is a significantly better option* or the
    `Options`-to-`Config` convention above applies. What is **not** acceptable as a substitute:
    `Options`, `Parameters`, `Request`, `Response`, `Resource`.
  - To classify usage from the `api/*.cs` listing: a **public constructor** means the type is
    used as input, a method on the package's `*ModelFactory` means it is used as output, and
    both together mean round-trip.
- <a name="naming-management-request-body" href="#naming-management-request-body">§</a> **Management request-body models follow their actual role and HTTP contract.** Use `Patch`
  for a dedicated PATCH partial-update model and `Content` for a dedicated PUT/POST wrapper.
  Resource-data models retain `Data`. Do not infer the verb from a method name or rename a
  reusable domain model merely because it is used as a request body. A model used as a property
  inside a PATCH body is not itself a patch merely because of its parent. If the property is
  replaced as a whole, name its model for its own role: retain a descriptive domain noun, or
  use `Content` for a dedicated input wrapper; use `Patch` only for actual partial-update
  semantics.
- <a name="naming-arm-common-types" href="#naming-arm-common-types">§</a> **Do not redefine an ARM common type this PR is newly introducing on the public surface of an
  `Azure.ResourceManager.*` package.** Each of these names is reserved for the shared framework
  type; a new declaration using one of them is a duplication bug, not a coincidence. When the
  service's wire contract matches, the fix is the framework type below. When it genuinely
  differs, the fix is a service-specific model under an RP-prefixed name instead — e.g.
  `BackupErrorDetail`, whose payload adds `Recommendations` — and that renamed variant is not
  itself a finding. An existing redefinition already shipped pre-PR is not a new-code finding to
  raise — removing it is itself a breaking change requiring the full GA-compatibility bar, not a
  quick fix in passing.

  | Type name | Use instead |
  |---|---|
  | `ManagedServiceIdentity`, `ManagedServiceIdentityType` | `Azure.ResourceManager.Models` equivalents |
  | `ManagedServiceIdentityPatch` | `Azure.ResourceManager.Models.ManagedServiceIdentity` — ARM patch models reuse it for `Identity` |
  | `UserAssignedIdentity` | `Azure.ResourceManager.Models.UserAssignedIdentity` |
  | `SystemData` | Already exposed via `ResourceData.SystemData` — do not redefine |
  | `ErrorResponse`, `ErrorDetail` | `Azure.ResponseError` |
  | `OperationStatusResult` | `Azure.ResourceManager.Models.OperationStatusResult`; for plain LRO polling state, the `ArmOperation`/`Operation<T>` pattern rather than a public status model |
  | `TrackedResource` | Inherit `TrackedResourceData` instead of defining a new base |
  | `TagsUpdate`, `TagsPatch` | The Tags-update pattern `Azure.ResourceManager` already provides, or a service-prefixed `*Patch` model that carries only `Tags` |
- <a name="naming-resource-suffix" href="#naming-resource-suffix">§</a> **`Resource` suffix is reserved for `ArmResource`-derived types.** A data model, options bag,
  or client named `*Resource` in a non-`Azure.ResourceManager.*` package is wrong. Third-party
  `*Resource` types being *consumed* (e.g. `OpenAI.Conversations.ConversationResource`) are not
  a finding.
- <a name="naming-arm-role-words" href="#naming-arm-role-words">§</a> **Omit redundant ARM role words:** `WidgetResourceData` and `WidgetResourceCollection`
  normally become `WidgetData` and `WidgetCollection`. Keep `Resource` when it is part of the
  domain name, such as `PrivateLinkResource`; this simplification does not apply to
  framework-owned types.
- <a name="naming-data-collection-suffixes" href="#naming-data-collection-suffixes">§</a> **In management-plane libraries, `Data` and `Collection` suffixes are reserved for the ARM
  resource trio.** `*Data` implies `ResourceData`/`TrackedResourceData` inheritance;
  `*Collection` implies `ArmCollection` inheritance. Established domain terms such as
  `MongoDBCollection`, `CosmosDBSqlCollection`, and `CassandraCollection` are exceptions because
  they name a real domain concept, not a resource collection. A plain settings/config/payload
  model with either suffix and without the matching base misrepresents its ARM role.
  In data-plane libraries, do not apply these ARM inheritance requirements; assess names by their
  domain meaning, such as `EventData` for event payloads.
- <a name="naming-resource-collection-alternatives" href="#naming-resource-collection-alternatives">§</a> In management-plane libraries, for an incorrectly named `*Resource` model, use a descriptive
  domain noun rather than a generic `Info` fallback; use `Data` only for a resource-data subtype.
  For a non-resource `*Collection`, `Group` or `List` can be appropriate if it describes the
  domain and does not collide; retain established domain terms such as `MongoDBCollection`.
  Do not apply these ARM-specific replacement requirements to data-plane models.
- <a name="naming-expand-abbreviations" href="#naming-expand-abbreviations">§</a> **Expand single-word and abbreviated names.** `AZC0012` only covers types — apply the same
  standard to public properties and parameters. Also expand abbreviations the analyzer never
  sees, on types *and* members: `auth` → `authentication`, `agentRef` → `agent`, `params` →
  `parameters`, `config` → `configuration`, `spec` → `specification`, `info`, `args`, `props`,
  `idx`. Highest-value case: a PR renames most of a type family to the expanded form
  (`ResponsesOpenApiAuthDetails` → `OpenApiAuthenticationDetails`) but misses one sibling
  (`OpenApiManagedAuthDetails`) or leaves the property/parameter carrying it abbreviated
  (`Auth`/`auth`). **Always check the whole family, not just the type in front of you.**
  Apply [H1](review-quality.md#h1--no-breaking-changes) before recommending further renames; a
  naming cleanup does not waive GA compatibility
- <a name="naming-time-to-live" href="#naming-time-to-live">§</a> For a duration concept abbreviated `TTL`, prefer `TimeToLive`. Prefer a `TimeSpan` type over a
  unit suffix such as `TimeToLiveInSeconds`; if fixed units are kept, apply the shared
  numeric-unit guidance. A hop count is not a duration.
- <a name="naming-interval-duration-suffixes" href="#naming-interval-duration-suffixes">§</a> In management-plane libraries, `Interval` or `Duration` may describe a duration regardless of
  its wire format or CLR type; do not strip the suffix solely because the value is not an ISO
  8601 string. Prefer `TimeSpan` for durations; fixed-unit numbers still name their units, for
  example `MonitoringIntervalInSeconds`.
- <a name="naming-parameter-consistency" href="#naming-parameter-consistency">§</a> **Parameter names must be consistent and descriptive within a scope** (all methods on a
  client, all public constructors + the model-factory method for a type, all overloads of a
  method).
  - The same concept must not be `id` on one method and `identifier` on another, or `agent` /
    `agentRef` / `agentReference` for the same type across one namespace.
  - <a name="naming-bare-id-parameters" href="#naming-bare-id-parameters">§</a> A bare `id` alongside a qualified `fileId` is under-specified — say which id it is
    (`pathId`, `runId`, …).
  - <a name="naming-numeric-suffixed-parameters" href="#naming-numeric-suffixed-parameters">§</a> **Numeric-suffixed public parameters (`id0`, `value1`) are always 🔴** — they're emitter
    collision artifacts leaking to the public surface, and they signal a real modeling problem
    (usually a `new`-shadowed base property forcing two same-named params into one signature).
    Check whether the un-suffixed twin is even used; often it is silently dead.
  - <a name="naming-internal-parameters" href="#naming-internal-parameters">§</a> A **public** parameter named `internal*` is 🔴 — it names an implementation detail the
    caller can't reason about.
  - Cheap mechanical check: within one scope (one method's overloads, one client's methods,
    one type's constructors + factory), parse the checked-in `api/*.cs` listing and group
    that scope's parameters by CLR type — a type bound to more than one name is a candidate
    to look at, not a finding by itself. Different parameters of the same type in one
    signature (`string widgetName, string operationId`) are a normal, correct pattern; only
    escalate when the names actually name the same semantic concept.

<a name="naming-new-or-renamed" href="#naming-new-or-renamed">§</a> Apply these to **new or renamed** public API only. Pre-existing names on untouched lines are out
of scope (see the [changed-code scope](review-quality.md#scope-changed-code)) — but a name on a
line the PR is already changing, or inside a type the PR is already renaming, is fair game,
because that is the cheapest moment it will ever be fixed.
