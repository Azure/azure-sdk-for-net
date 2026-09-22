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

Pass the following parameters to the shared eval archetype. Shared publishing
defaults remain off. The three tools entrypoints additionally enable scoped
automatic publication for their trusted internal main builds after merge.

| Parameter | Meaning |
| --- | --- |
| `autoPublishDashboardResults` | Entrypoint-only; default `true`. Automatically enable publishing and AzureStorage egress only for the tools production definitions below on trusted internal main builds. Set `false` to opt out. |
| `createDashboardBundle` | Prepare/retain a ZIP even without uploading; enabled in the workflow, skill and live entrypoints |
| `publishDashboardResults` | Explicitly enable direct Blob publication |
| `allowAzureStorageNetworkAccess` | Separately opt into the documented `AzureStorage` network-isolation policy for this trusted publishing run; default `false` |
| `storageServiceConnection` | Existing Azure Resource Manager service connection; tools entrypoints use `eval-dashboard-sc` |
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

### Opt-in network policy

The [1ES Network Isolation guide](https://aka.ms/1es/netiso/pipelinetemplates)
documents `AzureStorage` as a shared **allow** policy selectable through
`parameters.settings.networkIsolationPolicy`. On this repository's eval entrypoints,
setting `allowAzureStorageNetworkAccess=true` **and**
`publishDashboardResults=true` requests:

`DefaultDeny, CFSClean, CFSClean2, CFSClean3, AzureStorage`

Network isolation remains enforced. No `Permissive` fallback, process/proxy
workaround, extra role grant, storage firewall edit or account key is involved.
The opt-in is ignored for PR validation, pull refs and non-internal projects.
Unchanged consumers retain their existing policy lists. Cross-repo consumers
enabling this option need the matching `AllowAzureStorage` parameter support in
their repo-owned 1ES redirect; it is not forwarded when the opt-in is off.

**Scope:** this permits network access to Azure Storage generally from **all
processes in the pipeline**, not only the Summary job, one account or one
container. It does not grant Azure RBAC access. Obtain the pipeline owner's
approval for that scope; a central custom endpoint/process rule remains the
narrower alternative. Policy changes may create an SFI item per the 1ES guide.
Do not use `networkIsolationAdditionalDomainAllowList`: that is Agency-only.

Selecting this documented policy is an explicit configuration change, not a
retry through another identity or network. Verify the effective policy list
and upload result when onboarding a consumer.

### Real workflow, skill and live evaluations

All three entrypoints can publish to the same account/container. The pipeline
definition ID in each Blob name and the manifest's pipeline name keep their
results separate; no second dashboard or staging container is required.

| Pipeline | Definition | Entrypoint |
| --- | --- | --- |
| Workflow/tool evals | 8255 | `eng/common/pipelines/workflow-eval.yml` |
| Skill evals | 8256 | `eng/common/pipelines/skill-eval.yml` |
| Live workflow evals | 8246 | `eng/common/pipelines/live-eval.yml` |

For each deliberate real run, select the feature branch containing the publisher
and set `publishDashboardResults=true`, `allowAzureStorageNetworkAccess=true`,
and `notifyDashboard=false`. The default service connection/container above are
shared. All entrypoints execute the existing full eval matrix and consume model
quota. Workflow and skill use their mock MCP environments but still evaluate
real model responses. Synthetic fixtures are confined to local unit tests.

The live tier retains `UseAzSdkAuthentication=true`, the existing
`opensource-api-connection` for live MCP calls, `AZSDKTOOLS_AGENT_TESTING=true`,
and its evaluation score gate. The Blob publisher uses the separate
`eval-dashboard-sc` connection. Complete failed evaluations are published before
the gate; missing/incomplete shards still block publication. Do not change scores
or omit failing scenarios to make a dashboard import pass.

### Automatic main-branch publication

The three entrypoints pass `autoPublishDashboardResults` to a shared variable
template, which defaults off unless called explicitly. Automatic publication
requires all of the following: organization URL `https://dev.azure.com/azure-sdk/`,
project `internal`, repository `Azure/azure-sdk-tools`, the entrypoint's exact
definition ID (8255, 8256 or 8246), branch `refs/heads/main`, and a normal CI,
scheduled or manual reason.

Both publication and the documented AzureStorage egress policy are selected for
that scope. Notifications stay off. To disable a production run's publication,
set `autoPublishDashboardResults=false` and leave both explicit publication/network
flags false. Feature branches, pull refs, other definitions and synced consumers
remain off by default; their deliberate manual publication still requires the
existing explicit flags and trust guards.

This takes effect only after the feature branch is merged. It does not change
existing CI path filters or the live nightly schedule, and it creates no new
pipeline, storage account or container.

## Optional notification and dashboard activation

When enabled, the publisher sends only `{blobName, sha256}` to `POST /api/refresh`,
with an Entra application token. It saves `status: "stored"` locally before
waiting for this request. A failed signal is a warning and does not undo or fail
the durable archive. Retry only the signal, or use startup/manual reconciliation.

Blob permission is not notification permission. The app's expected API audience,
`Dashboard.Refresh` application role, client-ID allowlist, reader connectivity,
and agent-to-dashboard route must be configured separately. Preserve existing
viewer authentication and network restrictions. Successful storage publication
alone does not activate the dashboard reader. Configure hosted read-only sync
separately; startup/manual reconciliation, or its optional slow timer, can import
results while notifications stay disabled. This package does not change hosted
settings.

## Local tests

From this directory, run `npm ci --ignore-scripts` followed by `npm test`
(`npm.cmd` on Windows). Tests use temporary synthetic artifacts and a fake Blob
client; they do not contact Azure or call an evaluator. The full shared-script
suite remains `npm test` from the parent directory. End-to-end service-connection
validation uses the real evaluation pipelines; no extra verification upload is
performed during normal publication. Exact-byte retry/idempotency coverage is
retained in local tests.

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
