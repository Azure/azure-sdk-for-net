# Review Quality and General Rules

These rules augment the review agent's normal open-ended analysis. They are minimum checks, not
an exhaustive checklist. Continue looking for bugs, security issues, correctness failures,
reliability problems, concurrency hazards, resource leaks, test gaps, and maintainability or
performance regressions that are not named here.

## Scope and Evidence

- Review code added or modified by the change and regressions directly caused by it. Do not mine
  unrelated, unchanged code. A severe correctness, security, or breaking-change issue may be
  reported when the changed code exposes or depends on it; explain that connection.
- Read the pull request description, linked issues, existing review comments, and resolved or
  outdated threads before commenting. Do not duplicate a finding that has already been raised or
  relitigate an explicitly settled decision without new evidence.
- Read enough surrounding code and repository configuration to establish the local convention.
  A diff hunk alone is not sufficient evidence.
- Every finding must identify direct evidence, a concrete consequence, and a recommended
  correction. If any of those is missing, omit the finding.
- Check documented exceptions and allowed cases before reporting a rule violation. Try to
  disprove each candidate finding.
- Do not repeat diagnostics that normal CI or analyzers will already report unless the change
  adds or widens an opt-out, suppression, baseline, allow-list entry, or other way around the
  enforcement.
- Prefer silence over generic advice, speculative concerns, style preferences, or observations
  that do not ask the author to change anything.

## Hard Rules

These are not judgment calls. A violation is always 🔴.

### H1 — No breaking changes

**Always report** a change that breaks existing consumers. Assume every public/protected API
already has callers you cannot see.

Classify by what changed and how it manifests:

**API-breaking — never permitted in any release (major, minor, or patch).**
Existing code fails to compile or bind:
- Removing or renaming a public/protected type, member, parameter, or namespace
- Changing a return type, parameter type, or parameter name (named args break)
- Changing accessibility downward (`public` → `internal`, `protected` → `private`)
- Adding/removing/reordering parameters on an existing signature (add an overload instead)
- Sealing a previously unsealed type; removing `virtual`; adding `abstract` members
- Adding a member to an existing public interface, or a required member to a public type
- Moving a type between namespaces or assemblies without a `TypeForwardedTo`
- Changing generic arity or adding/tightening generic constraints
- Changing a class to a struct or vice versa; changing base type or removing an implemented
  interface
- Removing enum members or changing their explicit values

**Binary-breaking — never permitted in minor or patch releases.**
Public API shape is unchanged but pre-compiled callers break or silently misbehave:
- Changing the value of a `const` field (old value is inlined into caller IL)
- Changing a default parameter value (defaults are baked into the caller's IL)
- Removing or altering `TypeForwardedTo` when relocating types

**Source-breaking — major release only, with documented justification.**
API only grew, but recompiling existing source resolves differently or fails:
- Adding an overload that changes overload resolution at existing call sites
- Adding an implicit conversion that introduces ambiguity
- Adding an extension method that shadows/conflicts with an existing one

**Behavioral breaks count too.** Same signature, different observable behavior is a break:
changed exception type or message contract, changed null/empty handling, changed default
values, changed ordering/pagination, changed serialized wire or on-disk format, changed
thread-safety or disposal semantics, changed timing (sync → async-over-sync).

**How to check:**
- Diff the public surface, not just the implementation. If the repo checks in API listing
  files (`api/*.cs`, `*.api`, `PublicAPI.Shipped.txt`), **every removed or modified line in
  those files is a breaking change** — flag it. Added lines are additive and fine.
- If a public signature line in the diff was *modified* rather than *added*, that is a break.
  The additive alternative is a new overload that delegates to the new one.
- If the change is genuinely required, the answer is a new API alongside the old, with the
  old one kept working (and optionally `[Obsolete]`), not an edit in place.

### H2 — Follow the .NET Framework Design Guidelines

Reference: <https://aka.ms/fxdg3>

Apply them as written. The checks below are the ones most often missed — they are a starting
point, not the full set. Consult the source document when the diff touches an area not
listed here.

**Naming**
- PascalCase for types, members, namespaces; camelCase for parameters and locals
- No abbreviations or acronym soup; acronyms of 2 letters stay upper (`IO`), 3+ are Pascal
  (`Http`, `Xml`, `Uri`)
- No Hungarian notation; no type names in member names
- No generic/vague names — `OperationResponse`, `DataCollection`, `Manager`, `Helper`,
  `Utility`, `Info` are smells
- Async methods end in `Async`; `Try*` methods return `bool` with an `out` result
- Boolean members read affirmatively (`IsEnabled`, not `IsNotDisabled`)

**Type design**
- Prefer classes over interfaces. **Do not introduce an interface** unless you need multiple
  inheritance or structs must implement it — use an abstract class instead
- Do not introduce an abstraction (interface or abstract class) unless the API both **returns
  and consumes** it
- No empty types (types with no members)
- Structs only for small, immutable, value-semantic data; must have a meaningful default
  (all-zero) state
- Prefer sealed by default for new types not designed for inheritance; document the extension
  points you do allow
- Prefer immutability for types shared across threads

**Members**
- Properties for logical data, methods for actions. Properties must not throw for simple
  gets, must not be order-dependent, and must be cheap
- No `ref`/`out` in public APIs unless implementing `Try*`
- Do not overload on parameters that differ only by optionality; do not add default parameter
  values to an already-shipped signature
- Validate all public/protected inputs and throw the right exception:
  `ArgumentNullException` / `ArgumentException` / `ArgumentOutOfRangeException` with the
  correct `paramName`
- Throw `InvalidOperationException` for wrong-state, not `ArgumentException`
- Never throw `Exception`, `SystemException`, `ApplicationException`, or
  `NullReferenceException`/`IndexOutOfRangeException` directly
- Do not introduce a custom exception type when a BCL type already means the same thing —
  cancellation is `OperationCanceledException`. A new exception type has to carry
  information a caller can actually act on
- Never swallow exceptions silently; never `catch (Exception)` without rethrow or a
  documented reason
- Prefer the least-derived parameter type that works (`IEnumerable<T>` in) and the most
  useful return type out; never return `null` for a collection — return empty

**Async & cancellation**
- Every public async method takes a `CancellationToken`, last parameter,
  `= default` — and actually honors it
- No `async void` except event handlers; no sync-over-async (`.Result`, `.Wait()`,
  `GetAwaiter().GetResult()`) in library code
- Return `Task`/`ValueTask`, not `void`; use `ConfigureAwait(false)` in library code where
  that is the repo convention

**Enums & flags**
- Enums for closed sets; `[Flags]` only for genuinely combinable values with power-of-two
  members and a `None = 0`
- If the set of values can grow service-side or over time, an extensible
  value-struct/`readonly struct` pattern is preferred over a plain enum

**Disposal & resources**
- Types owning unmanaged or disposable resources implement `IDisposable` (and
  `IAsyncDisposable` where async cleanup exists) with the standard pattern
- `Dispose` must be idempotent and must not throw

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

- Null handling: nullable annotations match reality; no dereference of a possibly-null value;
  no `!` used to silence a real warning
- Off-by-one, boundary, and empty-collection cases
- Integer overflow, division by zero, and lossy numeric conversions
- Culture: `string` comparison and parsing must specify intent — `StringComparison.Ordinal`
  for identifiers/keys, culture-aware only for user-facing text. Same for `ToString`/`Parse`
  (`CultureInfo.InvariantCulture` for machine-readable values)
- URIs: build with `Uri`/`UriBuilder` or the repo's request-building type, not string
  concatenation — concatenation is where double slashes, unescaped segments, and dropped
  query separators come from
- Concurrency: shared mutable state guarded; no lock on `this` or on a public object; no
  double-checked locking without `volatile`/`Interlocked`; no `Task` fire-and-forget without
  observing faults
- Static mutable state is shared by every caller in the process. A non-`readonly` `static`
  field, or a `static` collection mutated after initialization, needs a concurrent type or
  explicit synchronization. Unlike most concurrency questions, this one is visible from the
  diff alone
- Resource lifetime: every `IDisposable` is disposed on all paths (including exceptions);
  no disposing of something you don't own (notably `HttpClient`/injected dependencies)
- Equality: overriding `Equals` requires `GetHashCode`; both must be consistent and match any
  `==` operator or `IComparable` implementation. Combine field hashes with the platform's
  `HashCode` type, or the shared equivalent the repo already links in — never with
  hand-written prime-multiplication arithmetic

## Security

- No secrets, tokens, connection strings, or keys in source, tests, logs, or comments
- No secrets or PII in exception messages, log output, or telemetry
- Untrusted input is validated before use in a path, URL, SQL statement, process
  invocation, or deserializer. For a path, "validated" means the *resolved* full path is
  confirmed to stay under the intended root — a `..` segment that escapes it is the miss
- No insecure deserialization (`BinaryFormatter`, unbounded polymorphic JSON)
- Crypto: no custom crypto, no weak algorithms (MD5, SHA1 for security, DES), no hardcoded
  IVs/salts, and no disabling of certificate validation

## Tests

- New behavior has a test; bug fixes have a test that fails before the fix
- Tests assert the behavior, not the implementation; no assertion-free tests
- No `Thread.Sleep` for synchronization; no dependence on wall-clock time, machine locale,
  network, or test execution order
- Test names describe the scenario and expectation
- Follow the test conventions of the project being changed (framework, naming, fixtures)

## Maintainability

- Dead code, commented-out code, leftover debugging output, and stray TODOs without an issue
  link do not ship
- Build outputs, binaries, and local developer assets do not ship — `.nupkg`, compiled
  assemblies, archives, publish profiles (`*.pubxml`), and tool output. Do not assume
  `.gitignore` covers them; it frequently does not
- Comments explain **why**, never restate **what** the code does. Flag comments that
  paraphrase the next line. XML doc comments on public/protected APIs are expected and
  exempt from this
- Public and protected members have XML docs — `<summary>`, `<param>`, `<returns>`,
  `<exception>` for each exception actually thrown
- Copy-pasted logic that has drifted between copies
- Dependencies: new package references need justification; prefer what the repo already uses;
  no new dependency for something the BCL already does
- Vendored or synced directories are effectively read-only in the consuming repository — a
  local edit is overwritten by the next sync, so the change is lost and the review that
  approved it was wasted. A README saying so, a sync script, or a CODEOWNERS entry naming
  another team are the markers. Send the change upstream instead

## Performance

Only flag when it matters — a hot path, an allocation per item in a loop, or an O(n²) where
n is unbounded. Do not micro-optimize cold code.

- Allocations in loops or hot paths: LINQ chains, `string` concatenation (use
  `StringBuilder`/`string.Create`), closures capturing locals, boxing of value types
- Repeated enumeration of an `IEnumerable<T>` that may be expensive or non-idempotent
- Missing `StringComparer` on dictionary lookups keyed by string
- Sync I/O on an async path
