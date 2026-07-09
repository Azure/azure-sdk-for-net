# eval-scripts (CI glue + pinned Vally CLI)

This folder holds the JavaScript glue the Vally eval CI runs (matrix sharding, the shard
runner, the JUnit summary) **and** pins the [`@microsoft/vally-cli`](https://www.npmjs.com/package/@microsoft/vally-cli)
version those shards install. The CLI and its full transitive dependency tree are locked by
the committed `package-lock.json` instead of resolved fresh from semver ranges on every run.
It lives under `eng/common` so it syncs to every repo that consumes the shared eval pipeline
templates.

- The only dependency should be `@microsoft/vally-cli`, pinned to the version CI should evaluate with.
- `package-lock.json` must be committed so `npm ci` is deterministic.

## Updating the Vally CLI version

1. Bump `@microsoft/vally-cli` in `package.json`.
2. Run `npm install` locally to refresh `package-lock.json`.
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
