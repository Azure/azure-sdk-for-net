# eval-scripts (CI glue + pinned Vally CLI)

This folder holds the TypeScript glue the Vally eval CI runs (matrix sharding, the shard
runner, the JUnit summary) **and** pins the [`@microsoft/vally-cli`](https://www.npmjs.com/package/@microsoft/vally-cli)
version those shards install. The CLI and its full transitive dependency tree are locked by
the committed `package-lock.json` instead of resolved fresh from semver ranges on every run.
It lives under `eng/common` so it syncs to every repo that consumes the shared eval pipeline
templates.

- This evaluator package's only dependency is `@microsoft/vally-cli`, pinned to the version CI should evaluate with.
- `package-lock.json` must be committed so `npm ci` is deterministic.
- Optional Blob publication is isolated in [publisher](publisher/), with
  its own small package/lock and tests. Shard evaluator restores do not install it.

## Complete build results and direct Blob publishing

Shards now retain the newest invocation's raw JSONL, JUnit and a completion marker
via [shard-results](lib/shard-results.ts), including failed evaluations.
Summary checks the full Prepare matrix and selects each expected shard's highest
attempt once for Markdown, the Tests tab and bundling. Missing, interrupted or
corrupt results remain incomplete; later failed attempts never fall back to older
successful artifacts. The selected-results path requires valid current-build
timeline evidence, read during selection with three bounded transient retries.
Unverified or ambiguous attempts cannot authorize publication. The legacy JUnit-only
summary remains supported. No historical build download or reconstruction is involved.

The [publishing step](../../pipelines/templates/steps/eval-publish-results.yml) restores
the publisher's small dependency lock, prepares one saved ZIP, and uploads it through
`AzureCLI@2` using `eval-dashboard-sc`. There is no enterprise checkout, dashboard
upload, evaluator rerun or container creation. The storage container and notification
target are fixed in [storage.ts](publisher/storage.ts), not queue-time/environment inputs.

| Control | Current use |
| --- | --- |
| `autoPublishDashboardResults` | Entrypoints default to `true`; disable to opt out of trusted tools main publication |
| `publishDashboardResults` | Explicit publication for an approved internal feature-branch run |
| `allowAzureStorageNetworkAccess` | Explicit pipeline-wide Azure Storage egress for that publishing run |
| `createDashboardBundle` | Shared-template artifact-only mode; enabled for all three tools entrypoints |

Automatic publication requires organization `https://dev.azure.com/azure-sdk/`,
project `internal`, repository `Azure/azure-sdk-tools`, pipeline ID **8255** (workflow),
**8256** (skill) or **8246** (live), exact `refs/heads/main`, and a CI, scheduled or
manual reason. Other repositories/definitions and feature branches stay opt-in.
PRs, pull refs and public-project runs cannot receive the publishing task.

For an approved feature-branch run, enable both explicit publication and network
access. The documented [AzureStorage policy](https://aka.ms/1es/netiso/pipelinetemplates)
keeps `DefaultDeny, CFSClean, CFSClean2, CFSClean3` and allows Azure Storage egress
for **all processes in that pipeline**, not just one container. It grants no RBAC
access. Other synced consumers need matching `AllowAzureStorage` support in their
repo-owned 1ES redirect; nothing is forwarded unless they opt in. Keep approvals,
network restrictions and existing consumer defaults unchanged.

These entrypoints run real evaluations and consume model quota; there is no synthetic
pipeline mode. Completed failed evaluations publish before their existing test gate;
missing or incomplete results fail Summary and cannot publish.

### Archive and retry contract

The fixed container is `https://evaltestsummary.blob.core.windows.net/vally-results`.
An archive uses `v1/<org>/<encoded-project>/<definition>/<build>/<Summary-attempt>/dashboard-bundle.zip`.
It contains a schema-v1 manifest, executed plain-eval JSONL trials, Markdown and JUnit,
never debug files, MCP binaries or unrelated workspace contents. Non-executed skips
remain in raw artifacts and JUnit/Markdown; an entirely skipped shard is incomplete.

Reader limits are **32 MiB ZIP, 128 MiB expanded, 10,000 entries and 100,000 trials**.
Canonical identities, UTC calendar dates, safe entries and counts are validated
before upload. Blob metadata records schema, SHA-256, hashed publisher identity and
the original storage time; Azure RBAC remains the authorization boundary.

Uploads use create-only `ifNoneMatch: *`, at most four attempts with the **same saved
bytes**, honoring bounded backpressure. Existing archives must match metadata,
owner, checksum and size. Changed content needs a new Summary attempt, not an overwrite.
The publisher never deletes archives; the dashboard's separate identity stays read-only.
Local storage receipts are replaced atomically before any notification. Later
notification/status-save failures cannot erase the retained successful storage result.

### Notification and recovery

Every successful publication sends only `{blobName, sha256}` to the reviewed
`https://azsdk-eval-bue6a7dwanatgpb3.westus3-01.azurewebsites.net/api/refresh` endpoint.
The publisher requests `api://258998df-81ec-460c-bdd7-56a9bdde1e48/.default`; the dashboard
validates the Entra v2 token's GUID `aud`, not the `api://` resource string.
The application needs `Dashboard.Refresh` permission and the receiver's Easy Auth
client allowlist. Blob permission alone does not grant notification access.

Signals are bounded to 2 KiB, retry at most four times, honor `Retry-After` and never
follow redirects. Failure is a warning after durable upload. Browser reload/startup
and daily reconciliation recover missed signals without changing source archives.
Do not replace viewer authentication or network restrictions to make a signal succeed.

### Publisher tests and diagnostics

Run `npm ci --ignore-scripts` and `npm test` from `publisher` (`npm.cmd` on Windows),
then `npm test` from this directory. Tests use synthetic fixtures and fake transports;
they do not evaluate models or contact production services. A real-run test remains
separate from local checks and should use an already approved evaluation run.

The saved result includes a bounded operation/error code/HTTP status, never raw SDK
requests, tokens or result contents. Token acquisition failures require checking the
service connection; Blob 403 requires checking its data-role scope; network failures
require checking approved egress. Preserve the original archive for conflicts, and
retry the signal or the same saved bytes for outages. Never substitute account keys,
relax TLS or broaden permissions to hide a failed request.

## TypeScript (no build step)

The `*.ts` sources run directly through Node's native type stripping (erasable syntax only —
no `enum`/`namespace`/parameter properties, no emit). CI pins Node `22.x`, which strips types
unflagged on `>=22.18`; the pipeline `node` invocations and the `npm test` script pass
`--experimental-strip-types` so the same sources also run on older local Node (`>=22.6`), which
prints a harmless `ExperimentalWarning`. Relative imports use explicit `.ts` specifiers, as Node requires.
The standalone Blob publisher uses the same execution model; it adds no compiler or TypeScript runtime dependency.

## Vendored files

- `lib/exec.ts` was **copied from azure-rest-api-specs** (`.github/shared/src/exec.js`
  @ `ef7dd74c13aa9ca12b67b33b9dc4b5d1419a46f0`) and ported to TypeScript. It lives here under
  `eng/common` (rather than the specs repo's `.github/shared` path) so it travels with the
  eng/common sync into the language repos. Re-vendor from upstream rather than editing locally;
  see [azure-sdk-tools#16296](https://github.com/Azure/azure-sdk-tools/issues/16296) for the plan
  to share these primitives instead of copying.

## Updating the Vally CLI version

1. Bump `@microsoft/vally-cli` in `package.json`.
2. Run `npm install --package-lock-only --registry https://registry.npmjs.org/` to refresh `package-lock.json`.
3. Commit both files in the same PR. The eval pipelines' path triggers include
   `eng/common/scripts/eval/**`, so CI re-runs against the new version automatically.

## Local use

Reproduce what CI does by installing from the same lockfile and invoking the local binary:

```sh
cd eng/common/scripts/eval
npm ci
cd ../../../..
./eng/common/scripts/eval/node_modules/.bin/vally lint .
```

This uses the same locked CLI as CI. A passing local run does not validate the
agent's credentials, network access, artifact permissions or live-service behavior.

A global install (`npm install -g @microsoft/vally-cli@<version>`) still works for ad-hoc iteration, but it won't match the transitive dependency tree CI uses and isn't a substitute for the steps above when validating a version bump.
