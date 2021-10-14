# Release History

## 1.0.0-preview.5 (Unreleased)

### Features Added

- Repository metadata KPIs are stored in the client instance. When metadata is stale,
  the next service operation that can make use of metadata will first attempt to
  fetch and refresh the client metadata state. The operation will then continue as normal.
- Adds the `ModelsRepositoryClientMetadataOptions` class and plumbing with `ModelsRepositoryClientOptions` to configure
  client interactions with repository metadata.
- Default metadata expiration is effectively "never" or `TimeSpan.MaxValue` by default.

## 1.0.0-preview.4 (2021-07-22)

- Consumes new service metadata capability
- Simplifies client API surface area:
  - Removes model dependency resolution configuration in the `ModelsRepositoryClientOptions`
    (and the pattern of the client constructor setting a default resolution option).
  - Removes `ModelDependencyResolution.TryFromExpanded`. TryFromExpanded becomes an internal processing concept.
    The metadata of a target repository will indicate if expanded model forms are available.
  - Model dependency resolution configuration becomes scoped to the service operation level.
    The `GetModels[Async]` service operations have their `dependencyResolution` parameter set to `ModelDependencyResolution.Enabled` by default.

## 1.0.0-preview.3 (2021-04-12)

- Updated core dependencies to bring in security vulnerability fixes that are addressed in `Azure.Core v1.13.0` and `System.Memory.Data v1.0.2`

## 1.0.0-preview.2 (2021-03-30)

### Breaking changes

- Changing the package namespace from `Azure.Iot.ModelsRepository` to `Azure.IoT.ModelsRepository`

## 1.0.0-preview.1 (2021-03-10)

### New features

- Initial preview of Azure.IoT.ModelsRepository SDK

### Breaking changes

- N/A

### Added

- N/A

### Fixes and improvements

- N/A
