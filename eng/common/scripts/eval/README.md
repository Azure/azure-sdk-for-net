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
  its own pnpm package/lock for **fflate only** and CLI/PowerShell tests. Shard evaluator
  restores do not install it; publication adds no Node Azure SDK dependencies.

## Extending a shard job

The shared `eng/common/pipelines/templates/jobs/eval-shard.yml` owns checkout,
Node/Vally installation, MCP staging, git fixture initialization and Copilot login.
Its defaults preserve the standard Prepare/Eval/Summary pipeline behavior.
Repo-local adapters can customize it without copying that infrastructure:

| Parameter | Contract |
| --- | --- |
| `matrixStageName` | Stage containing `generate_eval_matrix`; defaults to `Prepare`. The eval stage must depend on it. |
| `artifactNamespace` | Optional track namespace, e.g. `forced`. Common adds the separator: `eval-result-forced-<shard>-<attempt>` / `eval-debug-forced-<shard>-<attempt>`. Empty preserves existing names. Configure the matching summary with the same namespace. |
| `preEvalTemplate` / `postEvalTemplate` | Existing parameter-free setup/teardown step templates. |
| `evalInvokeTemplate` | Existing invocation template accepting `vallyRoot`, `UseAzSdkAuthentication` and `threshold`. |
| `azureSubscription` | Existing invoke service-connection setting, also forwarded by the stage/job when using the common invoke template. |
| `vallyArguments` | Optional array of supplementary Vally option/value pairs. Strings are required except that trial/worker counts also accept numbers. Available through the stage, shard job and common invoke template. Defaults to `[]`. |

Supported supplementary options are `--tag`, `--runs`, `--workers` and `--timeout`.
For example, `['--tag', 'mode=forced', '--runs', '3']` selects a local benchmark
configuration without replacing the common runner. Trial/worker counts must be
positive integer strings or safe integer numbers. Azure template expansion can
serialize numeric parameters as JSON numbers even when using `format`; the runner
validates and converts only `--runs` / `--workers` numeric values to strings.
All other options and values must be strings. Both authentication branches forward the array as JSON in
`VALLY_ARGUMENTS_JSON`; the runner passes literal arguments to the pinned CLI using
Node directly, without a shell or whitespace splitting of supplementary values.
Unsupported flags (including aliases and `--flag=value`) are rejected. Eval
selection, output paths, JUnit, plugins and verdict settings remain framework-owned.
Legacy custom invoke templates retain their existing parameter contract when the
array is empty. A custom template opting into a non-empty array must declare its
own `vallyArguments` parameter; otherwise template compilation rejects it.

Use the existing pre/post-eval and MCP setup hooks for repository-specific work.
Do not replace authentication, result collection or retry/completeness checks.
Supplementary reports must not rewrite JUnit thresholds or raw results.

For multiple tracks in one build, use a distinct artifact namespace and configure
the common summary's `matrixStageName`, `evalStageName` and `artifactNamespace`
to match the shard job. Each Summary stage must depend on both its Prepare and
Eval stages. Timeline attempts are checked against that exact Eval stage, and
only that namespace's latest verified attempts are selected. Namespaced tracks
support artifact-only summaries: dashboard bundles/publication are rejected
because the archive identity currently represents one build-wide Summary.

## Complete build results and direct Blob publishing

Shards now retain the newest invocation's raw JSONL, JUnit and a completion marker
via [shard-results](lib/shard-results.ts), including failed evaluations.
Summary checks the full Prepare matrix and selects the artifact matching each
shard's latest timeline attempt once for Markdown, the Tests tab and bundling. Missing, interrupted or
corrupt results remain incomplete; later failed attempts never fall back to older
successful artifacts. A separate step reads the current-build timeline with
`System.AccessToken` and three bounded transient retries, saving the latest attempt
evidence beside the summary. Rendering reads that file and needs no token or network.
If that exact attempt has no artifact, older JUnit is not copied or counted.
Missing or invalid timeline evidence also excludes unverified diagnostics and blocks publication.
Matching latest-attempt JUnit remains available when its result data is incomplete.
The legacy JUnit-only
summary remains supported. No historical build download or reconstruction is involved.
The bundler accepts exactly one already-selected attempt per expected shard; it
does not repeat Summary's selection or accept an ambiguous list of attempts.

The [publishing step](../../pipelines/templates/steps/eval-publish-results.yml) restores
the archive dependency with **pnpm 12.6.0** from the **default JavaScript feed**, prepares one saved ZIP
and a checksum/identity descriptor, then runs [Publish-EvalResults.ps1](publisher/Publish-EvalResults.ps1)
under `AzureCLI@2` using `eval-dashboard-sc`. The script uses `az storage blob upload`,
not a custom SDK transport. There is no enterprise checkout, dashboard file upload,
evaluator rerun or container creation. Bundle metadata is passed explicitly by YAML;
neither bundling nor upload interprets DevOps environment variables or publishing policy.
Shard/Summary jobs and publisher CI use Node 24; the publisher requires **24.14.1+**,
matching the specs repository. Its frozen `pnpm-lock.yaml` retains the reviewed
SHA512 checksum and no private registry URLs. `--ignore-workspace` prevents a
consumer's workspace from changing the install or pulling in unrelated packages.
The pipeline uses Node's bundled npm only to bootstrap the exact pnpm version into
the agent's temporary directory, with lifecycle scripts disabled. The same
authenticated `.npmrc` is used by both commands; no global tools are changed.
`--pm-on-fail=ignore` avoids pnpm resolving/downloading itself again after that
explicit bootstrap, without changing dependency checks or the frozen lock.

| Control | Current use |
| --- | --- |
| `publishDashboardResults` | The only checkbox; defaults to `true` in the three tools entrypoints. Set `false` to disable both upload and Azure Storage egress |
| `EvalStorageAccountName` | Pipeline-owner configuration. Upload is skipped when absent; set it to `evaltestsummary` for this dashboard |
| `EvalDashboardRefreshUrl` | Pipeline-owner configuration: `https://azsdk-eval-bue6a7dwanatgpb3.westus3-01.azurewebsites.net/api/refresh` |
| `EvalDashboardResource` | Pipeline-owner configuration: `api://258998df-81ec-460c-bdd7-56a9bdde1e48` (resource URI, not a `/.default` scope) |
| `createDashboardBundle` | Shared-template artifact-only mode; enabled for all three tools entrypoints |

The pipeline owner must set **`EvalStorageAccountName=evaltestsummary`** and the two
dashboard variables above in each onboarded DevOps pipeline, with **queue-time
override disabled** and edit permissions restricted. These settings are trusted
deployment configuration: the owner must verify the dashboard URL/API pairing.
The task passes values through environment mapping, never by evaluating their contents
as script code. This source change does not configure DevOps or grant
access. The dashboard reads that account's existing `vally-results` container;
publishing to another account does not redirect the reader. Service-connection
authorization, approved branch checks and existing RBAC remain required.

Publishing policy stays in YAML: organization `https://dev.azure.com/azure-sdk/`,
project `internal`, repository `Azure/azure-sdk-tools`, exact `refs/heads/main`, and
a CI, scheduled or manual reason. There is no hardcoded definition-ID allowlist or
variable template in shared code. Feature branches, other repositories, PRs, pull
refs and public-project runs do not get the credential-bearing task. At runtime it
also requires a complete summary and a configured storage account.

There is no separate automatic-publication, feature-branch override or network-access
flag. Publication requests the documented
[AzureStorage policy](https://aka.ms/1es/netiso/pipelinetemplates), which
keeps `DefaultDeny, CFSClean, CFSClean2, CFSClean3` and allows Azure Storage egress
for **all processes in that pipeline**, not just one container. It grants no RBAC
access. DevOps pipeline-stored variables are runtime values and cannot select a
compile-time 1ES policy: the checkbox and trusted-run checks select egress, while
the account variable additionally gates upload. An enabled trusted run can therefore
have storage egress even if the account variable is absent, but cannot upload.
Set the checkbox to `false` for artifact-only runs with no added storage egress.
Shared templates still default to no publication. Keep approvals, network restrictions
and existing consumer defaults unchanged.

These entrypoints run real evaluations and consume model quota; there is no synthetic
pipeline mode. Completed failed evaluations publish before their existing test gate;
missing or incomplete results fail Summary and cannot publish.

### Archive and retry contract

For this dashboard, configure account `evaltestsummary`; the container remains `vally-results`.
An archive uses `v1/<org>/<encoded-project>/<definition>/<build>/<Summary-attempt>/dashboard-bundle.zip`.
It contains a schema-v1 manifest, executed plain-eval JSONL trials, Markdown and JUnit,
never debug files, MCP binaries or unrelated workspace contents. Non-executed skips
remain in raw artifacts and JUnit/Markdown; an entirely skipped shard is incomplete.

Reader limits are **32 MiB ZIP, 128 MiB expanded, 10,000 entries and 100,000 trials**.
Canonical identities, UTC calendar dates, safe entries and counts are validated
before upload. Blob metadata records schema, SHA-256, hashed publisher identity and
the original storage time; Azure RBAC remains the authorization boundary.
Construction checks every required non-empty input, merged byte/trial limits and
the total entry count, including merged JSONL, before creating the ZIP. The final
compressed-size cap is checked afterward. Full ZIP decoding remains in contract
tests rather than reopening the archive in production. JSONL is decoded once and
parsed directly as text, with byte limits on both source and serialized records.

Uploads use `--auth-mode login --overwrite false --if-none-match=*` with the **same
saved ZIP**; Azure CLI owns transport retries, without another script/task retry loop.
The condition is one argument so Linux does not expand a standalone `*` into file names.
`--no-progress` keeps CLI progress out of captured command results. JSON is parsed
from stdout only; captured native stderr is never mixed into JSON or echoed.
Request/socket timeouts and the task deadline bound execution. Existing archives must match metadata,
owner, checksum and size. Changed content needs a new Summary attempt, not an overwrite.
The publisher never deletes archives; the dashboard's separate identity stays read-only.
The upload is confirmed and logged before notification. No local publication status
file is written; a failed notification does not change the stored archive or fail upload.

### Notification and recovery

Every successful publication attempts to send only `{blobName, sha256}` to
`EvalDashboardRefreshUrl`, using a token for `EvalDashboardResource`. No production
dashboard URL or API ID is hardcoded in the script. The URL must be a canonical
HTTPS App Service address ending exactly in `/api/refresh`, with no credentials,
nondefault port, query or fragment; the resource must be `api://<API-client-ID>`.
Validation happens before requesting a notification token. Missing or invalid
configuration preserves the uploaded archive, sends no token and warns.
The storage OAuth resource `https://storage.azure.com/` remains a platform constant,
not a deployment destination. For the values above, Azure CLI requests a token for
`api://258998df-81ec-460c-bdd7-56a9bdde1e48`; the dashboard
validates the Entra v2 token's GUID `aud`, not the `api://` resource string.
The application needs `Dashboard.Refresh` permission and the receiver's Easy Auth
client allowlist. Blob permission alone does not grant notification access.

Signals are bounded to 2 KiB, retry at most four times, honor `Retry-After` and never
follow redirects. Failure is a warning after durable upload. Browser reload/startup
and daily reconciliation recover missed signals without changing source archives.
Do not replace viewer authentication or network restrictions to make a signal succeed.

### Publisher tests and diagnostics

With **Node 24.14.1+ and pnpm 12.6.0**, run `pnpm --ignore-workspace install
--pm-on-fail=ignore --frozen-lockfile --prod --ignore-scripts` and
`pnpm --ignore-workspace --pm-on-fail=ignore test` from `publisher`,
then `node --experimental-strip-types --test` from this directory.
These shared Node tests do not need Tools-owned CI files, PowerShell tests or
the consuming repository's redirect settings. A consumer-copy regression runs
them without Tools files or Git history, with absent and different redirect templates.

In Tools, run `Invoke-Pester -Path eng/common-tests/eval/Publish-EvalResults.Tests.ps1 -CI`
from the repository root for the **PowerShell 7.4+ / Pester 5 / Azure CLI** tests. That Tools-only
suite also checks the Tools CI wiring and network policy. The existing common-tests
PR pipeline runs both the shared/archive Node tests and this tagged PowerShell suite;
failures fail the CI job. Other repositories do not need to copy this Tools test setup.
Pipeline upload uses the agent's authenticated Azure CLI.
CI restores only the locked archive dependency, not the Vally evaluator.
Regression coverage includes the actual HTTP
cmdlet against loopback, invalid collision metadata, upload-before-notification
ordering and publication without local status files.
One integration test also runs the real Azure CLI against a localhost-only Blob
fixture with synthetic credentials and an isolated CLI profile. It verifies one
successful upload does not trigger a fallback read. No production storage is used.
Construction regressions exercise the exact entry/trial boundaries, aggregate
expanded bytes, final compressed bytes, required inputs and UTF-8 JSONL limits.
The loopback fixture selects the first Node application when CI has multiple Node
installations on `PATH`. Configuration tests use synthetic hosts/resources and
prove invalid targets cannot request or receive notification tokens.
Tests use synthetic fixtures and fake Azure transports;
they do not evaluate models or contact production services. A real-run test remains
separate from local checks and should use an already approved evaluation run.

The task logs the stored Blob name and notification outcome. Failures include a
bounded operation/error code, never raw Azure responses, tokens or result contents.
CLI failures include the exit code and a fixed known storage error code, when
available. If the fallback read also fails, the original upload code is retained.
Token acquisition failures require checking the
service connection; Blob 403 requires checking its data-role scope; network failures
require checking approved egress. Preserve the original archive for conflicts, and
retry the signal or the same saved bytes for outages. Never substitute account keys,
relax TLS or broaden permissions to hide a failed request.

## TypeScript (no build step)

The `*.ts` sources run directly through Node's native type stripping (erasable syntax only —
no `enum`/`namespace`/parameter properties, no emit). Matrix/Shard/Summary jobs and publisher
CI use Node `24.x`; both evaluator projects and the publisher require `>=24.14.1`,
matching azure-rest-api-specs. Relative imports use explicit `.ts` specifiers, as Node requires.
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
