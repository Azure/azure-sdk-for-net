# Changelog for the Azure Data Factory V2 .NET SDK

## Current version

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
