# Release History

## 1.0.0-preview.11 (Unreleased)


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
