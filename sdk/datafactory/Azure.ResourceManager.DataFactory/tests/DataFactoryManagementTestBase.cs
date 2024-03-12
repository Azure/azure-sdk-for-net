// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Expressions.DataFactory;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests
{
    public class DataFactoryManagementTestBase : ManagementRecordedTestBase<DataFactoryManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected DataFactoryManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            JsonPathSanitizers.Add("$.keys.[*].value");
        }

        protected DataFactoryManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            JsonPathSanitizers.Add("$.keys.[*].value");
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(string rgName, AzureLocation location)
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<DataFactoryResource> CreateDataFactory(ResourceGroupResource resourceGroup, string dataFactoryName)
        {
            DataFactoryData data = new DataFactoryData(AzureLocation.WestUS2);
            var dataFactory = await resourceGroup.GetDataFactories().CreateOrUpdateAsync(WaitUntil.Completed, dataFactoryName, data);
            return dataFactory.Value;
        }

        protected async Task<DataFactoryLinkedServiceResource> CreateLinkedService(DataFactoryResource dataFactory, string linkedServiceName, string accessKey)
        {
            AzureBlobStorageLinkedService azureBlobStorageLinkedService = new AzureBlobStorageLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromLiteral($"{accessKey}")
            };
            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(azureBlobStorageLinkedService);
            var linkedService = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            return linkedService.Value;
        }

        protected async Task<string> GetStorageAccountAccessKey(ResourceGroupResource resourceGroup, string storageAccountName)
        {
            StorageAccountCreateOrUpdateContent data = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardLrs), StorageKind.BlobStorage, AzureLocation.WestUS2)
            {
                AccessTier = StorageAccountAccessTier.Hot,
            };
            var storage = await resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, storageAccountName, data);
            var key = await storage.Value.GetKeysAsync().FirstOrDefaultAsync(_ => true);
            return key.Value;
        }

        protected async Task<DataFactoryLinkedServiceResource> CreateAzureDBLinkedService(DataFactoryResource dataFactory, string linkedServiceName, string connectionString)
        {
            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(new AzureSqlDatabaseLinkedService(DataFactoryElement<string>.FromSecretString(connectionString)));
            var linkedService = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            return linkedService.Value;
        }

        protected async Task<DataFactoryDatasetResource> CreateAzureDBDataSet(DataFactoryResource dataFactory, string dataSetName, string linkedServiceName, string tableName)
        {
            DataFactoryLinkedServiceReference dataFactoryLinkedServiceReference = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceKind.LinkedServiceReference, linkedServiceName);
            DataFactoryDatasetData dataFactoryDatasetData = new DataFactoryDatasetData(new AzureSqlTableDataset(dataFactoryLinkedServiceReference)
            {
                Table = tableName,
                SchemaTypePropertiesSchema = DataFactoryElement<string>.FromLiteral("dbo"),
                Schema = new List<DatasetSchemaDataElement>()
                {
                    new DatasetSchemaDataElement(){ SchemaColumnName = "SampleId",SchemaColumnType="int"},
                    new DatasetSchemaDataElement(){ SchemaColumnName = "SampleDetail",SchemaColumnType="varchar"}
                }
            });

            var dataSet = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, dataSetName, dataFactoryDatasetData);
            return dataSet.Value;
        }

        protected async Task<DataFactoryPipelineResource> CreateCopyDataPipeline(DataFactoryResource dataFactory, string pipelineName, string dataSetAzureSqlSource, string dataSetAzureSqlSink, string dataSetAzureStorageSource, string dataSetAzureStorageSink, string dataSetAzureGen2Source, string dataSetAzureGen2Sink)
        {
            DataFactoryPipelineData pipelineData = new DataFactoryPipelineData()
            {
                Activities =
                {
                    new CopyActivity("TestAzureSQL",new AzureSqlSource()
                        {
                            SourceRetryCount = 10,
                            QueryTimeout = "02:00:00"
                        }, new AzureSqlSink())
                    {
                        State = PipelineActivityState.Active,
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,dataSetAzureSqlSource)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,dataSetAzureSqlSink)
                        }
                    },
                    new CopyActivity("TestAzureBlob",new DelimitedTextSource(), new DelimitedTextSink())
                    {
                        State = PipelineActivityState.Active,
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,dataSetAzureStorageSource)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,dataSetAzureStorageSink)
                        }
                    },
                    new CopyActivity("TestAzureGen2",new DelimitedTextSource(), new DelimitedTextSink())
                    {
                        State = PipelineActivityState.Active,
                        Inputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,dataSetAzureGen2Source)
                        },
                        Outputs =
                        {
                            new DatasetReference(DatasetReferenceType.DatasetReference,dataSetAzureGen2Sink)
                        }
                    }
                }
            };
            var pipeline = await dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, pipelineData);
            return pipeline.Value;
        }

        protected async Task<DataFactoryLinkedServiceResource> CreateAzureBlobStorageLinkedService(DataFactoryResource dataFactory, string linkedServiceName, string accessKey)
        {
            AzureBlobStorageLinkedService azureBlobStorageLinkedService = new AzureBlobStorageLinkedService()
            {
                ConnectionString = DataFactoryElement<string>.FromSecretString(accessKey)
            };
            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(azureBlobStorageLinkedService);
            var linkedService = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            return linkedService.Value;
        }

        protected async Task<DataFactoryLinkedServiceResource> CreateAzureDataLakeGen2LinkedService(DataFactoryResource dataFactory, string linkedServiceName, string accessKey)
        {
            AzureBlobFSLinkedService azureDataLakeGen2LinkedService = new AzureBlobFSLinkedService()
            {
                AccountKey = accessKey,
                Uri = "https://testazuresdkstoragegen2.dfs.core.windows.net/"
            };
            DataFactoryLinkedServiceData data = new DataFactoryLinkedServiceData(azureDataLakeGen2LinkedService);
            var linkedService = await dataFactory.GetDataFactoryLinkedServices().CreateOrUpdateAsync(WaitUntil.Completed, linkedServiceName, data);
            return linkedService.Value;
        }

        protected async Task<DataFactoryDatasetResource> CreateAzureBlobStorageDataSet(DataFactoryResource dataFactory, string dataSetName, string linkedServiceName)
        {
            DataFactoryLinkedServiceReference dataFactoryLinkedServiceReference = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceKind.LinkedServiceReference, linkedServiceName);
            DataFactoryDatasetData dataFactoryDatasetData = new DataFactoryDatasetData(new DelimitedTextDataset(dataFactoryLinkedServiceReference)
            {
                Schema = new List<DatasetSchemaDataElement>()
                {
                    new DatasetSchemaDataElement(){ SchemaColumnName = "Id",SchemaColumnType="String"},
                    new DatasetSchemaDataElement(){ SchemaColumnName = "Content",SchemaColumnType="String"}
                },
                DataLocation = new AzureBlobStorageLocation()
                {
                    Container = "testcontainer",
                    FileName = "TestData.csv"
                },
                ColumnDelimiter = ",",
                FirstRowAsHeader = true
            });

            var dataSet = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, dataSetName, dataFactoryDatasetData);
            return dataSet.Value;
        }

        protected async Task<DataFactoryDatasetResource> CreateAzureDataLakeGen2DataSet(DataFactoryResource dataFactory, string dataSetName, string linkedServiceName)
        {
            DataFactoryLinkedServiceReference dataFactoryLinkedServiceReference = new DataFactoryLinkedServiceReference(DataFactoryLinkedServiceReferenceKind.LinkedServiceReference, linkedServiceName);
            DataFactoryDatasetData dataFactoryDatasetData = new DataFactoryDatasetData(new DelimitedTextDataset(dataFactoryLinkedServiceReference)
            {
                Schema = new List<DatasetSchemaDataElement>()
                {
                    new DatasetSchemaDataElement(){ SchemaColumnName = "Id",SchemaColumnType="String"},
                    new DatasetSchemaDataElement(){ SchemaColumnName = "Content",SchemaColumnType="String"}
                },
                DataLocation = new AzureBlobStorageLocation()
                {
                    Container = "testcontainer",
                    FileName = "TestData.csv",
                    FolderPath = "testfolder"
                },
                ColumnDelimiter = ",",
                FirstRowAsHeader = true
            });

            var dataSet = await dataFactory.GetDataFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, dataSetName, dataFactoryDatasetData);
            return dataSet.Value;
        }
    }
}
