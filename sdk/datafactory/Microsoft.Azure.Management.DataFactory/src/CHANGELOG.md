# Changelog for the Azure Data Factory V2 .NET SDK

## Version 4.13.0
###  Feature Additions
- Added publicNetworkAccess property to datafactory
- Added logSettings property into CopyActivity
- Added connectionProperties property into Concur linkedService
- Added authenticationType and sessionToken properties into AmazonS3 linkedService
- Added support for more frequency types for TumblingWindowTrigger
- Set computeType, coreCount to object type to allow expressions
- Change property PartitionOption type to object for NetezzaSource, OracleSource, SapHanaSource, SapTableSource, SqlDWSource, SqlMISource, SqlServerSource, SqlSource, TeradataSource. 

## Version 4.12.0
###  Feature Additions
- Added logLevel/enableReliableLogging to LogStorageSettings
- Support Tar GZip compression type in Data Factory
- Added maxRowPerFile/fileNamePrefix to tabular format settings
- Added support for AzureDatabricks delta lake
- Update Rest Sink properties
- Added support lzo in orc format
- Added MongoDbAtlas Source Connector in DataFactory

## Version 4.11.0
###  Feature Additions
- Added support for Trigger Run Cancel API
- Added column delimiter for SAP Table/open hub
- Added azureCloudType for Aad Auth
- Added snapshot to Azure File Storage linked service
- Support HDFS for delete activity and deleteFilesAfterCompletion feature in copy activity
- Added support for managed Virtual Network and managed private endpoint CRUD APIs
- Added Support for Query EC List API
- Added more options on XML and CosmosDbSqlApi copy source
- Fix bug: Added AzureFileStorageWriteSettings

## Version 4.10.0
###  Feature Additions
- Added connectionProperties property to QuickBooks, Square, Xero, Zoho, SalesforceMarketingCloud linked service
- Added support of Message server connecting from SAP Open Hub
- Enable Sql Sources (AzureSqlDatabase, SqlSever, Synapse, SqlMI) read in parallel, support partition by dynamic range and sql built-in partitions.
- Added Rest as Sink Type in Copy Sink
- Added NewClusterLogDestination property to Azure Databricks linked service
- Support expression (object) type for data flow staging folder path
- Add new type "AzPowerShellSetup" to parameter "ExpressCustomSetup" for "AzureRmDataFactoryV2IntegrationRuntime" cmd to install Azure PowerShell

## Version 4.9.0
###  Feature Additions
- Added support for specifying a linked service as a Data Flow source and sink type
- Added support for providing a schema linked service reference within Data Flow sources and sinks
- Added support for xml dataset in ADF
- Added support for excel dataset in ADF
- Added new type conversion support in Copy activity
- Added support for copying data to and from Snowflake using copy activity
- Added package store support for Azure-SSIS integration runtime
- Added httpRequestTimeout for ODataSource, SapEccSource, SapCloudForCustomerSource, SapCloudForCustomerSink, DynamicsAXSource
- Added SharePointOnlineListConnector
- Added auth by accountKey/SASuri to azure file connector
- Added prefix filter to azure file source
- Added fileFilter to file server source
- Added partitionRootPath to binary connector
- Added an option to support unzip file directly to target folder

## Version 4.8.0
###  Feature Additions
- Added new API to query on triggers with filters like type and parentTrigger
- Fixed offset value validation in self dependency and trigger dependency for tumbling window trigger, now accepts negative offsets
- Introduced a new rerunTumblingWindowTrigger which can rerun multiple windows of an existing tumblingWindowTrigger with independent concurrency
- Added rerun from failed activity support for create pipeline run
- Added apiVersion property and set SecurityToken from required to optional for Salesforce
- Added connectionString property to DB2 linked service
- Added useTempFileRename to SFTP sink
- Added additionalColumns for copy source
- Added validate data consistency for copy activity
- Added support session log for copy activity
- Added isolationLevel for sql source
- Added expiryDateTime for ADLS Gen1 source
- Added fileListPath for binary sources

## Version 4.7.0
###  Feature Additions
- Added compute support in execute data flow activity

## Version 4.6.0
###  Feature Additions
- Added SAP HANA partition support in Copy Activity
- Added property prefix for azure blob source
- Added support for writing data into SFTP server using Copy activity

## Version 4.5.0
###  Feature Additions
- Added SQL DW Copy Command support in Copy Activity
- Added report status on callback support for webhook activity

## Version 4.4.0
###  Feature Additions
- Added Serve-to-Server authentication type for Dynamics 365, Dynamics CRM and Common Data Service for Apps connector
- Changed Username from required to optional in Dynamics 365, Dynamics CRM and Common Data Service for Apps connector
- Added Compression codec proprty to Orc dataset
- Added embedded package properties for ssis activity
- Added AKV support for webhook activity
- Added new optional property "connectVia" in Web activity

## Version 4.3.0
###  Feature Additions
- Added Switch activity
- Added AzureMLExecutePipeline activity
- Added AzureMLService linked service type
- Added support for Expressions for Arguments property on HDInsightPig activity

## Version 4.2.0
###  Feature Additions
* Added support for Data Flow:
    - Added data flow object model and CRUD APIs
    - Added data flow debug session APIs
    - Added support for execute data flow activity type
    - Added support for data flow properties in managed integration runtime
- Added property queryTimeout to tabular sources
- Added support for Cosmos DB SQL API dataset and copy source/sink
- Add dedicated linkedservice/dataset/source for Azure File Storage;
- Add dedicated linkedservice/dataset/source for GoogleCloudStorage;

## Version 4.1.3
###  Feature Additions
- Added RunDimension to Pipeline
- Added Chaining Trigger
- Added Dependency Status property in Pipeline and Trigger Run
- Added outputColumns property to Office365Source
- Added support for ORC dataset in ADF
- Added alternateKeyName property to DynamicsSink, DynamicsCrmSink and CommonDataServiceForAppsSinkCommonDataServiceForAppsSink
- Added property blockSizeInMB to Blobsink and BlobFSsink
- Added support for custom setup without script properties for a SSIS integration runtime
- Added support for instance pools in Databricks linked service

## Version 4.1.2
###  Feature Additions
- Added SapBwCube and Sybase dataset
- Added support for the follwoing new datasets in ADF - AvroDataset, along with source and sink for Copy activity
- AvroDataset will support following locations  AzureBlobStorageLocation, AzureBlobFSLocation, AzureDataLakeStoreLocation, AmazonS3Location, FileServerLocation, FtpServerLocation, SftpLocation, HttpServerLocation, HdfsLocation
- Added support for Json dataset in ADF
- Added support for the following new datasets in ADF - AmazonRedshiftTableDataset, AzureMySqlSink, Db2TableDataset
- Split tableName to schema and table in multiple datasets
- Added new API to rerun a trigger run
- Added new API for subscribing and unsubscribing triggers to events, and getting a triggers event subscription status

## Version 4.1.1
###  Feature Additions
- Add PostgreSql Sink
- Add Partition settings for Oracle, SapTable
- Add dedicated source and dataset for several relational sources including ODBC, MySql
- Add Azure Data Explorer Command activity, which allows users executing Kusto Control Commands
- Update PostgreSql Dataset to use a dedicated AzurePostgreSqlTableDatasetTypeProperties

## Version 4.1.0
###  Feature Additions
### Breaking Changes
- Fixed missing types CopyTranslator and TabularTranslator.
- Added support in Copy for MicrosoftAccessTable, InformixTable, SalesforceServiceCloudObject, AzureSqlMITable, DynamicsCrmEntity, CommonDataServiceForAppsEntity, TeradataTable, Binary, which inhcludes their Dataset, Linked Service, CopySource, and CopySink types
- Added TeradataTable CopySource support
- Added logLocation property to ExecuteSSISPackageActivity
- Added SSIS File system support by expanding SSISPackageLocation to support SSISDB and File location types

## Version 4.0.0
###  Feature Additions
### Breaking Changes
- Added support for the follwoing new datasets in ADF - ParquetDataset, DelimitedTextDataset, SapTableResourceDataset
- ParquetDataset will support following locations  AzureBlobStorageLocation, AzureBlobFSLocation, AzureDataLakeStoreLocation, AmazonS3Location, FileServerLocation, FtpServerLocation, SftpLocation, HttpServerLocation, HdfsLocation
- Added support for parameterization to a number of properties
- The table name is not required anymore for AzureSqlTable, AzureSqlDWTable, SqlServerTable
- Added a new property dataProxyProperties to Integration Runtime
- Added new SapTable Linked Services type
- Added types for Read and Write Connector settings in activities - AzureBlobStorageReadSettings, AzureBlobFSReadSettings, AzureDataLakeStoreReadSettings, AmazonS3ReadSettings, FileServerReadSettings, FtpReadSettings, SftpReadSettings, HttpReadSettings, HdfsReadSettings,
AzureBlobStorageWriteSettings, AzureBlobFSWriteSettings, AzureDataLakeStoreWriteSettings, FileServerWriteSettings, FormatReadSettings, DelimitedTextReadSettings, FormatWriteSettings, DelimitedTextWriteSettings
- Added new Copy sources - SapTableSource, SqlServerSource, AzureSqlSource
- Added new Copy sinks - ParquetSink, SqlServerSink, AzureSqlSink

## Version 3.0.2
###  Feature Additions
    - Added new Validation and Webhook activities
    - Added annotation property to Trigger resource 

## Version 3.0.1
###  Feature Additions
    - Fixed AzureFunctionActivity
    - Added support for RestService Source
    - Added support for SAP BW Open Hub Source
    - Added support for collectionReference
    - Added recovery mode for more advanced pipeline run retry capabilities (i.e. from a specific activity)
    - Added newClusterDriverNodeType, newClusterInitScripts, and newClusterEnableElasticDisk properties to DataBricks linked service
    - Added retentionTimeInDays property to CustomActivity
    - New connectors supported as Copy source:
        * Office365
        * Native MongoDB
        * CosmosDB MongoDB API
        * ADLS Gen2
        * Dynamics AX
        * Azure Data Explorer
        * Oracle Service Cloud
        * GoogleAdWords
    - New connector supported as copy sink:
        * ADLS Gen2
        * CosmosDB MongoDB API
        * Azure Data Explorer
    - Added support for incremental copy of files based on the lastModifiedTime for S3, File and Blob
    - Added support to copy data from ADLS Gen1 to ADLS Gen2 with ACL
    - Added support for ServiceUrl in the existing S3 linked service
    - Added support for AADServicePrincipal authentication in OData linked service
    - Added support for maxConcurrentConnections in copy source and sink

## Version 3.0.0
###  Feature Additions
    - Added new APIs: 
        * get DataPlane access 
        * get and refresh Integration Runtime object metadata
        * get feature value
    - Added new activity and linked service types to support Azure Functions
        - Added support for HDIngsight cluster with Enterprise Sercurity package
        - Updated exisitng activities and datasets:
        * Added 'tableName' property in datasets
        * Refactored Delete activity payload by adding more properties
        * Added support for expressions for SSIS activity property 'type'
        * Added WinAuth support in SSIS activity
        * Added 'schema' property to datasets

## Version 2.3.0
###  Feature Additions
    - Added variables support to Pipelines
    - Added new AppendVariable and SetVariable activities
    - Added support for SecureInput in activities
    - Added ScriptActions to on demand HDI linked service
    - Added support for recursive Cancel operation on runs
    - Added TumblingWindowRerunTrigger API

## Version 2.2.0
###  Feature Additions
    - Added folders to Pipeline and Dataset
    - Added TumblingWindowTrigger dependsOn, offset and size properties
    - Added new API to get GitHub access token
    - Added new property on Databricks linked Service to set Spark environment variables
    - Fixed the casing in JSON for FactoryGitHubConfiguration 

## Version 2.1.0
###  Feature Additions
* Added support for AzureBlob AAD Authentication
* Added support for AzureStorage 2 new Linked Service type: AzureBlobStorage, AzureTableStorage

## Version 2.0.0
###  Feature Additions
### Breaking Changes
* Updated UserProperties type in Activities

## Version 1.1.0
###  Feature Additions
* Added support for sharing self-hosted integration runtime across data factories and subscriptions
* Added support for Databricks Spark Jar and Databricks Spark Python activities

## Version 1.0.0
### Feature Additions
* Azure Data Factory new capabilities now fall under General Availability SLA. ADF has made cloud data integration easier than ever before. Build, schedule and manage data integration at scale wherever your data lives, in cloud or on-premises, with enterprise-grade security. Accelerate your data integration projects with over 70 data source connectors available, please refer to https://docs.microsoft.com/azure/data-factory/copy-activity-overview. Transform raw data into finished, shaped data that is ready for consumption by BI tools or custom applications. Easily lift your SQL Server Integration Services (SSIS) packages to Azure and let ADF manage your resources for you so you can increase productivity and lower TCO, please refer to https://docs.microsoft.com/sql/integration-services/lift-shift/ssis-azure-lift-shift-ssis-packages-overview?view=sql-server-2017. Meet your security and compliance needs while taking advantage of extensive capabilities and paying only for what you use. The ADF GA SDK changes include the following:
        -    The API 'removeNode’ on IR has been removed and replaced with DELETE API on IR node.
        -    The API 'POST pipelineRuns’ was renamed to 'POST queryPipelineRuns’ and 'PipelineRunFilterParameters’ was renamed to 'RunFilterParameters’.
        -    The API 'GET activityRuns’ using pipeline run id has been replaced with 'POST queryActivityRuns’. It also takes RunFilterParameters object in the body to provide more options to query and order the result.
        -    The API 'GET triggerRuns’ has been replaced with 'POST queryTriggerRuns’ and was moved to factory scope. This one too takes RunFilterParameters object in the body similar to previous query runs APIs.
        -    The API 'cancelPipelineRun’ has been moved to PipelineRuns operations and renamed to 'Cancel’.
        -    The property 'vstsConfiguration’ on factory resource has been renamed to repoConfiguration.
        -    Pipeline has new properties called 'userProperties’ which can be used to improve the run monitoring experience
        -    The error response format has been changed. It is now compliant with other Azure ARM services. Before the API-s were returning ErrorResponse object with code, message, target and details. Now, it returns CloudError object with another 'error’ object nested inside that contains code, message, target and details.
        -    Added If-Match header support on put calls and If-None-Match header support for get calls for ADF resources and sub resources.
        -    The response of 'PATCH' API on IR has been fixed to return the IR resource.
        - The 'cloudDataMovementUnits' property of Copy activity has been renamed to 'dataIntegrationUnits'

* Remove maxParallelExecutionsPerNode limitation

## Version 0.8.0-preview
### Feature Additions
* Added Configure factory repository operation
* Updated QuickBooks LinkedService to expose consumerKey and consumerSecret properties
* Updated Several model types from SecretBase to Object
* Added Blob Events trigger

## Version 0.7.0-preview
### Feature Additions
* Added execution parameters and connection managers property on ExecuteSSISPackage Activity
* Updated PostgreSql, MySql llinked service to use full connection string instead of server, database, schema, username and password
* Removed the schema from DB2 linked service
* Removed schema property from Teradata linked service
* Added LinkedService, Dataset, CopySource for Responsys

## Version 0.6.0-preview
### Feature Additions
* Added new AzureDatabricks LinkedService and DatabricksNotebook Activity
* Added headNodeSize and dataNodeSize properties in HDInsightOnDemand LinkedService
* Added LinkedService, Dataset, CopySource for SalesforceMarketingCloud
* Added support for SecureOutput on all activities 
* Added new BatchCount property on ForEach activity which control how many concurrent activities to run
* Added new Filter Activity
* Added Linked Service Parameters support

## Version 0.5.0-preview
### Feature Additions
* Enable AAD auth via service principal and management service identity for Azure SQL DB/DW linked service types
* Support integration runtime sharing across subscription and data factory
* Enable Azure Key Vault for all compute linked service
* Add SAP ECC Source
* GoogleBigQuery support clientId and clientSecret for UserAuthentication
* Add LinkedService, Dataset, CopySource for Vertica and Netezza

## Version 0.4.0-preview
### Feature Additions
* Add readBehavior to Salesforce Source
* Enable Azure Key Vault support for all data store linked services
* Add license type property to Azure SSIS integration runtime

## Version 0.3.0-preview
### Feature Additions
* Add SAP Cloud For Customer Source
* Add SAP Cloud For Customer Dataset
* Add SAP Cloud For Customer Sink
* Support providing a Dynamics password as a SecureString, a secret in Azure Key Vault, or as an encrypted credential.
* App model for Tumbling Window Trigger
* Add LinkedService, Dataset, Source for 26 RFI connectors, including: PostgreSQL,Google BigQuery,Impala,ServiceNow,Greenplum/Hawq,HBase,Hive ODBC,Spark ODBC,HBase Phoenix,MariaDB,Presto,Couchbase,Concur,Zoho CRM,Amazon Marketplace Services,PayPal,Square,Shopify,QuickBooks Online,Hubspot,Atlassian Jira,Magento,Xero,Drill,Marketo,Eloqua.
* Support round tripping of new properties using additionalProperties for some types
* Add new integration runtime API's: patch integration runtime; patch integration runtime node; upgrade integration runtime, get node IP address
* Add integration runtime naming validation

## Version 0.2.1-preview
### Feature Additions
* Cancel pipeline run api.
* Add AzureMySql linked service.
* Add AzureMySql table dataset.
* Add AzureMySql Source.
* Add Dynamics Sink
* Add SalesforceObject Dataset
* Add Salesforce Sink
* Add jsonNodeReference and jsonPathDefinition to JSONFormat
* Support providing Salesforce passwords and security tokens as SecureStrings or as secrets in Azure Key Vault.

## Version 0.2.0-preview
### Feature Additions
* Initial public release of the Azure Data Factory V2 .NET SDK.
