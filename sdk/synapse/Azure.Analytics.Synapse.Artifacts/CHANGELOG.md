# Release History

## 1.0.0-preview.14 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-preview.13 (2022-01-11)
- Added `MetastoreOperations`.

## 1.0.0-preview.12 (2021-11-09)
- Added data flow flowlet
- `KqlScriptContentCurrentConnection` now has poolName and databaseName properties

## 1.0.0-preview.11 (2021-10-05)
- Upgrade to [package-artifacts-composite-v1](https://github.com/Azure/azure-rest-api-specs/blob/bee724836ffdeb5458274037dc75f4d43576b5e3/specification/synapse/data-plane/readme.md#tag-package-artifacts-composite-v1)
- Added `SparkConfigurationClient`, `KqlScriptsClient` and associated support types.
- Update type of many modles from string to object
- `SparkJobDefinition`, `Notebook` and `SqlScript` now has a folder property
- `SqlScript` now has poolName and databaseName properties

## 1.0.0-preview.10 (2021-05-13)
### Key Bug Fixes
- LibraryRestClient.Append method nows includes comp parameter (https://github.com/Azure/azure-rest-api-specs/pull/13841)

## 1.0.0-preview.9 (2021-05-11)
### Key Bug Fixes
- Updated dependency versions.
- Improved deserialization of optional parameters (https://github.com/Azure/azure-sdk-for-net/issues/20051) 

## 1.0.0-preview.8 (2021-04-06)

### Added
- Many additional model classes

### Changed
- Exposed Serialization and Deserialization methods.

## 1.0.0-preview.7 (2021-03-17)

### Added
- Many models classes now have public getters.
- Added new `LibraryClient` and associated support types.

## 1.0.0-preview.6 (2021-02-10)

### Added
- Many models classes are now public.
- Added `BigDataPoolsClient`, `IntegrationRuntimesClient`, `SqlPoolsClient`, `WorkspaceClient` and associated support types.
- Added `Workspace`, `LastCommitId`, and `TenantId` on `Workspace`.
- Supports List/Get Synapse resources through data plane APIs.
- Support Rename operations.
- Support CICD operations.
- Improved samples and documentation.

### Changed
- Changed APIs on `SparkJobDefinitionClient` and `SqlScriptClient` to provide a Long Running Operation (LRO) when operations can be long in duration.
- Removed `HaveLibraryRequirementsChanged` and added `DynamicExecutorAllocation` on `BigDataPoolResourceInfo`.
- Removed `BabylonConfiguration` and added `PurviewConfiguration` on `Workspace`.
- `BlobEventTypes` renamed to `BlobEventType`.

### Fixed
- Make `name` as required parameter for `NotebookResource` and `SqlScriptResource`

## 1.0.0-preview.4 (2020-09-01)
- Added test cases.
- This release contains bug fixes to improve quality.

## 1.0.0-preview.3 (2020-08-18)

### Fixed
- Bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

## 1.0.0-preview.2 (2020-08-13)

- Added support for long running operation.

- Added generated model classes.

## 1.0.0-preview.1 (2020-06-10)
- Initial release
