# AGENTS.md — Azure.Storage.Blobs

This file contains package-specific guidance for agents working in `Azure.Storage.Blobs`.

> Base guidance lives in [`sdk/storage/AGENTS.md`](../AGENTS.md) and applies to this package.
> If any instruction here conflicts with the base file, this file takes precedence for `Azure.Storage.Blobs`.

## Scope

- Package path: `sdk/storage/Azure.Storage.Blobs`
- Applies to:
  - public and internal blob client families and models,
  - container/blob operation plumbing,
  - blob-type-specific behavior paths,
  - batch/query/lease implementation inside this package.

## Package Architecture Guidance

- Preserve client layering: public API -> convenience logic -> generated protocol clients -> pipeline.
- Keep public API shape and naming consistent with neighboring blob clients.
- Preserve existing condition, lease, version, and snapshot behavior semantics in implementation paths.
- Keep pageable and async-pageable internals continuation-token based and lazily evaluated.
- Keep shared helpers/package internals reusable rather than duplicating behavior per client.

## Error handling

- Follow storage-wide exception patterns from `sdk/storage/AGENTS.md`.
- Keep existing exception translation boundaries stable.
- Preserve diagnostics context and service error codes on failures.

## Testing guidance

- Update tests in the same feature area as the change.
- Prioritize coverage for behavior boundaries touched by the edit.
- Avoid unrelated test refactors.

## Non-goals

- Do not move shared logic out of established shared locations without clear package need.
- Do not edit generated code directly or alter protocol conventions without regeneration inputs.