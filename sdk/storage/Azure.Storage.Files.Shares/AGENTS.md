# AGENTS.md — Azure.Storage.Files.Shares

This file contains package-specific guidance for agents working in `Azure.Storage.Files.Shares`.

> Base guidance lives in [`sdk/storage/AGENTS.md`](../AGENTS.md) and applies to this package.
> If any instruction here conflicts with the base file, this file takes precedence for `Azure.Storage.Files.Shares`.

## Scope

- Package path: `sdk/storage/Azure.Storage.Files.Shares`
- Applies to:
  - Share, directory, and file clients
  - SMB/NFS-related option surfaces exposed by this package
  - Handle/permission/metadata operations under shares

## Shares-specific conventions

- Preserve directory and file path behavior and normalization as currently implemented.
- Maintain compatibility with existing SMB/NFS option handling and defaults.
- Keep request condition handling aligned with current share/file operations.
- Avoid introducing behavior that differs from existing shares client patterns unless required.

## Error handling

- Follow `sdk/storage/AGENTS.md` for exception creation/translation.
- Keep failures diagnosable with service error code/context preserved.
- Avoid package-local one-off exception mapping unless already established.

## Testing guidance

- Add targeted tests for affected client type(s): share, directory, or file.
- Include cases around:
  - path and hierarchy operations
  - permission/attribute-related behavior when changed
  - conditional headers and concurrency paths where relevant
- Keep changes minimal and focused to the feature under modification.

## Non-goals

- Do not alter unrelated protocol models or generated code.
- Do not refactor cross-package abstractions as part of a package-scoped fix unless explicitly required.