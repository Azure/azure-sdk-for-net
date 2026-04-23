# playground-bundle

Self-contained tooling used by the shared `archetype-typespec-emitter.yml`
pipeline template to bundle a TypeSpec emitter package and upload it to the
typespec playground blob storage (`https://typespec.blob.core.windows.net/pkgs/`).

The uploaded `<pkgName>/latest.json` import map is consumed by the in-browser
TypeSpec playgrounds (e.g. the [Azure playground](https://azure.github.io/typespec-azure))
via their `additionalPlaygroundPackages` configuration.

## Files

- `package.json` — dependencies pinned for reproducibility.
- `upload.mjs` — the upload script. Mirrors `bundleAndUploadStandalonePackage`
  from microsoft/typespec's `@typespec/bundle-uploader` package.

## How it is invoked

The `archetype-typespec-emitter.yml` template runs `npm ci` in this folder
and then invokes `node upload.mjs --package-path <path> --version <stamped-version>`
inside an `AzureCLI@2` task that authenticates against the `TypeSpec Storage`
service connection.

Pipelines opt in by setting `UploadPlaygroundBundle: true` on
`archetype-typespec-emitter.yml`. The bundler is run directly against the
package's already-built `dist/` (produced by `Build-Emitter.ps1`), so no
additional build step is required. The explicit `--version` argument is
needed because `Build-Emitter.ps1` restores `package.json` after packing,
which would otherwise cause the bundle manifest to record the
non-prerelease version from source control.
