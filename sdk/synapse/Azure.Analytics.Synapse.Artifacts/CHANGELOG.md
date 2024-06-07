# Release History

## 1.0.0-preview.21 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-preview.20 (2024-06-07)
### Features Added
- Model Dataset has a new parameter LakeHouseLocation
- Model Dataset has a new parameter GoogleBigQueryV2ObjectDataset
- Model Dataset has a new parameter PostgreSqlV2TableDataset
- Model Dataset has a new parameter SalesforceServiceCloudV2ObjectDataset
- Model Dataset has a new parameter SalesforceV2ObjectDataset
- Model Dataset has a new parameter ServiceNowV2ObjectDataset
- Model Dataset has a new parameter SnowflakeV2Dataset
- Model Dataset has a new parameter WarehouseTableDataset
- Model Pipeline has a new parameter ExpressionV2
- Model Pipeline has a new parameter GoogleBigQueryV2Source
- Model Pipeline has a new parameter LakeHouseTableSink
- Model Pipeline has a new parameter LakeHouseTableSource
- Model Pipeline has a new parameter LakeHouseWriteSettings
- Model Pipeline has a new parameter LakeHouseReadSettings
- Model Pipeline has a new parameter Metadata
- Model Pipeline has a new parameter MetadataItem
- Model Pipeline has a new parameter ParquetReadSettingsstate
- Model Pipeline has a new parameter PostgreSqlV2Source
- Model Pipeline has a new parameter SalesforceServiceCloudV2Sink
- Model Pipeline has a new parameter SalesforceServiceCloudV2Source
- Model Pipeline has a new parameter SalesforceV2Sink
- Model Pipeline has a new parameter SalesforceV2SourceReadBehavior
- Model Pipeline has a new parameter SalesforceV2Source
- Model Pipeline has a new parameter ServiceNowV2Source
- Model Pipeline has a new parameter SnowflakeV2Sink
- Model Pipeline has a new parameter SnowflakeV2Source
- Model Pipeline has a new parameter WarehouseSink
- Model Pipeline has a new parameter WarehouseSource
- Model LinkedService add supports GoogleAds
- Model LinkedService has a new parameter GoogleBigQueryV2LinkedService
- Model LinkedService has a new parameter LakeHouseLinkedService
- Model LinkedService has a new parameter PostgreSqlV2LinkedService
- Model LinkedService has a new parameter SalesforceServiceCloudV2LinkedService
- Model LinkedService has a new parameter SalesforceV2LinkedService
- Model LinkedService has a new parameter SalesforceV2LinkedService
- Model LinkedService has a new parameter SnowflakeV2LinkedService
- Model LinkedService has a new parameter WarehouseLinkedService
- Model LinkedService has a new parameter WarehouseLinkedService

### Breaking Changes
- Model LinkedService parameter MariaDBLinkedService update new properties
- Model LinkedService parameter MySqlLinkedService update new properties
- Model LinkedService parameter ServiceNowV2LinkedService update properties
- Model Pipeline parameter ExecuteDataFlowActivity update new properties computeType
- Model Pipeline parameter ScriptActivityScriptBlock update properties type

## 1.0.0-preview.19 (2023-10-30)
- Fix runNotebook sessionId from int to string
- Fix placeholder links causing 404s
- Sync expression Support From DataFactory To Synapse

## 1.0.0-preview.18 (2023-08-08)
- Added `authenticationType`, `containerUri`, `sasUri` and `sasToken` properties to BlobService 
- Added `setSystemVariable` proprety to SetVariableActivityTypeProperties
- Added `mongoDbAtlasDriverVersion` property to MongoDbAtlasLinkedServiceTypeProperties
- Added `ActionOnExistingTargetTable` property for Synapse Link
- Added `OutputColumn` Object For Office365Source outputColumns
- Added `configurationType` ,`targetSparkConfiguration` and `sparkConfig` properties for SynapseNotebookActivityTypeProperties
- Added `credential` property for LinkedService
- Added `isolationLevel` property for SQLServerSource
- Added new apis of Create/Cancel/GetStatus/GetSnapshot for RunNotebook

## 1.0.0-preview.17 (2023-01-10)
- Added `workspaceResourceId` to AzureSynapseArtifactsLinkedServiceTypeProperties
- Added `pythonCodeReference`, `filesV2`, `scanFolder`, `configurationType`, `targetSparkConfiguration` and `sparkConfig` properties to SparkJobActivity
- Added `authHeaders` proprety to RestServiceLinkedService
- Added new apis of Pause/Resume for Synapse Link
- Added PowerBIWorkspaceLinkedService

## 1.0.0-preview.16 (2022-09-13)
- Updated LinkConnection for Synapse Link
- Added TargetSparkConfiguration property for SparkJobDefinition and Notebook
- Added GoogleSheets connector
- Added SAP ODP connector
- Added support OAuth2ClientCredential auth in RestSevice
- Added support rejected data linked service in dataflow sink
- Added Dataworld, AppFigures, Asana, Twilio connectors
- Added Fail Activity

## 1.0.0-preview.15 (2022-04-07)
- Added LinkConnectionOperations.

## 1.0.0-preview.14 (2022-03-08)
- Added ScriptActivity.
- Added missing properties in SynapseNotebookActivity and SparkJobActivity.
- Added TeamDeskLinkedService/QuickbaseLinkedService/SmartsheetLinkedService/ZendeskLinkedService.

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
