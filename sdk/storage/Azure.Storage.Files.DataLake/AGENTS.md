# AGENTS.md — Azure.Storage.Files.DataLake

This file contains package-specific guidance for agents working in `Azure.Storage.Files.DataLake`.

> Base guidance lives in [`sdk/storage/AGENTS.md`](../AGENTS.md) and applies to this package.
> If any instruction here conflicts with the base file, this file takes precedence for `Azure.Storage.Files.DataLake`.

## Scope

- Package path: `sdk/storage/Azure.Storage.Files.DataLake`
- Applies to:
  - DataLake service/file-system/path client internals,
  - hierarchical namespace operation plumbing,
  - ACL/permission/metadata option and model behavior.

## Package Architecture Guidance

- Preserve hierarchical namespace semantics and path operation consistency.
- Keep rename/move and related failure-path behavior aligned with current implementation.
- Maintain ACL/permission model and translation behavior.
- Preserve listing continuation-token behavior and current traversal modes.

## Cross-Package Boundary Guidance

- Preserve the established boundary between DataLake package internals and Blob package internals.
- Keep shared behavior aligned where DataLake layers over Blob-backed service mechanics.
- Avoid duplicating Blob package internals in DataLake when an existing shared or delegated pattern already exists.

## Error handling

- Use shared storage exception handling guidance from `sdk/storage/AGENTS.md`.
- Preserve DataLake error code translation behavior where already present.
- Avoid introducing new custom exception wrappers unless there is a package precedent.

## Testing guidance

- Add focused tests around modified path/file-system internals.
- Cover rename/move/delete, ACL/permission, and list continuation behavior when touched.
- Keep test additions scoped to changed behavior.

## Non-goals

- Avoid unrelated changes to blob/files packages while modifying DataLake-only behavior.
- Avoid broad API redesigns in package-scoped fixes.