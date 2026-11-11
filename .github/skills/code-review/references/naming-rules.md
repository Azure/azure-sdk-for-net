# C# Naming Rules

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
- PascalCase for types, members, namespaces; camelCase for parameters and locals
- No abbreviations or acronym soup; acronyms of 2 letters stay upper (`IO`), 3+ are Pascal
  (`Http`, `Xml`, `Uri`). `Id` and `Vm` are explicit naming exceptions
- Before recommending expansion of an unfamiliar acronym, check domain documentation and usage
  for the intended audience. Personal unfamiliarity or search-result ranking is not enough
- No Hungarian notation; no type names in member names
- No generic/vague names — `OperationResponse`, `DataCollection`, `Manager`, `Helper`,
  `Utility`, `Info` are smells
- Assess public type names in normal unqualified use. Add domain context when needed for meaning,
  not a mechanical provider prefix. Assess enum members with their enclosing enum
- Async methods end in `Async`; `Try*` methods return `bool` with an `out` result
- Boolean members read affirmatively (`IsEnabled`, not `IsNotDisabled`)
- Numeric durations or time intervals with fixed units name those units, consistently with the
  contract and conversion logic. This does not apply to `TimeSpan` or explicitly selectable units

**Enum naming**
- Use singular names for non-flags enums; plural names are appropriate, not mandatory, for flags
  enums. Judge actual word meaning and declared semantics, not a trailing `s` or numeric values
- Keep version components unambiguous, such as `Tls1_0` for TLS 1.0. Do not guess how to split
  digits or impose underscores on an established, unambiguous naming convention

## Naming — Review-Only

**Scope: public surface area only.** These are API-design rules — they apply to `public` and
`protected` types, members, and parameters, i.e. anything that shows up in the checked-in
`api/*.cs` listing. Do **not** raise them on `internal`, `private`, or `private protected`
declarations, or on local variables. If an internal declaration is the *cause* of a bad public
name, anchor the comment on the public member and reference the internal one as the cause.

**Naming analyzers run only on shipping client libraries, and many projects opt out.**
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

- **Every naming analyzer above is type-scoped.** None of them look at member or parameter
  names, so the rules below always apply there regardless of what the build reported.
- **`<DisableEnhancedAnalysis>true</DisableEnhancedAnalysis>` silences `AZC0030`–`AZC0034` and
  `AZC0036` project-wide**, by pulling in
  `eng/globalconfigs/disable_enhanced_analysis.globalconfig`. It is set widely — grep the
  property to see whether the project under review is one of them — mostly by heavily-generated
  libraries. In such a project type names are unchecked too, and a PR *adding* the property is a
  project-wide suppression of six diagnostics at once → 🔴 on the
  [suppression ladder](repository-rules.md#analyzer-warnings-and-suppressions).

- **`Definition` and `Operation` are narrow, reserved suffixes, not general-purpose ones.**
  `*Definition` should be removed unless the plain noun would actually collide with another
  resource's type in the same namespace. `*Operation` is reserved for types that inherit
  `Operation<T>`; a plain data/info model should not borrow it (rename to `*Data` or similar).
  Both are only partially covered by `AZC0030`–`AZC0033`, which is type-scoped and frequently
  suppressed via `DisableEnhancedAnalysis` (see above) — treat this as the hand-review backstop
  for exactly the projects where the analyzer can't help.
- **`CheckNameAvailability` has a fixed naming triad.** Checking method:
  `Check<Resource/RP noun>NameAvailability`. Its request/response model follows the Content/
  Result convention below but keeps the resource/RP noun:
  `<Resource/RP noun>NameAvailability<Content|Result>`. The "why unavailable" enum:
  `<Resource/RP noun>NameUnavailableReason`. A bare `NameAvailability*`/`CheckNameAvailability*`
  without the resource/RP noun is under-specified and collides with the same pattern in sibling
  RPs.
- **Remove a `ListOperations`/`ListOperationsAsync` method this PR is newly generating or
  exposing.** Older ARM generation emitted this as a side effect; every operation already has
  its own public method, so a newly-generated one is pure surface noise, not a legitimate API.
  This is not a license to hunt for pre-existing occurrences in files the PR does not touch —
  flag it only when the PR's own diff introduces or regenerates it.
- **A PUT/PATCH body parameter this PR is newly adding should be required, not optional.** The
  body is the entire resource or patch payload — there is no meaningful "no body" call for a
  brand-new operation. Applies only to an operation the PR introduces. Do **not** suggest
  flipping an already-shipped method's body parameter from optional to required — that is
  itself the optional-to-required break already flagged under
  [Breaking Changes](repository-rules.md#breaking-changes-repo-specific-detection), and
  reverting it needs the same GA-compatibility bar, not a naming/design pass.
- **When the PR introduces a new discriminated (polymorphic) hierarchy, its base type should be
  `abstract`.** A concrete, directly-instantiable base alongside its own discriminator value
  next to real subtypes is almost always an incomplete hierarchy. If the PR instead adds a new
  subtype onto an existing, already-shipped concrete base, that base's concreteness is
  pre-existing design debt, not a new-code finding — note it only as an ℹ️ observation if at
  all, never a blocking finding.

- **`Url` → `Uri`, and the type is `Uri`** — no public member or parameter contains `Url`; it's
  always `Uri`. A member that holds an absolute address is typed `System.Uri`, not `string`.
  Watch for `string`-typed members whose *name* betrays a URI (`*Link`, `*Endpoint`,
  `*Address`, `*Uri`) — those are the same bug wearing a different name. A `string` shadow of a
  `Uri` property (public `internalConsentLink` parameter next to `Uri ConsentLink`) is 🔴.
- **`DateTimeOffset` members end in `On` — except under `sdk/ai`, where they end in `At`.**
  `StartTime` → `StartedOn` repo-wide, `StartedAt` under `sdk/ai`. Prefer the past-participle
  verb form (`Created`/`Updated`/`Started`/`Expires`), not the noun (`CreationOn`). Applies to
  public properties and parameters. Never use `DateTime` on the public surface.
- **Boolean properties and parameters start with a verb**, such as `Is`, `Can`, or `Has`
  (for example, the property `IsEnabled` and the parameter `isEnabled`).
- **No `Response` suffix — use `Result`.** Applies to public **types**, properties, methods, and
  parameters. Exception: a type deriving from a third-party base whose own convention is
  `...ResponseItem` (e.g. `OpenAI.Responses.ResponseItem`) keeps the base's suffix —
  consistency with the base type wins.
- **No `Request` suffix — use `Content`.** Same scope. `RequestContent`/`RequestContext`/
  `RequestOptions` from `Azure.Core` and `System.ClientModel` are framework types and are
  exempt. `*Parameters` is the same smell — drop the suffix or use a domain noun. Do **not**
  reach for `*Options` as the replacement (see the `Options` rule below).
- **`Options` suffix is reserved for client options and method options bags.** Two legitimate
  uses, and neither is "a serialized body model":
  1. **Client options** — `<Client>Options : ClientOptions`, client-level configuration.
  2. **A method options bag** — a type that aggregates the **query, path, header, and body**
     parameters of a single operation into one object. It shows up as a *method parameter*,
     and typically the method then takes exactly two: the options bag and a
     `CancellationToken`/`RequestContext`. An options bag spans multiple request locations, so
     it is generally not itself a single JSON body model.

  It is **not** a generic replacement suffix for a body/wire payload model. A type that
  implements `IJsonModel<T>`/`IPersistableModel<T>` — i.e. it serializes as one request or
  response body — must not be named `*Options`. When cleaning up a bad suffix (`*Parameters`,
  `*Resource`, `*Request`) on a payload model, do **not** land on `*Options` — use the default
  payload suffix convention below. To tell them apart in the `api/*.cs` listing: payload models
  spell out `: System.ClientModel.Primitives.IJsonModel<T>`; a real options bag appears as a
  method parameter next to a `CancellationToken`. Renaming a payload model *to* `*Options` is a
  regression even when the old suffix was also wrong.
- **Payload-model suffix defaults — only when the type is a *transport* type.** `Content` for
  an input/round-trip transport type, `Result` for an output-only one. A transport type exists
  purely to carry an operation's payload; it is not a thing in the service's domain.
  - **If the type is a noun in its own right, it takes no suffix at all** — even when it is
    round-tripped. `VirtualMachine` is created and fetched, and it is simply `VirtualMachine`,
    never `VirtualMachineContent`. Same for a nested domain object like a tool connection or a
    search configuration: name it the noun.
  - So "round-trip" alone never justifies `Content`. Ask first whether the type names a domain
    concept. Only reach for `Content`/`Result` when the answer is no and the type is a pure
    payload wrapper.
  - These are soft defaults — use them *unless there is a significantly better option*. What
    is **not** acceptable as a substitute: `Options`, `Parameters`, `Request`, `Response`,
    `Resource`.
  - To classify usage from the `api/*.cs` listing: a **public constructor** means the type is
    used as input, a method on the package's `*ModelFactory` means it is used as output, and
    both together mean round-trip.
- **Management request-body models follow their actual role and HTTP contract.** Use `Patch`
  for a dedicated PATCH partial-update model and `Content` for a dedicated PUT/POST wrapper.
  Resource-data models retain `Data`. Do not infer the verb from a method name or rename a
  reusable domain model merely because it is used as a request body.
- **Do not redefine an ARM common type this PR is newly introducing on the public surface of an
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
- **`Resource` suffix is reserved for `ArmResource`-derived types.** A data model, options bag,
  or client named `*Resource` in a non-`Azure.ResourceManager.*` package is wrong. Third-party
  `*Resource` types being *consumed* (e.g. `OpenAI.Conversations.ConversationResource`) are not
  a finding.
- **Omit redundant ARM role words:** `WidgetResourceData` and `WidgetResourceCollection`
  normally become `WidgetData` and `WidgetCollection`. Keep `Resource` when it is part of the
  domain name, such as `PrivateLinkResource`; this simplification does not apply to
  framework-owned types.
- **`Data` and `Collection` suffixes are reserved for the ARM resource trio.** `*Data` implies
  `ResourceData`/`TrackedResourceData` inheritance; `*Collection` implies `ArmCollection`
  inheritance. A handful of named domain terms are established exceptions —
  `MongoDBCollection`, `CosmosDBSqlCollection`, `CassandraCollection` — because they name a real
  collection/grouping concept from the service domain, not a resource collection. A plain
  settings/config/payload model named `*Data` or `*Collection` without the matching base
  misrepresents itself as resource-trio state.
- **Expand single-word and abbreviated names.** `AZC0012` only covers types — apply the same
  standard to public properties and parameters. Also expand abbreviations the analyzer never
  sees, on types *and* members: `auth` → `authentication`, `agentRef` → `agent`, `params` →
  `parameters`, `config` → `configuration`, `spec` → `specification`, `info`, `args`, `props`,
  `idx`. Highest-value case: a PR renames most of a type family to the expanded form
  (`ResponsesOpenApiAuthDetails` → `OpenApiAuthenticationDetails`) but misses one sibling
  (`OpenApiManagedAuthDetails`) or leaves the property/parameter carrying it abbreviated
  (`Auth`/`auth`). **Always check the whole family, not just the type in front of you.**
  Apply [H1](review-quality.md#h1--no-breaking-changes) before recommending further renames; a
  naming cleanup does not waive GA compatibility
- For a duration concept abbreviated `TTL`, prefer `TimeToLive` and apply the shared numeric-unit
  guidance rather than a universal unit suffix. A hop count is not a duration.
- **Parameter names must be consistent and descriptive within a scope** (all methods on a
  client, all public constructors + the model-factory method for a type, all overloads of a
  method).
  - The same concept must not be `id` on one method and `identifier` on another, or `agent` /
    `agentRef` / `agentReference` for the same type across one namespace.
  - A bare `id` alongside a qualified `fileId` is under-specified — say which id it is
    (`pathId`, `runId`, …).
  - **Numeric-suffixed public parameters (`id0`, `value1`) are always 🔴** — they're emitter
    collision artifacts leaking to the public surface, and they signal a real modeling problem
    (usually a `new`-shadowed base property forcing two same-named params into one signature).
    Check whether the un-suffixed twin is even used; often it is silently dead.
  - A **public** parameter named `internal*` is 🔴 — it names an implementation detail the
    caller can't reason about.
  - Cheap mechanical check: within one scope (one method's overloads, one client's methods,
    one type's constructors + factory), parse the checked-in `api/*.cs` listing and group
    that scope's parameters by CLR type — a type bound to more than one name is a candidate
    to look at, not a finding by itself. Different parameters of the same type in one
    signature (`string widgetName, string operationId`) are a normal, correct pattern; only
    escalate when the names actually name the same semantic concept.

Apply these to **new or renamed** public API only. Pre-existing names on untouched lines are out
of scope (see the changed-code scope in [review-quality.md](review-quality.md)) — but a name on a
line the PR is already changing, or inside a type the PR is already renaming, is fair game,
because that is the cheapest moment it will ever be fixed.
