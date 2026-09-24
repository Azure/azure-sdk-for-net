# Evaluation result publisher

This data-only package saves complete evaluation builds to Azure Blob, then
notifies the read-only dashboard. It contains no evaluator, dashboard, SQLite,
MCP or LLM client. Only the Summary job restores its separate dependency lock.

| Source | Responsibility |
| --- | --- |
| [prepare-bundle.ts](prepare-bundle.ts), [bundle.ts](bundle.ts) | Validate selected attempts and prepare the saved schema-v1 archive |
| [publish-bundle.ts](publish-bundle.ts), [storage.ts](storage.ts) | Authenticate the pipeline and publish the exact saved bytes with create-only retries |
| [notification.ts](notification.ts) | Authenticated refresh signal to the fixed reviewed dashboard |
| [diagnostics.ts](diagnostics.ts) | Bounded error reporting without credentials or result contents |

## Flow and contract

1. Shards retain raw JSONL, JUnit and completion metadata from the newest invocation,
   including completed failed evaluations.
2. Summary checks the Prepare matrix against **this build's** timeline and selects
   each expected shard's latest attempt. Missing, incomplete or unverified attempts
   prevent publication; older successful results are never substituted.
3. Prepare one saved schema-v1 ZIP containing the manifest, merged raw results,
   Markdown summary and JUnit. No debug files, MCP binaries or other artifacts enter it.
4. Upload using the task's federated `AzureCliCredential` and `ifNoneMatch: *`.
   Retain the publication result before sending the notification.

Archives use
`v1/<org>/<lowercase-encoded-project>/<definition>/<build>/<Summary-attempt>/dashboard-bundle.zip`.
Metadata contains `schema: "1"`, `sha256`, `publisher` (hashed tenant/principal ID),
and `storedat`. Metadata records integrity/provenance; Azure RBAC authorizes access.

Limits match the reader: **32 MiB ZIP, 128 MiB expanded, 10,000 entries, 100,000 trials**.
Identity strings must be trimmed, encoded names fit within 800 characters, and
timestamps must be valid UTC calendar dates. Only executed `success`/`error` trials
are imported. Non-executed skips remain in raw artifacts and JUnit/Markdown counts;
an entirely skipped shard is not publishable. Experiments are unsupported.

Transient failures retry the **same saved bytes**, at most four times. An existing
archive must match owner, checksum, size and valid metadata; changed results need
a new attempt. The publisher never overwrites/deletes archives or creates containers.
Its Blob write/read identity stays separate from the dashboard's read-only identity.

## Configure a consumer

Only controls with distinct uses remain:

| Parameter | Meaning |
| --- | --- |
| `autoPublishDashboardResults` | Entrypoint-only; default `true`. Automatically enable publishing and AzureStorage egress only for the tools production definitions below on trusted internal main builds. Set `false` to opt out. |
| `createDashboardBundle` | Prepare/retain a ZIP even without uploading; enabled in the workflow, skill and live entrypoints |
| `publishDashboardResults` | Explicitly enable direct Blob publication |
| `allowAzureStorageNetworkAccess` | Separately opt into the documented `AzureStorage` network-isolation policy for this trusted publishing run; default `false` |

These are YAML parameters, not App Service settings. Bundle-only runs need no
Blob credentials. Other consumers default to neither bundling nor publishing.
Summary uses the same Linux pool/image variables as the eval jobs; it has no
separate pool override. Every successful publication attempts a notification.

The [shared publishing step](../../../pipelines/templates/steps/eval-publish-results.yml)
defines the connection/container pair once: `eval-dashboard-sc` and
`https://evaltestsummary.blob.core.windows.net/vally-results`. They are not
queue-time parameters. Consumers opt into this shared dashboard rather than
selecting an unrelated destination; changing either value requires a reviewed
source change. Other repos must explicitly onboard service-connection authorization
and network access before opting in. No enterprise checkout is required.

Publication is excluded from PR validation, non-internal projects and `refs/pull/*`.
Keep service-connection approvals and checks in place.

### Opt-in network policy

The [1ES Network Isolation guide](https://aka.ms/1es/netiso/pipelinetemplates)
documents the `AzureStorage` allow policy. Enabling both network access and
publication on an internal non-PR run requests:

`DefaultDeny, CFSClean, CFSClean2, CFSClean3, AzureStorage`

**This permits Azure Storage egress for all processes in the pipeline**, not just
Summary or one container; it grants no RBAC access. Obtain the pipeline owner's
approval and verify the effective policy. Cross-repo consumers need matching
`AllowAzureStorage` support in their repo-owned 1ES redirect; nothing is forwarded
when the opt-in is off. PRs, pull refs and non-internal projects stay excluded.
Do not weaken Default Deny/CFS, use a permissive fallback or substitute credentials.

### Real workflow, skill and live evaluations

The three entrypoints share one dashboard/container; archive identities separate builds.

| Pipeline | Definition | Entrypoint |
| --- | --- | --- |
| Workflow/tool evals | 8255 | `eng/common/pipelines/workflow-eval.yml` |
| Skill evals | 8256 | `eng/common/pipelines/skill-eval.yml` |
| Live workflow evals | 8246 | `eng/common/pipelines/live-eval.yml` |

For each deliberate real run, select the feature branch containing the publisher
and set `publishDashboardResults=true` and `allowAzureStorageNetworkAccess=true`.
**These pipelines execute real evaluations and consume model quota.** Local tests
use synthetic fixtures; the pipelines do not have a separate synthetic run mode.

Live MCP authentication, `AZSDKTOOLS_AGENT_TESTING=true` and score gates are unchanged.
Complete failed evaluations publish before the gate; incomplete builds cannot publish.

### Automatic main-branch publication

Automatic publication requires organization URL `https://dev.azure.com/azure-sdk/`,
project `internal`, repository `Azure/azure-sdk-tools`, `System.DefinitionId` in
the approved set (8255, 8256 or 8246), branch `refs/heads/main`, and a normal CI,
scheduled or manual reason. Matching an ID alone never enables another repository.
That scope selects both publishing and the approved AzureStorage policy after merge.
Set `autoPublishDashboardResults=false` and leave explicit flags false to opt out.
Other definitions, feature branches and synced consumers remain off by default.

## Notification-first refresh and recovery

Every successful upload sends `{blobName, sha256}` to `POST /api/refresh` with an
Entra application token. The storage result is saved first. A failed signal is
only a warning; a failed Blob upload remains an error. Retries are bounded to four
attempts and redirects are disabled. Retry the signal, not a rebuilt archive.

The fixed reviewed pair in [notification.ts](notification.ts) is
`https://azsdk-eval-bue6a7dwanatgpb3.westus3-01.azurewebsites.net` and
`api://258998df-81ec-460c-bdd7-56a9bdde1e48`. There are no notification switches,
URL/audience overrides or retry-count settings. Changing the target requires review.

Blob access does not grant notification access. The receiver requires the
application-only `Dashboard.Refresh` role and an Easy Auth client allowlist.
Request tokens for
`api://258998df-81ec-460c-bdd7-56a9bdde1e48/.default`; the server validates the Entra
v2 token's `aud` as the API client ID `258998df-81ec-460c-bdd7-56a9bdde1e48`.
Preserve viewer authentication and network restrictions. The AzureStorage policy
does not prove agent-to-dashboard connectivity; confirm delivery on an approved run.
The reader recovers missed signals on browser reload/startup and **once-daily**
reconciliation, without changing source archives.

## Local tests

From this directory, run `npm ci --ignore-scripts` followed by `npm test`
(`npm.cmd` on Windows). Tests use temporary synthetic artifacts and a fake Blob
client; they do not contact Azure or call an evaluator. Run `npm test` from the
parent directory for staging, timeline and summary coverage.

CI restores through the authenticated Azure SDK npm mirror. Keep credentials,
local data and private dashboard source out of this package.

## Diagnosing a failed publication

The result artifact records a sanitized operation, error code and HTTP status.
Raw requests, tokens and evaluation content are not logged.

- `acquire_storage_token`: check service-connection federation and token acquisition.
- `publish_blob` with `AuthorizationPermissionMismatch`/403: check the connection
   identity's Blob data role and its scope; do not substitute an account key.
- `publish_blob` with network errors or `AuthorizationFailure`: check approved agent
   egress/storage network rules before assuming the RBAC grant is missing.
- `submission_conflict`: retain the original bytes and use a new Summary attempt
   for corrected content; never overwrite existing history.

Successful CLI login does not prove Blob or notification access. Do not broaden
network/security settings to hide a failed request.
