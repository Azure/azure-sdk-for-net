# AGENTS.md — Azure.Storage.Files.DataLake

This file contains package-specific guidance for agents working in `Azure.Storage.Files.DataLake`.

> Base guidance lives in [`sdk/storage/AGENTS.md`](../AGENTS.md) and applies to this package.
> If any instruction here conflicts with the base file, this file takes precedence for `Azure.Storage.Files.DataLake`.

## Scope

- Package path: `sdk/storage/Azure.Storage.Files.DataLake`
- Applies to:
  - DataLake service/file system/path clients
  - hierarchical namespace path operations (create, rename, delete, list, ACL)
  - DataLake-specific options and models

## DataLake-specific conventions

- Preserve hierarchical namespace semantics and path operation consistency.
- Keep rename/move behavior aligned with existing package expectations and error paths.
- Maintain ACL and permission-related API and behavior consistency.
- Preserve continuation token and listing behavior (including recursion/flat listing modes as implemented).

## Blob API preference

- Prefer Blob APIs for behavior that is fundamentally blob-native and does not depend on hierarchical namespace semantics.
- Use DataLake APIs when the scenario requires DataLake-specific features such as directories, rename semantics, ACLs, POSIX permissions, or hierarchical path traversal.
- When both packages can satisfy a scenario, avoid re-implementing blob behavior in DataLake-only code unless the package already has a clear precedent.
- Keep shared behavior aligned with the Blob package where DataLake is acting as a layer over Blob storage.

## Error handling

- Use shared storage exception handling guidance from `sdk/storage/AGENTS.md`.
- Preserve DataLake error code translation behavior where already present.
- Avoid introducing new custom exception wrappers unless there is a package precedent.

## Testing guidance

- Add focused tests around modified path/file-system scenarios.
- Include representative coverage for:
  - rename/move or delete edge cases (if touched)
  - ACL/permission behavior (if touched)
  - list pagination/continuation behavior (if touched)
- Keep test additions scoped to changed behavior.

## Non-goals

- Avoid unrelated changes to blob/files packages while modifying DataLake-only behavior.
- Avoid broad API redesigns in package-scoped fixes.