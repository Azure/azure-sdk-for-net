# AGENTS.md — Azure.Storage.DataMovement

This file contains package-specific guidance for agents working in `Azure.Storage.DataMovement`.

> Base guidance lives in [`sdk/storage/AGENTS.md`](../AGENTS.md) and applies to this package.
> If any instruction here conflicts with the base file, this file takes precedence for `Azure.Storage.DataMovement`.

## Scope

- Package path: `sdk/storage/Azure.Storage.DataMovement`
- Applies to:
  - transfer orchestration internals,
  - transfer option and state models,
  - checkpoint/resume components,
  - concurrency/chunk scheduling and progress signaling.

## Dependency Topology

- `Azure.Storage.DataMovement` is the shared orchestration core for DataMovement adapters.
- Customer-facing adapter packages such as `Azure.Storage.DataMovement.Blobs` and `Azure.Storage.DataMovement.Files.Shares` call into this package for transfer orchestration and shared transfer-state behavior.
- Customers typically reference one or both adapter packages for service-specific transfers, and those packages bring in `Azure.Storage.DataMovement` for base orchestration behavior.
- Keep shared orchestration contracts stable in this package so dependent package adapters can remain thin and consistent.
- Shared DataMovement internals live under `Azure.Storage.DataMovement/src/Shared`

## Package Architecture Guidance

- Preserve the current orchestration model and state-transition behavior.
- Keep scheduling, concurrency, and chunking defaults aligned with established package patterns.
- Keep progress and completion signaling contracts stable.
- Maintain compatibility with existing source/destination abstraction boundaries.

## Job Structure

DataMovement transfer execution follows a consistent hierarchy. Keep changes aligned to this model.

1. Classify the job scope:
  - Single-object transfer.
  - Multi-object transfer (for example, directory or container traversal).
2. Classify the transfer direction per object:
  - Upload: stream/file source to service URI destination (for example, local file to blob).
  - Download: service URI source to stream/file destination (for example, blob to local file).
  - Service copy: service URI to service URI (for example, blob to blob, blob to share file).
3. Expand each object transfer into work units:
  - Split objects into chunks/blocks according to transfer type and size.
  - Schedule chunk-level work with package concurrency and throttling controls.
4. Orchestrate and finalize:
  - Coordinate chunk execution, retries, and ordering semantics.
  - Aggregate progress/completion at object level and job level.
  - Persist and consume checkpoint state to support pause/resume.

When editing orchestration logic, preserve this hierarchy and avoid mixing object-discovery concerns with chunk-execution concerns in the same code path unless there is an existing package precedent.

## Error handling

- Follow shared guidance in `sdk/storage/AGENTS.md`.
- Preserve deterministic failure propagation across transfer components.
- Keep diagnostics detailed while preserving underlying exception context.

## Testing guidance

- Add targeted tests for modified orchestration paths.
- Validate retry, resume/checkpoint, and progress behavior when touched.
- When adding tests to abstract classes, recordings must be created for each derived test class, including derived classes that live in `Azure.Storage.DataMovement.Blobs`, `Azure.Storage.DataMovement.Files.Shares`, and `Azure.Storage.DataMovement.Blobs.Files.Shares` test packages.
- Keep perf/stress changes isolated from correctness changes unless explicitly requested.

## Non-goals

- Do not alter unrelated storage client package behavior from DataMovement-scoped edits.
- Do not combine broad tuning work with contract changes in one patch unless required.