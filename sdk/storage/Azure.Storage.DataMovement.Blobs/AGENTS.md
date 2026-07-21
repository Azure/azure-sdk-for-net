# AGENTS.md — Azure.Storage.DataMovement.Blobs

This file contains package-specific guidance for agents working in `Azure.Storage.DataMovement.Blobs`.

> Base guidance lives in [`sdk/storage/AGENTS.md`](../AGENTS.md) and applies to this package.
> Core orchestration guidance also lives in [`sdk/storage/Azure.Storage.DataMovement/AGENTS.md`](../Azure.Storage.DataMovement/AGENTS.md).
> If any instruction here conflicts with a base file, this file takes precedence for `Azure.Storage.DataMovement.Blobs`.

## Scope

- Package path: `sdk/storage/Azure.Storage.DataMovement.Blobs`
- Applies to:
  - Blob-specific transfer adapters built on DataMovement orchestration,
  - Blob source/destination resource implementation details,
  - Blob transfer option mapping and behavior.

## Package Role

- Customers typically reference this package for Blob transfer scenarios.
- `Azure.Storage.DataMovement` provides the shared orchestration core (transfer scheduling, progress signaling, pause/resume, and checkpoint flows).

## Package Architecture Guidance

- Keep Blob adapter logic thin and focused on Blob resource semantics.
- Reuse shared orchestration behavior from `Azure.Storage.DataMovement` instead of re-implementing scheduler/state logic locally.
- Preserve compatibility with existing transfer state and checkpoint/resume contracts.

## Error handling

- Follow shared storage exception guidance from `sdk/storage/AGENTS.md`.
- Preserve Blob error fidelity and avoid wrapping exceptions unless there is package precedent.

## Testing guidance

- Add focused tests for changed Blob adapter behavior.
- Cover upload/download/copy adapter paths and option mapping behavior when touched.
- Keep test updates aligned with existing recording/live test patterns.

## Non-goals

- Do not duplicate transfer orchestration internals that belong in `Azure.Storage.DataMovement`.
- Do not combine broad cross-package refactors with package-scoped adapter fixes.
