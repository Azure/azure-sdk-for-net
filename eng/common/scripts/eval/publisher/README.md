# Evaluation result publisher

This optional, data-only package writes one complete build result directly to
Azure Blob. It does not contain Vally CLI, the dashboard server, SQLite, MCP or an
LLM client. The evaluator stays in the parent package; only the Summary job
restores these separately locked dependencies when bundle creation is enabled.

## Flow and contract

1. Every shard retains its newest invocation's raw JSONL, JUnit and a schema-v1
   completion marker. Completed failed evaluations are results too.
2. Summary uses the Prepare matrix and each expected shard's highest attempt for
   its Markdown, Tests tab and bundle input. Missing/incomplete latest attempts
   block publishing; they never fall back to a previous successful attempt.
   It reads **this build's** timeline with `System.AccessToken` to detect newer
   retries that published no artifact. Failure to verify those attempts prevents
   publication while retaining diagnostics; no dashboard/ADO discovery is added.
3. `prepare-bundle.mjs` packages the selected streams into one saved ZIP:
   `manifest.json`, merged `results.jsonl`, `eval-summary.md` and `junit/*.xml`.
   Other artifacts, MCP binaries, debug files and signing files are excluded.
4. `publish-bundle.mjs` runs inside `AzureCLI@2`, using that task's federated
   identity via `AzureCliCredential`. It uploads the ZIP with `ifNoneMatch: *` to
   `v1/<org>/<lowercase-encoded-project>/<definition>/<build>/<Summary-attempt>/dashboard-bundle.zip`.
5. Immutable Blob metadata is `schema: "1"`, `sha256`, `publisher` (SHA-256 of
   tenant ID and principal object ID), and `storedat`. These are integrity and
   provenance fields, not cryptographic attestation. Azure RBAC authorizes writes.

The format matches the storage-first dashboard's schema-v1 reader. Archive and
expanded data limits are 32 MiB / 128 MiB, with at most 10,000 ZIP entries and
100,000 plain-eval trial records. Experiments are not supported. No ADO historical
backfill or evaluation rerun is performed by the publisher.

The current dashboard imports executed `success`/`error` trials. Non-executed
`skipped` records remain in the original raw shard artifacts; the ZIP's JUnit and
Markdown retain their skipped counts. Bundle preparation reports skipped records
explicitly rather than converting them to failed executions. A shard with no
executed trials remains non-publishable, not a successful evaluation result.

Transient storage errors retry the **same saved bytes**. An existing name must
have the same owner, checksum and size; changed data needs a new Summary attempt.
The publisher never overwrites/deletes an archive or creates the container.
Its identity needs Blob data write/read access to the existing container. Keep
the dashboard's identity separate and read-only.

## Configure a consumer

Pass the following parameters to the shared eval archetype. Publishing defaults
off for every consumer; this PR does not turn on scheduled production writes.

| Parameter | Meaning |
| --- | --- |
| `createDashboardBundle` | Prepare/retain a ZIP even without uploading; enabled in the workflow entrypoint |
| `publishDashboardResults` | Explicitly enable direct Blob publication |
| `storageServiceConnection` | Existing Azure Resource Manager service connection; workflow example uses `eval-dashboard-sc` |
| `storageContainerUrl` | Normal HTTPS container URL, with no SAS or keys |
| `notifyDashboard` | Optional small cache-refresh signal after durable storage; default `false` |
| `dashboardUrl` / `dashboardAudience` | HTTPS origin and Entra API audience for notifications only |
| `summaryPool` | Linux agent pool with routes to Blob and optionally the dashboard |

These are YAML parameters, not ordinary pipeline variables or App Service
settings. No GitHub Enterprise service connection or private dashboard checkout
is required: all publishing code is in this public shared package.

Publication is excluded from PR validation, non-internal projects and
`refs/pull/*` sources. For a draft PR pilot, manually run the existing pipeline
against the trusted **feature branch**, not the PR validation/merge ref. Keep
Azure DevOps service-connection approvals and checks in place.

### Manual no-LLM smoke test for workflow pipeline 8255

After the draft branch is pushed, open the existing workflow pipeline and select
**Run pipeline**. Select the PR's source branch and use:

| Parameter | Pilot value |
| --- | --- |
| `storageSmokeTest` | `true` |
| `publishDashboardResults` | `true` |
| `storageServiceConnection` | `eval-dashboard-sc` |
| `storageContainerUrl` | `https://evaltestsummary.blob.core.windows.net/vally-results` |
| `notifyDashboard` | `false` |

The smoke path is manual-only. It skips MCP building, evaluator installation,
eval/model credentials and all model calls. Two explicitly synthetic shards use
the real shared staging and Summary path. Intentionally failing synthetic trial
records prove that complete failed evaluations are still packaged; workflow is
report-only, so their score is not a pipeline gate. The manifest pipeline name
is suffixed with `[synthetic storage smoke]`; it is never real evaluation history.

The job runs local unit tests, uploads one ZIP using the actual service
connection, and repeats the upload of the exact same bytes to verify idempotency
without creating another archive. Check the Summary artifact's
`storage-publication-result.json`: `status: "stored"`, `retryVerified: true`,
`notification.status: "not_requested"`. The ZIP and result are retained even if
a later task fails. The smoke archive remains for inspection; no automatic
deletion or retention permission is granted to the dashboard.

For a real evaluation pilot, set `storageSmokeTest=false` and keep publication
enabled. That runs the actual evaluations and may consume model quota; it is a
separate deliberate run, not part of the synthetic storage test.

## Optional notification and dashboard activation

When enabled, the publisher sends only `{blobName, sha256}` to `POST /api/refresh`,
with an Entra application token. It saves `status: "stored"` locally before
waiting for this request. A failed signal is a warning and does not undo or fail
the durable archive. Retry only the signal, or use startup/manual reconciliation.

Blob permission is not notification permission. The app's expected API audience,
`Dashboard.Refresh` application role, client-ID allowlist, reader connectivity,
and agent-to-dashboard route must be configured separately. Preserve existing
viewer authentication and network restrictions. The deployed web-only dashboard
currently has sync/notifications disabled, so successful storage publication
alone does not make new charts visible. This PR does not change hosted settings.

## Local tests

From this directory, run `npm ci --ignore-scripts` followed by `npm test`
(`npm.cmd` on Windows). Tests use temporary synthetic artifacts and a fake Blob
client; they do not contact Azure or call an evaluator. The full shared-script
suite remains `npm test` from the parent directory. A real service-connection
upload is validated only by the explicitly approved pipeline smoke run above.

The publisher's dependency lock is separate from the evaluator lock, and the
Summary restore uses the authenticated Azure SDK npm mirror. Do not place keys,
tokens, local archives, database files, or external dashboard source in this package.

## Diagnosing a failed pilot

The result artifact records a bounded failure `operation`, `errorCode` and HTTP
status when available. Raw Azure SDK exceptions, requests, headers and tokens are
never logged. A saved successful storage result is not replaced by a later error.

- `acquire_storage_token`: check service-connection federation and token acquisition.
- `publish_blob` with `AuthorizationPermissionMismatch`/403: check the connection
   identity's Blob data role and its scope; do not substitute an account key.
- `publish_blob` with network errors or `AuthorizationFailure`: check approved agent
   egress/storage network rules before assuming the RBAC grant is missing.
- `submission_conflict`: retain the original bytes and use a new Summary attempt
   for corrected content; never overwrite existing history.

An Azure CLI login succeeding proves the connection can sign in, not that the
subsequent Blob request succeeded. Keep cloud-pilot results separate from local
unit/emulator validation and do not broaden network/security settings to hide a failure.
