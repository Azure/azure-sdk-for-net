# Release History

## 1.1.0-beta.5 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0-beta.4 (2022-04-05)

### Features Added

- Unifies features from the earlier preview releases with the latest stable release.

## 1.0.0 (2022-01-11)

### Features Added

- Adds stable features and bug fixes from the earlier preview releases.

### Breaking Changes

- Renamed `ArtifactManifestOrderBy` to `ArtifactManifestOrder`.
- Renamed `ArtifactTagOrderBy` to `ArtifactTagOrder`.

## 1.0.0-beta.5 (2021-11-18)

### Features Added
- Updated the supported service version to "2021-07-01".
- Added support to create instances of `ArtifactManifestProperties` using the `ContainerRegistryModelFactory`.

## 1.1.0-beta.3 (2021-11-09)

### Features Added

- Added support for [anonymous pull access](https://docs.microsoft.com/azure/container-registry/anonymous-pull-access#configure-anonymous-pull-access) using the `ContainerRegistryBlobClient`

## 1.1.0-beta.2 (2021-10-13)

### Features Added

- Added an overload for `UploadManifest(Async) method that takes the manifest `Stream` as an input.
- Added methods in `ContainerRegistryModelFactory` that create instances of `DownloadBlobResult`, `DownloadManifestResult`, `UploadBlobResult` and `UploadManifestResult` for mocking.
- Added `DownloadManifestOptions` type to allow callers to  pass-in either a tag or a digest in `DownloadManifest(Async)`.
- Added `ManifestStream` as a property in `DownloadManifestResult` that contains the raw manifest stream from the service response.

### Breaking Changes

- Changed `DownloadManifest(Async)` method to take `DownloadManifestOptions` as an input parameter. This allows callers to pass-in either a tag or a digest as the manifest identifier.

## 1.1.0-beta.1 (2021-09-07)

### Features Added

- Added `ContainerRegistryBlobClient` with methods to upload and download OCI Manifests and artifact blobs, to enable implementation of push/pull for OCI artifacts.

## 1.0.0-beta.4 (2021-08-10)

### Breaking Changes

- Replaced `AuthenticationScope` property on `ContainerRegistryClientOptions` with `Audience`.  `Audience` is of type `ContainerRegistryAudience`, a statically typed string, which allows customers to select from available audiences or provide their own audience string.  All calls to client constructors now require passing `ContainerRegistryClientOptions` with the `Audience` property set.

### Other Changes

- Updated documentation comments.

## 1.0.0-beta.3 (2021-06-08)

### Features Added

- Added `ContainerRegistryModelFactory` for use in mocking library types.
- Added `AuthenticationScope` option on `ContainerRegistryClientOptions` to allow setting the AAD scope for national clouds.

### Breaking Changes

- Removed `ContentProperties` type in favor of per resource property types such as `ArtifactManifestProperties`.
- Renamed `Pageable` APIs with the `Collection` suffix.
- Removed `LoginServer`, `Name`, and `RegistryUri` from `ContainerRegistryClient`.
- Removed `TagOrDigest` from `RegistryArtifact` and renamed `FullyQualifiedName` to `FullyQualifiedReference`.
- Removed `DeleteRepositoryResult` type and return `Response` from `DeleteRepository` methods.
- Various other renames for consistency and clarity.

## 1.0.0-beta.2 (2021-05-11)

### Features Added

- Added support for accessing ACR anonymously via two new constructors on `ContainerRegistryClient`.
- Added caching of the ACR refresh token during the authentication token exchange to reduce per operation network calls to the service.
- Updated API to have a single client as an entry point, `ContainerRegistryClient`, with two helper classes, `ContainerRepository` and `RegistryArtifact`, for resource-specific service calls.
- Added strongly typed string constants for `ArtifactArchitecture` and `ArtifactOperatingSystem`.
- Renamed methods operating on a manifest to have `Manifest` in their names.

### Breaking Changes

- Removed `ContainerRepositoryClient`.
- Renamed `GetRepositories` to `GetRepositoryNames` on `ContainerRegistryClient`.

## 1.0.0-beta.1 (2021-04-06)

- Started changelog to capture release notes.
