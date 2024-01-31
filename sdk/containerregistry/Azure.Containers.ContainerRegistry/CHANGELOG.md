# Release History

## 1.2.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.1 (2023-12-13)

### Bugs Fixed

- Fixed an issue where content client `DownloadBlobStreaming()` method would throw for blobs greater than 2GB in size. ([#37113](https://github.com/Azure/azure-sdk-for-net/pull/37113))
- Fixed an issue in the ACR client to enable redirects due to the change in Azure.Core 1.33.0, which made redirects disabled by default. ([#39377](https://github.com/Azure/azure-sdk-for-net/issues/39377))

## 1.2.0-beta.1 (2023-07-12)

### Bugs Fixed

- Fixed an issue where content client `DownloadBlobStreaming()` method would throw for blobs greater than 2GB in size.

## 1.1.0 (2023-05-09)

- General availability release of `ContainerRegistryContentClient`.

### Breaking Changes

- Added sanity check for manifest size at download time:  if the manifest is bigger than 4MB, `RequestFailedException` will be thrown.

## 1.1.0-beta.9 (2023-04-11)

### Features Added

- Added a `DownloadStreaming()` method to `ContainerRegistryContentClient`.  This method returns a network stream in the returned result that the caller must dispose after use.
- Added overloads to the `DownloadBlobTo()` method that take a file path instead of a Stream.
- Exceptions returned from service methods will now have the ErrorCode value populated when it is available in the service's error response.

### Breaking Changes

- Renamed `ContainerRegistryBlobClient` to `ContainerRegistryContentClient`.
- Moved `ContainerRegistryContentClient` and related types into main namespace.
- Removed `MaxChunkSize` property from `ContainerRegistryClientOptions`.
- Renamed `ContainerRegistryContentClient.DownloadBlob()` method to `DownloadBlobContent()`.
- Renamed `DownloadBlobResult` to `DownloadRegistryBlobResult`.
- Renamed `UploadBlobResult` to `UploadRegistryBlobResult`.
- Renamed `ContainerRegistryContentClient.DownloadManifest()` to `GetManifest()` and `DownloadManifestResult` to `GetManifestResult`.
- Renamed `ContainerRegistryContentClient.UploadManifest ()` to `SetManifest()` and `UploadManifestResult` to `SetManifestResult`.
- Renamed `GetManifestResult.Content` name to `GetManifestResult.Manifest`.
- Removed `GetManifestResult.AsOciManifest()` method in favor of `BinaryData.ToObjectFromJson<OciImageManifest>()`.
- Changed `Url`, `Source` and `Documentation` properties on `OciAnnotations` type to `Uri` type.
- Renamed `OciAnnotations.Config` to `OciAnnotations.Configuration`.

### Other Changes

- Removed requirement to pass `Audience` property on `ContainerRegistryClientOptions` in order to create any client instance.

## 1.1.0-beta.8 (2023-03-13)

### Features Added

- Added `SizeInBytes` to `UploadBlobResult` to prevent the need to check stream length on a possibly non-seekable stream.

### Breaking Changes

- Renamed `OciBlobDescriptor` to `OciDescriptor`.

## 1.1.0-beta.7 (2023-03-07)

### Features Added

- Added overloads to `ContainerRegistryBlobClient.DownloadManifest()` method that allow caller to specify multiple manifest media types in a collection.
- Added overloads to `ContainerRegistryBlobClient` methods `UploadBlob()` and `UploadManifest()` that take the content to upload as a `BinaryData`.

### Breaking Changes

- Removed `UploadBlobOptions` type and moved chunk size configuration into ClientOptions.
- Reordered parameters in `ContainerRegistryBlobClient` constructor for consistency with other SDK clients.
- Renamed `OciAnnotations.Size` to `OciAnnotations.SizeInBytes` and removed `Size` parameter from `UploadBlobResult` type.
- Changed the name of `OciManifest` to `OciImageManifest`.

## 1.1.0-beta.6 (2023-02-07)

### Features Added

- Added method `DownloadBlobTo()` to `ContainerRegistryBlobClient`.  This method downloads a blob to a provided Stream, using multiple requests if the blob size exceeds the maximum chunk size.
- Added an optional `ManifestMediaType` parameter to `UploadManifest()` to enable uploading image manifests of any type.
- Added `MediaType` property to `DownloadManifestResult` to enable checking the media type prior to deserializing returned manifest.

### Breaking Changes

- Changed signatures of `DownloadManifest()` and `UploadManifest()` methods on `ContainerRegistryBlobClient`.
- Removed `DownloadManifestOptions` and `UploadManifestOptions` types.
- Removed `ArtifactManifest` type.
- Removed `Manifest` and `ManifestStream` properties from `DownloadManifestResult`.

## 1.1.0-beta.5 (2023-01-10)

### Features Added

- `ContainerRegistryBlobClient.UploadBlob()` method now uploads a blob using multiple requests if it exceeds the maximum chunk size.  Chunk size defaults to 4MB and can be modified by passing `UploadBlobOptions`.
- Added `Pipeline` property to `ContainerRegistryClient` and `ContainerRegistryBlobClient` to enable advanced message processing scenarios.

### Breaking Changes

- Changed type of `Manifest` property on `DownloadManifestResult` from `OciManifest` to `ArtifactManfest` to accommodate non-OCI manifest types in the future.  Callers must now downcast `Manifest` to the appropriate type.

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

- Added an overload for `UploadManifest(Async)` method that takes the manifest `Stream` as an input.
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
