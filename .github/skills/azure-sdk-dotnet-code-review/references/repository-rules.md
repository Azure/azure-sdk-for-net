# Azure SDK for .NET Repository Review Rules

Layered **on top of** `review-quality.md`. Where these conflict with general guidance, these
repository rules win. The hard rules in `review-quality.md` (no breaking changes and the .NET
Framework Design Guidelines) still apply unconditionally.

---

## Authoritative Guidelines — Always Consult

**Primary:** <https://azure.github.io/azure-sdk/dotnet_introduction.html>
— .NET Azure SDK Design Guidelines. This is the governing document for every PR in this repo.

Supporting documents, fetch when the diff touches their area:

| Area | Document |
|------|----------|
| Implementation (pipeline, policies, retries, logging, diagnostics) | <https://azure.github.io/azure-sdk/dotnet_implementation.html> |
| Language-independent SDK rules | <https://azure.github.io/azure-sdk/general_introduction.html> |
| Azure.Core requirements | <https://azure.github.io/azure-sdk/general_azurecore.html> |
| .NET Framework Design Guidelines | <https://aka.ms/fxdg3> |
| .NET breaking change rules | <https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/breaking-change-rules.md> |

**How to use them:** do not try to read a whole document. Identify which areas the diff
touches (client shape, models, LRO, paging, versioning, packaging, dependencies…), then fetch
the matching section and check against it. When the guidelines and this file disagree, the
published guidelines win — report the discrepancy so this file can be corrected.

Precedence within the guidelines themselves: **more specific beats more general**. .NET SDK
guidelines beat general Azure SDK guidelines; both are constrained by the .NET Framework
Design Guidelines.

The guidelines' design principles, in priority order: **Idiomatic, Consistent, Approachable,
Dependable.** Productivity is the primary value; completeness, extensibility, and performance
are secondary. Use this to break ties — an API that is smaller and more obvious beats one
that is more capable.

---

## Shared Configuration and Cross-Library Impact

Cross-cutting work is normal in this repository — a generator roll, a central package bump,
an analyzer rollout. It is not the reviewer's job to police what may be changed together.
It is the reviewer's job to notice when a change reaches past one library and to review it
on that basis.

- **Surface every change outside a single `sdk/<area>` and state its reach.** "This changes
  X for every library in the repo" is the useful observation; "this doesn't belong in your
  PR" is not. ℹ️ when the reach looks deliberate and correct, 🟡 when it is broader than the
  PR's stated purpose, 🔴 when one library's convenience degrades the others
- **A new file under `sdk/<area>` that silently overrides root configuration is the
  dangerous case** — nothing fails, CI stays green, and only review catches it. Ask whether
  the setting already exists at the root and what the local copy is diverging from. Applies
  to any such file, not a fixed list 🟡
- Standalone projects under the root `/samples` tree are exempt from the override rules —
  they are exported and built outside the repository, so carrying their own configuration
  is expected. Judge whether the content is genuinely needed standalone
- **Any csproj property that overrides a repo-wide default gets surfaced, with its
  justification.** `eng/Directory.Build.Common.props` sets these centrally so every library
  moves together; a local override opts one library out of that. Restating the central value
  verbatim (e.g. `<LangVersion>latest</LangVersion>`, already the default) is dead weight to
  delete. A *different* value is a decision — `LangVersion` `12` holds the library back from
  newer language features, `preview` opts into unstable ones. Raise every override and quote
  the stated reason so the human reviewer can judge it; no stated reason is itself the
  finding 🟡
- **`eng/common` is synced from `Azure/azure-sdk-tools` — its own README says so.** An edit
  made there is overwritten by the next sync, so the change is silently lost and the review
  that approved it was wasted. It belongs in `azure-sdk-tools` 🔴
- C# and PowerShell are the only languages the repository has tooling and process to keep
  safe and current. A script in another language, or a build entry point outside standard
  .NET tooling, adds a supply-chain surface with no owner and no freshness story 🟡
- A nested `.gitignore` must not restate a rule the root `.gitignore` already has. An
  unanchored root rule applies at every depth, so the duplicate does nothing except go stale
  when the root changes. Genuinely local entries are fine — duplicated ones are the finding.
  Standalone samples are exempt: they are consumed outside the repository, where the root
  file does not travel with them 🟡

---

## CODEOWNERS and Labels

- **A brand-new library directory gets no ownership validation at all.**
  `Test-CodeownersForArtifacts` explicitly skips "packages whose directory is brand new on
  the target branch", and the linter pipeline only triggers on PRs that touch
  `.github/CODEOWNERS` — so an onboarding PR that simply never adds an entry trips nothing,
  and the library ships with no reviewer and no issue-support routing. The remedy is *not* a
  hand-edit in the PR: the `Client Libraries` section is protected, and CI rejects changes to
  it from anyone but `azure-sdk-automation[bot]`. Point the author at the registration
  process at https://aka.ms/azsdk/codeowners 🟡
- **Ordering decides ownership: the last matching pattern wins, so a specific path placed
  above a broader one is dead.** The file's own header states the rule — less specific
  earlier, more specific later. `/sdk/foo/Azure.Foo.Core/` listed above a plain `/sdk/foo/`
  is silently overridden and its named owner owns nothing. No linter check and no baseline
  category covers ordering, so check every added path against the entries *below* it 🟡
- **Lines added to `.github/CODEOWNERS_baseline_errors.txt` are suppressed linter failures.**
  The linter regenerates a baseline from the target branch and filters only pre-existing
  errors, so a *new* violation still fails the build — which makes adding a line to this file
  the way to get one through. It already carries hundreds of suppressions, mostly invalid or
  non-public owner accounts. Treat an added entry as the finding and ask what real failure it
  is hiding 🟡

Owner account validity, team membership, public org visibility, and `PRLabel:` /
`ServiceLabel:` names are all validated by the codeowners linter against live GitHub data.
Do not re-check them by hand.

---

## Breaking Changes (repo-specific detection)

🔴 **Check the checked-in API listing files first.** Every shipping package has
`sdk/<service>/<Package>/api/<Package>.netstandard2.0.cs` plus per-TFM variants
(`.net8.0.cs`, `.net10.0.cs`, `.net462.cs`, `.net472.cs`).

- Any **removed or modified** line in these files is an API break → 🔴, no exceptions
- **Added** lines are additive and fine
- A PR that changes public API but does **not** update the api files has not run
  `dotnet build /t:GenerateApiListing` — flag it
- The public API must be **identical across all TFMs**. A member present in `.net8.0.cs` but
  not `.netstandard2.0.cs` is a violation

Also specific to this repo:
- Changing a `const` or a default parameter value on shipped API → binary break → 🔴
- `ServiceVersion` enum: values are explicit and start at 1, `0` is reserved and must throw
  `ArgumentException`. Never renumber or remove an existing member
- Model property type changes (including nullability of a value type) are breaks
- Changing the serialized JSON shape of a model is a wire break even when the C# API is
  unchanged

**ApiCompat baselines — `eng/apicompatbaselines/<Package>.xml`.** An entry here accepts a
real API diff, so it is a break being waved through.

- Surface every entry the PR adds, even ones you judge acceptable — the approve/reject call
  is the human reviewer's, and they cannot make it if they never see it. Quote the stated
  justification in the finding, or note its absence 🟡
- `ApiCompatVersionOptOut.txt` turns ApiCompat off for an entire package → 🔴
- A local baseline file next to the project is hard-blocked by
  `ValidateNoLocalApiCompatBaseline` — `ApiCompatBaseline.txt`,
  `ApiCompatBaseline.<tfm>.txt`, and `CompatibilitySuppressions.xml` all error out with a
  pointer to `eng/apicompatbaselines/<Project>.xml`. Seeing one is the finding

**Stale baseline entries.** The build sets `ApiCompatPermitUnnecessarySuppressions=true`, so
entries that no longer match a real diff accumulate silently and nothing will flag them.

- The file name is the package name → its `.csproj` → its `sdk/<area>`. Attribution is
  deterministic, unlike `ignore-links.txt`
- If the PR touches `sdk/<area>`, check only that area's baseline files, never another
  area's
- Build with `/p:ApiCompatPermitUnnecessarySuppressions=false` to have ApiCompat report
  which entries are unnecessary
- Pre-existing stale entries → ℹ️; entries the PR adds that are already unnecessary → 🟡

---

## Client Design

- Service clients are named `<Service>Client`, are **classes** (not structs), are
  **immutable**, and live in the package's root namespace
- Service methods are `public virtual` — non-virtual public methods block mocking → 🔴
- Every service method has both sync and async variants with matching signatures; the async
  one is suffixed `Async` and returns `Task<Response<T>>`/`Task<Response>`
- `CancellationToken cancellationToken = default` is the **last** parameter of every service
  method
- A `protected` parameterless constructor exists for mocking on clients **and** subclients
- Simplest constructor takes only what's needed to connect and uses **no default parameter
  values**
- Constructors must not read the client's own `virtual` properties — a mocked/uninitialized
  virtual can return the wrong value. Use the parameter or a local instead
- Options type is `<Client>Options : ClientOptions`, has **no default constructor**, and its
  constructor takes `ServiceVersion version` as the **first** parameter defaulting to the
  latest
- Subclients: no public constructor, created only via `Get<Resource>()` /
  `Get<Group>Client()` factory methods on a parent, reuse the parent's `HttpPipeline`
- Do not force callers to test `ServiceVersion` for feature availability — use the
  tester-doer pattern (`CanX` property) or `Nullable<T>`
- **Public interfaces are strongly discouraged and are generally rejected in architecture
  review.** An interface is a versioning liability: adding a member breaks every implementer.
  Use an abstract base class or a concrete type unless there is a stated reason the contract
  must be implementable by callers 🟡
- **Nullable reference type annotations belong to core libraries, not service libraries.** There
  is no central default, and only a small minority of projects opt in via `<Nullable>` — nearly
  all of them infrastructure: `Azure.Core`, `System.ClientModel`, `Azure.Provisioning`, the
  generators. A service library enabling it puts `?` annotations into a public contract the rest
  of the repo does not carry.
  This is about nullable *reference* types; `Nullable<T>` on a value type for feature detection
  is a separate, sanctioned pattern 🟡
- **Do not invent an exception type where a well-known built-in fits.** A custom cancellation
  exception instead of `OperationCanceledException`/`TaskCanceledException` forces callers to
  write Azure-specific catch blocks for a framework-standard condition 🟡
- **A library picks one client stack and uses its abstractions throughout.** New AI/Foundry
  libraries build on `System.ClientModel` rather than `Azure.Core`, because their surface
  overlaps the `OpenAI` types — and that choice carries into authentication: the SCM
  token-provider abstraction, not `TokenCredential`. **Name the parameter for the abstraction it
  actually takes** — a token provider called `credential` misdescribes its own type 🟡
- **Environment variables are not the mechanism to reach for** 🟡. A new setting should arrive
  through the `ClientSettings` pattern and the host's configuration, not
  `Environment.GetEnvironmentVariable`. `Azure.Identity` reads env vars extensively because that
  is what the SDK used to do — that is history, not a precedent to copy (see the changed-code
  scope in `review-quality.md`)
- **Configuration is public API surface, even though it never appears in an `api/*.cs` file.**
  A setting's name, section, type, and meaning are all things customers take a dependency on.
  Renaming, removing, retyping, or quietly changing the precedence of one is a breaking change
  and gets the same treatment as a signature change 🔴 — ApiCompat will not say a word about it
- **A `ClientSettings` type is the shape for all config/DI integration**, so the experience stays
  consistent across the Azure SDKs. The generator emits it for a generated client; a hand-written
  client has to supply it deliberately, and that is where it gets missed
- **Configuration ships with a schema, or it ships without IntelliSense** 🟡. A
  `ConfigurationSchema.json` — `schema/` at the package root when hand-authored,
  `src/Generated/schema/` when generated — is auto-packed for any shipping client library and
  drives `appsettings.json` completion in VS and VS Code. It is opt-in purely by file existence:
  nothing errors when it is absent, so review is the only gate. Nearly every package exposing a
  `*ClientSettings` type ships one, and the few that do not are hand-authored integrations. Only
  one of the two locations should exist

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
  project-wide suppression of six diagnostics at once → 🔴 on the ladder.

- **`Url` → `Uri`, and the type is `Uri`** — no public member or parameter contains `Url`; it's
  always `Uri`. A member that holds an absolute address is typed `System.Uri`, not `string`.
  Watch for `string`-typed members whose *name* betrays a URI (`*Link`, `*Endpoint`,
  `*Address`, `*Uri`) — those are the same bug wearing a different name. A `string` shadow of a
  `Uri` property (public `internalConsentLink` parameter next to `Uri ConsentLink`) is 🔴.
- **`DateTimeOffset` members end in `On` — except under `sdk/ai`, where they end in `At`.**
  `StartTime` → `StartedOn` repo-wide, `StartedAt` under `sdk/ai`. Prefer the past-participle
  verb form (`Created`/`Updated`/`Started`/`Expires`), not the noun (`CreationOn`). Applies to
  public properties and parameters. Never use `DateTime` on the public surface.
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
- **`Resource` suffix is reserved for `ArmResource`-derived types.** A data model, options bag,
  or client named `*Resource` in a non-`Azure.ResourceManager.*` package is wrong. Third-party
  `*Resource` types being *consumed* (e.g. `OpenAI.Conversations.ConversationResource`) are not
  a finding.
- **Expand single-word and abbreviated names.** `AZC0012` only covers types — apply the same
  standard to public properties and parameters. Also expand abbreviations the analyzer never
  sees, on types *and* members: `auth` → `authentication`, `agentRef` → `agent`, `params` →
  `parameters`, `config` → `configuration`, `spec` → `specification`, `info`, `args`, `props`,
  `idx`. Highest-value case: a PR renames most of a type family to the expanded form
  (`ResponsesOpenApiAuthDetails` → `OpenApiAuthenticationDetails`) but misses one sibling
  (`OpenApiManagedAuthDetails`) or leaves the property/parameter carrying it abbreviated
  (`Auth`/`auth`). The rename is already a break, so finishing it costs nothing now and costs
  another break later. **Always check the whole family, not just the type in front of you.**
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
  - Cheap mechanical check: parse the checked-in `api/*.cs` listing, group parameters by type,
    and flag any type bound to more than one parameter name.

Apply these to **new or renamed** public API only. Pre-existing names on untouched lines are out
of scope (see the changed-code scope in `review-quality.md`) — but a name on a line the PR is
already changing, or inside a type the PR is already renaming, is fair game, because that is the
cheapest moment it will ever be fixed.

## Analyzer Warnings and Suppressions

**Fixing the warning is the expected outcome. A suppression is a last resort, and accepting one
is a judgment call that belongs to the human reviewer — not to the author, and not to this
skill.** Be critical of every one.

**Scope: only suppressions on lines the PR adds or modifies.** The changed-code scope in
`review-quality.md` applies normally — do not mine existing suppressions in untouched code. A
modified line that *widens* an existing suppression (scoped → whole-assembly, or a new code
appended to an existing entry) is in scope.

For every suppression in scope, **report it for human judgment**. Never silently accept one.

**Read `eng/analyzerallowlist/README.md` before commenting.** It is authoritative for the current
mechanism and its enforcement is tightening over time. Do not assert from memory whether
`<NoWarn>`, `#pragma warning disable`, or `[SuppressMessage]` is permitted — the answer changes.

Ask for the highest rung the author can reach:

1. **Fix the warning.** Always propose this first, and say concretely how.
2. **Narrow the code** so the diagnostic stops firing — correct `[Experimental]` attribution, a
   tighter type, the right overload.
3. **Scoped allow-list entry** — `nowarn:CODE T:Full.Type.Name` in
   `eng/analyzerallowlist/<Project>.txt`, with a justification comment directly above it → 🟡
4. **Whole-assembly entry** — a bare `nowarn:CODE` → 🔴. It silences the diagnostic across the
   assembly forever, including for types that do not exist yet.

**Ownership gates — a diff touching any of these is automatically a finding.** Each of these
paths carries a CODEOWNERS entry assigning it to the central .NET core team rather than to the
service team, precisely to force this review; they compel a look, they do not reject anything.
Check `.github/CODEOWNERS` for the current owners before naming anyone.

- `/eng/analyzerallowlist/`
- `/*` — includes the root `.editorconfig`
- `/sdk/**/.editorconfig`
- `/.vscode/` — includes `.vscode/cspell.json`

- **A project- or service-level `.editorconfig` is not allowed** — align with the repository root
  config instead. Any pre-existing instance that survives under `sdk/` is not precedent.
- A `dotnet_diagnostic.<CODE>.severity = none|suggestion` downgrade in any `.editorconfig` is a
  suppression by another name. Same ladder, same scrutiny.

**Test projects.** `eng/NoWarnValidation.targets` gates on `'$(IsShippingClientLibrary)' == 'true'`,
so test projects carry **no build enforcement at all** — review is the only gate, which makes this
more important there, not less. The sanctioned baseline is what `sdk/template/Azure.Template/tests`
ships: **`CS1591` only**. Any other project-wide code in a test project's `<NoWarn>` gets raised.

**What actually runs here.** `Microsoft.CodeAnalysis.NetAnalyzers` is referenced only when
`IsShippingClientLibrary` is true, and the repo sets no `AnalysisLevel` or `AnalysisMode`, and no
`.editorconfig` anywhere sets a `dotnet_diagnostic.CA*` severity — so `CA` rules run at the
package's stock default severities, on shipping libraries only. Three consequences:

- **Test projects get no analyzers at all.** `EnableClientSdkAnalyzers`,
  `EnableMicrosoftCodeAnalysisNetAnalyzers`, and `EnableBannedApiAnalyzers` are all gated on the
  same `IsShippingClientLibrary` condition — the same gap `NoWarnValidation.targets` leaves,
  approached from the other side.
- **`CA` diagnostics are real diagnostics here.** The default set fires and is widely suppressed
  in this repo. A `#pragma warning disable CA…` is a suppression and takes the same ladder above
  as an `AZC` code — including `CA5351`/`CA5394`, which do fire.
- **Taint/dataflow rules never run.** `CA3003` (file-path injection) and its `CA3xxx` siblings
  are not enabled by default, nothing here opts them in, and the repo contains zero references
  to them. CodeQL would cover some of this but is wired only to the internal build, never to
  public PR validation. So for untrusted input reaching a path, a URL, a process invocation, or
  a deserializer, **review is the only gate** — see Correctness and Security in the global rules.

**A spelling dictionary entry is a suppression too.** Adding a word makes a warning go away; the
only question is whether the word is right. Two failure modes matter:

- **A word added to silence a misspelling in a public API name, a parameter, or a doc comment
  that ships.** The typo then becomes permanent and customer-visible. Read what the word actually
  is before accepting it 🔴. CI will not catch this: the spell check runs on changed files only
  and is configured to warn rather than fail (`ContinueOnError` defaults to `true` and `ci.yml`
  does not override it), and `eng/scripts/spell-check-public-api.ps1` — the one thing that scans
  `api/*.cs` — is wired as the cspell upgrade validator, so it runs only when cspell's
  `package-lock.json` changes
- **A word added in the wrong place.** New words belong in `sdk/<service>/cspell.yaml`, which
  `import`s `../../.vscode/cspell.json` and scopes its words with an `overrides.filename` glob.
  Root `.vscode/cspell.json` is CODEOWNERS-gated; move the entry into the service file unless the
  word is genuinely repo-wide 🟡. A package-level `cspell.json` is not the convention — a handful
  survive under `sdk/`, none with an `import` field, and they are not precedent

**Trim/AOT suppressions are a sharper case than the ladder above.**
`[UnconditionalSuppressMessage]` is the only suppression form that survives into the compiled
assembly — `#pragma warning disable` and `[SuppressMessage]` are stripped, and the trimmer,
which operates on compiled assemblies, never sees them. That is why trim warnings require this
attribute, and it is also what makes it dangerous: it silences ILLink/ILC at *publish* time, so
it silences `eng/scripts/compatibility/Check-AOT-Compatibility.ps1` — the PR gate that would
otherwise catch the problem. A wrong one fails nothing in CI; it ships and surfaces as a
runtime failure inside a customer's trimmed or native-AOT app.

- **A newly added `[UnconditionalSuppressMessage]` is a finding** 🔴. The escalation order here
  is not the allow-list ladder: eliminate the reflection → annotate with
  `DynamicallyAccessedMembers` → mark the path `RequiresUnreferencedCode` /
  `RequiresDynamicCode` **and ship an AOT-safe alternative** → suppress last.
  `doc/dev/AotCompatibility.md` is repo-authoritative and unusually blunt — suppression "masks
  real compatibility issues," "should be avoided," and "is rarely the right approach." Quote it
  rather than arguing the point yourself
- A `Justification` has to establish why the code is *provably* safe — members pinned by
  `DynamicDependency`, or a path unreachable once trimmed. Restating the rule name, or "false
  positive," is not a justification 🟡
- Scope it to the smallest artifact. The documented pattern is a local function wrapping the
  one offending call; on a whole class or a broad method it also silences warnings that do not
  exist yet 🟡
- `<AotCompatOptOut>true</AotCompatOptOut>` disables the analyzers **and** the CI check for the
  entire library; `<AotAnalyzersOptOut>true</AotAnalyzersOptOut>` keeps CI but blinds the
  author. Either appearing in a diff is a finding 🔴
- Baselining AOT warnings is deliberately restricted to `sdk/core/` — the check script builds
  the `ExpectedAotWarnings.txt` path by hardcoding that directory, so the same file added under
  any other package is inert. A non-core library cannot baseline its way out
- The AOT defaults are set only when `IsShippingLibrary` is true, so non-shipping projects get
  no trim analysis at all — the same gap as the analyzer gate above, one property name over

**Cite the consequence, not the rule number.** A suppression argument is won on what the warning
protects against. Example: `AZC0150` means a `ModelReaderWriter.Read`/`Write` call is missing its
`ModelReaderWriterContext` overload, so the library falls back to the reflection path and is no
longer AOT/trim-safe — the fix is the context overload with a wired-up generated context.
Diagnostics from the out-of-repo `Azure.ClientSdk.Analyzers` (`AZC0100`+, `AZC0150`) are reviewed
manually; that is the intended reading of the in-repo-analyzer rule above, not an exception to it.
**Severity always comes from the ladder**, never from which code it is.

## Implementation

- All calls to Azure REST services go through `HttpPipeline` from `Azure.Core`. Hand-rolled
  `HttpClient` usage in a client library → 🔴
- Failed service calls throw `RequestFailedException` (or a derived type), never a generic
  exception
- LROs return `Operation<T>`/`Operation`; long-starting LRO methods are prefixed `Start`
- Paging methods return `Pageable<T>`/`AsyncPageable<T>` and are named `Get<Resource>s`
- Model factories: `<Namespace>ModelFactory` static class for constructing otherwise
  read-only models in tests; new optional parameters go on a new overload, with the old one
  marked `[EditorBrowsable(EditorBrowsableState.Never)]`
- Diagnostics scopes and distributed tracing follow the pipeline conventions; do not log
  secrets, credentials, or PII
- `HashCode` does not exist on `netstandard2.0`, so a client library cannot call
  `HashCode.Combine` directly. The repo's answer is the shared source file, linked as
  `<Compile Include="$(AzureCoreSharedSources)HashCodeBuilder.cs" LinkBase="Shared\Core" />`,
  which exposes the same `Combine` overloads. A new hand-rolled hash — or dropping
  `netstandard2.0` to reach the BCL type — is the wrong fix 🟡

## Testing

- **A new library needs live tests, a `tests.yml` pipeline definition, and a
  test-resources template — all three.** They only work in combination: a
  `test-resources.json` with no live tests behind it provisions infrastructure nothing
  exercises, and live tests with no `tests.yml` never run. If the service does not exist
  yet, a time-boxed exception needs an issue on file with a committed date, after which
  releases block → 🔴
- **Match the test framework to the client stack.** A library built on
  `System.ClientModel` uses `Microsoft.ClientModel.TestFramework`; one built on
  `Azure.Core` uses `Azure.Core.TestFramework`. Reaching across loses record/playback
  alignment with sibling libraries and drags the wrong stack into the test surface. Each
  framework's `README.md` under `sdk/core` is the reference → 🟡
- **Tests that never run in CI are not tests.** A new project that only runs on a
  developer's machine, or cases marked so the matrix skips them, needs a stated reason.
  CI plus nightly against the full target matrix is where the claim actually gets made 🟡

## Packaging, Versioning, Dependencies

- Assembly name, root namespace, and NuGet package id all match
- Version bumps: patch for bug fixes only — **no new public API in a patch release**; minor
  or major for new API or a new service API version. `CHANGELOG.md` must be updated in the
  same PR
- Dependencies limited to `Azure.*` from this repo, `System.*` from the .NET team,
  Architecture-Board-approved `Microsoft.*`, and your own team's packages. Anything else →
  🔴 and needs Architecture Board approval. `Newtonsoft.Json` is not allowed — use
  `System.Text.Json`
- Do not publicly expose types from dependencies unless those types also follow these
  guidelines
- No native dependencies

**A library added from the template carries placeholder content that builds cleanly.**
Nothing fails, so the only thing standing between a placeholder and a published package is
review.

- **A library's first `<Version>` is a prerelease.** A new package introduced at a stable
  `1.0.0` skips the beta period that exists to let its public surface change without a
  breaking-change process. If nothing is published under that package id yet, the version in
  the PR should carry a `-beta.N` suffix 🟡. The changelog heading is already forced to match
  `<Version>` at build time by the `ValidateReleaseNotes` target, so the csproj version is the
  only part left to judge
- **`<Description>` and `<AssemblyTitle>` are customer-facing** — the description is what
  renders on the package's nuget.org page. The template ships `Azure Widget Analytics client
  library for .NET`; a library still carrying that text, or a description auto-generated from
  the service spec that reads as machine output, publishes it to customers 🟡
- **`Microsoft.Template` in an `AssemblyInfo.cs` is template content that shipped** 🔴. The
  template's own comment says to replace the value "and uncomment", but the attribute is
  already uncommented — so a library that never touched the file still declares
  `[assembly: AzureResourceProviderNamespace("Microsoft.Template")]` and nothing fails.
  `ClientDiagnostics` reflects this value onto every distributed-tracing span as
  `az.namespace`, so the service is mis-attributed in customer telemetry. The fix is the
  service's real resource-provider namespace, not deleting the line — data-plane libraries
  carry it too (`Azure.Search.Documents` → `Microsoft.Search`), and a sibling library in the
  same `sdk/<service>/` directory usually already has the right value

**A shipping library has no `.nuspec` — its `PackageReference` items *are* the package's
declared dependency list.** Every direct reference in a `src` project becomes a version
floor customers must satisfy and a node in their restore graph.

- **A package already reaching you transitively does not need a direct reference.** Adding
  one publishes a dependency edge that buys customers nothing and freezes an implementation
  detail of the package you actually depend on into your own contract — you now can't drop
  it when the package below you does. Nothing in the build catches this, so it is on the
  reviewer: ask what the direct reference is for 🟡
- Wanting a newer version is not the reason. The version resolves from
  `eng/centralpackagemanagement` either way, so a direct reference changes the published
  contract without changing the version. That belongs in a per-package override file
- A dependency that should never reach customers — analyzers, source generators, build-time
  tooling — needs `PrivateAssets="all"`. Without it, it ships as a real dependency 🟡
- 🟡 A `src` project taking a `ProjectReference` on a shipping library **in a different
  `sdk/<service>/` directory** couples two independent release trains — the package cannot
  publish until the referenced one does, and it builds against code no customer can consume
  yet. Use a `PackageReference` instead. Not a finding: references within a single service
  directory (`Azure.Storage.Blobs` → `Azure.Storage.Common`), which are the convention and
  become ordinary package dependencies at pack time; and generator references carrying
  `ReferenceOutputAssembly="false"` with `PackAsAnalyzer="true"`, which bundle a DLL rather
  than declare a dependency

**Target frameworks follow from the project's name — they are not authored.**
`eng/Directory.Build.Common.props` classifies every project by naming convention, and that
classification selects `SupportsNetStandard20`, then `RequiredTargetFrameworks`, then
`TargetFrameworks`. Every classification is conditioned on the property being empty, so the
convention is the default and anything explicit overrides it.

| Name pattern | Classification |
|---|---|
| starts with `Azure.` | `IsClientLibrary`, which implies `SupportsNetStandard20` |
| starts with `Azure.Generator` | `IsGeneratorLibrary` |
| ends with `.SourceGeneration` / `Analyzers` | Roslyn component |
| ends with `.Tests` / `.Samples` / `.Perf` / `.Stress` | Runnable project |
| path contains `/tests/` | `IsTestSupportProject` |

- **An explicitly declared type switch means the project's name does not match what the
  project is.** The naming convention is the mechanism; declaring the type is the escape
  hatch. Surface it and ask whether renaming the project is the better fix. It is sometimes
  genuinely unavoidable — `Microsoft.Azure.Core.NewtonsoftJson` is a client library that
  cannot be named `Azure.*` — so this is a question for the human reviewer, not an automatic
  rejection 🟡
- A declaration only takes effect above the `<Import>` that chains to the parent
  `Directory.Build.props`. Below that import, or in the csproj body, the common props has
  already chosen the target frameworks, so the switch silently fails to move them — while
  `.targets`-time consumers do see it, leaving the project inconsistent with itself 🟡
- **Surface every change the PR makes to `TargetFrameworks` or `RequiredTargetFrameworks`,
  including an append.** These are derived; setting one directly says the classification is
  wrong. An append such as `$(RequiredTargetFrameworks);netstandard2.1` is narrower than a
  replacement but is still a deliberate divergence. Raise both and let the human reviewer
  judge 🟡
- Literal target-framework lists, and conditions testing `'$(TargetFramework)' == 'net8.0'`,
  must be hand-updated every time repository targets move. Use the property, and
  `$([MSBuild]::IsTargetFrameworkCompatible(...))` for conditions 🟡

**Package feeds — `NuGet.Config` / `nuget.config`.** NuGet merges configuration up the
directory tree, so a nested file silently changes restore for everything beneath it. Judge
the content, not whether the file exists.

- A private or internal feed → 🔴. It fails for non-Microsoft contributors, and packages in
  Microsoft-owned repositories must come from approved sources. The public azure-sdk dev
  feed is the sanctioned way to consume prerelease bits
- An added feed with no `<packageSourceMapping>` restricting it to specific package
  patterns → 🟡, a package-substitution risk
- A standalone sample without `<clear />` does not restore identically outside the
  repository 🟡
- An added feed with no stated condition for its removal 🟡

**Changes to central package entries — `eng/centralpackagemanagement`.** `NU1010` blocks
referencing a package that has no central entry, so the PR editing these files is where the
dependency decision actually gets made — and the only place review can catch it.

- **A version change should land on the latest stable release.** Anything older needs a
  stated reason — a known regression, a downstream conflict, a framework floor. Without one
  the next person has to rediscover it, and the reviewer is left checking currency by hand 🟡
- **A new entry is a new dependency for the entire repository.** Check that it still earns
  its place on every framework the consuming libraries target: as the BCL grows, a package
  that once filled a gap starts colliding with it. `System.Linq.Async` against .NET 10's
  built-in `System.Linq.AsyncEnumerable` is the current example — duplicate extension
  methods, ambiguous-call compile errors 🟡
- **Which central file an entry lands in decides which projects can see it.** The support,
  integration, legacy, extensions, and generation files scope their entries by condition —
  test and sample packages are invisible to shipping libraries, which is why a library
  referencing a test package fails to restore. Putting a test-only package in the general
  file instead silently makes it an approved dependency for published packages. Each file
  states its own admission criteria in a header comment; check the entry against it 🟡

**Central package management overrides —
`eng/centralpackagemanagement/overrides/<Package>.Packages.props`.** Treat these like
analyzer suppressions: the expected outcome is using the repo-standard central version.

- The default position is *don't*. A version the whole repo shares is worth more than a
  local pin
- Surface every override the PR adds, even ones you judge acceptable, and quote the stated
  justification so it can be evaluated. No justification, or one with no removal condition
  — "nobody can say when this goes away" — is itself the finding 🟡
- A prerelease or alpha pin escalates; a stable library cannot ship on one
- Placement is decided by scope, not duration: a package-specific exception stays in that
  package's override file however long it lives. The central files are for versions the
  repo shares. The same override repeated across several package files is the signal that
  it belongs centrally

**A package going GA — `<Version>` losing its `-beta` / `-alpha` / `-preview` suffix.**

- When a PR flips a version to stable, resolve every dependency that project actually uses —
  the central entries it consumes plus its `overrides/<Package>.Packages.props` file — and
  confirm none is a prerelease. A stable package cannot ship on one 🔴
- This is a deliberate exception to reviewing only what the diff touches. The prerelease pin
  will usually be older than the PR and untouched by it; the GA flip is what changed its
  status, so raise it and say that is why
- **A prerelease dependency in a prerelease library is correct and expected** — `-beta`
  depending on `-beta` is the normal pattern; do not flag it. The violation is only ever a
  *stable* library resolving to a prerelease. That arises two ways: the version flipping to
  GA (above), or a prerelease `PackageReference` added to an already-stable library 🔴
- **Do not treat a green build as proof for the package half of this.** The repo has a guard
  for exactly this scenario — `VerifyProjectReferencesReferences` in
  `eng/Directory.Build.Common.targets`, which runs only when the version is stable and the
  project is packable — but it reads `%(PackageReference.Version)`, and under Central Package
  Management that metadata is empty on every centrally-managed package, so the test never
  matches. NuGet passes `PackageReference` and `PackageVersion` into the restore graph as
  separate items and never merges the version back. The `ProjectReference` half still works.
  Resolve package versions from the central file yourself

## Commonly Overlooked (the guidelines' own list)

Check these on every API-surface PR:

- ⚠️ Too many types in the main namespace — type count drives perceived complexity
- ⛔ Abstractions (interface **or** abstract class) that the SDK does not both return and
  consume
- ⛔ Interfaces where an abstract class would do — interfaces are only justified by multiple
  inheritance or struct implementers
- ⛔ Generic/vague type names (`OperationResponse`, `DataCollection`)
- ⚠️ Parameter types where the valid values aren't obvious — e.g. a `string` that only
  accepts certain values
- ⛔ Empty types

## Docs & Samples

- Every public and protected type and member has XML doc comments
- Package root has a consumer-focused `README.md`; contributor content goes in
  `CONTRIBUTING.md`. "Azure SDK" names the whole collection of packages — an individual
  package is a "client library," which is what the CI-enforced README title asserts
- **README presence and shape are CI-enforced; the opt-out is the reviewable action.**
  `eng/.docsettings.yml` drives DocWarden over every package README — title, and the
  required `Getting started`, `Key concepts`, `Examples`, `Troubleshooting`,
  `Next steps`, `Contributing` sections. A PR adding its package to
  `known_presence_issues` or `known_content_issues` is opting out of all of it, and
  earns the same scrutiny as a suppression → 🔴

"Sample" means two different things here. Decide which one a change is before
reviewing it.

**Snippet samples** — a fragment the customer pastes into their own larger codebase.
They live inline in markdown: `samples/*.md`, a package `README.md`, or any other doc.

- Every C# fence in markdown is backed by real compiled source, via
  `#region Snippet:<UniqueName>` in a `.cs` file and a ` ```C# Snippet:<UniqueName> `
  fence in the markdown. Snippet names are unique repo-wide
- A C# fence with no `Snippet:` tag is the thing to catch. CI regenerates tagged
  snippets and fails on any diff, so a tagged snippet cannot be stale — an untagged
  fence is invisible to that tooling and rots silently → 🟡. Code that cannot compile
  against the current library — migration before/after, illustrative fragments in
  contributor docs — is the genuine exception
- Library snippet sources live in `tests/Samples/*.cs`; the markdown showing them is
  numbered `Sample<N>_*.md`, simplest → most complex, sync and async alongside each
  other. `sdk/template/Azure.Template` is the reference layout

**Standalone samples** — a complete project the customer copies wholesale. These live
in the repo-root `/samples/<area>` tree and are validated by building the folder, not
by snippet tooling.

- Self-contained by construction: `/samples` sets `ImportRepoCommonSettings=false` and
  `ManagePackageVersionsCentrally=false`, redirecting `DirectoryPackagesPropsPath` at an
  empty file to block the repo's central versions. Inline `Version=` on
  `PackageReference` is therefore required here — the opposite of the rule in `src`
- Nothing may tie the folder to this repo: no `ProjectReference` reaching into `sdk/`,
  no reliance on repo `eng/` infrastructure, no relative links escaping the sample. The
  test is whether the folder still builds once copied out → 🔴
- Each sample's `README.md` opens with MS Learn YAML front matter
- A runnable console or web project under `sdk/<area>/<Package>/samples/` is in neither
  category — either it's a snippet sample and belongs in markdown, or it's standalone
  and belongs in `/samples` → 🟡

## Broken-Link Ignores (`eng/ignore-links.txt`)

An entry is only correct when the link is right and the world is wrong.

**Entries the PR adds or modifies.**

- **In-repo links never need an entry.** `Verify-Links.ps1` resolves
  `https://github.com/Azure/<repo>/blob|tree/<branch>/<path>` against the local clone.
  A failure means the path is wrong — fix the link. 🟡
- **Links that already resolve are dead weight.** Verify with `GET`, never `HEAD` —
  nuget.org returns 404 to `HEAD` for packages that plainly exist. 🟡
- **Only 400, 404, 11001, 11004 and -131073 count as failures.** An entry added because a
  link returned 403, 500, or timed out is unnecessary. 🟡
- Legitimate: right link, unreachable world — package not yet published, path not yet on
  `main`, private repo, deliberately fake sample URL.
- Every entry needs an end state: a comment giving either the removal trigger ("remove
  when X ships") or why it is permanent ("private repo", "fabricated URL"). "Nobody can
  say when this goes away" is the finding. 🟡

**Re-verifying pre-existing entries — narrow changed-code-scope exception.**

Every entry has an owning area. Attribute it from the URL — package name, doc namespace,
or in-repo path. Entries that map to no service directory are owned by `sdk/core`.

- If the PR touches `sdk/<area>`, re-verify only the entries owned by that area and report
  any that now resolve as removable. ℹ️
- Never check entries owned by another area. A Storage PR does not carry Event Grid's
  cleanup, and editing the file does not make every entry in it yours.
- Skip entries whose comment marks them permanent.

## Generated Code

- Do not hand-edit generated files. Changes to generated output belong in the
  TypeSpec/Swagger input or in `Customization`/partial-class files
- Autorest/TypeSpec config changes (`tspconfig.yaml`, `autorest.md`) should be accompanied by
  regenerated output in the same PR
- **TypeSpec source belongs in `Azure/azure-rest-api-specs`, not in this repository.** One
  artifact describes the service for every language; a copy checked in under `sdk/` forks that
  contract and starts drifting immediately. A `.tsp` file added under `sdk/` is a deliberate
  departure from that model — question it 🟡
- **`tsp-location.yaml` must name `Azure/azure-rest-api-specs` and a commit on `main`, and
  nothing checks this until GA** 🟡. `Verify-RestApiSpecLocation.ps1` runs only in the release
  pipeline and returns early for any prerelease version, so a `repo:` pointing at a personal
  fork survives the entire beta lifecycle — several libraries carry one. By GA that fork may
  be deleted or rewritten, leaving the library unregenerable from its stated source. Treat a
  renamed file (`_tsp-location.yaml`) the same way: it silently opts the library out of
  regeneration instead of recording why
- **Shaping generated output has designated mechanisms — reach for those before anything
  else.** `[CodeGenType]`, `[CodeGenModel]`, `[CodeGenMember]`, `[CodeGenSuppress]`, and
  `[CodeGenSerialization]` in a partial-class or stubs file are how a library renames,
  replaces, or stops generating a member; each is used in hundreds of libraries. Excluding a
  file from compilation, suppressing the resulting warning, or editing emitter config to get
  the same effect works until the next regeneration and hides the intent from whoever runs it 🟡
