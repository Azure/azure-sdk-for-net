# eval-scripts (CI glue + pinned Vally CLI)

This folder holds the TypeScript glue the Vally eval CI runs (matrix sharding, the shard
runner, the JUnit summary) **and** pins the [`@microsoft/vally-cli`](https://www.npmjs.com/package/@microsoft/vally-cli)
version those shards install. The CLI and its full transitive dependency tree are locked by
the committed `package-lock.json` instead of resolved fresh from semver ranges on every run.
It lives under `eng/common` so it syncs to every repo that consumes the shared eval pipeline
templates.

- This evaluator package's only dependency is `@microsoft/vally-cli`, pinned to the version CI should evaluate with.
- `package-lock.json` must be committed so `npm ci` is deterministic.
- Optional Blob publication is isolated in [publisher](publisher/README.md), with
  its own small package/lock and tests. Shard evaluator restores do not install it.

## Complete build results and direct Blob publishing

Shards now retain the newest invocation's raw JSONL, JUnit and a completion marker
via [stage-eval-results.ts](stage-eval-results.ts), including failed evaluations.
Summary checks the full Prepare matrix and selects each expected shard's highest
attempt once for Markdown, the Tests tab and bundling. Missing, interrupted or
corrupt results remain incomplete; later failed attempts never fall back to older
successful artifacts. No historical build download or reconstruction is involved.

The shared archetype supports opt-in `createDashboardBundle` and
`publishDashboardResults`, with `storageServiceConnection`/`storageContainerUrl`.
The workflow entrypoint exposes these for pipeline 8255 and defaults publishing
to `false`; setting it to `true` writes directly to Blob using `AzureCLI@2`.
There is no dashboard ZIP upload or enterprise repository checkout.

For a draft-branch end-to-end test, `storageSmokeTest=true` selects two labeled
synthetic shards with no MCP/LLM/evaluation calls, then uses the real Summary
publisher. A manual run of the trusted feature branch is required; PR validation
never receives the publishing task. See [publisher setup and smoke-test steps](publisher/README.md).
Dashboard synchronization and notification authentication remain separate from
successful Blob storage and are not enabled by this pipeline change.

## TypeScript (no build step)

The `*.ts` sources run directly through Node's native type stripping (erasable syntax only —
no `enum`/`namespace`/parameter properties, no emit). CI pins Node `22.x`, which strips types
unflagged on `>=22.18`; the pipeline `node` invocations and the `npm test` script pass
`--experimental-strip-types` so the same sources also run on older local Node (`>=22.6`), which
prints a harmless `ExperimentalWarning`. Relative imports use explicit `.ts` specifiers, as Node requires.

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

This matches the CI job step-for-step, so a green local run on the current lockfile means a green CI run.

A global install (`npm install -g @microsoft/vally-cli@<version>`) still works for ad-hoc iteration, but it won't match the transitive dependency tree CI uses and isn't a substitute for the steps above when validating a version bump.
