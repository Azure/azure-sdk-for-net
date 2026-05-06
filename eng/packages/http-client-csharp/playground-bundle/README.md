# playground-bundle

Self-contained tooling that bundles the `@azure-typespec/http-client-csharp`
emitter package and uploads it to the typespec playground blob storage
(`https://typespec.blob.core.windows.net/pkgs/`).

The uploaded `<pkgName>/latest.json` import map is consumed by the in-browser
TypeSpec playgrounds (e.g. the [Azure playground](https://azure.github.io/typespec-azure))
via their `additionalPlaygroundPackages` configuration.

## Files

- `package.json` / `package-lock.json` — dependencies pinned for reproducibility.
- `upload.mjs` — the upload script. Mirrors `bundleAndUploadStandalonePackage`
  from microsoft/typespec's `@typespec/bundle-uploader` package.

## How it is invoked

The emitter's [`ci.yml`](../ci.yml) wires this script into the
`InitializationSteps` of the shared `archetype-typespec-emitter.yml`
template. Those steps run in every job of the pipeline, but the upload
steps are conditioned on the Test stage (`System.StageName == 'Test'`)
of internal main-branch CI runs only — at that point the Build stage's
`build_artifacts` (which include the `npm pack`-ed emitter tarball) has
already been downloaded to `$(Pipeline.Workspace)/build_artifacts/packages`.

For each qualifying run, the pipeline:

1. Runs `npm ci` in this folder to install the uploader's pinned deps.
2. Extracts the emitter tarball produced by the Build stage to a temp
   directory (it contains the stamped `package.json` + `dist/`).
3. Invokes `node upload.mjs --package-path <extracted-dir> --version <stamped-version>`
   inside an `AzureCLI@2` task that authenticates against the
   `TypeSpec Storage` service connection.

The bundler is run directly against the extracted package's `dist/`, so no
additional emitter build step is required. The explicit `--version` argument
is passed to keep the manifest version aligned with the version that the
Build stage actually packed.

## Why this lives here (and not in `eng/common`)

`eng/common` is auto-synced from `azure-sdk-tools` and must not be edited from
this repo. Vendoring the uploader here keeps the playground-bundle workflow
self-contained inside `eng/packages/http-client-csharp/`.
