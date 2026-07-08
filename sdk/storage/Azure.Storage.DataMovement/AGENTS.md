# AGENTS.md — Azure.Storage.DataMovement

This file contains package-specific guidance for agents working in `Azure.Storage.DataMovement`.

> Base guidance lives in [`sdk/storage/AGENTS.md`](../AGENTS.md) and applies to this package.
> If any instruction here conflicts with the base file, this file takes precedence for `Azure.Storage.DataMovement`.

## Scope

- Package path: `sdk/storage/Azure.Storage.DataMovement`
- Applies to:
  - transfer orchestration (upload/download/copy abstractions in this package)
  - job/transfer options, checkpointing/resume mechanics (if present)
  - concurrency, partitioning/chunking, and transfer progress wiring

## DataMovement-specific conventions

- Preserve transfer reliability and resumability semantics.
- Keep defaults for concurrency/chunk sizing/backoff aligned with existing package behavior.
- Avoid introducing breaking behavioral changes in scheduling or progress reporting.
- Maintain compatibility with existing source/destination abstractions and pipeline usage.

## Error handling

- Follow shared guidance in `sdk/storage/AGENTS.md`.
- Ensure failures provide actionable diagnostics without losing underlying service context.
- Avoid broad exception suppression; prefer deterministic failure and clear propagation.

## Testing guidance

- Add targeted tests for modified transfer paths.
- Include scenarios for:
  - partial failure/retry handling
  - resume/checkpoint behavior (if impacted)
  - progress and completion signaling consistency
- Keep stress/perf-oriented changes separate from correctness fixes unless explicitly requested.

## Non-goals

- Do not alter unrelated storage client package behavior from DataMovement-scoped changes.
- Do not mix perf tuning with API behavior changes unless required and justified.