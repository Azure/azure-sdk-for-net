# AGENTS.md — Azure.Storage.Files.Shares

This file contains package-specific guidance for agents working in `Azure.Storage.Files.Shares`.

> Base guidance lives in [`sdk/storage/AGENTS.md`](../AGENTS.md) and applies to this package.
> If any instruction here conflicts with the base file, this file takes precedence for `Azure.Storage.Files.Shares`.

## Scope

- Package path: `sdk/storage/Azure.Storage.Files.Shares`
- Applies to:
  - share/directory/file client internals,
  - option and model surfaces for shares,
  - handle/permission/metadata implementation paths.

## Package Architecture Guidance

- Preserve directory and file path normalization/validation behavior.
- Keep SMB/NFS-related option handling consistent with existing package defaults.
- Preserve request-condition and concurrency behavior in share/file operation paths.
- Keep client and model shape consistent with neighboring shares types.

## Error handling

- Follow `sdk/storage/AGENTS.md` for exception creation/translation.
- Keep failure paths diagnosable with service error codes and diagnostics context.
- Avoid one-off exception mapping patterns unless already established.

## Testing guidance

- Add tests in the affected client area (share, directory, or file).
- Cover changed hierarchy/path/permission/condition semantics as applicable.
- Keep changes minimal and scoped.

## Non-goals

- Do not alter unrelated protocol models or generated code.
- Do not refactor cross-package abstractions as part of a package-scoped fix unless explicitly required.