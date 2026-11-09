# PR re-review continuation

The review requirements are unchanged: verify prior threads, freshly review every changed file, and publish one `COMMENT` review only after complete coverage.

- Trusted pre-steps capture the PR head/base, every changed-file page, complete thread histories and prior reviews. Helpers are checked out before capture. The input artifact is uploaded before inference.
- `ReviewContinuation.cjs` assigns up to eight items/48 KB per batch and starts fresh CLI sessions using the pinned gh-aw Copilot harness. Shared histories and oversized patches are read from exported, read-only context rather than repeated in every prompt.
- Workers have no shell, write, task or safe-output access. A private stdio MCP backend supplies bounded raw GitHub source pages without base64 decoding; its token stays in the gateway/backend, and it opens no HTTP listener. Completed results stay in the controller's in-memory worklist; diagnostic checkpoints are not reloaded as authoritative progress. Unfinished items continue after a clean early exit. Clean no-progress responses reduce the assignment size but do not terminate review while time remains. Actual worker errors or the 22-minute soft deadline fail the run. The workflow retains its 25-minute limit.
- Only the controller queues outputs after every item completes. The trusted publication guard checks the Actions job result, immutable input identity, complete results, buffered-output routing and current PR/review state. Existing coverage, threat-detection and skipped-write safeguards remain active. Both resolve and reopen operations wait for proof that the matching reply was applied. gh-aw remains solely responsible for sanitizing output text; the publication guard does not reconstruct Markdown.

A completion result is still a model review conclusion, not proof of comprehension. Related-file reads and cross-file review remain required; prior reviews never substitute for a fresh changed-file result. This is not an unlimited or resumable-across-workflow-runs service.

The evidence extension retains source-backed file assessments in worker results and records the controller-selected worker log with each attempt. Publication binds each quote to that worker's successful exported-part read before its final decision, then delegates complete-part checks to the shared `Assert-PrReReviewReadCoverage` helper. It consumes the captured input/progress artifacts, not a single agent submission transcript, and delegates capture, freshness and completion to the existing controller and trusted helpers. The input artifact includes pre-inference markers; the progress artifact includes worker execution logs. Session-log evidence remains best-effort, not tamper-proof proof of comprehension.

## Validation

CI provisions the pinned gh-aw setup helpers for handler/receipt tests. To run the Node suites locally, point `GH_AW_TEST_ACTIONS_DIR` at those same helpers:

```bash
GH_AW_TEST_ACTIONS_DIR=/path/to/pinned/gh-aw/setup/js node --test .github/workflows/pr-re-review/*.Tests.cjs .github/workflows/test/pr-re-review-unresolve-thread.test.cjs .github/workflows/test/pr-re-review-evidence.test.cjs
```

The evidence integration tests require PowerShell 7.5+; set `REVIEW_PWSH` if that executable is not the default `pwsh`. Run the existing Pester suites under this directory and `.github/workflows/test` with Pester 5.x, and compile `pr-re-review.md` with the pinned gh-aw version after workflow changes. Subprocess fixtures reproduce the 106-file clean early-stop case without inference or GitHub writes; they do not establish hosted end-to-end review quality.
