# Release History

## 1.10.0 (2025-09-03)

### Features Added
- Added Managed Identity (MI) authentication support for Lakehouse, Warehouse, and HDInsight linked services.
- Added support for custom number precision and scale in Oracle V2.

## 1.9.0 (2025-06-13)

### Features Added

- Added property to Spark V2 linked service definition.
- Added property to Hive V2 linked service definition.
- Added Databricks Activity to dataFactory pipeline.

### Bugs Fixed
- Fixed ExpressionV2 for value type from string to object.

## 1.8.0 (2025-05-09)

### Features Added

- Added support for Amazon RDS for Oracle V2 linked service.
- Added property to Azure Databricks linked service definition.
- Added certificate authentication support for Microsoft 365 SharePoint linked service.
- Added Snowflake V2 linked service definition.

## 1.7.0 (2025-03-18)

### Features Added

- Added swagger support for handling multiple result sets in Snowflake scripts.
- Added connection properties to LinkedService definitions for Greenplum V2 support.
- Added support for Teradata connection properties and Teradata sink.
- Added support for Oracle connection properties.
- Added support for PostgreSQL Entra.

### Bugs Fixed

- Fixed the sncMode property of the LinkedService in SAPTable.
- Fixed the problem of an unknown linked service type 'LakeHouse'.

## 1.6.0 (2024-11-11)

### Features Added

- Added support for additional MySQL connection properties.
- Added support for Azure PostgreSQL v2, updated connection strings, and corrected Linked JSON configurations.

## 1.5.0 (2024-10-24)

### Features Added

- Add pageSize support to Salesforce V2 Source.
- Add pageSize support to ServiceNow V2 Source.
- Add host property to Snowflake linked service.
- Exposed `JsonModelWriteCore` for model serialization procedure.

### Bugs Fixed

- Fix missing authenticationType in PostgreSQL V2 linked service.

## 1.4.0 (2024-09-10)

### Features Added
- Added support for Iceberg format as a sink.
- Enabled sslMode and useSystemTrustStore options for MariaDB.

## 1.3.0 (2024-08-16)

### Features Added

- Enhanced Swagger to support Vertica V2 integration in Azure Data Factory.
- Added Managed Identity (MI) authentication support for Azure Files.
- Introduced versioning property for better version control.
- Implemented Service Principal Certificate Authentication in RestService and SharePointOnlineList Linked Services.

## 1.2.0 (2024-07-26)

### Features Added

- Security enhancement feature snowflake support storage integration.
- Supported 'domain' Property In Dynamics Family.
- Enabled UAMI auth for Data Factory Sql Server connector.
- Supported managed identity for Data Factory Azure Table connector.

### Bugs Fixed

- Added missing continuation settings for execute dataflow activity.

## 1.1.0 (2024-05-31)

### Features Added

- Added new app model properties for SQL Server family connectors for Data Factory and Synapse.
- Added query property for Salesforce V2.
- Added lakehouse table dataset schema property.
- Added credential property in DynamicsCrm for new feature.
- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.
- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Bugs Fixed

- Fixed headers schema issue.
- Corrected Swagger definitions for SPN, UAMI, and SAMI credentials.

### Other Changes

- Updated Python configuration.
- Changed ScriptActivityScriptBlock type property to support parameterization.
- Updated Swagger for ServiceNowV2 expression app model.
- Removed redundant credential resources in the .NET SDK.
- Removed UAMI and SAMI credentials since they will be resolved as ManagedIdentity.

## 1.0.0 (2024-03-14)

This release is the first stable release of the Data Factory Management client library.

### Features Added

- Improved Salesforce V2 properties.
- Added ServiceNowV2 linkedService, dataSet.
- Added GoogleBigQuery linkedService, dataSet.
- Added PostgreSqlV2 linkedService, dataSet.
- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).
- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Bugs Fixed

- Fixed headers and schema definition.
- Fixed DataFactoryResource.GetPipelineRuns cannot do pagination.

## 1.0.0-beta.6 (2024-01-26)

### Features Added

- Added warehouse linkedService, dataSet
- Added snowflake v2 linkedService, dataSet
- Added SalesforceV2 and SalesforceCloudServiceV2 linkedService, dataSet
- Update MySql & Mariadb LinkedService.json with new properties.

### Bugs Fixed

- Fixed headers and schema definition bug for Azure Function activity and Web Activity.
- Added metadata Into StoreWriteSettings For Bug Fixed.

## 1.0.0-beta.5 (2023-11-16)

### Features Added

- Upgraded API version.
  - Added Some Properties on GoogleAds Connector.
  - Added Supported LakeHouse Connector In ADF.
- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

## 1.0.0-beta.4 (2023-09-26)

### Features Added

- Upgraded API version.

### Bugs Fixed

- Fixed an issue that exception throws when `Uri` type field is empty during deserialization of `SelfHostedIntegrationRuntimeStatus`.

## 1.0.0-beta.3 (2023-08-02)

### Features Added

- Supported the new `DataFactoryElement<T>` expression type property.
- Upgraded API version.

### Other Changes

- Upgraded Azure.Core to 1.34.0.
- Upgraded Azure.ResourceManager to 1.7.0.

## 1.0.0-beta.2 (2022-08-29)

### Breaking Changes

Polishing since last public beta release:
- Prepended `DataFactory` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that don't follow [Microsoft .NET Naming Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://learn.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.0

## 1.0.0-beta.1 (2022-07-12)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.DataFactory` to `Azure.ResourceManager.DataFactory`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Supported MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Supported [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Supported uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
