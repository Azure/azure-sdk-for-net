# Review Quality and General Rules

<!-- § anchors are shared permalinks: never rename or reuse one, and give each new rule a unique name using its section's prefix. -->

These rules augment the review agent's normal open-ended analysis. They are minimum checks, not
an exhaustive checklist. Continue looking for bugs, security issues, correctness failures,
reliability problems, concurrency hazards, resource leaks, test gaps, and maintainability or
performance regressions that are not named here.

## Scope and Evidence

- <a name="scope-changed-code" href="#scope-changed-code">§</a> Review code added or modified by the change and regressions directly caused by it. Do not mine
  unrelated, unchanged code. A severe correctness, security, or breaking-change issue may be
  reported when the changed code exposes or depends on it; explain that connection.
- <a name="scope-prior-discussion" href="#scope-prior-discussion">§</a> Read the pull request description, linked issues, existing review comments, and resolved or
  outdated threads before commenting. Do not duplicate a finding that has already been raised or
  relitigate an explicitly settled decision without new evidence.
- <a name="scope-local-convention" href="#scope-local-convention">§</a> Read enough surrounding code and repository configuration to establish the local convention.
  A diff hunk alone is not sufficient evidence.
- <a name="scope-evidence" href="#scope-evidence">§</a> Every finding must identify direct evidence, a concrete consequence, and a recommended
  correction. If any of those is missing, omit the finding.
- <a name="scope-exceptions" href="#scope-exceptions">§</a> Check documented exceptions and allowed cases before reporting a rule violation. Try to
  disprove each candidate finding.
- <a name="scope-ci-diagnostics" href="#scope-ci-diagnostics">§</a> Do not repeat diagnostics that normal CI or analyzers will already report unless the change
  adds or widens an opt-out, suppression, baseline, allow-list entry, or other way around the
  enforcement.
- <a name="scope-prefer-silence" href="#scope-prefer-silence">§</a> Prefer silence over generic advice, speculative concerns, style preferences, or observations
  that do not ask the author to change anything.

## Hard Rules

These are not judgment calls. A violation is always 🔴.

### H1 — No breaking changes

**Always report** a concrete incompatibility with a GA-shipped contract.

<a name="h1-ga-only" href="#h1-ga-only">§</a> **All breaking-change checks apply only to APIs and observable contracts that have shipped in a
GA (stable) release, evaluated individually.** A package, enclosing type, or neighboring member
having shipped GA does not establish that this API has; a preview candidate does not undo an
API's GA history. Protect the API's GA contract, not every subsequent preview-only shape.

API additions, edits, removals, and renames are not findings by themselves. Beta-only and
never-shipped contracts may change. Continue checking changed APIs against other applicable
design, correctness, and repository rules.

<a name="h1-classification" href="#h1-classification">§</a> For an established GA contract, classify by what changed and how it manifests. Use
[dotnet/runtime's breaking-change rules](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/breaking-change-rules.md)
as the authoritative source for what qualifies in each category and why — it covers both
source/binary-compatibility changes and behavioral changes. Do not re-derive examples from
memory; consult it for borderline cases.

<a name="h1-api-breaking" href="#h1-api-breaking">§</a> **API-breaking — never permitted in any release (major, minor, or patch).**
Existing code fails to compile or bind.

<a name="h1-binary-breaking" href="#h1-binary-breaking">§</a> **Binary-breaking — never permitted in minor or patch releases.**
Public API shape is unchanged but pre-compiled callers break or silently misbehave.

<a name="h1-source-breaking" href="#h1-source-breaking">§</a> **Source-breaking — major release only, with documented justification.**
API only grew, but recompiling existing source resolves differently or fails.

<a name="h1-behavioral-breaks" href="#h1-behavioral-breaks">§</a> **Behavioral breaks count too.** Same signature, different observable behavior is a break.
The one explicitly required exception: bumping a GA client options constructor's
`ServiceVersion` default to the latest supported service version (see
[Client Design](repository-rules.md#client-options)) is not a finding.

**How to check:**
- <a name="h1-establish-ga-contract" href="#h1-establish-ga-contract">§</a> Establish each affected API's GA contract using released reference assemblies or
  release-tagged source. If release history is unavailable, state the limitation; do not turn
  an API diff or uncertainty alone into a finding.
- <a name="h1-compare-against-ga" href="#h1-compare-against-ga">§</a> Diff the public surface and implementation, and compare the changed behavior or signature
  against that GA contract. Checked-in API listings locate candidate changes; their presence,
  additions, removals, or edits do not establish release history or incompatibility.
- <a name="h1-caller-effects" href="#h1-caller-effects">§</a> Check actual effects on GA callers even when their API is unchanged: a new overload can
  alter resolution at an existing call site. Conversely, editing a preview-only shape to
  restore the GA contract is not a break merely because the listing changed.
- <a name="h1-preserve-ga-api" href="#h1-preserve-ga-api">§</a> For an actual GA incompatibility, recommend preserving the GA API and behavior, adding a
  compatible API alongside it when needed. Do not require aliases or overloads solely to
  preserve beta-only or never-shipped contracts.

### H2 — Follow the .NET Framework Design Guidelines

Reference: <https://learn.microsoft.com/dotnet/standard/design-guidelines/>

Apply them as written. The checks below are the ones most often missed — they are a starting
point, not the full set. Consult the source document when the diff touches an area not
listed here.

**Naming**

Apply the [hard naming checks](naming-rules.md#framework-design-guideline-naming--hard-rules),
including enum naming, along with the Framework Design Guidelines as written.

**Type design**
- <a name="fdg-prefer-classes" href="#fdg-prefer-classes">§</a> Prefer classes over interfaces. **Do not introduce an interface** unless you need multiple
  inheritance or structs must implement it — use an abstract class instead
- <a name="fdg-abstractions" href="#fdg-abstractions">§</a> Do not introduce an abstraction (interface or abstract class) unless the API both **returns
  and consumes** it
- <a name="fdg-empty-types" href="#fdg-empty-types">§</a> No empty types (types with no members)
- <a name="fdg-structs" href="#fdg-structs">§</a> Structs only for small, immutable, value-semantic data; must have a meaningful default
  (all-zero) state
- <a name="fdg-sealed-types" href="#fdg-sealed-types">§</a> Prefer sealed by default for new types not designed for inheritance; document the extension
  points you do allow
- <a name="fdg-immutability" href="#fdg-immutability">§</a> Prefer immutability for types shared across threads

**Members**
- <a name="fdg-properties-vs-methods" href="#fdg-properties-vs-methods">§</a> Properties for logical data, methods for actions. Properties must not throw for simple
  gets, must not be order-dependent, and must be cheap
- <a name="fdg-ref-out-parameters" href="#fdg-ref-out-parameters">§</a> No `ref`/`out` in public APIs unless implementing `Try*`
- <a name="fdg-optional-overloads" href="#fdg-optional-overloads">§</a> Do not add a new overload that differs from an existing one only by optionality — it's an
  ambiguous, confusing overload set for callers. Giving an already-shipped parameter a default
  value is not this (it's an additive change, not a new overload) and is not a finding by
  itself; flag it only under H1, and only with concrete evidence that it breaks overload
  resolution at an existing call site
- <a name="fdg-argument-validation" href="#fdg-argument-validation">§</a> Validate all public/protected inputs and throw the right exception:
  `ArgumentNullException` / `ArgumentException` / `ArgumentOutOfRangeException` with the
  correct `paramName`
- <a name="fdg-invalid-operation" href="#fdg-invalid-operation">§</a> Throw `InvalidOperationException` for wrong-state, not `ArgumentException`
- <a name="fdg-reserved-exceptions" href="#fdg-reserved-exceptions">§</a> Never throw `Exception`, `SystemException`, `ApplicationException`, or
  `NullReferenceException`/`IndexOutOfRangeException` directly
- <a name="fdg-custom-exceptions" href="#fdg-custom-exceptions">§</a> Do not introduce a custom exception type when a BCL type already means the same thing —
  cancellation is `OperationCanceledException`. A new exception type has to carry
  information a caller can actually act on
- <a name="fdg-swallowed-exceptions" href="#fdg-swallowed-exceptions">§</a> Never swallow exceptions silently; never `catch (Exception)` without rethrow or a
  documented reason
- <a name="fdg-parameter-and-return-types" href="#fdg-parameter-and-return-types">§</a> Prefer the least-derived parameter type that works (`IEnumerable<T>` in) and the most
  useful return type out; never return `null` for a collection — return empty

**Async & cancellation**
- <a name="fdg-cancellation" href="#fdg-cancellation">§</a> A `CancellationToken` parameter must actually be honored, not just declared. `AZC0002`/`CA1068`
  enforce its existence (or an equivalent `RequestContext` protocol overload), naming, and
  position — but only for `Azure.Core` methods; `AZC0002` doesn't inspect `System.ClientModel`
  methods at all (it only recognizes `Azure.Core` return types), so for those, still check that
  convenience methods declare `CancellationToken cancellationToken = default` and that protocol
  methods instead accept cancellation through their trailing `RequestOptions` parameter
- <a name="fdg-sync-over-async" href="#fdg-sync-over-async">§</a> No `async void` except event handlers; no sync-over-async (`.Result`, `.Wait()`,
  `GetAwaiter().GetResult()`) in library code
- <a name="fdg-async-returns" href="#fdg-async-returns">§</a> Return `Task`/`ValueTask`, not `void`; use `ConfigureAwait(false)` in library code where
  that is the repo convention

**Enums & flags**
- <a name="fdg-enums-and-flags" href="#fdg-enums-and-flags">§</a> Enums for closed sets; `[Flags]` only for genuinely combinable values with power-of-two
  members and a `None = 0`
- <a name="fdg-extensible-enums" href="#fdg-extensible-enums">§</a> If the set of values can grow service-side or over time, an extensible
  value-struct/`readonly struct` pattern is preferred over a plain enum

**Disposal & resources**
- <a name="fdg-disposable" href="#fdg-disposable">§</a> Types owning unmanaged or disposable resources implement `IDisposable` (and
  `IAsyncDisposable` where async cleanup exists) with the standard pattern
- <a name="fdg-idempotent-dispose" href="#fdg-idempotent-dispose">§</a> `Dispose` must be idempotent and must not throw

### H3 — Convention precedence

Judge every non-hard-rule question against, in order, stopping at the first that answers it:

1. **Local project** — the project/directory being changed
2. **Repo** — repo-wide patterns, `.editorconfig`, `Directory.Build.props`, analyzers,
   `CONTRIBUTING.md`
3. **Industry** — broadly accepted .NET/ecosystem practice

Do not flag code for following an established local or repo convention just because industry
practice differs. If the convention itself is bad, raise it as a separate ℹ️ note.

---

## Correctness

- <a name="correctness-nullability" href="#correctness-nullability">§</a> Null handling: nullable annotations match reality; no dereference of a possibly-null value;
  no `!` used to silence a real warning
- <a name="correctness-boundaries" href="#correctness-boundaries">§</a> Off-by-one, boundary, and empty-collection cases
- <a name="correctness-arithmetic" href="#correctness-arithmetic">§</a> Integer overflow, division by zero, and lossy numeric conversions
- <a name="correctness-culture" href="#correctness-culture">§</a> Culture: `string` comparison and parsing must specify intent — `StringComparison.Ordinal`
  for identifiers/keys, culture-aware only for user-facing text. Same for `ToString`/`Parse`
  (`CultureInfo.InvariantCulture` for machine-readable values)
- <a name="correctness-uri-building" href="#correctness-uri-building">§</a> URIs: build with `Uri`/`UriBuilder` or the repo's request-building type, not string
  concatenation — concatenation is where double slashes, unescaped segments, and dropped
  query separators come from
- <a name="correctness-concurrency" href="#correctness-concurrency">§</a> Concurrency: shared mutable state guarded; no lock on `this` or on a public object; no
  double-checked locking without `volatile`/`Interlocked`; no `Task` fire-and-forget without
  observing faults
- <a name="correctness-static-state" href="#correctness-static-state">§</a> Static mutable state is shared by every caller in the process. A non-`readonly` `static`
  field, or a `static` collection mutated after initialization, needs a concurrent type or
  explicit synchronization. Unlike most concurrency questions, this one is visible from the
  diff alone
- <a name="correctness-resource-lifetime" href="#correctness-resource-lifetime">§</a> Resource lifetime: every `IDisposable` is disposed on all paths (including exceptions);
  no disposing of something you don't own (notably `HttpClient`/injected dependencies)
- <a name="correctness-equality" href="#correctness-equality">§</a> Equality: overriding `Equals` requires `GetHashCode`; both must be consistent and match any
  `==` operator or `IComparable` implementation. Combine field hashes with the platform's
  `HashCode` type, or the shared equivalent the repo already links in — never with
  hand-written prime-multiplication arithmetic

## Security

- <a name="security-secrets" href="#security-secrets">§</a> No secrets, tokens, connection strings, or keys in source, tests, logs, or comments
- <a name="security-secrets-in-diagnostics" href="#security-secrets-in-diagnostics">§</a> No secrets or PII in exception messages, log output, or telemetry
- <a name="security-untrusted-input" href="#security-untrusted-input">§</a> Untrusted input is validated before use in a path, URL, SQL statement, process
  invocation, or deserializer. For a path, "validated" means the *resolved* full path is
  confirmed to stay under the intended root — a `..` segment that escapes it is the miss
- <a name="security-deserialization" href="#security-deserialization">§</a> No insecure deserialization (`BinaryFormatter`, unbounded polymorphic JSON)
- <a name="security-crypto" href="#security-crypto">§</a> Crypto: no custom crypto, no weak algorithms (MD5, SHA1 for security, DES), no hardcoded
  IVs/salts, and no disabling of certificate validation

## Tests

- <a name="tests-coverage" href="#tests-coverage">§</a> New behavior has a test; bug fixes have a test that fails before the fix
- <a name="tests-assertions" href="#tests-assertions">§</a> Tests assert the behavior, not the implementation; no assertion-free tests
- <a name="tests-determinism" href="#tests-determinism">§</a> No `Thread.Sleep` for synchronization; no dependence on wall-clock time, machine locale,
  network, or test execution order
- <a name="tests-names" href="#tests-names">§</a> Test names describe the scenario and expectation
- <a name="tests-conventions" href="#tests-conventions">§</a> Follow the test conventions of the project being changed (framework, naming, fixtures)

## Maintainability

- <a name="maintainability-dead-code" href="#maintainability-dead-code">§</a> Dead code, commented-out code, leftover debugging output, and stray TODOs without an issue
  link do not ship
- <a name="maintainability-build-outputs" href="#maintainability-build-outputs">§</a> Build outputs, binaries, and local developer assets do not ship — `.nupkg`, compiled
  assemblies, archives, publish profiles (`*.pubxml`), and tool output. Do not assume
  `.gitignore` covers them; it frequently does not
- <a name="maintainability-comments" href="#maintainability-comments">§</a> Comments explain **why**, never restate **what** the code does. Flag comments that
  paraphrase the next line. XML doc comments on public/protected APIs are expected and
  exempt from this
- <a name="maintainability-xml-docs" href="#maintainability-xml-docs">§</a> Public and protected members have XML docs — `<summary>`, `<param>`, `<returns>`,
  `<exception>` for each exception actually thrown
- <a name="maintainability-drifted-copies" href="#maintainability-drifted-copies">§</a> Copy-pasted logic that has drifted between copies
- <a name="maintainability-dependencies" href="#maintainability-dependencies">§</a> Dependencies: new package references need justification; prefer what the repo already uses;
  no new dependency for something the BCL already does
- <a name="maintainability-vendored-code" href="#maintainability-vendored-code">§</a> Vendored or synced directories are effectively read-only in the consuming repository — a
  local edit is overwritten by the next sync, so the change is lost and the review that
  approved it was wasted. A README saying so, a sync script, or a CODEOWNERS entry naming
  another team are the markers. Send the change upstream instead

## Performance

Only flag when it matters — a hot path, an allocation per item in a loop, or an O(n²) where
n is unbounded. Do not micro-optimize cold code.

- <a name="performance-allocations" href="#performance-allocations">§</a> Allocations in loops or hot paths: LINQ chains, `string` concatenation (use
  `StringBuilder`/`string.Create`), closures capturing locals, boxing of value types
- <a name="performance-repeated-enumeration" href="#performance-repeated-enumeration">§</a> Repeated enumeration of an `IEnumerable<T>` that may be expensive or non-idempotent
- <a name="performance-string-comparer" href="#performance-string-comparer">§</a> Missing `StringComparer` on dictionary lookups keyed by string
- <a name="performance-sync-io" href="#performance-sync-io">§</a> Sync I/O on an async path
