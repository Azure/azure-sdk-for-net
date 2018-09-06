# Changelog for the Azure Data Factory V2 .NET SDK

## Current version

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
* Azure Data Factory new capabilities now fall under General Availability SLA. ADF has made cloud data integration easier than ever before. Build, schedule and manage data integration at scale wherever your data lives, in cloud or on-premises, with enterprise-grade security. Accelerate your data integration projects with over 70 data source connectors available, please refer to https://docs.microsoft.com/en-us/azure/data-factory/copy-activity-overview. Transform raw data into finished, shaped data that is ready for consumption by BI tools or custom applications. Easily lift your SQL Server Integration Services (SSIS) packages to Azure and let ADF manage your resources for you so you can increase productivity and lower TCO, please refer to https://docs.microsoft.com/en-us/sql/integration-services/lift-shift/ssis-azure-lift-shift-ssis-packages-overview?view=sql-server-2017. Meet your security and compliance needs while taking advantage of extensive capabilities and paying only for what you use. The ADF GA SDK changes include the following:
        -	The API 'removeNode’ on IR has been removed and replaced with DELETE API on IR node.
        -	The API 'POST pipelineRuns’ was renamed to 'POST queryPipelineRuns’ and 'PipelineRunFilterParameters’ was renamed to 'RunFilterParameters’.
        -	The API 'GET activityRuns’ using pipeline run id has been replaced with 'POST queryActivityRuns’. It also takes RunFilterParameters object in the body to provide more options to query and order the result.
        -	The API 'GET triggerRuns’ has been replaced with 'POST queryTriggerRuns’ and was moved to factory scope. This one too takes RunFilterParameters object in the body similar to previous query runs APIs.
        -	The API 'cancelPipelineRun’ has been moved to PipelineRuns operations and renamed to 'Cancel’.
        -	The property 'vstsConfiguration’ on factory resource has been renamed to repoConfiguration.
        -	Pipeline has new properties called 'userProperties’ which can be used to improve the run monitoring experience
        -	The error response format has been changed. It is now compliant with other Azure ARM services. Before the API-s were returning ErrorResponse object with code, message, target and details. Now, it returns CloudError object with another 'error’ object nested inside that contains code, message, target and details.
        -	Added If-Match header support on put calls and If-None-Match header support for get calls for ADF resources and sub resources.
        -	The response of 'PATCH' API on IR has been fixed to return the IR resource.
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
