# AGENTS.md — Azure.Storage.Blobs

This file contains package-specific guidance for agents working in `Azure.Storage.Blobs`.

> Base guidance lives in [`sdk/storage/AGENTS.md`](../AGENTS.md) and applies to this package.
> If any instruction here conflicts with the base file, this file takes precedence for `Azure.Storage.Blobs`.

## Scope

- Package path: `sdk/storage/Azure.Storage.Blobs`
- Applies to:
  - Blob clients and models
  - BlobContainer and BlobBase/BlobClient families
  - Block blob/page blob/append blob behaviors
  - Blob batch, query, and lease-related implementation in this package

## Blob-specific conventions

- Preserve existing behavior around:
  - conditional headers (`If-Match`, `If-None-Match`, etc.)
  - access conditions and lease conditions
  - versioning/snapshots semantics
- Keep public API shape and naming consistent with existing clients.
- Do not introduce convenience APIs that bypass existing request condition patterns.
- For pageable/async pageable operations, preserve ordering and continuation token behavior.

## Error handling

- Follow package-wide and storage-wide exception patterns from `sdk/storage/AGENTS.md`.
- Do not create bespoke exception translation paths unless already established by this package.
- Ensure request/response failures preserve service diagnostics and error codes.

## Testing guidance

- Add or update tests near the affected feature area (unit/live as applicable).
- Include scenarios for:
  - conditional request failures/successes
  - lease-related constraints where relevant
  - snapshot/version behaviors when touched
- Avoid broad test refactors unrelated to the change.

## Non-goals

- Do not move shared logic out of established shared storage locations unless necessary.
- Do not change generated code or protocol-layer conventions unless required by an upstream swagger/protocol update.