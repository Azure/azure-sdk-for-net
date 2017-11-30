# Changelog for the Azure Data Factory V2 .NET SDK

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
