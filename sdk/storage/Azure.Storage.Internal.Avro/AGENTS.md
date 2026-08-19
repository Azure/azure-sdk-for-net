# AGENTS.md - Azure.Storage.Internal.Avro

This file contains folder-specific guidance for agents working in `Azure.Storage.Internal.Avro`.

> Base guidance lives in `sdk/storage/AGENTS.md` and applies here.
> If any instruction here conflicts with the base file, this file takes precedence for this folder.

## Scope

- Folder path: `sdk/storage/Azure.Storage.Internal.Avro`
- Applies to internal Avro support code used by storage libraries.

## Package Role

- This is an internal support package, not a publishable public SDK package.
- Do not treat this folder as a source of public client API shape or release-scope decisions.

## Change Guidance

- Keep changes narrowly scoped to internal functionality and compatibility needs.
- Preserve existing behavior contracts relied on by dependent storage packages.
