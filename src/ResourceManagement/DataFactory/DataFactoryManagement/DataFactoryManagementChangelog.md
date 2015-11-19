For additional details on features, see the full [Azure Data Factory Release Notes](https://azure.microsoft.com/en-us/documentation/articles/data-factory-release-notes). 

## Version 4.2.0
Release date: 2015.11.10

### Feature Additions

* New Activity type: AzureMLUpdateResource, along with a new optional property in the Azure ML Linked Service, "updateResourceEndpoint". 
    * This Activity takes as input a blob Dataset for an .iLearner file (e.g. produced as output of a retraining batch execution) and uploads it to the indicated management endpoint.
* Add LongRunningOperationInitialTimeout and LongRunningOperationRetryTimeout properties to DataFactoryManagementClient. 
    * Allow configuration of the timeouts for client calls to the Data Factory service. 

### Bug Fixes
* Properly initialize the internal client object wrapped by 
  Microsoft.Azure.Management.DataFactories.DataFactoryManagementClient in all constructors. 

## Version 4.1.0 
_Release date: 2015.10.28_

### Feature Additions
* The following linked service types have been added: 
    * AzureDataLakeStoreLinkedService
    * AzureDataLakeAnalyticsLinkedService
* The following activity types have been added: 
    * DataLakeAnalyticsUSQLActivity
* The following dataset types have been added: 
    * AzureDataLakeStoreDataset
* The following source and sink types for Copy Activity have been added:
    * AzureDataLakeStoreSource
    * AzureDataLakeStoreSink

## Bug Fixes
* Successful gateway creation response has status Succeeded and includes the gateway key.
 
## Version 4.0.1
_Release date: 2015.10.13_

## Bug Fixes
* Fix Dataset class names which had "Table" removed from them. 
    * AzureSqlDataWarehouseDataset → AzureSqlDataWarehouseTableDataset
    * AzureSqlDataset → AzureSqlTableDataset
    * AzureDataset → AzureTableDataset
    * OracleDatabaseDataset → OracleTableDataset
    * RelationalDataset → RelationalTableDataset
    * SqlServerDataset → SqlServerTableDataset
    * For types such as AzureSqlTable, "AzureSqlTableDataset" is the correct naming, not "AzureSqlDataset". These were the names prior to 4.0.0 and this restores those names. 

## Version 4.0.0
_Release date: 2015.10.02_

### Breaking Changes
    
* Send requests with API version 2015-10-01.
    * List API calls return paged results. If the response contains a non-empty NextLink property, the client application needs to continue fetching the next page until all pages are returned.
    * List pipeline API call returns only the summary of a pipeline instead of full details. For instance, activities in a pipeline summary only contain name and type.
* ITableOperations → IDatasetOperations 
* Models.Table → Models.Dataset
* Models.TableProperties → Models.DatasetProperties
* Models.TableTypeProprerties → Models.DatasetTypeProperties
* Models.TableCreateOrUpdateParameters → Models.DatasetCreateOrUpdateParameters
* Models.TableCreateOrUpdateResponse → Models.DatasetCreateOrUpdateResponse
* Models.TableGetResponse → Models.DatasetGetResponse
* Models.TableListResponse → Models.DatasetListResponse
* Models.CreateOrUpdateWithRawJsonContentParameters.cs → Models.DatasetCreateOrUpdateWithRawJsonContentParameters.cs

### Feature Additions
* Add SliceIdentifierColumnName and SqlWriterCleanupScript to support idempotent copy to SQL Data Warehouse.
* Add stored procedure support for both SQL and SQL Data Warehouse source. 


## Version 3.0.0
_Release date: 2015.08.29_

### Breaking Changes
* Send requests with API version 2015-09-01.
    * Impose message size limits for Linked Service, Dataset and Pipeline create requests. 
        * 200 KB limit is set for Pipelines. 
        * 30 KB limit is set for all other resources, e.g. Linked Service and Datasets.     
    * Does not accept copy-related properties removed in version 2.0.0 for create requests. 
* Remove Database and Schema properties from TeradataLinkedService. 

### Feature Additions
* New Activity type: AzureMLBatchExecutionActivity. 
    * Supports all configuration options for an Azure Machine Learning model. 
* Add Recursive property to BlobSource and FileSystemSource. 


## Version 2.0.1
_Release date: 2015.08.01_

### Bug Fixes
* Do not throw on errors during deserialization of service responses.  


## Version 2.0.0
_Release date: 2015.08.01_

### Breaking Changes
* Send requests with API version 2015-08-01. 
* Add required property BatchUri to AzureBatchLinkedService. 
* Remove unused copy-related properties from objects. 
    * From BlobSource: BlobColumnSeparators and NullValues
    * From AzureTableSink: AzureTableRetryIntervalInSec and AzureTableRetryTimes 
    * From BlobSink: BlockWriterBlockSize, BlobWriterPartitionColumns, BlobWriterPartitionFormat, BlobWriterSeparator and BlobWriterRowSuffix 
    * From CopySink: SinkPartitionData 
* Change the IDotNetActivity Execute method to take a collection of Linked Services, a collection of Tables and an Activity. 
    * The Tables collection contains all Tables referenced by the Activity. 
    * The Linked Services collection contains all the Linked Services referenced by the activity and the Tables.
* Remove Published property from TableProperties. 

### Feature Additions
* Add support for SQL Data Warehouse. 
    * Add AzureSqlDataWarehouseLinkedService, AzureSqlDataWarehouseTableDataset, SqlDWSource and SqlDWSink.


## Version 1.0.2
_Release date: 2015.07.27_

### Bug Fixes

* Return null when deserializing unknown nested polymorphic types, rather than throw an exception.
* Preserve the case of dictionary keys during serialization. 


## Version 1.0.1
_Release date: 2015.07.11_

### Bug Fixes

* Fix to initializing DataFactoryManagementClient with a delegating handler. 


## Version 1.0.0
_Release date: 2015.07.10_

### Breaking Changes

* Send requests with API version 2015-07-01-preview. 
* Modifies the class structure (and corresponding JSON payload) for Linked Services, Tables and Activities. 
    * The new TypeProperties element contains type specific properties for a linked service/table/activity. 
    * For Tables:
       * Move LinkedServiceName from Location to TableProperties.
       * Remove Location and the type specific properties such as TableName that were specified in the location section are specified in the TableTypeProperties.
    * For Activities:
       * Replace Transformation with the TypeProperties, of type ActivityTypeProperties.
* Update the names of all Linked Service, Table and Activity types. 
* Remove WaitOnExternal from Availability. 
    * Add property External property to TableProperties.
    * Add the properties of WaitOnExternal such as RetryInterval to optional property ExternalData in Policy.

### Feature Additions

* Add IDotNetActivity interface for implementing a custom C# activity.
* Add CopyBehavior property for BlobSink. 
* Add FileSystemSink for data output to on-premises file shares. 
