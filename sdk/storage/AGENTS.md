# AGENTS.md - Azure Storage SDK (.NET)

## Purpose

This file defines repository-level guidance for AI agents working in `sdk/storage`.

Focus this guidance on how the storage SDK codebase is organized and how package internals are expected to behave. Do not treat this file as end-user task guidance.

Repo-wide policies, safety boundaries, and generic development workflows are defined in `/AGENTS.md` at the repository root and should not be repeated here.

## Scope

- Applies to all packages under `sdk/storage/Azure.Storage.*`.
- Package-level `AGENTS.md` files may add package-specific rules.
- When conflicts exist, the nearest package-level `AGENTS.md` wins.

Out of scope for this file:
- repository-wide build/release workflows,
- general security/process policies,
- non-storage package guidance.

## Codebase Structure

Primary areas:
- `sdk/storage/Azure.Storage.*`: service/client packages.
- `sdk/storage/Azure.Storage.*/src`: implementation and public clients.
- `sdk/storage/Azure.Storage.*/tests`: recorded/live/unit test suites.
- `sdk/storage/Azure.Storage.*/api`: public API baseline files (generated artifacts). Update via /eng/scripts/Export-API.ps1
- Generated protocol code and custom convenience layers coexist by design.

Secondary areas (package-dependent):
- `sdk/storage/Azure.Storage.*/Generated`: generated protocol implementations for packages that include local generated folders.
  - Common in service-client packages such as Blobs, Files.Shares, Files.DataLake, and Queues.
  - Not universal across all `Azure.Storage.*` packages; for example, some `Azure.Storage.DataMovement.*` packages do not use a local `Generated` directory.
- `sdk/storage/Azure.Storage.*/perf`: performance and benchmark projects (when present).
- `sdk/storage/Azure.Storage.*/samples`: package-specific sample code (when present).

Non-shipping package areas:
- Some folders under `sdk/storage` are support/test infrastructure and are not publishable SDK packages.
- `sdk/storage/Azure.Storage.Internal.Avro`: internal-only dependency used by storage components.
- `sdk/storage/Azure.Storage.DataMovement.Blobs.Files.Shares`: integration/support project used to exercise DataMovement Blobs and Files.Shares together.
- Do not treat these folders as public package-shaping references when inferring release scope, API baseline expectations, or changelog requirements.

Navigation pattern:
1. Public client entry points (`*Client`).
2. Internal helper/convenience methods.
3. Generated REST client calls.
4. Azure Core pipeline behaviors.

## Architecture Model

Preserve this layering:
1. Public API surface.
2. Convenience SDK logic.
3. Generated protocol client.
4. Azure Core pipeline policies.

Do not bypass layers unless there is an existing package precedent.

## Cross-Package Consistency Rules

- Keep API shape and naming aligned with neighboring storage packages.
- Keep sync/async pairs aligned to shared internal implementations.
- Keep pageable behavior lazy and continuation-token based.
- Preserve existing request-condition and concurrency semantics.
- Keep diagnostics, logging, and exception behavior consistent with adjacent APIs.

## Diagnostics and Exceptions

- Mirror existing `DiagnosticScope` usage in the same client type.
- Ensure scope failure is recorded before rethrowing exceptions.
- Preserve `RequestFailedException` status and service error code fidelity.
- Define new validation throws through shared error helper catalogs instead of inline literals.

Shared error catalogs:
- `Azure.Storage.Common/src/Shared/Errors.cs`
- `Azure.Storage.Common/src/Shared/Errors.Clients.cs`
- `Azure.Storage.DataMovement/src/Shared/Errors.DataMovement.cs`

## Generated and Shared Sources

- Files under generated code folders are read-only implementation artifacts.
- Add customizations through partials or non-generated files.
- Shared storage internals live under `Azure.Storage.Common/src/Shared/` and are linked into packages.

## Test Architecture Expectations

- Use existing storage test base classes and fixture patterns.
- Add targeted tests for behavior changes in the same package area.
- Preserve recorded/live test determinism and avoid flaky patterns.

## Change Boundaries

Agents must avoid:
- introducing new architectural layers when existing ones already cover the scenario,
- broad cross-package refactors for package-scoped fixes.

## Decision Guidance

When uncertain:
1. Follow nearby established patterns in the same package.
2. Prefer minimal, behavior-preserving edits.
3. Keep changes scoped and test-backed.
4. Ask for clarification instead of inferring new architecture.
