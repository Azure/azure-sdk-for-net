# Release History

## 1.0.0-preview.7 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-preview.6 (2024-04-22)

### Features Added

- Updates the DTMI convention to be aligned with DTDL v3 requirements, to allow _versionless_ and `major.minor`

## 1.0.0-preview.5 (2021-11-04)

### Features Added

- Adds the `ModelsRepositoryClientMetadataOptions` class and plumbing with `ModelsRepositoryClientOptions` to configure
  client interactions with repository metadata.
- When repository metadata fetching is enabled (the default), service operations that can make use of metadata such as GetModels,
  will first attempt to fetch and store repository metadata state. The operation then continues as normal.
  This will happen one time per instance lifetime.
- Renames client method GetModels[Async] to GetModel[Async]
- Removes the multiple dtmis overload of the GetModel[Async] methods.
- Adds the `ModelResult` type, returned from the GetModel[Async] methods. `ModelResult` encompasses requested model content.

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
