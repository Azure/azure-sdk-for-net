# playground-bundle

Self-contained tooling that bundles a TypeSpec emitter package and uploads it
to the typespec playground blob storage (`https://typespec.blob.core.windows.net/pkgs/`).

The uploaded `<pkgName>/latest.json` import map is consumed by the in-browser
TypeSpec playgrounds (e.g. the [Azure playground](https://azure.github.io/typespec-azure))
via their `additionalPlaygroundPackages` configuration.

## Files

- `package.json` / `package-lock.json` — dependencies pinned for reproducibility.
- `upload.mjs` — the upload script. Mirrors `bundleAndUploadStandalonePackage`
  from microsoft/typespec's `@typespec/bundle-uploader` package.

## How it is invoked

The shared [`archetype-typespec-emitter.yml`](../pipelines/templates/archetype-typespec-emitter.yml)
template exposes an `UploadPlaygroundBundle` parameter. When a consuming
`ci.yml` sets `UploadPlaygroundBundle: true`, the archetype's Build job — on
non-PR runs in the internal project — invokes:

```
npm ci      # in eng/playground-bundle/
node ./upload.mjs --package-path <emitter-path> --version <stamped-version>
```

inside an `AzureCLI@2` task that authenticates against the `TypeSpec Storage`
service connection. The bundler runs against the emitter's already-built
`dist/` (produced by the preceding `Build-Emitter.ps1` step), so no
additional build step is required. The explicit `--version` argument is
passed because `Build-Emitter.ps1` restores `package.json` after packing,
which would otherwise cause the manifest to record the non-stamped source
version.

## Why this lives here (and not in `eng/common`)

The shared archetype template was copied out of `eng/common/` (which is
auto-synced from `azure-sdk-tools` and must not be edited) into
`eng/pipelines/templates/`. The associated playground-bundle helper folder
moves alongside it and is referenced from the local archetype as
`eng/playground-bundle/`.
