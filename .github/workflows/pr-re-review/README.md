# PR re-review continuation

The review requirements are unchanged: verify prior threads, freshly review every changed file, and publish one `COMMENT` review only after complete coverage.

- Trusted pre-steps capture the PR head/base, every changed-file page, complete thread histories and prior reviews. Helpers are checked out before capture. The input artifact is uploaded before inference.
- `ReviewContinuation.cjs` assigns up to eight items/48 KB per batch and starts fresh CLI sessions using the pinned gh-aw Copilot harness. Small patches are embedded; the private reader pages assigned thread histories, oversized patches, and required source sides for omitted patches, deletions and renames. Each response carries a random acknowledgement token; the controller accepts completion only when those tokens match gap-free receipts bound to the captured snapshot, assignment and fresh invocation. Receipts store token hashes, not the tokens. This establishes delivery through the reader, not comprehension.
- Workers have no shell, write, task or safe-output access. A private stdio MCP backend supplies bounded raw GitHub source pages without base64 decoding; its token stays in the gateway/backend, and it opens no HTTP listener. Completed results stay in the controller's in-memory worklist; diagnostic checkpoints are not reloaded as authoritative progress. Unfinished items continue after a clean early exit. Clean no-progress responses reduce the assignment size but do not terminate review while time remains. Actual worker errors or the 22-minute soft deadline fail the run. The workflow retains its 25-minute limit.
- Only the controller queues outputs after every item completes. The trusted publication guard checks the Actions job result, immutable input identity, complete results, buffered-output routing, structured coverage counts and current PR/review state. Full base/head central ApiCompat baselines are compared during trusted capture; every new suppression is inventoried independently of worker findings, without asserting that the affected API shipped GA. Missing or malformed required inputs fail closed. Existing threat-detection and skipped-write safeguards remain active. Both resolve and reopen operations wait for proof that the matching reply was applied. gh-aw remains responsible for sanitizing output text; the publication guard checks the deterministic suppression inventory without reconstructing free-form Markdown.

A completion result is still a model review conclusion, not proof of comprehension. Related-file reads and cross-file review remain required; prior reviews never substitute for a fresh changed-file result. Binary, non-UTF-8 or over-4-MiB source that is required for delivery fails closed; this is not an unlimited or resumable-across-workflow-runs service.

## Validation

CI provisions the pinned gh-aw setup helpers for handler/receipt tests. To run the Node suites locally, point `GH_AW_TEST_ACTIONS_DIR` at those same helpers:

```bash
GH_AW_TEST_ACTIONS_DIR=/path/to/pinned/gh-aw/setup/js node --test .github/workflows/pr-re-review/*.Tests.cjs .github/workflows/test/pr-re-review-unresolve-thread.test.cjs
```

Run the existing Pester suites under this directory and `.github/workflows/test`, and compile `pr-re-review.md` with the pinned gh-aw version after workflow changes. Subprocess fixtures reproduce the 106-file clean early-stop case without inference or GitHub writes; they do not establish hosted end-to-end review quality.
