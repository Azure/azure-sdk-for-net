# Release History

## 1.0.0-beta.4 (Unreleased)

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
