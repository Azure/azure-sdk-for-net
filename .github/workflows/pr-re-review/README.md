# API-only PR re-review

The `pr-re-review` workflow currently reviews **changed .NET API listings**, not the entire PR. Its assignment is `sdk/**/api/*.cs`, including removed files, renames into or out of that scope, and every changed target-framework listing.

## Input and execution

- A separate, read-only `api_scope` job runs trusted base-commit PowerShell helpers. It validates the full PR inventory and head/base stability before selecting the API assignment.
- The agent receives API patch parts and a metadata-only index of changed source candidates under the affected packages' `src/` directories. Unrelated patches, including generated workflow locks, are not review assignments.
- Source candidates are anchor lookup/context, not a second worklist. Missing source patches do not create guessed line ranges.
- With no API changes, the setup job skips the agent deterministically. This is an out-of-scope no-op, not a completed full-PR review.
- The existing Copilot engine, model selection, runtime pins, network controls and safe-output mechanism remain in use. There is no new continuation/controller engine.

## Findings and publication

API listings identify the affected fully qualified type/member. The agent must verify the corresponding declaration in generated or customization source before choosing an inline target. A matching filename alone is insufficient. Inline comments must use an allowed changed source path and a current-side diff line; API-listing inline comments are rejected. Ambiguous symbols, unavailable source diffs, and unchanged declarations use the review body instead. Commenting on generated source does not mean recommending a manual generated-code edit.

A completed review uses `COMMENT` and states:

```text
API coverage: <reviewed>/<changed> API files reviewed
```

Both counts must match the independently captured API assignment. Other PR files and historical thread states are not claimed as reviewed. Existing comments provide relevant context and duplicate detection only; API mode does not reply to, resolve, or reopen threads.

Before publication, the guard checks API counts, allowed output kinds, source anchors, scoped read markers/tool output, and head/base freshness. Read-content matching detects ordinary omitted/truncated reads; it is not tamper-proof evidence or proof of comprehension. Required-input failures or incomplete API coverage must not publish a partial review.

The generic helper contracts and their regression tests remain available, but the workflow opts into API mode explicitly. Source-symbol interpretation is an agent responsibility; the deterministic anchor guard does not parse C# declarations or prove semantic correspondence.

## Local validation

Run the Pester tests under `../test/` (including `../test/pr-re-review/`) and the Node thread regressions in `../test/pr-re-review-unresolve-thread.test.cjs`. After modifying `../pr-re-review.md`, regenerate `../pr-re-review.lock.yml` with the repository's exact pinned gh-aw compiler in strict mode. Offline tests and compilation validate the scope/publication contract; they do not prove completion of a live model review. Live workflow dispatch or inference requires separate authorization.
